/* ------------------------------------------------------------------------------------------------
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
    
------------------------------------------------------------------------------------------------ */
// Various required imports.
using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MadMilkman.Ini;
using NAudio.CoreAudioApi;

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
            UpdateActiveTab((int)LauncherTabs.MOTD);

            // Get our list of microphone devices.
            GetMicDevices();

            // Set working directory for DEBUG PURPOSES.
            //~ Directory.SetCurrentDirectory("D:/Program Files (D)/Aspyr/Guitar Hero World Tour");
            ModHandler.AppendVenueMods(new ComboBox[] { AutoLaunchVenue, PreferredStage });

            // Set up tabs, the window title, and the background.
            LoadINISettings();
            DoTabSetup();
            V3LauncherCore.SetWindowTitle(this);
            BGConstants.AutoDateBackground(this, VersionInfoLabel, WTDELogo);

            // DEV ONLY SETTINGS: THIS FILE SHOULD **NEVER** BE PRESENT IN PUBLIC BUILDS.
            OpenDevOnlySettings.Enabled = V3LauncherCore.AllowDevSettings();
            OpenDevOnlySettings.Visible = V3LauncherCore.AllowDevSettings();

            //~ Console.WriteLine(V3LauncherCore.AspyrKeyDecode("Keyboard_Menu", "KICK"));

            // Also, should we automatically update when the program starts?
            V3LauncherCore.AutoCheckForUpdates();
        }

        private void OpenDevOnlySettings_Click(object sender, EventArgs e) {
            WTDEDevSettingsDialog dlg = new WTDEDevSettingsDialog();
            dlg.ShowDialog();
        }

        /// <summary>
        ///  Load all config data from GHWTDE.ini and AspyrConfig.xml.
        /// </summary>
        public void LoadINISettings() {
            // Not needed, we have the INIFunctions class handling this for us!
            //~ IniFile file = new IniFile();
            //~ file.Load(V3LauncherConstants.WTDEConfigDir);

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
            // INPUT TAB
            // ---------------------------------
            MicrophoneSelect.Text = INIFunctions.GetINIValue("Audio", "MicDevice", "");
            MicAudioDelay.Value = int.Parse(INIFunctions.GetINIValue("Audio", "VocalAdjustment", "0"));
            MicVideoDelay.Value = int.Parse(XMLFunctions.AspyrGetString("Options.VocalsVisualLag", "0"));

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
            // BAND TAB
            // ---------------------------------
            PreferredGuitarist.Text = INIFunctions.GetINIValue("Band", "PreferredGuitarist");
            PreferredBassist.Text = INIFunctions.GetINIValue("Band", "PreferredBassist");
            PreferredDrummer.Text = INIFunctions.GetINIValue("Band", "PreferredDrummer");
            PreferredSinger.Text = INIFunctions.GetINIValue("Band", "PreferredSinger");
            PreferredStage.Text = INIFunctions.InterpretINISetting(INIFunctions.GetINIValue("Band", "PreferredStage"),
                V3LauncherConstants.VenueIDs[1].ToArray(), V3LauncherConstants.VenueIDs[0].ToArray());

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
                V3LauncherConstants.VenueIDs[1].ToArray(), V3LauncherConstants.VenueIDs[0].ToArray());

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

            AutoLaunchHideHUD.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "HideHUD"));
            AutoLaunchSongTime.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "SongTime"));
            AutoLaunchRawLoad.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("AutoLaunch", "RawLoad"));
            AutoLaunchEncoreMode.Checked = INIFunctions.GetBooleanCustomString(INIFunctions.GetINIValue("AutoLaunch", "EncoreMode"), "last_song");
        }

        /// <summary>
        ///  Save all data to GHWTDE.ini and AspyrConfig.xml.
        /// </summary>
        public void SaveINISettings(object sender, EventArgs e) {
            // All right, let's do some config settings saving!
            // We will be writing ALL INI and XML file settings!

            // ---------------------------------
            // GENERAL TAB
            // ---------------------------------
            INIFunctions.SaveINIValue("Config", "RichPresence", INIFunctions.BoolToString(RichPresence.Checked));
            INIFunctions.SaveINIValue("Config", "AllowHolidays", INIFunctions.BoolToString(AllowHolidays.Checked));
            INIFunctions.SaveINIValue("Audio", "MuteStreams", INIFunctions.BoolToString(MuteStreams.Checked));
            INIFunctions.SaveINIValue("Audio", "WhammyPitchShift", INIFunctions.BoolToString(WhammyPitchShift.Checked));
            INIFunctions.SaveINIValue("Config", "DefaultQPODifficulty", INIFunctions.InterpretINISetting(DefaultQPODifficulty.Text,
                new string[] { "Beginner", "Easy", "Medium", "Hard", "Expert" },
                new string[] { "easy_rhythm", "easy", "normal", "hard", "expert" }));
            XMLFunctions.AspyrWriteString("Audio.BuffLen", AudioBuffLen.Text);

            // -- MAIN MENU TOGGLES --------
            INIFunctions.SaveINIValue("Config", "UseCareerOption", INIFunctions.BoolToString(UseCareerOption.Checked));
            INIFunctions.SaveINIValue("Config", "UseQuickplayOption", INIFunctions.BoolToString(UseQuickplayOption.Checked));
            INIFunctions.SaveINIValue("Config", "UseHeadToHeadOption", INIFunctions.BoolToString(UseHeadToHeadOption.Checked));
            INIFunctions.SaveINIValue("Config", "UseOnlineOption", INIFunctions.BoolToString(UseOnlineOption.Checked));
            INIFunctions.SaveINIValue("Config", "UseMusicStudioOption", INIFunctions.BoolToString(UseMusicStudioOption.Checked));
            INIFunctions.SaveINIValue("Config", "UseCAROption", INIFunctions.BoolToString(UseCAROption.Checked));
            INIFunctions.SaveINIValue("Config", "UseOptionsOption", INIFunctions.BoolToString(UseOptionsOption.Checked));
            INIFunctions.SaveINIValue("Config", "UseQuitOption", INIFunctions.BoolToString(UseQuitOption.Checked));

            // ---------------------------------
            // INPUT TAB
            // ---------------------------------
            INIFunctions.SaveINIValue("Audio", "MicDevice", MicrophoneSelect.Text);
            INIFunctions.SaveINIValue("Audio", "VocalAdjustment", MicAudioDelay.Value.ToString());
            XMLFunctions.AspyrWriteString("Options.VocalsVisualLag", MicVideoDelay.Value.ToString());

            // ---------------------------------
            // BAND TAB
            // ---------------------------------
            INIFunctions.SaveINIValue("Band", "PreferredGuitarist", PreferredGuitarist.Text);
            INIFunctions.SaveINIValue("Band", "PreferredBassist", PreferredBassist.Text);
            INIFunctions.SaveINIValue("Band", "PreferredDrummer", PreferredDrummer.Text);
            INIFunctions.SaveINIValue("Band", "PreferredSinger", PreferredSinger.Text);
            INIFunctions.SaveINIValue("Band", "PreferredStage", INIFunctions.InterpretINISetting(PreferredStage.Text,
                V3LauncherConstants.VenueIDs[0].ToArray(), V3LauncherConstants.VenueIDs[1].ToArray()));

            INIFunctions.SaveINIValue("Band", "PreferredGuitaristHighway", PreferredGuitaristHighway.Text);
            INIFunctions.SaveINIValue("Band", "PreferredBassistHighway", PreferredBassistHighway.Text);
            INIFunctions.SaveINIValue("Band", "PreferredDrummerHighway", PreferredDrummerHighway.Text);

            INIFunctions.SaveINIValue("Band", "GuitarStrumAnim", INIFunctions.InterpretINISetting(GuitarStrumAnim.Text,
                new string[] { "GH: World Tour (Default)", "Guitar Hero: Metallica" },
                new string[] { "none", "ghm" }));
            INIFunctions.SaveINIValue("Band", "BassStrumAnim", INIFunctions.InterpretINISetting(BassStrumAnim.Text,
                new string[] { "GH: World Tour (Default)", "Guitar Hero: Metallica" },
                new string[] { "none", "ghm" }));

            // ---------------------------------
            // AUTO LAUNCH TAB
            // ---------------------------------
            INIFunctions.SaveINIValue("AutoLaunch", "Enabled", INIFunctions.BoolToString(AutoLaunchEnabled.Checked));

            INIFunctions.SaveINIValue("AutoLaunch", "Players", AutoLaunchPlayers.Text);
            INIFunctions.SaveINIValue("AutoLaunch", "Song", AutoLaunchSong.Text);
            INIFunctions.SaveINIValue("AutoLaunch", "Venue", INIFunctions.InterpretINISetting(AutoLaunchVenue.Text,
                V3LauncherConstants.VenueIDs[0].ToArray(), V3LauncherConstants.VenueIDs[1].ToArray()));

            string[][] autoLaunchInstruments = {
                new string[] { "guitar", "bass", "drum", "vocals" },
                new string[] { "Lead Guitar - PART GUITAR", "Bass Guitar - PART BASS", "Drums - PART DRUMS", "Vocals - PART VOCALS" }
            };

            string[][] autoLaunchDifficulties = {
                new string[] { "beginner", "easy", "medium", "hard", "expert" },
                new string[] { "Beginner", "Easy", "Medium", "Hard", "Expert" }
            };

            INIFunctions.SaveINIValue("AutoLaunch", "Part", INIFunctions.InterpretINISetting(AutoLaunchPart1.Text,
                autoLaunchInstruments[1], autoLaunchInstruments[0]));
            INIFunctions.SaveINIValue("AutoLaunch", "Part2", INIFunctions.InterpretINISetting(AutoLaunchPart2.Text,
                autoLaunchInstruments[1], autoLaunchInstruments[0]));
            INIFunctions.SaveINIValue("AutoLaunch", "Part3", INIFunctions.InterpretINISetting(AutoLaunchPart3.Text,
                autoLaunchInstruments[1], autoLaunchInstruments[0]));
            INIFunctions.SaveINIValue("AutoLaunch", "Part4", INIFunctions.InterpretINISetting(AutoLaunchPart4.Text,
                autoLaunchInstruments[1], autoLaunchInstruments[0]));

            INIFunctions.SaveINIValue("AutoLaunch", "Difficulty", INIFunctions.InterpretINISetting(AutoLaunchDifficulty1.Text,
                autoLaunchDifficulties[1], autoLaunchDifficulties[0]));
            INIFunctions.SaveINIValue("AutoLaunch", "Difficulty2", INIFunctions.InterpretINISetting(AutoLaunchDifficulty2.Text,
                autoLaunchDifficulties[1], autoLaunchDifficulties[0]));
            INIFunctions.SaveINIValue("AutoLaunch", "Difficulty3", INIFunctions.InterpretINISetting(AutoLaunchDifficulty3.Text,
                autoLaunchDifficulties[1], autoLaunchDifficulties[0]));
            INIFunctions.SaveINIValue("AutoLaunch", "Difficulty4", INIFunctions.InterpretINISetting(AutoLaunchDifficulty4.Text,
                autoLaunchDifficulties[1], autoLaunchDifficulties[0]));

            INIFunctions.SaveINIValue("AutoLaunch", "Bot", INIFunctions.BoolToString(AutoLaunchBot1.Checked));
            INIFunctions.SaveINIValue("AutoLaunch", "Bot2", INIFunctions.BoolToString(AutoLaunchBot2.Checked));
            INIFunctions.SaveINIValue("AutoLaunch", "Bot3", INIFunctions.BoolToString(AutoLaunchBot3.Checked));
            INIFunctions.SaveINIValue("AutoLaunch", "Bot4", INIFunctions.BoolToString(AutoLaunchBot4.Checked));

            INIFunctions.SaveINIValue("AutoLaunch", "HideHUD", INIFunctions.BoolToString(AutoLaunchHideHUD.Checked));
            INIFunctions.SaveINIValue("AutoLaunch", "SongTime", INIFunctions.BoolToString(AutoLaunchSongTime.Checked));
            INIFunctions.SaveINIValue("AutoLaunch", "RawLoad", INIFunctions.BoolToString(AutoLaunchRawLoad.Checked));
            INIFunctions.SaveINIValue("AutoLaunch", "EncoreMode", INIFunctions.BoolToStringCustom(AutoLaunchEncoreMode.Checked, "last_song", "none"));

            // ---------------------------------
            // DEBUG TAB
            // ---------------------------------
            INIFunctions.SaveINIValue("Debug", "FixNoteLimit", INIFunctions.BoolToString(FixNoteLimit.Checked));

            
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

                    TabCreditsGroup.Visible = false;
                    TabCreditsGroup.Enabled = false;

                    // ------------------------------------

                    TabGeneralGroup.Visible = false;
                    TabGeneralGroup.Enabled = false;

                    TabInputGroup.Visible = false;
                    TabInputGroup.Enabled = false;

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;

                // -- GENERAL TAB SWITCH ---------------------------------
                case 1:
                    MOTDText.Visible = false;
                    MOTDBack.Visible = false;

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

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;

                // -- INPUT TAB SWITCH ---------------------------------
                case 2:
                    MOTDText.Visible = false;
                    MOTDBack.Visible = false;

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

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;

                // -- BAND TAB SWITCH ---------------------------------
                case 4:
                    MOTDText.Visible = false;
                    MOTDBack.Visible = false;

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

                    TabBandGroup.Visible = true;
                    TabBandGroup.Enabled = true;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;

                // -- AUTO LAUNCH TAB SWITCH ---------------------------------
                case 5:
                    MOTDText.Visible = false;
                    MOTDBack.Visible = false;

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

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = true;
                    TabAutoLaunchGroup.Enabled = true;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;

                // -- DEBUG TAB SWITCH ---------------------------------
                case 6:
                    MOTDText.Visible = false;
                    MOTDBack.Visible = false;

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

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = true;
                    TabDebugGroup.Enabled = true;
                    break;

                // -- CREDITS TAB SWITCH ---------------------------------
                case 7:
                    MOTDText.Visible = false;
                    MOTDBack.Visible = false;

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

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;

                // -- PRE-TAB TAB SWITCH ---------------------------------
                case 8:
                    MOTDText.Visible = false;
                    MOTDBack.Visible = false;

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

                    TabBandGroup.Visible = false;
                    TabBandGroup.Enabled = false;

                    TabAutoLaunchGroup.Visible = false;
                    TabAutoLaunchGroup.Enabled = false;

                    TabDebugGroup.Visible = false;
                    TabDebugGroup.Enabled = false;
                    break;
            }
        }

        /// <summary>
        ///  Actions to be carried out when the program closes.
        /// </summary>
        public void ExitActions() {
            V3LauncherCore.DebugLog.Add("\n\nWe're done in the launcher for now!\nThanks for using it! :D");
            try {
                V3LauncherCore.WriteDebugLog();
            } catch (Exception ex) {
                Console.WriteLine($"Uh oh! Hit a problem! Probably nothing severe...\nException details: {ex.Message}");
            }
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e) {
            ExitActions();
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
            TabBandGroup.Text = "";
            TabAutoLaunchGroup.Text = "";
            TabDebugGroup.Text = "";

            // Parent all tabs to the parent container.
            TabGeneralGroup.Parent = TabParentContainer;
            TabInputGroup.Parent = TabParentContainer;
            TabBandGroup.Parent = TabParentContainer;
            TabAutoLaunchGroup.Parent = TabParentContainer;
            TabDebugGroup.Parent = TabParentContainer;

            // Move all of the tabs to their correct locations.
            Point location = new Point(12, 8);
            TabGeneralGroup.Location = location;
            TabInputGroup.Location = location;
            TabBandGroup.Location = location;
            TabAutoLaunchGroup.Location = location;
            TabDebugGroup.Location = location;
        }

        /// <summary>
        ///  Get the list of supported microphone devices. Uses NAudio to get devices.
        /// </summary>
        public void GetMicDevices() {
            var enumerator = new MMDeviceEnumerator();
            foreach (var endpoint in enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active)) {
                MicrophoneSelect.Items.Add(endpoint.FriendlyName);
            }
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
            ModHandler.UseUpdaterINIDirectory();
            this.Close();
            Process.Start("GHWT_Definitive.exe");
        }

        private void AdjustSettingsButton_Click(object sender, EventArgs e) {
            if (ActiveTab == 0 || ActiveTab == 7) UpdateActiveTab((int)LauncherTabs.PreTab);
            else UpdateActiveTab((int)LauncherTabs.MOTD);
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

        private void FretworksLogo_Click(object sender, EventArgs e) {
            if (ActiveTab == 7) UpdateActiveTab((int)LauncherTabs.MOTD);
            else UpdateActiveTab((int)LauncherTabs.Credits);
        }

        private void VersionInfoLabel_Click(object sender, EventArgs e) {
            // Which mouse button did we push?
            MouseEventArgs me = (MouseEventArgs) e;

            // Left triggers the background to swap.
            if (me.Button == MouseButtons.Left) {
                // Are we at the end of the BG cycle?
                if (BGConstants.BGIndex + 1 == BGConstants.V3LauncherBackgrounds.Length) BGConstants.BGIndex = 0;
                else BGConstants.BGIndex++;

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

        private void SetDefaultVoxLag_Click(object sender, EventArgs e) {
            MicAudioDelay.Value = -80;
            MicVideoDelay.Value = -315;

            INIFunctions.SaveINIValue("Audio", "VocalAdjustment", MicAudioDelay.Value.ToString());
            XMLFunctions.AspyrWriteString("Options.VocalsVisualLag", MicVideoDelay.Value.ToString());
        }

        private void SaveKeybindsButton_Click(object sender, EventArgs e) {
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
                    MicDownInputs.Text
                },

                new List<string> {
                    "GREEN", "RED", "YELLOW", "BLUE", "ORANGE", "START",
                    "BACK", "CANCEL", "UP", "DOWN"
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

        private void ResetKeybindsButton_Click(object sender, EventArgs e) {
            XMLFunctions.AspyrWriteString("Keyboard_Guitar", V3LauncherConstants.ASPYR_INPUT_GUITAR_DEFAULT);
            XMLFunctions.AspyrWriteString("Keyboard_Drum", V3LauncherConstants.ASPYR_INPUT_DRUMS_BACKUP);
            XMLFunctions.AspyrWriteString("Keyboard_Mic", V3LauncherConstants.ASPYR_INPUT_MIC_BACKUP);
            XMLFunctions.AspyrWriteString("Keyboard_Menu", V3LauncherConstants.ASPYR_INPUT_MENU_BACKUP);
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
                V3LauncherConstants.VenueIDs[0].ToArray(), V3LauncherConstants.VenueIDs[1].ToArray()));
        }

        private void GuitarStrumAnim_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "GuitarStrumAnim", INIFunctions.InterpretINISetting(GuitarStrumAnim.Text,
                new string[] { "GH: World Tour (Default)", "Guitar Hero: Metallica" }, new string[] { "none", "ghm" }));
        }

        private void BassStrumAnim_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "BassStrumAnim", INIFunctions.InterpretINISetting(BassStrumAnim.Text,
                new string[] { "GH: World Tour (Default)", "Guitar Hero: Metallica" }, new string[] { "none", "ghm" }));
        }

        private void PrefGtrSelectChar_Click(object sender, EventArgs e) {
            V3LauncherCore.TextBoxReadFromDialog(1, PreferredGuitarist, "Select Character Mod Folder");
        }

        private void PrefBasSelectChar_Click(object sender, EventArgs e) {
            V3LauncherCore.TextBoxReadFromDialog(1, PreferredBassist, "Select Character Mod Folder");
        }

        private void PrefDrmSelectChar_Click(object sender, EventArgs e) {
            V3LauncherCore.TextBoxReadFromDialog(1, PreferredDrummer, "Select Character Mod Folder");
        }

        private void PrefVoxSelectChar_Click(object sender, EventArgs e) {
            V3LauncherCore.TextBoxReadFromDialog(1, PreferredSinger, "Select Character Mod Folder");
        }

        private void PrefGtrHwySelectHwy_Click(object sender, EventArgs e) {
            V3LauncherCore.TextBoxReadFromDialog(1, PreferredGuitaristHighway, "Select Highway Mod Folder");
        }

        private void PrefBasHwySelectHwy_Click(object sender, EventArgs e) {
            V3LauncherCore.TextBoxReadFromDialog(1, PreferredBassistHighway, "Select Highway Mod Folder");
        }

        private void PrefDrmHwySelectHwy_Click(object sender, EventArgs e) {
            V3LauncherCore.TextBoxReadFromDialog(1, PreferredDrummerHighway, "Select Highway Mod Folder");
        }

        #endregion

        // ----------------------------------------------------------
        // AUTO LAUNCH TAB AUTO UPDATE
        // ----------------------------------------------------------
        #region Auto Launch Tab Auto Update
        private void AutoLaunchEnabled_CheckedChanged(object sender, EventArgs e) {
            TabALMainEditor.Enabled = AutoLaunchEnabled.Checked;
        }

        private void AutoLaunchPlayers_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Players", AutoLaunchPlayers.Text);
            // Update selectable player configs.
            switch (int.Parse(AutoLaunchPlayers.Text)) {
                case 1:
                    // -- PLAYER 1 --------------------------
                    TALPlayer1Label.Enabled = true;
                    TALP1DLabel.Enabled = true;
                    TALP1ILabel.Enabled = true;

                    AutoLaunchPart1.Enabled = true;
                    AutoLaunchDifficulty1.Enabled = true;
                    AutoLaunchBot1.Enabled = true;

                    // -- PLAYER 2 --------------------------
                    TALPlayer2Label.Enabled = false;
                    TALP2DLabel.Enabled = false;
                    TALP2ILabel.Enabled = false;

                    AutoLaunchPart2.Enabled = false;
                    AutoLaunchDifficulty2.Enabled = false;
                    AutoLaunchBot2.Enabled = false;

                    // -- PLAYER 3 --------------------------
                    TALPlayer3Label.Enabled = false;
                    TALP3DLabel.Enabled = false;
                    TALP3ILabel.Enabled = false;

                    AutoLaunchPart3.Enabled = false;
                    AutoLaunchDifficulty3.Enabled = false;
                    AutoLaunchBot3.Enabled = false;

                    // -- PLAYER 4 --------------------------
                    TALPlayer4Label.Enabled = false;
                    TALP4DLabel.Enabled = false;
                    TALP4ILabel.Enabled = false;

                    AutoLaunchPart4.Enabled = false;
                    AutoLaunchDifficulty4.Enabled = false;
                    AutoLaunchBot4.Enabled = false;
                    break;

                case 2:
                    // -- PLAYER 1 --------------------------
                    TALPlayer1Label.Enabled = true;
                    TALP1DLabel.Enabled = true;
                    TALP1ILabel.Enabled = true;

                    AutoLaunchPart1.Enabled = true;
                    AutoLaunchDifficulty1.Enabled = true;
                    AutoLaunchBot1.Enabled = true;

                    // -- PLAYER 2 --------------------------
                    TALPlayer2Label.Enabled = true;
                    TALP2DLabel.Enabled = true;
                    TALP2ILabel.Enabled = true;

                    AutoLaunchPart2.Enabled = true;
                    AutoLaunchDifficulty2.Enabled = true;
                    AutoLaunchBot2.Enabled = true;

                    // -- PLAYER 3 --------------------------
                    TALPlayer3Label.Enabled = false;
                    TALP3DLabel.Enabled = false;
                    TALP3ILabel.Enabled = false;

                    AutoLaunchPart3.Enabled = false;
                    AutoLaunchDifficulty3.Enabled = false;
                    AutoLaunchBot3.Enabled = false;

                    // -- PLAYER 4 --------------------------
                    TALPlayer4Label.Enabled = false;
                    TALP4DLabel.Enabled = false;
                    TALP4ILabel.Enabled = false;

                    AutoLaunchPart4.Enabled = false;
                    AutoLaunchDifficulty4.Enabled = false;
                    AutoLaunchBot4.Enabled = false;
                    break;

                case 3:
                    // -- PLAYER 1 --------------------------
                    TALPlayer1Label.Enabled = true;
                    TALP1DLabel.Enabled = true;
                    TALP1ILabel.Enabled = true;

                    AutoLaunchPart1.Enabled = true;
                    AutoLaunchDifficulty1.Enabled = true;
                    AutoLaunchBot1.Enabled = true;

                    // -- PLAYER 2 --------------------------
                    TALPlayer2Label.Enabled = true;
                    TALP2DLabel.Enabled = true;
                    TALP2ILabel.Enabled = true;

                    AutoLaunchPart2.Enabled = true;
                    AutoLaunchDifficulty2.Enabled = true;
                    AutoLaunchBot2.Enabled = true;

                    // -- PLAYER 3 --------------------------
                    TALPlayer3Label.Enabled = true;
                    TALP3DLabel.Enabled = true;
                    TALP3ILabel.Enabled = true;

                    AutoLaunchPart3.Enabled = true;
                    AutoLaunchDifficulty3.Enabled = true;
                    AutoLaunchBot3.Enabled = true;

                    // -- PLAYER 4 --------------------------
                    TALPlayer4Label.Enabled = false;
                    TALP4DLabel.Enabled = false;
                    TALP4ILabel.Enabled = false;

                    AutoLaunchPart4.Enabled = false;
                    AutoLaunchDifficulty4.Enabled = false;
                    AutoLaunchBot4.Enabled = false;
                    break;

                case 4:
                    // -- PLAYER 1 --------------------------
                    TALPlayer1Label.Enabled = true;
                    TALP1DLabel.Enabled = true;
                    TALP1ILabel.Enabled = true;

                    AutoLaunchPart1.Enabled = true;
                    AutoLaunchDifficulty1.Enabled = true;
                    AutoLaunchBot1.Enabled = true;

                    // -- PLAYER 2 --------------------------
                    TALPlayer2Label.Enabled = true;
                    TALP2DLabel.Enabled = true;
                    TALP2ILabel.Enabled = true;

                    AutoLaunchPart2.Enabled = true;
                    AutoLaunchDifficulty2.Enabled = true;
                    AutoLaunchBot2.Enabled = true;

                    // -- PLAYER 3 --------------------------
                    TALPlayer3Label.Enabled = true;
                    TALP3DLabel.Enabled = true;
                    TALP3ILabel.Enabled = true;

                    AutoLaunchPart3.Enabled = true;
                    AutoLaunchDifficulty3.Enabled = true;
                    AutoLaunchBot3.Enabled = true;

                    // -- PLAYER 4 --------------------------
                    TALPlayer4Label.Enabled = true;
                    TALP4DLabel.Enabled = true;
                    TALP4ILabel.Enabled = true;

                    AutoLaunchPart4.Enabled = true;
                    AutoLaunchDifficulty4.Enabled = true;
                    AutoLaunchBot4.Enabled = true;
                    break;
            }
        }

        private void AutoLaunchSong_TextChanged(object sender, EventArgs e) {
            try {
                INIFunctions.SaveINIValue("AutoLaunch", "Song", AutoLaunchSong.Text);
            } catch (Exception exc) {
                V3LauncherCore.AddDebugEntry(exc.ToString(), "Internal Error");
            }
        }

        private void ALSongSelectINI_Click(object sender, EventArgs e) {
            V3LauncherCore.TextBoxReadFromDialog(0, AutoLaunchSong, "Select song.ini File", false, "song.ini Files|*song.ini");
            IniFile file = new IniFile();
            file.Load(AutoLaunchSong.Text);
            AutoLaunchSong.Text = file.Sections["SongInfo"].Keys["Checksum"].Value;
        }

        private void AutoLaunchVenue_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Venue", INIFunctions.InterpretINISetting(AutoLaunchVenue.Text,
                V3LauncherConstants.VenueIDs[0].ToArray(), V3LauncherConstants.VenueIDs[1].ToArray()));
        }

        private void AutoLaunchPart1_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Part", INIFunctions.InterpretINISetting(AutoLaunchPart1.Text,
                V3LauncherConstants.InstrumentPartNames[0], V3LauncherConstants.InstrumentPartNames[1]));
        }

        private void AutoLaunchDifficulty1_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Difficulty", AutoLaunchDifficulty1.Text.ToLower());
        }

        private void AutoLaunchBot1_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Bot", INIFunctions.BoolToString(AutoLaunchBot1.Checked));
        }

        private void AutoLaunchPart2_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Part2", INIFunctions.InterpretINISetting(AutoLaunchPart2.Text,
                V3LauncherConstants.InstrumentPartNames[0], V3LauncherConstants.InstrumentPartNames[1]));
        }

        private void AutoLaunchDifficulty2_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Difficulty2", AutoLaunchDifficulty2.Text.ToLower());
        }

        private void AutoLaunchBot2_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Bot2", INIFunctions.BoolToString(AutoLaunchBot2.Checked));
        }

        private void AutoLaunchPart3_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Part3", INIFunctions.InterpretINISetting(AutoLaunchPart3.Text,
                V3LauncherConstants.InstrumentPartNames[0], V3LauncherConstants.InstrumentPartNames[1]));
        }

        private void AutoLaunchDifficulty3_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Difficulty3", AutoLaunchDifficulty3.Text.ToLower());
        }

        private void AutoLaunchBot3_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Bot3", INIFunctions.BoolToString(AutoLaunchBot3.Checked));
        }

        private void AutoLaunchPart4_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Part4", INIFunctions.InterpretINISetting(AutoLaunchPart4.Text,
                V3LauncherConstants.InstrumentPartNames[0], V3LauncherConstants.InstrumentPartNames[1]));
        }

        private void AutoLaunchDifficulty4_SelectedIndexChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Difficulty4", AutoLaunchDifficulty4.Text.ToLower());
        }

        private void AutoLaunchBot4_CheckedChanged(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("AutoLaunch", "Bot4", INIFunctions.BoolToString(AutoLaunchBot4.Checked));
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

    }
}
