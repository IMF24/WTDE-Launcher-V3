// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       M O D       F I N D E R
//
//    The Mod Manager's mod finder, which searches through the user's MODS
//    folder for specific mods based on specific filters.
// ----------------------------------------------------------------------------
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
using MadMilkman.Ini;

namespace WTDE_Launcher_V3 {
    public partial class ModFinder : Form {
        public ModFinder() {
            InitializeComponent();
            UpdateActionButtons();
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FindModsButton_Click(object sender, EventArgs e) {
            FindResultsList.Items.Clear();
            SearchResultsHeader.Text = "Searching...";

            UpdateActionButtons();

            Application.DoEvents();

            // Find mods with the given filters.
            List<string> matchedMods = new List<string>();

            string modNameFilter = ModName.Text.ToLower();
            string modAuthorFilter = ModAuthor.Text.ToLower();
            string modVersionFilter = ModVersion.Text.ToLower();
            string modDescriptionFilter = ModDescription.Text.ToLower();
            string modPathFilter = PathFilter.Text.ToLower();

            string modTypeFilter = "";

            // WHAT MODS ARE WE LOOKING FOR?
            // -- MOD TYPE FILTER --
            if (FindAllMods.Checked) {
                modTypeFilter = "";
            } else if (FindSongs.Checked) {
                modTypeFilter = "Song";
            } else if (FindCategories.Checked) {
                modTypeFilter = "Song Category";
            } else if (FindCharacters.Checked) {
                modTypeFilter = "Character";
            } else if (FindInstruments.Checked) {
                modTypeFilter = "Instrument";
            } else if (FindHighways.Checked) {
                modTypeFilter = "Highway";
            } else if (FindVenues.Checked) {
                modTypeFilter = "Venue";
            } else if (FindMenuMusics.Checked) {
                modTypeFilter = "Menu Music";
            } else if (FindGemThemes.Checked) {
                modTypeFilter = "Gem Theme";
            } else if (FindScripts.Checked) {
                modTypeFilter = "Script";
            }

            // -- MOD CONFIG FILE FILTER --
            string modFileFilter = ".ini";
            switch (modTypeFilter) {
                case "Song":
                    modFileFilter = "song.ini";
                    break;

                case "Song Category":
                    modFileFilter = "category.ini";
                    break;

                case "Character":
                    modFileFilter = "character.ini";
                    break;

                case "Instrument":
                    modFileFilter = "instrument.ini";
                    break;

                case "Highway":
                    modFileFilter = "highway.ini";
                    break;

                case "Venue":
                    modFileFilter = "venue.ini";
                    break;

                case "Menu Music":
                    modFileFilter = "menumusic.ini";
                    break;

                case "Gem Theme":
                    modFileFilter = "gems.ini";
                    break;

                case "Script":
                    modFileFilter = "Mod.ini";
                    break;

                default:
                    modFileFilter = ".ini";
                    break;
            }

            // Now, let's do some looping.
            // And... A LOT of looping.
            foreach (string[] mod in ModHandler.UserContentMods) {
                // Here's how we'll approach this.
                // First, we'll see if we've found the type of mod we want.
                // If this is the filtered type of mod we want, let's analyze it.
                if (mod[2] == modTypeFilter || modTypeFilter == "") {
                    // Do we have a path to check?
                    if (modPathFilter != "") {
                        if (!mod[5].ToLower().Contains(modPathFilter.Replace("/", "\\"))) continue;
                    }

                    // Now we'll check INI settings.
                    IniFile file = new IniFile();
                    file.Load(mod[5]);

                    // Name filter?
                    if (modNameFilter != "") {
                        try {
                            if (!file.Sections["ModInfo"].Keys["Name"].Value.ToLower().Contains(modNameFilter)) continue;
                        } catch {
                            if (modTypeFilter == "Venue") {
                                if (!file.Sections["VenueInfo"].Keys["Name"].Value.ToLower().Contains(modNameFilter)) continue;
                            } else continue;
                        }
                    }

                    // Author filter?
                    if (modAuthorFilter != "") {
                        if (!file.Sections["ModInfo"].Keys["Author"].Value.ToLower().Contains(modAuthorFilter)) continue;
                    }

                    // Version filter?
                    if (modVersionFilter != "") {
                        if (!file.Sections["ModInfo"].Keys["Version"].Value.ToLower().Contains(modVersionFilter)) continue;
                    }

                    // Description filter?
                    if (modDescriptionFilter != "") {
                        if (!file.Sections["ModInfo"].Keys["Description"].Value.ToLower().Contains(modDescriptionFilter)) continue;
                    }

                    // If we made it past all of this, we can add it to the list!
                    matchedMods.Add(mod[5]);
                    file.Sections.Clear();
                }
            }

            if (matchedMods.Count > 0) {
                foreach (string path in matchedMods) {
                    FindResultsList.Items.Add(path);
                    SearchResultsHeader.Text = $"Search Results: {FindResultsList.Items.Count} Matches Found";
                }
            } else {
                SearchResultsHeader.Text = $"No Matches Found";
            }

            UpdateActionButtons();
        }

        public void UpdateActionButtons() {
            bool enableButton = (FindResultsList.Items.Count > 0 && FindResultsList.SelectedItems.Count > 0);

            CopySelectedPath.Enabled = enableButton;
            OpenSelectedConfig.Enabled = enableButton;
            OpenSelectedFolder.Enabled = enableButton;
            DeleteSelectedMod.Enabled = enableButton;
        }

        private void CopySelectedPath_Click(object sender, EventArgs e) {
            try {
                Clipboard.SetText(FindResultsList.SelectedItems[0].ToString());
            } catch (Exception exc) {
                V3LauncherCore.DebugLog.Add($"Clipboard error, don't worry about it // Exception: {exc.Message}");
            }
        }

        private void OpenSelectedConfig_Click(object sender, EventArgs e) {
            Process.Start("notepad.exe", FindResultsList.SelectedItems[0].ToString());
        }

        private void OpenSelectedFolder_Click(object sender, EventArgs e) {
            Process.Start("explorer.exe", Path.GetDirectoryName(FindResultsList.SelectedItems[0].ToString()));
        }

        private void DeleteSelectedMod_Click(object sender, EventArgs e) {
            string path = Path.GetDirectoryName(FindResultsList.SelectedItems[0].ToString());

            string warningMessage = "Warning: Are you sure you want to delete this mod? This cannot be undone!";

            if (MessageBox.Show(warningMessage, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                Directory.Delete(path, true);
            }
        }

        private void FindResultsList_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateActionButtons();
        }
    }
}
