// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       S C R I P T       M O D       E D I T O R S
//          M O D I F Y       C U S T O M       B A N D S
//
//    Modify and edit custom bands, and use them in GHWT: DE.
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

namespace WTDE_Launcher_V3.Managers.ScriptMods {
    /// <summary>
    ///  Modify and edit custom bands, and use them in GHWT: DE.
    /// </summary>
    public partial class ModifyCustomBands : Form {
        /// <summary>
        ///  Modify and edit custom bands, and use them in GHWT: DE.
        /// </summary>
        public ModifyCustomBands() {
            InitializeComponent();
            BGWorkMain.RunWorkerAsync();
        }

        /// <summary>
        ///  List of band layouts that will be written to the script mod.
        /// </summary>
        public List<BandLayout> Bands { get; set; } = new List<BandLayout>();

        /// <summary>
        ///  Active selected band. We'll hold this in memory in case we aren't focusing on the list box.
        /// </summary>
        public int ActiveBandIndex = 0;

        /// <summary>
        ///  How many new bands have we made?
        /// </summary>
        private int NewBandsCreated = 0;

        /// <summary>
        ///  Are we adding a new band? If so, DO NOT change anything yet!
        /// </summary>
        private bool AddingNewBand = false;

        /// <summary>
        ///  Adds a new band to the queue.
        /// </summary>
        public void CreateNewBand() {
            AddingNewBand = true;
            if (BandLayoutsList.SelectedItems.Count > 0) {
                BandLayoutsList.SelectedItems.Clear();
            }

            if (ActiveBandIndex < 0 || ActiveBandIndex >= Bands.Count) ActiveBandIndex = 0;
            
            NewBandsCreated++;

            // TODO: Need to account for changed properties when we make a new band layout.
            // We should write a function to ensure we save everything, THEN make a new layout.

            Bands.Add(new BandLayout($"New_Band_{NewBandsCreated}", "RandomCharacter", "RandomCharacter", "RandomCharacter", "RandomCharacter"));
            BandLayoutsList.Items.Add($"Band: New_Band_{NewBandsCreated}");

            BandName.Text = $"New_Band_{NewBandsCreated}";
            BandGuitarist.Text = "RandomCharacter";
            BandBassist.Text = "RandomCharacter";
            BandDrummer.Text = "RandomCharacter";
            BandSinger.Text = "RandomCharacter";

            ActiveBandIndex = Bands.Count;

            AllowPlayerChars.Checked = true;

            UpdateControlState();
            AddingNewBand = false;
        }

