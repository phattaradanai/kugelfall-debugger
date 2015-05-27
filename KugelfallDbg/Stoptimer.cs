using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KugelfallDbg
{
    static class Stoptimer
    {
        public static void Start()
        {
            if (!m_Stopwatch.IsRunning) { m_Stopwatch.Start(); }
        }

        public static void Stop()
        {
            if (m_Stopwatch.IsRunning) { m_Stopwatch.Stop(); }
        }

        public static void Reset()
        {
            m_Stopwatch.Reset();
        }

        public static int Restart()
        {
            int iTemp = (int)m_Stopwatch.ElapsedMilliseconds;
            m_Stopwatch = System.Diagnostics.Stopwatch.StartNew();

            return iTemp;
        }
        public static long Time
        {
            get
            {
                if (m_Stopwatch.IsRunning == true)
                {
                    return m_Stopwatch.ElapsedMilliseconds;
                }
                else { return 0; }
            }
        }

        //Die Stopwatch erlaubt eine höher aufgelöste Zeitmessung im Gegensatz zu DateTime durch Verwendung des QueryPerformanceCounters
        private static System.Diagnostics.Stopwatch m_Stopwatch = new System.Diagnostics.Stopwatch();
    }
}
