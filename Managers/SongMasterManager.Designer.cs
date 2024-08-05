namespace WTDE_Launcher_V3.Managers {
    partial class SongMasterManager {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongMasterManager));
            this.SCMToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.SongModsList = new System.Windows.Forms.ListBox();
            this.SongCategoriesList = new System.Windows.Forms.ListBox();
            this.LogoImageBox = new System.Windows.Forms.PictureBox();
            this.AttachedCategorySongs = new System.Windows.Forms.ListView();
            this.SongTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SongChecksum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SongPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CloseButton = new System.Windows.Forms.Button();
            this.EditCategoryDataButton = new System.Windows.Forms.Button();
            this.SongModFilter = new System.Windows.Forms.TextBox();
            this.ApplySongModSearch = new System.Windows.Forms.Button();
            this.ResetSongModFilter = new System.Windows.Forms.Button();
            this.ResetSongCategoryFilter = new System.Windows.Forms.Button();
            this.ApplySongCategorySearch = new System.Windows.Forms.Button();
            this.SongCategoryFilter = new System.Windows.Forms.TextBox();
            this.MakeSetlistZIPButton = new System.Windows.Forms.Button();
            this.TopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openModsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshAllModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSongDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openModConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openModFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.addToCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showSongChecksumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCategoryDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.makeSetlistZIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.openModConfigToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openModFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.showCategoryChecksumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.SongModsHeader = new System.Windows.Forms.Label();
            this.SongCategoriesHeader = new System.Windows.Forms.Label();
            this.CategoryPreviewHeader = new System.Windows.Forms.Label();
            this.ActiveCategoryInfo = new System.Windows.Forms.Label();
            this.SongCatSongListHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LogoImageBox)).BeginInit();
            this.TopMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SongModsList
            // 
            this.SongModsList.FormattingEnabled = true;
            this.SongModsList.Location = new System.Drawing.Point(12, 63);
            this.SongModsList.Name = "SongModsList";
            this.SongModsList.Size = new System.Drawing.Size(268, 355);
            this.SongModsList.TabIndex = 7;
            this.SCMToolTipMain.SetToolTip(this.SongModsList, "List of all your song mods.");
            this.SongModsList.SelectedIndexChanged += new System.EventHandler(this.SongModsList_SelectedIndexChanged);
            // 
            // SongCategoriesList
            // 
            this.SongCategoriesList.FormattingEnabled = true;
            this.SongCategoriesList.Location = new System.Drawing.Point(12, 446);
            this.SongCategoriesList.Name = "SongCategoriesList";
            this.SongCategoriesList.Size = new System.Drawing.Size(268, 355);
            this.SongCategoriesList.TabIndex = 9;
            this.SCMToolTipMain.SetToolTip(this.SongCategoriesList, "List of all your song category mods.");
            this.SongCategoriesList.SelectedIndexChanged += new System.EventHandler(this.SongCategoriesList_SelectedIndexChanged);
            // 
            // LogoImageBox
            // 
            this.LogoImageBox.Location = new System.Drawing.Point(585, 65);
            this.LogoImageBox.Name = "LogoImageBox";
            this.LogoImageBox.Size = new System.Drawing.Size(192, 192);
            this.LogoImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoImageBox.TabIndex = 11;
            this.LogoImageBox.TabStop = false;
            this.SCMToolTipMain.SetToolTip(this.LogoImageBox, "The category\'s logo image.");
            // 
            // AttachedCategorySongs
            // 
            this.AttachedCategorySongs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SongTitle,
            this.SongChecksum,
            this.SongPath});
            this.AttachedCategorySongs.HideSelection = false;
            this.AttachedCategorySongs.Location = new System.Drawing.Point(306, 356);
            this.AttachedCategorySongs.Name = "AttachedCategorySongs";
            this.AttachedCategorySongs.Size = new System.Drawing.Size(738, 436);
            this.AttachedCategorySongs.TabIndex = 12;
            this.SCMToolTipMain.SetToolTip(this.AttachedCategorySongs, "List of all songs attached to the selected category.");
            this.AttachedCategorySongs.UseCompatibleStateImageBehavior = false;
            this.AttachedCategorySongs.View = System.Windows.Forms.View.Details;
            this.AttachedCategorySongs.SelectedIndexChanged += new System.EventHandler(this.AttachedCategorySongs_SelectedIndexChanged);
            // 
            // SongTitle
            // 
            this.SongTitle.Text = "Song: Artist - Title";
            this.SongTitle.Width = 244;
            // 
            // SongChecksum
            // 
            this.SongChecksum.Text = "Checksum";
            this.SongChecksum.Width = 120;
            // 
            // SongPath
            // 
            this.SongPath.Text = "Path";
            this.SongPath.Width = 344;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(976, 798);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 29;
            this.CloseButton.Text = "Close";
            this.SCMToolTipMain.SetToolTip(this.CloseButton, "Closes this window.");
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // EditCategoryDataButton
            // 
            this.EditCategoryDataButton.Location = new System.Drawing.Point(820, 41);
            this.EditCategoryDataButton.Name = "EditCategoryDataButton";
            this.EditCategoryDataButton.Size = new System.Drawing.Size(224, 23);
            this.EditCategoryDataButton.TabIndex = 30;
            this.EditCategoryDataButton.Text = "Edit Category Data...";
            this.SCMToolTipMain.SetToolTip(this.EditCategoryDataButton, "Edit the properties of this category.");
            this.EditCategoryDataButton.UseVisualStyleBackColor = true;
            this.EditCategoryDataButton.Click += new System.EventHandler(this.EditCategoryDataButton_Click);
            // 
            // SongModFilter
            // 
            this.SongModFilter.Location = new System.Drawing.Point(140, 41);
            this.SongModFilter.Name = "SongModFilter";
            this.SongModFilter.Size = new System.Drawing.Size(100, 20);
            this.SongModFilter.TabIndex = 31;
            this.SCMToolTipMain.SetToolTip(this.SongModFilter, "Filter your song mods by this string.");
            // 
            // ApplySongModSearch
            // 
            this.ApplySongModSearch.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.find_tiny;
            this.ApplySongModSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ApplySongModSearch.Location = new System.Drawing.Point(241, 40);
            this.ApplySongModSearch.Name = "ApplySongModSearch";
            this.ApplySongModSearch.Size = new System.Drawing.Size(23, 23);
            this.ApplySongModSearch.TabIndex = 32;
            this.SCMToolTipMain.SetToolTip(this.ApplySongModSearch, "Apply the given search filter.");
            this.ApplySongModSearch.UseVisualStyleBackColor = true;
            this.ApplySongModSearch.Click += new System.EventHandler(this.ApplySongModSearch_Click);
            // 
            // ResetSongModFilter
            // 
            this.ResetSongModFilter.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.delete_black;
            this.ResetSongModFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ResetSongModFilter.Location = new System.Drawing.Point(264, 40);
            this.ResetSongModFilter.Name = "ResetSongModFilter";
            this.ResetSongModFilter.Size = new System.Drawing.Size(23, 23);
            this.ResetSongModFilter.TabIndex = 33;
            this.SCMToolTipMain.SetToolTip(this.ResetSongModFilter, "Remove the filter off of the list.");
            this.ResetSongModFilter.UseVisualStyleBackColor = true;
            this.ResetSongModFilter.Click += new System.EventHandler(this.ResetSongModFilter_Click);
            // 
            // ResetSongCategoryFilter
            // 
            this.ResetSongCategoryFilter.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.delete_black;
            this.ResetSongCategoryFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ResetSongCategoryFilter.Location = new System.Drawing.Point(264, 423);
            this.ResetSongCategoryFilter.Name = "ResetSongCategoryFilter";
            this.ResetSongCategoryFilter.Size = new System.Drawing.Size(23, 23);
            this.ResetSongCategoryFilter.TabIndex = 36;
            this.SCMToolTipMain.SetToolTip(this.ResetSongCategoryFilter, "Remove the filter off of the list.");
            this.ResetSongCategoryFilter.UseVisualStyleBackColor = true;
            this.ResetSongCategoryFilter.Click += new System.EventHandler(this.ResetSongCategoryFilter_Click);
            // 
            // ApplySongCategorySearch
            // 
            this.ApplySongCategorySearch.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.find_tiny;
            this.ApplySongCategorySearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ApplySongCategorySearch.Location = new System.Drawing.Point(241, 423);
            this.ApplySongCategorySearch.Name = "ApplySongCategorySearch";
            this.ApplySongCategorySearch.Size = new System.Drawing.Size(23, 23);
            this.ApplySongCategorySearch.TabIndex = 35;
            this.SCMToolTipMain.SetToolTip(this.ApplySongCategorySearch, "Apply the given search filter.");
            this.ApplySongCategorySearch.UseVisualStyleBackColor = true;
            this.ApplySongCategorySearch.Click += new System.EventHandler(this.ApplySongCategorySearch_Click);
            // 
            // SongCategoryFilter
            // 
            this.SongCategoryFilter.Location = new System.Drawing.Point(140, 424);
            this.SongCategoryFilter.Name = "SongCategoryFilter";
            this.SongCategoryFilter.Size = new System.Drawing.Size(100, 20);
            this.SongCategoryFilter.TabIndex = 34;
            this.SCMToolTipMain.SetToolTip(this.SongCategoryFilter, "Filter your category mods by this string.");
            // 
            // MakeSetlistZIPButton
            // 
            this.MakeSetlistZIPButton.Location = new System.Drawing.Point(820, 70);
            this.MakeSetlistZIPButton.Name = "MakeSetlistZIPButton";
            this.MakeSetlistZIPButton.Size = new System.Drawing.Size(224, 23);
            this.MakeSetlistZIPButton.TabIndex = 30;
            this.MakeSetlistZIPButton.Text = "Make Setlist ZIP...";
            this.SCMToolTipMain.SetToolTip(this.MakeSetlistZIPButton, resources.GetString("MakeSetlistZIPButton.ToolTip"));
            this.MakeSetlistZIPButton.UseVisualStyleBackColor = true;
            this.MakeSetlistZIPButton.Click += new System.EventHandler(this.MakeSetlistZIPButton_Click);
            // 
            // TopMenuStrip
            // 
            this.TopMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.songToolStripMenuItem,
            this.songCategoryToolStripMenuItem});
            this.TopMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TopMenuStrip.Name = "TopMenuStrip";
            this.TopMenuStrip.Size = new System.Drawing.Size(1056, 24);
            this.TopMenuStrip.TabIndex = 0;
            this.TopMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openModsFolderToolStripMenuItem,
            this.refreshAllModsToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeManagerToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openModsFolderToolStripMenuItem
            // 
            this.openModsFolderToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.open_file;
            this.openModsFolderToolStripMenuItem.Name = "openModsFolderToolStripMenuItem";
            this.openModsFolderToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.openModsFolderToolStripMenuItem.Text = "Open Mods Folder";
            this.openModsFolderToolStripMenuItem.Click += new System.EventHandler(this.openModsFolderToolStripMenuItem_Click);
            // 
            // refreshAllModsToolStripMenuItem
            // 
            this.refreshAllModsToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.refresh;
            this.refreshAllModsToolStripMenuItem.Name = "refreshAllModsToolStripMenuItem";
            this.refreshAllModsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.refreshAllModsToolStripMenuItem.Text = "Refresh All Mods";
            this.refreshAllModsToolStripMenuItem.Click += new System.EventHandler(this.refreshAllModsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // closeManagerToolStripMenuItem
            // 
            this.closeManagerToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.exit_program;
            this.closeManagerToolStripMenuItem.Name = "closeManagerToolStripMenuItem";
            this.closeManagerToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.closeManagerToolStripMenuItem.Text = "Close Manager";
            this.closeManagerToolStripMenuItem.Click += new System.EventHandler(this.closeManagerToolStripMenuItem_Click);
            // 
            // songToolStripMenuItem
            // 
            this.songToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSongDataToolStripMenuItem,
            this.toolStripSeparator3,
            this.openModConfigToolStripMenuItem,
            this.openModFolderToolStripMenuItem,
            this.toolStripSeparator6,
            this.addToCategoryToolStripMenuItem,
            this.removeFromCategoryToolStripMenuItem,
            this.toolStripSeparator2,
            this.showSongChecksumsToolStripMenuItem});
            this.songToolStripMenuItem.Name = "songToolStripMenuItem";
            this.songToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.songToolStripMenuItem.Text = "Song";
            this.songToolStripMenuItem.Click += new System.EventHandler(this.songToolStripMenuItem_Click);
            // 
            // editSongDataToolStripMenuItem
            // 
            this.editSongDataToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.edit_meta_data;
            this.editSongDataToolStripMenuItem.Name = "editSongDataToolStripMenuItem";
            this.editSongDataToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.editSongDataToolStripMenuItem.Text = "Edit Song Data...";
            this.editSongDataToolStripMenuItem.Click += new System.EventHandler(this.editSongDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(196, 6);
            // 
            // openModConfigToolStripMenuItem
            // 
            this.openModConfigToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.edit_meta_data;
            this.openModConfigToolStripMenuItem.Name = "openModConfigToolStripMenuItem";
            this.openModConfigToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.openModConfigToolStripMenuItem.Text = "Open Mod Config";
            this.openModConfigToolStripMenuItem.Click += new System.EventHandler(this.openModConfigToolStripMenuItem_Click);
            // 
            // openModFolderToolStripMenuItem
            // 
            this.openModFolderToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.open_file;
            this.openModFolderToolStripMenuItem.Name = "openModFolderToolStripMenuItem";
            this.openModFolderToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.openModFolderToolStripMenuItem.Text = "Open Mod Folder";
            this.openModFolderToolStripMenuItem.Click += new System.EventHandler(this.openModFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(196, 6);
            // 
            // addToCategoryToolStripMenuItem
            // 
            this.addToCategoryToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.add;
            this.addToCategoryToolStripMenuItem.Name = "addToCategoryToolStripMenuItem";
            this.addToCategoryToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.addToCategoryToolStripMenuItem.Text = "Add to Category";
            this.addToCategoryToolStripMenuItem.Click += new System.EventHandler(this.addToCategoryToolStripMenuItem_Click);
            // 
            // removeFromCategoryToolStripMenuItem
            // 
            this.removeFromCategoryToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.delete;
            this.removeFromCategoryToolStripMenuItem.Name = "removeFromCategoryToolStripMenuItem";
            this.removeFromCategoryToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.removeFromCategoryToolStripMenuItem.Text = "Remove From Category";
            this.removeFromCategoryToolStripMenuItem.Click += new System.EventHandler(this.removeFromCategoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // showSongChecksumsToolStripMenuItem
            // 
            this.showSongChecksumsToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.music_note;
            this.showSongChecksumsToolStripMenuItem.Name = "showSongChecksumsToolStripMenuItem";
            this.showSongChecksumsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.showSongChecksumsToolStripMenuItem.Text = "Show Song Checksums";
            this.showSongChecksumsToolStripMenuItem.Click += new System.EventHandler(this.showSongChecksumsToolStripMenuItem_Click);
            // 
            // songCategoryToolStripMenuItem
            // 
            this.songCategoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCategoryToolStripMenuItem,
            this.deleteCategoryToolStripMenuItem,
            this.editCategoryDataToolStripMenuItem,
            this.toolStripSeparator7,
            this.makeSetlistZIPToolStripMenuItem,
            this.toolStripSeparator5,
            this.openModConfigToolStripMenuItem1,
            this.openModFolderToolStripMenuItem1,
            this.toolStripSeparator4,
            this.showCategoryChecksumsToolStripMenuItem});
            this.songCategoryToolStripMenuItem.Name = "songCategoryToolStripMenuItem";
            this.songCategoryToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.songCategoryToolStripMenuItem.Text = "Song Category";
            this.songCategoryToolStripMenuItem.Click += new System.EventHandler(this.songCategoryToolStripMenuItem_Click);
            // 
            // addCategoryToolStripMenuItem
            // 
            this.addCategoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addCategoryToolStripMenuItem.Image")));
            this.addCategoryToolStripMenuItem.Name = "addCategoryToolStripMenuItem";
            this.addCategoryToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.addCategoryToolStripMenuItem.Text = "Add New Category...";
            this.addCategoryToolStripMenuItem.Click += new System.EventHandler(this.addCategoryToolStripMenuItem_Click);
            // 
            // deleteCategoryToolStripMenuItem
            // 
            this.deleteCategoryToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.delete;
            this.deleteCategoryToolStripMenuItem.Name = "deleteCategoryToolStripMenuItem";
            this.deleteCategoryToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.deleteCategoryToolStripMenuItem.Text = "Delete Category";
            this.deleteCategoryToolStripMenuItem.Click += new System.EventHandler(this.deleteCategoryToolStripMenuItem_Click);
            // 
            // editCategoryDataToolStripMenuItem
            // 
            this.editCategoryDataToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.edit_meta_data;
            this.editCategoryDataToolStripMenuItem.Name = "editCategoryDataToolStripMenuItem";
            this.editCategoryDataToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.editCategoryDataToolStripMenuItem.Text = "Edit Category Data...";
            this.editCategoryDataToolStripMenuItem.Click += new System.EventHandler(this.editCategoryDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(215, 6);
            // 
            // makeSetlistZIPToolStripMenuItem
            // 
            this.makeSetlistZIPToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.folder;
            this.makeSetlistZIPToolStripMenuItem.Name = "makeSetlistZIPToolStripMenuItem";
            this.makeSetlistZIPToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.makeSetlistZIPToolStripMenuItem.Text = "Make Setlist ZIP...";
            this.makeSetlistZIPToolStripMenuItem.Click += new System.EventHandler(this.makeSetlistZIPToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(215, 6);
            // 
            // openModConfigToolStripMenuItem1
            // 
            this.openModConfigToolStripMenuItem1.Image = global::WTDE_Launcher_V3.Properties.Resources.edit_meta_data;
            this.openModConfigToolStripMenuItem1.Name = "openModConfigToolStripMenuItem1";
            this.openModConfigToolStripMenuItem1.Size = new System.Drawing.Size(218, 22);
            this.openModConfigToolStripMenuItem1.Text = "Open Mod Config";
            this.openModConfigToolStripMenuItem1.Click += new System.EventHandler(this.openModConfigToolStripMenuItem1_Click);
            // 
            // openModFolderToolStripMenuItem1
            // 
            this.openModFolderToolStripMenuItem1.Image = global::WTDE_Launcher_V3.Properties.Resources.open_file;
            this.openModFolderToolStripMenuItem1.Name = "openModFolderToolStripMenuItem1";
            this.openModFolderToolStripMenuItem1.Size = new System.Drawing.Size(218, 22);
            this.openModFolderToolStripMenuItem1.Text = "Open Mod Folder";
            this.openModFolderToolStripMenuItem1.Click += new System.EventHandler(this.openModFolderToolStripMenuItem1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(215, 6);
            // 
            // showCategoryChecksumsToolStripMenuItem
            // 
            this.showCategoryChecksumsToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.folder;
            this.showCategoryChecksumsToolStripMenuItem.Name = "showCategoryChecksumsToolStripMenuItem";
            this.showCategoryChecksumsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.showCategoryChecksumsToolStripMenuItem.Text = "Show Category Checksums";
            this.showCategoryChecksumsToolStripMenuItem.Click += new System.EventHandler(this.showCategoryChecksumsToolStripMenuItem_Click);
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 24);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(660, 13);
            this.InfoHeaderLabel.TabIndex = 2;
            this.InfoHeaderLabel.Text = "Song and Song Category Manager: Manage your songs and categories, and also help c" +
    "ategorize your songs better.";
            // 
            // SongModsHeader
            // 
            this.SongModsHeader.AutoSize = true;
            this.SongModsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.SongModsHeader.Location = new System.Drawing.Point(3, 45);
            this.SongModsHeader.Name = "SongModsHeader";
            this.SongModsHeader.Size = new System.Drawing.Size(74, 13);
            this.SongModsHeader.TabIndex = 6;
            this.SongModsHeader.Text = "Song Mods:";
            // 
            // SongCategoriesHeader
            // 
            this.SongCategoriesHeader.AutoSize = true;
            this.SongCategoriesHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.SongCategoriesHeader.Location = new System.Drawing.Point(3, 428);
            this.SongCategoriesHeader.Name = "SongCategoriesHeader";
            this.SongCategoriesHeader.Size = new System.Drawing.Size(104, 13);
            this.SongCategoriesHeader.TabIndex = 8;
            this.SongCategoriesHeader.Text = "Song Categories:";
            // 
            // CategoryPreviewHeader
            // 
            this.CategoryPreviewHeader.AutoSize = true;
            this.CategoryPreviewHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.CategoryPreviewHeader.Location = new System.Drawing.Point(296, 46);
            this.CategoryPreviewHeader.Name = "CategoryPreviewHeader";
            this.CategoryPreviewHeader.Size = new System.Drawing.Size(143, 13);
            this.CategoryPreviewHeader.TabIndex = 10;
            this.CategoryPreviewHeader.Text = "Song Category Preview:";
            // 
            // ActiveCategoryInfo
            // 
            this.ActiveCategoryInfo.AutoSize = true;
            this.ActiveCategoryInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ActiveCategoryInfo.Location = new System.Drawing.Point(303, 268);
            this.ActiveCategoryInfo.Name = "ActiveCategoryInfo";
            this.ActiveCategoryInfo.Size = new System.Drawing.Size(171, 52);
            this.ActiveCategoryInfo.TabIndex = 13;
            this.ActiveCategoryInfo.Text = "Name: ???\r\nChecksum: N/A\r\nPath: N/A\r\nSongs Tied to Category: N/A";
            // 
            // SongCatSongListHeader
            // 
            this.SongCatSongListHeader.AutoSize = true;
            this.SongCatSongListHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.SongCatSongListHeader.Location = new System.Drawing.Point(296, 338);
            this.SongCatSongListHeader.Name = "SongCatSongListHeader";
            this.SongCatSongListHeader.Size = new System.Drawing.Size(143, 13);
            this.SongCatSongListHeader.TabIndex = 14;
            this.SongCatSongListHeader.Text = "Song Category Preview:";
            // 
            // SongMasterManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1056, 825);
            this.Controls.Add(this.ResetSongCategoryFilter);
            this.Controls.Add(this.ApplySongCategorySearch);
            this.Controls.Add(this.SongCategoryFilter);
            this.Controls.Add(this.ResetSongModFilter);
            this.Controls.Add(this.ApplySongModSearch);
            this.Controls.Add(this.SongModFilter);
            this.Controls.Add(this.MakeSetlistZIPButton);
            this.Controls.Add(this.EditCategoryDataButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SongCatSongListHeader);
            this.Controls.Add(this.ActiveCategoryInfo);
            this.Controls.Add(this.AttachedCategorySongs);
            this.Controls.Add(this.LogoImageBox);
            this.Controls.Add(this.CategoryPreviewHeader);
            this.Controls.Add(this.SongCategoriesList);
            this.Controls.Add(this.SongCategoriesHeader);
            this.Controls.Add(this.SongModsList);
            this.Controls.Add(this.SongModsHeader);
            this.Controls.Add(this.InfoHeaderLabel);
            this.Controls.Add(this.TopMenuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.TopMenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SongMasterManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mod Manager: Song and Song Category Manager";
            ((System.ComponentModel.ISupportInitialize)(this.LogoImageBox)).EndInit();
            this.TopMenuStrip.ResumeLayout(false);
            this.TopMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip SCMToolTipMain;
        private System.Windows.Forms.MenuStrip TopMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openModsFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem songToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSongDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem openModConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openModFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem songCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCategoryToolStripMenuItem;
        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.ListBox SongModsList;
        private System.Windows.Forms.Label SongModsHeader;
        private System.Windows.Forms.ListBox SongCategoriesList;
        private System.Windows.Forms.Label SongCategoriesHeader;
        private System.Windows.Forms.Label CategoryPreviewHeader;
        private System.Windows.Forms.PictureBox LogoImageBox;
        private System.Windows.Forms.ListView AttachedCategorySongs;
        private System.Windows.Forms.Label ActiveCategoryInfo;
        private System.Windows.Forms.Label SongCatSongListHeader;
        private System.Windows.Forms.ColumnHeader SongTitle;
        private System.Windows.Forms.ColumnHeader SongChecksum;
        private System.Windows.Forms.ColumnHeader SongPath;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ToolStripMenuItem showSongChecksumsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshAllModsToolStripMenuItem;
        private System.Windows.Forms.Button EditCategoryDataButton;
        private System.Windows.Forms.ToolStripMenuItem editCategoryDataToolStripMenuItem;
        private System.Windows.Forms.TextBox SongModFilter;
        private System.Windows.Forms.Button ApplySongModSearch;
        private System.Windows.Forms.Button ResetSongModFilter;
        private System.Windows.Forms.Button ResetSongCategoryFilter;
        private System.Windows.Forms.Button ApplySongCategorySearch;
        private System.Windows.Forms.TextBox SongCategoryFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem showCategoryChecksumsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem addToCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openModConfigToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openModFolderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem makeSetlistZIPToolStripMenuItem;
        private System.Windows.Forms.Button MakeSetlistZIPButton;
    }
}