﻿// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       S C R I P T       M O D       E D I T O R S
//          G H 3       S T A R       P O W E R       E F F E C T S
//
//    Adds Star Power particles from Guitar Hero III onto character mods.
//    Requires GHSDK to use properly.
// ----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Launcher_V3 {
    /// <summary>
    ///  Adds Star Power particles from Guitar Hero III onto character mods.
    ///  Requires GHSDK to use properly.
    /// </summary>
    public partial class AddGH3StarPowerFX : Form {
        /// <summary>
        ///  Adds Star Power particles from Guitar Hero III onto character mods.
        ///  Requires GHSDK to use properly.
        /// </summary>
        public AddGH3StarPowerFX() {
            InitializeComponent();
            SDKPath.Text = GetSDKPath();
            StarPowerFXList.SelectedIndex = 0;

            CharModMemory.Text = "";

            UpdateButtonStatus();
        }

        public List<string> CharacterModNames = new List<string>();

        public List<string> CharacterModSPFX = new List<string>();

        public string[] StarPowerFXNames = new string[] {
            "Tesla Lightning (Default)", "Anarchy", "Hearts", "Peace", "Butterflies", "Bats"
        };

        public string[] StarPowerFX = new string[] {
            "standard", "flamethrower", "hearts", "peace", "butterflies", "bat"
        };

        public string GetSDKPath() {
            string sdkPath = INIFunctions.GetINIValue("Launcher", "SDKPath", ".");

            if (File.Exists(Path.Combine(sdkPath, "sdk.js"))) return sdkPath;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Guitar Hero SDK Folder";
            ofd.Filter = "Guitar Hero SDK Script|*sdk.js;*sdk.bat";
            ofd.Multiselect = false;
            ofd.ShowDialog();

            string finalPath = ofd.FileName;
            if (finalPath != "") {
                finalPath = Path.GetDirectoryName(ofd.FileName);
                INIFunctions.SaveINIValue("Launcher", "SDKPath", finalPath);
            }

            return (finalPath != "") ? finalPath : ".";
        }

        public void AddScriptModToWTDE() {
            string wtdeDir = V3LauncherCore.GetUpdaterINIDirectory();
            string outModFolderDir = $"{wtdeDir}/DATA/MODS/AddGH3CharacterModSPFX";

            CompileScript();

            using (StreamWriter sw = new StreamWriter($"{outModFolderDir}/Mod.ini")) {
                sw.Write("[ModInfo]\n" +
                         "Name=Add GH3 Star Power FX\n" +
                         "Description=Adds Guitar Hero III Star Power particles onto modded characters. (generated by V3 WTDE Launcher)\n" +
                         "Author=IMF24, Cobalt\n" +
                         "Version=1.0\n");
            }
        }

        public string MakeScriptMod() {
            string wtdeDir = V3LauncherCore.GetUpdaterINIDirectory();
            string outModDir = $"{wtdeDir}/DATA/MODS/AddGH3CharacterModSPFX/AddGH3CharacterModSPFX.txt";
            string outModFolderDir = $"{wtdeDir}/DATA/MODS/AddGH3CharacterModSPFX";

            if (!Directory.Exists(outModFolderDir)) Directory.CreateDirectory(outModFolderDir);

            using (StreamWriter sw = new StreamWriter(outModDir)) {
                // -- ADD CHARACTER SP FX SCRIPT
                sw.Write("Unknown [GHWT_HEADER]\n\nScript AddCharacterSPFX [\n");
                sw.Write("    :i $printf$ %s(\"Adding GH3 Star Power particles to defined character mods...\")\n");

                for (var i = 0; i < CharacterModNames.Count; i++) {
                    sw.WriteLine($"    :i $API_Set_CharacterValue$ $id$=${NXFunctions.MakeQBKeyFromString(CharacterModNames[i]).Replace("0x", "")}$ $element$=$star_power_effects$ $value$=${CharacterModSPFX[i]}$");
                }

                sw.Write("\n    :i endfunction\n]\n\n");

                // -- ADD SCRIPT CALLBACK (thanks Cobalt)
                sw.Write(
                    "Script AddGH3CharacterModSPFX_Load [\n" +
                    "    :i $API_Add_ScriptCallback$ $type$=$ModsLoaded$ $id$=$AddCharacterSPFX$\n" +
                    "    :i endfunction\n" +
                    "]\n"
                );
            }

            return Path.GetFullPath(outModDir);
        }

        public void CompileScript() {
            // Is this SDK folder even valid?
            string sdkPath = SDKPath.Text;
            if (Directory.Exists(sdkPath) && File.Exists(Path.Combine(sdkPath, "sdk.js"))) {
                // Write the script mod itself!
                string txtROQModPath = MakeScriptMod();

                Console.WriteLine($"ROQ mod path: {txtROQModPath}");

                // Command to be passed to the SDK.
                // Command format: node sdk.js compile <in_path>
                // THIS COMPILES TO THE WORKING DIRECTORY
                string cmd = $"/C node \"{sdkPath}\" compile \"{Path.GetFullPath(txtROQModPath)}\"";
                Process.Start("cmd.exe", cmd);
            }
        }

        public void UpdateButtonStatus() {
            StarPowerFXList.Enabled = (OutputModsList.Items.Count > 0);
            ClearAllDataButton.Enabled = (OutputModsList.Items.Count > 0);
            RemoveCharButton.Enabled = (OutputModsList.Items.Count > 0 && OutputModsList.SelectedItems.Count > 0);

            OKButton.Enabled = (CharacterModNames.Count > 0 && CharacterModSPFX.Count > 0 && CharacterModNames.Count == CharacterModSPFX.Count);
        }

        private void AddCharButton_Click(object sender, EventArgs e) {
            CharModMemory.Text = "";

            SelectCharacterMod scm = new SelectCharacterMod(CharModMemory);
            scm.ShowDialog();

            if (CharModMemory.Text == "") return;

            OutputModsList.Items.Add($"Mod Character: {CharModMemory.Text} | Star Power FX: {StarPowerFXList.Text}");

            CharacterModNames.Add(CharModMemory.Text);
            CharacterModSPFX.Add(StarPowerFX[0]);

            OutputModsList.SelectedIndex = CharacterModNames.Count - 1;
            StarPowerFXList.Text = StarPowerFXList.Items[0].ToString();

            UpdateButtonStatus();
        }

        private void StarPowerFXList_SelectedIndexChanged(object sender, EventArgs e) {
            if (OutputModsList.Items.Count > 0 && OutputModsList.SelectedItems.Count > 0) { 
                int selIndex = OutputModsList.SelectedIndex;

                OutputModsList.Items[selIndex] = $"Mod Character: {CharacterModNames[selIndex]} | Star Power FX: {StarPowerFXList.Text}";

                CharacterModSPFX[selIndex] = INIFunctions.InterpretINISetting(StarPowerFXList.Text, StarPowerFXNames, StarPowerFX);
            }
        }

        private void RemoveCharButton_Click(object sender, EventArgs e) {
            string areYouSureMsg = "Are you sure you want to delete this character from the queue?";

            if (MessageBox.Show(areYouSureMsg, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                int selIndex = OutputModsList.SelectedIndex;

                OutputModsList.Items.RemoveAt(selIndex);
                CharacterModNames.RemoveAt(selIndex);
                CharacterModSPFX.RemoveAt(selIndex);

                StarPowerFXList.Text = "";

                UpdateButtonStatus();
            }
        }

        private void ClearAllDataButton_Click(object sender, EventArgs e) {
            string areYouSureMsg = "Are you sure you want to clear the entire queue?";

            if (MessageBox.Show(areYouSureMsg, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                OutputModsList.Items.Clear();
                CharacterModNames.Clear();
                CharacterModSPFX.Clear();

                StarPowerFXList.Text = "";

                UpdateButtonStatus();
            }
        }

        private void OutputModsList_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateButtonStatus();
        }

        private void SelectSDKPath_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Guitar Hero SDK Folder";
            ofd.Filter = "Guitar Hero SDK Script|*sdk.js;*sdk.bat";
            ofd.Multiselect = false;
            ofd.ShowDialog();

            string finalPath = ofd.FileName;
            if (finalPath != "") {
                finalPath = Path.GetDirectoryName(ofd.FileName);
                INIFunctions.SaveINIValue("Launcher", "SDKPath", finalPath);

                SDKPath.Text = finalPath;
            }
        }

        private void OKButton_Click(object sender, EventArgs e) {
            AddScriptModToWTDE();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}