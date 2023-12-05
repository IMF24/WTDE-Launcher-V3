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
            TabButtonDebug = new Button();
            TabButtonAutoLaunch = new Button();
            TabButtonBand = new Button();
            TabButtonGraphics = new Button();
            TabButtonInput = new Button();
            TabButtonGeneral = new Button();
            MOTDLabel = new Label();
            LogoWTDE = new PictureBox();
            RunWTDE = new Button();
            ToolTipMain = new ToolTip(components);
            AdjustSettings = new Button();
            OpenMods = new Button();
            CheckForUpdates = new Button();
            RichPresence = new CheckBox();
            AllowHolidays = new CheckBox();
            MuteStreams = new CheckBox();
            StatusHandler = new CheckBox();
            WhammyPitchShift = new CheckBox();
            AutoCheckForUpdates = new CheckBox();
            DefaultQPODifficulty = new ComboBox();
            AutoLaunchPlayers = new ComboBox();
            AutoLaunchEncoreMode = new CheckBox();
            AutoLaunchSongTime = new CheckBox();
            EnableAutoLaunch = new CheckBox();
            AutoLaunchVenue = new ComboBox();
            AutoLaunchPart1 = new ComboBox();
            AutoLaunchDifficulty1 = new ComboBox();
            AutoLaunchDifficulty2 = new ComboBox();
            AutoLaunchPart2 = new ComboBox();
            AutoLaunchDifficulty3 = new ComboBox();
            AutoLaunchPart3 = new ComboBox();
            AutoLaunchDifficulty4 = new ComboBox();
            AutoLaunchPart4 = new ComboBox();
            AutoLaunchSong = new TextBox();
            LogoFretworks = new PictureBox();
            MOTDDarkOverlay = new PictureBox();
            TabGeneralGroup = new GroupBox();
            TabGeneralBSHeader = new Label();
            TabGeneralLOHeader = new Label();
            DefaultQPODifficultyLabel = new Label();
            UseQuitOption = new CheckBox();
            UseOptionsOption = new CheckBox();
            UseCAROption = new CheckBox();
            UseMusicStudioOption = new CheckBox();
            UseOnlineOption = new CheckBox();
            UseHeadToHeadOption = new CheckBox();
            UseQuickplayOption = new CheckBox();
            UseCareerOption = new CheckBox();
            TabGeneralMMOHeader = new Label();
            TabAutoLaunchGroup = new GroupBox();
            TabALEditorPanel = new Panel();
            AutoLaunchSongSelectINI = new Button();
            AutoLaunchDiffsLabel = new Label();
            AutoLaunchPartsLabel = new Label();
            TabAutoLaunchALSHeader = new Label();
            label1 = new Label();
            AutoLaunchHideHUD = new CheckBox();
            AutoLaunchBot4 = new CheckBox();
            AutoLaunchBot1 = new CheckBox();
            AutoLaunchRawLoad = new CheckBox();
            AutoLaunchP3Label = new Label();
            AutoLaunchPlayersLabel = new Label();
            AutoLaunchBot3 = new CheckBox();
            TabAutoLaunchASHeader = new Label();
            TabAutoLaunchPSHeader = new Label();
            AutoLaunchSongLabel = new Label();
            AutoLaunchP2Label = new Label();
            AutoLaunchVenueLabel = new Label();
            AutoLaunchBot2 = new CheckBox();
            AutoLaunchP1Label = new Label();
            TabParentContainer = new Panel();
            ((System.ComponentModel.ISupportInitialize)LeftDarkOverlay).BeginInit();
            TabButtonGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoWTDE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LogoFretworks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MOTDDarkOverlay).BeginInit();
            TabGeneralGroup.SuspendLayout();
            TabAutoLaunchGroup.SuspendLayout();
            TabALEditorPanel.SuspendLayout();
            TabParentContainer.SuspendLayout();
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
            TabButtonGroup.BackgroundImageLayout = ImageLayout.Stretch;
            TabButtonGroup.Controls.Add(TabButtonDebug);
            TabButtonGroup.Controls.Add(TabButtonAutoLaunch);
            TabButtonGroup.Controls.Add(TabButtonBand);
            TabButtonGroup.Controls.Add(TabButtonGraphics);
            TabButtonGroup.Controls.Add(TabButtonInput);
            TabButtonGroup.Controls.Add(TabButtonGeneral);
            TabButtonGroup.Location = new Point(314, -1);
            TabButtonGroup.Name = "TabButtonGroup";
            TabButtonGroup.Size = new Size(701, 66);
            TabButtonGroup.TabIndex = 5;
            // 
            // TabButtonDebug
            // 
            TabButtonDebug.BackColor = Color.Transparent;
            TabButtonDebug.BackgroundImage = Properties.Resources.dark_overlay_d;
            TabButtonDebug.BackgroundImageLayout = ImageLayout.Stretch;
            TabButtonDebug.Cursor = Cursors.Hand;
            TabButtonDebug.FlatAppearance.BorderColor = Color.White;
            TabButtonDebug.FlatAppearance.MouseDownBackColor = Color.Transparent;
            TabButtonDebug.FlatAppearance.MouseOverBackColor = Color.Transparent;
            TabButtonDebug.FlatStyle = FlatStyle.Flat;
            TabButtonDebug.Font = new Font("Lexend", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TabButtonDebug.ForeColor = Color.White;
            TabButtonDebug.Location = new Point(578, 10);
            TabButtonDebug.Name = "TabButtonDebug";
            TabButtonDebug.RightToLeft = RightToLeft.No;
            TabButtonDebug.Size = new Size(107, 44);
            TabButtonDebug.TabIndex = 18;
            TabButtonDebug.Text = "Debug";
            ToolTipMain.SetToolTip(TabButtonDebug, "Adjust general settings about WTDE.");
            TabButtonDebug.UseVisualStyleBackColor = false;
            // 
            // TabButtonAutoLaunch
            // 
            TabButtonAutoLaunch.BackColor = Color.Transparent;
            TabButtonAutoLaunch.BackgroundImage = Properties.Resources.dark_overlay_d;
            TabButtonAutoLaunch.BackgroundImageLayout = ImageLayout.Stretch;
            TabButtonAutoLaunch.Cursor = Cursors.Hand;
            TabButtonAutoLaunch.FlatAppearance.BorderColor = Color.White;
            TabButtonAutoLaunch.FlatAppearance.MouseDownBackColor = Color.Transparent;
            TabButtonAutoLaunch.FlatAppearance.MouseOverBackColor = Color.Transparent;
            TabButtonAutoLaunch.FlatStyle = FlatStyle.Flat;
            TabButtonAutoLaunch.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TabButtonAutoLaunch.ForeColor = Color.White;
            TabButtonAutoLaunch.Location = new Point(465, 10);
            TabButtonAutoLaunch.Name = "TabButtonAutoLaunch";
            TabButtonAutoLaunch.RightToLeft = RightToLeft.No;
            TabButtonAutoLaunch.Size = new Size(107, 44);
            TabButtonAutoLaunch.TabIndex = 17;
            TabButtonAutoLaunch.Text = "Auto Launch";
            ToolTipMain.SetToolTip(TabButtonAutoLaunch, "Adjust general settings about WTDE.");
            TabButtonAutoLaunch.UseVisualStyleBackColor = false;
            TabButtonAutoLaunch.Click += TabButtonAutoLaunch_Click;
            // 
            // TabButtonBand
            // 
            TabButtonBand.BackColor = Color.Transparent;
            TabButtonBand.BackgroundImage = Properties.Resources.dark_overlay_d;
            TabButtonBand.BackgroundImageLayout = ImageLayout.Stretch;
            TabButtonBand.Cursor = Cursors.Hand;
            TabButtonBand.FlatAppearance.BorderColor = Color.White;
            TabButtonBand.FlatAppearance.MouseDownBackColor = Color.Transparent;
            TabButtonBand.FlatAppearance.MouseOverBackColor = Color.Transparent;
            TabButtonBand.FlatStyle = FlatStyle.Flat;
            TabButtonBand.Font = new Font("Lexend", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TabButtonBand.ForeColor = Color.White;
            TabButtonBand.Location = new Point(352, 10);
            TabButtonBand.Name = "TabButtonBand";
            TabButtonBand.RightToLeft = RightToLeft.No;
            TabButtonBand.Size = new Size(107, 44);
            TabButtonBand.TabIndex = 16;
            TabButtonBand.Text = "Band";
            ToolTipMain.SetToolTip(TabButtonBand, "Adjust general settings about WTDE.");
            TabButtonBand.UseVisualStyleBackColor = false;
            // 
            // TabButtonGraphics
            // 
            TabButtonGraphics.BackColor = Color.Transparent;
            TabButtonGraphics.BackgroundImage = Properties.Resources.dark_overlay_d;
            TabButtonGraphics.BackgroundImageLayout = ImageLayout.Stretch;
            TabButtonGraphics.Cursor = Cursors.Hand;
            TabButtonGraphics.FlatAppearance.BorderColor = Color.White;
            TabButtonGraphics.FlatAppearance.MouseDownBackColor = Color.Transparent;
            TabButtonGraphics.FlatAppearance.MouseOverBackColor = Color.Transparent;
            TabButtonGraphics.FlatStyle = FlatStyle.Flat;
            TabButtonGraphics.Font = new Font("Lexend", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TabButtonGraphics.ForeColor = Color.White;
            TabButtonGraphics.Location = new Point(239, 10);
            TabButtonGraphics.Name = "TabButtonGraphics";
            TabButtonGraphics.RightToLeft = RightToLeft.No;
            TabButtonGraphics.Size = new Size(107, 44);
            TabButtonGraphics.TabIndex = 15;
            TabButtonGraphics.Text = "Graphics";
            ToolTipMain.SetToolTip(TabButtonGraphics, "Adjust general settings about WTDE.");
            TabButtonGraphics.UseVisualStyleBackColor = false;
            // 
            // TabButtonInput
            // 
            TabButtonInput.BackColor = Color.Transparent;
            TabButtonInput.BackgroundImage = Properties.Resources.dark_overlay_d;
            TabButtonInput.BackgroundImageLayout = ImageLayout.Stretch;
            TabButtonInput.Cursor = Cursors.Hand;
            TabButtonInput.FlatAppearance.BorderColor = Color.White;
            TabButtonInput.FlatAppearance.MouseDownBackColor = Color.Transparent;
            TabButtonInput.FlatAppearance.MouseOverBackColor = Color.Transparent;
            TabButtonInput.FlatStyle = FlatStyle.Flat;
            TabButtonInput.Font = new Font("Lexend", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TabButtonInput.ForeColor = Color.White;
            TabButtonInput.Location = new Point(126, 10);
            TabButtonInput.Name = "TabButtonInput";
            TabButtonInput.RightToLeft = RightToLeft.No;
            TabButtonInput.Size = new Size(107, 44);
            TabButtonInput.TabIndex = 14;
            TabButtonInput.Text = "Input";
            ToolTipMain.SetToolTip(TabButtonInput, "Adjust general settings about WTDE.");
            TabButtonInput.UseVisualStyleBackColor = false;
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
            // 
            // RichPresence
            // 
            RichPresence.AutoSize = true;
            RichPresence.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            RichPresence.Location = new Point(30, 51);
            RichPresence.Name = "RichPresence";
            RichPresence.Size = new Size(208, 26);
            RichPresence.TabIndex = 1;
            RichPresence.Text = "Use Discord Rich Presence";
            ToolTipMain.SetToolTip(RichPresence, resources.GetString("RichPresence.ToolTip"));
            RichPresence.UseVisualStyleBackColor = true;
            RichPresence.CheckedChanged += RichPresence_CheckedChanged;
            // 
            // AllowHolidays
            // 
            AllowHolidays.AutoSize = true;
            AllowHolidays.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AllowHolidays.Location = new Point(30, 83);
            AllowHolidays.Name = "AllowHolidays";
            AllowHolidays.Size = new Size(168, 26);
            AllowHolidays.TabIndex = 2;
            AllowHolidays.Text = "Use Holiday Themes";
            ToolTipMain.SetToolTip(AllowHolidays, resources.GetString("AllowHolidays.ToolTip"));
            AllowHolidays.UseVisualStyleBackColor = true;
            AllowHolidays.CheckedChanged += AllowHolidays_CheckedChanged;
            // 
            // MuteStreams
            // 
            MuteStreams.AutoSize = true;
            MuteStreams.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            MuteStreams.Location = new Point(30, 115);
            MuteStreams.Name = "MuteStreams";
            MuteStreams.Size = new Size(219, 26);
            MuteStreams.TabIndex = 3;
            MuteStreams.Text = "Mute Split Tracks Upon Miss";
            ToolTipMain.SetToolTip(MuteStreams, "Turn ON or OFF muting of instrument tracks upon notes being missed. If enabled,\r\nwhen a note is missed, its respective track will be muted until another note is hit.");
            MuteStreams.UseVisualStyleBackColor = true;
            MuteStreams.CheckedChanged += MuteStreams_CheckedChanged;
            // 
            // StatusHandler
            // 
            StatusHandler.AutoSize = true;
            StatusHandler.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            StatusHandler.Location = new Point(30, 179);
            StatusHandler.Name = "StatusHandler";
            StatusHandler.Size = new Size(169, 26);
            StatusHandler.TabIndex = 13;
            StatusHandler.Text = "Write Streamer Files";
            ToolTipMain.SetToolTip(StatusHandler, "When enabled, this will export to the Logs folder various text files for streamers to use containing\r\nvarious information, such as the song currently playing, artist, venue, etc.");
            StatusHandler.UseVisualStyleBackColor = true;
            StatusHandler.CheckedChanged += StatusHandler_CheckedChanged;
            // 
            // WhammyPitchShift
            // 
            WhammyPitchShift.AutoSize = true;
            WhammyPitchShift.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            WhammyPitchShift.Location = new Point(30, 147);
            WhammyPitchShift.Name = "WhammyPitchShift";
            WhammyPitchShift.Size = new Size(167, 26);
            WhammyPitchShift.TabIndex = 4;
            WhammyPitchShift.Text = "Whammy Pitch Shift";
            ToolTipMain.SetToolTip(WhammyPitchShift, "Turn ON or OFF whammy effects. If this is OFF, audio distortion by whammy will be disabled.");
            WhammyPitchShift.UseVisualStyleBackColor = true;
            WhammyPitchShift.CheckedChanged += WhammyPitchShift_CheckedChanged;
            // 
            // AutoCheckForUpdates
            // 
            AutoCheckForUpdates.AutoSize = true;
            AutoCheckForUpdates.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AutoCheckForUpdates.Location = new Point(30, 437);
            AutoCheckForUpdates.Name = "AutoCheckForUpdates";
            AutoCheckForUpdates.Size = new Size(194, 26);
            AutoCheckForUpdates.TabIndex = 16;
            AutoCheckForUpdates.Text = "Auto Check For Updates";
            ToolTipMain.SetToolTip(AutoCheckForUpdates, "Enable or disable the functionality to check for updates to WTDE when the launcher starts up.\r\n");
            AutoCheckForUpdates.UseVisualStyleBackColor = true;
            AutoCheckForUpdates.CheckedChanged += AutoCheckForUpdates_CheckedChanged;
            // 
            // DefaultQPODifficulty
            // 
            DefaultQPODifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            DefaultQPODifficulty.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DefaultQPODifficulty.FormattingEnabled = true;
            DefaultQPODifficulty.Items.AddRange(new object[] { "Beginner", "Easy", "Medium", "Hard", "Expert" });
            DefaultQPODifficulty.Location = new Point(240, 216);
            DefaultQPODifficulty.Name = "DefaultQPODifficulty";
            DefaultQPODifficulty.Size = new Size(106, 23);
            DefaultQPODifficulty.TabIndex = 15;
            ToolTipMain.SetToolTip(DefaultQPODifficulty, "The default difficulty that will be selected when playing a song for the first time in Quickplay.");
            DefaultQPODifficulty.SelectedIndexChanged += DefaultQPODifficulty_SelectedIndexChanged;
            // 
            // AutoLaunchPlayers
            // 
            AutoLaunchPlayers.DropDownStyle = ComboBoxStyle.DropDownList;
            AutoLaunchPlayers.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchPlayers.FormattingEnabled = true;
            AutoLaunchPlayers.Items.AddRange(new object[] { "1", "2", "3", "4" });
            AutoLaunchPlayers.Location = new Point(90, 52);
            AutoLaunchPlayers.Name = "AutoLaunchPlayers";
            AutoLaunchPlayers.Size = new Size(48, 23);
            AutoLaunchPlayers.TabIndex = 15;
            ToolTipMain.SetToolTip(AutoLaunchPlayers, "How many players do you want?");
            AutoLaunchPlayers.SelectedIndexChanged += AutoLaunchPlayers_SelectedIndexChanged;
            // 
            // AutoLaunchEncoreMode
            // 
            AutoLaunchEncoreMode.AutoSize = true;
            AutoLaunchEncoreMode.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchEncoreMode.Location = new Point(20, 368);
            AutoLaunchEncoreMode.Name = "AutoLaunchEncoreMode";
            AutoLaunchEncoreMode.Size = new Size(148, 26);
            AutoLaunchEncoreMode.TabIndex = 13;
            AutoLaunchEncoreMode.Text = "Last Song Encore";
            ToolTipMain.SetToolTip(AutoLaunchEncoreMode, "When enabled, this will export to the Logs folder various text files for streamers to use containing\r\nvarious information, such as the song currently playing, artist, venue, etc.");
            AutoLaunchEncoreMode.UseVisualStyleBackColor = true;
            AutoLaunchEncoreMode.CheckedChanged += AutoLaunchEncoreMode_CheckedChanged;
            // 
            // AutoLaunchSongTime
            // 
            AutoLaunchSongTime.AutoSize = true;
            AutoLaunchSongTime.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchSongTime.Location = new Point(172, 336);
            AutoLaunchSongTime.Name = "AutoLaunchSongTime";
            AutoLaunchSongTime.Size = new Size(142, 26);
            AutoLaunchSongTime.TabIndex = 4;
            AutoLaunchSongTime.Text = "Show Song Time";
            ToolTipMain.SetToolTip(AutoLaunchSongTime, "Turn ON or OFF whammy effects. If this is OFF, audio distortion by whammy will be disabled.");
            AutoLaunchSongTime.UseVisualStyleBackColor = true;
            AutoLaunchSongTime.CheckedChanged += AutoLaunchSongTime_CheckedChanged;
            // 
            // EnableAutoLaunch
            // 
            EnableAutoLaunch.AutoSize = true;
            EnableAutoLaunch.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EnableAutoLaunch.Location = new Point(15, 23);
            EnableAutoLaunch.Name = "EnableAutoLaunch";
            EnableAutoLaunch.Size = new Size(164, 26);
            EnableAutoLaunch.TabIndex = 1;
            EnableAutoLaunch.Text = "Enable Auto Launch";
            ToolTipMain.SetToolTip(EnableAutoLaunch, resources.GetString("EnableAutoLaunch.ToolTip"));
            EnableAutoLaunch.UseVisualStyleBackColor = true;
            EnableAutoLaunch.CheckedChanged += EnableAutoLaunch_CheckedChanged;
            // 
            // AutoLaunchVenue
            // 
            AutoLaunchVenue.DropDownStyle = ComboBoxStyle.DropDownList;
            AutoLaunchVenue.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchVenue.FormattingEnabled = true;
            AutoLaunchVenue.Items.AddRange(new object[] { "WT: Phi Psi Kappa", "WT: Wilted Orchid", "WT: Bone Church", "WT: Pang Tang Bay", "WT: Amoeba Records", "WT: Tool", "WT: Swamp Shack", "WT: Rock Brigade", "WT: Strutter's Farm", "WT: House of Blues", "WT: Ted's Tiki Hut", "WT: Will Heilm's Keep", "WT: Recording Studio", "WT: AT&T Park", "WT: Tesla's Coil", "WT: Ozzfest", "WT: Times Square", "WT: Sunna's Chariot", "GHM: The Forum", "GHM: Tushino Air Field", "GHM: Hammersmith Apollo", "GHM: Damaged Justice Tour", "GHM: The Meadowlands", "GHM: Donington Park", "GHM: The Ice Cave", "GHM: Metallica Recording Studio", "GHM: Metallica Backstage", "SH: Amazon Rain Forest", "SH: The Grand Canyon", "SH: Polar Ice Cap", "SH: London Sewerage System", "SH: The Sphinx", "SH: The Great Wall of China", "SH: The Lost City of Atlantis", "SH: Quebec City", "VH: Los Angeles", "VH: West Hollywood", "VH: Rome", "VH: New York City", "VH: Berlin", "VH: Dallas", "VH: London", "VH: The Netherlands", "GH5: The 13th Rail", "GH5: Club Boson", "GH5: Sideshow", "GH5: O'Connell's Corner", "GH5: Guitarhenge", "GH5: Electric Honky Tonk", "GH5: Calavera Square", "GH5: Hypersphere", "BH: Mall of Fame Tour", "BH: Club La Noza", "BH: Summer Park Festival", "BH: Harajuku", "BH: Everpop Awards", "BH: AMP Orbiter", "III: Desert Rock Tour", "III: Lou's Inferno" });
            AutoLaunchVenue.Location = new Point(454, 52);
            AutoLaunchVenue.Name = "AutoLaunchVenue";
            AutoLaunchVenue.Size = new Size(171, 23);
            AutoLaunchVenue.TabIndex = 22;
            ToolTipMain.SetToolTip(AutoLaunchVenue, "The default difficulty that will be selected when playing a song for the first time in Quickplay.");
            AutoLaunchVenue.SelectedIndexChanged += AutoLaunchVenue_SelectedIndexChanged;
            // 
            // AutoLaunchPart1
            // 
            AutoLaunchPart1.DropDownStyle = ComboBoxStyle.DropDownList;
            AutoLaunchPart1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchPart1.FormattingEnabled = true;
            AutoLaunchPart1.Items.AddRange(new object[] { "Lead Guitar - PART GUITAR", "Bass Guitar - PART BASS", "Drums - PART DRUMS", "Vocals - PART VOCALS" });
            AutoLaunchPart1.Location = new Point(136, 147);
            AutoLaunchPart1.Name = "AutoLaunchPart1";
            AutoLaunchPart1.Size = new Size(171, 23);
            AutoLaunchPart1.TabIndex = 25;
            ToolTipMain.SetToolTip(AutoLaunchPart1, "The default difficulty that will be selected when playing a song for the first time in Quickplay.");
            AutoLaunchPart1.SelectedIndexChanged += AutoLaunchPart1_SelectedIndexChanged;
            // 
            // AutoLaunchDifficulty1
            // 
            AutoLaunchDifficulty1.DropDownStyle = ComboBoxStyle.DropDownList;
            AutoLaunchDifficulty1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchDifficulty1.FormattingEnabled = true;
            AutoLaunchDifficulty1.Items.AddRange(new object[] { "Beginner", "Easy", "Medium", "Hard", "Expert" });
            AutoLaunchDifficulty1.Location = new Point(358, 147);
            AutoLaunchDifficulty1.Name = "AutoLaunchDifficulty1";
            AutoLaunchDifficulty1.Size = new Size(105, 23);
            AutoLaunchDifficulty1.TabIndex = 27;
            ToolTipMain.SetToolTip(AutoLaunchDifficulty1, "The default difficulty that will be selected when playing a song for the first time in Quickplay.");
            AutoLaunchDifficulty1.SelectedIndexChanged += AutoLaunchDifficulty1_SelectedIndexChanged;
            // 
            // AutoLaunchDifficulty2
            // 
            AutoLaunchDifficulty2.DropDownStyle = ComboBoxStyle.DropDownList;
            AutoLaunchDifficulty2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchDifficulty2.FormattingEnabled = true;
            AutoLaunchDifficulty2.Items.AddRange(new object[] { "Beginner", "Easy", "Medium", "Hard", "Expert" });
            AutoLaunchDifficulty2.Location = new Point(358, 182);
            AutoLaunchDifficulty2.Name = "AutoLaunchDifficulty2";
            AutoLaunchDifficulty2.Size = new Size(105, 23);
            AutoLaunchDifficulty2.TabIndex = 31;
            ToolTipMain.SetToolTip(AutoLaunchDifficulty2, "The default difficulty that will be selected when playing a song for the first time in Quickplay.");
            AutoLaunchDifficulty2.SelectedIndexChanged += AutoLaunchDifficulty2_SelectedIndexChanged;
            // 
            // AutoLaunchPart2
            // 
            AutoLaunchPart2.DropDownStyle = ComboBoxStyle.DropDownList;
            AutoLaunchPart2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchPart2.FormattingEnabled = true;
            AutoLaunchPart2.Items.AddRange(new object[] { "Lead Guitar - PART GUITAR", "Bass Guitar - PART BASS", "Drums - PART DRUMS", "Vocals - PART VOCALS" });
            AutoLaunchPart2.Location = new Point(136, 182);
            AutoLaunchPart2.Name = "AutoLaunchPart2";
            AutoLaunchPart2.Size = new Size(171, 23);
            AutoLaunchPart2.TabIndex = 30;
            ToolTipMain.SetToolTip(AutoLaunchPart2, "The default difficulty that will be selected when playing a song for the first time in Quickplay.");
            AutoLaunchPart2.SelectedIndexChanged += AutoLaunchPart2_SelectedIndexChanged;
            // 
            // AutoLaunchDifficulty3
            // 
            AutoLaunchDifficulty3.DropDownStyle = ComboBoxStyle.DropDownList;
            AutoLaunchDifficulty3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchDifficulty3.FormattingEnabled = true;
            AutoLaunchDifficulty3.Items.AddRange(new object[] { "Beginner", "Easy", "Medium", "Hard", "Expert" });
            AutoLaunchDifficulty3.Location = new Point(358, 217);
            AutoLaunchDifficulty3.Name = "AutoLaunchDifficulty3";
            AutoLaunchDifficulty3.Size = new Size(105, 23);
            AutoLaunchDifficulty3.TabIndex = 36;
            ToolTipMain.SetToolTip(AutoLaunchDifficulty3, "The default difficulty that will be selected when playing a song for the first time in Quickplay.");
            AutoLaunchDifficulty3.SelectedIndexChanged += AutoLaunchDifficulty3_SelectedIndexChanged;
            // 
            // AutoLaunchPart3
            // 
            AutoLaunchPart3.DropDownStyle = ComboBoxStyle.DropDownList;
            AutoLaunchPart3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchPart3.FormattingEnabled = true;
            AutoLaunchPart3.Items.AddRange(new object[] { "Lead Guitar - PART GUITAR", "Bass Guitar - PART BASS", "Drums - PART DRUMS", "Vocals - PART VOCALS" });
            AutoLaunchPart3.Location = new Point(136, 217);
            AutoLaunchPart3.Name = "AutoLaunchPart3";
            AutoLaunchPart3.Size = new Size(171, 23);
            AutoLaunchPart3.TabIndex = 35;
            ToolTipMain.SetToolTip(AutoLaunchPart3, "The default difficulty that will be selected when playing a song for the first time in Quickplay.");
            AutoLaunchPart3.SelectedIndexChanged += AutoLaunchPart3_SelectedIndexChanged;
            // 
            // AutoLaunchDifficulty4
            // 
            AutoLaunchDifficulty4.DropDownStyle = ComboBoxStyle.DropDownList;
            AutoLaunchDifficulty4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchDifficulty4.FormattingEnabled = true;
            AutoLaunchDifficulty4.Items.AddRange(new object[] { "Beginner", "Easy", "Medium", "Hard", "Expert" });
            AutoLaunchDifficulty4.Location = new Point(358, 253);
            AutoLaunchDifficulty4.Name = "AutoLaunchDifficulty4";
            AutoLaunchDifficulty4.Size = new Size(105, 23);
            AutoLaunchDifficulty4.TabIndex = 40;
            ToolTipMain.SetToolTip(AutoLaunchDifficulty4, "The default difficulty that will be selected when playing a song for the first time in Quickplay.");
            AutoLaunchDifficulty4.SelectedIndexChanged += AutoLaunchDifficulty4_SelectedIndexChanged;
            // 
            // AutoLaunchPart4
            // 
            AutoLaunchPart4.DropDownStyle = ComboBoxStyle.DropDownList;
            AutoLaunchPart4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchPart4.FormattingEnabled = true;
            AutoLaunchPart4.Items.AddRange(new object[] { "Lead Guitar - PART GUITAR", "Bass Guitar - PART BASS", "Drums - PART DRUMS", "Vocals - PART VOCALS" });
            AutoLaunchPart4.Location = new Point(136, 253);
            AutoLaunchPart4.Name = "AutoLaunchPart4";
            AutoLaunchPart4.Size = new Size(171, 23);
            AutoLaunchPart4.TabIndex = 39;
            ToolTipMain.SetToolTip(AutoLaunchPart4, "The default difficulty that will be selected when playing a song for the first time in Quickplay.");
            AutoLaunchPart4.SelectedIndexChanged += AutoLaunchPart4_SelectedIndexChanged;
            // 
            // AutoLaunchSong
            // 
            AutoLaunchSong.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchSong.Location = new Point(226, 52);
            AutoLaunchSong.Name = "AutoLaunchSong";
            AutoLaunchSong.PlaceholderText = "Insert checksum...";
            AutoLaunchSong.Size = new Size(133, 23);
            AutoLaunchSong.TabIndex = 20;
            ToolTipMain.SetToolTip(AutoLaunchSong, "What song should we boot into?");
            AutoLaunchSong.TextChanged += AutoLaunchSong_TextChanged;
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
            TabGeneralGroup.Controls.Add(TabGeneralBSHeader);
            TabGeneralGroup.Controls.Add(TabGeneralLOHeader);
            TabGeneralGroup.Controls.Add(AutoCheckForUpdates);
            TabGeneralGroup.Controls.Add(DefaultQPODifficulty);
            TabGeneralGroup.Controls.Add(DefaultQPODifficultyLabel);
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
            TabGeneralGroup.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TabGeneralGroup.Location = new Point(671, 11);
            TabGeneralGroup.Name = "TabGeneralGroup";
            TabGeneralGroup.Size = new Size(669, 642);
            TabGeneralGroup.TabIndex = 14;
            TabGeneralGroup.TabStop = false;
            TabGeneralGroup.Text = "DEBUG: General Tab";
            // 
            // TabGeneralBSHeader
            // 
            TabGeneralBSHeader.AutoSize = true;
            TabGeneralBSHeader.Font = new Font("Lexend", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TabGeneralBSHeader.Location = new Point(15, 18);
            TabGeneralBSHeader.Name = "TabGeneralBSHeader";
            TabGeneralBSHeader.Size = new Size(140, 25);
            TabGeneralBSHeader.TabIndex = 18;
            TabGeneralBSHeader.Text = "Basic Settings:";
            // 
            // TabGeneralLOHeader
            // 
            TabGeneralLOHeader.AutoSize = true;
            TabGeneralLOHeader.Font = new Font("Lexend", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TabGeneralLOHeader.Location = new Point(15, 405);
            TabGeneralLOHeader.Name = "TabGeneralLOHeader";
            TabGeneralLOHeader.Size = new Size(172, 25);
            TabGeneralLOHeader.TabIndex = 17;
            TabGeneralLOHeader.Text = "Launcher Options:";
            // 
            // DefaultQPODifficultyLabel
            // 
            DefaultQPODifficultyLabel.AutoSize = true;
            DefaultQPODifficultyLabel.Location = new Point(30, 215);
            DefaultQPODifficultyLabel.Name = "DefaultQPODifficultyLabel";
            DefaultQPODifficultyLabel.Size = new Size(204, 22);
            DefaultQPODifficultyLabel.TabIndex = 14;
            DefaultQPODifficultyLabel.Text = "Default Quickplay Difficulty: ";
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
            UseQuitOption.CheckedChanged += UseQuitOption_CheckedChanged;
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
            UseOptionsOption.CheckedChanged += UseOptionsOption_CheckedChanged;
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
            UseCAROption.CheckedChanged += UseCAROption_CheckedChanged;
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
            UseMusicStudioOption.CheckedChanged += UseMusicStudioOption_CheckedChanged;
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
            UseOnlineOption.CheckedChanged += UseOnlineOption_CheckedChanged;
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
            UseHeadToHeadOption.CheckedChanged += UseHeadToHeadOption_CheckedChanged;
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
            UseQuickplayOption.CheckedChanged += UseQuickplayOption_CheckedChanged;
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
            UseCareerOption.CheckedChanged += UseCareerOption_CheckedChanged;
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
            // TabAutoLaunchGroup
            // 
            TabAutoLaunchGroup.BackColor = Color.Transparent;
            TabAutoLaunchGroup.BackgroundImage = Properties.Resources.white_overlay_d_l;
            TabAutoLaunchGroup.Controls.Add(EnableAutoLaunch);
            TabAutoLaunchGroup.Controls.Add(TabALEditorPanel);
            TabAutoLaunchGroup.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TabAutoLaunchGroup.Location = new Point(13, 17);
            TabAutoLaunchGroup.Name = "TabAutoLaunchGroup";
            TabAutoLaunchGroup.Size = new Size(669, 642);
            TabAutoLaunchGroup.TabIndex = 15;
            TabAutoLaunchGroup.TabStop = false;
            TabAutoLaunchGroup.Text = "DEBUG: Auto Launch Tab";
            // 
            // TabALEditorPanel
            // 
            TabALEditorPanel.Controls.Add(AutoLaunchSongSelectINI);
            TabALEditorPanel.Controls.Add(AutoLaunchDiffsLabel);
            TabALEditorPanel.Controls.Add(AutoLaunchDifficulty4);
            TabALEditorPanel.Controls.Add(AutoLaunchPartsLabel);
            TabALEditorPanel.Controls.Add(TabAutoLaunchALSHeader);
            TabALEditorPanel.Controls.Add(AutoLaunchPart4);
            TabALEditorPanel.Controls.Add(AutoLaunchSongTime);
            TabALEditorPanel.Controls.Add(label1);
            TabALEditorPanel.Controls.Add(AutoLaunchHideHUD);
            TabALEditorPanel.Controls.Add(AutoLaunchBot4);
            TabALEditorPanel.Controls.Add(AutoLaunchBot1);
            TabALEditorPanel.Controls.Add(AutoLaunchDifficulty3);
            TabALEditorPanel.Controls.Add(AutoLaunchRawLoad);
            TabALEditorPanel.Controls.Add(AutoLaunchPart3);
            TabALEditorPanel.Controls.Add(AutoLaunchEncoreMode);
            TabALEditorPanel.Controls.Add(AutoLaunchP3Label);
            TabALEditorPanel.Controls.Add(AutoLaunchPlayersLabel);
            TabALEditorPanel.Controls.Add(AutoLaunchBot3);
            TabALEditorPanel.Controls.Add(AutoLaunchPlayers);
            TabALEditorPanel.Controls.Add(TabAutoLaunchASHeader);
            TabALEditorPanel.Controls.Add(TabAutoLaunchPSHeader);
            TabALEditorPanel.Controls.Add(AutoLaunchDifficulty2);
            TabALEditorPanel.Controls.Add(AutoLaunchSongLabel);
            TabALEditorPanel.Controls.Add(AutoLaunchPart2);
            TabALEditorPanel.Controls.Add(AutoLaunchSong);
            TabALEditorPanel.Controls.Add(AutoLaunchP2Label);
            TabALEditorPanel.Controls.Add(AutoLaunchVenueLabel);
            TabALEditorPanel.Controls.Add(AutoLaunchBot2);
            TabALEditorPanel.Controls.Add(AutoLaunchVenue);
            TabALEditorPanel.Controls.Add(AutoLaunchDifficulty1);
            TabALEditorPanel.Controls.Add(AutoLaunchP1Label);
            TabALEditorPanel.Controls.Add(AutoLaunchPart1);
            TabALEditorPanel.Location = new Point(17, 55);
            TabALEditorPanel.Name = "TabALEditorPanel";
            TabALEditorPanel.Size = new Size(635, 579);
            TabALEditorPanel.TabIndex = 41;
            // 
            // AutoLaunchSongSelectINI
            // 
            AutoLaunchSongSelectINI.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchSongSelectINI.Location = new Point(361, 51);
            AutoLaunchSongSelectINI.Name = "AutoLaunchSongSelectINI";
            AutoLaunchSongSelectINI.Size = new Size(28, 25);
            AutoLaunchSongSelectINI.TabIndex = 41;
            AutoLaunchSongSelectINI.Text = "...";
            AutoLaunchSongSelectINI.UseVisualStyleBackColor = true;
            // 
            // AutoLaunchDiffsLabel
            // 
            AutoLaunchDiffsLabel.AutoSize = true;
            AutoLaunchDiffsLabel.Location = new Point(350, 122);
            AutoLaunchDiffsLabel.Name = "AutoLaunchDiffsLabel";
            AutoLaunchDiffsLabel.Size = new Size(130, 22);
            AutoLaunchDiffsLabel.TabIndex = 26;
            AutoLaunchDiffsLabel.Text = "Player Difficulties";
            // 
            // AutoLaunchPartsLabel
            // 
            AutoLaunchPartsLabel.AutoSize = true;
            AutoLaunchPartsLabel.Location = new Point(153, 122);
            AutoLaunchPartsLabel.Name = "AutoLaunchPartsLabel";
            AutoLaunchPartsLabel.Size = new Size(140, 22);
            AutoLaunchPartsLabel.TabIndex = 24;
            AutoLaunchPartsLabel.Text = "Player Instruments";
            // 
            // TabAutoLaunchALSHeader
            // 
            TabAutoLaunchALSHeader.AutoSize = true;
            TabAutoLaunchALSHeader.Font = new Font("Lexend", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TabAutoLaunchALSHeader.Location = new Point(5, 19);
            TabAutoLaunchALSHeader.Name = "TabAutoLaunchALSHeader";
            TabAutoLaunchALSHeader.Size = new Size(204, 25);
            TabAutoLaunchALSHeader.TabIndex = 18;
            TabAutoLaunchALSHeader.Text = "Auto Launch Settings:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 253);
            label1.Name = "label1";
            label1.Size = new Size(70, 22);
            label1.TabIndex = 38;
            label1.Text = "Player 4:";
            // 
            // AutoLaunchHideHUD
            // 
            AutoLaunchHideHUD.AutoSize = true;
            AutoLaunchHideHUD.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchHideHUD.Location = new Point(20, 336);
            AutoLaunchHideHUD.Name = "AutoLaunchHideHUD";
            AutoLaunchHideHUD.Size = new Size(96, 26);
            AutoLaunchHideHUD.TabIndex = 6;
            AutoLaunchHideHUD.Text = "Hide HUD";
            AutoLaunchHideHUD.UseVisualStyleBackColor = true;
            AutoLaunchHideHUD.CheckedChanged += AutoLaunchHideHUD_CheckedChanged;
            // 
            // AutoLaunchBot4
            // 
            AutoLaunchBot4.AutoSize = true;
            AutoLaunchBot4.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchBot4.Location = new Point(531, 250);
            AutoLaunchBot4.Name = "AutoLaunchBot4";
            AutoLaunchBot4.Size = new Size(89, 26);
            AutoLaunchBot4.TabIndex = 37;
            AutoLaunchBot4.Text = "Use Bot?";
            AutoLaunchBot4.UseVisualStyleBackColor = true;
            AutoLaunchBot4.CheckedChanged += AutoLaunchBot4_CheckedChanged;
            // 
            // AutoLaunchBot1
            // 
            AutoLaunchBot1.AutoSize = true;
            AutoLaunchBot1.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchBot1.Location = new Point(531, 144);
            AutoLaunchBot1.Name = "AutoLaunchBot1";
            AutoLaunchBot1.Size = new Size(89, 26);
            AutoLaunchBot1.TabIndex = 9;
            AutoLaunchBot1.Text = "Use Bot?";
            AutoLaunchBot1.UseVisualStyleBackColor = true;
            AutoLaunchBot1.CheckedChanged += AutoLaunchBot1_CheckedChanged;
            // 
            // AutoLaunchRawLoad
            // 
            AutoLaunchRawLoad.AutoSize = true;
            AutoLaunchRawLoad.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchRawLoad.Location = new Point(350, 336);
            AutoLaunchRawLoad.Name = "AutoLaunchRawLoad";
            AutoLaunchRawLoad.Size = new Size(225, 26);
            AutoLaunchRawLoad.TabIndex = 10;
            AutoLaunchRawLoad.Text = "Use Raw Venue PAK Loading";
            AutoLaunchRawLoad.UseVisualStyleBackColor = true;
            AutoLaunchRawLoad.CheckedChanged += AutoLaunchRawLoad_CheckedChanged;
            // 
            // AutoLaunchP3Label
            // 
            AutoLaunchP3Label.AutoSize = true;
            AutoLaunchP3Label.Location = new Point(20, 217);
            AutoLaunchP3Label.Name = "AutoLaunchP3Label";
            AutoLaunchP3Label.Size = new Size(68, 22);
            AutoLaunchP3Label.TabIndex = 34;
            AutoLaunchP3Label.Text = "Player 3:";
            // 
            // AutoLaunchPlayersLabel
            // 
            AutoLaunchPlayersLabel.AutoSize = true;
            AutoLaunchPlayersLabel.Location = new Point(20, 51);
            AutoLaunchPlayersLabel.Name = "AutoLaunchPlayersLabel";
            AutoLaunchPlayersLabel.Size = new Size(64, 22);
            AutoLaunchPlayersLabel.TabIndex = 14;
            AutoLaunchPlayersLabel.Text = "Players:";
            // 
            // AutoLaunchBot3
            // 
            AutoLaunchBot3.AutoSize = true;
            AutoLaunchBot3.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchBot3.Location = new Point(531, 214);
            AutoLaunchBot3.Name = "AutoLaunchBot3";
            AutoLaunchBot3.Size = new Size(89, 26);
            AutoLaunchBot3.TabIndex = 33;
            AutoLaunchBot3.Text = "Use Bot?";
            AutoLaunchBot3.UseVisualStyleBackColor = true;
            AutoLaunchBot3.CheckedChanged += AutoLaunchBot3_CheckedChanged;
            // 
            // TabAutoLaunchASHeader
            // 
            TabAutoLaunchASHeader.AutoSize = true;
            TabAutoLaunchASHeader.Font = new Font("Lexend", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TabAutoLaunchASHeader.Location = new Point(5, 303);
            TabAutoLaunchASHeader.Name = "TabAutoLaunchASHeader";
            TabAutoLaunchASHeader.Size = new Size(179, 25);
            TabAutoLaunchASHeader.TabIndex = 32;
            TabAutoLaunchASHeader.Text = "Advanced Settings:";
            // 
            // TabAutoLaunchPSHeader
            // 
            TabAutoLaunchPSHeader.AutoSize = true;
            TabAutoLaunchPSHeader.Font = new Font("Lexend", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TabAutoLaunchPSHeader.Location = new Point(5, 90);
            TabAutoLaunchPSHeader.Name = "TabAutoLaunchPSHeader";
            TabAutoLaunchPSHeader.Size = new Size(147, 25);
            TabAutoLaunchPSHeader.TabIndex = 17;
            TabAutoLaunchPSHeader.Text = "Player Settings:";
            // 
            // AutoLaunchSongLabel
            // 
            AutoLaunchSongLabel.AutoSize = true;
            AutoLaunchSongLabel.Location = new Point(172, 51);
            AutoLaunchSongLabel.Name = "AutoLaunchSongLabel";
            AutoLaunchSongLabel.Size = new Size(48, 22);
            AutoLaunchSongLabel.TabIndex = 19;
            AutoLaunchSongLabel.Text = "Song:";
            // 
            // AutoLaunchP2Label
            // 
            AutoLaunchP2Label.AutoSize = true;
            AutoLaunchP2Label.Location = new Point(20, 182);
            AutoLaunchP2Label.Name = "AutoLaunchP2Label";
            AutoLaunchP2Label.Size = new Size(69, 22);
            AutoLaunchP2Label.TabIndex = 29;
            AutoLaunchP2Label.Text = "Player 2:";
            // 
            // AutoLaunchVenueLabel
            // 
            AutoLaunchVenueLabel.AutoSize = true;
            AutoLaunchVenueLabel.Location = new Point(395, 51);
            AutoLaunchVenueLabel.Name = "AutoLaunchVenueLabel";
            AutoLaunchVenueLabel.Size = new Size(54, 22);
            AutoLaunchVenueLabel.TabIndex = 21;
            AutoLaunchVenueLabel.Text = "Venue:";
            // 
            // AutoLaunchBot2
            // 
            AutoLaunchBot2.AutoSize = true;
            AutoLaunchBot2.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AutoLaunchBot2.Location = new Point(531, 179);
            AutoLaunchBot2.Name = "AutoLaunchBot2";
            AutoLaunchBot2.Size = new Size(89, 26);
            AutoLaunchBot2.TabIndex = 28;
            AutoLaunchBot2.Text = "Use Bot?";
            AutoLaunchBot2.UseVisualStyleBackColor = true;
            AutoLaunchBot2.CheckedChanged += AutoLaunchBot2_CheckedChanged;
            // 
            // AutoLaunchP1Label
            // 
            AutoLaunchP1Label.AutoSize = true;
            AutoLaunchP1Label.Location = new Point(20, 147);
            AutoLaunchP1Label.Name = "AutoLaunchP1Label";
            AutoLaunchP1Label.Size = new Size(68, 22);
            AutoLaunchP1Label.TabIndex = 23;
            AutoLaunchP1Label.Text = "Player 1:";
            // 
            // TabParentContainer
            // 
            TabParentContainer.BackColor = Color.Transparent;
            TabParentContainer.BackgroundImage = Properties.Resources.light_overlay;
            TabParentContainer.BackgroundImageLayout = ImageLayout.Stretch;
            TabParentContainer.Controls.Add(TabAutoLaunchGroup);
            TabParentContainer.Controls.Add(TabGeneralGroup);
            TabParentContainer.Location = new Point(314, 64);
            TabParentContainer.Name = "TabParentContainer";
            TabParentContainer.Size = new Size(701, 672);
            TabParentContainer.TabIndex = 16;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImage = Properties.Resources.bg_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1008, 729);
            Controls.Add(CheckForUpdates);
            Controls.Add(OpenMods);
            Controls.Add(AdjustSettings);
            Controls.Add(VersionInfoLabel);
            Controls.Add(LogoFretworks);
            Controls.Add(RunWTDE);
            Controls.Add(LogoWTDE);
            Controls.Add(LeftDarkOverlay);
            Controls.Add(TabButtonGroup);
            Controls.Add(TabParentContainer);
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
            ((System.ComponentModel.ISupportInitialize)MOTDDarkOverlay).EndInit();
            TabGeneralGroup.ResumeLayout(false);
            TabGeneralGroup.PerformLayout();
            TabAutoLaunchGroup.ResumeLayout(false);
            TabAutoLaunchGroup.PerformLayout();
            TabALEditorPanel.ResumeLayout(false);
            TabALEditorPanel.PerformLayout();
            TabParentContainer.ResumeLayout(false);
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
        private ComboBox DefaultQPODifficulty;
        private Label DefaultQPODifficultyLabel;
        private Label TabGeneralLOHeader;
        private CheckBox AutoCheckForUpdates;
        private Label TabGeneralBSHeader;
        private Button TabButtonDebug;
        private Button TabButtonAutoLaunch;
        private Button TabButtonBand;
        private Button TabButtonGraphics;
        private Button TabButtonInput;
        private GroupBox TabAutoLaunchGroup;
        private Label TabAutoLaunchALSHeader;
        private Label TabAutoLaunchPSHeader;
        private ComboBox AutoLaunchPlayers;
        private Label AutoLaunchPlayersLabel;
        private CheckBox AutoLaunchEncoreMode;
        private CheckBox AutoLaunchRawLoad;
        private CheckBox AutoLaunchBot1;
        private CheckBox AutoLaunchHideHUD;
        private CheckBox AutoLaunchSongTime;
        private CheckBox EnableAutoLaunch;
        private Label AutoLaunchSongLabel;
        private TextBox AutoLaunchSong;
        private ComboBox AutoLaunchVenue;
        private Label AutoLaunchVenueLabel;
        private ComboBox AutoLaunchDifficulty1;
        private Label AutoLaunchDiffsLabel;
        private ComboBox AutoLaunchPart1;
        private Label AutoLaunchPartsLabel;
        private Label AutoLaunchP1Label;
        private Label TabAutoLaunchASHeader;
        private ComboBox AutoLaunchDifficulty2;
        private ComboBox AutoLaunchPart2;
        private Label AutoLaunchP2Label;
        private CheckBox AutoLaunchBot2;
        private ComboBox AutoLaunchDifficulty4;
        private ComboBox AutoLaunchPart4;
        private Label label1;
        private CheckBox AutoLaunchBot4;
        private ComboBox AutoLaunchDifficulty3;
        private ComboBox AutoLaunchPart3;
        private Label AutoLaunchP3Label;
        private CheckBox AutoLaunchBot3;
        private Panel TabParentContainer;
        private Panel TabALEditorPanel;
        private Button AutoLaunchSongSelectINI;
    }
}