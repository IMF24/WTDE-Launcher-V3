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

namespace WTDE_Launcher_V3 {
    public partial class CharacterModEditor : Form {

        public CharacterModEditor(string modDir) {
            InitializeComponent();
            this.ModPath = modDir;
            ImportCharModData();
            ModPathLabel.Text = Path.GetDirectoryName(this.ModPath);
        }

        /// <summary>
        ///  Folder path to the mod config we're currently editing!
        /// </summary>
        public string ModPath;

        /// <summary>
        ///  Read an INI field from the given mod config.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public string ReadINIField(string section, string key, string defaultVal = "") {
            IniOptions options = new IniOptions();
            options.CommentStarter = IniCommentStarter.Hash;
            IniFile file = new IniFile(options);
            file.Load(ModPath);

            if (file.Sections.Contains(section) && file.Sections[section].Keys.Contains(key)) {
                if (file.Sections[section].Keys[key].Value != null) return file.Sections[section].Keys[key].Value;
            } else {
                WriteINIField(section, key, defaultVal);
                return defaultVal;
            }

            return defaultVal;
        }
        
        /// <summary>
        ///  Write an INI field to the given mod config.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void WriteINIField(string section, string key, string value) { 
            IniFile file = new IniFile();
            file.Load(ModPath);

            if (!file.Sections.Contains(section)) file.Sections.Add(section);
            if (!file.Sections[section].Keys.Contains(key)) file.Sections[section].Keys.Add(key);
            file.Sections[section].Keys[key].Value = value;

            file.Save(ModPath);
        }

        /// <summary>
        ///  Read an INI file and import all data from it.
        /// </summary>
        public void ImportCharModData() {
            // -- MOD INFO
            ModInfoName.Text = ReadINIField("ModInfo", "Name");
            ModInfoDescription.Text = ReadINIField("ModInfo", "Description");
            ModInfoAuthor.Text = ReadINIField("ModInfo", "Author");
            ModInfoVersion.Text = ReadINIField("ModInfo", "Version");

            // -- CHARACTER MOD INFO
            CharacterName.Text = ReadINIField("CharacterInfo", "Name");
            CharacterDescription.Text = ReadINIField("CharacterInfo", "Description").Replace("\\n", "\n");
            BioCharLimit.Text = $"{CharacterDescription.Text.Length} / 2048";


        }

        private void CharacterDescription_TextChanged(object sender, EventArgs e) {
            int charCountOfBio = CharacterDescription.Text.Length;
            
            BioCharLimit.Text = $"{charCountOfBio} / 2048";

            BioCharLimit.ForeColor = (charCountOfBio >= 2000) ? Color.Red : Color.Black;
        }
    }
}
