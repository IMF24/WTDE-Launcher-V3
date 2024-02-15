// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       I N T R O       S P L A S H
//
//    Intro splash form shown that auto kills when Main is done loading.
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

            this.Text = $"GHWT: Definitive Edition Launcher - V{V3LauncherConstants.VERSION}";
            VersionInfoLabel.Text = $"Version {V3LauncherConstants.VERSION}";
        }

        // Add in double buffering.
        protected override CreateParams CreateParams {
            // Double buffer to prevent flickering.
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}
