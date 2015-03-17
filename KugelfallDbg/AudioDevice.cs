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
    public partial class FormAudioDevice : Form
    {
        public FormAudioDevice()
        {
            InitializeComponent();
        }



        //public NAudio.CoreAudioApi.MMDevice m_Device;
        public int m_iSelectedDevice;

        private void FormAudioDevice_Load(object sender, EventArgs e)
        {
            int DeviceCount = NAudio.Wave.WaveIn.DeviceCount;
            for (int device = 0; device < DeviceCount; device++)
            {
                NAudio.Wave.WaveInCapabilities DeviceCapabilities = NAudio.Wave.WaveIn.GetCapabilities(device);
                CBAudioDevices.Items.Add(DeviceCapabilities.ProductName);
            }

            CBAudioDevices.SelectedIndex = 0;
            /*
            //Alle aufzeichnenden aktiven Geräte auflisten
            NAudio.CoreAudioApi.MMDeviceEnumerator mde = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            NAudio.CoreAudioApi.MMDeviceCollection mdc = mde.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.Capture,NAudio.CoreAudioApi.DeviceState.Active);

            //Geräte anschließend zur Auswahl stellen
            for(int i = 0;i < mdc.Count; i++)
            {
                CBAudioDevices.Items.Add(mdc[i]);
            }

            if (CBAudioDevices.Items.Count > 0)
            {
                CBAudioDevices.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Keine Aufnahmegeräte vorhanden");
            }*/
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (CBAudioDevices.Items.Count > 0)
            {
                //m_Device = (NAudio.CoreAudioApi.MMDevice)CBAudioDevices.SelectedItem;
                m_iSelectedDevice = CBAudioDevices.SelectedIndex;
            }
            else
            {
                MessageBox.Show("Kein Aufnahmegerät vorhanden!");
            }
        }
    }
}
