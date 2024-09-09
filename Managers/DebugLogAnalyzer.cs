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
    /// <summary>
    ///  The Mod Manager's Debug Log Manager, a tool to analyze debug logs and
    ///  tell the end user what might be wrong.
    /// </summary>
    public partial class DebugLogAnalyzer : Form {
        /// <summary>
        ///  The Mod Manager's Debug Log Manager, a tool to analyze debug logs and
        ///  tell the end user what might be wrong.
        /// </summary>
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
                new string[] { "Mesh Error: Bad geometry in mesh file OR the model has too many vertices or faces in one single mesh, and it is blowing out the CPU skinning buffer. Your model is too complex!", "00666FCB", "006623BF", "006623F9" },
                new string[] { "WTDE or Mesh Error: An installed mod's folder path exceeds the limit of 255 characters OR a mesh file has over 21,845 vertices inside of it, and it needs to be split or decimated.", "01B70808", "01B76291" },
                new string[] { "Engine or Texture Error: One (if not all) of your textures have incorrectly uncompressed mipmaps.", "0065BB38" },
                new string[] { "Engine or Texture Error: Attempted to load a texture dictionary that is over 28 MB in size, and the game crashed upon loading it. You probably have too many high resolution textures; downscale them, or remove materials!", "0066975F" },
                new string[] { "Song Error: A section inside of song_guitar_markers is missing a Marker parameter and the game can't compare its section against _ENDOFSONG. Update your song mod!", "004E5954" },
                new string[] { "Microsoft Windows Error: Game failed to write controls or online credentials to AspyrConfig.xml. Remove read-only properties from the XML file to fix it!", "76320592" },
                new string[] { "WTDE Error: Your save file is corrupt; delete it or load a non-corrupt back up save!", "004D7022", "00443FF1" },
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
                new string[] { "Engine or Texture Error: An error has occurred with a texture dictionary in some aspect. Contact a developer.", "0065A7DE" },

            },

            // -- WTDE ERRORS
            new string[][] {
                new string[] { "WTDE and Engine Error: You have too many songs tied to a single category. Remove some of them!", "Out of CSpriteElements (3000 max) in their Compact Pool (Exceeded pool bounds!)" },
                new string[] { "WTDE and Engine Error: Out of arrays in memory; you proba0bly have too many songs!", "Out of CArrays (500000 max) in their Compact Pool (Exceeded pool bounds!)" },
                
                new string[] { "Melody Error: Internal chart parser detected a Guitar Hero Live guitar track. This is not supported; delete ANY AND ALL GHL tracks to fix it!", "GHLGuitar" }
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

                    // Read each line and parse it!
                    int linesDone = 0;
                    foreach (string currentLine in content) {

                        string line = currentLine.Replace("\n", "");

                        // We want to scan over our various mod exception types.
                        for (var i = 0; i < ModExceptionTypes.Count; i++) {

                            // First up, let's scan for generic errors.
                            if (i == 0) {

                                // Do not parse index 0! That's the text we'll give back.
                                // Rather, we should check like this:
                                // CRITICAL: !! -- FATAL ERROR AT {address[j]} -- !!
                                // Make sure we call ToLower() on this!
                                //~ Console.WriteLine($"line text: {line.ToLower()}");

                                foreach (string[] errorInfo in ModExceptionTypes[0]) {
                                    for (var j = 1; j < errorInfo.Length; j++) {
                                        string toCheck = $"FATAL ERROR AT 0x{errorInfo[j]}";

                                        //~ Console.WriteLine($"string to check: {toCheck.ToLower()}");
                                        //~ Console.WriteLine($"line being scanned over: {line.ToLower().Contains(toCheck.ToLower())}");

                                        if (line.ToLower().Contains(toCheck.ToLower())) {
                                            //~ Console.WriteLine($"Error found: {errorInfo[j]} // On line: {line}");
                                            textOutList.Add($"{errorInfo[j]}: {errorInfo[0]}");
                                        }
                                    }
                                }

                            // WTDE specific errors.
                            } else {

                                //~ Console.WriteLine($"Scanning WTDE specific errors...");

                                foreach (string[] errorInfo in ModExceptionTypes[i]) {
                                    for (var j = 1; j < errorInfo.Length; j++) {
                                        string toCheck = $"{errorInfo[j]}";

                                        //~ Console.WriteLine($"string to check: {toCheck.ToLower()}");
                                        //~ Console.WriteLine($"line being scanned over: {line.ToLower().Contains(toCheck.ToLower())}");

                                        if (line.ToLower().Contains(toCheck.ToLower())) {
                                            //~ Console.WriteLine($"Error found: {errorInfo[j]} // On line: {line}");
                                            textOutList.Add($"{errorInfo[j]}: {errorInfo[0]}");
                                        }
                                    }
                                }

                            }
                        }

                        // Update the progress bar stuff.
                        linesDone++;
                        ScanProgressBar.Value = linesDone;

                        decimal totalProgress = (linesDone / (decimal) content.Length) * 100;
                        string resultStr = Math.Round(totalProgress, 0).ToString() + "%";

                        ScanProgressPercent.Text = resultStr;

                        Application.DoEvents();
                    }

                    // - - - - - - - - - - - - - - - - - - -

                    // Now let's show the results!
                    if (textOutList.Count <= 0) {
                        textOutList.Add("No errors were recognized as common.");
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

        private void CloseButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
