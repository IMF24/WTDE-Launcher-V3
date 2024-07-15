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
            // Are the dev settings failed?
            bool isEnabled = V3LauncherCore.EnableDeveloperSettings;

            // -- FILE MENU
            analyzeDebugLogToolStripMenuItem.Visible = isEnabled;
            analyzeDebugLogToolStripMenuItem.Enabled = isEnabled;
            // -----------------------------
            qBScriptEditorToolStripMenuItem.Visible = isEnabled;
            qBScriptEditorToolStripMenuItem.Enabled = isEnabled;
            // -----------------------------
            managePluginsToolStripMenuItem.Visible = isEnabled;
            managePluginsToolStripMenuItem.Enabled = isEnabled;

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

            // We want to inject our user editors here!
            // First off, does the directory we need exist?
            string managersDir = "./launcher_managers";

            // If not, just hide the menu and return.
            if (!Directory.Exists(managersDir)) {
                V3LauncherCore.AddDebugEntry("No editors to register", "Mod Manager");
                UserEditorsMenu.Enabled = false;
                UserEditorsMenu.Visible = false;
                return;
            }

            // - - - - - - - - - - - - - - - - - - - - - - - - - -

            V3LauncherCore.AddDebugEntry("Checking for editor config files...", "Mod Manager");

            // All right, the directory existed, cool!

            // The first thing we want to do is get all INI files in the
            // directory with the launcher managers in it.
            string[] iniFiles = Directory.GetFiles(managersDir, "*manager.ini", SearchOption.AllDirectories);

            // If this array was empty, just return.
            if (iniFiles.Length <= 0) {
                V3LauncherCore.AddDebugEntry("No INI files were found in the managers directory", "Mod Manager");
                UserEditorsMenu.Enabled = false;
                UserEditorsMenu.Visible = false;
                return;
            }

            // OK, safe! Now go through each one!
            // We want to read their data and create our menu items based
            // on the content within them.

            V3LauncherCore.AddDebugEntry("Parsing configs and creating menu commands...", "Mod Manager");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            ToolStripMenuItem[] menuCommands = new ToolStripMenuItem[iniFiles.Length];
            BinaryExecutables.Clear();
            UserEditorsMenu.DropDownItems.Clear();

            for (var i = 0; i < iniFiles.Length; i++) {
                // Initialize our menu command we want to edit!
                menuCommands[i] = new ToolStripMenuItem();

                // Read the data from the current INI file!
                // Our hand-made INI class will be really handy for this.
                INI currentIni = new INI(iniFiles[i]);
                string managerFolder = Path.GetDirectoryName(iniFiles[i]);

                string commandName = currentIni.GetString("ManagerInfo", "Name", "Custom Manager");
                string objectName = currentIni.GetString("ManagerInfo", "VariableName", $"userManagerMenuCommand{i}");
                string imagePath = currentIni.GetString("ManagerInfo", "Image");
                string executableName = currentIni.GetString("ManagerInfo", "ProgramFile");

                imagePath = Path.Combine(managerFolder, imagePath);
                executableName = Path.Combine(managerFolder, executableName);

                // --------------------

                // If the executable does not exist, DO NOT FINISH SETTING THIS ONE UP!
                // This is a bad manager setup, and we should not show it.
                // To account for it, we'll simply hide the command.
                // Also set the file to something absurdly long that no one will ever run.
                if (!File.Exists(executableName)) {
                    V3LauncherCore.AddDebugEntry($"ERROR: Executable did NOT exist for manager {iniFiles[i]}.", "Mod Manager");
                    menuCommands[i].Visible = false;
                    menuCommands[i].Enabled = false;
                    BinaryExecutables.Add("./DUMMY_EXECUTABLE_DO_NOT_RUN_THIS_WILL_FAIL_ALWAYS.dummy_file_exe");
                    continue;
                }

                // --------------------

                menuCommands[i].Name = objectName;
                menuCommands[i].Text = commandName;
                menuCommands[i].Click += new EventHandler(UserManagerMenuCommandHandler);

                // --------------------

                // Set the image!
                // If the image path existed, let's make a new Bitmap and
                // assign it to this menu command.
                if (File.Exists(imagePath)) {
                    Bitmap commandImage = new Bitmap(imagePath);
                    menuCommands[i].Image = commandImage;
                } else {
                    menuCommands[i].Image = null;
                }

                // --------------------

                // Inject the executable name!
                BinaryExecutables.Add(executableName);

                // --------------------

                string newManagerInfo = $"ID {i}: New custom editor added:\nName: {commandName}\nObject reference: {objectName}\nEXE file: {executableName}\nImage file: {imagePath}";
                V3LauncherCore.AddDebugEntry(newManagerInfo, "Mod Manager");

            }

            // At the end of the loop, set our commands for the menu!
            UserEditorsMenu.DropDownItems.AddRange(menuCommands);

            stopwatch.Stop();
            V3LauncherCore.AddDebugEntry($"All custom managers configured! Took {stopwatch.Elapsed.TotalSeconds:0.00} seconds");
        }

        /// <summary>
        ///  List of binary exectuable files that will be run based on the selected command index.
        /// </summary>
        public List<string> BinaryExecutables = new List<string>();

        /// <summary>
        ///  Event handler method for the User Custom Editors menu commands. The starting file for the V3 launcher's execution. We start here!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserManagerMenuCommandHandler(object sender, EventArgs e) {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem) sender;

            int idxOfCommand = UserEditorsMenu.DropDownItems.IndexOf(clickedItem);

            if (idxOfCommand < 0 || idxOfCommand >= UserEditorsMenu.DropDownItems.Count) return;

            string fileToRun = BinaryExecutables[idxOfCommand];
            if (!File.Exists(fileToRun)) return;

            Process.Start("cmd.exe", $"/C start ./{fileToRun}");
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Populates the Script Mod Editors menu!
        /// </summary>
        public void PopulateScriptModMenu() {
            // Enable script mod editors if we have any valid ones.
            IEnumerable<string> scriptModQuery =
                from mod in ModHandler.UserContentMods
                where mod[2] == "Script"
                select mod[5];
            List<string> scriptMods = scriptModQuery.ToList();

            V3LauncherCore.AddDebugEntry($"Read script mods; found a total of {scriptMods.Count} mods", "Mod Manager");

            // Disable all editors by default.
            starPowerColorModifierToolStripMenuItem.Visible = false;
            extendedHyperspeedToolStripMenuItem.Visible = false;

            if (scriptMods.Count > 0) {
                foreach (string mod in scriptMods) {
                    if (mod.Contains("StarPowerModifier")) {
                        V3LauncherCore.AddDebugEntry("Found SP modifier script, enabling SP color modifier dialog", "Mod Manager");
                        starPowerColorModifierToolStripMenuItem.Visible = true;
                    }

                    if (mod.Contains("ExtendedHyperspeed")) {
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
            UserContentModsTree.Items.Clear();
            StatusLabelMain.Text = "Refreshing mods list...";

            Application.DoEvents();

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

            PopulateScriptModMenu();
            RegisterUserEditors();

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
