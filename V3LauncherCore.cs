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
using MadMilkman.Ini;

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
                // Attempt to download the updater files.
                string noUpdaterExistsMessage = "The updater program and its necessary files were not found in this folder!\n" +
                                                "Do you want to download it from the GHWT: DE website?";
                if (MessageBox.Show(noUpdaterExistsMessage, "No Updater Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    try {
                        using (var client = new WebClient()) {
                            client.DownloadFile("https://ghwt.de/meta/Updater.exe", "Updater.exe");
                            client.DownloadFile("https://ghwt.de/meta/libcurl.dll", "libcurl.dll");
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
                    // We have the hash list string, let's split it at the newlines and find whatever the latest version number is.
                    string downloadString = client.DownloadString("https://gitgud.io/fretworks/ghwt-de-volatile/-/raw/master/GHWTDE/hashlist.dat");
                    string[] downloadLines = downloadString.Split(new char[] { '\r', '\n' });
                    // Index 1 (2nd item) is always the version number.
                    return downloadLines[1];
                }
            // If the user is not connected to the internet, show error message.
            } catch {
                // MessageBox.Show("No internet connection was found!", "Can't Update!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "??? (connect to internet)";
            }
        }

        /// <summary>
        ///  List of file types the V3 launcher will use in the DynamicTextBoxUpdate function.
        /// </summary>
        public enum FileFilterTypes {
            INI = 0,
            Folder = 1
        }

        /// <summary>
        ///  List of different mod types as an enum.
        /// </summary>
        public enum ModINITypes {
            /// <summary>
            ///  Song mod types.
            /// </summary>
            Song = 0,
            /// <summary>
            ///  Character mod types.
            /// </summary>
            Character = 1,
            /// <summary>
            ///  Instrument mod types.
            /// </summary>
            Instrument = 2,
            /// <summary>
            ///  Highway mod types.
            /// </summary>
            Highway = 3,
            /// <summary>
            ///  Venue mod types.
            /// </summary>
            Venue = 4,
            /// <summary>
            ///  Menu music mod types.
            /// </summary>
            MenuMusic = 5,
            /// <summary>
            ///  Song category mod types.
            /// </summary>
            Category = 6,
            /// <summary>
            ///  Gem theme mod types.
            /// </summary>
            Gems = 7,
            /// <summary>
            ///  Code script mod types.
            /// </summary>
            Script = 8
        }

        /// <summary>
        ///  Read data from a file or folder dialog, then update the given TextBox control.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tb"></param>
        public static void DynamicTextBoxUpdate(string initialDir, int filter, string title, int type, TextBox tb) {
            switch (type) {
                // INI file mode.
                case 0:
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Title = title;
                    openFileDialog.InitialDirectory = initialDir;
                    // Set the filter based on our preferences.
                    switch (filter) {
                        case 0:
                            openFileDialog.Filter = "Song Mod INIs (song.ini)|*song.ini";
                            break;

                        case 1:
                            openFileDialog.Filter = "Character Mod INIs (character.ini)|*character.ini";
                            break;

                        case 2:
                            openFileDialog.Filter = "Instrument Mod INIs (instrument.ini)|*instrument.ini";
                            break;

                        case 3:
                            openFileDialog.Filter = "Highway Mod INIs (highway.ini)|*highway.ini";
                            break;

                        case 4:
                            openFileDialog.Filter = "Venue Mod INIs (venue.ini)|*venue.ini";
                            break;

                        case 5:
                            openFileDialog.Filter = "Menu Music Mod INIs (menumusic.ini)|*menumusic.ini";
                            break;

                        case 6:
                            openFileDialog.Filter = "Song Category Mod INIs (category.ini)|*category.ini";
                            break;

                        case 7:
                            openFileDialog.Filter = "Gem Mod INIs (gems.ini)|*gems.ini";
                            break;

                        case 8:
                            openFileDialog.Filter = "Script Mod INIs (Mod.ini)|*Mod.ini";
                            break;

                        default:
                            openFileDialog.Filter = "INI Files (*.ini)|*.ini";
                            break;
                    }

                    if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                    // Get INI contents.
                    IniFile file = new IniFile();
                    file.Load(openFileDialog.FileName);

                    // Update text box with correct data.
                    switch (filter) {
                        case 0:
                            tb.Text = file.Sections["SongInfo"].Keys["Checksum"].Value;
                            break;

                        case 1:
                            tb.Text = file.Sections["CharacterInfo"].Keys["Name"].Value;
                            break;

                        case 2:
                            tb.Text = file.Sections["InstrumentInfo"].Keys["Name"].Value;
                            break;

                        case 3:
                            tb.Text = file.Sections["HighwayInfo"].Keys["Name"].Value;
                            break;

                        case 4:
                            tb.Text = file.Sections["VenueInfo"].Keys["PakPrefix"].Value;
                            break;

                        case 5:
                            tb.Text = file.Sections["MenuMusicInfo"].Keys["FSBName"].Value;
                            break;

                        case 6:
                            tb.Text = file.Sections["CategoryInfo"].Keys["Name"].Value;
                            break;

                        case 7:
                            tb.Text = file.Sections["GemInfo"].Keys["Name"].Value;
                            break;

                        case 8: default:
                            tb.Text = "";
                            break;
                    }
                    
                    break;

                // Folder mode.
                case 1:
                    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                    
                    if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

                    tb.Text = folderBrowserDialog.ToString().Replace("\\", "/").Split("/").Last();

                    break;
            }
        }
    }
}