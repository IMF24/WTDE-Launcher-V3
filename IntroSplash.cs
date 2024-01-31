// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       I N T R O       S P L A S H
//
//    Intro splash form shown that auto kills after 3 seconds, then the main
//    form spawns.
// ----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Launcher_V3 {
    /// <summary>
    ///  Intro splash form shown that auto kills after 3 seconds, then the main form spawns.
    /// </summary>
    public partial class IntroSplash : Form {
        public IntroSplash() {
            InitializeComponent();

            VersionInfoLabel.Text = $"Version {V3LauncherConstants.VERSION}";
        }

        private void SelfKillWorker_DoWork(object sender, DoWorkEventArgs e) {
            Thread.Sleep(3000);

            this.Close();
        }

        private void IntroSplash_MouseEnter(object sender, EventArgs e) {
            try {
                SelfKillWorker.RunWorkerAsync();
            } catch {
                return;
            }
        }
    }
}
