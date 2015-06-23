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
    public partial class HardwareSettings : Form
    {
        public HardwareSettings(string _sOffsetFile)
        {
            InitializeComponent();
            m_sOffsetfile = _sOffsetFile;
        }

        private void HardwareSettings_Load(object sender, EventArgs e)
        {
            ArduinoSettings();
            CameraSettings();
            AudioSettings();
        }

        private void ArduinoSettings()
        {
            if (GetSerialPorts() == false)  //Keine ComPorts!
            {
                CBRS232Ports.Enabled = false;
                CBBps.Enabled = false;

                return;
            }
        }

        //RS232Ports ermitteln und auflisten
        private bool GetSerialPorts()
        {
            string[] m_sArrayComPortsNames = System.IO.Ports.SerialPort.GetPortNames(); //Alle ComPorts abfragen

            if (m_sArrayComPortsNames.Length == 0) //Keine ComPorts vorhanden
            {
                return false;
            }
            else
            {
                //Ports in Combobox auflisten
                foreach (string sPort in m_sArrayComPortsNames)
                {
                    CBRS232Ports.Items.Add(sPort);
                }

                CBRS232Ports.SelectedIndex = 0;

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

                return true;
            }
        }

        private void CameraSettings()
        {
            m_FilterVideoDevices = new AForge.Video.DirectShow.FilterInfoCollection(AForge.Video.DirectShow.FilterCategory.VideoInputDevice);

            if (m_FilterVideoDevices.Count > 0) //Prüfen ob Kameras verfügbar sind
            {
                foreach (AForge.Video.DirectShow.FilterInfo device in m_FilterVideoDevices)
                {
                    CBCamera.Items.Add(device.Name);
                }

                CBCamera.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Keine Kamera verfügbar, bitte Kamera anschließen.");
                BtnOK.Enabled = false;
            }
        }

        private void AudioSettings()
        {
            int DeviceCount = NAudio.Wave.WaveIn.DeviceCount;
            for (int device = 0; device < DeviceCount; device++)
            {
                NAudio.Wave.WaveInCapabilities DeviceCapabilities = NAudio.Wave.WaveIn.GetCapabilities(device);
                CBAudioDevices.Items.Add(DeviceCapabilities.ProductName);
            }

            CBAudioDevices.SelectedIndex = 0;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            //Arduinoeinstellungen übernehmen
            if (CBRS232Ports.Enabled == true)    //Arduino verfügbar
            {
                if (CBBps.SelectedIndex < 0 || CBRS232Ports.SelectedIndex < 0)
                {
                    MessageBox.Show("Bitte prüfen ob alle Parameter ausgewählt wurden.", "Fehlende Parameter!");
                }
                else
                {
                    Arduino.SetParameters((int)CBBps.SelectedItem, (string)CBRS232Ports.SelectedItem);
                }

                if (Arduino.OpenPort() == true)
                {
                    Arduino.ClosePort();

                    Arduino.IsSet = true;

                    //Einstellungen in den Properties speichern
                    Properties.Settings.Default.ArduinoPort = string.Empty;

                    Properties.Settings.Default.ArduinoPort = Arduino.RS232Port.PortName;
                    Properties.Settings.Default.ArduinoBaudRate = Arduino.RS232Port.BaudRate;

                    Properties.Settings.Default.Save();
                }
                else
                {
                    MessageBox.Show("Fehler beim Öffnen des Arduino Ports!");
                }
            }

            //Kameraeinstellungen

            VideoDeviceMoniker = m_VideoCaptureDevice.Source;

            if (m_VideoCapabilitiesDictionary.Count != 0)
            {
                AForge.Video.DirectShow.VideoCapabilities caps = m_VideoCapabilitiesDictionary[(string)CBResolution.SelectedItem];
                
                m_VideoCaptureDevice.DesiredFrameSize = caps.FrameSize;
                m_VideoCaptureDevice.DesiredFrameRate = caps.FrameRate;
            }

            //Audioeinstellungen übernehmen
            AudioDevice = CBAudioDevices.SelectedIndex;

            //Offset übernehmen
            Offset = Int32.Parse(TBDelay.Text);

            Properties.Settings.Default.Offset = Offset;
            try
            {
                System.IO.File.WriteAllText(m_sOffsetfile, TBDelay.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler beim Schreiben in das Offsetfile");
            }
            Properties.Settings.Default.Save();

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void CBCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_FilterVideoDevices.Count != 0)
            {
                CBResolution.Items.Clear();
                m_VideoCaptureDevice = new AForge.Video.DirectShow.VideoCaptureDevice(m_FilterVideoDevices[CBCamera.SelectedIndex].MonikerString);

                AForge.Video.DirectShow.VideoCapabilities[] vc = m_VideoCaptureDevice.VideoCapabilities;

                foreach (AForge.Video.DirectShow.VideoCapabilities capability in vc)
                {
                    string item = string.Format("{0} x {1}", capability.FrameSize.Width, capability.FrameSize.Height);

                    //Existiert das Item bereits in der Combobox?
                    if(!CBResolution.Items.Contains(item))
                    {
                        CBResolution.Items.Add(item);
                    }

                    //Existiert das Item bereits im Dictionary
                    if (!m_VideoCapabilitiesDictionary.ContainsKey(item))
                    {
                        m_VideoCapabilitiesDictionary.Add(item, capability);
                    }
                    else
                    {
                        if (capability.FrameRate > m_VideoCapabilitiesDictionary[item].FrameRate)
                        {
                            m_VideoCapabilitiesDictionary[item] = capability;
                        }
                    }
                }

                if (vc.Length == 0) { CBResolution.Items.Add("Nicht unterstützt"); }

                VideoDeviceMoniker = m_VideoCaptureDevice.Source;
                CBResolution.SelectedIndex = 0;
            }
        }


        public int Offset { get; set; }

        //NAudio Audio
        private int m_iAudioDevice; //Beinhaltet das Audioaufnahmegerät
        public int AudioDevice
        {
            get { return m_iAudioDevice; }
            set { m_iAudioDevice = value; }
        }

        //AForge Video
        private Dictionary<string, AForge.Video.DirectShow.VideoCapabilities> m_VideoCapabilitiesDictionary = new Dictionary<string, AForge.Video.DirectShow.VideoCapabilities>( );
        public AForge.Video.DirectShow.VideoCaptureDevice VideoCaptureDevice
        {
            get { return m_VideoCaptureDevice; }
        }
        private AForge.Video.DirectShow.VideoCaptureDevice m_VideoCaptureDevice;

        public string VideoDeviceMoniker { get; set; }  //Wird benötigt um das Videogerät eindeutig zu identifizieren
        private AForge.Video.DirectShow.FilterInfoCollection m_FilterVideoDevices;

        private void CBAudioDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioDevice = CBAudioDevices.SelectedIndex;
        }

        private void TBDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b')
            {
                e.Handled = false; //Eingabe nicht verwerfen
            }
            else
            {
                e.Handled = true;
            }
        }

        private void CBResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBCamera.Text.Contains("PS3") == true)
            {
                if (CBResolution.Text.Contains("640")) { TBDelay.Text = 50.ToString(); }
                else if (CBResolution.Text.Contains("320")) { TBDelay.Text = 10.ToString(); }
            }
        }

        public string m_sOffsetfile { get; set; }
    }
}
