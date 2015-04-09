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
    public partial class FormVersuch : Form
    {
        public FormVersuch(ref Versuchsbild _v)
        {
            InitializeComponent();

            m_Versuchsbild = _v;
        }

        /**
         * void BtnOK_Click(...)
         * Passt die Versuchsauswertung entsprechend den Änderungen an
         */
        private void BtnOK_Click(object sender, EventArgs e)
        {
            m_Versuchsbild.Comment = TBComment.Text;
            m_Versuchsbild.Deviation = int.Parse(NDeviation.Value.ToString());
            m_Versuchsbild.Success = CBSuccess.Checked;
        }

        /// <summary>
        /// Die aktuellen Versuchsdaten zurückgeben
        /// </summary>

        public Versuchsbild GetVersuch
        {
            get { return m_Versuchsbild; }
        }

        /**
         *  void FormVersuch_Load(...)
         *  Trägt in die Felder sämtliche vorhandenen Werte ein.
         */
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
            TBArduino.Text = m_Versuchsbild.Debugtext;
        }

        /// <summary>
        /// Die Auswahl des besten Bildes hat sich geändert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBGewBild_CheckedChanged(object sender, EventArgs e)
        {
            if (CBChosenPicture.Checked == true)
            {
                m_Versuchsbild.BestPicture = TBPicture.Value;
            }
        }

        /// <summary>
        /// Der Slider zur Bildauswahl hat seinen Wert verändert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBPicture_ValueChanged(object sender, EventArgs e)
        {
            PBTest.Image = new Bitmap(m_Versuchsbild.Pictures[TBPicture.Value], new Size(PBTest.Width, PBTest.Height));
            if (m_Versuchsbild.BestPicture == TBPicture.Value) { CBChosenPicture.Checked = true; }
            else { CBChosenPicture.Checked = false; }
        }

        /// <summary>
        /// Der Slider zur Bildauswahl lässt leider von Haus aus kein direktes Klicken zu.
        /// Deshalb prüft diese Methode, wo sich der Mauszeiger zum Klickzeitpunkt befand, um
        /// den am nähesten liegenden klickbaren Wert zu wählen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBPicture_MouseDown(object sender, MouseEventArgs e)
        {
            double dblValue = 0.0;

            // Jump to the clicked location
            dblValue = ((double)e.X / (double)TBPicture.Width) * (TBPicture.Maximum - TBPicture.Minimum);
            TBPicture.Value = Convert.ToInt32(dblValue);
        }

        private Versuchsbild m_Versuchsbild;
    }
}
