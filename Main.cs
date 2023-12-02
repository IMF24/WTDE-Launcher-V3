/* -----------------------------------------------------------------------------------------------
     __    __  _____  ___  __        __    _             __  ___         __  __            _____ 
    / / /\ \ \/__   \/   \/__\      / /   /_\  /\ /\  /\ \ \/ __\ /\  /\/__\/__\    /\   /\___ / 
    \ \/  \/ /  / /\/ /\ /_\       / /   //_\\/ / \ \/  \/ / /   / /_/ /_\ / \//    \ \ / / |_ \ 
     \  /\  /  / / / /_///__      / /___/  _  \ \_/ / /\  / /___/ __  //__/ _  \     \ V / ___) |
      \/  \/   \/ /___,'\__/      \____/\_/ \_/\___/\_\ \/\____/\/ /_/\__/\/ \_/      \_/ |____/ 
                                                                                             
    GHWT: Definitive Edition Launcher Version 3 - By IMF24
     - - - - - - - - - - - - - - - - - - - - - - - - - -

    The 3rd generation launcher program for Guitar Hero World Tour: Definitive Edition, but now
    expanded even further and made as pretty as Uzis' original launcher!

    This time, this isn't a Python program, it's now written in C#! That's right, we've moved
    away from Python, and we're moving the launcher BACK to the C# language, built on the .NET
    framework. All the functionality of the V2 launcher will be re-imported into here, and it
    will also be visually polished to make it look the best it possibly can!
    
----------------------------------------------------------------------------------------------- */
// Various required imports.
using System.Diagnostics;

// Main namespace for the program is WTDE_Launcher_V3.
namespace WTDE_Launcher_V3
{
    /// <summary>
    ///  Main class for the V3 launcher.
    /// </summary>
    public partial class Main : Form
    {
        public int BGIndex = 0;
        public int ActiveTab = 1;
        public bool TabBarActive = false;

        /// <summary>
        ///  Opens a specific website. This handles all the complicated stuff to do this.
        /// </summary>
        /// <param name="site"></param>
        public static void OpenSiteURL(string site)
        {
            var url = site;
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = url;
            System.Diagnostics.Process.Start(psi);
        }

        /// <summary>
        ///  Main entry point of the V3 launcher Form.
        /// </summary>
        public Main()
        {
            // Initialize Windows Form. We need this. DON'T EDIT OR DELETE IT!
            InitializeComponent();

            // This ID number indicates which tab we're on.
            /* TAB NUMBERS:
             *   1 - General
             *   2 - Input
             *   ...
             */
            // Is the settings tab bar active? OFF by default, we'll show the
            // MOTD first, then the user can trigger the settings pane.
            // DEBUG: Set this true for now. When we ship this, turn it back to false.

            // Update window title with random splash and actual version number.
            // The object `random` is used for the random splash picker.
            Random random = new Random();
            string[] requiredSplashList = { };

            // What month is it? This determines both what splash bank to pull
            // from, and also how the background needs to be stylized.
            switch (DateTime.Now.Month)
            {
                // Halloween holiday stuff
                case 10:
                    requiredSplashList = V3LauncherConstants.RandomWindowTitlesHW;
                    LogoWTDE.Image = Properties.Resources.wtde_logo_hw;
                    this.BackgroundImage = Properties.Resources.bg_1_hw;
                    BGConstants.V3LauncherBackgrounds[1] = Properties.Resources.bg_1_hw;
                    break;

                // Christmas holiday stuff
                case 12:
                    requiredSplashList = V3LauncherConstants.RandomWindowTitlesXM;
                    LogoWTDE.Image = Properties.Resources.wtde_logo_xmas;
                    this.BackgroundImage = Properties.Resources.bg_1_xm;
                    BGConstants.V3LauncherBackgrounds[1] = Properties.Resources.bg_1_xm;
                    break;

                // Normal title splashes, nothing different
                default:
                    requiredSplashList = V3LauncherConstants.RandomWindowTitles;
                    break;
            }
            // Now pick a random one, and update the window title!
            int splashID = random.Next(0, requiredSplashList.Length);
            this.Text = $"GHWT: Definitive Edition Launcher - V{V3LauncherConstants.VERSION} - {requiredSplashList[splashID]}";

            // Main editing area is located at (391, -4).
            // That's where we need to move the MOTD container to.
            //~ MOTDPanel.Location = new Point(391, -4);

            // Make MOTD visible, hide editing area (for now).
            WhiteOverlay.Enabled = TabBarActive;
            TabButtonGroup.Enabled = TabBarActive;
            WhiteOverlay.Visible = TabBarActive;
            TabButtonGroup.Visible = TabBarActive;

            MOTDPanel.Visible = !TabBarActive;
            MOTDLabel.Text = TabHandler.GetMOTDText();

            // Just for the sake of debugging, we'll change our working directory to where
            // GHWT is installed. This path is defined in the `wtde_path.txt` file.
            // DEBUG: Read `wtde_path.txt` and change working directory there.
            Directory.SetCurrentDirectory(File.ReadAllText("../../../wtde_path.txt"));
        }

        /// <summary>
        ///  When this button is clicked, start GHWT: DE.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunWTDE_Click(object sender, EventArgs e)
        {
            if (File.Exists("GHWT_Definitive.exe"))
            {
                System.Diagnostics.Process.Start("GHWT_Definitive.exe");
            }
        }

        /// <summary>
        ///  When the version label is clicked, change the background. This is pulled from the BGConstants class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VersionInfoLabel_Click(object sender, EventArgs e)
        {
            // Which mouse button did we push?
            MouseEventArgs me = (MouseEventArgs)e;

            // Left triggers the background to swap.
            if (me.Button == MouseButtons.Left)
            {
                // Are we at the end of the BG cycle?
                if (BGIndex + 1 == BGConstants.V3LauncherBackgrounds.Length) BGIndex = 0;
                else BGIndex++;

                // Update the background image.
                this.BackgroundImage = BGConstants.V3LauncherBackgrounds[BGIndex];

                // Update the version info.
                VersionInfoLabel.Text = $"GHWT: DE Launcher V{V3LauncherConstants.VERSION} by IMF24\nBG Image: {BGConstants.V3LauncherBGAuthors[BGIndex]}";

                // And right opens the social link for that person.
            }
            else if (me.Button == MouseButtons.Right)
            {
                OpenSiteURL(BGConstants.V3LauncherSocials[BGIndex]);
            }
        }

        /// <summary>
        ///  When clicked, enable the user's ability to edit their config file(s) settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdjustSettings_Click(object sender, EventArgs e)
        {
            // Invert the status of TabBarActive.
            TabBarActive = !TabBarActive;

            WhiteOverlay.Enabled = TabBarActive;
            WhiteOverlay.Visible = TabBarActive;

            TabButtonGroup.Enabled = TabBarActive;
            TabButtonGroup.Visible = TabBarActive;

            MOTDPanel.Visible = !TabBarActive;
        }

        /// <summary>
        ///  Open the user's mods folder for GHWT: DE in DATA\MODS.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMods_Click(object sender, EventArgs e)
        {
            //~ Debug.WriteLine($"cwd: {Directory.GetCurrentDirectory()}");
            System.Diagnostics.Process.Start("explorer.exe", "DATA\\MODS");
        }

        /// <summary>
        ///  When the user clicks this, run the update checker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckForUpdates_Click(object sender, EventArgs e)
        {
            V3LauncherCore.CheckForUpdates();
        }
    }
}