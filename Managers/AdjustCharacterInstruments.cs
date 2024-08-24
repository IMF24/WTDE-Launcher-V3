// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       A D J U S T       C H A R A C T E R       I N S T R U M E N T S
//
//    Allows the user to adjust the preferred instruments for characters.
//
//    This dialog is very heavily a WIP, and it will be finished in later
//    updates to the launcher.
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
    ///  Allows the user to adjust the preferred instruments for characters.
    /// </summary>
    public partial class AdjustCharacterInstruments : Form {
        /// <summary>
        ///  Allows the user to adjust the preferred instruments for characters.
        /// </summary>
        public AdjustCharacterInstruments(string characterName, string iniPath) {
            // Initialize Designer code.
            InitializeComponent();

            // Initialize fields for the class.
            ActiveCharacterName = characterName;
            ActiveCharacterFolderINI = iniPath;

            // Set character name in the window.
            ActiveCharacterLabel.Text = ActiveCharacterName;

            // Get the preferred instruments of the given character.
            ReadCharacterInstruments();

            // Get the user's instrument mods.
            List<string> modPaths = ModHandler.GetPropertyFromModType(ModHandler.ModTypes.Instrument, ModHandler.ModProperty.FolderPath);
            foreach (string modPath in modPaths) {
                InstrumentMods.Add(Helpers.LastFolderNameOnly(modPath));
            }
            //~ Helpers.DumpListContents(InstrumentMods, true);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  The name of the character being modified.
        /// </summary>
        public string ActiveCharacterName = "";

        /// <summary>
        ///  The path to the active character's INI file.
        /// </summary>
        public string ActiveCharacterFolderINI = "";

        /// <summary>
        ///  The instrument mods that the user has installed.
        /// </summary>
        public List<string> InstrumentMods = new List<string>();

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Reads the instruments of a the given character.
        /// </summary>
        /// <param name="characterName"></param>
        public void ReadCharacterInstruments() {
            // Make sure the given INI path exists!
            if (!File.Exists(ActiveCharacterFolderINI)) return;

            // Read the INI file.
            INI file = new INI(ActiveCharacterFolderINI);

            // Now, we want to get the preferred instruments.
            // We read our various INI keys for that:
            NewPreferredGuitar.Text = file.GetString("CharacterInfo", "FullGuitar");
            NewPreferredBass.Text = file.GetString("CharacterInfo", "FullBass");
            NewPreferredDrums.Text = file.GetString("CharacterInfo", "FullDrums");
            NewPreferredMic.Text = file.GetString("CharacterInfo", "FullMic");
            NewPreferredMicStand.Text = file.GetString("CharacterInfo", "FullMicStand");
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Handle choosing an instrument mod.
        /// </summary>
        /// <param name="tb">
        ///  The text box to apply this to.
        /// </param>
        public void SelectInstrumentMod(TextBox tb) {
            // Show an open file dialog, you get the idea.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Instrument Mod INI File";
            ofd.Filter = "Instrument Mod Config|*instrument.ini";
            ofd.Multiselect = false;
            ofd.ShowDialog();

            // Make sure we had a file and make sure it exists!
            if (ofd.FileName == "" || !File.Exists(ofd.FileName)) return;

            // Get the name of the instrument in the INI file!
            INI file = new INI(ofd.FileName);
            tb.Text = file.GetString("InstrumentInfo", "Name");
        }

        private void SelectGuitarButton_Click(object sender, EventArgs e) {
            SelectInstrumentMod(NewPreferredGuitar);
        }

        private void SelectBassButton_Click(object sender, EventArgs e) {
            SelectInstrumentMod(NewPreferredBass);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Write the new preferred instruments to the character mod!
        /// </summary>
        public void WriteNewInstruments() {
            INI file = new INI(ActiveCharacterFolderINI);
            file.SetString("CharacterInfo", "FullGuitar", NewPreferredGuitar.Text);
            file.SetString("CharacterInfo", "FullBass", NewPreferredBass.Text);
            file.SetString("CharacterInfo", "FullDrums", NewPreferredDrums.Text);
            file.SetString("CharacterInfo", "FullMic", NewPreferredMic.Text);
            file.SetString("CharacterInfo", "FullMicStand", NewPreferredMicStand.Text);
        }

        /// <summary>
        ///  When the OK button is pressed, handles closing the window.
        /// </summary>
        public void HandleClose() {
            WriteNewInstruments();
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e) {
            HandleClose();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
