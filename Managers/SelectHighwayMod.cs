// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       H I G H W A Y       M O D       S E L E C T O R
//
//    Dialog for selecting highway mod folders.
// ----------------------------------------------------------------------------
// V3 launcher imports.
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
    ///  Dialog for selecting highway mod folders.
    /// </summary>
    public partial class SelectHighwayMod : Form {
        /// <summary>
        ///  Dialog for selecting highway mod folders.
        /// </summary>
        /// <param name="inLabel"></param>
        public SelectHighwayMod(Control inLabel) {
            InitializeComponent();

            this.SourceLabel = inLabel;

            LoadCharacterMods();
        }

        public Control SourceLabel;

        public List<string> CharacterModFolderNames = new List<string>();

        public List<string> CharacterModPaths = new List<string>();

        public void LoadCharacterMods() {
            // Clear our list box out first.
            CharacterModsList.Items.Clear();

            // Let's get our character mods!
            List<string[]> characterMods = ModHandler.GetModsByType(ModHandler.ModTypes.Highway);

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

            CharModsHeader.Text = $"Highway Mods ({CharacterModsList.Items.Count}):";
        }

        private void OKButton_Click(object sender, EventArgs e) {
            if (CharacterModsList.SelectedItems.Count > 0) {
                string outName = CharacterModsList.SelectedItems[0].ToString();
                SourceLabel.Text = outName;
            }
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void RefreshCharModsButton_Click(object sender, EventArgs e) {
            LoadCharacterMods();
        }
    }
}
