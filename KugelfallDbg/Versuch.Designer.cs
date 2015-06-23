namespace KugelfallDbg
{
    partial class FormVersuch
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
            this.TBComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NDeviation = new System.Windows.Forms.NumericUpDown();
            this.TBPicture = new System.Windows.Forms.TrackBar();
            this.lblAbstand = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            this.CBChosenPicture = new System.Windows.Forms.CheckBox();
            this.PBTest = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBArduino = new System.Windows.Forms.TextBox();
            this.CBSuccess = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.NDeviation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBTest)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBComment
            // 
            this.TBComment.Location = new System.Drawing.Point(25, 407);
            this.TBComment.Name = "TBComment";
            this.TBComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBComment.Size = new System.Drawing.Size(320, 20);
            this.TBComment.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kommentar zum Versuch:";
            // 
            // NDeviation
            // 
            this.NDeviation.Enabled = false;
            this.NDeviation.Location = new System.Drawing.Point(236, 39);
            this.NDeviation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NDeviation.Name = "NDeviation";
            this.NDeviation.Size = new System.Drawing.Size(74, 20);
            this.NDeviation.TabIndex = 3;
            // 
            // TBPicture
            // 
            this.TBPicture.Location = new System.Drawing.Point(25, 258);
            this.TBPicture.Maximum = 5;
            this.TBPicture.Name = "TBPicture";
            this.TBPicture.Size = new System.Drawing.Size(320, 45);
            this.TBPicture.TabIndex = 5;
            this.TBPicture.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TBPicture.ValueChanged += new System.EventHandler(this.TBPicture_ValueChanged);
            this.TBPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TBPicture_MouseDown);
            // 
            // lblAbstand
            // 
            this.lblAbstand.AutoSize = true;
            this.lblAbstand.Enabled = false;
            this.lblAbstand.Location = new System.Drawing.Point(88, 17);
            this.lblAbstand.Name = "lblAbstand";
            this.lblAbstand.Size = new System.Drawing.Size(125, 13);
            this.lblAbstand.TabIndex = 6;
            this.lblAbstand.Text = "Abstand zur Aussparung:";
            // 
            // BtnOK
            // 
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Location = new System.Drawing.Point(144, 535);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(79, 23);
            this.BtnOK.TabIndex = 14;
            this.BtnOK.Text = "Übernehmen";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // CBChosenPicture
            // 
            this.CBChosenPicture.AutoSize = true;
            this.CBChosenPicture.Location = new System.Drawing.Point(7, 33);
            this.CBChosenPicture.Name = "CBChosenPicture";
            this.CBChosenPicture.Size = new System.Drawing.Size(78, 17);
            this.CBChosenPicture.TabIndex = 15;
            this.CBChosenPicture.Text = "Bestes Bild";
            this.CBChosenPicture.UseVisualStyleBackColor = true;
            this.CBChosenPicture.CheckedChanged += new System.EventHandler(this.CBGewBild_CheckedChanged);
            this.CBChosenPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CBChosenPicture_MouseDown);
            this.CBChosenPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CBChosenPicture_MouseUp);
            // 
            // PBTest
            // 
            this.PBTest.Location = new System.Drawing.Point(25, 12);
            this.PBTest.Name = "PBTest";
            this.PBTest.Size = new System.Drawing.Size(320, 240);
            this.PBTest.TabIndex = 0;
            this.PBTest.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Arduino Debugausgabe:";
            // 
            // TBArduino
            // 
            this.TBArduino.Location = new System.Drawing.Point(25, 450);
            this.TBArduino.Multiline = true;
            this.TBArduino.Name = "TBArduino";
            this.TBArduino.ReadOnly = true;
            this.TBArduino.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBArduino.Size = new System.Drawing.Size(320, 74);
            this.TBArduino.TabIndex = 17;
            // 
            // CBSuccess
            // 
            this.CBSuccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSuccess.Enabled = false;
            this.CBSuccess.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBSuccess.FormattingEnabled = true;
            this.CBSuccess.Location = new System.Drawing.Point(91, 37);
            this.CBSuccess.Name = "CBSuccess";
            this.CBSuccess.Size = new System.Drawing.Size(141, 23);
            this.CBSuccess.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CBChosenPicture);
            this.groupBox2.Controls.Add(this.CBSuccess);
            this.groupBox2.Controls.Add(this.NDeviation);
            this.groupBox2.Controls.Add(this.lblAbstand);
            this.groupBox2.Location = new System.Drawing.Point(25, 299);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 76);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // FormVersuch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 566);
            this.Controls.Add(this.TBArduino);
            this.Controls.Add(this.TBPicture);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBComment);
            this.Controls.Add(this.PBTest);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVersuch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Versuch";
            this.Load += new System.EventHandler(this.FormVersuch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NDeviation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBTest)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBTest;
        private System.Windows.Forms.TextBox TBComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NDeviation;
        private System.Windows.Forms.TrackBar TBPicture;
        private System.Windows.Forms.Label lblAbstand;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.CheckBox CBChosenPicture;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBArduino;
        private System.Windows.Forms.ComboBox CBSuccess;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}