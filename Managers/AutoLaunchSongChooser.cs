// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       A U T O       L A U N C H       S O N G       C H O O S E R
//
//    Dialog for managing the songs in the auto launch rotation.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;
using WTDE_Launcher_V3.IO;

// Other required imports.
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
    ///  Dialog for managing the songs in the auto launch rotation.
    /// </summary>
    public partial class AutoLaunchSongChooser : Form {
        /// <summary>
        ///  Dialog for managing the songs in the auto launch rotation.
        /// </summary>
        public AutoLaunchSongChooser(IEnumerable<string> sourceChecksums) {
            // Initialize Designer, like usual
            InitializeComponent();

            // Get the rotation songs.
            RotationSongInfo = GetSongInfoFromSourceChecksums(sourceChecksums);
            RotationInternalInfo = RotationSongInfo;

            // Populate the list boxes!
            PopulateListBoxFromSongData(RotationSongInfo, AutoLaunchQueueList);
            SongQueueHeader.Text = $"Song Queue ({AutoLaunchQueueList.Items.Count}):";

            PopulateListBoxFromSongData(V3LauncherConstants.StockSongList, WTStockSongsList);
            StockSongsHeader.Text = $"Built-In Songs ({WTStockSongsList.Items.Count}):";

            PopulateListBoxFromSongData(SongModInfo, ModSongsList);
            ModSongsHeader.Text = $"Mod Songs ({ModSongsList.Items.Count}):";

            // Disable all add/remove buttons.
            RemoveSelectedSongsFromQueue.Enabled = false;
            AddStockSongToQueueButton.Enabled = false;
            AddSongModsToQueueButton.Enabled = false;
            MoveUpInQueueButton.Enabled = false;
            MoveDownInQueueButton.Enabled = false;

            //~ foreach (var item in RotationSongInfo) {
            //~     Helpers.DumpListContents(item);
            //~ }
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Can the values be saved? Used in Main.cs when the songs get written.
        /// </summary>
        public bool CanSave = false;

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Max queue size.
        /// </summary>
        public const int MaxQueueSize = 20;

        /// <summary>
        ///  List of songs that will be in the Auto Launch rotation.
        /// </summary>
        public List<string[]> RotationSongInfo = new List<string[]>();

        /// <summary>
        ///  Internal rotation info.
        /// </summary>
        private static List<string[]> RotationInternalInfo = new List<string[]>();

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  List of song mods. Index 0 is the name; index 1 is the checksum.
        /// </summary>
        public static List<string[]> SongModInfo = ModHandler.GetSongModNamesAndChecksums();

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  The filtered indices of the queued songs.
        /// </summary>
        public int[] QueueSelectedIndices = Helpers.GetStringListMatchIndices(
            (from songInfo in RotationInternalInfo
             select songInfo[1]).ToArray(), ""
        );

        /// <summary>
        ///  The filtered indices of the stock songs.
        /// </summary>
        public int[] StockSongSelectedIndices = Helpers.GetStringListMatchIndices(
            (from songInfo in V3LauncherConstants.StockSongList
             select songInfo[0]).ToArray(), ""
        );

        /// <summary>
        ///  The filtered indices of the mod songs.
        /// </summary>
        public int[] SongModSelectedIndices = Helpers.GetStringListMatchIndices(
            (from songInfo in ModHandler.GetSongModNamesAndChecksums()
             select songInfo[0]).ToArray(), ""
        );

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Gets the information (e.g. title and checksum) of song mods by source checksums.
        /// </summary>
        /// <param name="sourceChecksums">
        ///  The collection of source checksums.
        /// </param>
        /// <returns>
        ///  List of string arrays with the necessary information about the given songs.
        /// </returns>
        public List<string[]> GetSongInfoFromSourceChecksums(IEnumerable<string> sourceChecksums) {
            // Final output list
            List<string[]> resultList = new List<string[]>();

            // Go through each checksum
            foreach (string checksum in sourceChecksums) {

                // Now check ALL stock songs and song mods for this checksum!
                // We'll check it case INSENSITIVELY

                // Look through stock songs
                foreach (string[] stockSong in V3LauncherConstants.StockSongList) {

                    // It matched, we're clear to add it!
                    if (stockSong[1].ToLower() == checksum.ToLower()) {
                        resultList.Add(stockSong);
                    }
                }

                // Look through song mods
                foreach (string[] songMod in SongModInfo) {

                    // It matched, we're clear to add it!
                    if (songMod[1].ToLower() == checksum.ToLower()) { 
                        resultList.Add(songMod);
                    }
                }
            }

            // Return the final list!
            return resultList;
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // HELPER FUNCTIONS
        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  From an <see cref="IEnumerable{T}"/> collection of string arrays, populate the given <see cref="ListBox"/> with the items provided.
        /// </summary>
        /// <param name="sourceData">
        ///  The source of song titles and checksums. All entries in the array are EXPECTED to be 2 entries long.
        /// </param>
        /// <param name="listBox">
        ///  The list box instance to populate.
        /// </param>
        /// <param name="indicesArray">
        ///  Optional: The integer array to populate in memory with the indices found. Default is none.
        /// </param>
        /// <param name="useChecksums">
        ///  Optional: Populate the list box with checksums rather than titles? Default is false.
        /// </param>
        /// <param name="filter">
        ///  Optional: String filter to check against. Default is an empty string, which is no filter.
        /// </param>
        /// <param name="useCaseInsensitive">
        ///  Optional: If this is true, this will search for the filter without regard to letter case. True by default; set to false to force case sensitive checking.
        /// </param>
        public void PopulateListBoxFromSongData(IEnumerable<string[]> sourceData, ListBox listBox, GlobalIndicesArray indicesArray = GlobalIndicesArray.None, bool useChecksums = false, string filter = "", bool useCaseInsensitive = true) {
            // Clear the given list box's items out first.
            listBox.Items.Clear();

            // Make sure our actual filter has no weird whitespaces!
            string actualFilter = filter.Trim();

            // Now loop through the source data arrays.
            // We will match our filters against the source data and
            // filter out the ones that do not match our filters.
            List<string> populatableData = new List<string>();
            foreach (string[] songInfo in sourceData) {
                // If this is for checksum use, check index 1.
                // If it's for song name use, check index 0.
                string checkAgainstProperty = useChecksums ? songInfo[1] : songInfo[0];

                // Now, we want to check our property against the actual filter!
                populatableData.Add(checkAgainstProperty);
            }

            // Now add the populatable data to the given list box!
            int[] stringListMatchIndices = Helpers.GetStringListMatchIndices(populatableData, actualFilter);
            List<string> actualFilteredData = new List<string>();
            foreach (int idx in stringListMatchIndices) {
                actualFilteredData.Add(populatableData[idx]);
            }

            foreach (string item in actualFilteredData) {
                listBox.Items.Add(item);
            }

            // Update the array in global memory based on arguments.
            switch (indicesArray) {
                case GlobalIndicesArray.None: default:
                    break;

                case GlobalIndicesArray.StockSongs:
                    StockSongSelectedIndices = stringListMatchIndices;
                    break;

                case GlobalIndicesArray.ModSongs:
                    SongModSelectedIndices = stringListMatchIndices;
                    break;
            }

            //~ Helpers.DumpListContents(StockSongSelectedIndices);
            //~ Helpers.DumpListContents(SongModSelectedIndices);
        }

        /// <summary>
        ///  Used to determine what array to store the resulting filtered indices from
        ///  the song search filters to in global memory.
        /// </summary>
        public enum GlobalIndicesArray {
            /// <summary>
            ///  No global array.
            /// </summary>
            None = -1,
            /// <summary>
            ///  Using stock songs.
            /// </summary>
            StockSongs = 0,
            /// <summary>
            ///  Using mod songs.
            /// </summary>
            ModSongs = 1
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Add the songs from a list box to the queue!
        /// </summary>
        /// <param name="sourceBox">
        ///  The source list box to read the items from.
        /// </param>
        /// <param name="infoSource">
        ///  The source list of string arrays to read the song data from.
        /// </param>
        /// <param name="arrayOfIndices">
        ///  Integer array of indices to read from.
        /// </param>
        public void AddSongsToQueue(ListBox sourceBox, IEnumerable<string[]> infoSource, int[] arrayOfIndices) {
            // Do we have selected items?
            if (sourceBox.SelectedItems.Count > 0) {

                // Now get the list box's selected indices!
                var indexes = sourceBox.SelectedIndices;
                foreach (int index in indexes) {
                    // Get the song information.
                    string[] songInfo = infoSource.ToList()[arrayOfIndices[index]];

                    // Add it to the rotation!
                    RotationSongInfo.Add(songInfo);
                    RotationInternalInfo = RotationSongInfo;
                    AutoLaunchQueueList.Items.Add(songInfo[0]);
                }

                // Clear the selected items from the source list box.
                sourceBox.SelectedItems.Clear();
            }

            // Update header label.
            SongQueueHeader.Text = $"Song Queue ({AutoLaunchQueueList.Items.Count}):";

            // DEBUG: Dump list contents.
            foreach (var item in RotationSongInfo) {
                Helpers.DumpListContents(item);
            }

            // If we've exceeded the max size, show or hide the warning info.
            bool hasExceededMax = (RotationSongInfo.Count > MaxQueueSize);
            WarningLogoIcon.Visible = hasExceededMax;
            OverMaxSizeLabel.Visible = hasExceededMax;
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // DISABLE ALL CLICKED BOXES, THEN ALLOW CHANGE
        // - - - - - - - - - - - - - - - - - - - - - - -

        // -- GHWT STOCK SONGS
        private void WTStockSongsList_SelectedIndexChanged(object sender, EventArgs e) {
            ModSongsList.SelectedItems.Clear();
            AddStockSongToQueueButton.Enabled = (WTStockSongsList.SelectedItems.Count > 0);
        }

        // -- SONG MODS LIST
        private void ModSongsList_SelectedIndexChanged(object sender, EventArgs e) {
            WTStockSongsList.SelectedItems.Clear();
            AddSongModsToQueueButton.Enabled = (ModSongsList.SelectedItems.Count > 0);
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // BUILT IN SONG FILTERING
        // - - - - - - - - - - - - - - - - - - - - - - -

        private void ApplyStockSongSearch_Click(object sender, EventArgs e) {
            PopulateListBoxFromSongData(V3LauncherConstants.StockSongList, WTStockSongsList, GlobalIndicesArray.StockSongs, filter: StockSongFilter.Text);
            StockSongsHeader.Text = $"Built-In Songs ({WTStockSongsList.Items.Count}):";
        }

        private void ResetStockSongFilter_Click(object sender, EventArgs e) {
            StockSongFilter.Text = "";
            PopulateListBoxFromSongData(V3LauncherConstants.StockSongList, WTStockSongsList, GlobalIndicesArray.ModSongs, filter: StockSongFilter.Text);
            StockSongsHeader.Text = $"Built-In Songs ({WTStockSongsList.Items.Count}):";
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // MOD SONG FILTERING
        // - - - - - - - - - - - - - - - - - - - - - - -

        private void ApplySongModSearch_Click(object sender, EventArgs e) {
            PopulateListBoxFromSongData(SongModInfo, ModSongsList, GlobalIndicesArray.ModSongs, filter: SongModFilter.Text);
            ModSongsHeader.Text = $"Mod Songs ({ModSongsList.Items.Count}):";
        }

        private void ResetSongModFilter_Click(object sender, EventArgs e) {
            SongModFilter.Text = "";
            PopulateListBoxFromSongData(SongModInfo, ModSongsList, GlobalIndicesArray.ModSongs, filter: SongModFilter.Text);
            ModSongsHeader.Text = $"Mod Songs ({ModSongsList.Items.Count}):";
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // ADD OR REMOVE SONGS TO/FROM QUEUE
        // - - - - - - - - - - - - - - - - - - - - - - -

        // -- GHWT STOCK SONGS
        private void AddStockSongToQueueButton_Click(object sender, EventArgs e) {
            AddSongsToQueue(WTStockSongsList, V3LauncherConstants.StockSongList, StockSongSelectedIndices);
        }

        // -- SONG MODS LIST
        private void AddSongModsToQueueButton_Click(object sender, EventArgs e) {
            AddSongsToQueue(ModSongsList, SongModInfo, SongModSelectedIndices);
        }

        // -- REMOVE SELECTED SONGS FROM THE QUEUE
        private void RemoveSelectedSongsFromQueue_Click(object sender, EventArgs e) {
            // Store the removeable indices so we can delete the items.
            List<int> removeIndices = new List<int>();
            foreach (int idx in AutoLaunchQueueList.SelectedIndices) {
                removeIndices.Add(idx);
            }

            // Clear the selected items out and delete the items at the positions.
            AutoLaunchQueueList.SelectedItems.Clear();
            foreach (int idx in removeIndices) {
                RotationSongInfo.RemoveAt(idx);
                AutoLaunchQueueList.Items.RemoveAt(idx);
            }

            // If we've exceeded the max size, show or hide the warning info.
            bool hasExceededMax = (RotationSongInfo.Count > MaxQueueSize);
            WarningLogoIcon.Visible = hasExceededMax;
            OverMaxSizeLabel.Visible = hasExceededMax;

            // Update header label.
            SongQueueHeader.Text = $"Song Queue ({AutoLaunchQueueList.Items.Count}):";
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // OK / CANCEL BUTTON
        // 
        // We thankfully don't need to wire up save
        // logic, since Main.cs has the save logic we
        // need. All we need to do there is just loop
        // over our checksums and save them to the INI!
        // - - - - - - - - - - - - - - - - - - - - - - -

        private void OKButton_Click(object sender, EventArgs e) {
            CanSave = true;
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            CanSave = false;
            Close();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // UPDATE ADDING / SUBTRACTING SONGS
        // - - - - - - - - - - - - - - - - - - - - - - -

        // -- DISABLE SUBTRACT BUTTON
        private void AutoLaunchQueueList_SelectedIndexChanged(object sender, EventArgs e) {
            bool useControls = (AutoLaunchQueueList.SelectedItems.Count > 0);

            MoveUpInQueueButton.Enabled = useControls;
            MoveDownInQueueButton.Enabled = useControls;
            RemoveSelectedSongsFromQueue.Enabled = useControls;
        }

        // -- MOVE ITEM UP IN QUEUE
        private void MoveUpInQueueButton_Click(object sender, EventArgs e) {
            int selectedIdx = AutoLaunchQueueList.SelectedIndex;
            int moveIdx = Math.Max(0, selectedIdx - 1);

            string sourceText = AutoLaunchQueueList.Items[selectedIdx].ToString();
            string moveItemText = AutoLaunchQueueList.Items[moveIdx].ToString();

            AutoLaunchQueueList.Items[selectedIdx] = moveItemText;
            AutoLaunchQueueList.Items[moveIdx] = sourceText;

            // Update rotation list.
            string[] sourceInfo = RotationSongInfo[selectedIdx];
            string[] moveInfo = RotationSongInfo[moveIdx];

            RotationSongInfo[selectedIdx] = moveInfo;
            RotationSongInfo[moveIdx] = sourceInfo;

            AutoLaunchQueueList.SelectedIndex = moveIdx;
        }

        // -- MOVE ITEM DOWN IN QUEUE
        private void MoveDownInQueueButton_Click(object sender, EventArgs e) {
            int selectedIdx = AutoLaunchQueueList.SelectedIndex;
            int moveIdx = Math.Min(AutoLaunchQueueList.Items.Count - 1, selectedIdx + 1);

            string sourceText = AutoLaunchQueueList.Items[selectedIdx].ToString();
            string moveItemText = AutoLaunchQueueList.Items[moveIdx].ToString();

            AutoLaunchQueueList.Items[selectedIdx] = moveItemText;
            AutoLaunchQueueList.Items[moveIdx] = sourceText;

            // Update rotation list.
            string[] sourceInfo = RotationSongInfo[selectedIdx];
            string[] moveInfo = RotationSongInfo[moveIdx];

            RotationSongInfo[selectedIdx] = moveInfo;
            RotationSongInfo[moveIdx] = sourceInfo;

            AutoLaunchQueueList.SelectedIndex = moveIdx;
        }
    }
}
