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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MadMilkman.Ini;

namespace WTDE_Launcher_V3 {
    /// <summary>
    ///  Main entry class for the V3 launcher. The Form's name is Main.
    /// </summary>
    public partial class Main : Form {
        /// <summary>
        ///  Main entry point for the V3 launcher.
        /// </summary>
        public Main() {
            // Initialize Windows Forms. We need this. DO NOT EDIT OR DELETE IT!
            InitializeComponent();

            // Set our background image correctly and get the MOTD from the website.
            this.BackgroundImage = Properties.Resources.bg_1;
            MOTDText.Text = V3LauncherCore.GetMOTDText();
            UpdateActiveTab((int) LauncherTabs.MOTD);

            // Set up tabs, load INI and XML file settings, set the window title, and the background.
            DoTabSetup();
            LoadINISettings();
            V3LauncherCore.SetWindowTitle(this);
            BGConstants.AutoDateBackground(this, VersionInfoLabel, WTDELogo);

            Console.WriteLine(V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "KICK"));

            // Should we automatically update when the program starts?
            V3LauncherCore.AutoCheckForUpdates();
        }
        
        /// <summary>
        ///  Load all config data from GHWTDE.ini and AspyrConfig.xml.
        /// </summary>
        public void LoadINISettings() {
            IniFile file = new IniFile();
            file.Load(V3LauncherConstants.WTDEConfigDir);

            // ---------------------------------
            // GENERAL TAB
            // ---------------------------------
            RichPresence.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "RichPresence"));
            AllowHolidays.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "AllowHolidays"));
            MuteStreams.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Audio", "MuteStreams"));
            WhammyPitchShift.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Audio", "WhammyPitchShift"));
            DefaultQPODifficulty.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Config", "DefaultQPODifficulty"),
                new string[] { "easy_rhythm", "easy", "normal", "hard", "expert" },
                new string[] { "Beginner", "Easy", "Medium", "Hard", "Expert" });
            AudioBuffLen.Text = XMLFunctions.AspyrGetString("Audio.BuffLen", "4096");

            CheckForUpdates.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Launcher", "CheckForUpdates", "1"));

            // -- MAIN MENU TOGGLES --------
            UseCareerOption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseCareerOption"));
            UseQuickplayOption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseQuickplayOption"));
            UseHeadToHeadOption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseHeadToHeadOption"));
            UseOnlineOption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseOnlineOption"));
            UseMusicStudioOption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseMusicStudioOption"));
            UseCAROption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseCAROption"));
            UseOptionsOption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseOptionsOption"));
            UseQuitOption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseQuitOption"));

            // ---------------------------------
            // BAND TAB
            // ---------------------------------
            PreferredGuitarist.Text = INIFunctions.GetINIValue("Band", "PreferredGuitarist");
            PreferredBassist.Text = INIFunctions.GetINIValue("Band", "PreferredBassist");
            PreferredDrummer.Text = INIFunctions.GetINIValue("Band", "PreferredDrummer");
            PreferredSinger.Text = INIFunctions.GetINIValue("Band", "PreferredSinger");
            PreferredStage.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Band", "PreferredStage"),
                V3LauncherConstants.VenueIDs[1], V3LauncherConstants.VenueIDs[0]);

            PreferredGuitaristHighway.Text = INIFunctions.GetINIValue("Band", "PreferredGuitaristHighway");
            PreferredBassistHighway.Text = INIFunctions.GetINIValue("Band", "PreferredBassistHighway");
            PreferredDrummerHighway.Text = INIFunctions.GetINIValue("Band", "PreferredDrummerHighway");

            GuitarStrumAnim.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Band", "GuitarStrumAnim"),
                new string[] { "none", "ghm" },
                new string[] { "GH: World Tour (Default)", "Guitar Hero: Metallica" });
            BassStrumAnim.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Band", "BassStrumAnim"),
                new string[] { "none", "ghm" },
                new string[] { "GH: World Tour (Default)", "Guitar Hero: Metallica" });

            // ---------------------------------
            // AUTO LAUNCH TAB
            // ---------------------------------
            AutoLaunchEnabled.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "Enabled", "0"));
            TabALMainEditor.Enabled = AutoLaunchEnabled.Checked;

            AutoLaunchPlayers.Text = INIFunctions.GetINIValue("AutoLaunch", "Players", "1");
            AutoLaunchSong.Text = INIFunctions.GetINIValue("AutoLaunch", "Song", "random");
            AutoLaunchVenue.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Venue"),
                V3LauncherConstants.VenueIDs[1], V3LauncherConstants.VenueIDs[0]);

            AutoLaunchPart1.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Part", "guitar"),
                new string[] { "guitar", "bass", "drum", "vocals" },
                new string[] { "Lead Guitar - PART GUITAR", "Bass Guitar - PART BASS", "Drums - PART DRUMS", "Vocals - PART VOCALS" });
            AutoLaunchPart2.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Part2", "bass"),
                new string[] { "guitar", "bass", "drum", "vocals" },
                new string[] { "Lead Guitar - PART GUITAR", "Bass Guitar - PART BASS", "Drums - PART DRUMS", "Vocals - PART VOCALS" });
            AutoLaunchPart3.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Part3", "drum"),
                new string[] { "guitar", "bass", "drum", "vocals" },
                new string[] { "Lead Guitar - PART GUITAR", "Bass Guitar - PART BASS", "Drums - PART DRUMS", "Vocals - PART VOCALS" });
            AutoLaunchPart4.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Part4", "vocals"),
                new string[] { "guitar", "bass", "drum", "vocals" },
                new string[] { "Lead Guitar - PART GUITAR", "Bass Guitar - PART BASS", "Drums - PART DRUMS", "Vocals - PART VOCALS" });

            AutoLaunchDifficulty1.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Difficulty", "easy"),
                new string[] { "beginner", "easy", "medium", "hard", "expert" },
                new string[] { "Beginner", "Easy", "Medium", "Hard", "Expert" });
            AutoLaunchDifficulty2.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Difficulty2", "easy"),
                new string[] { "beginner", "easy", "medium", "hard", "expert" },
                new string[] { "Beginner", "Easy", "Medium", "Hard", "Expert" });
            AutoLaunchDifficulty3.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Difficulty3", "easy"),
                new string[] { "beginner", "easy", "medium", "hard", "expert" },
                new string[] { "Beginner", "Easy", "Medium", "Hard", "Expert" });
            AutoLaunchDifficulty4.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Difficulty4", "easy"),
                new string[] { "beginner", "easy", "medium", "hard", "expert" },
                new string[] { "Beginner", "Easy", "Medium", "Hard", "Expert" });

            AutoLaunchBot1.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "Bot", "1"));
            AutoLaunchBot2.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "Bot2", "1"));
            AutoLaunchBot3.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "Bot3", "1"));
            AutoLaunchBot4.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "Bot4", "1"));

            AutoLaunchHideHUD.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "HideHUD"));
            AutoLaunchSongTime.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "SongTime"));
            AutoLaunchRawLoad.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "RawLoad"));
            AutoLaunchEncoreMode.Checked = INIFunctions.GetBooleanCustomString(INIFunctions.GetINIValue("AutoLaunch", "EncoreMode"), "last_song");
        }

        /// <summary>
        ///  What is the currently active tab?
        /// </summary>
        public int ActiveTab = 0;

        // Add in double buffering.
        protected override CreateParams CreateParams {
            // Double buffer to prevent flickering.
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        }

        /// <summary>
        ///  List of the launcher's different tabs.
        /// </summary>
        public enum LauncherTabs {
            /// <summary>
            ///  Message of the day tab. This isn't really a tab, but it displays the MOTD.
            /// </summary>
            MOTD = 0,
            /// <summary>
            ///  General settings tab.
            /// </summary>
            General = 1,
            /// <summary>
            ///  Input and controls tab.
            /// </summary>
            Input = 2,
            /// <summary>
            ///  Graphics settings tab.
            /// </summary>
            Graphics = 3,
            /// <summary>
            ///  Band lineup settings tab.
            /// </summary>
            Band = 4,
            /// <summary>
            ///  Auto launch settings tab.
            /// </summary>
            AutoLaunch = 5,
            /// <summary>
            ///  Debug settings tab.
            /// </summary>
            Debug = 6,
            /// <summary>
            ///  Credits page. This isn't a tab, but it shows the credits information.
            /// </summary>
            Credits = 7,
            /// <summary>
            ///  This "tab" is shown BEFORE any tabs get selected.
            /// </summary>
            PreTab = 8
        }

        /// <summary>
        ///  Update the currently selected tab to a different one.
        /// </summary>
        /// <param name="tab"></param>
        public void UpdateActiveTab(int tab) {
            ActiveTab = tab;
            switch (tab) {
                // -- MOTD LABEL TAB SWITCH ---------------------------------
                case 0:
                    MOTDText.Visible = true;
                    MOTDBack.Visible = true;

                    TabParentContainer.Visible = false;
                    TabParentContainer.Enabled = false;
                    
                    TabButtonGroup.Visible = false;
                    TabButtonGroup.Enabled = false;

                    // ------------------------------------

                    TabGeneralGroup.Visible = false;
                    TabGeneralGroup.Enabled = false;

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;
                    break;

                // -- GENERAL TAB SWITCH ---------------------------------
                case 1:
                    MOTDText.Visible = false;
                    MOTDBack.Visible = false;

                    TabParentContainer.Visible = true;
                    TabParentContainer.Enabled = true;

                    TabButtonGroup.Visible = true;
                    TabButtonGroup.Enabled = true;

                    // ------------------------------------

                    TabGeneralGroup.Visible = true;
                    TabGeneralGroup.Enabled = true;

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;
                    break;

                // -- BAND TAB SWITCH ---------------------------------
                case 4:
                    MOTDText.Visible = false;
                    MOTDBack.Visible = false;

                    TabParentContainer.Visible = true;
                    TabParentContainer.Enabled = true;

                    TabButtonGroup.Visible = true;
                    TabButtonGroup.Enabled = true;

                    // ------------------------------------

                    TabGeneralGroup.Visible = false;
                    TabGeneralGroup.Enabled = false;

                    TabBandGroup.Visible = true;
                    TabBandGroup.Enabled = true;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;
                    break;

                // -- AUTO LAUNCH TAB SWITCH ---------------------------------
                case 5:
                    MOTDText.Visible = false;
                    MOTDBack.Visible = false;

                    TabParentContainer.Visible = true;
                    TabParentContainer.Enabled = true;

                    TabButtonGroup.Visible = true;
                    TabButtonGroup.Enabled = true;

                    // ------------------------------------

                    TabGeneralGroup.Visible = false;
                    TabGeneralGroup.Enabled = false;

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = true;
                    TabAutoLaunchGroup.Enabled = true;
                    break;

                // -- PRE-TAB TAB SWITCH ---------------------------------
                case 8:
                    MOTDText.Visible = false;
                    MOTDBack.Visible = false;

                    TabParentContainer.Visible = true;
                    TabParentContainer.Enabled = true;

                    TabButtonGroup.Visible = true;
                    TabButtonGroup.Enabled = true;

                    // ------------------------------------

                    TabGeneralGroup.Visible = false;
                    TabGeneralGroup.Enabled = false;

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;
                    break;
            }
        }

        /// <summary>
        ///  Actions to be carried out when the program closes.
        /// </summary>
        public void ExitActions() {
            V3LauncherCore.AddDebugEntry("We're done in the launcher for now!\nThanks for using it! :D", "Form Closing");
            V3LauncherCore.WriteDebugLog();
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e) {
            ExitActions();
        }

        /// <summary>
        ///  Moves all tabs to the correct location and other various tab setup functionality.
        /// </summary>
        public void DoTabSetup() {
            // Hide title text on the group boxes.
            TabGeneralGroup.Text = "";
            TabBandGroup.Text = "";
            TabAutoLaunchGroup.Text = "";

            // Parent all tabs to the parent container.
            TabGeneralGroup.Parent = TabParentContainer;

            // Move all of the tabs to their correct locations.
            Point location = new Point(12, 8);
            TabGeneralGroup.Location = location;
            TabBandGroup.Location = location;
            TabAutoLaunchGroup.Location = location;
        }

        // ----------------------------------------------------------
        // LEFT SIDE BUTTONS & CONTROLS
        // ----------------------------------------------------------
        #region Left Side Buttons & Controls

        private void WTDELogo_Click(object sender, EventArgs e) {
            string creditsBriefInfo = "GHWT: Definitive Edition by Fretworks, EST. 2021\n" +
                                     $"GHWT: Definitive Edition Launcher V{V3LauncherConstants.VERSION} by IMF24\n\n" +
                                      "Do you want to open the credits on the website?";
            if (MessageBox.Show(creditsBriefInfo, "Open Credits", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                V3LauncherCore.OpenSiteURL("https://ghwt.de");
            }
        }

        private void AdjustSettingsButton_Click(object sender, EventArgs e) {
            if (ActiveTab == 0) UpdateActiveTab((int)LauncherTabs.PreTab);
            else UpdateActiveTab((int)LauncherTabs.MOTD);
        }

        private void CheckUpdatesButton_Click(object sender, EventArgs e) {
            V3LauncherCore.CheckForUpdates();
        }

        private void VersionInfoLabel_Click(object sender, EventArgs e) {
            // Which mouse button did we push?
            MouseEventArgs me = (MouseEventArgs) e;

            // Left triggers the background to swap.
            if (me.Button == MouseButtons.Left) {
                // Are we at the end of the BG cycle?
                if (BGConstants.BGIndex + 1 == BGConstants.V3LauncherBackgrounds.Length) BGConstants.BGIndex = 0;
                else BGConstants.BGIndex++;

                // Update the background image.
                this.BackgroundImage = BGConstants.V3LauncherBackgrounds[BGConstants.BGIndex];

                // Update the version info.
                VersionInfoLabel.Text = $"GHWT: DE Launcher V{V3LauncherConstants.VERSION} by IMF24\nBG Image: {BGConstants.V3LauncherBGAuthors[BGConstants.BGIndex]}\nWTDE Latest Version: {V3LauncherCore.GetLatestVersion()}";

                // And right opens the social link for that person.
            } else if (me.Button == MouseButtons.Right) {
                V3LauncherCore.OpenSiteURL(BGConstants.V3LauncherSocials[BGConstants.BGIndex]);
            }
        }
        #endregion

        // ----------------------------------------------------------
        // TAB BUTTONS
        // ----------------------------------------------------------
        #region Tab Buttons
        private void TabButtonGeneral_Click(object sender, EventArgs e) {
            UpdateActiveTab((int)LauncherTabs.General);
        }

        private void TabButtonInput_Click(object sender, EventArgs e) {
            UpdateActiveTab((int)LauncherTabs.Input);
        }

        private void TabButtonGraphics_Click(object sender, EventArgs e) {
            UpdateActiveTab((int)LauncherTabs.Graphics);
        }

        private void TabButtonBand_Click(object sender, EventArgs e) {
            UpdateActiveTab((int)LauncherTabs.Band);
        }

        private void TabButtonAutoLaunch_Click(object sender, EventArgs e) {
            UpdateActiveTab((int)LauncherTabs.AutoLaunch);
        }

        private void TabButtonDebug_Click(object sender, EventArgs e) {
            UpdateActiveTab((int)LauncherTabs.Debug);
        }
        #endregion

        // ----------------------------------------------------------
        // GENERAL TAB AUTO UPDATE
        // ----------------------------------------------------------
        #region General Tab Auto Update
        private void RichPresence_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "RichPresence", INIFunctions.BoolToString(RichPresence.Checked));
        }

        private void AllowHolidays_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "AllowHolidays", INIFunctions.BoolToString(AllowHolidays.Checked));
        }

        private void MuteStreams_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Audio", "MuteStreams", INIFunctions.BoolToString(MuteStreams.Checked));
        }

        private void WhammyPitchShift_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Audio", "WhammyPitchShift", INIFunctions.BoolToString(WhammyPitchShift.Checked));
        }

        private void DefaultQPODifficulty_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "DefaultQPODifficulty", INIFunctions.InterpretINISetting(DefaultQPODifficulty.Text,
                new string[] { "Beginner", "Easy", "Medium", "Hard", "Expert" },
                new string[] { "easy_rhythm", "easy", "normal", "hard", "expert" }));
        }

        private void AudioBuffLen_SelectedIndexChanged(object sender, EventArgs e) {
            XMLFunctions.AspyrWriteString("Audio.BuffLen", AudioBuffLen.Text);
        }

        private void CheckForUpdates_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Launcher", "CheckForUpdates", INIFunctions.BoolToString(CheckForUpdates.Checked));
        }

        // -- MAIN MENU TOGGLES -----------------------------

        private void UseCareerOption_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "UseCareerOption", INIFunctions.BoolToString(UseCareerOption.Checked));
        }

        private void UseQuickplayOption_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "UseQuickplayOption", INIFunctions.BoolToString(UseQuickplayOption.Checked));
        }

        private void UseHeadToHeadOption_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "UseHeadToHeadOption", INIFunctions.BoolToString(UseHeadToHeadOption.Checked));
        }

        private void UseOnlineOption_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "UseOnlineOption", INIFunctions.BoolToString(UseOnlineOption.Checked));
        }

        private void UseMusicStudioOption_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "UseMusicStudioOption", INIFunctions.BoolToString(UseMusicStudioOption.Checked));
        }

        private void UseCAROption_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "UseCAROption", INIFunctions.BoolToString(UseCAROption.Checked));
        }

        private void UseOptionsOption_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "UseOptionsOption", INIFunctions.BoolToString(UseOptionsOption.Checked));
        }

        private void UseQuitOption_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "UseQuitOption", INIFunctions.BoolToString(UseQuitOption.Checked));
        }

        #endregion

        // ----------------------------------------------------------
        // BAND TAB AUTO UPDATE
        // ----------------------------------------------------------
        #region Band Tab Auto Update
        private void PreferredGuitarist_TextChanged(object sender, EventArgs e) {
            try {
                INIFunctions.SaveINIValue("Band", "PreferredGuitarist", PreferredGuitarist.Text);
            } catch (Exception exc) {
                V3LauncherCore.AddDebugEntry(exc.ToString(), "Internal Error");
            }
        }

        private void PreferredBassist_TextChanged(object sender, EventArgs e) {
            try {
                INIFunctions.SaveINIValue("Band", "PreferredBassist", PreferredBassist.Text);
            } catch (Exception exc) {
                V3LauncherCore.AddDebugEntry(exc.ToString(), "Internal Error");
            }
        }

        private void PreferredDrummer_TextChanged(object sender, EventArgs e) {
            try {
                INIFunctions.SaveINIValue("Band", "PreferredDrummer", PreferredDrummer.Text);
            } catch (Exception exc) {
                V3LauncherCore.AddDebugEntry(exc.ToString(), "Internal Error");
            }
        }

        private void PreferredSinger_TextChanged(object sender, EventArgs e) {
            try {
                INIFunctions.SaveINIValue("Band", "PreferredSinger", PreferredSinger.Text);
            } catch (Exception exc) {
                V3LauncherCore.AddDebugEntry(exc.ToString(), "Internal Error");
            }
        }

        private void PreferredGuitaristHighway_TextChanged(object sender, EventArgs e) {
            try {
                INIFunctions.SaveINIValue("Band", "PreferredGuitaristHighway", PreferredGuitaristHighway.Text);
            } catch (Exception exc) {
                V3LauncherCore.AddDebugEntry(exc.ToString(), "Internal Error");
            }
        }

        private void PreferredBassistHighway_TextChanged(object sender, EventArgs e) {
            try {
                INIFunctions.SaveINIValue("Band", "PreferredBassistHighway", PreferredBassistHighway.Text);
            } catch (Exception exc) {
                V3LauncherCore.AddDebugEntry(exc.ToString(), "Internal Error");
            }
        }

        private void PreferredDrummerHighway_TextChanged(object sender, EventArgs e) {
            try {
                INIFunctions.SaveINIValue("Band", "PreferredDrummerHighway", PreferredDrummerHighway.Text);
            } catch (Exception exc) {
                V3LauncherCore.AddDebugEntry(exc.ToString(), "Internal Error");
            }
        }

        private void PreferredStage_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "PreferredStage", INIFunctions.InterpretINISetting(PreferredStage.Text,
                V3LauncherConstants.VenueIDs[0], V3LauncherConstants.VenueIDs[1]));
        }

        private void GuitarStrumAnim_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "GuitarStrumAnim", INIFunctions.InterpretINISetting(GuitarStrumAnim.Text,
                new string[] { "GH: World Tour (Default)", "Guitar Hero: Metallica" }, new string[] { "none", "ghm" }));
        }

        private void BassStrumAnim_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "BassStrumAnim", INIFunctions.InterpretINISetting(BassStrumAnim.Text,
                new string[] { "GH: World Tour (Default)", "Guitar Hero: Metallica" }, new string[] { "none", "ghm" }));
        }
        #endregion
    }
}
