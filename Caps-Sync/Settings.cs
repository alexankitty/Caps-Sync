using System;
using RegHandler;

namespace Caps_Sync
{
    public static class Settings
    {
        public static void Initialize(string name) //Exception handler from RegHandler if settings do not exist yet.
        {
            switch (name)
            {
                case "Mode":
                    Mode = "Server";
                    break;
                case "IP":
                    IP = "0.0.0.0";
                    break;
                case "Port":
                    Port = 18873;
                    break;
                case "PollInterval":
                    PollInterval = 50;
                    break;
                case "Caps Sync":
                    StartWithWindows = "";
                    break;
                case "StartMinimized":
                    StartMinimized = "False";
                    break;
                case "LogLevel":
                    LogLevel = 3;
                    break;
            }
        }
        private static readonly string SettingPath = @"Software\Alexandra Stone Software\Caps Sync"; //The registry path for storing settings at
        private static RegObject StartWithWindowsReg = new RegObject("HKCU", @"Software\Microsoft\Windows\CurrentVersion\Run", "Caps Sync");
        private static RegObject ModeReg = new RegObject("HKCU", SettingPath, "Mode");
        private static RegObject IPReg = new RegObject("HKCU", SettingPath, "IP");
        private static RegObject PortReg = new RegObject("HKCU", SettingPath, "Port");
        private static RegObject PollIntervalReg = new RegObject("HKCU", SettingPath, "PollInterval");
        private static RegObject StartMinimizedReg = new RegObject("HKCU", SettingPath, "StartMinimized");
        private static RegObject LogLevelReg = new RegObject("HKCU", SettingPath, "LogLevel");

        private static string _StartWithWindows;
        private static string _Mode;
        private static string _IP;
        private static string _Port;
        private static string _PollInterval;
        private static string _StartMinimized;
        private static string _LogLevel;

        public static void InitializeVars()
        {
            _StartWithWindows = StartWithWindowsReg.GetValue();
            _Mode = ModeReg.GetValue();
            _IP = IPReg.GetValue();
            _Port = PortReg.GetValue();
            _PollInterval = PollIntervalReg.GetValue();
            _StartMinimized = StartMinimizedReg.GetValue();
            _LogLevel = LogLevelReg.GetValue();
        }

        public static string StartWithWindows
        {
            get
            {
                return _StartWithWindows;
            }
            set
            {
                if (value == "")
                {
                    StartWithWindowsReg.Delete();
                }
                else
                {
                    StartWithWindowsReg.Save(value);
                }
                _StartWithWindows = value;
            }
        }

        public static string Mode
        {
            get
            {
                return _Mode;
            }
            set
            {
                ModeReg.Save(value);
                _Mode = value;
            }
        }
        public static string IP
        {
            get
            {
                return _IP;
            }
            set
            {
                IPReg.Save(value);
                _IP = value;
            }
        }
        public static int Port
        {
            get
            {
                return Convert.ToInt32(_Port);
            }
            set
            {
                string valueString = value.ToString();
                PortReg.Save(valueString);
                _Port = valueString;
            }
        }
        public static int PollInterval
        {
            get
            {
                return Convert.ToInt32(_PollInterval);
            }
            set
            {
                string valueString = value.ToString();
                PollIntervalReg.Save(valueString);
                _PollInterval = valueString;
            }
        }

        public static string StartMinimized
        {
            get
            {
                return _StartMinimized;
            }
            set
            {
                StartMinimizedReg.Save(value);
                _StartMinimized = value;
            }
        }

        public static int LogLevel
        {
            get
            {
                return Convert.ToInt32(_LogLevel);
            }
            set
            {
                string valueString = value.ToString();
                LogLevelReg.Save(valueString);
                _LogLevel = valueString;
            }
        }
    }
}
