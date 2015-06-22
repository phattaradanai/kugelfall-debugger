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
                //System.IO.File.AppendAllText("Samples.txt", _Samples.ToString());
                m_bInProgress = true;

                int WaitFrames = 2;

                /*while (WaitFrames != 0)
                {
                    //MessageBox.Show("Index: " + Index.ToString() + " m_sIndex: " + m_sIndex);
                    if (Index != m_sIndex)
                    {
                        WaitFrames--;
                        Index = m_sIndex;
                    }
                }*/
                SetBuffering(false);
                //MessageBox.Show("Exceed");

                //ActivateCamera(false);
                ActivateAudio(false);

                bool bBufferReady = false;

                //Prüfung, ob der Buffer bereits gefüllt ist
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
                    long lImageTime = CalculateOptimalPictureTime(_Duration, _EndTime, _RaisedSample, _Samples);
                    lImageTime += m_iIndexOffset;
                    int PictureIndex = LookupFrame(lImageTime);

                    if (m_bShowDebugWindow == true)
                    {
                        ShowPicturesDebug spd = new ShowPicturesDebug(ref m_bImageBuffer, ref m_ImageTime, PictureIndex, _EndTime, lImageTime, _Duration); 
                        spd.ShowDialog();
                    }

                    CaptureImage(PictureIndex);
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
        /// Sucht nach dem passenden Frame in Abhängigkeit von der Zeit
        /// </summary>
        /// <param name="_fFrameTime"></param>
        /// <returns></returns>
        private int LookupFrame(long _lFrameTime)
        {
            int iBestIndex = -1;
            long iMinimalDifference = -1;

            for (int i = m_sIndex - 1; i != m_sIndex; i--)
            {
                if (i < 0) { i = m_iBufferSize - 1; }
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

            if (Arduino.IsOpen() == true)
            {
                v.Debugtext = Arduino.DebugText;
            }

            m_Versuche.Add(v.Test, v);

            ListViewItem lvi = new ListViewItem();
            for (int i = 0; i < m_iListViewColumns; i++)
            {
                lvi.SubItems.Insert(i, new ListViewItem.ListViewSubItem());
            }

            lvi.SubItems[m_iTestIndex] = new ListViewItem.ListViewSubItem(lvi, v.Test.Remove(0, 8));
            lvi.SubItems[m_iDeviationIndex] = new ListViewItem.ListViewSubItem(lvi, v.Deviation.ToString());
            lvi.SubItems[m_iArduinoDebugIndex] = new ListViewItem.ListViewSubItem(lvi, v.Debugtext);
            lvi.SubItems[m_iCommentIndex] = new ListViewItem.ListViewSubItem(lvi, v.Comment);
            lvi.SubItems[m_iSuccessIndex] = new ListViewItem.ListViewSubItem(lvi, string.Empty);
            LVTestEvaluation.Items.Add(lvi);

            m_iAnzVersuche++;

            //Ressourcen freigeben
            //foreach (Bitmap b in _Frames) { b.Dispose(); }
        }
    }
}
