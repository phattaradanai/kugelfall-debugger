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

        /**
         * void waveIn_DataAvailable(...)
         * Sobald Daten am Audioeingang vorliegen, wird dieses Event
         * aufgerufen und verarbeitet
         */
        void waveIn_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                short sample = (short)((e.Buffer[index + 1] << 8) | e.Buffer[index + 0]);

                //Sample in 32-bit (4 Byte) umwandeln
                float sample32 = sample / 32768f;
                sample32 *= 100;    //Mal 100 um die Lautstärke zwischen 0 und 100 pendeln zu lassen (sonst 0.0f und 1.0f)
                sample32 = Math.Abs(sample32);
                
                m_iVolume = Convert.ToInt32(sample32);
                if (m_iVolume > m_iMaxVolume)
                {
                    m_iMaxVolume = m_iVolume;
                }
            }
        }

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

        /**
         *  void StopRecording():
         *  Stoppt die Audioaufnahme 
         */
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

        /**
         * int MaxVolume:
         * Gibt die aktuelle Lautstärke zurück
         */

        public int Volume
        {
            get { return m_iVolume; }
            set { m_iVolume = value; }
        }
        public int MaxVolume
        {
            get
            {
                    return m_iMaxVolume;
            }
            set { m_iMaxVolume = value; }
        }

        private int m_iSampleRate = 44100;
        private int m_iChannels = 1;    ///Wieviele Kanäle sollen zur Aufnahme benutzt werden (Default: 1 -> Mono)
        private int m_iDeviceNumber;    ///Nummer des Soundaufnahmegerätes (Dient zur Identifikation)
        private int m_iVolume;          ///Die aktuelle Lautstärke
        private int m_iMaxVolume;       ///Die aktuelle maximale Lautstärke
        private NAudio.Wave.WaveIn m_iWaveInDevice;
        
        /* AB WINDOWS VISTA
        public NAudio.CoreAudioApi.MMDevice AudioDevice
        {
            get { return m_AudioDevice; }
            set { m_AudioDevice = value; }
        }

        private NAudio.CoreAudioApi.MMDevice m_AudioDevice;
        **/
    }
}
