// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       U S E R       C U S T O M       E D I T O R
//
//    Helper class used by the Mod Manager for registering plugin-like user
//    custom editors for the V3 launcher.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.IO;

// Various other imports.
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WTDE_Launcher_V3.Core {
    /// <summary>
    ///  An object which is a registered user custom editor, used by the Mod Manager.
    /// </summary>
    public class UserCustomEditor {
        /// <summary>
        ///  Construct a new instance of <see cref="UserCustomEditor"/>.
        /// </summary>
        /// <param name="folderPath">
        ///  The path the FOLDER where this manager is.
        /// </param>
        /// <exception cref="FileNotFoundException"/>
        public UserCustomEditor(string folderPath) {
            // Is there a `manager.ini` file in this folder?
            string testForManagerFile = Path.Combine(folderPath, "manager.ini");

            // Make sure it exists!
            if (File.Exists(testForManagerFile)) {

                // It DOES exist, read it!
                INI file = new INI(testForManagerFile);

                // Get the name, description, author, and version of the manager.
                // This info is shown in the Plugin Manager.
                string pluginName = file.GetString("PluginInfo", "Name", "Unknown Plugin");
                string pluginDesc = file.GetString("PluginInfo", "Description", "A user custom editor.");
                string pluginAuthor = file.GetString("PluginInfo", "Author", "Unknown Author");
                string pluginVersion = file.GetString("PluginInfo", "Version", "1.0");

                // Set the member fields!
                Name = pluginName;
                Description = pluginDesc;
                Author = pluginAuthor;
                Version = pluginVersion;

                // -----------------------------------

                // The ACTUAL manager information itself!
                string managerName = file.GetString("ManagerInfo", "Name", "Unknown Manager");
                string managerVarName = file.GetString("ManagerInfo", "VariableName", "NO_VAR_NAME");
                string managerExeLocation = file.GetString("ManagerInfo", "ProgramFile", "./NO_FILE_DEFINED.default_unk");
                string managerImageLocation = file.GetString("ManagerInfo", "Image", "NO_IMAGE_DEFINED");

                // -----------------------------------

                // Now translate it into something usable!
                MenuCommandText = managerName;

                // Make sure we have a valid manager variable name!
                if (managerVarName == "NO_VAR_NAME") {
                    throw new Exception("No menu command variable name was given.");
                }
                string actualVarName = managerVarName.Replace(" ", "");
                MenuVariableName = actualVarName;

                // Get the full executable path.
                string fullExePath = Path.GetFullPath(Path.Combine(folderPath, managerExeLocation));
                if (!File.Exists(fullExePath)) {
                    throw new FileNotFoundException("The provided executable file did not exist.");
                }
                BinaryExecutablePath = fullExePath;

                // Make a new bitmap image!
                string fullImagePath = Path.GetFullPath(Path.Combine(folderPath, managerImageLocation));
                Image actualImage;
                if (!File.Exists(fullImagePath)) {
                    actualImage = null;
                } else {
                    actualImage = new Bitmap(fullImagePath);
                }
                Icon = actualImage;

            // It didn't exist, just throw an exception if that's the case.
            } else throw new FileNotFoundException("The given INI file did not exist.");
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Title of the manager.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Information about this manager.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///  The author of the manager.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        ///  The version of the manager.
        /// </summary>
        public string Version { get; set; }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  The text shown for the menu command.
        /// </summary>
        public string MenuCommandText { get; set; }

        /// <summary>
        ///  The referent name for the menu
        /// </summary>
        public string MenuVariableName { get; set; }

        /// <summary>
        ///  The image for the manager.
        /// </summary>
        public Image Icon { get; set; }

        /// <summary>
        ///  String to the path of the binary executable path.
        /// </summary>
        public string BinaryExecutablePath { get; set; }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Create a usable <see cref="ToolStripMenuItem"/> that can be placed into any type of menu.
        ///  The command is built from the provided data given by the constructor and member fields.
        /// </summary>
        /// <returns>
        ///  A usable <see cref="ToolStripMenuItem"/> which can be placed into 
        /// </returns>
        public ToolStripMenuItem BuildMenuCommand() {
            // The output tool strip menu item!
            ToolStripMenuItem finalMenuItem = new ToolStripMenuItem {
                // Set the variable name, text, and image.
                Name = MenuVariableName,
                Text = MenuCommandText,
                Image = Icon
            };
            // Set the delegate event handler!
            finalMenuItem.Click += new EventHandler(RunBinaryExecutable);

            // Return the new menu item!
            return finalMenuItem;
        }

        /// <summary>
        ///  Runs the attached program to this menu item.
        /// </summary>
        /// <param name="sender">
        ///  The sender object.
        /// </param>
        /// <param name="e">
        ///  The event arguments.
        /// </param>
        private void RunBinaryExecutable(object sender, EventArgs e) {
            if (File.Exists(BinaryExecutablePath)) {
                Process.Start("cmd.exe", $"/C {BinaryExecutablePath}");
            }
        }
    }
}
