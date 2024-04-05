namespace WTDE_Launcher_V3.Managers {
    partial class CARManager {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CARManager));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.CARFilesHeader = new System.Windows.Forms.Label();
            this.CARProfilesList = new System.Windows.Forms.ListBox();
            this.ActionsHeader = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.InstallNewProfile = new System.Windows.Forms.Button();
            this.DeleteSelectedProfile = new System.Windows.Forms.Button();
            this.OpenProfilesFolder = new System.Windows.Forms.Button();
            this.RefreshProfilesList = new System.Windows.Forms.Button();
            this.CARManagerToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.MarkPreferredGuitarist = new System.Windows.Forms.Button();
            this.MarkPreferredBassist = new System.Windows.Forms.Button();
            this.MarkPreferredDrummer = new System.Windows.Forms.Button();
            this.MarkPreferredSinger = new System.Windows.Forms.Button();
            this.MarkPreferredFemaleSinger = new System.Windows.Forms.Button();
            this.PreferredBandHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(499, 13);
            this.InfoHeaderLabel.TabIndex = 1;
            this.InfoHeaderLabel.Text = "Rock Star Creator Character Manager: Manage installed Rock Star Creator character" +
    "s.";
            // 
            // CARFilesHeader
            // 
            this.CARFilesHeader.AutoSize = true;
            this.CARFilesHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.CARFilesHeader.Location = new System.Drawing.Point(3, 32);
            this.CARFilesHeader.Name = "CARFilesHeader";
            this.CARFilesHeader.Size = new System.Drawing.Size(110, 13);
            this.CARFilesHeader.TabIndex = 4;
            this.CARFilesHeader.Text = "Installed Rockers:";
            // 
            // CARProfilesList
            // 
            this.CARProfilesList.FormattingEnabled = true;
            this.CARProfilesList.Location = new System.Drawing.Point(12, 49);
            this.CARProfilesList.Name = "CARProfilesList";
            this.CARProfilesList.Size = new System.Drawing.Size(268, 277);
            this.CARProfilesList.TabIndex = 5;
            this.CARManagerToolTipMain.SetToolTip(this.CARProfilesList, "List of all installed Rock Star Creator characters you have.");
            this.CARProfilesList.SelectedIndexChanged += new System.EventHandler(this.CARProfilesList_SelectedIndexChanged);
            // 
            // ActionsHeader
            // 
            this.ActionsHeader.AutoSize = true;
            this.ActionsHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ActionsHeader.Location = new System.Drawing.Point(294, 32);
            this.ActionsHeader.Name = "ActionsHeader";
            this.ActionsHeader.Size = new System.Drawing.Size(51, 15);
            this.ActionsHeader.TabIndex = 16;
            this.ActionsHeader.Text = "Actions:";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(449, 359);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 17;
            this.CloseButton.Text = "Close";
            this.CARManagerToolTipMain.SetToolTip(this.CloseButton, "Closes this window.");
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // InstallNewProfile
            // 
            this.InstallNewProfile.Location = new System.Drawing.Point(297, 50);
            this.InstallNewProfile.Name = "InstallNewProfile";
            this.InstallNewProfile.Size = new System.Drawing.Size(221, 23);
            this.InstallNewProfile.TabIndex = 18;
            this.InstallNewProfile.Text = "Install CAR Character(s)...";
            this.CARManagerToolTipMain.SetToolTip(this.InstallNewProfile, "Install new Rock Star Creator characters into your Profiles folder.");
            this.InstallNewProfile.UseVisualStyleBackColor = true;
            this.InstallNewProfile.Click += new System.EventHandler(this.InstallNewProfile_Click);
            // 
            // DeleteSelectedProfile
            // 
            this.DeleteSelectedProfile.Location = new System.Drawing.Point(297, 79);
            this.DeleteSelectedProfile.Name = "DeleteSelectedProfile";
            this.DeleteSelectedProfile.Size = new System.Drawing.Size(221, 23);
            this.DeleteSelectedProfile.TabIndex = 19;
            this.DeleteSelectedProfile.Text = "Delete CAR Character";
            this.CARManagerToolTipMain.SetToolTip(this.DeleteSelectedProfile, "Delete the selected character file.");
            this.DeleteSelectedProfile.UseVisualStyleBackColor = true;
            this.DeleteSelectedProfile.Click += new System.EventHandler(this.DeleteSelectedProfile_Click);
            // 
            // OpenProfilesFolder
            // 
            this.OpenProfilesFolder.Location = new System.Drawing.Point(297, 108);
            this.OpenProfilesFolder.Name = "OpenProfilesFolder";
            this.OpenProfilesFolder.Size = new System.Drawing.Size(221, 23);
            this.OpenProfilesFolder.TabIndex = 20;
            this.OpenProfilesFolder.Text = "Open Profiles Folder";
            this.CARManagerToolTipMain.SetToolTip(this.OpenProfilesFolder, "Open your Profiles folder.");
            this.OpenProfilesFolder.UseVisualStyleBackColor = true;
            this.OpenProfilesFolder.Click += new System.EventHandler(this.OpenProfilesFolder_Click);
            // 
            // RefreshProfilesList
            // 
            this.RefreshProfilesList.Location = new System.Drawing.Point(12, 329);
            this.RefreshProfilesList.Name = "RefreshProfilesList";
            this.RefreshProfilesList.Size = new System.Drawing.Size(268, 23);
            this.RefreshProfilesList.TabIndex = 21;
            this.RefreshProfilesList.Text = "Refresh List";
            this.CARManagerToolTipMain.SetToolTip(this.RefreshProfilesList, "Refresh the list of profiles in your Profiles folder.");
            this.RefreshProfilesList.UseVisualStyleBackColor = true;
            this.RefreshProfilesList.Click += new System.EventHandler(this.RefreshProfilesList_Click);
            // 
            // MarkPreferredGuitarist
            // 
            this.MarkPreferredGuitarist.Location = new System.Drawing.Point(297, 187);
            this.MarkPreferredGuitarist.Name = "MarkPreferredGuitarist";
            this.MarkPreferredGuitarist.Size = new System.Drawing.Size(221, 23);
            this.MarkPreferredGuitarist.TabIndex = 22;
            this.MarkPreferredGuitarist.Text = "Set As Preferred Guitarist";
            this.CARManagerToolTipMain.SetToolTip(this.MarkPreferredGuitarist, "Mark the selected character as the preferred guitarist.");
            this.MarkPreferredGuitarist.UseVisualStyleBackColor = true;
            this.MarkPreferredGuitarist.Click += new System.EventHandler(this.MarkPreferredGuitarist_Click);
            // 
            // MarkPreferredBassist
            // 
            this.MarkPreferredBassist.Location = new System.Drawing.Point(297, 216);
            this.MarkPreferredBassist.Name = "MarkPreferredBassist";
            this.MarkPreferredBassist.Size = new System.Drawing.Size(221, 23);
            this.MarkPreferredBassist.TabIndex = 23;
            this.MarkPreferredBassist.Text = "Set As Preferred Bassist";
            this.CARManagerToolTipMain.SetToolTip(this.MarkPreferredBassist, "Mark the selected character as the preferred bassist.");
            this.MarkPreferredBassist.UseVisualStyleBackColor = true;
            this.MarkPreferredBassist.Click += new System.EventHandler(this.MarkPreferredBassist_Click);
            // 
            // MarkPreferredDrummer
            // 
            this.MarkPreferredDrummer.Location = new System.Drawing.Point(297, 245);
            this.MarkPreferredDrummer.Name = "MarkPreferredDrummer";
            this.MarkPreferredDrummer.Size = new System.Drawing.Size(221, 23);
            this.MarkPreferredDrummer.TabIndex = 24;
            this.MarkPreferredDrummer.Text = "Set As Preferred Drummer";
            this.CARManagerToolTipMain.SetToolTip(this.MarkPreferredDrummer, "Mark the selected character as the preferred drummer.");
            this.MarkPreferredDrummer.UseVisualStyleBackColor = true;
            this.MarkPreferredDrummer.Click += new System.EventHandler(this.MarkPreferredDrummer_Click);
            // 
            // MarkPreferredSinger
            // 
            this.MarkPreferredSinger.Location = new System.Drawing.Point(297, 274);
            this.MarkPreferredSinger.Name = "MarkPreferredSinger";
            this.MarkPreferredSinger.Size = new System.Drawing.Size(221, 23);
            this.MarkPreferredSinger.TabIndex = 25;
            this.MarkPreferredSinger.Text = "Set As Preferred Male Singer";
            this.CARManagerToolTipMain.SetToolTip(this.MarkPreferredSinger, "Mark the selected character as the preferred male singer.");
            this.MarkPreferredSinger.UseVisualStyleBackColor = true;
            this.MarkPreferredSinger.Click += new System.EventHandler(this.MarkPreferredSinger_Click);
            // 
            // MarkPreferredFemaleSinger
            // 
            this.MarkPreferredFemaleSinger.Location = new System.Drawing.Point(297, 303);
            this.MarkPreferredFemaleSinger.Name = "MarkPreferredFemaleSinger";
            this.MarkPreferredFemaleSinger.Size = new System.Drawing.Size(221, 23);
            this.MarkPreferredFemaleSinger.TabIndex = 26;
            this.MarkPreferredFemaleSinger.Text = "Set As Preferred Female Singer";
            this.CARManagerToolTipMain.SetToolTip(this.MarkPreferredFemaleSinger, "Mark the selected character as the preferred female singer.");
            this.MarkPreferredFemaleSinger.UseVisualStyleBackColor = true;
            this.MarkPreferredFemaleSinger.Click += new System.EventHandler(this.MarkPreferredFemaleSinger_Click);
            // 
            // PreferredBandHeader
            // 
            this.PreferredBandHeader.AutoSize = true;
            this.PreferredBandHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.PreferredBandHeader.Location = new System.Drawing.Point(294, 169);
            this.PreferredBandHeader.Name = "PreferredBandHeader";
            this.PreferredBandHeader.Size = new System.Drawing.Size(152, 15);
            this.PreferredBandHeader.TabIndex = 27;
            this.PreferredBandHeader.Text = "Preferred Band Members:";
            // 
            // CARManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(530, 386);
            this.Controls.Add(this.PreferredBandHeader);
            this.Controls.Add(this.MarkPreferredFemaleSinger);
            this.Controls.Add(this.MarkPreferredSinger);
            this.Controls.Add(this.MarkPreferredDrummer);
            this.Controls.Add(this.MarkPreferredBassist);
            this.Controls.Add(this.MarkPreferredGuitarist);
            this.Controls.Add(this.RefreshProfilesList);
            this.Controls.Add(this.OpenProfilesFolder);
            this.Controls.Add(this.DeleteSelectedProfile);
            this.Controls.Add(this.InstallNewProfile);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ActionsHeader);
            this.Controls.Add(this.CARProfilesList);
            this.Controls.Add(this.CARFilesHeader);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CARManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mod Manager: Rock Star Creator Character Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.Label CARFilesHeader;
        private System.Windows.Forms.ListBox CARProfilesList;
        private System.Windows.Forms.Label ActionsHeader;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button InstallNewProfile;
        private System.Windows.Forms.Button DeleteSelectedProfile;
        private System.Windows.Forms.Button OpenProfilesFolder;
        private System.Windows.Forms.Button RefreshProfilesList;
        private System.Windows.Forms.ToolTip CARManagerToolTipMain;
        private System.Windows.Forms.Button MarkPreferredGuitarist;
        private System.Windows.Forms.Button MarkPreferredBassist;
        private System.Windows.Forms.Button MarkPreferredDrummer;
        private System.Windows.Forms.Button MarkPreferredSinger;
        private System.Windows.Forms.Button MarkPreferredFemaleSinger;
        private System.Windows.Forms.Label PreferredBandHeader;
    }
}