// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       I N I       F U N C T I O N S
//
//    Various functions for dealing with INI files.
// ----------------------------------------------------------------------------
using MadMilkman.Ini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Windows.Forms;

namespace WTDE_Launcher_V3 {
    /// <summary>
    ///  Various functions for dealing with INI files.
    /// </summary>
    internal class INIFunctions {
        /// <summary>
        ///  Checks if a boolean value (0/1) is present in GHWTDE.ini. Returns true if 1, false if 0.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool GetBoolean(string s)
        {
            return (s == "1") ? true : false;
        }

        /// <summary>
        ///  Inverse operation of GetBoolean. Returns false if 1, true if 0.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool GetBooleanInverse(string s)
        {
            return (s == "1") ? false : true;
        }

        /// <summary>
        ///  Convert a boolean value to a 1 or 0 string.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string BoolToString(bool b)
        {
            return (b ? "1" : "0");
        }

        /// <summary>
        ///  Inverse of BoolToString, returns a 1 or 0 string, but with the inverse boolean.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string BoolToStringInverserse(bool b) { 
            return (b ? "0" : "1");
        }

        /// <summary>
        ///  In GHWTDE.ini, pulls a specific value from a specific section in the INI file.
        /// </summary>
        /// <param name="sect">
        ///  Section in GHWTDE.ini to pull data from.
        /// </param>
        /// <param name="opt">
        ///  Option/Key name in the section to look for.
        /// </param>
        /// <param name="fallback">
        ///  Optional: Fallback value that will be returned. Default is "0".
        /// </param>
        /// <returns>
        ///  Returns the requested value as a string. Returns a string of "0" when not found.
        /// </returns>
        public static string GetINIValue(string sect, string opt, string fallback = "0")
        {
            // Initialize MadMilkman's INI library, load GHWTDE.ini.
            IniFile file = new IniFile();
            file.Load(V3LauncherConstants.WTDEConfigDir);

            // Look for the option we specified in the arguments.
            foreach (var section in file.Sections)
            {
                if (section.Name == sect)
                {
                    foreach (var key in section.Keys)
                    {
                        if (key.Name == opt)
                        {
                            return key.Value.ToString();
                        }
                    }
                }
            }

            // If option doesn't exist, write it as a fallback.
            if (!file.Sections.Contains(sect)) file.Sections.Add(sect);
            if (!file.Sections[sect].Keys.Contains(opt)) file.Sections[sect].Keys.Add(opt);

            file.Sections[sect].Keys[opt].Value = fallback;
            file.Save(V3LauncherConstants.WTDEConfigDir);
            return fallback.ToString();
        }

        /// <summary>
        ///  Saves a value to GHWTDE.ini.
        /// </summary>
        /// <param name="section">
        ///  INI section this option is under.
        /// </param>
        /// <param name="key">
        ///  Name of the option in the given section.
        /// </param>
        /// <param name="value">
        ///  Value to assign to this option.
        /// </param>
        public static void SaveINIValue(string section, string key, string value)
        {
            IniFile file = new IniFile();
            file.Load(V3LauncherConstants.WTDEConfigDir);

            if (!file.Sections.Contains(section)) file.Sections.Add(section);
            if (!file.Sections[section].Keys.Contains(key)) file.Sections[section].Keys.Add(key);

            file.Sections[section].Keys[key].Value = value;
            file.Save(V3LauncherConstants.WTDEConfigDir);
        }

        /// <summary>
        ///  Takes an input INI setting read from GHWTDE.ini, and interprets it into something displayable to the end user.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inValues"></param>
        /// <param name="outValues"></param>
        /// <returns></returns>
        public static string InterpretINISetting(string value, string[] inValues, string[] outValues)
        {
            for (var i = 0; i < inValues.Length; i++)
            {
                if (inValues[i] == value) {
                    return outValues[i].ToString();
                }
            }
            return "";
        }

        public static string[] QPODifficulties = { "easy_rhythm", "easy", "normal", "hard", "expert" };
        public static string[] QPODifficultiesNames = { "Beginner", "Easy", "Medium", "Hard", "Expert" };

        /// <summary>
        ///  The default contents of GHWTDE.ini.
        /// </summary>
        public static string DefaultINIContents =
@"# --------------------------------------------------
#   GHWT: Definitive Edition Config
# 
#     Auto generated by WTDE Launcher V3
#
#   All settings are annotated for your convenience!
# --------------------------------------------------
[Config]
# Uses Discord's rich presence feature; includes data about the current song, game mode, etc. | 1 = ON, 0 = OFF
RichPresence=1
# During certain times of the year, triggers certain holiday themes! | 1 = ON, 0 = OFF
AllowHolidays=1
# When enabled, writes files for streamers to use when playing, including song title, venue, artist, etc. | 1 = ON, 0 = OFF
StatusHandler=1
# Should the Career command be shown on the main menu? | 1 = Yes, 0 = No
UseCareerOption=1
# Should the Quickplay command be shown on the main menu? | 1 = Yes, 0 = No
UseQuickplayOption=1
# Should the Head to Head command be shown on the main menu? | 1 = Yes, 0 = No
UseHeadToHeadOption=1
# Should the Online command be shown on the main menu? | 1 = Yes, 0 = No
UseOnlineOption=1
# Should the Music Studio command be shown on the main menu? | 1 = Yes, 0 = No
UseMusicStudioOption=1
# Should the Rock Star Creator command be shown on the main menu? | 1 = Yes, 0 = No
UseCAROption=1
# Should the Options command be shown on the main menu? | 1 = Yes, 0 = No
UseOptionsOption=1
# Should the Exit command be shown on the main menu? | 1 = Yes, 0 = No
UseQuitOption=1

SongSpecificInstruments=0

DefaultQPODifficulty=expert

EnableCamPulse=1

SplashScreenDelay=0

AttractDelay=110

Language=en

Holiday=

MelodyAudioMode=permanent";
    }
}
