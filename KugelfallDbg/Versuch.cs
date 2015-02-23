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
            m_Versuchsbild.Comment = TBKommentar.Text;
            m_Versuchsbild.Deviation = int.Parse(NVersatz.Value.ToString());
            //m_Versuchsbild.Pictures = m_Bitmap;
            m_Versuchsbild.Success = CBErfolg.Checked;
        }

        //Die aktuellen Versuchsdaten zurückgeben
        public Versuchsbild GetVersuch
        {
            get { return m_Versuchsbild; }
        }

        private void PBVersuch_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void PBVersuch_MouseLeave(object sender, EventArgs e)
        {

        }

        private void FormVersuch_Load(object sender, EventArgs e)
        {
            if (m_Versuchsbild.BestPicture != -1)   //Falls es bereits ein Bild geben sollte
            {
                TBPicture.Value = m_Versuchsbild.BestPicture;
                CBGewBild.Checked = true;
            }
            else
            {
                PBVersuch.Image = new Bitmap(m_Versuchsbild.Pictures[0], new Size(PBVersuch.Width, PBVersuch.Height));
            }
            
            //Alle Daten in die Felder laden
            TBKommentar.Text = m_Versuchsbild.Comment;
            NVersatz.Value = m_Versuchsbild.Deviation;
            CBErfolg.Checked = m_Versuchsbild.Success;
        }

        private void CBGewBild_CheckedChanged(object sender, EventArgs e)
        {
            if (CBGewBild.Checked == true)
            {
                m_Versuchsbild.BestPicture = TBPicture.Value;
            }
        }

        private void TBPicture_ValueChanged(object sender, EventArgs e)
        {
            PBVersuch.Image = new Bitmap(m_Versuchsbild.Pictures[TBPicture.Value], new Size(PBVersuch.Width, PBVersuch.Height));
            if (m_Versuchsbild.BestPicture == TBPicture.Value)
            { CBGewBild.Checked = true; }
            else { CBGewBild.Checked = false; }
        }
    }
}
