﻿namespace WTDE_Launcher_V3.Managers {
    partial class SelectCharacterMod {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCharacterMod));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.CharModsHeader = new System.Windows.Forms.Label();
            this.CharacterModsList = new System.Windows.Forms.ListBox();
            this.RefreshCharModsButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.StockCharactersList = new System.Windows.Forms.ListBox();
            this.IGNCharsHeader = new System.Windows.Forms.Label();
            this.SortByCateLabel = new System.Windows.Forms.Label();
            this.GameSortFilter = new System.Windows.Forms.ComboBox();
            this.ExportCharListButton = new System.Windows.Forms.Button();
            this.OpenCASManagerButton = new System.Windows.Forms.Button();
            this.ResetStockSearchFilter = new System.Windows.Forms.Button();
            this.ApplyStockSearchButton = new System.Windows.Forms.Button();
            this.StockCharacterFilter = new System.Windows.Forms.TextBox();
            this.ModCharacterFilter = new System.Windows.Forms.TextBox();
            this.ApplyModSearchButton = new System.Windows.Forms.Button();
            this.ResetModSearchFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(219, 13);
            this.InfoHeaderLabel.TabIndex = 0;
            this.InfoHeaderLabel.Text = "Select Character: Select a character.";
            // 
            // CharModsHeader
            // 
            this.CharModsHeader.AutoSize = true;
            this.CharModsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.CharModsHeader.Location = new System.Drawing.Point(387, 22);
            this.CharModsHeader.Name = "CharModsHeader";
            this.CharModsHeader.Size = new System.Drawing.Size(100, 13);
            this.CharModsHeader.TabIndex = 1;
            this.CharModsHeader.Text = "Character Mods:";
            // 
            // CharacterModsList
            // 
            this.CharacterModsList.FormattingEnabled = true;
            this.CharacterModsList.Location = new System.Drawing.Point(397, 38);
            this.CharacterModsList.Name = "CharacterModsList";
            this.CharacterModsList.Size = new System.Drawing.Size(345, 342);
            this.CharacterModsList.TabIndex = 2;
            this.CharacterModsList.SelectedIndexChanged += new System.EventHandler(this.CharacterModsList_SelectedIndexChanged);
            // 
            // RefreshCharModsButton
            // 
            this.RefreshCharModsButton.Location = new System.Drawing.Point(397, 409);
            this.RefreshCharModsButton.Name = "RefreshCharModsButton";
            this.RefreshCharModsButton.Size = new System.Drawing.Size(157, 23);
            this.RefreshCharModsButton.TabIndex = 3;
            this.RefreshCharModsButton.Text = "Refresh List";
            this.RefreshCharModsButton.UseVisualStyleBackColor = true;
            this.RefreshCharModsButton.Click += new System.EventHandler(this.RefreshCharModsButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(667, 436);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(586, 436);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // StockCharactersList
            // 
            this.StockCharactersList.FormattingEnabled = true;
            this.StockCharactersList.Location = new System.Drawing.Point(19, 77);
            this.StockCharactersList.Name = "StockCharactersList";
            this.StockCharactersList.Size = new System.Drawing.Size(345, 303);
            this.StockCharactersList.TabIndex = 6;
            this.StockCharactersList.SelectedIndexChanged += new System.EventHandler(this.StockCharactersList_SelectedIndexChanged);
            // 
            // IGNCharsHeader
            // 
            this.IGNCharsHeader.AutoSize = true;
            this.IGNCharsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.IGNCharsHeader.Location = new System.Drawing.Point(9, 22);
            this.IGNCharsHeader.Name = "IGNCharsHeader";
            this.IGNCharsHeader.Size = new System.Drawing.Size(123, 13);
            this.IGNCharsHeader.TabIndex = 7;
            this.IGNCharsHeader.Text = "In-Game Characters:";
            // 
            // SortByCateLabel
            // 
            this.SortByCateLabel.AutoSize = true;
            this.SortByCateLabel.Location = new System.Drawing.Point(26, 47);
            this.SortByCateLabel.Name = "SortByCateLabel";
            this.SortByCateLabel.Size = new System.Drawing.Size(44, 13);
            this.SortByCateLabel.TabIndex = 8;
            this.SortByCateLabel.Text = "Sort By:";
            // 
            // GameSortFilter
            // 
            this.GameSortFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameSortFilter.FormattingEnabled = true;
            this.GameSortFilter.Items.AddRange(new object[] {
            "Guitar Hero: World Tour",
            "Guitar Hero I",
            "Guitar Hero II",
            "Guitar Hero III",
            "Guitar Hero: Aerosmith",
            "Guitar Hero: On Tour",
            "Band Hero DS",
            "Guitar Hero: Metallica",
            "Guitar Hero: Van Halen",
            "Guitar Hero 5",
            "Band Hero",
            "Guitar Hero: Warriors of Rock",
            "DJ Hero",
            "GHWT: Definitive Edition",
            "Tony Hawk Series",
            "Random Characters"});
            this.GameSortFilter.Location = new System.Drawing.Point(76, 44);
            this.GameSortFilter.Name = "GameSortFilter";
            this.GameSortFilter.Size = new System.Drawing.Size(288, 21);
            this.GameSortFilter.TabIndex = 9;
            this.GameSortFilter.SelectedIndexChanged += new System.EventHandler(this.GameSortFilter_SelectedIndexChanged);
            // 
            // ExportCharListButton
            // 
            this.ExportCharListButton.Location = new System.Drawing.Point(585, 409);
            this.ExportCharListButton.Name = "ExportCharListButton";
            this.ExportCharListButton.Size = new System.Drawing.Size(157, 23);
            this.ExportCharListButton.TabIndex = 10;
            this.ExportCharListButton.Text = "Export Character List...";
            this.ExportCharListButton.UseVisualStyleBackColor = true;
            this.ExportCharListButton.Click += new System.EventHandler(this.ExportCharListButton_Click);
            // 
            // OpenCASManagerButton
            // 
            this.OpenCASManagerButton.Location = new System.Drawing.Point(19, 409);
            this.OpenCASManagerButton.Name = "OpenCASManagerButton";
            this.OpenCASManagerButton.Size = new System.Drawing.Size(345, 23);
            this.OpenCASManagerButton.TabIndex = 3;
            this.OpenCASManagerButton.Text = "Rock Star Creator Character Manager...";
            this.OpenCASManagerButton.UseVisualStyleBackColor = true;
            this.OpenCASManagerButton.Click += new System.EventHandler(this.OpenCASManagerButton_Click);
            // 
            // ResetStockSearchFilter
            // 
            this.ResetStockSearchFilter.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.delete_black;
            this.ResetStockSearchFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ResetStockSearchFilter.Location = new System.Drawing.Point(341, 383);
            this.ResetStockSearchFilter.Name = "ResetStockSearchFilter";
            this.ResetStockSearchFilter.Size = new System.Drawing.Size(23, 23);
            this.ResetStockSearchFilter.TabIndex = 37;
            this.ResetStockSearchFilter.UseVisualStyleBackColor = true;
            this.ResetStockSearchFilter.Click += new System.EventHandler(this.ResetStockSearchFilter_Click);
            // 
            // ApplyStockSearchButton
            // 
            this.ApplyStockSearchButton.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.find_tiny;
            this.ApplyStockSearchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ApplyStockSearchButton.Location = new System.Drawing.Point(318, 383);
            this.ApplyStockSearchButton.Name = "ApplyStockSearchButton";
            this.ApplyStockSearchButton.Size = new System.Drawing.Size(23, 23);
            this.ApplyStockSearchButton.TabIndex = 35;
            this.ApplyStockSearchButton.UseVisualStyleBackColor = true;
            this.ApplyStockSearchButton.Click += new System.EventHandler(this.ApplyStockSearchButton_Click);
            // 
            // StockCharacterFilter
            // 
            this.StockCharacterFilter.Location = new System.Drawing.Point(19, 385);
            this.StockCharacterFilter.Name = "StockCharacterFilter";
            this.StockCharacterFilter.Size = new System.Drawing.Size(293, 20);
            this.StockCharacterFilter.TabIndex = 34;
            // 
            // ModCharacterFilter
            // 
            this.ModCharacterFilter.Location = new System.Drawing.Point(397, 385);
            this.ModCharacterFilter.Name = "ModCharacterFilter";
            this.ModCharacterFilter.Size = new System.Drawing.Size(293, 20);
            this.ModCharacterFilter.TabIndex = 34;
            // 
            // ApplyModSearchButton
            // 
            this.ApplyModSearchButton.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.find_tiny;
            this.ApplyModSearchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ApplyModSearchButton.Location = new System.Drawing.Point(696, 383);
            this.ApplyModSearchButton.Name = "ApplyModSearchButton";
            this.ApplyModSearchButton.Size = new System.Drawing.Size(23, 23);
            this.ApplyModSearchButton.TabIndex = 35;
            this.ApplyModSearchButton.UseVisualStyleBackColor = true;
            this.ApplyModSearchButton.Click += new System.EventHandler(this.ApplyModSearchButton_Click);
            // 
            // ResetModSearchFilter
            // 
            this.ResetModSearchFilter.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.delete_black;
            this.ResetModSearchFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ResetModSearchFilter.Location = new System.Drawing.Point(719, 383);
            this.ResetModSearchFilter.Name = "ResetModSearchFilter";
            this.ResetModSearchFilter.Size = new System.Drawing.Size(23, 23);
            this.ResetModSearchFilter.TabIndex = 37;
            this.ResetModSearchFilter.UseVisualStyleBackColor = true;
            this.ResetModSearchFilter.Click += new System.EventHandler(this.ResetModSearchFilter_Click);
            // 
            // SelectCharacterMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(751, 465);
            this.Controls.Add(this.ResetModSearchFilter);
            this.Controls.Add(this.ResetStockSearchFilter);
            this.Controls.Add(this.ApplyModSearchButton);
            this.Controls.Add(this.ApplyStockSearchButton);
            this.Controls.Add(this.ModCharacterFilter);
            this.Controls.Add(this.StockCharacterFilter);
            this.Controls.Add(this.ExportCharListButton);
            this.Controls.Add(this.GameSortFilter);
            this.Controls.Add(this.SortByCateLabel);
            this.Controls.Add(this.IGNCharsHeader);
            this.Controls.Add(this.StockCharactersList);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OpenCASManagerButton);
            this.Controls.Add(this.RefreshCharModsButton);
            this.Controls.Add(this.CharacterModsList);
            this.Controls.Add(this.CharModsHeader);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectCharacterMod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mod Selector: Select Character";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.Label CharModsHeader;
        private System.Windows.Forms.ListBox CharacterModsList;
        private System.Windows.Forms.Button RefreshCharModsButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ListBox StockCharactersList;
        private System.Windows.Forms.Label IGNCharsHeader;
        private System.Windows.Forms.Label SortByCateLabel;
        private System.Windows.Forms.ComboBox GameSortFilter;
        private System.Windows.Forms.Button ExportCharListButton;
        private System.Windows.Forms.Button OpenCASManagerButton;
        private System.Windows.Forms.Button ResetStockSearchFilter;
        private System.Windows.Forms.Button ApplyStockSearchButton;
        private System.Windows.Forms.TextBox StockCharacterFilter;
        private System.Windows.Forms.TextBox ModCharacterFilter;
        private System.Windows.Forms.Button ApplyModSearchButton;
        private System.Windows.Forms.Button ResetModSearchFilter;
    }
}