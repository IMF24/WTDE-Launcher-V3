// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       I N I       A N D       X M L       F I L E       E D I T O R
//
//    The Mod Manager's INI and XML file editor, allowing the user to edit both
//    GHWTDE.ini and AspyrConfig.xml as raw text.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;

using System;
using System.IO;
using System.Windows.Forms;

namespace WTDE_Launcher_V3.Managers {
    /// <summary>
    ///  The Mod Manager's INI and XML file editor, allowing the user to edit both
    ///  GHWTDE.ini and AspyrConfig.xml as raw text.
    /// </summary>
    public partial class DEConfigFilesEditor : Form {
        public DEConfigFilesEditor() {
            InitializeComponent();

            // -------------------------------

            string[] iniLines = File.ReadAllLines(V3LauncherConstants.WTDEConfigDir);
            string[] xmlLines = File.ReadAllLines(V3LauncherConstants.AspyrConfigDir);

            WTDEEditorTextArea.Lines = iniLines;
            AspyrEditorTextArea.Lines = xmlLines;
        }

        public void SaveBothFiles() {
            using (StreamWriter sw = new StreamWriter(new FileStream(V3LauncherConstants.WTDEConfigDir, FileMode.Create))) {
                foreach (string line in WTDEEditorTextArea.Lines) {
                    sw.WriteLine(line);
                }
            }

            // -------------------------------

            using (StreamWriter sw = new StreamWriter(new FileStream(V3LauncherConstants.AspyrConfigDir, FileMode.Create))) {
                foreach (string line in AspyrEditorTextArea.Lines) {
                    sw.WriteLine(line);
                }
            }
        }

        private void SaveAndExitButton_Click(object sender, EventArgs e) {
            SaveBothFiles();
            Close();
        }

        private void CloseButtonNoSave_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
