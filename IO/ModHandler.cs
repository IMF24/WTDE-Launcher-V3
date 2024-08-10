﻿// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       M O D       H A N D L E R
//
//    Main logic class for reading the user's mods folder.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MadMilkman.Ini;

namespace WTDE_Launcher_V3.IO {
    /// <summary>
    ///  Main logic class for reading the user's mods folder.
    /// </summary>
    internal class ModHandler {
        /// <summary>
        ///  List of all of the user's installed mods and their paths.
        ///  <br/><br/>
        ///  The list contains various string arrays, each containing 7 entries per array. They correspond to the following information:
        ///  <br/>
        ///  - Index 0 is the name of the mod.
        ///  <br/>
        ///  - Index 1 is the author of the mod.
        ///  <br/>
        ///  - Index 2 is the type of mod.
        ///  <br/>
        ///  - Index 3 is the version of the mod.
        ///  <br/>
        ///  - Index 4 is the description of the mod.
        ///  <br/>
        ///  - Index 5 is the path to the mod's config (INI) file.
        ///  <br/>
        ///  - Index 6 is the path to the mod's folder.
        /// </summary>
        public static List<string[]> UserContentMods = ReadMods();

        /// <summary>
        ///  If an Updater.ini file is present, changes the working directory into
        ///  the one provided in the GameDirectory section of the file.
        ///  <br/><br/>
        ///  This method is a VOID return method. For the related method that actually
        ///  does return a path string, use <see cref="V3LauncherCore.GetUpdaterINIDirectory()"/>.
        /// </summary>
        public static void UseUpdaterINIDirectory() {
            if (File.Exists("Updater.ini")) {
                IniFile uif = new IniFile();
                uif.Load("Updater.ini");

                Directory.SetCurrentDirectory(uif.Sections["Updater"].Keys["GameDirectory"].Value);
            }
        }

