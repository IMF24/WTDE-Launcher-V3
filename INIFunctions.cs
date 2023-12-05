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
                            string retnValue = key.Value.ToString();
                            file = null;
                            GC.Collect();
                            return retnValue;
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
        ///  Takes an input string, and interprets it into something displayable to the end user OR
        ///  a string that can be written to GHWTDE.ini. Both input arrays MUST match in length.
        ///  Raise Exception if input and output arrays do not match in length.
        /// </summary>
        /// <param name="value">
        ///  Value string to interpret.
        /// </param>
        /// <param name="inValues">
        ///  Values to match the input value against.
        /// </param>
        /// <param name="outValues">
        ///  Values that will potentially be given back.
        /// </param>
        /// <returns></returns>
        public static string InterpretINISetting(string value, string[] inValues, string[] outValues)
        {
            if (inValues.Length != outValues.Length) throw new Exception("The input values and output values do not equal each other in length.");

            for (var i = 0; i < inValues.Length; i++)
            {
                if (inValues[i] == value) {
                    return outValues[i].ToString();
                }
            }
            return "";
        }

        /// <summary>
        ///  QPO difficulties names. | Index 0: Option names | Index 1: INI option values
        /// </summary>
        public static string[][] QPODifficulties = {
            new string[] { "Beginner", "Easy", "Medium", "Hard", "Expert" },
            new string[] { "easy_rhythm", "easy", "normal", "hard", "expert" }
        };
    }
}
