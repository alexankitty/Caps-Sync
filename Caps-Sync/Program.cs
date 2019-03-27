using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using System.Timers;
using System.Text.RegularExpressions;

namespace Caps_Sync
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
            Application.Run(new HiddenContext());

        }

        public static void exceptionWrite(Exception e)
        {
            Console.WriteLine($"The Following Error occured: '{e}'");
        }
    }

    class HiddenContext : ApplicationContext
    {
        public HiddenContext()
        {
            MainWindow mainWindow = new MainWindow();
            if (Settings.StartMinimized.GetValue() == "true")
            {
                mainWindow.Visible = false;
            }
            else
            {
                mainWindow.Visible = true;
            }
        }
    }

        public class Network
        {
        public static string IPSet
        {
            get
            {
                return Settings.IP.GetValue();
            }
        }

        public static int PortSet
        {
            get
            {
                int val;
                if (Int32.TryParse(Settings.Port.GetValue(), out val)){
                    return val;
                }
                else
                {
                    return 18873;
                }
            }
        }

        public static string localIP
        {
            get
            {
                return getIP();
            }
        }

        //public static Socket Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));

        public static void clientConnect(System.Net.IPEndPoint remoteEP)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(IPSet, PortSet);
        }

        public static string getIP()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
                socket.Close();
            }
            return localIP;
        }
    }

    public static class Settings
    {
        public static void Initialize(string name) //Exception handler from RegHandler if settings do not exist yet.
        {
            switch (name)
            {
                case "Mode":
                    Mode.Save("Server");
                    break;
                case "IP":
                    IP.Save(Network.localIP);
                    break;
                case "Port":
                    Port.Save("18873");
                    break;
                case "PollInterval":
                    PollInterval.Save("50");
                    break;
                case "Caps Sync":
                    StartWithWindows.Save("");
                    break;
                case "StartMinimized":
                    StartMinimized.Save("False");
                    break;
            }
        }
        private static readonly string SettingPath = @"Software\Alexandra Stone Software\Caps Sync"; //The registry path for storing settings at
        public static RegHandler.RegObject StartWithWindows = new RegHandler.RegObject("HKCU", @"Software\Microsoft\Windows\CurrentVersion\Run", "Caps Sync");
        public static RegHandler.RegObject Mode = new RegHandler.RegObject("HKCU", SettingPath, "Mode");
        public static RegHandler.RegObject IP = new RegHandler.RegObject("HKCU", SettingPath, "IP");
        public static RegHandler.RegObject Port = new RegHandler.RegObject("HKCU", SettingPath, "Port");
        public static RegHandler.RegObject PollInterval = new RegHandler.RegObject("HKCU", SettingPath, "PollInterval");
        public static RegHandler.RegObject StartMinimized = new RegHandler.RegObject("HKCU", SettingPath, "StartMinimized");
        public static int PortInt
        {
            get{
                return Convert.ToInt32(Port.GetValue());
            }
        }
    }


    public class KeyHandler //Grabs information about current key status, along with changing it.
    {
        [DllImport("user32.dll")] //PInvoke for keyboard events
        internal static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        private static void PressKeyboardButton(Keys keyCode) //Simulates a keypress
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;

            keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        public static bool CapsStatus() //Pulls current CapsLock status
        {
            return Control.IsKeyLocked(Keys.CapsLock);
        }

        public static void SetCapsState() //Simulates a caps lock press
        {
            PressKeyboardButton(Keys.CapsLock);
        }

        public static void SynchronizeCapsState(bool state) //Logic for changing the caps lock mode, to be paired with network code.
        {
            switch (Settings.Mode.GetValue())
            {
                case "Server":
                    if(CapsStatus() != state){
                        SetCapsState();
                    }
                    break;
                case "Client":
                    if (Client.connected)
                    {
                        Client.SendCaps(MainWindow.KeyText());
                    }
                    //Network Send Code Goes Here.
                    break;
            }
        }
    }

    public static class StringExtensions
    {
        public static string RemoveFirstLines(string text, int linesCount)
        {
            var lines = Regex.Split(text, "\r\n|\r|\n").Skip(linesCount);
            return string.Join(Environment.NewLine, lines.ToArray());
        }
    }
}
