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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CBSuccess = new System.Windows.Forms.CheckBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.CBChosenPicture = new System.Windows.Forms.CheckBox();
            this.PBTest = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NDeviation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBPicture)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBTest)).BeginInit();
            this.SuspendLayout();
            // 
            // TBComment
            // 
            this.TBComment.Location = new System.Drawing.Point(341, 25);
            this.TBComment.Multiline = true;
            this.TBComment.Name = "TBComment";
            this.TBComment.Size = new System.Drawing.Size(199, 59);
            this.TBComment.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kommentar zum Versuch:";
            // 
            // NDeviation
            // 
            this.NDeviation.Location = new System.Drawing.Point(410, 203);
            this.NDeviation.Name = "NDeviation";
            this.NDeviation.Size = new System.Drawing.Size(130, 20);
            this.NDeviation.TabIndex = 3;
            // 
            // TBPicture
            // 
            this.TBPicture.Location = new System.Drawing.Point(6, 13);
            this.TBPicture.Maximum = 5;
            this.TBPicture.Name = "TBPicture";
            this.TBPicture.Size = new System.Drawing.Size(187, 45);
            this.TBPicture.TabIndex = 5;
            this.TBPicture.ValueChanged += new System.EventHandler(this.TBPicture_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Versatz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "6";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TBPicture);
            this.groupBox1.Location = new System.Drawing.Point(341, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 64);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bilder";
            // 
            // CBSuccess
            // 
            this.CBSuccess.AutoSize = true;
            this.CBSuccess.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CBSuccess.Location = new System.Drawing.Point(341, 180);
            this.CBSuccess.Name = "CBSuccess";
            this.CBSuccess.Size = new System.Drawing.Size(133, 17);
            this.CBSuccess.TabIndex = 12;
            this.CBSuccess.Text = "Kugel ist durchgefallen";
            this.CBSuccess.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(338, 229);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(79, 23);
            this.BtnCancel.TabIndex = 13;
            this.BtnCancel.Text = "Verwerfen";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Location = new System.Drawing.Point(423, 229);
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
            this.CBChosenPicture.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CBChosenPicture.Location = new System.Drawing.Point(341, 160);
            this.CBChosenPicture.Name = "CBChosenPicture";
            this.CBChosenPicture.Size = new System.Drawing.Size(90, 17);
            this.CBChosenPicture.TabIndex = 15;
            this.CBChosenPicture.Text = "\"Bild wählen\"";
            this.CBChosenPicture.UseVisualStyleBackColor = true;
            this.CBChosenPicture.CheckedChanged += new System.EventHandler(this.CBGewBild_CheckedChanged);
            // 
            // PBTest
            // 
            this.PBTest.Location = new System.Drawing.Point(12, 12);
            this.PBTest.Name = "PBTest";
            this.PBTest.Size = new System.Drawing.Size(320, 240);
            this.PBTest.TabIndex = 0;
            this.PBTest.TabStop = false;
            this.PBTest.MouseLeave += new System.EventHandler(this.PBVersuch_MouseLeave);
            this.PBTest.MouseHover += new System.EventHandler(this.PBVersuch_MouseHover);
            // 
            // FormVersuch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 260);
            this.Controls.Add(this.CBChosenPicture);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.CBSuccess);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NDeviation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBComment);
            this.Controls.Add(this.PBTest);
            this.Name = "FormVersuch";
            this.ShowIcon = false;
            this.Text = "Versuch";
            this.Load += new System.EventHandler(this.FormVersuch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NDeviation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBPicture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBTest;
        private System.Windows.Forms.TextBox TBComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NDeviation;
        private System.Windows.Forms.TrackBar TBPicture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CBSuccess;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.CheckBox CBChosenPicture;
    }
}