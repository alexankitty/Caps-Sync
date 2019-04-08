using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Caps_Sync
{


    public partial class MainWindow : Form
    {


        private System.Timers.Timer capCheckTimer; //Initializes the timer
        public static bool SettingsChanged = false;

        private void SetTimer() //Function for creating the timer
        {
            capCheckTimer = new System.Timers.Timer(Settings.PollInterval); //grabs the poll intervel from the registry and sets to that.
            capCheckTimer.Elapsed += OnTimedEvent;
            capCheckTimer.AutoReset = true;
            capCheckTimer.Enabled = true;
        }

        private bool isCapsLocked = false;

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (isCapsLocked != KeyHandler.CapsStatus() && Settings.Mode == "Client")
            {
                isCapsLocked = KeyHandler.CapsStatus();
                KeyHandler.SynchronizeCapsState(isCapsLocked);
            }
            if(Settings.SyncOnPoll == "true" && Settings.Mode == "Client")
            {
                KeyHandler.SynchronizeCapsState(KeyHandler.CapsStatus());
            }
            SetText(AdditionalText(), StatusText(), ServerIPText());
            toolStripCapsStatus.Text = KeyText();
        }

        private static string ServerMode
        {
            get
            {
                return Settings.Mode;
            }
        }

        public static ConsoleWindow consoleForm = new ConsoleWindow();

        public MainWindow()
        {
            isCapsLocked = KeyHandler.CapsStatus();
            SetTimer();
            InitializeComponent();
            consoleForm.Show();
            networkSetup();
            capCheckTimer.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
            aboutForm.Dispose();
        }

        public static string KeyText()
        {
            if (KeyHandler.CapsStatus())
            {
                return "ON";
            }
            else
            {
                return "OFF";
            }
        }

        public static string StatusText()
        {
            if (Client.connected && Settings.Mode == "Client")
            {
                return "Connected";
            }
            else if(Settings.Mode == "Server")
            {
                return "Client List";
            }
            return "Disconnected";
        }
        public static string AdditionalText()
        {
            if (Server.Setup)
            {
                string IPs = "";
                for (int x = 0; x < Server._clients.Length; x++)
                {
                    if(Server._clients[x].socket != null)
                    IPs += Server._clients[x].IPAddress + "\r\n";
                }
                return IPs;
            }
            return "";
        }

        public static string ServerIPText()
        {
            switch (Settings.Mode)
            {
                case "Server":
                    return Server.ServerString;
                case "Client":
                    return Client.ServerString;
                default:
                    return "0.0.0.0";
            }

        }

        private void modeSetup()
        {
            toolStripCapsStatus.Text = KeyText();
            toolStripModeStatus.Text = Settings.Mode;

            if (Server.Setup)
            {
                Server.RemoveServer();
            }
            if (Client.clientInitialized)
            {
                Client.RemoveClient();
            }
            switch (Settings.Mode)
            {
                case "Server":
                    IPAddress.Text = (Server.ServerString);
                    Server.SetupServer();
                    break;
                case "Client":
                    IPAddress.Text = (Client.ServerString);
                    Client.ConnectToServer();
                    break;
            }
        }

        private void networkSetup()
        {
            ServerHandleNetworkData.InitializeNetworkPackages();
            ClientHandleNetworkData.InitializeNetworkPackages();
            toolStripCapsStatus.Text = KeyText();
            toolStripModeStatus.Text = ServerMode;
            switch (Settings.Mode)
            {
                case "Server":
                    Server.SetupServer();
                    break;
                case "Client":
                    Client.ConnectToServer();
                    break;
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config configForm = new Config();
            configForm.ShowDialog();
            if (SettingsChanged)
            {
                modeSetup();
                SettingsChanged = false;
            }
            capCheckTimer.Stop();
            capCheckTimer.Start();
            configForm.Dispose();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        delegate void SetTextCallback(string text, string text2, string text3);

        private void SetText(string Additional, string Status, string IP)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.AdditionalServerInfo.InvokeRequired || this.ServerStatus.InvokeRequired || this.IPAddress.InvokeRequired)
            {
                try
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { Additional, Status, IP });
                }
                catch(ObjectDisposedException)
                {
                    return;
                }
            }
            else
            {
                this.AdditionalServerInfo.Text = Additional;
                this.ServerStatus.Text = Status;
                this.IPAddress.Text = IP;
            }
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainWindow.consoleForm.Visible = true;
            MainWindow.consoleForm.Opacity = 100;
            MainWindow.consoleForm.ShowInTaskbar = true;
        }
    }
}

