// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       M O D       V I S U A L       E D I T O R
//
//    The Mod Manager's mod visual editor, allowing for a relatively simplistic
//    and friendly frontend for editing the configuration of a mod.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;
using WTDE_Launcher_V3.IO;

// Other required imports.
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
    ///  The Mod Manager's mod visual editor, allowing for a relatively simplistic
    ///  and friendly frontend for editing the configuration of a mod.
    /// </summary>
    public partial class ModVisualEditor : Form {
        /// <summary>
        ///  The Mod Manager's mod visual editor, allowing for a relatively simplistic
        ///  and friendly frontend for editing the configuration of a mod.
        /// </summary>
        /// <param name="modIniPath">
        ///  INI file path to the current mod.
        /// </param>
        /// <param name="modType">
        ///  Type constant for the type of mod being loaded.
        /// </param>
        public ModVisualEditor(string modIniPath, ModHandler.ModTypes modType) {
            // Initialize Designer support, do we really need to comment
            // on what this function does anymore?
            InitializeComponent();

            // These should NEVER get changed during the life
            // of this object!
            ModINIPath = modIniPath;
            CurrentModType = modType;

            // Add context for settings!
            AddSettingsOptions();

            // Determine editable tabs!
            DetermineEditableTabs();

            // Insert raw text into the raw text editor box.
            RawModINIText.Lines = File.ReadAllLines(ModINIPath);

            // Read base mod data.
            ReadModInfo();

            // Based on input mod type, read data!
            switch (CurrentModType) {
                case ModHandler.ModTypes.Song:
                    ReadSongConfig();
                    break;
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  INI file path to the mod loaded into the constructor. Cannot be altered.
        /// </summary>
        public string ModINIPath { get; }

        /// <summary>
        ///  Type of the mod loaded. Cannot be altered.
        /// </summary>
        public ModHandler.ModTypes CurrentModType { get; }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Determines the editable tabs for the loaded mod.
        /// </summary>
        public void DetermineEditableTabs() {
            // Mod info tab is always visible. So is the raw INI editor.
            ModInfoPage.Show();
            RawTextEditorPage.Show();

            // Now, based on our input mod type, we want to hide or show
            // certain tabs!
            switch (CurrentModType) {

                // --------------------------
                // SONG MOD 
                // --------------------------
                case ModHandler.ModTypes.Song:
                    MainConfigEditorTabs.TabPages.Remove(CategoryInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CharacterInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(InstrumentInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(HighwayInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(MenuMusicInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(GemInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(VenueInfoPage);
                    break;

                // --------------------------
                // SONG CATEGORY MOD 
                // --------------------------
                case ModHandler.ModTypes.Category:
                    MainConfigEditorTabs.TabPages.Remove(SongInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CharacterInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(InstrumentInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(HighwayInfoPage); 
                    MainConfigEditorTabs.TabPages.Remove(MenuMusicInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(GemInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(VenueInfoPage);
                    break;

                // --------------------------
                // CHARACTER MOD 
                // --------------------------
                case ModHandler.ModTypes.Character:
                    MainConfigEditorTabs.TabPages.Remove(SongInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CategoryInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(InstrumentInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(HighwayInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(MenuMusicInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(GemInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(VenueInfoPage);
                    break;

                // --------------------------
                // INSTRUMENT MOD 
                // --------------------------
                case ModHandler.ModTypes.Instrument:
                    MainConfigEditorTabs.TabPages.Remove(SongInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CategoryInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CharacterInfoPage);
                    InstrumentInfoPage.Show();
                    MainConfigEditorTabs.TabPages.Remove(HighwayInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(MenuMusicInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(GemInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(VenueInfoPage);
                    break;

                // --------------------------
                // HIGHWAY MOD 
                // --------------------------
                case ModHandler.ModTypes.Highway:
                    MainConfigEditorTabs.TabPages.Remove(SongInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CategoryInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CharacterInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(InstrumentInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(MenuMusicInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(GemInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(VenueInfoPage);
                    break;

                // --------------------------
                // MENU MUSIC MOD 
                // --------------------------
                case ModHandler.ModTypes.MenuMusic:
                    MainConfigEditorTabs.TabPages.Remove(SongInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CategoryInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CharacterInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(InstrumentInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(HighwayInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(GemInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(VenueInfoPage);
                    break;

                // --------------------------
                // GEM THEME MOD 
                // --------------------------
                case ModHandler.ModTypes.Gems:
                    MainConfigEditorTabs.TabPages.Remove(SongInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CategoryInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CharacterInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(InstrumentInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(HighwayInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(MenuMusicInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(VenueInfoPage);
                    break;

                // --------------------------
                // VENUE MOD 
                // --------------------------
                case ModHandler.ModTypes.Venue:
                    MainConfigEditorTabs.TabPages.Remove(SongInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CategoryInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CharacterInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(InstrumentInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(HighwayInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(MenuMusicInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(GemInfoPage);
                    break;

                // --------------------------
                // SCRIPT MOD / DEFAULT
                // --------------------------
                case ModHandler.ModTypes.Script: default:
                    MainConfigEditorTabs.TabPages.Remove(SongInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CategoryInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(CharacterInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(InstrumentInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(HighwayInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(MenuMusicInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(GemInfoPage);
                    MainConfigEditorTabs.TabPages.Remove(VenueInfoPage);
                    break;
            }
        }

        /// <summary>
        ///  Adds options for various settings!
        /// </summary>
        public void AddSettingsOptions() {

            // --------------------------
            // SONG MOD 
            // --------------------------

            // Game categories; for song info!
            SongInfoGameCategory.Items.AddRange(WTDEContentIDLists.StockCategoryList[0].ToArray());
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Read mod information only.
        /// </summary>
        public void ReadModInfo() {
            // Instantiate INI class.
            INI file = new INI(ModINIPath);

            // Read mod info!
            ModInfoName.Text = file.GetString("ModInfo", "Name", "");
            ModInfoDescription.Text = file.GetString("ModInfo", "Description", "");
            ModInfoAuthor.Text = file.GetString("ModInfo", "Author", "");
            ModInfoVersion.Text = file.GetString("ModInfo", "Version", "");
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Read the contents of a song mod's INI file into the editor!
        /// </summary>
        public void ReadSongConfig() {
            // Only on song mods!
            if (CurrentModType != ModHandler.ModTypes.Song) return;

            // Instantiate INI class.
            INI file = new INI(ModINIPath);

            // -------------------
            // BASIC OPTIONS
            // -------------------

            // Read checksum!
            SongInfoChecksum.Text = file.GetString("SongInfo", "Checksum", "unkChecksum");

            // Title, artist, and year!
            SongInfoTitle.Text = file.GetString("SongInfo", "Title", "Unknown Title");
            SongInfoArtist.Text = file.GetString("SongInfo", "Artist", "Unknown Artist");
            SongInfoYear.Value = file.GetInt("SongInfo", "Year", 2008);

            // Title, artist, and year!
            file.SetString("SongInfo", "Title", SongInfoTitle.Text);
            file.SetString("SongInfo", "Artist", SongInfoArtist.Text);
            file.SetInt("SongInfo", "Year", (int)SongInfoYear.Value);

            // Artist text!
            string[] artistTextSettingsLiteral = new string[] {
                "By",
                "From",
                "As made famous by"
            };
            string[] artistTextSettingsActual = new string[] {
                "artist_text_by",
                "artist_text_from",
                "artist_text_as_made_famous_by"
            };

            // Use our helper function to get the value to write!
            string artistTextSource = file.GetString("SongInfo", "ArtistText", "artist_text_by");
            string artistTextReadStr = Helpers.InterpretValue(artistTextSource, artistTextSettingsActual, artistTextSettingsLiteral);
            SongInfoArtistText.Text = artistTextReadStr;
        }

        /// <summary>
        ///  Save the contents of the song properties editor the disk!
        /// </summary>
        public void WriteSongConfig() {
            // Only on song mods!
            if (CurrentModType != ModHandler.ModTypes.Song) return;

            // Instantiate INI class.
            INI file = new INI(ModINIPath);

            // Now write all settings to the disk, one by one!

            // -------------------
            // BASIC OPTIONS
            // -------------------

            // Ignore checksum, we don't want to mess with it!

            // Title, artist, and year!
            file.SetString("SongInfo", "Title", SongInfoTitle.Text);            
            file.SetString("SongInfo", "Artist", SongInfoArtist.Text);          
            file.SetInt("SongInfo", "Year", (int) SongInfoYear.Value);          

            // Artist text!
            // Use these arrays to determine the value we want to save.
            string[] artistTextSettingsLiteral = new string[] {
                "By",
                "From",
                "As made famous by"
            };
            string[] artistTextSettingsActual = new string[] {
                "artist_text_by",
                "artist_text_from",
                "artist_text_as_made_famous_by"
            };

            // Use our helper function to get the value to write!
            string artistTextSource = SongInfoArtistText.Text;
            string artistTextSaveStr = Helpers.InterpretValue(artistTextSource, artistTextSettingsLiteral, artistTextSettingsActual);
            file.SetString("SongInfo", "ArtistText", artistTextSaveStr);

            // Cover artist setting, saved as an INVERSE value!
            file.SetBool("SongInfo", "OriginalArtist", !SongInfoOriginalArtist.Checked);

            // If we had a cover set, we want to save the information!
            if (SongInfoOriginalArtist.Checked) {

                // Cover artist's name!
                string coverArtistText = SongInfoCoverArtist.Text.Trim();
                if (coverArtistText != "") {
                    file.SetString("SongInfo", "CoverArtist", coverArtistText);
                }

                // Year of the cover!
                file.SetInt("SongInfo", "CoverYear", (int) SongInfoCoverYear.Value);
            }

            // -------------------
            // SETLIST CONTROL
            // -------------------

            // Game category and icon!
            //~ string actualCategoryChecksum = Helpers.InterpretValue();
            file.SetString("SongInfo", "GameCategory", SongInfoGameCategory.Text);
            file.SetString("SongInfo", "GameIcon", SongInfoGameIcon.Text);

            // Need a 2x bass icon?
            file.SetBool("SongInfo", "HasDoubleBass", SongInfoHasDoubleBass.Checked);

            // Hide in setlist?
            file.SetBool("SongInfo", "HideInSetlistG", SongInfoHideInSetlistG.Checked);
            file.SetBool("SongInfo", "HideInSetlistB", SongInfoHideInSetlistB.Checked);
            file.SetBool("SongInfo", "HideInSetlistD", SongInfoHideInSetlistD.Checked);
            file.SetBool("SongInfo", "HideInSetlistV", SongInfoHideInSetlistV.Checked);
            file.SetBool("SongInfo", "HideInSetlistA", SongInfoHideInSetlistA.Checked);

            // Career sort indices!
            file.SetInt("SongInfo", "CareerSortIndexG", (int) SongInfoCareerSortIndexG.Value);
            file.SetInt("SongInfo", "CareerSortIndexB", (int) SongInfoCareerSortIndexB.Value);
            file.SetInt("SongInfo", "CareerSortIndexD", (int) SongInfoCareerSortIndexD.Value);
            file.SetInt("SongInfo", "CareerSortIndexV", (int) SongInfoCareerSortIndexV.Value);
            file.SetInt("SongInfo", "CareerSortIndexA", (int) SongInfoCareerSortIndexA.Value);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Save the contents of the character properties editor to the disk!
        /// </summary>
        public void WriteCharacterConfig() {
            // Only on character mods!
            if (CurrentModType != ModHandler.ModTypes.Character) return;

            // Do real code here later
        }
    }
}
