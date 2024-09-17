// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       B G       C O N S T A N T S
//
//    This class holds various logic when working with the background. Controls
//    activating various backgrounds when commanded, and also loading specific
//    backgrounds for the artists and developers for this launcher!
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.IO;

// Other required imports.
using System;
using System.IO;
using System.Drawing;

namespace WTDE_Launcher_V3.Core {
    /// <summary>
    ///  This class holds various logic when working with the background. Controls
    ///  activating various backgrounds when commanded, and also loading specific
    ///  backgrounds for the artists and developers for this launcher!
    /// </summary>
    public class BGConstants {
        /// <summary>
        ///  What is the current background?
        /// </summary>
        public static int BGIndex = 0;

        /// <summary>
        ///  Is there a custom background set?
        /// </summary>
        public static bool IsCustomBG = false;

        /// <summary>
        ///  List of backgrounds. This is handled in the background swapper. THESE MUST BE INDEXED PROPERLY!
        /// </summary>
        public static Bitmap[] V3LauncherBackgrounds = {
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
            "Derpytron84",
            "Fox (FoxInari)"
        };

        /// <summary>
        ///  List of social links tied to each person's backgrounds. THESE MUST BE INDEXED PROPERLY!
        /// </summary>
        public static string[] V3LauncherSocials = {
            "https://youtube.com/@Fox-Inari",
            "https://youtube.com/@IMF24",
            "https://youtube.com/@DerpyTheShreddingProto",
            "https://github.com/Bludude2",
            "https://youtube.com/@DanRockProductions",
            "https://twitter.com/samual130",
            "https://youtube.com/@ForTheMisery",
            "https://youtube.com/@hex21510",
            "https://youtube.com/@DanRockProductions",
            "https://youtube.com/@strangerxo1591",
            "https://youtube.com/@DerpyTheShreddingProto",
            "https://youtube.com/@Fox-Inari"
        };

        /// <summary>
        ///  List of WTDE logo images. These changed based on the time of year.
        /// </summary>
        public static Bitmap[] LogoImages = {
            Properties.Resources.logo_wtde,
            Properties.Resources.logo_vd,
            Properties.Resources.logo_af,
            Properties.Resources.logo_hw,
            Properties.Resources.logo_xm
        };

