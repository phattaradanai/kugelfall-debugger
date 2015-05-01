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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblImageTimes = new System.Windows.Forms.Label();
            this.lblRaisedTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRaisedSample = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
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
            this.button1.Location = new System.Drawing.Point(658, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(739, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "BildIndex:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(798, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(890, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(739, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Momentaner TrackBar Index:";
            // 
            // lblImageTimes
            // 
            this.lblImageTimes.AutoSize = true;
            this.lblImageTimes.Location = new System.Drawing.Point(665, 163);
            this.lblImageTimes.Name = "lblImageTimes";
            this.lblImageTimes.Size = new System.Drawing.Size(70, 13);
            this.lblImageTimes.TabIndex = 7;
            this.lblImageTimes.Text = "_ImageTimes";
            // 
            // lblRaisedTime
            // 
            this.lblRaisedTime.AutoSize = true;
            this.lblRaisedTime.ForeColor = System.Drawing.Color.Red;
            this.lblRaisedTime.Location = new System.Drawing.Point(757, 146);
            this.lblRaisedTime.Name = "lblRaisedTime";
            this.lblRaisedTime.Size = new System.Drawing.Size(70, 13);
            this.lblRaisedTime.TabIndex = 8;
            this.lblRaisedTime.Text = "_ImageTimes";
            this.lblRaisedTime.Click += new System.EventHandler(this.label5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(665, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Event ausgelöst:";
            // 
            // lblRaisedSample
            // 
            this.lblRaisedSample.AutoSize = true;
            this.lblRaisedSample.ForeColor = System.Drawing.Color.Red;
            this.lblRaisedSample.Location = new System.Drawing.Point(927, 146);
            this.lblRaisedSample.Name = "lblRaisedSample";
            this.lblRaisedSample.Size = new System.Drawing.Size(70, 13);
            this.lblRaisedSample.TabIndex = 10;
            this.lblRaisedSample.Text = "_ImageTimes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(839, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "RaisedSample:";
            // 
            // ShowPicturesDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 503);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblRaisedSample);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblRaisedTime);
            this.Controls.Add(this.lblImageTimes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblImageTimes;
        private System.Windows.Forms.Label lblRaisedTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRaisedSample;
        private System.Windows.Forms.Label label7;
    }
}