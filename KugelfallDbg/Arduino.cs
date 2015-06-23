using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace KugelfallDbg
{
    //Es darf nur ein RS232-Port als Ausgabe genutzt werden, deshalb static
    static class Arduino
    {
        /*
         *  static bool OpenPort():
         *  Öffnet eine RS232-Verbindung, die die Verbindung zum
         *  Arduino darstellt.
         */
        public static bool OpenPort()
        {
            if(!m_RS232Port.IsOpen)
            {
                m_RS232Port.DataReceived += m_RS232Port_DataReceived;
                m_RS232Port.ReadTimeout = 3000;

                //Port öffnen
                try
                {
                    m_RS232Port.Open();
                }
                catch (System.IO.IOException)    //Nicht gefunden
                {
                    return false;
                }
                catch (InvalidOperationException e)
                {
                    m_RS232Port.Close();
                    return false;
                }
            }

            return true;
        }


        /** void m_RS232Port_DataReceived:
         * Dieses Event tritt ein, wenn der Serialport Daten erhält 
         */
        static void m_RS232Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            char sTemp = 'a';
            
            try
            {
                sTemp = (char)m_RS232Port.ReadChar();  //Temporärer String

                m_bStringAccess = true;
                m_sDebugText += sTemp;
                m_bStringAccess = false;

                if (m_sDebugText.Length >= m_iBufferLength)
                {
                    m_sDebugText.Remove(0, 50);
                }
            }
            catch (InvalidOperationException ioe)   //Der Arduino sendete etwas und der Port wurde geschlossen
            {
                System.Windows.Forms.MessageBox.Show(ioe.Message);
            }
            catch (TimeoutException te)
            {
                System.Windows.Forms.MessageBox.Show(te.Message);
                ClosePort();
                IsSet = false;
            }
            catch (System.IO.IOException)
            {
                if (m_RS232Port.IsOpen)
                {
                    ClosePort();
                }
            }
        }
        private static void SafeClose(Object StateInfo)
        {
            try
            {
                m_RS232Port.Close();
                m_RS232Port.DataReceived -= m_RS232Port_DataReceived;
            }
            catch (Exception)
            {
                
            }
        }

        /**
         * static bool ClosePort():
         * Schließt den RS232-Port
         */
        public static bool ClosePort()
        {
            //Port schließen
            if(m_RS232Port.IsOpen == true)
            {
                m_RS232Port.Close();
            }

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
            get
            {
                string temp = m_sDebugText;

                return m_sDebugText;
            }
            set { m_sDebugText = value; }
        }

        /**
         * static void SetParameters(int _Bps, string _sPortName):
         * Legt die Parameter (Baudrate und Port) des RS232-Ports fest.
         */
        public static void SetParameters(int _Bps, string _sPortName)
        {
            try
            {
                m_RS232Port.BaudRate = _Bps;
                m_RS232Port.PortName = _sPortName;
            }
            catch (Exception)
            {
                
            }
        }

        /**
         *  SerialPort RS232Port:
         *  Beinhaltet den Arduino
         */
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

        private static int m_iBufferLength = 120;
        private static SerialPort m_RS232Port = new SerialPort();   ///Der RS232-Port des Arduino
        private static string m_sDebugText = string.Empty;         ///Hier werden Ausgaben gespeichert, die vom Arduino kommen
        private static bool m_bArduinoSet = false;  ///Wurde der Arduino bereits eingerichtet? (Port)
        private static bool m_bStringAccess = false;
    }
}
