using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KugelfallDbg
{
    //Das Gerät, von dem der Ton aufgezeichnet wird
    class Audio
    {
        public Audio()
        {
        
        }

        public NAudio.CoreAudioApi.MMDevice AudioDevice
        {
            get { return m_AudioDevice; }
            set { m_AudioDevice = value; }
        }

        private NAudio.CoreAudioApi.MMDevice m_AudioDevice;
    }
}
