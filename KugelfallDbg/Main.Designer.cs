namespace KugelfallDbg
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TSLblCameraActive = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSLblAudioActive = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSLblThreshold = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSLblArduino = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainVideoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.LVTestEvaluation = new System.Windows.Forms.ListView();
            this.CHGetroffen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHVersuch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHVersatz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHArduino = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHKommentar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSBtnRemoveTest = new System.Windows.Forms.ToolStripButton();
            this.TSBtnDeactivateCam = new System.Windows.Forms.ToolStripButton();
            this.TSBtnActivateCam = new System.Windows.Forms.ToolStripButton();
            this.TSBtnDeleteAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSBtnExportCSV = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSBtnCamSettings = new System.Windows.Forms.ToolStripButton();
            this.TSBtnArduinoSettings = new System.Windows.Forms.ToolStripButton();
            this.TSBtnAudioConfiguration = new System.Windows.Forms.ToolStripButton();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.ILVersuchsbilder = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TimerAudio = new System.Windows.Forms.Timer(this.components);
            this.pb_Images = new System.Windows.Forms.PictureBox();
            this.VolumeMeter = new ProgressBars.Basic.BasicProgressBar();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Images)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSLblCameraActive,
            this.TSLblAudioActive,
            this.TSLblThreshold,
            this.TSLblArduino});
            this.statusStrip1.Location = new System.Drawing.Point(0, 421);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1244, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TSLblCameraActive
            // 
            this.TSLblCameraActive.Name = "TSLblCameraActive";
            this.TSLblCameraActive.Size = new System.Drawing.Size(928, 17);
            this.TSLblCameraActive.Spring = true;
            this.TSLblCameraActive.Text = "Keine Kamera ausgewählt";
            this.TSLblCameraActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TSLblAudioActive
            // 
            this.TSLblAudioActive.Name = "TSLblAudioActive";
            this.TSLblAudioActive.Size = new System.Drawing.Size(155, 17);
            this.TSLblAudioActive.Text = "Kein Audiogerät ausgewählt";
            // 
            // TSLblThreshold
            // 
            this.TSLblThreshold.Name = "TSLblThreshold";
            this.TSLblThreshold.Size = new System.Drawing.Size(150, 17);
            this.TSLblThreshold.Text = "Eingestellter Schwellenwert";
            this.TSLblThreshold.Visible = false;
            // 
            // TSLblArduino
            // 
            this.TSLblArduino.Name = "TSLblArduino";
            this.TSLblArduino.Size = new System.Drawing.Size(146, 17);
            this.TSLblArduino.Text = "Arduino nicht ausgewählt!";
            // 
            // MainVideoSourcePlayer
            // 
            this.MainVideoSourcePlayer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MainVideoSourcePlayer.Location = new System.Drawing.Point(12, 111);
            this.MainVideoSourcePlayer.Name = "MainVideoSourcePlayer";
            this.MainVideoSourcePlayer.Size = new System.Drawing.Size(560, 304);
            this.MainVideoSourcePlayer.TabIndex = 1;
            this.MainVideoSourcePlayer.VideoSource = null;
            this.MainVideoSourcePlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.MainVideoSourcePlayer_NewFrame);
            // 
            // LVTestEvaluation
            // 
            this.LVTestEvaluation.BackColor = System.Drawing.Color.White;
            this.LVTestEvaluation.CheckBoxes = true;
            this.LVTestEvaluation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CHGetroffen,
            this.CHVersuch,
            this.CHVersatz,
            this.CHArduino,
            this.CHKommentar});
            this.LVTestEvaluation.FullRowSelect = true;
            this.LVTestEvaluation.GridLines = true;
            this.LVTestEvaluation.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LVTestEvaluation.Location = new System.Drawing.Point(593, 111);
            this.LVTestEvaluation.MultiSelect = false;
            this.LVTestEvaluation.Name = "LVTestEvaluation";
            this.LVTestEvaluation.Size = new System.Drawing.Size(639, 304);
            this.LVTestEvaluation.TabIndex = 16;
            this.LVTestEvaluation.UseCompatibleStateImageBehavior = false;
            this.LVTestEvaluation.View = System.Windows.Forms.View.Details;
            this.LVTestEvaluation.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LVTestEvaluation_ItemCheck);
            this.LVTestEvaluation.SelectedIndexChanged += new System.EventHandler(this.LVTestEvaluation_SelectedIndexChanged);
            this.LVTestEvaluation.DoubleClick += new System.EventHandler(this.LVVersuchsauswertung_DoubleClick);
            this.LVTestEvaluation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LVTestEvaluation_MouseDown);
            this.LVTestEvaluation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LVTestEvaluation_MouseUp);
            // 
            // CHGetroffen
            // 
            this.CHGetroffen.Text = "OK";
            this.CHGetroffen.Width = 28;
            // 
            // CHVersuch
            // 
            this.CHVersuch.Text = "Versuch";
            // 
            // CHVersatz
            // 
            this.CHVersatz.Text = "Versatz";
            // 
            // CHArduino
            // 
            this.CHArduino.Text = "Arduino Debug";
            this.CHArduino.Width = 91;
            // 
            // CHKommentar
            // 
            this.CHKommentar.Text = "Kommentar";
            this.CHKommentar.Width = 396;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSBtnRemoveTest,
            this.TSBtnDeactivateCam,
            this.TSBtnActivateCam,
            this.TSBtnDeleteAll,
            this.toolStripSeparator2,
            this.TSBtnExportCSV,
            this.toolStripSeparator1,
            this.TSBtnCamSettings,
            this.TSBtnArduinoSettings,
            this.TSBtnAudioConfiguration,
            this.toolStripProgressBar1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1244, 59);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSBtnRemoveTest
            // 
            this.TSBtnRemoveTest.Enabled = false;
            this.TSBtnRemoveTest.Image = global::KugelfallDbg.Properties.Resources.Delete;
            this.TSBtnRemoveTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnRemoveTest.Name = "TSBtnRemoveTest";
            this.TSBtnRemoveTest.Size = new System.Drawing.Size(97, 56);
            this.TSBtnRemoveTest.Text = "Versuch löschen";
            this.TSBtnRemoveTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBtnRemoveTest.Click += new System.EventHandler(this.TSBtnDeleteTest_Click);
            // 
            // TSBtnDeactivateCam
            // 
            this.TSBtnDeactivateCam.Enabled = false;
            this.TSBtnDeactivateCam.Image = ((System.Drawing.Image)(resources.GetObject("TSBtnDeactivateCam.Image")));
            this.TSBtnDeactivateCam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnDeactivateCam.Name = "TSBtnDeactivateCam";
            this.TSBtnDeactivateCam.Size = new System.Drawing.Size(116, 56);
            this.TSBtnDeactivateCam.Text = "Kamera ausschalten";
            this.TSBtnDeactivateCam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBtnDeactivateCam.ToolTipText = "Versuchskamera einschalten";
            this.TSBtnDeactivateCam.Click += new System.EventHandler(this.TSBtnDeactivateCam_Click);
            // 
            // TSBtnActivateCam
            // 
            this.TSBtnActivateCam.Image = global::KugelfallDbg.Properties.Resources.Video;
            this.TSBtnActivateCam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnActivateCam.Name = "TSBtnActivateCam";
            this.TSBtnActivateCam.Size = new System.Drawing.Size(114, 56);
            this.TSBtnActivateCam.Text = "Kamera einschalten";
            this.TSBtnActivateCam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBtnActivateCam.ToolTipText = "Versuchskamera einschalten";
            this.TSBtnActivateCam.Click += new System.EventHandler(this.TSBtnActivateCam_Click);
            // 
            // TSBtnDeleteAll
            // 
            this.TSBtnDeleteAll.Image = global::KugelfallDbg.Properties.Resources.Delete;
            this.TSBtnDeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnDeleteAll.Name = "TSBtnDeleteAll";
            this.TSBtnDeleteAll.Size = new System.Drawing.Size(109, 56);
            this.TSBtnDeleteAll.Text = "Alle Daten löschen";
            this.TSBtnDeleteAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBtnDeleteAll.ToolTipText = "Alle Bilder löschen";
            this.TSBtnDeleteAll.Click += new System.EventHandler(this.TSBtnDeleteAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 59);
            // 
            // TSBtnExportCSV
            // 
            this.TSBtnExportCSV.Image = global::KugelfallDbg.Properties.Resources.CSVExport;
            this.TSBtnExportCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnExportCSV.Name = "TSBtnExportCSV";
            this.TSBtnExportCSV.Size = new System.Drawing.Size(70, 56);
            this.TSBtnExportCSV.Text = "CSV-Export";
            this.TSBtnExportCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBtnExportCSV.ToolTipText = "Daten als CSV-Datei exportieren";
            this.TSBtnExportCSV.Click += new System.EventHandler(this.TSBtnExportCSV_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 59);
            // 
            // TSBtnCamSettings
            // 
            this.TSBtnCamSettings.Image = ((System.Drawing.Image)(resources.GetObject("TSBtnCamSettings.Image")));
            this.TSBtnCamSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnCamSettings.Name = "TSBtnCamSettings";
            this.TSBtnCamSettings.Size = new System.Drawing.Size(122, 56);
            this.TSBtnCamSettings.Text = "Kameraeinstellungen";
            this.TSBtnCamSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBtnCamSettings.Click += new System.EventHandler(this.TSBtnCamSettings_Click);
            // 
            // TSBtnArduinoSettings
            // 
            this.TSBtnArduinoSettings.Image = global::KugelfallDbg.Properties.Resources.RS232;
            this.TSBtnArduinoSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnArduinoSettings.Name = "TSBtnArduinoSettings";
            this.TSBtnArduinoSettings.Size = new System.Drawing.Size(128, 56);
            this.TSBtnArduinoSettings.Text = "Arduino Einstellungen";
            this.TSBtnArduinoSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBtnArduinoSettings.ToolTipText = "RS232 Einstellungen";
            this.TSBtnArduinoSettings.Click += new System.EventHandler(this.TSBtnArduinoSettings_Click);
            // 
            // TSBtnAudioConfiguration
            // 
            this.TSBtnAudioConfiguration.Image = global::KugelfallDbg.Properties.Resources.Microphone;
            this.TSBtnAudioConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnAudioConfiguration.Name = "TSBtnAudioConfiguration";
            this.TSBtnAudioConfiguration.Size = new System.Drawing.Size(114, 56);
            this.TSBtnAudioConfiguration.Text = "Audioeinstellungen";
            this.TSBtnAudioConfiguration.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBtnAudioConfiguration.Click += new System.EventHandler(this.TSBtnAudioConfiguration_Click);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 56);
            // 
            // ILVersuchsbilder
            // 
            this.ILVersuchsbilder.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ILVersuchsbilder.ImageSize = new System.Drawing.Size(16, 16);
            this.ILVersuchsbilder.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Livebild der Kamera";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(551, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Lautstärke";
            // 
            // TimerAudio
            // 
            this.TimerAudio.Interval = 10;
            this.TimerAudio.Tick += new System.EventHandler(this.TimerAudio_Tick);
            // 
            // pb_Images
            // 
            this.pb_Images.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pb_Images.Location = new System.Drawing.Point(12, 111);
            this.pb_Images.Name = "pb_Images";
            this.pb_Images.Size = new System.Drawing.Size(560, 304);
            this.pb_Images.TabIndex = 25;
            this.pb_Images.TabStop = false;
            this.pb_Images.Visible = false;
            // 
            // VolumeMeter
            // 
            this.VolumeMeter.BackColor = System.Drawing.Color.DarkGray;
            this.VolumeMeter.Font = new System.Drawing.Font("Consolas", 10.25F);
            this.VolumeMeter.ForeColor = System.Drawing.Color.ForestGreen;
            this.VolumeMeter.Location = new System.Drawing.Point(698, 62);
            this.VolumeMeter.Name = "VolumeMeter";
            this.VolumeMeter.Size = new System.Drawing.Size(73, 43);
            this.VolumeMeter.TabIndex = 26;
            this.VolumeMeter.Text = "basicProgressBar1";
            this.VolumeMeter.Value = 0;
            this.VolumeMeter.Click += new System.EventHandler(this.VolumeMeter_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1244, 443);
            this.Controls.Add(this.VolumeMeter);
            this.Controls.Add(this.pb_Images);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.LVTestEvaluation);
            this.Controls.Add(this.MainVideoSourcePlayer);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Kugelfall-Debugger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Main_Click);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Images)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private AForge.Controls.VideoSourcePlayer MainVideoSourcePlayer;
        private System.Windows.Forms.ListView LVTestEvaluation;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TSBtnActivateCam;
        private System.Windows.Forms.ColumnHeader CHVersuch;
        private System.Windows.Forms.ColumnHeader CHVersatz;
        private System.Windows.Forms.ColumnHeader CHKommentar;
        private System.Windows.Forms.ColumnHeader CHGetroffen;
        private System.Windows.Forms.ToolStripButton TSBtnExportCSV;
        private System.Windows.Forms.ColumnHeader CHArduino;
        private System.Windows.Forms.ImageList ILVersuchsbilder;
        private System.Windows.Forms.ToolStripButton TSBtnDeleteAll;
        private System.Windows.Forms.ToolStripStatusLabel TSLblCameraActive;
        private System.Windows.Forms.ToolStripButton TSBtnArduinoSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton TSBtnCamSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TSBtnAudioConfiguration;
        private System.Windows.Forms.Timer TimerAudio;
        private System.Windows.Forms.ToolStripButton TSBtnRemoveTest;
        private System.Windows.Forms.ToolStripStatusLabel TSLblAudioActive;
        private System.Windows.Forms.PictureBox pb_Images;
        private ProgressBars.Basic.BasicProgressBar VolumeMeter;
        private System.Windows.Forms.ToolStripStatusLabel TSLblThreshold;
        private System.Windows.Forms.ToolStripStatusLabel TSLblArduino;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripButton TSBtnDeactivateCam;
    }
}

