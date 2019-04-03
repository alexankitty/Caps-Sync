namespace Caps_Sync
{
    partial class Config
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
            this.label1 = new System.Windows.Forms.Label();
            this.ModeBox = new System.Windows.Forms.ComboBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.Option = new System.Windows.Forms.Label();
            this.StartCheck = new System.Windows.Forms.CheckBox();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PollIntervalBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.LoggingBox = new System.Windows.Forms.ComboBox();
            this.MinimizedBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PollIntervalBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mode: ";
            // 
            // ModeBox
            // 
            this.ModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeBox.FormattingEnabled = true;
            this.ModeBox.Items.AddRange(new object[] {
            "Client",
            "Server"});
            this.ModeBox.Location = new System.Drawing.Point(79, 3);
            this.ModeBox.Name = "ModeBox";
            this.ModeBox.Size = new System.Drawing.Size(100, 21);
            this.ModeBox.TabIndex = 0;
            this.ModeBox.SelectedIndexChanged += new System.EventHandler(this.ModeBox_SelectedIndexChanged);
            // 
            // PortTextBox
            // 
            this.PortTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PortTextBox.Location = new System.Drawing.Point(67, 29);
            this.PortTextBox.MaxLength = 5;
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(100, 20);
            this.PortTextBox.TabIndex = 1;
            // 
            // Option
            // 
            this.Option.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Option.AutoSize = true;
            this.Option.Location = new System.Drawing.Point(16, 32);
            this.Option.Name = "Option";
            this.Option.Size = new System.Drawing.Size(32, 13);
            this.Option.TabIndex = 5;
            this.Option.Text = "Port: ";
            // 
            // StartCheck
            // 
            this.StartCheck.AutoSize = true;
            this.StartCheck.Location = new System.Drawing.Point(12, 161);
            this.StartCheck.Name = "StartCheck";
            this.StartCheck.Size = new System.Drawing.Size(120, 17);
            this.StartCheck.TabIndex = 2;
            this.StartCheck.Text = "Start With Windows";
            this.StartCheck.UseVisualStyleBackColor = true;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelbutton.Location = new System.Drawing.Point(93, 229);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelbutton.TabIndex = 4;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // OKbutton
            // 
            this.OKbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OKbutton.Location = new System.Drawing.Point(12, 229);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 5;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.Option, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PortTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.IPTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.PollIntervalBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.LoggingBox, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(173, 108);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP/FQDN: ";
            // 
            // IPTextBox
            // 
            this.IPTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.IPTextBox.Location = new System.Drawing.Point(67, 3);
            this.IPTextBox.MaxLength = 1000;
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(100, 20);
            this.IPTextBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Interval";
            // 
            // PollIntervalBox
            // 
            this.PollIntervalBox.Location = new System.Drawing.Point(67, 55);
            this.PollIntervalBox.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.PollIntervalBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PollIntervalBox.Name = "PollIntervalBox";
            this.PollIntervalBox.Size = new System.Drawing.Size(100, 20);
            this.PollIntervalBox.TabIndex = 2;
            this.PollIntervalBox.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Log Level:";
            // 
            // LoggingBox
            // 
            this.LoggingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LoggingBox.FormattingEnabled = true;
            this.LoggingBox.Items.AddRange(new object[] {
            "Critical",
            "Warning",
            "Informational",
            "Verbose"});
            this.LoggingBox.Location = new System.Drawing.Point(67, 81);
            this.LoggingBox.Name = "LoggingBox";
            this.LoggingBox.Size = new System.Drawing.Size(100, 21);
            this.LoggingBox.TabIndex = 3;
            // 
            // MinimizedBox
            // 
            this.MinimizedBox.AutoSize = true;
            this.MinimizedBox.Location = new System.Drawing.Point(12, 185);
            this.MinimizedBox.Name = "MinimizedBox";
            this.MinimizedBox.Size = new System.Drawing.Size(97, 17);
            this.MinimizedBox.TabIndex = 3;
            this.MinimizedBox.Text = "Start Minimized";
            this.MinimizedBox.UseVisualStyleBackColor = true;
            // 
            // Config
            // 
            this.AcceptButton = this.OKbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.Cancelbutton;
            this.ClientSize = new System.Drawing.Size(198, 264);
            this.Controls.Add(this.MinimizedBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ModeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.StartCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Configuration";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PollIntervalBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ModeBox;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label Option;
        private System.Windows.Forms.CheckBox StartCheck;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown PollIntervalBox;
        private System.Windows.Forms.CheckBox MinimizedBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox LoggingBox;
    }
}