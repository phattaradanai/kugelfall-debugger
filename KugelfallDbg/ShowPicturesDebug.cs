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
        public ShowPicturesDebug(ref Bitmap[] bitmaps, int FramesBack)
        {
            InitializeComponent();
            m_Bitmaps = bitmaps;
            m_Back = FramesBack;
        }

        private void ShowPicturesDebug_Load(object sender, EventArgs e)
        {
            trackBar1.Maximum = m_Bitmaps.Length-1;
            trackBar1.Value = 0;
            pictureBox1.Image = m_Bitmaps[0];
            label2.Text = m_Back.ToString();
        }

        private System.Drawing.Bitmap[] m_Bitmaps;
        private int m_Back = 0;

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = m_Bitmaps[trackBar1.Value];
        }
    }
}
