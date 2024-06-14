// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       H E L P E R       M E T H O D S
//          A N D       V A R I A B L E S
//
//    Various functions and variables meant to make writing code easier!
// ----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDE_Launcher_V3.Core {
    /// <summary>
    ///  Various functions and variables meant to make writing code easier!
    /// </summary>
    public class Helpers {
        /// <summary>
        ///  Normalize all path slashes!
        /// </summary>
        /// <param name="path">
        ///  Path to normalize slashes for.
        /// </param>
        /// <returns>
        ///  A path string with all slashes turned into forward slashes (/). Regardless of if a path has back slashes (\) or not,
        ///  all slashes in the given path will be turned into forward slashes.
        /// </returns>
        public static string NormalizeSlashes(string path) {
            return (path == null) ? Directory.GetCurrentDirectory() : path.Replace("\\", "/");
        }
    }
}
