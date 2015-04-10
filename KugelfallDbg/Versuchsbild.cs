using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

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
            m_sText = string.Empty;
            m_sComment = string.Empty;
            m_bSuccess = false;
        }

        /**
         * string Comment:
         * Beinhaltet den Kommentar zum Bild
         */
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

        /**
         * string Debugtext:
         * Hier werden die Debugausgaben des Arduino gespeichert
         */
        public string Debugtext
        {
            get { return m_sText; }
            set { m_sText = value; }
        }

        //Versuch + Nummer
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

        /**
         * int BestPicture:
         * Gibt das beste Bild an, also welches Bild den (Miss-)Erfolg am Besten darstellt
         */
        public int BestPicture
        {
            get { return m_iBestPicture;  }
            set { m_iBestPicture = value; }
        }

        private int m_iBestPicture;         //Das Bild, welches den Versuch am Besten darstellt (bspw. die durchgefallene Kugel)
        private string m_sText;                //Arduino Debuggingtext
        private string m_sTest;          //Versuch
        private bool m_bSuccess = false;    //War der Versuch erfolgreich?
        private string m_sComment;          //Kommentar zum Versuchsbild
        private int m_iDeviation;            //Abweichung der Kugel zur Aussparung
        private System.Drawing.Bitmap[] m_bPictures;   //Bild des Versuchs
    }
}
