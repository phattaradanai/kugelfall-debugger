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
            m_iWaveInDevice.WaveFormat = new NAudio.Wave.WaveFormat(SampleRate, m_iChannels);
            m_iWaveInDevice.DataAvailable += waveIn_DataAvailable;
            m_iWaveInDevice.DeviceNumber = m_iDeviceNumber;
            m_iWaveInDevice.BufferMilliseconds = 100;
            BufferMilliseconds = m_iWaveInDevice.BufferMilliseconds;
        }

        /**
         * void waveIn_DataAvailable(...)
         * Sobald Daten am Audioeingang vorliegen, wird dieses Event
         * aufgerufen und verarbeitet
         */
        void waveIn_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            float _maxsample = 0.0f;
            float _fSampleCount = 0.0f;
            float _fSampleCounter = 0.0f;

            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                short sample = (short)((e.Buffer[index + 1] << 8) | e.Buffer[index + 0]);

                //Sample in 32-bit (4 Byte) umwandeln
                float sample32 = sample / 32768f;

                _maxsample = Math.Max(sample32, _maxsample);
                _fSampleCounter++;

                if (_fSampleCount == 0 && _maxsample >= m_fThreshold)
                {
                    _fSampleCount = _fSampleCounter;
                }
            }

            OnNewMaxSample(this, _maxsample * 100);

            if (_fSampleCount != 0)
            {
                DateTimeMilli = (float)DateTime.Now.Millisecond;
                OnThresholdExceed(this, _fSampleCount);
            }

            
        }

        public float DateTimeMilli
        { get; private set; }

        private System.Diagnostics.Stopwatch m_BufferTimer = new System.Diagnostics.Stopwatch();

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

            try
            {
                m_iWaveInDevice.StartRecording();
                m_bIsRecording = true;
            }
            catch(InvalidOperationException)    //WaveIn nimmt bereits auf
            {
            
            }
        }

        /**
         *  void StopRecording():
         *  Stoppt die Audioaufnahme 
         */
        public void StopRecording()
        {
            if (m_iWaveInDevice != null)
            {
                if (m_bIsRecording == true)
                {
                    m_iWaveInDevice.Dispose();
                    m_iWaveInDevice = null;
                    m_bIsRecording = false;
                }
            }
        }

        public NAudio.Wave.WaveIn WaveInDevice
        {
            get { return m_iWaveInDevice; }
        }

        public int Volume
        {
            get { return m_iVolume; }
            set { m_iVolume = value; }
        }

        public int SampleRate
        {
            get { return m_iSampleRate; }
            private set { m_iSampleRate = 16000; }
        }

        public float Threshold
        {
            get { return m_fThreshold;  }
            set { m_fThreshold = value/100; }
        }

        private volatile float m_fThreshold = 0.75f;  ///Schwellenwert
        private int m_iSampleRate = 16000;   //Wieviele Samples pro Sekunde
        private int m_iBufferTime = 100;     //Bufferzeit in ms
        private int m_iChannels = 1;        ///Wieviele Kanäle sollen zur Aufnahme benutzt werden (Default: 1 -> Mono)
        private int m_iDeviceNumber;        ///Nummer des Soundaufnahmegerätes (Dient zur Identifikation)
        private volatile int m_iVolume;     ///Die aktuelle Lautstärke
        private NAudio.Wave.WaveIn m_iWaveInDevice;
        private bool m_bIsRecording = false;
        
        //Eigene Eventhandler, welche zur Überwachung des Audiosignals dienen
        
        //Handler, der immer das aktuellste, lauteste Sample herausgibt
        public delegate void MaxSampleHandler(object sender, float MaxSample);
        public event MaxSampleHandler NewMaxSample;
        protected void OnNewMaxSample(object sender, float MaxSample)
        {
            if (NewMaxSample != null)   //Prüfung, ob sich sich jemand in das Event eingeschrieben hat
            {
                NewMaxSample(this, MaxSample);  //Das aktuelle MaxSample weitergeben
            }
        }

        public int BufferMilliseconds { get; private set; }

        //Handler bei Überschreitung des Schwellenwerts
        public delegate void ThresholdExceedHandler(object sender, float fSample);
        public event ThresholdExceedHandler ThresholdExceeded;
        protected void OnThresholdExceed(object sender, float fSample)
        {
            if (ThresholdExceeded != null)
            {
                ThresholdExceeded(this, fSample);
            }
        }
    }
}
