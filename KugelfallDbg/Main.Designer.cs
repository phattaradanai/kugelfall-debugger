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
            this.CHVersuch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHGetroffen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHVersatz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHKommentar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHArduino = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TSBtnAbout = new System.Windows.Forms.ToolStripButton();
            this.ILVersuchsbilder = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.PBVolumeMeter = new System.Windows.Forms.ProgressBar();
            this.TBTresholdControl = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pb_Images = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBTresholdControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Images)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightGray;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSLblCameraActive,
            this.TSLblAudioActive,
            this.TSLblThreshold,
            this.TSLblArduino});
            this.statusStrip1.Location = new System.Drawing.Point(0, 491);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1256, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TSLblCameraActive
            // 
            this.TSLblCameraActive.Name = "TSLblCameraActive";
            this.TSLblCameraActive.Size = new System.Drawing.Size(940, 17);
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
            this.MainVideoSourcePlayer.Location = new System.Drawing.Point(10, 109);
            this.MainVideoSourcePlayer.Name = "MainVideoSourcePlayer";
            this.MainVideoSourcePlayer.Size = new System.Drawing.Size(540, 380);
            this.MainVideoSourcePlayer.TabIndex = 1;
            this.MainVideoSourcePlayer.VideoSource = null;
            this.MainVideoSourcePlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.MainVideoSourcePlayer_NewFrame);
            // 
            // LVTestEvaluation
            // 
            this.LVTestEvaluation.BackColor = System.Drawing.Color.White;
            this.LVTestEvaluation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CHVersuch,
            this.CHGetroffen,
            this.CHVersatz,
            this.CHKommentar,
            this.CHArduino});
            this.LVTestEvaluation.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LVTestEvaluation.FullRowSelect = true;
            this.LVTestEvaluation.GridLines = true;
            this.LVTestEvaluation.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LVTestEvaluation.Location = new System.Drawing.Point(604, 109);
            this.LVTestEvaluation.MultiSelect = false;
            this.LVTestEvaluation.Name = "LVTestEvaluation";
            this.LVTestEvaluation.Size = new System.Drawing.Size(639, 379);
            this.LVTestEvaluation.TabIndex = 16;
            this.LVTestEvaluation.UseCompatibleStateImageBehavior = false;
            this.LVTestEvaluation.View = System.Windows.Forms.View.Details;
            this.LVTestEvaluation.SelectedIndexChanged += new System.EventHandler(this.LVTestEvaluation_SelectedIndexChanged);
            this.LVTestEvaluation.DoubleClick += new System.EventHandler(this.LVVersuchsauswertung_DoubleClick);
            // 
            // CHVersuch
            // 
            this.CHVersuch.Text = "Nr.";
            this.CHVersuch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CHVersuch.Width = 34;
            // 
            // CHGetroffen
            // 
            this.CHGetroffen.Text = "Treffer";
            this.CHGetroffen.Width = 106;
            // 
            // CHVersatz
            // 
            this.CHVersatz.Text = "Versatz";
            // 
            // CHKommentar
            // 
            this.CHKommentar.Text = "Kommentar";
            this.CHKommentar.Width = 254;
            // 
            // CHArduino
            // 
            this.CHArduino.Text = "Arduino Debug";
            this.CHArduino.Width = 181;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.LightGray;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(26, 26);
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
            this.toolStripSeparator3,
            this.TSBtnAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(818, 46);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSBtnRemoveTest
            // 
            this.TSBtnRemoveTest.Enabled = false;
            this.TSBtnRemoveTest.Image = global::KugelfallDbg.Properties.Resources.Delete;
            this.TSBtnRemoveTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnRemoveTest.Name = "TSBtnRemoveTest";
            this.TSBtnRemoveTest.Size = new System.Drawing.Size(95, 43);
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
            this.TSBtnDeactivateCam.Size = new System.Drawing.Size(112, 43);
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
            this.TSBtnActivateCam.Size = new System.Drawing.Size(110, 43);
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
            this.TSBtnDeleteAll.Size = new System.Drawing.Size(107, 43);
            this.TSBtnDeleteAll.Text = "Alle Daten löschen";
            this.TSBtnDeleteAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBtnDeleteAll.ToolTipText = "Alle Bilder löschen";
            this.TSBtnDeleteAll.Click += new System.EventHandler(this.TSBtnDeleteAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 46);
            // 
            // TSBtnExportCSV
            // 
            this.TSBtnExportCSV.Image = global::KugelfallDbg.Properties.Resources.CSVExport;
            this.TSBtnExportCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnExportCSV.Name = "TSBtnExportCSV";
            this.TSBtnExportCSV.Size = new System.Drawing.Size(68, 43);
            this.TSBtnExportCSV.Text = "CSV-Export";
            this.TSBtnExportCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBtnExportCSV.ToolTipText = "Daten als CSV-Datei exportieren";
            this.TSBtnExportCSV.Click += new System.EventHandler(this.TSBtnExportCSV_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // TSBtnCamSettings
            // 
            this.TSBtnCamSettings.Image = ((System.Drawing.Image)(resources.GetObject("TSBtnCamSettings.Image")));
            this.TSBtnCamSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnCamSettings.Name = "TSBtnCamSettings";
            this.TSBtnCamSettings.Size = new System.Drawing.Size(81, 43);
            this.TSBtnCamSettings.Text = "Kamera Setup";
            this.TSBtnCamSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBtnCamSettings.Click += new System.EventHandler(this.TSBtnCamSettings_Click);
            // 
            // TSBtnArduinoSettings
            // 
            this.TSBtnArduinoSettings.Image = global::KugelfallDbg.Properties.Resources.RS232;
            this.TSBtnArduinoSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnArduinoSettings.Name = "TSBtnArduinoSettings";
            this.TSBtnArduinoSettings.Size = new System.Drawing.Size(86, 43);
            this.TSBtnArduinoSettings.Text = "Arduino Setup";
            this.TSBtnArduinoSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBtnArduinoSettings.ToolTipText = "RS232 Einstellungen";
            this.TSBtnArduinoSettings.Click += new System.EventHandler(this.TSBtnArduinoSettings_Click);
            // 
            // TSBtnAudioConfiguration
            // 
            this.TSBtnAudioConfiguration.Image = global::KugelfallDbg.Properties.Resources.Microphone;
            this.TSBtnAudioConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnAudioConfiguration.Name = "TSBtnAudioConfiguration";
            this.TSBtnAudioConfiguration.Size = new System.Drawing.Size(75, 43);
            this.TSBtnAudioConfiguration.Text = "Audio Setup";
            this.TSBtnAudioConfiguration.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBtnAudioConfiguration.Click += new System.EventHandler(this.TSBtnAudioConfiguration_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 46);
            // 
            // TSBtnAbout
            // 
            this.TSBtnAbout.Image = global::KugelfallDbg.Properties.Resources.Information2;
            this.TSBtnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnAbout.Name = "TSBtnAbout";
            this.TSBtnAbout.Size = new System.Drawing.Size(36, 43);
            this.TSBtnAbout.Text = "Über";
            this.TSBtnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBtnAbout.Click += new System.EventHandler(this.TSBtnAbout_Click);
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
            this.label2.Location = new System.Drawing.Point(230, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Livebild der Kamera";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(818, 22);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(818, 68);
            this.toolStripContainer1.TabIndex = 28;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // PBVolumeMeter
            // 
            this.PBVolumeMeter.BackColor = System.Drawing.Color.LightSlateGray;
            this.PBVolumeMeter.Location = new System.Drawing.Point(89, 18);
            this.PBVolumeMeter.Name = "PBVolumeMeter";
            this.PBVolumeMeter.Size = new System.Drawing.Size(302, 23);
            this.PBVolumeMeter.TabIndex = 29;
            // 
            // TBTresholdControl
            // 
            this.TBTresholdControl.Location = new System.Drawing.Point(82, 32);
            this.TBTresholdControl.Maximum = 100;
            this.TBTresholdControl.Name = "TBTresholdControl";
            this.TBTresholdControl.Size = new System.Drawing.Size(320, 45);
            this.TBTresholdControl.TabIndex = 30;
            this.TBTresholdControl.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TBTresholdControl.Value = 75;
            this.TBTresholdControl.ValueChanged += new System.EventHandler(this.TBTresholdControl_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(864, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Versuchsauswertungen";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(10, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(804, 10);
            this.panel2.TabIndex = 33;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 65);
            this.panel3.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Input Level:";
            // 
            // pb_Images
            // 
            this.pb_Images.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pb_Images.Location = new System.Drawing.Point(10, 109);
            this.pb_Images.Name = "pb_Images";
            this.pb_Images.Size = new System.Drawing.Size(540, 380);
            this.pb_Images.TabIndex = 25;
            this.pb_Images.TabStop = false;
            this.pb_Images.Visible = false;
            this.pb_Images.WaitOnLoad = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Schwellenwert";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PBVolumeMeter);
            this.groupBox1.Controls.Add(this.TBTresholdControl);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(837, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 83);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lautstärkeregelung";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(815, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 65);
            this.panel1.TabIndex = 35;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1256, 513);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.pb_Images);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LVTestEvaluation);
            this.Controls.Add(this.MainVideoSourcePlayer);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Kugelfall-Debugger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Main_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBTresholdControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Images)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton TSBtnCamSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TSBtnAudioConfiguration;
        private System.Windows.Forms.ToolStripButton TSBtnRemoveTest;
        private System.Windows.Forms.ToolStripStatusLabel TSLblAudioActive;
        private System.Windows.Forms.PictureBox pb_Images;
        private System.Windows.Forms.ToolStripStatusLabel TSLblThreshold;
        private System.Windows.Forms.ToolStripStatusLabel TSLblArduino;
        private System.Windows.Forms.ToolStripButton TSBtnDeactivateCam;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ProgressBar PBVolumeMeter;
        private System.Windows.Forms.TrackBar TBTresholdControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripButton TSBtnAbout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
    }
}

