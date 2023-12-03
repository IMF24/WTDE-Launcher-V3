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
            TabGeneralGroup = new GroupBox();
            UseQuitOption = new CheckBox();
            UseOptionsOption = new CheckBox();
            UseCAROption = new CheckBox();
            UseMusicStudioOption = new CheckBox();
            UseOnlineOption = new CheckBox();
            UseHeadToHeadOption = new CheckBox();
            UseQuickplayOption = new CheckBox();
            UseCareerOption = new CheckBox();
            WhammyPitchShift = new CheckBox();
            MuteStreams = new CheckBox();
            AllowHolidays = new CheckBox();
            RichPresence = new CheckBox();
            TabGeneralMMOHeader = new Label();
            StatusHandler = new CheckBox();
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
            MOTDLabel.BackColor = Color.Transparent;
            MOTDLabel.Font = new Font("Lexend", 9F, FontStyle.Regular, GraphicsUnit.Point);
            MOTDLabel.ForeColor = Color.White;
            MOTDLabel.Image = Properties.Resources.dark_overlay_m_l;
            MOTDLabel.Location = new Point(327, 15);
            MOTDLabel.Name = "MOTDLabel";
            MOTDLabel.Size = new Size(669, 702);
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
            // TabGeneralGroup
            // 
            TabGeneralGroup.BackColor = Color.Transparent;
            TabGeneralGroup.BackgroundImage = Properties.Resources.white_overlay_d_l;
            TabGeneralGroup.Controls.Add(StatusHandler);
            TabGeneralGroup.Controls.Add(UseQuitOption);
            TabGeneralGroup.Controls.Add(UseOptionsOption);
            TabGeneralGroup.Controls.Add(UseCAROption);
            TabGeneralGroup.Controls.Add(UseMusicStudioOption);
            TabGeneralGroup.Controls.Add(UseOnlineOption);
            TabGeneralGroup.Controls.Add(UseHeadToHeadOption);
            TabGeneralGroup.Controls.Add(UseQuickplayOption);
            TabGeneralGroup.Controls.Add(UseCareerOption);
            TabGeneralGroup.Controls.Add(WhammyPitchShift);
            TabGeneralGroup.Controls.Add(MuteStreams);
            TabGeneralGroup.Controls.Add(AllowHolidays);
            TabGeneralGroup.Controls.Add(RichPresence);
            TabGeneralGroup.Controls.Add(TabGeneralMMOHeader);
            TabGeneralGroup.Location = new Point(327, 75);
            TabGeneralGroup.Name = "TabGeneralGroup";
            TabGeneralGroup.Size = new Size(669, 642);
            TabGeneralGroup.TabIndex = 14;
            TabGeneralGroup.TabStop = false;
            // 
            // UseQuitOption
            // 
            UseQuitOption.AutoSize = true;
            UseQuitOption.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            UseQuitOption.Location = new Point(418, 273);
            UseQuitOption.Name = "UseQuitOption";
            UseQuitOption.Size = new Size(55, 26);
            UseQuitOption.TabIndex = 12;
            UseQuitOption.Text = "Exit";
            UseQuitOption.UseVisualStyleBackColor = true;
            // 
            // UseOptionsOption
            // 
            UseOptionsOption.AutoSize = true;
            UseOptionsOption.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            UseOptionsOption.Location = new Point(418, 243);
            UseOptionsOption.Name = "UseOptionsOption";
            UseOptionsOption.Size = new Size(82, 26);
            UseOptionsOption.TabIndex = 11;
            UseOptionsOption.Text = "Options";
            UseOptionsOption.UseVisualStyleBackColor = true;
            // 
            // UseCAROption
            // 
            UseCAROption.AutoSize = true;
            UseCAROption.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            UseCAROption.Location = new Point(418, 211);
            UseCAROption.Name = "UseCAROption";
            UseCAROption.Size = new Size(153, 26);
            UseCAROption.TabIndex = 10;
            UseCAROption.Text = "Rock Star Creator";
            UseCAROption.UseVisualStyleBackColor = true;
            // 
            // UseMusicStudioOption
            // 
            UseMusicStudioOption.AutoSize = true;
            UseMusicStudioOption.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            UseMusicStudioOption.Location = new Point(418, 179);
            UseMusicStudioOption.Name = "UseMusicStudioOption";
            UseMusicStudioOption.Size = new Size(115, 26);
            UseMusicStudioOption.TabIndex = 9;
            UseMusicStudioOption.Text = "Music Studio";
            UseMusicStudioOption.UseVisualStyleBackColor = true;
            // 
            // UseOnlineOption
            // 
            UseOnlineOption.AutoSize = true;
            UseOnlineOption.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            UseOnlineOption.Location = new Point(418, 147);
            UseOnlineOption.Name = "UseOnlineOption";
            UseOnlineOption.Size = new Size(72, 26);
            UseOnlineOption.TabIndex = 8;
            UseOnlineOption.Text = "Online";
            UseOnlineOption.UseVisualStyleBackColor = true;
            // 
            // UseHeadToHeadOption
            // 
            UseHeadToHeadOption.AutoSize = true;
            UseHeadToHeadOption.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            UseHeadToHeadOption.Location = new Point(418, 115);
            UseHeadToHeadOption.Name = "UseHeadToHeadOption";
            UseHeadToHeadOption.Size = new Size(125, 26);
            UseHeadToHeadOption.TabIndex = 7;
            UseHeadToHeadOption.Text = "Head to Head";
            UseHeadToHeadOption.UseVisualStyleBackColor = true;
            // 
            // UseQuickplayOption
            // 
            UseQuickplayOption.AutoSize = true;
            UseQuickplayOption.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            UseQuickplayOption.Location = new Point(418, 83);
            UseQuickplayOption.Name = "UseQuickplayOption";
            UseQuickplayOption.Size = new Size(97, 26);
            UseQuickplayOption.TabIndex = 6;
            UseQuickplayOption.Text = "Quickplay";
            UseQuickplayOption.UseVisualStyleBackColor = true;
            // 
            // UseCareerOption
            // 
            UseCareerOption.AutoSize = true;
            UseCareerOption.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            UseCareerOption.Location = new Point(418, 51);
            UseCareerOption.Name = "UseCareerOption";
            UseCareerOption.Size = new Size(76, 26);
            UseCareerOption.TabIndex = 5;
            UseCareerOption.Text = "Career";
            UseCareerOption.UseVisualStyleBackColor = true;
            // 
            // WhammyPitchShift
            // 
            WhammyPitchShift.AutoSize = true;
            WhammyPitchShift.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            WhammyPitchShift.Location = new Point(24, 115);
            WhammyPitchShift.Name = "WhammyPitchShift";
            WhammyPitchShift.Size = new Size(167, 26);
            WhammyPitchShift.TabIndex = 4;
            WhammyPitchShift.Text = "Whammy Pitch Shift";
            WhammyPitchShift.UseVisualStyleBackColor = true;
            // 
            // MuteStreams
            // 
            MuteStreams.AutoSize = true;
            MuteStreams.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            MuteStreams.Location = new Point(24, 83);
            MuteStreams.Name = "MuteStreams";
            MuteStreams.Size = new Size(219, 26);
            MuteStreams.TabIndex = 3;
            MuteStreams.Text = "Mute Split Tracks Upon Miss";
            MuteStreams.UseVisualStyleBackColor = true;
            // 
            // AllowHolidays
            // 
            AllowHolidays.AutoSize = true;
            AllowHolidays.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AllowHolidays.Location = new Point(24, 51);
            AllowHolidays.Name = "AllowHolidays";
            AllowHolidays.Size = new Size(168, 26);
            AllowHolidays.TabIndex = 2;
            AllowHolidays.Text = "Use Holiday Themes";
            AllowHolidays.UseVisualStyleBackColor = true;
            // 
            // RichPresence
            // 
            RichPresence.AutoSize = true;
            RichPresence.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            RichPresence.Location = new Point(24, 19);
            RichPresence.Name = "RichPresence";
            RichPresence.Size = new Size(208, 26);
            RichPresence.TabIndex = 1;
            RichPresence.Text = "Use Discord Rich Presence";
            RichPresence.UseVisualStyleBackColor = true;
            // 
            // TabGeneralMMOHeader
            // 
            TabGeneralMMOHeader.AutoSize = true;
            TabGeneralMMOHeader.Font = new Font("Lexend", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TabGeneralMMOHeader.Location = new Point(398, 18);
            TabGeneralMMOHeader.Name = "TabGeneralMMOHeader";
            TabGeneralMMOHeader.Size = new Size(184, 25);
            TabGeneralMMOHeader.TabIndex = 0;
            TabGeneralMMOHeader.Text = "Main Menu Options:";
            // 
            // StatusHandler
            // 
            StatusHandler.AutoSize = true;
            StatusHandler.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            StatusHandler.Location = new Point(24, 147);
            StatusHandler.Name = "StatusHandler";
            StatusHandler.Size = new Size(169, 26);
            StatusHandler.TabIndex = 13;
            StatusHandler.Text = "Write Streamer Files";
            StatusHandler.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImage = Properties.Resources.bg_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1008, 729);
            Controls.Add(TabGeneralGroup);
            Controls.Add(CheckForUpdates);
            Controls.Add(OpenMods);
            Controls.Add(AdjustSettings);
            Controls.Add(VersionInfoLabel);
            Controls.Add(LogoFretworks);
            Controls.Add(RunWTDE);
            Controls.Add(LogoWTDE);
            Controls.Add(WhiteOverlay);
            Controls.Add(LeftDarkOverlay);
            Controls.Add(TabButtonGroup);
            Controls.Add(MOTDLabel);
            Controls.Add(MOTDDarkOverlay);
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
        private GroupBox TabGeneralGroup;
        private Label TabGeneralMMOHeader;
        private CheckBox RichPresence;
        private CheckBox AllowHolidays;
        private CheckBox MuteStreams;
        private CheckBox WhammyPitchShift;
        private CheckBox UseCareerOption;
        private CheckBox UseQuickplayOption;
        private CheckBox UseHeadToHeadOption;
        private CheckBox UseOnlineOption;
        private CheckBox UseMusicStudioOption;
        private CheckBox UseCAROption;
        private CheckBox UseOptionsOption;
        private CheckBox UseQuitOption;
        private CheckBox StatusHandler;
    }
}