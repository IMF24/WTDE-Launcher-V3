namespace WTDE_Launcher_V3.Managers {
    partial class SelectHighwayMod {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectHighwayMod));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.CharModsHeader = new System.Windows.Forms.Label();
            this.CharacterModsList = new System.Windows.Forms.ListBox();
            this.RefreshCharModsButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(259, 13);
            this.InfoHeaderLabel.TabIndex = 0;
            this.InfoHeaderLabel.Text = "Select Highway Mod: Select a highway mod.";
            // 
            // CharModsHeader
            // 
            this.CharModsHeader.AutoSize = true;
            this.CharModsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.CharModsHeader.Location = new System.Drawing.Point(3, 22);
            this.CharModsHeader.Name = "CharModsHeader";
            this.CharModsHeader.Size = new System.Drawing.Size(93, 13);
            this.CharModsHeader.TabIndex = 1;
            this.CharModsHeader.Text = "Highway Mods:";
            // 
            // CharacterModsList
            // 
            this.CharacterModsList.FormattingEnabled = true;
            this.CharacterModsList.Location = new System.Drawing.Point(12, 38);
            this.CharacterModsList.Name = "CharacterModsList";
            this.CharacterModsList.Size = new System.Drawing.Size(345, 342);
            this.CharacterModsList.TabIndex = 2;
            // 
            // RefreshCharModsButton
            // 
            this.RefreshCharModsButton.Location = new System.Drawing.Point(12, 386);
            this.RefreshCharModsButton.Name = "RefreshCharModsButton";
            this.RefreshCharModsButton.Size = new System.Drawing.Size(345, 23);
            this.RefreshCharModsButton.TabIndex = 3;
            this.RefreshCharModsButton.Text = "Refresh List";
            this.RefreshCharModsButton.UseVisualStyleBackColor = true;
            this.RefreshCharModsButton.Click += new System.EventHandler(this.RefreshCharModsButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(282, 415);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(201, 415);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // SelectHighwayMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(369, 444);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.RefreshCharModsButton);
            this.Controls.Add(this.CharacterModsList);
            this.Controls.Add(this.CharModsHeader);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectHighwayMod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mod Selector: Select Highway Mod";
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
    }
}