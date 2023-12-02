namespace WTDE_Launcher_V3
{
    partial class Main
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            LeftDarkOverlay = new PictureBox();
            VersionInfoLabel = new Label();
            TabButtonGroup = new Panel();
            TabButtonGeneral = new Button();
            MOTDLabel = new Label();
            LogoWTDE = new PictureBox();
            RunWTDE = new Button();
            ToolTipMain = new ToolTip(components);
            AdjustSettings = new Button();
            OpenMods = new Button();
            CheckForUpdates = new Button();
            LogoFretworks = new PictureBox();
            WhiteOverlay = new PictureBox();
            MOTDDarkOverlay = new PictureBox();
            process1 = new System.Diagnostics.Process();
            TabGeneralGroup = new GroupBox();
            TabGeneralSocialHeader = new Label();
            RichPresence = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)LeftDarkOverlay).BeginInit();
            TabButtonGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoWTDE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LogoFretworks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhiteOverlay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MOTDDarkOverlay).BeginInit();
            TabGeneralGroup.SuspendLayout();
            SuspendLayout();
            // 
            // LeftDarkOverlay
            // 
            LeftDarkOverlay.BackColor = Color.Transparent;
            LeftDarkOverlay.Image = Properties.Resources.dark_overlay_d_l;
            LeftDarkOverlay.Location = new Point(-4, -5);
            LeftDarkOverlay.Name = "LeftDarkOverlay";
            LeftDarkOverlay.Size = new Size(318, 741);
            LeftDarkOverlay.SizeMode = PictureBoxSizeMode.StretchImage;
            LeftDarkOverlay.TabIndex = 0;
            LeftDarkOverlay.TabStop = false;
            // 
            // VersionInfoLabel
            // 
            VersionInfoLabel.AutoSize = true;
            VersionInfoLabel.BackColor = Color.Transparent;
            VersionInfoLabel.Cursor = Cursors.Help;
            VersionInfoLabel.Font = new Font("Lexend", 12F, FontStyle.Regular, GraphicsUnit.Point);
            VersionInfoLabel.ForeColor = Color.White;
            VersionInfoLabel.Image = Properties.Resources.dark_overlay_d_l;
            VersionInfoLabel.Location = new Point(10, 648);
            VersionInfoLabel.Name = "VersionInfoLabel";
            VersionInfoLabel.Size = new Size(284, 75);
            VersionInfoLabel.TabIndex = 4;
            VersionInfoLabel.Text = "GHWT: DE Launcher V3.0 by IMF24\r\nBG Image: Fox (FoxJudy)\r\nWTDE Latest Version: w.x.y.z";
            VersionInfoLabel.Click += VersionInfoLabel_Click;
            // 
            // TabButtonGroup
            // 
            TabButtonGroup.BackColor = Color.Transparent;
            TabButtonGroup.BackgroundImage = Properties.Resources.dark_overlay_m;
            TabButtonGroup.Controls.Add(TabButtonGeneral);
            TabButtonGroup.Location = new Point(314, -1);
            TabButtonGroup.Name = "TabButtonGroup";
            TabButtonGroup.Size = new Size(701, 66);
            TabButtonGroup.TabIndex = 5;
            // 
            // TabButtonGeneral
            // 
            TabButtonGeneral.BackColor = Color.Transparent;
            TabButtonGeneral.BackgroundImage = Properties.Resources.dark_overlay_d;
            TabButtonGeneral.BackgroundImageLayout = ImageLayout.Stretch;
            TabButtonGeneral.Cursor = Cursors.Hand;
            TabButtonGeneral.FlatAppearance.BorderColor = Color.White;
            TabButtonGeneral.FlatAppearance.MouseDownBackColor = Color.Transparent;
            TabButtonGeneral.FlatAppearance.MouseOverBackColor = Color.Transparent;
            TabButtonGeneral.FlatStyle = FlatStyle.Flat;
            TabButtonGeneral.Font = new Font("Lexend", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TabButtonGeneral.ForeColor = Color.White;
            TabButtonGeneral.Location = new Point(13, 10);
            TabButtonGeneral.Name = "TabButtonGeneral";
            TabButtonGeneral.RightToLeft = RightToLeft.No;
            TabButtonGeneral.Size = new Size(107, 44);
            TabButtonGeneral.TabIndex = 13;
            TabButtonGeneral.Text = "General";
            ToolTipMain.SetToolTip(TabButtonGeneral, "Adjust general settings about WTDE.");
            TabButtonGeneral.UseVisualStyleBackColor = false;
            TabButtonGeneral.Click += TabButtonGeneral_Click;
            // 
            // MOTDLabel
            // 
            MOTDLabel.AutoSize = true;
            MOTDLabel.BackColor = Color.Transparent;
            MOTDLabel.Font = new Font("Lexend", 9F, FontStyle.Regular, GraphicsUnit.Point);
            MOTDLabel.ForeColor = Color.White;
            MOTDLabel.Image = Properties.Resources.dark_overlay_m_l;
            MOTDLabel.Location = new Point(327, 15);
            MOTDLabel.Name = "MOTDLabel";
            MOTDLabel.Size = new Size(525, 57);
            MOTDLabel.TabIndex = 0;
            MOTDLabel.Text = "MOTD not found, call IMF!\r\n\r\nIf you're seeing this, it means we probably couldn't establish a connection to the internet.";
            // 
            // LogoWTDE
            // 
            LogoWTDE.BackColor = Color.Transparent;
            LogoWTDE.BackgroundImage = Properties.Resources.dark_overlay_d;
            LogoWTDE.Image = Properties.Resources.wtde_logo_normal;
            LogoWTDE.Location = new Point(59, 0);
            LogoWTDE.Name = "LogoWTDE";
            LogoWTDE.Size = new Size(200, 200);
            LogoWTDE.SizeMode = PictureBoxSizeMode.StretchImage;
            LogoWTDE.TabIndex = 7;
            LogoWTDE.TabStop = false;
            // 
            // RunWTDE
            // 
            RunWTDE.BackColor = Color.Transparent;
            RunWTDE.BackgroundImage = Properties.Resources.dark_overlay_d;
            RunWTDE.BackgroundImageLayout = ImageLayout.Stretch;
            RunWTDE.Cursor = Cursors.Hand;
            RunWTDE.FlatAppearance.BorderColor = Color.White;
            RunWTDE.FlatAppearance.MouseDownBackColor = Color.Transparent;
            RunWTDE.FlatAppearance.MouseOverBackColor = Color.Transparent;
            RunWTDE.FlatStyle = FlatStyle.Flat;
            RunWTDE.Font = new Font("Lexend", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            RunWTDE.ForeColor = Color.White;
            RunWTDE.Location = new Point(15, 206);
            RunWTDE.Name = "RunWTDE";
            RunWTDE.RightToLeft = RightToLeft.No;
            RunWTDE.Size = new Size(284, 54);
            RunWTDE.TabIndex = 6;
            RunWTDE.Text = "Start WTDE";
            ToolTipMain.SetToolTip(RunWTDE, "Save your configuration settings and launch WTDE.");
            RunWTDE.UseVisualStyleBackColor = false;
            RunWTDE.Click += RunWTDE_Click;
            // 
            // AdjustSettings
            // 
            AdjustSettings.BackColor = Color.Transparent;
            AdjustSettings.BackgroundImage = Properties.Resources.dark_overlay_d;
            AdjustSettings.BackgroundImageLayout = ImageLayout.Stretch;
            AdjustSettings.Cursor = Cursors.Hand;
            AdjustSettings.FlatAppearance.BorderColor = Color.White;
            AdjustSettings.FlatAppearance.MouseDownBackColor = Color.Transparent;
            AdjustSettings.FlatAppearance.MouseOverBackColor = Color.Transparent;
            AdjustSettings.FlatStyle = FlatStyle.Flat;
            AdjustSettings.Font = new Font("Lexend", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            AdjustSettings.ForeColor = Color.White;
            AdjustSettings.Location = new Point(15, 277);
            AdjustSettings.Name = "AdjustSettings";
            AdjustSettings.RightToLeft = RightToLeft.No;
            AdjustSettings.Size = new Size(284, 54);
            AdjustSettings.TabIndex = 9;
            AdjustSettings.Text = "Adjust Settings";
            ToolTipMain.SetToolTip(AdjustSettings, "Adjust your configuration settings for the mod.");
            AdjustSettings.UseVisualStyleBackColor = false;
            AdjustSettings.Click += AdjustSettings_Click;
            // 
            // OpenMods
            // 
            OpenMods.BackColor = Color.Transparent;
            OpenMods.BackgroundImage = Properties.Resources.dark_overlay_d;
            OpenMods.BackgroundImageLayout = ImageLayout.Stretch;
            OpenMods.Cursor = Cursors.Hand;
            OpenMods.FlatAppearance.BorderColor = Color.White;
            OpenMods.FlatAppearance.MouseDownBackColor = Color.Transparent;
            OpenMods.FlatAppearance.MouseOverBackColor = Color.Transparent;
            OpenMods.FlatStyle = FlatStyle.Flat;
            OpenMods.Font = new Font("Lexend", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            OpenMods.ForeColor = Color.White;
            OpenMods.Location = new Point(15, 348);
            OpenMods.Name = "OpenMods";
            OpenMods.RightToLeft = RightToLeft.No;
            OpenMods.Size = new Size(284, 54);
            OpenMods.TabIndex = 10;
            OpenMods.Text = "Open Mods Folder";
            ToolTipMain.SetToolTip(OpenMods, "Open your mods folder.");
            OpenMods.UseVisualStyleBackColor = false;
            OpenMods.Click += OpenMods_Click;
            // 
            // CheckForUpdates
            // 
            CheckForUpdates.BackColor = Color.Transparent;
            CheckForUpdates.BackgroundImage = Properties.Resources.dark_overlay_d;
            CheckForUpdates.BackgroundImageLayout = ImageLayout.Stretch;
            CheckForUpdates.Cursor = Cursors.Hand;
            CheckForUpdates.FlatAppearance.BorderColor = Color.White;
            CheckForUpdates.FlatAppearance.MouseDownBackColor = Color.Transparent;
            CheckForUpdates.FlatAppearance.MouseOverBackColor = Color.Transparent;
            CheckForUpdates.FlatStyle = FlatStyle.Flat;
            CheckForUpdates.Font = new Font("Lexend", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            CheckForUpdates.ForeColor = Color.White;
            CheckForUpdates.Location = new Point(15, 419);
            CheckForUpdates.Name = "CheckForUpdates";
            CheckForUpdates.RightToLeft = RightToLeft.No;
            CheckForUpdates.Size = new Size(284, 54);
            CheckForUpdates.TabIndex = 12;
            CheckForUpdates.Text = "Check For Updates";
            ToolTipMain.SetToolTip(CheckForUpdates, "Check for updates to GHWT: DE and verify your installation's integrity.");
            CheckForUpdates.UseVisualStyleBackColor = false;
            CheckForUpdates.Click += CheckForUpdates_Click;
            // 
            // LogoFretworks
            // 
            LogoFretworks.BackColor = Color.Transparent;
            LogoFretworks.BackgroundImage = Properties.Resources.dark_overlay_d;
            LogoFretworks.BackgroundImageLayout = ImageLayout.Stretch;
            LogoFretworks.Image = Properties.Resources.logo_fretworks;
            LogoFretworks.Location = new Point(7, 549);
            LogoFretworks.Name = "LogoFretworks";
            LogoFretworks.Size = new Size(300, 95);
            LogoFretworks.SizeMode = PictureBoxSizeMode.StretchImage;
            LogoFretworks.TabIndex = 8;
            LogoFretworks.TabStop = false;
            // 
            // WhiteOverlay
            // 
            WhiteOverlay.BackColor = Color.Transparent;
            WhiteOverlay.BackgroundImage = Properties.Resources.light_overlay;
            WhiteOverlay.Location = new Point(314, 65);
            WhiteOverlay.Name = "WhiteOverlay";
            WhiteOverlay.Size = new Size(701, 671);
            WhiteOverlay.TabIndex = 11;
            WhiteOverlay.TabStop = false;
            // 
            // MOTDDarkOverlay
            // 
            MOTDDarkOverlay.BackColor = Color.Transparent;
            MOTDDarkOverlay.BackgroundImage = Properties.Resources.dark_overlay_m;
            MOTDDarkOverlay.Location = new Point(313, 1);
            MOTDDarkOverlay.Name = "MOTDDarkOverlay";
            MOTDDarkOverlay.Size = new Size(701, 744);
            MOTDDarkOverlay.TabIndex = 13;
            MOTDDarkOverlay.TabStop = false;
            // 
            // process1
            // 
            process1.StartInfo.Domain = "";
            process1.StartInfo.LoadUserProfile = false;
            process1.StartInfo.Password = null;
            process1.StartInfo.StandardErrorEncoding = null;
            process1.StartInfo.StandardInputEncoding = null;
            process1.StartInfo.StandardOutputEncoding = null;
            process1.StartInfo.UserName = "";
            process1.SynchronizingObject = this;
            // 
            // TabGeneralGroup
            // 
            TabGeneralGroup.BackColor = Color.Transparent;
            TabGeneralGroup.BackgroundImage = Properties.Resources.white_overlay_d_l;
            TabGeneralGroup.Controls.Add(RichPresence);
            TabGeneralGroup.Controls.Add(TabGeneralSocialHeader);
            TabGeneralGroup.Location = new Point(327, 75);
            TabGeneralGroup.Name = "TabGeneralGroup";
            TabGeneralGroup.Size = new Size(669, 642);
            TabGeneralGroup.TabIndex = 14;
            TabGeneralGroup.TabStop = false;
            // 
            // TabGeneralSocialHeader
            // 
            TabGeneralSocialHeader.AutoSize = true;
            TabGeneralSocialHeader.Font = new Font("Lexend", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TabGeneralSocialHeader.Location = new Point(12, 16);
            TabGeneralSocialHeader.Name = "TabGeneralSocialHeader";
            TabGeneralSocialHeader.Size = new Size(127, 25);
            TabGeneralSocialHeader.TabIndex = 0;
            TabGeneralSocialHeader.Text = "Social Config";
            // 
            // RichPresence
            // 
            RichPresence.AutoSize = true;
            RichPresence.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            RichPresence.Location = new Point(24, 47);
            RichPresence.Name = "RichPresence";
            RichPresence.Size = new Size(208, 26);
            RichPresence.TabIndex = 1;
            RichPresence.Text = "Use Discord Rich Presence";
            RichPresence.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImage = Properties.Resources.bg_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1008, 729);
            Controls.Add(TabGeneralGroup);
            Controls.Add(TabButtonGroup);
            Controls.Add(CheckForUpdates);
            Controls.Add(OpenMods);
            Controls.Add(AdjustSettings);
            Controls.Add(VersionInfoLabel);
            Controls.Add(LogoFretworks);
            Controls.Add(RunWTDE);
            Controls.Add(LogoWTDE);
            Controls.Add(WhiteOverlay);
            Controls.Add(MOTDLabel);
            Controls.Add(MOTDDarkOverlay);
            Controls.Add(LeftDarkOverlay);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main";
            Text = "GHWT: Definitive Edition Launcher V3.0";
            ((System.ComponentModel.ISupportInitialize)LeftDarkOverlay).EndInit();
            TabButtonGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LogoWTDE).EndInit();
            ((System.ComponentModel.ISupportInitialize)LogoFretworks).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhiteOverlay).EndInit();
            ((System.ComponentModel.ISupportInitialize)MOTDDarkOverlay).EndInit();
            TabGeneralGroup.ResumeLayout(false);
            TabGeneralGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox LeftDarkOverlay;
        private Label VersionInfoLabel;
        private Panel TabButtonGroup;
        private PictureBox LogoWTDE;
        private Button RunWTDE;
        private ToolTip ToolTipMain;
        private PictureBox LogoFretworks;
        private Label MOTDLabel;
        private Button AdjustSettings;
        private Button OpenMods;
        private PictureBox WhiteOverlay;
        private Button CheckForUpdates;
        private Button TabButtonGeneral;
        private PictureBox MOTDDarkOverlay;
        private System.Diagnostics.Process process1;
        private GroupBox TabGeneralGroup;
        private Label TabGeneralSocialHeader;
        private CheckBox RichPresence;
    }
}