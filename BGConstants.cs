// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       B G       C O N S T A N T S
//
//    This class holds various logic when working with the background. Controls
//    activating various backgrounds when commanded, and also loading specific
//    backgrounds for the artists and developers for this launcher!
// ----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDE_Launcher_V3 {
    /// <summary>
    ///  This class holds various logic when working with the background. Controls
    ///  activating various backgrounds when commanded, and also loading specific
    ///  backgrounds for the artists and developers for this launcher!
    /// </summary>
    internal class BGConstants {
        /// <summary>
        ///  List of backgrounds. This is handled in the background swapper. THESE MUST BE INDEXED PROPERLY!
        /// </summary>
        public static System.Drawing.Bitmap[] V3LauncherBackgrounds = {
            Properties.Resources.bg_1,
            Properties.Resources.bg_2,
            Properties.Resources.bg_3,
            Properties.Resources.bg_4,
            Properties.Resources.bg_5,
            Properties.Resources.bg_6,
            Properties.Resources.bg_7,
            Properties.Resources.bg_8,
            Properties.Resources.bg_9,
            Properties.Resources.bg_10,
            Properties.Resources.bg_11,
            Properties.Resources.bg_12
        };

        /// <summary>
        ///  List of authors of the backgrounds. THESE MUST BE INDEXED PROPERLY!
        /// </summary>
        public static string[] V3LauncherBGAuthors = {
            "Fox (FoxJudy)",
            "IMF24",
            "Derpytron84",
            "blu2.rph",
            "DanRock",
            "INF3CT0R",
            "Cobalt",
            "Hex",
            "DanRock",
            "StrangerX-01",
            "Raccoon_333",
            "Derpytron84"
        };

        /// <summary>
        ///  List of social links tied to each person's backgrounds. THESE MUST BE INDEXED PROPERLY!
        /// </summary>
        public static string[] V3LauncherSocials = {
            "https://youtube.com/@Fox-Judy",
            "https://youtube.com/@IMF24",
            "https://youtube.com/@DerpyTheShreddingProto",
            "https://github.com/Bludude2",
            "https://youtube.com/@DanRockProductions",
            "https://twitter.com/samual130",
            "https://youtube.com/@Cobalt179",
            "https://www.youtube.com/@hex21510",
            "https://youtube.com/@DanRockProductions",
            "https://youtube.com/@strangerxo1591",
            "https://youtube.com/@raccoon_333",
            "https://youtube.com/@DerpyTheShreddingProto"
        };
    }
}
