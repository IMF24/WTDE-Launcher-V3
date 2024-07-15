// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       M O D       M A N A G E R       P L U G I N       M A N A G E R
//
//    The Mod Manager's plugin manager, allowing the user to install various
//    plugins into the Mod Manager.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;
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
using System.Dynamic;

namespace WTDE_Launcher_V3.Managers {
    /// <summary>
    ///  The Mod Manager's plugin manager, allowing the user to install various 
    ///  plugins into the Mod Manager.
    /// </summary>
    public partial class ModManagerPluginManager : Form {
        public ModManagerPluginManager() {
            InitializeComponent();

            // Get our installed plugins!
            GetInstalledPlugins();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Get the user's installed plugins and display them!
        /// </summary>
        public void GetInstalledPlugins() {
            // Reset all data!
            PluginName.Text = "";
            PluginAuthor.Text = "";
            PluginVersion.Text = "";
            PluginHelp.Text = "";
            PluginHelp.ReadOnly = true;
            PluginData.Clear();
            PluginParameters.Clear();
            PluginsList.Items.Clear();
            PluginParametersList.Clear();

            // ----------------

            // Iterate through the plugins folder and add our plugin entries
            // to the ListView control.

            // Get our manager INI files!
            string[] iniFiles = Directory.GetFiles("./launcher_managers", "*manager.ini", SearchOption.AllDirectories);
            foreach (string file in iniFiles) {
                // Make an INI file reader/writer class!
                // Our own INI file class will be pretty handy for this.
                INI iniFile = new INI(file);

                // Get the info from the plugin info section!
                string pluginName = iniFile.GetString("PluginInfo", "Name", "Unknown Title");
                string pluginDesc = iniFile.GetString("PluginInfo", "Description", "A custom plugin. Does something cool!");
                string pluginAuthor = iniFile.GetString("PluginInfo", "Author", "Unknown Author");
                string pluginVersion = iniFile.GetString("PluginInfo", "Version", "1.0");

                // Get the path of the plugin folder!
                string pluginDir = Path.GetDirectoryName(file);

                // ----------------

                // DEBUG: This is a dummy status, we'll make this operational later.
                string pluginStatus = "ON";

                // ----------------

                // Make the entry in the plugins list!
                string[] newData = new string[] { pluginName, pluginAuthor, pluginDesc, pluginDir, pluginStatus };
                PluginsList.Items.Add(new ListViewItem(newData));

                // ----------------

                // So we've done the plugin display data in the installed plugins list. Cool!
                // Now we need to actually get the data that will be shown
                // to the end user when they click on a specific plugin.

                // -- PLUGIN NAME
                string actualName = iniFile.GetString("ManagerInfo", "Name", "");

                // -- PLUGIN HELP
                string helpFileDir = iniFile.GetString("ManagerInfo", "HelpFileDir");
                string helpFileText = (File.Exists(helpFileDir)) ? File.ReadAllText(helpFileDir) : "No help file was provided.";

                // -- DATA TO GO IN MEMORY
                List<string> newPluginData = new List<string> { actualName, pluginAuthor, pluginVersion, helpFileText };
                PluginData.Add(newPluginData);

                // ----------------

                // -- PARAMETERS
                // DEBUG: Just put a dummy array in.
                string[][] newParams = new string[][] { new string[] { "Test Parameter", "Test Value" } };
                PluginParameters.Add(newParams);

            }

        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  The plugin data itself that will be shown in the loaded info.
        /// </summary>
        public List<List<string>> PluginData = new List<List<string>>();

        /// <summary>
        ///  The plugin parameters themselves.
        /// </summary>
        public List<string[][]> PluginParameters = new List<string[][]>();

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Load the selected plugin's data into view!
        /// </summary>
        public void LoadPluginData() {
            try {
                // -- GET SELECTED INDEX
                int idx = PluginsList.SelectedItems[0].Index;
                if (idx < 0 || idx >= PluginsList.Items.Count) return;

                PluginParametersList.Items.Clear();

                // -- SET PLUGIN DATA
                PluginName.Text = PluginData[idx][0];
                PluginAuthor.Text = PluginData[idx][1];
                PluginVersion.Text = PluginData[idx][2];

                // -- SET PLUGIN HELP
                PluginHelp.ReadOnly = false;
                PluginHelp.Text = PluginData[idx][3];
                PluginHelp.ReadOnly = true;

                // Load parameters.
                foreach (string[] param in PluginParameters[idx]) {
                    V3LauncherCore.AddDebugEntry($"Number of items in param: {param.Length}", "Mod Manager: Plugin Manager");
                    var newItem = new ListViewItem(new string[] { param[0], param[1] });
                    PluginParametersList.Items.Add(newItem);
                }

                Application.DoEvents();

                V3LauncherCore.AddDebugEntry($"Plugin parameters count: {PluginParametersList.Items.Count}", "Mod Manager: Plugin Manager");
            } catch (Exception exc) {
                V3LauncherCore.AddDebugEntry($"Error loading plugin data: {exc.Message}", "Mod Manager: Plugin Manager");
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        private void PluginsList_SelectedIndexChanged(object sender, EventArgs e) {
            LoadPluginData();
        }

    }
}
