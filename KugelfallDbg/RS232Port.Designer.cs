namespace KugelfallDbg
{
    partial class RS232Port
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            this.CBBps = new System.Windows.Forms.ComboBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.CBDataBits = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBParity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CBStopBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CBFlowControl = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CBRS232Ports = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bits/Sekunde:";
            // 
            // BtnOK
            // 
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Location = new System.Drawing.Point(142, 203);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 1;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // CBBps
            // 
            this.CBBps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBBps.FormattingEnabled = true;
            this.CBBps.Location = new System.Drawing.Point(94, 46);
            this.CBBps.Name = "CBBps";
            this.CBBps.Size = new System.Drawing.Size(145, 21);
            this.CBBps.TabIndex = 2;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(63, 203);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Abbrechen";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // CBDataBits
            // 
            this.CBDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBDataBits.FormattingEnabled = true;
            this.CBDataBits.Location = new System.Drawing.Point(94, 73);
            this.CBDataBits.Name = "CBDataBits";
            this.CBDataBits.Size = new System.Drawing.Size(145, 21);
            this.CBDataBits.TabIndex = 5;
            this.CBDataBits.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parität:";
            this.label2.Visible = false;
            // 
            // CBParity
            // 
            this.CBParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBParity.FormattingEnabled = true;
            this.CBParity.Location = new System.Drawing.Point(94, 100);
            this.CBParity.Name = "CBParity";
            this.CBParity.Size = new System.Drawing.Size(145, 21);
            this.CBParity.TabIndex = 7;
            this.CBParity.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Datenbits:";
            this.label3.Visible = false;
            // 
            // CBStopBits
            // 
            this.CBStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBStopBits.FormattingEnabled = true;
            this.CBStopBits.Location = new System.Drawing.Point(94, 127);
            this.CBStopBits.Name = "CBStopBits";
            this.CBStopBits.Size = new System.Drawing.Size(145, 21);
            this.CBStopBits.TabIndex = 9;
            this.CBStopBits.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Stoppbits:";
            this.label4.Visible = false;
            // 
            // CBFlowControl
            // 
            this.CBFlowControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFlowControl.FormattingEnabled = true;
            this.CBFlowControl.Location = new System.Drawing.Point(94, 154);
            this.CBFlowControl.Name = "CBFlowControl";
            this.CBFlowControl.Size = new System.Drawing.Size(145, 21);
            this.CBFlowControl.TabIndex = 11;
            this.CBFlowControl.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Flusssteuerung:";
            this.label5.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CBRS232Ports);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CBFlowControl);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CBStopBits);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CBParity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CBDataBits);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CBBps);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 188);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameter";
            // 
            // CBRS232Ports
            // 
            this.CBRS232Ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBRS232Ports.FormattingEnabled = true;
            this.CBRS232Ports.Location = new System.Drawing.Point(94, 19);
            this.CBRS232Ports.Name = "CBRS232Ports";
            this.CBRS232Ports.Size = new System.Drawing.Size(145, 21);
            this.CBRS232Ports.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Port:";
            // 
            // RS232Port
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 233);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Name = "RS232Port";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "RS232-Einstellungen";
            this.Load += new System.EventHandler(this.RS232Port_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.ComboBox CBBps;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ComboBox CBDataBits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBParity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBStopBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBFlowControl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CBRS232Ports;
        private System.Windows.Forms.Label label6;
    }
}