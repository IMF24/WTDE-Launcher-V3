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
        private int NewBandsCreated = 1;

        /// <summary>
        ///  Adds a new band to the queue.
        /// </summary>
        public void CreateNewBand() {
            Bands.Add(new BandLayout($"New_Band_{NewBandsCreated}", "RandomCharacter", "RandomCharacter", "RandomCharacter", "RandomCharacter"));
            BandLayoutsList.Items.Add($"Band: New_Band_{NewBandsCreated}");

            BandName.Text = $"New_Band_{NewBandsCreated}";
            BandGuitarist.Text = "RandomCharacter";
            BandBassist.Text = "RandomCharacter";
            BandDrummer.Text = "RandomCharacter";
            BandSinger.Text = "RandomCharacter";

            AllowPlayerChars.Checked = true;

            NewBandsCreated++;
        }

        private void NewBandButton_Click(object sender, EventArgs e) {
            CreateNewBand();
        }

        private void EraseBandButton_Click(object sender, EventArgs e) {

        }

        private void BandName_TextChanged(object sender, EventArgs e) {
            var idx = ActiveBandIndex;

            Bands[idx].Name = BandName.Text;
            BandLayoutsList.Items[idx] = $"Band: {BandName.Text}";
        }
    }

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
        public string Name;

        /// <summary>
        ///  Name of the guitarist.
        /// </summary>
        public string Guitarist;

        /// <summary>
        ///  Hide the guitarist?
        /// </summary>
        public bool HideGuitarist = false;

        /// <summary>
        ///  Name of the bassist.
        /// </summary>
        public string Bassist;

        /// <summary>
        ///  Hide the bassist?
        /// </summary>
        public bool HideBassist = false;

        /// <summary>
        ///  Name of the drummer.
        /// </summary>
        public string Drummer;

        /// <summary>
        ///  Hide the drummer?
        /// </summary>
        public bool HideDrummer = false;

        /// <summary>
        ///  Name of the vocalist.
        /// </summary>
        public string Vocalist;

        /// <summary>
        ///  Hide the vocalist?
        /// </summary>
        public bool HideSinger = false;

        /// <summary>
        ///  Allow the use of player selected characters?
        /// </summary>
        public bool AllowPlayerSelectedCharacters = true;

        /// <summary>
        ///  Should the vocalist have a guitar instrument?
        /// </summary>
        public bool VocalistHasGuitar = false;

        /// <summary>
        ///  Should the vocalist have a bass instrument?
        /// </summary>
        public bool VocalistHasBass = false;

        /// <summary>
        ///  Loading clip to be run when the band is created.
        /// </summary>
        public string LoadingClip = "";

        /// <summary>
        ///  Array of song checksums to apply the band layout to.
        /// </summary>
        public string[] SongsToApplyTo = new string[] { };

        /// <summary>
        ///  Interpret this BandLayout object into an ROQ struct that can be
        ///  written for use in script mods.
        /// </summary>
        /// <returns></returns>
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
