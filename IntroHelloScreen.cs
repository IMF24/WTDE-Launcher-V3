// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       I N T R O       W E L C O M E       S C R E E N
//
//    Quick welcome screen to the end user if this is the first time the
//    launcher program has booted up.
// ----------------------------------------------------------------------------
using System;
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
    public partial class IntroHelloScreen : Form {
        public IntroHelloScreen() {
            InitializeComponent();
            VersionInfoLabel.Text = VersionInfoLabel.Text.Replace("ABC", V3LauncherConstants.VERSION);
        }

        public void RunNeverShowAgain() {
            if (NeverShowAgain.Checked) {
                INIFunctions.SaveINIValue("Launcher", "HelloMessageShown", "1");
            }
        }

        private void RunWTDEButton_Click(object sender, EventArgs e) {
            RunNeverShowAgain();
            this.Close();

            // Move to game directory and start!
            ModHandler.UseUpdaterINIDirectory();
            Application.Exit();
            Process.Start("GHWT_Definitive.exe");
        }

        private void ProceedToLauncherButton_Click(object sender, EventArgs e) {
            RunNeverShowAgain();
            this.Close();
        }
    }
}
