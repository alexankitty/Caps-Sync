using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace RegHandler
{
    public static class SystemDiag
    {
        public static string ProcessPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
        public static string PWD = Environment.CurrentDirectory;
    }

    public class RegObject
    {
        private readonly string hive;
        private readonly string keypath;
        private readonly string name;
        /*public string value;
        public byte[] valueByte;*/
        private readonly bool bit64;



        public RegObject(string hive, string keypath, string name, bool bit64 = false)
        {
            this.hive = hive;
            this.keypath = keypath;
            this.name = name;
            this.bit64 = bit64;

        }
        /*private RegistryHive hiveloc = new RegistryHive(); //Initializes the placeholders to tell the computer which hive and if 32/64 bit view
        private RegistryView regview = new RegistryView();*/
        private RegistryKey subkey;
        private RegistryKey basekey;

        private void Load() // Loads the key in one function by creating the basekey for the desired registryview (which should always be in 64 bit mode if 64bit process, otherwise specified for system keys. Formated like Load("HKLM", @"Path\To\Key, "NameOfReg
        {


            switch (hive) //Sets hivelocation to path specified in function argument
            {
                case "HKLM":
                    //subkey = Registry.LocalMachine.CreateSubKey(keypath);
                    if (Environment.Is64BitProcess == true || Environment.Is64BitOperatingSystem == true && bit64 == true) //if 64bit process, make regview 64, else only make regview 64 if OS and 64bit system flag specified.
                    {
                        basekey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                    }
                    else
                    {
                        basekey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                    }
                    basekey.CreateSubKey(keypath);
                    break;
                case "HKCU":
                    subkey = Registry.CurrentUser.CreateSubKey(keypath);
                    break;
            }
            /*if (subkey.GetValueKind(name).ToString() == "Binary") {
                valueByte = (byte[])subkey.GetValue(name);
            }
            value = subkey.GetValue(name).ToString(); //opens the key and gets the value
            */
        }

        public string GetValue(int x = 0, int y = 0)
        {
            string value;
            this.Load();
            /*try
            {
                subkey.GetValue(name);
            }
            catch(System.NullReferenceException ex)
            {

            }
            if (subkey.GetValue(name) == null){
                return "";
            }*/
            try
            {
                value = subkey.GetValue(name).ToString();
            }
            catch
            {
                
                if (name == "Caps Sync")
                {
                    Caps_Sync.Logging.Write("A registry entry for StartWithWindows does not exist. This can be safely ignored.", 3);
                    return "";
                }
                Caps_Sync.Logging.Write(String.Format("A registry entry for {0} does not exist, creating it now with default settings.", name), 3);
                Caps_Sync.Settings.Initialize(name);
            }
            this.Load();
            value = subkey.GetValue(name).ToString();
            /*if (y == 0)
            {
                y = valueByte.Length;
            }
            string cvalue = "";
            if (valueByte != null)
            {
                for( ; x <= y; x++ )
                {
                    cvalue = cvalue + valueByte[x].ToString("X");
                }
                return (cvalue);
            }*/
            this.Close();
            return value;
        }

        public void Save(string value)
        {
            this.Load();
            subkey.SetValue(name, value);
            subkey.Close();
        }

        public void Delete()
        {
            this.Load();
            if (subkey.GetValue(name) == null)
            {
                return;
            }
            subkey.DeleteValue(name);
        }

        private void Close()
        {
            subkey.Close();
        }

    }

}
