// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       C A R       R O C K E R       M A N A G E R
//
//    The Mod Manager's Rock Star Creator character manager, which allows the
//    user to more easily control their CAR characters through the 1.2+ system
//    for custom, in-game rockers.
//
//    WTDE changed its system for Rock Star Creator characters in update 1.2,
//    which allowed user-shareable CARs through the use of *.car files. This
//    manager allows the user to easily install and manage them.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;
using WTDE_Launcher_V3.IO;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Launcher_V3.Managers {
    /// <summary>
    ///  The Mod Manager's Rock Star Creator character manager, which allows the
    ///  user to more easily control their CAR characters through the 1.2+ system
    ///  for custom, in-game rockers.
    ///  <br/><br/>
    ///  WTDE changed its system for Rock Star Creator characters in update 1.2,
    ///  which allowed user-shareable CARs through the use of *.car files. This
    ///  manager allows the user to easily install and manage them.
    /// </summary>
    public partial class CARManager : Form {
        /// <summary>
        ///  The Mod Manager's Rock Star Creator character manager, which allows the
        ///  user to more easily control their CAR characters through the 1.2+ system
        ///  for custom, in-game rockers.
        ///  <br/><br/>
        ///  WTDE changed its system for Rock Star Creator characters in update 1.2,
        ///  which allowed user-shareable CARs through the use of *.car files. This
        ///  manager allows the user to easily install and manage them.
        /// </summary>
        public CARManager() {
            InitializeComponent();
            GetCARProfiles();
        }

        public void GetCARProfiles() {
            CARProfilesList.Items.Clear();
            CARFilesHeader.Text = "Refreshing...";

            Application.DoEvents();

            List<string> carFileList = Directory.GetFiles(V3LauncherConstants.WTDEProfilesDir).ToList();
            carFileList.Sort();

            foreach (string carFile in carFileList) {
                CARProfilesList.Items.Add(Path.GetFileName(carFile));
            }

            CARFilesHeader.Text = $"Installed Rockers ({CARProfilesList.Items.Count}):";

            UpdateButtonStatus();
        }

        public void UpdateButtonStatus() {
            bool activateButtons = (CARProfilesList.SelectedItems.Count > 0);

            DeleteSelectedProfile.Enabled = activateButtons;

            MarkPreferredGuitarist.Enabled = activateButtons;
            MarkPreferredBassist.Enabled = activateButtons;
            MarkPreferredDrummer.Enabled = activateButtons;
            MarkPreferredSinger.Enabled = activateButtons;
            MarkPreferredFemaleSinger.Enabled = activateButtons;
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void InstallNewProfile_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select CAR File(s) to Install";
            ofd.Filter = "Rock Star Creator Characters|*.car";
            ofd.Multiselect = true;

            ofd.ShowDialog();

            if (ofd.FileNames.Length > 0) {
                string installAskMessage = $"You've chosen to {ofd.FileNames.Length} file(s) to install:\n";
                foreach (string carFile in ofd.FileNames) { 
                    installAskMessage += carFile + "\n";
                }
                installAskMessage += "\nIs this correct?";

                if (MessageBox.Show(installAskMessage, "Install CAR Files", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    foreach (string carFile in ofd.FileNames) {
                        try {
                            string fileName = Path.GetFileName(carFile);

                            if (File.Exists($"{V3LauncherConstants.WTDEProfilesDir}/{fileName}")) {
                                File.Delete($"{V3LauncherConstants.WTDEProfilesDir}/{fileName}");
                            }

                            File.Copy(carFile, $"{V3LauncherConstants.WTDEProfilesDir}/{fileName}");

                            MessageBox.Show("All characters were installed successfully!", "Install Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GetCARProfiles();
                        } catch (Exception exc) {
                            V3LauncherCore.AddDebugEntry($"!! ERROR INSTALLING CHARACTER !! - {exc.Message}", "CAR Manager");

                            string errorMessage = $"An error occurred installing the character(s):\n\nError info:\n{exc.Message}";

                            MessageBox.Show(errorMessage, "Error Installing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void RefreshProfilesList_Click(object sender, EventArgs e) {
            GetCARProfiles();
        }

        private void CARProfilesList_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateButtonStatus();
        }

        private void DeleteSelectedProfile_Click(object sender, EventArgs e) {
            if (CARProfilesList.SelectedItems.Count > 0) {
                string deleteWarning = "Are you sure you want to delete this character file? This cannot be undone!";

                if (MessageBox.Show(deleteWarning, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    string fileName = CARProfilesList.SelectedItems[0].ToString();

                    string sourceFile = $"{V3LauncherConstants.WTDEProfilesDir}/{fileName}";

                    if (File.Exists(sourceFile)) File.Delete(sourceFile);

                    GetCARProfiles();
                }
            }
        }

        private void OpenProfilesFolder_Click(object sender, EventArgs e) {
            Process.Start("explorer.exe", Path.GetFullPath(V3LauncherConstants.WTDEProfilesDir));
        }

        private void MarkPreferredGuitarist_Click(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "PreferredGuitarist", $"custom_character_{CARProfilesList.SelectedIndex}");
        }

        private void MarkPreferredBassist_Click(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "PreferredBassist", $"custom_character_{CARProfilesList.SelectedIndex}");
        }

        private void MarkPreferredDrummer_Click(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "PreferredDrummer", $"custom_character_{CARProfilesList.SelectedIndex}");
        }

        private void MarkPreferredSinger_Click(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "PreferredSinger", $"custom_character_{CARProfilesList.SelectedIndex}");
        }

        private void MarkPreferredFemaleSinger_Click(object sender, EventArgs e) {
            INIFunctions.SaveINIValue("Band", "PreferredFemaleSinger", $"custom_character_{CARProfilesList.SelectedIndex}");
        }
    }
}
