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
                // Halloween title splashes
                case 10:
                    requiredSplashList = V3LauncherConstants.RandomWindowTitlesHW;
                    break;

                // Christmas title splashes
                case 12:
                    requiredSplashList = V3LauncherConstants.RandomWindowTitlesXM;
                    break;

                // Normal title splashes
                default:
                    requiredSplashList = V3LauncherConstants.RandomWindowTitles;
                    break;
            }
            // Now pick a random one, and update the window title!
            int splashID = random.Next(0, requiredSplashList.Length);
            this.Text = $"GHWT: Definitive Edition Launcher - V{V3LauncherConstants.VERSION} - {requiredSplashList[splashID]}";

            // Main editing area is located at (391, -4).
            // That's where we need to move the MOTD container to.
            MOTDPanel.Location = new Point(391, -4);

            // Make MOTD visible, hide editing area (for now).
            MainEditorPane.Visible = TabBarActive;
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

        private void MOTDLabel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///  When the version label is clicked, change the background. This is pulled from the BGConstants class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VersionInfoLabel_Click(object sender, EventArgs e)
        {
            // Are we at the end of the BG cycle?
            if (BGIndex + 1 == BGConstants.V3LauncherBackgrounds.Length) BGIndex = 0;
            else BGIndex++;

            // Update the background image.
            this.BackgroundImage = BGConstants.V3LauncherBackgrounds[BGIndex];

            // Update the version info.
            VersionInfoLabel.Text = $"GHWT: DE Launcher V{V3LauncherConstants.VERSION} by IMF24\nBG Image: {BGConstants.V3LauncherBGAuthors[BGIndex]}";
        }
    }
}