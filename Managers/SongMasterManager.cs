// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       S O N G       A N D       C A T E G O R Y       M A N A G E R
//
//    The Mod Manager's song and song category mod manager, which lets the user
//    more easily sort and categorize their songs.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;
using WTDE_Launcher_V3.IO;

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MadMilkman.Ini;
using Pfim;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;
using WTDE_Launcher_V3.NX;
using System.IO.Compression;

namespace WTDE_Launcher_V3.Managers {
    /// <summary>
    ///  The Mod Manager's song and song category mod manager, which lets the user
    ///  more easily sort and categorize their songs.
    /// </summary>
    public partial class SongMasterManager : Form {
        /// <summary>
        ///  List of songs in Artist - Title format.
        /// </summary>
        public List<string> SongTitles = new List<string>();

        /// <summary>
        ///  List of song checksums.
        /// </summary>
        public List<string> SongChecksums = new List<string>();

        /// <summary>
        ///  List of song mod paths.
        /// </summary>
        public List<string> SongModPaths = new List<string>();

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  List of song category names.
        /// </summary>
        public List<string> SongCategoryNames = new List<string>();

        /// <summary>
        ///  List of song category checksums.
        /// </summary>
        public List<string> SongCategoryChecksums = new List<string>();

        /// <summary>
        ///  List of song category paths.
        /// </summary>
        public List<string> SongCategoryPaths = new List<string>();

        /// <summary>
        ///  The checksum of the currently loaded category.
        /// </summary>
        public string CurrentLoadedCategoryChecksum = "";

        /// <summary>
        ///  The path of the currently loaded category.
        /// </summary>
        public string CurrentLoadedCategoryPath = "";

        /// <summary>
        ///  The name of the currently loaded category's image.
        /// </summary>
        public string CurrentLoadedCategoryImageName = "";

        // - - - - - - - - - - - - - - - - - - - - - - -

        public SongMasterManager() {
            InitializeComponent();
            GetSongsAndCategories();
            UpdateActiveSongControls();
            UpdateMenuCommands();

            // For now, until ready, disable the Make Setlist ZIP command.
            //~ MakeSetlistZIPButton.Visible = false;
            //~ makeSetlistZIPToolStripMenuItem.Visible = false;
        }

        public void GetSongsAndCategories() {
            // First up, let's get our song and song category mods.
            // We'll make 2 lists: 1 list for Artist - Title format, and
            // another for just checksums.

            // We'll have another 2 lists for song categories and category
            // checksums too. We'll just use the name lists for both
            // things in their list boxes.

            // We actually need 3 lists... One for each mod type's paths.

            // Let's clear these lists first.
            SongTitles.Clear();
            SongChecksums.Clear();
            SongModPaths.Clear();

            SongCategoryNames.Clear();
            SongCategoryChecksums.Clear();
            SongCategoryPaths.Clear();

            // Clear out the list boxes too.
            SongModsList.Items.Clear();
            SongCategoriesList.Items.Clear();

            // Adjust header labels and update the idle tasks.
            SongModsHeader.Text = "Refreshing...";
            SongCategoriesHeader.Text = "Refreshing...";
            EditCategoryDataButton.Enabled = false;

            Application.DoEvents();

            // Refresh the mod list just in case.
            ModHandler.ReadMods();

            // Now let's do some populating!
            // Loop through our installed mods and get all song
            // and song category mods.
            int unkIdx = 0;
            foreach (string[] mod in ModHandler.UserContentMods) {
                // Read this INI file.
                INI file = new INI(mod[5]);

                // Invalid category mod if the file is directly inside of DATA/MODS.
                // If that's the case, then skip it!
                string testModsPath = Path.Combine(V3LauncherCore.GetUpdaterINIDirectory(), "DATA/MODS/category.ini");
                if (mod[5].ToLower() == testModsPath.ToLower()) continue;

                // Is this a song mod?
                if (mod[2] == "Song") {
                    // Get its title, artist, and checksum, then add all of
                    // that info to the lists.
                    string songName = file.GetString("SongInfo", "Title", "Unknown Title");
                    string songArtist = file.GetString("SongInfo", "Artist", "Unknown Artist");

                    string songChecksum = file.GetString("SongInfo", "Checksum", $"unk{unkIdx}");

                    SongTitles.Add($"{songArtist} - {songName}");
                    SongChecksums.Add(songChecksum);
                    SongModPaths.Add(mod[5]);
                
                // Is this a category mod?
                } else if (mod[2] == "Song Category") {
                    // Get the name and category checksum.
                    string cateName = file.GetString("CategoryInfo", "Name", "Unknown Category Title");
                    string cateChecksum = file.GetString("CategoryInfo", "Checksum", $"unknownCat{unkIdx}");

                    SongCategoryNames.Add(cateName);
                    SongCategoryChecksums.Add(cateChecksum);
                    SongCategoryPaths.Add(mod[5]);
                }

                unkIdx++;
            }

            // - - - - - - - - - - - - - - - - - - - - - - -

            // Now let's populate the list boxes!
            // First up, song mods.
            if (!showSongChecksumsToolStripMenuItem.Checked) {
                foreach (string song in SongTitles) {
                    SongModsList.Items.Add(song);
                }
            } else {
                foreach (string checksum in SongChecksums) {
                    SongModsList.Items.Add(checksum);
                }
            }

            // Now for category mods.
            if (!showCategoryChecksumsToolStripMenuItem.Checked) {
                foreach (string category in SongCategoryNames) {
                    SongCategoriesList.Items.Add(category);
                }
            } else {
                foreach (string checksum in SongCategoryChecksums) {
                    SongCategoriesList.Items.Add(checksum);
                }
            }

            // And adjust header labels too.
            SongModsHeader.Text = $"Song Mods ({SongModsList.Items.Count}):";
            SongCategoriesHeader.Text = $"Song Categories ({SongCategoriesList.Items.Count}):";
        }

