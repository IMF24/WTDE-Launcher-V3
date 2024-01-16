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
        ///  What is the current background?
        /// </summary>
        public static int BGIndex = 0;

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
            "Fox (FoxInari)",
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

        /// <summary>
        ///  List of WTDE logo images. These changed based on the time of year.
        /// </summary>
        public static System.Drawing.Bitmap[] LogoImages = {
            Properties.Resources.logo_wtde,
            Properties.Resources.logo_hw,
            Properties.Resources.logo_xm
        };

        /// <summary>
        ///  Update the background and logo image based on the time of year of BG artists' birthdays!
        /// </summary>
        /// <param name="form"></param>
        /// <param name="label"></param>
        public static void AutoDateBackground(System.Windows.Forms.Form form, System.Windows.Forms.Label label, System.Windows.Forms.PictureBox pictureBox) {
            // What month is it?
            switch (DateTime.Now.Month) {
                // Halloween logo and background.
                case 10:
                    form.BackgroundImage = Properties.Resources.bg_1_hw;
                    V3LauncherBackgrounds[0] = Properties.Resources.bg_1_hw;
                    pictureBox.Image = LogoImages[1];
                    break;

                // Christmas logo and background.
                case 12:
                    if (DateTime.Now.Day >= 1 && DateTime.Now.Day <= 25) {
                        form.BackgroundImage = Properties.Resources.bg_1_xm;
                        V3LauncherBackgrounds[0] = Properties.Resources.bg_1_xm;
                        pictureBox.Image = LogoImages[2];
                    }
                    break;
            }

            // Now, who's birthday is it?
            switch (DateTime.Now.Month) {
                // Blu's background
                case 1:
                    if (DateTime.Now.Day == 23) {
                        BGIndex = 3;
                    }
                    break;

                // Cobalt's background
                case 3:
                    if (DateTime.Now.Day == 5) {
                        BGIndex = 6;
                    }
                    break;

                case 4:
                    // IMF's background
                    if (DateTime.Now.Day == 14) {
                        BGIndex = 1;
                    }

                    // INF3CT0R's background
                    if (DateTime.Now.Day == 20) {
                        BGIndex = 5;
                    }
                    break;

                // Hex's background
                case 5:
                    if (DateTime.Now.Day == 3) {
                        BGIndex = 7;
                    }
                    break;

                // Derpy's background
                case 6:
                    if (DateTime.Now.Day == 2) {
                        BGIndex = 11;
                    }
                    break;

                // Strange's background
                case 7:
                    if (DateTime.Now.Day == 26) {
                        BGIndex = 9;
                    }
                    break;

                // Fox's background
                case 8:
                    if (DateTime.Now.Day == 7) {
                        BGIndex = 0;
                    }
                    break;

                // DanRock's background
                case 9:
                    if (DateTime.Now.Day == 22) {
                        BGIndex = 4;
                    }
                    break;
            }

            form.BackgroundImage = V3LauncherBackgrounds[BGIndex];

            label.Text = label.Text.Replace("ABC", V3LauncherConstants.VERSION);
            label.Text = label.Text.Replace("BG_AUTHOR", V3LauncherBGAuthors[BGIndex]);
            label.Text = label.Text.Replace("LATEST_VERSION", V3LauncherCore.GetLatestVersion());
        }
    }
}
