// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       M O D       M A N A G E R
//
//    The Mod Manager, meant for the user to manage their mods with a
//    relatively user-friendly dialog.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;
using WTDE_Launcher_V3.IO;
using WTDE_Launcher_V3.Managers.ModTypes;
using WTDE_Launcher_V3.Managers.ScriptMods;

using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WTDE_Launcher_V3.Managers {
    /// <summary>
    ///  The Mod Manager, meant for the user to manage their mods with a relatively user-friendly dialog.
    /// </summary>
    public partial class ModManager : Form {
        /// <summary>
        ///  The Mod Manager, meant for the user to manage their mods with a relatively user-friendly dialog.
        /// </summary>
        public ModManager() {
            InitializeComponent();

            RPCHandler.SetRPCLargeImage(
                "https://raw.githubusercontent.com/IMF24/WTDE-Launcher-V3/master/res/img/icon/mod_manager.png",
                $"GHWT: Definitive Edition Launcher - V{V3LauncherConstants.VERSION} - Mod Manager"
            );
            RPCHandler.SetRPCDetails("Managing some mods");

            this.Text = $"GHWT: Definitive Edition Launcher - V{V3LauncherConstants.VERSION} - Mod Manager";
            if (V3LauncherCore.EnableDeveloperSettings) this.Text += " | Dev. Settings Enabled";

            // Populate the mod list.
            foreach (string[] mod in ModHandler.UserContentMods) {
                var listViewItem = new ListViewItem(mod);
                UserContentModsTree.Items.Add(listViewItem);
            }

            PopulateScriptModMenu();
            RegisterUserEditors();
            EnableDevSettingsItems();

            XMLFunctions.ReturningFromDialog = true;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  What mod is selected? This property holds that mod's config file path.
        /// </summary>
        public string SelectedModConfig = "";

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Enables various other stuff in the Mod Manager if the dev settings file is present.
        /// </summary>
        public void EnableDevSettingsItems() {
            // Are the dev settings enabled?
            bool isEnabled = V3LauncherCore.EnableDeveloperSettings;

            // - - - - - - - - - - - - -

            // -- FILE MENU
            //~ analyzeDebugLogToolStripMenuItem.Visible = isEnabled;
            //~ analyzeDebugLogToolStripMenuItem.Enabled = isEnabled;
            // -----------------------------
            qBScriptEditorToolStripMenuItem.Visible = isEnabled;
            qBScriptEditorToolStripMenuItem.Enabled = isEnabled;
            // -----------------------------
            managePluginsToolStripMenuItem.Visible = isEnabled;
            managePluginsToolStripMenuItem.Enabled = isEnabled;

            // - - - - - - - - - - - - -

            // -- SCRIPT MOD EDITORS MENU
            modifyAndCreateBandLineupsToolStripMenuItem.Visible = isEnabled;
            modifyAndCreateBandLineupsToolStripMenuItem.Enabled = isEnabled;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Register any user-made editors with the Mod Manager!
        /// </summary>
        public void RegisterUserEditors() {
            V3LauncherCore.AddDebugEntry("Registering user custom editors...", "Mod Manager");

            // Clear out our menu!
            UserEditorsMenu.DropDownItems.Clear();

            // Begin the stopwatch!
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Get the manager.ini files, if we have any.
            string[] managerINIFiles = Directory.GetFiles(V3LauncherConstants.UserEditorsFolderDir, "*manager.ini", SearchOption.AllDirectories);

            // Do we have items to iterate over?
            List<string[]> badEditorPaths = new List<string[]>();
            if (managerINIFiles.Length > 0) {
                foreach (string iniFile in managerINIFiles) {
                    // Get the FOLDER name of the manager.
                    string iniFileFolder = Path.GetDirectoryName(iniFile);
                    try {
                        // Make our user custom editor and turn it into a menu command!
                        UserCustomEditor newEditor = new UserCustomEditor(iniFileFolder);
                        ToolStripMenuItem userEditorItem = newEditor.BuildMenuCommand();
                        
                        // Add it to the menu!
                        UserEditorsMenu.DropDownItems.Add(userEditorItem);
                    } catch (Exception exc) {
                        V3LauncherCore.AddDebugEntry($"Error registering manager: {exc.Message}", "Mod Manager");
                        badEditorPaths.Add(new string[] { iniFileFolder, exc.Message });
                    }
                }
            } else {
                V3LauncherCore.AddDebugEntry("No editors to register", "Mod Manager");
            }

            // And stop the stopwatch here!
            watch.Stop();
            V3LauncherCore.AddDebugEntry($"All done! Parsed {managerINIFiles.Length} managers in {watch.Elapsed.TotalSeconds:0.00} sec");

            // If there's bad managers, display an error message!
            if (badEditorPaths.Count > 0) {
                string errorMessage = "We detected some errors in the configuration of some user custom editors.\n\nThe details are below:\n\n";

                foreach (string[] badEditorData in badEditorPaths) {
                    string thisEditorData = $"- Path: {badEditorData[0]}\n" +
                                            $"- Error: {badEditorData[1]}\n\n";
                    errorMessage += thisEditorData;
                }

                MessageBox.Show(errorMessage, "User Custom Editor Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Update menu visiblity!
            UserEditorsMenu.Visible = (managerINIFiles.Length > 0) && (UserEditorsMenu.DropDownItems.Count > 0);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Populates the Script Mod Editors menu!
        /// </summary>
        public void PopulateScriptModMenu() {
            // Enable script mod editors if we have any valid ones.
            List<string[]> scriptMods = ModHandler.GetModsByType(ModHandler.ModTypes.Script);

            V3LauncherCore.AddDebugEntry($"Read script mods; found a total of {scriptMods.Count} mods", "Mod Manager");

            // Disable all editors by default.
            starPowerColorModifierToolStripMenuItem.Visible = false;
            extendedHyperspeedToolStripMenuItem.Visible = false;

            if (scriptMods.Count > 0) {
                foreach (string[] mod in scriptMods) {
                    if (mod[5].Contains("StarPowerModifier")) {
                        V3LauncherCore.AddDebugEntry("Found SP modifier script, enabling SP color modifier dialog", "Mod Manager");
                        starPowerColorModifierToolStripMenuItem.Visible = true;
                    }

                    if (mod[5].Contains("ExtendedHyperspeed")) {
                        V3LauncherCore.AddDebugEntry("Found extended hyperspeed script, enabling extended hyperspeed dialog", "Mod Manager");
                        extendedHyperspeedToolStripMenuItem.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        ///  Refresh the mods list!
        /// </summary>
        /// <param name="filterMods">
        ///  Do we want to filter mods?
        /// </param>
        /// <param name="filterType">
        ///  The mod type string to filter by.
        /// </param>
        public void RefreshModsList(bool filterMods = false, string filterType = "Any") {
            // Clear the Mod Manager listing, update the status bar.
            UserContentModsTree.Items.Clear();
            StatusLabelMain.Text = "Refreshing mods list...";

            // Update idle tasks, just in case.
            Application.DoEvents();

            // Are we able to populate the Mod Manager?
            INI deConfig = new INI(V3LauncherConstants.WTDEConfigDir);
            bool shouldPopulate = deConfig.GetInt("Launcher", "PopulateModManager", 1) == 1;

            // Yes we can, so let's do it!
            if (shouldPopulate) { 
                ModHandler.ReadMods();

                // Just list the items!
                if (!filterMods) {
                    foreach (string[] mod in ModHandler.UserContentMods) {
                        var listViewItem = new ListViewItem(mod);
                        UserContentModsTree.Items.Add(listViewItem);
                    }

                // If we made it here, DO NOT just normally list them!
                // We want to filter them first, so let's do that!
                } else {
                    foreach (string[] mod in ModHandler.UserContentMods) { 
                        if (mod[2].ToLower() == filterType.ToLower()) {
                            var listViewItem = new ListViewItem(mod);
                            UserContentModsTree.Items.Add(listViewItem);
                        }
                    }
                }
            }
            
            // Re-register script mod menu items and user editors!
            PopulateScriptModMenu();
            RegisterUserEditors();

            // Update idle tasks again, once again, just in case.
            Application.DoEvents();

            // Update status bar text.
            StatusLabelMain.Text = $"All done; scanned {ModHandler.UserContentMods.Count} valid mods, {UserContentModsTree.Items.Count} matching current filter(s)";
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

        public void OpenSelectedModConfig() {
            if (UserContentModsTree.SelectedItems.Count <= 0) return;

            string modType = UserContentModsTree.SelectedItems[0].SubItems[2].Text;
            string iniPath = this.SelectedModConfig;

            // WIP, return to this later
            /*
            switch (modType) {
                case "Character":
                    CharacterModEditor cme = new CharacterModEditor(iniPath);
                    cme.ShowDialog();
                    break;

                default:
                    Process.Start("notepad.exe", iniPath);
                    break;
            }
            */
            Process.Start("notepad.exe", iniPath);
        }

        private void openSelectedModConfigToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenSelectedModConfig();
        }

        private void openSelectedModConfigToolStripMenuItem1_Click(object sender, EventArgs e) {
            OpenSelectedModConfig();
        }

        private void openSelectedModFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                V3LauncherCore.AddDebugEntry($"Length of selected mod config path: {SelectedModConfig.Length}", "Mod Manager");
                Process.Start("explorer.exe", Path.GetDirectoryName(this.SelectedModConfig));
            } catch {
                return;
            }
        }

        private void openSelectedModFolderToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                V3LauncherCore.AddDebugEntry($"Length of selected mod config path: {SelectedModConfig.Length}", "Mod Manager");
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

        private void starPowerColorModifierToolStripMenuItem_Click(object sender, EventArgs e) {
            StarPowerModifierManager spmm = new StarPowerModifierManager();
            spmm.ShowDialog();
        }

        private void extendedHyperspeedToolStripMenuItem_Click(object sender, EventArgs e) {
            ExtendedHyperspeedManager ehm = new ExtendedHyperspeedManager();
            ehm.ShowDialog();
        }

        private void gemThemeDesignerToolStripMenuItem_Click(object sender, EventArgs e) {
            GemThemeCreator gtc = new GemThemeCreator();
            gtc.ShowDialog();
        }

        private void assignGH3SPFXToCharacterModToolStripMenuItem_Click(object sender, EventArgs e) {
            AddGH3StarPowerFX gh3SPFX = new AddGH3StarPowerFX();
            gh3SPFX.ShowDialog();
        }

        private void modifyAndCreateBandLineupsToolStripMenuItem_Click(object sender, EventArgs e) {
            ModifyCustomBands mcb = new ModifyCustomBands();
            mcb.ShowDialog();
        }

        private void analyzeDebugLogToolStripMenuItem_Click(object sender, EventArgs e) {
            DebugLogAnalyzer dla = new DebugLogAnalyzer();
            dla.ShowDialog();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - -
        // MOD LISTING FILTERS
        // - - - - - - - - - - - - - - - - - - - - - - - -

        private void songModsToolStripMenuItem_Click(object sender, EventArgs e) {
            RefreshModsList(true, "Song");
        }

        private void songCategoryModsToolStripMenuItem_Click(object sender, EventArgs e) {
            RefreshModsList(true, "Song Category");
        }

        private void characterModsToolStripMenuItem_Click(object sender, EventArgs e) {
            RefreshModsList(true, "Character");
        }

        private void highwayModsToolStripMenuItem_Click(object sender, EventArgs e) {
            RefreshModsList(true, "Highway");
        }

        private void instrumentModsToolStripMenuItem_Click(object sender, EventArgs e) {
            RefreshModsList(true, "Instrument");
        }

        private void mainMenuMusicModsToolStripMenuItem_Click(object sender, EventArgs e) {
            RefreshModsList(true, "Menu Music");
        }

        private void gemThemeModsToolStripMenuItem_Click(object sender, EventArgs e) {
            RefreshModsList(true, "Gem Theme");
        }

        private void venueModsToolStripMenuItem_Click(object sender, EventArgs e) {
            RefreshModsList(true, "Venue");
        }

        private void scriptModsToolStripMenuItem_Click(object sender, EventArgs e) {
            RefreshModsList(true, "Script");
        }
        
        // -------------------

        private void noFilterToolStripMenuItem_Click(object sender, EventArgs e) {
            RefreshModsList();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - -

        private void iNIAndXMLEditorToolStripMenuItem_Click(object sender, EventArgs e) {
            DEConfigFilesEditor defc = new DEConfigFilesEditor();
            defc.ShowDialog();
        }

        private void qBScriptEditorToolStripMenuItem_Click(object sender, EventArgs e) {
            QBScriptEditor qbse = new QBScriptEditor();
            qbse.ShowDialog();
        }

        private void managePluginsToolStripMenuItem_Click(object sender, EventArgs e) {
            ModManagerPluginManager mmpm = new ModManagerPluginManager();
            mmpm.ShowDialog();

            RegisterUserEditors();
        }

        private void wTDEDiscordServerToolStripMenuItem_Click(object sender, EventArgs e) {
            V3LauncherCore.OpenSiteURL("https://discord.gg/HVECPzkV4u");
        }

        private void iMFsGitHubToolStripMenuItem_Click(object sender, EventArgs e) {
            V3LauncherCore.OpenSiteURL("https://github.com/IMF24");
        }
    }
}
