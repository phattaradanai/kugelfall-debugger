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
    public partial class ArduinoConfig : Form
    {
        public ArduinoConfig()
        {
            InitializeComponent();
        }

        private string[] m_sArrayComPortsNames = null;

        //RS232Ports ermitteln und auflisten
        private bool GetSerialPorts()
        {
            m_sArrayComPortsNames = System.IO.Ports.SerialPort.GetPortNames(); //Alle ComPorts abfragen

            if (m_sArrayComPortsNames.Length == 0) //Keine ComPorts vorhanden
            {
                return false;
            }
            else
            {
                //Ports in Combobox auflisten
                foreach(string sPort in m_sArrayComPortsNames)
                {
                    CBRS232Ports.Items.Add(sPort);
                }

                CBRS232Ports.SelectedIndex = 0;

                //CBRS232Ports.Update();

                return true;
            }
        }

        //Restliche Parameter in Comboboxen eintragen
        
        private void GetParameters()
        {
            //Bits pro Sekunde
            CBBps.Items.Add(300);
            CBBps.Items.Add(600);
            CBBps.Items.Add(1200);
            CBBps.Items.Add(2400);
            CBBps.Items.Add(4800);
            CBBps.Items.Add(9600);
            CBBps.SelectedIndex = CBBps.Items.Count - 1;    //9600Bps als Default-Parameter (wird auch in den Arduino Beispielen genutzt)
            CBBps.Items.Add(14400);
            CBBps.Items.Add(19200);
            CBBps.Items.Add(28800);
            CBBps.Items.Add(38400);
            CBBps.Items.Add(56000);
            CBBps.Items.Add(57600);
            CBBps.Items.Add(115200);

            //Datenbits
            //CBDataBits.Items.Add(7);
            //CBDataBits.Items.Add(8);

            ////Parität
            //CBParity.Items.Add(System.IO.Ports.Parity.Even);
            //CBParity.Items.Add(System.IO.Ports.Parity.Mark);
            //CBParity.Items.Add(System.IO.Ports.Parity.None);
            //CBParity.Items.Add(System.IO.Ports.Parity.Odd);
            //CBParity.Items.Add(System.IO.Ports.Parity.Space);

            ////Flusssteuerung
            //CBFlowControl.Items.Add(System.IO.Ports.Handshake.XOnXOff);
            //CBFlowControl.Items.Add(System.IO.Ports.Handshake.RequestToSend);
            //CBFlowControl.Items.Add(System.IO.Ports.Handshake.RequestToSendXOnXOff);
            //CBFlowControl.Items.Add(System.IO.Ports.Handshake.None);

            ////Stoppbits
            //CBStopBits.Items.Add(System.IO.Ports.StopBits.One);
            //CBStopBits.Items.Add(System.IO.Ports.StopBits.OnePointFive);
            //CBStopBits.Items.Add(System.IO.Ports.StopBits.Two);
        }
        
        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (CBBps.SelectedIndex < 0 ||/* CBDataBits.SelectedIndex < 0 || CBFlowControl.SelectedIndex < 0 || CBParity.SelectedIndex < 0 ||*/
               CBRS232Ports.SelectedIndex < 0 /*|| CBStopBits.SelectedIndex < 0*/)
            {
                MessageBox.Show("Bitte prüfen ob alle Parameter ausgewählt wurden.", "Fehlende Parameter!");
            }
            else
            {
                Arduino.SetParameters((int)CBBps.SelectedItem,
                                      /*(int)CBDataBits.SelectedItem,
                                      (System.IO.Ports.Parity)CBParity.SelectedItem,
                                      (System.IO.Ports.Handshake)CBFlowControl.SelectedItem,
                                      (System.IO.Ports.StopBits)CBStopBits.SelectedItem,*/
                                      (string)CBRS232Ports.SelectedItem);
                this.Close();
                return;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ArduinoConfig_Load(object sender, EventArgs e)
        {
            if (GetSerialPorts() == false)  //Keine ComPorts!
            {
                MessageBox.Show("Keine RS232-Ports vorhanden", "Keine RS232-Ports");
                this.Close();
                return;
            }

            GetParameters();
        }


    }

    //Alle Parameter in einer Variable
}
