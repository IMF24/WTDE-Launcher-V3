namespace WTDE_Launcher_V3.Managers {
    partial class ModManagerPluginManager {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModManagerPluginManager));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.PluginListHeader = new System.Windows.Forms.Label();
            this.PluginsList = new System.Windows.Forms.ListView();
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PathHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PluginInfoHeader = new System.Windows.Forms.Label();
            this.InstallPluginButton = new System.Windows.Forms.Button();
            this.PluginNameSideLabel = new System.Windows.Forms.Label();
            this.UninstallPluginButton = new System.Windows.Forms.Button();
            this.ParameterHeaderLabel = new System.Windows.Forms.Label();
            this.PluginParametersList = new System.Windows.Forms.ListView();
            this.ParamHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValueHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PluginName = new System.Windows.Forms.Label();
            this.PluginAuthor = new System.Windows.Forms.Label();
            this.PluginAuthorSideLabel = new System.Windows.Forms.Label();
            this.PluginHelpHeader = new System.Windows.Forms.Label();
            this.PluginHelp = new System.Windows.Forms.RichTextBox();
            this.PluginStatusSideLabel = new System.Windows.Forms.Label();
            this.PluginStatus = new System.Windows.Forms.ComboBox();
            this.PluginVersion = new System.Windows.Forms.Label();
            this.PluginVersionSideLabel = new System.Windows.Forms.Label();
            this.ApplyButton = new System.Windows.Forms.Button();
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
            this.InfoHeaderLabel.Size = new System.Drawing.Size(431, 13);
            this.InfoHeaderLabel.TabIndex = 3;
            this.InfoHeaderLabel.Text = "Mod Manager Plugins: Manage your installed plugins for the Mod Manager.";
            // 
            // PluginListHeader
            // 
            this.PluginListHeader.AutoSize = true;
            this.PluginListHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.PluginListHeader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PluginListHeader.Location = new System.Drawing.Point(6, 25);
            this.PluginListHeader.Name = "PluginListHeader";
            this.PluginListHeader.Size = new System.Drawing.Size(104, 13);
            this.PluginListHeader.TabIndex = 4;
            this.PluginListHeader.Text = "Installed Plugins:";
            // 
            // PluginsList
            // 
            this.PluginsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader,
            this.AuthorHeader,
            this.DescriptionHeader,
            this.PathHeader,
            this.StatusHeader});
            this.PluginsList.GridLines = true;
            this.PluginsList.HideSelection = false;
            this.PluginsList.Location = new System.Drawing.Point(15, 41);
            this.PluginsList.Name = "PluginsList";
            this.PluginsList.Size = new System.Drawing.Size(483, 569);
            this.PluginsList.TabIndex = 5;
            this.PluginsList.UseCompatibleStateImageBehavior = false;
            this.PluginsList.View = System.Windows.Forms.View.Details;
            this.PluginsList.SelectedIndexChanged += new System.EventHandler(this.PluginsList_SelectedIndexChanged);
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "Name";
            this.NameHeader.Width = 88;
            // 
            // AuthorHeader
            // 
            this.AuthorHeader.Text = "Author";
            this.AuthorHeader.Width = 82;
            // 
            // DescriptionHeader
            // 
            this.DescriptionHeader.Text = "Description";
            this.DescriptionHeader.Width = 131;
            // 
            // PathHeader
            // 
            this.PathHeader.Text = "Path";
            this.PathHeader.Width = 100;
            // 
            // StatusHeader
            // 
            this.StatusHeader.Text = "Status";
            // 
            // PluginInfoHeader
            // 
            this.PluginInfoHeader.AutoSize = true;
            this.PluginInfoHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.PluginInfoHeader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PluginInfoHeader.Location = new System.Drawing.Point(509, 25);
            this.PluginInfoHeader.Name = "PluginInfoHeader";
            this.PluginInfoHeader.Size = new System.Drawing.Size(72, 13);
            this.PluginInfoHeader.TabIndex = 4;
            this.PluginInfoHeader.Text = "Plugin Info:";
            // 
            // InstallPluginButton
            // 
            this.InstallPluginButton.Location = new System.Drawing.Point(15, 616);
            this.InstallPluginButton.Name = "InstallPluginButton";
            this.InstallPluginButton.Size = new System.Drawing.Size(220, 23);
            this.InstallPluginButton.TabIndex = 6;
            this.InstallPluginButton.Text = "Install Plugin...";
            this.InstallPluginButton.UseVisualStyleBackColor = true;
            // 
            // PluginNameSideLabel
            // 
            this.PluginNameSideLabel.AutoSize = true;
            this.PluginNameSideLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.PluginNameSideLabel.Location = new System.Drawing.Point(525, 46);
            this.PluginNameSideLabel.Name = "PluginNameSideLabel";
            this.PluginNameSideLabel.Size = new System.Drawing.Size(43, 13);
            this.PluginNameSideLabel.TabIndex = 7;
            this.PluginNameSideLabel.Text = "Name:";
            // 
            // UninstallPluginButton
            // 
            this.UninstallPluginButton.Location = new System.Drawing.Point(278, 616);
            this.UninstallPluginButton.Name = "UninstallPluginButton";
            this.UninstallPluginButton.Size = new System.Drawing.Size(220, 23);
            this.UninstallPluginButton.TabIndex = 8;
            this.UninstallPluginButton.Text = "Uninstall Plugin...";
            this.UninstallPluginButton.UseVisualStyleBackColor = true;
            // 
            // ParameterHeaderLabel
            // 
            this.ParameterHeaderLabel.AutoSize = true;
            this.ParameterHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ParameterHeaderLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ParameterHeaderLabel.Location = new System.Drawing.Point(940, 25);
            this.ParameterHeaderLabel.Name = "ParameterHeaderLabel";
            this.ParameterHeaderLabel.Size = new System.Drawing.Size(113, 13);
            this.ParameterHeaderLabel.TabIndex = 9;
            this.ParameterHeaderLabel.Text = "Plugin Parameters:";
            // 
            // PluginParametersList
            // 
            this.PluginParametersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ParamHeader,
            this.ValueHeader});
            this.PluginParametersList.GridLines = true;
            this.PluginParametersList.HideSelection = false;
            this.PluginParametersList.Location = new System.Drawing.Point(950, 41);
            this.PluginParametersList.Name = "PluginParametersList";
            this.PluginParametersList.Size = new System.Drawing.Size(423, 598);
            this.PluginParametersList.TabIndex = 10;
            this.PluginParametersList.UseCompatibleStateImageBehavior = false;
            this.PluginParametersList.View = System.Windows.Forms.View.Details;
            // 
            // ParamHeader
            // 
            this.ParamHeader.Text = "Parameter";
            this.ParamHeader.Width = 145;
            // 
            // ValueHeader
            // 
            this.ValueHeader.Text = "Value";
            this.ValueHeader.Width = 273;
            // 
            // PluginName
            // 
            this.PluginName.BackColor = System.Drawing.Color.White;
            this.PluginName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PluginName.Location = new System.Drawing.Point(572, 43);
            this.PluginName.Name = "PluginName";
            this.PluginName.Size = new System.Drawing.Size(361, 21);
            this.PluginName.TabIndex = 11;
            this.PluginName.Text = "PLUGIN NAME HERE";
            this.PluginName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PluginAuthor
            // 
            this.PluginAuthor.BackColor = System.Drawing.Color.White;
            this.PluginAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PluginAuthor.Location = new System.Drawing.Point(572, 70);
            this.PluginAuthor.Name = "PluginAuthor";
            this.PluginAuthor.Size = new System.Drawing.Size(361, 21);
            this.PluginAuthor.TabIndex = 13;
            this.PluginAuthor.Text = "PLUGIN AUTHOR HERE";
            this.PluginAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PluginAuthorSideLabel
            // 
            this.PluginAuthorSideLabel.AutoSize = true;
            this.PluginAuthorSideLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.PluginAuthorSideLabel.Location = new System.Drawing.Point(520, 73);
            this.PluginAuthorSideLabel.Name = "PluginAuthorSideLabel";
            this.PluginAuthorSideLabel.Size = new System.Drawing.Size(48, 13);
            this.PluginAuthorSideLabel.TabIndex = 12;
            this.PluginAuthorSideLabel.Text = "Author:";
            // 
            // PluginHelpHeader
            // 
            this.PluginHelpHeader.AutoSize = true;
            this.PluginHelpHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.PluginHelpHeader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PluginHelpHeader.Location = new System.Drawing.Point(509, 130);
            this.PluginHelpHeader.Name = "PluginHelpHeader";
            this.PluginHelpHeader.Size = new System.Drawing.Size(72, 13);
            this.PluginHelpHeader.TabIndex = 14;
            this.PluginHelpHeader.Text = "Plugin Help";
            // 
            // PluginHelp
            // 
            this.PluginHelp.BackColor = System.Drawing.Color.White;
            this.PluginHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PluginHelp.Location = new System.Drawing.Point(518, 147);
            this.PluginHelp.Name = "PluginHelp";
            this.PluginHelp.Size = new System.Drawing.Size(415, 492);
            this.PluginHelp.TabIndex = 15;
            this.PluginHelp.Text = "";
            // 
            // PluginStatusSideLabel
            // 
            this.PluginStatusSideLabel.AutoSize = true;
            this.PluginStatusSideLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.PluginStatusSideLabel.Location = new System.Drawing.Point(521, 101);
            this.PluginStatusSideLabel.Name = "PluginStatusSideLabel";
            this.PluginStatusSideLabel.Size = new System.Drawing.Size(47, 13);
            this.PluginStatusSideLabel.TabIndex = 12;
            this.PluginStatusSideLabel.Text = "Status:";
            // 
            // PluginStatus
            // 
            this.PluginStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PluginStatus.FormattingEnabled = true;
            this.PluginStatus.Items.AddRange(new object[] {
            "ON",
            "OFF"});
            this.PluginStatus.Location = new System.Drawing.Point(572, 98);
            this.PluginStatus.Name = "PluginStatus";
            this.PluginStatus.Size = new System.Drawing.Size(121, 21);
            this.PluginStatus.TabIndex = 16;
            // 
            // PluginVersion
            // 
            this.PluginVersion.BackColor = System.Drawing.Color.White;
            this.PluginVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PluginVersion.Location = new System.Drawing.Point(807, 98);
            this.PluginVersion.Name = "PluginVersion";
            this.PluginVersion.Size = new System.Drawing.Size(126, 21);
            this.PluginVersion.TabIndex = 17;
            this.PluginVersion.Text = "1.0";
            this.PluginVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PluginVersionSideLabel
            // 
            this.PluginVersionSideLabel.AutoSize = true;
            this.PluginVersionSideLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.PluginVersionSideLabel.Location = new System.Drawing.Point(748, 101);
            this.PluginVersionSideLabel.Name = "PluginVersionSideLabel";
            this.PluginVersionSideLabel.Size = new System.Drawing.Size(53, 13);
            this.PluginVersionSideLabel.TabIndex = 12;
            this.PluginVersionSideLabel.Text = "Version:";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(1305, 643);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 18;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(1224, 643);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 18;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(1143, 643);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 18;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // ModManagerPluginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1385, 670);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.PluginVersion);
            this.Controls.Add(this.PluginStatus);
            this.Controls.Add(this.PluginHelp);
            this.Controls.Add(this.PluginHelpHeader);
            this.Controls.Add(this.PluginAuthor);
            this.Controls.Add(this.PluginStatusSideLabel);
            this.Controls.Add(this.PluginVersionSideLabel);
            this.Controls.Add(this.PluginAuthorSideLabel);
            this.Controls.Add(this.PluginName);
            this.Controls.Add(this.PluginParametersList);
            this.Controls.Add(this.ParameterHeaderLabel);
            this.Controls.Add(this.UninstallPluginButton);
            this.Controls.Add(this.PluginNameSideLabel);
            this.Controls.Add(this.InstallPluginButton);
            this.Controls.Add(this.PluginsList);
            this.Controls.Add(this.PluginInfoHeader);
            this.Controls.Add(this.PluginListHeader);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ModManagerPluginManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mod Manager: Manage Plugins";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.Label PluginListHeader;
        private System.Windows.Forms.ListView PluginsList;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.ColumnHeader AuthorHeader;
        private System.Windows.Forms.ColumnHeader DescriptionHeader;
        private System.Windows.Forms.ColumnHeader PathHeader;
        private System.Windows.Forms.Label PluginInfoHeader;
        private System.Windows.Forms.Button InstallPluginButton;
        private System.Windows.Forms.Label PluginNameSideLabel;
        private System.Windows.Forms.Button UninstallPluginButton;
        private System.Windows.Forms.Label ParameterHeaderLabel;
        private System.Windows.Forms.ListView PluginParametersList;
        private System.Windows.Forms.ColumnHeader ParamHeader;
        private System.Windows.Forms.ColumnHeader ValueHeader;
        private System.Windows.Forms.ColumnHeader StatusHeader;
        private System.Windows.Forms.Label PluginName;
        private System.Windows.Forms.Label PluginAuthor;
        private System.Windows.Forms.Label PluginAuthorSideLabel;
        private System.Windows.Forms.Label PluginHelpHeader;
        private System.Windows.Forms.RichTextBox PluginHelp;
        private System.Windows.Forms.Label PluginStatusSideLabel;
        private System.Windows.Forms.ComboBox PluginStatus;
        private System.Windows.Forms.Label PluginVersion;
        private System.Windows.Forms.Label PluginVersionSideLabel;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
    }
}