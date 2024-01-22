namespace WTDE_Launcher_V3 {
    partial class ModInstaller {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModInstaller));
            this.AddModArchives = new System.Windows.Forms.Button();
            this.ModInstallerHeader = new System.Windows.Forms.Label();
            this.ClearModQueue = new System.Windows.Forms.Button();
            this.ModInstallQueueHeader = new System.Windows.Forms.Label();
            this.ModQueueList = new System.Windows.Forms.ListBox();
            this.TotalInstallProgress = new System.Windows.Forms.ProgressBar();
            this.ModInstallProgress = new System.Windows.Forms.Label();
            this.ModInstallProgLabel = new System.Windows.Forms.Label();
            this.ExecuteInstall = new System.Windows.Forms.Button();
            this.ExecuteInstallSelectedOnly = new System.Windows.Forms.Button();
            this.InstallProgressInfo = new System.Windows.Forms.Label();
            this.InstallerBGWorker = new System.ComponentModel.BackgroundWorker();
            this.InstallerToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // AddModArchives
            // 
            this.AddModArchives.Location = new System.Drawing.Point(12, 20);
            this.AddModArchives.Name = "AddModArchives";
            this.AddModArchives.Size = new System.Drawing.Size(295, 23);
            this.AddModArchives.TabIndex = 0;
            this.AddModArchives.Text = "Add Archive Mod...";
            this.InstallerToolTipMain.SetToolTip(this.AddModArchives, "Add mod archives to the queue list (ZIP/7Z/RAR format).");
            this.AddModArchives.UseVisualStyleBackColor = true;
            this.AddModArchives.Click += new System.EventHandler(this.AddModArchives_Click);
            // 
            // ModInstallerHeader
            // 
            this.ModInstallerHeader.AutoSize = true;
            this.ModInstallerHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ModInstallerHeader.Location = new System.Drawing.Point(3, 2);
            this.ModInstallerHeader.Name = "ModInstallerHeader";
            this.ModInstallerHeader.Size = new System.Drawing.Size(244, 15);
            this.ModInstallerHeader.TabIndex = 1;
            this.ModInstallerHeader.Text = "Mod Installer: Install new mods into WTDE.";
            // 
            // ClearModQueue
            // 
            this.ClearModQueue.Enabled = false;
            this.ClearModQueue.Location = new System.Drawing.Point(323, 20);
            this.ClearModQueue.Name = "ClearModQueue";
            this.ClearModQueue.Size = new System.Drawing.Size(295, 23);
            this.ClearModQueue.TabIndex = 2;
            this.ClearModQueue.Text = "Clear Mod Queue";
            this.InstallerToolTipMain.SetToolTip(this.ClearModQueue, "Empty out the mod install queue.");
            this.ClearModQueue.UseVisualStyleBackColor = true;
            this.ClearModQueue.Click += new System.EventHandler(this.ClearModQueue_Click);
            // 
            // ModInstallQueueHeader
            // 
            this.ModInstallQueueHeader.AutoSize = true;
            this.ModInstallQueueHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ModInstallQueueHeader.Location = new System.Drawing.Point(3, 54);
            this.ModInstallQueueHeader.Name = "ModInstallQueueHeader";
            this.ModInstallQueueHeader.Size = new System.Drawing.Size(111, 15);
            this.ModInstallQueueHeader.TabIndex = 3;
            this.ModInstallQueueHeader.Text = "Mod Install Queue:";
            // 
            // ModQueueList
            // 
            this.ModQueueList.FormattingEnabled = true;
            this.ModQueueList.Location = new System.Drawing.Point(12, 72);
            this.ModQueueList.Name = "ModQueueList";
            this.ModQueueList.Size = new System.Drawing.Size(606, 355);
            this.ModQueueList.TabIndex = 4;
            this.InstallerToolTipMain.SetToolTip(this.ModQueueList, "This is a list of all queued mods you want to install.\r\n\r\nYou have the option to " +
        "install only certain mods or install of these mods in one cycle.");
            this.ModQueueList.SelectedIndexChanged += new System.EventHandler(this.ModQueueList_SelectedIndexChanged);
            // 
            // TotalInstallProgress
            // 
            this.TotalInstallProgress.Location = new System.Drawing.Point(152, 434);
            this.TotalInstallProgress.Name = "TotalInstallProgress";
            this.TotalInstallProgress.Size = new System.Drawing.Size(401, 23);
            this.TotalInstallProgress.TabIndex = 5;
            // 
            // ModInstallProgress
            // 
            this.ModInstallProgress.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ModInstallProgress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ModInstallProgress.Location = new System.Drawing.Point(559, 438);
            this.ModInstallProgress.Name = "ModInstallProgress";
            this.ModInstallProgress.Size = new System.Drawing.Size(59, 15);
            this.ModInstallProgress.TabIndex = 6;
            this.ModInstallProgress.Text = "0%";
            this.ModInstallProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ModInstallProgLabel
            // 
            this.ModInstallProgLabel.AutoSize = true;
            this.ModInstallProgLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ModInstallProgLabel.Location = new System.Drawing.Point(12, 438);
            this.ModInstallProgLabel.Name = "ModInstallProgLabel";
            this.ModInstallProgLabel.Size = new System.Drawing.Size(122, 15);
            this.ModInstallProgLabel.TabIndex = 7;
            this.ModInstallProgLabel.Text = "Mod Install Progress:";
            // 
            // ExecuteInstall
            // 
            this.ExecuteInstall.Enabled = false;
            this.ExecuteInstall.Location = new System.Drawing.Point(490, 500);
            this.ExecuteInstall.Name = "ExecuteInstall";
            this.ExecuteInstall.Size = new System.Drawing.Size(128, 23);
            this.ExecuteInstall.TabIndex = 8;
            this.ExecuteInstall.Text = "Install All Mods";
            this.InstallerToolTipMain.SetToolTip(this.ExecuteInstall, "Install of the mods in the queue.");
            this.ExecuteInstall.UseVisualStyleBackColor = true;
            this.ExecuteInstall.Click += new System.EventHandler(this.ExecuteInstall_Click);
            // 
            // ExecuteInstallSelectedOnly
            // 
            this.ExecuteInstallSelectedOnly.Enabled = false;
            this.ExecuteInstallSelectedOnly.Location = new System.Drawing.Point(356, 500);
            this.ExecuteInstallSelectedOnly.Name = "ExecuteInstallSelectedOnly";
            this.ExecuteInstallSelectedOnly.Size = new System.Drawing.Size(128, 23);
            this.ExecuteInstallSelectedOnly.TabIndex = 9;
            this.ExecuteInstallSelectedOnly.Text = "Install Selected Mod";
            this.InstallerToolTipMain.SetToolTip(this.ExecuteInstallSelectedOnly, "Install only the selected mods in the queue list.");
            this.ExecuteInstallSelectedOnly.UseVisualStyleBackColor = true;
            this.ExecuteInstallSelectedOnly.Click += new System.EventHandler(this.ExecuteInstallSelectedOnly_Click);
            // 
            // InstallProgressInfo
            // 
            this.InstallProgressInfo.AutoSize = true;
            this.InstallProgressInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.InstallProgressInfo.Location = new System.Drawing.Point(12, 471);
            this.InstallProgressInfo.Name = "InstallProgressInfo";
            this.InstallProgressInfo.Size = new System.Drawing.Size(118, 15);
            this.InstallProgressInfo.TabIndex = 10;
            this.InstallProgressInfo.Text = "INSTALL_PROG_INFO";
            // 
            // InstallerBGWorker
            // 
            this.InstallerBGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.InstallerBGWorker_DoWork);
            // 
            // ModInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(630, 530);
            this.Controls.Add(this.InstallProgressInfo);
            this.Controls.Add(this.ExecuteInstallSelectedOnly);
            this.Controls.Add(this.ExecuteInstall);
            this.Controls.Add(this.ModInstallProgLabel);
            this.Controls.Add(this.ModInstallProgress);
            this.Controls.Add(this.TotalInstallProgress);
            this.Controls.Add(this.ModQueueList);
            this.Controls.Add(this.ModInstallQueueHeader);
            this.Controls.Add(this.ClearModQueue);
            this.Controls.Add(this.ModInstallerHeader);
            this.Controls.Add(this.AddModArchives);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModInstaller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mod Manager: Mod Installer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddModArchives;
        private System.Windows.Forms.Label ModInstallerHeader;
        private System.Windows.Forms.Button ClearModQueue;
        private System.Windows.Forms.Label ModInstallQueueHeader;
        private System.Windows.Forms.ListBox ModQueueList;
        private System.Windows.Forms.ProgressBar TotalInstallProgress;
        private System.Windows.Forms.Label ModInstallProgress;
        private System.Windows.Forms.Label ModInstallProgLabel;
        private System.Windows.Forms.Button ExecuteInstall;
        private System.Windows.Forms.Button ExecuteInstallSelectedOnly;
        private System.Windows.Forms.Label InstallProgressInfo;
        private System.ComponentModel.BackgroundWorker InstallerBGWorker;
        private System.Windows.Forms.ToolTip InstallerToolTipMain;
    }
}