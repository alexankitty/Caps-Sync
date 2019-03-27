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
            switch (StartCheck.Checked)
            {
                case true:
                    Settings.StartWithWindows.Save(RegHandler.SystemDiag.ProcessPath);
                    break;
                case false:
                    if(Settings.StartWithWindows.GetValue() != RegHandler.SystemDiag.ProcessPath)
                    {
                    break;
                    }
                    Settings.StartWithWindows.Delete();
                    break;
            }
            switch (MinimizedBox.Checked)
            {
                case true:
                    Settings.StartMinimized.Save("true");
                    break;
                case false:
                    Settings.StartMinimized.Save("false");
                    break;
            }
            Settings.Mode.Save(ModeBox.SelectedItem.ToString());
            Settings.Port.Save(PortTextBox.Text);
            Settings.IP.Save(IPTextBox.Text);
            Settings.PollInterval.Save(PollIntervalBox.Value.ToString());
            ModeSelected(Settings.Mode.GetValue());
            MainWindow.SettingsChanged = true;
        }

        private void SettingRead()
        {
            if (Settings.StartWithWindows.GetValue() == RegHandler.SystemDiag.ProcessPath)
            {
                StartCheck.Checked = true;
            }
            if (Settings.Mode.GetValue() == "")
            {
                ModeSelected("Server");
                return;
            }
            if(Settings.StartMinimized.GetValue() == "true")
            {
                MinimizedBox.Checked = true;
            }
            ModeBox.SelectedItem = Settings.Mode.GetValue();
            ModeSelected(Settings.Mode.GetValue());
            PollIntervalBox.Value = Convert.ToInt32(Settings.PollInterval.GetValue());
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ModeBox.SelectedItem.ToString()) {
                case "Server":
                    ModeSelected(ModeBox.SelectedItem.ToString());
                    break;
                case "Client":
                    ModeSelected(ModeBox.SelectedItem.ToString());
                    break;
            }
        }

        private void ModeSelected(string mode)
        {
           Settings.Mode.Save(ModeBox.Text);
            if (Settings.Port.GetValue() == "")
            {
                Settings.Port.Save("18873");
            }
            PortTextBox.Text = Settings.Port.GetValue();
            if (Settings.IP.GetValue() == "")
            {
                Settings.IP.Save(Network.localIP);
            }
            switch (mode)
            {
                case "Server":
                IPTextBox.Enabled = false;
                    break;
                case "Client":
                IPTextBox.Enabled = true;
                    break;
            }
            IPTextBox.Text = Settings.IP.GetValue();
            ModeBox.Text = Settings.Mode.GetValue();
        }
    }
}
