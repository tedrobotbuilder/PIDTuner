using System;
using System.Windows.Forms;

namespace DataPlot3
{
    static class MyConstants {
        public const sbyte Green = 0;
        public const sbyte Red = -1;
        public const string Start = "0";
        public const string Stop = "1";
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application
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
