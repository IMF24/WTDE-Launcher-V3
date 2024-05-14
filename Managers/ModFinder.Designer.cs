namespace WTDE_Launcher_V3.Managers {
    partial class ModFinder {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModFinder));
            this.ModFinderHeader = new System.Windows.Forms.Label();
            this.FindSongs = new System.Windows.Forms.RadioButton();
            this.ModTypeGroup = new System.Windows.Forms.GroupBox();
            this.FindAllMods = new System.Windows.Forms.RadioButton();
            this.FindScripts = new System.Windows.Forms.RadioButton();
            this.FindGemThemes = new System.Windows.Forms.RadioButton();
            this.FindMenuMusics = new System.Windows.Forms.RadioButton();
            this.FindHighways = new System.Windows.Forms.RadioButton();
            this.FindCategories = new System.Windows.Forms.RadioButton();
            this.FindVenues = new System.Windows.Forms.RadioButton();
            this.FindInstruments = new System.Windows.Forms.RadioButton();
            this.FindCharacters = new System.Windows.Forms.RadioButton();
            this.PathLabel = new System.Windows.Forms.Label();
            this.SearchFiltersGroup = new System.Windows.Forms.GroupBox();
            this.CaseSensitiveWarning = new System.Windows.Forms.Label();
            this.ModDescription = new System.Windows.Forms.TextBox();
            this.ModDescLabel = new System.Windows.Forms.Label();
            this.ModVersion = new System.Windows.Forms.TextBox();
            this.ModVersionLabel = new System.Windows.Forms.Label();
            this.ModAuthor = new System.Windows.Forms.TextBox();
            this.ModAuthorLabel = new System.Windows.Forms.Label();
            this.ModName = new System.Windows.Forms.TextBox();
            this.ModNameLabel = new System.Windows.Forms.Label();
            this.PathFilter = new System.Windows.Forms.TextBox();
            this.SearchResultsHeader = new System.Windows.Forms.Label();
            this.FindResultsList = new System.Windows.Forms.ListBox();
            this.FindModsButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.CopySelectedPath = new System.Windows.Forms.Button();
            this.OpenSelectedFolder = new System.Windows.Forms.Button();
            this.DeleteSelectedMod = new System.Windows.Forms.Button();
            this.OpenSelectedConfig = new System.Windows.Forms.Button();
            this.ActionsHeader = new System.Windows.Forms.Label();
            this.FinderToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.ExportResultList = new System.Windows.Forms.Button();
            this.ModTypeGroup.SuspendLayout();
            this.SearchFiltersGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModFinderHeader
            // 
            this.ModFinderHeader.AutoSize = true;
            this.ModFinderHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ModFinderHeader.Location = new System.Drawing.Point(3, 2);
            this.ModFinderHeader.Name = "ModFinderHeader";
            this.ModFinderHeader.Size = new System.Drawing.Size(332, 15);
            this.ModFinderHeader.TabIndex = 2;
            this.ModFinderHeader.Text = "Mod Finder: Find installed mods you have by various filters.";
            // 
            // FindSongs
            // 
            this.FindSongs.AutoSize = true;
            this.FindSongs.Location = new System.Drawing.Point(18, 19);
            this.FindSongs.Name = "FindSongs";
            this.FindSongs.Size = new System.Drawing.Size(50, 17);
            this.FindSongs.TabIndex = 3;
            this.FindSongs.Text = "Song";
            this.FindSongs.UseVisualStyleBackColor = true;
            // 
            // ModTypeGroup
            // 
            this.ModTypeGroup.Controls.Add(this.FindAllMods);
            this.ModTypeGroup.Controls.Add(this.FindScripts);
            this.ModTypeGroup.Controls.Add(this.FindGemThemes);
            this.ModTypeGroup.Controls.Add(this.FindMenuMusics);
            this.ModTypeGroup.Controls.Add(this.FindHighways);
            this.ModTypeGroup.Controls.Add(this.FindCategories);
            this.ModTypeGroup.Controls.Add(this.FindVenues);
            this.ModTypeGroup.Controls.Add(this.FindInstruments);
            this.ModTypeGroup.Controls.Add(this.FindCharacters);
            this.ModTypeGroup.Controls.Add(this.FindSongs);
            this.ModTypeGroup.Location = new System.Drawing.Point(12, 20);
            this.ModTypeGroup.Name = "ModTypeGroup";
            this.ModTypeGroup.Size = new System.Drawing.Size(518, 72);
            this.ModTypeGroup.TabIndex = 4;
            this.ModTypeGroup.TabStop = false;
            this.ModTypeGroup.Text = "Mod Type";
            this.FinderToolTipMain.SetToolTip(this.ModTypeGroup, "Filter the mod search down to a certain mod type.");
            // 
            // FindAllMods
            // 
            this.FindAllMods.AutoSize = true;
            this.FindAllMods.Checked = true;
            this.FindAllMods.Location = new System.Drawing.Point(433, 42);
            this.FindAllMods.Name = "FindAllMods";
            this.FindAllMods.Size = new System.Drawing.Size(43, 17);
            this.FindAllMods.TabIndex = 12;
            this.FindAllMods.TabStop = true;
            this.FindAllMods.Text = "Any";
            this.FindAllMods.UseVisualStyleBackColor = true;
            // 
            // FindScripts
            // 
            this.FindScripts.AutoSize = true;
            this.FindScripts.Location = new System.Drawing.Point(324, 42);
            this.FindScripts.Name = "FindScripts";
            this.FindScripts.Size = new System.Drawing.Size(52, 17);
            this.FindScripts.TabIndex = 11;
            this.FindScripts.Text = "Script";
            this.FindScripts.UseVisualStyleBackColor = true;
            // 
            // FindGemThemes
            // 
            this.FindGemThemes.AutoSize = true;
            this.FindGemThemes.Location = new System.Drawing.Point(219, 42);
            this.FindGemThemes.Name = "FindGemThemes";
            this.FindGemThemes.Size = new System.Drawing.Size(83, 17);
            this.FindGemThemes.TabIndex = 10;
            this.FindGemThemes.Text = "Gem Theme";
            this.FindGemThemes.UseVisualStyleBackColor = true;
            // 
            // FindMenuMusics
            // 
            this.FindMenuMusics.AutoSize = true;
            this.FindMenuMusics.Location = new System.Drawing.Point(96, 42);
            this.FindMenuMusics.Name = "FindMenuMusics";
            this.FindMenuMusics.Size = new System.Drawing.Size(83, 17);
            this.FindMenuMusics.TabIndex = 9;
            this.FindMenuMusics.Text = "Menu Music";
            this.FindMenuMusics.UseVisualStyleBackColor = true;
            // 
            // FindHighways
            // 
            this.FindHighways.AutoSize = true;
            this.FindHighways.Location = new System.Drawing.Point(433, 19);
            this.FindHighways.Name = "FindHighways";
            this.FindHighways.Size = new System.Drawing.Size(66, 17);
            this.FindHighways.TabIndex = 8;
            this.FindHighways.Text = "Highway";
            this.FindHighways.UseVisualStyleBackColor = true;
            // 
            // FindCategories
            // 
            this.FindCategories.AutoSize = true;
            this.FindCategories.Location = new System.Drawing.Point(96, 19);
            this.FindCategories.Name = "FindCategories";
            this.FindCategories.Size = new System.Drawing.Size(95, 17);
            this.FindCategories.TabIndex = 7;
            this.FindCategories.Text = "Song Category";
            this.FindCategories.UseVisualStyleBackColor = true;
            // 
            // FindVenues
            // 
            this.FindVenues.AutoSize = true;
            this.FindVenues.Location = new System.Drawing.Point(18, 42);
            this.FindVenues.Name = "FindVenues";
            this.FindVenues.Size = new System.Drawing.Size(56, 17);
            this.FindVenues.TabIndex = 6;
            this.FindVenues.Text = "Venue";
            this.FindVenues.UseVisualStyleBackColor = true;
            // 
            // FindInstruments
            // 
            this.FindInstruments.AutoSize = true;
            this.FindInstruments.Location = new System.Drawing.Point(324, 19);
            this.FindInstruments.Name = "FindInstruments";
            this.FindInstruments.Size = new System.Drawing.Size(74, 17);
            this.FindInstruments.TabIndex = 5;
            this.FindInstruments.Text = "Instrument";
            this.FindInstruments.UseVisualStyleBackColor = true;
            // 
            // FindCharacters
            // 
            this.FindCharacters.AutoSize = true;
            this.FindCharacters.Location = new System.Drawing.Point(219, 19);
            this.FindCharacters.Name = "FindCharacters";
            this.FindCharacters.Size = new System.Drawing.Size(71, 17);
            this.FindCharacters.TabIndex = 4;
            this.FindCharacters.Text = "Character";
            this.FindCharacters.UseVisualStyleBackColor = true;
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(55, 37);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(47, 13);
            this.PathLabel.TabIndex = 5;
            this.PathLabel.Text = "By Path:";
            // 
            // SearchFiltersGroup
            // 
            this.SearchFiltersGroup.Controls.Add(this.CaseSensitiveWarning);
            this.SearchFiltersGroup.Controls.Add(this.ModDescription);
            this.SearchFiltersGroup.Controls.Add(this.ModDescLabel);
            this.SearchFiltersGroup.Controls.Add(this.ModVersion);
            this.SearchFiltersGroup.Controls.Add(this.ModVersionLabel);
            this.SearchFiltersGroup.Controls.Add(this.ModAuthor);
            this.SearchFiltersGroup.Controls.Add(this.ModAuthorLabel);
            this.SearchFiltersGroup.Controls.Add(this.ModName);
            this.SearchFiltersGroup.Controls.Add(this.ModNameLabel);
            this.SearchFiltersGroup.Controls.Add(this.PathFilter);
            this.SearchFiltersGroup.Controls.Add(this.PathLabel);
            this.SearchFiltersGroup.Location = new System.Drawing.Point(12, 98);
            this.SearchFiltersGroup.Name = "SearchFiltersGroup";
            this.SearchFiltersGroup.Size = new System.Drawing.Size(518, 171);
            this.SearchFiltersGroup.TabIndex = 6;
            this.SearchFiltersGroup.TabStop = false;
            this.SearchFiltersGroup.Text = "Search Filters";
            this.FinderToolTipMain.SetToolTip(this.SearchFiltersGroup, "Various other filters to apply to the search query.");
            // 
            // CaseSensitiveWarning
            // 
            this.CaseSensitiveWarning.AutoSize = true;
            this.CaseSensitiveWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.CaseSensitiveWarning.Location = new System.Drawing.Point(6, 16);
            this.CaseSensitiveWarning.Name = "CaseSensitiveWarning";
            this.CaseSensitiveWarning.Size = new System.Drawing.Size(187, 15);
            this.CaseSensitiveWarning.TabIndex = 15;
            this.CaseSensitiveWarning.Text = "Note: Fields are case-insensitive.";
            // 
            // ModDescription
            // 
            this.ModDescription.Location = new System.Drawing.Point(110, 139);
            this.ModDescription.Name = "ModDescription";
            this.ModDescription.Size = new System.Drawing.Size(389, 20);
            this.ModDescription.TabIndex = 14;
            this.FinderToolTipMain.SetToolTip(this.ModDescription, "Searches the ModInfo section for a mod\'s description.");
            // 
            // ModDescLabel
            // 
            this.ModDescLabel.AutoSize = true;
            this.ModDescLabel.Location = new System.Drawing.Point(15, 142);
            this.ModDescLabel.Name = "ModDescLabel";
            this.ModDescLabel.Size = new System.Drawing.Size(87, 13);
            this.ModDescLabel.TabIndex = 13;
            this.ModDescLabel.Text = "Mod Description:";
            // 
            // ModVersion
            // 
            this.ModVersion.Location = new System.Drawing.Point(110, 115);
            this.ModVersion.Name = "ModVersion";
            this.ModVersion.Size = new System.Drawing.Size(389, 20);
            this.ModVersion.TabIndex = 12;
            this.FinderToolTipMain.SetToolTip(this.ModVersion, "Searches the ModInfo section for a mod\'s version.");
            // 
            // ModVersionLabel
            // 
            this.ModVersionLabel.AutoSize = true;
            this.ModVersionLabel.Location = new System.Drawing.Point(33, 118);
            this.ModVersionLabel.Name = "ModVersionLabel";
            this.ModVersionLabel.Size = new System.Drawing.Size(69, 13);
            this.ModVersionLabel.TabIndex = 11;
            this.ModVersionLabel.Text = "Mod Version:";
            // 
            // ModAuthor
            // 
            this.ModAuthor.Location = new System.Drawing.Point(110, 92);
            this.ModAuthor.Name = "ModAuthor";
            this.ModAuthor.Size = new System.Drawing.Size(389, 20);
            this.ModAuthor.TabIndex = 10;
            this.FinderToolTipMain.SetToolTip(this.ModAuthor, "Searches the ModInfo section for a mod\'s author.");
            // 
            // ModAuthorLabel
            // 
            this.ModAuthorLabel.AutoSize = true;
            this.ModAuthorLabel.Location = new System.Drawing.Point(37, 95);
            this.ModAuthorLabel.Name = "ModAuthorLabel";
            this.ModAuthorLabel.Size = new System.Drawing.Size(65, 13);
            this.ModAuthorLabel.TabIndex = 9;
            this.ModAuthorLabel.Text = "Mod Author:";
            // 
            // ModName
            // 
            this.ModName.Location = new System.Drawing.Point(110, 69);
            this.ModName.Name = "ModName";
            this.ModName.Size = new System.Drawing.Size(389, 20);
            this.ModName.TabIndex = 8;
            this.FinderToolTipMain.SetToolTip(this.ModName, "Searches the ModInfo section for a mod\'s name.");
            // 
            // ModNameLabel
            // 
            this.ModNameLabel.AutoSize = true;
            this.ModNameLabel.Location = new System.Drawing.Point(40, 72);
            this.ModNameLabel.Name = "ModNameLabel";
            this.ModNameLabel.Size = new System.Drawing.Size(62, 13);
            this.ModNameLabel.TabIndex = 7;
            this.ModNameLabel.Text = "Mod Name:";
            // 
            // PathFilter
            // 
            this.PathFilter.Location = new System.Drawing.Point(110, 34);
            this.PathFilter.Name = "PathFilter";
            this.PathFilter.Size = new System.Drawing.Size(389, 20);
            this.PathFilter.TabIndex = 6;
            this.FinderToolTipMain.SetToolTip(this.PathFilter, "Look for a specific path/folder/file name.");
            // 
            // SearchResultsHeader
            // 
            this.SearchResultsHeader.AutoSize = true;
            this.SearchResultsHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.SearchResultsHeader.Location = new System.Drawing.Point(3, 299);
            this.SearchResultsHeader.Name = "SearchResultsHeader";
            this.SearchResultsHeader.Size = new System.Drawing.Size(88, 15);
            this.SearchResultsHeader.TabIndex = 7;
            this.SearchResultsHeader.Text = "Search Results";
            // 
            // FindResultsList
            // 
            this.FindResultsList.FormattingEnabled = true;
            this.FindResultsList.Location = new System.Drawing.Point(12, 317);
            this.FindResultsList.Name = "FindResultsList";
            this.FindResultsList.Size = new System.Drawing.Size(376, 277);
            this.FindResultsList.TabIndex = 8;
            this.FinderToolTipMain.SetToolTip(this.FindResultsList, "List of mod paths matching what you provided.");
            this.FindResultsList.SelectedIndexChanged += new System.EventHandler(this.FindResultsList_SelectedIndexChanged);
            // 
            // FindModsButton
            // 
            this.FindModsButton.Location = new System.Drawing.Point(455, 274);
            this.FindModsButton.Name = "FindModsButton";
            this.FindModsButton.Size = new System.Drawing.Size(75, 23);
            this.FindModsButton.TabIndex = 9;
            this.FindModsButton.Text = "Search";
            this.FinderToolTipMain.SetToolTip(this.FindModsButton, "Run a scan on your mods folder, reporting any mods matching the filters you provi" +
        "ded.");
            this.FindModsButton.UseVisualStyleBackColor = true;
            this.FindModsButton.Click += new System.EventHandler(this.FindModsButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(461, 600);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 10;
            this.CloseButton.Text = "Close";
            this.FinderToolTipMain.SetToolTip(this.CloseButton, "Closes this window.");
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // CopySelectedPath
            // 
            this.CopySelectedPath.Location = new System.Drawing.Point(394, 317);
            this.CopySelectedPath.Name = "CopySelectedPath";
            this.CopySelectedPath.Size = new System.Drawing.Size(136, 23);
            this.CopySelectedPath.TabIndex = 11;
            this.CopySelectedPath.Text = "Copy Selected Path";
            this.FinderToolTipMain.SetToolTip(this.CopySelectedPath, "Copy the selected mod\'s path.");
            this.CopySelectedPath.UseVisualStyleBackColor = true;
            this.CopySelectedPath.Click += new System.EventHandler(this.CopySelectedPath_Click);
            // 
            // OpenSelectedFolder
            // 
            this.OpenSelectedFolder.Location = new System.Drawing.Point(394, 375);
            this.OpenSelectedFolder.Name = "OpenSelectedFolder";
            this.OpenSelectedFolder.Size = new System.Drawing.Size(136, 23);
            this.OpenSelectedFolder.TabIndex = 12;
            this.OpenSelectedFolder.Text = "Open Selected Folder";
            this.FinderToolTipMain.SetToolTip(this.OpenSelectedFolder, "Open the selected mod\'s folder.");
            this.OpenSelectedFolder.UseVisualStyleBackColor = true;
            this.OpenSelectedFolder.Click += new System.EventHandler(this.OpenSelectedFolder_Click);
            // 
            // DeleteSelectedMod
            // 
            this.DeleteSelectedMod.Location = new System.Drawing.Point(394, 404);
            this.DeleteSelectedMod.Name = "DeleteSelectedMod";
            this.DeleteSelectedMod.Size = new System.Drawing.Size(136, 23);
            this.DeleteSelectedMod.TabIndex = 13;
            this.DeleteSelectedMod.Text = "Delete Mod";
            this.FinderToolTipMain.SetToolTip(this.DeleteSelectedMod, "Delete the selected mod.");
            this.DeleteSelectedMod.UseVisualStyleBackColor = true;
            this.DeleteSelectedMod.Click += new System.EventHandler(this.DeleteSelectedMod_Click);
            // 
            // OpenSelectedConfig
            // 
            this.OpenSelectedConfig.Location = new System.Drawing.Point(394, 346);
            this.OpenSelectedConfig.Name = "OpenSelectedConfig";
            this.OpenSelectedConfig.Size = new System.Drawing.Size(136, 23);
            this.OpenSelectedConfig.TabIndex = 14;
            this.OpenSelectedConfig.Text = "Open Selected Config";
            this.FinderToolTipMain.SetToolTip(this.OpenSelectedConfig, "Open the selected mod\'s INI file.");
            this.OpenSelectedConfig.UseVisualStyleBackColor = true;
            this.OpenSelectedConfig.Click += new System.EventHandler(this.OpenSelectedConfig_Click);
            // 
            // ActionsHeader
            // 
            this.ActionsHeader.AutoSize = true;
            this.ActionsHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ActionsHeader.Location = new System.Drawing.Point(391, 299);
            this.ActionsHeader.Name = "ActionsHeader";
            this.ActionsHeader.Size = new System.Drawing.Size(51, 15);
            this.ActionsHeader.TabIndex = 15;
            this.ActionsHeader.Text = "Actions:";
            // 
            // ExportResultList
            // 
            this.ExportResultList.Location = new System.Drawing.Point(394, 433);
            this.ExportResultList.Name = "ExportResultList";
            this.ExportResultList.Size = new System.Drawing.Size(136, 23);
            this.ExportResultList.TabIndex = 16;
            this.ExportResultList.Text = "Export Result List...";
            this.FinderToolTipMain.SetToolTip(this.ExportResultList, "Writes all results to a text file on the disk.");
            this.ExportResultList.UseVisualStyleBackColor = true;
            this.ExportResultList.Click += new System.EventHandler(this.ExportResultList_Click);
            // 
            // ModFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 628);
            this.Controls.Add(this.ExportResultList);
            this.Controls.Add(this.ActionsHeader);
            this.Controls.Add(this.OpenSelectedConfig);
            this.Controls.Add(this.DeleteSelectedMod);
            this.Controls.Add(this.OpenSelectedFolder);
            this.Controls.Add(this.CopySelectedPath);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.FindModsButton);
            this.Controls.Add(this.FindResultsList);
            this.Controls.Add(this.SearchResultsHeader);
            this.Controls.Add(this.SearchFiltersGroup);
            this.Controls.Add(this.ModTypeGroup);
            this.Controls.Add(this.ModFinderHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModFinder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mod Manager: Find Mods";
            this.ModTypeGroup.ResumeLayout(false);
            this.ModTypeGroup.PerformLayout();
            this.SearchFiltersGroup.ResumeLayout(false);
            this.SearchFiltersGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ModFinderHeader;
        private System.Windows.Forms.RadioButton FindSongs;
        private System.Windows.Forms.GroupBox ModTypeGroup;
        private System.Windows.Forms.RadioButton FindInstruments;
        private System.Windows.Forms.RadioButton FindCharacters;
        private System.Windows.Forms.RadioButton FindAllMods;
        private System.Windows.Forms.RadioButton FindScripts;
        private System.Windows.Forms.RadioButton FindGemThemes;
        private System.Windows.Forms.RadioButton FindMenuMusics;
        private System.Windows.Forms.RadioButton FindHighways;
        private System.Windows.Forms.RadioButton FindCategories;
        private System.Windows.Forms.RadioButton FindVenues;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.GroupBox SearchFiltersGroup;
        private System.Windows.Forms.TextBox ModVersion;
        private System.Windows.Forms.Label ModVersionLabel;
        private System.Windows.Forms.TextBox ModAuthor;
        private System.Windows.Forms.Label ModAuthorLabel;
        private System.Windows.Forms.TextBox ModName;
        private System.Windows.Forms.Label ModNameLabel;
        private System.Windows.Forms.TextBox PathFilter;
        private System.Windows.Forms.TextBox ModDescription;
        private System.Windows.Forms.Label ModDescLabel;
        private System.Windows.Forms.Label SearchResultsHeader;
        private System.Windows.Forms.ListBox FindResultsList;
        private System.Windows.Forms.Button FindModsButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label CaseSensitiveWarning;
        private System.Windows.Forms.Button CopySelectedPath;
        private System.Windows.Forms.Button OpenSelectedFolder;
        private System.Windows.Forms.Button DeleteSelectedMod;
        private System.Windows.Forms.Button OpenSelectedConfig;
        private System.Windows.Forms.Label ActionsHeader;
        private System.Windows.Forms.ToolTip FinderToolTipMain;
        private System.Windows.Forms.Button ExportResultList;
    }
}