namespace WTDE_Launcher_V3.Managers {
    partial class SCMEditHiddenSongs {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCMEditHiddenSongs));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.SongListView = new System.Windows.Forms.ListView();
            this.HeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeaderChecksum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeaderGuitarVisibility = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeaderBassVisibility = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeaderDrumVisibility = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeaderVocalsVisibility = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeaderBandVisibility = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SongsInCateHeader = new System.Windows.Forms.Label();
            this.EditActionsHeader = new System.Windows.Forms.Label();
            this.ShowOnGuitarButton = new System.Windows.Forms.Button();
            this.ShowOnBassButton = new System.Windows.Forms.Button();
            this.ShowOnDrumsButton = new System.Windows.Forms.Button();
            this.ShowOnVocalsButton = new System.Windows.Forms.Button();
            this.ShowOnBandButton = new System.Windows.Forms.Button();
            this.HideOnGuitarButton = new System.Windows.Forms.Button();
            this.HideOnBassButton = new System.Windows.Forms.Button();
            this.HideOnDrumsButton = new System.Windows.Forms.Button();
            this.HideOnVocalsButton = new System.Windows.Forms.Button();
            this.HideOnBandButton = new System.Windows.Forms.Button();
            this.ShowForAllButton = new System.Windows.Forms.Button();
            this.HideForAllButton = new System.Windows.Forms.Button();
            this.HideOnAllPartsAndSongsButton = new System.Windows.Forms.Button();
            this.ShowOnAllPartsAndSongsButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(384, 13);
            this.InfoHeaderLabel.TabIndex = 6;
            this.InfoHeaderLabel.Text = "Manage Hidden Songs: Hide certain songs from view in the setlist.";
            // 
            // SongListView
            // 
            this.SongListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HeaderTitle,
            this.HeaderChecksum,
            this.HeaderGuitarVisibility,
            this.HeaderBassVisibility,
            this.HeaderDrumVisibility,
            this.HeaderVocalsVisibility,
            this.HeaderBandVisibility});
            this.SongListView.HideSelection = false;
            this.SongListView.Location = new System.Drawing.Point(17, 36);
            this.SongListView.Name = "SongListView";
            this.SongListView.Size = new System.Drawing.Size(745, 554);
            this.SongListView.TabIndex = 7;
            this.SongListView.UseCompatibleStateImageBehavior = false;
            this.SongListView.View = System.Windows.Forms.View.Details;
            this.SongListView.SelectedIndexChanged += new System.EventHandler(this.SongListView_SelectedIndexChanged);
            // 
            // HeaderTitle
            // 
            this.HeaderTitle.Text = "Song: Artist - Title";
            this.HeaderTitle.Width = 135;
            // 
            // HeaderChecksum
            // 
            this.HeaderChecksum.Text = "Checksum";
            this.HeaderChecksum.Width = 135;
            // 
            // HeaderGuitarVisibility
            // 
            this.HeaderGuitarVisibility.Text = "Guitar Visibility";
            this.HeaderGuitarVisibility.Width = 90;
            // 
            // HeaderBassVisibility
            // 
            this.HeaderBassVisibility.Text = "Bass Visibility";
            this.HeaderBassVisibility.Width = 90;
            // 
            // HeaderDrumVisibility
            // 
            this.HeaderDrumVisibility.Text = "Drums Visibility";
            this.HeaderDrumVisibility.Width = 90;
            // 
            // HeaderVocalsVisibility
            // 
            this.HeaderVocalsVisibility.Text = "Vocals Visibility";
            this.HeaderVocalsVisibility.Width = 90;
            // 
            // HeaderBandVisibility
            // 
            this.HeaderBandVisibility.Text = "Band Visibility";
            this.HeaderBandVisibility.Width = 90;
            // 
            // SongsInCateHeader
            // 
            this.SongsInCateHeader.AutoSize = true;
            this.SongsInCateHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.SongsInCateHeader.Location = new System.Drawing.Point(8, 20);
            this.SongsInCateHeader.Name = "SongsInCateHeader";
            this.SongsInCateHeader.Size = new System.Drawing.Size(114, 13);
            this.SongsInCateHeader.TabIndex = 6;
            this.SongsInCateHeader.Text = "Songs in Category:";
            // 
            // EditActionsHeader
            // 
            this.EditActionsHeader.AutoSize = true;
            this.EditActionsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.EditActionsHeader.Location = new System.Drawing.Point(767, 20);
            this.EditActionsHeader.Name = "EditActionsHeader";
            this.EditActionsHeader.Size = new System.Drawing.Size(53, 13);
            this.EditActionsHeader.TabIndex = 6;
            this.EditActionsHeader.Text = "Actions:";
            // 
            // ShowOnGuitarButton
            // 
            this.ShowOnGuitarButton.Location = new System.Drawing.Point(776, 36);
            this.ShowOnGuitarButton.Name = "ShowOnGuitarButton";
            this.ShowOnGuitarButton.Size = new System.Drawing.Size(195, 23);
            this.ShowOnGuitarButton.TabIndex = 8;
            this.ShowOnGuitarButton.Text = "Show on Guitar";
            this.ShowOnGuitarButton.UseVisualStyleBackColor = true;
            this.ShowOnGuitarButton.Click += new System.EventHandler(this.ShowOnGuitarButton_Click);
            // 
            // ShowOnBassButton
            // 
            this.ShowOnBassButton.Location = new System.Drawing.Point(776, 65);
            this.ShowOnBassButton.Name = "ShowOnBassButton";
            this.ShowOnBassButton.Size = new System.Drawing.Size(195, 23);
            this.ShowOnBassButton.TabIndex = 8;
            this.ShowOnBassButton.Text = "Show on Bass";
            this.ShowOnBassButton.UseVisualStyleBackColor = true;
            this.ShowOnBassButton.Click += new System.EventHandler(this.ShowOnBassButton_Click);
            // 
            // ShowOnDrumsButton
            // 
            this.ShowOnDrumsButton.Location = new System.Drawing.Point(776, 94);
            this.ShowOnDrumsButton.Name = "ShowOnDrumsButton";
            this.ShowOnDrumsButton.Size = new System.Drawing.Size(195, 23);
            this.ShowOnDrumsButton.TabIndex = 8;
            this.ShowOnDrumsButton.Text = "Show on Drums";
            this.ShowOnDrumsButton.UseVisualStyleBackColor = true;
            this.ShowOnDrumsButton.Click += new System.EventHandler(this.ShowOnDrumsButton_Click);
            // 
            // ShowOnVocalsButton
            // 
            this.ShowOnVocalsButton.Location = new System.Drawing.Point(776, 123);
            this.ShowOnVocalsButton.Name = "ShowOnVocalsButton";
            this.ShowOnVocalsButton.Size = new System.Drawing.Size(195, 23);
            this.ShowOnVocalsButton.TabIndex = 8;
            this.ShowOnVocalsButton.Text = "Show on Vocals";
            this.ShowOnVocalsButton.UseVisualStyleBackColor = true;
            this.ShowOnVocalsButton.Click += new System.EventHandler(this.ShowOnVocalsButton_Click);
            // 
            // ShowOnBandButton
            // 
            this.ShowOnBandButton.Location = new System.Drawing.Point(776, 152);
            this.ShowOnBandButton.Name = "ShowOnBandButton";
            this.ShowOnBandButton.Size = new System.Drawing.Size(195, 23);
            this.ShowOnBandButton.TabIndex = 8;
            this.ShowOnBandButton.Text = "Show for Band";
            this.ShowOnBandButton.UseVisualStyleBackColor = true;
            this.ShowOnBandButton.Click += new System.EventHandler(this.ShowOnBandButton_Click);
            // 
            // HideOnGuitarButton
            // 
            this.HideOnGuitarButton.Location = new System.Drawing.Point(977, 36);
            this.HideOnGuitarButton.Name = "HideOnGuitarButton";
            this.HideOnGuitarButton.Size = new System.Drawing.Size(195, 23);
            this.HideOnGuitarButton.TabIndex = 8;
            this.HideOnGuitarButton.Text = "Hide on Guitar";
            this.HideOnGuitarButton.UseVisualStyleBackColor = true;
            this.HideOnGuitarButton.Click += new System.EventHandler(this.HideOnGuitarButton_Click);
            // 
            // HideOnBassButton
            // 
            this.HideOnBassButton.Location = new System.Drawing.Point(977, 65);
            this.HideOnBassButton.Name = "HideOnBassButton";
            this.HideOnBassButton.Size = new System.Drawing.Size(195, 23);
            this.HideOnBassButton.TabIndex = 8;
            this.HideOnBassButton.Text = "Hide on Bass";
            this.HideOnBassButton.UseVisualStyleBackColor = true;
            this.HideOnBassButton.Click += new System.EventHandler(this.HideOnBassButton_Click);
            // 
            // HideOnDrumsButton
            // 
            this.HideOnDrumsButton.Location = new System.Drawing.Point(977, 94);
            this.HideOnDrumsButton.Name = "HideOnDrumsButton";
            this.HideOnDrumsButton.Size = new System.Drawing.Size(195, 23);
            this.HideOnDrumsButton.TabIndex = 8;
            this.HideOnDrumsButton.Text = "Hide on Drums";
            this.HideOnDrumsButton.UseVisualStyleBackColor = true;
            this.HideOnDrumsButton.Click += new System.EventHandler(this.HideOnDrumsButton_Click);
            // 
            // HideOnVocalsButton
            // 
            this.HideOnVocalsButton.Location = new System.Drawing.Point(977, 123);
            this.HideOnVocalsButton.Name = "HideOnVocalsButton";
            this.HideOnVocalsButton.Size = new System.Drawing.Size(195, 23);
            this.HideOnVocalsButton.TabIndex = 8;
            this.HideOnVocalsButton.Text = "Hide on Vocals";
            this.HideOnVocalsButton.UseVisualStyleBackColor = true;
            this.HideOnVocalsButton.Click += new System.EventHandler(this.HideOnVocalsButton_Click);
            // 
            // HideOnBandButton
            // 
            this.HideOnBandButton.Location = new System.Drawing.Point(977, 152);
            this.HideOnBandButton.Name = "HideOnBandButton";
            this.HideOnBandButton.Size = new System.Drawing.Size(195, 23);
            this.HideOnBandButton.TabIndex = 8;
            this.HideOnBandButton.Text = "Hide for Band";
            this.HideOnBandButton.UseVisualStyleBackColor = true;
            this.HideOnBandButton.Click += new System.EventHandler(this.HideOnBandButton_Click);
            // 
            // ShowForAllButton
            // 
            this.ShowForAllButton.Location = new System.Drawing.Point(776, 210);
            this.ShowForAllButton.Name = "ShowForAllButton";
            this.ShowForAllButton.Size = new System.Drawing.Size(195, 23);
            this.ShowForAllButton.TabIndex = 8;
            this.ShowForAllButton.Text = "Show For All Parts";
            this.ShowForAllButton.UseVisualStyleBackColor = true;
            this.ShowForAllButton.Click += new System.EventHandler(this.ShowForAllButton_Click);
            // 
            // HideForAllButton
            // 
            this.HideForAllButton.Location = new System.Drawing.Point(977, 210);
            this.HideForAllButton.Name = "HideForAllButton";
            this.HideForAllButton.Size = new System.Drawing.Size(195, 23);
            this.HideForAllButton.TabIndex = 8;
            this.HideForAllButton.Text = "Hide For All Parts";
            this.HideForAllButton.UseVisualStyleBackColor = true;
            this.HideForAllButton.Click += new System.EventHandler(this.HideForAllButton_Click);
            // 
            // HideOnAllPartsAndSongsButton
            // 
            this.HideOnAllPartsAndSongsButton.Location = new System.Drawing.Point(776, 297);
            this.HideOnAllPartsAndSongsButton.Name = "HideOnAllPartsAndSongsButton";
            this.HideOnAllPartsAndSongsButton.Size = new System.Drawing.Size(396, 23);
            this.HideOnAllPartsAndSongsButton.TabIndex = 8;
            this.HideOnAllPartsAndSongsButton.Text = "Hide for All Parts on All Songs";
            this.HideOnAllPartsAndSongsButton.UseVisualStyleBackColor = true;
            this.HideOnAllPartsAndSongsButton.Click += new System.EventHandler(this.HideOnAllPartsAndSongsButton_Click);
            // 
            // ShowOnAllPartsAndSongsButton
            // 
            this.ShowOnAllPartsAndSongsButton.Location = new System.Drawing.Point(776, 268);
            this.ShowOnAllPartsAndSongsButton.Name = "ShowOnAllPartsAndSongsButton";
            this.ShowOnAllPartsAndSongsButton.Size = new System.Drawing.Size(396, 23);
            this.ShowOnAllPartsAndSongsButton.TabIndex = 8;
            this.ShowOnAllPartsAndSongsButton.Text = "Show for All Parts on All Songs";
            this.ShowOnAllPartsAndSongsButton.UseVisualStyleBackColor = true;
            this.ShowOnAllPartsAndSongsButton.Click += new System.EventHandler(this.ShowOnAllPartsAndSongsButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(942, 599);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 9;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(1023, 599);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(1104, 599);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 9;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // SCMEditHiddenSongs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1184, 627);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.HideOnBandButton);
            this.Controls.Add(this.ShowOnBandButton);
            this.Controls.Add(this.HideOnVocalsButton);
            this.Controls.Add(this.ShowOnVocalsButton);
            this.Controls.Add(this.HideOnDrumsButton);
            this.Controls.Add(this.ShowOnDrumsButton);
            this.Controls.Add(this.HideForAllButton);
            this.Controls.Add(this.HideOnBassButton);
            this.Controls.Add(this.ShowOnBassButton);
            this.Controls.Add(this.ShowOnAllPartsAndSongsButton);
            this.Controls.Add(this.HideOnAllPartsAndSongsButton);
            this.Controls.Add(this.ShowForAllButton);
            this.Controls.Add(this.HideOnGuitarButton);
            this.Controls.Add(this.ShowOnGuitarButton);
            this.Controls.Add(this.SongListView);
            this.Controls.Add(this.EditActionsHeader);
            this.Controls.Add(this.SongsInCateHeader);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SCMEditHiddenSongs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Hidden Songs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.ListView SongListView;
        private System.Windows.Forms.ColumnHeader HeaderTitle;
        private System.Windows.Forms.ColumnHeader HeaderChecksum;
        private System.Windows.Forms.ColumnHeader HeaderGuitarVisibility;
        private System.Windows.Forms.ColumnHeader HeaderBassVisibility;
        private System.Windows.Forms.ColumnHeader HeaderDrumVisibility;
        private System.Windows.Forms.ColumnHeader HeaderVocalsVisibility;
        private System.Windows.Forms.ColumnHeader HeaderBandVisibility;
        private System.Windows.Forms.Label SongsInCateHeader;
        private System.Windows.Forms.Label EditActionsHeader;
        private System.Windows.Forms.Button ShowOnGuitarButton;
        private System.Windows.Forms.Button ShowOnBassButton;
        private System.Windows.Forms.Button ShowOnDrumsButton;
        private System.Windows.Forms.Button ShowOnVocalsButton;
        private System.Windows.Forms.Button ShowOnBandButton;
        private System.Windows.Forms.Button HideOnGuitarButton;
        private System.Windows.Forms.Button HideOnBassButton;
        private System.Windows.Forms.Button HideOnDrumsButton;
        private System.Windows.Forms.Button HideOnVocalsButton;
        private System.Windows.Forms.Button HideOnBandButton;
        private System.Windows.Forms.Button ShowForAllButton;
        private System.Windows.Forms.Button HideForAllButton;
        private System.Windows.Forms.Button HideOnAllPartsAndSongsButton;
        private System.Windows.Forms.Button ShowOnAllPartsAndSongsButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ApplyButton;
    }
}