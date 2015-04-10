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
        private int m_iSelectedDevice;
        public int SelectedDevice
        {
            get { return m_iSelectedDevice; }
            set { m_iSelectedDevice = value; }
        }

        private void FormAudioDevice_Load(object sender, EventArgs e)
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
            if (CBAudioDevices.Items.Count > 0)
            {
                //m_Device = (NAudio.CoreAudioApi.MMDevice)CBAudioDevices.SelectedItem;
                m_iSelectedDevice = CBAudioDevices.SelectedIndex;

                Properties.Settings.Default.AudioDevice = m_iSelectedDevice;//NAudio.Wave.WaveIn.GetCapabilities(CBAudioDevices.SelectedIndex).ProductName;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Kein Aufnahmegerät vorhanden!");
            }
        }
    }
}
