using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Caps_Sync
{
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
            switch (Settings.Mode)
            {
                case "Server":
                    if (CapsStatus() != state)
                    {
                        Logging.Write(String.Format("Caps Lock has been changed to {0}.", state), 4);
                        SetCapsState();
                    }
                    break;
                case "Client":
                    if (Client.connected)
                    {
                        Client.SendCaps(MainWindow.KeyText());
                    }
                    break;
            }
        }
    }
}
