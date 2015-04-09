using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.IO.Ports;

namespace KugelfallDbg
{
    //Es darf nur ein RS232-Port als Ausgabe genutzt werden, deshalb static
    static class Arduino
    {
        /**
         *  static bool OpenPort():
         *  Öffnet eine RS232-Verbindung, die die Verbindung zum
         *  Arduino darstellt.
         */
        public static bool OpenPort()
        {
            try
            {
                m_RS232Port.DataReceived += m_RS232Port_DataReceived;

                //Port öffnen
                m_RS232Port.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Port konnte nicht geöffnet werden! " + e.Message, "Portfehler");
                return false;
            }

            return true;
        }

        /** void m_RS232Port_DataReceived:
         * Dieses Event tritt ein, wenn der Serialport Daten erhält 
         */
        static void m_RS232Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string sTemp = m_RS232Port.ReadLine();  //Temporärer String
            sTemp = sTemp.Replace("\r", "");
            m_sDebugText = sTemp;
        }

        /**
         * static bool ClosePort():
         * Schließt den RS232-Port
         */
        public static bool ClosePort()
        {
            //Port schließen
            m_RS232Port.Close();

            return true;
        }

        /**
         * static bool IsOpen():
         * Gibt zurück (true/false), ob der RS232-Port geöffnet oder geschlossen ist.
         */
        public static bool IsOpen()
        {
            //Port geöffnet/geschlossen?
            return m_RS232Port.IsOpen;
        }

        /**
         * static int ReadData():
         * Liest zeichenweise Daten vom RS232-Port 
         */
        public static int ReadData()
        {
            return m_RS232Port.ReadChar();
        }

        /**
         * static string DebugText:
         * Get-/Set-Methode um den vom Arduino kommenden Debugtext zu setzen oder zurück zu geben
         */
        public static string DebugText
        {
            get { return m_sDebugText; }
            set { m_sDebugText = value; }
        }

        /**
         * static void SetParameters(int _Bps, string _sPortName):
         * Legt die Parameter (Baudrate und Port) des RS232-Ports fest.
         */
        public static void SetParameters(int _Bps, string _sPortName)
        {
            m_RS232Port.BaudRate = _Bps;
            m_RS232Port.PortName = _sPortName;
        }

        
        public static SerialPort RS232Port
        {
            get { return m_RS232Port; }
            set { m_RS232Port = value; }
        }

        /**
         * static bool IsSet:
         * Get-/Set-Methode um den RS232-Port festzulegen oder zurückzugeben
         */
        public static bool IsSet    //Arduino eingerichtet?
        {
            get { return m_bArduinoSet; }
            set { m_bArduinoSet = value; }
        }

        private static SerialPort m_RS232Port = new SerialPort();   ///Der RS232-Port des Arduino
        private static string m_sDebugText;         ///Hier werden Ausgaben gespeichert, die vom Arduino kommen
        private static bool m_bWatch;               ///Ausgaben des Arduino aufzeichnen?
        private static bool m_bArduinoSet = false;  ///Wurde der Arduino bereits eingerichtet? (Port)
    }
}
