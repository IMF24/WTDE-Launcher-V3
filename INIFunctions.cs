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
        ///  In GHWTDE.ini, pulls a specific value from a specific section in the INI file.
        /// </summary>
        /// <param name="sect">
        ///  Section in GHWTDE.ini to pull data from.
        /// </param>
        /// <param name="opt">
        ///  Option/Key name in the section to look for.
        /// </param>
        /// <returns>
        ///  Returns the requested value as a string. Returns a string of "0" when not found.
        /// </returns>
        public static string GetINIValue(string sect, string opt)
        {
            IniFile file = new IniFile();
            file.Load(V3LauncherConstants.WTDEConfigDir);

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

            return "0";
        }
    }
}
