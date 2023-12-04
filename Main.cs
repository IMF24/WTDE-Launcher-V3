/* -----------------------------------------------------------------------------------------------
     __    __  _____  ___  __        __    _             __  ___         __  __            _____ 
    / / /\ \ \/__   \/   \/__\      / /   /_\  /\ /\  /\ \ \/ __\ /\  /\/__\/__\    /\   /\___ / 
    \ \/  \/ /  / /\/ /\ /_\       / /   //_\\/ / \ \/  \/ / /   / /_/ /_\ / \//    \ \ / / |_ \ 
     \  /\  /  / / / /_///__      / /___/  _  \ \_/ / /\  / /___/ __  //__/ _  \     \ V / ___) |
      \/  \/   \/ /___,'\__/      \____/\_/ \_/\___/\_\ \/\____/\/ /_/\__/\/ \_/      \_/ |____/ 
                                                                                             
    GHWT: Definitive Edition Launcher Version 3 - By IMF24
     - - - - - - - - - - - - - - - - - - - - - - - - - -

    The 3rd generation launcher program for Guitar Hero World Tour: Definitive Edition, but now
    expanded even further and made as pretty as Uzis' original launcher!

    This time, this isn't a Python program, it's now written in C#! That's right, we've moved
    away from Python, and we're moving the launcher BACK to the C# language, built on the .NET
    framework. All the functionality of the V2 launcher will be re-imported into here, and it
    will also be visually polished to make it look the best it possibly can!
    
----------------------------------------------------------------------------------------------- */
// Various required imports.
using System.Diagnostics;
using MadMilkman.Ini;

// Main namespace for the program is WTDE_Launcher_V3.
namespace WTDE_Launcher_V3
{
    /// <summary>
    ///  Main class for the V3 launcher.
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        ///  The current background index.
        /// </summary>
        public int BGIndex = 0;

        /// <summary>
        ///  Is the settings tab bar active? OFF by default, we'll show the
        ///  MOTD first, then the user can trigger the settings pane.
        /// </summary>
        public bool TabBarActive = false;

        /// <summary>
        ///  Makes flickering less obvious. (thanks Uzis)
        /// </summary>
        protected override CreateParams CreateParams
        {
            // Double buffer to prevent flickering.
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        }

