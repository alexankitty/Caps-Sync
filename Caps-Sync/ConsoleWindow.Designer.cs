namespace Caps_Sync
{
    partial class ConsoleWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.consoleOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // consoleOutput
            // 
            this.consoleOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleOutput.Location = new System.Drawing.Point(0, 0);
            this.consoleOutput.Multiline = true;
            this.consoleOutput.Name = "consoleOutput";
            this.consoleOutput.ReadOnly = true;
            this.consoleOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleOutput.Size = new System.Drawing.Size(320, 224);
            this.consoleOutput.TabIndex = 0;
            // 
            // ConsoleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 224);
            this.Controls.Add(this.consoleOutput);
            this.Name = "ConsoleWindow";
            this.Text = "ConsoleWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.consoleForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox consoleOutput;
    }
}