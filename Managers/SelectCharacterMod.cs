// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       C H A R A C T E R       S E L E C T O R
//
//    Dialog for selecting characters.
// ----------------------------------------------------------------------------
// V3 launcher imports.
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
    ///  Dialog for selecting characters.
    /// </summary>
    public partial class SelectCharacterMod : Form {
        /// <summary>
        ///  Dialog for selecting characters.
        /// </summary>
        /// <param name="inLabel"></param>
        public SelectCharacterMod(Control inLabel) {
            InitializeComponent();

            this.SourceLabel = inLabel;

            GameSortFilter.SelectedIndex = 0;
            LoadCharacterMods();
        }

        /// <summary>
        ///  What control do we want to hold the text output in?
        /// </summary>
        public Control SourceLabel;

        /// <summary>
        ///  The list of the character mod folder names, stripped of all path elements.
        /// </summary>
        public List<string> CharacterModFolderNames = new List<string>();

        /// <summary>
        ///  The list of folders that are validly detected character mods.
        /// </summary>
        public List<string> CharacterModPaths = new List<string>();

        /// <summary>
        ///  List of indices of character mods in the mods list.
        /// </summary>
        public List<int> CharacterModIndices = new List<int>();

        /// <summary>
        ///  List of all stock characters, sorted by category. In every sub-array, the arrays contained within are 2 items in length.
        ///  The first index is the literal name; the second index is the internal referent ID.
        ///  <br/>
        ///  For example, if we wanted GHWT Axel, we could refer to that as the following:
        ///  <br/>
        ///  <code>
        ///   string axelName = StockCharacterLists[0][0][0];
        ///   string axelID = StockCharacterLists[0][0][1];
        ///  </code>
        ///  By chaining index operators, we'll eventually wind up at the character name or ID we would like to use.
        ///  <br/><br/>
        ///  Here's a list of all characters seen in this list, organized by game:
        ///  <br/>
        ///  - Index 0: Guitar Hero: World Tour characters.
        ///  <br/>
        ///  - Index 1: Guitar Hero I characters.
        ///  <br/>
        ///  - Index 2: Guitar Hero II characters.
        ///  <br/>
        ///  - Index 3: Guitar Hero III characters.
        ///  <br/>
        ///  - Index 4: Guitar Hero: Aerosmith characters.
        ///  <br/>
        ///  - Index 5: Guitar Hero: On Tour characters.
        ///  <br/>
        ///  - Index 6: Band Hero (DS) characters.
        ///  <br/>
        ///  - Index 7: Guitar Hero: Metallica characters.
        ///  <br/>
        ///  - Index 8: Guitar Hero: Van Halen characters.
        ///  <br/>
        ///  - Index 9: Guitar Hero 5 characters.
        ///  <br/>
        ///  - Index 10: Band Hero characters.
        ///  <br/>
        ///  - Index 11: Guitar Hero: Warriors of Rock characters.
        ///  <br/>
        ///  - Index 12: DJ Hero 1 and 2 characters.
        ///  <br/>
        ///  - Index 13: GHWT: Definitive Edition characters.
        ///  <br/>
        ///  - Index 14: Tony Hawk series characters.
        ///  <br/>
        ///  - Index 15: Random characters.
        /// </summary>
        public static List<string[][]> StockCharacterLists = new List<string[][]> {
            // We have over 500 characters registered in the game...
            // All of you... You've made me do this.
            // Oh well, here we go...

            // -----------------------
            // GUITAR HERO: WORLD TOUR
            // -----------------------
            new string[][] {
                // -- NORMAL CHARACTERS
                new string[] { "WT: Axel Steel", "axel" },
                new string[] { "WT: Casey Lynch", "Casey" },
                new string[] { "WT: Izzy Sparks", "izzy" },
                new string[] { "WT: Judy Nails", "judy" },
                new string[] { "WT: Johnny Napalm", "johnny" },
                new string[] { "WT: Lars Umlaut", "lars" },
                new string[] { "WT: Midori", "midori" },
                new string[] { "WT: Clive Winston", "clive" },
                new string[] { "WT: Pandora", "pandora" },
                new string[] { "WT: Eddie Knox", "eddie" },
                new string[] { "WT: Drummer", "DRUMMER" },
                new string[] { "WT: Bassist", "BASSIST" },
                new string[] { "WT: Guitarist", "GUITARIST" },
                new string[] { "WT: Singer", "SINGER" },

                // -- SECRET CHARACTERS
                new string[] { "WT: Nick Arnold", "NickArnold" },
                new string[] { "WT: Aaron Steele", "Aaron Steele" },
                new string[] { "WT: Rina", "Rina" },
                new string[] { "WT: Skeleton", "skeleton" },
                new string[] { "WT: Rockubot", "Rockbot" },
                new string[] { "WT: Boneman", "BonemanFemaleRocker" },

                // -- MALE CROWD PEDS
                new string[] { "WT: Male Ped A, Skin 1", "GHWT_Ped_01" },
                new string[] { "WT: Male Ped A, Skin 2", "GHWT_Ped_01B" },
                new string[] { "WT: Male Ped A, Skin 3", "GHWT_Ped_01C" },
                new string[] { "WT: Male Ped B, Skin 1", "GHWT_Ped_02" },
                new string[] { "WT: Male Ped B, Skin 2", "GHWT_Ped_02B" },
                new string[] { "WT: Male Ped B, Skin 3", "GHWT_Ped_02C" },
                new string[] { "WT: Male Ped B, Recording Dude", "GHWT_Ped_02D" },

                // -- TALENT CHARACTERS
                new string[] { "WT: Jimi Hendrix", "Jimi" },
                new string[] { "WT: Hayley Williams", "Hayley" },
                new string[] { "WT: Hayley Williams (Decode)", "Hayley_Decode" },
                new string[] { "WT: Ted Nugent", "TedNugent" },
                new string[] { "WT: Travis Barker", "Travis" },
                new string[] { "WT: Sting", "Sting" },
                new string[] { "WT: Zakk Wylde", "ZakkWylde" },
                new string[] { "WT: Ozzy Osbourne", "Ozzy" },
                new string[] { "WT: Billy Corgan", "Billy" }
            },

            // -----------------------
            // GUITAR HERO I
            // -----------------------
            new string[][] {
                new string[] { "GH1: Axel Steel", "GH1_Axel" },
                new string[] { "GH1: Clive Winston", "GH1_Clive" },
                new string[] { "GH1: Izzy Sparks", "GH1_Izzy_Rocker" },
                new string[] { "GH1: Johnny Napalm", "GH1_Johnny_Rocker" },
                new string[] { "GH1: Xavier Stone", "GH1_Xavier" },
                new string[] { "GH1: Judy Nails", "GH1Judy" },
                new string[] { "GH1: Pandora", "GH1Pandora" },
                new string[] { "GH1: Male Singer", "GH1_MaleSinger" },
                new string[] { "GH1: Female Singer", "GH1_FemaleSinger" },
                new string[] { "GH1: Grim Ripper", "GH1GrimRocker" }
            },

            // -----------------------
            // GUITAR HERO II
            // -----------------------
            new string[][] {
                new string[] { "GH2: Axel Steel (Shirt)", "GH2Axel" },
                new string[] { "GH2: Axel Steel (Other Shirt)", "GH2AxelAlt" },
                new string[] { "GH2: Judy Nails (Skulls)", "GH2Judy" },
                new string[] { "GH2: Judy Nails (Snakes)", "GH2JudyAlt" },
                new string[] { "GH2: Pandora (Leathers)", "GH2PandoraRocker" },
                new string[] { "GH2: Pandora (Feathers)", "GH2_Pandora_2" },
                new string[] { "GH2: Izzy Sparks (Codpiece)", "GH2Izzy" },
                new string[] { "GH2: Izzy Sparks (Top Hat)", "GH2IzzyAlt" },
                new string[] { "GH2: Johnny Napalm (Mohawk)", "GH2Johnny" },
                new string[] { "GH2: Johnny Napalm (Liberty Spikes)", "GH2JohnnyAlt" },
                new string[] { "GH2: Xavier Stone", "GH2Xavier" },
                new string[] { "GH2: Grim Ripper", "GH2GrimRipperRocker" }
            },

            // -----------------------
            // GUITAR HERO III
            // -----------------------
            new string[][] {
                // -- AXEL STEEL OUTFITS
                new string[] { "GH3: Axel Steel (Black 'n Blue)", "GH3_Axel" },
                new string[] { "GH3: Axel Steel (Black 'n Red)", "GH3_Axel_2" },
                new string[] { "GH3: Axel Steel (Stonewashed)", "GH3_Axel_3" },
                new string[] { "GH3: Axel Steel (Red Leather)", "GH3_Axel_4" },
                new string[] { "GH3: Axel Steel (Black Vest)", "GH3_Axel_Alt_1" },
                new string[] { "GH3: Axel Steel (Brown Vest)", "GH3_Axel_Alt_2" },
                new string[] { "GH3: Axel Steel (White Vest)", "GH3_Axel_Alt_3" },
                new string[] { "GH3: Axel Steel (Stripes)", "GH3_Axel_Alt_4" },

                // -- CASEY LYNCH OUTFITS
                new string[] { "GH3: Casey Lynch (Basic Black)", "GH3Casey" },
                new string[] { "GH3: Casey Lynch (Silver 'N Black)", "GH3Casey2" },
                new string[] { "GH3: Casey Lynch (Crimson)", "GH3Casey3" },
                new string[] { "GH3: Casey Lynch (Camo)", "GH3Casey4" },
                new string[] { "GH3: Casey Lynch (Black 'N Red)", "GH3CaseyAlt" },
                new string[] { "GH3: Casey Lynch (Black 'N White)", "GH3CaseyAlt2" },
                new string[] { "GH3: Casey Lynch (Vast Purple)", "GH3CaseyAlt3" },
                new string[] { "GH3: Casey Lynch (Fiery)", "GH3CaseyAlt4" },

                // -- JUDY NAILS OUTFITS
                new string[] { "GH3: Judy Nails (Shocking Pink)", "GH3Judy" },
                new string[] { "GH3: Judy Nails (Tornado Blue)", "GH3Judy2" },
                new string[] { "GH3: Judy Nails (Jet Black)", "GH3Judy3" },
                new string[] { "GH3: Judy Nails (Flame Orange)", "GH3Judy4" },
                new string[] { "GH3: Judy Nails (Purple Plaid)", "GH3JudyAlt" },
                new string[] { "GH3: Judy Nails (Dirty Yellow)", "GH3JudyAlt2" },
                new string[] { "GH3: Judy Nails (Stripes)", "GH3JudyAlt3" },
                new string[] { "GH3: Judy Nails (Riot)", "GH3JudyAlt4" },
                
                // -- ELROY BUDVIS OUTFITS
                new string[] { "GH3: Elroy Budvis, Skin 1", "GH3Elroy1" },
                new string[] { "GH3: Elroy Budvis, Skin 2", "GH3Elroy2" },
                new string[] { "GH3: Elroy Budvis, Skin 3", "GH3Elroy3" },
                new string[] { "GH3: Elroy Budvis, Skin 4", "GH3Elroy4" },

                // -- IZZY SPARKS OUTFITS
                new string[] { "GH3: Izzy Sparks (Leopard)", "GH3Izzy" },
                new string[] { "GH3: Izzy Sparks (Lizard)", "GH3Izzy_2" },
                new string[] { "GH3: Izzy Sparks (Zebra)", "GH3Izzy_3" },
                new string[] { "GH3: Izzy Sparks (Menagerie)", "GH3Izzy_4" },
                new string[] { "GH3: Izzy Sparks (Fantasy)", "GH3IzzyAlt" },
                new string[] { "GH3: Izzy Sparks (Florid)", "GH3IzzyAlt_2" },
                new string[] { "GH3: Izzy Sparks (Starry Night)", "GH3IzzyAlt_3" },
                new string[] { "GH3: Izzy Sparks (Neon Knight)", "GH3IzzyAlt_4" },

                // -- JOHNNY NAPALM OUTFITS
                new string[] { "GH3: Johnny Napalm (Bloodshot)", "GH3Johnny" },
                new string[] { "GH3: Johnny Napalm (Pea Soup)", "GH3JohnnyPeaSoup" },
                new string[] { "GH3: Johnny Napalm (Spew)", "GH3JohnnySpew" },
                new string[] { "GH3: Johnny Napalm (Skeleton)", "GH3JohnnySkeleton" },
                new string[] { "GH3: Johnny Napalm (Spinach)", "GH3JohnnySpinach" },
                new string[] { "GH3: Johnny Napalm (Pumpkin)", "GH3JohnnyPumpkin" },
                new string[] { "GH3: Johnny Napalm (Two Tone)", "GH3JohnnyTwoTone" },
                new string[] { "GH3: Johnny Napalm (Eggplant)", "GH3JohnnyEggplant" },

                // -- XAVIER STONE OUTFITS
                new string[] { "GH3: Xavier Stone (Orchid)", "GH3_Xavier" },
                new string[] { "GH3: Xavier Stone (Tangerine)", "GH3_Xavier_2" },
                new string[] { "GH3: Xavier Stone (Azure)", "GH3_Xavier_3" },
                new string[] { "GH3: Xavier Stone (Emerald)", "GH3_Xavier_4" },
                new string[] { "GH3: Xavier Stone (John)", "GH3_Xavier_Alt" },
                new string[] { "GH3: Xavier Stone (Paul)", "GH3_Xavier_Alt_2" },
                new string[] { "GH3: Xavier Stone (George)", "GH3_Xavier_Alt_3" },
                new string[] { "GH3: Xavier Stone (Larry)", "GH3_Xavier_Alt_4" },

                // -- LARS UMLAUT OUTFITS
                new string[] { "GH3: Lars Umlaut (Dyed Black)", "GH3Lars" },
                new string[] { "GH3: Lars Umlaut (Bleach Blonde)", "GH3Lars_2" },
                new string[] { "GH3: Lars Umlaut (Phantom)", "GH3Lars_3" },
                new string[] { "GH3: Lars Umlaut (Sanguine)", "GH3Lars_4" },
                new string[] { "GH3: Lars Umlaut (Natural)", "GH3Lars_Alt" },
                new string[] { "GH3: Lars Umlaut (Barbaric)", "GH3Lars_Alt_2" },
                new string[] { "GH3: Lars Umlaut (Icy)", "GH3Lars_Alt_3" },
                new string[] { "GH3: Lars Umlaut (Freedom)", "GH3Lars_Alt_4" },

                // -- MIDORI OUTFITS
                new string[] { "GH3: Midori (Amethyst)", "GH3_Midori" },
                new string[] { "GH3: Midori (Ruby)", "GH3_Midori_2" },
                new string[] { "GH3: Midori (Candy)", "GH3_Midori_3" },
                new string[] { "GH3: Midori (Jade)", "GH3_Midori_4" },
                new string[] { "GH3: Midori (Emerald)", "GH3_Midori_Alt" },
                new string[] { "GH3: Midori (Aqua)", "GH3_Midori_Alt_2" },
                new string[] { "GH3: Midori (Maroon)", "GH3_Midori_Alt_3" },
                new string[] { "GH3: Midori (Cream)", "GH3_Midori_Alt_4" },

                // -- III TALENT CHARACTERS
                new string[] { "GH3: Tom Morello", "TomMorelloRocker" },
                new string[] { "GH3: Slash", "SlashRocker" },
                new string[] { "GH3: Slash (Modern Look)", "SlashCustomRocker" },

                // -- EXTRA ASSORTED CHARACTERS
                new string[] { "GH3: Grim Ripper", "GrimRipperRocker" },
                new string[] { "GH3: Lou", "Lou" },
                new string[] { "GH3: Thick Izzy", "Thick Izzy" },
                new string[] { "GH3: Female Singer", "GH3FemaleSinger" },
                new string[] { "GH3: Male Singer", "GH3MaleSinger_Rocker" },
                new string[] { "GH3: Bret Michaels", "GH3BretMichaels" },
                new string[] { "GH3: Metalhead", "GH3MetalheadRocker" },
                new string[] { "GH3: Metalhead (Marx)", "GH3MetalheadRocker_B" },
                new string[] { "GH3: Metalhead (Super-Atomic)", "GH3MetalheadRocker_C" },
                new string[] { "GH3: Metalhead (TV Head)", "GH3MetalheadRocker_D" },
                new string[] { "GH3: Metalhead (Gumball)", "GH3MetalheadRocker_E" },
                new string[] { "GH3: Metalhead (Mr. Pineal)", "GH3MetalheadRocker_F" },
                new string[] { "GH3: Metalhead (VV)", "GH3MetalheadRocker_G" },
                new string[] { "GH3: Bassist", "GH3 Bassist" },
                new string[] { "GH3: Drummer", "GH3 DRUMMER" },
                new string[] { "GH3: Skeleton", "GH3SkeletonRocker" },
                new string[] { "GH3: God of Rock", "GH3_GodofRock" },
                new string[] { "GH3: GoGo Dancer", "GH3_GogoDancer" },
                new string[] { "GH3: Devil Girl", "GH3_DevilGirl" }
            },

            // -----------------------
            // GUITAR HERO: AEROSMITH
            // -----------------------
            new string[][] {
                // -- AXEL STEEL OUTFITS
                new string[] { "GHA: Axel Steel (Camo Shirt)", "GHA_Axel_1" },
                new string[] { "GHA: Axel Steel (Skull Shirt)", "GHA_Axel_2" },
                new string[] { "GHA: Axel Steel (Flame Skull)", "GHA_Axel_3" },
                new string[] { "GHA: Axel Steel (Red Vest)", "GHA_Axel_Alt_1" },
                new string[] { "GHA: Axel Steel (Blue Vest)", "GHA_Axel_Alt_2" },
                new string[] { "GHA: Axel Steel (Green Vest)", "GHA_Axel_Alt_3" },

                // -- CASEY LYNCH OUTFITS
                new string[] { "GHA: Casey Lynch (Jeans)", "GHACasey_1" },
                new string[] { "GHA: Casey Lynch (Animal)", "GHACasey_2" },
                new string[] { "GHA: Casey Lynch (Red)", "GHACasey_3" },
                new string[] { "GHA: Casey Lynch (Red on Red)", "GHACaseyAlt_1" },
                new string[] { "GHA: Casey Lynch (Gray)", "GHACaseyAlt_2" },
                new string[] { "GHA: Casey Lynch (Purples)", "GHACaseyAlt_3" },

                // -- IZZY SPARKS OUTFITS
                new string[] { "GHA: Izzy Sparks (Bluebird)", "GHAIzzy_1" },
                new string[] { "GHA: Izzy Sparks (Sea Urchin)", "GHAIzzy_2" },
                new string[] { "GHA: Izzy Sparks (Viper)", "GHAIzzy_3" },
                new string[] { "GHA: Izzy Sparks (Cock 'O the Walk)", "GHAIzzyAlt_1" },
                new string[] { "GHA: Izzy Sparks (Magniloquent)", "GHAIzzyAlt_2" },
                new string[] { "GHA: Izzy Sparks (Grandiose)", "GHAIzzyAlt_3" },

                // -- JUDY NAILS OUTFITS
                new string[] { "GHA: Judy Nails (Fuschia)", "GHAJudy_1" },
                new string[] { "GHA: Judy Nails (Goblin)", "GHAJudy_2" },
                new string[] { "GHA: Judy Nails (Bruiser)", "GHAJudy_3" },
                new string[] { "GHA: Judy Nails (Stripe Socks)", "GHAJudyAlt_1" },
                new string[] { "GHA: Judy Nails (Disorder)", "GHAJudyAlt_2" },
                new string[] { "GHA: Judy Nails (Black and White)", "GHAJudyAlt_3" },

                // -- JOHNNY NAPALM OUTFITS
                new string[] { "GHA: Johnny Napalm (Mowed Lawn)", "GHAJohnnyMowedLawn" },
                new string[] { "GHA: Johnny Napalm (Oi)", "GHAJohnnyOi" },
                new string[] { "GHA: Johnny Napalm (Old School)", "GHAJohnnyOldSchool" },
                new string[] { "GHA: Johnny Napalm (Heliotrope)", "GHAJohnnyHeliotrope" },
                new string[] { "GHA: Johnny Napalm (Shorn)", "GHAJohnnyShorn" },
                new string[] { "GHA: Johnny Napalm (Skunk)", "GHAJohnnySkunk" },

                // -- LARS UMLAUT OUTFITS
                new string[] { "GHA: Lars Umlaut (Thunda)", "GHALars_1" },
                new string[] { "GHA: Lars Umlaut (Fishnet)", "GHALars_2" },
                new string[] { "GHA: Lars Umlaut (Icy Blue)", "GHALars_3" },
                new string[] { "GHA: Lars Umlaut (Visigoth)", "GHALars_Alt_1" },
                new string[] { "GHA: Lars Umlaut (Arctic)", "GHALars_Alt_2" },
                new string[] { "GHA: Lars Umlaut (Ninja)", "GHALars_Alt_3" },

                // -- MIDORI OUTFITS
                new string[] { "GHA: Midori (Apricot)", "GHA_Midori" },
                new string[] { "GHA: Midori (Leprechaun)", "GHA_Midori_2" },
                new string[] { "GHA: Midori (Tickled)", "GHA_Midori_3" },
                new string[] { "GHA: Midori (Flame Tips)", "GHA_Midori_Alt" },
                new string[] { "GHA: Midori (Orchid)", "GHA_Midori_Alt_2" },
                new string[] { "GHA: Midori (Blush)", "GHA_Midori_Alt_3" },

                // -- XAVIER STONE OUTFITS
                new string[] { "GHA: Xavier Stone (Bittersweet)", "GHA_Xavier_1" },
                new string[] { "GHA: Xavier Stone (Sapphire)", "GHA_Xavier_2" },
                new string[] { "GHA: Xavier Stone (Saffron)", "GHA_Xavier_3" },
                new string[] { "GHA: Xavier Stone (Davey)", "GHA_Xavier_Alt_1" },
                new string[] { "GHA: Xavier Stone (Mickey)", "GHA_Xavier_Alt_2" },
                new string[] { "GHA: Xavier Stone (Peter)", "GHA_Xavier_Alt_3" },

                // -- III:A TALENT CHARACTERS
                // -- STEVEN TYLER OUTFITS
                new string[] { "GHA: Steven Tyler", "StevenTyler" },
                new string[] { "GHA: Steven Tyler (Nipmuc High School)", "StevenTylerNipmuc" },
                new string[] { "GHA: Steven Tyler (Max's Kansas City)", "StevenTylerMaxKC" },
                new string[] { "GHA: Steven Tyler (Moscow/Nine Lives)", "StevenTylerNL" },
                new string[] { "GHA: Steven Tyler (The Orpheum)", "StevenTylerOrpheum" },
                new string[] { "GHA: Steven Tyler (Hall of Fame)", "StevenTylerHoF" },
                
                // -- JOE PERRY OUTFITS
                new string[] { "GHA: Joe Perry", "JoePerry" },
                new string[] { "GHA: Joe Perry (Talk Box)", "JoePerry_airbag" },
                new string[] { "GHA: Joe Perry (Nipmuc High School)", "JoePerry_nipmuc" },
                new string[] { "GHA: Joe Perry (Max's Kansas City)", "JoePerry_maxkc" },
                new string[] { "GHA: Joe Perry (The Orpheum)", "JoePerry_orpheum" },
                new string[] { "GHA: Joe Perry (Moscow/Nine Lives)", "JoePerry_ninelives" },
                new string[] { "GHA: Joe Perry (Half Time Show)", "JoePerry_jpplay" },

                // -- BRAD WHITFORD OUTFITS
                new string[] { "GHA: Brad Whitford", "GHA_Brad" },
                new string[] { "GHA: Brad Whitford (Nipmuc High School)", "GHA_Brad_nipmuc" },
                new string[] { "GHA: Brad Whitford (Max's Kansas City)", "GHA_Brad_maxkc" },
                new string[] { "GHA: Brad Whitford (The Orpheum)", "GHA_Brad_orpheum" },
                new string[] { "GHA: Brad Whitford (Moscow/Nine Lives)", "GHA_Brad_ninelives" },
                new string[] { "GHA: Brad Whitford (Half Time Show)", "GHA_Brad_jpplay" },

                // -- TOM HAMILTON OUTFITS
                new string[] { "GHA: Tom Hamilton", "GHA_Tom" },
                new string[] { "GHA: Tom Hamilton (Nipmuc High School)", "GHA_Tom_nipmuc" },
                new string[] { "GHA: Tom Hamilton (Max's Kansas City)", "GHA_Tom_maxkc" },
                new string[] { "GHA: Tom Hamilton (The Orpheum)", "GHA_Tom_orpheum" },
                new string[] { "GHA: Tom Hamilton (Moscow/Nine Lives)", "GHA_Tom_ninelives" },
                new string[] { "GHA: Tom Hamilton (Half Time Show)", "GHA_Tom_jpplay" },

                // -- JOEY KRAMER OUTFITS
                new string[] { "GHA: Joey Kramer", "GHA_Joey" },
                new string[] { "GHA: Joey Kramer (Nipmuc High School)", "GHA_Joey_nipmuc" },
                new string[] { "GHA: Joey Kramer (Max's Kansas City)", "GHA_Joey_maxkc" },
                new string[] { "GHA: Joey Kramer (The Orpheum)", "GHA_Joey_orpheum" },
                new string[] { "GHA: Joey Kramer (Moscow/Nine Lives)", "GHA_Joey_ninelives" },
                new string[] { "GHA: Joey Kramer (Half Time Show)", "GHA_Joey_jpplay" },

                // -- EXTRA TALENT CHARACTERS
                new string[] { "GHA: D.M.C.", "DMC" },

                // -- EXTRA ASSORTED CHARACTERS
                new string[] { "GHA: Violet (Rhythm Guitarist)", "GHAViolet" },
                new string[] { "GHA: Lou (Light Red)", "GHA_Lou_1" },
                new string[] { "GHA: Lou (Green)", "GHA_Lou_2" },
                new string[] { "GHA: Lou (Yellow)", "GHA_Lou_3" },
            },

            // -----------------------
            // GUITAR HERO: ON TOUR
            // -----------------------
            new string[][] {
                // -- PANDORA OUTFITS
                new string[] { "GHOT: Pandora, Skin 1", "GHOTPandoraRocker" },
                new string[] { "GHOT: Pandora, Skin 2", "GHOTPandoraRocker_2" },
                new string[] { "GHOT: Pandora, Skin 3", "GHOTPandoraRocker_3" },
                new string[] { "GHOT:MH: Pandora, Skin 4: Bad Girl", "GHOTPandoraRocker_4" },
                new string[] { "GHOT:MH: Pandora, Skin 5: Dark Goddess", "GHOTPandoraRocker_5" },
                new string[] { "GHOT:MH: Pandora, Skin 6: Gothic Lace", "GHOTPandoraRocker_6" },
                new string[] { "GHOT:MH: Pandora, Skin 7: Elegant Lace", "GHOTPandoraRocker_7" },
                new string[] { "GHOT:MH: Pandora, Skin 8: Stripes", "GHOTPandoraRocker_8" },
                new string[] { "GHOT:MH: Pandora, Skin 9: Minidress", "GHOTPandoraRocker_9" },

                // -- JUDY NAILS OUTFITS
                new string[] { "GHOT: Judy Nails", "GHOTJudyRocker" },
                new string[] { "GHOT: Judy Nails (Flashback)", "GHOTJudyRocker_Flashback" },
                new string[] { "GHOT: Judy Nails (Pirette)", "GHOTJudyRocker_Pirette" },

                // -- JOHNNY NAPALM OUTFITS
                new string[] { "GHOT: Johnny Napalm", "GHOTJohnny_Rocker" },

                // -- MEMPHIS ROSE OUTFITS
                new string[] { "GHOT: Memphis Rose", "GHOTMemphisRocker" },
                new string[] { "GHOT: Memphis Rose (Recruit)", "GHOTMemphisRocker_Recruit" },
                new string[] { "GHOT: Memphis Rose (Biker Gal)", "GHOTMemphisRocker_BikerGal" },

                // -- MIDORI OUTFITS
                new string[] { "GHOT:D: Midori", "GHOTMidoriRocker" },

                // -- EXTRA ASSORTED CHARACTERS
                new string[] { "GHOT: Male Singer", "GHOTMaleSinger_Rocker" },
            },

            // -----------------------
            // BAND HERO (DS)
            // -----------------------
            new string[][] {
                new string[] { "BHDS: Cthulhu", "BHDSCthulhu" },
            },

            // -----------------------
            // GUITAR HERO: METALLICA
            // -----------------------
            new string[][] {
                // -- NORMAL CHARACTERS
                new string[] { "GHM: Axel Steel", "GHM_axel" },
                new string[] { "GHM: Casey Lynch", "GHM_Casey" },
                new string[] { "GHM: Izzy Sparks", "izzy" },
                new string[] { "GHM: Judy Nails", "judy" },
                new string[] { "GHM: Johnny Napalm", "GHM_Johnny" },
                new string[] { "GHM: Lars Umlaut", "lars" },
                new string[] { "GHM: Midori", "GHM_Midori" },
                new string[] { "GHM: Clive Winston", "GHM_clive" },
                new string[] { "GHM: Pandora", "GHM_Pandora" },
                new string[] { "GHM: Eddie Knox", "GHM_eddie" },
                new string[] { "GHM: Drummer", "GHM_DRUMMER" },
                new string[] { "GHM: Bassist", "GHM_BASSIST" },
                new string[] { "GHM: Guitarist", "GHM_GUITARIST" },
                new string[] { "GHM: Singer", "GHM_SINGER" },

                // -- EXTRA ASSORTED CHARACTERS
                new string[] { "GHM: Fembot", "GHMFembotRocker" },
                
                // -- GHM TALENT CHARACTERS
                // -- LARS ULRICH OUTFITS
                new string[] { "GHM: Lars Ulrich", "GHM_Lars" },
                new string[] { "GHM: Lars Ulrich (Classic)", "GHM_Lars_80s" },
                new string[] { "GHM: Zombie Lars", "GHM_Lars_Zombie" },

                // -- KIRK HAMMETT OUTFITS
                new string[] { "GHM: Kirk Hammett", "GHM_Kirk" },
                new string[] { "GHM: Kirk Hammett (Classic)", "GHM_Kirk_80s" },
                new string[] { "GHM: Zombie Kirk", "GHM_Kirk_Zombie" },

                // -- JAMES HETFIELD OUTFITS
                new string[] { "GHM: James Hetfield", "GHM_James" },
                new string[] { "GHM: James Hetfield (Classic)", "GHM_James_80s" },
                new string[] { "GHM: Zombie James", "GHM_James_Zombie" },

                // -- ROBERT TRUJILLO OUTFITS
                new string[] { "GHM: Robert Trujillo", "GHM_Rob" },
                new string[] { "GHM: Robert Trujillo (Alternative)", "GHM_Rob_80s" },
                new string[] { "GHM: Zombie Rob", "GHM_Rob_Zombie" },

                // -- MISC. TALENT CHARACTERS
                new string[] { "GHM: Lemmy Kilmister", "GHMLemmy" },

                // -- KING DIAMOND OUTFITS
                new string[] { "GHM: King Diamond", "GHMKingDiamondRocker" },
                new string[] { "GHM: King Diamond (Uncensored)", "GHMKingDiamondRockerUncensored" },

                // -- ZACH HARMON OUTFITS
                new string[] { "GHM: Zach Harmon", "GHMZach" },
                new string[] { "GHM: Zach Harmon (Alternative)", "GHMZachAlt" },
            },

            // -----------------------
            // GUITAR HERO: VAN HALEN
            // -----------------------
            new string[][] {
                // -- VH TALENT CHARACTERS
                // -- ALEX VAN HALEN OUTFITS
                new string[] { "VH: Alex Van Halen, Skin 1", "GHVH_Alex" },
                new string[] { "VH: Alex Van Halen, Skin 2 (Classic)", "GHVH_Alex_Classic" },

                // -- DAVID LEE ROTH OUTFITS
                new string[] { "VH: David Lee Roth, Skin 1", "GHVH_David" },
                new string[] { "VH: David Lee Roth, Skin 2 (Classic)", "GHVH_David_Classic" },

                // -- EDDIE VAN HALEN OUTFITS
                new string[] { "VH: Eddie Van Halen, Skin 1", "GHVH_Eddie" },
                new string[] { "VH: Eddie Van Halen, Skin 2 (Classic)", "GHVH_Eddie_Classic" },

                // -- WOLFGANG VAN HALEN OUTFITS
                new string[] { "VH: Wolfgang Van Halen, Skin 1", "GHVH_Wolf" },
                new string[] { "VH: Wolfgang Van Halen, Skin 2 (Classic)", "GHVH_Wolf_Classic" },
            },

            // -----------------------
            // GUITAR HERO 5
            // -----------------------
            new string[][] {
                // -- AXEL STEEL OUTFITS
                new string[] { "GH5: Axel Steel (Stormbringer)", "GH5_Axel_1" },
                new string[] { "GH5: Axel Steel (Shoulder Blades)", "GH5_Axel_2" },
                new string[] { "GH5: Axel Steel (Hog Wild)", "GH5_Axel_3" },
                new string[] { "GH5: Axel Steel (Battle Scar)", "GH5_Axel_4" },

                // -- CASEY LYNCH OUTFITS
                new string[] { "GH5: Casey Lynch (Sharp Shooter)", "GH5Casey1" },
                new string[] { "GH5: Casey Lynch (Flying Trapeze)", "GH5Casey2" },
                new string[] { "GH5: Casey Lynch (Monochrome Maiden)", "GH5Casey3" },
                new string[] { "GH5: Casey Lynch (Daredevil)", "GH5Casey4" },

                // -- CLIVE WINSTON OUTFITS
                new string[] { "GH5: Clive Winston (Slick Rags)", "GH5_Clive_1" },
                new string[] { "GH5: Clive Winston (The Persuader)", "GH5_Clive_2" },
                new string[] { "GH5: Clive Winston (Sugar Daddy)", "GH5_Clive_3" },
                new string[] { "GH5: Clive Winston (Deer Scout)", "GH5_Clive_4" },

                // -- EDDIE KNOX OUTFITS
                new string[] { "GH5: Eddie Knox (On Lockdown)", "GH5_Eddie_1" },
                new string[] { "GH5: Eddie Knox (Casual Wednesday)", "GH5_Eddie_2" },
                new string[] { "GH5: Eddie Knox (Sueded Spade)", "GH5_Eddie_3" },
                new string[] { "GH5: Eddie Knox (The Cruiser)", "GH5_Eddie_4" },

                // -- IZZY SPARKS OUTFITS
                new string[] { "GH5: Izzy Sparks (Glam Tease)", "GH5_Izzy_1" },
                new string[] { "GH5: Izzy Sparks (The Impresario)", "GH5_Izzy_2" },
                new string[] { "GH5: Izzy Sparks (Stiki)", "GH5_Izzy_3" },
                new string[] { "GH5: Izzy Sparks (Sideshow)", "GH5_Izzy_4" },

                // -- JOHNNY NAPALM OUTFITS
                new string[] { "GH5: Johnny Napalm (Klobber)", "GH5_Johnny_1" },
                new string[] { "GH5: Johnny Napalm (Suburban Snot Punk)", "GH5_Johnny_2" },
                new string[] { "GH5: Johnny Napalm (Generation Zzyzx)", "GH5_Johnny_3" },
                new string[] { "GH5: Johnny Napalm (1976)", "GH5_Johnny_4" },

                // -- JUDY NAILS OUTFITS
                new string[] { "GH5: Judy Nails (Big Knee Pin)", "GH5Judy1" },
                new string[] { "GH5: Judy Nails (Mall Chic)", "GH5Judy2" },
                new string[] { "GH5: Judy Nails (Combat Girl)", "GH5Judy3" },
                new string[] { "GH5: Judy Nails (The Riot Starts Here)", "GH5Judy4" },

                // -- LARS UMLAUT OUTFITS
                new string[] { "GH5: Lars Umlaut (Tundra Beast)", "GH5_Lars_1" },
                new string[] { "GH5: Lars Umlaut (Grendel)", "GH5_Lars_2" },
                new string[] { "GH5: Lars Umlaut (Soldier of Faroe)", "GH5_Lars_3" },
                new string[] { "GH5: Lars Umlaut (Valhalla Battledress)", "GH5_Lars_4" },

                // -- PANDORA OUTFITS
                new string[] { "GH5: Pandora (Ringmistress)", "GH5Pandora1" },
                new string[] { "GH5: Pandora (Gretel)", "GH5Pandora2" },
                new string[] { "GH5: Pandora (Strapped)", "GH5Pandora3" },
                new string[] { "GH5: Pandora (State of Fluxus)", "GH5Pandora4" },

                // -- EXTRA ASSORTED CHARACTERS
                new string[] { "GH5: Golden God", "GH5_Silhouette_Gold" },

                // -- GH5 TALENT CHARACTERS
                new string[] { "GH5: Kurt Cobain", "GH5KurtCobain" },
                new string[] { "GH5: Matt Bellamy", "GH5MattBellamy" },
                new string[] { "GH5: Johnny Cash", "GH5JohnnyCash" },
                new string[] { "GH5: Shirley Manson", "GH5Shirley" },
                new string[] { "GH5: Carlos Santana", "GH5Santana" },
            },

            // -----------------------
            // BAND HERO
            // -----------------------
            new string[][] {
                // -- BH NORMAL CHARACTERS
                new string[] { "BH: Izzy Sparks", "BH_Izzy" },
                new string[] { "BH: Axel Steel", "BH_Axel" },
                new string[] { "BH: Johnny Napalm", "BH_Johnny" },
                new string[] { "BH: Clive Winston", "BH_Clive" },
                new string[] { "BH: Judy Nails", "BH_Judy" },
                new string[] { "BH: Eddie Knox", "BH_Eddie" },
                new string[] { "BH: Casey Lynch", "BH_Casey" },
                new string[] { "BH: Pandora", "BH_Pandora" },

                // -- MIDORI OUTFITS
                new string[] { "BH: Midori (Normal)", "BHMidori1" },
                new string[] { "BH: Midori (Kat Bella)", "BHMidori2" },
                new string[] { "BH: Midori (Nurse M)", "BHMidori3" },
                new string[] { "BH: Midori (Twenny Boper)", "BHMidori4" },

                // -- QUINCY STYLES OUTFITS
                new string[] { "BH: Quincy Styles (Normal)", "BH_Quincy_1" },
                new string[] { "BH: Quincy Styles (Spanish Harlem)", "BH_Quincy_2" },
                new string[] { "BH: Quincy Styles (Preep Skool Style)", "BH_Quincy_3" },
                new string[] { "BH: Quincy Styles (In the Key of Q)", "BH_Quincy_4" },

                // -- EXTRA ASSORTED CHARACTERS
                new string[] { "BH: Electrika Steel", "BandHeroVBot" },

                // -- BH TALENT CHARACTERS
                new string[] { "BH: Adam Levine", "BH_AdamLevine" },

                // -- NO DOUBT TALENT CHARACTERS
                new string[] { "BH: Taylor Swift", "TaylorSwift" },
                new string[] { "BH: Taylor Swift (Alt)", "TaylorSwiftAlt" },
                new string[] { "BH: Gwen Stefani, Skin 1", "GwenStefaniRocker" },
                new string[] { "BH: Gwen Stefani, Skin 2", "GwenStefaniRocker2" },
                new string[] { "BH: Tom Dumont", "BHTomDumont" },
                new string[] { "BH: Tony Kanal", "BHTonyKanal" },
                new string[] { "BH: Adrian Young", "BHAdrianyoung2" },
            },

            // -----------------------
            // GUITAR HERO: WARRIORS OF ROCK
            // -----------------------
            new string[][] {
                // -- NORMAL CHARACTERS + WARRIOR VARIANTS
                // -- CASEY LYNCH OUTFITS
                new string[] { "WOR: Casey Lynch (Normal)", "GHWoR_Casey" },
                new string[] { "WOR: Casey Lynch (Warrior)", "GHWoR_Casey_Warrior" },

                // -- PANDORA OUTFITS
                new string[] { "WOR: Pandora (Normal)", "GHWoRPandora" },
                new string[] { "WOR: Pandora (Warrior)", "GHWoRPandoraWarrior" },

                // -- JOHNNY NAPALM OUTFITS
                new string[] { "WOR: Johnny Napalm (Normal)", "GHWoR_Johnny" },
                new string[] { "WOR: Johnny Napalm (Warrior)", "GHWoR_JohnnyWarrior" },

                // -- LARS UMLAUT OUTFITS
                new string[] { "WOR: Lars Umlaut (Normal)", "GHWoR_Lars" },
                new string[] { "WOR: Lars Umlaut (Warrior)", "GHWoR_Lars_Warrior" },

                // -- AUSTIN TEJAS OUTFITS
                new string[] { "WOR: Austin Tejas (Normal)", "GHWoR_Austin" },
                new string[] { "WOR: Austin Tejas (Warrior)", "GHWoR_AustinWarrior" },

                // -- AXEL STEEL OUTFITS
                new string[] { "WOR: Axel Steel (Normal)", "GHWoR_Axel" },
                new string[] { "WOR: Axel Steel (Warrior)", "GHWoR_Axel_2" },

                // -- ECHO TESLA OUTFITS
                new string[] { "WOR: Echo Tesla (Normal)", "GHWoREchoTesla" },
                new string[] { "WOR: Echo Tesla (Warrior)", "GHWoREchoTeslaWarrior" },

                // -- JUDY NAILS OUTFITS
                new string[] { "WOR: Judy Nails (Normal)", "GHWoRJudy" },
                new string[] { "WOR: Judy Nails (Warrior A)", "GHWoRJudyWarrior" },
                new string[] { "WTDE: Judy Nails (Warrior B)", "GHWoRJudyWarrior2" },

                // -- EXTRA NORMAL CHARACTERS (NO WARRIOR)
                new string[] { "WOR: Clive Winston", "GHWoR_Clive" },
                new string[] { "WOR: Eddie Knox", "GHWoR_Eddie" },
                new string[] { "WOR: Izzy Sparks", "GHWoR_Izzy" },

                // -- OTHER WARRIOR TYPE CHARACTERS
                new string[] { "WOR: Arthas Menethil", "GHWoR_Arthas_Rocker" },
                new string[] { "WOR: Demigod of Rock", "GHWoR_DemiGod_of_Rock" },
                new string[] { "WOR: Minotaur", "GHWoR_Minotaur" },
            },

            // -----------------------
            // DJ HERO 1 & 2
            // -----------------------
            new string[][] {
                // -- DJH NORMAL CHARACTERS
                new string[] { "DJH: DJ AM", "DJH_DJ_AM" },
                new string[] { "DJH: DJ Shadow", "DJH_DJ_Shadow" },
                new string[] { "DJH: Candy Nova (Tight Fit)", "DJ Hero Candy Nova Tight Fit" },
                new string[] { "DJH: Candy Nova (Hot Socks)", "DJ Hero Candy Nova Hot Socks" },
                new string[] { "DJH: Candy Nova (Golden Angel)", "DJ Hero Candy Nova Golden Angel" },
                new string[] { "DJH: Candy Nova (Red Wing)", "DJ Hero Candy Nova Red Wing" },
                new string[] { "DJH: Mixy Trix (Hot Yellow)", "DJ Hero Mixy Trix Hot Yellow" },
                new string[] { "DJH: Mixy Trix (Hot Suit)", "DJ Hero Mixy Trix Hot Suit" },
                new string[] { "DJH: Mixy Trix (Fire Suit)", "DJ Hero Mixy Trix Fire Suit" },

                // -- DJH TALENT CHARACTERS
                new string[] { "DJH: Guy-Manuel de Homem-Christo", "DJH_DP_GuyManuel" },
                new string[] { "DJH: Thomas Bangalter", "DJH_DP_ThomasBangalter" },
            },

            // -----------------------
            // GHWT: DEFINITIVE EDITION
            // -----------------------
            new string[][] {
                new string[] { "WTDE: Buckethead", "Buckethead" },
                new string[] { "WTDE: Acai", "Acai" },
                new string[] { "WTDE: Zedek The Plague Doctor", "Zedek" },
                new string[] { "WTDE: Zen", "Zen" },
                new string[] { "WTDE: Spider-Man 2000: VBlack Cat", "BlackCat_Rocker" },
                new string[] { "WTDE: Spider-Man 2000: VCarnage", "Carnage_Rocker" },
                new string[] { "WTDE: Spider-Man 2000: Venom", "Venom_Rocker" },
                new string[] { "WTDE: Apocalypse: Trey Kincaid", "Apocalypse_Bruce" },
                new string[] { "WTDE: Gun: Colton White", "Gun_ColtonWhite" },
                new string[] { "WTDE: Kurt Cobain (Videoclip)", "GHDEKurt" },
                new string[] { "WTDE: Pandora (Mix)", "WTDEPandoraRocker" },
                new string[] { "WTDE: Marrow", "XRayRocker" },
                new string[] { "WTDE: Marrow (X-Ray)", "XRayRocker_XRay" },
                new string[] { "WTDE: Marrow (Glowstick)", "XRayRocker_Glowstick" },
                new string[] { "WTDE: BH2: Clive Winston (Lightstreaks)", "BH2_Clive_Rocker" },
            },

            // -----------------------
            // TONY HAWK SERIES
            // -----------------------
            new string[][] {
                // - - -   TONY  HAWK'S  PRO  SKATER   - - - //

                // -- TONY HAWK'S PRO SKATER 1
                new string[] { "THPS1: Tony Hawk", "THPS1Hawk_Rocker" },
                new string[] { "THPS1: Private Carrera", "THPS1PVTCarrera" },
                new string[] { "THPS1: Officer Tick", "THPS1Fatcop" },

                // -- TONY HAWK'S PRO SKATER 2
                new string[] { "THPS2: Spider-Man (Normal)", "THPS2SpiderMan" },
                new string[] { "THPS2: Spider-Man (Symbiote)", "THPS2SpiderMan_2" },
                new string[] { "THPS2: Spider-Man (Armored)", "THPS2SpiderMan_3" },
                new string[] { "THPS2: Spider-Man (Universe)", "THPS2SpiderMan_4" },

                // -- TONY HAWK'S PRO SKATER 3
                new string[] { "THPS3: Ollie the Magic Bum", "THPS3 Ollie The Magic Bum" },
                new string[] { "THPS3: Darth Maul", "THPS3 Darth Maul" },
                new string[] { "THPS3: Demoness", "THPS3 Demoness" },
                new string[] { "THPS3: Neversoft Guy", "THPS3 Neversoft Guy" },
                new string[] { "THPS3: Wolverine", "Wolverine_Rocker" },
                new string[] { "THPS3: Doom Guy", "DoomGuyRocker" },

                // -- TONY HAWK'S PRO SKATER 4
                new string[] { "THPS4: Eddie", "EddieMascotRocker" },
                new string[] { "THPS4: Jango Fett", "THPS4 Jango Fett" },
                new string[] { "THPS4: Fry Cook", "THPS4ChefBam" },

                // -- TH PRO SKATER 4: KISS TALENT CHARACTERS
                new string[] { "THPS4: Ace Frehley", "AceFrehley" },
                new string[] { "THPS4: Gene Simmons", "GeneSimmonsRocker" },
                new string[] { "THPS4: Paul Stanley", "PaulStanley" },
                new string[] { "THPS4: Peter Criss", "PeterCriss" },

                // - - -   TONY  HAWK'S  UNDERGROUND   - - - //

                // -- TONY HAWK'S UNDERGROUND 1
                new string[] { "THUG: Chad Muska", "THUGChadMuska" },
                new string[] { "THUG: Eric Sparrow", "THUGEricSparrow" },
                new string[] { "THUG: Iron Man", "THUG Iron Man" },
                new string[] { "THUG: T.H.U.D.", "THUGCreature" },

                // -- TONY HAWK'S UNDERGROUND 2
                new string[] { "THUG2: Tony Hawk", "THUG2Hawk_Rocker" },
                new string[] { "THUG2: Bam Margera", "THUG2BamMargera" },
                new string[] { "THUG2: Steve-O", "THUG2SteveO" },
                new string[] { "THUG2: Captain Price", "THUG2Price" },
                new string[] { "THUG2: Skaboto", "THUG2Skaboto" },
                new string[] { "THUG2: Shrek", "THUG2Shrek_Rocker" },
                new string[] { "THUG2: The Hand", "THUG2Hand" },
                new string[] { "THUG2: Bigfoot", "THUG2_Bigfoot" },
                new string[] { "THUG2: Ben Franklin", "THUG2BenFranklin" },
                new string[] { "THUG2: Jester", "THUG2Jester" },
                new string[] { "THUG2: Bullfighter", "THUG2Bullfighter" },
                new string[] { "THUG2: Phil Margera", "THUG2PhilMargera" },
                new string[] { "THUG2: Voodoo Doctor", "THUG2Voodoo" },
                new string[] { "THUG2: Aborigine", "THUG2Aborigine" },

                new string[] { "THUG2: Alien (Normal)", "THUG2AlienRocker" },
                new string[] { "THUG2: Alien (Leader)", "THUG2AlienLeaderRocker" },
                new string[] { "THUG2: Alien (Doctor)", "THUG2AlienDoctorRocker" },

                // -- THUG 2: REMIX
                new string[] { "THUG2:R: Voltraman", "THUG2R_Voltraman" },

                // - - -   TONY  HAWK'S  AMERICAN  WASTELAND   - - - //
                new string[] { "THAW: Billie Joe Armstrong", "THAW_BillieJoe_Rocker" },
                new string[] { "THAW: Robo-Tony", "THAWRobot" },
                new string[] { "THAW: Mindy", "THAW Mindy" },

                // - - -   TONY  HAWK'S  PROJECT  8   - - - //
                new string[] { "THP8: Travis Barker", "THP8TravisBarker" },
                new string[] { "THP8: Jason Lee", "THP8JasonLee" },
                new string[] { "THP8: Nerd", "THP8Nerd" },
                new string[] { "THP8: Beaver Mascot", "THP8Mascot" },
                new string[] { "THP8: Voodoo Doll", "THP8Voodoo" },
                new string[] { "THP8: Officer Dick (Zombified)", "THP8ZombieDick" },

                // - - -   TONY  HAWK'S  PROVING  GROUND   - - - //
                new string[] { "THPG: Bam Margera", "THPGBamMargera" },
                new string[] { "THPG: Eric Sparrow", "THPGEricSparrow" },
                new string[] { "THPG: Luchador", "THPGLuchador" },
            },

            // -----------------------
            // RANDOM CHARACTERS
            // -----------------------
            new string[][] {
                // -- RANDOM APPEARANCES 0-3
                new string[] { "Random Appearance 0", "RandomAppearance0" },
                new string[] { "Random Appearance 1", "RandomAppearance1" },
                new string[] { "Random Appearance 2", "RandomAppearance2" },
                new string[] { "Random Appearance 3", "RandomAppearance3" },

                // -- WORST MALE/FEMALE BAND MEMBERS
                new string[] { "Worst Male Guitarist", "WorstMaleGuitarist" },
                new string[] { "Worst Male Bassist", "WorstMaleBassist" },
                new string[] { "Worst Male Drummer", "WorstMaleDrummer" },
                new string[] { "Worst Male Vocalist", "WorstMaleVocalist" },

                new string[] { "Worst Female Guitarist", "WorstFemaleGuitarist" },
                new string[] { "Worst Female Bassist", "WorstFemaleBassist" },
                new string[] { "Worst Female Drummer", "WorstFemaleDrummer" },
                new string[] { "Worst Female Vocalist", "WorstFemaleVocalist" },

                // -- EMPTY GUY
                new string[] { "Empty Guy", "EmptyGuy" },
            }
        };

        /// <summary>
        ///  Update the stock venue character list on the left side when the dropdown menu sort option is changed.
        /// </summary>
        public void UpdateStockCharList() {
            // Empty the list out.
            StockCharactersList.Items.Clear();

            // What game array do we want to filter by?
            int arrayID = GameSortFilter.SelectedIndex;
            
            // Out of range? Don't go further!
            if (arrayID > StockCharacterLists.Count - 1) return;

            // Loop through the array, populate the list box!
            // Index 0 contains the literal, user-friendly names.
            foreach (string[] characterInfo in StockCharacterLists[arrayID]) {
                StockCharactersList.Items.Add(characterInfo[0]);
            }
        }

        /// <summary>
        ///  Loads all installed character mods into the right list box.
        /// </summary>
        public void LoadCharacterMods() {
            // Clear our list box out first.
            CharacterModsList.Items.Clear();

            // Let's get our character mods!
            List<string[]> characterMods = ModHandler.GetModsByType(ModHandler.ModTypes.Character);

            // If we had none, just abort.
            if (characterMods.Count < 0) {
                this.Close();
                return;
            }

            // Now we'll get them down to just folder names.
            // Also add the paths to the mod paths list.
            List<string> charModNames = new List<string>();
            List<string> charModPaths = new List<string>();
            foreach (string[] characterMod in characterMods) {
                // Nice mess of string operators on this...
                // But anyway, get our folder name.
                string folderName = characterMod[6].Replace('\\', '/').Split('/').Last().Trim('/');
                charModNames.Add(folderName);
                charModPaths.Add(characterMod[6]);
            }

            // Set the object fields too!
            CharacterModFolderNames = charModNames;
            CharacterModPaths = charModPaths;

            // Now let's populate our list!
            foreach (string name in CharacterModFolderNames) {
                CharacterModsList.Items.Add(name);
            }

            CharModsHeader.Text = $"Character Mods ({CharacterModsList.Items.Count}):";
        }

        private void OKButton_Click(object sender, EventArgs e) {
            if (CharacterModsList.SelectedItems.Count > 0) {
                string outName = CharacterModsList.SelectedItems[0].ToString();
                SourceLabel.Text = outName;

            } else if (StockCharactersList.SelectedItems.Count > 0) {

                int arrayID = GameSortFilter.SelectedIndex;
                string outName = StockCharactersList.SelectedItems[0].ToString();

                foreach (string[] characterInfo in StockCharacterLists[arrayID]) {
                    if (characterInfo[0] == outName) {
                        outName = characterInfo[1];
                    }
                }

                SourceLabel.Text = outName;
            }
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void RefreshCharModsButton_Click(object sender, EventArgs e) {
            LoadCharacterMods();
        }

        private void GameSortFilter_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateStockCharList();
        }

        private void StockCharactersList_SelectedIndexChanged(object sender, EventArgs e) {
            if (CharacterModsList.SelectedItems.Count > 0) {
                CharacterModsList.SelectedItems.Clear();
            }
        }

        private void CharacterModsList_SelectedIndexChanged(object sender, EventArgs e) {
            if (StockCharactersList.SelectedItems.Count > 0) {
                StockCharactersList.SelectedItems.Clear();
            }
        }

        public void WriteCharacterListFile() {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Character List File";
            sfd.Filter = "Text Files|*.txt|All Files|*.*";

            sfd.ShowDialog();

            // Do we have a file to save?
            if (sfd.FileName != "") {
                // List of game names!
                string[] gameNames = new string[] { 
                    "GUITAR HERO: WORLD TOUR",
                    "GUITAR HERO I",
                    "GUITAR HERO II",
                    "GUITAR HERO III: LEGENDS OF ROCK",
                    "GUITAR HERO: AEROSMITH",
                    "GUITAR HERO: ON TOUR SERIES",
                    "BAND HERO (DS)",
                    "GUITAR HERO: METALLICA",
                    "GUITAR HERO: VAN HALEN",
                    "GUITAR HERO 5",
                    "BAND HERO",
                    "GUITAR HERO: WARRIORS OF ROCK",
                    "DJ HERO 1 & 2",
                    "GHWT: DEFINITIVE EDITION",
                    "TONY HAWK SERIES",
                    "RANDOM CHARACTERS"
                };

                // Now let's begin writing some data!
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8)) {
                    // Header text stuff.
                    sw.WriteLine("// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    sw.WriteLine("// -------------------------------------------------------------");
                    sw.WriteLine("//  WORLD TOUR DE CHARACTER IDS");
                    sw.WriteLine($"//    List exported on {DateTime.Now} // Auto generated by WTDE Launcher V3");
                    sw.WriteLine("// -------------------------------------------------------------");
                    sw.WriteLine("// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

                    // Write the characters themselves!
                    int index = 0;
                    foreach (string gameName in gameNames) {
                        sw.WriteLine($"\n// -------------------------------\n// {gameName}\n// -------------------------------");
                        foreach (string[] characterInfo in StockCharacterLists[index]) {
                            sw.WriteLine("Name: " + characterInfo[0] + " // ID: " + characterInfo[1]);
                        }
                        index++;
                    }

                    // Do we have character mods installed?
                    // If so, let's write them too!
                    // We just want to write folder names, since that's both the name and ID.
                    if (CharacterModFolderNames.Count > 0) {
                        sw.WriteLine("\n// -------------------------------\n// INSTALLED MOD CHARACTERS\n// -------------------------------");

                        foreach (string mod in CharacterModFolderNames) {
                            sw.WriteLine(mod);
                        }
                    }
                }
            }
        }

        private void ExportCharListButton_Click(object sender, EventArgs e) {
            WriteCharacterListFile();
        }

        private void OpenCASManagerButton_Click(object sender, EventArgs e) {
            CARManager car = new CARManager();
            car.ShowDialog();
        }
    }
}
