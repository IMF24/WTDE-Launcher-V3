﻿/* ------------------------------------------------------------------------------------------------
     __    __  _____  ___  __        __    _             __  ___         __  __            _____ 
    / / /\ \ \/__   \/   \/__\      / /   /_\  /\ /\  /\ \ \/ __\ /\  /\/__\/__\    /\   /\___ / 
    \ \/  \/ /  / /\/ /\ /_\       / /   //_\\/ / \ \/  \/ / /   / /_/ /_\ / \//    \ \ / / |_ \ 
     \  /\  /  / / / /_///__      / /___/  _  \ \_/ / /\  / /___/ __  //__/ _  \     \ V / ___) |
      \/  \/   \/ /____/\__/      \____/\_/ \_/\___/\_\ \/\____/\/ /_/\__/\/ \_/      \_/ |____/ 
    
    GHWT: Definitive Edition Launcher Version 3 - By IMF24
     - - - - - - - - - - - - -  - - - - - - - - - - - - -
    
    The 3rd generation launcher program for Guitar Hero World Tour: Definitive Edition, but now
    expanded even further and made as pretty as Uzis' original launcher!
    
    This time, this isn't a Python program, it's now written in C#! That's right, we've moved
    away from Python, and we're moving the launcher BACK to the C# language, built on the .NET
    framework. All the functionality of the V2 launcher will be re-imported into here, and it
    will also be visually polished to make it look the best it possibly can!

    This launcher is written in C# 7.3 on .NET 4.6.2.
    
------------------------------------------------------------------------------------------------ */
// V3 launcher imports.
using WTDE_Launcher_V3.IO;
using WTDE_Launcher_V3.Managers;
using WTDE_Launcher_V3.Managers.ScriptMods;

// Various required imports.
using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using NAudio.CoreAudioApi;
using MadMilkman.Ini;