        public void ReadAttachedSongs() {
            if (SongCategoriesList.SelectedItems.Count <= 0) return;

            //~ Console.WriteLine("Reading songs...");

            int finalIndex;
            string categoryToSearch;
            List<string> setList = (showCategoryChecksumsToolStripMenuItem.Checked) ? SongCategoryChecksums : SongCategoryNames;
            int[] modPathIndexes = GetItemIndexesInList(setList, SongCategoryFilter.Text);

            finalIndex = modPathIndexes[SongCategoriesList.SelectedIndex];
            categoryToSearch = SongCategoryChecksums[finalIndex];

            CurrentLoadedCategoryChecksum = SongCategoryChecksums[finalIndex];
            CurrentLoadedCategoryPath = Path.GetFullPath(Path.GetDirectoryName(SongCategoryPaths[finalIndex]));

            //~ Console.WriteLine($"-- CURRENT DATA --\nmod path indexes: {modPathIndexes}\nfinal index: {finalIndex}\ncurrent loaded category checksum: {CurrentLoadedCategoryChecksum}");

            // First, let's clear out anything we need to clear.
            AttachedCategorySongs.Items.Clear();

            // - - - - - - - - - - - - - - - - - - - - - - -

            // Now comes the hard part, find all songs attached to a category.
            // We have 2 means of attaching a song: In a song mod config or
            // in a folder.ini file.

            // We'll have to iterate through the entire MODS directory for this.
            // We can't just use the UserContentMods list.

            // - - - - - - - - - - - - - - - - - - - - - - -

            // First up, let's change directories.
            var owd = Directory.GetCurrentDirectory();
            ModHandler.UseUpdaterINIDirectory();

            // Read the user's MODS directory for ALL INI FILES.
            string[] files = Directory.GetFiles("DATA/MODS", "*.ini", SearchOption.AllDirectories);

            // This is the list of string arrays we'll add to the list view at the end.
            List<string[]> outData = new List<string[]>();

            // Now let's look for song.ini OR folder.ini files.
            for (var i = 0; i < files.Length; i++) {

                // For compatibility with the old foreach loop we had,
                // we'll repurpose the `file` variable so we can reuse
                // it from the system we had before.
                string file = files[i];

                //~ Console.WriteLine($"current file: {file}");

                // Invalid category mod if the file is directly inside of DATA/MODS.
                // If that's the case, then skip it!
                string testModsPath = Path.Combine(V3LauncherCore.GetUpdaterINIDirectory(), "DATA/MODS/category.ini");
                if (Path.GetFullPath(file).ToLower() == testModsPath.ToLower()) {
                    continue;
                }

                // These 4 strings will hold:
                // - The linked category.
                // - The song's name, if it's linked.
                // - The song's artist's name.
                // - The song's checksum.
                string linkedCat, songName, songArtist, songChecksum;

                // Read the current INI file!
                INI iFile = new INI(file);

                // Now, we want either song.ini or folder.ini files.
                switch (Path.GetFileName(file)) {

                    // Regular song config.
                    case "song.ini":

                        // Is this a Melody song?
                        // If so, we do not want to parse it.
                        if (Directory.GetFiles(Path.GetDirectoryName(file), "*.mp3").Length > 0 ||
                            Directory.GetFiles(Path.GetDirectoryName(file), "*.ogg").Length > 0 ||
                            Directory.GetFiles(Path.GetDirectoryName(file), "*.wav").Length > 0 ||
                            Directory.GetFiles(Path.GetDirectoryName(file), "*.opus").Length > 0 ||
                            File.Exists(Path.Combine(Path.GetDirectoryName(file), "notes.mid")) ||
                            File.Exists(Path.Combine(Path.GetDirectoryName(file), "notes.chart"))) {

                            V3LauncherCore.AddDebugEntry("Detected a Melody song, skipping...", "Song & Song Category Manager");
                            continue;

                        }

                        // Is this song tied to a category?
                        if (!iFile.HasKey("SongInfo", "GameCategory")) linkedCat = "";
                        else linkedCat = iFile.GetString("SongInfo", "GameCategory");

                        // If we actually had a tied category, is it the category we're trying to find?
                        if (linkedCat != "" && linkedCat.ToUpper() == categoryToSearch.ToUpper()) {

                            // It is! Let's get its details.
                            // Our INI file class contains fallbacks, thankfully, so this
                            // is extremely easy to do with our INI class.
                            songName = iFile.GetString("SongInfo", "Title", "Unknown Title");
                            songArtist = iFile.GetString("SongInfo", "Artist", "Unknown Artist");
                            songChecksum = iFile.GetString("SongInfo", "Checksum", $"unkChecksum{i}");

                            // Add the song's name, path, and checksum to the list.
                            string[] addArray = new string[] { $"{songArtist} - {songName}", songChecksum, Path.GetFullPath(file) };

                            // IS THIS SONG IN THE LIST ALREADY?
                            bool dupeFound = false;
                            foreach (string[] arr in outData) {
                                dupeFound = (arr[0] == addArray[0]);
                                if (dupeFound) break;
                            }

                            // This wasn't a duplicate, cool! Let's add it!
                            if (!dupeFound) outData.Add(addArray);
                        }

                        break;

                    // - - - - - - - - - - - - - - - - - - - - - - -

                    // Folder configs.
                    case "folder.ini":

                        // Is this even a validly formatted folder config file?
                        if (iFile.HasKey("SongInfo", "GameCategory")) {

                            // Is this the checksum we want?
                            // Remember that song category checksums are case INsensitive.
                            if (iFile.GetString("SongInfo", "GameCategory").ToUpper() == categoryToSearch.ToUpper()) {

                                // This is the one we want, now we have to do another iteration
                                // nested in here for this folder.
                                string[] nestedFiles = Directory.GetFiles(Path.GetDirectoryName(file), "*.ini", SearchOption.AllDirectories);

                                // Now go through the nested files and get the song names.
                                foreach (string nestedFile in nestedFiles) {

                                    // Just be doubly sure that this is a song.ini file!
                                    if (nestedFile.Contains("song.ini")) {

                                        // Very nice, it was!
                                        // We'll need a new instance of our INI class to read this stuff.
                                        INI iFile2 = new INI(nestedFile);

                                        // Let's get the name, artist, and checksum for each song.
                                        songName = iFile2.GetString("SongInfo", "Title", "Unknown Title");
                                        songArtist = iFile2.GetString("SongInfo", "Artist", "Unknown Artist");
                                        songChecksum = iFile2.GetString("SongInfo", "Checksum", $"unkChecksum{i}");

                                        // Add the song's name, path, and checksum to the list.
                                        string[] addArray = new string[] { $"{songArtist} - {songName}", songChecksum, Path.GetFullPath(nestedFile) };

                                        // IS THIS SONG IN THE LIST ALREADY?
                                        bool dupeFound = false;
                                        foreach (string[] arr in outData) {
                                            dupeFound = (arr[0] == addArray[0]);
                                            if (dupeFound) break;
                                        }

                                        // This wasn't a duplicate, cool! Let's add it!
                                        if (!dupeFound) outData.Add(addArray);
                                    }
                                }
                            }
                        }
                        break;
                }
            }

            // - - - - - - - - - - - - - - - - - - - - - - -

            // Remove any duplicates, leave only distinct ones.
            outData = outData.Distinct().ToList();

            // Now, we're FINALLY DONE!
            // Let's populate our list view now!
            foreach (string[] outMod in outData) {
                var newItem = new ListViewItem(outMod);

                if (AttachedCategorySongs.Items.Contains(newItem)) {
                    continue;
                }

                AttachedCategorySongs.Items.Add(newItem);
            }

            // - - - - - - - - - - - - - - - - - - - - - - -

            // Update the info header too.
            string activeCategoryText = $"Name: {SongCategoryNames[finalIndex]}\n" +
                                        $"Checksum: {SongCategoryChecksums[finalIndex]}\n" +
                                        $"Path: {Path.GetDirectoryName(SongCategoryPaths[finalIndex])}\n" +
                                        $"Songs Tied to Category: {AttachedCategorySongs.Items.Count}";

            ActiveCategoryInfo.Text = activeCategoryText;

            // - - - - - - - - - - - - - - - - - - - - - - -

            Directory.SetCurrentDirectory(owd);

            UpdateActiveSongControls();
        }

