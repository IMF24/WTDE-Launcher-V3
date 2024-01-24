using MadMilkman.Ini;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Launcher_V3 {
    public partial class DupeChecksumManager : Form {
        public DupeChecksumManager() {
            InitializeComponent();

            GetDupedChecksums();
            UpdateButtonStatus();
        }

        /// <summary>
        ///  List of song mod data with duplicated checksums.
        /// </summary>
        public List<List<string>> SongModData;

        public void GetDupedChecksums() {
            // Clear both lists of checksums and paths.
            DupedChecksumsList.Items.Clear();
            ModPathsList.Items.Clear();

            ModFoldersHeader.Text = "Mod Folders:";
            DupedChecksumsHeader.Text = "Refreshing...";

            // Also update the mod listing.
            ModHandler.ReadMods();

            Application.DoEvents();

            // This list will hold all song mod information.
            // This will work just like the V2 launcher's system for this:
            //   - Scan for all song mods.
            //   - 1st entry is the checksum, 2nd is the song's path.
            //   - For every subsequent find of a song mod, add another path after the first path.
            //   - If a list has 3 or more entries, that signals that we have a duplicate.
            List<List<string>> songMods = new List<List<string>>();

            // Now, loop through the user's mods for song mods.
            foreach (string[] mod in ModHandler.UserContentMods) {
                // Index 2: Mod type.
                // Is this a song mod?
                if (mod[2] == "Song") {
                    // Load this INI file, get the checksum.
                    IniFile file = new IniFile();
                    file.Load(mod[5]);

                    bool dupeFound = false;
                    var currentChecksum = file.Sections["SongInfo"].Keys["Checksum"].Value;

                    // Now, let's look for a duplicate here.
                    if (songMods.Count > 0) {
                        foreach (var songMod in songMods) {
                            dupeFound = (songMod[0] == currentChecksum);
                            if (dupeFound) {
                                songMod.Add(mod[5]);
                                break;
                            }
                        }
                        if (dupeFound) continue;
                    }

                    List<string> songModInfo = new List<string>() { file.Sections["SongInfo"].Keys["Checksum"].Value, mod[5] };
                    songMods.Add(songModInfo);
                }
            }

            // Now, we've got our song mods, let's add ONLY THE DUPLICATES to our list box.
            foreach (List<string> songMod in songMods) {
                if (songMod.Count > 2) DupedChecksumsList.Items.Add(songMod[0]);
            }
            DupedChecksumsHeader.Text = $"Duplicated Checksums ({DupedChecksumsList.Items.Count}):";

            // Let's also update the global list.
            SongModData = songMods;

            UpdateButtonStatus();

            if (DupedChecksumsList.Items.Count <= 0) {
                MessageBox.Show("You have no duplicated checksums!", "No Duplicates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        public void LoadDupedChecksumPaths() {
            // Clear the list out.
            ModPathsList.Items.Clear();

            // What is the checksum we're looking for?
            string checksumToLookFor = DupedChecksumsList.SelectedItems[0].ToString();

            // Now, let's find it, and load all paths.
            foreach (List<string> songMod in SongModData) {
                if (songMod[0] == checksumToLookFor) {
                    for (var i = 1; i < songMod.Count; i++) {
                        ModPathsList.Items.Add(songMod[i]);
                    }
                    break;
                }
            }

            ModFoldersHeader.Text = $"Mod Folders ({ModPathsList.Items.Count}):";
            UpdateButtonStatus();
        }

        public void UpdateButtonStatus() {
            bool enableButtons = (ModPathsList.SelectedItems.Count > 0);

            OpenModConfig.Enabled = enableButtons;
            OpenModFolder.Enabled = enableButtons;
            DeleteModFolder.Enabled = enableButtons;
        }

        private void CloseWindow_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void OpenModConfig_Click(object sender, EventArgs e) {
            Process.Start("notepad.exe", ModPathsList.SelectedItems[0].ToString());
        }

        private void OpenModFolder_Click(object sender, EventArgs e) {
            Process.Start("explorer.exe", Path.GetDirectoryName(ModPathsList.SelectedItems[0].ToString()));
        }

        private void DeleteModFolder_Click(object sender, EventArgs e) {
            string pathToDelete = Path.GetDirectoryName(ModPathsList.SelectedItems[0].ToString());

            string modDeleteWarning = "Are you sure you want to delete this mod folder from your mods? This cannot be undone!";

            if (MessageBox.Show(modDeleteWarning, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                if (Directory.Exists(pathToDelete)) Directory.Delete(pathToDelete, true);

                MessageBox.Show("Mod was successfully deleted.", "Mod Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetDupedChecksums();
                //~ LoadDupedChecksumPaths();
            }
        }

        private void DupedChecksumsList_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                LoadDupedChecksumPaths();
                UpdateButtonStatus();
            } catch (Exception exc) {
                V3LauncherCore.DebugLog.Add($"Minor error, don't worry about it // Exception: {exc.Message}");
            }
        }

        private void ModPathsList_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateButtonStatus();
        }

        private void RefreshDupeChecksumList_Click(object sender, EventArgs e) {
            GetDupedChecksums();
        }
    }
}
