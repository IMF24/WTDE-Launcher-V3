// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       S O N G       A N D       C A T E G O R Y       M A N A G E R
//          M A K E       S E T L I S T       Z I P
//
//    The Mod Manager's song and song category mod manager's dialog for turning
//    a category and its songs into a shareable ZIP file with others.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;
using WTDE_Launcher_V3.IO;

using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace WTDE_Launcher_V3.Managers {
    /// <summary>
    ///  The Mod Manager's song and song category mod manager's dialog for turning
    ///  a category and its songs into a shareable ZIP file with others.
    /// </summary>
    public partial class SCMMakeSetlistZIP : Form {
        /// <summary>
        ///  The Mod Manager's song and song category mod manager's dialog for turning
        ///  a category and its songs into a shareable ZIP file with others.
        /// </summary>
        public SCMMakeSetlistZIP(
                List<string> songs,
                string originalCategoryChecksum,
                string originalCategoryPath,
                string originalCategoryImage
            ) {
            InitializeComponent();

            // Set status label.
            ExportStatusLabel.Text = "";

            // Set member fields!
            OriginalSongPaths = songs;
            OriginalCategoryChecksum = originalCategoryChecksum;
            OriginalCategoryPath = originalCategoryPath;
            OriginalCategoryImage = originalCategoryImage;

            // Do control update initialization!
            FolderConfigChecksum.Text = OriginalCategoryChecksum;
            CompileSetlistZIPButton.Enabled = false;
            SetFolderINIConfigEnabledState();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Original song paths that this category has tied to it.
        /// </summary>
        public List<string> OriginalSongPaths;

        /// <summary>
        ///  The original checksum of the category that will be saved.
        /// </summary>
        public string OriginalCategoryChecksum;

        /// <summary>
        ///  The original path to the category that will be saved.
        /// </summary>
        public string OriginalCategoryPath;

        /// <summary>
        ///  The name of the image checksum for this category.
        /// </summary>
        public string OriginalCategoryImage;

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Actually export the ZIP file!
        /// </summary>
        public void DoZIPExport() {
            // Are we going to export?
            string exportWarningMessage = "Are you ready to compile this category and any companion mods into a ZIP file?\n\n" +
                                          "NOTE: After the compile has started, you will NO LONGER be able to change any data! " +
                                          "In order to change anything, you will need to open this dialog and start anew.\n\n" +
                                          "Are you ready to compile?";
            bool confirmExport = (MessageBox.Show(exportWarningMessage, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);
            
            // Actually begin exporting!
            if (confirmExport) {
                try {
                    var watch = new Stopwatch();
                    watch.Start();

                    Console.WriteLine("Compiling setlist ZIP from current category...");

                    // Switch the control status!
                    ExportOptionsPanel.Enabled = false;
                    CompileSetlistZIPButton.Enabled = false;
                    ExportStatusPanel.Enabled = true;

                    // Now, how many tasks do we need to complete?
                    int tasksDone = 0;
                    ExportProgressBar.Value = 0;

                    int totalTasks = (3 + (WriteFolderINIFile.Checked ? 1 : 0) + OriginalSongPaths.Count + ExtraSongsList.Items.Count + ExtraCategoriesList.Items.Count);
                    ExportProgressBar.Maximum = totalTasks;

                    // The temporary folder that will hold of our setlist data!
                    AddOutputLine("Making temporary folder...");

                    string tmpDirName = "C:/__TMP_LAUNCHER_SETLIST_ZIPPER";
                    if (Directory.Exists(tmpDirName)) Directory.Delete(tmpDirName, true);
                    Directory.CreateDirectory(tmpDirName);
                    tasksDone ++;

                    UpdateProgressBar(tasksDone, totalTasks);

                    // First up, copy the category folder!
                    AddOutputLine("Copying original category");

                    string cateFolderName = new DirectoryInfo(OriginalCategoryPath).Name;
                    Helpers.CopyDirectory(OriginalCategoryPath, Path.Combine(tmpDirName, cateFolderName), true);

                    // Now copy our original song paths!
                    int idx;
                    
                    idx = 0;
                    foreach (string path in OriginalSongPaths) {
                        idx ++;

                        AddOutputLine($"Copying file {idx} of {OriginalSongPaths.Count}...");

                        string originalSongDirName = new DirectoryInfo(path).Name;
                        string outDir = Path.Combine(tmpDirName + "/Songs", Helpers.NormalizeSlashes(originalSongDirName));
                        outDir = Helpers.NormalizeSlashes(outDir);

                        if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);

                        Console.WriteLine($"Source path: {path}\nDestination path: {outDir}");

                        AddOutputLine($"Source path: {path}");
                        AddOutputLine($"Destination path: {outDir}");

                        Helpers.CopyDirectory(path, outDir, true);

                        tasksDone ++;
                        UpdateProgressBar(tasksDone, totalTasks);
                    }

                    // - - - - - - - - - - - - - - - - - - - - - - -

                    // Next, copy our extra song paths!
                    idx = 0;
                    if (ExtraSongsList.Items.Count > 0) {
                        foreach (var item in ExtraSongsList.Items) {
                            idx ++;

                            AddOutputLine($"Copying file {idx} of {ExtraSongsList.Items.Count}...");

                            string path = item.ToString();

                            string originalSongDirName = new DirectoryInfo(path).Name;
                            string outDir = Path.Combine(tmpDirName + "/Songs", Helpers.NormalizeSlashes(originalSongDirName));
                            outDir = Helpers.NormalizeSlashes(outDir);

                            if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);

                            Console.WriteLine($"Source path: {path}\nDestination path: {outDir}");

                            AddOutputLine($"Source path: {path}");
                            AddOutputLine($"Destination path: {outDir}");

                            Helpers.CopyDirectory(path, outDir, true);

                            tasksDone++;
                            UpdateProgressBar(tasksDone, totalTasks);
                        }
                    }

                    // Next, copy our extra song categories!
                    idx = 0;
                    if (ExtraCategoriesList.Items.Count > 0) {
                        foreach (var item in ExtraCategoriesList.Items) {
                            idx ++;

                            AddOutputLine($"Copying file {idx} of {ExtraCategoriesList.Items.Count}...");

                            string path = item.ToString();

                            string originalSongDirName = new DirectoryInfo(path).Name;
                            string outDir = Path.Combine(tmpDirName + "/Extra Categories", Helpers.NormalizeSlashes(originalSongDirName));
                            outDir = Helpers.NormalizeSlashes(outDir);

                            if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);

                            Console.WriteLine($"Source path: {path}\nDestination path: {outDir}");

                            AddOutputLine($"Source path: {path}");
                            AddOutputLine($"Destination path: {outDir}");

                            Helpers.CopyDirectory(path, outDir, true);

                            tasksDone++;
                            UpdateProgressBar(tasksDone, totalTasks);
                        }
                    }

                    // - - - - - - - - - - - - - - - - - - - - - - -

                    // Lastly, for our user's convenience, let's write a folder.ini file!
                    // We'll only do this if we told the program to.
                    if (WriteFolderINIFile.Checked) {

                        AddOutputLine("Writing folder.ini file...");

                        string folderINIText = "[SongInfo]\n";

                        // -- INSERT CUSTOM CHECKSUM
                        if (UseCustomChecksum.Checked) {
                            folderINIText += "GameCategory = " + ((FolderConfigChecksum.Text.Trim() == "") ? OriginalCategoryChecksum : FolderConfigChecksum.Text) + "\n";
                        }

                        // -- INSERT GAME ICON
                        if (UseGameIcon.Checked) {
                            folderINIText += "GameIcon = " + ((FolderConfigIcon.Text.Trim() == "") ? OriginalCategoryImage : FolderConfigIcon.Text) + "\n";
                        }

                        // Write the folder.ini file!
                        string folderINIPath = Path.Combine(tmpDirName, "Songs/folder.ini");
                        using (StreamWriter sw = new StreamWriter(folderINIPath, false)) {
                            sw.Write(folderINIText);
                        }

                        tasksDone++;
                        UpdateProgressBar(tasksDone, totalTasks);
                    }

                    // - - - - - - - - - - - - - - - - - - - - - - -

                    // Zip the directory up, and save it to where we designated!
                    string finalOutPath = ZIPFileName.Text;

                    Console.WriteLine($"Saving ZIP file to path: {finalOutPath}\nTHIS MAY FREEZE THE WINDOW, JUST BE PATIENT");
                    AddOutputLine($"DIALOG MAY FREEZE: Saving ZIP file to path: {finalOutPath}");

                    if (File.Exists(finalOutPath)) File.Delete(finalOutPath);
                    ZipFile.CreateFromDirectory(tmpDirName, finalOutPath);

                    tasksDone++;
                    UpdateProgressBar(tasksDone, totalTasks);

                    // Clean up the temp directory, we no longer need it.
                    Directory.Delete(tmpDirName, true);

                    tasksDone++;
                    UpdateProgressBar(tasksDone, totalTasks);

                    watch.Stop();

                    Console.WriteLine($"Compile complete! ZIP package compile took {watch.Elapsed.TotalSeconds:0.00} sec");
                    AddOutputLine($"Compile complete! ZIP package compile took {watch.Elapsed.TotalSeconds:0.00} sec");

                    OpenFinishedZIPButton.Visible = true;

                    MessageBox.Show("The setlist package has been compiled successfully!", "Compile Complete!");

                } catch (Exception exc) {
                    Console.WriteLine($"An error occurred in exporting: {exc.Message}");
                    MessageBox.Show($"An error occurred in exporting the ZIP file:\n\n{exc.Message}", "Error Compiling", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Update the progress bar!
        /// </summary>
        /// <param name="current">
        ///  The current value.
        /// </param>
        /// <param name="max">
        ///  The maximum value.
        /// </param>
        public void UpdateProgressBar(int current, int max) {
            ExportProgressBar.Value = current;
            ExportProgressBar.Maximum = max;

            decimal progress = ((decimal) current / max) * 100M;
            ExportPercentLabel.Text = $"{progress:0.00}%";

            Application.DoEvents();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Set the text on our export status label!
        /// </summary>
        /// <param name="status">
        ///  The text to set on the export status label.
        /// </param>
        public void SetStatus(string status) {
            ExportStatusLabel.Text = status;
            Application.DoEvents();
        }

        /// <summary>
        ///  Add a line of text to the output log.
        /// </summary>
        /// <param name="outputLine">
        ///  Text to add to the output log.
        /// </param>
        public void AddOutputLine(string outputLine) {
            List<string> originalLines = OutputTextLog.Lines.ToList();
            originalLines.Add(outputLine);
            OutputTextLog.ReadOnly = false;
            OutputTextLog.Lines = originalLines.ToArray();
            OutputTextLog.Select(OutputTextLog.Text.Length - 1, 0);
            OutputTextLog.ScrollToCaret();
            OutputTextLog.ReadOnly = true;

            SetStatus(outputLine);

            Application.DoEvents();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // ZIP FILE OPTIONS
        // - - - - - - - - - - - - - - - - - - - - - - -

        private void SelectSavePathButton_Click(object sender, EventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Select Compiled ZIP Location";
            sfd.Filter = "ZIP Files|*.zip";
            sfd.ShowDialog();

            if (sfd.FileName != "") ZIPFileName.Text = sfd.FileName;
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // FOLDER INI OPTIONS
        // - - - - - - - - - - - - - - - - - - - - - - -
        
        /// <summary>
        ///  Sets the enabled state of all folder.ini options.
        /// </summary>
        public void SetFolderINIConfigEnabledState() {
            bool shouldEnable = (WriteFolderINIFile.Checked);

            // -- CATEGORY CHECKSUM
            UseCustomChecksum.Enabled = shouldEnable;
            FolderConfigChecksum.Enabled = shouldEnable;
            UseCategoryChecksumNameButton.Enabled = shouldEnable;
            SetGameCategoryState();

            // -- GAME ICON
            UseGameIcon.Enabled = shouldEnable;
            FolderConfigIcon.Enabled = shouldEnable;
            UseCategoryImageNameButton.Enabled = shouldEnable;
            SetGameIconState();
        }

        /// <summary>
        ///  Set the state of setting a custom category checksum override.
        /// </summary>
        public void SetGameCategoryState() {
            bool shouldEnable = (UseCustomChecksum.Checked);

            FolderConfigChecksum.Enabled = shouldEnable;
            UseCategoryChecksumNameButton.Enabled = shouldEnable;
        }

        /// <summary>
        ///  Set the state of setting a custom category icon override.
        /// </summary>
        public void SetGameIconState() {
            bool shouldEnable = (UseGameIcon.Checked);

            FolderConfigIcon.Enabled = shouldEnable;
            UseCategoryImageNameButton.Enabled = shouldEnable;
        }

        // - - - - - - - - - - - -

        private void ZIPFileName_TextChanged(object sender, EventArgs e) {
            bool finalCompileEnabled = (ZIPFileName.Text.Trim() != "");
            CompileSetlistZIPButton.Enabled = finalCompileEnabled;
        }

        private void WriteFolderINIFile_CheckedChanged(object sender, EventArgs e) {
            SetFolderINIConfigEnabledState();
        }

        private void UseCustomChecksum_CheckedChanged(object sender, EventArgs e) {
            SetGameCategoryState();
        }

        private void UseGameIcon_CheckedChanged(object sender, EventArgs e) {
            SetGameIconState();
        }

        private void UseCategoryChecksumNameButton_Click(object sender, EventArgs e) {
            FolderConfigChecksum.Text = OriginalCategoryChecksum;
        }

        private void UseCategoryImageNameButton_Click(object sender, EventArgs e) {
            FolderConfigIcon.Text = OriginalCategoryImage;
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // EXTRA ELEMENTS HANDLER
        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Adds an extra category, song, folder of categories, or folder of songs! that will be included in the final compile!
        /// </summary>
        /// <param name="multiple">
        ///  Optional: For multiple songs or categories, set this to true.
        /// </param>
        /// <param name="forSongs">
        ///  Optional: If meant for songs, set this to true.
        /// </param>
        public void AddExtraElement(bool multiple = false, bool forSongs = false) {
            // ------------------------
            // ADD SINGLE SONG OR CATEGORY
            // ------------------------
            if (!multiple) {
                // Ask for a category folder!
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = $"Select {((forSongs) ? "Song" : "Category")} Mod INI File";
                ofd.Filter = (forSongs) ? "Song INI File|*song.ini" : "Category INI File|*category.ini";
                ofd.Multiselect = false;

                ofd.ShowDialog();

                // Do we have a folder to add?
                if (ofd.FileName != "") {
                    // And does it exist?
                    if (File.Exists(ofd.FileName)) {
                        // Nice, it does!
                        // We'll get JUST THE DIRECTORY name of this.
                        string actualDir = Path.GetFullPath(Path.GetDirectoryName(ofd.FileName));
                        Console.WriteLine($"Adding directory: {actualDir}");

                        if (!forSongs) ExtraCategoriesList.Items.Add(actualDir);
                        else ExtraSongsList.Items.Add(actualDir);
                    }
                }

            // ------------------------
            // ADD MULTIPLE SONGS OR CATEGORIES
            // ------------------------
            } else {

                // Select a folder.
                // Using this gross, bad dialog box... Ugh...
                // Oh well, can't think of another way to do this.

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();

                // We got a folder, get all categories in it, if any.
                if (fbd.SelectedPath != "") {

                    // Get the INI files in this folder!
                    string iniFileFilter = (forSongs) ? "*song.ini" : "*category.ini";
                    string[] iniFiles = Directory.GetFiles(fbd.SelectedPath, iniFileFilter, SearchOption.AllDirectories);

                    // Are there any songs or categories in this folder?
                    // If so, we'll start inserting data.
                    // To do so, we'll just get the absolute path of it.
                    if (iniFiles.Length > 0) {
                        foreach (string iniFile in iniFiles) {
                            if (File.Exists(iniFile)) {
                                string actualDir = Path.GetFullPath(Path.GetDirectoryName(iniFile));
                                Console.WriteLine($"Adding directory: {actualDir}");

                                if (!forSongs) ExtraCategoriesList.Items.Add(actualDir);
                                else ExtraSongsList.Items.Add(actualDir);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  Delete an extra song or category out of the list(s).
        /// </summary>
        /// <param name="forSongs">
        ///  Optional: Is this for songs? If false, for categories.
        /// </param>
        public void DeleteExtraElements(bool forSongs = false) {
            List<int> idxListToDelete = new List<int>();

            ListBox lBox = (forSongs) ? ExtraSongsList : ExtraCategoriesList;

            foreach (var item in lBox.SelectedItems) {
                int idxToAdd = lBox.Items.IndexOf(item);
                Console.WriteLine($"Index of item was detected at {idxToAdd}");
                idxListToDelete.Add(idxToAdd);
            }

            foreach (int idx in idxListToDelete) {
                Console.WriteLine($"Deleting entry at index {idx}...");
                lBox.Items.RemoveAt(idx);
            }
        }

        /// <summary>
        ///  Clear the list of extra songs or categories!
        /// </summary>
        /// <param name="forSongs">
        ///  Optional: Is this for songs? If false, for categories.
        /// </param>
        public void ClearAllExtraElements(bool forSongs = false) {
            ListBox lBox = (forSongs) ? ExtraSongsList : ExtraCategoriesList;

            if (lBox.Items.Count <= 0) return;

            bool clearThisList = (MessageBox.Show("Are you sure you want to clear the list?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);

            if (clearThisList) lBox.Items.Clear();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // EXTRA CATEGORIES HANDLER
        // - - - - - - - - - - - - - - - - - - - - - - -

        private void AddSingleCateButton_Click(object sender, EventArgs e) {
            AddExtraElement();
        }

        private void AddFolderOfCatsButton_Click(object sender, EventArgs e) {
            AddExtraElement(true);
        }

        private void DeleteSingleExtraCateButton_Click(object sender, EventArgs e) {
            DeleteExtraElements();
        }

        private void ClearExtraCateListButton_Click(object sender, EventArgs e) {
            ClearAllExtraElements();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // EXTRA SONGS HANDLER
        // - - - - - - - - - - - - - - - - - - - - - - -

        private void AddSingleExSongButton_Click(object sender, EventArgs e) {
            AddExtraElement(forSongs: true);
        }

        private void AddFolderOfSongsButton_Click(object sender, EventArgs e) {
            AddExtraElement(true, true);
        }

        private void DeleteSingleExtraSongButton_Click(object sender, EventArgs e) {
            DeleteExtraElements(true);
        }

        private void ClearExtraSongListButton_Click(object sender, EventArgs e) {
            ClearAllExtraElements(true);
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // HANDLE EXPORT
        // - - - - - - - - - - - - - - - - - - - - - - -

        private void CompileSetlistZIPButton_Click(object sender, EventArgs e) {
            DoZIPExport();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -
        // CLOSE AND OPEN FINISHED ZIP BUTTONS
        // - - - - - - - - - - - - - - - - - - - - - - -

        private void OpenFinishedZIPButton_Click(object sender, EventArgs e) {
            // We'll use Path.Combine() for this, otherwise we might
            // run into other platform issues (for example, Linux).
            string outputFolder = Path.GetFullPath(Path.GetDirectoryName(ZIPFileName.Text));

            Process.Start("explorer.exe", outputFolder);
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            if (ExportOptionsPanel.Enabled) {
                bool shouldClose = (MessageBox.Show("Are you sure you want to exit? Your changes WILL NOT BE SAVED!", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);

                if (shouldClose) Close();
            } else { 
                Close();
            }
        }
    }
}