        public void UnloadAllData() {
            // Erase all of the loaded category data.
            LogoImageBox.Image = null;

            AttachedCategorySongs.Items.Clear();

            string noCategoryLoadedText = "Name: ???\nChecksum: N/A\nPath: N/A\nSongs Tied to Category: N/A";
            ActiveCategoryInfo.Text = noCategoryLoadedText;

            EditCategoryDataButton.Enabled = false;

            CurrentLoadedCategoryChecksum = "";

            SongModFilter.Text = "";
            SongCategoryFilter.Text = "";
        }

        public void UpdateActiveSongControls() {
            EditCategoryDataButton.Enabled = (SongCategoriesList.SelectedItems.Count > 0);
            MakeSetlistZIPButton.Enabled = (AttachedCategorySongs.Items.Count > 0 && SongCategoriesList.SelectedItems.Count > 0);
        }

        /// <summary>
        ///  Read a Neversoft image file and display it in the given PictureBox. Also updates the given Label with information
        ///  about this image.
        /// </summary>
        /// <param name="picBox"></param>
        /// <param name="label"></param>
        public void OpenNXImageFile() {
            // Get image name from selected category config.
            //~ IniFile iFile = new IniFile();
            string path;
            int findIndex;

            string itemToFind = SongCategoriesList.SelectedItems[0].ToString();
            if (showCategoryChecksumsToolStripMenuItem.Checked) {
                // Look for checksums.
                findIndex = SongCategoryChecksums.IndexOf(itemToFind);
            } else {
                // Look for names.
                findIndex = SongCategoryNames.IndexOf(itemToFind);
            }
            path = SongCategoryPaths[findIndex];

            INI iFile = new INI(path);

            //~ iFile.Load(path);

            // Image name?
            string imageName = iFile.GetString("CategoryInfo", "Logo", "");
            CurrentLoadedCategoryImageName = imageName;
            if (imageName == null || imageName == "") return;

            // Does the image exist? If not, leave!
            string imageDir = Path.Combine(Path.GetDirectoryName(path), $"{imageName}.img.xen");
            if (!File.Exists(imageDir)) return;

            // Decompile the image and display it!
            NXImage nxImg = new NXImage(imageDir);
            LogoImageBox.Image = nxImg.Image;
        }

