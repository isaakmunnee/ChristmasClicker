using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChristmasClicker
{
    static class Program
    {
        public static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ClickerSystem.Initialise();
            myTimer.Tick += new EventHandler(ClickerSystem.Tick);
            myTimer.Interval = 10;
            myTimer.Start();
            Application.Run(new Form1());
        }
    }
}
