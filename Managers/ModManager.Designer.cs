namespace WTDE_Launcher_V3 {
    partial class ModManager {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModManager));
            this.UserContentModsTree = new System.Windows.Forms.ListView();
            this.ModName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ModAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ModType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ModVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ModDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ModPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ModTreeContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openSelectedModConfigToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openSelectedModFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.copyFolderPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModManagerMenuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSaveFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rockStarCreatorCharacterManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.closeModManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openModsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ghwtNexusModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wtdeGoogleDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openSelectedModConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSelectedModFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedModFolderPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteModToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.songsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songAndSongCategoryManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDuplicateSongChecksumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptModEditorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gemThemeDesignerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignGH3SPFXToCharacterModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.starPowerColorModifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extendedHyperspeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBarMain = new System.Windows.Forms.StatusStrip();
            this.StatusLabelMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.ModTreeContext.SuspendLayout();
            this.ModManagerMenuMain.SuspendLayout();
            this.StatusBarMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserContentModsTree
            // 
            this.UserContentModsTree.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ModName,
            this.ModAuthor,
            this.ModType,
            this.ModVersion,
            this.ModDescription,
            this.ModPath});
            this.UserContentModsTree.ContextMenuStrip = this.ModTreeContext;
            this.UserContentModsTree.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserContentModsTree.HideSelection = false;
            this.UserContentModsTree.Location = new System.Drawing.Point(0, 24);
            this.UserContentModsTree.Name = "UserContentModsTree";
            this.UserContentModsTree.Size = new System.Drawing.Size(1264, 636);
            this.UserContentModsTree.TabIndex = 0;
            this.UserContentModsTree.UseCompatibleStateImageBehavior = false;
            this.UserContentModsTree.View = System.Windows.Forms.View.Details;
            this.UserContentModsTree.SelectedIndexChanged += new System.EventHandler(this.UserContentModsTree_SelectedIndexChanged);
            // 
            // ModName
            // 
            this.ModName.Text = "Mod Name";
            this.ModName.Width = 251;
            // 
            // ModAuthor
            // 
            this.ModAuthor.Text = "Author";
            this.ModAuthor.Width = 170;
            // 
            // ModType
            // 
            this.ModType.Text = "Type";
            this.ModType.Width = 122;
            // 
            // ModVersion
            // 
            this.ModVersion.Text = "Version";
            // 
            // ModDescription
            // 
            this.ModDescription.Text = "Description";
            this.ModDescription.Width = 294;
            // 
            // ModPath
            // 
            this.ModPath.Text = "Path";
            this.ModPath.Width = 346;
            // 
            // ModTreeContext
            // 
            this.ModTreeContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSelectedModConfigToolStripMenuItem1,
            this.openSelectedModFolderToolStripMenuItem,
            this.toolStripSeparator6,
            this.copyFolderPathToolStripMenuItem,
            this.toolStripSeparator5,
            this.deleteModToolStripMenuItem});
            this.ModTreeContext.Name = "ModTreeContext";
            this.ModTreeContext.Size = new System.Drawing.Size(218, 104);
            // 
            // openSelectedModConfigToolStripMenuItem1
            // 
            this.openSelectedModConfigToolStripMenuItem1.Image = global::WTDE_Launcher_V3.Properties.Resources.edit_meta_data;
            this.openSelectedModConfigToolStripMenuItem1.Name = "openSelectedModConfigToolStripMenuItem1";
            this.openSelectedModConfigToolStripMenuItem1.Size = new System.Drawing.Size(217, 22);
            this.openSelectedModConfigToolStripMenuItem1.Text = "Open Selected Mod Config";
            this.openSelectedModConfigToolStripMenuItem1.Click += new System.EventHandler(this.openSelectedModConfigToolStripMenuItem1_Click);
            // 
            // openSelectedModFolderToolStripMenuItem
            // 
            this.openSelectedModFolderToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.open_file;
            this.openSelectedModFolderToolStripMenuItem.Name = "openSelectedModFolderToolStripMenuItem";
            this.openSelectedModFolderToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.openSelectedModFolderToolStripMenuItem.Text = "Open Selected Mod Folder";
            this.openSelectedModFolderToolStripMenuItem.Click += new System.EventHandler(this.openSelectedModFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(214, 6);
            // 
            // copyFolderPathToolStripMenuItem
            // 
            this.copyFolderPathToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.copy;
            this.copyFolderPathToolStripMenuItem.Name = "copyFolderPathToolStripMenuItem";
            this.copyFolderPathToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.copyFolderPathToolStripMenuItem.Text = "Copy Folder Path";
            this.copyFolderPathToolStripMenuItem.Click += new System.EventHandler(this.copyFolderPathToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(214, 6);
            // 
            // deleteModToolStripMenuItem
            // 
            this.deleteModToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.delete;
            this.deleteModToolStripMenuItem.Name = "deleteModToolStripMenuItem";
            this.deleteModToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.deleteModToolStripMenuItem.Text = "Delete Mod...";
            this.deleteModToolStripMenuItem.Click += new System.EventHandler(this.deleteModToolStripMenuItem_Click);
            // 
            // ModManagerMenuMain
            // 
            this.ModManagerMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modsToolStripMenuItem,
            this.songsToolStripMenuItem,
            this.scriptModEditorsToolStripMenuItem});
            this.ModManagerMenuMain.Location = new System.Drawing.Point(0, 0);
            this.ModManagerMenuMain.Name = "ModManagerMenuMain";
            this.ModManagerMenuMain.Size = new System.Drawing.Size(1264, 24);
            this.ModManagerMenuMain.TabIndex = 1;
            this.ModManagerMenuMain.Text = "ModManagerMenuMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageSaveFilesToolStripMenuItem,
            this.rockStarCreatorCharacterManagerToolStripMenuItem,
            this.toolStripSeparator4,
            this.closeModManagerToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // manageSaveFilesToolStripMenuItem
            // 
            this.manageSaveFilesToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.save_manager;
            this.manageSaveFilesToolStripMenuItem.Name = "manageSaveFilesToolStripMenuItem";
            this.manageSaveFilesToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.manageSaveFilesToolStripMenuItem.Text = "Manage Save Files";
            this.manageSaveFilesToolStripMenuItem.Click += new System.EventHandler(this.manageSaveFilesToolStripMenuItem_Click);
            // 
            // rockStarCreatorCharacterManagerToolStripMenuItem
            // 
            this.rockStarCreatorCharacterManagerToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.rsc_manager;
            this.rockStarCreatorCharacterManagerToolStripMenuItem.Name = "rockStarCreatorCharacterManagerToolStripMenuItem";
            this.rockStarCreatorCharacterManagerToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.rockStarCreatorCharacterManagerToolStripMenuItem.Text = "Rock Star Creator Character Manager";
            this.rockStarCreatorCharacterManagerToolStripMenuItem.Click += new System.EventHandler(this.rockStarCreatorCharacterManagerToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(266, 6);
            // 
            // closeModManagerToolStripMenuItem
            // 
            this.closeModManagerToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.exit_program;
            this.closeModManagerToolStripMenuItem.Name = "closeModManagerToolStripMenuItem";
            this.closeModManagerToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.closeModManagerToolStripMenuItem.Text = "Close Mod Manager";
            this.closeModManagerToolStripMenuItem.Click += new System.EventHandler(this.closeModManagerToolStripMenuItem_Click);
            // 
            // modsToolStripMenuItem
            // 
            this.modsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openModsFolderToolStripMenuItem,
            this.installModsToolStripMenuItem,
            this.refreshModsToolStripMenuItem,
            this.findModsToolStripMenuItem,
            this.toolStripSeparator2,
            this.ghwtNexusModsToolStripMenuItem,
            this.wtdeGoogleDriveToolStripMenuItem,
            this.toolStripSeparator1,
            this.openSelectedModConfigToolStripMenuItem,
            this.openSelectedModFolderToolStripMenuItem1,
            this.copySelectedModFolderPathToolStripMenuItem,
            this.toolStripSeparator3,
            this.deleteModToolStripMenuItem1});
            this.modsToolStripMenuItem.Name = "modsToolStripMenuItem";
            this.modsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.modsToolStripMenuItem.Text = "Mods";
            // 
            // openModsFolderToolStripMenuItem
            // 
            this.openModsFolderToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.open_file;
            this.openModsFolderToolStripMenuItem.Name = "openModsFolderToolStripMenuItem";
            this.openModsFolderToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.openModsFolderToolStripMenuItem.Text = "Open Mods Folder";
            this.openModsFolderToolStripMenuItem.Click += new System.EventHandler(this.openModsFolderToolStripMenuItem_Click);
            // 
            // installModsToolStripMenuItem
            // 
            this.installModsToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.download;
            this.installModsToolStripMenuItem.Name = "installModsToolStripMenuItem";
            this.installModsToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.installModsToolStripMenuItem.Text = "Install Mods...";
            this.installModsToolStripMenuItem.Click += new System.EventHandler(this.installModsToolStripMenuItem_Click);
            // 
            // refreshModsToolStripMenuItem
            // 
            this.refreshModsToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.refresh;
            this.refreshModsToolStripMenuItem.Name = "refreshModsToolStripMenuItem";
            this.refreshModsToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.refreshModsToolStripMenuItem.Text = "Refresh Mods";
            this.refreshModsToolStripMenuItem.Click += new System.EventHandler(this.refreshModsToolStripMenuItem_Click);
            // 
            // findModsToolStripMenuItem
            // 
            this.findModsToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.find;
            this.findModsToolStripMenuItem.Name = "findModsToolStripMenuItem";
            this.findModsToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.findModsToolStripMenuItem.Text = "Find Mods...";
            this.findModsToolStripMenuItem.Click += new System.EventHandler(this.findModsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(237, 6);
            // 
            // ghwtNexusModsToolStripMenuItem
            // 
            this.ghwtNexusModsToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.nexus_smaller;
            this.ghwtNexusModsToolStripMenuItem.Name = "ghwtNexusModsToolStripMenuItem";
            this.ghwtNexusModsToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.ghwtNexusModsToolStripMenuItem.Text = "GHWT Nexus Mods";
            this.ghwtNexusModsToolStripMenuItem.Click += new System.EventHandler(this.ghwtNexusModsToolStripMenuItem_Click);
            // 
            // wtdeGoogleDriveToolStripMenuItem
            // 
            this.wtdeGoogleDriveToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.google_drive_smaller;
            this.wtdeGoogleDriveToolStripMenuItem.Name = "wtdeGoogleDriveToolStripMenuItem";
            this.wtdeGoogleDriveToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.wtdeGoogleDriveToolStripMenuItem.Text = "WTDE Google Drive";
            this.wtdeGoogleDriveToolStripMenuItem.Click += new System.EventHandler(this.wtdeGoogleDriveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(237, 6);
            // 
            // openSelectedModConfigToolStripMenuItem
            // 
            this.openSelectedModConfigToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.edit_meta_data;
            this.openSelectedModConfigToolStripMenuItem.Name = "openSelectedModConfigToolStripMenuItem";
            this.openSelectedModConfigToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.openSelectedModConfigToolStripMenuItem.Text = "Open Selected Mod Config...";
            this.openSelectedModConfigToolStripMenuItem.Click += new System.EventHandler(this.openSelectedModConfigToolStripMenuItem_Click);
            // 
            // openSelectedModFolderToolStripMenuItem1
            // 
            this.openSelectedModFolderToolStripMenuItem1.Image = global::WTDE_Launcher_V3.Properties.Resources.open_file;
            this.openSelectedModFolderToolStripMenuItem1.Name = "openSelectedModFolderToolStripMenuItem1";
            this.openSelectedModFolderToolStripMenuItem1.Size = new System.Drawing.Size(240, 22);
            this.openSelectedModFolderToolStripMenuItem1.Text = "Open Selected Mod Folder";
            this.openSelectedModFolderToolStripMenuItem1.Click += new System.EventHandler(this.openSelectedModFolderToolStripMenuItem1_Click);
            // 
            // copySelectedModFolderPathToolStripMenuItem
            // 
            this.copySelectedModFolderPathToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.copy;
            this.copySelectedModFolderPathToolStripMenuItem.Name = "copySelectedModFolderPathToolStripMenuItem";
            this.copySelectedModFolderPathToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.copySelectedModFolderPathToolStripMenuItem.Text = "Copy Selected Mod Folder Path";
            this.copySelectedModFolderPathToolStripMenuItem.Click += new System.EventHandler(this.copySelectedModFolderPathToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(237, 6);
            // 
            // deleteModToolStripMenuItem1
            // 
            this.deleteModToolStripMenuItem1.Image = global::WTDE_Launcher_V3.Properties.Resources.delete;
            this.deleteModToolStripMenuItem1.Name = "deleteModToolStripMenuItem1";
            this.deleteModToolStripMenuItem1.Size = new System.Drawing.Size(240, 22);
            this.deleteModToolStripMenuItem1.Text = "Delete Mod...";
            this.deleteModToolStripMenuItem1.Click += new System.EventHandler(this.deleteModToolStripMenuItem1_Click);
            // 
            // songsToolStripMenuItem
            // 
            this.songsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.songAndSongCategoryManagerToolStripMenuItem,
            this.manageDuplicateSongChecksumsToolStripMenuItem});
            this.songsToolStripMenuItem.Name = "songsToolStripMenuItem";
            this.songsToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.songsToolStripMenuItem.Text = "Songs";
            // 
            // songAndSongCategoryManagerToolStripMenuItem
            // 
            this.songAndSongCategoryManagerToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.music_note;
            this.songAndSongCategoryManagerToolStripMenuItem.Name = "songAndSongCategoryManagerToolStripMenuItem";
            this.songAndSongCategoryManagerToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.songAndSongCategoryManagerToolStripMenuItem.Text = "Song and Song Category Manager";
            this.songAndSongCategoryManagerToolStripMenuItem.Click += new System.EventHandler(this.songAndSongCategoryManagerToolStripMenuItem_Click);
            // 
            // manageDuplicateSongChecksumsToolStripMenuItem
            // 
            this.manageDuplicateSongChecksumsToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.copy;
            this.manageDuplicateSongChecksumsToolStripMenuItem.Name = "manageDuplicateSongChecksumsToolStripMenuItem";
            this.manageDuplicateSongChecksumsToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.manageDuplicateSongChecksumsToolStripMenuItem.Text = "Manage Duplicate Song Checksums";
            this.manageDuplicateSongChecksumsToolStripMenuItem.Click += new System.EventHandler(this.manageDuplicateSongChecksumsToolStripMenuItem_Click);
            // 
            // scriptModEditorsToolStripMenuItem
            // 
            this.scriptModEditorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gemThemeDesignerToolStripMenuItem,
            this.assignGH3SPFXToCharacterModToolStripMenuItem,
            this.toolStripSeparator7,
            this.starPowerColorModifierToolStripMenuItem,
            this.extendedHyperspeedToolStripMenuItem});
            this.scriptModEditorsToolStripMenuItem.Name = "scriptModEditorsToolStripMenuItem";
            this.scriptModEditorsToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.scriptModEditorsToolStripMenuItem.Text = "Script Mod Editors";
            // 
            // gemThemeDesignerToolStripMenuItem
            // 
            this.gemThemeDesignerToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.theme_colors;
            this.gemThemeDesignerToolStripMenuItem.Name = "gemThemeDesignerToolStripMenuItem";
            this.gemThemeDesignerToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.gemThemeDesignerToolStripMenuItem.Text = "Gem Theme Designer...";
            this.gemThemeDesignerToolStripMenuItem.Click += new System.EventHandler(this.gemThemeDesignerToolStripMenuItem_Click);
            // 
            // assignGH3SPFXToCharacterModToolStripMenuItem
            // 
            this.assignGH3SPFXToCharacterModToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.gh3_sp_fx;
            this.assignGH3SPFXToCharacterModToolStripMenuItem.Name = "assignGH3SPFXToCharacterModToolStripMenuItem";
            this.assignGH3SPFXToCharacterModToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.assignGH3SPFXToCharacterModToolStripMenuItem.Text = "Assign GH3 SP FX to Character Mod(s)...";
            this.assignGH3SPFXToCharacterModToolStripMenuItem.Click += new System.EventHandler(this.assignGH3SPFXToCharacterModToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(282, 6);
            // 
            // starPowerColorModifierToolStripMenuItem
            // 
            this.starPowerColorModifierToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.star_power;
            this.starPowerColorModifierToolStripMenuItem.Name = "starPowerColorModifierToolStripMenuItem";
            this.starPowerColorModifierToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.starPowerColorModifierToolStripMenuItem.Text = "Star Power Color Modifier...";
            this.starPowerColorModifierToolStripMenuItem.Click += new System.EventHandler(this.starPowerColorModifierToolStripMenuItem_Click);
            // 
            // extendedHyperspeedToolStripMenuItem
            // 
            this.extendedHyperspeedToolStripMenuItem.Image = global::WTDE_Launcher_V3.Properties.Resources.highway;
            this.extendedHyperspeedToolStripMenuItem.Name = "extendedHyperspeedToolStripMenuItem";
            this.extendedHyperspeedToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.extendedHyperspeedToolStripMenuItem.Text = "Extended Hyperspeed...";
            this.extendedHyperspeedToolStripMenuItem.Click += new System.EventHandler(this.extendedHyperspeedToolStripMenuItem_Click);
            // 
            // StatusBarMain
            // 
            this.StatusBarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabelMain});
            this.StatusBarMain.Location = new System.Drawing.Point(0, 659);
            this.StatusBarMain.Name = "StatusBarMain";
            this.StatusBarMain.Size = new System.Drawing.Size(1264, 22);
            this.StatusBarMain.TabIndex = 2;
            this.StatusBarMain.Text = "StatusBarMain";
            // 
            // StatusLabelMain
            // 
            this.StatusLabelMain.Name = "StatusLabelMain";
            this.StatusLabelMain.Size = new System.Drawing.Size(473, 17);
            this.StatusLabelMain.Text = "Select a mod from the list or browse the menus to run various other actions or ma" +
    "nagers";
            // 
            // ModManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.StatusBarMain);
            this.Controls.Add(this.UserContentModsTree);
            this.Controls.Add(this.ModManagerMenuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ModManagerMenuMain;
            this.MaximizeBox = false;
            this.Name = "ModManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WTDE Mod Manager";
            this.ModTreeContext.ResumeLayout(false);
            this.ModManagerMenuMain.ResumeLayout(false);
            this.ModManagerMenuMain.PerformLayout();
            this.StatusBarMain.ResumeLayout(false);
            this.StatusBarMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView UserContentModsTree;
        private System.Windows.Forms.ColumnHeader ModName;
        private System.Windows.Forms.ColumnHeader ModAuthor;
        private System.Windows.Forms.ColumnHeader ModType;
        private System.Windows.Forms.ColumnHeader ModVersion;
        private System.Windows.Forms.ColumnHeader ModDescription;
        private System.Windows.Forms.ColumnHeader ModPath;
        private System.Windows.Forms.MenuStrip ModManagerMenuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem songsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip StatusBarMain;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelMain;
        private System.Windows.Forms.ToolStripMenuItem refreshModsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem installModsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem songAndSongCategoryManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDuplicateSongChecksumsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem manageSaveFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSelectedModConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem closeModManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openModsFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findModsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ModTreeContext;
        private System.Windows.Forms.ToolStripMenuItem openSelectedModConfigToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openSelectedModFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem deleteModToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSelectedModFolderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteModToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem copyFolderPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedModFolderPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rockStarCreatorCharacterManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ghwtNexusModsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wtdeGoogleDriveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem scriptModEditorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem starPowerColorModifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extendedHyperspeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gemThemeDesignerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignGH3SPFXToCharacterModToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}