namespace WTDE_Launcher_V3.Core {
    /// <summary>
    ///  Main entry class for the V3 launcher. The Form's name is Main.
    /// </summary>
    public partial class Main : Form {
        /// <summary>
        ///  Main entry point for the V3 launcher.
        /// </summary>
        public Main() {
            // Make sure we're in the correct starting directory before we begin!
            // Apparently Fox has temp directory issues... trying to sort that out.
            string startDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Directory.SetCurrentDirectory(startDir);
            V3LauncherCore.AddDebugEntry($"Starting in the directory: {startDir}");

            try {
                // Show the intro splash.
                V3LauncherCore.AddDebugEntry("Showing intro form! Auto killing when launcher is ready...");
                IntroSplash ish = new IntroSplash();
                ish.Show();

                // Update idle tasks; causes the form to not even render!
                Application.DoEvents();

                // Do some directory and file verification.
                V3LauncherCore.MakeUpdaterINI();

                // - - - - - - - - - - - - - - - - - - - - - - -

                // Initialize Windows Forms. We need this. DO NOT EDIT OR DELETE IT!
                // This contains the Designer support; you see why we need it?
                InitializeComponent();

                // - - - - - - - - - - - - - - - - - - - - - - -

                // Set the venue listings correctly.
                PreferredStage.Items.Clear();
                PreferredTrainingStage.Items.Clear();
                AutoLaunchVenue.Items.Clear();

                string[] itemsToAdd = V3LauncherConstants.VenueIDs[0].ToArray();
                PreferredStage.Items.AddRange(itemsToAdd);
                PreferredTrainingStage.Items.AddRange(itemsToAdd);
                AutoLaunchVenue.Items.AddRange(itemsToAdd);

                // - - - - - - - - - - - - - - - - - - - - - - -

                // Set our background image correctly and get the MOTD from the website.
                BackgroundImage = Properties.Resources.bg_1;

                // Remove any auto strum workarounds.
                RemoveAutoStrumKeys();

                // Get our list of microphone devices.
                GetMicDevices();

                // Set the window title and the background.
                V3LauncherCore.SetWindowTitle(this);

                // Append gem and venue mods from the user's mods!
                ModHandler.AppendVenueMods(new ComboBox[] { AutoLaunchVenue, PreferredStage, PreferredTrainingStage });
                ModHandler.AppendGemMods(new ComboBox[] { GemTheme });

                // Load our INI and XML settings and set up the tabs for use.
                LoadINISettings();
                DoTabSetup();

                // Also play boot VOs if we have them on, fun stuff!
                V3LauncherCore.AudioBootVO();

                // DEV ONLY SETTINGS: THIS FILE SHOULD **NEVER** BE PRESENT IN PUBLIC BUILDS.
                OpenDevOnlySettings.Enabled = V3LauncherCore.AllowDevSettings();
                OpenDevOnlySettings.Visible = V3LauncherCore.AllowDevSettings();
                DevSettingsONLabel.Visible = V3LauncherCore.AllowDevSettings(false);

                // Also, should we automatically update when the program starts?
                V3LauncherCore.AutoCheckForUpdates();

                // Show update needed?
                //~ bool showUpdateNeeded = V3LauncherCore.IsWTDEUpToDate();
                //~ Console.WriteLine($"is update needed? {showUpdateNeeded}");
                //~ UpdateAvailableLabel.Visible = !showUpdateNeeded;
                //~ UpdateAvailableLabel.BringToFront();
                //~ UpdateAvailableLabel.Text = UpdateAvailableLabel.Text.Replace("VXYZ", V3LauncherCore.GetLatestVersion());
                UpdateAvailableLabel.Visible = false;

                // Can we update the game? Do we have an internet connection?
                if (!IsNetworkConnected) {
                    CheckUpdatesButton.Enabled = false;
                    CheckUpdatesButton.ForeColor = Color.Black;
                    if (EnableAFDTheme) ChangeControlTooltip(CheckUpdatesButton, "WTDX cannot be updated! Your subscription has expired.");
                    else ChangeControlTooltip(CheckUpdatesButton, "Can't update WTDE! Is the network working? Make sure you check if you have a valid internet\n" +
                                                                  "connection, relaunch the program, then try again.");
                    UseMOTDWithImage = false;
                    V3LauncherCore.GetMOTDText(MOTDText);
                } else {
                    V3LauncherCore.GetMOTDText(MOTDLabelImage, UseMOTDWithImage, MOTDImage);
                }

                // HACK: We can use MaximumSize and AutoSize together here
                // to trick Windows Forms. It works, though!
                // This gives us a scrollable label that looks really clean.

                // We pull this off by putting a normal label in a panel,
                // setting AutoScroll for the panel to be true, and then we
                // set the label's maximum size and make it auto resize too.
                MOTDLabelImage.MaximumSize = new Size(650, 0);
                MOTDLabelImage.AutoSize = true;

                MOTDText.MaximumSize = new Size(650, 0);
                MOTDText.AutoSize = true;

                // April Fools Day stuff!               
                if (EnableAFDTheme && !IsFirstBoot) {
                    BackgroundImage = Properties.Resources.bg_1_af;
                    WTDELogo.Image = Properties.Resources.logo_af;
                    IconLogoIMF.BackgroundImage = Properties.Resources.logo_imf24_af;
                    IconLogoDELauncher.BackgroundImage = Properties.Resources.icon_af;

                    MOTDText.Text = "Well, this is embarrassing.\n\n" +
                                    "We regret to inform you, but Guitar Hero World Tour: Definitive Edition is no more.\n" +
                                    "It's now Guitar Hero World Tour Deluxe. In order to play, you require a Premium Rocker subscription in order to play the game.\n\n" +
                                    "If you feel as if you've received this message in error, please contact our hotline. Our unpaid interns will get back to you as soon as possible.\n\n" +
                                    "We're sorry for the inconvenience! D:";

                    MOTDLabelImage.Text = "Well, this is embarrassing.\n\n" +
                                          "We regret to inform you, but Guitar Hero World Tour: Definitive Edition is no more.\n" +
                                          "It's now Guitar Hero World Tour Deluxe. In order to play, you require a Premium Rocker subscription in order to play the game.\n\n" +
                                          "If you feel as if you've received this message in error, please contact our hotline. Our unpaid interns will get back to you as soon as possible.\n\n" +
                                          "We're sorry for the inconvenience! D:";

                    // Auto launch warning header.
                    TALSaveWarningLabel.Enabled = true;
                    TALSaveWarningLabel.Text = "Warning: It's party time!! And we don't live in a facsist nation!!";

                    // Side buttons.
                    RunWTDEButton.Text = "Start WTDX Trial";
                    AdjustSettingsButton.Text = "Don't Change These!";
                    OpenModsButton.Text = "Mods Folder...?";
                    CheckUpdatesButton.Text = "Updates Unsupported";
                    ModManagerButton.Text = "Mod Deleter";

                    // Tab buttons.
                    TabButtonGeneral.Text = "Basic";
                    TabButtonInput.Text = "Buttons";
                    TabButtonGraphics.Text = "Visuals";
                    TabButtonBand.Text = "Peoples";
                    TabButtonAutoLaunch.Text = "Blast Off";
                    TabButtonDebug.Text = "Re-bug";

                    // Credits page stuff.
                    CreditsVersionLabel.Enabled = true;
                    CreditsMainInfo.Enabled = true;
                    
                    CreditsVersionLabel.Text = $"GHWT Deluxe Destroyer - Version {V3LauncherConstants.VERSION}";

                    CreditsMainInfo.Text = "GHWT Deluxe by Fretworkers, EST. 1969\n" +
                                           "GHWT Deluxe Destroyer by International Monetary Fund 24\n\n" +
                                           "Made in Cb 9999999999999999999.99999999 on .ORG 9.99.999\n\n" +
                                           "This isn't even your launcher to deface! It's vandalism! It's pure vandalism! You wouldn't do that if this was YOUR launcher, would you? If I came around your house, smashing your property and telly to bits, you'd be furious! And rightfully so! Unbelievable!\n\n" +
                                           "You really shouldn't be here... I'm leaving now. You'll be GLaD you did.\n\n" +
                                           "GHWT: DX and Fretworkers are not associated with AlwaysSoft, Inactive Vision Wizard, RedOctave, Beeswax, or Above Ground Deployment in any way, shape, or form.\n" +
                                           "Thank you! GHWT: DX is a project. Yes. A project. That's what it is.";

                    VersionInfoLabel.Text = $"WTDX Destroyer V{V3LauncherConstants.VERSION} by I.M. Fund 24\nBG Image: Someone Based\nWTDE Latest Version: WTDE is no more";

                    // Update the social link button images. Thanks Derpy!
                    ButtonYouTube.Image = Properties.Resources.youtube_af;
                    ButtonGitHub.Image = Properties.Resources.github_af;
                    ButtonWTDESite.Image = Properties.Resources.wtde_site_af;
                    ButtonFretworks.Image = Properties.Resources.fretworks_af;
                    ButtonDiscord.Image = Properties.Resources.discord_af;

                    FretworksLogo.Image = Properties.Resources.fretworks_banner_s_af;
                } else {
                    BGConstants.AutoDateBackground(this, VersionInfoLabel, WTDELogo);
                }

                // Initially boot into our preferred tab!
                // Also ensures we draw the correct MOTD style based on if
                // we are connected to the internet or not.
                int defaultTab = int.Parse(INIFunctions.GetINIValue("Launcher", "DefaultTab", "0"));
                UpdateActiveTab(defaultTab);

                ish.Close();

                // - - - - - - - - - - - - - - - - - - - - - - -

                // Show the welcome screen, if it hasn't been shown before.
                if (IsFirstBoot) {
                    IntroHelloScreen ihs = new IntroHelloScreen();
                    ihs.ShowDialog();
                }

                // - - - - - - - - - - - - - - - - - - - - - - -

                // Show intro popups 5 times each to make the user READ;
                // sad that we have to do this. But oh well.

                if (!IsFirstBoot) {
                    int timesPopupsShown = int.Parse(INIFunctions.GetINIValue("Launcher", "IntroPopupsTimesShown", "0"));
                    if (timesPopupsShown < 5) {
                        // -- INTRO POPUP 1
                        string bootPopup1 = "Heads up!\n\n" +
                                            "This launcher is designed for tweaking of most settings, but not every setting is shown in this program. For instance, to bind your controllers, please visit the Bind Controllers menu in the Options Menu in-game.";
                    
                        // -- INTRO POPUP 2
                        string bootPopup2 = "Heads up!\n\n" +
                                            "Should you run into any issues using this launcher, please create an issue thread on the GitHub page for the launcher, or visit the help line channels in our Discord server.\n\n" +
                                            "Remember: Do NOT drop a debug_launcher.txt file without providing context.";

                        MessageBox.Show(bootPopup1, "Heads Up!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(bootPopup2, "Heads Up!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        timesPopupsShown++;
                        INIFunctions.SaveINIValue("Launcher", "IntroPopupsTimesShown", timesPopupsShown.ToString());
                    }
                }

                // - - - - - - - - - - - - - - - - - - - - - - -

                // INI file class testing! It works beautifully! :D
                //~ INI testIni = new INI("C:/Users/ifire/Desktop/test_ini_file.ini", true, true);
                //~ string testValue = testIni.GetString("TestSection", "TestValue", "Something Different");
                //~ decimal testNumber = testIni.GetDecimal("TestSection", "TestNumber");
                //~ int testInt = testIni.GetInt("TestSection", "AnotherNumber2", 16);

                //~ testIni.SetInt("TestSection", "AnotherTest", 24);

                //~ Console.WriteLine($"test INI value: {testValue}");
                //~ Console.WriteLine($"test decimal value: {testNumber}");
                //~ Console.WriteLine($"test int value: {testInt}");

                //~ testNumber += 15;

                //~ Console.WriteLine($"test decimal value after addition: {testNumber}");

                // - - - - - - - - - - - - - - - - - - - - - - -

                RPCHandler.SetRPCDetails("Changing some settings");

                // - - - - - - - - - - - - - - - - - - - - - - -

                // Disable some settings objects that are unfinished.
                TGDefaultCategory.Visible = false;
                InitialSetlistCategory.Enabled = false;
                InitialSetlistCategory.Visible = false;

            } catch (Exception exc) {
                // Get information about the crash.
                // Apparently Costura.Fody causes this to be messed up or thrown
                // out of whack... Not sure why; probably unavoidable.
                var st = new StackTrace(exc, true);
                var frame = st.GetFrame(0);
                var line = frame.GetFileLineNumber();

                // Print the error to the end user.
                V3LauncherCore.AddDebugEntry($"Uh oh, we hit an error upon startup! // Exception: {exc.Message}");
                
                // Along with showing the error, ask if we want to restart the launcher.
                bool restartExecution = MessageBox.Show($"Uh oh, something went wrong!\n\n----------------\n\nError information: {exc.Message}\n\n----------------\n\nLine: line {line}\nFrame: {frame}\n\n----------------\n\nDo you want to restart the launcher and try again?", "Boot Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes;

                // We DO want to restart!
                if (restartExecution) {
                    this.Close();
                    Application.Restart();

                // We do NOT want to restart; just close the program down!
                } else {
                    V3LauncherCore.WriteDebugLog();

                    this.Close();
                    Application.Exit();
                    return;
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  What type of MOTD box would we like to use?
        ///  <br/>
        ///  - Set this to true to get an MOTD container with an image and text.
        ///  <br/>
        ///  - Set this to false to get an MOTD container with text only.
        /// </summary>
        public static bool UseMOTDWithImage = true;
        
        /// <summary>
        ///  Is this the hello message going to be shown, or has it been shown before?
        /// </summary>
        public static bool IsFirstBoot = INIFunctions.GetINIValue("Launcher", "HelloMessageShown", "0") == "0";

        /// <summary>
        ///  Are we enabling the April Fools' Day theme?
        /// </summary>
        public static bool EnableAFDTheme = ((INIFunctions.GetINIValue("Config", "Holiday", "") == "aprilfools") || (DateTime.Now.Month == 4 && DateTime.Now.Day == 1));

        /// <summary>
        ///  Is there an available internet connection?
        /// </summary>
        public static bool IsNetworkConnected = V3LauncherCore.IsConnectedToInternet();

        /// <summary>
        ///  The last button's name for the band member to change that was activated.
        /// </summary>
        public string BandMemberChangeLastButton = "";

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Array of difficulty icon images.
        /// </summary>
        public Bitmap[] DifficultyIcons = new Bitmap[] {
            Properties.Resources.icon_difficulty_beginner,
            Properties.Resources.icon_difficulty_easy,
            Properties.Resources.icon_difficulty_medium,
            Properties.Resources.icon_difficulty_hard,
            Properties.Resources.icon_difficulty_expert
        };

        /// <summary>
        ///  Array of instrument icon images.
        /// </summary>
        public Bitmap[] InstrumentIcons = new Bitmap[] {
            Properties.Resources.mixer_icon_guitar,
            Properties.Resources.mixer_icon_bass,
            Properties.Resources.mixer_icon_drums,
            Properties.Resources.mixer_icon_vocals
        };

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  The list of songs that will be loaded into when in Auto Launch mode.
        /// </summary>
        public List<string> AutoLaunchSongs = new List<string>();

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Change the text tooltip of a control.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="text"></param>
        public void ChangeControlTooltip(Control control, string text) {
            if (control != null) {
                this.ToolTipMain.SetToolTip(control, text);
            }
        }
        
        // - - - - - - - - - - - - - - - - - - - - - - -

        private void OpenDevOnlySettings_Click(object sender, EventArgs e) {
            WTDEDevSettingsDialog dlg = new WTDEDevSettingsDialog();
            dlg.ShowDialog();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Makes a default GHWTDE.ini file for the user if they don't have one.
        /// </summary>
        public void WriteDefaultConfig() {
            if (!File.Exists(V3LauncherConstants.WTDEConfigDir)) {
                string fileContents = Properties.Resources.default_config.ToString();
                File.WriteAllText(V3LauncherConstants.WTDEConfigDir, fileContents);
            }
        }

        /// <summary>
        ///  Load all config data from GHWTDE.ini and AspyrConfig.xml.
        /// </summary>
        public void LoadINISettings() {
            // Write a new default config if the user doesn't have one!
            WriteDefaultConfig();

            // ---------------------------------
            // GENERAL TAB
            // ---------------------------------

            // -- BASIC OPTIONS --------
            // Basic Settings
            RichPresence.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "RichPresence"));
            AllowHolidays.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "AllowHolidays"));
            DefaultQPODifficulty.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Config", "DefaultQPODifficulty"),
                new string[] { "easy_rhythm", "easy", "medium", "hard", "expert" },
                new string[] { "Beginner", "Easy", "Medium", "Hard", "Expert" });
            Language.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Config", "Language", "en"),
                V3LauncherConstants.Languages[1], V3LauncherConstants.Languages[0]);
            AutoLogin.Text = INIFunctions.InterpretINISetting(XMLFunctions.AspyrGetString("AutoLogin", "PROMPT"),
                new string[] { "ON", "PROMPT", "OFF" },
                new string[] { "On", "Always Prompt", "Off" });
            StatusHandler.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "StatusHandler", "0"));
            Holiday.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Config", "Holiday", ""),
                V3LauncherConstants.HolidayThemes[1], V3LauncherConstants.HolidayThemes[0]);

            // Main Menu Toggles
            UseCareerOption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseCareerOption", "1"));
            UseQuickplayOption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseQuickplayOption", "1"));
            UseHeadToHeadOption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseHeadToHeadOption", "1"));
            UseOnlineOption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseOnlineOption", "1"));
            UseMusicStudioOption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseMusicStudioOption", "1"));
            UseCAROption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseCAROption", "1"));
            UseOptionsOption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseOptionsOption", "1"));
            UseQuitOption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "UseQuitOption", "1"));

            // Launcher Settings
            CheckForUpdates.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Launcher", "CheckForUpdates", "1"));
            ExitOnSave.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Launcher", "ExitOnSave", "1"));
            DebugConsoleLauncher.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Launcher", "Console"));
            LauncherRichPresence.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Launcher", "RichPresence"));
            DefaultTab.SelectedIndex = int.Parse(INIFunctions.GetINIValue("Launcher", "DefaultTab"));

            // User Names
            PreferredGamerTagText1.Text = INIFunctions.GetINIValue("Config", "PreferredGamerTagText1", "");
            PreferredGamerTagText2.Text = INIFunctions.GetINIValue("Config", "PreferredGamerTagText2", "");
            PreferredGamerTagText3.Text = INIFunctions.GetINIValue("Config", "PreferredGamerTagText3", "");
            PreferredGamerTagText4.Text = INIFunctions.GetINIValue("Config", "PreferredGamerTagText4", "");

            // -- AUDIO SETTINGS --------
            MuteStreams.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Audio", "MuteStreams"));
            WhammyPitchShift.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Audio", "WhammyPitchShift"));
            StarPowerReverb.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Audio", "StarPowerReverb", "1"));
            AudioBuffLen.Text = XMLFunctions.AspyrGetString("Audio.BuffLen", "4096");
            SPClapType.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Audio", "SPClapType", "default"),
                new string[] {
                    "default",
                    "small_int",
                    "medium_int",
                    "medium_ext",
                    "large_ext",
                    "none"
                },
                
                new string[] {
                    "Default (Per Venue)",
                    "Small, Interior",
                    "Medium, Interior",
                    "Medium, Exterior",
                    "Large, Exterior",
                    "No Claps"
                });
            SPActivationSFX.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Audio", "SPActivationSFX", "default"),
                V3LauncherConstants.StarPowerActivationSounds[1], V3LauncherConstants.StarPowerActivationSounds[0]);

            // -- EXTRA SETTINGS --------
            DefaultSetlistSortIndex.SelectedIndex = int.Parse(INIFunctions.GetINIValue("Config", "DefaultSetlistSortIndex"));

            // ---------------------------------
            // INPUT TAB
            // ---------------------------------
            MicrophoneSelect.Text = INIFunctions.GetINIValue("Audio", "MicDevice", "None");
            DisableInputHack.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "DisableInputHack", "0"));

            MicAudioDelay.Value = decimal.Parse(INIFunctions.GetINIValue("Audio", "VocalAdjustment", "-80"));
            MicVideoDelay.Value = decimal.Parse(XMLFunctions.AspyrGetString("Options.VocalsVisualLag", "-315"));

            // -- GUITAR KEYBOARD INPUTS --------
            GuitarGreenInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "GREEN");
            GuitarRedInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "RED");
            GuitarYellowInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "YELLOW");
            GuitarBlueInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "BLUE");
            GuitarOrangeInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "ORANGE");
            GuitarStartInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "START");
            GuitarSelectInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "BACK");
            GuitarWhammyInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "WHAMMY");
            GuitarStarPowerInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "STAR");
            GuitarCancelInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "CANCEL");
            GuitarUpInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "UP");
            GuitarDownInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "DOWN");
            GuitarLeftInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "LEFT");
            GuitarRightInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "RIGHT");

            // -- DRUM KEYBOARD INPUTS --------
            DrumRedInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Drum", "RED");
            DrumYellowInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Drum", "YELLOW");
            DrumBlueInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Drum", "BLUE");
            DrumOrangeInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Drum", "ORANGE");
            DrumGreenInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Drum", "GREEN");
            DrumKickInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Drum", "KICK");
            DrumStartInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Drum", "START");
            DrumSelectInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Drum", "BACK");
            DrumCancelInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Drum", "CANCEL");
            DrumUpInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Drum", "UP");
            DrumDownInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Drum", "DOWN");

            // -- MIC KEYBOARD INPUTS --------
            MicGreenInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Mic", "GREEN");
            MicRedInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Mic", "RED");
            MicYellowInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Mic", "YELLOW");
            MicBlueInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Mic", "BLUE");
            MicOrangeInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Mic", "ORANGE");
            MicStartInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Mic", "START");
            MicSelectInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Mic", "BACK");
            MicCancelInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Mic", "CANCEL");
            MicUpInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Mic", "UP");
            MicDownInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Mic", "DOWN");

            // -- MENU KEYBOARD INPUTS --------
            MenuGreenInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "GREEN");
            MenuRedInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "RED");
            MenuYellowInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "YELLOW");
            MenuBlueInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "BLUE");
            MenuOrangeInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "ORANGE");
            MenuKickInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "KICK");
            MenuWhammyInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "WHAMMY");
            MenuStartInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "START");
            MenuSelectInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "BACK");
            MenuCancelInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "CANCEL");
            MenuUpInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "UP");
            MenuDownInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "DOWN");
            MenuLeftInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "LEFT");
            MenuRightInputs.Text = V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "RIGHT");

            // ---------------------------------
            // GRAPHICS TAB
            // ---------------------------------

            // -- BASIC OPTIONS --------
            VideoWidth.Value = decimal.Parse(INIFunctions.GetINIValue("Graphics", "ResolutionX", "1280"));
            VideoHeight.Value = decimal.Parse(INIFunctions.GetINIValue("Graphics", "ResolutionY", "720"));
            FPSLimit.Value = decimal.Parse(INIFunctions.GetINIValue("Graphics", "FPSLimit"));

            DisableVSync.Checked = INIFunctions.GetBooleanInverse(INIFunctions.GetINIValue("Graphics", "DisableVSync", "1"));
            WindowedMode.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "WindowedMode"));
            Borderless.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "Borderless"));
            HighDetail.Checked = !(XMLFunctions.AspyrGetString("Options.GraphicsQuality", "1") == "1");

            // -- GAMEPLAY OPTIONS --------
            HitSparks.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "HitSparks", "1"));
            BlackStage.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "BlackStage"));
            HideBand.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "HideBand"));
            HideInstruments.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "HideInstruments"));
            HandFlames.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "HandFlames"));
            SpecialStarPowerFX.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "SpecialStarPowerFX"));
            TeslaFX.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "TeslaFX", "1"));
            SoloMarkers.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "SoloMarkers", "0"));
            OptionsPhysics.Checked = INIFunctions.GetBoolean(XMLFunctions.AspyrGetString("Options.Physics", "0"));
            OptionsFrontRowCamera.Checked = INIFunctions.GetBoolean(XMLFunctions.AspyrGetString("Options.FrontRowCamera", "0"));
            OptionsCrowd.SelectedIndex = int.Parse(XMLFunctions.AspyrGetString("Options.Crowd", "2"));
            X360Zones.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "X360Zones", "0"));
            RandomTrainingVenues.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "RandomTrainingVenues", "0"));
            FastWin.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "FastWin"));
            FastStart.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "FastStart"));
            FastLose.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "FastLose"));
            FlawlessOnly.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "FlawlessOnly"));
            FocusedHighway.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "FocusedHighway"));
            BadTripMode.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "BadTripMode"));
            DrunkMode.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "DrunkMode"));

            // -- INTERFACE OPTIONS --------
            GemTheme.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Graphics", "GemTheme", "ghwt"),
                V3LauncherConstants.NoteStyles[1], V3LauncherConstants.NoteStyles[0]);
            GemColors.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Graphics", "GemColors", "standard_gems"),
                V3LauncherConstants.NoteThemeColors[1], V3LauncherConstants.NoteThemeColors[0]);
            SongIntroStyle.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Graphics", "SongIntroStyle", "ghwt"),
                V3LauncherConstants.IntroStyles[1], V3LauncherConstants.IntroStyles[0]);
            LoadingTheme.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Graphics", "LoadingTheme", "wtde"),
                V3LauncherConstants.LoadScreenThemes[1], V3LauncherConstants.LoadScreenThemes[0]);
            HUDTheme.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Graphics", "HUDTheme", "ghwt_plus"),
                V3LauncherConstants.HUDThemes[1], V3LauncherConstants.HUDThemes[0]);
            TrainingScore.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "TrainingScore", "0"));
            AttackIconTheme.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Graphics", "AttackIconTheme", "ghwt"),
                new string[] { "ghwt", "gh3", "gh3_demo", "ghm" },
                new string[] { "GH: World Tour (Default)", "Guitar Hero III", "Guitar Hero III (Demo)", "Guitar Hero: Metallica" });
            YouRockTheme.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Graphics", "YouRockTheme", "ghwt"),
                V3LauncherConstants.YouRockThemes[1], V3LauncherConstants.YouRockThemes[0]);
            PauseTheme.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Graphics", "PauseTheme", "ghwt"),
                V3LauncherConstants.PauseMenuThemes[1], V3LauncherConstants.PauseMenuThemes[0]);
            HelperPillTheme.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Graphics", "HelperPillTheme", "wtde"),
                V3LauncherConstants.HelperPillThemes[1], V3LauncherConstants.HelperPillThemes[0]);
            TrainingSectionFont.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Graphics", "TrainingSectionFont", "ghwt"),
                V3LauncherConstants.TrainingSectionThemes[1], V3LauncherConstants.TrainingSectionThemes[0]);
            TapTrailTheme.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Graphics", "TapTrailTheme", "ghwt"),
                V3LauncherConstants.TapTrailThemes[1], V3LauncherConstants.TapTrailThemes[0]);
            HitFlameTheme.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Graphics", "HitFlameTheme", "ghwt"),
                V3LauncherConstants.HitFlameStyles[1], V3LauncherConstants.HitFlameStyles[0]);
            TrainingAccuracy.SelectedIndex = int.Parse(INIFunctions.GetINIValue("Graphics", "TrainingAccuracy"));
            SustainFX.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "SustainFX", "1"));
            HighwayOpacity.Value = decimal.Parse(INIFunctions.GetINIValue("Graphics", "HighwayOpacity", "100"));
            BlackHighway.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "BlackHighway", "0"));
            HighwayVignetteOpacity.Value = decimal.Parse(INIFunctions.GetINIValue("Graphics", "HighwayVignetteOpacity", "0"));
            ShowAllSPBulbs.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "ShowAllSPBulbs"));

            // -- ADVANCED GRAPHICS --------
            DisableDOF.Checked = INIFunctions.GetBooleanInverse(INIFunctions.GetINIValue("Graphics", "DisableDOF", "0"));
            DisableBloom.Checked = INIFunctions.GetBooleanInverse(INIFunctions.GetINIValue("Graphics", "DisableBloom", "0"));
            ColorFilters.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "ColorFilters", "1"));
            RenderParticles.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "RenderParticles", "1"));
            RenderGeoms.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "RenderGeoms", "1"));
            RenderInstances.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "RenderInstances", "1"));
            DrawProjectors.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "DrawProjectors", "1"));
            Render2D.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "Render2D", "1"));
            RenderScreenFX.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "RenderScreenFX", "1"));
            RenderFog.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "RenderFog", "1"));
            ApplyBandName.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "ApplyBandName", "1"));
            ApplyBandLogo.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Graphics", "ApplyBandLogo", "1"));
            EnableCamPulse.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "EnableCamPulse", "1"));
            DefaultTODProfile.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Graphics", "DefaultTODProfile", "ghwt"),
                V3LauncherConstants.TODProfiles[1], V3LauncherConstants.TODProfiles[0]);
            DOFQuality.SelectedIndex = int.Parse(INIFunctions.GetINIValue("Graphics", "DOFQuality", "2"));
            DOFBlur.Value = decimal.Parse(INIFunctions.GetINIValue("Graphics", "DOFBlur", "6.0"));
            FlareStyle.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Graphics", "FlareStyle", "wtde"),
                V3LauncherConstants.FlareStyles[1], V3LauncherConstants.FlareStyles[0]);

            // ---------------------------------
            // BAND TAB
            // ---------------------------------
            PreferredGuitarist.Text = INIFunctions.GetINIValue("Band", "PreferredGuitarist", "");
            PreferredBassist.Text = INIFunctions.GetINIValue("Band", "PreferredBassist", "");
            PreferredDrummer.Text = INIFunctions.GetINIValue("Band", "PreferredDrummer", "");
            PreferredSinger.Text = INIFunctions.GetINIValue("Band", "PreferredSinger", "");
            PreferredFemaleSinger.Text = INIFunctions.GetINIValue("Band", "PreferredFemaleSinger", "");
            PreferredStage.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Band", "PreferredStage", ""),
                V3LauncherConstants.VenueIDs[1], V3LauncherConstants.VenueIDs[0]);
            PreferredTrainingStage.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Band", "PreferredTrainingStage", ""),
                V3LauncherConstants.VenueIDs[1], V3LauncherConstants.VenueIDs[0]);
            ReplaceSpecialBands.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Band", "ReplaceSpecialBands"));
            SongSpecificInstruments.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Config", "SongSpecificInstruments"));

            PreferredGuitaristHighway.Text = INIFunctions.GetINIValue("Band", "PreferredGuitaristHighway", "");
            PreferredBassistHighway.Text = INIFunctions.GetINIValue("Band", "PreferredBassistHighway", "");
            PreferredDrummerHighway.Text = INIFunctions.GetINIValue("Band", "PreferredDrummerHighway", "");

            GuitarStrumAnim.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Band", "GuitarStrumAnim", "none"),
                new string[] { "none", "ghm" },
                new string[] { "GH: World Tour (Default)", "Guitar Hero: Metallica" });
            BassStrumAnim.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Band", "BassStrumAnim", "none"),
                new string[] { "none", "ghm" },
                new string[] { "GH: World Tour (Default)", "Guitar Hero: Metallica" });

            SongSpecificIntros.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("CelebritiesIntros", "SongSpecificIntros", "1"));
            AlwaysSplashText.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("CelebritiesIntros", "AlwaysSplashText", "1"));
            AlwaysCelebIntro.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("CelebritiesIntros", "AlwaysCelebIntro", "1"));
            AlwaysVOIntro.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("CelebritiesIntros", "AlwaysVOIntro"));
            CustomFirstName.Text = INIFunctions.GetINIValue("CelebritiesIntros", "CustomFirstName", "");
            CustomLastName.Text = INIFunctions.GetINIValue("CelebritiesIntros", "CustomLastName", "");

            // ---------------------------------
            // AUTO LAUNCH TAB
            // ---------------------------------
            AutoLaunchEnabled.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "Enabled", "0"));
            TabALMainEditor.Enabled = AutoLaunchEnabled.Checked;

            AutoLaunchPlayers.Text = INIFunctions.GetINIValue("AutoLaunch", "Players", "1");
            GetAutoLaunchSongs();
            AutoLaunchVenue.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Venue"),
                V3LauncherConstants.VenueIDs[1], V3LauncherConstants.VenueIDs[0]);
            AutoLaunchGameMode.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "GameMode", ""),
                V3LauncherConstants.AutoLaunchModes[1], V3LauncherConstants.AutoLaunchModes[0]);

            string[][] autoLaunchInstruments = {
                new string[] { "guitar", "bass", "drum", "vocals" },
                new string[] { "Lead Guitar - PART GUITAR", "Bass Guitar - PART BASS", "Drums - PART DRUMS", "Vocals - PART VOCALS" }
            };

            string[][] autoLaunchDifficulties = {
                new string[] { "beginner", "easy", "medium", "hard", "expert" },
                new string[] { "Beginner", "Easy", "Medium", "Hard", "Expert" }
            };

            AutoLaunchPart1.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Part", "guitar"),
                autoLaunchInstruments[0], autoLaunchInstruments[1]);
            AutoLaunchPart2.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Part2", "bass"),
                autoLaunchInstruments[0], autoLaunchInstruments[1]);
            AutoLaunchPart3.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Part3", "drum"),
                autoLaunchInstruments[0], autoLaunchInstruments[1]);
            AutoLaunchPart4.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Part4", "vocals"),
                autoLaunchInstruments[0], autoLaunchInstruments[1]);

            AutoLaunchDifficulty1.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Difficulty", "easy"),
                autoLaunchDifficulties[0], autoLaunchDifficulties[1]);
            AutoLaunchDifficulty2.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Difficulty2", "easy"),
                autoLaunchDifficulties[0], autoLaunchDifficulties[1]);
            AutoLaunchDifficulty3.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Difficulty3", "easy"),
                autoLaunchDifficulties[0], autoLaunchDifficulties[1]);
            AutoLaunchDifficulty4.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("AutoLaunch", "Difficulty4", "easy"),
                autoLaunchDifficulties[0], autoLaunchDifficulties[1]);

            AutoLaunchBot1.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "Bot", "1"));
            AutoLaunchBot2.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "Bot2", "1"));
            AutoLaunchBot3.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "Bot3", "1"));
            AutoLaunchBot4.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "Bot4", "1"));

            GamerTag1.Text = INIFunctions.GetINIValue("AutoLaunch", "GamerTag", "");
            GamerTag2.Text = INIFunctions.GetINIValue("AutoLaunch", "GamerTag2", "");
            GamerTag3.Text = INIFunctions.GetINIValue("AutoLaunch", "GamerTag3", "");
            GamerTag4.Text = INIFunctions.GetINIValue("AutoLaunch", "GamerTag4", "");

            AutoLaunchHideHUD.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "HideHUD"));
            AutoLaunchSongTime.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "SongTime"));
            AutoLaunchRawLoad.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "RawLoad"));
            AutoLaunchEncoreMode.Checked = INIFunctions.GetBooleanCustomString(INIFunctions.GetINIValue("AutoLaunch", "EncoreMode"), "last_song");

            // ---------------------------------
            // DEBUG TAB
            // ---------------------------------
            FixGuitarInputLogic.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixGuitarInputLogic", "1"));
            FixNoteLimit.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixNoteLimit", "0"));
            FixMemoryHandler.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixMemoryHandler", "1"));
            DebugConsole.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Logger", "Console", "0"));
            WriteFile.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Logger", "WriteFile", "1"));
            DisableSongLogging.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Logger", "DisableSongLogging", "0"));
            DebugDLCSync.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Logger", "DebugDLCSync", "0"));
            FixFSBObjects.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixFSBObjects", "0"));
            ExtraOptimizedSaves.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "ExtraOptimizedSaves", "0"));
            DebugSaves.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "DebugSaves", "0"));
            ShowWarnings.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Logger", "ShowWarnings", "0"));
            FixFastTextures.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixFastTextures", "1"));
            BindWarningShown.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "BindWarningShown", "0"));
            QuickDebug.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "QuickDebug", "0"));
            PrintLoadedAssets.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Logger", "PrintLoadedAssets", "0"));
            PrintCreateFile.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Logger", "PrintCreateFile", "0"));
            CASNoticeShown.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "CASNoticeShown", "0"));
            ImmediateVectorHandlers.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Logger", "ImmediateVectorHandlers", "1"));
            ExceptionHandler.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Logger", "ExceptionHandler", "1"));
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Remove up and down strum key binds from the fret inputs on the guitar input mapping string.
        ///  Also removes fret binds from the up and down strum inputs.
        ///  <br/>
        ///  This is to prevent any sort of auto strum workaround; this will re-write the input mapping
        ///  string once all workarounds are removed.
        /// </summary>
        public void RemoveAutoStrumKeys() {

            V3LauncherCore.AddDebugEntry("Removing auto strum workarounds, if detected...");

            // - - - - - - - - - - - -
            
            // First up, get the up, down, green, red, yellow, blue,
            // and orange input keys. We will match these against
            // each other when we filter everything out.

            // Get the up and down strum key binds.
            List<string> upKeys = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "UP").Split(' ').ToList();
            List<string> downKeys = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "DOWN").Split(' ').ToList();

            // Get the inputs on guitar for the various fret keys.
            List<string> greenKeys = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "GREEN").Split(' ').ToList();
            List<string> redKeys = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "RED").Split(' ').ToList();
            List<string> yellowKeys = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "YELLOW").Split(' ').ToList();
            List<string> blueKeys = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "BLUE").Split(' ').ToList();
            List<string> orangeKeys = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "ORANGE").Split(' ').ToList();

            // The sets of fret keys we'll look through.
            List<List<string>> fretKeySets = new List<List<string>>() { greenKeys, redKeys, yellowKeys, blueKeys, orangeKeys };
            List<List<string>> strumKeySets = new List<List<string>>() { upKeys, downKeys };

            // Remove the whitespaces from the strings in the inputs.
            foreach (List<string> keySet in fretKeySets) {
                for (var i = 0; i < keySet.Count; i++) {
                    string key = keySet[i].Replace(" ", "");
                    keySet[i] = key;
                }
            }

            foreach (List<string> keySet in strumKeySets) {
                for (var i = 0; i < keySet.Count; i++) {
                    string key = keySet[i].Replace(" ", "");
                    keySet[i] = key;
                }
            }

            // - - - - - - - - - - - -

            // -- TASK 1: FILTER STRUM KEYS FROM FRET INPUTS
            // Go through every strum key set.
            foreach (List<string> keySet in strumKeySets) {

                // Now go through every key in the set.
                for (var i = 0; i < keySet.Count; i++) {

                    // If this key is tied to a fret button input, let's remove it.
                    string key = keySet[i];

                    if (greenKeys.Contains(key) ||
                        redKeys.Contains(key) ||
                        yellowKeys.Contains(key) ||
                        blueKeys.Contains(key) ||
                        orangeKeys.Contains(key)) {

                        keySet.Remove(key);
                    }
                }
            }

            // - - - - - - - - - - - -

            // -- TASK 2: FILTER FRET KEYS FROM STRUM INPUTS
            // Go through each fret key set.
            foreach (List<string> keySet in fretKeySets) {

                // Now go through every key in the set.
                for (var i = 0; i < keySet.Count; i++) {

                    // If the up or down strum keys contain this key, we need to
                    // remove the binding.
                    string key = keySet[i];

                    if (upKeys.Contains(key) || downKeys.Contains(key)) {
                        keySet.Remove(key);
                    }
                }
            }

            // - - - - - - - - - - - -

            // -- TASK 3: RECONSTRUCT THE INPUT STRINGS
            // Once the filtering is complete, we want to re-construct our
            // input mapping strings so that we can write the inputs
            // into AspyrConfig.xml.

            // -- GREEN INPUT STRING
            string newGreenString = "";
            foreach (string key in greenKeys) {
                newGreenString += key + " ";
            }
            newGreenString = newGreenString.Trim();

            // -- RED INPUT STRING
            string newRedString = "";
            foreach (string key in redKeys) {
                newRedString += key + " ";
            }
            newRedString = newRedString.Trim();

            // -- YELLOW INPUT STRING
            string newYellowString = "";
            foreach (string key in yellowKeys) {
                newYellowString += key + " ";
            }
            newYellowString = newYellowString.Trim();

            // -- BLUE INPUT STRING
            string newBlueString = "";
            foreach (string key in blueKeys) {
                newBlueString += key + " ";
            }
            newBlueString = newBlueString.Trim();

            // -- ORANGE INPUT STRING
            string newOrangeString = "";
            foreach (string key in orangeKeys) {
                newOrangeString += key + " ";
            }
            newOrangeString = newOrangeString.Trim();

            // -- UP INPUT STRING
            string newUpString = "";
            foreach (string key in upKeys) {
                newUpString += key + " ";
            }
            newUpString = newUpString.Trim();

            // -- DOWN INPUT STRING
            string newDownString = "";
            foreach (string key in downKeys) {
                newDownString += key + " ";
            }
            newDownString = newDownString.Trim();

            // - - - - - - - - - - - -

            // -- TASK 4: GET THE REMAINING INPUTS
            // If we want a complete mapping string, we need the other inputs too.
            string startInputs = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "START");
            string selectInputs = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "BACK");
            string whammyInputs = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "WHAMMY");
            string starInputs = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "STAR");
            string cancelInputs = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "CANCEL");
            string leftInputs = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "LEFT");
            string rightInputs = V3LauncherCore.AspyrKeyDecode("Keyboard_Guitar", "RIGHT");

            // - - - - - - - - - - - -

            // -- TASK 5: RE-ENCODE THE INPUT MAPPING STRING
            // Now with all that complete, we can re-write our input mapping string.

            // Listen, if you're using the launcher, expect your auto strum workaround(s) to
            // be removed. This is Guitar Hero; there NEVER was any sort of auto strum.

            // If you insist on using auto strum, then Clone Hero and/or Fortnite Festival have
            // corrupted your vision on the core gameplay of Guitar Hero or Rock Band.
            // My advice to you: Get an actual guitar controller and learn the REAL way of
            // playing these games. That or learn the real way of playing it on the keyboard;
            // don't cheap your way out. I'm sorry, but not really.

            V3LauncherCore.AspyrKeyEncode(
                new List<string>() {
                    newGreenString,
                    newRedString,
                    newYellowString,
                    newBlueString,
                    newOrangeString,
                    startInputs,
                    selectInputs,
                    whammyInputs,
                    starInputs,
                    cancelInputs,
                    newUpString,
                    newDownString,
                    leftInputs,
                    rightInputs
                },

                new List<string> {
                    "GREEN", "RED", "YELLOW", "BLUE", "ORANGE", "START", "BACK",
                    "WHAMMY", "STAR", "CANCEL", "UP", "DOWN", "LEFT", "RIGHT"
                },

                "Keyboard_Guitar"
            );

            // - - - - - - - - - - - -

            V3LauncherCore.AddDebugEntry("Auto strum workarounds deleted");
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        // Add in double buffering.
        protected override CreateParams CreateParams {
            // Double buffer to prevent flickering.
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  What is the currently active tab?
        /// </summary>
        public int ActiveTab = 0;

        /// <summary>
        ///  List of the launcher's different tabs.
        /// </summary>
        public enum LauncherTabs {
            /// <summary>
            ///  Message of the day page. This isn't really a tab, but it displays the MOTD.
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
            ///  Credits page. This isn't really a tab, but it shows the credits information.
            /// </summary>
            Credits = 7,
            /// <summary>
            ///  This "tab" is shown BEFORE any tabs get selected.
            /// </summary>
            PreTab = 8
        }

        /// <summary>
        ///  Moves all tabs to the correct location and other various tab setup functionality.
        /// </summary>
        public void DoTabSetup() {
            // Set up the main editing containers' locations and the credits tab panel.
            TabButtonGroup.Location = new Point(321, 0);
            TabParentContainer.Location = new Point(321, 60);
            TabCreditsGroup.Location = new Point(321, 0);
            TabCreditsGroup.Parent = this;
            CreditsVersionLabel.Text = $"GHWT: Definitive Edition Launcher - Version {V3LauncherConstants.VERSION}";

            // Hide title text on the group boxes.
            TabGeneralGroup.Text = "";
            TabInputGroup.Text = "";
            TabGraphicsGroup.Text = "";
            TabBandGroup.Text = "";
            TabAutoLaunchGroup.Text = "";
            TabDebugGroup.Text = "";

            // Parent all tabs to the parent container.
            TabGeneralGroup.Parent = TabParentContainer;
            TabInputGroup.Parent = TabParentContainer;
            TabGraphicsGroup.Parent = TabParentContainer;
            TabBandGroup.Parent = TabParentContainer;
            TabAutoLaunchGroup.Parent = TabParentContainer;
            TabDebugGroup.Parent = TabParentContainer;

            // Move all of the tabs to their correct locations.
            Point location = new Point(12, 8);
            TabGeneralGroup.Location = location;
            TabInputGroup.Location = location;
            TabGraphicsGroup.Location = location;
            TabBandGroup.Location = location;
            TabAutoLaunchGroup.Location = location;
            TabDebugGroup.Location = location;
        }

        /// <summary>
        ///  Update the currently selected tab to a different one.
        /// </summary>
        /// <param name="tab">
        ///  Tab ID to swap to.
        /// </param>
        public void UpdateActiveTab(int tab) {
            ActiveTab = tab;
            switch (tab) {
                // -- MOTD LABEL TAB SWITCH ---------------------------------
                case 0:
                    MOTDPanel.Visible = !UseMOTDWithImage;
                    MOTDWithImagePanel.Visible = UseMOTDWithImage;

                    TabParentContainer.Visible = false;
                    TabParentContainer.Enabled = false;
                    
                    TabButtonGroup.Visible = false;
                    TabButtonGroup.Enabled = false;

                    TabCreditsGroup.Visible = false;
                    TabCreditsGroup.Enabled = false;

                    // ------------------------------------

                    TabGeneralGroup.Visible = false;
                    TabGeneralGroup.Enabled = false;

                    TabInputGroup.Visible = false;
                    TabInputGroup.Enabled = false;

                    TabGraphicsGroup.Visible = false;
                    TabGraphicsGroup.Enabled = false;

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;

                // -- GENERAL TAB SWITCH ---------------------------------
                case 1:
                    MOTDPanel.Visible = false;
                    MOTDWithImagePanel.Visible = false;

                    TabParentContainer.Visible = true;
                    TabParentContainer.Enabled = true;

                    TabButtonGroup.Visible = true;
                    TabButtonGroup.Enabled = true;

                    TabCreditsGroup.Visible = false;
                    TabCreditsGroup.Enabled = false;

                    // ------------------------------------

                    TabGeneralGroup.Visible = true;
                    TabGeneralGroup.Enabled = true;

                    TabInputGroup.Visible = false;
                    TabInputGroup.Enabled = false;

                    TabGraphicsGroup.Visible = false;
                    TabGraphicsGroup.Enabled = false;

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;

                // -- INPUT TAB SWITCH ---------------------------------
                case 2:
                    MOTDPanel.Visible = false;
                    MOTDWithImagePanel.Visible = false;

                    TabParentContainer.Visible = true;
                    TabParentContainer.Enabled = true;

                    TabButtonGroup.Visible = true;
                    TabButtonGroup.Enabled = true;

                    TabCreditsGroup.Visible = false;
                    TabCreditsGroup.Enabled = false;

                    // ------------------------------------

                    TabGeneralGroup.Visible = false;
                    TabGeneralGroup.Enabled = false;

                    TabInputGroup.Visible = true;
                    TabInputGroup.Enabled = true;

                    TabGraphicsGroup.Visible = false;
                    TabGraphicsGroup.Enabled = false;

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;

                // -- GRAPHICS TAB SWITCH ---------------------------------
                case 3:
                    MOTDPanel.Visible = false;
                    MOTDWithImagePanel.Visible = false;

                    TabParentContainer.Visible = true;
                    TabParentContainer.Enabled = true;

                    TabButtonGroup.Visible = true;
                    TabButtonGroup.Enabled = true;

                    TabCreditsGroup.Visible = false;
                    TabCreditsGroup.Enabled = false;

                    // ------------------------------------

                    TabGeneralGroup.Visible = false;
                    TabGeneralGroup.Enabled = false;

                    TabInputGroup.Visible = false;
                    TabInputGroup.Enabled = false;

                    TabGraphicsGroup.Visible = true;
                    TabGraphicsGroup.Enabled = true;

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;

                // -- BAND TAB SWITCH ---------------------------------
                case 4:
                    MOTDPanel.Visible = false;
                    MOTDWithImagePanel.Visible = false;

                    TabParentContainer.Visible = true;
                    TabParentContainer.Enabled = true;

                    TabButtonGroup.Visible = true;
                    TabButtonGroup.Enabled = true;

                    TabCreditsGroup.Visible = false;
                    TabCreditsGroup.Enabled = false;

                    // ------------------------------------

                    TabGeneralGroup.Visible = false;
                    TabGeneralGroup.Enabled = false;

                    TabInputGroup.Visible = false;
                    TabInputGroup.Enabled = false;

                    TabGraphicsGroup.Visible = false;
                    TabGraphicsGroup.Enabled = false;

                    TabBandGroup.Visible = true;
                    TabBandGroup.Enabled = true;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;

                // -- AUTO LAUNCH TAB SWITCH ---------------------------------
                case 5:
                    MOTDPanel.Visible = false;
                    MOTDWithImagePanel.Visible = false;

                    TabParentContainer.Visible = true;
                    TabParentContainer.Enabled = true;

                    TabButtonGroup.Visible = true;
                    TabButtonGroup.Enabled = true;

                    TabCreditsGroup.Visible = false;
                    TabCreditsGroup.Enabled = false;

                    // ------------------------------------

                    TabGeneralGroup.Visible = false;
                    TabGeneralGroup.Enabled = false;

                    TabInputGroup.Visible = false;
                    TabInputGroup.Enabled = false;

                    TabGraphicsGroup.Visible = false;
                    TabGraphicsGroup.Enabled = false;

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = true;
                    TabAutoLaunchGroup.Enabled = true;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;

                // -- DEBUG TAB SWITCH ---------------------------------
                case 6:
                    MOTDPanel.Visible = false;
                    MOTDWithImagePanel.Visible = false;

                    TabParentContainer.Visible = true;
                    TabParentContainer.Enabled = true;

                    TabButtonGroup.Visible = true;
                    TabButtonGroup.Enabled = true;

                    TabCreditsGroup.Visible = false;
                    TabCreditsGroup.Enabled = false;

                    // ------------------------------------

                    TabGeneralGroup.Visible = false;
                    TabGeneralGroup.Enabled = false;

                    TabInputGroup.Visible = false;
                    TabInputGroup.Enabled = false;

                    TabGraphicsGroup.Visible = false;
                    TabGraphicsGroup.Enabled = false;

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = true;
                    TabDebugGroup.Enabled = true;
                    break;

                // -- CREDITS TAB SWITCH ---------------------------------
                case 7:
                    MOTDPanel.Visible = false;
                    MOTDWithImagePanel.Visible = false;

                    TabParentContainer.Visible = false;
                    TabParentContainer.Enabled = false;

                    TabButtonGroup.Visible = false;
                    TabButtonGroup.Enabled = false;

                    TabCreditsGroup.Visible = true;
                    TabCreditsGroup.Enabled = true;

                    // ------------------------------------

                    TabGeneralGroup.Visible = false;
                    TabGeneralGroup.Enabled = false;

                    TabInputGroup.Visible = false;
                    TabInputGroup.Enabled = false;

                    TabGraphicsGroup.Visible = false;
                    TabGraphicsGroup.Enabled = false;

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;

                // -- PRE-TAB TAB SWITCH ---------------------------------
                case 8:
                    MOTDPanel.Visible = false;
                    MOTDWithImagePanel.Visible = false;

                    TabParentContainer.Visible = true;
                    TabParentContainer.Enabled = true;

                    TabButtonGroup.Visible = true;
                    TabButtonGroup.Enabled = true;

                    TabCreditsGroup.Visible = false;
                    TabCreditsGroup.Enabled = false;

                    // ------------------------------------

                    TabGeneralGroup.Visible = false;
                    TabGeneralGroup.Enabled = false;

                    TabInputGroup.Visible = false;
                    TabInputGroup.Enabled = false;

                    TabGraphicsGroup.Visible = false;
                    TabGraphicsGroup.Enabled = false;

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Actions to be carried out when the program closes.
        /// </summary>
        public void ExitActions() {
            V3LauncherCore.DebugLog.Add("\n\nWe're done in the launcher for now!\nThanks for using it! :D");
            Console.WriteLine("\n\nWe're done in the launcher for now!\nThanks for using it! :D");
            try {
                V3LauncherCore.WriteDebugLog();
            } catch (Exception ex) {
                Console.WriteLine($"Uh oh! Hit a problem! Probably nothing severe...\nException details: {ex.Message}");
            }
        }
        
        private void Main_FormClosed(object sender, FormClosedEventArgs e) {
            ExitActions();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Get the list of supported microphone devices. Uses NAudio to get devices.
        /// </summary>
        public void GetMicDevices() {
            var enumerator = new MMDeviceEnumerator();
            foreach (var endpoint in enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active)) {
                MicrophoneSelect.Items.Add(endpoint.FriendlyName);
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Verifies if the settings for auto launch are valid.
        /// </summary>
        /// <returns>
        ///  True if the settings are valid, false if they are not. If false, a dialog of warning messages will be shown.
        /// </returns>
        public bool AutoLaunchVerifyOK() {
            bool okStatus = true;
            List<string> autoLaunchErrors = new List<string> { };

            // Do we have any songs to boot into?
            if (AutoLaunchSongs.Count <= 0) {
                okStatus = false;
                autoLaunchErrors.Add("No songs were given. At least 1 song is required.");
            }

            // Do we have a venue specified?
            // We should never be false here.
            if (AutoLaunchVenue.Text.Trim() == "") {
                okStatus = false;
                autoLaunchErrors.Add("No venue specified.");
            }

            // Do we have a mode to boot into?
            if (AutoLaunchGameMode.Text.Trim() == "") {
                okStatus = false;
                autoLaunchErrors.Add("No game mode specified.");
            }

            // ------------
            // MODE PART VALIDATION
            // ------------
            // Player parts.
            var p1Part = AutoLaunchPart1.Text;
            var p2Part = AutoLaunchPart2.Text;
            var p3Part = AutoLaunchPart3.Text;
            var p4Part = AutoLaunchPart4.Text;

            string[] playerParts2 = new string[] { p1Part, p2Part };
            string[] playerParts3 = new string[] { p1Part, p2Part, p3Part };
            string[] playerParts4 = new string[] { p1Part, p2Part, p3Part, p4Part };

            // How many of each part do we have?
            // We'll use this to verify the number of each instrument
            // for the following switch.
            int numPlayers = int.Parse(AutoLaunchPlayers.Text);

            int numDrums2P = playerParts2.Where(s => s == "Drums - PART DRUMS").Count();
            int numVocals2P = playerParts2.Where(s => s == "Vocals - PART VOCALS").Count();

            int numGuitar3P = playerParts3.Where(s => s == "Lead Guitar - PART GUITAR").Count();
            int numBass3P = playerParts3.Where(s => s == "Bass Guitar - PART BASS").Count();
            int numDrum3P = playerParts3.Where(s => s == "Drums - PART DRUMS").Count();
            int numVocals3P = playerParts3.Where(s => s == "Vocals - PART VOCALS").Count();

            int numGuitar4P = playerParts4.Where(s => s == "Lead Guitar - PART GUITAR").Count();
            int numBass4P = playerParts4.Where(s => s == "Bass Guitar - PART BASS").Count();
            int numDrum4P = playerParts4.Where(s => s == "Drums - PART DRUMS").Count();
            int numVocals4P = playerParts4.Where(s => s == "Vocals - PART VOCALS").Count();

            switch (AutoLaunchGameMode.SelectedIndex) {
                // -- BAND QUICKPLAY -----------------
                case 0:
                    switch (numPlayers) {
                        // -- 1 PLAYER -------------------
                        case 1:
                            // Safe, probably
                            break;

                        // -- 2 PLAYERS ------------------
                        case 2:
                            // Just check the first 2 parts against each other.
                            if (p1Part == p2Part) {
                                okStatus = false;
                                autoLaunchErrors.Add("Instrument parts cannot be duplicated for band quickplay.");
                            }
                            break;

                        // -- 3 PLAYERS ------------------
                        case 3:
                            // Check if any of these 3 parts are equal to each other.
                            if ((p1Part == p2Part) || (p1Part == p3Part) || (p2Part == p3Part)) {
                                okStatus = false;
                                autoLaunchErrors.Add("Instrument parts cannot be duplicated for band quickplay.");
                            }
                            break;

                        // -- 4 PLAYERS ------------------
                        case 4:
                            if (numGuitar4P != 1 || numBass4P != 1 || numDrum4P != 1 || numVocals4P != 1) {
                                okStatus = false;
                                autoLaunchErrors.Add("Instrument parts cannot be duplicated for band quickplay.");
                            }
                            break;
                    }
                    break;

                // -- 2P FACE OFF AND PFO ------------
                case 1: case 2:
                    // We only want to check players 1 and 2 for this.
                    if (int.Parse(AutoLaunchPlayers.Text) != 2) {
                        okStatus = false;
                        autoLaunchErrors.Add("Must have EXACTLY 2 players specified for face off or pro face off play.");
                    
                    // We're safe, let's test other things now.
                    } else {
                        // Are we on vocals?
                        if (numVocals2P > 0) {
                            okStatus = false;
                            autoLaunchErrors.Add("Cannot enter face off modes on vocals.");
                        
                        // Are the parts not the same?
                        } else {
                            if (p1Part != p2Part) {
                                okStatus = false;
                                autoLaunchErrors.Add("Parts cannot be different for face off or pro face off play.");
                            }
                        }
                    }
                    break;

                // -- 2P BATTLE ----------------------
                case 3:
                    // We only want to check players 1 and 2 for this.
                    if (int.Parse(AutoLaunchPlayers.Text) != 2) {
                        okStatus = false;
                        autoLaunchErrors.Add("Must have EXACTLY 2 players specified for battle mode play.");

                    // We're safe, let's test other things now.
                    } else {
                        // Are we on drums or vocals?
                        if (numDrums2P > 0 || numVocals2P > 0) {
                            okStatus = false;
                            autoLaunchErrors.Add("Cannot enter battle mode on drums or vocals.");

                        // Are the parts not the same?
                        } else {
                            if (p1Part != p2Part) {
                                okStatus = false;
                                autoLaunchErrors.Add("Parts cannot be different for battle mode play.");
                            }
                        }
                    }
                    break;
            }

            // Did we have any errors?
            // If so, show a warning dialog!
            if (!okStatus || autoLaunchErrors.Count > 0) {
                string autoErrorText = "You have errors in your auto launch configuration! The following problems were found:\n";

                foreach (string error in autoLaunchErrors) {
                    autoErrorText += $"\n- {error}";
                }
                
                MessageBox.Show(autoErrorText, "Auto Launch Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // And give the status back!
            return okStatus;
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

        private void RunWTDEButton_Click(object sender, EventArgs e) {
            try {
                // Is WTDE already running? If so, let's ask if the user wants
                // to kill the already running process and start a new one.
                Process[] pname = Process.GetProcessesByName("GHWT_Definitive");
                V3LauncherCore.AddDebugEntry($"Running processes of WTDE (should be 1 if game is running): {pname.Length}");
                if (pname.Length == 0) {
                    V3LauncherCore.AddDebugEntry("WTDE is NOT running");
                } else {
                    V3LauncherCore.AddDebugEntry("WTDE IS RUNNING");

                    string wtdeAlreadyRunning = "It seems that GHWT: DE is already running. Do you want to close the currently running " +
                                                "instance of the game and start a new one?";

                    if (MessageBox.Show(wtdeAlreadyRunning, "WTDE Already Open", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes) {
                        pname[0].Kill();
                    } else {
                        return;
                    }
                }

                // Do we have auto launch enabled?
                if (AutoLaunchEnabled.Checked) {
                    // If our auto launch configuration isn't valid, do not proceed!
                    if (!AutoLaunchVerifyOK()) return;

                    // If Auto Launch is enabled, warn the user!
                    // Back up their save data if we're instructed to do so.
                    string autoLaunchEnabledWarning = "You have Auto Launch functionality enabled. Running the game may cause your save data " +
                                                      "to be lost.\n\nIn the event something goes wrong, do you want to create a backup copy " +
                                                      "of your save data?";

                    if (MessageBox.Show(autoLaunchEnabledWarning, "Auto Launch Enabled", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                        File.Copy(V3LauncherConstants.WTDESaveDir, $"{V3LauncherConstants.WTDESaveBackupsDir}/GHWTDE_{DateTime.Now.ToString().Replace(":", "_").Replace("/", "-")}.sav", true);

                        string saveBackedUp = "Your save file has been backed up!\n\nYou can load the backup save from the Save File Manager if something goes wrong. " +
                                              "Access the manager by going to the Mod Manager, then go to File > Manage Save Files.";

                        MessageBox.Show(saveBackedUp, "Save Backed Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Go to the user's WTDE install folder and start the game up!
                ModHandler.UseUpdaterINIDirectory();
                Process.Start("GHWT_Definitive.exe");

                // If we want to exit on save, it will close the launcher.
                // Otherwise, don't close it!
                if (ExitOnSave.Checked) {
                    this.Close();
                    Environment.Exit(0);
                }

            } catch (Exception exc) {
                V3LauncherCore.AddDebugEntry($"Error during game launch: {exc.Message}");
                return;
            }
        }

        private void AdjustSettingsButton_Click(object sender, EventArgs e) {
            if (ActiveTab == 0 || ActiveTab == 7) UpdateActiveTab((int) LauncherTabs.PreTab);
            else UpdateActiveTab((int) LauncherTabs.MOTD);
        }

        private void OpenModsButton_Click(object sender, EventArgs e) {
            // We'll use Path.Combine() for this, otherwise we might
            // run into other platform issues (for example, Linux).
            var owd = Directory.GetCurrentDirectory();
            ModHandler.UseUpdaterINIDirectory();
            Process.Start("explorer.exe", Path.Combine("DATA", "MODS"));
            Directory.SetCurrentDirectory(owd);
        }

        private void CheckUpdatesButton_Click(object sender, EventArgs e) {
            V3LauncherCore.CheckForUpdates();
        }

        private void ModManagerButton_Click(object sender, EventArgs e) {
            ModManager mManager = new ModManager();
            mManager.ShowDialog();

            // Is this a bug? I don't know, I think Fox had an issue with this...
            // Reload INI/XML settings again just in case.
            LoadINISettings();

            // Reset RPC status.
            RPCHandler.SetRPCLargeImage(
                "https://raw.githubusercontent.com/IMF24/WTDE-Launcher-V3/master/res/img/icon/icon.png"
            );
            RPCHandler.SetRPCDetails("Changing some settings");
        }

        private void FretworksLogo_Click(object sender, EventArgs e) {
            if (ActiveTab == 7) UpdateActiveTab((int) LauncherTabs.MOTD);
            else UpdateActiveTab((int) LauncherTabs.Credits);
        }

        private void VersionInfoLabel_Click(object sender, EventArgs e) {
            // AFD theme? Using custom background? Don't change it!
            if (EnableAFDTheme || BGConstants.IsCustomBG) return;

            V3LauncherCore.AddDebugEntry("AFD theme nor custom BG is active, DO change the background");

            // Which mouse button did we push?
            MouseEventArgs me = (MouseEventArgs) e;

            // Left triggers the background to swap.
            if (me.Button == MouseButtons.Left) {
                // Are we at the end of the BG cycle?
                if (BGConstants.BGIndex + 1 == BGConstants.V3LauncherBackgrounds.Length) BGConstants.BGIndex = 0;
                else BGConstants.BGIndex++;

                V3LauncherCore.AddDebugEntry($"BG index is currently {BGConstants.BGIndex}");

                // Update the version info.
                VersionInfoLabel.Text = $"GHWT: DE Launcher V{V3LauncherConstants.VERSION} by IMF24\nBG Image: {BGConstants.V3LauncherBGAuthors[BGConstants.BGIndex]}\nWTDE Latest Version: {V3LauncherCore.GetLatestVersion()}";

                // Update the background image.
                this.BackgroundImage = BGConstants.V3LauncherBackgrounds[BGConstants.BGIndex];

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

        // -- BASIC OPTIONS -----------------------------
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
                new string[] { "easy_rhythm", "easy", "medium", "hard", "expert" }));
            QPODifficultyIconImage.BackgroundImage = DifficultyIcons[DefaultQPODifficulty.SelectedIndex];
        }

        private void Language_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "Language", INIFunctions.InterpretINISetting(Language.Text,
                V3LauncherConstants.Languages[0], V3LauncherConstants.Languages[1]));
        }

        private void AutoLogin_SelectedIndexChanged(object sender, EventArgs e) {
            string valueToWrite = AutoLogin.Text;
            switch (AutoLogin.Text) {
                case "Always Prompt":
                    valueToWrite = "Prompt";
                    break;
            }
            XMLFunctions.AspyrWriteString("AutoLogin", valueToWrite.ToUpper());
        }

        private void Holiday_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "Holiday", INIFunctions.InterpretINISetting(Holiday.Text,
                V3LauncherConstants.HolidayThemes[0], V3LauncherConstants.HolidayThemes[1]));
        }

        private void StatusHandler_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "StatusHandler", INIFunctions.BoolToString(StatusHandler.Checked));
        }

        private void PreferredGamerTagText1_TextChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "PreferredGamerTagText1", PreferredGamerTagText1.Text);
        }

        private void PreferredGamerTagText2_TextChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "PreferredGamerTagText2", PreferredGamerTagText2.Text);
        }

        private void PreferredGamerTagText3_TextChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "PreferredGamerTagText3", PreferredGamerTagText3.Text);
        }

        private void PreferredGamerTagText4_TextChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "PreferredGamerTagText4", PreferredGamerTagText4.Text);
        }

        // -- LAUNCHER OPTIONS -----------------------------

        private void CheckForUpdates_CheckedChanged(object sender, EventArgs e) {
            if (!CheckForUpdates.Checked) {
                string cfuDisableWarning = "Do you really wish to disable the auto update checker? Doing this " +
                                           "is not recommended and may cause your WTDE installation to fall " +
                                           "out of date much faster.";
                CheckForUpdates.Checked = !(MessageBox.Show(cfuDisableWarning, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);
            }
            INIFunctions.SaveINIValue("Launcher", "CheckForUpdates", INIFunctions.BoolToString(CheckForUpdates.Checked));
        }

        private void ExitOnSave_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Launcher", "ExitOnSave", INIFunctions.BoolToString(ExitOnSave.Checked));
        }

        private void DebugConsoleLauncher_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Launcher", "Console", INIFunctions.BoolToString(DebugConsoleLauncher.Checked));
        }

        private void LauncherRichPresence_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Launcher", "RichPresence", INIFunctions.BoolToString(LauncherRichPresence.Checked));
        }

        private void DefaultTab_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Launcher", "DefaultTab", DefaultTab.SelectedIndex.ToString());
        }

        // -- AUDIO OPTIONS -----------------------------

        private void StarPowerReverb_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Audio", "StarPowerReverb", INIFunctions.BoolToString(StarPowerReverb.Checked));
        }

        private void SPClapType_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Audio", "SPClapType", INIFunctions.InterpretINISetting(SPClapType.Text,
                new string[] {
                    "Default (Per Venue)",
                    "Small, Interior",
                    "Medium, Interior",
                    "Medium, Exterior",
                    "Large, Exterior",
                    "No Claps"
                },

                new string[] {
                    "default",
                    "small_int",
                    "medium_int",
                    "medium_ext",
                    "large_ext",
                    "none"
                })
            );
        }

        private void SPActivationSFX_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Audio", "SPActivationSFX", INIFunctions.InterpretINISetting(SPActivationSFX.Text,
                V3LauncherConstants.StarPowerActivationSounds[0], V3LauncherConstants.StarPowerActivationSounds[1]));
        }

        private void AudioBuffLen_SelectedIndexChanged(object sender, EventArgs e) {
            XMLFunctions.AspyrWriteString("Audio.BuffLen", AudioBuffLen.Text);
        }

        // -- EXTRA OPTIONS -----------------------------

        private void DefaultSetlistSortIndex_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "DefaultSetlistSortIndex", DefaultSetlistSortIndex.SelectedIndex.ToString());
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
        // INPUT TAB AUTO UPDATE
        // ----------------------------------------------------------
        #region Input Tab Auto Update
        private void MicrophoneSelect_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Audio", "MicDevice", MicrophoneSelect.Text);
        }

        private void DeleteWTDEInputINI_Click(object sender, EventArgs e) {
            if (File.Exists(V3LauncherConstants.WTDEInputConfigDir)) {
                string inputResetWarning = "Are you sure you want to reset your SDL controller mappings?\n" +
                                           "This cannot be undone!";

                if (MessageBox.Show(inputResetWarning, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    File.Delete(V3LauncherConstants.WTDEInputConfigDir);
                }
            }
        }

        private void DisableInputHack_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Debug", "DisableInputHack", INIFunctions.BoolToString(DisableInputHack.Checked));
        }

        private void MicAudioDelay_ValueChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Audio", "VocalAdjustment", MicAudioDelay.Value.ToString());
        }

        private void MicVideoDelay_ValueChanged(object sender, EventArgs e) {
            XMLFunctions.AspyrWriteString("Options.VocalsVisualLag", MicVideoDelay.Value.ToString());
        }

        private void SetDefaultVoxLag_Click(object sender, EventArgs e) {
            MicAudioDelay.Value = -80;
            MicVideoDelay.Value = -315;

            INIFunctions.SaveINIValue("Audio", "VocalAdjustment", MicAudioDelay.Value.ToString());
            XMLFunctions.AspyrWriteString("Options.VocalsVisualLag", MicVideoDelay.Value.ToString());
        }

        /// <summary>
        ///  Makes sure there are no matching inputs across both strums and frets.
        /// </summary>
        /// <param name="strums"></param>
        /// <param name="frets"></param>
        /// <returns></returns>
        private bool VerifyNoAutoStrum(string strums, string frets) {
            string[] fretInputs = frets.Split(' ');
            string[] strumInputs = strums.Split(' ');

            foreach (string fi in fretInputs) {
                foreach (string si in strumInputs) {
                    if (fi.Trim().ToUpper() == si.Trim().ToUpper()) return false;
                }
            }

            return true;
        }

        /// <summary>
        ///  Saves the user's defined key binds as Aspyr formatted key bindings!
        ///  <br/>
        ///  Has measures in place to prevent auto strum workarounds.
        /// </summary>
        public void SaveKeyBinds() {
            // No more auto strum workarounds. Cry about it; I don't care.
            if (!(VerifyNoAutoStrum(GuitarGreenInputs.Text, GuitarUpInputs.Text) &&
                  VerifyNoAutoStrum(GuitarGreenInputs.Text, GuitarDownInputs.Text) &&
                  VerifyNoAutoStrum(GuitarRedInputs.Text, GuitarUpInputs.Text) &&
                  VerifyNoAutoStrum(GuitarRedInputs.Text, GuitarDownInputs.Text) &&
                  VerifyNoAutoStrum(GuitarYellowInputs.Text, GuitarUpInputs.Text) &&
                  VerifyNoAutoStrum(GuitarYellowInputs.Text, GuitarDownInputs.Text) &&
                  VerifyNoAutoStrum(GuitarBlueInputs.Text, GuitarUpInputs.Text) &&
                  VerifyNoAutoStrum(GuitarBlueInputs.Text, GuitarDownInputs.Text) &&
                  VerifyNoAutoStrum(GuitarOrangeInputs.Text, GuitarUpInputs.Text) &&
                  VerifyNoAutoStrum(GuitarOrangeInputs.Text, GuitarDownInputs.Text))) {

                MessageBox.Show("You cannot map strums and frets to the same inputs. Auto strum is not supported.",
                                "Invalid Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // -- GUITAR INPUTS ----------------------
            V3LauncherCore.AspyrKeyEncode(
                new List<string> {
                    GuitarGreenInputs.Text,
                    GuitarRedInputs.Text,
                    GuitarYellowInputs.Text,
                    GuitarBlueInputs.Text,
                    GuitarOrangeInputs.Text,
                    GuitarStartInputs.Text,
                    GuitarSelectInputs.Text,
                    GuitarWhammyInputs.Text,
                    GuitarStarPowerInputs.Text,
                    GuitarCancelInputs.Text,
                    GuitarUpInputs.Text,
                    GuitarDownInputs.Text,
                    GuitarLeftInputs.Text,
                    GuitarRightInputs.Text,
                },

                new List<string> {
                    "GREEN", "RED", "YELLOW", "BLUE", "ORANGE", "START", "BACK",
                    "WHAMMY", "STAR", "CANCEL", "UP", "DOWN", "LEFT", "RIGHT"
                },

                "Keyboard_Guitar"
            );

            // -- DRUM INPUTS ----------------------
            V3LauncherCore.AspyrKeyEncode(
                new List<string> {
                    DrumRedInputs.Text,
                    DrumYellowInputs.Text,
                    DrumBlueInputs.Text,
                    DrumOrangeInputs.Text,
                    DrumGreenInputs.Text,
                    DrumKickInputs.Text,
                    DrumStartInputs.Text,
                    DrumSelectInputs.Text,
                    DrumCancelInputs.Text,
                    DrumUpInputs.Text,
                    DrumDownInputs.Text
                },

                new List<string> {
                    "RED", "YELLOW", "BLUE", "ORANGE", "GREEN", "KICK", "START",
                    "BACK", "CANCEL", "UP", "DOWN"
                },

                "Keyboard_Drum"
            );

            // -- MIC INPUTS ----------------------
            V3LauncherCore.AspyrKeyEncode(
                new List<string> {
                    MicGreenInputs.Text,
                    MicRedInputs.Text,
                    MicYellowInputs.Text,
                    MicBlueInputs.Text,
                    MicOrangeInputs.Text,
                    MicStartInputs.Text,
                    MicSelectInputs.Text,
                    MicCancelInputs.Text,
                    MicUpInputs.Text,
                    MicDownInputs.Text,
                    "-"
                },

                new List<string> {
                    "GREEN", "RED", "YELLOW", "BLUE", "ORANGE", "START",
                    "BACK", "CANCEL", "UP", "DOWN", "MIC_VOL_DOWN"
                },

                "Keyboard_Mic"
            );

            // -- MENU INPUTS ----------------------
            V3LauncherCore.AspyrKeyEncode(
                new List<string> {
                    MenuGreenInputs.Text,
                    MenuRedInputs.Text,
                    MenuYellowInputs.Text,
                    MenuBlueInputs.Text,
                    MenuOrangeInputs.Text,
                    MenuKickInputs.Text,
                    MenuWhammyInputs.Text,
                    MenuStartInputs.Text,
                    MenuSelectInputs.Text,
                    MenuCancelInputs.Text,
                    MenuUpInputs.Text,
                    MenuDownInputs.Text,
                    MenuLeftInputs.Text,
                    MenuRightInputs.Text
                },

                new List<string> {
                    "GREEN", "RED", "YELLOW", "BLUE", "ORANGE", "KICK", "WHAMMY", "START",
                    "BACK", "CANCEL", "UP", "DOWN", "LEFT", "RIGHT"
                },

                "Keyboard_Menu"
            );
        }

        private void SaveKeybindsButton_Click(object sender, EventArgs e) {
            SaveKeyBinds();
        }

        private void ResetKeybindsButton_Click(object sender, EventArgs e) {
            string resetKeysWarning = "Are you sure you want to reset your keyboard bindings to the default?\n\nThis cannot be undone!";

            if (MessageBox.Show(resetKeysWarning, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                XMLFunctions.AspyrWriteString("Keyboard_Guitar", V3LauncherConstants.ASPYR_INPUT_GUITAR_DEFAULT);
                XMLFunctions.AspyrWriteString("Keyboard_Drum", V3LauncherConstants.ASPYR_INPUT_DRUMS_BACKUP);
                XMLFunctions.AspyrWriteString("Keyboard_Mic", V3LauncherConstants.ASPYR_INPUT_MIC_BACKUP);
                XMLFunctions.AspyrWriteString("Keyboard_Menu", V3LauncherConstants.ASPYR_INPUT_MENU_BACKUP);

                LoadINISettings();

            }

        }

        /// <summary>
        ///  Insert a new input into the provided label. Brings an on-screen
        ///  keyboard for the user to select an input.
        /// </summary>
        /// <param name="label"></param>
        public void AddInputKey(Label label) {
            InputKeySelector iks = new InputKeySelector(label);
            iks.ShowDialog();
        }

        // - - - - - - - - - - - - - - - - - - -
        //  G U I T A R     I N P U T S
        // - - - - - - - - - - - - - - - - - - -
        #region Guitar Inputs
        private void AddGtrGreenInput_Click(object sender, EventArgs e) {
            AddInputKey(GuitarGreenInputs);
        }

        private void ClearGtrGreenInputs_Click(object sender, EventArgs e) {
            GuitarGreenInputs.Text = "";
        }

        private void AddGtrRedInput_Click(object sender, EventArgs e) {
            AddInputKey(GuitarRedInputs);
        }

        private void ClearGtrRedInputs_Click(object sender, EventArgs e) {
            GuitarRedInputs.Text = "";
        }

        private void AddGtrYellowInput_Click(object sender, EventArgs e) {
            AddInputKey(GuitarYellowInputs);
        }

        private void ClearGtrYellowInputs_Click(object sender, EventArgs e) {
            GuitarYellowInputs.Text = "";
        }

        private void AddGtrBlueInput_Click(object sender, EventArgs e) {
            AddInputKey(GuitarBlueInputs);
        }

        private void ClearGtrBlueInputs_Click(object sender, EventArgs e) {
            GuitarBlueInputs.Text = "";
        }

        private void AddGtrOrangeInput_Click(object sender, EventArgs e) {
            AddInputKey(GuitarOrangeInputs);
        }

        private void ClearGtrOrangeInputs_Click(object sender, EventArgs e) {
            GuitarOrangeInputs.Text = "";
        }

        private void AddGtrStartInput_Click(object sender, EventArgs e) {
            AddInputKey(GuitarStartInputs);
        }

        private void ClearGtrStartInputs_Click(object sender, EventArgs e) {
            GuitarStartInputs.Text = "";
        }

        private void AddGtrSelectInput_Click(object sender, EventArgs e) {
            AddInputKey(GuitarSelectInputs);
        }

        private void ClearGtrSelectInputs_Click(object sender, EventArgs e) {
            GuitarSelectInputs.Text = "";
        }

        private void AddGtrWhammyInput_Click(object sender, EventArgs e) {
            AddInputKey(GuitarWhammyInputs);
        }

        private void ClearGtrWhammyInputs_Click(object sender, EventArgs e) {
            GuitarWhammyInputs.Text = "";
        }

        private void AddGtrStarPowerInput_Click(object sender, EventArgs e) {
            AddInputKey(GuitarStarPowerInputs);
        }

        private void ClearGtrStarPowerInputs_Click(object sender, EventArgs e) {
            GuitarStarPowerInputs.Text = "";
        }

        private void AddGtrCancelInput_Click(object sender, EventArgs e) {
            AddInputKey(GuitarCancelInputs);
        }

        private void ClearGtrCancelInputs_Click(object sender, EventArgs e) {
            GuitarCancelInputs.Text = "";
        }

        private void AddGtrUpInput_Click(object sender, EventArgs e) {
            AddInputKey(GuitarUpInputs);
        }

        private void ClearGtrUpInputs_Click(object sender, EventArgs e) {
            GuitarUpInputs.Text = "";
        }

        private void AddGtrDownInput_Click(object sender, EventArgs e) {
            AddInputKey(GuitarDownInputs);
        }

        private void ClearGtrDownInputs_Click(object sender, EventArgs e) {
            GuitarDownInputs.Text = "";
        }
        #endregion

        // - - - - - - - - - - - - - - - - - - -
        //  D R U M     I N P U T S
        // - - - - - - - - - - - - - - - - - - -
        #region Drum Inputs
        private void AddDrmRedInput_Click(object sender, EventArgs e) {
            AddInputKey(DrumRedInputs);
        }

        private void ClearDrmRedInputs_Click(object sender, EventArgs e) {
            DrumRedInputs.Text = "";
        }

        private void AddDrmYellowInput_Click(object sender, EventArgs e) {
            AddInputKey(DrumYellowInputs);
        }

        private void ClearDrmYellowInputs_Click(object sender, EventArgs e) {
            DrumYellowInputs.Text = "";
        }

        private void AddDrmBlueInput_Click(object sender, EventArgs e) {
            AddInputKey(DrumBlueInputs);
        }

        private void ClearDrmBlueInputs_Click(object sender, EventArgs e) {
            DrumBlueInputs.Text = "";
        }

        private void AddDrmOrangeInput_Click(object sender, EventArgs e) {
            AddInputKey(DrumOrangeInputs);
        }

        private void button19_Click(object sender, EventArgs e) {
            DrumOrangeInputs.Text = "";
        }

        private void AddDrmGreenInput_Click(object sender, EventArgs e) {
            AddInputKey(DrumGreenInputs);
        }

        private void ClearDrmGreenInputs_Click(object sender, EventArgs e) {
            DrumGreenInputs.Text = "";
        }

        private void AddDrmKickInput_Click(object sender, EventArgs e) {
            AddInputKey(DrumKickInputs);
        }

        private void ClearDrmKickInputs_Click(object sender, EventArgs e) {
            DrumKickInputs.Text = "";
        }

        private void AddDrmStartInput_Click(object sender, EventArgs e) {
            AddInputKey(DrumStartInputs);
        }

        private void ClearDrmStartInputs_Click(object sender, EventArgs e) {
            DrumStartInputs.Text = "";
        }

        private void AddDrmSelectInput_Click(object sender, EventArgs e) {
            AddInputKey(DrumSelectInputs);
        }

        private void ClearDrmSelectInputs_Click(object sender, EventArgs e) {
            DrumSelectInputs.Text = "";
        }

        private void AddDrmCancelInput_Click(object sender, EventArgs e) {
            AddInputKey(DrumCancelInputs);
        }

        private void ClearDrmCancelInputs_Click(object sender, EventArgs e) {
            DrumCancelInputs.Text = "";
        }

        private void AddDrmUpInput_Click(object sender, EventArgs e) {
            AddInputKey(DrumUpInputs);
        }

        private void ClearDrmUpInputs_Click(object sender, EventArgs e) {
            DrumUpInputs.Text = "";
        }

        private void AddDrmDownInput_Click(object sender, EventArgs e) {
            AddInputKey(DrumDownInputs);
        }

        private void ClearDrmDownInputs_Click(object sender, EventArgs e) {
            DrumDownInputs.Text = "";
        }
        #endregion
         
        // - - - - - - - - - - - - - - - - - - -
        //  M I C     I N P U T S
        // - - - - - - - - - - - - - - - - - - -
        #region Mic Inputs
        private void AddMicGreenInput_Click(object sender, EventArgs e) {
            AddInputKey(MicGreenInputs);
        }

        private void ClearMicGreenInputs_Click(object sender, EventArgs e) {
            MicGreenInputs.Text = "";
        }

        private void AddMicRedInput_Click(object sender, EventArgs e) {
            AddInputKey(MicRedInputs);
        }

        private void ClearMicRedInputs_Click(object sender, EventArgs e) {
            MicRedInputs.Text = "";
        }

        private void AddMicYellowInput_Click(object sender, EventArgs e) {
            AddInputKey(MicYellowInputs);
        }

        private void ClearMicYellowInputs_Click(object sender, EventArgs e) {
            MicYellowInputs.Text = "";
        }

        private void AddMicBlueInput_Click(object sender, EventArgs e) {
            AddInputKey(MicBlueInputs);
        }

        private void ClearMicBlueInputs_Click(object sender, EventArgs e) {
            MicBlueInputs.Text = "";
        }

        private void AddMicOrangeInput_Click(object sender, EventArgs e) {
            AddInputKey(MicOrangeInputs);
        }

        private void ClearMicOrangeInputs_Click(object sender, EventArgs e) {
            MicOrangeInputs.Text = "";
        }

        private void AddMicStartInput_Click(object sender, EventArgs e) {
            AddInputKey(MicStartInputs);
        }

        private void ClearMicStartInputs_Click(object sender, EventArgs e) {
            MicStartInputs.Text = "";
        }

        private void AddMicSelectInput_Click(object sender, EventArgs e) {
            AddInputKey(MicSelectInputs);
        }

        private void ClearMicSelectInputs_Click(object sender, EventArgs e) {
            MicSelectInputs.Text = "";
        }

        private void AddMicCancelInput_Click(object sender, EventArgs e) {
            AddInputKey(MicCancelInputs);
        }

        private void ClearMicCancelInputs_Click(object sender, EventArgs e) {
            MicCancelInputs.Text = "";
        }

        private void AddMicUpInput_Click(object sender, EventArgs e) {
            AddInputKey(MicUpInputs);
        }

        private void ClearMicUpInputs_Click(object sender, EventArgs e) {
            MicUpInputs.Text = "";
        }

        private void AddMicDownInput_Click(object sender, EventArgs e) {
            AddInputKey(MicDownInputs);
        }

        private void ClearMicDownInputs_Click(object sender, EventArgs e) {
            MicDownInputs.Text = "";
        }
        #endregion

        // - - - - - - - - - - - - - - - - - - -
        //  M E N U     I N P U T S
        // - - - - - - - - - - - - - - - - - - -
        #region Menu Inputs
        private void AddMenuGreenInput_Click(object sender, EventArgs e) {
            AddInputKey(MenuGreenInputs);
        }

        private void ClearMenuGreenInputs_Click(object sender, EventArgs e) {
            MenuGreenInputs.Text = "";
        }

        private void AddMenuRedInput_Click(object sender, EventArgs e) {
            AddInputKey(MenuRedInputs);
        }

        private void ClearMenuRedInputs_Click(object sender, EventArgs e) {
            MenuRedInputs.Text = "";
        }

        private void AddMenuYellowInput_Click(object sender, EventArgs e) {
            AddInputKey(MenuYellowInputs);
        }

        private void ClearMenuYellowInputs_Click(object sender, EventArgs e) {
            MenuYellowInputs.Text = "";
        }

        private void AddMenuBlueInput_Click(object sender, EventArgs e) {
            AddInputKey(MenuBlueInputs);
        }

        private void ClearMenuBlueInputs_Click(object sender, EventArgs e) {
            MenuBlueInputs.Text = "";
        }

        private void AddMenuOrangeInput_Click(object sender, EventArgs e) {
            AddInputKey(MenuOrangeInputs);
        }

        private void ClearMenuOrangeInputs_Click(object sender, EventArgs e) {
            MenuOrangeInputs.Text = "";
        }

        private void AddMenuKickInput_Click(object sender, EventArgs e) {
            AddInputKey(MenuKickInputs);
        }

        private void ClearMenuKickInputs_Click(object sender, EventArgs e) {
            MenuKickInputs.Text = "";
        }

        private void AddMenuWhammyInput_Click(object sender, EventArgs e) {
            AddInputKey(MenuWhammyInputs);
        }

        private void ClearMenuWhammyInputs_Click(object sender, EventArgs e) {
            MenuWhammyInputs.Text = "";
        }

        private void AddMenuStartInput_Click(object sender, EventArgs e) {
            AddInputKey(MenuStartInputs);
        }

        private void ClearMenuStartInputs_Click(object sender, EventArgs e) {
            MenuStartInputs.Text = "";
        }

        private void AddMenuSelectInput_Click(object sender, EventArgs e) {
            AddInputKey(MenuSelectInputs);
        }

        private void ClearMenuSelectInputs_Click(object sender, EventArgs e) {
            MenuSelectInputs.Text = "";
        }

        private void AddMenuCancelInput_Click(object sender, EventArgs e) {
            AddInputKey(MenuCancelInputs);
        }

        private void ClearMenuCancelInputs_Click(object sender, EventArgs e) {
            MenuCancelInputs.Text = "";
        }

        private void AddMenuUpInput_Click(object sender, EventArgs e) {
            AddInputKey(MenuUpInputs);
        }

        private void ClearMenuUpInputs_Click(object sender, EventArgs e) {
            MenuUpInputs.Text = "";
        }

        private void AddMenuDownInput_Click(object sender, EventArgs e) {
            AddInputKey(MenuDownInputs);
        }

        private void ClearMenuDownInputs_Click(object sender, EventArgs e) {
            MenuDownInputs.Text = "";
        }

        private void AddMenuLeftInput_Click(object sender, EventArgs e) {
            AddInputKey(MenuLeftInputs);
        }

        private void ClearMenuLeftInputs_Click(object sender, EventArgs e) {
            MenuLeftInputs.Text = "";
        }

        private void AddMenuRightInput_Click(object sender, EventArgs e) {
            AddInputKey(MenuRightInputs);
        }

        private void ClearMenuRightInputs_Click(object sender, EventArgs e) {
            MenuRightInputs.Text = "";
        }
        #endregion

        #endregion
        
        // ----------------------------------------------------------
        // GRAPHICS TAB AUTO UPDATE
        // ----------------------------------------------------------
        #region Graphics Tab Auto Update
        // - - - - - - - - - - - - - - - - - - -
        //  B A S I C     O P T I O N S
        // - - - - - - - - - - - - - - - - - - -
        #region Graphics Settings: Basic Options
        private void VideoWidth_ValueChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "ResolutionX", VideoWidth.Value.ToString());
        }

        private void VideoHeight_ValueChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "ResolutionY", VideoHeight.Value.ToString());
        }

        private void FPSLimit_ValueChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "FPSLimit", FPSLimit.Value.ToString());
        }

        private void DisableVSync_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "DisableVSync", INIFunctions.BoolToStringInverse(DisableVSync.Checked));
        }

        private void WindowedMode_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "WindowedMode", INIFunctions.BoolToString(WindowedMode.Checked));
        }

        private void Borderless_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "Borderless", INIFunctions.BoolToString(Borderless.Checked));
        }

        private void HighDetail_CheckedChanged(object sender, EventArgs e) {
            if (HighDetail.Checked) {
                XMLFunctions.AspyrWriteString("Options.GraphicsQuality", "0");
                XMLFunctions.AspyrWriteString("Options.UseLOD", "0");
                XMLFunctions.AspyrWriteString("Options.Flares", "1");
            } else {
                XMLFunctions.AspyrWriteString("Options.GraphicsQuality", "1");
                XMLFunctions.AspyrWriteString("Options.UseLOD", "1");
                XMLFunctions.AspyrWriteString("Options.Flares", "0");
            }
        }

        #endregion

        // - - - - - - - - - - - - - - - - - - -
        //  G A M E P L A Y     O P T I O N S
        // - - - - - - - - - - - - - - - - - - -
        #region Graphics Settings: Gameplay Options
        private void HitSparks_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "HitSparks", INIFunctions.BoolToString(HitSparks.Checked));
        }

        private void BlackStage_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "BlackStage", INIFunctions.BoolToString(BlackStage.Checked));
        }

        private void HideBand_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "HideBand", INIFunctions.BoolToString(HideBand.Checked));
        }

        private void HideInstruments_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "HideInstruments", INIFunctions.BoolToString(HideInstruments.Checked));
        }

        private void HandFlames_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "HandFlames", INIFunctions.BoolToString(HandFlames.Checked));
        }

        private void SpecialStarPowerFX_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "SpecialStarPowerFX", INIFunctions.BoolToString(SpecialStarPowerFX.Checked));
        }

        private void TeslaFX_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "TeslaFX", INIFunctions.BoolToString(TeslaFX.Checked));
        }

        private void SoloMarkers_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "SoloMarkers", INIFunctions.BoolToString(SoloMarkers.Checked));
        }

        private void OptionsPhysics_CheckedChanged(object sender, EventArgs e) {
            XMLFunctions.AspyrWriteString("Options.Physics", INIFunctions.BoolToString(OptionsPhysics.Checked));
        }

        private void OptionsFrontRowCamera_CheckedChanged(object sender, EventArgs e) {
            XMLFunctions.AspyrWriteString("Options.FrontRowCamera", INIFunctions.BoolToString(OptionsFrontRowCamera.Checked));
        }

        private void OptionsCrowd_SelectedIndexChanged(object sender, EventArgs e) {
            XMLFunctions.AspyrWriteString("Options.Crowd", OptionsCrowd.SelectedIndex.ToString());
        }

        private void X360Zones_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "X360Zones", INIFunctions.BoolToString(X360Zones.Checked));
        }

        private void RandomTrainingVenues_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "RandomTrainingVenues", INIFunctions.BoolToString(RandomTrainingVenues.Checked));
        }

        private void FastWin_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "FastWin", INIFunctions.BoolToString(FastWin.Checked));
        }

        private void FastStart_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "FastStart", INIFunctions.BoolToString(FastStart.Checked));
        }

        private void FastLose_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "FastLose", INIFunctions.BoolToString(FastLose.Checked));
        }

        private void FlawlessOnly_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "FlawlessOnly", INIFunctions.BoolToString(FlawlessOnly.Checked));
        }

        private void FocusedHighway_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "FocusedHighway", INIFunctions.BoolToString(FocusedHighway.Checked));
        }

        private void BadTripMode_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "BadTripMode", INIFunctions.BoolToString(BadTripMode.Checked));
        }

        private void DrunkMode_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "DrunkMode", INIFunctions.BoolToString(DrunkMode.Checked));
        }
        #endregion

        // - - - - - - - - - - - - - - - - - - -
        //  I N T E R F A C E     O P T I O N S
        // - - - - - - - - - - - - - - - - - - -
        #region Graphics Settings: Interface Options
        private void GemTheme_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "GemTheme", INIFunctions.InterpretINISetting(GemTheme.Text,
                V3LauncherConstants.NoteStyles[0].ToArray(), V3LauncherConstants.NoteStyles[1].ToArray()));
        }

        private void GemColors_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "GemColors", INIFunctions.InterpretINISetting(GemColors.Text,
                V3LauncherConstants.NoteThemeColors[0].ToArray(), V3LauncherConstants.NoteThemeColors[1].ToArray()));
        }

        private void GemColors_TextUpdate(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "GemColors", GemColors.Text);
        }

        private void SongIntroStyle_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "SongIntroStyle", INIFunctions.InterpretINISetting(SongIntroStyle.Text,
                V3LauncherConstants.IntroStyles[0].ToArray(), V3LauncherConstants.IntroStyles[1].ToArray()));
        }

        private void LoadingTheme_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "LoadingTheme", INIFunctions.InterpretINISetting(LoadingTheme.Text,
                V3LauncherConstants.LoadScreenThemes[0].ToArray(), V3LauncherConstants.LoadScreenThemes[1].ToArray()));
        }

        private void HUDTheme_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "HUDTheme", INIFunctions.InterpretINISetting(HUDTheme.Text,
                V3LauncherConstants.HUDThemes[0].ToArray(), V3LauncherConstants.HUDThemes[1].ToArray()));
        }

        private void TrainingScore_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "TrainingScore", INIFunctions.BoolToString(TrainingScore.Checked));
        }

        private void AttackIconTheme_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "AttackIconTheme", INIFunctions.InterpretINISetting(AttackIconTheme.Text,
                new string[] { "GH: World Tour (Default)", "Guitar Hero III", "Guitar Hero: Metallica" },
                new string[] { "ghwt", "gh3", "ghm" }));
        }

        private void YouRockTheme_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "YouRockTheme", INIFunctions.InterpretINISetting(YouRockTheme.Text,
                V3LauncherConstants.YouRockThemes[0].ToArray(), V3LauncherConstants.YouRockThemes[1].ToArray()));
        }

        private void PauseTheme_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "PauseTheme", INIFunctions.InterpretINISetting(PauseTheme.Text,
                V3LauncherConstants.PauseMenuThemes[0].ToArray(), V3LauncherConstants.PauseMenuThemes[1].ToArray()));
        }

        private void TrainingSectionFont_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "TrainingSectionFont", INIFunctions.InterpretINISetting(TrainingSectionFont.Text,
                V3LauncherConstants.TrainingSectionThemes[0], V3LauncherConstants.TrainingSectionThemes[1]));
        }

        private void TrainingAccuracy_SelectedIndexChanged(object sender, EventArgs e)
        {
            INIFunctions.SaveINIValue("Graphics", "TrainingAccuracy", TrainingAccuracy.SelectedIndex.ToString());
        }

        private void HelperPillTheme_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "HelperPillTheme", INIFunctions.InterpretINISetting(HelperPillTheme.Text,
                V3LauncherConstants.HelperPillThemes[0].ToArray(), V3LauncherConstants.HelperPillThemes[1].ToArray()));
        }

        private void TapTrailTheme_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "TapTrailTheme", INIFunctions.InterpretINISetting(TapTrailTheme.Text,
                V3LauncherConstants.TapTrailThemes[0].ToArray(), V3LauncherConstants.TapTrailThemes[1].ToArray()));
        }

        private void HitFlameTheme_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "HitFlameTheme", INIFunctions.InterpretINISetting(HitFlameTheme.Text,
                V3LauncherConstants.HitFlameStyles[0].ToArray(), V3LauncherConstants.HitFlameStyles[1].ToArray()));
        }

        private void SustainFX_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "SustainFX", INIFunctions.BoolToString(SustainFX.Checked));
        }

        private void HighwayOpacity_ValueChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "HighwayOpacity", HighwayOpacity.Value.ToString());
        }

        private void BlackHighway_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "BlackHighway", INIFunctions.BoolToString(BlackHighway.Checked));
        }

        private void HighwayVignetteOpacity_ValueChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "HighwayVignetteOpacity", HighwayVignetteOpacity.Value.ToString());
        }

        private void ShowAllSPBulbs_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "ShowAllSPBulbs", INIFunctions.BoolToString(ShowAllSPBulbs.Checked));
        }
        #endregion

        // - - - - - - - - - - - - - - - - - - -
        //  A D V A N C E D     G R A P H I C S
        // - - - - - - - - - - - - - - - - - - -
        #region Graphics Settings: Advanced Graphics
        private void DisableDOF_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "DisableDOF", INIFunctions.BoolToStringInverse(DisableDOF.Checked));
        }

        private void DisableBloom_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "DisableBloom", INIFunctions.BoolToStringInverse(DisableBloom.Checked));
        }

        private void ColorFilters_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "ColorFilters", INIFunctions.BoolToString(ColorFilters.Checked));
        }

        private void RenderParticles_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "RenderParticles", INIFunctions.BoolToString(RenderParticles.Checked));
        }

        private void RenderGeoms_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "RenderGeoms", INIFunctions.BoolToString(RenderGeoms.Checked));
        }

        private void RenderInstances_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "RenderInstances", INIFunctions.BoolToString(RenderInstances.Checked));
        }

        private void DrawProjectors_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "DrawProjectors", INIFunctions.BoolToString(DrawProjectors.Checked));
        }

        private void Render2D_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "Render2D", INIFunctions.BoolToString(Render2D.Checked));
        }

        private void RenderScreenFX_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "RenderScreenFX", INIFunctions.BoolToString(RenderScreenFX.Checked));
        }

        private void RenderFog_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "RenderFog", INIFunctions.BoolToString(RenderFog.Checked));
        }

        private void ApplyBandName_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "ApplyBandName", INIFunctions.BoolToString(ApplyBandName.Checked));
        }

        private void ApplyBandLogo_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "ApplyBandLogo", INIFunctions.BoolToString(ApplyBandLogo.Checked));
        }

        private void EnableCamPulse_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "EnableCamPulse", INIFunctions.BoolToString(EnableCamPulse.Checked));
        }

        private void DefaultTODProfile_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "DefaultTODProfile", INIFunctions.InterpretINISetting(DefaultTODProfile.Text,
                V3LauncherConstants.TODProfiles[0].ToArray(), V3LauncherConstants.TODProfiles[1].ToArray()));
        }

        private void DOFQuality_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "DOFQuality", DOFQuality.SelectedIndex.ToString());
        }

        private void DOFBlur_ValueChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "DOFBlur", DOFBlur.Value.ToString());
        }

        private void FlareStyle_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "FlareStyle", INIFunctions.InterpretINISetting(FlareStyle.Text,
                V3LauncherConstants.FlareStyles[0].ToArray(), V3LauncherConstants.FlareStyles[1].ToArray()));
        }

        private void HavokFPS_ValueChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Graphics", "HavokFPS", HavokFPS.Value.ToString());
        }
        #endregion
        #endregion

        // ----------------------------------------------------------
        // BAND TAB AUTO UPDATE
        // ----------------------------------------------------------
        #region Band Tab Auto Update

        /// <summary>
        ///  Save a band profile layout to a text file (*.deband).
        /// </summary>
        public void SaveBandProfile() {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Band Profile Layout";
            sfd.Filter = "WTDE Band Profile|*.deband";
            sfd.ShowDialog();

            if (sfd.FileName != "") {
                string bandName = Path.GetFileNameWithoutExtension(sfd.FileName);

                using (StreamWriter sw = new StreamWriter(sfd.FileName)) {
                    sw.WriteLine("; ------------------------------");
                    sw.WriteLine($";  {bandName.ToUpper().Replace('_', ' ').Replace('-', ' ')} BAND PROFILE");
                    sw.WriteLine(";    Auto generated by WTDE Launcher V3");
                    sw.WriteLine("; ------------------------------\n");

                    sw.Write("[BandProfile]\n" +
                            $"Guitarist={PreferredGuitarist.Text}\n" +
                            $"Bassist={PreferredBassist.Text}\n" +
                            $"Drummer={PreferredDrummer.Text}\n" +
                            $"MaleVocalist={PreferredSinger.Text}\n" +
                            $"FemaleVocalist={PreferredFemaleSinger.Text}\n" +
                            $"Stage={PreferredStage.Text}\n" +
                            $"TrainingStage={PreferredTrainingStage.Text}\n");

                    sw.WriteLine("; ------------------------------\n");

                    sw.Write($"HighwayG={PreferredGuitaristHighway.Text}\n" +
                             $"HighwayB={PreferredBassistHighway.Text}\n" +
                             $"HighwayD={PreferredDrummerHighway.Text}");
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - -
        
        /// <summary>
        ///  Loads a band profile from a *.deband file!
        /// </summary>
        public void LoadBandProfile() {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Import Band Profile Layout";
            ofd.Filter = "WTDE Band Profile|*.deband";
            ofd.ShowDialog();

            if (ofd.FileName != "") {
                try {
                    INI file = new INI(ofd.FileName);

                    PreferredGuitarist.Text = file.GetString("BandProfile", "Guitarist");
                    PreferredBassist.Text = file.GetString("BandProfile", "Bassist");
                    PreferredDrummer.Text = file.GetString("BandProfile", "Drummer");
                    PreferredSinger.Text = file.GetString("BandProfile", "MaleVocalist");
                    PreferredFemaleSinger.Text = file.GetString("BandProfile", "FemaleVocalist");
                    PreferredStage.Text = file.GetString("BandProfile", "Stage");
                    PreferredTrainingStage.Text = file.GetString("BandProfile", "TrainingStage");

                    // - - - - - - -

                    PreferredGuitaristHighway.Text = file.GetString("BandProfile", "HighwayG");
                    PreferredBassistHighway.Text = file.GetString("BandProfile", "HighwayB");
                    PreferredDrummerHighway.Text = file.GetString("BandProfile", "HighwayD");

                } catch (Exception exc) {
                    V3LauncherCore.AddDebugEntry($"Error importing band profile: {exc.Message}", "Band Profile Import");
                    MessageBox.Show($"Uh oh! An error occurred in importing the file:\n{exc.Message}", "Error Importing Band", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - -
        //  P R E F E R R E D     B A N D
        // - - - - - - - - - - - - - - - - - - -

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

        private void PreferredFemaleSinger_TextChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "PreferredFemaleSinger", PreferredFemaleSinger.Text);
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
                V3LauncherConstants.VenueIDs[0].ToArray(), V3LauncherConstants.VenueIDs[1].ToArray()));
        }

        private void PreferredTrainingStage_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "PreferredTrainingStage", INIFunctions.InterpretINISetting(PreferredTrainingStage.Text,
                V3LauncherConstants.VenueIDs[0], V3LauncherConstants.VenueIDs[1]));
        }

        private void ReplaceSpecialBands_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "ReplaceSpecialBands", INIFunctions.BoolToString(ReplaceSpecialBands.Checked));
        }

        private void SongSpecificInstruments_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Config", "SongSpecificInstruments", INIFunctions.BoolToString(SongSpecificInstruments.Checked));
        }

        // - - - - - - - - - - - - - - - - - - -
        //  S T R U M     A N I M A T I O N S
        // - - - - - - - - - - - - - - - - - - -

        private void GuitarStrumAnim_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "GuitarStrumAnim", INIFunctions.InterpretINISetting(GuitarStrumAnim.Text,
                new string[] { "GH: World Tour (Default)", "Guitar Hero: Metallica" }, new string[] { "none", "ghm" }));
        }

        private void BassStrumAnim_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "BassStrumAnim", INIFunctions.InterpretINISetting(BassStrumAnim.Text,
                new string[] { "GH: World Tour (Default)", "Guitar Hero: Metallica" }, new string[] { "none", "ghm" }));
        }

        private void SaveBandProfButton_Click(object sender, EventArgs e) {
            SaveBandProfile();
        }

        private void LoadBandProfButton_Click(object sender, EventArgs e) {
            LoadBandProfile();
        }

        // - - - - - - - - - - - - - - - - - - -
        //  C H A R A C T E R     S E L E C T S
        // - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  An enumeration of band member names.
        /// </summary>
        public enum BandMembers {
            /// <summary>
            ///  The guitarist.
            /// </summary>
            Guitarist = 0,
            /// <summary>
            ///  The bassist.
            /// </summary>
            Bassist = 1,
            /// <summary>
            ///  The drummer.   
            /// </summary>
            Drummer = 2,
            /// <summary>
            ///  The male vocalist.
            /// </summary>
            MaleVocalist = 3,
            /// <summary>
            ///  The female vocalist.
            /// </summary>
            FemaleVocalist = 4
        }

        /// <summary>
        ///  Handles changing a band member!
        /// </summary>
        /// <param name="sender">
        ///  The object that sent the event.
        /// </param>
        /// <param name="e">
        ///  The event arguments.
        /// </param>
        /// <param name="member">
        ///  The band member to take effect on.
        /// </param>
        public void HandleChangeBandMember(object sender, EventArgs e, BandMembers member) {
            // Make sure our event arguments are MouseEvent arguments!
            MouseEventArgs me = e as MouseEventArgs;

            Button btnSender = sender as Button;

            BandMemberChangeLastButton = btnSender.Name;

            // If we right clicked, show the context menu!
            if (me.Button == MouseButtons.Right) {
                Point belowButton = new Point(0, btnSender.Height);
                belowButton = btnSender.PointToScreen(belowButton);
                BandMemberChangeMenu.Show(belowButton);

            // Otherwise, we're just handling it regularly!
            } else {
                SpawnChangeBandMember(member);
            }

            // This is only temporary, but we'll disable change instruments
            // if we are using a built-in character.
            // This will be usable in the future, but disabled for now.
            //~ string nameOfMod = GetBandMemberTextBox(member).Text;
            //~ Console.WriteLine($"Name of mod: {nameOfMod}");
            //~ ChangeInstMenuItem.Enabled = ModHandler.ModExists(nameOfMod, ModHandler.ModProperty.Name);

            // Reload INI settings (in case we used the CAS manager).
            LoadINISettings();
        }
        
        /// <summary>
        ///  Get the text box ID of the given band member.
        /// </summary>
        /// <param name="member">
        ///  The band member type.
        /// </param>
        /// <returns>
        ///  The text box for the given band member.
        /// </returns>
        public TextBox GetBandMemberTextBox(BandMembers member) {
            // Based on our band member selection, we will modify a different text box.
            TextBox inTextBox;
            switch (member) {
                // -- GUITARIST
                // -- Also default case
                case BandMembers.Guitarist:
                default:
                    inTextBox = PreferredGuitarist;
                    break;

                // -- BASSIST
                case BandMembers.Bassist:
                    inTextBox = PreferredBassist;
                    break;

                // -- DRUMMER
                case BandMembers.Drummer:
                    inTextBox = PreferredDrummer;
                    break;

                // -- MALE VOCALIST
                case BandMembers.MaleVocalist:
                    inTextBox = PreferredSinger;
                    break;

                // -- FEMALE VOCALIST
                case BandMembers.FemaleVocalist:
                    inTextBox = PreferredFemaleSinger;
                    break;
            }

            return inTextBox;
        }

        /// <summary>
        ///  Actually handles changing band members!
        /// </summary>
        /// <param name="member">
        ///  The band member to change.
        /// </param>
        public void SpawnChangeBandMember(BandMembers member) {
            // Get the text box we want to change.
            TextBox inTextBox = GetBandMemberTextBox(member);

            // Show the dialog box!
            SelectCharacterMod scm = new SelectCharacterMod(inTextBox);
            scm.ShowDialog();
        }

        private void PrefGtrSelectChar_Click(object sender, EventArgs e) {
            HandleChangeBandMember(sender, e, BandMembers.Guitarist);
        }

        private void PrefBasSelectChar_Click(object sender, EventArgs e) {
            HandleChangeBandMember(sender, e, BandMembers.Bassist);
        }

        private void PrefDrmSelectChar_Click(object sender, EventArgs e) {
            HandleChangeBandMember(sender, e, BandMembers.Drummer);
        }

        private void PrefVoxSelectChar_Click(object sender, EventArgs e) {
            HandleChangeBandMember(sender, e, BandMembers.MaleVocalist);
        }

        private void PrefFVoxSelectChar_Click(object sender, EventArgs e) {
            HandleChangeBandMember(sender, e, BandMembers.FemaleVocalist);
        }

        // - - - - - - - - - - - - - - - - - - -
        //  H I G H W A Y     S E L E C T S
        // - - - - - - - - - - - - - - - - - - -

        private void PrefGtrHwySelectHwy_Click(object sender, EventArgs e) {
            SelectHighwayMod shm = new SelectHighwayMod(PreferredGuitaristHighway);
            shm.ShowDialog();
        }

        private void PrefBasHwySelectHwy_Click(object sender, EventArgs e) {
            SelectHighwayMod shm = new SelectHighwayMod(PreferredBassistHighway);
            shm.ShowDialog();
        }

        private void PrefDrmHwySelectHwy_Click(object sender, EventArgs e) {
            SelectHighwayMod shm = new SelectHighwayMod(PreferredDrummerHighway);
            shm.ShowDialog();
        }

        // - - - - - - - - - - - - - - - - - - -
        //  C E L E B R I T Y     I N T R O S
        // - - - - - - - - - - - - - - - - - - -

        private void SongSpecificIntros_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("CelebritiesIntros", "SongSpecificIntros", INIFunctions.BoolToString(SongSpecificIntros.Checked));
        }

        private void AlwaysSplashText_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("CelebritiesIntros", "AlwaysSplashText", INIFunctions.BoolToString(AlwaysSplashText.Checked));
        }

        private void AlwaysVOIntro_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("CelebritiesIntros", "AlwaysVOIntro", INIFunctions.BoolToString(AlwaysVOIntro.Checked));
        }

        private void AlwaysCelebIntro_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("CelebritiesIntros", "AlwaysCelebIntro", INIFunctions.BoolToString(AlwaysCelebIntro.Checked));
        }

        private void CustomFirstName_TextChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("CelebritiesIntros", "CustomFirstName", CustomFirstName.Text);
        }

        private void CustomLastName_TextChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("CelebritiesIntros", "CustomLastName", CustomLastName.Text);
        }

        #endregion

        // ----------------------------------------------------------
        // AUTO LAUNCH TAB AUTO UPDATE
        // ----------------------------------------------------------
        #region Auto Launch Tab Auto Update
        
        /// <summary>
        ///  Read the songs that are in the current auto launch rotation.
        /// </summary>
        public void GetAutoLaunchSongs() {
            // Clear the song list queue.
            AutoLaunchSongs.Clear();

            // Max of 20 songs! This is related to the in-game song limit.
            for (var i = 1; i <= 20; i++) {
                // The key to look for.
                string songKey = (i > 1) ? $"Song{i}" : "Song";

                // Add the string from the given song key.
                string valueFromKey = INIFunctions.GetINIValue("AutoLaunch", songKey, "").Trim();
                if (valueFromKey != "") AutoLaunchSongs.Add(valueFromKey);
            }
        }

        /// <summary>
        ///  Save the songs in the auto launch rotation to GHWTDE.ini.
        /// </summary>
        public void SaveAutoLaunchSongs() {
            // Clean the list out of empty entries.
            string[] writableSongs = (
                from song in AutoLaunchSongs
                where song.Trim() != ""
                select song
            ).ToArray();

            // If there were no entries, then just populate the song keys with nothing.
            if (AutoLaunchSongs.Count <= 0) {
                for (var i = 0; i < 20; i++) {
                    // The key that will be written to.
                    string songKey = (i > 0) ? $"Song{i + 1}" : "Song";

                    // Write the value!
                    INIFunctions.SaveINIValue("AutoLaunch", songKey, "");
                }

            // We had 1+ song(s), write it/them!
            } else {
                for (var i = 0; i < writableSongs.Length; i++) {
                    // If over 20, break out; we can't write any more songs!
                    if (i >= 20) break;

                    // The key that will be written to.
                    string songKey = (i > 0) ? $"Song{i + 1}" : "Song";

                    // Write the value!
                    INIFunctions.SaveINIValue("AutoLaunch", songKey, writableSongs[i]);
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        private void AutoLaunchEnabled_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Enabled", INIFunctions.BoolToString(AutoLaunchEnabled.Checked));
            TabALMainEditor.Enabled = AutoLaunchEnabled.Checked;
        }

        private void AutoLaunchPlayers_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Players", AutoLaunchPlayers.Text);
            // Update selectable player configs.
            switch (int.Parse(AutoLaunchPlayers.Text)) {
                // - - - - - - - - - - - - - - - - - - -
                //  1     P L A Y E R
                // - - - - - - - - - - - - - - - - - - -
                case 1:
                    // -- PLAYER 1 --------------------------
                    TALPlayer1Label.Enabled = true;
                    TALP1DLabel.Enabled = true;
                    TALP1ILabel.Enabled = true;

                    AutoLaunchPart1.Enabled = true;
                    AutoLaunchDifficulty1.Enabled = true;
                    AutoLaunchBot1.Enabled = true;

                    ALInstIconP1.Enabled = true;
                    ALDiffIconP1.Enabled = true;

                    TALPTLPlayer1Label.Enabled = false;
                    GamerTag1.Enabled = false;

                    // -- PLAYER 2 --------------------------
                    TALPlayer2Label.Enabled = false;
                    TALP2DLabel.Enabled = false;
                    TALP2ILabel.Enabled = false;

                    AutoLaunchPart2.Enabled = false;
                    AutoLaunchDifficulty2.Enabled = false;
                    AutoLaunchBot2.Enabled = false;

                    ALInstIconP2.Enabled = false;
                    ALDiffIconP2.Enabled = false;

                    TALPTLPlayer2Label.Enabled = false;
                    GamerTag2.Enabled = false;

                    // -- PLAYER 3 --------------------------
                    TALPlayer3Label.Enabled = false;
                    TALP3DLabel.Enabled = false;
                    TALP3ILabel.Enabled = false;

                    AutoLaunchPart3.Enabled = false;
                    AutoLaunchDifficulty3.Enabled = false;
                    AutoLaunchBot3.Enabled = false;

                    ALInstIconP3.Enabled = false;
                    ALDiffIconP3.Enabled = false;

                    TALPTLPlayer3Label.Enabled = false;
                    GamerTag3.Enabled = false;

                    // -- PLAYER 4 --------------------------
                    TALPlayer4Label.Enabled = false;
                    TALP4DLabel.Enabled = false;
                    TALP4ILabel.Enabled = false;

                    AutoLaunchPart4.Enabled = false;
                    AutoLaunchDifficulty4.Enabled = false;
                    AutoLaunchBot4.Enabled = false;

                    ALInstIconP4.Enabled = false;
                    ALDiffIconP4.Enabled = false;

                    TALPTLPlayer4Label.Enabled = false;
                    GamerTag4.Enabled = false;
                    break;

                // - - - - - - - - - - - - - - - - - - -
                //  2     P L A Y E R S
                // - - - - - - - - - - - - - - - - - - -
                case 2:
                    // -- PLAYER 1 --------------------------
                    TALPlayer1Label.Enabled = true;
                    TALP1DLabel.Enabled = true;
                    TALP1ILabel.Enabled = true;

                    AutoLaunchPart1.Enabled = true;
                    AutoLaunchDifficulty1.Enabled = true;
                    AutoLaunchBot1.Enabled = true;

                    ALInstIconP1.Enabled = true;
                    ALDiffIconP1.Enabled = true;

                    TALPTLPlayer1Label.Enabled = true;
                    GamerTag1.Enabled = true;

                    // -- PLAYER 2 --------------------------
                    TALPlayer2Label.Enabled = true;
                    TALP2DLabel.Enabled = true;
                    TALP2ILabel.Enabled = true;

                    AutoLaunchPart2.Enabled = true;
                    AutoLaunchDifficulty2.Enabled = true;
                    AutoLaunchBot2.Enabled = true;

                    ALInstIconP2.Enabled = true;
                    ALDiffIconP2.Enabled = true;

                    TALPTLPlayer2Label.Enabled = true;
                    GamerTag2.Enabled = true;

                    // -- PLAYER 3 --------------------------
                    TALPlayer3Label.Enabled = false;
                    TALP3DLabel.Enabled = false;
                    TALP3ILabel.Enabled = false;

                    AutoLaunchPart3.Enabled = false;
                    AutoLaunchDifficulty3.Enabled = false;
                    AutoLaunchBot3.Enabled = false;

                    ALInstIconP3.Enabled = false;
                    ALDiffIconP3.Enabled = false;

                    TALPTLPlayer3Label.Enabled = false;
                    GamerTag3.Enabled = false;

                    // -- PLAYER 4 --------------------------
                    TALPlayer4Label.Enabled = false;
                    TALP4DLabel.Enabled = false;
                    TALP4ILabel.Enabled = false;

                    AutoLaunchPart4.Enabled = false;
                    AutoLaunchDifficulty4.Enabled = false;
                    AutoLaunchBot4.Enabled = false;

                    ALInstIconP4.Enabled = false;
                    ALDiffIconP4.Enabled = false;

                    TALPTLPlayer4Label.Enabled = false;
                    GamerTag4.Enabled = false;
                    break;

                // - - - - - - - - - - - - - - - - - - -
                //  3     P L A Y E R S
                // - - - - - - - - - - - - - - - - - - -
                case 3:
                    // -- PLAYER 1 --------------------------
                    TALPlayer1Label.Enabled = true;
                    TALP1DLabel.Enabled = true;
                    TALP1ILabel.Enabled = true;

                    AutoLaunchPart1.Enabled = true;
                    AutoLaunchDifficulty1.Enabled = true;
                    AutoLaunchBot1.Enabled = true;

                    ALInstIconP1.Enabled = true;
                    ALDiffIconP1.Enabled = true;

                    TALPTLPlayer1Label.Enabled = true;
                    GamerTag1.Enabled = true;

                    // -- PLAYER 2 --------------------------
                    TALPlayer2Label.Enabled = true;
                    TALP2DLabel.Enabled = true;
                    TALP2ILabel.Enabled = true;

                    AutoLaunchPart2.Enabled = true;
                    AutoLaunchDifficulty2.Enabled = true;
                    AutoLaunchBot2.Enabled = true;

                    ALInstIconP2.Enabled = true;
                    ALDiffIconP2.Enabled = true;

                    TALPTLPlayer2Label.Enabled = true;
                    GamerTag2.Enabled = true;

                    // -- PLAYER 3 --------------------------
                    TALPlayer3Label.Enabled = true;
                    TALP3DLabel.Enabled = true;
                    TALP3ILabel.Enabled = true;

                    AutoLaunchPart3.Enabled = true;
                    AutoLaunchDifficulty3.Enabled = true;
                    AutoLaunchBot3.Enabled = true;

                    ALInstIconP3.Enabled = true;
                    ALDiffIconP3.Enabled = true;

                    TALPTLPlayer3Label.Enabled = true;
                    GamerTag3.Enabled = true;

                    // -- PLAYER 4 --------------------------
                    TALPlayer4Label.Enabled = false;
                    TALP4DLabel.Enabled = false;
                    TALP4ILabel.Enabled = false;

                    AutoLaunchPart4.Enabled = false;
                    AutoLaunchDifficulty4.Enabled = false;
                    AutoLaunchBot4.Enabled = false;

                    ALInstIconP4.Enabled = false;
                    ALDiffIconP4.Enabled = false;

                    TALPTLPlayer4Label.Enabled = false;
                    GamerTag4.Enabled = false;
                    break;

                // - - - - - - - - - - - - - - - - - - -
                //  4     P L A Y E R S
                // - - - - - - - - - - - - - - - - - - -
                case 4:
                    // -- PLAYER 1 --------------------------
                    TALPlayer1Label.Enabled = true;
                    TALP1DLabel.Enabled = true;
                    TALP1ILabel.Enabled = true;

                    AutoLaunchPart1.Enabled = true;
                    AutoLaunchDifficulty1.Enabled = true;
                    AutoLaunchBot1.Enabled = true;

                    ALInstIconP1.Enabled = true;
                    ALDiffIconP1.Enabled = true;

                    TALPTLPlayer1Label.Enabled = true;
                    GamerTag1.Enabled = true;

                    // -- PLAYER 2 --------------------------
                    TALPlayer2Label.Enabled = true;
                    TALP2DLabel.Enabled = true;
                    TALP2ILabel.Enabled = true;

                    AutoLaunchPart2.Enabled = true;
                    AutoLaunchDifficulty2.Enabled = true;
                    AutoLaunchBot2.Enabled = true;

                    ALInstIconP2.Enabled = true;
                    ALDiffIconP2.Enabled = true;

                    TALPTLPlayer2Label.Enabled = true;
                    GamerTag2.Enabled = true;

                    // -- PLAYER 3 --------------------------
                    TALPlayer3Label.Enabled = true;
                    TALP3DLabel.Enabled = true;
                    TALP3ILabel.Enabled = true;

                    AutoLaunchPart3.Enabled = true;
                    AutoLaunchDifficulty3.Enabled = true;
                    AutoLaunchBot3.Enabled = true;

                    ALInstIconP3.Enabled = true;
                    ALDiffIconP3.Enabled = true;

                    TALPTLPlayer3Label.Enabled = true;
                    GamerTag3.Enabled = true;

                    // -- PLAYER 4 --------------------------
                    TALPlayer4Label.Enabled = true;
                    TALP4DLabel.Enabled = true;
                    TALP4ILabel.Enabled = true;

                    AutoLaunchPart4.Enabled = true;
                    AutoLaunchDifficulty4.Enabled = true;
                    AutoLaunchBot4.Enabled = true;

                    ALInstIconP4.Enabled = true;
                    ALDiffIconP4.Enabled = true;

                    TALPTLPlayer4Label.Enabled = true;
                    GamerTag4.Enabled = true;
                    break;
            }
        }

        private void ALSongMakeQueueButton_Click(object sender, EventArgs e) {
            AutoLaunchSongChooser alsc = new AutoLaunchSongChooser(AutoLaunchSongs);
            alsc.ShowDialog();

            AutoLaunchSongs = (
                from song in alsc.RotationSongInfo
                select song[1]
            ).ToList();
            bool canSave = alsc.CanSave;

            alsc.Dispose();

            Console.WriteLine($"Number of Auto Launch songs: {AutoLaunchSongs.Count}");

            if (canSave) SaveAutoLaunchSongs();
        }

        private void AutoLaunchVenue_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Venue", INIFunctions.InterpretINISetting(AutoLaunchVenue.Text,
                V3LauncherConstants.VenueIDs[0].ToArray(), V3LauncherConstants.VenueIDs[1].ToArray()));
        }

        private void AutoLaunchGameMode_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "GameMode", INIFunctions.InterpretINISetting(AutoLaunchGameMode.Text,
                V3LauncherConstants.AutoLaunchModes[0], V3LauncherConstants.AutoLaunchModes[1]));
        }

        private void AutoLaunchPart1_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Part", INIFunctions.InterpretINISetting(AutoLaunchPart1.Text,
                V3LauncherConstants.InstrumentPartNames[0], V3LauncherConstants.InstrumentPartNames[1]));
            ALInstIconP1.BackgroundImage = InstrumentIcons[AutoLaunchPart1.SelectedIndex];
        }

        private void AutoLaunchDifficulty1_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Difficulty", AutoLaunchDifficulty1.Text.ToLower());
            ALDiffIconP1.BackgroundImage = DifficultyIcons[AutoLaunchDifficulty1.SelectedIndex];
        }

        private void AutoLaunchBot1_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Bot", INIFunctions.BoolToString(AutoLaunchBot1.Checked));
        }

        private void AutoLaunchPart2_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Part2", INIFunctions.InterpretINISetting(AutoLaunchPart2.Text,
                V3LauncherConstants.InstrumentPartNames[0], V3LauncherConstants.InstrumentPartNames[1]));
            ALInstIconP2.BackgroundImage = InstrumentIcons[AutoLaunchPart2.SelectedIndex];
        }

        private void AutoLaunchDifficulty2_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Difficulty2", AutoLaunchDifficulty2.Text.ToLower());
            ALDiffIconP2.BackgroundImage = DifficultyIcons[AutoLaunchDifficulty2.SelectedIndex];
        }

        private void AutoLaunchBot2_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Bot2", INIFunctions.BoolToString(AutoLaunchBot2.Checked));
        }

        private void AutoLaunchPart3_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Part3", INIFunctions.InterpretINISetting(AutoLaunchPart3.Text,
                V3LauncherConstants.InstrumentPartNames[0], V3LauncherConstants.InstrumentPartNames[1]));
            ALInstIconP3.BackgroundImage = InstrumentIcons[AutoLaunchPart3.SelectedIndex];
        }

        private void AutoLaunchDifficulty3_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Difficulty3", AutoLaunchDifficulty3.Text.ToLower());
            ALDiffIconP3.BackgroundImage = DifficultyIcons[AutoLaunchDifficulty3.SelectedIndex];
        }

        private void AutoLaunchBot3_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Bot3", INIFunctions.BoolToString(AutoLaunchBot3.Checked));
        }

        private void AutoLaunchPart4_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Part4", INIFunctions.InterpretINISetting(AutoLaunchPart4.Text,
                V3LauncherConstants.InstrumentPartNames[0], V3LauncherConstants.InstrumentPartNames[1]));
            ALInstIconP4.BackgroundImage = InstrumentIcons[AutoLaunchPart4.SelectedIndex];
        }

        private void AutoLaunchDifficulty4_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Difficulty4", AutoLaunchDifficulty4.Text.ToLower());
            ALDiffIconP4.BackgroundImage = DifficultyIcons[AutoLaunchDifficulty4.SelectedIndex];
        }

        private void AutoLaunchBot4_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Bot4", INIFunctions.BoolToString(AutoLaunchBot4.Checked));
        }

        private void GamerTag1_TextChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "GamerTag", GamerTag1.Text);
        }

        private void GamerTag2_TextChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "GamerTag2", GamerTag2.Text);
        }

        private void GamerTag3_TextChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "GamerTag3", GamerTag3.Text);
        }

        private void GamerTag4_TextChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "GamerTag4", GamerTag4.Text);
        }

        private void AutoLaunchHideHUD_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "HideHUD", INIFunctions.BoolToString(AutoLaunchHideHUD.Checked));
        }

        private void AutoLaunchSongTime_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "SongTime", INIFunctions.BoolToString(AutoLaunchSongTime.Checked));
        }

        private void AutoLaunchRawLoad_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "RawLoad", INIFunctions.BoolToString(AutoLaunchRawLoad.Checked));
        }

        private void AutoLaunchEncoreMode_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "EncoreMode", INIFunctions.BoolToStringCustom(AutoLaunchEncoreMode.Checked,
                "last_song", "none"));
        }
        #endregion

        // ----------------------------------------------------------
        // DEBUG TAB AUTO UPDATE
        // ----------------------------------------------------------
        #region Debug Tab Auto Update
        private void FixGuitarInputLogic_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Debug", "FixGuitarInputLogic", INIFunctions.BoolToString(FixGuitarInputLogic.Checked));
        }

        private void FixNoteLimit_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Debug", "FixNoteLimit", INIFunctions.BoolToString(FixNoteLimit.Checked));
        }

        private void FixMemoryHandler_CheckedChanged(object sender, EventArgs e) {
            if (!FixMemoryHandler.Checked) {
                string warnDisableMemHandler = "Do you really wish to disable the memory handler fix? Disabling this may be potentially dangerous and is not recommended.";

                if (MessageBox.Show(warnDisableMemHandler, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
                    FixMemoryHandler.Checked = true;
                }
            }

            INIFunctions.SaveINIValue("Debug", "FixMemoryHandler", INIFunctions.BoolToString(FixMemoryHandler.Checked));
        }

        private void DebugConsole_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Logger", "Console", INIFunctions.BoolToString(DebugConsole.Checked));
        }

        private void WriteFile_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Logger", "WriteFile", INIFunctions.BoolToString(WriteFile.Checked));
        }

        private void DisableSongLogging_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Logger", "DisableSongLogging", INIFunctions.BoolToString(DisableSongLogging.Checked));
        }

        private void DebugDLCSync_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Logger", "DebugDLCSync", INIFunctions.BoolToString(DebugDLCSync.Checked));
        }

        private void FixFSBObjects_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Debug", "FixFSBObjects", INIFunctions.BoolToString(FixFSBObjects.Checked));
        }

        private void ExtraOptimizedSaves_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Debug", "ExtraOptimizedSaves", INIFunctions.BoolToString(ExtraOptimizedSaves.Checked));
        }

        private void DebugSaves_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Debug", "DebugSaves", INIFunctions.BoolToString(DebugSaves.Checked));
        }

        private void ShowWarnings_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Logger", "ShowWarnings", INIFunctions.BoolToString(ShowWarnings.Checked));
        }

        private void FixFastTextures_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Debug", "FixFastTextures", INIFunctions.BoolToString(FixFastTextures.Checked));
        }

        private void BindWarningShown_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Debug", "BindWarningShown", INIFunctions.BoolToString(BindWarningShown.Checked));
        }

        private void QuickDebug_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Debug", "QuickDebug", INIFunctions.BoolToString(QuickDebug.Checked));
        }

        private void PrintLoadedAssets_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Logger", "PrintLoadedAssets", INIFunctions.BoolToString(PrintLoadedAssets.Checked));
        }

        private void PrintCreateFile_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Logger", "PrintCreateFile", INIFunctions.BoolToString(PrintCreateFile.Checked));
        }

        private void CASNoticeShown_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Debug", "CASNoticeShown", INIFunctions.BoolToString(CASNoticeShown.Checked));
        }

        private void DisableInitialMovies_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Debug", "DisableInitialMovies", INIFunctions.BoolToString(DisableInitialMovies.Checked));
        }

        private void ImmediateVectorHandlers_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Logger", "ImmediateVectorHandlers", INIFunctions.BoolToString(ImmediateVectorHandlers.Checked));
        }

        private void ExceptionHandler_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Logger", "ExceptionHandler", INIFunctions.BoolToString(ExceptionHandler.Checked));
        }

        private void ChangeDEVersionButton_Click(object sender, EventArgs e) {
            GHDEVersionChanger verChange = new GHDEVersionChanger();
            verChange.ShowDialog();
        }
        #endregion

        // ----------------------------------------------------------
        // CREDITS TAB SOCIAL BUTTONS
        // ----------------------------------------------------------
        #region Credits Tab Social Buttons
        private void ButtonYouTube_Click(object sender, EventArgs e) {
            V3LauncherCore.OpenSiteURL("https://youtube.com/@IMF24");
        }

        private void ButtonGitHub_Click(object sender, EventArgs e) {
            V3LauncherCore.OpenSiteURL("https://github.com/IMF24");
        }

        private void ButtonWTDESite_Click(object sender, EventArgs e) {
            V3LauncherCore.OpenSiteURL("https://ghwt.de");
        }

        private void ButtonFretworks_Click(object sender, EventArgs e) {
            V3LauncherCore.OpenSiteURL("https://gitgud.io/fretworks");
        }

        private void ButtonDiscord_Click(object sender, EventArgs e) {
            V3LauncherCore.OpenSiteURL("https://discord.gg/HVECPzkV4u");
        }







        #endregion

        // ----------------------------------------------------------
        // RIGHT CLICK CONTENT MENU STRIP LOGIC
        // ----------------------------------------------------------
        #region Right Click Context Menu Strip Logic
        // - - - - - - - - - - - - - - - - - - -
        //  B A N D     M E M B E R     C H A N G E
        // - - - - - - - - - - - - - - - - - - -
        #region Band Member Change Menu
        private void PreferredCharacterHoverChange(object sender, EventArgs e) {
            // Update the active character changer button every
            // time we hover over one.
            BandMemberChangeLastButton = (sender as Button).Name;
        }

        private void SetMemberMenuItem_Click(object sender, EventArgs e) {
            // Now, which button called this function?
            BandMembers member;

            // This is really weird, since the control's name is a string here.
            // This is odd. We don't usually refer to them this way.
            // But it's necessary here! Otherwise we won't spawn a dialog at all.
            switch (BandMemberChangeLastButton) {
                // -- GUITARIST
                // -- Also the default if invalid
                case "PrefGtrSelectChar": default:
                    member = BandMembers.Guitarist;
                    break;

                // -- BASSIST
                case "PrefBasSelectChar":
                    member = BandMembers.Bassist;
                    break;

                // -- DRUMMER
                case "PrefDrmSelectChar":
                    member = BandMembers.Drummer;
                    break;

                // -- MALE VOCALIST
                case "PrefVoxSelectChar":
                    member = BandMembers.MaleVocalist;
                    break;

                // -- FEMALE VOCALIST
                case "PrefFVoxSelectChar":
                    member = BandMembers.FemaleVocalist;
                    break;
            }

            // Actually spawn the dialog now!
            SpawnChangeBandMember(member);
        }

        private void ChangeInstMenuItem_Click(object sender, EventArgs e) {
            // Now, which button called this function?
            BandMembers member;

            // This is really weird, since the control's name is a string here.
            // This is odd. We don't usually refer to them this way.
            // But it's necessary here! Otherwise we won't spawn a dialog at all.
            switch (BandMemberChangeLastButton) {
                // -- GUITARIST
                // -- Also the default if invalid
                case "PrefGtrSelectChar": default:
                    member = BandMembers.Guitarist;
                    break;

                // -- BASSIST
                case "PrefBasSelectChar":
                    member = BandMembers.Bassist;
                    break;

                // -- DRUMMER
                case "PrefDrmSelectChar":
                    member = BandMembers.Drummer;
                    break;

                // -- MALE VOCALIST
                case "PrefVoxSelectChar":
                    member = BandMembers.MaleVocalist;
                    break;

                // -- FEMALE VOCALIST
                case "PrefFVoxSelectChar":
                    member = BandMembers.FemaleVocalist;
                    break;
            }

            // Now get the text box of the current member type.
            TextBox tb;
            switch (member) {
                case BandMembers.Guitarist: default:
                    tb = PreferredGuitarist;
                    break;

                case BandMembers.Bassist:
                    tb = PreferredBassist;
                    break;

                case BandMembers.Drummer:
                    tb = PreferredDrummer;
                    break;

                case BandMembers.MaleVocalist:
                    tb = PreferredSinger;
                    break;

                case BandMembers.FemaleVocalist:
                    tb = PreferredFemaleSinger;
                    break;
            }

            // Find the IMPLIED mod, we'll ASSUME this is the only mod with this name.
            string[] impliedMod = (
                from mod in ModHandler.UserContentMods
                where mod[0].Contains(tb.Text.Trim())
                select mod
            ).ToList()[0];

            // Get its name and INI file path.
            string selectedCharacterName = tb.Text.Trim();
            string selectedCharacterPath = impliedMod[5];

            // Show the dialog!
            AdjustCharacterInstruments aci = new AdjustCharacterInstruments(selectedCharacterName, selectedCharacterPath);
            aci.ShowDialog();
        }





        #endregion

        // - - - - - - - - - - - - - - - - - - -
        //  M O D     M A N A G E R     C O N T E X T
        // - - - - - - - - - - - - - - - - - - -
        #region Mod Manager Context Menu
        // -- OPEN MOD MANAGER
        private void OpenModManagerMenuItem_Click(object sender, EventArgs e) {
            ModManager modManager = new ModManager();
            modManager.ShowDialog();
        }

        // - - - - - - - - - - - - -

        // -- INI & XML EDITOR
        private void OpenINIEditorMenuItem_Click(object sender, EventArgs e) {
            DEConfigFilesEditor iniEditor = new DEConfigFilesEditor();
            iniEditor.ShowDialog();
        }

        // - - - - - - - - - - - - -

        // -- MANAGE SAVE FILES
        private void OpenSaveManagerMenuItem_Click(object sender, EventArgs e) {
            SaveFileManager saveManager = new SaveFileManager();
            saveManager.ShowDialog();
        }

        // -- ROCK STAR CREATOR CHARACTER MANAGER
        private void OpenCASManagerMenuItem_Click(object sender, EventArgs e) {
            CARManager casManager = new CARManager();
            casManager.ShowDialog();
        }

        // - - - - - - - - - - - - -

        // -- ANALYZE WTDE DEBUG LOGS
        private void OpenDebugAnalyzerMenuItem_Click(object sender, EventArgs e) {
            DebugLogAnalyzer logAnalyzer = new DebugLogAnalyzer();
            logAnalyzer.ShowDialog();
        }

        // - - - - - - - - - - - - -

        // -- INSTALL MODS
        private void OpenModInstallerMenuItem_Click(object sender, EventArgs e) {
            ModInstaller modInstaller = new ModInstaller();
            modInstaller.ShowDialog();
        }
        
        // -- FIND MODS
        private void OpenModFinderMenuItem_Click(object sender, EventArgs e) {
            ModFinder modFinder = new ModFinder();
            modFinder.ShowDialog();
        }

        // - - - - - - - - - - - - -

        // -- SONG & SONG CATEGORY MANAGER
        private void OpenSongManagerMenuItem_Click(object sender, EventArgs e) {
            SongMasterManager songManager = new SongMasterManager();
            songManager.ShowDialog();
        }

        // -- MANAGE DUPLICATE SONG CHECKSUMS
        private void OpenDupesEditorMenuItem_Click(object sender, EventArgs e) {
            DupeChecksumManager dupeManager = new DupeChecksumManager();
            dupeManager.ShowDialog();
        }

        // - - - - - - - - - - - - -

        // -- GEM THEME DESIGNER
        private void OpenGemDesignerMenuItem_Click(object sender, EventArgs e) {
            GemThemeCreator gemDesigner = new GemThemeCreator();
            gemDesigner.ShowDialog();
        }
        #endregion
        #endregion
    }
}
