// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       S O N G       A N D       C A T E G O R Y       M A N A G E R
//          C H A N G E       S O N G       C A T E G O R Y
//
//    The Mod Manager's song and song category mod manager's dialog for moving
//    the currently selected songs to a different category.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.IO;

// Other imports.
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
    ///  The Mod Manager's song and song category mod manager's dialog for moving
    ///  the currently selected songs to a different category.
    /// </summary>
    public partial class SCMChangeCategory : Form {
        /// <summary>
        ///  The Mod Manager's song and song category mod manager's dialog for moving
        ///  the currently selected songs to a different category.
        /// </summary>
        public SCMChangeCategory(IEnumerable<string> categoryChecksums, string originalCategory) {
            // Initialize Designer, yada yada, you get the idea
            InitializeComponent();

            // Add our checksums EXCEPT the one we specified!
            foreach (string checksum in categoryChecksums) {
                // Is it the original one? Skip it!
                if (checksum.ToLower() == originalCategory.ToLower()) continue;
                SongCategoriesList.Items.Add(checksum);
            }

            CategoryChecksums = categoryChecksums;
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  List of category checksums.
        /// </summary>
        public IEnumerable<string> CategoryChecksums = new List<string>();

        /// <summary>
        ///  What category is the desired move location?
        /// </summary>
        public string DestinationCategory = "";
        
        // - - - - - - - - - - - - - - - - - - - - - - -

        // When clicked, change the destination category to the text
        // of our currently selected ListBox item!
        private void SongCategoriesList_SelectedIndexChanged(object sender, EventArgs e) {
            if (SongCategoriesList.SelectedItems.Count > 0) {
                DestinationCategory = SongCategoriesList.SelectedItems[0].ToString();
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        private void OKButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
