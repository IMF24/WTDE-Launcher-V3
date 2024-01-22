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

			UseUpdaterINIDirectory();

			// Timer starts now!
			var startTime = DateTime.Now.Millisecond;

			// Read the user's MODS directory for ALL INI FILES.
			string[] files = Directory.GetFiles("DATA/MODS", "*.ini", SearchOption.AllDirectories);

			// This is the output list we'll give back:
			List<string[]> outArray = new List<string[]>();

			// Iterate through these files.
			foreach (string file in files) {
                V3LauncherCore.DebugLog.Add($"in dir, reading config file: {file}");

				IniFile iFile = new IniFile();

				if (file.ToLower().Contains(".ini") && !file.ToLower().Contains("folder.ini")) iFile.Load(file.ToLower());
				else continue;

				// Normalize slashes, split path, also figure out
				// what type of INI file this is.
				string currentINIFile = file.Replace("\\", "/").Split('/').Last().Replace("/", "").ToLower();
                V3LauncherCore.DebugLog.Add($"current INI file is {currentINIFile}");

				// What type of INI file is this?
				string modName, modAuthor, modType, modVersion, modDescription;
				switch (currentINIFile) {
					case "song.ini":
                        V3LauncherCore.DebugLog.Add("We found a song mod!");

						modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Song";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
                        break;

					case "character.ini":
                        V3LauncherCore.DebugLog.Add("We found a character mod!");

                        modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Character";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					case "instrument.ini":
                        V3LauncherCore.DebugLog.Add("We found an instrument mod!");

                        modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Instrument";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					case "highway.ini":
                        V3LauncherCore.DebugLog.Add("We found a highway mod!");

                        modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Highway";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					case "category.ini":
                        V3LauncherCore.DebugLog.Add("We found a song category mod!");

						modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Song Category";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					case "menumusic.ini":
                        V3LauncherCore.DebugLog.Add("We found a main menu music mod!");

						modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Menu Music";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					case "venue.ini":
                        V3LauncherCore.DebugLog.Add("We found a venue mod!");

						try {
                            modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
                        } catch (Exception ex) {
							V3LauncherCore.DebugLog.Add($"Oops, no mod name! Thanks GHTools... {ex.Message}");
							modName = iFile.Sections["VenueInfo"].Keys["Name"].Value;

							V3LauncherCore.DebugLog.Add($"Mod Name (IS THIS EVEN RIGHT?!) {modName}");
						}
                        
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Venue";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					case "gems.ini":
                        V3LauncherCore.DebugLog.Add("We found a gem theme mod!");

						modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Gem Theme";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					case "Mod.ini":
					case "mod.ini":
                        V3LauncherCore.DebugLog.Add("We found a script mod!");

						modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Script";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					default:
						continue;
						break;
				}
				outArray.Add(new string[] { modName, modAuthor, modType, modVersion, modDescription, Path.Combine(Directory.GetCurrentDirectory(), file) });
			}

			// And the timer stops here!
			var endTime = DateTime.Now.Millisecond;

            V3LauncherCore.DebugLog.Add($"ALL DONE! Read and parsed {outArray.Count} mods in {(endTime - startTime).ToString("0.00")} sec");

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
                    V3LauncherCore.DebugLog.Add("--------------------------\nVENUE MOD FOUND\n--------------------------");

                    V3LauncherCore.DebugLog.Add($"path being loaded: {mod[5]}");

                    // It is, let's get its name and zone prefix!
                    file.Load(mod[5]);

					venueName = file.Sections["VenueInfo"].Keys["Name"].Value;
					venuePrefix = file.Sections["VenueInfo"].Keys["PakPrefix"].Value;

					V3LauncherConstants.VenueIDs[0].Add($"Mod: {venueName}");
					V3LauncherConstants.VenueIDs[1].Add(venuePrefix);

					V3LauncherCore.DebugLog.Add($"-- MOD INFORMATION ADDED: --\nVenue name: {venueName}\nZone prefix: {venuePrefix}\n-- END INFO ADDED --");

					venueMods.Add(new string[] { $"Mod: {venueName}", venuePrefix });

					// Clear sections list, otherwise we get a bunch
					// of copies of the same venue.
					file.Sections.Clear();

					continue;
				}
			}

			foreach (var cBox in cBoxList) {
				foreach (var venueMod in venueMods) {
					cBox.Items.Add(venueMod[0]);
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
					V3LauncherCore.DebugLog.Add("--------------------------\nGEM THEME MOD FOUND\n--------------------------");

					V3LauncherCore.DebugLog.Add($"path being loaded: {mod[5]}");

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

			foreach (var cBox in cBoxList) {
				foreach (var gemMod in gemMods) {
					cBox.Items.Add(gemMod[0]);
				}
			}
		}
	
		
	}
}
