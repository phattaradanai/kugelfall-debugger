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
            m_StopWatch = new System.Diagnostics.Stopwatch();
        }

        ~Camera()
        {
            CloseVideoSource();
        }

        public void Stop() { m_Camera.Stop(); } ///Aufnahme stoppen
        public void Start() { m_Camera.Start(); }   ///Aufnahme starten

        //Sämtliche Aktivitäten beenden
        public void Exit()
        {
            CloseVideoSource();
        }

        private void CloseVideoSource()
        {
            if (m_Camera.IsRunning) //Nur falls Kamera noch aktiv
            {
                //Kamera und Stoppuhr anhalten
                m_Camera.Stop();
                m_StopWatch.Stop();
            }
        }        

        public System.Diagnostics.Stopwatch Stopwatch
        {
            get { return m_StopWatch; }
        }

        public AForge.Video.IVideoSource GetCamera
        {
            get { return m_Camera; }
        }

        private AForge.Video.IVideoSource m_Camera; //Gewählte Kamera
        
        //Stoppuhr für FPS-Berechnung erstellen
        private System.Diagnostics.Stopwatch m_StopWatch;
    }
}
