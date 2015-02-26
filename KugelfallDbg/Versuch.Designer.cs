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
            this.PBVersuch = new System.Windows.Forms.PictureBox();
            this.TBKommentar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NVersatz = new System.Windows.Forms.NumericUpDown();
            this.TBPicture = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CBErfolg = new System.Windows.Forms.CheckBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.CBGewBild = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBVersuch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NVersatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBPicture)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PBVersuch
            // 
            this.PBVersuch.Location = new System.Drawing.Point(12, 12);
            this.PBVersuch.Name = "PBVersuch";
            this.PBVersuch.Size = new System.Drawing.Size(320, 240);
            this.PBVersuch.TabIndex = 0;
            this.PBVersuch.TabStop = false;
            this.PBVersuch.MouseLeave += new System.EventHandler(this.PBVersuch_MouseLeave);
            this.PBVersuch.MouseHover += new System.EventHandler(this.PBVersuch_MouseHover);
            // 
            // TBKommentar
            // 
            this.TBKommentar.Location = new System.Drawing.Point(341, 25);
            this.TBKommentar.Multiline = true;
            this.TBKommentar.Name = "TBKommentar";
            this.TBKommentar.Size = new System.Drawing.Size(199, 59);
            this.TBKommentar.TabIndex = 1;
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
            // NVersatz
            // 
            this.NVersatz.Location = new System.Drawing.Point(410, 203);
            this.NVersatz.Name = "NVersatz";
            this.NVersatz.Size = new System.Drawing.Size(130, 20);
            this.NVersatz.TabIndex = 3;
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
            // CBErfolg
            // 
            this.CBErfolg.AutoSize = true;
            this.CBErfolg.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CBErfolg.Location = new System.Drawing.Point(341, 180);
            this.CBErfolg.Name = "CBErfolg";
            this.CBErfolg.Size = new System.Drawing.Size(133, 17);
            this.CBErfolg.TabIndex = 12;
            this.CBErfolg.Text = "Kugel ist durchgefallen";
            this.CBErfolg.UseVisualStyleBackColor = true;
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
            // CBGewBild
            // 
            this.CBGewBild.AutoSize = true;
            this.CBGewBild.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CBGewBild.Location = new System.Drawing.Point(341, 160);
            this.CBGewBild.Name = "CBGewBild";
            this.CBGewBild.Size = new System.Drawing.Size(90, 17);
            this.CBGewBild.TabIndex = 15;
            this.CBGewBild.Text = "\"Bild wählen\"";
            this.CBGewBild.UseVisualStyleBackColor = true;
            this.CBGewBild.CheckedChanged += new System.EventHandler(this.CBGewBild_CheckedChanged);
            // 
            // FormVersuch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 260);
            this.Controls.Add(this.CBGewBild);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.CBErfolg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NVersatz);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBKommentar);
            this.Controls.Add(this.PBVersuch);
            this.Name = "FormVersuch";
            this.Text = "Versuch";
            this.Load += new System.EventHandler(this.FormVersuch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBVersuch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NVersatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBPicture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBVersuch;
        private System.Windows.Forms.TextBox TBKommentar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NVersatz;
        private System.Windows.Forms.TrackBar TBPicture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CBErfolg;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.CheckBox CBGewBild;
    }
}