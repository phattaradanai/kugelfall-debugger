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
        private Audio m_Audio;  //Audioaufnahmegerät

        private int m_iBufferSize = 6;
        private Bitmap[] m_bImageBuffer;
        private bool m_bIsCapturing = false;    //Flag: Signalisiert, ob gerade ein Bild aufgenommen wurde
        private bool m_bTestAvailable = false;   //Versuch ist verfügbar

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
        private short m_sPassedFrames = 0;  ///Beinhaltet die Anzahl der bereits gemachten Bilder 
        private short m_sIndex = 0;         ///Dient also "Zeiger" in der Buffervariable (maximal m_iBufferSize Bilder)
                                            
        private void MainVideoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            if (Arduino.DataAvailable == true)
            {
                m_bStopBuffering = false;
                //(Nach wie vielen gemachten Bildern soll eines davon im Buffer abgelegt werden)?
                /*  Version 1
                if (m_sPassedFrames == 1)
                {
                    m_bImageBuffer[m_sIndex] = (Bitmap)image.Clone();   //Aktuelles Bild wird im Buffer abgelegt
                    m_sIndex++;
                    if (m_sIndex == m_iBufferSize) 
                    { 
                        m_sIndex = 0;
                        m_bTestAvailable = true; 
                        Arduino.DataAvailable = false;
                    }

                    m_sPassedFrames = 0;                                //zurücksetzen
                }
                else
                {
                    m_sPassedFrames++;
                }*/

                //Version 2:
                if (m_sPassedFrames == 0)
                {
                    m_bImageBuffer[m_sIndex] = (Bitmap)image.Clone();   //Aktuelles Bild wird im Buffer abgelegt
                    m_sIndex++;
                    if (m_sIndex == m_iBufferSize)
                    {
                        m_sIndex = 0;
                    }

                    if(m_bStopBuffering == true)
                    {
                        m_bTestAvailable = true;
                        Arduino.DataAvailable = false;
                    }

                    m_sPassedFrames = 0;                                //zurücksetzen
                }
                else
                {
                    m_sPassedFrames++;
                }
            }
        }

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
                MainVideoSourcePlayer.VideoSource.Stop();
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
            //ToDo: Prüfen ob eine Kamera vorhanden ist und bereits ausgewählt wurde
            TSLblThreshold.Text = "Schwellenwert: " + VolumeMeter.Threshold;

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
            }
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
            if (m_Camera != null && m_Audio != null && Arduino.IsSet == true)
            {
                if (m_Camera.GetCamera.IsRunning == false)
                {
                    ActivateCamera(true);
                    ActivateAudio(true);

                    TSBtnCamSettings.Enabled = false;
                    TSBtnArduinoSettings.Enabled = false;
                    TSBtnAudioConfiguration.Enabled = false;
                    TSBtnActivateCam.Enabled = false;
                    TSBtnDeactivateCam.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Bitte stellen Sie sicher, dass eine Kamera, ein Audiogerät und ein Arduino ausgewählt wurden", "Nicht alle Geräte festgelegt", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }

        /**
         * void ActivateAudio(bool _bActivate):
         * Aktiviert den AudioTimer, der regelmäßig den Lautstärkepegel
         * aktualisiert und prüft, ob die gerade eingetroffenen Samples
         * den Schwellwert überschreiten.
         */
        private void ActivateAudio(bool _bActivate)
        {
            if (m_Camera != null && m_Audio != null)   //Eine Kamera sowie ein Audiogerät muss unbedingt vorhanden sein
            {
                if (_bActivate == true)
                {
                    TimerAudio.Enabled = true;
                    TimerAudio.Start();
                    m_Audio.StartRecording();
                    //TSLblVolume.Visible = true;
                    TSLblAudioActive.Text = m_sAudioOn;
                }
                else
                {
                    TimerAudio.Enabled = false;
                    TimerAudio.Stop();
                    m_Audio.StopRecording();
                    //TSLblVolume.Visible = false;
                }
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

                    //GUI entsprechend anpassen

                    //Buttontoolstrip
                    TSBtnActivateCam.Image = KugelfallDbg.Properties.Resources.Video;
                    TSBtnActivateCam.Text = m_sCameraOn;

                    //Statuslabel
                    TSLblCameraActive.Text = m_sCameraOn;
                }
                else
                {
                    CloseVideoSource();

                    //Gui-Anpassung
                    TSBtnActivateCam.Image = KugelfallDbg.Properties.Resources.NoVideo;
                    TSBtnActivateCam.Text = m_sCameraOff;
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
                            sw.Write(",");
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
                            sw.Write(",");

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
         * void TimerAudio_Tick(object sender, EventArgs e)
         * Der AudioTimer fragt in regelmäßigen Abständen den Lautstärkepegel ab
         * und aktualisiert das Label (mit dem Pegel), sowie das VolumeMeter
         */
        private void TimerAudio_Tick(object sender, EventArgs e)
        {
            //Den Maximalwert des Audioeingangs abfragen
            if (Arduino.DataAvailable) { ldata.Text = "data"; }
            else { ldata.Text = "no data"; }

            if (iRefresh == 30)
            {
                //VolumeMeter.Value = m_Audio.Volume;
                TSVolumeMeter.Value = m_Audio.Volume;
                iRefresh = 0;
            }
            else { iRefresh++; }


            //Prüfen, ob eine bestimmte Schwelle überschritten wurde (regelbar)
            if (m_Audio.MaxVolume > VolumeMeter.Threshold)
            {
                //VolumeMeter.Value = m_Audio.MaxVolume;  //Der User soll noch sehen können, wo der Pegel als letztes war
                
                m_Audio.MaxVolume = 0;

                if (m_bIsCapturing == false)
                {
                    m_bIsCapturing = true;
                    CaptureImage();
                    m_bIsCapturing = false;
                }
            }
            else if(m_Audio.MaxVolume <= VolumeMeter.Threshold)    /* Stellt sicher, dass nicht endlos viele Bilder gemacht 
                                                 * werden können, sobald die Schwelle einmal überschritten wurde 
                                                 * (bspw. zu lauter Pegel) */
            {
                m_bIsCapturing = false;
            }
        }

        int iRefresh = 0;

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
            m_bStopBuffering = true;
            /* Version 1
            if (m_bTestAvailable == true)
            {
                //Audioaufnahme temporär stoppen um keine weiteren Aufnahmen zu erzeugen
                ActivateAudio(false);
                //ActivateCamera(false);

                //Für den Fall, dass die Kamera aktiviert wurde und gleich auslösen sollte. Verhindert, dass null-Referenzen (dadurch
                //dass der ImageBuffer noch nicht gefüllt ist) in den Versuch kopiert werden.

                foreach (Bitmap b in m_bImageBuffer)
                {
                    if (b == null)
                    {
                        MessageBox.Show("ImageBuffer noch nicht bereit!");
                        ActivateAudio(true);
                        return;
                    }
                }

                Versuchsbild v = new Versuchsbild(m_iBufferSize);

                v.Test = "Versuch " + m_iAnzVersuche;   //(m_Versuche.Count + 1);  //Versuchsbeschreibung dient zur Identifizierung im Dictionary (m_Versuche)
                v.Pictures = (Bitmap[])m_bImageBuffer.Clone();
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

                //System.Threading.Thread.Sleep(50);

                //Aufnahme wieder erlauben
                ActivateAudio(true);
                ActivateCamera(true);
            }
            */
                //Audioaufnahme temporär stoppen um keine weiteren Aufnahmen zu erzeugen
                ActivateAudio(false);
                //ActivateCamera(false);

                //Für den Fall, dass die Kamera aktiviert wurde und gleich auslösen sollte. Verhindert, dass null-Referenzen (dadurch
                //dass der ImageBuffer noch nicht gefüllt ist) in den Versuch kopiert werden.

                foreach (Bitmap b in m_bImageBuffer)
                {
                    if (b == null)
                    {
                        MessageBox.Show("ImageBuffer noch nicht bereit!");
                        ActivateAudio(true);
                        return;
                    }
                }

                Versuchsbild v = new Versuchsbild(m_iBufferSize);

                v.Test = "Versuch " + m_iAnzVersuche;   //(m_Versuche.Count + 1);  //Versuchsbeschreibung dient zur Identifizierung im Dictionary (m_Versuche)
                v.Pictures = (Bitmap[])m_bImageBuffer.Clone();
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

                //System.Threading.Thread.Sleep(50);

                //Aufnahme wieder erlauben
                ActivateAudio(true);
                ActivateCamera(true);
        }

        //Jeder Versuch wird in einer Map abgespeichert und ist eindeutig identifizierbar über einen String und einer Versuchsklasse
        private System.Collections.Generic.Dictionary<string, Versuchsbild> m_Versuche;
        private int m_iAnzVersuche = 1;

        private void LVVersuchsauswertung_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvi = LVTestEvaluation.SelectedItems[0];
            string key = "Versuch " + (lvi.Index + 1).ToString();

            Versuchsbild temp = GetSelectedItem();
            FormVersuch fv = new FormVersuch(ref temp);
            DialogResult dr = fv.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                m_Versuche[key] = temp;

                //Itemupdate
                lvi.Checked = temp.Success;
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

            return m_Versuche[key]; //EVTL HIER NOCH KRITISCH!!
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

                Versuchsbild temp = GetSelectedItem();// m_Versuche[key];

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
            if (TimerAudio.Enabled) { TimerAudio.Stop(); }
            if (m_Camera.GetCamera.IsRunning) { m_Camera.Stop(); }
            m_Audio.StopRecording();
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
        }

        private bool m_bAutoCheck = false;
        #endregion

        private void Main_Click(object sender, EventArgs e)
        {
            LVTestEvaluation.SelectedItems.Clear();
        }

        private void VolumeMeter_Click(object sender, EventArgs e)
        {
            //Sollte der Schwellenwert geändert worden sein, muss auch die letzte maximale
            try
            {
                m_Audio.MaxVolume = 0;
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Bitte Audiogerät auswählen");
            }
        }

        private void TSBtnDeactivateCam_Click(object sender, EventArgs e)
        {
            if (m_Camera != null && m_Audio != null && Arduino.IsSet == true && m_Camera.GetCamera.IsRunning)
            {
                ActivateCamera(false);
                ActivateAudio(false);

                TSBtnCamSettings.Enabled = true;
                TSBtnArduinoSettings.Enabled = true;
                TSBtnAudioConfiguration.Enabled = true;
                TSBtnActivateCam.Enabled = true;
                TSBtnDeactivateCam.Enabled = false;
            }
        }

        private bool m_bStopBuffering = true;
        private string m_sArduinoChosen = "Arduino wurde ausgewählt";
        private string m_sAudioChosen = "Audiogerät wurde ausgewählt";
        private string m_sAudioOn = "Audio aktiviert";
        private string m_sCameraChosen = "Kamera wurde ausgewählt";
        private string m_sCameraOn = "Kamera eingeschaltet";
        private string m_sCameraOff = "Kamera ausgeschaltet";
    }
}
