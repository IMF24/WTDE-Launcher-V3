// ----------------------------------------------------------------------------
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
        ///  Where is GHWTDEInput.ini located?
        /// </summary>
        public static string WTDEInputConfigDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/My Games/Guitar Hero World Tour Definitive Edition/GHWTDEInput.ini";

        /// <summary>
        ///  Where is GHWTDE.sav located?
        /// </summary>
        public static string WTDESaveDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/My Games/Guitar Hero World Tour Definitive Edition/GHWTDE.sav";

        /// <summary>
        ///  Where are the user's save file backups located?
        /// </summary>
        public static string WTDESaveBackupsDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/My Games/Guitar Hero World Tour Definitive Edition/Save Backups";

        /// <summary>
        ///  Where are the user's Rock Star Creator character files located?
        /// </summary>
        public static string WTDEProfilesDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/My Games/Guitar Hero World Tour Definitive Edition/Profiles";

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
        ///  These messages are used when the holiday is Valentine's Day.
        /// </summary>
        public static string[] RandomWindowTitlesVD = {
            "Happy Valentine's Day!",
            "I don't need a bullet, but thank you",
            "Hopefully the tears don't fall this month",
            "Will you be the voice of my band?",
            "You're the right kind of sinner to release my inner fantasy",
        };

        /// <summary>
        ///  Random window titles that will show in the title bar on startup.
        ///  These messages are used when the holiday is April Fools Day.
        /// </summary>
        public static string[] RandomWindowTitlesAF = {
            "Happy April Fools Day!",
            "This launcher will self destruct in 5 minutes...",
            "A minimum payment of $99.99 is required in order to continue playing GHWT: DX",
            "You have reached the end of your GHWT: DX Premium Rocker subscription trial period",
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
                "None",
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
                "",
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
        ///  List of language names.
        /// </summary>
        public static string[][] Languages = new string[][] {
            // Language names.
            new string[] {
                "English",
                "Spanish (Español)",
                "Italian (Italiano)",
                "French (Français)",
                "German (Deutsch)",
                "Japanese (日本語)",
                "Korean (한국어)"
            },

            // Language IDs.
            new string[] { 
                "en",
                "es",
                "it",
                "fr",
                "de",
                "ja",
                "ko"
            }
        };

        /// <summary>
        ///  List of holiday themes.
        /// </summary>
        public static string[][] HolidayThemes = new string[][] { 
            // Holiday names.
            new string[] {
                "Auto (Based on Date)",
                "Valentine's Day Theme",
                "April Fools Day Theme",
                "Halloween Theme",
                "Christmas Theme",
                "No Holidays"
            },

            // Holiday IDs.
            new string[] { 
                "",
                "valentine",
                "aprilfools",
                "halloween",
                "xmas",
                "none"
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
        ///  Private InputKeySelector object.
        /// </summary>
        private static InputKeySelector IKS = new InputKeySelector();

        /// <summary>
        ///  List of keyboard keys, their internal Aspyr numerical IDs, and their key button objects.
        /// </summary>
        public static List<object[]> AspyrKeyBinds = new List<object[]> {
            new object[] { "999", "Esc", IKS.KeyEsc },
            new object[] { "237", "F1", IKS.KeyF1 },
            new object[] { "238", "F2", IKS.KeyF2 },
            new object[] { "239", "F3", IKS.KeyF3 },
            new object[] { "240", "F4", IKS.KeyF4 },
            new object[] { "241", "F5", IKS.KeyF5 },
            new object[] { "242", "F6", IKS.KeyF6 },
            new object[] { "243", "F7", IKS.KeyF7 },
            new object[] { "244", "F8", IKS.KeyF8 },
            new object[] { "245", "F9", IKS.KeyF9 },
            new object[] { "246", "F10", IKS.KeyF10 },
            new object[] { "247", "F11", IKS.KeyF11 },
            new object[] { "248", "F12", IKS.KeyF12 },
            new object[] { "321", "PrScr", IKS.KeyPrintScreen },
            new object[] { "314", "ScrLck", IKS.KeyScrollLock },
            new object[] { "298", "Pause", IKS.KeyPauseBreak },
            new object[] { "253", "~", IKS.KeyGrave },
            new object[] { "200", "0", IKS.KeyNum0 },
            new object[] { "201", "1", IKS.KeyNum1 },
            new object[] { "202", "2", IKS.KeyNum2 },
            new object[] { "203", "3", IKS.KeyNum3 },
            new object[] { "204", "4", IKS.KeyNum4 },
            new object[] { "205", "5", IKS.KeyNum5 },
            new object[] { "206", "6", IKS.KeyNum6 },
            new object[] { "207", "7", IKS.KeyNum7 },
            new object[] { "208", "8", IKS.KeyNum8 },
            new object[] { "209", "9", IKS.KeyNum9 },
            new object[] { "219", "BckSpc", IKS.KeyBackspace },
            new object[] { "235", "Accent", IKS.KeyGrave },
            new object[] { "257", "Ins", IKS.KeyInsert },
            new object[] { "229", "Del", IKS.KeyDelete },
            new object[] { "255", "Home", IKS.KeyHome },
            new object[] { "233", "End", IKS.KeyEnd },
            new object[] { "303", "PgUp", IKS.KeyPageUp },
            new object[] { "278", "PgDn", IKS.KeyPageDown },
            new object[] { "281", "NumLck", IKS.KeyNumLock },
            new object[] { "282", "Num0", IKS.KeyNumPad0 },
            new object[] { "283", "Num1", IKS.KeyNumPad1 },
            new object[] { "284", "Num2", IKS.KeyNumPad2 },
            new object[] { "285", "Num3", IKS.KeyNumPad3 },
            new object[] { "286", "Num4", IKS.KeyNumPad4 },
            new object[] { "287", "Num5", IKS.KeyNumPad5 },
            new object[] { "288", "Num6", IKS.KeyNumPad6 },
            new object[] { "289", "Num7", IKS.KeyNumPad7 },
            new object[] { "290", "Num8", IKS.KeyNumPad8 },
            new object[] { "291", "Num9", IKS.KeyNumPad9 },
            new object[] { "213", "Num+", IKS.KeyNumPadPlus },
            new object[] { "320", "Num-", IKS.KeyNumPadMinus },
            new object[] { "274", "Num*", IKS.KeyNumStar },
            new object[] { "230", "Num/", IKS.KeyNumSlash },
            new object[] { "293", "NumEnt", IKS.KeyNumPadReturn },
            new object[] { "228", "NumDel", IKS.KeyNumPadDot },
            new object[] { "323", "Tab", IKS.KeyTab },
            new object[] { "304", "Q", IKS.KeyQ },
            new object[] { "331", "W", IKS.KeyW },
            new object[] { "232", "E", IKS.KeyE },
            new object[] { "305", "R", IKS.KeyR },
            new object[] { "322", "T", IKS.KeyT },
            new object[] { "341", "Y", IKS.KeyY },
            new object[] { "324", "U", IKS.KeyU },
            new object[] { "256", "I", IKS.KeyI },
            new object[] { "295", "O", IKS.KeyO },
            new object[] { "297", "P", IKS.KeyP },
            new object[] { "263", "[", IKS.KeyLeftBracket },
            new object[] { "306", "]", IKS.KeyRightBracket },
            new object[] { "220", "\\", IKS.KeyBackslash },
            new object[] { "273", "-", IKS.KeyRowMinus },
            new object[] { "234", "=", IKS.KeyEquals },
            new object[] { "223", "Caps", IKS.KeyCapsLock },
            new object[] { "210", "A", IKS.KeyA },
            new object[] { "313", "S", IKS.KeyS },
            new object[] { "227", "D", IKS.KeyD },
            new object[] { "236", "F", IKS.KeyF },
            new object[] { "252", "G", IKS.KeyG },
            new object[] { "254", "H", IKS.KeyH },
            new object[] { "258", "J", IKS.KeyJ },
            new object[] { "259", "K", IKS.KeyK },
            new object[] { "262", "L", IKS.KeyL },
            new object[] { "345", ";", IKS.KeyColon },
            new object[] { "214", "'", IKS.KeyQuote },
            new object[] { "308", "Enter", IKS.KeyEnter },
            new object[] { "267", "LShift", IKS.KeyLShift },
            new object[] { "343", "Z", IKS.KeyZ },
            new object[] { "340", "X", IKS.KeyX },
            new object[] { "221", "C", IKS.KeyC },
            new object[] { "328", "V", IKS.KeyV },
            new object[] { "218", "B", IKS.KeyB },
            new object[] { "330", "B", IKS.KeyB },
            new object[] { "277", "N", IKS.KeyN },
            new object[] { "269", "M", IKS.KeyM },
            new object[] { "225", ",", IKS.KeyComma },
            new object[] { "299", ".", IKS.KeyPeriod },
            new object[] { "316", "?", IKS.KeyQuestion },
            new object[] { "311", "RShift", IKS.KeyRShift },
            new object[] { "264", "LCtrl", IKS.KeyLCtrl },
            new object[] { "266", "LAlt", IKS.KeyLAlt },
            new object[] { "318", "Space", IKS.KeySpace },
            new object[] { "310", "RAlt", IKS.KeyRAlt },
            new object[] { "307", "RCtrl", IKS.KeyRCtrl },
            new object[] { "327", "Up", IKS.KeyUpArrow },
            new object[] { "231", "Down", IKS.KeyDownArrow },
            new object[] { "265", "Left", IKS.KeyLeftArrow },
            new object[] { "309", "Right", IKS.KeyRightArrow },
            new object[] { "400", "LMB", IKS.KeyLMB },
            new object[] { "401", "RMB", IKS.KeyRMB },
            new object[] { "402", "MMB", IKS.KeyMMB }
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

        /// <summary>
        ///  List of note styles.
        /// </summary>
        public static List<List<string>> NoteStyles = new List<List<string>> {
            // Note style names.
            new List<string> {
                "GH: World Tour (Default)",
                "Guitar Hero III",
                "Guitar Hero: Warriors of Rock",
                "Flat Notes"
            },

            // Note style IDs.
            new List<string> {
                "ghwt",
                "gh3",
                "ghwor",
                "flat"
            }
        };

        /// <summary>
        ///  List of note theme colors.
        /// </summary>
        public static string[][] NoteThemeColors = new string[][] {
            // Theme color names.
            new string[] {
                "Normal Color (Default)",
                "Pink",
                "Stealth",
                "Eggs 'N Bacon",
                "Old Glory",
                "Solid Gold",
                "Platinum",
                "Diabolic",
                "Toxic Waste",
                "Black",
                "Pastel",
                "Dark",
                "Outline",
                "GH1 Prototype",
                "Pure Green",
                "Pure Red",
                "Pure Yellow",
                "Pure Blue",
                "Pure Orange",
                "Candy Cane",
                "Ghoulish"
            },

            // Theme color IDs.
            new string[] {
                "standard_gems",
                "pink_gems",
                "stealth_gems",
                "Eggs_N_Bacon_gems",
                "old_glory_gems",
                "solid_gold_gems",
                "platinum_gems",
                "diabolic_gems",
                "toxic_waste_gems",
                "black_gems",
                "pastel_gems",
                "dark_gems",
                "outline_gems",
                "gh1proto_gems",
                "pure_green",
                "pure_red",
                "pure_yellow",
                "pure_blue",
                "pure_orange",
                "candy_cane",
                "halloween"
            }
        };

        /// <summary>
        ///  List of title card intro styles
        /// </summary>
        public static string[][] IntroStyles = new string[][] {
            // Intro style names.
            new string[] {
                "Normal GHWT (Default)",
                "Guitar Hero III",
                "Guitar Hero III (Left)",
                "Guitar Hero: Metallica",
                "Guitar Hero: Smash Hits",
                "Guitar Hero: Van Halen",
                "Guitar Hero 5",
                "Band Hero",
                "Guitar Hero: Warriors of Rock",
                "Auto (Based on Setlist)"
            },

            // Intro style IDs.
            new string[] {
                "ghwt",
                "gh3",
                "gh3_left",
                "ghm",
                "ghshits",
                "ghvh",
                "gh5",
                "bh",
                "ghwor",
                "auto"
            }
        };

        /// <summary>
        ///  List of load screen themes.
        /// </summary>
        public static string[][] LoadScreenThemes = new string[][] {
            // Load screen names.
            new string[] {
                "GHWT: DE (Default)",
                "Guitar Hero II",
                "Guitar Hero III",
                "Guitar Hero III (Console)",
                "Guitar Hero: Aerosmith",
                "Guitar Hero: World Tour",
                "Guitar Hero: Metallica",
                "Guitar Hero: Smash Hits",
                "Guitar Hero: Van Halen"
            },

            // Load screen IDs.
            new string[] {
                "wtde",
                "gh2",
                "gh3",
                "gh3_console",
                "gha",
                "ghwt",
                "ghm",
                "ghshits",
                "ghvh"
            }
        };

        /// <summary>
        ///  List of different HUD theme layouts.
        /// </summary>
        public static string[][] HUDThemes = new string[][] {
            // HUD theme names.
            new string[] {
                "GH: World Tour+ (Default)",
                "Guitar Hero: World Tour",
                "Guitar Hero: Metallica",
                "Guitar Hero: Smash Hits",
                "Guitar Hero: Van Halen"
            },

            // HUD theme IDs.
            new string[] { 
                "ghwt_plus",
                "ghwt",
                "ghm",
                "ghsh",
                "ghvh"
            }
        };

        /// <summary>
        ///  List of different "You Rock!" themes.
        /// </summary>
        public static string[][] YouRockThemes = new string[][] { 
            // You Rock theme names.
            new string[] {
                "GH: World Tour (Default)",
                "Guitar Hero: Metallica",
                "Guitar Hero: Smash Hits",
                "Guitar Hero: Van Halen"
            },

            // You Rock theme IDs.
            new string[] {
                "ghwt",
                "ghm",
                "ghshits",
                "ghvh"
            }
        };

        /// <summary>
        ///  List of pause menu themes.
        /// </summary>
        public static string[][] PauseMenuThemes = new string[][] {
            // Pause menu theme names.
            new string[] {
                "GH: World Tour (Default)",
                "Guitar Hero: Metallica",
                "Guitar Hero: Smash Hits",
                "Guitar Hero: Van Halen"
            },

            // Pause menu theme IDs.
            new string[] {
                "ghwt",
                "ghm",
                "ghshits",
                "ghvh"
            }
        };

        /// <summary>
        ///  List of user helper pill themes.
        /// </summary>
        public static string[][] HelperPillThemes = new string[][] {
            // Helper pill theme names.
            new string[] {
                "GHWT: DE (Default)",
                "Guitar Hero: World Tour",
                "Guitar Hero: World Tour (Beta)",
                "Guitar Hero: World Tour (Wii)",
                "GH: World Tour (Wii, HD)"
            },

            // Helper pill theme IDs.
            new string[] { 
                "wtde",
                "ghwt",
                "ghwt_beta",
                "ghwt_wii",
                "ghwt_wii_hd"
            }
        };

        /// <summary>
        ///  List of tap trail themes.
        /// </summary>
        public static string[][] TapTrailThemes = new string[][] {
            // Tap trail theme names.
            new string[] {
                "GH: World Tour (Default)",
                "Guitar Hero: Metallica",
                "No Tap Trail"
            },

            // Tap trail theme IDs.
            new string[] {
                "ghwt",
                "ghm",
                "none"
            }
        };
        
        /// <summary>
        ///  List of note hit flame themes.
        /// </summary>
        public static string[][] HitFlameStyles = new string[][] {
            // Flame theme names.
            new string[] {
                "GH: World Tour (Default)",
                "Guitar Hero II",
                "Guitar Hero: Warriors of Rock",
                "No Hit Flames"
            },

            // Flame theme IDs.
            new string[] {
                "ghwt",
                "gh2",
                "ghwor",
                "none"
            }
        };

        /// <summary>
        ///  List of time of day profiles/post processing FX.
        /// </summary>
        public static string[][] TODProfiles = new string[][] {
            // TOD profile names.
            new string[] { 
                "Retro (Default)",
                "Modern",
                "Black & White",
                "Psychadelic",
                "Dusty Orange",
                "Spooky"
            },

            // TOD profile IDs.
            new string[] { 
                "ghwt",
                "ghvh",
                "bw",
                "psych",
                "dustyorange",
                "spooky"
            }
        };

        /// <summary>
        ///  List of flare styles.
        /// </summary>
        public static string[][] FlareStyles = new string[][] { 
            // Flare style names.
            new string[] {
                "GHWT: DE (Default)",
                "Guitar Hero: World Tour",
                "Guitar Hero III",
                "No Flares"
            },

            // Flare style IDs.
            new string[] { 
                "wtde",
                "ghwt",
                "gh3",
                "none"
            }
        };
    }
}
