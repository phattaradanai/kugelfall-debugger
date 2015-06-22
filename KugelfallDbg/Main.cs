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
            m_ImageTime = new long[m_iBufferSize];
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

        /// <summary>
        /// Variablen, für den Zugriff auf die einzelnen ListView Spalten
        /// </summary>
        
        //Dadurch muss nicht mittels festen Index zugegriffen werden
        private int m_iTestIndex = 0;           //Versuchsnummer
        private int m_iSuccessIndex = 0;        //Treffer
        private int m_iDeviationIndex = 0;      //Abweichung/Versatz
        private int m_iCommentIndex = 0;        //Kommentar
        private int m_iArduinoDebugIndex = 0;   //Arduino Debug
        private int m_iListViewColumns = 0;     //Anzahl der Spalten im ListView

        private void Form1_Load(object sender, EventArgs e)
        {
            TBTresholdControl.Maximum = PBVolumeMeter.Maximum;

            //Spaltenindizes ermitteln
            foreach (ColumnHeader ch in LVTestEvaluation.Columns)
            {
                m_iListViewColumns++;
                if (ch.Text == "Nr.") { m_iTestIndex = ch.Index; }
                if (ch.Text == "Treffer") { m_iSuccessIndex = ch.Index; }
                if (ch.Text == "Versatz") { m_iDeviationIndex = ch.Index; }
                if (ch.Text == "Kommentar") { m_iCommentIndex = ch.Index; }
                if (ch.Text == "Arduino Debug") { m_iArduinoDebugIndex = ch.Index; }
            }

            //Evtl. vorhandene Geräte eintragen und Offsetdatei auslesen
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
            
                    m_AsyncVideo = new AForge.Video.AsyncVideoSource(m_Camera.GetCamera,true);
                    m_AsyncVideo.NewFrame += m_asyncvideo_NewFrame;
                    MainVideoSourcePlayer.VideoSource = m_AsyncVideo;

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

            m_iIndexOffset = Properties.Settings.Default.Offset;

            /*---NICHT MEHR VERWENDET---*/
            //Auf Existenz der Datei für die Verschiebung des Bilderindex prüfen:
            //Die Datei legt den Offset bei der Versuchsauswertung fest, das heisst: Zusätzlich,
            //nach der Auswahl des besten Bildes, erfolgt eine Verschiebung der Auswahl um den in
            //der Datei stehenden Faktor

            /*m_iIndexOffset = 0;

            if (System.IO.File.Exists(m_sOffsetfile) == true)
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(m_sOffsetfile))
                {
                    try
                    {
                        m_iIndexOffset = Int32.Parse(sr.ReadLine());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Fehler beim Auslesen der Offsetdatei! Bitte die Datei " + m_sOffsetfile + " auf Zahlenwert prüfen");
                    }
                }
            }
            else
            {
                System.IO.File.WriteAllText(m_sOffsetfile,"0");
            }
            ----------------------------------*/
            
        }

        
        private bool m_bInProgress = false;

        

        void m_Audio_NewMaxSample(object sender, float MaxSample)
        {
            PBVolumeMeter.Value = (int)(MaxSample);
        }

        //Dient zum Öffnen der Videoquelle
        private void OpenVideoSource()
        {
            //System.IO.File.AppendAllText("videotimes.txt", "Start: " + Stoptimer.Time.ToString());
            MainVideoSourcePlayer.Start();
            TSLblCameraActive.Text = m_sCameraOn;
        }

        private Camera m_Camera;

        private void TSBtnActivateCam_Click(object sender, EventArgs e)
        {
            if (m_Camera != null && m_Audio != null)
            {
                if (m_Camera.GetCamera.IsRunning == false)
                {
                    Stoptimer.Start();
                    ActivateCamera(true);
                    ActivateAudio(true);
                    TimerFps.Start();

                    TBTresholdControl.Value = (int)Math.Round((float)(PBVolumeMeter.Maximum * 3f / 4f), MidpointRounding.ToEven);
                    TSBtnActivateCam.Enabled = false;
                    TSBtnDeactivateCam.Enabled = true;
                    TSBtnHardwareSettings.Enabled = false;
                    TBTresholdControl.Enabled = true;
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

                m_AsyncVideo = new AForge.Video.AsyncVideoSource(vcdf.VideoDevice, true);
                m_AsyncVideo.NewFrame += m_asyncvideo_NewFrame;
                MainVideoSourcePlayer.VideoSource = m_AsyncVideo;//vcdf.VideoDevice;
                TSLblCameraActive.Text = m_sCameraChosen;
            }
        }

        void m_asyncvideo_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            if (m_bBuffer)
            {
                m_ImageTime[m_sIndex] = Stoptimer.Time;//DateTime.Now.Millisecond;   //Zeitstempel des Bildes machen

                //System.IO.File.AppendAllText("videotimes.txt", m_ImageTime[m_sIndex].ToString());
                //Dispose nötig, da sonst der GarbageCollector die alten Frames zu spät entfernen könnte,
                //was zu einem Überlauf des Arbeitsspeichers führen könnte
                //if (m_bImageBuffer[m_sIndex] != null) { m_bImageBuffer[m_sIndex].Dispose(); }
                if (m_bImageBuffer[m_sIndex] != null) { m_bImageBuffer[m_sIndex] = null; }

                m_bImageBuffer[m_sIndex] = (Bitmap)eventArgs.Frame.Clone();//image.Clone();
                m_sIndex = (m_sIndex + 1) % m_iBufferSize;
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
                    if (i == 3) { y++; offset = 0; }    //Nach 3 Bildern erfolgt ein "Zeilenumbruch" (Die zweite Zeile wird mit Bildern gefüllt)
                    g.DrawImage(_v.Pictures[i], new System.Drawing.Rectangle(offset, y * _v.Pictures[i].Height, _v.Pictures[i].Width, _v.Pictures[i].Height));

                    offset += _v.Pictures[i].Width;
                }
            }

            //Bilder mit Rahmen umranden

            if (true)
            {
                int offset = 0;
                Rectangle Rect = new Rectangle();

                float PenWidth = 4.0f;
                Pen p = new Pen(Color.Black, PenWidth);

                for (int i = 0, y = 0; i < _v.Pictures.Length; i++)
                {
                    if (i == 3) { y++; offset = 0; }    //Nach 3 Bildern erfolgt ein "Zeilenumbruch" (Die zweite Zeile wird mit Bildern gefüllt)

                    //Korrekturfaktoren, damit der Rand sauber gezeichnet wird
                    if (y == 0)
                    {
                        if (i == 0) { Rect.X = (int)PenWidth / 2 - 1; Rect.Y = (int)PenWidth / 2 - 1; Rect.Width = _v.Pictures[i].Width; Rect.Height = _v.Pictures[i].Height; }
                        else if (i == 1) { Rect.X = offset; Rect.Y = (int)PenWidth / 2 - 1; Rect.Width = _v.Pictures[i].Width; Rect.Height = _v.Pictures[i].Height; }
                        else if (i == 2) { Rect.X = offset; Rect.Y = (int)PenWidth / 2 - 1; Rect.Width = _v.Pictures[i].Width - (int)PenWidth / 2 - 1; Rect.Height = _v.Pictures[i].Height; }
                    }
                    else if (y == 1)
                    {
                        if (i == 3) { Rect.X = (int)PenWidth / 2 - 1; Rect.Y = y * _v.Pictures[i].Height; Rect.Width = _v.Pictures[i].Width; Rect.Height = _v.Pictures[i].Height - (int)(PenWidth / 2) - 1; }
                        else if (i == 4) { Rect.X = offset; Rect.Y = y * _v.Pictures[i].Height; Rect.Width = _v.Pictures[i].Width; Rect.Height = _v.Pictures[i].Height - (int)PenWidth / 2 - 1; }
                        else if (i == 5) { Rect.X = offset; Rect.Y = y * _v.Pictures[i].Height; Rect.Width = _v.Pictures[i].Width - (int)PenWidth / 2 - 1; Rect.Height = _v.Pictures[i].Height - (int)PenWidth / 2 - 1; }
                    }

                    g.DrawRectangle(p, Rect);

                    offset += _v.Pictures[i].Width;
                }
            }

            //Bestes Bild umranden
            if (_v.BestPicture != -1)
            {
                int offset = 0;
                Rectangle Rect = new Rectangle();

                float PenWidth = 7.0f;
                Pen p = new Pen(Color.Red, PenWidth);

                for (int i = 0, y = 0; i < _v.Pictures.Length; i++)
                {
                    if (i == 3) { y++; offset = 0; }    //Nach 3 Bildern erfolgt ein "Zeilenumbruch" (Die zweite Zeile wird mit Bildern gefüllt)
                    if (i == _v.BestPicture)
                    {
                        //Korrekturfaktoren, damit der Rand sauber gezeichnet wird
                        if (y == 0)
                        {
                            if (i == 0) { Rect.X = (int)PenWidth / 2 - 1; Rect.Y = (int)PenWidth / 2 - 1; Rect.Width = _v.Pictures[i].Width; Rect.Height = _v.Pictures[i].Height; }
                            else if (i == 1) { Rect.X = offset; Rect.Y = (int)PenWidth / 2 - 1; Rect.Width = _v.Pictures[i].Width; Rect.Height = _v.Pictures[i].Height; }
                            else if (i == 2) { Rect.X = offset; Rect.Y = (int)PenWidth / 2 - 1; Rect.Width = _v.Pictures[i].Width - (int)PenWidth / 2 - 1; Rect.Height = _v.Pictures[i].Height; }
                        }
                        else if(y == 1)
                        {
                            if (i == 3) { Rect.X = (int)PenWidth/2 - 1; Rect.Y = y * _v.Pictures[i].Height; Rect.Width = _v.Pictures[i].Width; Rect.Height = _v.Pictures[i].Height - (int)(PenWidth/2) - 1; }
                            else if (i == 4) { Rect.X = offset; Rect.Y = y * _v.Pictures[i].Height; Rect.Width = _v.Pictures[i].Width; Rect.Height = _v.Pictures[i].Height - (int)PenWidth / 2 - 1; }
                            else if (i == 5) { Rect.X = offset; Rect.Y = y * _v.Pictures[i].Height; Rect.Width = _v.Pictures[i].Width - (int)PenWidth / 2 - 1; Rect.Height = _v.Pictures[i].Height - (int)PenWidth / 2 - 1; }
                        }

                        g.DrawRectangle(p,Rect);
                        break;
                    }

                    offset += _v.Pictures[i].Width;
                }
            }

            return b;
        }

        /**
         * void ActivateCamera(bool _bActivate):
         * Aktiviert bzw. deaktiviert die Kamera.
         */
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
                m_iAnzVersuche = 1;
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
                    System.IO.StreamWriter sw = null;
                    bool bOpen = false;

                    try
                    {
                        sw = new System.IO.StreamWriter(sfd.FileName, false, Encoding.UTF8);    //Encoding auf UTF8 für spezielle Symbole
                        bOpen = true;
                    }
                    catch(System.IO.IOException)
                    {
                        MessageBox.Show("Datei ist bereits geöffnet");
                    }

                    if (bOpen == true)
                    {
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
                            //SubItems durchgehen und eintragen
                            for (int iSubItems = 0; iSubItems < lvi.SubItems.Count; iSubItems++)
                            {
                                if (lvi.SubItems[iSubItems].Text.Contains("\n") || lvi.SubItems[iSubItems].Text.Contains("\r\n"))
                                {
                                    string s = lvi.SubItems[iSubItems].Text.Replace("\r\n", " ");
                                    lvi.SubItems[iSubItems].Text = s;
                                    sw.Write(s);
                                }
                                else
                                {
                                    sw.Write(lvi.SubItems[iSubItems].Text);
                                }
                                sw.Write(";");
                            }

                            sw.Write("\n");
                        }

                        sw.Close();
                    }
                }
            }
        }
        #endregion

        private void TSBtnCamSettings_Click(object sender, EventArgs e)
        {
            CamSettings();
        }

        //Jeder Versuch wird in einer Map abgespeichert und ist eindeutig identifizierbar über einen String und einer Versuchsklasse
        private System.Collections.Generic.Dictionary<string, Versuchsbild> m_Versuche;

        private int m_iAnzVersuche = 1; //Anzahl der gemachten Versuche

        /**
         * void LVVersuchsauswertung_DoubleClick(object sender, EventArgs e):
         * Event, tritt ein wenn ein Element aus der Versuchsliste ausgewählt wurde.
         */
        private void LVVersuchsauswertung_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvi = LVTestEvaluation.SelectedItems[0];       //Angeklicktes Element wählen
            string key = "Versuch " + lvi.SubItems[m_iTestIndex].Text;  //Schlüssel für Dictionary generieren

            Versuchsbild temp = GetSelectedItem();
            FormVersuch fv = new FormVersuch(ref temp);
            DialogResult dr = fv.ShowDialog();

            //Versuch anzeigen
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                m_Versuche[key] = temp;

                //Itemupdate
                lvi.SubItems[m_iSuccessIndex].Text = temp.Success;
                lvi.SubItems[m_iDeviationIndex].Text = temp.Deviation.ToString();
                lvi.SubItems[m_iArduinoDebugIndex].Text = temp.Debugtext;
                lvi.SubItems[m_iCommentIndex].Text = temp.Comment;
            }
        }

        /**
         * Versuchsbild GetSelectedItem():
         * Das gewählte ListviewItem (also ein Versuch) wird gesucht und zurückgegeben.
         */
        private Versuchsbild GetSelectedItem()
        {
            ListViewItem lvi = LVTestEvaluation.SelectedItems[0];

            string key = "Versuch " + lvi.SubItems[m_iTestIndex].Text;
            try
            {
                return m_Versuche[key];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        /**
         * void LVTestEvaluation_SelectedIndexChanged(object sender, EventArgs e):
         * Ein Item (also ein Versuch) wurde aus der Liste ausgewählt. Um diesen bearbeiten zu können,
         * wird ein Dialog aufgerufen
        */
        private void LVTestEvaluation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Audio deaktivieren
                ActivateAudio(false);
            }
            catch (NullReferenceException)
            {

            }

            MainVideoSourcePlayer.Visible = false;

            if (LVTestEvaluation.SelectedItems.Count == 0)  //Vermeiden, dass ein Fehlklick oder ein nicht mehr angeklicktes Item zu einer Exception führt (OutOfRange)
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
            else //Item wurde ausgewählt --> Ausgewähltes Bild auf Livebild übertragen
            {
                TSBtnRemoveTest.Enabled = true;

                Versuchsbild temp = GetSelectedItem();

                MainVideoSourcePlayer.Visible = false;
                pb_Images.Visible = true;
                pb_Images.Image = new Bitmap(CombineImages(temp), new Size(pb_Images.Width, pb_Images.Height));
            }
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

        private void Main_Click(object sender, EventArgs e)
        {
            //Das Listview-Element soll den Fokus verlieren (keine Auswahl eines Items)
            LVTestEvaluation.SelectedItems.Clear();
        }

        /**
         * void TSBtnDeactivateCam_Click(object sender, EventArgs e):
         * Event, falls die Kamera deaktiviert werden soll
         */
        private void TSBtnDeactivateCam_Click(object sender, EventArgs e)
        {
            if (m_Camera != null && m_Audio != null && m_Camera.GetCamera.IsRunning)
            {
                TimerFps.Stop();
                
                //Audio und Video deaktivieren
                ActivateCamera(false);
                ActivateAudio(false);

                //Arduino schließen
                if (Arduino.IsOpen() == true) { Arduino.ClosePort(); }

                //Stoptimer anhalten
                Stoptimer.Stop();
                Stoptimer.Reset();

                //GUI-Anpassungen vornehmen
                TSBtnActivateCam.Enabled = true;
                TSBtnDeactivateCam.Enabled = false;
                TSBtnHardwareSettings.Enabled = true;
                TBTresholdControl.Enabled = false;
            }
        }

        /**
         * TBTresholdControle_ValueChanged(...):
         * Event tritt ein, falls sich der Wert am Schwellenwertregler ändert
         */
        private void TBTresholdControl_ValueChanged(object sender, EventArgs e)
        {
            if (TBTresholdControl.Value <= m_iMinimalThreshold)   //Verhindern, dass die Schwelle ständig überschritten wird
            {
                MessageBox.Show("Wert zu niedrig");
                m_Audio.Threshold = 15;
                TBTresholdControl.Value = 15;
            }
            else { m_Audio.Threshold = TBTresholdControl.Value; }
        }

        private int m_iMinimalThreshold = 5;    ///Minimale Schwelle, um zu verhindern, dass die Schwelle ständig überschritten wird
        private Audio m_Audio;                  ///Audioaufnahmegerät

        private int m_iBufferSize = 60;         //Festgelegte ImageBuffer Größe
        private Bitmap[] m_bImageBuffer;        //ImageBuffer für Versuchsbilder
        private long[] m_ImageTime;             //Beinhaltet sämtliche Bilderzeiten
        private int m_sIndex = 0;               //Dient als "Zeiger" in der Buffervariable (maximal m_iBufferSize Bilder)
        private int m_iIndexOffset = 0;
        private string m_sOffsetfile = "IndexOffset.kd";
        

        //Textvariablen zur einheitlichen Beschriftung
        private string m_sArduinoChosen = "Arduino wurde ausgewählt";
        private string m_sAudioChosen = "Audiogerät wurde ausgewählt";
        private string m_sAudioOn = "Audio aktiviert";
        private string m_sCameraChosen = "Kamera wurde ausgewählt";
        private string m_sCameraOn = "Kamera eingeschaltet";
        private string m_sCameraOff = "Kamera ausgeschaltet";
        private AForge.Video.AsyncVideoSource m_AsyncVideo = null;
        private bool m_bKeyHeld = false;
        private bool m_bShowDebugWindow = false;

        private void TSBtnAbout_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.ShowDialog();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (!m_bKeyHeld)
            {
                if (e.Control && e.KeyCode == Keys.D)
                {
                    m_bKeyHeld = true;
                    m_bShowDebugWindow = !m_bShowDebugWindow;
                }
            }
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            m_bKeyHeld = false;
        }

        private void TimerFps_Tick(object sender, EventArgs e)
        {
            float iFPS = MainVideoSourcePlayer.VideoSource.FramesReceived;
            TS_FPS.Text = iFPS.ToString();
            TS_Framelength.Text = (Math.Round(1000.0f*(1.0f/iFPS),0)).ToString() + " ms";
        }

        private void TSBtnHardwareSettings_Click(object sender, EventArgs e)
        {
            HardwareSettings hs = new HardwareSettings();
            if (hs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //ActivateAudio(false);
                //AForge.Video.DirectShow.VideoCaptureDeviceForm vcdf = new AForge.Video.DirectShow.VideoCaptureDeviceForm();

                if (m_Camera != null)
                {
                    m_Camera = null;
                }

                m_Camera = new Camera(hs.VideoCaptureDevice);

                Properties.Settings.Default.VideoDevice = hs.VideoDeviceMoniker;  //Gerätebezeichner abspeichern
                Properties.Settings.Default.Save();

                m_AsyncVideo = new AForge.Video.AsyncVideoSource(hs.VideoCaptureDevice, true);
                m_AsyncVideo.NewFrame += m_asyncvideo_NewFrame;
                MainVideoSourcePlayer.VideoSource = m_AsyncVideo;

                TSLblCameraActive.Text = m_sCameraChosen;

                //Audioeinstellungen übernehmen
                if (m_Audio != null)    //Falls eine Audioinstanz vorhanden sein sollte
                {
                    ActivateAudio(false);   //Zur Sicherheit beenden

                    m_Audio = null;
                }

                m_Audio = new Audio(hs.AudioDevice);
                m_Audio.NewMaxSample += m_Audio_NewMaxSample;
                m_Audio.ThresholdExceeded += m_Audio_ThresholdExceeded;

                TSLblAudioActive.Text = m_sAudioChosen;
                
                //Einstellungen speichern
                Properties.Settings.Default.AudioDevice = hs.AudioDevice;
                Properties.Settings.Default.Save();
                
                //Offset eintragen
                m_iIndexOffset = hs.Offset;
            }
        }
    }
}