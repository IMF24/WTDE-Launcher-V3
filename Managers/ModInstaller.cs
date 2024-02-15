// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       M O D       I N S T A L L E R
//
//    The Mod Manager's mod installer, allowing the user to very easily install
//    new mods for their WTDE installation.
// ----------------------------------------------------------------------------
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
using System.IO.Compression;
using Aspose.Zip.Saving;
using SharpCompress.Archives.SevenZip;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Rar;

namespace WTDE_Launcher_V3 {
    public partial class ModInstaller : Form {
        public ModInstaller() {
            InitializeComponent();

            InstallProgressInfo.Text = "";

            InstallerBGWorker.RunWorkerAsync();
        }

        private void AddModArchives_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Mods in Archive Format (ZIP/7Z/RAR)";
            ofd.Filter = "Archive Mods|*.zip;*.7z;*.rar";
            ofd.Multiselect = true;

            ofd.ShowDialog();

            if (ofd.FileNames.Length > 0) {
                foreach (var file in ofd.FileNames) {
                    ModQueueList.Items.Add(file);
                }
            }

            InstallerBGWorker.RunWorkerAsync();
        }

        private void ClearModQueue_Click(object sender, EventArgs e) {
            if (ModQueueList.Items.Count > 0) {
                string clearModListWarning = "Are you sure you want to clear the install queue?";

                if (MessageBox.Show(clearModListWarning, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    ModQueueList.Items.Clear();
                }
            }

            InstallerBGWorker.RunWorkerAsync();
        }

        private void InstallerBGWorker_DoWork(object sender, DoWorkEventArgs e) {
            if (ModQueueList.Items.Count > 0) {
                ClearModQueue.Enabled = true;
                ExecuteInstall.Enabled = true;

                this.Text = $"Mod Manager: Mod Installer: {ModQueueList.Items.Count} Mod(s) Pending";
            } else {
                ClearModQueue.Enabled = false;
                ExecuteInstall.Enabled = false;

                this.Text = "Mod Manager: Mod Installer";
            }

            ExecuteInstallSelectedOnly.Enabled = (ModQueueList.SelectedItems.Count > 0);
        }

        private void ModQueueList_SelectedIndexChanged(object sender, EventArgs e) {
            InstallerBGWorker.RunWorkerAsync();
        }

        private void ExecuteInstallSelectedOnly_Click(object sender, EventArgs e) {
            var selectedMods = ModQueueList.SelectedItems;

            var owd = Directory.GetCurrentDirectory();

            // Get the working directory in Updater.ini.
            ModHandler.UseUpdaterINIDirectory();

            foreach (var selectedMod in selectedMods) {
                var lastFolderName = Path.GetFileNameWithoutExtension(selectedMod.ToString().TrimEnd(Path.DirectorySeparatorChar));

                switch (Path.GetExtension(selectedMod.ToString())) {
                    // ZIP archive
                    case ".zip":
                        ZipFile.ExtractToDirectory(selectedMod.ToString(), $"./DATA/MODS/{lastFolderName}");
                        break;

                    // 7Zip Archive
                    case ".7z":
                        using (Aspose.Zip.SevenZip.SevenZipArchive szr = new Aspose.Zip.SevenZip.SevenZipArchive()) {
                            szr.ExtractToDirectory(selectedMod.ToString(), $"./DATA/MODS/{lastFolderName}");
                        }
                        break;

                    // WinRAR archive
                    case ".rar":
                        RarArchive rar = new RarArchive(selectedMod.ToString());
                        rar.ExtractToDirectory($"./DATA/MODS/{lastFolderName}");
                        break;
                }

                ModQueueList.Items.Remove(selectedMod);
            }

            // Reset working directory.
            Directory.SetCurrentDirectory(owd);
        }

        private void ExecuteInstall_Click(object sender, EventArgs e) {
            // Get the working directory in Updater.ini.
            var owd = Directory.GetCurrentDirectory();
            ModHandler.UseUpdaterINIDirectory();

            decimal modsInstalled = 0;
            decimal modsToInstall = ModQueueList.Items.Count;
            TotalInstallProgress.Maximum = (int) modsToInstall;

            // Now let's install each mod!
            foreach (var modPath in ModQueueList.Items) {
                var path = modPath.ToString();

                var lastFolderName = Path.GetFileNameWithoutExtension(path.TrimEnd(Path.DirectorySeparatorChar));

                InstallProgressInfo.Text = $"Installing Mod: {path}";

                Application.DoEvents();

                if (Directory.Exists($"./DATA/MODS/{lastFolderName}")) {
                    Directory.Delete($"./DATA/MODS/{lastFolderName}", true);
                }

                switch (Path.GetExtension(path)) {
                    // ZIP archive
                    case ".zip":
                        ZipFile.ExtractToDirectory(path, $"./DATA/MODS/{lastFolderName}");
                        break;

                    // 7Zip Archive
                    case ".7z":
                        var szr = SharpCompress.Archives.SevenZip.SevenZipArchive.Open(path);

                        if (!Directory.Exists($"./DATA/MODS/{lastFolderName}")) Directory.CreateDirectory($"./DATA/MODS/{lastFolderName}");
                        Directory.SetCurrentDirectory($"./DATA/MODS/{lastFolderName}");

                        szr.ExtractAllEntries();

                        Directory.SetCurrentDirectory("../../..");
                        break;

                    // WinRAR archive
                    case ".rar":
                        RarArchive rar = new RarArchive(path);
                        rar.ExtractToDirectory($"./DATA/MODS/{lastFolderName}");
                        break;
                }

                modsInstalled++;

                TotalInstallProgress.Value++;

                decimal installProgress = (modsInstalled / modsToInstall) * 100;

                ModInstallProgress.Text = $"{(int) installProgress}%";

                Application.DoEvents();
            }
            ModQueueList.Items.Clear();

            // Reset working directory.
            Directory.SetCurrentDirectory(owd);

            MessageBox.Show("All mods have been installed successfully!", "Install Complete!", MessageBoxButtons.OK);

            InstallProgressInfo.Text = "";
            TotalInstallProgress.Value = 0;
            ModInstallProgress.Text = "0%";

            InstallerBGWorker.RunWorkerAsync();
        }
    }
}
