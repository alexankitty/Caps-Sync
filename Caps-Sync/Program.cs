using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Runtime.ExceptionServices;

namespace Caps_Sync
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        static void Main()
        {
            Settings.InitializeVars();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (!AppDomain.CurrentDomain.FriendlyName.EndsWith("vshost.exe"))
            {
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            }
            Application.Run(new HiddenContext());

        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logging.Write(e.Exception.Message, 1);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logging.Write((e.ExceptionObject as Exception).Message, 1);
        }

    }

    class HiddenContext : ApplicationContext
    {
        public HiddenContext()
        {
            MainWindow mainWindow = new MainWindow();
            if (Settings.StartMinimized == "true")
            {
                mainWindow.Visible = false;
            }
            else
            {
                mainWindow.Visible = true;
            }
        }
    }
}
