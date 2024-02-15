// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       S O N G       A N D       C A T E G O R Y       M A N A G E R
//          E D I T       S O N G       P R O P E R T I E S
//
//    The Mod Manager's song and song category mod manager's dialog for editing
//    the song properties of an existing song mod.
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
using MadMilkman.Ini;
using System.Runtime.Versioning;

namespace WTDE_Launcher_V3 {
    public partial class SCMSongProperties : Form {
        public List<string> CategoryNames = new List<string>() { 
            "GHWT: Definitive Edition",
            "Guitar Hero I",
            "Guitar Hero I (DLC)",
            "Guitar Hero II",
            "Guitar Hero II (DLC)",
            "Guitar Hero Encore: RT80s",
            "Guitar Hero Encore: RT80s (DLC)",
            "Guitar Hero III: LOR",
            "Guitar Hero III: LOR (DLC)",
            "Guitar Hero: Aerosmith",
            "Guitar Hero: Aerosmith (DLC)",
            "Guitar Hero: World Tour (DLC)",
            "Guitar Hero: Metallica",
            "Guitar Hero: Metallica (DLC)",
            "Guitar Hero: Smash Hits",
            "Guitar Hero: Smash Hits (DLC)",
            "Guitar Hero: Van Halen",
            "Guitar Hero: Van Halen (DLC)",
            "Guitar Hero 5",
            "Guitar Hero 5 (DLC)",
            "Band Hero",
            "Band Hero (DLC)",
            "Guitar Hero: Warriors of Rock",
            "Guitar Hero: Warriors of Rock (DLC)",
            "Guitar Hero: On Tour",
            "Guitar Hero: On Tour (DLC)",
            "Guitar Hero: On Tour: Decades",
            "Guitar Hero: On Tour: Decades (DLC)",
            "Guitar Hero: On Tour: Modern Hits",
            "Guitar Hero: On Tour: Modern Hits (DLC)",
            "DJ Hero",
            "DJ Hero (DLC)",
            "DJ Hero 2",
            "DJ Hero 2 (DLC)",
            "Tony Hawk's Pro Skater",
            "Tony Hawk's Pro Skater 2",
            "Tony Hawk's Pro Skater 3",
            "Tony Hawk's Pro Skater 4",
            "Tony Hawk's Underground",
            "Tony Hawk's Underground 2",
            "Tony Hawk's American Wasteland",
            "Tony Hawk's Proving Ground",
            "Tony Hawk's Project 8",
            "Spider-Man (2000)",
            "Apocalypse",
            "GUN"
        };

        public List<string> CategoryChecksums = new List<string>() { 
            "wtde",
            "gh1",
            "gh1dlc",
            "gh2",
            "gh2dlc",
            "gh80s",
            "gh80sdlc",
            "gh3",
            "gh3dlc",
            "gha",
            "ghadlc",
            "ghwtdlc",
            "ghm",
            "ghmdlc",
            "ghshits",
            "ghshitsdlc",
            "ghvh",
            "ghvhdlc",
            "gh5",
            "gh5dlc",
            "bh",
            "bhdlc",
            "ghwor",
            "ghwordlc",
            "ghot",
            "ghotdlc",
            "ghotd",
            "ghotddlc",
            "ghotmh",
            "ghotmhdlc",
            "djh",
            "djhdlc",
            "djh2",
            "djh2dlc",
            "thps",
            "thps2",
            "thps3",
            "thps4",
            "thug",
            "thug2",
            "thaw",
            "thpg",
            "thp8",
            "sm2000",
            "apocalypse",
            "gun"
        };

        public string GetSongProperty(string prop, string fallback) {
            string path = PathFolderLabel.Text;

            IniFile file = new IniFile();
            file.Load(path);

            if (file.Sections["SongInfo"].Keys.Contains(prop)) {
                return file.Sections["SongInfo"].Keys[prop].Value;
            }

            return fallback;
        }

        public void UpdateCoverControls() {
            CoverArtist.Enabled = !OriginalArtist.Checked;
            CoverYear.Enabled = !OriginalArtist.Checked;
        }

        public bool HasSectionKey(IniFile file, string section, string key) {
            return (file.Sections[section].Keys.Contains(key));
        }

        public void AddSectionKey(IniFile file, string section, string key) {
            if (!HasSectionKey(file, section, key)) {
                file.Sections[section].Keys.Add(key);
            }
        }

