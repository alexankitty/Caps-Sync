﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Caps_Sync
{
    public partial class ConsoleWindow : Form
    {
        public ConsoleWindow()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Console.SetOut(new ControlWriter(consoleOutput));
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.
            Opacity = 0;
            base.OnLoad(e);
        }

        private void consoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false;
                this.Opacity = 0;
                this.ShowInTaskbar = false;
                e.Cancel = true;
            }
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<String>(AppendTextBox), new object[] { value });
                return;
            }
            consoleOutput.AppendText(value);
            for (int x = 0; consoleOutput.Text.Length >= 25000; x++)
            {
                consoleOutput.Text = StringExtensions.RemoveFirstLines(consoleOutput.Text, 1);
            }
        }

        public void AppendTextBox(char value)
        {
            if (InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action<char>(AppendTextBox), new object[] { value });
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
                return;
            }
            consoleOutput.AppendText(value.ToString());
            for(int x = 0; consoleOutput.Text.Length >= 25000; x++)
            {
                consoleOutput.Text = StringExtensions.RemoveFirstLines(consoleOutput.Text, 1);
            }
        }
    }
}
