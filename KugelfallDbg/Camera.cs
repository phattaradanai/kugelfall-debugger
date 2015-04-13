using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace KugelfallDbg
{
    class Camera
    {
        public Camera(AForge.Video.IVideoSource _VideoSource)
        {
            m_Camera = _VideoSource;
        }

        ~Camera()
        {
            if(m_Camera != null)
            {
                if (m_Camera.IsRunning)
                {
                    m_Camera.SignalToStop();
                    m_Camera.WaitForStop();
                }
            }
        }

        public AForge.Video.IVideoSource GetCamera
        {
            get { return m_Camera; }
        }

        private AForge.Video.IVideoSource m_Camera; //Gewählte Kamera
    }
}
