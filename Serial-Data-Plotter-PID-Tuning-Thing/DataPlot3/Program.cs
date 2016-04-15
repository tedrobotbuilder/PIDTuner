using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataPlot3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// The main entry point for the application.b1
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
