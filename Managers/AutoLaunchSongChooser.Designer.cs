namespace WTDE_Launcher_V3.Managers {
    partial class AutoLaunchSongChooser {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoLaunchSongChooser));
            this.AutoLaunchQueueList = new System.Windows.Forms.ListBox();
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.SongQueueHeader = new System.Windows.Forms.Label();
            this.WTStockSongsList = new System.Windows.Forms.ListBox();
            this.StockSongsHeader = new System.Windows.Forms.Label();
            this.ModSongsList = new System.Windows.Forms.ListBox();
            this.ModSongsHeader = new System.Windows.Forms.Label();
            this.AddSongModsToQueueButton = new System.Windows.Forms.Button();
            this.ResetSongModFilter = new System.Windows.Forms.Button();
            this.ApplySongModSearch = new System.Windows.Forms.Button();
            this.SongModFilter = new System.Windows.Forms.TextBox();
            this.AddStockSongToQueueButton = new System.Windows.Forms.Button();
            this.ResetStockSongFilter = new System.Windows.Forms.Button();
            this.ApplyStockSongSearch = new System.Windows.Forms.Button();
            this.StockSongFilter = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.RemoveSelectedSongsFromQueue = new System.Windows.Forms.Button();
            this.TopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.WarningLogoIcon = new System.Windows.Forms.PictureBox();
            this.OverMaxSizeLabel = new System.Windows.Forms.Label();
            this.MoveUpInQueueButton = new System.Windows.Forms.Button();
            this.MoveDownInQueueButton = new System.Windows.Forms.Button();
            this.TopMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarningLogoIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // AutoLaunchQueueList
            // 
            this.AutoLaunchQueueList.FormattingEnabled = true;
            this.AutoLaunchQueueList.Location = new System.Drawing.Point(19, 65);
            this.AutoLaunchQueueList.Name = "AutoLaunchQueueList";
            this.AutoLaunchQueueList.Size = new System.Drawing.Size(225, 381);
            this.AutoLaunchQueueList.TabIndex = 0;
            this.AutoLaunchQueueList.SelectedIndexChanged += new System.EventHandler(this.AutoLaunchQueueList_SelectedIndexChanged);
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 26);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(610, 13);
            this.InfoHeaderLabel.TabIndex = 1;
            this.InfoHeaderLabel.Text = "Auto Launch: Song List Manager: Manage the list of songs that will be played in t" +
    "he Auto Launch rotation.";
            // 
            // SongQueueHeader
            // 
            this.SongQueueHeader.AutoSize = true;
            this.SongQueueHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.SongQueueHeader.Location = new System.Drawing.Point(11, 49);
            this.SongQueueHeader.Name = "SongQueueHeader";
            this.SongQueueHeader.Size = new System.Drawing.Size(81, 13);
            this.SongQueueHeader.TabIndex = 1;
            this.SongQueueHeader.Text = "Song Queue:";
            // 
            // WTStockSongsList
            // 
            this.WTStockSongsList.FormattingEnabled = true;
            this.WTStockSongsList.Location = new System.Drawing.Point(290, 65);
            this.WTStockSongsList.Name = "WTStockSongsList";
            this.WTStockSongsList.Size = new System.Drawing.Size(225, 381);
            this.WTStockSongsList.TabIndex = 0;
            this.WTStockSongsList.SelectedIndexChanged += new System.EventHandler(this.WTStockSongsList_SelectedIndexChanged);
            // 
            // StockSongsHeader
            // 
            this.StockSongsHeader.AutoSize = true;
            this.StockSongsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.StockSongsHeader.Location = new System.Drawing.Point(282, 49);
            this.StockSongsHeader.Name = "StockSongsHeader";
            this.StockSongsHeader.Size = new System.Drawing.Size(90, 13);
            this.StockSongsHeader.TabIndex = 1;
            this.StockSongsHeader.Text = "Built-In Songs:";
            // 
            // ModSongsList
            // 
            this.ModSongsList.FormattingEnabled = true;
            this.ModSongsList.Location = new System.Drawing.Point(562, 65);
            this.ModSongsList.Name = "ModSongsList";
            this.ModSongsList.Size = new System.Drawing.Size(225, 381);
            this.ModSongsList.TabIndex = 0;
            this.ModSongsList.SelectedIndexChanged += new System.EventHandler(this.ModSongsList_SelectedIndexChanged);
            // 
            // ModSongsHeader
            // 
            this.ModSongsHeader.AutoSize = true;
            this.ModSongsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ModSongsHeader.Location = new System.Drawing.Point(554, 49);
            this.ModSongsHeader.Name = "ModSongsHeader";
            this.ModSongsHeader.Size = new System.Drawing.Size(74, 13);
            this.ModSongsHeader.TabIndex = 1;
            this.ModSongsHeader.Text = "Mod Songs:";
            // 
            // AddSongModsToQueueButton
            // 
            this.AddSongModsToQueueButton.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.add_black;
            this.AddSongModsToQueueButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddSongModsToQueueButton.Location = new System.Drawing.Point(764, 447);
            this.AddSongModsToQueueButton.Name = "AddSongModsToQueueButton";
            this.AddSongModsToQueueButton.Size = new System.Drawing.Size(23, 23);
            this.AddSongModsToQueueButton.TabIndex = 36;
            this.AddSongModsToQueueButton.UseVisualStyleBackColor = true;
            this.AddSongModsToQueueButton.Click += new System.EventHandler(this.AddSongModsToQueueButton_Click);
            // 
            // ResetSongModFilter
            // 
            this.ResetSongModFilter.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.delete_black;
            this.ResetSongModFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ResetSongModFilter.Location = new System.Drawing.Point(741, 447);
            this.ResetSongModFilter.Name = "ResetSongModFilter";
            this.ResetSongModFilter.Size = new System.Drawing.Size(23, 23);
            this.ResetSongModFilter.TabIndex = 37;
            this.ResetSongModFilter.UseVisualStyleBackColor = true;
            this.ResetSongModFilter.Click += new System.EventHandler(this.ResetSongModFilter_Click);
            // 
            // ApplySongModSearch
            // 
            this.ApplySongModSearch.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.find_tiny;
            this.ApplySongModSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ApplySongModSearch.Location = new System.Drawing.Point(718, 447);
            this.ApplySongModSearch.Name = "ApplySongModSearch";
            this.ApplySongModSearch.Size = new System.Drawing.Size(23, 23);
            this.ApplySongModSearch.TabIndex = 35;
            this.ApplySongModSearch.UseVisualStyleBackColor = true;
            this.ApplySongModSearch.Click += new System.EventHandler(this.ApplySongModSearch_Click);
            // 
            // SongModFilter
            // 
            this.SongModFilter.Location = new System.Drawing.Point(562, 449);
            this.SongModFilter.Name = "SongModFilter";
            this.SongModFilter.Size = new System.Drawing.Size(150, 20);
            this.SongModFilter.TabIndex = 34;
            // 
            // AddStockSongToQueueButton
            // 
            this.AddStockSongToQueueButton.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.add_black;
            this.AddStockSongToQueueButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddStockSongToQueueButton.Location = new System.Drawing.Point(492, 447);
            this.AddStockSongToQueueButton.Name = "AddStockSongToQueueButton";
            this.AddStockSongToQueueButton.Size = new System.Drawing.Size(23, 23);
            this.AddStockSongToQueueButton.TabIndex = 40;
            this.AddStockSongToQueueButton.UseVisualStyleBackColor = true;
            this.AddStockSongToQueueButton.Click += new System.EventHandler(this.AddStockSongToQueueButton_Click);
            // 
            // ResetStockSongFilter
            // 
            this.ResetStockSongFilter.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.delete_black;
            this.ResetStockSongFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ResetStockSongFilter.Location = new System.Drawing.Point(469, 447);
            this.ResetStockSongFilter.Name = "ResetStockSongFilter";
            this.ResetStockSongFilter.Size = new System.Drawing.Size(23, 23);
            this.ResetStockSongFilter.TabIndex = 41;
            this.ResetStockSongFilter.UseVisualStyleBackColor = true;
            this.ResetStockSongFilter.Click += new System.EventHandler(this.ResetStockSongFilter_Click);
            // 
            // ApplyStockSongSearch
            // 
            this.ApplyStockSongSearch.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.find_tiny;
            this.ApplyStockSongSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ApplyStockSongSearch.Location = new System.Drawing.Point(446, 447);
            this.ApplyStockSongSearch.Name = "ApplyStockSongSearch";
            this.ApplyStockSongSearch.Size = new System.Drawing.Size(23, 23);
            this.ApplyStockSongSearch.TabIndex = 39;
            this.ApplyStockSongSearch.UseVisualStyleBackColor = true;
            this.ApplyStockSongSearch.Click += new System.EventHandler(this.ApplyStockSongSearch_Click);
            // 
            // StockSongFilter
            // 
            this.StockSongFilter.Location = new System.Drawing.Point(290, 449);
            this.StockSongFilter.Name = "StockSongFilter";
            this.StockSongFilter.Size = new System.Drawing.Size(150, 20);
            this.StockSongFilter.TabIndex = 38;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(720, 534);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(82, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(632, 534);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(82, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // RemoveSelectedSongsFromQueue
            // 
            this.RemoveSelectedSongsFromQueue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RemoveSelectedSongsFromQueue.Location = new System.Drawing.Point(187, 447);
            this.RemoveSelectedSongsFromQueue.Name = "RemoveSelectedSongsFromQueue";
            this.RemoveSelectedSongsFromQueue.Size = new System.Drawing.Size(57, 23);
            this.RemoveSelectedSongsFromQueue.TabIndex = 44;
            this.RemoveSelectedSongsFromQueue.Text = "Remove";
            this.RemoveSelectedSongsFromQueue.UseVisualStyleBackColor = true;
            this.RemoveSelectedSongsFromQueue.Click += new System.EventHandler(this.RemoveSelectedSongsFromQueue_Click);
            // 
            // TopMenuStrip
            // 
            this.TopMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.TopMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TopMenuStrip.Name = "TopMenuStrip";
            this.TopMenuStrip.Size = new System.Drawing.Size(807, 24);
            this.TopMenuStrip.TabIndex = 45;
            this.TopMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // WarningLogoIcon
            // 
            this.WarningLogoIcon.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.alert;
            this.WarningLogoIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WarningLogoIcon.Location = new System.Drawing.Point(19, 475);
            this.WarningLogoIcon.Name = "WarningLogoIcon";
            this.WarningLogoIcon.Size = new System.Drawing.Size(56, 56);
            this.WarningLogoIcon.TabIndex = 46;
            this.WarningLogoIcon.TabStop = false;
            this.WarningLogoIcon.Visible = false;
            // 
            // OverMaxSizeLabel
            // 
            this.OverMaxSizeLabel.AutoSize = true;
            this.OverMaxSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.OverMaxSizeLabel.ForeColor = System.Drawing.Color.Red;
            this.OverMaxSizeLabel.Location = new System.Drawing.Point(81, 475);
            this.OverMaxSizeLabel.Name = "OverMaxSizeLabel";
            this.OverMaxSizeLabel.Size = new System.Drawing.Size(454, 52);
            this.OverMaxSizeLabel.TabIndex = 47;
            this.OverMaxSizeLabel.Text = resources.GetString("OverMaxSizeLabel.Text");
            this.OverMaxSizeLabel.Visible = false;
            // 
            // MoveUpInQueueButton
            // 
            this.MoveUpInQueueButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MoveUpInQueueButton.Location = new System.Drawing.Point(19, 447);
            this.MoveUpInQueueButton.Name = "MoveUpInQueueButton";
            this.MoveUpInQueueButton.Size = new System.Drawing.Size(71, 23);
            this.MoveUpInQueueButton.TabIndex = 44;
            this.MoveUpInQueueButton.Text = "Move Up";
            this.MoveUpInQueueButton.UseVisualStyleBackColor = true;
            this.MoveUpInQueueButton.Click += new System.EventHandler(this.MoveUpInQueueButton_Click);
            // 
            // MoveDownInQueueButton
            // 
            this.MoveDownInQueueButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MoveDownInQueueButton.Location = new System.Drawing.Point(96, 447);
            this.MoveDownInQueueButton.Name = "MoveDownInQueueButton";
            this.MoveDownInQueueButton.Size = new System.Drawing.Size(85, 23);
            this.MoveDownInQueueButton.TabIndex = 44;
            this.MoveDownInQueueButton.Text = "Move Down";
            this.MoveDownInQueueButton.UseVisualStyleBackColor = true;
            this.MoveDownInQueueButton.Click += new System.EventHandler(this.MoveDownInQueueButton_Click);
            // 
            // AutoLaunchSongChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(807, 561);
            this.Controls.Add(this.OverMaxSizeLabel);
            this.Controls.Add(this.WarningLogoIcon);
            this.Controls.Add(this.MoveDownInQueueButton);
            this.Controls.Add(this.MoveUpInQueueButton);
            this.Controls.Add(this.RemoveSelectedSongsFromQueue);
            this.Controls.Add(this.AddStockSongToQueueButton);
            this.Controls.Add(this.ResetStockSongFilter);
            this.Controls.Add(this.ApplyStockSongSearch);
            this.Controls.Add(this.StockSongFilter);
            this.Controls.Add(this.AddSongModsToQueueButton);
            this.Controls.Add(this.ResetSongModFilter);
            this.Controls.Add(this.ApplySongModSearch);
            this.Controls.Add(this.SongModFilter);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ModSongsHeader);
            this.Controls.Add(this.StockSongsHeader);
            this.Controls.Add(this.SongQueueHeader);
            this.Controls.Add(this.InfoHeaderLabel);
            this.Controls.Add(this.ModSongsList);
            this.Controls.Add(this.WTStockSongsList);
            this.Controls.Add(this.AutoLaunchQueueList);
            this.Controls.Add(this.TopMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.TopMenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoLaunchSongChooser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Launch: Song List Manager";
            this.TopMenuStrip.ResumeLayout(false);
            this.TopMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarningLogoIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AutoLaunchQueueList;
        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.Label SongQueueHeader;
        private System.Windows.Forms.ListBox WTStockSongsList;
        private System.Windows.Forms.Label StockSongsHeader;
        private System.Windows.Forms.ListBox ModSongsList;
        private System.Windows.Forms.Label ModSongsHeader;
        private System.Windows.Forms.Button AddSongModsToQueueButton;
        private System.Windows.Forms.Button ResetSongModFilter;
        private System.Windows.Forms.Button ApplySongModSearch;
        private System.Windows.Forms.TextBox SongModFilter;
        private System.Windows.Forms.Button AddStockSongToQueueButton;
        private System.Windows.Forms.Button ResetStockSongFilter;
        private System.Windows.Forms.Button ApplyStockSongSearch;
        private System.Windows.Forms.TextBox StockSongFilter;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button RemoveSelectedSongsFromQueue;
        private System.Windows.Forms.MenuStrip TopMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolTip ToolTipMain;
        private System.Windows.Forms.PictureBox WarningLogoIcon;
        private System.Windows.Forms.Label OverMaxSizeLabel;
        private System.Windows.Forms.Button MoveUpInQueueButton;
        private System.Windows.Forms.Button MoveDownInQueueButton;
    }
}