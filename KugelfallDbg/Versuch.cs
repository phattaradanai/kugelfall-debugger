using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KugelfallDbg
{
    public partial class FormVersuch : Form
    {
        public FormVersuch(ref Versuchsbild _v)
        {
            InitializeComponent();

            m_Versuchsbild = _v;
        }

        private Versuchsbild m_Versuchsbild;

        private void BtnOK_Click(object sender, EventArgs e)
        {
            m_Versuchsbild.Comment = TBComment.Text;
            m_Versuchsbild.Deviation = int.Parse(NDeviation.Value.ToString());
            m_Versuchsbild.Success = CBSuccess.Checked;
        }

        //Die aktuellen Versuchsdaten zurückgeben
        public Versuchsbild GetVersuch
        {
            get { return m_Versuchsbild; }
        }

        private void FormVersuch_Load(object sender, EventArgs e)
        {
            if (m_Versuchsbild.BestPicture != -1)   //Falls es bereits ein Bild geben sollte
            {
                TBPicture.Value = m_Versuchsbild.BestPicture;
                CBChosenPicture.Checked = true;
            }
            else
            {
                PBTest.Image = new Bitmap(m_Versuchsbild.Pictures[0], new Size(PBTest.Width, PBTest.Height));
            }
            
            //Alle Daten in die Felder laden
            TBComment.Text = m_Versuchsbild.Comment;
            NDeviation.Value = m_Versuchsbild.Deviation;
            CBSuccess.Checked = m_Versuchsbild.Success;
        }

        private void CBGewBild_CheckedChanged(object sender, EventArgs e)
        {
            if (CBChosenPicture.Checked == true)
            {
                m_Versuchsbild.BestPicture = TBPicture.Value;
            }
        }

        private void TBPicture_ValueChanged(object sender, EventArgs e)
        {
            PBTest.Image = new Bitmap(m_Versuchsbild.Pictures[TBPicture.Value], new Size(PBTest.Width, PBTest.Height));
            if (m_Versuchsbild.BestPicture == TBPicture.Value)
            { CBChosenPicture.Checked = true; }
            else { CBChosenPicture.Checked = false; }
        }
    }
}
