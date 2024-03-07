namespace WTDE_Launcher_V3 {
    partial class AddGH3StarPowerFX {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGH3StarPowerFX));
            this.AvatarImageBox = new System.Windows.Forms.PictureBox();
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.OutputModsList = new System.Windows.Forms.ListBox();
            this.CharModsHeader = new System.Windows.Forms.Label();
            this.ActionButtonHeader = new System.Windows.Forms.Label();
            this.AddCharButton = new System.Windows.Forms.Button();
            this.RemoveCharButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SelectSDKPath = new System.Windows.Forms.Button();
            this.SDKPath = new System.Windows.Forms.TextBox();
            this.SDKPathLabel = new System.Windows.Forms.Label();
            this.ClearAllDataButton = new System.Windows.Forms.Button();
            this.CharModMemory = new System.Windows.Forms.Label();
            this.SPParticlesLabel = new System.Windows.Forms.Label();
            this.StarPowerFXList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AvatarImageBox
            // 
            this.AvatarImageBox.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.logo_imf24;
            this.AvatarImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AvatarImageBox.Location = new System.Drawing.Point(10, 6);
            this.AvatarImageBox.Name = "AvatarImageBox";
            this.AvatarImageBox.Size = new System.Drawing.Size(52, 52);
            this.AvatarImageBox.TabIndex = 43;
            this.AvatarImageBox.TabStop = false;
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(126, 6);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(626, 39);
            this.InfoHeaderLabel.TabIndex = 42;
            this.InfoHeaderLabel.Text = "Assign GH3 SP FX: Adds Guitar Hero III Star Power particles to modded characters." +
    " Requires GHSDK to use.\r\n\r\nAuthor: IMF24, Cobalt";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.logo_cobalt;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(68, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 52);
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // OutputModsList
            // 
            this.OutputModsList.FormattingEnabled = true;
            this.OutputModsList.Location = new System.Drawing.Point(12, 84);
            this.OutputModsList.Name = "OutputModsList";
            this.OutputModsList.Size = new System.Drawing.Size(563, 290);
            this.OutputModsList.TabIndex = 46;
            this.OutputModsList.SelectedIndexChanged += new System.EventHandler(this.OutputModsList_SelectedIndexChanged);
            // 
            // CharModsHeader
            // 
            this.CharModsHeader.AutoSize = true;
            this.CharModsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.CharModsHeader.Location = new System.Drawing.Point(3, 68);
            this.CharModsHeader.Name = "CharModsHeader";
            this.CharModsHeader.Size = new System.Drawing.Size(100, 13);
            this.CharModsHeader.TabIndex = 45;
            this.CharModsHeader.Text = "Character Mods:";
            // 
            // ActionButtonHeader
            // 
            this.ActionButtonHeader.AutoSize = true;
            this.ActionButtonHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ActionButtonHeader.Location = new System.Drawing.Point(585, 68);
            this.ActionButtonHeader.Name = "ActionButtonHeader";
            this.ActionButtonHeader.Size = new System.Drawing.Size(53, 13);
            this.ActionButtonHeader.TabIndex = 47;
            this.ActionButtonHeader.Text = "Actions:";
            // 
            // AddCharButton
            // 
            this.AddCharButton.Location = new System.Drawing.Point(597, 84);
            this.AddCharButton.Name = "AddCharButton";
            this.AddCharButton.Size = new System.Drawing.Size(157, 23);
            this.AddCharButton.TabIndex = 48;
            this.AddCharButton.Text = "Add Character";
            this.AddCharButton.UseVisualStyleBackColor = true;
            this.AddCharButton.Click += new System.EventHandler(this.AddCharButton_Click);
            // 
            // RemoveCharButton
            // 
            this.RemoveCharButton.Location = new System.Drawing.Point(597, 113);
            this.RemoveCharButton.Name = "RemoveCharButton";
            this.RemoveCharButton.Size = new System.Drawing.Size(157, 23);
            this.RemoveCharButton.TabIndex = 49;
            this.RemoveCharButton.Text = "Remove Character";
            this.RemoveCharButton.UseVisualStyleBackColor = true;
            this.RemoveCharButton.Click += new System.EventHandler(this.RemoveCharButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(605, 448);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 58;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(686, 448);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 59;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SelectSDKPath
            // 
            this.SelectSDKPath.Location = new System.Drawing.Point(547, 408);
            this.SelectSDKPath.Name = "SelectSDKPath";
            this.SelectSDKPath.Size = new System.Drawing.Size(28, 23);
            this.SelectSDKPath.TabIndex = 57;
            this.SelectSDKPath.Text = "...";
            this.SelectSDKPath.UseVisualStyleBackColor = true;
            this.SelectSDKPath.Click += new System.EventHandler(this.SelectSDKPath_Click);
            // 
            // SDKPath
            // 
            this.SDKPath.Location = new System.Drawing.Point(81, 409);
            this.SDKPath.Name = "SDKPath";
            this.SDKPath.Size = new System.Drawing.Size(460, 20);
            this.SDKPath.TabIndex = 56;
            // 
            // SDKPathLabel
            // 
            this.SDKPathLabel.AutoSize = true;
            this.SDKPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.SDKPathLabel.ForeColor = System.Drawing.Color.Red;
            this.SDKPathLabel.Location = new System.Drawing.Point(9, 412);
            this.SDKPathLabel.Name = "SDKPathLabel";
            this.SDKPathLabel.Size = new System.Drawing.Size(66, 13);
            this.SDKPathLabel.TabIndex = 55;
            this.SDKPathLabel.Text = "SDK Path:";
            // 
            // ClearAllDataButton
            // 
            this.ClearAllDataButton.Location = new System.Drawing.Point(597, 142);
            this.ClearAllDataButton.Name = "ClearAllDataButton";
            this.ClearAllDataButton.Size = new System.Drawing.Size(157, 23);
            this.ClearAllDataButton.TabIndex = 60;
            this.ClearAllDataButton.Text = "Clear Entire Queue";
            this.ClearAllDataButton.UseVisualStyleBackColor = true;
            this.ClearAllDataButton.Click += new System.EventHandler(this.ClearAllDataButton_Click);
            // 
            // CharModMemory
            // 
            this.CharModMemory.AutoSize = true;
            this.CharModMemory.Location = new System.Drawing.Point(800, 413);
            this.CharModMemory.Name = "CharModMemory";
            this.CharModMemory.Size = new System.Drawing.Size(286, 13);
            this.CharModMemory.TabIndex = 61;
            this.CharModMemory.Text = "INSERT CHAR MOD HERE, THIS IS FOR MEMORY USE";
            // 
            // SPParticlesLabel
            // 
            this.SPParticlesLabel.AutoSize = true;
            this.SPParticlesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.SPParticlesLabel.Location = new System.Drawing.Point(9, 385);
            this.SPParticlesLabel.Name = "SPParticlesLabel";
            this.SPParticlesLabel.Size = new System.Drawing.Size(126, 13);
            this.SPParticlesLabel.TabIndex = 62;
            this.SPParticlesLabel.Text = "Star Power Particles:";
            // 
            // StarPowerFXList
            // 
            this.StarPowerFXList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StarPowerFXList.FormattingEnabled = true;
            this.StarPowerFXList.Items.AddRange(new object[] {
            "Tesla Lightning (Default)",
            "Anarchy",
            "Hearts",
            "Peace",
            "Butterflies",
            "Bats"});
            this.StarPowerFXList.Location = new System.Drawing.Point(141, 382);
            this.StarPowerFXList.Name = "StarPowerFXList";
            this.StarPowerFXList.Size = new System.Drawing.Size(179, 21);
            this.StarPowerFXList.TabIndex = 63;
            this.StarPowerFXList.SelectedIndexChanged += new System.EventHandler(this.StarPowerFXList_SelectedIndexChanged);
            // 
            // AddGH3StarPowerFX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(766, 476);
            this.Controls.Add(this.StarPowerFXList);
            this.Controls.Add(this.SPParticlesLabel);
            this.Controls.Add(this.CharModMemory);
            this.Controls.Add(this.ClearAllDataButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SelectSDKPath);
            this.Controls.Add(this.SDKPath);
            this.Controls.Add(this.SDKPathLabel);
            this.Controls.Add(this.RemoveCharButton);
            this.Controls.Add(this.AddCharButton);
            this.Controls.Add(this.ActionButtonHeader);
            this.Controls.Add(this.OutputModsList);
            this.Controls.Add(this.CharModsHeader);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.AvatarImageBox);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddGH3StarPowerFX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Script Mod Options: Assign GH3 Star Power FX to Character Mods";
            ((System.ComponentModel.ISupportInitialize)(this.AvatarImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AvatarImageBox;
        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox OutputModsList;
        private System.Windows.Forms.Label CharModsHeader;
        private System.Windows.Forms.Label ActionButtonHeader;
        private System.Windows.Forms.Button AddCharButton;
        private System.Windows.Forms.Button RemoveCharButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SelectSDKPath;
        private System.Windows.Forms.TextBox SDKPath;
        private System.Windows.Forms.Label SDKPathLabel;
        private System.Windows.Forms.Button ClearAllDataButton;
        private System.Windows.Forms.Label CharModMemory;
        private System.Windows.Forms.Label SPParticlesLabel;
        private System.Windows.Forms.ComboBox StarPowerFXList;
    }
}