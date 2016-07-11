using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Shortcut_Manager
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
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            //http://stackoverflow.com/a/6392077/3472690    

            Application.Run(new mainWin());
        }
    }
}
