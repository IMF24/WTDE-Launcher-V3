// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       M O D       H A N D L E R
//
//    Main logic class for reading the user's mods folder.
// ----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MadMilkman.Ini;

namespace WTDE_Launcher_V3 {
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
		/// <returns></returns>
		public static List<string[]> ReadMods() {
			// If Updater.ini exists, let's use that path to read the stuff.
			string owd = Directory.GetCurrentDirectory();

			Directory.SetCurrentDirectory(V3LauncherCore.GetUpdaterINIDirectory());

			V3LauncherCore.AddDebugEntry($"CURRENT DIRECTORY: {Directory.GetCurrentDirectory()}", "Mod Handler: ReadMods");

			// Timer starts now!
			var startTime = DateTime.Now.Second;

			// Read the user's MODS directory for ALL INI FILES.
			string[] files = Directory.GetFiles("DATA/MODS", "*.ini", SearchOption.AllDirectories);

			// This is the output list we'll give back:
			List<string[]> outArray = new List<string[]>();

			// Iterate through these files.
			foreach (string file in files) {
				V3LauncherCore.AddDebugEntry($"in dir, reading config file: {file}", "Mod Handler: ReadMods");

				IniFile iFile = new IniFile();

				if (file.ToLower().Contains(".ini") && !file.ToLower().Contains("folder.ini")) iFile.Load(file.ToLower());
				else continue;

				// Normalize slashes, split path, also figure out
				// what type of INI file this is.
				string currentINIFile = file.Replace("\\", "/").Split('/').Last().Replace("/", "").ToLower();
				V3LauncherCore.AddDebugEntry($"current INI file is {currentINIFile}", "Mod Handler: ReadMods");

				// What type of INI file is this?
				string modName, modAuthor, modType, modVersion, modDescription;
				switch (currentINIFile) {
					case "song.ini":
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
						break;
				}
				outArray.Add(new string[] { modName, modAuthor, modType, modVersion, modDescription, Path.Combine(Directory.GetCurrentDirectory(), file), Path.GetDirectoryName(file) });
			}

			// And the timer stops here!
			var endTime = DateTime.Now.Second;

			V3LauncherCore.AddDebugEntry($"ALL DONE! Read and parsed {outArray.Count} mods in {(endTime - startTime).ToString("0.00")} sec", "Mod Handler: ReadMods");

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

			// Now let's do some searching!
			List<string[]> outMods = new List<string[]>();
			foreach (string[] mod in UserContentMods) {
				if (mod[2] == modTypeToFind) {
					outMods.Add(mod);
				}
			}

			// And let's give the list back when we're done!
			return outMods;
		}

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

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
					V3LauncherCore.AddDebugEntry("--------------------------\nVENUE MOD FOUND\n--------------------------", "Mod Handler: AppendVenueMods");

					V3LauncherCore.AddDebugEntry($"path being loaded: {mod[5]}", "Mod Handler: AppendVenueMods");

					// It is, let's get its name and zone prefix!
					file.Load(mod[5]);

					venueName = file.Sections["VenueInfo"].Keys["Name"].Value;
					venuePrefix = file.Sections["VenueInfo"].Keys["PakPrefix"].Value;

					V3LauncherConstants.VenueIDs[0].Add($"Mod: {venueName}");
					V3LauncherConstants.VenueIDs[1].Add(venuePrefix);

					V3LauncherCore.AddDebugEntry($"-- MOD INFORMATION ADDED: --\nVenue name: {venueName}\nZone prefix: {venuePrefix}\n-- END INFO ADDED --", "Mod Handler: AppendVenueMods");

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
					V3LauncherCore.AddDebugEntry("--------------------------\nGEM THEME MOD FOUND\n--------------------------", "Mod Handler: AppendGemMods");

					V3LauncherCore.AddDebugEntry($"path being loaded: {mod[5]}", "Mod Handler: AppendGemMods");

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
