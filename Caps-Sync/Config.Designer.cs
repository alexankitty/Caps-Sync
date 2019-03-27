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
            this.label1.TabIndex = 0;
            this.label1.Text = "Mode: ";
            // 
            // ModeBox
            // 
            this.ModeBox.FormattingEnabled = true;
            this.ModeBox.Items.AddRange(new object[] {
            "Client",
            "Server"});
            this.ModeBox.Location = new System.Drawing.Point(79, 3);
            this.ModeBox.Name = "ModeBox";
            this.ModeBox.Size = new System.Drawing.Size(100, 21);
            this.ModeBox.TabIndex = 2;
            this.ModeBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // PortTextBox
            // 
            this.PortTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PortTextBox.Location = new System.Drawing.Point(67, 32);
            this.PortTextBox.MaxLength = 5;
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(100, 20);
            this.PortTextBox.TabIndex = 3;
            // 
            // Option
            // 
            this.Option.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Option.AutoSize = true;
            this.Option.Location = new System.Drawing.Point(16, 35);
            this.Option.Name = "Option";
            this.Option.Size = new System.Drawing.Size(32, 13);
            this.Option.TabIndex = 4;
            this.Option.Text = "Port: ";
            // 
            // StartCheck
            // 
            this.StartCheck.AutoSize = true;
            this.StartCheck.Location = new System.Drawing.Point(12, 124);
            this.StartCheck.Name = "StartCheck";
            this.StartCheck.Size = new System.Drawing.Size(120, 17);
            this.StartCheck.TabIndex = 1;
            this.StartCheck.Text = "Start With Windows";
            this.StartCheck.UseVisualStyleBackColor = true;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelbutton.Location = new System.Drawing.Point(93, 171);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelbutton.TabIndex = 2;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(12, 171);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 3;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(173, 85);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "IP/FQDN: ";
            // 
            // IPTextBox
            // 
            this.IPTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.IPTextBox.Location = new System.Drawing.Point(67, 4);
            this.IPTextBox.MaxLength = 1000;
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(100, 20);
            this.IPTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Interval";
            // 
            // PollIntervalBox
            // 
            this.PollIntervalBox.Location = new System.Drawing.Point(67, 59);
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
            this.PollIntervalBox.TabIndex = 8;
            this.PollIntervalBox.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // MinimizedBox
            // 
            this.MinimizedBox.AutoSize = true;
            this.MinimizedBox.Location = new System.Drawing.Point(12, 148);
            this.MinimizedBox.Name = "MinimizedBox";
            this.MinimizedBox.Size = new System.Drawing.Size(97, 17);
            this.MinimizedBox.TabIndex = 6;
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
            this.ClientSize = new System.Drawing.Size(201, 206);
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
    }
}