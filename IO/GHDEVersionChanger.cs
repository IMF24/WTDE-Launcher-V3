// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       W T D E       V E R S I O N       C H A N G E R
//
//    User dialog to change the installed version of GHWT: DE.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;

using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace WTDE_Launcher_V3.IO {
    /// <summary>
    ///  User dialog to change the installed version of GHWT: DE.
    /// </summary>
    public partial class GHDEVersionChanger : Form {
        /// <summary>
        ///  User dialog to change the installed version of GHWT: DE.
        /// </summary>
        public GHDEVersionChanger() {
            InitializeComponent();

            DELatestVersionLabel.Text = DELatestVersionLabel.Text.Replace("VABC", V3LauncherCore.GetLatestVersion());
            VersionInfoList.Items.Clear();
            ChangeVersionButton.Enabled = false;

            foreach (string[] version in WTDEVersionHistory.WTDEVersionInfo) {
                var newItem = new ListViewItem(version);
                VersionInfoList.Items.Add(newItem);
            }
        }

        /// <summary>
        ///  Start changing our WTDE version to a different one!
        /// </summary>
        public void BeginDEChangeVersion(string newVersion, string versionDate, string hashListURL) {
            if (newVersion == null || versionDate == null) return;

            string askChangeVersionMsg = "You have selected to change your WTDE version to the following version:\n\n" +
                                        $"{newVersion} - {versionDate}\n\n" +
                                         "NOTE: If you move to an older version, you are ineligible for support until you return to the current version.\n" +
                                         "We do not offer support for older versions of the mod.\n\n" +
                                         "Are you sure you want to change versions?";

            bool doChange = (MessageBox.Show(askChangeVersionMsg, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);
        
            // Begin changing versions if we asked to!
            if (doChange) {
                InstantiateUpdate(hashListURL);
            }
        }

        /// <summary>
        ///  Begins an update!
        /// </summary>
        /// <param name="url">
        ///  URL to the hash list.
        /// </param>
        public void InstantiateUpdate(string url) {
            // Open our Updater.ini file, change some stuff with it.
            INI updaterConfig = new INI("Updater.ini");
            updaterConfig.SetString("Updater", "HashListURL", url);
            if (!File.Exists("WTDE-Updater-V2.exe")) {
                V3LauncherCore.CheckForUpdates();
            }
            Process.Start("WTDE-Updater-V2.exe");
            Environment.Exit(0);
        }

        /// <summary>
        ///  Updates control usability.
        /// </summary>
        public void UpdateControlStatus() {
            bool shouldEnable = !(VersionInfoList.SelectedItems.Count <= 0);

            ChangeVersionButton.Enabled = shouldEnable;
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        private void ChangeVersionButton_Click(object sender, EventArgs e) {
            var item = VersionInfoList.SelectedItems[0];
            string newVer = item.SubItems[0].Text;
            string verDate = item.SubItems[1].Text;
            string buildURL = item.SubItems[2].Text;
            BeginDEChangeVersion(newVer, verDate, buildURL);
        }

        private void VersionInfoList_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateControlStatus();
        }

        private void RevertVersionButton_Click(object sender, EventArgs e) {
            InstantiateUpdate(V3LauncherConstants.WTDEHashList);
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
