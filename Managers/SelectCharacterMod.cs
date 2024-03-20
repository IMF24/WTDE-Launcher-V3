// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       C H A R A C T E R       M O D       S E L E C T O R
//
//    Dialog for selecting character mod folders.
// ----------------------------------------------------------------------------
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

namespace WTDE_Launcher_V3 {
    /// <summary>
    ///  Dialog for selecting character mod folders.
    /// </summary>
    public partial class SelectCharacterMod : Form {
        /// <summary>
        ///  Dialog for selecting character mod folders.
        /// </summary>
        /// <param name="inLabel"></param>
        public SelectCharacterMod(Control inLabel) {
            InitializeComponent();

            this.SourceLabel = inLabel;

            LoadCharacterMods();
        }

        public Control SourceLabel;

        public List<string> CharacterModFolderNames = new List<string>();

        public List<string> CharacterModPaths = new List<string>();

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
        /// </summary>
        public static List<string[][]> StockCharacterLists = new List<string[][]> {
            // We have 544 characters registered in the game...
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
                
            }
        };

        public void UpdateStockCharList() {
            // Empty the list out.
            StockCharactersList.Items.Clear();

            int arrayID = GameSortFilter.SelectedIndex;

            if (arrayID > StockCharacterLists.Count - 1) return;

            // Loop through the array, populate the list box!
            foreach (string[] characterInfo in StockCharacterLists[arrayID]) {
                StockCharactersList.Items.Add(characterInfo[0]);
            }
        }

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
    }
}
