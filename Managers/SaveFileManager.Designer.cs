namespace WTDE_Launcher_V3.Managers {
    partial class SaveFileManager {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveFileManager));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.ReplaceSaveButton = new System.Windows.Forms.Button();
            this.BackUpSaveButton = new System.Windows.Forms.Button();
            this.SaveBackupsHeader = new System.Windows.Forms.Label();
            this.SaveBackupsList = new System.Windows.Forms.ListBox();
            this.LoadSelectedBackup = new System.Windows.Forms.Button();
            this.CloseSFMWindow = new System.Windows.Forms.Button();
            this.SFMToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.OpenBackupFolder = new System.Windows.Forms.Button();
            this.DeleteSelectedBackup = new System.Windows.Forms.Button();
            this.RefreshBackups = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(331, 13);
            this.InfoHeaderLabel.TabIndex = 0;
            this.InfoHeaderLabel.Text = "Save File Manager: Manage and back up your save files.";
            // 
            // ReplaceSaveButton
            // 
            this.ReplaceSaveButton.Location = new System.Drawing.Point(12, 18);
            this.ReplaceSaveButton.Name = "ReplaceSaveButton";
            this.ReplaceSaveButton.Size = new System.Drawing.Size(177, 23);
            this.ReplaceSaveButton.TabIndex = 1;
            this.ReplaceSaveButton.Text = "Replace Save...";
            this.SFMToolTipMain.SetToolTip(this.ReplaceSaveButton, "Replace your save file with a different one.");
            this.ReplaceSaveButton.UseVisualStyleBackColor = true;
            this.ReplaceSaveButton.Click += new System.EventHandler(this.ReplaceSaveButton_Click);
            // 
            // BackUpSaveButton
            // 
            this.BackUpSaveButton.Location = new System.Drawing.Point(209, 18);
            this.BackUpSaveButton.Name = "BackUpSaveButton";
            this.BackUpSaveButton.Size = new System.Drawing.Size(177, 23);
            this.BackUpSaveButton.TabIndex = 2;
            this.BackUpSaveButton.Text = "Back Up Save";
            this.SFMToolTipMain.SetToolTip(this.BackUpSaveButton, "Create a copy of your save file.\r\n\r\nAll backed up save files are stored in the Sa" +
        "ve Backups directory where GHWTDE.ini is located.");
            this.BackUpSaveButton.UseVisualStyleBackColor = true;
            this.BackUpSaveButton.Click += new System.EventHandler(this.BackUpSaveButton_Click);
            // 
            // SaveBackupsHeader
            // 
            this.SaveBackupsHeader.AutoSize = true;
            this.SaveBackupsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.SaveBackupsHeader.Location = new System.Drawing.Point(3, 110);
            this.SaveBackupsHeader.Name = "SaveBackupsHeader";
            this.SaveBackupsHeader.Size = new System.Drawing.Size(93, 13);
            this.SaveBackupsHeader.TabIndex = 3;
            this.SaveBackupsHeader.Text = "Save Backups:";
            // 
            // SaveBackupsList
            // 
            this.SaveBackupsList.FormattingEnabled = true;
            this.SaveBackupsList.Location = new System.Drawing.Point(12, 126);
            this.SaveBackupsList.Name = "SaveBackupsList";
            this.SaveBackupsList.Size = new System.Drawing.Size(374, 316);
            this.SaveBackupsList.TabIndex = 4;
            this.SFMToolTipMain.SetToolTip(this.SaveBackupsList, "This is a list of all save file backups detected by the launcher.");
            this.SaveBackupsList.SelectedIndexChanged += new System.EventHandler(this.SaveBackupsList_SelectedIndexChanged);
            // 
            // LoadSelectedBackup
            // 
            this.LoadSelectedBackup.Location = new System.Drawing.Point(12, 448);
            this.LoadSelectedBackup.Name = "LoadSelectedBackup";
            this.LoadSelectedBackup.Size = new System.Drawing.Size(374, 46);
            this.LoadSelectedBackup.TabIndex = 5;
            this.LoadSelectedBackup.Text = "Load Selected Backup";
            this.SFMToolTipMain.SetToolTip(this.LoadSelectedBackup, "Replace your save file with the currently selected backup. Can\'t be undone!");
            this.LoadSelectedBackup.UseVisualStyleBackColor = true;
            this.LoadSelectedBackup.Click += new System.EventHandler(this.LoadSelectedBackup_Click);
            // 
            // CloseSFMWindow
            // 
            this.CloseSFMWindow.Location = new System.Drawing.Point(313, 503);
            this.CloseSFMWindow.Name = "CloseSFMWindow";
            this.CloseSFMWindow.Size = new System.Drawing.Size(80, 23);
            this.CloseSFMWindow.TabIndex = 6;
            this.CloseSFMWindow.Text = "Close";
            this.SFMToolTipMain.SetToolTip(this.CloseSFMWindow, "Closes this window.");
            this.CloseSFMWindow.UseVisualStyleBackColor = true;
            this.CloseSFMWindow.Click += new System.EventHandler(this.CloseSFMWindow_Click);
            // 
            // OpenBackupFolder
            // 
            this.OpenBackupFolder.Location = new System.Drawing.Point(12, 47);
            this.OpenBackupFolder.Name = "OpenBackupFolder";
            this.OpenBackupFolder.Size = new System.Drawing.Size(177, 23);
            this.OpenBackupFolder.TabIndex = 7;
            this.OpenBackupFolder.Text = "Open Backups Folder";
            this.SFMToolTipMain.SetToolTip(this.OpenBackupFolder, "Open the folder containing your save file backups.");
            this.OpenBackupFolder.UseVisualStyleBackColor = true;
            this.OpenBackupFolder.Click += new System.EventHandler(this.OpenBackupFolder_Click);
            // 
            // DeleteSelectedBackup
            // 
            this.DeleteSelectedBackup.Location = new System.Drawing.Point(209, 47);
            this.DeleteSelectedBackup.Name = "DeleteSelectedBackup";
            this.DeleteSelectedBackup.Size = new System.Drawing.Size(177, 23);
            this.DeleteSelectedBackup.TabIndex = 8;
            this.DeleteSelectedBackup.Text = "Delete Selected Backup";
            this.SFMToolTipMain.SetToolTip(this.DeleteSelectedBackup, "Erase the selected backup in the list.");
            this.DeleteSelectedBackup.UseVisualStyleBackColor = true;
            this.DeleteSelectedBackup.Click += new System.EventHandler(this.DeleteSelectedBackup_Click);
            // 
            // RefreshBackups
            // 
            this.RefreshBackups.Location = new System.Drawing.Point(12, 76);
            this.RefreshBackups.Name = "RefreshBackups";
            this.RefreshBackups.Size = new System.Drawing.Size(374, 23);
            this.RefreshBackups.TabIndex = 9;
            this.RefreshBackups.Text = "Refresh Backups List";
            this.SFMToolTipMain.SetToolTip(this.RefreshBackups, "Replace your save file with a different one.");
            this.RefreshBackups.UseVisualStyleBackColor = true;
            this.RefreshBackups.Click += new System.EventHandler(this.RefreshBackups_Click);
            // 
            // SaveFileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(398, 532);
            this.Controls.Add(this.RefreshBackups);
            this.Controls.Add(this.DeleteSelectedBackup);
            this.Controls.Add(this.OpenBackupFolder);
            this.Controls.Add(this.CloseSFMWindow);
            this.Controls.Add(this.LoadSelectedBackup);
            this.Controls.Add(this.SaveBackupsList);
            this.Controls.Add(this.SaveBackupsHeader);
            this.Controls.Add(this.BackUpSaveButton);
            this.Controls.Add(this.ReplaceSaveButton);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveFileManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mod Manager: Save File Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.Button ReplaceSaveButton;
        private System.Windows.Forms.Button BackUpSaveButton;
        private System.Windows.Forms.Label SaveBackupsHeader;
        private System.Windows.Forms.ListBox SaveBackupsList;
        private System.Windows.Forms.Button LoadSelectedBackup;
        private System.Windows.Forms.Button CloseSFMWindow;
        private System.Windows.Forms.ToolTip SFMToolTipMain;
        private System.Windows.Forms.Button OpenBackupFolder;
        private System.Windows.Forms.Button DeleteSelectedBackup;
        private System.Windows.Forms.Button RefreshBackups;
    }
}