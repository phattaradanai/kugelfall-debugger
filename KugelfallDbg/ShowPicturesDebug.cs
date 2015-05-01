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
    public partial class ShowPicturesDebug : Form
    {
        public ShowPicturesDebug(ref Bitmap[] bitmaps, int FramesBack, ref int[] _ImageTime, ref float _EventRaised, float _fRaisedSample)
        {
            InitializeComponent();
            m_Bitmaps = bitmaps;
            m_Back = FramesBack;
            t_iImageTime = _ImageTime;
            t_fRaisedSample = _fRaisedSample;
            t_fEventRaised = _EventRaised;
        }

        private void ShowPicturesDebug_Load(object sender, EventArgs e)
        {
            trackBar1.Maximum = m_Bitmaps.Length-1;
            trackBar1.Value = 0;
            pictureBox1.Image = m_Bitmaps[0];
            label2.Text = m_Back.ToString();
            lblImageTimes.Text = string.Empty;

            for (int i = 0; i < t_iImageTime.Length; i++)
            {
                lblImageTimes.Text += i + ": " + t_iImageTime[i] + "ms  |  ";
                i++;
                lblImageTimes.Text += i + ": " + t_iImageTime[i] + "ms\n";
            }

            lblRaisedTime.Text = t_fEventRaised.ToString() + "ms";
            lblRaisedSample.Text = t_fRaisedSample.ToString();
        }

        private System.Drawing.Bitmap[] m_Bitmaps;
        private int m_Back = 0;
        private int[] t_iImageTime;
        private float t_fRaisedSample = 0.0f;
        private float t_fEventRaised = 0.0f;

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = m_Bitmaps[trackBar1.Value];
            label3.Text = trackBar1.Value.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
