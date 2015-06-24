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
    public partial class SpD : Form
    {
        public SpD(ref Bitmap[] bitmaps, ref long[] _ImageTime, int _iBestPicAtIndex, long _lEndTime, long _lImpactTime, long _lDuration)
        {
            InitializeComponent();

            m_iImageTime = _ImageTime;
            m_Bitmaps = bitmaps;
            lblBestPicAtIndex.Text = _iBestPicAtIndex.ToString();
            m_iBestPicture = _iBestPicAtIndex;
            lblEndTime.Text = _lEndTime.ToString();
            lblImpactTime.Text = _lImpactTime.ToString();
            lblDuration.Text = _lDuration.ToString();
        }
        
        private int m_iBestPicture = 0;

        private void ShowPicturesDebug_Load(object sender, EventArgs e)
        {
            trackBar1.Maximum = m_Bitmaps.Length-1;
            trackBar1.Value = 0;

            pictureBox1.Image = m_Bitmaps[0];

            //Zeistempel der Bilder eintragen
            lblImageTime.Text = string.Empty;
            for (int i = 0; i < m_iImageTime.Length; i++)
            {
                lblImageTime.Text += i + ": " + m_iImageTime[i] + "ms  |  ";
                i++;
                if(i > m_iImageTime.Length) { break; }
                lblImageTime.Text += i + ": " + m_iImageTime[i] + "ms | ";
                i++;
                if(i > m_iImageTime.Length) { break; }
                lblImageTime.Text += i + ": " + m_iImageTime[i] + "ms\n";
            }

            //Distanz zum Trefferbild aufzeigen
            lblOffsetTime.Text = string.Empty;
            for (int i = m_iBestPicture + 1; i != m_iBestPicture;)
            {
                for (int y = 0; y != 3; y++)
                {
                    if (i >= m_iImageTime.Length) { i = 0; }
                    if (m_iImageTime[i] > m_iImageTime[m_iBestPicture])
                    {
                        lblOffsetTime.Text += i.ToString() + ": +" + (m_iImageTime[i] - m_iImageTime[m_iBestPicture]).ToString();
                    }
                    else
                    {
                        lblOffsetTime.Text += i.ToString() + ": -" + (m_iImageTime[m_iBestPicture] - m_iImageTime[i]).ToString();
                    }
                    i++;

                    if (i == m_iBestPicture) { break;}
                    if (y != 2)
                    {
                        lblOffsetTime.Text += " | ";
                    }
                    else { lblOffsetTime.Text += "\n"; }
                }
                if (i == m_iBestPicture) { lblOffsetTime.Text += i.ToString() + ": " + m_iImageTime[i];}
            }

            
        }

        private System.Drawing.Bitmap[] m_Bitmaps;
        
        private long[] m_iImageTime;
        
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
