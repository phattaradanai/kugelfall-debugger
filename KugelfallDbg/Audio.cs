using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace KugelfallDbg
{
    //Das Gerät, von dem der Ton aufgezeichnet wird
    class Audio
    {
        public Audio(int _iDeviceNumber)
        {
            m_iDeviceNumber = _iDeviceNumber;
            m_iWaveInDevice = new NAudio.Wave.WaveIn();
            m_iWaveInDevice.WaveFormat = new NAudio.Wave.WaveFormat(m_iSampleRate, m_iChannels);
            m_iWaveInDevice.DataAvailable += waveIn_DataAvailable;
            m_iWaveInDevice.DeviceNumber = m_iDeviceNumber;
        }

        //Sample aus dem Buffer holen
        void waveIn_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                short sample = (short)((e.Buffer[index + 1] << 8) |
                                        e.Buffer[index + 0]);
                float sample32 = sample / 32768f;
                rawvalue = sample32;
                sample32 *= 100;
                sample32 = Math.Abs(sample32);
                m_iMaxVolume = (int)sample32;

            }
        }
        public float getrawvalue() { return rawvalue; }
        private float rawvalue = 0;

        public void StartRecording()
        {
            //Sollte der Recordingvorgang unterbrochen worden sein, muss das WaveInDevice neu angefordert werden
            if (m_iWaveInDevice == null)
            {
                m_iWaveInDevice = new NAudio.Wave.WaveIn();
                m_iWaveInDevice.DeviceNumber = m_iDeviceNumber;
                m_iWaveInDevice.WaveFormat = new NAudio.Wave.WaveFormat(m_iSampleRate,m_iChannels);
                m_iWaveInDevice.DataAvailable += waveIn_DataAvailable;
            }
            
            m_iWaveInDevice.StartRecording();
        }

        public void StopRecording()
        {
            if (m_iWaveInDevice != null)
            {
                m_iWaveInDevice.Dispose();
                m_iWaveInDevice = null;
            }
        }

        public NAudio.Wave.WaveIn WaveInDevice
        {
            get { return m_iWaveInDevice; }
        }

        public int MaxVolume
        {
            get { return m_iMaxVolume; }
            set { m_iMaxVolume = value; }
        }

        private int m_iSampleRate = 44100;
        private int m_iChannels = 1;
        private int m_iDeviceNumber;    //Nummer des Soundaufnahmegerätes
        private int m_iMaxVolume;
        private NAudio.Wave.WaveIn m_iWaveInDevice;
        
        /*
        public NAudio.CoreAudioApi.MMDevice AudioDevice
        {
            get { return m_AudioDevice; }
            set { m_AudioDevice = value; }
        }

        private NAudio.CoreAudioApi.MMDevice m_AudioDevice;
        **/
    }
}
