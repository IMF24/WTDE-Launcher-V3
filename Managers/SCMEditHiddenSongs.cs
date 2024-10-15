// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       S O N G       A N D       C A T E G O R Y       M A N A G E R
//          M A N A G E       H I D D E N       S O N G S
//
//    The Mod Manager's song and song category mod manager's dialog for editing
//    what songs are and are not visible on certain instruments.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;
using WTDE_Launcher_V3.IO;

// Other required imports.
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WTDE_Launcher_V3.Managers {
    /// <summary>
    ///  The Mod Manager's song and song category mod manager's dialog for editing
    ///  what songs are and are not visible on certain instruments.
    /// </summary>
    public partial class SCMEditHiddenSongs : Form {
        /// <summary>
        ///  The Mod Manager's song and song category mod manager's dialog for editing
        ///  what songs are and are not visible on certain instruments.
        /// </summary>
        public SCMEditHiddenSongs(List<string> iniPathList) {
            // You get the idea, initialize Designer stuff
            InitializeComponent();
            UpdateControlStatus();

            // ----------------------

            // Parse our INI files!
            SongINIPaths = iniPathList;

            // No paths? Break away!
            if (SongINIPaths.Count <= 0) {
                return;

            // We DO have paths!
            } else {
                // Begin looping!
                for (var i = 0; i < SongINIPaths.Count; i++) {
                    // Get the current INI path.
                    string iniPath = SongINIPaths[i];

                    // Make INI object.
                    INI file = new INI(iniPath);

                    // Get the artist, title, and checksum of the song!
                    string songTitle = $"{file.GetString("SongInfo", "Artist", "Unknown Artist")} - {file.GetString("SongInfo", "Title", "Unknown Title")}";
                    string songChecksum = file.GetString("SongInfo", "Checksum", $"unkChecksum{i + 1}");

                    // Now read our visibilities.
                    bool canViewG = file.GetBool("SongInfo", "HideInSetlistG", true);
                    bool canViewB = file.GetBool("SongInfo", "HideInSetlistB", true);
                    bool canViewD = file.GetBool("SongInfo", "HideInSetlistD", true);
                    bool canViewV = file.GetBool("SongInfo", "HideInSetlistV", true);
                    bool canViewA = file.GetBool("SongInfo", "HideInSetlistA", true);

                    // Make a boolean array and add it to the visibility map!
                    bool[] canViewArray = new bool[] { canViewG, canViewB, canViewD, canViewV, canViewA };
                    SongVisibilityMap.Add(canViewArray);

                    // Now we want to add a list view item to the list view!
                    // First, get the status strings based on our boolean values.
                    string viewStringG = (canViewG) ? "ON" : "OFF";
                    string viewStringB = (canViewB) ? "ON" : "OFF";
                    string viewStringD = (canViewD) ? "ON" : "OFF";
                    string viewStringV = (canViewV) ? "ON" : "OFF";
                    string viewStringA = (canViewA) ? "ON" : "OFF";

                    // String array to add as a list view item!
                    string[] viewItemData = new string[] { songTitle, songChecksum, viewStringG, viewStringB, viewStringD, viewStringV, viewStringA };
                    
                    // Make the item and add it!
                    ListViewItem lvi = new ListViewItem(viewItemData);
                    SongListView.Items.Add(lvi);
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  List of paths to the song INI files.
        /// </summary>
        public List<string> SongINIPaths = new List<string>();

        /// <summary>
        ///  Map of booleans for each song.
        /// </summary>
        public List<bool[]> SongVisibilityMap = new List<bool[]>();

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Actually writes the visibility changes!
        /// </summary>
        public void WriteVisibilityChanges() {
            // Go through each INI path and write our changes!
            for (var i = 0; i < SongINIPaths.Count; i++) {
                // Get the current INI path!
                string iniPath = SongINIPaths[i];

                // INI file object.
                INI file = new INI(iniPath);

                // Write the booleans!
                file.SetBool("SongInfo", "HideInSetlistG", !SongVisibilityMap[i][0]);
                file.SetBool("SongInfo", "HideInSetlistB", !SongVisibilityMap[i][1]);
                file.SetBool("SongInfo", "HideInSetlistD", !SongVisibilityMap[i][2]);
                file.SetBool("SongInfo", "HideInSetlistV", !SongVisibilityMap[i][3]);
                file.SetBool("SongInfo", "HideInSetlistA", !SongVisibilityMap[i][4]);
            }
        }

        /// <summary>
        ///  Change the visiblity for the selected songs.
        /// </summary>
        /// <param name="member">
        ///  Band member for the visibility change to take effect on.
        /// </param>
        /// <param name="visible">
        ///  Optional: Do you want to make the song visible? Set to true to show it,
        ///  or false to hide it. True by default.
        /// </param>
        public void ChangeSongVisibility(Helpers.BandMembers member, bool visible = true) {
            // Do we have songs to change?
            if (SongListView.SelectedItems.Count <= 0 || SongListView.Items.Count <= 0) return;

            // Text we want to display!
            string changeText = (visible) ? "ON" : "OFF";

            // Iterate through our selection!
            foreach (int idx in SongListView.SelectedIndices) {
                // Get the list view item!
                ListViewItem item = SongListView.Items[idx];

                // Now, which band member did we specify?
                switch (member) {
                    // -- LEAD GUITAR
                    case Helpers.BandMembers.Guitarist: default:
                        item.SubItems[2].Text = changeText;
                        SongVisibilityMap[idx][0] = visible;
                        break;

                    // -- BASS GUITAR
                    case Helpers.BandMembers.Bassist:
                        item.SubItems[3].Text = changeText;
                        SongVisibilityMap[idx][1] = visible;
                        break;

                    // -- DRUMS
                    case Helpers.BandMembers.Drummer:
                        item.SubItems[4].Text = changeText;
                        SongVisibilityMap[idx][2] = visible;
                        break;

                    // -- VOCALS
                    case Helpers.BandMembers.Vocalist:
                        item.SubItems[5].Text = changeText;
                        SongVisibilityMap[idx][3] = visible;
                        break;

                    // -- BAND (OR NONE)
                    case Helpers.BandMembers.None: case Helpers.BandMembers.Band:
                        item.SubItems[6].Text = changeText;
                        SongVisibilityMap[idx][4] = visible;
                        break;
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Update control statuses.
        /// </summary>
        public void UpdateControlStatus() { 
            bool usable = SongListView.SelectedItems.Count > 0;

            ShowOnGuitarButton.Enabled = usable;
            ShowOnBassButton.Enabled = usable;
            ShowOnDrumsButton.Enabled = usable;
            ShowOnVocalsButton.Enabled = usable;
            ShowOnBandButton.Enabled = usable;
            ShowForAllButton.Enabled = usable;

            HideOnGuitarButton.Enabled = usable;
            HideOnBassButton.Enabled = usable;
            HideOnDrumsButton.Enabled = usable;
            HideOnVocalsButton.Enabled = usable;
            HideOnBandButton.Enabled = usable;
            HideForAllButton.Enabled = usable;
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        // -- UPDATE INDEX: UPDATE CONTROLS
        private void SongListView_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateControlStatus();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // SHOW SONG COMMANDS
        // - - - - - - - - - - - - - - - - - - - - - - -

        // -- SHOW ON GUITAR
        private void ShowOnGuitarButton_Click(object sender, EventArgs e) {
            ChangeSongVisibility(Helpers.BandMembers.Guitarist, true);
        }

        // -- SHOW ON BASS
        private void ShowOnBassButton_Click(object sender, EventArgs e) {
            ChangeSongVisibility(Helpers.BandMembers.Bassist, true);
        }

        // -- SHOW ON DRUMS
        private void ShowOnDrumsButton_Click(object sender, EventArgs e) {
            ChangeSongVisibility(Helpers.BandMembers.Drummer, true);
        }

        // -- SHOW ON VOCALS
        private void ShowOnVocalsButton_Click(object sender, EventArgs e) {
            ChangeSongVisibility(Helpers.BandMembers.Vocalist, true);
        }

        // -- SHOW FOR BAND
        private void ShowOnBandButton_Click(object sender, EventArgs e) {
            ChangeSongVisibility(Helpers.BandMembers.Band, true);
        }

        // -- SHOW FOR ALL
        private void ShowForAllButton_Click(object sender, EventArgs e) {
            ChangeSongVisibility(Helpers.BandMembers.Guitarist, true);
            ChangeSongVisibility(Helpers.BandMembers.Bassist, true);
            ChangeSongVisibility(Helpers.BandMembers.Drummer, true);
            ChangeSongVisibility(Helpers.BandMembers.Vocalist, true);
            ChangeSongVisibility(Helpers.BandMembers.Band, true);
        }

        // -- SHOW FOR ALL SONGS ON ALL PARTS
        private void ShowOnAllPartsAndSongsButton_Click(object sender, EventArgs e) {
            // Select all items!
            SongListView.SelectedItems.Clear();
            foreach (ListViewItem lvi in SongListView.Items) {
                lvi.Selected = true;
            }

            // Now apply visibility!
            ChangeSongVisibility(Helpers.BandMembers.Guitarist, true);
            ChangeSongVisibility(Helpers.BandMembers.Bassist, true);
            ChangeSongVisibility(Helpers.BandMembers.Drummer, true);
            ChangeSongVisibility(Helpers.BandMembers.Vocalist, true);
            ChangeSongVisibility(Helpers.BandMembers.Band, true);
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // HIDE SONG COMMANDS
        // - - - - - - - - - - - - - - - - - - - - - - -

        // -- HIDE ON GUITAR
        private void HideOnGuitarButton_Click(object sender, EventArgs e) {
            ChangeSongVisibility(Helpers.BandMembers.Guitarist, false);
        }

        // -- HIDE ON BASS
        private void HideOnBassButton_Click(object sender, EventArgs e) {
            ChangeSongVisibility(Helpers.BandMembers.Bassist, false);
        }

        // -- HIDE ON DRUMS
        private void HideOnDrumsButton_Click(object sender, EventArgs e) {
            ChangeSongVisibility(Helpers.BandMembers.Drummer, false);
        }

        // -- HIDE ON VOCALS
        private void HideOnVocalsButton_Click(object sender, EventArgs e) {
            ChangeSongVisibility(Helpers.BandMembers.Vocalist, false);
        }

        // -- HIDE FOR BAND
        private void HideOnBandButton_Click(object sender, EventArgs e) {
            ChangeSongVisibility(Helpers.BandMembers.Band, false);
        }

        // -- HIDE FOR ALL
        private void HideForAllButton_Click(object sender, EventArgs e) {
            ChangeSongVisibility(Helpers.BandMembers.Guitarist, false);
            ChangeSongVisibility(Helpers.BandMembers.Bassist, false);
            ChangeSongVisibility(Helpers.BandMembers.Drummer, false);
            ChangeSongVisibility(Helpers.BandMembers.Vocalist, false);
            ChangeSongVisibility(Helpers.BandMembers.Band, false);
        }

        // -- HIDE FOR ALL SONGS ON ALL PARTS
        private void HideOnAllPartsAndSongsButton_Click(object sender, EventArgs e) {
            // Select all items!
            SongListView.SelectedItems.Clear();
            foreach (ListViewItem lvi in SongListView.Items) {
                lvi.Selected = true;
            }

            // Now apply visibility!
            ChangeSongVisibility(Helpers.BandMembers.Guitarist, false);
            ChangeSongVisibility(Helpers.BandMembers.Bassist, false);
            ChangeSongVisibility(Helpers.BandMembers.Drummer, false);
            ChangeSongVisibility(Helpers.BandMembers.Vocalist, false);
            ChangeSongVisibility(Helpers.BandMembers.Band, false);
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // OK / CANCEL / APPLY BUTTONS
        // - - - - - - - - - - - - - - - - - - - - - - -

        // -- OK BUTTON: APPLY AND CLOSE
        private void OKButton_Click(object sender, EventArgs e) {
            WriteVisibilityChanges();
            Close();
        }

        // -- CLOSE BUTTON: DO NOT SAVE
        private void CancelButton_Click(object sender, EventArgs e) {
            Close();
        }

        // -- APPLY BUTTON: JUST WRITE CHANGES
        private void ApplyButton_Click(object sender, EventArgs e) {
            WriteVisibilityChanges();
        }
    }
}
