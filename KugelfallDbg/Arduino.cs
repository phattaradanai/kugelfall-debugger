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
                m_RS232Port.ReadTimeout = 3000;

                //Port öffnen
                try
                {
                    m_RS232Port.Open();
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Fehler beim Öffnen des Ports, bitte Ports überprüfen");
                    m_RS232Port.DataReceived -= m_RS232Port_DataReceived;
                    return false;
                }
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
            char sTemp = 'a';
            try
            {
                sTemp = (char) m_RS232Port.ReadChar();  //Temporärer String
            }
            catch (InvalidOperationException ioe)   //Der Arduino sendete etwas und der Port wurde geschlossen
            {
                System.Windows.Forms.MessageBox.Show(ioe.Message);
            }
            catch(TimeoutException te)
            {
                System.Windows.Forms.MessageBox.Show(te.Message);
            }
                //sTemp = sTemp.Replace("\r", "");
            m_bStringAccess = true;
            m_sDebugText += sTemp;
            m_bStringAccess = false;

            if (m_sDebugText.Length >= m_iBufferLength)
            {
                m_sDebugText.Remove(0, 50);
            }
            /*}
            catch (System.IO.IOException ioe)
            {
                if (m_RS232Port.IsOpen)
                {
                    ClosePort();
                    System.Windows.Forms.MessageBox.Show("IOException" + ioe.Message);
                }
            }
            
            catch (System.Runtime.InteropServices.COMException com) //Wenn die Anwendung ausgelastet ist, wird diese Exception geworfen
            {
                System.Windows.Forms.MessageBox.Show("COMException");
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }*/
        }
        private static void SafeClose(Object StateInfo)
        {
            m_RS232Port.Close();
            m_RS232Port.DataReceived -= m_RS232Port_DataReceived;
        }

        /**
         * static bool ClosePort():
         * Schließt den RS232-Port
         */
        public static bool ClosePort()
        {
            //Port schließen
            ThreadPool.QueueUserWorkItem(new WaitCallback(SafeClose));
            
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
                //m_bStringAccess = true;
                //m_sDebugText = string.Empty;
                //m_bStringAccess = false;
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
            m_RS232Port.BaudRate = _Bps;
            m_RS232Port.PortName = _sPortName;
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
