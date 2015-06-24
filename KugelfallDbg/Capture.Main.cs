using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KugelfallDbg
{
    public partial class Main
    {
        /*
         NewFrame-Event:
         * Signalisiert, dass ein neuer Frame aus der asynchronen Quelle zur Verarbeitung vorliegt.
         */
        void m_asyncvideo_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            //Das Bufferflag verhindert das während der Verarbeitung der Bilder bzw. der Eintragung des Versuches
            //noch Frames ankommen und vorhandene Bilder evtl. überschreiben

            if (m_bBuffer) 
            {
                m_ImageTime[m_sIndex] = Stoptimer.Time;   //Zeitstempel des Bildes machen

                //Dispose nötig, da sonst der GarbageCollector die alten Frames zu spät entfernen und damit
                //zu einem Überlauf des Arbeitsspeichers führen könnte
                if (m_bImageBuffer[m_sIndex] != null) { m_bImageBuffer[m_sIndex].Dispose(); }

                m_bImageBuffer[m_sIndex] = (Bitmap)eventArgs.Frame.Clone();
                m_sIndex = (m_sIndex + 1) % m_iBufferSize;  //Ringpuffer weiterschalten
            }
        }

        /* long Duration: Dauer des Samplepakets
         * long EndTime: Zeit nach dem Aufnahmeprozess
         * long RaisedSample: Sample mit dem Aufschlag
         * long Samples: Anz. der Samples (evtl. nicht nötig, sollte konstant sein)
        */
        private long CalculateOptimalPictureTime(long _Duration, long _EndTime, long _RaisedSample, long _Samples)
        {
            float SampleTime = (float)_Duration / (float)_Samples;  //Zeit die ein Sample benötigt
            float TimeImpact = SampleTime * (float)_RaisedSample;   //Berechnung der Aufschlagszeit

            return _EndTime - _Duration + (long)TimeImpact; //Zeit des angekommenen Samplepakets - Dauer + Aufschlagszeit
        }

        void m_Audio_ThresholdExceeded(object sender, long _Duration, long _EndTime, long _RaisedSample, int _Samples)
        {
            if (m_bInProgress == false)
            {
                int Index = m_sIndex;

                m_bInProgress = true;

                System.Threading.Thread.Sleep(50);  //Thread kurz pausieren, damit andere Threads (Video, Arduino) noch ihre Arbeit erledigen können
                SetBuffering(false);

                ActivateAudio(false);

                bool bBufferReady = false;

                //Prüfen, ob der Buffer bereits gefüllt ist
                if (bBufferReady == false)
                {
                    bool bReady = true;
                    foreach (Bitmap b in m_bImageBuffer)
                    {
                        if (b == null)
                        {
                            bReady = false;
                        }
                    }
                    if (bReady == true)
                    {
                        bBufferReady = true;
                    }
                }

                if (bBufferReady)
                {
                    long lImageTime = CalculateOptimalPictureTime(_Duration, _EndTime, _RaisedSample, _Samples);    //Idealzeit berechnen
                    lImageTime += m_iIndexOffset;               //Versatz zwischen Audio und Video berücksichtigen
                    int PictureIndex = LookupFrame(lImageTime); //Frame im Buffer suchen

                    if (m_bSdW == true)
                    {
                        SpD spd = new SpD(ref m_bImageBuffer, ref m_ImageTime, PictureIndex, _EndTime, lImageTime, _Duration); 
                        spd.ShowDialog();
                    }

                    CaptureImage(PictureIndex); //Bilder eintragen
                }
                else { MessageBox.Show("Der Buffer ist noch nicht bereit"); }

                //Aufnahme wieder erlauben
                ActivateAudio(true);
                SetBuffering(true);
                ActivateCamera(true);
                m_bInProgress = false;
            }
        }

        /// <summary>
        /// Sucht nach dem passenden Frame in Abhängigkeit von der Zeit. Gesucht wird nach der geringsten Differenz
        /// </summary>
        /// <param name="_fFrameTime"></param>
        /// <returns></returns>
        private int LookupFrame(long _lFrameTime)
        {
            int iBestIndex = -1;
            long iMinimalDifference = -1;

            for (int i = m_sIndex - 1; i != m_sIndex; i--)
            {
                if (i < 0) { i = m_iBufferSize - 1; }   //Ungültigen Index vermeiden
                if (Math.Abs(m_ImageTime[i] - _lFrameTime) <= iMinimalDifference || iMinimalDifference == -1)
                {
                    iBestIndex = i;
                    iMinimalDifference = Math.Abs(m_ImageTime[i] - _lFrameTime);
                }

                if (i == 0) { i = m_iBufferSize; }
            }

            return iBestIndex;
        }

        /**
         * void CaptureImage():
         * CaptureImage deaktiviert kurzzeitig das Audiosignal, um nicht während
         * des Bildaufnahmeprozesses auf weitere Schwellüberschreitungen zu reagieren.
        */
        private void CaptureImage(int _PictureStart)
        {
            int _iBilder = 6;

            Bitmap[] _Frames = new Bitmap[_iBilder];

            //Auf den Index des idealen Frames setzen und Verschiebung des Offsets beachten
            //_PictureStart += m_iIndexOffset;

            //Korrektur des Index nach Addition des Offsets um nicht außerhalb der Buffergröße zu sein
            if (_PictureStart >= m_iBufferSize)
            {
                _PictureStart -= m_iBufferSize;
            }

            //Berechnung: Der Index auf den der Indexzeiger ist - die zu puffernden Bilder - 1 damit auch an der Stelle Index das Bild kopiert wird
            _PictureStart -= _iBilder;

            //Für den Fall, das Index bei bspw. 0 war und nach Abzug des Obigen ein negativer Startindex vorhanden ist
            if (_PictureStart < 0)
            {
                _PictureStart = m_iBufferSize - Math.Abs(_PictureStart) + 1;
            }

            for (int i = 0; i < _iBilder; i++, _PictureStart++)
            {
                if (_PictureStart == m_iBufferSize) { _PictureStart = 0; }
                _Frames[i] = (Bitmap)m_bImageBuffer[_PictureStart].Clone();
            }

            Versuchsbild v = new Versuchsbild(_iBilder);

            v.Test = "Versuch " + m_iAnzVersuche;   //Versuchsbeschreibung dient zur Identifizierung im Dictionary (m_Versuche)
            v.Pictures = (Bitmap[])_Frames.Clone();

            //Arduinodaten abgreifen
            if (Arduino.IsOpen() == true && Arduino.IsSet)
            {
                v.Debugtext = Arduino.DebugText;
                Arduino.DebugText = string.Empty;
            }

            m_Versuche.Add(v.Test, v);

            //Versuch eintragen
            ListViewItem lvi = new ListViewItem();
            for (int i = 0; i < m_iListViewColumns; i++)
            {
                lvi.SubItems.Insert(i, new ListViewItem.ListViewSubItem());
            }

            lvi.SubItems[m_iTestIndex] = new ListViewItem.ListViewSubItem(lvi, v.Test.Remove(0, 8));
            lvi.SubItems[m_iDeviationIndex] = new ListViewItem.ListViewSubItem(lvi, v.Deviation.ToString());

            string LVDebugtext = v.Debugtext.Replace("\r\n", "|");  //\r\n kann nicht im Listview dargestellt werden (evtl. Blanks sichtbar)
            lvi.SubItems[m_iArduinoDebugIndex] = new ListViewItem.ListViewSubItem(lvi, LVDebugtext);
            lvi.SubItems[m_iCommentIndex] = new ListViewItem.ListViewSubItem(lvi, v.Comment);
            lvi.SubItems[m_iSuccessIndex] = new ListViewItem.ListViewSubItem(lvi, string.Empty);
            LVTestEvaluation.Items.Add(lvi);

            m_iAnzVersuche++;
        }
    }
}
