// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       E N T R Y       P O I N T       F I L E
//
//    The starting file for the V3 launcher's execution. We start here!
// ----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Launcher_V3.Core {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
