namespace WTDE_Launcher_V3 {
    partial class DupeChecksumManager {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DupeChecksumManager));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.DupedChecksumsHeader = new System.Windows.Forms.Label();
            this.DupedChecksumsList = new System.Windows.Forms.ListBox();
            this.ModFoldersHeader = new System.Windows.Forms.Label();
            this.ModPathsList = new System.Windows.Forms.ListBox();
            this.ModActionsHeader = new System.Windows.Forms.Label();
            this.DeleteModFolder = new System.Windows.Forms.Button();
            this.OpenModConfig = new System.Windows.Forms.Button();
            this.OpenModFolder = new System.Windows.Forms.Button();
            this.CloseWindow = new System.Windows.Forms.Button();
            this.DSMToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.RefreshDupeChecksumList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(559, 13);
            this.InfoHeaderLabel.TabIndex = 2;
            this.InfoHeaderLabel.Text = "Duplicate Song Checksum Manager: Manage conflicts with song mods with duplicate c" +
    "hecksums.";
            // 
            // DupedChecksumsHeader
            // 
            this.DupedChecksumsHeader.AutoSize = true;
            this.DupedChecksumsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.DupedChecksumsHeader.Location = new System.Drawing.Point(3, 27);
            this.DupedChecksumsHeader.Name = "DupedChecksumsHeader";
            this.DupedChecksumsHeader.Size = new System.Drawing.Size(140, 13);
            this.DupedChecksumsHeader.TabIndex = 5;
            this.DupedChecksumsHeader.Text = "Duplicated Checksums:";
            // 
            // DupedChecksumsList
            // 
            this.DupedChecksumsList.FormattingEnabled = true;
            this.DupedChecksumsList.Location = new System.Drawing.Point(12, 43);
            this.DupedChecksumsList.Name = "DupedChecksumsList";
            this.DupedChecksumsList.Size = new System.Drawing.Size(245, 264);
            this.DupedChecksumsList.TabIndex = 6;
            this.DSMToolTipMain.SetToolTip(this.DupedChecksumsList, "List of all the detected checksums that have occurred in\r\nyour mods folder more t" +
        "han once.");
            this.DupedChecksumsList.SelectedIndexChanged += new System.EventHandler(this.DupedChecksumsList_SelectedIndexChanged);
            // 
            // ModFoldersHeader
            // 
            this.ModFoldersHeader.AutoSize = true;
            this.ModFoldersHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ModFoldersHeader.Location = new System.Drawing.Point(263, 27);
            this.ModFoldersHeader.Name = "ModFoldersHeader";
            this.ModFoldersHeader.Size = new System.Drawing.Size(80, 13);
            this.ModFoldersHeader.TabIndex = 7;
            this.ModFoldersHeader.Text = "Mod Folders:";
            // 
            // ModPathsList
            // 
            this.ModPathsList.FormattingEnabled = true;
            this.ModPathsList.Location = new System.Drawing.Point(272, 43);
            this.ModPathsList.Name = "ModPathsList";
            this.ModPathsList.Size = new System.Drawing.Size(376, 264);
            this.ModPathsList.TabIndex = 8;
            this.DSMToolTipMain.SetToolTip(this.ModPathsList, "List of mod folder paths that contain the same song checksum.");
            this.ModPathsList.SelectedIndexChanged += new System.EventHandler(this.ModPathsList_SelectedIndexChanged);
            // 
            // ModActionsHeader
            // 
            this.ModActionsHeader.AutoSize = true;
            this.ModActionsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ModActionsHeader.Location = new System.Drawing.Point(654, 27);
            this.ModActionsHeader.Name = "ModActionsHeader";
            this.ModActionsHeader.Size = new System.Drawing.Size(53, 13);
            this.ModActionsHeader.TabIndex = 9;
            this.ModActionsHeader.Text = "Actions:";
            // 
            // DeleteModFolder
            // 
            this.DeleteModFolder.Location = new System.Drawing.Point(662, 101);
            this.DeleteModFolder.Name = "DeleteModFolder";
            this.DeleteModFolder.Size = new System.Drawing.Size(182, 23);
            this.DeleteModFolder.TabIndex = 10;
            this.DeleteModFolder.Text = "Delete Mod";
            this.DSMToolTipMain.SetToolTip(this.DeleteModFolder, "Delete the selected mod folder.");
            this.DeleteModFolder.UseVisualStyleBackColor = true;
            this.DeleteModFolder.Click += new System.EventHandler(this.DeleteModFolder_Click);
            // 
            // OpenModConfig
            // 
            this.OpenModConfig.Location = new System.Drawing.Point(662, 43);
            this.OpenModConfig.Name = "OpenModConfig";
            this.OpenModConfig.Size = new System.Drawing.Size(182, 23);
            this.OpenModConfig.TabIndex = 11;
            this.OpenModConfig.Text = "Open Mod Config";
            this.DSMToolTipMain.SetToolTip(this.OpenModConfig, "Open the selected mod\'s INI file.");
            this.OpenModConfig.UseVisualStyleBackColor = true;
            this.OpenModConfig.Click += new System.EventHandler(this.OpenModConfig_Click);
            // 
            // OpenModFolder
            // 
            this.OpenModFolder.Location = new System.Drawing.Point(662, 72);
            this.OpenModFolder.Name = "OpenModFolder";
            this.OpenModFolder.Size = new System.Drawing.Size(182, 23);
            this.OpenModFolder.TabIndex = 12;
            this.OpenModFolder.Text = "Open Mod Folder";
            this.DSMToolTipMain.SetToolTip(this.OpenModFolder, "Open the selected mod folder.");
            this.OpenModFolder.UseVisualStyleBackColor = true;
            this.OpenModFolder.Click += new System.EventHandler(this.OpenModFolder_Click);
            // 
            // CloseWindow
            // 
            this.CloseWindow.Location = new System.Drawing.Point(776, 347);
            this.CloseWindow.Name = "CloseWindow";
            this.CloseWindow.Size = new System.Drawing.Size(75, 23);
            this.CloseWindow.TabIndex = 13;
            this.CloseWindow.Text = "Close";
            this.DSMToolTipMain.SetToolTip(this.CloseWindow, "Closes this window.");
            this.CloseWindow.UseVisualStyleBackColor = true;
            this.CloseWindow.Click += new System.EventHandler(this.CloseWindow_Click);
            // 
            // RefreshDupeChecksumList
            // 
            this.RefreshDupeChecksumList.Location = new System.Drawing.Point(12, 313);
            this.RefreshDupeChecksumList.Name = "RefreshDupeChecksumList";
            this.RefreshDupeChecksumList.Size = new System.Drawing.Size(245, 23);
            this.RefreshDupeChecksumList.TabIndex = 14;
            this.RefreshDupeChecksumList.Text = "Refresh List";
            this.DSMToolTipMain.SetToolTip(this.RefreshDupeChecksumList, "Refresh the list of duplicate checksums.");
            this.RefreshDupeChecksumList.UseVisualStyleBackColor = true;
            this.RefreshDupeChecksumList.Click += new System.EventHandler(this.RefreshDupeChecksumList_Click);
            // 
            // DupeChecksumManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(856, 374);
            this.Controls.Add(this.RefreshDupeChecksumList);
            this.Controls.Add(this.CloseWindow);
            this.Controls.Add(this.OpenModFolder);
            this.Controls.Add(this.OpenModConfig);
            this.Controls.Add(this.DeleteModFolder);
            this.Controls.Add(this.ModActionsHeader);
            this.Controls.Add(this.ModPathsList);
            this.Controls.Add(this.ModFoldersHeader);
            this.Controls.Add(this.DupedChecksumsList);
            this.Controls.Add(this.DupedChecksumsHeader);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DupeChecksumManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mod Manager: Duplicate Song Checksum Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.Label DupedChecksumsHeader;
        private System.Windows.Forms.ListBox DupedChecksumsList;
        private System.Windows.Forms.Label ModFoldersHeader;
        private System.Windows.Forms.ListBox ModPathsList;
        private System.Windows.Forms.Label ModActionsHeader;
        private System.Windows.Forms.Button DeleteModFolder;
        private System.Windows.Forms.Button OpenModConfig;
        private System.Windows.Forms.Button OpenModFolder;
        private System.Windows.Forms.Button CloseWindow;
        private System.Windows.Forms.ToolTip DSMToolTipMain;
        private System.Windows.Forms.Button RefreshDupeChecksumList;
    }
}