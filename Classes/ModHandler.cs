// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       M O D       H A N D L E R
//
//    Main logic class for reading the user's mods folder.
// ----------------------------------------------------------------------------
using MadMilkman.Ini;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Launcher_V3 {
	/// <summary>
	///  Main logic class for reading the user's mods folder.
	/// </summary>
	class ModHandler {
		/// <summary>
		///  List of all of the user's installed mods and their paths.
		/// </summary>
		public static List<string[]> UserContentMods = ReadMods();

		/// <summary>
		///  If an Updater.ini file is present, changes the working directory into
		///  the one provided in the GameDirectory section of the file.
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
		///  and folder path.
		/// </summary>
		/// <returns></returns>
		public static List<string[]> ReadMods() {
			// If Updater.ini exists, let's use that path to read the stuff.
			string owd = Directory.GetCurrentDirectory();

            Directory.SetCurrentDirectory(V3LauncherCore.GetUpdaterINIDirectory());

            V3LauncherCore.AddDebugEntry($"CURRENT DIRECTORY: {Directory.GetCurrentDirectory()}");

			// Timer starts now!
			var startTime = DateTime.Now.Millisecond;

			// Read the user's MODS directory for ALL INI FILES.
			string[] files = Directory.GetFiles("DATA/MODS", "*.ini", SearchOption.AllDirectories);

			// This is the output list we'll give back:
			List<string[]> outArray = new List<string[]>();

			// Iterate through these files.
			foreach (string file in files) {
                V3LauncherCore.AddDebugEntry($"in dir, reading config file: {file}");

				IniFile iFile = new IniFile();

				if (file.ToLower().Contains(".ini") && !file.ToLower().Contains("folder.ini")) iFile.Load(file.ToLower());
				else continue;

				// Normalize slashes, split path, also figure out
				// what type of INI file this is.
				string currentINIFile = file.Replace("\\", "/").Split('/').Last().Replace("/", "").ToLower();
                V3LauncherCore.AddDebugEntry($"current INI file is {currentINIFile}");

				// What type of INI file is this?
				string modName, modAuthor, modType, modVersion, modDescription;
				switch (currentINIFile) {
					case "song.ini":
                        V3LauncherCore.AddDebugEntry("We found a song mod!");

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
                        V3LauncherCore.AddDebugEntry("We found a character mod!");

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
                        V3LauncherCore.AddDebugEntry("We found an instrument mod!");

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
                        V3LauncherCore.AddDebugEntry("We found a highway mod!");

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
                        V3LauncherCore.AddDebugEntry("We found a song category mod!");

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
                        V3LauncherCore.AddDebugEntry("We found a main menu music mod!");

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
                        V3LauncherCore.AddDebugEntry("We found a venue mod!");

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
                        V3LauncherCore.AddDebugEntry("We found a gem theme mod!");

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
                        V3LauncherCore.AddDebugEntry("We found a script mod!");

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
						break;
				}
				outArray.Add(new string[] { modName, modAuthor, modType, modVersion, modDescription, Path.Combine(Directory.GetCurrentDirectory(), file) });
			}

			// And the timer stops here!
			var endTime = DateTime.Now.Millisecond;

            V3LauncherCore.AddDebugEntry($"ALL DONE! Read and parsed {outArray.Count} mods in {(endTime - startTime).ToString("0.00")} sec");

			UserContentMods = outArray;

			// Reset our working directory if we changed it, then give the list back!
			Directory.SetCurrentDirectory(owd);
			return outArray;
		}

		/// <summary>
		///  Insert venue mods into the global array of zone names and prefixes.
		/// </summary>
		public static void AppendVenueMods(ComboBox[] cBoxList) {
			// This list will house our venue mods.
			List<string[]> venueMods = new List<string[]>();

			// We'll use the ACTUAL venue name in the VenueInfo section.
			IniFile file = new IniFile();

			string venueName = "", venuePrefix = "";
			foreach (var mod in UserContentMods) {
				// Is this a venue mod?
				if (mod[2] == "Venue") {
                    V3LauncherCore.AddDebugEntry("--------------------------\nVENUE MOD FOUND\n--------------------------");

                    V3LauncherCore.AddDebugEntry($"path being loaded: {mod[5]}");

                    // It is, let's get its name and zone prefix!
                    file.Load(mod[5]);

					venueName = file.Sections["VenueInfo"].Keys["Name"].Value;
					venuePrefix = file.Sections["VenueInfo"].Keys["PakPrefix"].Value;

					V3LauncherConstants.VenueIDs[0].Add($"Mod: {venueName}");
					V3LauncherConstants.VenueIDs[1].Add(venuePrefix);

					V3LauncherCore.AddDebugEntry($"-- MOD INFORMATION ADDED: --\nVenue name: {venueName}\nZone prefix: {venuePrefix}\n-- END INFO ADDED --");

					venueMods.Add(new string[] { $"Mod: {venueName}", venuePrefix });

					// Clear sections list, otherwise we get a bunch
					// of copies of the same venue.
					file.Sections.Clear();

					continue;
				}
			}

			if (venueMods.Count > 0) {
				foreach (var cBox in cBoxList) {
					foreach (var venueMod in venueMods) {
						cBox.Items.Add(venueMod[0]);
					}
				}
			}
		}

        /// <summary>
        ///  Insert gem mods into the global array of gem mod names and filenames.
        /// </summary>
        public static void AppendGemMods(ComboBox[] cBoxList) {
			// This list will house our gem mods.
			List<string[]> gemMods = new List<string[]>();

			// We'll use the ACTUAL name in the GemInfo section.
			IniFile file = new IniFile();

			string gemModName = "", gemNameValue = "";
			foreach (var mod in UserContentMods) {
				// Is this a gem mod?
				if (mod[2] == "Gem Theme") {
					V3LauncherCore.AddDebugEntry("--------------------------\nGEM THEME MOD FOUND\n--------------------------");

					V3LauncherCore.AddDebugEntry($"path being loaded: {mod[5]}");

					// It is, let's get its name and filename.
					file.Load(mod[5]);

					gemModName = file.Sections["GemInfo"].Keys["Name"].Value;
					gemNameValue = file.Sections["GemInfo"].Keys["Filename"].Value;

					V3LauncherConstants.NoteStyles[0].Add($"Mod: {gemModName}");
					V3LauncherConstants.NoteStyles[1].Add(gemNameValue);

					gemMods.Add(new string[] { $"Mod: {gemModName}", gemNameValue });

                    // Clear sections list, otherwise we get a bunch
                    // of copies of the same gem mod name.
                    file.Sections.Clear();

					continue;
                }
			}

			if (gemMods.Count > 0) {
				foreach (var cBox in cBoxList) {
					foreach (var gemMod in gemMods) {
						cBox.Items.Add(gemMod[0]);
					}
				}
			}
		}
	}
}
