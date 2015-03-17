using System;
using System.Collections.Generic;
using System.Linq;
 
using System.Windows.Forms;

namespace KugelfallDbg
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Main());
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.StackTrace.ToString());
            }
        }
    }
}
