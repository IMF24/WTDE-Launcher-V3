// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       I N S T R U M E N T       S E L E C T O R
//
//    Dialog for selecting instruments.
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

namespace WTDE_Launcher_V3.Managers {
    /// <summary>
    ///  Dialog for selecting instruments.
    /// </summary>
    public partial class SelectInstrumentMod : Form {
        /// <summary>
        ///  Dialog for selecting characters.
        /// </summary>
        public SelectInstrumentMod(Control sourceControl) {
            // Initialize Designer code.
            InitializeComponent();

            // Set the source control we'll modify the text for.
            SourceControl = sourceControl;

            // Read our instrument mods!
            // Used for the guitars and basses tabs.
            ReadInstrumentMods();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  What control do we want to hold the text output in?
        /// </summary>
        public Control SourceControl;

        /// <summary>
        ///  Lead guitar mods.
        /// </summary>
        public List<string[]> GuitarMods = new List<string[]>();

        /// <summary>
        ///  Bass guitar mods.
        /// </summary>
        public List<string[]> BassMods = new List<string[]>();

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Reads the user's guitar and bass instrument mods.
        /// </summary>
        public void ReadInstrumentMods() {
            // Clear the guitar/bass list boxes' contents.
            GuitarModsList.Items.Clear();
            BassModsList.Items.Clear();

            // Show numerical counts on headers.
            GuitModsHeader.Text = "Refreshing...";
            BassModsHeader.Text = "Refreshing...";

            // Update idle tasks.
            Application.DoEvents();

            // Get the instrument mods.
            List<string[]> instrumentMods = ModHandler.GetModsByType(ModHandler.ModTypes.Instrument);

            // Now go through each mod and determine whether it is a lead
            // guitar or a bass guitar.
            // Depending on the detected type, we'll set the contents
            // of our list boxes!
            foreach (string[] mod in instrumentMods) {
                // Read the INI file of this mod.
                // If it doesn't exist, then just skip it.
                if (!File.Exists(mod[5])) continue;
                INI cf = new INI(mod[5]);

                // For the purposes of how WTDE works, the name or ID of
                // the instrument is the FOLDER NAME of it.
                // We'll use our helper function for that task.
                string instName = Helpers.LastFolderNameOnly(mod[6]);

                // Next up, check the type of instrument!
                string instType = cf.GetString("InstrumentInfo", "Instrument", "guitar");

                // Add in the instrument based on the type.
                // It's a bass!
                if (instType == "bass") {
                    BassMods.Add(mod);
                    BassModsList.Items.Add(instName);

                // It's a guitar!
                } else {
                    GuitarMods.Add(mod);
                    GuitarModsList.Items.Add(instName);
                }

                // Show numerical counts on headers.
                GuitModsHeader.Text = $"Lead Guitar Mods ({GuitarMods.Count}):";
                BassModsHeader.Text = $"Bass Guitar Mods ({BassMods.Count}):";
            }

            // Update idle tasks.
            Application.DoEvents();
        }

        private void RefreshGtrModsButton_Click(object sender, EventArgs e) {
            ReadInstrumentMods();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    }
}
