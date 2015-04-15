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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            m_Versuche = new Dictionary<string, Versuchsbild>();
            m_bImageBuffer = new Bitmap[m_iBufferSize];
            this.LVTestEvaluation.LostFocus += LVTestEvaluation_LostFocus;
        }

        void LVTestEvaluation_LostFocus(object sender, EventArgs e)
        {
            LVTestEvaluation.SelectedItems.Clear();
            LVTestEvaluation.Update();
        }

        ~Main()
        {
            //Sicherstellen, dass alles heruntergefahren wird
            Shutdown();
        }

        private void MenuDateiKamEinstellungen_Click(object sender, EventArgs e)
        {
            CamSettings();
        }

        /**
         * NewFrame-Event: Schreibt in den Imagebuffer um Bilder (im Falle einer Schwellenüberschreitung der Lautstärke) zur Besichtigung parat zu haben
         */
        private short m_sIndex = 0;         ///Dient also "Zeiger" in der Buffervariable (maximal m_iBufferSize Bilder)
        private void MainVideoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            if (m_bBuffer)
            {
                if (m_bImageBuffer[m_sIndex] != null) { m_bImageBuffer[m_sIndex].Dispose(); }

                m_bImageBuffer[m_sIndex] = (Bitmap)image.Clone();

                if (m_sIndex == m_iBufferSize - 1) { m_sIndex = 0; }
                else { m_sIndex++; }
            }
        }

        private int CalculateOptimalPicture()
        {
            //Nicht mehr verwendet
            //Frames: (Bufferdelay + maxsample_delay)/fpsdelay [aufgerundet]
            //(Der Aufnahmebuffer + Die Zeit bis zum Auslösesample)/Delay zwischen den einzelnen Frames

            if (m_iCurrentFPS == 0) { return 0; }
            float fpsdelay = (float)(1000 / m_iCurrentFPS);    //Bspw. 10 FPS == 1000ms (1s) / 10 = 100ms pro Frame
            float Bufferdelay = (float)(m_Audio.BufferMilliseconds);

            double Frames = (Bufferdelay + m_fMaxSampleDelay) / fpsdelay;
            Frames = Math.Round(Frames, MidpointRounding.AwayFromZero);

            return (int)Frames;
        }

        private void SetBuffering(bool _bBuffer)
        {
            m_bBuffer = _bBuffer;
        }

        private bool m_bBuffer = true;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit();
            ActivateCamera(false);
            ActivateAudio(false);
            m_Camera = null;
        }

        //Sämtliche Videoquellen abschalten
        private void CloseVideoSource()
        {
            if (m_Camera.GetCamera.IsRunning == true)
            {
                MainVideoSourcePlayer.SignalToStop();
                MainVideoSourcePlayer.WaitForStop();
            }
        }

        private void MenuDateiBeenden_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Sämtliche Video-/Audioquellen deaktivieren und Programm beenden
        private void Exit()
        {
            AForge.Video.IVideoSource vSource = MainVideoSourcePlayer.VideoSource;

            if (vSource != null)
            {
                CloseVideoSource();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TBTresholdControl.Maximum = PBVolumeMeter.Maximum;

            //Evtl. vorhandene Geräte eintragen
            CheckSettings();
        }

        /**
         * void CheckSettings():
         * Prüfen, ob evtl. bereits vorhandene Geräte vorliegen 
         */
        private void CheckSettings()
        {
            //Kamera abfragen
            if (string.IsNullOrEmpty(Properties.Settings.Default.VideoDevice) == false)
            {
                if (m_Camera == null)
                {
                    m_Camera = new Camera(new AForge.Video.DirectShow.VideoCaptureDevice(Properties.Settings.Default.VideoDevice));
                    MainVideoSourcePlayer.VideoSource = m_Camera.GetCamera;
                    TSLblCameraActive.Text = m_sCameraChosen;
                }
            }

            //Audio abfragen
            if (string.IsNullOrEmpty(Properties.Settings.Default.VideoDevice) == false)
            {
                if (m_Audio == null)
                {
                    m_Audio = new Audio(Properties.Settings.Default.AudioDevice);
                    TSLblAudioActive.Text = m_sAudioChosen;
                }

                m_Audio.NewMaxSample += m_Audio_NewMaxSample;
                m_Audio.ThresholdExceeded += m_Audio_ThresholdExceeded;
            }

            //Arduino abfragen
            if (string.IsNullOrEmpty(Properties.Settings.Default.ArduinoPort) == false)
            {
                if (Arduino.RS232Port == null) { Arduino.RS232Port = new System.IO.Ports.SerialPort(); }

                Arduino.SetParameters(Properties.Settings.Default.ArduinoBaudRate, Properties.Settings.Default.ArduinoPort);

                if (Arduino.OpenPort() == true)
                {
                    Arduino.IsSet = true;
                    TSLblArduino.Text = m_sArduinoChosen;
                }
                else
                {
                    Properties.Settings.Default.ArduinoBaudRate = 0;
                    Properties.Settings.Default.ArduinoPort = string.Empty;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private bool m_bInProgress = false;

        void m_Audio_ThresholdExceeded(object sender, float fSample)
        {
            if (m_bInProgress == false)
            {
                m_bInProgress = true;
                SetBuffering(false);

                //ActivateCamera(false);
                ActivateAudio(false);

                bool bBufferReady = true;

                //Prüfung, ob der Buffer bereits gefüllt ist
                foreach (Bitmap b in m_bImageBuffer)
                {
                    if (b == null)
                    {
                        bBufferReady = false;
                    }
                }

                if (bBufferReady)
                {
                    CaptureImage();
                }
                else { MessageBox.Show("Der Buffer ist noch nicht bereit"); }

                //Aufnahme wieder erlauben
                ActivateAudio(true);
                SetBuffering(true);
                ActivateCamera(true);
                m_bInProgress = false;
            }
        }

        void m_Audio_NewMaxSample(object sender, float MaxSample)
        {
            PBVolumeMeter.Value = (int)(MaxSample);
        }

        //Dient zum Öffnen der Videoquelle
        private void OpenVideoSource()
        {
            MainVideoSourcePlayer.Start();
            TSLblCameraActive.Text = m_sCameraOn;
        }

        private Camera m_Camera;

        private void TSBtnActivateCam_Click(object sender, EventArgs e)
        {
            if (m_Camera != null && m_Audio != null)// && Arduino.IsSet == true)
            {
                if (m_Camera.GetCamera.IsRunning == false)
                {
                    ActivateCamera(true);
                    ActivateAudio(true);

                    TBTresholdControl.Value = (int)Math.Round((float)(PBVolumeMeter.Maximum * 3f / 4f), MidpointRounding.ToEven);

                    TSBtnCamSettings.Enabled = false;
                    TSBtnArduinoSettings.Enabled = false;
                    TSBtnAudioConfiguration.Enabled = false;
                    TSBtnActivateCam.Enabled = false;
                    TSBtnDeactivateCam.Enabled = true;
                }
                if (Arduino.IsSet == true && Arduino.IsOpen() == false)
                {
                    Arduino.OpenPort();
                }
            }
            else
            {
                MessageBox.Show("Bitte stellen Sie sicher, dass eine Kamera und ein Audiogerät ausgewählt wurden", "Nicht alle Geräte festgelegt", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }

        /**
         * void ActivateAudio(bool _bActivate):
         * 
         */
        private void ActivateAudio(bool _bActivate)
        {
            if (m_Camera != null && m_Audio != null)   //Eine Kamera sowie ein Audiogerät muss unbedingt vorhanden sein
            {
                try
                {
                    if (_bActivate == true)
                    {
                        m_Audio.StartRecording();
                        TSLblAudioActive.Text = m_sAudioOn;
                    }
                    else
                    {
                        m_Audio.StopRecording();
                    }
                }
                finally { }
            }
        }

        /**
         * void CamSettings():
         * Ruft den Dialog zur Einstellung der verwendeten Kamera auf.
         * Eingestellt werden können: Kamera, Auflösung
         */
        private void CamSettings()
        {
            AForge.Video.DirectShow.VideoCaptureDeviceForm vcdf = new AForge.Video.DirectShow.VideoCaptureDeviceForm();

            if (vcdf.ShowDialog() == System.Windows.Forms.DialogResult.OK)  //Kamera wurde ausgewählt
            {
                //Falls aktive Kamera bereits vorhanden, diese löschen
                ActivateAudio(false);

                if (m_Camera != null)
                {
                    m_Camera = null;
                }

                //Videoquelle erstellen
                m_Camera = new Camera(vcdf.VideoDevice);
                
                Properties.Settings.Default.VideoDevice = vcdf.VideoDeviceMoniker;  //Gerätebezeichner abspeichern
                Properties.Settings.Default.Save();

                MainVideoSourcePlayer.VideoSource = vcdf.VideoDevice;
                TSLblCameraActive.Text = m_sCameraChosen;
            }
        }

        /**
         * private Bitmap CombineImages(Versuchsbild _v):
         * Kombiniert die gemachten Bilder eines Versuches, um sie alle 
         * gleichzeitig in einem 2x6-Feld darzustellen
         */
        private Bitmap CombineImages(Versuchsbild _v)
        {
            Bitmap b = null;
            
            int width = 0, height = 0;

            for (int i = 0; i < 3; i++)
            {
                width += _v.Pictures[i].Width;
            }

            //Die Bilder die gemacht werden haben einheitliche Größe
            height = _v.Pictures[0].Height * 2;

            b = new Bitmap(width, height);

            //Graphisches Objekt anfordern um darauf die Bilder zu zeichnen
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(b);
            {
                //Hintergrundfarbe
                g.Clear(System.Drawing.Color.Transparent);

                //Jedes Bild auf das Grafikobjekt zeichnen
                int offset = 0;
                for (int i = 0, y = 0; i < _v.Pictures.Length;i++ )
                {
                    if (i == 3) { y++; offset = 0; }    //Nach 3 Bildern erfolgt ein "Zeilenumbruch" (Die zweite Zeile wird mit Bildern gefüllt
                    g.DrawImage(_v.Pictures[i], new System.Drawing.Rectangle(offset, y * _v.Pictures[i].Height, _v.Pictures[i].Width, _v.Pictures[i].Height));
                    offset += _v.Pictures[i].Width;
                }
            }

            return b;
        }

        //Je nach Zustand wird die Kamera ein- oder ausgeschaltet
        private void ActivateCamera(bool _bActivate)
        {
            if (m_Camera != null && m_Audio != null)
            {
                if (_bActivate == true)
                {
                    //Videoquelle öffnen
                    OpenVideoSource();

                    //Buttontoolstrip
                    TSBtnActivateCam.Image = KugelfallDbg.Properties.Resources.Video;

                    //Statuslabel
                    TSLblCameraActive.Text = m_sCameraOn;
                }
                else
                {
                    CloseVideoSource();

                    TSLblCameraActive.Text = m_sCameraOff;
                }
            }
        }

#region CSV Export Button
        private void TSBtnExportCSV_Click(object sender, EventArgs e)
        {
            ExportCSV();
        }

        private void MenuDatenCSVExport_Click(object sender, EventArgs e)
        {
            ExportCSV();
        }
#endregion

        /**
         * void DeletePictures():
         * Dient dem Löschen sämtlicher Versuchsdaten.
         */
        private void DeletePictures()
        {
            if (MessageBox.Show("Möchten Sie wirklich alle Versuchsdaten löschen?", "Versuchsdaten löschen", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                LVTestEvaluation.Items.Clear();
                m_Versuche.Clear();
            }
        }

        #region CSVExport-Methode
        /**
         * void ExportCSV(): 
         * Diese Methode exportiert alle vorhandenen Versuchsdaten als CSV-Datei.
         */
        private void ExportCSV()
        {
            if (LVTestEvaluation.Items.Count == 0)  //Keine Auswertungen vorhanden
            {
                MessageBox.Show("Es sind keine Versuchsdaten vorhanden, die als CSV exportiert werden könnten.", "Fehler beim CSV-Export",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                //Speicherort
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV-Datei|*.csv";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName);

                    //CSV Header erstellen
                    for (int i = 0; i < LVTestEvaluation.Columns.Count; i++)
                    {
                        sw.Write(LVTestEvaluation.Columns[i].Text);

                        if ((i + 1) != LVTestEvaluation.Columns.Count)  //Prüfen, ob noch ein Separator gesetzt werden muss
                        {
                            sw.Write(";");
                        }
                    }
                    sw.Write("\n");

                    foreach (ListViewItem lvi in LVTestEvaluation.Items)
                    {
                        if(lvi.Checked == true)
                        {
                            sw.Write("Ja");
                        }
                        else
                        {
                            sw.Write("Nein");
                        }

                        //SubItems durchgehen und eintragen
                        for (int iSubItems = 1; iSubItems < lvi.SubItems.Count; iSubItems++)
                        {
                            sw.Write(";");

                            sw.Write(lvi.SubItems[iSubItems].Text);
                        }
                        sw.Write("\n");
                    }

                    sw.Close();
                }
            }
        }
        #endregion

        private void MenuDateiRS232_Click(object sender, EventArgs e)
        {
            ArduinoSettings();
        }

        /**
         * void ArduinoSettings():
         * Arduino Konfiguration
         */
        private void ArduinoSettings()
        {
            ArduinoConfig rs232 = new ArduinoConfig();

            if (Arduino.IsOpen() == true) {Arduino.ClosePort(); }
            if (rs232.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Arduino.OpenPort() == true)
                {
                    Arduino.ClosePort();

                    Arduino.IsSet = true;
                    TSLblArduino.Text = m_sArduinoChosen;

                    //Arduinoeinstellungen speichern
                    Properties.Settings.Default.ArduinoPort = string.Empty;

                    Properties.Settings.Default.ArduinoPort = Arduino.RS232Port.PortName;
                    Properties.Settings.Default.ArduinoBaudRate = Arduino.RS232Port.BaudRate;

                    Properties.Settings.Default.Save();
                }
            }
        }

        private void TSBtnCamSettings_Click(object sender, EventArgs e)
        {
            CamSettings();
        }

        /**
         * void CaptureImage():
         * CaptureImage deaktiviert kurzzeitig das Audiosignal, um nicht während
         * des Bildaufnahmeprozesses auf weitere Schwellüberschreitungen zu reagieren.
         * 
         * Todo: Die letzten Frames werden aus dem Bildspeicher geholt und die optimalen Bilder approximiert,
         * um somit der Aufnahmelatenz entgegenzuwirken und dem User die passenden Versuchsbilder zu liefern.
        */
        private void CaptureImage()
        {
            int _iBilder = 6;
            //int _iFramesBack = CalculateOptimalPicture();

            Bitmap[] _Frames = new Bitmap[_iBilder];

            //Auf das letztgemachte Bild setzen
            int _PictureStart = m_sIndex;
            
            /*DEBUGAUSGABEN*/
            ShowPicturesDebug s = new ShowPicturesDebug(ref m_bImageBuffer, _PictureStart);
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK) { }

            //Berechnung: Der Index auf den der Indexzeiger ist - die zu puffernden Bilder - 1 damit auch an der Stelle Index das Bild kopiert wird
            _PictureStart -= _iBilder;// - 1);

            //Für den Fall, das Index bei bspw. 0 war und nach Abzug des Obigen ein negativer Startindex vorhanden ist
            if (_PictureStart < 0)
            {
                _PictureStart = m_iBufferSize - Math.Abs(_PictureStart);
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

            //OK,Versuch,Versatz,Geschwindigkeit,Kommentar
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add(v.Test.Remove(0, 8));
            lvi.SubItems.Add(v.Deviation.ToString());
            lvi.SubItems.Add(v.Debugtext);
            lvi.SubItems.Add(v.Comment);

            LVTestEvaluation.Items.Add(lvi);

            m_iAnzVersuche++;

            //Ressourcen freigeben
            //foreach (Bitmap b in _Frames) { b.Dispose(); }
                
        }

        //Jeder Versuch wird in einer Map abgespeichert und ist eindeutig identifizierbar über einen String und einer Versuchsklasse
        private System.Collections.Generic.Dictionary<string, Versuchsbild> m_Versuche;
        private int m_iAnzVersuche = 1;

        private void LVVersuchsauswertung_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvi = LVTestEvaluation.SelectedItems[0];
            string key = "Versuch " + lvi.SubItems[1].Text;//(lvi.Index + 1).ToString();

            Versuchsbild temp = GetSelectedItem();
            FormVersuch fv = new FormVersuch(ref temp);
            DialogResult dr = fv.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                m_Versuche[key] = temp;

                //Itemupdate
                m_bAutoCheck = false;
                lvi.Checked = temp.Success;
                m_bAutoCheck = true;
                lvi.SubItems[2].Text = temp.Deviation.ToString();
                lvi.SubItems[3].Text = temp.Debugtext;
                lvi.SubItems[4].Text = temp.Comment;
            }
        }

        /**
         * Das gewählte ListviewItem (also ein Versuch) wird gesucht und zurückgegeben
         */
        private Versuchsbild GetSelectedItem()
        {
            ListViewItem lvi = LVTestEvaluation.SelectedItems[0];

            string key = "Versuch " + lvi.SubItems[1].Text;

            return m_Versuche[key];
        }

        /**
         * Ein Item (also ein Versuch) wurde aus der Liste ausgewählt. Um diesen bearbeiten zu können,
         * wird ein Dialog aufgerufen
        */
        private void LVTestEvaluation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Audio deaktivieren
            ActivateAudio(false);

            MainVideoSourcePlayer.Visible = false;

            //Item wurde ausgewählt --> Ausgewähltes Bild auf Livebild übertragen
            if (LVTestEvaluation.SelectedItems.Count == 0)  //Vermeiden, dass ein Fehlklick zu einer Exception führt (OutOfRange)
            {
                for (int i = 0; i < LVTestEvaluation.Items.Count; i++)
                {
                    LVTestEvaluation.Items[i].Selected = false;
                }

                MainVideoSourcePlayer.Visible = true;

                pb_Images.Visible = false;
                TSBtnRemoveTest.Enabled = false;

                ActivateAudio(true);

                return;
            }
            else //Item ausgewählt
            {
                TSBtnRemoveTest.Enabled = true;

                Versuchsbild temp = GetSelectedItem();

                MainVideoSourcePlayer.Visible = false;
                pb_Images.Visible = true;
                pb_Images.Image = new Bitmap(CombineImages(temp), new Size(pb_Images.Width, pb_Images.Height));
            }
        }

        private void TSBtnArduinoSettings_Click(object sender, EventArgs e)
        {
            ArduinoSettings();
        }

        /**
         * TSBtnAudioConfiguration_Click:
         * Nach dem Klick auf den Button Audioeinstellungen wird die 
         * Audioaufnahme gestoppt und ein neues Gerät zugewiesen.
         */

        private void TSBtnAudioConfiguration_Click(object sender, EventArgs e)
        {
            FormAudioDevice fad = new FormAudioDevice();
            if (fad.ShowDialog() == DialogResult.OK)
            {
                if (m_Audio != null)
                {
                    ActivateAudio(false);

                    m_Audio = null;
                }

                m_Audio = new Audio(fad.SelectedDevice);
                m_Audio.NewMaxSample += m_Audio_NewMaxSample;
                m_Audio.ThresholdExceeded += m_Audio_ThresholdExceeded;
                TSLblAudioActive.Text = m_sAudioChosen;
            }
        }

        private void TSBtnDeleteAll_Click(object sender, EventArgs e)
        {
            DeletePictures();
        }

        /** void TSBtnDeleteTest_Click
         *  Dieses Event tritt ein, wenn ein Versuch gelöscht werden soll.
         */
        private void TSBtnDeleteTest_Click(object sender, EventArgs e)
        {
            //Vorausgesetzt Item wurde ausgewählt
            if (LVTestEvaluation.SelectedItems.Count == 0)  //Vermeiden, dass ein Fehlklick zu einer Exception führt (OutOfRange)
            {
                return;
            }

            ListViewItem lvi = LVTestEvaluation.SelectedItems[0];

            string key = "Versuch " + (lvi.Index + 1).ToString();

            if (MessageBox.Show("Möchten Sie diesen Versuch wirklich löschen?", "Versuch löschen", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                m_Versuche.Remove(key);
                LVTestEvaluation.Items.Remove(lvi);
            }
        }

        /**
         * void Shutdown():
         * Beendet sämtliche Aktivitäten 
         */
        private void Shutdown()
        {
            if (MainVideoSourcePlayer.IsRunning)
            {
                MainVideoSourcePlayer.SignalToStop();
                MainVideoSourcePlayer.WaitForStop();
            }
            if (m_Audio != null)
            {
                try { m_Audio.StopRecording(); }
                finally { m_Audio = null; }
            }
        }


        #region ListView: Versehentlichen CheckBox-Click vermeiden
        //Die Events MouseDown, MouseUp, ItemCheck dienen dem Zweck, dass nicht versehentlich der Versuch als OK bzw. nicht OK markiert wird
        private void LVTestEvaluation_MouseDown(object sender, MouseEventArgs e)
        {
            m_bAutoCheck = true;
        }

        private void LVTestEvaluation_MouseUp(object sender, MouseEventArgs e)
        {
            m_bAutoCheck = false;
        }

        private void LVTestEvaluation_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (m_bAutoCheck)
            {
                e.NewValue = e.CurrentValue;
            }
            else
            {
                ListViewItem lvi = LVTestEvaluation.Items[e.Index];

                string key = "Versuch " + lvi.SubItems[1].Text;//(lvi.Index + 1).ToString();

                Versuchsbild temp = m_Versuche[key];

                if(e.NewValue == CheckState.Checked)
                {
                    temp.Success = true;
                }
                else
                {
                    temp.Success = false;
                }

                m_Versuche[key] = temp;
            }
        }

        private bool m_bAutoCheck = false;
        #endregion

        private void Main_Click(object sender, EventArgs e)
        {
            LVTestEvaluation.SelectedItems.Clear();
        }

        private void TSBtnDeactivateCam_Click(object sender, EventArgs e)
        {
            if (m_Camera != null && m_Audio != null && m_Camera.GetCamera.IsRunning)
            {
                ActivateCamera(false);
                ActivateAudio(false);

                if (Arduino.IsOpen() == true) { Arduino.ClosePort(); }

                TSBtnCamSettings.Enabled = true;
                TSBtnArduinoSettings.Enabled = true;
                TSBtnAudioConfiguration.Enabled = true;
                TSBtnActivateCam.Enabled = true;
                TSBtnDeactivateCam.Enabled = false;
            }
        }

        private Audio m_Audio;  //Audioaufnahmegerät

        private int m_iBufferSize = 30; //30 Bilder im Buffer halten
        private Bitmap[] m_bImageBuffer;

        //Textvariablen zur einheitlichen Beschriftung
        private string m_sArduinoChosen = "Arduino wurde ausgewählt";
        private string m_sAudioChosen = "Audiogerät wurde ausgewählt";
        private string m_sAudioOn = "Audio aktiviert";
        private string m_sCameraChosen = "Kamera wurde ausgewählt";
        private string m_sCameraOn = "Kamera eingeschaltet";
        private string m_sCameraOff = "Kamera ausgeschaltet";

        private int m_iCurrentFPS = 0;
        private float m_fMaxSampleDelay = 0.0f;

        private void TBTresholdControl_ValueChanged(object sender, EventArgs e)
        {
            if (TBTresholdControl.Value <= 5)
            {
                MessageBox.Show("Wert zu niedrig");
                m_Audio.Threshold = 15;
                TBTresholdControl.Value = 15;
            }
            else { m_Audio.Threshold = TBTresholdControl.Value; }
        }

        
    }
}
