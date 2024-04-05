// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       S A V E       F I L E       M A N A G E R
//
//    The Mod Manager's save file manager, which lets the user manage their
//    WTDE specific save files.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Launcher_V3.Managers {
    /// <summary>
    ///  The Mod Manager's save file manager, which lets the user manage their
    ///  WTDE specific save files.
    /// </summary>
    public partial class SaveFileManager : Form {
        public SaveFileManager() {
            InitializeComponent();
            if (!Directory.Exists(V3LauncherConstants.WTDESaveBackupsDir)) {
                Directory.CreateDirectory(V3LauncherConstants.WTDESaveBackupsDir);
            }

            GetSaveBackups();
            UpdateButtonStatus();
        }

        public void GetSaveBackups() {
            SaveBackupsList.Items.Clear();

            var saveBackupFiles = Directory.GetFiles(V3LauncherConstants.WTDESaveBackupsDir);
            foreach (var file in saveBackupFiles) {
                SaveBackupsList.Items.Add(Path.GetFileName(file));
            }
            SaveBackupsHeader.Text = $"Save Backups ({saveBackupFiles.Length}):";

            UpdateButtonStatus();
        }

        private void CloseSFMWindow_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BackUpSaveButton_Click(object sender, EventArgs e) {
            File.Copy(V3LauncherConstants.WTDESaveDir, $"{V3LauncherConstants.WTDESaveBackupsDir}/GHWTDE_{DateTime.Now.ToString().Replace(":", "_").Replace("/", "-")}.sav", true);
            GetSaveBackups();
        }

        public void UpdateButtonStatus() {
            bool filesSelected = (SaveBackupsList.SelectedItems.Count > 0);

            DeleteSelectedBackup.Enabled = filesSelected;
            LoadSelectedBackup.Enabled = filesSelected;
        }

        private void SaveBackupsList_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateButtonStatus();
        }

        private void ReplaceSaveButton_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Save File to Replace With";
            ofd.Filter = "GHWT: DE Save Files|*.sav";

            ofd.ShowDialog();

            if (ofd.FileName != "") {
                string replaceSaveWarning = $"You've chosen to replace your save file with the following save file:\n\n{ofd.FileName}\n\n" +
                                             "Are you sure you want to do this? This cannot be undone!";

                if (MessageBox.Show(replaceSaveWarning, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    try {
                        File.Delete(V3LauncherConstants.WTDESaveDir);
                        File.Copy(ofd.FileName, V3LauncherConstants.WTDESaveDir);

                        MessageBox.Show("Your save file has been replaced!", "Save Replaced", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception exc) {
                        MessageBox.Show($"An error occurred copying the save file:\n\n{exc.Message}", "Replace Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void OpenBackupFolder_Click(object sender, EventArgs e) {
            Process.Start("explorer.exe", Path.GetFullPath(V3LauncherConstants.WTDESaveBackupsDir));
        }

        private void DeleteSelectedBackup_Click(object sender, EventArgs e) {
            if (SaveBackupsList.SelectedItems.Count > 0) {
                string deleteBackupWarning = "Are you sure you want to delete this backup? This cannot be undone!";

                if (MessageBox.Show(deleteBackupWarning, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    File.Delete($"{V3LauncherConstants.WTDESaveBackupsDir}/{SaveBackupsList.SelectedItems[0].ToString()}");

                    MessageBox.Show("Save backup was deleted.", "Deleted Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            GetSaveBackups();
        }

        private void LoadSelectedBackup_Click(object sender, EventArgs e) {
            if (SaveBackupsList.SelectedItems.Count > 0) {
                string replaceSaveWarning = $"You've chosen to replace your save file with the following save file backup:\n\n{SaveBackupsList.SelectedItems[0].ToString()}\n\n" +
                                             "Are you sure you want to do this? This cannot be undone!";

                if (MessageBox.Show(replaceSaveWarning, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    try {
                        File.Delete(V3LauncherConstants.WTDESaveDir);
                        File.Copy($"{V3LauncherConstants.WTDESaveBackupsDir}/{SaveBackupsList.SelectedItems[0].ToString()}", V3LauncherConstants.WTDESaveDir);

                        MessageBox.Show("Your save file has been replaced!", "Save Replaced", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception exc) {
                        MessageBox.Show($"An error occurred copying the save file:\n\n{exc.Message}", "Replace Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void RefreshBackups_Click(object sender, EventArgs e) {
            GetSaveBackups();
        }
    }
}
