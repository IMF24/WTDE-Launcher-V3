// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       C O N S T A N T       V A R I A B L E S
//
//    Internal class of constants for the V3 launcher. Contains locations of
//    necessary config files, and other various constant variables.
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
    /// </summary>
    internal class V3LauncherConstants {
        /// <summary>
        ///  Version number of the program.
        /// </summary>
        public const string VERSION = "3.0";

        /// <summary>
        ///  Where is GHWTDE.ini located?
        /// </summary>
        public string WTDEConfigDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/GHWTDE.ini";

        /// <summary>
        ///  Where is AspyrConfig.xml located?
        /// </summary>
        public string AspyrConfigDir = $"{Environment.GetEnvironmentVariable("LOCALAPPDATA")}/Aspyr/Guitar Hero World Tour/AspyrConfig.xml";

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
            $"It's not {DateTime.Now.ToString("MM")}fest, it's Oktoberfest",
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
            "\"YOU DID NOT\" -Hex"
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
            "10... 9... 8... Oh wait, that's New Year's",
            "\"Baby, it's cold outside!\" Well... Not if you're in Australia",
            "It isn't a silent night in Times Square on 12/31",
            "12/24 is 1/2, simplify your fractions!",
            "I could use some hot chocolate right about now"
        };
    }
}