        /// <summary>
        ///  Iterate through the entire MODS directory and return a list of information about all file
        ///  paths in that folder, including its mod name, author, version, type, description,
        ///  INI file path, and folder path.
        /// </summary>
        /// <returns>
        ///  A list of string arrays containing all mod information. For more information about what the returned list of
        ///  string array contains, view more details on the <see cref="UserContentMods"/> field.
        /// </returns>
        public static List<string[]> ReadMods() {
            // If Updater.ini exists, let's use that path to read the stuff.
            string owd = Directory.GetCurrentDirectory();

            Directory.SetCurrentDirectory(V3LauncherCore.GetUpdaterINIDirectory());

            V3LauncherCore.AddDebugEntry($"CURRENT DIRECTORY: {Directory.GetCurrentDirectory()}", "Mod Handler: ReadMods");

            // Timer starts now!
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            // Read the user's MODS directory for ALL INI FILES.
            string[] files = Directory.GetFiles("DATA/MODS", "*.ini", SearchOption.AllDirectories);

            // This is the output list we'll give back:
            List<string[]> outArray = new List<string[]>();

            // 0 length list? Return the empty output array.
            if (files.Length <= 0) {
                return outArray;
            }

            // Iterate through these files.
            foreach (string file in files) {
                try { 
                    V3LauncherCore.AddDebugEntry($"in dir, reading config file: {file}", "Mod Handler: ReadMods");

                    IniFile iFile = new IniFile();

                    if (file.ToLower().Contains(".ini") && !file.ToLower().Contains("folder.ini")) iFile.Load(file.ToLower());
                    else continue;

                    // Invalid category mod if the file is directly inside of DATA/MODS.
                    // If that's the case, then skip it!
                    string testModsPath = Path.Combine(V3LauncherCore.GetUpdaterINIDirectory(), "DATA/MODS/category.ini");
                    if (Path.GetFullPath(file).ToLower() == testModsPath.ToLower()) {
                        continue;
                    }

                    // Normalize slashes, split path, also figure out
                    // what type of INI file this is.
                    string currentINIFile = file.Replace("\\", "/").Split('/').Last().Replace("/", "").ToLower();
                    V3LauncherCore.AddDebugEntry($"current INI file is {currentINIFile}", "Mod Handler: ReadMods");

                    // What type of INI file is this?
                    string modName, modAuthor, modType, modVersion, modDescription;
                    switch (currentINIFile) {
                        case "song.ini":
                            // If this folder contains a MIDI or CHART file, this is a Melody song.
                            // Therefore, it is not a valid song mod.
                            if (File.Exists(Path.Combine(Path.GetDirectoryName(file), "notes.mid")) ||
                                File.Exists(Path.Combine(Path.GetDirectoryName(file), "notes.chart"))) {

                                V3LauncherCore.AddDebugEntry("Folder was likely a Melody song, skipping...", "Mod Handler: ReadMods");
                                continue;

                            }

                            V3LauncherCore.AddDebugEntry("We found a song mod!", "Mod Handler: ReadMods");

                            try {
                                modName = (iFile.Sections["ModInfo"].Keys.Contains("Name")) ? iFile.Sections["ModInfo"].Keys["Name"].Value : iFile.Sections["SongInfo"].Keys["Title"].Value;
                            } catch {
                                modName = "Unknown Song";
                            }

                            try {
                                modAuthor = (iFile.Sections["ModInfo"].Keys.Contains("Author")) ? iFile.Sections["ModInfo"].Keys["Author"].Value : iFile.Sections["SongInfo"].Keys["Artist"].Value;
                            } catch {
                                modAuthor = "Unknown Author";
                            }

                            modType = "Song";

                            try {
                                modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
                            } catch {
                                modVersion = "N/A";
                            }

                            try {
                                modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
                            } catch {
                                modDescription = "Unknown Information";
                            }
                            break;

                        case "character.ini":
                            V3LauncherCore.AddDebugEntry("We found a character mod!", "Mod Handler: ReadMods");

                            try {
                                modName = (iFile.Sections["ModInfo"].Keys.Contains("Name")) ? iFile.Sections["ModInfo"].Keys["Name"].Value : iFile.Sections["CharacterInfo"].Keys["Name"].Value;
                            } catch {
                                modName = "Unknown Character";
                            }

                            try {
                                modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
                            } catch {
                                modAuthor = "Unknown Author";
                            }

                            modType = "Character";

                            try {
                                modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
                            } catch {
                                modVersion = "N/A";
                            }

                            try {
                                modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
                            } catch {
                                modDescription = "Unknown Information";
                            }
                            break;

                        case "instrument.ini":
                            V3LauncherCore.AddDebugEntry("We found an instrument mod!", "Mod Handler: ReadMods");

                            try {
                                modName = (iFile.Sections["ModInfo"].Keys.Contains("Name")) ? iFile.Sections["ModInfo"].Keys["Name"].Value : iFile.Sections["InstrumentInfo"].Keys["Name"].Value;
                            } catch {
                                modName = "Unknown Instrument";
                            }

                            try {
                                modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
                            } catch {
                                modAuthor = "Unknown Author";
                            }

                            modType = "Instrument";

                            try {
                                modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
                            } catch {
                                modVersion = "N/A";
                            }

                            try {
                                modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
                            } catch {
                                modDescription = "Unknown Information";
                            }
                            break;

                        case "highway.ini":
                            V3LauncherCore.AddDebugEntry("We found a highway mod!", "Mod Handler: ReadMods");

                            try {
                                modName = (iFile.Sections["ModInfo"].Keys.Contains("Name")) ? iFile.Sections["ModInfo"].Keys["Name"].Value : iFile.Sections["HighwayInfo"].Keys["Name"].Value;
                            } catch {
                                modName = "Unknown Highway";
                            }

                            try {
                                modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
                            } catch {
                                modAuthor = "Unknown Author";
                            }

                            modType = "Highway";

                            try {
                                modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
                            } catch {
                                modVersion = "N/A";
                            }

                            try {
                                modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
                            } catch {
                                modDescription = "Unknown Information";
                            }
                            break;

                        case "category.ini":
                            V3LauncherCore.AddDebugEntry("We found a song category mod!", "Mod Handler: ReadMods");

                            try {
                                modName = (iFile.Sections["ModInfo"].Keys.Contains("Name")) ? iFile.Sections["ModInfo"].Keys["Name"].Value : iFile.Sections["CategoryInfo"].Keys["Name"].Value;
                            } catch {
                                modName = "Unknown Category";
                            }

                            try {
                                modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
                            } catch {
                                modAuthor = "Unknown Author";
                            }

                            modType = "Song Category";

                            try {
                                modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
                            } catch {
                                modVersion = "N/A";
                            }

                            try {
                                modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
                            } catch {
                                modDescription = "Unknown Information";
                            }
                            break;

                        case "menumusic.ini":
                            V3LauncherCore.AddDebugEntry("We found a main menu music mod!", "Mod Handler: ReadMods");

                            try {
                                modName = (iFile.Sections["ModInfo"].Keys.Contains("Name")) ? iFile.Sections["ModInfo"].Keys["Name"].Value : iFile.Sections["MenuMusicInfo"].Keys["FSBName"].Value;
                            } catch {
                                modName = "Unknown Menu Music";
                            }

                            try {
                                modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
                            } catch {
                                modAuthor = "Unknown Author";
                            }

                            modType = "Menu Music";

                            try {
                                modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
                            } catch {
                                modVersion = "N/A";
                            }

                            try {
                                modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
                            } catch {
                                modDescription = "Unknown Information";
                            }
                            break;

                        case "venue.ini":
                            V3LauncherCore.AddDebugEntry("We found a venue mod!", "Mod Handler: ReadMods");

                            try {
                                modName = (iFile.Sections["ModInfo"].Keys.Contains("Name")) ? iFile.Sections["ModInfo"].Keys["Name"].Value : iFile.Sections["VenueInfo"].Keys["Name"].Value;
                            } catch {
                                modName = "Unknown Venue";
                            }

                            try {
                                modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
                            } catch {
                                modAuthor = "Unknown Author";
                            }

                            modType = "Venue";

                            try {
                                modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
                            } catch {
                                modVersion = "N/A";
                            }

                            try {
                                modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
                            } catch {
                                modDescription = "Unknown Information";
                            }
                            break;

                        case "gems.ini":
                            V3LauncherCore.AddDebugEntry("We found a gem theme mod!", "Mod Handler: ReadMods");

                            try {
                                modName = (iFile.Sections["ModInfo"].Keys.Contains("Name")) ? iFile.Sections["ModInfo"].Keys["Name"].Value : iFile.Sections["GemInfo"].Keys["Name"].Value;
                            } catch {
                                modName = "Unknown Gem Theme";
                            }

                            try {
                                modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
                            } catch {
                                modAuthor = "Unknown Author";
                            }

                            modType = "Gem Theme";

                            try {
                                modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
                            } catch {
                                modVersion = "N/A";
                            }

                            try {
                                modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
                            } catch {
                                modDescription = "Unknown Information";
                            }
                            break;

                        case "Mod.ini":
                        case "mod.ini":
                            V3LauncherCore.AddDebugEntry("We found a script mod!", "Mod Handler: ReadMods");

                            try {
                                modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
                            } catch {
                                modName = "Unknown Script";
                            }

                            try {
                                modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
                            } catch {
                                modAuthor = "Unknown Author";
                            }

                            modType = "Script";

                            try {
                                modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
                            } catch {
                                modVersion = "N/A";
                            }

                            try {
                                modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
                            } catch {
                                modDescription = "Unknown Information";
                            }
                            break;

                        default:
                            continue;
                    }
                    outArray.Add(new string[] { modName, modAuthor, modType, modVersion, modDescription, Path.Combine(Directory.GetCurrentDirectory(), file), Path.GetDirectoryName(file) });
                
                // Uh oh, we ran into an error parsing this mod.
                // Just log it in the debug log.
                } catch (Exception exc) {
                    V3LauncherCore.AddDebugEntry($"Error parsing mod: {exc.Message}");
                    continue;
                }
            }

            // And the timer stops here!
            stopWatch.Stop();

            V3LauncherCore.AddDebugEntry($"ALL DONE! Read and parsed {outArray.Count} mods in {stopWatch.Elapsed.TotalSeconds:0.00} sec", "Mod Handler: ReadMods");

            UserContentMods = outArray;

            // Reset our working directory if we changed it, then give the list back!
            Directory.SetCurrentDirectory(owd);
            return outArray;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  List of various mod types used by GHWT: DE.
        /// </summary>
        public enum ModTypes {
            /// <summary>
            ///  Song mods.
            /// </summary>
            Song = 0,
            /// <summary>
            ///  Character mods.
            /// </summary>
            Character = 1,
            /// <summary>
            ///  Instrument mods.
            /// </summary>
            Instrument = 2,
            /// <summary>
            ///  Highway mods.
            /// </summary>
            Highway = 3,
            /// <summary>
            ///  Venue mods.
            /// </summary>
            Venue = 4,
            /// <summary>
            ///  Menu music mods.
            /// </summary>
            MenuMusic = 5,
            /// <summary>
            ///  Song category mods.
            /// </summary>
            Category = 6,
            /// <summary>
            ///  Gem theme mods.
            /// </summary>
            Gems = 7,
            /// <summary>
            ///  QB script mods.
            /// </summary>
            Script = 8
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Finds all mods of a various type.
        /// </summary>
        /// <param name="modType">
        ///  The type of mod to search for.
        /// </param>
        /// <returns>
        ///  Returns a list of all of the mods matching the given type.
        /// </returns>
        public static List<string[]> GetModsByType(ModTypes modType) {
            // What type of mod do we want to find?
            string[] modTypes = new string[] {
                "Song", "Character", "Instrument", "Highway", "Venue",
                "Menu Music", "Song Category", "Gem Theme", "Script"
            };
            string modTypeToFind = modTypes[(int) modType];

            // Now let's do some searching! LINQ makes this pretty elegant.
            IEnumerable<string[]> outMods =
                from mod in UserContentMods
                where mod[2] == modTypeToFind
                select mod;

            // And let's give the list back when we're done!
            return outMods.ToList();
        }

        /// <summary>
        ///  Finds all mods of a various type.
        /// </summary>
        /// <param name="modType">
        ///  The type of mod to search for.
        /// </param>
        /// <returns>
        ///  Returns a list of all of the mods matching the given type.
        /// </returns>
        public static List<string[]> GetModsByType(int modType) {
            // What type of mod do we want to find?
            if (modType > 8 || modType < 0) modType = 0;
            string[] modTypes = new string[] {
                "Song", "Character", "Instrument", "Highway", "Venue",
                "Menu Music", "Song Category", "Gem Theme", "Script"
            };
            string modTypeToFind = modTypes[modType];

            // Now let's do some searching! LINQ makes this pretty elegant.
            IEnumerable<string[]> outMods =
                from mod in UserContentMods
                where mod[2] == modTypeToFind
                select mod;

            // And let's give the list back when we're done!
            return outMods.ToList();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Insert venue mods into the global array of zone names and prefixes.
        /// </summary>
        public static void AppendVenueMods(ComboBox[] cBoxList) {
            // Get our venue mods!
            List<string[]> venueMods = GetModsByType(ModTypes.Venue);

            // Combo box data used later on.
            List<string[]> venueModCBoxData = new List<string[]>();

            // Loop through each one; we want to read its INI file.
            for (var i = 0; i < venueMods.Count; i++) {
                try { 
                    // Open our current venue mod's config file!
                    // First, make sure the file exists.
                    string configPath = venueMods[i][5];
                    if (!File.Exists(configPath)) {
                        V3LauncherCore.AddDebugEntry($"Venue mod config {configPath} was not found, skipping...", "Mod Handler: AppendVenueMods");
                        continue;
                    }

                    // We did find it, great! Let's load it!
                    INI file = new INI(configPath);

                    // Next, get the venue's name and PAK prefix!
                    // This will be safer than using IniFile since our INI class
                    // has fallback measures in place if the strings are not
                    // found. We can't assume the user has everything.

                    string venueName = file.GetString("VenueInfo", "Name", $"Unknown Venue {i + 1}");
                    string venuePrefix = file.GetString("VenueInfo", "PakPrefix", $"z_unknownvenue{i}");

                    // Next up, add our venue's name and PAK prefix into the global lists.
                    V3LauncherConstants.VenueIDs[0].Add($"Mod: {venueName}");
                    V3LauncherConstants.VenueIDs[1].Add(venuePrefix);

                    // And finally, add our new data so we can insert it
                    // into the combo boxes here shortly!
                    venueModCBoxData.Add(new string[] { $"Mod: {venueName}", venuePrefix });
                
                } catch (Exception exc) {
                    // Something went wrong, just log it and skip this venue mod.
                    V3LauncherCore.AddDebugEntry($"Error processing venue mod, skipping // Exception: {exc.Message}", "Mod Handler: AppendGemMods");
                    continue;
                }
            }

            // Last task: Add these to the combo boxes we specified!
            if (venueMods.Count > 0) {
                foreach (var cBox in cBoxList) {
                    foreach (string[] dataArr in venueModCBoxData) {
                        cBox.Items.Add(dataArr[0]);
                    }
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Insert gem mods into the global array of gem mod names and filenames.
        /// </summary>
        public static void AppendGemMods(ComboBox[] cBoxList) {
            // Get our gem mods!
            List<string[]> gemMods = GetModsByType(ModTypes.Gems);

            // Combo box data used later on.
            List<string[]> gemModCBoxData = new List<string[]>();

            // Loop through each one; we want to read its INI file.
            for (var i = 0; i < gemMods.Count; i++) {
                try {
                    // Open our current gem style mod's config file!
                    // First, make sure the file exists.
                    string configPath = gemMods[i][5];
                    if (!File.Exists(configPath)) {
                        V3LauncherCore.AddDebugEntry($"Gem mod config {configPath} was not found, skipping...", "Mod Handler: AppendGemMods");
                        continue;
                    }

                    // We did find it, great! Let's load it!
                    INI file = new INI(configPath);

                    // Next, get the gem theme's name and theme checksum!
                    // This will be safer than using IniFile since our INI class
                    // has fallback measures in place if the strings are not
                    // found. We can't assume the user has everything.

                    string gemModName = file.GetString("GemInfo", "Name", "");
                    string gemNameValue = file.GetString("GemInfo", "Filename", "");

                    // Next up, add our gem's name and checksum into the global lists.
                    V3LauncherConstants.NoteStyles[0].Add($"Mod: {gemModName}");
                    V3LauncherConstants.NoteStyles[1].Add(gemNameValue);

                    // And finally, add our new data so we can insert it
                    // into the combo boxes here shortly!
                    gemModCBoxData.Add(new string[] { $"Mod: {gemModName}", gemNameValue });

                } catch (Exception exc) {
                    // Something went wrong, just log it and skip this gem theme mod.
                    V3LauncherCore.AddDebugEntry($"Error processing gem theme mod, skipping // Exception: {exc.Message}", "Mod Handler: AppendGemMods");
                    continue;
                }
            }

            // Last task: Add these to the combo boxes we specified!
            if (gemMods.Count > 0) {
                foreach (var cBox in cBoxList) {
                    foreach (string[] dataArr in gemModCBoxData) {
                        cBox.Items.Add(dataArr[0]);
                    }
                }
            }
        }
    }
}
