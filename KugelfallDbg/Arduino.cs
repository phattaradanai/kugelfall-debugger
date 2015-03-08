using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //throw new NotImplementedException();
            m_sDebugText += m_RS232Port.ReadLine();
            if(m_sDebugText.Length == 100)  //Auf 100 Zeichen beschränken
            {
                m_sDebugText.Remove(0);
            }
            m_sDebugText += ';';    //Trennzeichen
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
            //m_RS232Port.DataBits = _iDataBits;
            //m_RS232Port.Handshake = _Handshake;
            //m_RS232Port.Parity = _Parity;
            //m_RS232Port.StopBits = _StopBits;
            m_RS232Port.PortName = _sPortName;
        }

        /*public static void SetParameters(int _Bps,int _iDataBits, System.IO.Ports.Parity _Parity,System.IO.Ports.Handshake _Handshake, System.IO.Ports.StopBits _StopBits, string _sPortName)
        {
            m_RS232Port.BaudRate = _Bps;
            //m_RS232Port.DataBits = _iDataBits;
            //m_RS232Port.Handshake = _Handshake;
            //m_RS232Port.Parity = _Parity;
            //m_RS232Port.StopBits = _StopBits;
            m_RS232Port.PortName = _sPortName;
        }*/

        public static SerialPort RS232Port
        {
            get { return m_RS232Port; }
            set { m_RS232Port = value; }
        }

        private static SerialPort m_RS232Port = new SerialPort();
        private static string m_sDebugText;             //Ausgaben, welche vom Arduino kommen
    }
}