        public void WriteDefaultINI()
        {
            if (!File.Exists(V3LauncherConstants.WTDEConfigDir))
            {
                using (StreamWriter sw = new StreamWriter(V3LauncherConstants.WTDEConfigDir, true))
                {
                    string[] defaultConfigLines = INIFunctions.DefaultINIContents.Split("\n");
                    foreach (string line in defaultConfigLines)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
        }

        /// <summary>
        ///  Load all configuration data from GHWTDE.ini.
        /// </summary>
        public void LoadINISettings()
        {
            // ---------------------------
            // General Tab
            // ---------------------------
            RichPresence.Checked = Convert.ToBoolean(INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "RichPresence")));
            AllowHolidays.Checked = Convert.ToBoolean(INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "AllowHolidays")));
            MuteStreams.Checked = Convert.ToBoolean(INIFunctions.GetBoolean(INIFunctions.GetINIValue("Audio", "MuteStreams")));
            WhammyPitchShift.Checked = Convert.ToBoolean(INIFunctions.GetBoolean(INIFunctions.GetINIValue("Audio", "WhammyPitchShift")));
            StatusHandler.Checked = Convert.ToBoolean(INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "StatusHandler")));
            DefaultQPODifficulty.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Config", "DefaultQPODifficulty", "expert"), INIFunctions.QPODifficulties, INIFunctions.QPODifficultiesNames);

            // -- MAIN MENU TOGGLES ---------------------------
            UseCareerOption.Checked = Convert.ToBoolean(INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseCareerOption")));
            UseQuickplayOption.Checked = Convert.ToBoolean(INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseQuickplayOption")));
            UseHeadToHeadOption.Checked = Convert.ToBoolean(INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseHeadToHeadOption")));
            UseOnlineOption.Checked = Convert.ToBoolean(INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseOnlineOption")));
            UseMusicStudioOption.Checked = Convert.ToBoolean(INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseMusicStudioOption")));
            UseCAROption.Checked = Convert.ToBoolean(INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseCAROption")));
            UseOptionsOption.Checked = Convert.ToBoolean(INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseOptionsOption")));
            UseQuitOption.Checked = Convert.ToBoolean(INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseQuitOption")));

            // -- LAUNCHER OPTIONS ---------------------------
            AutoCheckForUpdates.Checked = Convert.ToBoolean(INIFunctions.GetBoolean(INIFunctions.GetINIValue("Launcher", "CheckForUpdates", "1")));
        }

        /// <summary>
        ///  Save all configured data into GHWTDE.ini.
        /// </summary>
        public void SaveINISettings()
        {
            // Set up IniFile. Pretty self-explanatory.
            IniFile file = new IniFile();
            file.Load(V3LauncherConstants.WTDEConfigDir);

            // ---------------------------
            // General Tab
            // ---------------------------
            file.Sections["Config"].Keys["RichPresence"].Value = (RichPresence.Checked.ToString() == "True") ? "1" : "0";
            file.Sections["Config"].Keys["AllowHolidays"].Value = (AllowHolidays.Checked.ToString() == "True") ? "1" : "0";
            file.Sections["Audio"].Keys["MuteStreams"].Value = (MuteStreams.Checked.ToString() == "True") ? "1" : "0";
            file.Sections["Audio"].Keys["WhammyPitchShift"].Value = (WhammyPitchShift.Checked.ToString() == "True") ? "1" : "0";
            file.Sections["Config"].Keys["DefaultQPODifficulty"].Value = INIFunctions.InterpretINISetting(DefaultQPODifficulty.Text, INIFunctions.QPODifficultiesNames, INIFunctions.QPODifficulties);

            // -- MAIN MENU TOGGLES ---------------------------
            file.Sections["Config"].Keys["UseCareerOption"].Value = (UseCareerOption.Checked.ToString() == "True") ? "1" : "0";
            file.Sections["Config"].Keys["UseQuickplayOption"].Value = (UseQuickplayOption.Checked.ToString() == "True") ? "1" : "0";
            file.Sections["Config"].Keys["UseHeadToHeadOption"].Value = (UseHeadToHeadOption.Checked.ToString() == "True") ? "1" : "0";
            file.Sections["Config"].Keys["UseOnlineOption"].Value = (UseOnlineOption.Checked.ToString() == "True") ? "1" : "0";
            file.Sections["Config"].Keys["UseMusicStudioOption"].Value = (UseMusicStudioOption.Checked.ToString() == "True") ? "1" : "0";
            file.Sections["Config"].Keys["UseCAROption"].Value = (UseCAROption.Checked.ToString() == "True") ? "1" : "0";
            file.Sections["Config"].Keys["UseOptionsOption"].Value = (UseOptionsOption.Checked.ToString() == "True") ? "1" : "0";
            file.Sections["Config"].Keys["UseQuitOption"].Value = (UseQuitOption.Checked.ToString() == "True") ? "1" : "0";

            // Save the config settings to GHWTDE.ini.
            file.Save(V3LauncherConstants.WTDEConfigDir);
        }

        /// <summary>
        ///  When moving out of Adjust Settings, hide all settings tabs and panes.
        /// </summary>
        public void HideAllTabs()
        {
            // No text on group boxes. That's just debug stuff.
            TabGeneralGroup.Text = "";

            TabAutoLaunchGroup.Text = "";

            // Hide all group boxes, move them to their correct positions.
            TabGeneralGroup.Hide();
            TabAutoLaunchGroup.Hide();
        }

        /// <summary>
        ///  Move all tab groups to their correct locations. This should hopefully DPI scale.
        /// </summary>
        public void MoveAllTabGroups()
        {
            // Move all tab groups to their correct locations.
            // (X, Y): (327, 75)
            int PosX = 327;
            int PosY = 75;

            TabGeneralGroup.Location = new Point(PosX, PosY);
            TabAutoLaunchGroup.Location = new Point(PosX, PosY);
        }

        /// <summary>
        ///  Opens a specific website. This handles all the complicated stuff to do this.
        /// </summary>
        /// <param name="site"></param>
        public static void OpenSiteURL(string site)
        {
            var url = site;
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = url;
            System.Diagnostics.Process.Start(psi);
        }

        /// <summary>
        ///  Main entry point of the V3 launcher Form.
        /// </summary>
        public Main()
        {
            // Initialize Windows Form. We need this. DON'T EDIT OR DELETE IT!
            InitializeComponent();

            // Update window title with random splash and actual version number.
            // The object `random` is used for the random splash picker.
            Random random = new Random();
            string[] requiredSplashList = { };

            // Pull latest version from website.
            VersionInfoLabel.Text = $"GHWT: DE Launcher V{V3LauncherConstants.VERSION} by IMF24\nBG Image: Fox (FoxJudy)\nWTDE Latest Version: {V3LauncherCore.GetLatestVersion()}";

            // What month is it? This determines both what splash bank to pull
            // from, and also how the background needs to be stylized.
            switch (DateTime.Now.Month)
            {
                // Valentine's Day stuff (for sake of testing)
                case 2:
                    this.BackgroundImage = Properties.Resources.bg_13_d;
                    break;

                // Halloween holiday stuff
                case 10:
                    requiredSplashList = V3LauncherConstants.RandomWindowTitlesHW;
                    LogoWTDE.Image = Properties.Resources.wtde_logo_hw;
                    this.BackgroundImage = Properties.Resources.bg_1_hw;
                    BGConstants.V3LauncherBackgrounds[0] = Properties.Resources.bg_1_hw;
                    break;

                // Christmas holiday stuff
                case 12:
                    if (DateTime.Now.Day >= 1 && DateTime.Now.Day <= 25)
                    {
                        requiredSplashList = V3LauncherConstants.RandomWindowTitlesXM;
                        LogoWTDE.Image = Properties.Resources.wtde_logo_xmas;
                        this.BackgroundImage = Properties.Resources.bg_1_xm;
                        BGConstants.V3LauncherBackgrounds[0] = Properties.Resources.bg_1_xm;
                    }
                    break;

                // Normal title splashes, nothing different
                default:
                    requiredSplashList = V3LauncherConstants.RandomWindowTitles;
                    break;
            }
            // Now pick a random one, and update the window title!
            int splashID = random.Next(0, requiredSplashList.Length);
            this.Text = $"GHWT: Definitive Edition Launcher - V{V3LauncherConstants.VERSION} - {requiredSplashList[splashID]}";

            // Main editing area is located at (391, -4).
            // That's where we need to move the MOTD container to.
            //~ MOTDPanel.Location = new Point(391, -4);

            // Make MOTD visible, hide editing area (for now).
            WhiteOverlay.Enabled = TabBarActive;
            TabButtonGroup.Enabled = TabBarActive;
            WhiteOverlay.Visible = TabBarActive;
            TabButtonGroup.Visible = TabBarActive;

            MOTDDarkOverlay.Visible = !TabBarActive;
            MOTDLabel.Text = TabHandler.GetMOTDText();

            // Hide all tabs, move the group boxes, and load our INI settings.
            HideAllTabs();
            MoveAllTabGroups();
            WriteDefaultINI();
            LoadINISettings();

            // Debug.WriteLine($"AspyrConfig read test: {XMLFunctions.AspyrGetString("Audio.BuffLen")}");



            // Just for the sake of debugging, we'll change our working directory to where
            // GHWT is installed. This path is defined in the `wtde_path.txt` file.
            // DEBUG: Read `wtde_path.txt` and change working directory there.
            Directory.SetCurrentDirectory(File.ReadAllText("../../../wtde_path.txt"));
        }

        /// <summary>
        ///  When this button is clicked, start GHWT: DE.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunWTDE_Click(object sender, EventArgs e)
        {
            if (File.Exists("GHWT_Definitive.exe"))
            {
                System.Diagnostics.Process.Start("GHWT_Definitive.exe");
            }
        }

        /// <summary>
        ///  When the version label is clicked, change the background. This is pulled from the BGConstants class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VersionInfoLabel_Click(object sender, EventArgs e)
        {
            // Which mouse button did we push?
            MouseEventArgs me = (MouseEventArgs)e;

            // Left triggers the background to swap.
            if (me.Button == MouseButtons.Left)
            {
                // Are we at the end of the BG cycle?
                if (BGIndex + 1 == BGConstants.V3LauncherBackgrounds.Length) BGIndex = 0;
                else BGIndex++;

                // Update the background image.
                this.BackgroundImage = BGConstants.V3LauncherBackgrounds[BGIndex];

                // Update the version info.
                VersionInfoLabel.Text = $"GHWT: DE Launcher V{V3LauncherConstants.VERSION} by IMF24\nBG Image: {BGConstants.V3LauncherBGAuthors[BGIndex]}\nWTDE Latest Version: {V3LauncherCore.GetLatestVersion()}";

                // And right opens the social link for that person.
            }
            else if (me.Button == MouseButtons.Right)
            {
                OpenSiteURL(BGConstants.V3LauncherSocials[BGIndex]);
            }
        }

        /// <summary>
        ///  When clicked, enable the user's ability to edit their config file(s) settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdjustSettings_Click(object sender, EventArgs e)
        {
            // Invert the status of TabBarActive.
            TabBarActive = !TabBarActive;

            WhiteOverlay.Enabled = TabBarActive;
            WhiteOverlay.Visible = TabBarActive;

            if (TabBarActive == false)
            {
                HideAllTabs();
                // SaveINISettings();
            }

            TabButtonGroup.Enabled = TabBarActive;
            TabButtonGroup.Visible = TabBarActive;

            MOTDDarkOverlay.Visible = !TabBarActive;

        }

        /// <summary>
        ///  Open the user's mods folder for GHWT: DE in DATA\MODS.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMods_Click(object sender, EventArgs e)
        {
            //~ Debug.WriteLine($"cwd: {Directory.GetCurrentDirectory()}");
            System.Diagnostics.Process.Start("explorer.exe", "DATA\\MODS");
        }

        /// <summary>
        ///  When the user clicks this, run the update checker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckForUpdates_Click(object sender, EventArgs e)
        {
            V3LauncherCore.CheckForUpdates();
        }

        private void TabButtonGeneral_Click(object sender, EventArgs e)
        {
            TabGeneralGroup.Show();

            TabAutoLaunchGroup.Hide();
        }

        // ------------------------------------------------------
        // GENERAL SETTINGS AUTO UPDATE
        // ------------------------------------------------------
        #region General Settings Auto Update

        private void RichPresence_CheckedChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Config", "RichPresence", INIFunctions.BoolToString(RichPresence.Checked));
        }

        private void AllowHolidays_CheckedChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Config", "AllowHolidays", INIFunctions.BoolToString(AllowHolidays.Checked));
        }

        private void MuteStreams_CheckedChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Audio", "MuteStreams", INIFunctions.BoolToString(MuteStreams.Checked));
        }

        private void WhammyPitchShift_CheckedChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Audio", "WhammyPitchShift", INIFunctions.BoolToString(WhammyPitchShift.Checked));
        }

        private void StatusHandler_CheckedChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Config", "StatusHandler", INIFunctions.BoolToString(StatusHandler.Checked));
        }

        private void DefaultQPODifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Config", "DefaultQPODifficulty", INIFunctions.InterpretINISetting(DefaultQPODifficulty.Text, INIFunctions.QPODifficultiesNames, INIFunctions.QPODifficulties));
        }

        private void UseCareerOption_CheckedChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Config", "UseCareerOption", INIFunctions.BoolToString(UseCareerOption.Checked));
        }

        private void UseQuickplayOption_CheckedChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Config", "UseQuickplayOption", INIFunctions.BoolToString(UseQuickplayOption.Checked));
        }

        private void UseHeadToHeadOption_CheckedChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Config", "UseHeadToHeadOption", INIFunctions.BoolToString(UseHeadToHeadOption.Checked));
        }

        private void UseOnlineOption_CheckedChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Config", "UseOnlineOption", INIFunctions.BoolToString(UseOnlineOption.Checked));
        }

        private void UseMusicStudioOption_CheckedChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Config", "UseMusicStudioOption", INIFunctions.BoolToString(UseMusicStudioOption.Checked));
        }

        private void UseCAROption_CheckedChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Config", "UseCAROption", INIFunctions.BoolToString(UseCAROption.Checked));
        }

        private void UseOptionsOption_CheckedChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Config", "UseOptionsOption", INIFunctions.BoolToString(UseOptionsOption.Checked));
        }

        private void UseQuitOption_CheckedChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Config", "UseQuitOption", INIFunctions.BoolToString(UseQuitOption.Checked));
        }

        private void AutoCheckForUpdates_CheckedChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Launcher", "CheckForUpdates", INIFunctions.BoolToString(AutoCheckForUpdates.Checked));
        }

        #endregion

        private void TabButtonAutoLaunch_Click(object sender, EventArgs e)
        {
            TabGeneralGroup.Hide();

            TabAutoLaunchGroup.Show();
        }
    }
}