        /// <summary>
        ///  Delete the selected band from the queue.
        /// </summary>
        public void EraseSelectedBand() {
            if (Bands.Count <= 0 || ActiveBandIndex < 0) return;

            string confirmDeleteMsg = "Are you sure you want to delete this band layout? This cannot be undone!";

            if (MessageBox.Show(confirmDeleteMsg, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                var idx = ActiveBandIndex;

                Console.WriteLine($"active band index: {idx}");
                BandLayoutsList.Items.RemoveAt(idx);
                Bands.RemoveAt(idx);

                BandLayoutsList.SelectedItems.Clear();
                ActiveBandIndex = 0;
            }

            UpdateControlState();
        }

        /// <summary>
        ///  Updates the control states.
        /// </summary>
        public void UpdateControlState() {
            if (Bands.Count <= 0 || BandLayoutsList.Items.Count <= 0) {
                EraseBandButton.Enabled = false;
                MainEditorField.Enabled = false;
            } else {
                EraseBandButton.Enabled = true;
                MainEditorField.Enabled = true;
            }
        }

        /// <summary>
        ///  Loads band data from memory at the currently held memory index.
        /// </summary>
        public void LoadBandDataFromMemory() {
            if (AddingNewBand) return;

            var idx = ActiveBandIndex;
            if (idx < 0 || idx >= Bands.Count) return;

            BandLayout layout = Bands[idx];

            if (layout == null) return;

            BandName.Text = layout.Name;
            
            BandGuitarist.Text = layout.Guitarist;
            HideGuitarist.Checked = layout.HideGuitarist;

            BandBassist.Text = layout.Bassist;
            HideBassist.Checked = layout.HideBassist;

            BandDrummer.Text = layout.Drummer;
            HideDrummer.Checked = layout.HideDrummer;

            BandSinger.Text = layout.Vocalist;
            HideSinger.Checked = layout.HideSinger;

            AllowPlayerChars.Checked = layout.AllowPlayerSelectedCharacters;

            VocalistHasGuitar.Checked = layout.VocalistHasGuitar;
            VocalistHasBass.Checked = layout.VocalistHasBass;

            LoadingClip.Text = layout.LoadingClip;

            ApplyToSongs.Lines = layout.SongsToApplyTo;
        }

        /// <summary>
        ///  Stores the data in the main editor into memory.
        /// </summary>
        public void StoreEditorDataToMemory() {
            if (AddingNewBand) return;

            var idx = ActiveBandIndex;
            if (idx < 0 || idx >= Bands.Count) return;

            // At the given index, store all of our data!
            Bands[idx].Name = BandName.Text;

            Bands[idx].Guitarist = BandGuitarist.Text;
            Bands[idx].HideGuitarist = HideGuitarist.Checked;

            Bands[idx].Bassist = BandBassist.Text;
            Bands[idx].HideBassist = HideBassist.Checked;

            Bands[idx].Drummer = BandDrummer.Text;
            Bands[idx].HideDrummer = HideDrummer.Checked;

            Bands[idx].Vocalist = BandSinger.Text;
            Bands[idx].HideSinger = HideSinger.Checked;

            Bands[idx].AllowPlayerSelectedCharacters = AllowPlayerChars.Checked;

            Bands[idx].VocalistHasGuitar = VocalistHasGuitar.Checked;
            Bands[idx].VocalistHasBass = VocalistHasBass.Checked;

            Bands[idx].LoadingClip = LoadingClip.Text;

            Bands[idx].SongsToApplyTo = ApplyToSongs.Lines;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        private void BGWorkMain_DoWork(object sender, DoWorkEventArgs e) {
            BackgroundWorker worker = (BackgroundWorker) sender;
            while (!worker.CancellationPending) {
                UpdateControlState();
                if (Bands.Count > 0) StoreEditorDataToMemory();
            }
        }

        private void NewBandButton_Click(object sender, EventArgs e) {
            CreateNewBand();
        }

        private void EraseBandButton_Click(object sender, EventArgs e) {
            EraseSelectedBand();
        }

        private void BandName_TextChanged(object sender, EventArgs e) {
            if (AddingNewBand) return;

            var idx = ActiveBandIndex;
            Console.WriteLine($"active band index: {idx}");
            Bands[idx].Name = BandName.Text;
            BandLayoutsList.Items[idx] = $"Band: {BandName.Text}";
        }

        private void BandLayoutsList_SelectedIndexChanged(object sender, EventArgs e) {
            if (AddingNewBand) return;

            ActiveBandIndex = BandLayoutsList.SelectedIndex;
            LoadBandDataFromMemory();
        }

        // - - - - - - - -   SELECT  BAND  MEMBER  CHARACTERS   - - - - - - - - \\
        
        private void SelectGuitaristChar_Click(object sender, EventArgs e) {
            SelectCharacterMod scm = new SelectCharacterMod(BandGuitarist);
            scm.ShowDialog();
        }

        private void SelectBassistChar_Click(object sender, EventArgs e) {
            SelectCharacterMod scm = new SelectCharacterMod(BandBassist);
            scm.ShowDialog();
        }

        private void SelectDrummerChar_Click(object sender, EventArgs e) {
            SelectCharacterMod scm = new SelectCharacterMod(BandDrummer);
            scm.ShowDialog();
        }

        private void SelectSingerChar_Click(object sender, EventArgs e) {
            SelectCharacterMod scm = new SelectCharacterMod(BandSinger);
            scm.ShowDialog();
        }

        // - - - - - - - - - - - - - - - - -- - - - - - - - - - - - - - - - - - \\


    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //    B A N D       L A Y O U T       C L A S S
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    /// <summary>
    ///  Used for creating band layouts.
    /// </summary>
    public class BandLayout {
        /// <summary>
        ///  Construct a new band layout object.
        /// </summary>
        /// <param name="name">
        ///  Name of the band.
        /// </param>
        /// <param name="gtr">
        ///  Name of the guitarist.
        /// </param>
        /// <param name="bas">
        ///  Name of the bassist.
        /// </param>
        /// <param name="drm">
        ///  Name of the drummer.
        /// </param>
        /// <param name="vox">
        ///  Name of the vocalist.
        /// </param>
        public BandLayout(string name, string gtr, string bas, string drm, string vox) {
            this.Name = name;
            this.Guitarist = gtr;
            this.Bassist = bas;
            this.Drummer = drm;
            this.Vocalist = vox;
        }

        /// <summary>
        ///  Name of the band.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Name of the guitarist.
        /// </summary>
        public string Guitarist { get; set; }

        /// <summary>
        ///  Hide the guitarist?
        /// </summary>
        public bool HideGuitarist { get; set; } = false;

        /// <summary>
        ///  Name of the bassist.
        /// </summary>
        public string Bassist { get; set; }

        /// <summary>
        ///  Hide the bassist?
        /// </summary>
        public bool HideBassist { get; set; } = false;

        /// <summary>
        ///  Name of the drummer.
        /// </summary>
        public string Drummer { get; set; }

        /// <summary>
        ///  Hide the drummer?
        /// </summary>
        public bool HideDrummer { get; set; } = false;

        /// <summary>
        ///  Name of the vocalist.
        /// </summary>
        public string Vocalist { get; set; }

        /// <summary>
        ///  Hide the vocalist?
        /// </summary>
        public bool HideSinger { get; set; } = false;

        /// <summary>
        ///  Allow the use of player selected characters?
        /// </summary>
        public bool AllowPlayerSelectedCharacters { get; set; } = true;

        /// <summary>
        ///  Should the vocalist have a guitar instrument?
        /// </summary>
        public bool VocalistHasGuitar { get; set; } = false;

        /// <summary>
        ///  Should the vocalist have a bass instrument?
        /// </summary>
        public bool VocalistHasBass { get; set; } = false;

        /// <summary>
        ///  Loading clip to be run when the band is created.
        /// </summary>
        public string LoadingClip { get; set; } = "";

        /// <summary>
        ///  Array of song checksums to apply the band layout to.
        /// </summary>
        public string[] SongsToApplyTo { get; set; } = new string[] { };

        /// <summary>
        ///  Interpret this BandLayout object into an ROQ struct that can be
        ///  written for use in script mods.
        /// </summary>
        /// <returns>
        ///  An ROQ struct in a string format that can be written for a script mod.
        /// </returns>
        public override string ToString() {
            string structString = $"SectionStruct {Name.Trim().Replace(" ", "_")}\n{{    StructHeader\n    {{";

            // -- GUITARIST
            if (!this.HideGuitarist) {
                structString += (this.Guitarist != "")
                                ? $"        StructQBKey guitarist = {NXFunctions.MakeQBKeyFromString(this.Guitarist)}\n"
                                : "        StructQBKey guitarist = RandomCharacter\n";
            } else {
                structString += "        StructQBKey guitarist = EmptyGuy\n";
            }

            // -- BASSIST
            if (!this.HideBassist) {
                structString += (this.Bassist != "")
                                ? $"        StructQBKey bassist = {NXFunctions.MakeQBKeyFromString(this.Bassist)}\n"
                                : "        StructQBKey bassist = RandomCharacter\n";
            } else {
                structString += "        StructQBKey bassist = EmptyGuy\n";
            }

            // -- DRUMMER
            if (!this.HideDrummer) {
                structString += (this.Drummer != "")
                                ? $"        StructQBKey drummer = {NXFunctions.MakeQBKeyFromString(this.Drummer)}\n"
                                : "        StructQBKey drummer = RandomCharacter\n";
            } else {
                structString += "        StructQBKey drummer = EmptyGuy\n";
            }

            // -- VOCALIST
            if (!this.HideSinger) {
                structString += (this.Vocalist != "")
                                ? $"        StructQBKey vocalist = {NXFunctions.MakeQBKeyFromString(this.Vocalist)}\n"
                                : "        StructQBKey vocalist = RandomCharacter\n";
            } else {
                structString += "        StructQBKey vocalist = EmptyGuy\n";
            }

            if (this.VocalistHasGuitar && !this.VocalistHasBass) {
                structString += "        StructQBKey vocalist_has_guitar\n";
            }

            if (this.VocalistHasBass && !this.VocalistHasGuitar) {
                structString += "        StructQBKey vocalist_has_bass\n";
            }

            if (this.AllowPlayerSelectedCharacters) {
                structString += "        StructQBKey allow_player_selected_characters = true\n";
            } else {
                structString += "        StructQBKey allow_player_selected_characters = false\n";
            }

            if (this.LoadingClip != "") {
                structString += $"        StructQBKey loading_clip = {this.LoadingClip.Trim().Replace(" ", "_")}\n";
            }

            structString += "    }\n}\n";

            return structString;
        }
    }
}
