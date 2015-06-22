namespace KugelfallDbg
{
    partial class ShowPicturesDebug
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBestPicAtIndex = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOffsetTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblImageTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblImpactTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(658, 12);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(322, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(986, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(665, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bestes Bild bei Index:";
            // 
            // lblBestPicAtIndex
            // 
            this.lblBestPicAtIndex.AutoSize = true;
            this.lblBestPicAtIndex.ForeColor = System.Drawing.Color.Red;
            this.lblBestPicAtIndex.Location = new System.Drawing.Point(806, 84);
            this.lblBestPicAtIndex.Name = "lblBestPicAtIndex";
            this.lblBestPicAtIndex.Size = new System.Drawing.Size(89, 13);
            this.lblBestPicAtIndex.TabIndex = 4;
            this.lblBestPicAtIndex.Text = "lblBestPicAtIndex";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(816, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(665, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Momentaner TrackBar Index:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(665, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Zeitstempel der Bilder:";
            // 
            // lblOffsetTime
            // 
            this.lblOffsetTime.AutoSize = true;
            this.lblOffsetTime.ForeColor = System.Drawing.Color.Red;
            this.lblOffsetTime.Location = new System.Drawing.Point(898, 159);
            this.lblOffsetTime.Name = "lblOffsetTime";
            this.lblOffsetTime.Size = new System.Drawing.Size(68, 13);
            this.lblOffsetTime.TabIndex = 8;
            this.lblOffsetTime.Text = "lblOffsetTime";
            this.lblOffsetTime.Click += new System.EventHandler(this.label5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(665, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Zeit des Samplepaketes:";
            // 
            // lblImageTime
            // 
            this.lblImageTime.AutoSize = true;
            this.lblImageTime.ForeColor = System.Drawing.Color.Red;
            this.lblImageTime.Location = new System.Drawing.Point(665, 159);
            this.lblImageTime.Name = "lblImageTime";
            this.lblImageTime.Size = new System.Drawing.Size(69, 13);
            this.lblImageTime.TabIndex = 10;
            this.lblImageTime.Text = "lblImageTime";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(897, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Abstand zum Treffersample";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.ForeColor = System.Drawing.Color.Red;
            this.lblEndTime.Location = new System.Drawing.Point(806, 97);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(59, 13);
            this.lblEndTime.TabIndex = 12;
            this.lblEndTime.Text = "lblEndTime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(665, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Berechnete Trefferzeit:";
            // 
            // lblImpactTime
            // 
            this.lblImpactTime.AutoSize = true;
            this.lblImpactTime.ForeColor = System.Drawing.Color.Red;
            this.lblImpactTime.Location = new System.Drawing.Point(806, 110);
            this.lblImpactTime.Name = "lblImpactTime";
            this.lblImpactTime.Size = new System.Drawing.Size(72, 13);
            this.lblImpactTime.TabIndex = 14;
            this.lblImpactTime.Text = "lblImpactTime";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(665, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Dauer des Samplepaketes:";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.ForeColor = System.Drawing.Color.Red;
            this.lblDuration.Location = new System.Drawing.Point(806, 123);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(57, 13);
            this.lblDuration.TabIndex = 16;
            this.lblDuration.Text = "lblDuration";
            // 
            // ShowPicturesDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 503);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblImpactTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblImageTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblOffsetTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblBestPicAtIndex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ShowPicturesDebug";
            this.Text = "ShowPicturesDebug";
            this.Load += new System.EventHandler(this.ShowPicturesDebug_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBestPicAtIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOffsetTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblImageTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblImpactTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDuration;
    }
}