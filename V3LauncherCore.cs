// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       C O R E       F U N C T I O N A L I T Y
//
//    Internal class of important functions used by the V3 launcher. This has
//    the code for update checking, mod folder scanning, etc.
//
//    This class has several bits of important functionality:
//    - Has the code for update checking using MD5 hash checks.
//    - Contains logic for the launcher's debug log.
//    - Has the ability to decode Aspyr keyboard input mapping strings.
//    - Reads various data from ghwt.de and the GHWT: DE Volatile repository.
//    - And many other important things!
// ----------------------------------------------------------------------------
// Any various imports we may require.
using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MadMilkman.Ini;
using Microsoft.Win32;

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
        ///  Allows for developer settings window. NEVER ALLOW THIS IN PUBLIC BUILDS.
        /// </summary>
        /// <returns></returns>
        public static bool AllowDevSettings() {
            if (File.Exists("dev_settings_enable")) {
                using (var md5 = MD5.Create()) {
                    using (var file = File.OpenRead("dev_settings_enable")) {
                        // THIS HASH MUST MATCH.
                        var hash = md5.ComputeHash(file);
                        return (BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant() == "3D663C297E547366D7429491D7EE7BBC");
                    }
                }
            } else return false;
        }

        /// <summary>
        ///  Attempt to guess the user's GHWT installation path. Reads the Windows Registry to see if it can find the
        ///  installation. If it can, it returns that path. If not, return the current working directory.
        /// </summary>
        /// <returns></returns>
        public static string GHWTInstallPathGuess() {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Aspyr\\Guitar Hero World Tour")) {
                if (key != null) {
                    string ghwtPath = key.GetValue("Path").ToString().Replace("\\", "/").TrimEnd('/');
                    if (File.Exists($"{ghwtPath}/GHWT.exe")) {
                        return ghwtPath;
                    } else {
                        return Directory.GetCurrentDirectory();
                    }
                }
            }
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        ///  Using MD5 hash checks, checks for updates to GHWT: DE.
        /// </summary>
        public static void CheckForUpdates(bool usingAutoUpdate = false) {
            // Does updater not exist?
            if (!File.Exists("WTDE-Updater-V2.exe") && !File.Exists("Updater.ini")) {
                // Attempt to download the updater files.
                string noUpdaterExistsMessage = "The updater program and its necessary files were not found in this folder!\n" +
                                                "Do you want to download them from the GHWT: DE website?";
                if (MessageBox.Show(noUpdaterExistsMessage, "No Updater Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    try {
                        using (var client = new WebClient()) {
                            // Download the ZIP file, extract it!
                            client.DownloadFile("https://ghwt.de/meta/WTDE-Updater-V2.zip", "WTDE-Updater-V2.zip");
                            System.IO.Compression.ZipFile.ExtractToDirectory("WTDE-Updater-V2.zip", ".");
                            File.Delete("WTDE-Updater-V2.zip");
                        }

                        // Also write a new INI file (Updater.ini) in this folder.
                        if (!File.Exists("Updater.ini")) {
                            using (StreamWriter sw = new StreamWriter("Updater.ini")) {
                                sw.WriteLine("[Updater]");
                                sw.WriteLine($"GameDirectory={GHWTInstallPathGuess()}\nAutoUpdate=1\nStartAfterFinish=1");
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

            // Updater DOES exist, let's update the user's mod!
            } else {
                IniFile file = new IniFile();
                file.Load("Updater.ini");

                string wtdeDir = file.Sections["Updater"].Keys["GameDirectory"].Value;
                string userMD5 = "", repoMD5 = "";

                // Check the MD5 hash of tb.pab.xen.
                using (var md5 = MD5.Create()) {
                    using (var tbFile = File.OpenRead($"{wtdeDir}/DATA/PAK/tb.pab.xen")) { 
                        var hash = md5.ComputeHash(tbFile);
                        userMD5 = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                }

                // Now get the hash on the website.
                using (WebClient client = new WebClient()) {
                    string downloadString = client.DownloadString(V3LauncherConstants.WTDEHashList);
                    string[] hashListData = downloadString.Split(new char[] { '\r', '\n' });

                    bool tbPABFound = false;

                    foreach (string item in hashListData) {
                        // We found it, let's get its hash!
                        if (tbPABFound) {
                            repoMD5 = item;
                            break;
                        }

                        // Is this tb.pab.xen?
                        tbPABFound = item.Contains("tb.pab.xen");
                    }
                }

                // User and repo's MD5 hashes do not match, alert them about an update!
                if (userMD5 != repoMD5) {
                    string updateAlertString = $"A new version of WTDE is available!\nThe latest version is {GetLatestVersion()}.\n\n" +
                                               $"Do you want to download it now? This will close the launcher.";

                    if (MessageBox.Show(updateAlertString, "Update WTDE?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        Process.Start("WTDE-Updater-V2.exe");
                        Environment.Exit(0);
                    }

                // User is all good!
                } else {
                    if (!usingAutoUpdate) MessageBox.Show("You're already up to date!", "Up to Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        ///  Automatically run an update check when the launcher starts up, if designated.
        /// </summary>
        public static void AutoCheckForUpdates() {
            bool autoUpdate = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Launcher", "CheckForUpdates", "1"));
            if (autoUpdate) CheckForUpdates(true);
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
                    } else {
                        selectedID = random.Next(0, V3LauncherConstants.RandomWindowTitles.Length);
                        form.Text = $"GHWT: Definitive Edition Launcher - V{V3LauncherConstants.VERSION} - {V3LauncherConstants.RandomWindowTitles[selectedID]}";
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

        /// <summary>
        ///  After reading either a file or directory from an Open dialog, populate the given text box with the result.
        ///  <br/>
        ///  Mode 0 is for file browsing, mode 1 is for folder/directory browsing.
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="textBox"></param>
        /// <param name="filter"></param>
        public static void TextBoxReadFromDialog(int mode, TextBox textBox, string title, bool stripPath = true, string filter = "All Files|*.*") {
            string resultingValue;
            string oldText = textBox.Text;
            if (mode == 0) {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = filter;
                dialog.Title = title;

                dialog.ShowDialog();

                resultingValue = (dialog.FileName != "") ? (stripPath) ? dialog.FileName.Replace("\\", "/").Split('/').Last() : dialog.FileName : oldText;
            } else {
                FolderBrowserDialog dialog = new FolderBrowserDialog();

                dialog.ShowDialog();

                resultingValue = (dialog.SelectedPath != "") ? (stripPath) ? dialog.SelectedPath.Replace("\\", "/").Split('/').Last() : dialog.SelectedPath : oldText;
            }
            textBox.Text = resultingValue;
        }
    }
}
