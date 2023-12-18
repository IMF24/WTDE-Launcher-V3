// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       C O R E       F U N C T I O N A L I T Y
//
//    Internal class of important functions used by the V3 launcher. This has
//    the code for update checking, mod folder scanning, etc.
// ----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Launcher_V3 {
    /// <summary>
    ///  Internal class of important functions used by the V3 launcher. This has
    ///  the code for update checking, mod folder scanning, etc.
    /// </summary>
    internal class V3LauncherCore {
        /// <summary>
        ///  Internal debug log written by the V3 Launcher. Writes to debug_launcher.txt in the user's Documents folder.
        /// </summary>
        public static List<string> DebugLog = new List<string> {
            "~=-=~=-=~      W T D E     L A U N C H E R     V 3      ~=-=~=-=~",
            $"WTDE Launcher Execution Debug Log: V{V3LauncherConstants.VERSION}",
            $"Date of Execution: {DateTime.Now.ToString()}",
            "~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~"
        };

        /// <summary>
        ///  Add entry to the debug log. Prefix is surrounded in square brackets ( [] ).
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="prefix"></param>
        public static void AddDebugEntry(string entry, string prefix = "V3 Launcher") {
            DebugLog.Add($"[{prefix}] {entry}");
        }

        /// <summary>
        ///  Write the V3 launcher's debug log to the Logs directory in Documents.
        /// </summary>
        public static void WriteDebugLog() {
            string saveDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/My Games/Guitar Hero World Tour Definitive Edition/Logs/debug_launcher.txt";
            using (StreamWriter sw = new StreamWriter(saveDir)) {
                foreach (string line in DebugLog) sw.WriteLine(line);
            }
        }

        /// <summary>
        ///  Using MD5 hash checks, checks for updates to GHWT: DE.
        /// </summary>
        public static void CheckForUpdates() {
            // Does updater not exist?
            if (!File.Exists("Updater.exe")) {
                // Attempt to download the updater files.
                string noUpdaterExistsMessage = "The updater program and its necessary files were not found in this folder!\n" +
                                                "Do you want to download it from the GHWT: DE website?";
                if (MessageBox.Show(noUpdaterExistsMessage, "No Updater Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    try {
                        using (var client = new WebClient()) {
                            client.DownloadFile("https://ghwt.de/meta/Updater.exe", "Updater.exe");
                            client.DownloadFile("https://ghwt.de/meta/libcurl.dll", "libcurl.dll");
                        }

                        // Also write a new INI file (Updater.ini) in this folder.
                        if (!File.Exists("Updater.ini")) {
                            using (StreamWriter sw = new StreamWriter("Updater.ini")) {
                                sw.WriteLine("[Updater]");
                                sw.WriteLine($"GameDirectory={Directory.GetCurrentDirectory()}\nAutoUpdate=1\nStartAfterFinish=1");
                            }
                        }

                        string updaterFilesDownloaded = "All files were downloaded!\n\n" +
                                                        "If the program fails to begin the update due to a virus flag, it is" +
                                                        "a FALSE POSITIVE! You might have to allow these files in Windows or" +
                                                        "create an exception in your antivirus software.";
                        MessageBox.Show(updaterFilesDownloaded, "Updater Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception exc) {
                        MessageBox.Show($"An error occurred in downloading the files:\n\n{exc}", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        ///  Automatically run an update check when the launcher starts up, if designated.
        /// </summary>
        public static void AutoCheckForUpdates() {
            bool autoUpdate = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Launcher", "CheckForUpdates", "1"));
            if (autoUpdate) CheckForUpdates();
        }

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

        /// <summary>
        ///  Opens a specific website. This handles all the complicated stuff to do this.
        /// </summary>
        /// <param name="site"></param>
        public static void OpenSiteURL(string site) {
            var url = site;
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = url;
            System.Diagnostics.Process.Start(psi);
        }

        /// <summary>
        ///  Get the latest version of WTDE from the hashlist.
        /// </summary>
        /// <returns></returns>
        public static string GetLatestVersion() {
            using (WebClient client = new WebClient()) {
                string downloadString = client.DownloadString("https://gitgud.io/fretworks/ghwt-de-volatile/-/raw/master/GHWTDE/hashlist.dat");
                return downloadString.Split('\n')[1];
            }
        }
        
        /// <summary>
        ///  Update the form with the correct window title based on the various seasonal themes.
        /// </summary>
        /// <param name="form"></param>
        public static void SetWindowTitle(System.Windows.Forms.Form form) {
            // Random number selection.
            Random random = new Random();
            int selectedID;

            // What is the current month?
            switch (DateTime.Now.Month) {
                case 10:
                    selectedID = random.Next(0, V3LauncherConstants.RandomWindowTitlesHW.Length);
                    form.Text = $"GHWT: Definitive Edition Launcher - V{V3LauncherConstants.VERSION} - {V3LauncherConstants.RandomWindowTitlesHW[selectedID]}";
                    break;

                case 12:
                    if (DateTime.Now.Day >= 1 && DateTime.Now.Day <= 25) {
                        selectedID = random.Next(0, V3LauncherConstants.RandomWindowTitlesXM.Length);
                        form.Text = $"GHWT: Definitive Edition Launcher - V{V3LauncherConstants.VERSION} - {V3LauncherConstants.RandomWindowTitlesXM[selectedID]}";
                    }
                    break;

                default:
                    selectedID = random.Next(0, V3LauncherConstants.RandomWindowTitles.Length);
                    form.Text = $"GHWT: Definitive Edition Launcher - V{V3LauncherConstants.VERSION} - {V3LauncherConstants.RandomWindowTitles[selectedID]}";
                    break;
            }
        }

        /// <summary>
        ///  Returns true or false if a string contains only numeric digits.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDigitsOnly(string str) {
            foreach (char c in str) {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        /// <summary>
        ///  Take an Aspyr keyboard mapping string and decode a specific input from it.
        /// </summary>
        /// <param name="sIDKeyBindString"></param>
        /// <param name="inputKey"></param>
        /// <returns>
        ///  Returns a set of decoded keyboard inputs from the given string.
        /// </returns>
        public static string AspyrKeyDecode(string sIDKeyBindString, string inputKey) {
            // Initial boiler plate stuff; key bind string being split at whitespaces, you get the idea.
            string bindString = XMLFunctions.AspyrGetString(sIDKeyBindString);
            string[] inputs = bindString.Split(' ');
            inputKey = inputKey.ToUpper();

            bool inputFound = false;
            string returnString = "";

            // Let's decode the inputs now!
            for (var i = 0; i < inputs.Length; i++) {
                // Have we found the input we want?
                if (inputFound) {
                    // Have we found an input we DO NOT want?
                    if (!IsDigitsOnly(inputs[i]) && inputs[i].ToUpper() != inputKey) {
                        break;
                    }

                    // Take the string and figure out what number corresponds to what input.
                    if (IsDigitsOnly(inputs[i].Trim())) {
                        foreach (string[] keyPair in V3LauncherConstants.AspyrKeyBinds) {
                            if (keyPair[0] == inputs[i]) {
                                returnString += keyPair[1] + " ";
                                break;
                            }
                        }
                    }

                // Is this the input we want?
                } else {
                    if (inputs[i].ToUpper() == inputKey) inputFound = true;
                }
            }
            // Add debug log entry and return the string!
            returnString = returnString.Trim();
            AddDebugEntry($"Aspyr key string {sIDKeyBindString} decoded inputs for input {inputKey}: {returnString}", "Aspyr Keybind Decoder");
            return returnString;
        }
    }
}
