// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       S O N G       A N D       C A T E G O R Y       M A N A G E R
//          E D I T       S O R T       B Y       C A R E E R       O R D E R
//
//    The Mod Manager's song and song category mod manager's dialog for editing
//    the sort order for when the Sort by Career filter is chosen in-game.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;
using WTDE_Launcher_V3.IO;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Launcher_V3.Managers {
    /// <summary>
    ///  The Mod Manager's song and song category mod manager's dialog for editing
    ///  the sort order for when the Sort by Career filter is chosen in-game.
    /// </summary>
    public partial class SCMEditCareerSort : Form {
        /// <summary>
        ///  The Mod Manager's song and song category mod manager's dialog for editing
        ///  the sort order for when the Sort by Career filter is chosen in-game.
        /// </summary>
        public SCMEditCareerSort(List<string> songNames, List<string> songChecksums, List<string> iniPaths) {
            // Initialize Designer code.
            InitializeComponent();

            // Set member fields.
            SongNames = songNames;
            SongChecksums = songChecksums;
            SongINIPaths = iniPaths;
            ActiveListBox = GuitarSortList;

            IndexMoverSpinBox.Maximum = SongNames.Count - 1;
            TabCopyDestination.SelectedIndex = 0;

            // Next, create our sorted list items!
            CreateSortedListBoxItems();

            // Update control statuses.
            UpdateControlStatus();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  The active tab index for the selected tab in the main tab control.
        /// </summary>
        public int ActiveTabIndex = 0;

        /// <summary>
        ///  The active list box that is being changed, based on the selected tab.
        /// </summary>
        public ListBox ActiveListBox;

        /// <summary>
        ///  Names of all the songs in this category.
        /// </summary>
        public List<string> SongNames = new List<string>();

        /// <summary>
        ///  The QB checksums of all songs.
        /// </summary>
        public List<string> SongChecksums = new List<string>();

        /// <summary>
        ///  Paths to all of the INI files for the songs in this category.
        /// </summary>
        public List<string> SongINIPaths = new List<string>();

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  The final guitar sort data that will be parsed out by the writer method.
        /// </summary>
        public List<string[]> GuitarSortWritableData = new List<string[]>();

        /// <summary>
        ///  The final bass sort data that will be parsed out by the writer method.
        /// </summary>
        public List<string[]> BassSortWritableData = new List<string[]>();

        /// <summary>
        ///  The final drums sort data that will be parsed out by the writer method.
        /// </summary>
        public List<string[]> DrumsSortWritableData = new List<string[]>();

        /// <summary>
        ///  The final vocals sort data that will be parsed out by the writer method.
        /// </summary>
        public List<string[]> VocalsSortWritableData = new List<string[]>();

        /// <summary>
        ///  The final band mode sort data that will be parsed out by the writer method.
        /// </summary>
        public List<string[]> BandSortWritableData = new List<string[]>();

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Updates the usability of the controls.
        /// </summary>
        public void UpdateControlStatus() { 
            bool canMoveItems = (ActiveListBox.SelectedItems.Count > 0);

            MoveItemUpGButton.Enabled = canMoveItems;
            MoveItemDownGButton.Enabled = canMoveItems;
            MoveToIndexButton.Enabled = canMoveItems;
            AtIndexLabel.Enabled = canMoveItems;
            IndexMoverSpinBox.Enabled = canMoveItems;
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Makes the lists of items in memory and for the display to the end user.
        /// </summary>
        public void CreateSortedListBoxItems() {
            // Initialize the boiler plate lists.
            List<string[]> guitarSortedIndices = new List<string[]>();
            List<string[]> guitarUnsortedIndices = new List<string[]>();

            List<string[]> bassSortedIndices = new List<string[]>();
            List<string[]> bassUnsortedIndices = new List<string[]>();

            List<string[]> drumSortedIndices = new List<string[]>();
            List<string[]> drumUnsortedIndices = new List<string[]>();

            List<string[]> vocalsSortedIndices = new List<string[]>();
            List<string[]> vocalsUnsortedIndices = new List<string[]>();

            List<string[]> bandSortedIndices = new List<string[]>();
            List<string[]> bandUnsortedIndices = new List<string[]>();

            // ------------------------------

            // Iterate through our INI files.
            for (var i = 0; i < SongINIPaths.Count; i++) {
                // Get the INI file path!
                string iniFile = SongINIPaths[i];

                // Read the INI file.
                INI file = new INI(iniFile);

                // Figure out its sort locations!
                int guitarSortIdx = file.GetInt("SongInfo", "CareerSortIndexG", -1);
                int bassSortIdx = file.GetInt("SongInfo", "CareerSortIndexB", -1);
                int drumSortIdx = file.GetInt("SongInfo", "CareerSortIndexD", -1);
                int vocalsSortIdx = file.GetInt("SongInfo", "CareerSortIndexV", -1);
                int bandSortIdx = file.GetInt("SongInfo", "CareerSortIndexA", -1);

                // Get the song name and checksum.
                string songName = SongNames[i];
                string songChecksum = SongChecksums[i];

                // The new records we will add!
                string[] guitarRecord = new string[] { songName, songChecksum, guitarSortIdx.ToString(), iniFile };
                string[] bassRecord = new string[] { songName, songChecksum, bassSortIdx.ToString(), iniFile };
                string[] drumRecord = new string[] { songName, songChecksum, drumSortIdx.ToString(), iniFile };
                string[] vocalsRecord = new string[] { songName, songChecksum, vocalsSortIdx.ToString(), iniFile };
                string[] bandRecord = new string[] { songName, songChecksum, bandSortIdx.ToString(), iniFile };

                // Add the entries to our record lists!

                // -- LEAD GUITAR
                if (guitarSortIdx >= 0) {
                    guitarSortedIndices.Add(guitarRecord);
                } else {
                    guitarUnsortedIndices.Add(guitarRecord);
                }

                // -- BASS GUITAR
                if (bassSortIdx >= 0) {
                    bassSortedIndices.Add(bassRecord);
                } else {
                    bassUnsortedIndices.Add(bassRecord);
                }

                // -- DRUMS
                if (drumSortIdx >= 0) {
                    drumSortedIndices.Add(drumRecord);
                } else {
                    drumUnsortedIndices.Add(drumRecord);
                }

                // -- VOCALS
                if (vocalsSortIdx >= 0) {
                    vocalsSortedIndices.Add(vocalsRecord);
                } else {
                    vocalsUnsortedIndices.Add(vocalsRecord);
                }

                // -- BAND PLAY
                if (bandSortIdx >= 0) {
                    bandSortedIndices.Add(bandRecord);
                } else {
                    bandUnsortedIndices.Add(bandRecord);
                }
            }

            // ------------------------------
            // Now, we need to re-sort the lists based on our indices.
            // ------------------------------

            // ------------------------------
            // SORTED INDICES
            // ------------------------------
            guitarSortedIndices = (
                from record in guitarSortedIndices
                orderby int.Parse(record[2]) ascending
                select record
            ).ToList();

            bassSortedIndices = (
                from record in bassSortedIndices
                orderby int.Parse(record[2]) ascending
                select record
            ).ToList();

            drumSortedIndices = (
                from record in drumSortedIndices
                orderby int.Parse(record[2]) ascending
                select record
            ).ToList();

            vocalsSortedIndices = (
                from record in vocalsSortedIndices
                orderby int.Parse(record[2]) ascending
                select record
            ).ToList();

            bandSortedIndices = (
                from record in bandSortedIndices
                orderby int.Parse(record[2]) ascending
                select record
            ).ToList();

            // ------------------------------
            // UNSORTED INDICES
            // ------------------------------
            guitarUnsortedIndices = (
                from record in guitarUnsortedIndices
                orderby record[0] ascending
                select record
            ).ToList();

            bassUnsortedIndices = (
                from record in bassUnsortedIndices
                orderby record[0] ascending
                select record
            ).ToList();

            drumUnsortedIndices = (
                from record in drumUnsortedIndices
                orderby record[0] ascending
                select record
            ).ToList();

            vocalsUnsortedIndices = (
                from record in vocalsUnsortedIndices
                orderby record[0] ascending
                select record
            ).ToList();

            bandUnsortedIndices = (
                from record in bandUnsortedIndices
                orderby record[0] ascending
                select record
            ).ToList();

            // ------------------------------

            // DEBUG: Dump re-sorted list contents.
            //~ Console.WriteLine("#=#=#=#=#=#=#   SORTED INDICES   #=#=#=#=#=#=#");
            //~ foreach (string[] record in guitarSortedIndices) {
            //~     Helpers.DumpListContents(record);
            //~ }
            //~ foreach (string[] record in bassSortedIndices) {
            //~     Helpers.DumpListContents(record);
            //~ }
            //~ foreach (string[] record in drumSortedIndices) {
            //~     Helpers.DumpListContents(record);
            //~ }
            //~ foreach (string[] record in vocalsSortedIndices) {
            //~     Helpers.DumpListContents(record);
            //~ }
            //~ foreach (string[] record in bandSortedIndices) {
            //~     Helpers.DumpListContents(record);
            //~ }
            //~ 
            //~ Console.WriteLine("#=#=#=#=#=#=#  UNSORTED INDICES  #=#=#=#=#=#=#");
            //~ foreach (string[] record in guitarUnsortedIndices) {
            //~     Helpers.DumpListContents(record);
            //~ }
            //~ foreach (string[] record in bassUnsortedIndices) {
            //~     Helpers.DumpListContents(record);
            //~ }
            //~ foreach (string[] record in drumUnsortedIndices) {
            //~     Helpers.DumpListContents(record);
            //~ }
            //~ foreach (string[] record in vocalsUnsortedIndices) {
            //~     Helpers.DumpListContents(record);
            //~ }
            //~ foreach (string[] record in bandUnsortedIndices) {
            //~     Helpers.DumpListContents(record);
            //~ }

            // ------------------------------

            // Correct the indices of each sorted indices list!
            for (var i = 0; i < guitarSortedIndices.Count; i++) {
                guitarSortedIndices[i][2] = i.ToString();
            }
            for (var i = 0; i < bassSortedIndices.Count; i++) {
                bassSortedIndices[i][2] = i.ToString();
            }
            for (var i = 0; i < drumSortedIndices.Count; i++) {
                drumSortedIndices[i][2] = i.ToString();
            }
            for (var i = 0; i < vocalsSortedIndices.Count; i++) {
                vocalsSortedIndices[i][2] = i.ToString();
            }
            for (var i = 0; i < bandSortedIndices.Count; i++) {
                bandSortedIndices[i][2] = i.ToString();
            }

            // Correct the indices of each unsorted indices list!
            for (var i = 0; i < guitarUnsortedIndices.Count; i++) {
                int adjustedIndex = i + guitarSortedIndices.Count;
                guitarUnsortedIndices[i][2] = adjustedIndex.ToString();
            }
            for (var i = 0; i < bassUnsortedIndices.Count; i++) { 
                int adjustedIndex = i + bassSortedIndices.Count;
                bassUnsortedIndices[i][2] = adjustedIndex.ToString();
            }
            for (var i = 0; i < drumUnsortedIndices.Count; i++) {
                int adjustedIndex = i + drumSortedIndices.Count;
                drumUnsortedIndices[i][2] = adjustedIndex.ToString();
            }
            for (var i = 0; i < vocalsUnsortedIndices.Count; i++) {
                int adjustedIndex = i + vocalsSortedIndices.Count;
                vocalsUnsortedIndices[i][2] = adjustedIndex.ToString();
            }
            for (var i = 0; i < bandUnsortedIndices.Count; i++) {
                int adjustedIndex = i + bandSortedIndices.Count;
                bandUnsortedIndices[i][2] = adjustedIndex.ToString();
            }

            // ------------------------------

            // Re-build the final lists.
            // We need to take the sorted indices and redefine their indices in the list so
            // we can show and write the list properly.
            List<string[]> finalGuitarList = new List<string[]>();
            List<string[]> finalBassList = new List<string[]>();
            List<string[]> finalDrumList = new List<string[]>();
            List<string[]> finalVocalsList = new List<string[]>();
            List<string[]> finalBandList = new List<string[]>();

            // -- REBUILD GUITAR LIST
            foreach (string[] record in guitarSortedIndices) {
                finalGuitarList.Add(record);
            }
            foreach (string[] record in guitarUnsortedIndices) {
                finalGuitarList.Add(record);
            }

            // -- REBUILD BASS LIST
            foreach (string[] record in bassSortedIndices) {
                finalBassList.Add(record);
            }
            foreach (string[] record in bassUnsortedIndices) {
                finalBassList.Add(record);
            }

            // -- REBUILD DRUMS LIST
            foreach (string[] record in drumSortedIndices) {
                finalDrumList.Add(record);
            }
            foreach (string[] record in drumUnsortedIndices) {
                finalDrumList.Add(record);
            }

            // -- REBUILD VOCALS LIST
            foreach (string[] record in vocalsSortedIndices) {
                finalVocalsList.Add(record);
            }
            foreach (string[] record in vocalsUnsortedIndices) {
                finalVocalsList.Add(record);
            }

            // -- REBUILD BAND PLAY LIST
            foreach (string[] record in bandSortedIndices) {
                finalBandList.Add(record);
            }
            foreach (string[] record in bandUnsortedIndices) {
                finalBandList.Add(record);
            }

            // Set the new lists globally!
            GuitarSortWritableData = finalGuitarList;
            BassSortWritableData = finalBassList;
            DrumsSortWritableData = finalDrumList;
            VocalsSortWritableData = finalVocalsList;
            BandSortWritableData = finalBandList;

            // ------------------------------

            // And finally, fill in the list boxes!
            var transferDataLists = new List<List<string[]>>() {
                GuitarSortWritableData,
                BassSortWritableData,
                DrumsSortWritableData,
                VocalsSortWritableData,
                BandSortWritableData
            };

            var insertListBoxes = new List<ListBox>() {
                GuitarSortList,
                BassSortList,
                DrumsSortList,
                VocalsSortList,
                BandSortList
            };

            for (var i = 0; i < insertListBoxes.Count; i++) {
                ListBox lb = insertListBoxes[i];
                List<string[]> transferData = transferDataLists[i];

                foreach (string[] record in transferData) {
                    lb.Items.Add(record[0]);
                }
            }

            // DEBUG: Dump the list contents of the final constructed set of data.
            //~ foreach (var transferData in transferDataLists) { 
            //~     foreach (string[] record in transferData) {
            //~         Helpers.DumpListContents(record);
            //~     }
            //~ }
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Write the new career sort order for all 5 instrument selections!
        /// </summary>
        public void WriteNewCareerSortOrder() {
            // Are we sure we want to write the sort orders?
            bool doWriteSorts = (MessageBox.Show(
                "Are you sure you want to write your career sort order to all tied songs in this category?",
                "Are You Sure?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes);

            if (doWriteSorts) {
                // Here we go, the fun stuff!
                // We want to go through each list in memory and write
                // our values to their INI files.
                List<List<string[]>> outputDataSets = new List<List<string[]>>() {
                    GuitarSortWritableData, BassSortWritableData, DrumsSortWritableData, VocalsSortWritableData, BandSortWritableData
                };
                string[] outputSortIndexSuffixes = new string[] { "G", "B", "D", "V", "A" };

                // Go through each record and write its value.
                for (var i = 0; i < outputDataSets.Count; i++) {
                    // Go through every record in the current output data set.
                    string iniSaveKey = $"CareerSortIndex{outputSortIndexSuffixes[i]}";
                    foreach (string[] record in outputDataSets[i]) {
                        // Get and open the INI file of the current record.
                        string iniPath = record[3];
                        INI file = new INI(iniPath);

                        // Set the career sort index.
                        int sortIndexValue = int.Parse(record[2]);

                        file.SetInt("SongInfo", iniSaveKey, sortIndexValue);
                    }
                }

                this.Close();
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Update the necessary data set based on the active tab index with the given set of new data.
        /// </summary>
        /// <param name="dataToSet">
        ///  The new set of data.
        /// </param>
        public void UpdateGlobalWritableList(List<string[]> dataToSet) {
            // Reset the sort list in global scope.
            switch (ActiveTabIndex) {
                case 0: default:
                    GuitarSortWritableData = dataToSet;
                    break;

                case 1:
                    BassSortWritableData = dataToSet;
                    break;

                case 2:
                    DrumsSortWritableData = dataToSet;
                    break;

                case 3:
                    VocalsSortWritableData = dataToSet;
                    break;

                case 4:
                    BandSortWritableData = dataToSet;
                    break;
            }
        }

        /// <summary>
        ///  Handles switching the values of the global memory lists based on
        ///  the instrument part being currently edited.
        /// </summary>
        /// <param name="moveDown">
        ///  Optional: Is this for moving down? If it is, set to true. Otherwise, leave it as false.
        /// </param>
        public void HandleElementOrderSwap(bool moveDown = false) {
            // Figure out the list box ID and writable data list we need.
            List<string[]> writableDataList;
            ListBox listBoxID;
            switch (ActiveTabIndex) {
                // -- LEAD GUITAR
                case 0: default:
                    writableDataList = GuitarSortWritableData;
                    listBoxID = GuitarSortList;
                    break;

                // -- BASS GUITAR
                case 1:
                    writableDataList = BassSortWritableData;
                    listBoxID = BassSortList;
                    break;

                // -- DRUMS
                case 2:
                    writableDataList = DrumsSortWritableData;
                    listBoxID = DrumsSortList;
                    break;

                // -- VOCALS
                case 3:
                    writableDataList = VocalsSortWritableData;
                    listBoxID = VocalsSortList;
                    break;

                // -- BAND PLAY
                case 4:
                    writableDataList = BandSortWritableData;
                    listBoxID = BandSortList;
                    break;
            }

            // ------------------------------

            // Get the index of the item currently being focused on.
            // We'll make sure it's clamped within the range.
            int focusedIdx = listBoxID.SelectedIndex;
            string focusedText = listBoxID.Items[focusedIdx].ToString();

            if (focusedIdx < 0 || focusedIdx >= listBoxID.Items.Count) return;

            // Based on if we're moving up or down, get the index of the item
            // we need to move, along with its contents.

            int moveItemIdx;
            string moveItemText;

            // --- MOVING UP ---
            if (!moveDown) {
                moveItemIdx = focusedIdx - 1;
                if (moveItemIdx >= 0) {
                    moveItemText = listBoxID.Items[moveItemIdx].ToString();
                } else return;

            // -- MOVING DOWN --
            } else {
                moveItemIdx = focusedIdx + 1;
                if (moveItemIdx < listBoxID.Items.Count) {
                    moveItemText = listBoxID.Items[moveItemIdx].ToString();
                } else return;
            }

            // Switch the items.
            listBoxID.Items[moveItemIdx] = focusedText;
            listBoxID.Items[focusedIdx] = moveItemText;

            // ------------------------------

            // Now we need to swap the order of the items in memory.
            string[] originalArray = writableDataList[focusedIdx];
            string[] moveableArray = writableDataList[moveItemIdx];

            // Change out the indices with the swapped ones.
            moveableArray[2] = focusedIdx.ToString();
            originalArray[2] = moveItemIdx.ToString();

            // Switch their order!
            writableDataList[focusedIdx] = moveableArray;
            writableDataList[moveItemIdx] = originalArray;

            UpdateGlobalWritableList(writableDataList);

            // ------------------------------

            // Set the selected index.
            listBoxID.SelectedIndex = moveItemIdx;
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Handles swapping items with the index mover spin box.
        /// </summary>
        public void HandleIndexMover() {
            // Figure out the list box ID and writable data list we need.
            List<string[]> writableDataList;
            ListBox listBoxID;
            switch (ActiveTabIndex) {
                // -- LEAD GUITAR
                case 0:
                default:
                    writableDataList = GuitarSortWritableData;
                    listBoxID = GuitarSortList;
                    break;

                // -- BASS GUITAR
                case 1:
                    writableDataList = BassSortWritableData;
                    listBoxID = BassSortList;
                    break;

                // -- DRUMS
                case 2:
                    writableDataList = DrumsSortWritableData;
                    listBoxID = DrumsSortList;
                    break;

                // -- VOCALS
                case 3:
                    writableDataList = VocalsSortWritableData;
                    listBoxID = VocalsSortList;
                    break;

                // -- BAND PLAY
                case 4:
                    writableDataList = BandSortWritableData;
                    listBoxID = BandSortList;
                    break;
            }

            // ------------------------------

            // Get the index of the item currently being focused on.
            // We'll make sure it's clamped within the range.
            int focusedIdx = listBoxID.SelectedIndex;
            string focusedText = listBoxID.Items[focusedIdx].ToString();

            int moveItemIdx = (int) IndexMoverSpinBox.Value;
            string moveItemText = listBoxID.Items[moveItemIdx].ToString();

            // Swap the items.
            listBoxID.Items[focusedIdx] = moveItemText;
            listBoxID.Items[moveItemIdx] = focusedText;

            // Swap the items in the writable data list!
            string[] originalArray = writableDataList[focusedIdx];
            string[] moveableArray = writableDataList[moveItemIdx];

            moveableArray[2] = focusedIdx.ToString();
            originalArray[2] = moveItemIdx.ToString();

            writableDataList[focusedIdx] = moveableArray;
            writableDataList[moveItemIdx] = originalArray;

            listBoxID.SelectedIndex = moveItemIdx;
            listBoxID.Focus();

            //~ foreach (string[] record in writableDataList) {
            //~     Helpers.DumpListContents(record);
            //~ }
        }

        private void MoveToIndexButton_Click(object sender, EventArgs e) {
            HandleIndexMover();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Move a list box item up.
        /// </summary>
        public void MoveListItemUp() {
            HandleElementOrderSwap();
        }

        /// <summary>
        ///  Move a list box item down.
        /// </summary>
        public void MoveListItemDown() {
            HandleElementOrderSwap(true);
        }

        /// <summary>
        ///  Update the changeable list box element when the tab is swapped.
        /// </summary>
        public void UpdateChangeableListBox() { 
            switch (ActiveTabIndex) {
                case 0: default:
                    ActiveListBox = GuitarSortList;
                    break;

                case 1:
                    ActiveListBox = BassSortList;
                    break;

                case 2:
                    ActiveListBox = DrumsSortList;
                    break;

                case 3:
                    ActiveListBox = VocalsSortList;
                    break;

                case 4:
                    ActiveListBox = BandSortList;
                    break;
            }
            UpdateControlStatus();
        }

        private void MoveItemUpGButton_Click(object sender, EventArgs e) {
            MoveListItemUp();
        }

        private void MoveItemDownGButton_Click(object sender, EventArgs e) {
            MoveListItemDown();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        private void MainEditorTabs_SelectedIndexChanged(object sender, EventArgs e) {
            // Update active tab index.
            ActiveTabIndex = MainEditorTabs.SelectedIndex;
            UpdateChangeableListBox();
            Console.WriteLine($"Active tab index: {ActiveTabIndex}");

            // When the tab index changes, make sure we clear the selected items
            // from all of the list boxes in all of the tabs.
            GuitarSortList.SelectedItems.Clear();
            BassSortList.SelectedItems.Clear();
            DrumsSortList.SelectedItems.Clear();
            VocalsSortList.SelectedItems.Clear();
            BandSortList.SelectedItems.Clear();

            // Update the status of controls.
            UpdateControlStatus();
        }

        private void MainListBoxes_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateControlStatus();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Resets the sort order for all songs for either a single instrument or ALL instruments.
        /// </summary>
        /// <param name="resetAll">
        ///  Optional: Is this meant to reset all instruments? If so, set to true. If not, leave it as false.
        /// </param>
        public void ResetSortOrder(bool resetAll = false) {
            string resetSortWarningText = (resetAll) ?
                "Are you sure you want to reset the sort order for ALL instruments?" :
                "Are you sure you want to reset this instrument's career sort order?";

            bool canResetSort = (
                MessageBox.Show(
                $"{resetSortWarningText} This CAN NOT be undone!",
                "Are You Sure?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes);

            if (canResetSort) {
                // Figure out the list box ID and writable data list we need.
                List<string[]> writableDataList;
                ListBox listBoxID;
                switch (ActiveTabIndex) {
                    // -- LEAD GUITAR
                    case 0:
                    default:
                        writableDataList = GuitarSortWritableData;
                        listBoxID = GuitarSortList;
                        break;

                    // -- BASS GUITAR
                    case 1:
                        writableDataList = BassSortWritableData;
                        listBoxID = BassSortList;
                        break;

                    // -- DRUMS
                    case 2:
                        writableDataList = DrumsSortWritableData;
                        listBoxID = DrumsSortList;
                        break;

                    // -- VOCALS
                    case 3:
                        writableDataList = VocalsSortWritableData;
                        listBoxID = VocalsSortList;
                        break;

                    // -- BAND PLAY
                    case 4:
                        writableDataList = BandSortWritableData;
                        listBoxID = BandSortList;
                        break;
                }

                // ------------------------------

                // Clear out the active list box's items; we need to reset the sort order.
                if (!resetAll) {
                    listBoxID.Items.Clear();
                } else {
                    GuitarSortList.Items.Clear();
                    BassSortList.Items.Clear();
                    DrumsSortList.Items.Clear();
                    VocalsSortList.Items.Clear();
                    BandSortList.Items.Clear();
                }

                // Re-sort the list by title and re-write the indices starting at 0.
                List<string[]> resetSortList = (
                    from record in writableDataList
                    orderby record[0] ascending
                    select record
                ).ToList();

                // Now re-write the indices for this reset list.
                for (var i = 0; i < resetSortList.Count; i++) {
                    resetSortList[i][2] = i.ToString();
                }

                // Re-populate the list box with the reset sort order.
                foreach (string[] record in resetSortList) {
                    if (!resetAll) {
                        listBoxID.Items.Add(record[0]);
                    } else {
                        GuitarSortList.Items.Add(record[0]);
                        BassSortList.Items.Add(record[0]);
                        DrumsSortList.Items.Add(record[0]);
                        VocalsSortList.Items.Add(record[0]);
                        BandSortList.Items.Add(record[0]);
                    }
                }

                // If this for ALL instruments, set every global list to the reset sort list.
                // Otherwise, just update the single one.
                if (!resetAll) {
                    UpdateGlobalWritableList(resetSortList);
                } else {
                    GuitarSortWritableData = resetSortList;
                    BassSortWritableData = resetSortList;
                    DrumsSortWritableData = resetSortList;
                    VocalsSortWritableData = resetSortList;
                    BandSortWritableData = resetSortList;
                }

                //~ foreach (string[] record in GuitarSortWritableData) {
                //~     Helpers.DumpListContents(record);
                //~ }
            }
        }

        private void ResetSortOrderButton_Click(object sender, EventArgs e) {
            ResetSortOrder();
        }

        private void ResetSortAllOrdersButton_Click(object sender, EventArgs e) {
            ResetSortOrder(true);
        }

        private void ManageVisibilitiesButton_Click(object sender, EventArgs e) {
            SCMEditHiddenSongs sehs = new SCMEditHiddenSongs(SongINIPaths);
            sehs.ShowDialog();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Copy the sort order of the current tab to the destination tab!
        /// </summary>
        public void CopySortOrder() {
            bool doCopy = (MessageBox.Show(
                "Are you sure you want to copy the current sort order to the given instrument? This cannot be undone!",
                "Are You Sure?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes);

            if (!doCopy) return;

            // -----------------------

            // What tab are we currently looking at?
            int currentTabIdx = MainEditorTabs.SelectedIndex;
            int destTabIdx = TabCopyDestination.SelectedIndex;

            // Our ACTIVE list box is the source order.
            // The destination order will be the one based on
            // our destination index!
            ListBox destListBox;
            switch (destTabIdx) {
                case 0: default: destListBox = GuitarSortList; break;
                case 1: destListBox = BassSortList; break;
                case 2: destListBox = DrumsSortList; break;
                case 3: destListBox = VocalsSortList; break;
                case 4: destListBox = BandSortList; break;
            }

            // -----------------------

            // Clear the destination's list box items.
            destListBox.Items.Clear();

            // Copy our sort order over on the frontend!
            foreach (string item in ActiveListBox.Items) {
                destListBox.Items.Add(item);
            }

            // -----------------------

            // Now copy our writable order based on our source and destination!
            switch (destTabIdx) {
                // -- DESTINATION IS GUITAR
                case 0: default:

                    // -- GET SOURCE INDEX
                    switch (currentTabIdx) {
                        case 0: default:
                            break;

                        case 1:
                            GuitarSortWritableData = BassSortWritableData;
                            break;

                        case 2:
                            GuitarSortWritableData = DrumsSortWritableData;
                            break;

                        case 3:
                            GuitarSortWritableData = VocalsSortWritableData;
                            break;

                        case 4:
                            GuitarSortWritableData = BandSortWritableData;
                            break;
                    }

                    break;

                // -- DESTINATION IS BASS
                case 1:

                    // -- GET SOURCE INDEX
                    switch (currentTabIdx) {
                        case 0: default:
                            BassSortWritableData = GuitarSortWritableData;
                            break;

                        case 1:
                            break;

                        case 2:
                            BassSortWritableData = DrumsSortWritableData;
                            break;

                        case 3:
                            BassSortWritableData = VocalsSortWritableData;
                            break;

                        case 4:
                            BassSortWritableData = BandSortWritableData;
                            break;
                    }

                    break;

                // -- DESTINATION IS DRUMS
                case 2:

                    // -- GET SOURCE INDEX
                    switch (currentTabIdx) {
                        case 0: default:
                            DrumsSortWritableData = GuitarSortWritableData;
                            break;

                        case 1:
                            DrumsSortWritableData = BassSortWritableData;
                            break;

                        case 2:
                            break;

                        case 3:
                            DrumsSortWritableData = VocalsSortWritableData;
                            break;

                        case 4:
                            DrumsSortWritableData = BandSortWritableData;
                            break;
                    }

                    break;

                // -- DESTINATION IS VOCALS
                case 3:

                    // -- GET SOURCE INDEX
                    switch (currentTabIdx) {
                        case 0: default:
                            VocalsSortWritableData = GuitarSortWritableData;
                            break;

                        case 1:
                            VocalsSortWritableData = BassSortWritableData;
                            break;

                        case 2:
                            VocalsSortWritableData = DrumsSortWritableData;
                            break;

                        case 3:
                            break;

                        case 4:
                            VocalsSortWritableData = BandSortWritableData;
                            break;
                    }

                    break;

                // -- DESTINATION IS BAND
                case 4:

                    // -- GET SOURCE INDEX
                    switch (currentTabIdx) {
                        case 0: default:
                            BandSortWritableData = GuitarSortWritableData;
                            break;

                        case 1:
                            BandSortWritableData = BassSortWritableData;
                            break;

                        case 2:
                            BandSortWritableData = DrumsSortWritableData;
                            break;

                        case 3:
                            BandSortWritableData = VocalsSortWritableData;
                            break;

                        case 4:
                            break;
                    }

                    break;
            }
        }

        private void DoCopyOrderButton_Click(object sender, EventArgs e) {
            CopySortOrder();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        private void OKButton_Click(object sender, EventArgs e) {
            WriteNewCareerSortOrder();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            bool confirmClose = (MessageBox.Show(
                "Are you sure you want to close this dialog without saving your changes?",
                "Are You Sure?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes);

            if (confirmClose) this.Close();
        }

        
    }
}