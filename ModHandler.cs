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
		///  Iterate through the entire MODS directory and return a list of information about all file
		///  paths in that folder, including its mod name, author, version, type, description,
		///  and folder path.
		/// </summary>
		/// <returns></returns>
		public static List<string[]> ReadMods() {
			// If Updater.ini exists, let's use that path to read the stuff.
			string owd = Directory.GetCurrentDirectory();

			if (File.Exists("Updater.ini")) {
				IniFile uif = new IniFile();
				uif.Load("Updater.ini");

				Directory.SetCurrentDirectory(uif.Sections["Updater"].Keys["GameDirectory"].Value);
			}

			// Timer starts now!
			var startTime = DateTime.Now.Second;

			// Read the user's MODS directory for ALL INI FILES.
			string[] files = Directory.GetFiles("./DATA/MODS", "*.ini", SearchOption.AllDirectories);

			// This is the output list we'll give back:
			List<string[]> outArray = new List<string[]>();

			// Iterate through these files.
			foreach (string file in files) {
                Console.WriteLine($"in dir, reading config file: {file}");

				IniFile iFile = new IniFile();
				iFile.Load(file);

				// Normalize slashes, split path, also figure out
				// what type of INI file this is.
				string currentINIFile = file.Replace("\\", "/").Split('/').Last().Replace("/", "");
                Console.WriteLine($"current INI file is {currentINIFile}");

				// What type of INI file is this?
				string modName, modAuthor, modType, modVersion, modDescription, modPath;
				switch (currentINIFile) {
					case "song.ini":
                        Console.WriteLine("We found a song mod!");

						modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Song";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
                        break;

					case "character.ini":
                        Console.WriteLine("We found a character mod!");

                        modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Character";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					case "instrument.ini":
                        Console.WriteLine("We found an instrument mod!");

                        modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Instrument";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					case "highway.ini":
                        Console.WriteLine("We found a highway mod!");

                        modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Highway";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					case "category.ini":
                        Console.WriteLine("We found a song category mod!");

						modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Song Category";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					case "menumusic.ini":
                        Console.WriteLine("We found a main menu music mod!");

						modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Menu Music";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					case "venue.ini":
                        Console.WriteLine("We found a venue mod!");

                        modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Venue";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					case "gems.ini":
                        Console.WriteLine("We found a gem theme mod!");

						modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Gem Theme";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					case "Mod.ini":
                        Console.WriteLine("We found a script mod!");

						modName = iFile.Sections["ModInfo"].Keys["Name"].Value;
						modAuthor = iFile.Sections["ModInfo"].Keys["Author"].Value;
						modType = "Script";
						modVersion = iFile.Sections["ModInfo"].Keys["Version"].Value;
						modDescription = iFile.Sections["ModInfo"].Keys["Description"].Value;
						break;

					default:
						modName = "Unknown Mod";
						modAuthor = "Unknown Author";
						modType = "N/A";
						modVersion = "N/A";
						modDescription = "NO INFO";
						break;
				}
				modPath = file;
				outArray.Add(new string[] { modName, modAuthor, modType, modVersion, modDescription, modPath });
			}

			// And the timer stops here!
			var endTime = DateTime.Now.Second;

			Console.WriteLine($"ALL DONE! Read and parsed {outArray.Count} mods in {endTime - startTime} sec");

			// Reset our working directory if we changed it, then give the list back!
			Directory.SetCurrentDirectory(owd);
			return outArray;
		}

		/// <summary>
		///  Insert venue mods into the global array of zone names and prefixes.
		/// </summary>
		public static void AppendVenueMods() {
			// This list will house our venue mods.
			List<string[]> venueMods = new List<string[]>();

			// We'll use the ACTUAL venue name in the VenueInfo section.
			IniFile file = new IniFile();

			foreach (var mod in UserContentMods) {
				// Is this a venue mod?
				if (mod[2] == "Venue") {
					// It is, let's get its name and zone prefix!
					file.Load(mod[5]);

					string venueName = file.Sections["VenueInfo"].Keys["Name"].Value;
					string venuePrefix = file.Sections["VenueInfo"].Keys["PakPrefix"].Value;

					V3LauncherConstants.VenueIDs[0].Add($"Mod: {venueName}");
					V3LauncherConstants.VenueIDs[1].Add(venuePrefix);
				}
			}
		}
	}
}
