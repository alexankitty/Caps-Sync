using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caps_Sync
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
            SettingRead();
        }

        private void SettingSave()
        {
            Settings.Mode = ModeBox.SelectedItem.ToString();
            Settings.Port = Convert.ToInt32(PortTextBox.Text);
            Settings.IP = IPTextBox.Text;
            Settings.PollInterval = (int)PollIntervalBox.Value;
            MainWindow.SettingsChanged = true;
            SettingProg(true);
        }

        private void SettingRead()
        {
            ModeBox.SelectedItem = Settings.Mode;
            ModeSelected(Settings.Mode);
            IPTextBox.Text = Settings.IP;
            PortTextBox.Text = Settings.Port.ToString();
            PollIntervalBox.Value = Settings.PollInterval;
            SettingProg();
        } 

        private void OKbutton_Click(object sender, EventArgs e)
        {
            SettingSave();
            Close();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModeSelected(ModeBox.SelectedItem.ToString());
        }

        private void ModeSelected(string mode)
        {
            switch (mode)
            {
                case "Server":
                    IPTextBox.Enabled = false;
                    break;
                case "Client":
                    IPTextBox.Enabled = true;
                    break;
            }
        }

        private void SettingProg(bool saving = false)
        {
            if (saving)
            {
                switch (LoggingBox.SelectedItem.ToString())
                {
                    case "Critical":
                        Settings.LogLevel = 1;
                        break;
                    case "Warning":
                        Settings.LogLevel = 2;
                        break;
                    case "Informational":
                        Settings.LogLevel = 3;
                        break;
                    case "Verbose":
                        Settings.LogLevel = 4;
                        break;
                }
                switch (StartCheck.Checked)
                {
                    case true:
                        Settings.StartWithWindows = RegHandler.SystemDiag.ProcessPath;
                        break;
                    case false:
                        if (Settings.StartWithWindows != RegHandler.SystemDiag.ProcessPath)
                        {
                            break;
                        }
                        Settings.StartWithWindows = "";
                        break;
                }
                switch (MinimizedBox.Checked)
                {
                    case true:
                        Settings.StartMinimized = "true";
                        break;
                    case false:
                        Settings.StartMinimized = "false";
                        break;
                }
                switch (SyncOnPollCheckBox.Checked)
                {
                    case true:
                        Settings.SyncOnPoll = "true";
                        break;
                    case false:
                        Settings.SyncOnPoll = "false";
                        break;
                }
            }
            else
            {
                switch (Settings.LogLevel)
                {
                    case 1:
                        LoggingBox.SelectedItem = "Critical";
                        break;
                    case 2:
                        LoggingBox.SelectedItem = "Warning";
                        break;
                    case 3:
                        LoggingBox.SelectedItem = "Informational";
                        break;
                    case 4:
                        LoggingBox.SelectedItem = "Verbose";
                        break;
                }

                if (Settings.StartWithWindows == RegHandler.SystemDiag.ProcessPath)
                {
                    StartCheck.Checked = true;
                }
                if (Settings.StartMinimized == "true")
                {
                    MinimizedBox.Checked = true;
                }
                if(Settings.SyncOnPoll == "true")
                {
                    SyncOnPollCheckBox.Checked = true;
                }
            }
        }
    }
}