        public void ApplySongPropertyChanges(bool okButton = false) {
            string applyChangesConfirm = "Are you sure you want to apply all changes?";

            if (MessageBox.Show(applyChangesConfirm, "Apply Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string path = PathFolderLabel.Text;

                IniFile file = new IniFile();
                file.Load(path);

                // -- BASIC INFORMATION ------------------------
                file.Sections["SongInfo"].Keys["Title"].Value = SongTitle.Text;
                file.Sections["SongInfo"].Keys["Artist"].Value = SongArtist.Text;
                file.Sections["SongInfo"].Keys["Year"].Value = SongYear.Value.ToString();
                file.Sections["SongInfo"].Keys["ArtistText"].Value = INIFunctions.InterpretINISetting(SongArtistText.Text,
                    new string[] { "By", "From", "As made famous by" },
                    new string[] { "artist_text_by", "artist_text_from", "artist_text_as_made_famous_by" });

                // -- COVER INFORMATION ------------------------
                file.Sections["SongInfo"].Keys["OriginalArtist"].Value = (OriginalArtist.Checked) ? "1" : "0";
                
                if (!OriginalArtist.Checked) {
                    AddSectionKey(file, "SongInfo", "CoverArtist");
                    file.Sections["SongInfo"].Keys["CoverArtist"].Value = CoverArtist.Text;

                    AddSectionKey(file, "SongInfo", "CoverYear");
                    file.Sections["SongInfo"].Keys["CoverYear"].Value = CoverYear.Value.ToString();
                }

                // -- CHART SETTINGS ------------------------
                AddSectionKey(file, "SongInfo", "Volume");
                file.Sections["SongInfo"].Keys["Volume"].Value = SongVolume.Value.ToString();

                if (SongCents.Value != 0) {
                    AddSectionKey(file, "SongInfo", "Cents");
                    file.Sections["SongInfo"].Keys["Cents"].Value = SongCents.Value.ToString();
                }

                if (WhammyCutoff.Value != 0.5M) {
                    AddSectionKey(file, "SongInfo", "WhammyCutoff");
                    file.Sections["SongInfo"].Keys["WhammyCutoff"].Value = WhammyCutoff.Value.ToString();
                }

                AddSectionKey(file, "SongInfo", "Genre");
                file.Sections["SongInfo"].Keys["Genre"].Value = SongGenre.Text;

                AddSectionKey(file, "SongInfo", "Countoff");
                file.Sections["SongInfo"].Keys["Countoff"].Value = SongCountoff.Text;

                AddSectionKey(file, "SongInfo", "Drumkit");
                file.Sections["SongInfo"].Keys["Drumkit"].Value = INIFunctions.InterpretINISetting(SongDrumkit.Text,
                    new string[] { "Heavy Rock", "Classic Rock", "Modern Rock", "Fusion", "Hip Hop", "Blip Hop" },
                    new string[] { "heavyrock", "classicrock", "modernrock", "fusion", "hiphop", "bliphop" });

                // -- BAND MEMBERS ------------------------
                if (SongBand.Text != "") {
                    AddSectionKey(file, "SongInfo", "Band");
                    file.Sections["SongInfo"].Keys["Band"].Value = SongBand.Text;
                }

                file.Sections["SongInfo"].Keys["Singer"].Value = SongSinger.Text;

                if (UseNewClips.Checked || HasSectionKey(file, "SongInfo", "UseNewClips")) {
                    AddSectionKey(file, "SongInfo", "UseNewClips");
                    file.Sections["SongInfo"].Keys["UseNewClips"].Value = (UseNewClips.Checked) ? "1" : "0";
                }

                if (SkeletonTypeG.Text != "Default") {
                    AddSectionKey(file, "SongInfo", "SkeletonTypeG");
                    file.Sections["SongInfo"].Keys["SkeletonTypeG"].Value = SkeletonTypeG.Text;
                }

                if (SkeletonTypeB.Text != "Default") {
                    AddSectionKey(file, "SongInfo", "SkeletonTypeB");
                    file.Sections["SongInfo"].Keys["SkeletonTypeB"].Value = SkeletonTypeB.Text;
                }

                if (SkeletonTypeD.Text != "Default") {
                    AddSectionKey(file, "SongInfo", "SkeletonTypeD");
                    file.Sections["SongInfo"].Keys["SkeletonTypeD"].Value = SkeletonTypeD.Text;
                }

                if (SkeletonTypeV.Text != "Default") {
                    AddSectionKey(file, "SongInfo", "SkeletonTypeV");
                    file.Sections["SongInfo"].Keys["SkeletonTypeV"].Value = SkeletonTypeV.Text;
                }

                // -- CATEGORY SETTINGS ------------------------
                if (GameIcon.Text != "") {
                    AddSectionKey(file, "SongInfo", "GameIcon");
                    file.Sections["SongInfo"].Keys["GameIcon"].Value = GameIcon.Text;
                }

                string folderINIPath = Path.Combine(Path.GetDirectoryName(path), "../folder.ini");
                if ((GameCategory.Text != "GHWT: Definitive Edition" || HasSectionKey(file, "SongInfo", "GameCategory")) && !File.Exists(folderINIPath)) {
                    AddSectionKey(file, "SongInfo", "GameCategory");
                    file.Sections["SongInfo"].Keys["GameCategory"].Value = INIFunctions.InterpretINISetting(GameCategory.Text, CategoryNames.ToArray(), CategoryChecksums.ToArray());
                }

                // -- VENUE SETTINGS ------------------------
                if (ModernStrobes.Checked || HasSectionKey(file, "SongInfo", "ModernStrobes")) {
                    AddSectionKey(file, "SongInfo", "ModernStrobes");
                    file.Sections["SongInfo"].Keys["ModernStrobes"].Value = (ModernStrobes.Checked) ? "1" : "0";
                }

                file.Save(path);

                if (okButton) this.Close();
            }
        }

        public SCMSongProperties(string path, List<string> cateNames, List<string> cateChecksums) {
            InitializeComponent();

            foreach (string name in cateNames) {
                CategoryNames.Add(name);
            }

            foreach (string checksum in cateChecksums) {
                CategoryChecksums.Add(checksum);
            }

            PathFolderLabel.Text = Path.GetDirectoryName(path);

            // -- BASIC INFORMATION ------------------------
            SongTitle.Text = GetSongProperty("Title", "");
            SongArtist.Text = GetSongProperty("Artist", "");
            SongYear.Value = decimal.Parse(GetSongProperty("Year", "2000"));
            SongArtistText.Text = INIFunctions.InterpretINISetting(GetSongProperty("ArtistText", "artist_text_by"),
                new string[] { "artist_text_by", "artist_text_from", "artist_text_as_made_famous_by" },
                new string[] { "By", "From", "As made famous by" });

            // -- COVER INFORMATION ------------------------
            bool isOriginalArtist = (GetSongProperty("OriginalArist", "1") == "1");
            OriginalArtist.Checked = isOriginalArtist;

            CoverArtist.Text = GetSongProperty("CoverArtist", "");
            CoverArtist.Enabled = !isOriginalArtist;

            CoverYear.Value = decimal.Parse(GetSongProperty("CoverYear", "2000"));
            CoverYear.Enabled = !isOriginalArtist;

            // -- CHART SETTINGS ------------------------
            SongVolume.Value = decimal.Parse(GetSongProperty("Volume", "0.00"));
            SongCents.Value = decimal.Parse(GetSongProperty("Cents", "0"));
            WhammyCutoff.Value = decimal.Parse(GetSongProperty("WhammyCutoff", "0.50"));
            SongGenre.Text = GetSongProperty("Genre", "Rock");
            SongCountoff.Text = GetSongProperty("Countoff", "Hihat01");
            SongDrumkit.Text = INIFunctions.InterpretINISetting(GetSongProperty("Drumkit", "heavyrock"),
                new string[] { "heavyrock", "classicrock", "modernrock", "fusion", "hiphop", "bliphop" },
                new string[] { "Heavy Rock", "Classic Rock", "Modern Rock", "Fusion", "Hip Hop", "Blip Hop" });

            // -- BAND MEMBERS ------------------------
            SongBand.Text = GetSongProperty("Band", "");
            SongSinger.Text = GetSongProperty("Singer", "Male");
            UseNewClips.Checked = (GetSongProperty("UseNewClips", "") == "1");

            MicForGuitarist.Checked = (GetSongProperty("MicForGuitarist", "0") == "1");
            MicForBassist.Checked = (GetSongProperty("MicForBassist", "0") == "1");

            SkeletonTypeG.Text = GetSongProperty("SkeletonTypeG", "Default");
            SkeletonTypeB.Text = GetSongProperty("SkeletonTypeB", "Default");
            SkeletonTypeD.Text = GetSongProperty("SkeletonTypeD", "Default");
            SkeletonTypeV.Text = GetSongProperty("SkeletonTypeV", "Default");

            // -- CATEGORY SETTINGS ------------------------
            GameIcon.Text = GetSongProperty("GameIcon", "");
            string cateResult = "";
            if (GetSongProperty("GameCategory", "") == "") {
                string folderOnly = path.Replace("\\", "/").Replace("/song.ini", "");

                V3LauncherCore.DebugLog.Add($"Path looking for: {Path.Combine(folderOnly, "../folder.ini")}");

                if (File.Exists(Path.Combine(folderOnly, "../folder.ini"))) {
                    V3LauncherCore.DebugLog.Add("folder.ini did exist!");

                    IniFile file = new IniFile();
                    file.Load(Path.Combine(folderOnly, "../folder.ini"));

                    if (file.Sections.Contains("SongInfo") && file.Sections["SongInfo"].Keys.Contains("GameCategory")) {
                        cateResult = file.Sections["SongInfo"].Keys["GameCategory"].Value;
                    }
                } else {
                    cateResult = "";
                }
            } else cateResult = GetSongProperty("GameCategory", "");
            // Also import all category names into the dropdown list!
            foreach (string name in CategoryNames) {
                GameCategory.Items.Add(name);
            }
            GameCategory.Text = INIFunctions.InterpretINISetting(cateResult, CategoryChecksums.ToArray(), CategoryNames.ToArray());

            // -- VENUE SETTINGS ------------------------
            ModernStrobes.Checked = (GetSongProperty("ModernStrobes", "") == "1");

        }

        private void OriginalArtist_CheckedChanged(object sender, EventArgs e) {
            UpdateCoverControls();
        }
        private void OKButton_Click(object sender, EventArgs e) {
            ApplySongPropertyChanges(true);
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e) {
            ApplySongPropertyChanges();
        }
    }
}
