using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KugelfallDbg
{
    //Dient zum generieren von Bildern, die mit Kommentaren 
    //und Abweichungen des Versuches versehen werden können
    public class Versuchsbild
    {
        public Versuchsbild(int _iBufferSize)
        {
            m_bPictures = new System.Drawing.Bitmap[_iBufferSize];
            m_iBestPicture = -1;    //-1 um zu signalisieren, dass es noch keine Bild gibt, dass den Versuch am Besten visualisiert
            m_iDeviation = 0;
            m_iSpin = 0;
            m_sComment = string.Empty;
            m_bSuccess = false;
        }

        //Kommentar zum Bild
        public string Comment
        {
            get { return m_sComment; }
            set { m_sComment = value; }
        }

        /**
         * public int Deviation:
         * Get/Set Methoden für die Abweichung
        */
        public int Deviation
        {
            get { return m_iDeviation; }
            set { m_iDeviation = value; }
        }

        /**
         * public System.Drawing.Bitmap[] Pictures:
         * Get/Set Methoden für die Einzelbilder
        */
        public System.Drawing.Bitmap[] Pictures
        {
            get { return m_bPictures; }
            set
            { m_bPictures = value; }
        }

        //Drehzahl der Platte
        public int Spin
        {
            get { return m_iSpin; }
            set { m_iSpin = value; }
        }
        public string Test
        {
            get { return m_sTest; }
            set { m_sTest = value; }
        }

        /**
         * public bool Success:
         * Get/Set Methoden
        */
        public bool Success
        {
            get { return m_bSuccess; }
            set { m_bSuccess = value; }
        }

        public int BestPicture
        {
            get { return m_iBestPicture;  }
            set { m_iBestPicture = value; }
        }

        private int m_iBestPicture;         //Das Bild, welches den Versuch am Besten darstellt (bspw. die durchgefallene Kugel)
        private int m_iSpin;                //Drehzahl
        private string m_sTest;          //Versuch
        private bool m_bSuccess = false;    //War der Versuch erfolgreich?
        private string m_sComment;          //Kommentar zum Versuchsbild
        private int m_iDeviation;            //Abweichung der Kugel zur Aussparung
        private System.Drawing.Bitmap[] m_bPictures;   //Bild des Versuchs
    }
}
