namespace WTDE_Launcher_V3.Managers {
    partial class SelectInstrumentMod {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectInstrumentMod));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.ExportInstListsButton = new System.Windows.Forms.Button();
            this.MicStandsTabGroup = new System.Windows.Forms.TabPage();
            this.MicsTabGroup = new System.Windows.Forms.TabPage();
            this.DrumsTabGroup = new System.Windows.Forms.TabPage();
            this.BassesTabGroup = new System.Windows.Forms.TabPage();
            this.GuitarsTabGroup = new System.Windows.Forms.TabPage();
            this.RefreshGtrModsButton = new System.Windows.Forms.Button();
            this.IGNGtrsHeader = new System.Windows.Forms.Label();
            this.GuitarModsList = new System.Windows.Forms.ListBox();
            this.SortByCateGLabel = new System.Windows.Forms.Label();
            this.GuitModsHeader = new System.Windows.Forms.Label();
            this.GameSortFilter = new System.Windows.Forms.ComboBox();
            this.StockGuitarsList = new System.Windows.Forms.ListBox();
            this.InstrumentSelectorTabMaster = new System.Windows.Forms.TabControl();
            this.StockBassesList = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BassModsHeader = new System.Windows.Forms.Label();
            this.SortByCateBLabel = new System.Windows.Forms.Label();
            this.BassModsList = new System.Windows.Forms.ListBox();
            this.IGNBassHeader = new System.Windows.Forms.Label();
            this.RefreshBasModsButton = new System.Windows.Forms.Button();
            this.BassesTabGroup.SuspendLayout();
            this.GuitarsTabGroup.SuspendLayout();
            this.InstrumentSelectorTabMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(234, 13);
            this.InfoHeaderLabel.TabIndex = 4;
            this.InfoHeaderLabel.Text = "Select Instrument: Select an instrument.";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(726, 474);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(83, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(637, 474);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(83, 23);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // ExportInstListsButton
            // 
            this.ExportInstListsButton.Location = new System.Drawing.Point(474, 474);
            this.ExportInstListsButton.Name = "ExportInstListsButton";
            this.ExportInstListsButton.Size = new System.Drawing.Size(157, 23);
            this.ExportInstListsButton.TabIndex = 19;
            this.ExportInstListsButton.Text = "Export Instrument List...";
            this.ExportInstListsButton.UseVisualStyleBackColor = true;
            // 
            // MicStandsTabGroup
            // 
            this.MicStandsTabGroup.Location = new System.Drawing.Point(4, 22);
            this.MicStandsTabGroup.Name = "MicStandsTabGroup";
            this.MicStandsTabGroup.Size = new System.Drawing.Size(782, 424);
            this.MicStandsTabGroup.TabIndex = 5;
            this.MicStandsTabGroup.Text = "Microphone Stands";
            this.MicStandsTabGroup.UseVisualStyleBackColor = true;
            // 
            // MicsTabGroup
            // 
            this.MicsTabGroup.Location = new System.Drawing.Point(4, 22);
            this.MicsTabGroup.Name = "MicsTabGroup";
            this.MicsTabGroup.Size = new System.Drawing.Size(782, 424);
            this.MicsTabGroup.TabIndex = 4;
            this.MicsTabGroup.Text = "Microphones";
            this.MicsTabGroup.UseVisualStyleBackColor = true;
            // 
            // DrumsTabGroup
            // 
            this.DrumsTabGroup.Location = new System.Drawing.Point(4, 22);
            this.DrumsTabGroup.Name = "DrumsTabGroup";
            this.DrumsTabGroup.Size = new System.Drawing.Size(782, 424);
            this.DrumsTabGroup.TabIndex = 3;
            this.DrumsTabGroup.Text = "Drum Kits";
            this.DrumsTabGroup.UseVisualStyleBackColor = true;
            // 
            // BassesTabGroup
            // 
            this.BassesTabGroup.Controls.Add(this.StockBassesList);
            this.BassesTabGroup.Controls.Add(this.comboBox1);
            this.BassesTabGroup.Controls.Add(this.BassModsHeader);
            this.BassesTabGroup.Controls.Add(this.SortByCateBLabel);
            this.BassesTabGroup.Controls.Add(this.BassModsList);
            this.BassesTabGroup.Controls.Add(this.IGNBassHeader);
            this.BassesTabGroup.Controls.Add(this.RefreshBasModsButton);
            this.BassesTabGroup.Location = new System.Drawing.Point(4, 22);
            this.BassesTabGroup.Name = "BassesTabGroup";
            this.BassesTabGroup.Padding = new System.Windows.Forms.Padding(3);
            this.BassesTabGroup.Size = new System.Drawing.Size(782, 424);
            this.BassesTabGroup.TabIndex = 1;
            this.BassesTabGroup.Text = "Basses";
            this.BassesTabGroup.UseVisualStyleBackColor = true;
            // 
            // GuitarsTabGroup
            // 
            this.GuitarsTabGroup.Controls.Add(this.StockGuitarsList);
            this.GuitarsTabGroup.Controls.Add(this.GameSortFilter);
            this.GuitarsTabGroup.Controls.Add(this.GuitModsHeader);
            this.GuitarsTabGroup.Controls.Add(this.SortByCateGLabel);
            this.GuitarsTabGroup.Controls.Add(this.GuitarModsList);
            this.GuitarsTabGroup.Controls.Add(this.IGNGtrsHeader);
            this.GuitarsTabGroup.Controls.Add(this.RefreshGtrModsButton);
            this.GuitarsTabGroup.Location = new System.Drawing.Point(4, 22);
            this.GuitarsTabGroup.Name = "GuitarsTabGroup";
            this.GuitarsTabGroup.Padding = new System.Windows.Forms.Padding(3);
            this.GuitarsTabGroup.Size = new System.Drawing.Size(782, 424);
            this.GuitarsTabGroup.TabIndex = 2;
            this.GuitarsTabGroup.Text = "Guitars";
            this.GuitarsTabGroup.UseVisualStyleBackColor = true;
            // 
            // RefreshGtrModsButton
            // 
            this.RefreshGtrModsButton.Location = new System.Drawing.Point(409, 381);
            this.RefreshGtrModsButton.Name = "RefreshGtrModsButton";
            this.RefreshGtrModsButton.Size = new System.Drawing.Size(345, 23);
            this.RefreshGtrModsButton.TabIndex = 14;
            this.RefreshGtrModsButton.Text = "Refresh List";
            this.RefreshGtrModsButton.UseVisualStyleBackColor = true;
            this.RefreshGtrModsButton.Click += new System.EventHandler(this.RefreshGtrModsButton_Click);
            // 
            // IGNGtrsHeader
            // 
            this.IGNGtrsHeader.AutoSize = true;
            this.IGNGtrsHeader.BackColor = System.Drawing.Color.Transparent;
            this.IGNGtrsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.IGNGtrsHeader.Location = new System.Drawing.Point(21, 17);
            this.IGNGtrsHeader.Name = "IGNGtrsHeader";
            this.IGNGtrsHeader.Size = new System.Drawing.Size(102, 13);
            this.IGNGtrsHeader.TabIndex = 16;
            this.IGNGtrsHeader.Text = "In-Game Guitars:";
            // 
            // GuitarModsList
            // 
            this.GuitarModsList.FormattingEnabled = true;
            this.GuitarModsList.Location = new System.Drawing.Point(409, 33);
            this.GuitarModsList.Name = "GuitarModsList";
            this.GuitarModsList.Size = new System.Drawing.Size(345, 342);
            this.GuitarModsList.TabIndex = 12;
            // 
            // SortByCateGLabel
            // 
            this.SortByCateGLabel.AutoSize = true;
            this.SortByCateGLabel.BackColor = System.Drawing.Color.Transparent;
            this.SortByCateGLabel.Location = new System.Drawing.Point(38, 42);
            this.SortByCateGLabel.Name = "SortByCateGLabel";
            this.SortByCateGLabel.Size = new System.Drawing.Size(44, 13);
            this.SortByCateGLabel.TabIndex = 17;
            this.SortByCateGLabel.Text = "Sort By:";
            // 
            // GuitModsHeader
            // 
            this.GuitModsHeader.AutoSize = true;
            this.GuitModsHeader.BackColor = System.Drawing.Color.Transparent;
            this.GuitModsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.GuitModsHeader.Location = new System.Drawing.Point(399, 17);
            this.GuitModsHeader.Name = "GuitModsHeader";
            this.GuitModsHeader.Size = new System.Drawing.Size(111, 13);
            this.GuitModsHeader.TabIndex = 11;
            this.GuitModsHeader.Text = "Lead Guitar Mods:";
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
            "Guitar Hero: Metallica",
            "Guitar Hero: Van Halen",
            "Guitar Hero 5",
            "Band Hero",
            "Guitar Hero: Warriors of Rock",
            "DJ Hero",
            "GHWT: Definitive Edition",
            "Tony Hawk Series"});
            this.GameSortFilter.Location = new System.Drawing.Point(88, 39);
            this.GameSortFilter.Name = "GameSortFilter";
            this.GameSortFilter.Size = new System.Drawing.Size(288, 21);
            this.GameSortFilter.TabIndex = 18;
            // 
            // StockGuitarsList
            // 
            this.StockGuitarsList.FormattingEnabled = true;
            this.StockGuitarsList.Location = new System.Drawing.Point(31, 72);
            this.StockGuitarsList.Name = "StockGuitarsList";
            this.StockGuitarsList.Size = new System.Drawing.Size(345, 303);
            this.StockGuitarsList.TabIndex = 15;
            // 
            // InstrumentSelectorTabMaster
            // 
            this.InstrumentSelectorTabMaster.Controls.Add(this.GuitarsTabGroup);
            this.InstrumentSelectorTabMaster.Controls.Add(this.BassesTabGroup);
            this.InstrumentSelectorTabMaster.Controls.Add(this.DrumsTabGroup);
            this.InstrumentSelectorTabMaster.Controls.Add(this.MicsTabGroup);
            this.InstrumentSelectorTabMaster.Controls.Add(this.MicStandsTabGroup);
            this.InstrumentSelectorTabMaster.Location = new System.Drawing.Point(13, 18);
            this.InstrumentSelectorTabMaster.Name = "InstrumentSelectorTabMaster";
            this.InstrumentSelectorTabMaster.SelectedIndex = 0;
            this.InstrumentSelectorTabMaster.Size = new System.Drawing.Size(790, 450);
            this.InstrumentSelectorTabMaster.TabIndex = 0;
            // 
            // StockBassesList
            // 
            this.StockBassesList.FormattingEnabled = true;
            this.StockBassesList.Location = new System.Drawing.Point(31, 72);
            this.StockBassesList.Name = "StockBassesList";
            this.StockBassesList.Size = new System.Drawing.Size(345, 303);
            this.StockBassesList.TabIndex = 22;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Guitar Hero: World Tour",
            "Guitar Hero I",
            "Guitar Hero II",
            "Guitar Hero III",
            "Guitar Hero: Aerosmith",
            "Guitar Hero: On Tour",
            "Guitar Hero: Metallica",
            "Guitar Hero: Van Halen",
            "Guitar Hero 5",
            "Band Hero",
            "Guitar Hero: Warriors of Rock",
            "DJ Hero",
            "GHWT: Definitive Edition",
            "Tony Hawk Series"});
            this.comboBox1.Location = new System.Drawing.Point(88, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(288, 21);
            this.comboBox1.TabIndex = 25;
            // 
            // BassModsHeader
            // 
            this.BassModsHeader.AutoSize = true;
            this.BassModsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BassModsHeader.Location = new System.Drawing.Point(399, 17);
            this.BassModsHeader.Name = "BassModsHeader";
            this.BassModsHeader.Size = new System.Drawing.Size(110, 13);
            this.BassModsHeader.TabIndex = 19;
            this.BassModsHeader.Text = "Bass Guitar Mods:";
            // 
            // SortByCateBLabel
            // 
            this.SortByCateBLabel.AutoSize = true;
            this.SortByCateBLabel.Location = new System.Drawing.Point(38, 42);
            this.SortByCateBLabel.Name = "SortByCateBLabel";
            this.SortByCateBLabel.Size = new System.Drawing.Size(44, 13);
            this.SortByCateBLabel.TabIndex = 24;
            this.SortByCateBLabel.Text = "Sort By:";
            // 
            // BassModsList
            // 
            this.BassModsList.FormattingEnabled = true;
            this.BassModsList.Location = new System.Drawing.Point(409, 33);
            this.BassModsList.Name = "BassModsList";
            this.BassModsList.Size = new System.Drawing.Size(345, 342);
            this.BassModsList.TabIndex = 20;
            // 
            // IGNBassHeader
            // 
            this.IGNBassHeader.AutoSize = true;
            this.IGNBassHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.IGNBassHeader.Location = new System.Drawing.Point(21, 17);
            this.IGNBassHeader.Name = "IGNBassHeader";
            this.IGNBassHeader.Size = new System.Drawing.Size(102, 13);
            this.IGNBassHeader.TabIndex = 23;
            this.IGNBassHeader.Text = "In-Game Basses:";
            // 
            // RefreshBasModsButton
            // 
            this.RefreshBasModsButton.Location = new System.Drawing.Point(409, 381);
            this.RefreshBasModsButton.Name = "RefreshBasModsButton";
            this.RefreshBasModsButton.Size = new System.Drawing.Size(345, 23);
            this.RefreshBasModsButton.TabIndex = 21;
            this.RefreshBasModsButton.Text = "Refresh List";
            this.RefreshBasModsButton.UseVisualStyleBackColor = true;
            // 
            // SelectInstrumentMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(814, 501);
            this.Controls.Add(this.ExportInstListsButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.InfoHeaderLabel);
            this.Controls.Add(this.InstrumentSelectorTabMaster);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectInstrumentMod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mod Selector: Select Instrument";
            this.BassesTabGroup.ResumeLayout(false);
            this.BassesTabGroup.PerformLayout();
            this.GuitarsTabGroup.ResumeLayout(false);
            this.GuitarsTabGroup.PerformLayout();
            this.InstrumentSelectorTabMaster.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button ExportInstListsButton;
        private System.Windows.Forms.TabPage MicStandsTabGroup;
        private System.Windows.Forms.TabPage MicsTabGroup;
        private System.Windows.Forms.TabPage DrumsTabGroup;
        private System.Windows.Forms.TabPage BassesTabGroup;
        private System.Windows.Forms.ListBox StockBassesList;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label BassModsHeader;
        private System.Windows.Forms.Label SortByCateBLabel;
        private System.Windows.Forms.ListBox BassModsList;
        private System.Windows.Forms.Label IGNBassHeader;
        private System.Windows.Forms.Button RefreshBasModsButton;
        private System.Windows.Forms.TabPage GuitarsTabGroup;
        private System.Windows.Forms.ListBox StockGuitarsList;
        private System.Windows.Forms.ComboBox GameSortFilter;
        private System.Windows.Forms.Label GuitModsHeader;
        private System.Windows.Forms.Label SortByCateGLabel;
        private System.Windows.Forms.ListBox GuitarModsList;
        private System.Windows.Forms.Label IGNGtrsHeader;
        private System.Windows.Forms.Button RefreshGtrModsButton;
        private System.Windows.Forms.TabControl InstrumentSelectorTabMaster;
    }
}