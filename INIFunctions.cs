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
    }
}
