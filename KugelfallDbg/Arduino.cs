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
            }

            return true;
        }

        static void m_RS232Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string sTemp = m_RS232Port.ReadLine();  //Temporärer String
            sTemp = sTemp.Replace("\r", "");

            if (sTemp == "trigger") //Der Switch wurde betätigt
            {
                m_bWatch = true;
                m_sDebugText = string.Empty;
            }
            else if (sTemp == "drop") { m_bWatch = false; } //Die Kugel ist durch den Sensor gefallen
            else if (m_bWatch == true)
            {
                m_sDebugText += sTemp;
            }
        }

        public static bool ClosePort()
        {
            //Port schließen
            m_RS232Port.Close();

            return true;
        }

        public static bool IsOpen()
        {
            //Port geöffnet/geschlossen?
            return m_RS232Port.IsOpen;
        }

        public static int ReadData()
        {
            return m_RS232Port.ReadChar();
        }

        public static string DebugText
        {
            get { return m_sDebugText; }
            set { m_sDebugText = value; }
        }

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

        private static SerialPort m_RS232Port = new SerialPort();
        private static string m_sDebugText;             //Ausgaben, welche vom Arduino kommen
        private static bool m_bWatch;   //Ausgaben des Arduino aufzeichnen
    }
}