        /// <summary>
        ///  Update the background and logo image based on the time of year of BG artists' birthdays!
        /// </summary>
        /// <param name="form">
        ///  The Windows Form to be affected by the background change.
        /// </param>
        /// <param name="label">
        ///  The label to be affected by this function. This is intended for the version info label on the lower left.
        /// </param>
        /// <param name="pictureBox">
        ///  The picture box to be affected by this function. This is intended for the logo image on the top left.
        /// </param>
        public static void AutoDateBackground(System.Windows.Forms.Form form, System.Windows.Forms.Label label, System.Windows.Forms.PictureBox pictureBox) {
            if ((INIFunctions.GetINIValue("Config", "Holiday", "") != "") &&
                (INIFunctions.GetINIValue("Config", "Holiday") == "aprilfools")) return;

            // Imports a custom background image from the defined path in GHWTDE.ini.
            // Read GHWTDE.ini; do we have a custom background path defined?
            INI file = new INI(V3LauncherConstants.WTDEConfigDir, writeFallback: false);

            V3LauncherCore.AddDebugEntry($"Is dev settings enabled? {V3LauncherCore.EnableDeveloperSettings}", "BG Constants: AutoDateBackground");

            // This is a safe guard measure to make sure we don't accidentally
            // leak in the ability to do this, not that anyone would anyway.
            if (V3LauncherCore.EnableDeveloperSettings && file.HasSection("Launcher")) {
                // Is the "CustomBGPath" key under the [Launcher] section?
                if (file.HasKey("Launcher", "CustomBGPath")) {
                    // Get the path to check if it exists.
                    string pathToCheck = file.GetString("Launcher", "CustomBGPath");
                    
                    // Does this file even exist?
                    if (pathToCheck != null && File.Exists(pathToCheck)) {
                        // Yes it does, let's make a new bitmap and assign the background to it!
                        // We'll go ahead and scale it to 1280 X 768 to make it fit the screen better.
                        V3LauncherCore.AddDebugEntry($"Path to custom BG image: {pathToCheck}", "BG Constants: AutoDateBackground");
                        Bitmap newBGImage = new Bitmap(pathToCheck);
                        Bitmap scaledImage = new Bitmap(newBGImage, 1280, 768);
                        form.BackgroundImage = scaledImage;

                        // Custom author text?
                        if (file.HasKey("Launcher", "CustomBGAuthor")) {
                            string newBGAuthor = file.GetString("Launcher", "CustomBGAuthor");

                            // If so, use it!
                            if (newBGAuthor != null) {
                                label.Text = label.Text.Replace("BG_AUTHOR", newBGAuthor);
                            
                            // Otherwise, we'll just say the author is N/A.
                            } else {
                                label.Text = label.Text.Replace("BG_AUTHOR", "N/A");
                            }

                            // Also add the version and latest version text!
                            label.Text = label.Text.Replace("ABC", V3LauncherConstants.VERSION);
                            label.Text = label.Text.Replace("LATEST_VERSION", V3LauncherCore.GetLatestVersion());
                        }

                        // Mark the below field as true to say we DO have a custom BG set.
                        IsCustomBG = true;

                        // Break out; we're finished!
                        return;

                    // The file didn't exist, do some debug prints or something
                    } else {
                        V3LauncherCore.AddDebugEntry("I/O: The path for the defined custom background does not exist.", "BG Constants: AutoDateBackground");
                        V3LauncherCore.AddDebugEntry("Falling back to auto-date background...", "BG Constants: AutoDateBackground");
                    }
                }
            }

            // What month is it?
            switch (DateTime.Now.Month) {
                // Valentine's Day logo and background.
                case 2:
                    if (DateTime.Now.Day >= 1 && DateTime.Now.Day <= 14) {
                        form.BackgroundImage = Properties.Resources.bg_1_vd;
                        V3LauncherBackgrounds[0] = Properties.Resources.bg_1_vd;
                        pictureBox.Image = LogoImages[1];
                    }
                    break;

                // April Fools Day logo and background.
                case 4:
                    if (DateTime.Now.Day == 1) {
                        form.BackgroundImage = Properties.Resources.bg_1_af;
                        V3LauncherBackgrounds[0] = Properties.Resources.bg_1_af;
                        pictureBox.Image = LogoImages[2];
                    }
                    break;

                // Halloween logo and background.
                case 10:
                    form.BackgroundImage = Properties.Resources.bg_1_hw;
                    V3LauncherBackgrounds[0] = Properties.Resources.bg_1_hw;
                    pictureBox.Image = LogoImages[3];
                    break;

                // Christmas logo and background.
                case 12:
                    if (DateTime.Now.Day >= 1 && DateTime.Now.Day <= 25) {
                        form.BackgroundImage = Properties.Resources.bg_1_xm;
                        V3LauncherBackgrounds[0] = Properties.Resources.bg_1_xm;
                        pictureBox.Image = LogoImages[4];
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
                        BGIndex = 10;
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

                // 2 year anniversary background
                case 12:
                    if (DateTime.Now.Day == 25) {
                        BGIndex = 12;
                    }
                    break;
            }
            
            // Is there a preferred background set?
            if (file.HasSection("Launcher")) {
                if (file.HasKey("Launcher", "PreferredBackground")) {
                    BGIndex = file.GetInt("Launcher", "PreferredBackground");
                    if (BGIndex >= V3LauncherBackgrounds.Length) BGIndex = 0;
                }
            }
            form.BackgroundImage = V3LauncherBackgrounds[BGIndex];

            V3LauncherCore.AddDebugEntry($"Label ID: {label}");

            label.Text = label.Text.Replace("ABC", V3LauncherConstants.VERSION);
            label.Text = label.Text.Replace("BG_AUTHOR", V3LauncherBGAuthors[BGIndex]);
            label.Text = label.Text.Replace("LATEST_VERSION", V3LauncherCore.GetLatestVersion());
        }
    }
}
