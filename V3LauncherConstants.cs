﻿// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       C O N S T A N T       V A R I A B L E S
//
//    Internal class of constants for the V3 launcher. Contains locations of
//    necessary config files, and other various constant variables.
//
//    We primarily won't be changing these. If we do, we'll change anything at
//    start up, then leave them be from there on.
// ----------------------------------------------------------------------------
// Various imports. We might not need all these, but it's nice to have them.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDE_Launcher_V3 {
    /// <summary>
    ///  Internal class of global constants for the V3 launcher. Contains locations of
    ///  necessary config files, and other various constant variables.
    ///  <br/><br/>
    ///  We primarily won't be changing these. If we do, we'll change anything at
    ///  start up, then leave them be from there on.
    /// </summary>
    internal class V3LauncherConstants {
        /// <summary>
        ///  Version number of the program.
        /// </summary>
        public const string VERSION = "3.0";

        /// <summary>
        ///  Where is GHWTDE.ini located?
        /// </summary>
        public static string WTDEConfigDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/My Games/Guitar Hero World Tour Definitive Edition/GHWTDE.ini";

        /// <summary>
        ///  Where is GHWTDE.sav located?
        /// </summary>
        public static string WTDESaveDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/My Games/Guitar Hero World Tour Definitive Edition/GHWTDE.sav";

        /// <summary>
        ///  Where are the user's save file backups located?
        /// </summary>
        public static string WTDESaveBackupsDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/My Games/Guitar Hero World Tour Definitive Edition/Save Backups";

        /// <summary>
        ///  Where is AspyrConfig.xml located?
        /// </summary>
        public static string AspyrConfigDir = $"{Environment.GetEnvironmentVariable("LOCALAPPDATA")}/Aspyr/Guitar Hero World Tour/AspyrConfig.xml";

        /// <summary>
        ///  The MD5 hash list for all WTDE related files. File hashes on the disk get matched against these before being updated.
        /// </summary>
        public static string WTDEHashList = "https://gitgud.io/fretworks/ghwt-de-volatile/-/raw/master/GHWTDE/hashlist.dat";

        /// <summary>
        ///  Random window titles that will show in the title bar on startup.
        ///  These messages are used when there is no active holiday.
        /// </summary>
        public static string[] RandomWindowTitles = {
            "Third gen launcher is here!",
            "Writing debug.txt",
            "What's up, boss?",
            "Beep boop beep",
            "Not affiliated with Neversoft",
            "Avoiding CStruct crashes",
            "Applying gross hacks",
            "Eliminating path limits",
            "Making GHWT better!",
            "One update at a time",
            "Don't blow out the CPU buffer",
            "\"Two\" many menu music mods",
            "No, 00500FAB is not fab",
            "Now featuring functional online!",
            "Testing, testing, 1, 2, 3...",
            "QBC is better than ROQ",
            "WTDE is non-profit, but not 501(c)(3)",
            "\"AspyrConfig is hell\" -IMF24",
            "Rock Star Creator isn't for character mods",
            "Whoa, this thing is snazzy!",
            "IMF is busy head-banging against the wall",
            "The definitive experience",
            "You want mods? We got mods",
            "It wasn't IMF who made this all himself!",
            "Now with ∞% more CAR space!",
            "Making GHWT PC better since December 2021",
            "Remove MemInitHeap, save 600 MB of memory",
            "\"That's CArray, nice one\" -Zedek",
            "Now featuring Camera FOV Pulse from GH:M",
            "Don't forget to breathe",
            "The Discord exists, utilize it!",
            "\"based\" -Too many people to count",
            "\"Does he know?\"",
            "Who needs Spotify when you have WTDE?",
            "Infinitely better than CH",
            "YOU WILL UNINSTALL CLONE HERO",
            "WE HAVE HOPO/TAP CHORDS, GET RID OF CH NOW",
            "Includes less-than-perfect tap notes",
            "Please keep your stuff up to date, ok bye",
            "\"60 FPS is miles better than unlimited\" -IMF24",
            "Trying and failing to work",
            "Last time I checked, the New Year is not 2009",
            "The background's artist is infinitely underrated",
            "Working to work as intended",
            "ROQ: The Curse of NodeROQ",
            "Get your goodies on ghwt.de",
            "This launcher definitely took labor",
            "ROQ allowing syntax errors",
            "ROQ being ROQ, like always",
            "Make #roq-slander in the WTDE Discord already",
            "Never forget All Nightmare Long on Hard on GH3",
            "Band Hero 2 would have been cool",
            "Your \"average Joe\" couldn't afford a GH7 guitar",
            "\"Let's say by Day 9\", f**k",
            "\"Aw ffs not this again\" -Zedek",
            "1096 vs. 1100",
            "No, we can't read your CPU's instructions",
            "Viruses. Viruses in WTDE? False positives!",
            "Hello user, how are you doing?",
            "The launcher is indeed ready",
            "AI VOs on startup made by Derpytron84",
            "Be careful for what you wish for",
            "As polished as the launcher has ever been!",
            "INI is better than XML",
            "Limit 1,024 characters for character bios",
            "Free play really is free, it doesn't cost a dime",
            "No, your instruments are not infected",
            "\"Praise the other devs, not me!\" -IMF24",
            "How does one unlock these supposed hidden characters?",
            "Rendering in Cycles...",
            "Rendering in Eevee...",
            "iB and B are not the same",
            "There's secrets here... Can you find them?",
            "No, a CAR is not a vehicle",
            "There are secrets where options don't live",
            "Make #imf-slander real as well",
            "We don't redact things here, we tell it straight",
            "Is this launcher more stable? I hope so",
            "\"zedek sux lol\" -Dody",
            "\"u are the trash of the garbage\" (I swear, it's a joke, you aren't actually trash)",
            "Cry 4: Skill Issue Edition",
            "\"These suggestions feel like lorem ipsum text\" -IMF24",
            "\"A creative problem solver\" -- A chad: \"You didn't patch *this*\" -Oktoberfest",
            "\"literally 1984\" -Go cry about it",
            "\"Real or Based\" > \"Fax\"",
            "Top Class Chefs; they're a rare handful",
            "WE KNOW YOUR CONTROLLER WORKS IN CH",
            "Where's the KFC?",
            "Who eats waffles? Jimmy does",
            (DateTime.Now.Month == 10) ? "It's not--Oh wait, it is Oktoberfest!" : $"It's not {DateTime.Now.ToString("MMMM")}fest, it's Oktoberfest",
            "IMF is not the International Monetary Fund",
            "\"A PS2 ISO is not going to work, pal\" -Yopsito",
            "\"By using this pristine launcher you immediately become a Dodymensional being, put that to good use\" -Dody",
            "\"i truly apology for doing such things to said smurf, i apology\" -blu",
            "YOU WILL NOT PLAY WITH LOONA FROM HELLUVA BOSS",
            "Who said the pool was safe? No one did, unless you did",
            "If you don't play on The Sphinx or Cairo Bazaar you'll be hit with The Pharaoh's Curse",
            "\"Infinite front end? We don't do that here\" -M0D_Steam",
            "\"Infinite front end is infinitely stupid\" -WTB",
            "\"You can't spam your way through this engine, son\" -IMF24",
            "Lots of polish on this launcher... And not the language kind",
            "\"Also try Clone Hero (don't actually do that)\" -M0D_Steam",
            "\"infinite front end?, nah blud u buggin\" -blu",
            "\"No more front end copium for that skill issue!\" -WTB",
            "\"how's cheat central doing?\" -blu",
            "\"Have CARs? Ask Fox, you'll be stuck for hours hearing his OC's backstory\" -Fox",
            "Now featuring functional HOPO and tap chords!",
            "\"What?! It's me!--I'm in Guitar Hero, guys\" -DanRock",
            "\"YOU DID NOT\" -Hex",
        };

        /// <summary>
        ///  Random window titles that will show in the title bar on startup.
        ///  These messages are used when the holiday is Halloween.
        /// </summary>
        public static string[] RandomWindowTitlesHW = {
            "Happy Halloween!",
            "It is the spooky season now",
            "I hope we aren't smashing any pumpkins",
            "In the spirit of Halloween",
            "Kill the ghost that hides in your soul",
            "There is no spooky bunch here",
            "I don't see any spooky, scary skeletons around here",
            "The ghosts are out tonight"
        };

        /// <summary>
        ///  Random window titles that will show in the title bar on startup.
        ///  These messages are used when the holiday is Christmas.
        /// </summary>
        public static string[] RandomWindowTitlesXM = {
            "Merry Christmas!",
            "Happy Holidays!",
            "Season's Greetings",
            "Hot on Christmas Day and no snow? Where's my snow machine?",
            "Who was messing with the thermostat outside?",
            "\"Ho Ho Ho, We are Santa's elves\" - Uh... We WTDE devs aren't; oh wait, we kinda are",
            "Cold in the north... Hot in the south",
            "Cue the 1960s clay animations",
            "1964: Rudolph the Red-Nosed Reindeer",
            "1969: Frosty the Snowman",
            "1988: Die Hard",
            "10... 9... 8... Oh wait, that's New Year's",
            "\"Baby, it's cold outside!\" Well... Not if you're in the southern hemisphere",
            "It isn't a silent night in Times Square on 12/31",
            "12/24 is 1/2, simplify your fractions!",
            "I could use some hot chocolate right about now"
        };

        /// <summary>
        ///  List of venue names and zone prefixes. | Index 0: Zone names | Index 1: Zone PAK names/zone prefixes
        /// </summary>
        public static List<List<string>> VenueIDs = new List<List<string>>() {
            // Venue literal names
            new List<string>() {
                "WT: Phi Psi Kappa",
                "WT: Wilted Orchid",
                "WT: Bone Church",
                "WT: Pang Tang Bay",
                "WT: Amoeba Records",
                "WT: Tool",
                "WT: Swamp Shack",
                "WT: Rock Brigade",
                "WT: Strutter's Farm",
                "WT: House of Blues",
                "WT: Ted's Tiki Hut",
                "WT: Will Heilm's Keep",
                "WT: Recording Studio",
                "WT: AT&T Park",
                "WT: Tesla's Coil",
                "WT: Ozzfest",
                "WT: Times Square",
                "WT: Sunna's Chariot",
                "GHM: The Forum",
                "GHM: Tushino Air Field",
                "GHM: Hammersmith Apollo",
                "GHM: Damaged Justice Tour",
                "GHM: The Meadowlands",
                "GHM: Donington Park",
                "GHM: The Ice Cave",
                "GHM: Metallica Recording Studio",
                "GHM: Metallica Backstage",
                "SH: Amazon Rain Forest",
                "SH: The Grand Canyon",
                "SH: Polar Ice Cap",
                "SH: London Sewerage System",
                "SH: The Sphinx",
                "SH: The Great Wall of China",
                "SH: The Lost City of Atlantis",
                "SH: Quebec City",
                "VH: Los Angeles",
                "VH: West Hollywood",
                "VH: Rome",
                "VH: New York City",
                "VH: Berlin",
                "VH: Dallas",
                "VH: London",
                "VH: The Netherlands",
                "GH5: The 13th Rail",
                "GH5: Club Boson",
                "GH5: Sideshow",
                "GH5: O'Connell's Corner",
                "GH5: Guitarhenge",
                "GH5: Electric Honky Tonk",
                "GH5: Calavera Square",
                "GH5: Hypersphere",
                "BH: Mall of Fame Tour",
                "BH: Club La Noza",
                "BH: Summer Park Festival",
                "BH: Harajuku",
                "BH: Everpop Awards",
                "BH: AMP Orbiter",
                "III: Desert Rock Tour",
                "III: Lou's Inferno"
            },

            // Venue PAK names
            new List<string>() {
                "z_frathouse",
                "z_goth",
                "z_cathedral",
                "z_harbor",
                "z_recordstore",
                "z_tool",
                "z_bayou",
                "z_military",
                "z_fairgrounds",
                "z_hob",
                "z_hotel",
                "z_castle",
                "z_studio2",
                "z_ballpark",
                "z_scifi",
                "z_metalfest",
                "z_newyork",
                "z_credits",
                "z_forum",
                "z_tushino",
                "z_mop",
                "z_justice",
                "z_meadowlands",
                "z_donnington",
                "z_icecave",
                "z_soundcheckghm",
                "z_studio2ghm",
                "z_amazon",
                "z_canyon",
                "z_icecap",
                "z_london",
                "z_sphinx",
                "z_greatwall",
                "z_atlantis",
                "z_quebec",
                "z_la_block_party",
                "z_starwood",
                "z_rome",
                "z_s_stage",
                "z_paris",          // Note from IMF: Why the hell is Berlin named as z_paris?
                "z_drum_kit",
                "z_londonghvh",
                "z_frankenstrat",
                "z_subway",
                "z_lhc",
                "z_freakshow",
                "z_dublin",
                "z_carhenge",
                "z_nashville",
                "z_mexicocity",
                "z_hyperspherewt",
                "z_mall",
                "z_cabo",
                "z_centralpark",
                "z_tokyo",
                "z_awardshow",
                "z_space",
                "z_wikker",
                "z_hell"
            }
        };

        /// <summary>
        ///  List of instrument part names. Index 0 = Option names | Index 1 = Internal referents
        /// </summary>
        public static string[][] InstrumentPartNames = {
            new string[] { "Lead Guitar - PART GUITAR", "Bass Guitar - PART BASS", "Drums - PART DRUMS", "Vocals - PART VOCALS" },
            new string[] { "guitar", "bass", "drum", "vocals" }
        };

        /// <summary>
        ///  Default Quickplay options difficulties names. Index 0 = Option names | Index 1 = Internal referents
        /// </summary>
        public static string[][] DefaultQPODifficulties = {
            new string[] { "Beginner", "Easy", "Medium", "Hard", "Expert" },
            new string[] { "easy_rhythm", "easy", "normal", "hard", "expert" }
        };

        /// <summary>
        ///  List of keyboard keys and their internal Aspyr numerical IDs.
        /// </summary>
        public static string[][] AspyrKeyBinds = {
            new string[] { "999", "Esc" },
            new string[] { "237", "F1" },
            new string[] { "238", "F2" },
            new string[] { "239", "F3" },
            new string[] { "240", "F4" },
            new string[] { "241", "F5" },
            new string[] { "242", "F6" },
            new string[] { "243", "F7" },
            new string[] { "244", "F8" },
            new string[] { "245", "F9" },
            new string[] { "246", "F10" },
            new string[] { "247", "F11" },
            new string[] { "248", "F12" },
            new string[] { "321", "PrScr" },
            new string[] { "314", "ScrLck" },
            new string[] { "298", "Pause" },
            new string[] { "253", "~" },
            new string[] { "200", "0" },
            new string[] { "201", "1" },
            new string[] { "202", "2" },
            new string[] { "203", "3" },
            new string[] { "204", "4" },
            new string[] { "205", "5" },
            new string[] { "206", "6" },
            new string[] { "207", "7" },
            new string[] { "208", "8" },
            new string[] { "209", "9" },
            new string[] { "219", "BckSpc" },
            new string[] { "235", "Accent" },
            new string[] { "257", "Ins" },
            new string[] { "229", "Del" },
            new string[] { "255", "Home" },
            new string[] { "233", "End" },
            new string[] { "303", "PgUp" },
            new string[] { "278", "PgDn" },
            new string[] { "281", "NumLck" },
            new string[] { "282", "Num0" },
            new string[] { "283", "Num1" },
            new string[] { "284", "Num2" },
            new string[] { "285", "Num3" },
            new string[] { "286", "Num4" },
            new string[] { "287", "Num5" },
            new string[] { "288", "Num6" },
            new string[] { "289", "Num7" },
            new string[] { "290", "Num8" },
            new string[] { "291", "Num9" },
            new string[] { "213", "Num+" },
            new string[] { "320", "Num-" },
            new string[] { "274", "Num*" },
            new string[] { "230", "Num/" },
            new string[] { "293", "NumEnt" },
            new string[] { "228", "NumDel" },
            new string[] { "323", "Tab" },
            new string[] { "304", "Q" },
            new string[] { "331", "W" },
            new string[] { "232", "E" },
            new string[] { "305", "R" },
            new string[] { "322", "T" },
            new string[] { "341", "Y" },
            new string[] { "324", "U" },
            new string[] { "256", "I" },
            new string[] { "295", "O" },
            new string[] { "297", "P" },
            new string[] { "263", "[" },
            new string[] { "306", "]" },
            new string[] { "220", "\"" },
            new string[] { "273", "-" },
            new string[] { "234", "=" },
            new string[] { "223", "Caps" },
            new string[] { "210", "A" },
            new string[] { "313", "S" },
            new string[] { "227", "D" },
            new string[] { "236", "F" },
            new string[] { "252", "G" },
            new string[] { "254", "H" },
            new string[] { "258", "J" },
            new string[] { "259", "K" },
            new string[] { "262", "L" },
            new string[] { "345", ";" },
            new string[] { "214", "'" },
            new string[] { "308", "Enter" },
            new string[] { "267", "LShift" },
            new string[] { "343", "Z" },
            new string[] { "340", "X" },
            new string[] { "221", "C" },
            new string[] { "328", "V" },
            new string[] { "218", "B" },
            new string[] { "330", "B" },
            new string[] { "277", "N" },
            new string[] { "269", "M" },
            new string[] { "225", "," },
            new string[] { "299", "." },
            new string[] { "316", "?" },
            new string[] { "311", "RShift" },
            new string[] { "264", "LCtrl" },
            new string[] { "266", "LAlt" },
            new string[] { "318", "Space" },
            new string[] { "310", "RAlt" },
            new string[] { "307", "RCtrl" },
            new string[] { "327", "Up" },
            new string[] { "231", "Down" },
            new string[] { "265", "Left" },
            new string[] { "309", "Right" },
            new string[] { "400", "LMB" },
            new string[] { "401", "RMB" },
            new string[] { "402", "MMB" }
        };

        /// <summary>
        ///  The default mapping string for `Keyboard_Guitar` in AspyrConfig.xml. 
        /// </summary>
        public const string ASPYR_INPUT_GUITAR_DEFAULT = "GREEN 328 308 RED 221 YELLOW 340 BLUE 343 ORANGE 267 STAR 402 318 CANCEL 999 START 219 BACK 999 DOWN 231 400 UP 327 401 WHAMMY 310 LEFT 265 RIGHT 309 ";

        /// <summary>
        ///  The default mapping string for `Keyboard_Drum` in AspyrConfig.xml.
        /// </summary>
        public const string ASPYR_INPUT_DRUMS_BACKUP = "GREEN 308 262 259 258 254 RED 252 236 227 313 YELLOW 322 305 232 331 BLUE 295 256 324 341 ORANGE 999 KICK 318 CANCEL 999 START 219 BACK 999 DOWN 231 UP 327 WHAMMY 999 ";

        /// <summary>
        ///  The default mapping string for `Keyboard_Mic` in AspyrConfig.xml.
        /// </summary>
        public const string ASPYR_INPUT_MIC_BACKUP = "GREEN 328 308 402 318 RED 221 YELLOW 340 BLUE 343 ORANGE 267 234 218 CANCEL 999 START 219 BACK 999 DOWN 400 231 UP 401 327 MIC_VOL_DOWN 273 ";

        /// <summary>
        ///  The default mapping string for `Keyboard_Menu` in AspyrConfig.xml.
        /// </summary>
        public const string ASPYR_INPUT_MENU_BACKUP = "GREEN 308 328 RED 221 YELLOW 340 BLUE 343 ORANGE 267 CANCEL 999 START 219 BACK 402 311 DOWN 400 231 UP 401 327 WHAMMY 310 KICK 318 LEFT 265 RIGHT 309 ";

    }
}
