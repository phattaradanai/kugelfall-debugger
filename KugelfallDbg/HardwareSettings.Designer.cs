namespace KugelfallDbg
{
    partial class HardwareSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TBDelay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.CBResolution = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBCamera = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CBAudioDevices = new System.Windows.Forms.ComboBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CBRS232Ports = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CBBps = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TTDelay = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kamera:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TBDelay);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.CBResolution);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CBCamera);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CBAudioDevices);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 177);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Audio/Videosetup";
            // 
            // TBDelay
            // 
            this.TBDelay.Location = new System.Drawing.Point(199, 84);
            this.TBDelay.Name = "TBDelay";
            this.TBDelay.Size = new System.Drawing.Size(100, 20);
            this.TBDelay.TabIndex = 23;
            this.TBDelay.Text = "0";
            this.TTDelay.SetToolTip(this.TBDelay, "Der Versatz beschreibt die Verzögerung zwischen dem Audio- und Videosignal in Mil" +
        "lisekunden.\r\nPositive Werte gleichen verspätete, negative Werte gleichen zu früh" +
        "e Frames aus.\r\n");
            this.TBDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBDelay_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Versatz zwischen Bild- und Ton in ms:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::KugelfallDbg.Properties.Resources.VideoCamera;
            this.pictureBox2.Location = new System.Drawing.Point(8, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::KugelfallDbg.Properties.Resources.Microphone;
            this.pictureBox3.Location = new System.Drawing.Point(8, 116);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(45, 44);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // CBResolution
            // 
            this.CBResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBResolution.FormattingEnabled = true;
            this.CBResolution.Location = new System.Drawing.Point(124, 48);
            this.CBResolution.Name = "CBResolution";
            this.CBResolution.Size = new System.Drawing.Size(175, 21);
            this.CBResolution.TabIndex = 3;
            this.CBResolution.SelectedIndexChanged += new System.EventHandler(this.CBResolution_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Auflösung:";
            // 
            // CBCamera
            // 
            this.CBCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCamera.FormattingEnabled = true;
            this.CBCamera.Location = new System.Drawing.Point(124, 18);
            this.CBCamera.Name = "CBCamera";
            this.CBCamera.Size = new System.Drawing.Size(175, 21);
            this.CBCamera.TabIndex = 1;
            this.CBCamera.SelectedIndexChanged += new System.EventHandler(this.CBCamera_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Verfügbare Geräte zur Audioaufnahme:";
            // 
            // CBAudioDevices
            // 
            this.CBAudioDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBAudioDevices.FormattingEnabled = true;
            this.CBAudioDevices.Location = new System.Drawing.Point(64, 137);
            this.CBAudioDevices.Name = "CBAudioDevices";
            this.CBAudioDevices.Size = new System.Drawing.Size(235, 21);
            this.CBAudioDevices.TabIndex = 5;
            this.CBAudioDevices.SelectedIndexChanged += new System.EventHandler(this.CBAudioDevices_SelectedIndexChanged);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(353, 206);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(119, 23);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "Abbrechen";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Location = new System.Drawing.Point(204, 206);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(119, 23);
            this.BtnOK.TabIndex = 7;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KugelfallDbg.Properties.Resources.ArduinoCommunityLogo_SVG;
            this.pictureBox1.Location = new System.Drawing.Point(353, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CBRS232Ports);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.CBBps);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(353, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 79);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parameter";
            // 
            // CBRS232Ports
            // 
            this.CBRS232Ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBRS232Ports.FormattingEnabled = true;
            this.CBRS232Ports.Location = new System.Drawing.Point(104, 19);
            this.CBRS232Ports.Name = "CBRS232Ports";
            this.CBRS232Ports.Size = new System.Drawing.Size(145, 21);
            this.CBRS232Ports.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Port:";
            // 
            // CBBps
            // 
            this.CBBps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBBps.FormattingEnabled = true;
            this.CBBps.Location = new System.Drawing.Point(104, 46);
            this.CBBps.Name = "CBBps";
            this.CBBps.Size = new System.Drawing.Size(145, 21);
            this.CBBps.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bits/Sekunde:";
            // 
            // TTDelay
            // 
            this.TTDelay.ShowAlways = true;
            this.TTDelay.ToolTipTitle = "Versatz in ms:";
            // 
            // HardwareSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 241);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HardwareSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Hardware Setup";
            this.Load += new System.EventHandler(this.HardwareSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CBResolution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBCamera;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBAudioDevices;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CBRS232Ports;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CBBps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBDelay;
        private System.Windows.Forms.ToolTip TTDelay;
    }
}