namespace WTDE_Launcher_V3.IO {
    partial class GHDEVersionChanger {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GHDEVersionChanger));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.DELatestVersionLabel = new System.Windows.Forms.Label();
            this.RevertVersionButton = new System.Windows.Forms.Button();
            this.OlderVersionsHeader = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.VersionInfoList = new System.Windows.Forms.ListView();
            this.VersionNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChangeVersionButton = new System.Windows.Forms.Button();
            this.SelectInstructionsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(571, 13);
            this.InfoHeaderLabel.TabIndex = 0;
            this.InfoHeaderLabel.Text = "WTDE Version Changer: Change your GHWT: Definitive Edition install to an older or" +
    " newer version.";
            // 
            // DELatestVersionLabel
            // 
            this.DELatestVersionLabel.AutoSize = true;
            this.DELatestVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DELatestVersionLabel.Location = new System.Drawing.Point(12, 23);
            this.DELatestVersionLabel.Name = "DELatestVersionLabel";
            this.DELatestVersionLabel.Size = new System.Drawing.Size(149, 18);
            this.DELatestVersionLabel.TabIndex = 1;
            this.DELatestVersionLabel.Text = "Latest Version: VABC";
            // 
            // RevertVersionButton
            // 
            this.RevertVersionButton.Location = new System.Drawing.Point(388, 22);
            this.RevertVersionButton.Name = "RevertVersionButton";
            this.RevertVersionButton.Size = new System.Drawing.Size(186, 23);
            this.RevertVersionButton.TabIndex = 2;
            this.RevertVersionButton.Text = "Revert to Current Version";
            this.RevertVersionButton.UseVisualStyleBackColor = true;
            this.RevertVersionButton.Click += new System.EventHandler(this.RevertVersionButton_Click);
            // 
            // OlderVersionsHeader
            // 
            this.OlderVersionsHeader.AutoSize = true;
            this.OlderVersionsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.OlderVersionsHeader.Location = new System.Drawing.Point(3, 57);
            this.OlderVersionsHeader.Name = "OlderVersionsHeader";
            this.OlderVersionsHeader.Size = new System.Drawing.Size(93, 13);
            this.OlderVersionsHeader.TabIndex = 0;
            this.OlderVersionsHeader.Text = "Older Versions:";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(494, 519);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(80, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // VersionInfoList
            // 
            this.VersionInfoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.VersionNameHeader,
            this.DateTimeHeader});
            this.VersionInfoList.HideSelection = false;
            this.VersionInfoList.Location = new System.Drawing.Point(12, 119);
            this.VersionInfoList.MultiSelect = false;
            this.VersionInfoList.Name = "VersionInfoList";
            this.VersionInfoList.Size = new System.Drawing.Size(562, 344);
            this.VersionInfoList.TabIndex = 3;
            this.VersionInfoList.UseCompatibleStateImageBehavior = false;
            this.VersionInfoList.View = System.Windows.Forms.View.Details;
            this.VersionInfoList.SelectedIndexChanged += new System.EventHandler(this.VersionInfoList_SelectedIndexChanged);
            // 
            // VersionNameHeader
            // 
            this.VersionNameHeader.Text = "Version";
            this.VersionNameHeader.Width = 276;
            // 
            // DateTimeHeader
            // 
            this.DateTimeHeader.Text = "Date";
            this.DateTimeHeader.Width = 252;
            // 
            // ChangeVersionButton
            // 
            this.ChangeVersionButton.Location = new System.Drawing.Point(12, 469);
            this.ChangeVersionButton.Name = "ChangeVersionButton";
            this.ChangeVersionButton.Size = new System.Drawing.Size(562, 44);
            this.ChangeVersionButton.TabIndex = 4;
            this.ChangeVersionButton.Text = "Change Version to Selected";
            this.ChangeVersionButton.UseVisualStyleBackColor = true;
            this.ChangeVersionButton.Click += new System.EventHandler(this.ChangeVersionButton_Click);
            // 
            // SelectInstructionsLabel
            // 
            this.SelectInstructionsLabel.AutoSize = true;
            this.SelectInstructionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.SelectInstructionsLabel.Location = new System.Drawing.Point(10, 73);
            this.SelectInstructionsLabel.Name = "SelectInstructionsLabel";
            this.SelectInstructionsLabel.Size = new System.Drawing.Size(475, 39);
            this.SelectInstructionsLabel.TabIndex = 0;
            this.SelectInstructionsLabel.Text = resources.GetString("SelectInstructionsLabel.Text");
            // 
            // GHDEVersionChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(587, 548);
            this.Controls.Add(this.ChangeVersionButton);
            this.Controls.Add(this.VersionInfoList);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.RevertVersionButton);
            this.Controls.Add(this.DELatestVersionLabel);
            this.Controls.Add(this.SelectInstructionsLabel);
            this.Controls.Add(this.OlderVersionsHeader);
            this.Controls.Add(this.InfoHeaderLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GHDEVersionChanger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GHWT: Definitive Edition - Version Changer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.Label DELatestVersionLabel;
        private System.Windows.Forms.Button RevertVersionButton;
        private System.Windows.Forms.Label OlderVersionsHeader;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ListView VersionInfoList;
        private System.Windows.Forms.Button ChangeVersionButton;
        private System.Windows.Forms.ColumnHeader VersionNameHeader;
        private System.Windows.Forms.ColumnHeader DateTimeHeader;
        private System.Windows.Forms.Label SelectInstructionsLabel;
    }
}