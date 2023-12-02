// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       T A B       H A N D L E R       C L A S S
//
//    This class controls various tab-related things.
// ----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WTDE_Launcher_V3 {
    internal class TabHandler {
        /// <summary>
        ///  Returns the MOTD text from the GHWT: DE website. This content is located at https://ghwt.de/meta/motd.txt. Returns placeholder
        ///  MOTD upon failure to establish an internet connection.
        /// </summary>
        /// <returns>
        ///  String of text containing the MOTD. Gives back fallback MOTD if it fails.
        /// </returns>
        public static string GetMOTDText() {
            try {
                using (WebClient client = new WebClient()) {
                    string downloadString = client.DownloadString("https://ghwt.de/meta/motd.txt");
                    return downloadString;
                }
            } catch {
                string retnString = "MOTD not found, call IMF!\n\nIf you're seeing this, it means we probably couldn't establish a connection to the internet.";
                return retnString;
            }
        }
    }
}
