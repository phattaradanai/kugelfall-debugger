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
    public partial class FormAudioDevice : Form
    {
        public FormAudioDevice()
        {
            InitializeComponent();
        }



        public NAudio.CoreAudioApi.MMDevice m_Device;

        private void FormAudioDevice_Load(object sender, EventArgs e)
        {

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
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (CBAudioDevices.Items.Count > 0)
            {
                m_Device = (NAudio.CoreAudioApi.MMDevice)CBAudioDevices.SelectedItem;
            }
            else
            {
                MessageBox.Show("Kein Aufnahmegerät vorhanden!");
            }
        }
    }
}
