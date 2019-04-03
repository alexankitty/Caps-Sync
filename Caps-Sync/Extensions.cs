using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Caps_Sync
{
    public static class StringExtensions
    {
        public static string RemoveFirstLines(string text, int linesCount)
        {
            var lines = Regex.Split(text, "\r\n|\r|\n").Skip(linesCount);
            return string.Join(Environment.NewLine, lines.ToArray());
        }
    }

    public partial class Logging
    {
        public static void Write(string text, int level)
        {
            if (Settings.LogLevel >= level)
            {
                Console.Out.Flush();
                switch (level) {
                    case 1:
                        MainWindow.consoleForm.WriteLog(WriteLine(String.Format("Critical: {0} ", text)));
                        break;
                    case 2:
                        MainWindow.consoleForm.WriteLog(WriteLine(String.Format("Warning: {0} ", text)));
                        break;
                    case 3:
                        MainWindow.consoleForm.WriteLog(WriteLine(String.Format("Information: {0} ", text)));
                        break;
                    case 4:
                        MainWindow.consoleForm.WriteLog(WriteLine(String.Format("Verbose: {0} ", text)));
                        break;
                }
            }
        }

        private static string WriteLine(string text)
        {
            return text + Environment.NewLine;
        }
        public static void ExceptionWrite(Exception e) //We will not perform a check on this because we always want exceptions to be written to the console.
        {
            MainWindow.consoleForm.WriteLog(WriteLine("Critical: The Following unhandled exception occured: "));
            MainWindow.consoleForm.WriteLog(WriteLine(e.ToString()));
        }
    }
}
