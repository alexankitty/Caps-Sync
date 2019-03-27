using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Caps_Sync
{
    public class ControlWriter : TextWriter
    {
        private Control textbox;
        public ControlWriter(Control textbox)
        {
            this.textbox = textbox;
        }

        public override void Write(char value)
        {
            //textbox.Text += value;
            MainWindow.consoleForm.AppendTextBox(value);
        }

        public override void Write(string value)
        {
            //textbox.Text += value;
            MainWindow.consoleForm.AppendTextBox(value);
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
}