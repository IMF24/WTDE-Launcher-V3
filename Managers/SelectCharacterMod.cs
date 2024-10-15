// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       C H A R A C T E R       S E L E C T O R
//
//    Dialog for selecting characters.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;
using WTDE_Launcher_V3.IO;

// Other required imports.
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WTDE_Launcher_V3.Managers {
    /// <summary>
    ///  Dialog for selecting characters.
    /// </summary>
    public partial class SelectCharacterMod : Form {
        /// <summary>
        ///  Dialog for selecting characters.
        /// </summary>
        /// <param name="inLabel">
        ///  Input control to store the resulting character to.
        /// </param>
        public SelectCharacterMod(Control inLabel) {
            InitializeComponent();

            this.SourceLabel = inLabel;

            GameSortFilter.SelectedIndex = 0;
            LoadCharacterMods();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  What control do we want to hold the text output in?
        /// </summary>
        public Control SourceLabel;

        /// <summary>
        ///  The list of the character mod folder names, stripped of all path elements.
        /// </summary>
        public List<string> CharacterModFolderNames = new List<string>();

        /// <summary>
        ///  The list of folders that are validly detected character mods.
        /// </summary>
        public List<string> CharacterModPaths = new List<string>();

        /// <summary>
        ///  List of indices of character mods in the mods list.
        /// </summary>
        public List<int> CharacterModIndices = new List<int>();

        /// <summary>
        ///  The list of stock characters. See the <see cref="WTDEContentIDLists.StockCharacterLists"/> member field for more information.
        /// </summary>
        public static List<string[][]> StockCharacterLists = WTDEContentIDLists.StockCharacterLists;

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Selectable indices for the stock characters. Used in the final selection.
        /// </summary>
        public int[] StockSelectableIndices = new int[] { 0 };

        /// <summary>
        ///  Selectable indices for the modded characters. Used in the final selection.
        /// </summary>
        public int[] ModSelectableIndices = new int[] { 0 };

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Update the stock venue character list on the left side when the dropdown menu sort option is changed.
        /// </summary>
        public void UpdateStockCharList() {
            // Empty the list out.
            StockCharactersList.Items.Clear();

            // What game array do we want to filter by?
            int arrayID = GameSortFilter.SelectedIndex;
            
            // Out of range? Don't go further!
            if (arrayID > StockCharacterLists.Count - 1) return;

            // Loop through the array, populate the list box!
            // Index 0 contains the literal, user-friendly names.
            foreach (string[] characterInfo in StockCharacterLists[arrayID]) {
                StockCharactersList.Items.Add(characterInfo[0]);
            }
        }

        /// <summary>
        ///  Loads all installed character mods into the right list box.
        /// </summary>
        public void LoadCharacterMods() {
            // Clear our list box out first.
            CharacterModsList.Items.Clear();

            // Let's get our character mods!
            List<string[]> characterMods = ModHandler.GetModsByType(ModHandler.ModTypes.Character);

            // If we had none, just abort.
            if (characterMods.Count < 0) {
                this.Close();
                return;
            }

            // Now we'll get them down to just folder names.
            // Also add the paths to the mod paths list.
            List<string> charModNames = new List<string>();
            List<string> charModPaths = new List<string>();
            foreach (string[] characterMod in characterMods) {
                // Nice mess of string operators on this...
                // But anyway, get our folder name.
                string folderName = characterMod[6].Replace('\\', '/').Split('/').Last().Trim('/');
                charModNames.Add(folderName);
                charModPaths.Add(characterMod[6]);
            }

            // Set the object fields too!
            CharacterModFolderNames = charModNames;
            CharacterModPaths = charModPaths;

            // Now let's populate our list!
            foreach (string name in CharacterModFolderNames) {
                CharacterModsList.Items.Add(name);
            }

            CharModsHeader.Text = $"Character Mods ({CharacterModsList.Items.Count}):";
        }

        private void OKButton_Click(object sender, EventArgs e) {
            // If it's a character mod, just use the name!
            if (CharacterModsList.SelectedItems.Count > 0) {

                // Name of the character; store to source Control.
                string outName = CharacterModsList.SelectedItems[0].ToString();
                SourceLabel.Text = outName;

            // It's a stock character; we want to find its REAL ID!
            } else if (StockCharactersList.SelectedItems.Count > 0) {

                // Get game sort filter.
                int arrayID = GameSortFilter.SelectedIndex;

                // Name to look for!
                string outName = StockCharactersList.SelectedItems[0].ToString();

                // Find the actual character ID.
                foreach (string[] characterInfo in StockCharacterLists[arrayID]) {

                    // Found the name, save it and break out!
                    if (characterInfo[0] == outName) {
                        outName = characterInfo[1];
                        break;
                    }
                }

                // Save the text to the source Control.
                SourceLabel.Text = outName;
            }

            // Close the window!
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void RefreshCharModsButton_Click(object sender, EventArgs e) {
            LoadCharacterMods();
        }

        private void GameSortFilter_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateStockCharList();
        }

        private void StockCharactersList_SelectedIndexChanged(object sender, EventArgs e) {
            if (CharacterModsList.SelectedItems.Count > 0) {
                CharacterModsList.SelectedItems.Clear();
            }
        }

        private void CharacterModsList_SelectedIndexChanged(object sender, EventArgs e) {
            if (StockCharactersList.SelectedItems.Count > 0) {
                StockCharactersList.SelectedItems.Clear();
            }
        }

        public void WriteCharacterListFile() {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Character List File";
            sfd.Filter = "Text Files|*.txt|All Files|*.*";

            sfd.ShowDialog();

            // Do we have a file to save?
            if (sfd.FileName != "") {
                // List of game names!
                string[] gameNames = new string[] { 
                    "GUITAR HERO: WORLD TOUR",
                    "GUITAR HERO I",
                    "GUITAR HERO II",
                    "GUITAR HERO III: LEGENDS OF ROCK",
                    "GUITAR HERO: AEROSMITH",
                    "GUITAR HERO: ON TOUR SERIES",
                    "BAND HERO (DS)",
                    "GUITAR HERO: METALLICA",
                    "GUITAR HERO: VAN HALEN",
                    "GUITAR HERO 5",
                    "BAND HERO",
                    "GUITAR HERO: WARRIORS OF ROCK",
                    "DJ HERO 1 & 2",
                    "GHWT: DEFINITIVE EDITION",
                    "TONY HAWK SERIES",
                    "RANDOM CHARACTERS"
                };

                // Now let's begin writing some data!
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8)) {
                    // Header text stuff.
                    sw.WriteLine("// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    sw.WriteLine("// -------------------------------------------------------------");
                    sw.WriteLine("//  WORLD TOUR DE CHARACTER IDS");
                    sw.WriteLine($"//    List exported on {DateTime.Now} // Auto generated by WTDE Launcher V3");
                    sw.WriteLine("// -------------------------------------------------------------");
                    sw.WriteLine("// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

                    // Write the characters themselves!
                    int index = 0;
                    foreach (string gameName in gameNames) {
                        sw.WriteLine($"\n// -------------------------------\n// {gameName}\n// -------------------------------");
                        foreach (string[] characterInfo in StockCharacterLists[index]) {
                            sw.WriteLine("Name: " + characterInfo[0] + " // ID: " + characterInfo[1]);
                        }
                        index++;
                    }

                    // Do we have character mods installed?
                    // If so, let's write them too!
                    // We just want to write folder names, since that's both the name and ID.
                    if (CharacterModFolderNames.Count > 0) {
                        sw.WriteLine("\n// -------------------------------\n// INSTALLED MOD CHARACTERS\n// -------------------------------");

                        foreach (string mod in CharacterModFolderNames) {
                            sw.WriteLine(mod);
                        }
                    }
                }
            }
        }

        private void ExportCharListButton_Click(object sender, EventArgs e) {
            WriteCharacterListFile();
        }

        private void OpenCASManagerButton_Click(object sender, EventArgs e) {
            this.Close();
            Thread.Sleep(1);
            CARManager car = new CARManager();
            car.ShowDialog();
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Apply a search filter to a list box.
        /// </summary>
        /// <param name="lBox">
        ///  The list box to read the contents of.
        /// </param>
        /// <param name="filter">
        ///  The search filter to read for.
        /// </param>
        /// <param name="label">
        ///  Label to change the text of.
        /// </param>
        /// <param name="labelText">
        ///  Text to change the given label to.
        /// </param>
        /// <param name="showCount">
        ///  Optional: Show a numeric count of all filtered results. Default is false (hidden).
        /// </param>
        /// <returns>
        ///  Array of integers with the filtered indices.
        /// </returns>
        public int[] ApplySearchFilter(ListBox lBox, string filter, Label label, string labelText, bool showCount = false) {
            // Get the strings from the list box.
            List<string> elements = new List<string>();
            foreach (string element in lBox.Items) { 
                elements.Add(element);
            }

            // Clear the input list box.
            lBox.Items.Clear();

            // Get the filtered items!
            int[] foundIndices = Helpers.GetStringListMatchIndices(elements, filter);

            // Iterate through our elements and add the strings back in!
            foreach (int idx in foundIndices) {
                lBox.Items.Add(elements[idx]);
            }

            // Update label text!
            label.Text = $"{labelText}{(showCount ? $" ({foundIndices.Length})" : "")}:";

            // Return the resulting integer array.
            return foundIndices;
        }

        private void ApplyStockSearchButton_Click(object sender, EventArgs e) {
            string filter = StockCharacterFilter.Text.Trim();
            if (filter != "") {
                StockSelectableIndices = ApplySearchFilter(StockCharactersList, filter, IGNCharsHeader, "Search Results", true);
            }
        }

        private void ResetStockSearchFilter_Click(object sender, EventArgs e) {
            StockCharacterFilter.Text = "";
            UpdateStockCharList();
            StockSelectableIndices = ApplySearchFilter(StockCharactersList, "", IGNCharsHeader, "In-Game Characters");
        }

        private void ApplyModSearchButton_Click(object sender, EventArgs e) {
            string filter = ModCharacterFilter.Text.Trim();
            if (filter != "") {
                ModSelectableIndices = ApplySearchFilter(CharacterModsList, filter, CharModsHeader, "Search Results", true);
            }
        }

        private void ResetModSearchFilter_Click(object sender, EventArgs e) {
            ModCharacterFilter.Text = "";
            LoadCharacterMods();
            ModSelectableIndices = ApplySearchFilter(CharacterModsList, "", CharModsHeader, "Character Mods", true);
        }
    }
}
