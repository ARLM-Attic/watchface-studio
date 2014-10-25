using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace WatchfaceStudio
{
    static class Program
    {
        static Mutex _mutex;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            _mutex = new System.Threading.Mutex(false, "WatchfaceStudio.SingleInstance.Mutex", out createdNew);

            if (createdNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new StudioForm());
            }
            else
            {
                var helper = new MessageHelper();
                var hWnd = helper.getWindowId(null, "Watchface Studio");
                helper.bringAppToFront(hWnd);
                var args = Environment.GetCommandLineArgs();
                if (args.Length > 1)
                    helper.sendWindowsStringMessage(hWnd, 0, args[1]);
            }
        }
    }
}