        /// <summary>
        ///  Does some magic to convert a UInt32 to big endian... I think.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static uint ESwap(uint value) {
            return ((value & 0xFF) << 24) |
                   ((value & 0xFF00) << 8) |
                   ((value & 0xFF0000) >> 8) |
                   ((value & 0xFF000000) >> 24);
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        public static int[] GetItemIndexesInList(List<string> list, string match) {
            List<int> outIndexes = new List<int>();

            for (var i = 0; i < list.Count; i++) {
                if (list[i].ToLower() == match.ToLower() ||
                    list[i].ToLower().Contains(match.ToLower())) {
                    outIndexes.Add(i);
                }
            }

            return outIndexes.ToArray();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        private void CloseButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void AttachedCategorySongs_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateActiveSongControls();
        }

        private void SongModsList_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateMenuCommands();
        }

        private void SongCategoriesList_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                //~ Console.WriteLine("Reading attached songs...");
                ReadAttachedSongs();

                //~ Console.WriteLine("Opening category image...");
                OpenNXImageFile();

                //~ Console.WriteLine("Updating active controls...");
                UpdateActiveSongControls();

                //~ Console.WriteLine("Updating menu commands...");
                UpdateMenuCommands();
            } catch (Exception exc) {
                V3LauncherCore.AddDebugEntry($"Category list update error, don't worry about it // {exc.Message}", "Song & Song Category Manager");
            }
        }

        private void showSongChecksumsToolStripMenuItem_Click(object sender, EventArgs e) {
            showSongChecksumsToolStripMenuItem.Checked = !showSongChecksumsToolStripMenuItem.Checked;

            showSongChecksumsToolStripMenuItem.Text = (showSongChecksumsToolStripMenuItem.Checked) ? "Show Song Artist and Title" : "Show Song Checksums";

            SongModsList.Items.Clear();

            // If checked show song checksums.
            if (showSongChecksumsToolStripMenuItem.Checked) {
                foreach (string checksum in SongChecksums) {
                    SongModsList.Items.Add(checksum);
                }
            } else {
                foreach (string song in SongTitles) {
                    SongModsList.Items.Add(song);
                }
            }
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e) {
            SCMNewCategory scm = new SCMNewCategory();
            scm.ShowDialog();

            GetSongsAndCategories();
            UpdateActiveSongControls();
            UpdateMenuCommands();
        }

        private void refreshAllModsToolStripMenuItem_Click(object sender, EventArgs e) {
            GetSongsAndCategories();
            UpdateActiveSongControls();
            UnloadAllData();
        }

        public void RefreshAllData() {
            UnloadAllData();
            GetSongsAndCategories();
            UpdateActiveSongControls();
        }

        private void deleteCategoryToolStripMenuItem_Click(object sender, EventArgs e) {
            // VERY CRITICAL CHECK:
            // WE CAN NOT DELETE A CATEGORY IF THE INI FILE IS IN THE MODS FOLDER DIRECTLY.
            // IF WE DO, A CATASTROPHE WILL ENSUE AND THE ENTIRE MODS DIRECTORY WILL BE
            // RECURSIVELY DELETED. We found this out the hard way... I'm sorry, Derpy...

            // So... To account for it, we'll need to verify that this category is not
            // in our MODS folder DIRECTLY. If there's a "category.ini" file in the MODS
            // folder directly, IT IS AN INVALID CATEGORY MOD.

            // Is that file in existence?
            string testModsPath = Path.Combine(V3LauncherCore.GetUpdaterINIDirectory(), "DATA/MODS/category.ini");
            if (File.Exists(testModsPath)) {
                MessageBox.Show(
                    $"Can not delete category because its category config file is located directly " +
                    $"inside the MODS directory.\n\nMove the config file, re-scan the categories, and try again.",
                    "Error Deleting Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SongCategoriesList.SelectedItems.Count > 0) {
                string categoryDeleteWarning = "Warning: Are you sure you want to delete this category? Songs that have been " +
                                               "tied to it will NOT show up in it, and will instead be moved to the WTDE " +
                                               "setlist category. This cannot be undone!";

                if (MessageBox.Show(categoryDeleteWarning, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    try {
                        // Delete the directory of the selected category;
                        int selectedID = SongCategoriesList.SelectedIndex;

                        string pathToDelete = Path.GetDirectoryName(SongCategoryPaths[selectedID]);
                        V3LauncherCore.DebugLog.Add($"path being deleted: {pathToDelete}");

                        if (Directory.Exists(pathToDelete)) {
                            Directory.Delete(pathToDelete, true);
                        }

                        MessageBox.Show("Category was deleted successfully.", "Deleted Category", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        UnloadAllData();
                        GetSongsAndCategories();
                        UpdateActiveSongControls();
                    } catch (Exception exc) {
                        V3LauncherCore.AddDebugEntry($"Error deleting category: {exc.Message}", "Song & Song Category Manager");

                        MessageBox.Show($"An error occurred deleting this category:\n{exc.Message}", "Delete Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void editCategoryDataToolStripMenuItem_Click(object sender, EventArgs e) {
            if (SongCategoriesList.SelectedItems.Count > 0) {
                List<string> setList = (showCategoryChecksumsToolStripMenuItem.Checked) ? SongCategoryChecksums : SongCategoryNames;
                int[] modPathIndexes = GetItemIndexesInList(setList, SongCategoryFilter.Text);

                int selectedID = modPathIndexes[SongCategoriesList.SelectedIndex];

                SCMEditCategory sem = new SCMEditCategory(Path.GetDirectoryName(SongCategoryPaths[selectedID]),
                                                          SongCategoryNames[selectedID],
                                                          SongCategoryChecksums[selectedID],
                                                          LogoImageBox.Image);

                sem.ShowDialog();

                UnloadAllData();
                GetSongsAndCategories();
                UpdateActiveSongControls();
            }
        }

        private void EditCategoryDataButton_Click(object sender, EventArgs e) {
            if (SongCategoriesList.SelectedItems.Count > 0) {
                List<string> setList = (showCategoryChecksumsToolStripMenuItem.Checked) ? SongCategoryChecksums : SongCategoryNames;
                int[] modPathIndexes = GetItemIndexesInList(setList, SongCategoryFilter.Text);

                int selectedID = modPathIndexes[SongCategoriesList.SelectedIndex];

                SCMEditCategory sem = new SCMEditCategory(Path.GetDirectoryName(SongCategoryPaths[selectedID]),
                                                          SongCategoryNames[selectedID],
                                                          SongCategoryChecksums[selectedID],
                                                          LogoImageBox.Image);

                sem.ShowDialog();

                UnloadAllData();
                GetSongsAndCategories();
                UpdateActiveSongControls();
            }
        }

        private void ApplySongModSearch_Click(object sender, EventArgs e) {
            // RESET THE LISTS FIRST!
            // This is pretty inefficient, but we'll roll with it.
            SongModsList.Items.Clear();

            // Do we want song and artist names, or do we want song checksums?
            if (showSongChecksumsToolStripMenuItem.Checked) {
                foreach (string checksum in SongChecksums) {
                    SongModsList.Items.Add(checksum);
                }
            } else {
                foreach (string song in SongTitles) {
                    SongModsList.Items.Add(song);
                }
            }

            // Let's look for any strings in the list box that match
            // what we're looking for!
            List<string> matches = new List<string>();

            string filter = SongModFilter.Text;

            if (filter == "") {
                SongModsHeader.Text = $"Song Mods ({SongTitles.Count}):";
                return;
            }

            foreach (var item in SongModsList.Items) {
                string itemText = item.ToString();
                if (itemText.ToLower().Contains(filter.ToLower())) matches.Add(itemText);
            }

            SongModsList.Items.Clear();

            foreach (string item in matches) {
                SongModsList.Items.Add(item);
            }

            SongModsHeader.Text = $"Mods Found ({SongModsList.Items.Count}):";
        }

        private void ResetSongModFilter_Click(object sender, EventArgs e) {
            SongModFilter.Text = "";
            SongModsList.Items.Clear();

            // Do we want song and artist names, or do we want song checksums?
            if (showSongChecksumsToolStripMenuItem.Checked) {
                foreach (string checksum in SongChecksums) {
                    SongModsList.Items.Add(checksum);
                }
            } else {
                foreach (string song in SongTitles) {
                    SongModsList.Items.Add(song);
                }
            }

            SongModsHeader.Text = $"Song Mods ({SongTitles.Count}):";
        }

        private void ApplySongCategorySearch_Click(object sender, EventArgs e) {
            // RESET THE LISTS FIRST!
            // This is pretty inefficient, but we'll roll with it.
            SongCategoriesList.Items.Clear();

            // Do we want category names, or do we want category checksums?
            if (showCategoryChecksumsToolStripMenuItem.Checked) {
                foreach (string checksum in SongCategoryChecksums) {
                    SongCategoriesList.Items.Add(checksum);
                }
            } else {
                foreach (string title in SongCategoryNames) {
                    SongCategoriesList.Items.Add(title);
                }
            }

            // Let's look for any strings in the list box that match
            // what we're looking for!
            List<string> matches = new List<string>();

            string filter = SongCategoryFilter.Text;

            if (filter == "") {
                SongCategoriesHeader.Text = $"Song Categories ({SongCategoryNames.Count}):";
                return;
            }

            foreach (var item in SongCategoriesList.Items) {
                string itemText = item.ToString();
                if (itemText.ToLower().Contains(filter.ToLower())) matches.Add(itemText);
            }

            SongCategoriesList.Items.Clear();

            foreach (string item in matches) {
                SongCategoriesList.Items.Add(item);
            }

            SongCategoriesHeader.Text = $"Mods Found ({SongCategoriesList.Items.Count}):";
        }

        private void ResetSongCategoryFilter_Click(object sender, EventArgs e) {
            SongCategoryFilter.Text = "";

            SongCategoriesList.Items.Clear();

            // Do we want category names, or do we want category checksums?
            if (showCategoryChecksumsToolStripMenuItem.Checked) {
                foreach (string checksum in SongCategoryChecksums) {
                    SongCategoriesList.Items.Add(checksum);
                }
            } else {
                foreach (string title in SongCategoryNames) {
                    SongCategoriesList.Items.Add(title);
                }
            }

            SongCategoriesHeader.Text = $"Song Categories ({SongCategoryNames.Count}):";
        }

        private void showCategoryChecksumsToolStripMenuItem_Click(object sender, EventArgs e) {
            showCategoryChecksumsToolStripMenuItem.Checked = !showCategoryChecksumsToolStripMenuItem.Checked;

            showCategoryChecksumsToolStripMenuItem.Text = (showCategoryChecksumsToolStripMenuItem.Checked) ? "Show Category Names" : "Show Category Checksums";

            SongCategoriesList.Items.Clear();

            // Do we want category names, or do we want category checksums?
            if (showCategoryChecksumsToolStripMenuItem.Checked) {
                foreach (string checksum in SongCategoryChecksums) {
                    SongCategoriesList.Items.Add(checksum);
                }
            } else {
                foreach (string title in SongCategoryNames) {
                    SongCategoriesList.Items.Add(title);
                }
            }
        }

        /// <summary>
        ///  Add all of the selected songs to the currently selected category!
        /// </summary>
        public void AddSongsToCurrentCategory() {
            // Is a category loaded and do we have song mods to add?
            if (SongModsList.SelectedItems.Count > 0 && CurrentLoadedCategoryChecksum != "") {

                // Are we certain we want to add all of the selected songs? Ask!
                string addAllMessage = $"You've selected a total of {SongModsList.SelectedItems.Count} song mod(s) " +
                                        "to add to the current category.\n\n" +
                                        "Note: This will OVERWRITE any pre-existing categories these songs may or " +
                                        "may not have been tied to previously!\n\n" +
                                        "Are you sure you want to add all of these songs?";
                bool shouldAddAll = (MessageBox.Show(addAllMessage, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);

                if (!shouldAddAll) return;

                // - - - - - - - - - - - - - - - - - - -

                // Get the song list indices.
                List<string> setList = (showSongChecksumsToolStripMenuItem.Checked) ? SongChecksums : SongTitles;
                int[] modPathIndexes = GetItemIndexesInList(setList, SongModFilter.Text);

                // - - - - - - - - - - - - - - - - - - -

                // Required song path indices.
                List<int> requiredIndices = new List<int>();

                // Get the selected indices of the items.
                var selectedIdxs = SongModsList.SelectedIndices;
                foreach (int idx in selectedIdxs) {
                    int locatedIdx = modPathIndexes[idx];
                    Console.WriteLine($"located index: {locatedIdx}");
                    requiredIndices.Add(locatedIdx);
                }

                // - - - - - - - - - - - - - - - - - - -

                // Next task, get all the paths:
                List<string> songConfigPaths = new List<string>();
                foreach (int idx in requiredIndices) {
                    string songConfigPath = SongModPaths[idx];
                    Console.WriteLine($"detected path: {songConfigPath}");
                    songConfigPaths.Add(songConfigPath);
                }

                // - - - - - - - - - - - - - - - - - - -

                // Now, we've finally done all the required setup!
                // We can FINALLY start adding songs to the category of our choosing!

                // Set up our INI file object.
                INI file;

                // Go through every song path!
                foreach (string path in songConfigPaths) {
                    
                    // Initialize INI with this file.
                    file = new INI(path);

                    // Write our category checksum!
                    file.SetString("SongInfo", "GameCategory", CurrentLoadedCategoryChecksum);

                }

                ReadAttachedSongs();
            }
        }

        private void addToCategoryToolStripMenuItem_Click(object sender, EventArgs e) {

            AddSongsToCurrentCategory();

            /*
            if (SongModsList.SelectedItems.Count > 0 && CurrentLoadedCategoryChecksum != "") {
                // What index do we need?
                string pathToCheck;

                List<string> setList = (showSongChecksumsToolStripMenuItem.Checked) ? SongChecksums : SongTitles;
                int[] modPathIndexes = GetItemIndexesInList(setList, SongModFilter.Text);

                pathToCheck = SongModPaths[modPathIndexes[SongModsList.SelectedIndex]];

                INI file;

                string folderINIPath = Path.Combine(Path.GetDirectoryName(pathToCheck), "../folder.ini");

                if (File.Exists(folderINIPath)) {
                    file = new INI(folderINIPath);
                } else file = new INI(pathToCheck);

                if (file.HasKey("SongInfo", "GameCategory")) {
                    if (file.GetString("SongInfo", "GameCategory") == CurrentLoadedCategoryChecksum) {
                        string alreadyTiedMessage = "This song is already tied to this category!";

                        MessageBox.Show(alreadyTiedMessage, "Already Tied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (!file.HasKey("SongInfo", "GameCategory")) {
                    // Do we want to add this song to the category?
                    string addToCateMessage = "You've chosen to add the following song to the currently selected category:\n\n" +
                                             $"{SongModsList.SelectedItems[0]}\n\n" +
                                              "Is this correct?";

                    if (MessageBox.Show(addToCateMessage, "Add Song to Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
                        return;
                    }
                } else {
                    // Warn the user that this song is already tied, do we
                    // want to overwrite it?
                    string overwriteCateMessage = "This song has already been tied to a pre-existing category. " +
                                                  "Do you want to overwrite it with the currently selected one?";

                    if (MessageBox.Show(overwriteCateMessage, "Overwrite Tied Category?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) {
                        return;
                    }
                }


                V3LauncherCore.DebugLog.Add($"path to check: {pathToCheck}");

                file.SetString("SongInfo", "GameCategory", CurrentLoadedCategoryChecksum);

                ReadAttachedSongs();
            }
            */
        }

        private void removeFromCategoryToolStripMenuItem_Click(object sender, EventArgs e) {
            if (SongModsList.SelectedItems.Count <= 0) return;

            List<string> setList = (showSongChecksumsToolStripMenuItem.Checked) ? SongChecksums : SongTitles;
            int[] modPathIndexes = GetItemIndexesInList(setList, SongModFilter.Text);

            string pathToConfig = Path.Combine(Path.GetDirectoryName(SongModPaths[modPathIndexes[SongModsList.SelectedIndex]]), "song.ini");

            string folderINIPath = Path.Combine(Path.GetDirectoryName(SongModPaths[modPathIndexes[SongModsList.SelectedIndex]]), "../folder.ini");

            IniFile file = new IniFile();
            string pathToLoad;
            if (File.Exists(folderINIPath)) {
                pathToLoad = folderINIPath;
            } else {
                pathToLoad = pathToConfig;
            }
            file.Load(pathToLoad);

            string removeTiedCategoryWarning = "Are you sure you want to remove the tied category from this song mod? " +
                                               "Doing this will place the song in the WTDE category.";
            if (MessageBox.Show(removeTiedCategoryWarning, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                // Song INI file?
                if (pathToLoad == pathToConfig) {
                    file.Sections["SongInfo"].Keys["GameCategory"].Value = "none";
                    file.Save(pathToConfig);

                // Folder INI file?
                } else {
                    string wtdeDir = V3LauncherCore.GetUpdaterINIDirectory();
                    var splitPath = pathToConfig.Replace('\\', '/').Split('/');
                    string lastFolderName = splitPath[splitPath.Length - 2];

                    string sourceDir = Path.GetDirectoryName(pathToConfig);
                    string destDir = Path.Combine($"{wtdeDir}/DATA/MODS", lastFolderName);

                    V3LauncherCore.DebugLog.Add($"Moving file out to untie from category...\n" +
                                                $"last folder name: {lastFolderName}\n" +
                                                $"source path: {sourceDir}\n" +
                                                $"destination path: {destDir}");

                    if (Directory.Exists(destDir)) Directory.Delete(destDir, true);

                    Directory.Move(sourceDir, destDir);

                    // So do we still have a tied category even after moving?
                    // If so, let's get rid of it too.
                    IniFile file2 = new IniFile();
                    file2.Load(Path.Combine(destDir, "song.ini"));

                    // Untie the category if we still have one tied after moving.
                    if (file2.Sections["SongInfo"].Keys.Contains("GameCategory")) {
                        file2.Sections["SongInfo"].Keys["GameCategory"].Value = "none";
                        file2.Save(Path.Combine(destDir, "song.ini"));
                    }
                }

                MessageBox.Show("Mod was removed from its tied category.", "Mod Untied", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UnloadAllData();
                UpdateActiveSongControls();
                GetSongsAndCategories();
            }
        }

        private void openModConfigToolStripMenuItem_Click(object sender, EventArgs e) {
            if (SongModsList.SelectedItems.Count <= 0) return;

            List<string> setList = (showSongChecksumsToolStripMenuItem.Checked) ? SongChecksums : SongTitles;
            int[] modPathIndexes = GetItemIndexesInList(setList, SongModFilter.Text);

            Process.Start("notepad.exe", Path.Combine(Path.GetDirectoryName(SongModPaths[modPathIndexes[SongModsList.SelectedIndex]]), "song.ini"));
        }

        private void openModFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            if (SongModsList.SelectedItems.Count <= 0) return;

            List<string> setList = (showSongChecksumsToolStripMenuItem.Checked) ? SongChecksums : SongTitles;
            int[] modPathIndexes = GetItemIndexesInList(setList, SongModFilter.Text);

            Process.Start("explorer.exe", Path.GetDirectoryName(SongModPaths[modPathIndexes[SongModsList.SelectedIndex]]));
        }

        private void editSongDataToolStripMenuItem_Click(object sender, EventArgs e) {
            if (SongModsList.SelectedItems.Count <= 0) return;

            List<string> setList = (showSongChecksumsToolStripMenuItem.Checked) ? SongChecksums : SongTitles;
            int[] modPathIndexes = GetItemIndexesInList(setList, SongModFilter.Text);

            SCMSongProperties ssp = new SCMSongProperties(Path.Combine(SongModPaths[modPathIndexes[SongModsList.SelectedIndex]], "song.ini"), SongCategoryNames, SongCategoryChecksums);
            ssp.ShowDialog();

            UnloadAllData();
            GetSongsAndCategories();
        }

        private void openModsFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            var owd = Directory.GetCurrentDirectory();
            ModHandler.UseUpdaterINIDirectory();
            Process.Start("explorer.exe", Path.Combine("DATA", "MODS"));
            Directory.SetCurrentDirectory(owd);
        }

        private void closeManagerToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        public void UpdateMenuCommands() {
            // -- SONG MENU ------------------------
            bool enableVariousCommandsS = (SongModsList.SelectedItems.Count > 0);

            editSongDataToolStripMenuItem.Enabled = enableVariousCommandsS;
            // ----------------------
            openModConfigToolStripMenuItem.Enabled = enableVariousCommandsS;
            openModFolderToolStripMenuItem.Enabled = enableVariousCommandsS;
            // ----------------------
            addToCategoryToolStripMenuItem.Enabled = enableVariousCommandsS;
            AddSongsToCategoryButton.Enabled = enableVariousCommandsS;
            removeFromCategoryToolStripMenuItem.Enabled = enableVariousCommandsS;

            // -- SONG CATEGORY MENU ------------------------
            bool enableVariousCommandsC = (SongCategoriesList.SelectedItems.Count > 0);
            bool enableMakeSetlistZIP = (AttachedCategorySongs.Items.Count > 0);
            
            deleteCategoryToolStripMenuItem.Enabled = enableVariousCommandsC;
            editCategoryDataToolStripMenuItem.Enabled = enableVariousCommandsC;
            // ----------------------
            makeSetlistZIPToolStripMenuItem.Enabled = enableMakeSetlistZIP;
            // ----------------------
            openModConfigToolStripMenuItem1.Enabled = enableVariousCommandsC;
            openModFolderToolStripMenuItem1.Enabled = enableVariousCommandsC;
        }

        private void songToolStripMenuItem_Click(object sender, EventArgs e) {
            UpdateMenuCommands();
        }

        private void songCategoryToolStripMenuItem_Click(object sender, EventArgs e) {
            UpdateMenuCommands();
        }

        private void openModConfigToolStripMenuItem1_Click(object sender, EventArgs e) {
            if (SongCategoriesList.SelectedItems.Count <= 0) return;

            List<string> setList = (showCategoryChecksumsToolStripMenuItem.Checked) ? SongCategoryChecksums : SongCategoryNames;
            int[] modPathIndexes = GetItemIndexesInList(setList, SongCategoryFilter.Text);

            Process.Start("notepad.exe", Path.Combine(Path.GetDirectoryName(SongCategoryPaths[modPathIndexes[SongCategoriesList.SelectedIndex]]), "category.ini"));
        }

        private void openModFolderToolStripMenuItem1_Click(object sender, EventArgs e) {
            if (SongCategoriesList.SelectedItems.Count <= 0) return;

            List<string> setList = (showCategoryChecksumsToolStripMenuItem.Checked) ? SongCategoryChecksums : SongCategoryNames;
            int[] modPathIndexes = GetItemIndexesInList(setList, SongCategoryFilter.Text);

            Process.Start("explorer.exe", Path.GetDirectoryName(SongCategoryPaths[modPathIndexes[SongCategoriesList.SelectedIndex]]));
        }

        public List<string> GetSongsForZIP() {
            List<string> songModPaths = new List<string>();
            foreach (ListViewItem item in AttachedCategorySongs.Items) {
                string modDir = item.SubItems[2].Text;
                modDir = Path.GetDirectoryName(Path.GetFullPath(modDir));
                songModPaths.Add(modDir);
                Console.WriteLine($"Added directory: {modDir}");
            }

            return songModPaths;
        }

        private void MakeSetlistZIPButton_Click(object sender, EventArgs e) {
            List<string> songModPaths = GetSongsForZIP();

            SCMMakeSetlistZIP makeZIP = new SCMMakeSetlistZIP(
                songModPaths, CurrentLoadedCategoryChecksum,
                CurrentLoadedCategoryPath, CurrentLoadedCategoryImageName);

            makeZIP.ShowDialog();
        }

        private void makeSetlistZIPToolStripMenuItem_Click(object sender, EventArgs e) {
            List<string> songModPaths = GetSongsForZIP();

            SCMMakeSetlistZIP makeZIP = new SCMMakeSetlistZIP(
                songModPaths, CurrentLoadedCategoryChecksum,
                CurrentLoadedCategoryPath, CurrentLoadedCategoryImageName);

            makeZIP.ShowDialog();
        }

        private void AddSongsToCategoryButton_Click(object sender, EventArgs e) {
            AddSongsToCurrentCategory();
        }
    }
}
