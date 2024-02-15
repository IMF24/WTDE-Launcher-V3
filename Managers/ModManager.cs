// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       M O D       M A N A G E R
//
//    The Mod Manager, meant for the user to manage their mods with a
//    relatively user-friendly dialog.
// ----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Launcher_V3 {
    /// <summary>
    ///  The Mod Manager, meant for the user to manage their mods with a relatively user-friendly dialog.
    /// </summary>
    public partial class ModManager : Form {
        /// <summary>
        ///  What mod is selected? This property holds that mod's config file path.
        /// </summary>
        public string SelectedModConfig = "";

        public ModManager() {
            InitializeComponent();

            this.Text = $"GHWT: Definitive Edition Launcher - V{V3LauncherConstants.VERSION} - Mod Manager";

            // Populate the mod list.
            foreach (string[] mod in ModHandler.UserContentMods) {
                var listViewItem = new ListViewItem(mod);
                UserContentModsTree.Items.Add(listViewItem);
            }
        }

        public void RefreshModsList() {
            UserContentModsTree.Items.Clear();
            StatusLabelMain.Text = "Refreshing mods list...";

            Application.DoEvents();

            ModHandler.ReadMods();

            foreach (string[] mod in ModHandler.UserContentMods) {
                var listViewItem = new ListViewItem(mod);
                UserContentModsTree.Items.Add(listViewItem);
            }

            StatusLabelMain.Text = $"All done; scanned {ModHandler.UserContentMods.Count} valid mods";
        }

        private void UserContentModsTree_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                this.SelectedModConfig = UserContentModsTree.SelectedItems[0].SubItems[5].Text;
            } catch (Exception exc) {
                V3LauncherCore.DebugLog.Add($"Well, something bad happened: {exc}");
            }
            //~ Console.WriteLine($"Selected mod config: {this.SelectedModConfig}");
        }

        private void openModsFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            var owd = Directory.GetCurrentDirectory();
            ModHandler.UseUpdaterINIDirectory();
            Process.Start("explorer.exe", Path.Combine("DATA", "MODS"));
            Directory.SetCurrentDirectory(owd);
        }

        private void closeModManagerToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void refreshModsToolStripMenuItem_Click(object sender, EventArgs e) {
            RefreshModsList();
        }

        private void openSelectedModConfigToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("notepad.exe", this.SelectedModConfig);
        }

        private void openSelectedModConfigToolStripMenuItem1_Click(object sender, EventArgs e) {
            Process.Start("notepad.exe", this.SelectedModConfig);
        }

        private void openSelectedModFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Process.Start("explorer.exe", Path.GetDirectoryName(this.SelectedModConfig));
            } catch {
                return;
            }
        }

        private void openSelectedModFolderToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                Process.Start("explorer.exe", Path.GetDirectoryName(this.SelectedModConfig));
            } catch {
                return;
            }
        }

        private void deleteModToolStripMenuItem1_Click(object sender, EventArgs e) {
            if (this.SelectedModConfig != "" && Directory.Exists(Path.GetDirectoryName(this.SelectedModConfig))) {
                string deleteModWarning = "Warning: Are you sure you want to delete this mod? This cannot be undone!";

                if (MessageBox.Show(deleteModWarning, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    string modFolderDir = Path.GetDirectoryName(this.SelectedModConfig);
                    Directory.Delete(modFolderDir);
                }
            }
        }

        private void deleteModToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.SelectedModConfig != "" && Directory.Exists(Path.GetDirectoryName(this.SelectedModConfig))) {
                string deleteModWarning = "Warning: Are you sure you want to delete this mod? This cannot be undone!";

                if (MessageBox.Show(deleteModWarning, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    string modFolderDir = Path.GetDirectoryName(this.SelectedModConfig);
                    Directory.Delete(modFolderDir);
                }
            }
        }

        private void copyFolderPathToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Clipboard.SetText(Path.GetDirectoryName(this.SelectedModConfig));
            } catch (Exception exc) {
                V3LauncherCore.DebugLog.Add($"Clipboard failure, don't worry about it // Exception: {exc.Message}");
            }
        }

        private void installModsToolStripMenuItem_Click(object sender, EventArgs e) {
            ModInstaller modInstaller = new ModInstaller();
            modInstaller.ShowDialog();

            // REFRESH MODS LIST AFTER INSTALLING
            RefreshModsList();
        }

        private void copySelectedModFolderPathToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Clipboard.SetText(Path.GetDirectoryName(this.SelectedModConfig));
            } catch (Exception exc) {
                V3LauncherCore.DebugLog.Add($"Clipboard failure, don't worry about it // Exception: {exc.Message}");
            }
        }

        private void findModsToolStripMenuItem_Click(object sender, EventArgs e) {
            ModFinder finder = new ModFinder();
            finder.ShowDialog();

            // REFRESH MODS LIST AFTER INSTALLING
            RefreshModsList();
        }

        private void manageSaveFilesToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileManager sfm = new SaveFileManager();
            sfm.ShowDialog();
        }

        private void rockStarCreatorCharacterManagerToolStripMenuItem_Click(object sender, EventArgs e) {
            CARManager cam = new CARManager();
            cam.ShowDialog();
        }

        private void manageDuplicateSongChecksumsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                DupeChecksumManager dcm = new DupeChecksumManager();
                dcm.ShowDialog();
            } catch (Exception exc) {
                V3LauncherCore.DebugLog.Add($"Issue with Duplicate Song Checksum Manager // Exception: {exc.Message}");
            }

            // REFRESH MODS LIST AFTER INSTALLING
            RefreshModsList();
        }

        private void songAndSongCategoryManagerToolStripMenuItem_Click(object sender, EventArgs e) {
            SongMasterManager smm = new SongMasterManager();
            smm.ShowDialog();

            RefreshModsList();
        }

        private void ghwtNexusModsToolStripMenuItem_Click(object sender, EventArgs e) {
            V3LauncherCore.OpenSiteURL("https://www.nexusmods.com/guitarheroworldtour/mods/");
        }

        private void wtdeGoogleDriveToolStripMenuItem_Click(object sender, EventArgs e) {
            V3LauncherCore.OpenSiteURL("https://drive.google.com/drive/folders/1fK1R6gmLfPFlEf1LciXQ59B2Kd34dAmc");
        }
    }
}
