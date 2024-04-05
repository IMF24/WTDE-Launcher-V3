namespace WTDE_Launcher_V3.Managers.ModTypes {
    partial class CharacterModEditor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterModEditor));
            this.ModInfoName = new System.Windows.Forms.TextBox();
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.ModInfoGroup = new System.Windows.Forms.GroupBox();
            this.ModPathLabel = new System.Windows.Forms.Label();
            this.ModPathSideLabel = new System.Windows.Forms.Label();
            this.ModVersionLabel = new System.Windows.Forms.Label();
            this.ModInfoVersion = new System.Windows.Forms.TextBox();
            this.ModAuthorLabel = new System.Windows.Forms.Label();
            this.ModInfoAuthor = new System.Windows.Forms.TextBox();
            this.ModDescriptionLabel = new System.Windows.Forms.Label();
            this.ModInfoDescription = new System.Windows.Forms.TextBox();
            this.ModNameLabel = new System.Windows.Forms.Label();
            this.CharacterInfoGroup = new System.Windows.Forms.GroupBox();
            this.BioCharLimit = new System.Windows.Forms.Label();
            this.CharacterDescription = new System.Windows.Forms.TextBox();
            this.CharBioLabel = new System.Windows.Forms.Label();
            this.CharNameLabel = new System.Windows.Forms.Label();
            this.CharacterName = new System.Windows.Forms.TextBox();
            this.ModInfoGroup.SuspendLayout();
            this.CharacterInfoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModInfoName
            // 
            this.ModInfoName.Location = new System.Drawing.Point(103, 47);
            this.ModInfoName.Name = "ModInfoName";
            this.ModInfoName.Size = new System.Drawing.Size(423, 20);
            this.ModInfoName.TabIndex = 0;
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(351, 13);
            this.InfoHeaderLabel.TabIndex = 1;
            this.InfoHeaderLabel.Text = "Edit Character Data: Edit information about a character mod.";
            // 
            // ModInfoGroup
            // 
            this.ModInfoGroup.Controls.Add(this.ModPathLabel);
            this.ModInfoGroup.Controls.Add(this.ModPathSideLabel);
            this.ModInfoGroup.Controls.Add(this.ModVersionLabel);
            this.ModInfoGroup.Controls.Add(this.ModInfoVersion);
            this.ModInfoGroup.Controls.Add(this.ModAuthorLabel);
            this.ModInfoGroup.Controls.Add(this.ModInfoAuthor);
            this.ModInfoGroup.Controls.Add(this.ModDescriptionLabel);
            this.ModInfoGroup.Controls.Add(this.ModInfoDescription);
            this.ModInfoGroup.Controls.Add(this.ModNameLabel);
            this.ModInfoGroup.Controls.Add(this.ModInfoName);
            this.ModInfoGroup.Location = new System.Drawing.Point(12, 18);
            this.ModInfoGroup.Name = "ModInfoGroup";
            this.ModInfoGroup.Size = new System.Drawing.Size(852, 156);
            this.ModInfoGroup.TabIndex = 2;
            this.ModInfoGroup.TabStop = false;
            this.ModInfoGroup.Text = "Mod Information";
            // 
            // ModPathLabel
            // 
            this.ModPathLabel.AutoSize = true;
            this.ModPathLabel.ForeColor = System.Drawing.Color.Gray;
            this.ModPathLabel.Location = new System.Drawing.Point(103, 23);
            this.ModPathLabel.Name = "ModPathLabel";
            this.ModPathLabel.Size = new System.Drawing.Size(93, 13);
            this.ModPathLabel.TabIndex = 9;
            this.ModPathLabel.Text = "MOD_DIR_HERE";
            // 
            // ModPathSideLabel
            // 
            this.ModPathSideLabel.AutoSize = true;
            this.ModPathSideLabel.Location = new System.Drawing.Point(41, 23);
            this.ModPathSideLabel.Name = "ModPathSideLabel";
            this.ModPathSideLabel.Size = new System.Drawing.Size(56, 13);
            this.ModPathSideLabel.TabIndex = 8;
            this.ModPathSideLabel.Text = "Mod Path:";
            // 
            // ModVersionLabel
            // 
            this.ModVersionLabel.AutoSize = true;
            this.ModVersionLabel.Location = new System.Drawing.Point(28, 128);
            this.ModVersionLabel.Name = "ModVersionLabel";
            this.ModVersionLabel.Size = new System.Drawing.Size(69, 13);
            this.ModVersionLabel.TabIndex = 7;
            this.ModVersionLabel.Text = "Mod Version:";
            // 
            // ModInfoVersion
            // 
            this.ModInfoVersion.Location = new System.Drawing.Point(103, 125);
            this.ModInfoVersion.Name = "ModInfoVersion";
            this.ModInfoVersion.Size = new System.Drawing.Size(423, 20);
            this.ModInfoVersion.TabIndex = 6;
            // 
            // ModAuthorLabel
            // 
            this.ModAuthorLabel.AutoSize = true;
            this.ModAuthorLabel.Location = new System.Drawing.Point(32, 102);
            this.ModAuthorLabel.Name = "ModAuthorLabel";
            this.ModAuthorLabel.Size = new System.Drawing.Size(65, 13);
            this.ModAuthorLabel.TabIndex = 5;
            this.ModAuthorLabel.Text = "Mod Author:";
            // 
            // ModInfoAuthor
            // 
            this.ModInfoAuthor.Location = new System.Drawing.Point(103, 99);
            this.ModInfoAuthor.Name = "ModInfoAuthor";
            this.ModInfoAuthor.Size = new System.Drawing.Size(423, 20);
            this.ModInfoAuthor.TabIndex = 4;
            // 
            // ModDescriptionLabel
            // 
            this.ModDescriptionLabel.AutoSize = true;
            this.ModDescriptionLabel.Location = new System.Drawing.Point(10, 76);
            this.ModDescriptionLabel.Name = "ModDescriptionLabel";
            this.ModDescriptionLabel.Size = new System.Drawing.Size(87, 13);
            this.ModDescriptionLabel.TabIndex = 3;
            this.ModDescriptionLabel.Text = "Mod Description:";
            // 
            // ModInfoDescription
            // 
            this.ModInfoDescription.Location = new System.Drawing.Point(103, 73);
            this.ModInfoDescription.Name = "ModInfoDescription";
            this.ModInfoDescription.Size = new System.Drawing.Size(423, 20);
            this.ModInfoDescription.TabIndex = 2;
            // 
            // ModNameLabel
            // 
            this.ModNameLabel.AutoSize = true;
            this.ModNameLabel.Location = new System.Drawing.Point(35, 50);
            this.ModNameLabel.Name = "ModNameLabel";
            this.ModNameLabel.Size = new System.Drawing.Size(62, 13);
            this.ModNameLabel.TabIndex = 1;
            this.ModNameLabel.Text = "Mod Name:";
            // 
            // CharacterInfoGroup
            // 
            this.CharacterInfoGroup.Controls.Add(this.BioCharLimit);
            this.CharacterInfoGroup.Controls.Add(this.CharacterDescription);
            this.CharacterInfoGroup.Controls.Add(this.CharBioLabel);
            this.CharacterInfoGroup.Controls.Add(this.CharNameLabel);
            this.CharacterInfoGroup.Controls.Add(this.CharacterName);
            this.CharacterInfoGroup.Location = new System.Drawing.Point(12, 180);
            this.CharacterInfoGroup.Name = "CharacterInfoGroup";
            this.CharacterInfoGroup.Size = new System.Drawing.Size(852, 458);
            this.CharacterInfoGroup.TabIndex = 3;
            this.CharacterInfoGroup.TabStop = false;
            this.CharacterInfoGroup.Text = "Mod Properties";
            // 
            // BioCharLimit
            // 
            this.BioCharLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BioCharLimit.Location = new System.Drawing.Point(630, 231);
            this.BioCharLimit.Name = "BioCharLimit";
            this.BioCharLimit.Size = new System.Drawing.Size(213, 18);
            this.BioCharLimit.TabIndex = 12;
            this.BioCharLimit.Text = "ABC / 2048";
            this.BioCharLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CharacterDescription
            // 
            this.CharacterDescription.Location = new System.Drawing.Point(128, 46);
            this.CharacterDescription.Multiline = true;
            this.CharacterDescription.Name = "CharacterDescription";
            this.CharacterDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CharacterDescription.Size = new System.Drawing.Size(715, 182);
            this.CharacterDescription.TabIndex = 11;
            this.CharacterDescription.TextChanged += new System.EventHandler(this.CharacterDescription_TextChanged);
            // 
            // CharBioLabel
            // 
            this.CharBioLabel.AutoSize = true;
            this.CharBioLabel.Location = new System.Drawing.Point(10, 49);
            this.CharBioLabel.Name = "CharBioLabel";
            this.CharBioLabel.Size = new System.Drawing.Size(112, 13);
            this.CharBioLabel.TabIndex = 10;
            this.CharBioLabel.Text = "Character Description:";
            // 
            // CharNameLabel
            // 
            this.CharNameLabel.AutoSize = true;
            this.CharNameLabel.Location = new System.Drawing.Point(35, 22);
            this.CharNameLabel.Name = "CharNameLabel";
            this.CharNameLabel.Size = new System.Drawing.Size(87, 13);
            this.CharNameLabel.TabIndex = 9;
            this.CharNameLabel.Text = "Character Name:";
            // 
            // CharacterName
            // 
            this.CharacterName.Location = new System.Drawing.Point(128, 19);
            this.CharacterName.Name = "CharacterName";
            this.CharacterName.Size = new System.Drawing.Size(423, 20);
            this.CharacterName.TabIndex = 8;
            // 
            // CharacterModEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(876, 737);
            this.Controls.Add(this.CharacterInfoGroup);
            this.Controls.Add(this.ModInfoGroup);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CharacterModEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mod Manager: Edit Character Mod Data";
            this.ModInfoGroup.ResumeLayout(false);
            this.ModInfoGroup.PerformLayout();
            this.CharacterInfoGroup.ResumeLayout(false);
            this.CharacterInfoGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ModInfoName;
        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.GroupBox ModInfoGroup;
        private System.Windows.Forms.Label ModNameLabel;
        private System.Windows.Forms.Label ModVersionLabel;
        private System.Windows.Forms.TextBox ModInfoVersion;
        private System.Windows.Forms.Label ModAuthorLabel;
        private System.Windows.Forms.TextBox ModInfoAuthor;
        private System.Windows.Forms.Label ModDescriptionLabel;
        private System.Windows.Forms.TextBox ModInfoDescription;
        private System.Windows.Forms.GroupBox CharacterInfoGroup;
        private System.Windows.Forms.Label BioCharLimit;
        private System.Windows.Forms.TextBox CharacterDescription;
        private System.Windows.Forms.Label CharBioLabel;
        private System.Windows.Forms.Label CharNameLabel;
        private System.Windows.Forms.TextBox CharacterName;
        private System.Windows.Forms.Label ModPathSideLabel;
        private System.Windows.Forms.Label ModPathLabel;
    }
}