// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       C O R E       F U N C T I O N A L I T Y
//
//    Internal class of important functions used by the V3 launcher. This has
//    the code for update checking, mod folder scanning, etc.
// ----------------------------------------------------------------------------
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

namespace WTDE_Launcher_V3 {
    /// <summary>
    ///  Internal class of important functions used by the V3 launcher. This has
    ///  the code for update checking, mod folder scanning, etc.
    /// </summary>
    internal class V3LauncherCore {
        /// <summary>
        ///  Using MD5 hash checks, checks for updates to GHWT: DE.
        /// </summary>
        public static bool CheckForUpdates() { 
            // Does updater not exist?
            if (!File.Exists("Updater.exe")) {
                // TODO: Sort this out later
            }

            // Get the MD5 hash of tb.pab.xen in the user's GHWT install folder.\
            string userMD5 = "";
            string repoMD5 = "";
            string latestVersion = "";
            using (var md5 = MD5.Create()) { 
                using (var file = File.OpenRead("DATA/PAK/tb.pab.xen")) {
                    var hash = md5.ComputeHash(file);
                    userMD5 = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            // Now we want the MD5 hash from the Git repository.
            try {
                using (WebClient client = new WebClient()) {
                    // We have the hash list string, let's split it at the newlines and find tb.pab.xen in the list.
                    string downloadString = client.DownloadString("https://gitgud.io/fretworks/ghwt-de-volatile/-/raw/master/GHWTDE/hashlist.dat");
                    string[] downloadLines = downloadString.Split(new char[] { '\r', '\n' });

                    latestVersion = downloadLines[1];

                    bool foundTB = false;

                    foreach (string line in downloadLines) {
                        // Is this file tb.pab?
                        if (line.Contains("tb.pab.xen")) {
                            foundTB = true;
                            continue;
                        }

                        // We found tb.pab!
                        if (foundTB) {
                            repoMD5 = line;
                            break;
                        }
                    }
                }
            // If the user is not connected to the internet, show error message.
            } catch {
                MessageBox.Show("No internet connection was found!", "Can't Update!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Debug.WriteLine($"user MD5 hash: {userMD5}");
            Debug.WriteLine($"repo MD5 hash: {repoMD5}");

            // Are these hashes the same?
            if (userMD5.ToUpper() == repoMD5.ToUpper()) {
                // They are, we're good!
                MessageBox.Show("You're already up to date!", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                // Does the user want to update?
                string askUpdateMessage = $"A new version of WTDE is available!\nThe latest version is {latestVersion}.\n\nDo you want to update now?";
                if (MessageBox.Show(askUpdateMessage, "Update WTDE?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    System.Diagnostics.Process.Start("Updater.exe");
                }
            }

            return true;
        }

        /// <summary>
        ///  Get the latest version of WTDE from the public Git repository.
        /// </summary>
        /// <returns></returns>
        public static string GetLatestVersion() {
            try {
                using (WebClient client = new WebClient()) {
                    // We have the hash list string, let's split it at the newlines and find tb.pab.xen in the list.
                    string downloadString = client.DownloadString("https://gitgud.io/fretworks/ghwt-de-volatile/-/raw/master/GHWTDE/hashlist.dat");
                    string[] downloadLines = downloadString.Split(new char[] { '\r', '\n' });

                    return downloadLines[1];
                }
            // If the user is not connected to the internet, show error message.
            } catch {
                // MessageBox.Show("No internet connection was found!", "Can't Update!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "??? (connect to internet)";


            }
        }
    }
}