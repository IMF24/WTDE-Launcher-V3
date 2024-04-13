// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       I N I       F U N C T I O N S
//
//    Various functions for dealing with INI files.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MadMilkman.Ini;

namespace WTDE_Launcher_V3.IO {
    /// <summary>
    ///  Various functions for dealing with GHWT: DE's INI file(s).
    /// </summary>
    internal class INIFunctions {
        /// <summary>
        ///  Checks if a boolean value (0/1) is present in GHWTDE.ini. Returns true if 1, false if 0.
        /// </summary>
        /// <param name="s">
        ///  The string to check.
        /// </param>
        /// <returns>
        ///  True if the given string is a string of "1". Returns false if it is not.
        /// </returns>
        public static bool GetBoolean(string s) {
            return (s == "1");
        }

        /// <summary>
        ///  Inverse operation of GetBoolean. Returns false if 1, true if 0.
        /// </summary>
        /// <param name="s">
        ///  The string to check.
        /// </param>
        /// <returns>
        ///  True if the given string is <b>not</b> a string of "1". Returns false if it is.
        /// </returns>
        public static bool GetBooleanInverse(string s) {
            return !(s == "1");
        }

        /// <summary>
        ///  Get boolean as a custom string.
        /// </summary>
        /// <param name="s">
        ///  The input string to be compared.
        /// </param>
        /// <param name="t">
        ///  The string to check the input string against.
        /// </param>
        /// <returns>
        ///  True if the input value string is equal to the input comparer string.
        /// </returns>
        public static bool GetBooleanCustomString(string s, string t) {
            return (s == t);
        }

        /// <summary>
        ///  Convert a boolean value to a 1 or 0 string.
        /// </summary>
        /// <param name="b">
        ///  Boolean value to be interpreted.
        /// </param>
        /// <returns>
        ///  A string of "1" if the value is true, and a string of "0" if the value is false.
        /// </returns>
        public static string BoolToString(bool b) {
            return (b ? "1" : "0");
        }

        /// <summary>
        ///  Inverse of <see cref="BoolToString(bool)"/>, returns a 1 or 0 string, but with the inverse boolean.
        /// </summary>
        /// <param name="b">
        ///  Boolean value to be interpreted.
        /// </param>
        /// <returns>
        ///  A string of "0" if the value is true, and a string of "1" if the value is false.
        /// </returns>
        public static string BoolToStringInverse(bool b) {
            return (b ? "0" : "1");
        }

        /// <summary>
        ///  Allows a custom string to be assigned between a true and false variable.
        /// </summary>
        /// <param name="b">
        ///  Boolean value to be changed to a string.
        /// </param>
        /// <param name="t">
        ///  String that will be returned if the given boolean value is true.
        /// </param>
        /// <param name="f">
        ///  String that will be returned if the given boolean value is false.
        /// </param>
        /// <returns>
        ///  A string based on the given true/false strings. If the boolean is true, the true string is returned.
        ///  If the boolean is false, the false string is returned.
        /// </returns>
        public static string BoolToStringCustom(bool b, string t, string f) {
            return (b ? t : f);
        }

        /// <summary>
        ///  In GHWTDE.ini, pulls a specific value from a specific section in the INI file. If the specified
        ///  value/section is not found, it will be written to the file.
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
        ///  The requested value from the given section and option as a string. Returns the fallback string
        ///  if the value was not found.
        /// </returns>
        public static string GetINIValue(string sect, string opt, string fallback = "0") {
            // Initialize MadMilkman's INI library, load GHWTDE.ini.
            IniFile file = new IniFile();
            file.Load(V3LauncherConstants.WTDEConfigDir);

            // Look for the option we specified in the arguments.
            foreach (var section in file.Sections) {
                if (section.Name == sect) {
                    foreach (var key in section.Keys) {
                        if (key.Name == opt) {
                            V3LauncherCore.AddDebugEntry($"Reading value of {opt} in {sect}, found {key.Value}", "INI Functions");
                            return key.Value.ToString();
                        }
                    }
                }
            }

            // If option doesn't exist, write it as a fallback.
            if (!file.Sections.Contains(sect)) file.Sections.Add(sect);
            if (!file.Sections[sect].Keys.Contains(opt)) file.Sections[sect].Keys.Add(opt);

            V3LauncherCore.AddDebugEntry($"Reading value of {opt} in {sect}; option not found, using fallback value {fallback}", "INI Functions");

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
        public static void SaveINIValue(string section, string key, string value) {
            IniFile file = new IniFile();
            file.Load(V3LauncherConstants.WTDEConfigDir);

            if (!file.Sections.Contains(section)) file.Sections.Add(section);
            if (!file.Sections[section].Keys.Contains(key)) file.Sections[section].Keys.Add(key);

            V3LauncherCore.AddDebugEntry($"Saving value {value} to {key} in {section} of GHWTDE.ini", "INI Functions");

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
        ///  Array of string values to match the input string against.
        /// </param>
        /// <param name="outValues">
        ///  Array of string values that will potentially be given back.
        /// </param>
        /// <returns>
        ///  An interpreted string from the given output array, relative to the index of its first occurrence in the input array of strings.
        ///  If the value is not found in the input values, the original value is returned back.
        /// </returns>
        public static string InterpretINISetting(string value, string[] inValues, string[] outValues) {
            if (inValues.Length != outValues.Length) throw new Exception("The input values and output values do not equal each other in length.");

            for (var i = 0; i < inValues.Length; i++) {
                if (inValues[i] == value) {
                    return outValues[i].ToString();
                }
            }

            return value;
        }

        /// <summary>
        ///  Takes an input string, and interprets it into something displayable to the end user OR
        ///  a string that can be written to GHWTDE.ini. Both input lists MUST match in length.
        ///  Raise Exception if input and output lists do not match in length.
        /// </summary>
        /// <param name="value">
        ///  Value string to interpret.
        /// </param>
        /// <param name="inValues">
        ///  List of string values to match the input string against.
        /// </param>
        /// <param name="outValues">
        ///  List of string values that will potentially be given back.
        /// </param>
        /// <returns>
        ///  An interpreted string from the given output list, relative to the index of its first occurrence in the input list of strings.
        ///  If the value is not found in the input values, the original value is returned back.
        /// </returns>
        public static string InterpretINISetting(string value, List<string> inValues, List<string> outValues) {
            if (inValues.Count != outValues.Count) throw new Exception("The input values and output values do not equal each other in length.");

            for (var i = 0; i < inValues.Count; i++) {
                if (inValues[i] == value) {
                    return outValues[i].ToString();
                }
            }

            return value;
        }
    }
}
