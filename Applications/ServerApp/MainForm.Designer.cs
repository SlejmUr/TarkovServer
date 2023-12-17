using System.Windows.Forms;

namespace ServerApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainTabPage = new ReaLTaiizor.Controls.TabPage();
            MainPage = new TabPage();
            enableSSLCheckBox = new ReaLTaiizor.Controls.CrownCheckBox();
            ip_port_textBox = new TextBox();
            crownLabel1 = new ReaLTaiizor.Controls.CrownLabel();
            stopButton = new ReaLTaiizor.Controls.CrownButton();
            startButton = new ReaLTaiizor.Controls.CrownButton();
            ManagementPage = new TabPage();
            PluginsPage = new TabPage();
            SettingsPage = new TabPage();
            consoleVisiblityButton = new ReaLTaiizor.Controls.CrownButton();
            serverStatusLabel = new ReaLTaiizor.Controls.CrownLabel();
            MainTabPage.SuspendLayout();
            MainPage.SuspendLayout();
            SettingsPage.SuspendLayout();
            SuspendLayout();
            // 
            // MainTabPage
            // 
            MainTabPage.ActiveForeColor = Color.FromArgb(254, 255, 255);
            MainTabPage.ActiveLineTabColor = Color.FromArgb(89, 169, 222);
            MainTabPage.ActiveTabColor = Color.FromArgb(35, 36, 38);
            MainTabPage.Alignment = TabAlignment.Left;
            MainTabPage.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            MainTabPage.CompositingType = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            MainTabPage.ControlBackColor = Color.FromArgb(54, 57, 64);
            MainTabPage.Controls.Add(MainPage);
            MainTabPage.Controls.Add(ManagementPage);
            MainTabPage.Controls.Add(PluginsPage);
            MainTabPage.Controls.Add(SettingsPage);
            MainTabPage.DrawMode = TabDrawMode.OwnerDrawFixed;
            MainTabPage.FrameColor = Color.FromArgb(41, 50, 63);
            MainTabPage.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            MainTabPage.ItemSize = new Size(44, 135);
            MainTabPage.LineColor = Color.FromArgb(25, 26, 28);
            MainTabPage.LineTabColor = Color.FromArgb(54, 57, 64);
            MainTabPage.Location = new Point(4, 63);
            MainTabPage.Multiline = true;
            MainTabPage.Name = "MainTabPage";
            MainTabPage.NormalForeColor = Color.FromArgb(159, 162, 167);
            MainTabPage.PageColor = Color.FromArgb(50, 63, 74);
            MainTabPage.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            MainTabPage.SelectedIndex = 0;
            MainTabPage.Size = new Size(854, 494);
            MainTabPage.SizeMode = TabSizeMode.Fixed;
            MainTabPage.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            MainTabPage.StringType = StringAlignment.Near;
            MainTabPage.TabColor = Color.FromArgb(54, 57, 64);
            MainTabPage.TabIndex = 0;
            MainTabPage.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // MainPage
            // 
            MainPage.BackColor = Color.FromArgb(50, 63, 74);
            MainPage.Controls.Add(enableSSLCheckBox);
            MainPage.Controls.Add(ip_port_textBox);
            MainPage.Controls.Add(crownLabel1);
            MainPage.Controls.Add(stopButton);
            MainPage.Controls.Add(startButton);
            MainPage.Location = new Point(139, 4);
            MainPage.Name = "MainPage";
            MainPage.Padding = new Padding(3);
            MainPage.Size = new Size(711, 486);
            MainPage.TabIndex = 0;
            MainPage.Text = "Main";
            // 
            // enableSSLCheckBox
            // 
            enableSSLCheckBox.AutoSize = true;
            enableSSLCheckBox.Checked = true;
            enableSSLCheckBox.CheckState = CheckState.Checked;
            enableSSLCheckBox.Location = new Point(155, 61);
            enableSSLCheckBox.Name = "enableSSLCheckBox";
            enableSSLCheckBox.Size = new Size(82, 19);
            enableSSLCheckBox.TabIndex = 8;
            enableSSLCheckBox.Text = "Enable SSL";
            // 
            // ip_port_textBox
            // 
            ip_port_textBox.BackColor = Color.FromArgb(50, 63, 74);
            ip_port_textBox.ForeColor = SystemColors.Window;
            ip_port_textBox.Location = new Point(24, 59);
            ip_port_textBox.Name = "ip_port_textBox";
            ip_port_textBox.Size = new Size(100, 23);
            ip_port_textBox.TabIndex = 7;
            ip_port_textBox.Text = "127.0.0.1:6969";
            // 
            // crownLabel1
            // 
            crownLabel1.AutoSize = true;
            crownLabel1.ForeColor = Color.FromArgb(220, 220, 220);
            crownLabel1.Location = new Point(26, 23);
            crownLabel1.Name = "crownLabel1";
            crownLabel1.Size = new Size(138, 15);
            crownLabel1.TabIndex = 6;
            crownLabel1.Text = "Enter IP address and Port";
            // 
            // stopButton
            // 
            stopButton.Location = new Point(155, 99);
            stopButton.Name = "stopButton";
            stopButton.Padding = new Padding(5);
            stopButton.Size = new Size(106, 32);
            stopButton.TabIndex = 3;
            stopButton.Text = "Stop Server";
            stopButton.Click += stopButton_Click;
            // 
            // startButton
            // 
            startButton.Location = new Point(24, 99);
            startButton.Name = "startButton";
            startButton.Padding = new Padding(5);
            startButton.Size = new Size(106, 32);
            startButton.TabIndex = 2;
            startButton.Text = "Start Server";
            startButton.Click += startButton_Click;
            // 
            // ManagementPage
            // 
            ManagementPage.BackColor = Color.FromArgb(50, 63, 74);
            ManagementPage.Location = new Point(139, 4);
            ManagementPage.Name = "ManagementPage";
            ManagementPage.Size = new Size(711, 486);
            ManagementPage.TabIndex = 2;
            ManagementPage.Text = "Management";
            // 
            // PluginsPage
            // 
            PluginsPage.BackColor = Color.FromArgb(50, 63, 74);
            PluginsPage.Location = new Point(139, 4);
            PluginsPage.Name = "PluginsPage";
            PluginsPage.Size = new Size(711, 486);
            PluginsPage.TabIndex = 3;
            PluginsPage.Text = "Plugins";
            // 
            // SettingsPage
            // 
            SettingsPage.BackColor = Color.FromArgb(50, 63, 74);
            SettingsPage.Controls.Add(consoleVisiblityButton);
            SettingsPage.Location = new Point(139, 4);
            SettingsPage.Name = "SettingsPage";
            SettingsPage.Padding = new Padding(3);
            SettingsPage.Size = new Size(711, 486);
            SettingsPage.TabIndex = 1;
            SettingsPage.Text = "Settings";
            // 
            // consoleVisiblityButton
            // 
            consoleVisiblityButton.Location = new Point(26, 23);
            consoleVisiblityButton.Name = "consoleVisiblityButton";
            consoleVisiblityButton.Padding = new Padding(5);
            consoleVisiblityButton.Size = new Size(106, 32);
            consoleVisiblityButton.TabIndex = 4;
            consoleVisiblityButton.Text = "Show Console";
            consoleVisiblityButton.Click += consoleVisiblityButton_Click;
            // 
            // serverStatusLabel
            // 
            serverStatusLabel.AutoSize = true;
            serverStatusLabel.ForeColor = Color.FromArgb(220, 220, 220);
            serverStatusLabel.Location = new Point(712, 33);
            serverStatusLabel.Name = "serverStatusLabel";
            serverStatusLabel.Size = new Size(131, 15);
            serverStatusLabel.TabIndex = 9;
            serverStatusLabel.Text = "Server Status: Unknown";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 560);
            Controls.Add(serverStatusLabel);
            Controls.Add(MainTabPage);
            Margin = new Padding(2);
            Name = "MainForm";
            Padding = new Padding(14, 60, 14, 14);
            Resizable = false;
            Style = ReaLTaiizor.Enum.Poison.ColorStyle.Black;
            Text = "Tarkov Server Application";
            Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            Load += MainForm_Load;
            MainTabPage.ResumeLayout(false);
            MainPage.ResumeLayout(false);
            MainPage.PerformLayout();
            SettingsPage.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.TabPage MainTabPage;
        private TabPage MainPage;
        private TabPage SettingsPage;
        private ReaLTaiizor.Controls.CrownButton startButton;
        private ReaLTaiizor.Controls.CrownButton stopButton;
        private ReaLTaiizor.Controls.CrownLabel crownLabel1;
        private ReaLTaiizor.Controls.CrownButton consoleVisiblityButton;
        private TextBox ip_port_textBox;
        private ReaLTaiizor.Controls.CrownCheckBox enableSSLCheckBox;
        private ReaLTaiizor.Controls.CrownLabel serverStatusLabel;
        private TabPage ManagementPage;
        private TabPage PluginsPage;
    }
}