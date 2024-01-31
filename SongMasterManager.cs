﻿// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       S O N G       A N D       C A T E G O R Y       M A N A G E R
//
//    The Mod Manager's song and song category mod manager, which lets the user
//    more easily sort and categorize their songs.
// ----------------------------------------------------------------------------
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

namespace WTDE_Launcher_V3 {
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

        // - - - - - - - - - - - - - - - - - - - - - - -

        public SongMasterManager() {
            InitializeComponent();
            GetSongsAndCategories();
            UpdateActiveSongControls();
            UpdateMenuCommands();
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

            // Use IniFile for this to get the title, artist, and checksum.
            IniFile file = new IniFile();

            // Now let's do some populating!
            // Loop through our installed mods and get all song
            // and song category mods.
            foreach (string[] mod in ModHandler.UserContentMods) {
                // Read this INI file.
                file.Load(mod[5]);

                // Is this a song mod?
                if (mod[2] == "Song") {
                    // Get its title, artist, and checksum, then add all of
                    // that info to the lists.
                    string songName = file.Sections["SongInfo"].Keys["Title"].Value;
                    string songArtist = file.Sections["SongInfo"].Keys["Artist"].Value;

                    string songChecksum = file.Sections["SongInfo"].Keys["Checksum"].Value;

                    SongTitles.Add($"{songArtist} - {songName}");
                    SongChecksums.Add(songChecksum);
                    SongModPaths.Add(mod[5]);
                }

                // Is this a category mod?
                if (mod[2] == "Song Category") {
                    // Get the name and category checksum.
                    string cateName = file.Sections["CategoryInfo"].Keys["Name"].Value;
                    string cateChecksum = file.Sections["CategoryInfo"].Keys["Checksum"].Value;

                    SongCategoryNames.Add(cateName);
                    SongCategoryChecksums.Add(cateChecksum);
                    SongCategoryPaths.Add(mod[5]);
                }

                // Clear the sections list for the INI file so we can go again.
                file.Sections.Clear();
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

            int finalIndex;
            string categoryToSearch;
            List<string> setList = (showCategoryChecksumsToolStripMenuItem.Checked) ? SongCategoryChecksums : SongCategoryNames;
            int[] modPathIndexes = GetItemIndexesInList(setList, SongCategoryFilter.Text);

            categoryToSearch = SongCategoryChecksums[modPathIndexes[SongCategoriesList.SelectedIndex]];
            finalIndex = modPathIndexes[SongCategoriesList.SelectedIndex];

            CurrentLoadedCategoryChecksum = SongCategoryChecksums[modPathIndexes[SongCategoriesList.SelectedIndex]];

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
            foreach (string file in files) {
                string linkedCat, songName, songArtist, songChecksum;

                // New INI file object.
                IniFile iFile = new IniFile();

                // Is this an INI file? If so, read it!
                if (file.Contains(".ini")) {
                    iFile.Load(file);

                    // Now, we want either song.ini or folder.ini files.
                    switch (Path.GetFileName(file)) {
                        // Regular song config.
                        case "song.ini":
                            if (!iFile.Sections["SongInfo"].Keys.Contains("GameCategory")) linkedCat = "";
                            else linkedCat = iFile.Sections["SongInfo"].Keys["GameCategory"].Value;

                            if (linkedCat != "" && linkedCat.ToUpper() == categoryToSearch.ToUpper()) {
                                songName = iFile.Sections["SongInfo"].Keys["Title"].Value;
                                songArtist = iFile.Sections["SongInfo"].Keys["Artist"].Value;
                                songChecksum = iFile.Sections["SongInfo"].Keys["Checksum"].Value;

                                // Add the song's name, path, and checksum to the list.
                                string[] addArray = new string[] { $"{songArtist} - {songName}", songChecksum, Path.GetFullPath(file) };

                                // IS THIS SONG IN THE LIST ALREADY?
                                bool dupeFound = false;
                                foreach (var arr in outData) {
                                    dupeFound = (arr[0] == addArray[0]);
                                    if (dupeFound) break;
                                }

                                if (!dupeFound) outData.Add(addArray);
                            }

                            iFile.Sections.Clear();

                            break;

                        // Folder configs.
                        case "folder.ini":
                            // Is this the checksum we want?
                            // Remember that song category checksums are case INsensitive.
                            if (iFile.Sections["SongInfo"].Keys.Contains("GameCategory")) {
                                if (iFile.Sections["SongInfo"].Keys["GameCategory"].Value.ToUpper() == categoryToSearch.ToUpper()) {
                                    // This is the one we want, now we have to do another iteration
                                    // nested in here for this folder.
                                    string[] nestedFiles = Directory.GetFiles(Path.GetDirectoryName(file), "*.ini", SearchOption.AllDirectories);

                                    // Now go through the nested files and get the song names.
                                    foreach (string nestedFile in nestedFiles) {
                                        if (nestedFile.Contains("song.ini")) {
                                            // Need a new instance of IniFile to read this stuff.
                                            IniFile iFile2 = new IniFile();

                                            iFile2.Load(nestedFile);

                                            // Let's get the name, artist, and checksum for each song.
                                            songName = iFile2.Sections["SongInfo"].Keys["Title"].Value;
                                            songArtist = iFile2.Sections["SongInfo"].Keys["Artist"].Value;
                                            songChecksum = iFile2.Sections["SongInfo"].Keys["Checksum"].Value;

                                            // Add the song's name, path, and checksum to the list.
                                            string[] addArray = new string[] { $"{songArtist} - {songName}", songChecksum, Path.GetFullPath(nestedFile) };

                                            // IS THIS SONG IN THE LIST ALREADY?
                                            bool dupeFound = false;
                                            foreach (var arr in outData) {
                                                dupeFound = (arr[0] == addArray[0]);
                                                if (dupeFound) break;
                                            }

                                            if (!dupeFound) outData.Add(addArray);

                                            iFile2.Sections.Clear();
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
            }

            // - - - - - - - - - - - - - - - - - - - - - - -

            // Remove any duplicates, leave only distinct ones.
            outData = outData.Distinct().ToList();

            // Seems like only the last one gets duplicated?


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
            
        }

        /// <summary>
        ///  Read a Neversoft image file and display it in the given PictureBox. Also updates the given Label with information
        ///  about this image.
        /// </summary>
        /// <param name="picBox"></param>
        /// <param name="label"></param>
        public void OpenNXImageFile() {
            // Get image name from selected category config.
            IniFile iFile = new IniFile();
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

            iFile.Load(path);

            // Image name?
            if (!iFile.Sections["CategoryInfo"].Keys.Contains("Logo")) return;

            string imageName = iFile.Sections["CategoryInfo"].Keys["Logo"].Value;

            string imageDir = Path.Combine(Path.GetDirectoryName(path), $"{imageName}.img.xen");

            try {
                // Interpret the image file into something we can display in the picture box.
                // Credit: Wesley / donnaken15
                V3LauncherCore.AddDebugEntry("Decompiling image...", "Song & Song Category Manager");

                // Read all of the file's bytes.
                byte[] img = File.ReadAllBytes(imageDir);

                // Is this even an image file?
                if ((img[0] != 0x0A || img[1] != 0x28 || img[2] != 0x13 || img[3] != 0x00) &&
                    (img[0] != 0x0A || img[1] != 0x28 || img[2] != 0x11 || img[3] != 0x00)) {
                    V3LauncherCore.AddDebugEntry("Invalid Neversoft image", "Song & Song Category Manager");
                    return;
                }

                // A bunch of complicated stuff... Wes didn't document this.
                // But whatever, let's just roll with it.
                // Dody seems to tell me this is endian swapping, which makes sense.
                uint off = BitConverter.ToUInt32(img, 0x1C);
                uint len = BitConverter.ToUInt32(img, 0x20);
                if (BitConverter.IsLittleEndian) {
                    V3LauncherCore.AddDebugEntry("Is little endian, swapping stuff", "Song & Song Category Manager");
                    off = ESwap(off);
                    len = ESwap(len);
                }

                byte[] outData = new byte[len];
                Array.Copy(img, off, outData, 0, len);

                // Assuming DDS texture by default?
                string ext = ".dds";
                byte[] magic = new byte[4];

                Array.Copy(outData, magic, 4);

                // Let's figure out what type of image this is.
                V3LauncherCore.AddDebugEntry("Reading image format", "Song & Song Category Manager");
                byte[][] magics = new byte[4][] {
                    // DDS
                    new byte[4] { 0x44, 0x44, 0x53, 0x20 },
                    // PNG
                    new byte[4] { 0x89, 0x50, 0x4E, 0x47 },
                    // JPG
                    new byte[4] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    // BMP
                    new byte[4] { 0x42, 0x4D, 0x36, 0x16 },
                };
                string[] exts = { ".dds", ".png", ".jpg", ".bmp" };
                for (var i = 0; i < magics.Length; i++) {
                    if (magic[0] == magics[i][0] && magic[1] == magics[i][1] && magic[2] == magics[i][2]) {
                        ext = exts[i];
                        V3LauncherCore.AddDebugEntry($"image format is type {ext}", "Song & Song Category Manager");
                        break;
                    }
                }

                V3LauncherCore.AddDebugEntry($"Image data length: {outData.Length}", "Song & Song Category Manager");

                // Image has been decompiled, let's go!
                Image extractedImage;
                using (var ms = new MemoryStream(outData)) {
                    if (ext == ".png" || ext == ".jpg" || ext == ".bmp") {
                        extractedImage = Image.FromStream(ms);

                    // This is a DDS image, oh boy
                    // This requires a bit of work to convert it to a supported bitmap format.
                    // Using Pfim, we'll take it from DDS and convert it to PNG.
                    } else {
                        using (var image = Pfimage.FromStream(ms)) {
                            PixelFormat format;

                            // Go from Pfim image format to GDI+.
                            switch (image.Format) {
                                case Pfim.ImageFormat.Rgba32:
                                    format = PixelFormat.Format32bppArgb;
                                    break;

                                default:
                                    throw new NotImplementedException();
                                    break;
                            }

                            // This is specifically for DDS images.
                            var handle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
                            var data = Marshal.UnsafeAddrOfPinnedArrayElement(image.Data, 0);

                            // Now turn this new data into something we can display!
                            extractedImage = new Bitmap(image.Width, image.Height, image.Stride, format, data);

                            handle.Free();
                        }
                    }
                }

                LogoImageBox.Image = extractedImage;

                V3LauncherCore.AddDebugEntry("NX image decompiled!", "Song & Song Category Manager");
            } catch (Exception exc) {
                V3LauncherCore.AddDebugEntry($"Uh oh, something went wrong! - {exc}", "Song & Song Category Manager");
                //~ MessageBox.Show($"An error occurred reading the category's image: {exc}", "Error Opening File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                ReadAttachedSongs();
                OpenNXImageFile();
                UpdateActiveSongControls();
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

        private void deleteCategoryToolStripMenuItem_Click(object sender, EventArgs e) {
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

        private void addToCategoryToolStripMenuItem_Click(object sender, EventArgs e) {
            if (SongModsList.SelectedItems.Count > 0 && CurrentLoadedCategoryChecksum != "") {
                // What index do we need?
                string pathToCheck;

                List<string> setList = (showSongChecksumsToolStripMenuItem.Checked) ? SongChecksums : SongTitles;
                int[] modPathIndexes = GetItemIndexesInList(setList, SongModFilter.Text);

                pathToCheck = SongModPaths[modPathIndexes[SongModsList.SelectedIndex]];

                IniFile file = new IniFile();

                string folderINIPath = Path.Combine(Path.GetDirectoryName(pathToCheck), "../folder.ini");

                if (File.Exists(folderINIPath)) {
                    file.Load(folderINIPath);
                } else file.Load(pathToCheck);

                if (file.Sections["SongInfo"].Keys.Contains("GameCategory")) {
                    if (file.Sections["SongInfo"].Keys["GameCategory"].Value == CurrentLoadedCategoryChecksum) {
                        string alreadyTiedMessage = "This song is already tied to this category!";

                        MessageBox.Show(alreadyTiedMessage, "Already Tied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (!file.Sections["SongInfo"].Keys.Contains("GameCategory")) {
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

                if (!file.Sections["SongInfo"].Keys.Contains("GameCategory")) {
                    file.Sections["SongInfo"].Keys.Add("GameCategory");
                }
                file.Sections["SongInfo"].Keys["GameCategory"].Value = CurrentLoadedCategoryChecksum;

                if (File.Exists(folderINIPath)) {
                    file.Save(folderINIPath);
                } else file.Save(pathToCheck);

                ReadAttachedSongs();
            }
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
            removeFromCategoryToolStripMenuItem.Enabled = enableVariousCommandsS;

            // -- SONG CATEGORY MENU ------------------------
            bool enableVariousCommandsC = (SongCategoriesList.SelectedItems.Count > 0);

            deleteCategoryToolStripMenuItem.Enabled = enableVariousCommandsC;
            editCategoryDataToolStripMenuItem.Enabled = enableVariousCommandsC;
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
    }
}
