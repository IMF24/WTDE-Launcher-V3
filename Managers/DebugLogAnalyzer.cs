// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       D E B U G       L O G       A N A L Y Z E R
//
//    The Mod Manager's Debug Log Manager, a tool to analyze debug logs and
//    tell the end user what might be wrong.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;
using WTDE_Launcher_V3.IO;

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Launcher_V3.Managers {
    public partial class DebugLogAnalyzer : Form {
        public DebugLogAnalyzer() {
            InitializeComponent();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -
        //  M O D    E X C E P T I O N    T Y P E S
        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        public List<string[][]> ModExceptionTypes = new List<string[][]> { 
            // -- COMMON EXCEPTIONS
            new string[][] {
                new string[] { "Error is unknown. Contact a developer for more information.", "00000000"  },
                new string[] { "WTDE Error: Button model arrays are missing, stems from CFunc SetButtonData. Contact a developer.", "0048D031" },
                new string[] { "Skeleton Error: A character's skeleton file is missing or packaged incorrectly, or cannot be loaded because it is named incorrectly. In most cases, this is an issue with the drummer skeleton.", "00532A07" },
                new string[] { "Mesh Error: An error reading sMeshes from a .skin.xen file. The model might have too much geometry!", "0060D45C" },
                new string[] { "Engine or Texture Error: Might be an issue that is related to a texture dictionary. May be caused from messing with CAR items. Contact a developer.", "0065BF4A" },
                new string[] { "Engine Error: Failure to load a standalone image, probably a screen image. Contact a developer.", "0065A9FC" },
                new string[] { "Mesh Error: Bad geometry in mesh file or the model has too many vertices or faces in one single mesh. Your model is probably too complex!", "00666FCB" },
                new string[] { "WTDE or Mesh Error: An installed mod's folder path exceeds the limit of 255 characters OR a mesh file has over 21,845 vertices inside of it, and it needs to be split or decimated.", "01B70808", "01B76291" },
                new string[] { "Engine or Texture Error: One (if not all) of your textures have incorrectly uncompressed mipmaps.", "0065BB38" },
                new string[] { "Engine or Texture Error: Attempted to load a texture dictionary that is over 28 MB in size, and the game crashed upon loading it. You probably have too many high resolution textures; downscale them, or remove materials!", "0066975F" },
                new string[] { "Song Error: A section inside of song_guitar_markers is missing a Marker parameter and the game can't compare its section against _ENDOFSONG. Update your song mod!", "004E5954" },
                new string[] { "Microsoft Windows Error: Game failed to write controls or online credentials to AspyrConfig.xml. Remove read-only properties from the XML file to fix it!", "76320592" },
                new string[] { "WTDE Error: Your save file is corrupt, delete it!", "004D7022" },
                new string[] { "Song or Venue Error: The PAK file of said mod type is corrupt. Delete the mod and get in contact with the author of that mod to fix it!", "004A224B" },
                new string[] { "Texture Error: Missing highway texture, re-install or update WTDE!", "005EA5C3" },
                new string[] { "Song Error: Animations are corrupt, re-install the song mod and contact the author to fix it.", "0076876E" },
                new string[] { "Venue Error: A light housing in a venue is missing the following QBKey:\n\nStructQBKey volumeshadow = false\n\nAdd it to the venue's LFX file!", "006829B7" },
                new string[] { "Engine Error: An action was carried out that caused the game to lose focus of the Direct3D device, and attempted to write to non-existent memory. Usually happens from ALT-TABing, or from changing monitor refresh rate.", "00500FAB", "00500B0E" },
                new string[] { "Havok Error: An error with a Havok ragdoll. Contact a developer.", "006BFCC0" },
                new string[] { "Havok Error: The game is expecting bones and rigid bodies to appear in the order they are parented in, but the data is not written properly. Contact the developer of your mod, or if it is with a built-in character, contact a WTDE developer.", "00543D8F" },
                new string[] { "QB Error: An error occurred in trying to populate a script with a QB element through C++ functionality. Contact a developer.", "005F1827" },
                new string[] { "QB or Engine Error: An error in creating a frontend menu. Contact a developer.", "005A02CE" },
                new string[] { "Engine Error: Hook to strcmp used by Havok is failing, usually a missing piece of text. Contact a developer.", "007C9D58" },
                new string[] { "WTDE and Engine Error: You (most likely) have too many songs tied to a single category. Remove some out of them!", "006B7897" },

                new string[] { "Melody Error: Internal chart parser detected a Guitar Hero Live guitar track. This is not supported; delete ANY AND ALL GHL tracks to fix it!", "GHLGuitar" }
            },

            // -- COMPACT POOL ISSUES
            new string[][] {
                new string[] { "WTDE and Engine Error: You have too many songs tied to a single category. Remove some of them!", "Out of CSpriteElements (3000 max) in their Compact Pool (Exceeded pool bounds!)" },
                new string[] { "WTDE and Engine Error: Out of arrays in memory; you proba0bly have too many songs!", "Out of CArrays (500000 max) in their Compact Pool (Exceeded pool bounds!)" },
            }
        };


        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Read a debug log and report any errors we find!
        /// </summary>
        /// <param name="filename">
        ///  The text file to open.
        /// </param>
        public void ScanDebugLog(string filename) {
            // Clear out the output logs!
            AnalyzeOutputText.ReadOnly = false;
            AnalyzeOutputText.Text = "";

            ScanProgressBar.Value = 0;
            ScanProgressPercent.Text = "0%";

            // Got a file to open? Let's analyze it!
            if (filename != "") {
                string[] content = File.ReadAllLines(filename);
                ScanProgressBar.Minimum = 0;
                ScanProgressBar.Maximum = content.Length;

                List<string> textOutList = new List<string>();

                // Bad debug log, we cannot scan it.
                if (content.Last().Contains("Song active status setting: 1")) {
                    AnalyzeOutputText.Text += "The tool cannot analyze your debug log. You have Skip Song Logging enabled. Disable it, run the mod, obtain the same crash, and try again with a new debug log.";
                    ScanProgressBar.Value = ScanProgressBar.Maximum;
                    ScanProgressPercent.Text = "100%";

                // Valid log, let's scan it!
                } else {
                    bool hasPassedMainContent = false;

                    // Scan the file and find any crashes!
                    foreach (string line in content) {

                        if (hasPassedMainContent) {

                            //~ Console.WriteLine($"Scanning line: {line}");

                            for (var i = 0; i < ModExceptionTypes.Count; i++) {
                                // Scan generic mod exceptions with crash addresses.
                                if (i == 0) {


                                    if (!hasPassedMainContent) continue;

                                    foreach (string[] errorInfo in ModExceptionTypes[i]) {
                                        for (var j = 1; j < errorInfo.Length; j++) {

                                            string crashAddressString = $"CRITICAL: !! -- FATAL ERROR AT 0x{errorInfo[j].ToLower()} -- !!";

                                            //~ Console.WriteLine($"Checking for string: {crashAddressString}");

                                            if (hasPassedMainContent) {
                                                if (line.ToLower().Contains(crashAddressString.ToLower())) {
                                                    Console.WriteLine($"Crash address string was: {crashAddressString}");
                                                    Console.WriteLine($"Line that contained the string: {line}");

                                                    textOutList.Add(errorInfo[0]);

                                                    break;
                                                } else if (line.ToLower().Contains("CRITICAL: !! -- FATAL ERROR AT".ToLower())) {
                                                    Console.WriteLine($"Crash address string was: {crashAddressString}");
                                                    Console.WriteLine($"Line that contained the string: {line}");

                                                    textOutList.Add($"I can't give a lot of info on this, but I found a crash address: {line} // Please contact a developer for further information.");

                                                    break;
                                                }
                                            }
                                        }
                                    }
                                } else {
                                    foreach (string[] errorInfo in ModExceptionTypes[i]) {

                                        if (!hasPassedMainContent) continue;

                                        for (var j = 1; j < errorInfo.Length; j++) {
                                            string crashAddressString = errorInfo[j];

                                            //~ Console.WriteLine($"Checking for string: {crashAddressString}");

                                            if (line.ToLower().Contains(crashAddressString.ToLower())) {
                                                Console.WriteLine($"Crash address string was: {crashAddressString}");
                                                Console.WriteLine($"Line that contained the string: {line}");

                                                textOutList.Add(errorInfo[0]);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        ScanProgressBar.Value++;
                        ScanProgressPercent.Text = $"{Math.Round(((decimal)ScanProgressBar.Value / ScanProgressBar.Maximum) * 100M, 0)}%";

                        Application.DoEvents();

                        if (line.Contains("<!> TODO: FIXME <!>") && !hasPassedMainContent) {
                            hasPassedMainContent = true;
                        } else continue;
                    }

                    if (AnalyzeOutputText.Text.Length <= 0) {
                        textOutList.Add("Sorry, this doesn't tell me anything. Everything looks fine.");
                    }

                    AnalyzeOutputText.Lines = textOutList.ToArray();
                }
            // No file to open? Tell the user!
            } else {
                string errorMsg = "You didn't specify a debug log path!\n\nPlease input a path to a WTDE debug log and try again.";
                MessageBox.Show(errorMsg, "No File Given", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AnalyzeOutputText.ReadOnly = true;
        }

        public string GetDebugLogFromFileDialog() {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select WTDE Debug Log";
            ofd.Filter = "Text Files|*.txt|All Files|*.*";

            ofd.ShowDialog();

            return ofd.FileName;
        }

        private void ScanLogButton_Click(object sender, EventArgs e) {
            ScanDebugLog(DebugLogPath.Text);
        }

        private void SelectDebugLogButton_Click(object sender, EventArgs e) {
            string outPath = GetDebugLogFromFileDialog();
            DebugLogPath.Text = (outPath != "") ? outPath : DebugLogPath.Text;
        }
    }
}
