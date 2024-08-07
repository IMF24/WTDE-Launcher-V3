namespace WTDE_Launcher_V3.Managers {
    partial class SCMMakeSetlistZIP {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCMMakeSetlistZIP));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.ExportOptionsHeader = new System.Windows.Forms.Label();
            this.ZIPFileNameLabel = new System.Windows.Forms.Label();
            this.ZIPFileName = new System.Windows.Forms.TextBox();
            this.SelectSavePathButton = new System.Windows.Forms.Button();
            this.UseGameIcon = new System.Windows.Forms.CheckBox();
            this.ExportOptionsPanel = new System.Windows.Forms.Panel();
            this.UseCustomChecksum = new System.Windows.Forms.CheckBox();
            this.UseCategoryChecksumNameButton = new System.Windows.Forms.Button();
            this.FolderConfigChecksum = new System.Windows.Forms.TextBox();
            this.WriteFolderINIFile = new System.Windows.Forms.CheckBox();
            this.UseCategoryImageNameButton = new System.Windows.Forms.Button();
            this.ExtraCategoriesHeader = new System.Windows.Forms.Label();
            this.FolderConfigIcon = new System.Windows.Forms.TextBox();
            this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.ExtraSongsHeader = new System.Windows.Forms.Label();
            this.ExtraCategoriesList = new System.Windows.Forms.ListBox();
            this.ExtraSongsList = new System.Windows.Forms.ListBox();
            this.AddSingleCateButton = new System.Windows.Forms.Button();
            this.AddFolderOfCatsButton = new System.Windows.Forms.Button();
            this.DeleteSingleExtraCateButton = new System.Windows.Forms.Button();
            this.ClearExtraCateListButton = new System.Windows.Forms.Button();
            this.AddSingleExSongButton = new System.Windows.Forms.Button();
            this.DeleteSingleExtraSongButton = new System.Windows.Forms.Button();
            this.ClearExtraSongListButton = new System.Windows.Forms.Button();
            this.AddFolderOfSongsButton = new System.Windows.Forms.Button();
            this.CompileSetlistZIPButton = new System.Windows.Forms.Button();
            this.ExportStatusPanel = new System.Windows.Forms.Panel();
            this.OutputLogHeader = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ExportStatusSideLabel = new System.Windows.Forms.Label();
            this.ExportStatusLabel = new System.Windows.Forms.Label();
            this.ExportPercentLabel = new System.Windows.Forms.Label();
            this.ExportProgressBar = new System.Windows.Forms.ProgressBar();
            this.OutputTextLog = new System.Windows.Forms.RichTextBox();
            this.OpenFinishedZIPButton = new System.Windows.Forms.Button();
            this.RedFieldsReminderLabel = new System.Windows.Forms.Label();
            this.ExportOptionsPanel.SuspendLayout();
            this.ExportStatusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(443, 13);
            this.InfoHeaderLabel.TabIndex = 5;
            this.InfoHeaderLabel.Text = "Make Setlist ZIP: Turn this category into a usable setlist package for WTDE.";
            // 
            // ExportOptionsHeader
            // 
            this.ExportOptionsHeader.AutoSize = true;
            this.ExportOptionsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportOptionsHeader.Location = new System.Drawing.Point(9, 4);
            this.ExportOptionsHeader.Name = "ExportOptionsHeader";
            this.ExportOptionsHeader.Size = new System.Drawing.Size(94, 13);
            this.ExportOptionsHeader.TabIndex = 6;
            this.ExportOptionsHeader.Text = "Export Options:";
            // 
            // ZIPFileNameLabel
            // 
            this.ZIPFileNameLabel.AutoSize = true;
            this.ZIPFileNameLabel.ForeColor = System.Drawing.Color.Red;
            this.ZIPFileNameLabel.Location = new System.Drawing.Point(26, 26);
            this.ZIPFileNameLabel.Name = "ZIPFileNameLabel";
            this.ZIPFileNameLabel.Size = new System.Drawing.Size(77, 13);
            this.ZIPFileNameLabel.TabIndex = 7;
            this.ZIPFileNameLabel.Text = "ZIP File Name:";
            // 
            // ZIPFileName
            // 
            this.ZIPFileName.Location = new System.Drawing.Point(109, 23);
            this.ZIPFileName.Name = "ZIPFileName";
            this.ZIPFileName.Size = new System.Drawing.Size(588, 20);
            this.ZIPFileName.TabIndex = 8;
            this.ToolTipMain.SetToolTip(this.ZIPFileName, "The path that the output ZIP file will be saved to.");
            this.ZIPFileName.TextChanged += new System.EventHandler(this.ZIPFileName_TextChanged);
            // 
            // SelectSavePathButton
            // 
            this.SelectSavePathButton.Location = new System.Drawing.Point(703, 22);
            this.SelectSavePathButton.Name = "SelectSavePathButton";
            this.SelectSavePathButton.Size = new System.Drawing.Size(24, 23);
            this.SelectSavePathButton.TabIndex = 9;
            this.SelectSavePathButton.Text = "...";
            this.ToolTipMain.SetToolTip(this.SelectSavePathButton, "Select a location to save the ZIP file to.");
            this.SelectSavePathButton.UseVisualStyleBackColor = true;
            this.SelectSavePathButton.Click += new System.EventHandler(this.SelectSavePathButton_Click);
            // 
            // UseGameIcon
            // 
            this.UseGameIcon.AutoSize = true;
            this.UseGameIcon.Location = new System.Drawing.Point(51, 101);
            this.UseGameIcon.Name = "UseGameIcon";
            this.UseGameIcon.Size = new System.Drawing.Size(111, 17);
            this.UseGameIcon.TabIndex = 13;
            this.UseGameIcon.Text = "Show Game Icon:";
            this.ToolTipMain.SetToolTip(this.UseGameIcon, "If enabled, sets all of the songs\' game icons to the specified one.");
            this.UseGameIcon.UseVisualStyleBackColor = true;
            this.UseGameIcon.CheckedChanged += new System.EventHandler(this.UseGameIcon_CheckedChanged);
            // 
            // ExportOptionsPanel
            // 
            this.ExportOptionsPanel.Controls.Add(this.AddFolderOfSongsButton);
            this.ExportOptionsPanel.Controls.Add(this.AddFolderOfCatsButton);
            this.ExportOptionsPanel.Controls.Add(this.ClearExtraSongListButton);
            this.ExportOptionsPanel.Controls.Add(this.ClearExtraCateListButton);
            this.ExportOptionsPanel.Controls.Add(this.DeleteSingleExtraSongButton);
            this.ExportOptionsPanel.Controls.Add(this.DeleteSingleExtraCateButton);
            this.ExportOptionsPanel.Controls.Add(this.AddSingleExSongButton);
            this.ExportOptionsPanel.Controls.Add(this.AddSingleCateButton);
            this.ExportOptionsPanel.Controls.Add(this.ExtraSongsList);
            this.ExportOptionsPanel.Controls.Add(this.ExtraCategoriesList);
            this.ExportOptionsPanel.Controls.Add(this.UseCustomChecksum);
            this.ExportOptionsPanel.Controls.Add(this.UseCategoryChecksumNameButton);
            this.ExportOptionsPanel.Controls.Add(this.FolderConfigChecksum);
            this.ExportOptionsPanel.Controls.Add(this.WriteFolderINIFile);
            this.ExportOptionsPanel.Controls.Add(this.UseGameIcon);
            this.ExportOptionsPanel.Controls.Add(this.ZIPFileName);
            this.ExportOptionsPanel.Controls.Add(this.UseCategoryImageNameButton);
            this.ExportOptionsPanel.Controls.Add(this.ExtraSongsHeader);
            this.ExportOptionsPanel.Controls.Add(this.ExtraCategoriesHeader);
            this.ExportOptionsPanel.Controls.Add(this.ExportOptionsHeader);
            this.ExportOptionsPanel.Controls.Add(this.FolderConfigIcon);
            this.ExportOptionsPanel.Controls.Add(this.ZIPFileNameLabel);
            this.ExportOptionsPanel.Controls.Add(this.SelectSavePathButton);
            this.ExportOptionsPanel.Location = new System.Drawing.Point(6, 40);
            this.ExportOptionsPanel.Name = "ExportOptionsPanel";
            this.ExportOptionsPanel.Size = new System.Drawing.Size(737, 338);
            this.ExportOptionsPanel.TabIndex = 14;
            // 
            // UseCustomChecksum
            // 
            this.UseCustomChecksum.AutoSize = true;
            this.UseCustomChecksum.Location = new System.Drawing.Point(51, 75);
            this.UseCustomChecksum.Name = "UseCustomChecksum";
            this.UseCustomChecksum.Size = new System.Drawing.Size(136, 17);
            this.UseCustomChecksum.TabIndex = 16;
            this.UseCustomChecksum.Text = "Set Custom Checksum:";
            this.ToolTipMain.SetToolTip(this.UseCustomChecksum, "If enabled, sets all of the songs\' tied category checksum to the specified one.");
            this.UseCustomChecksum.UseVisualStyleBackColor = true;
            this.UseCustomChecksum.CheckedChanged += new System.EventHandler(this.UseCustomChecksum_CheckedChanged);
            // 
            // UseCategoryChecksumNameButton
            // 
            this.UseCategoryChecksumNameButton.Location = new System.Drawing.Point(559, 72);
            this.UseCategoryChecksumNameButton.Name = "UseCategoryChecksumNameButton";
            this.UseCategoryChecksumNameButton.Size = new System.Drawing.Size(166, 23);
            this.UseCategoryChecksumNameButton.TabIndex = 15;
            this.UseCategoryChecksumNameButton.Text = "Set As Category\'s Checksum";
            this.ToolTipMain.SetToolTip(this.UseCategoryChecksumNameButton, "Set the checksum in the folder.ini file as the category\'s default checksum.");
            this.UseCategoryChecksumNameButton.UseVisualStyleBackColor = true;
            this.UseCategoryChecksumNameButton.Click += new System.EventHandler(this.UseCategoryChecksumNameButton_Click);
            // 
            // FolderConfigChecksum
            // 
            this.FolderConfigChecksum.Location = new System.Drawing.Point(193, 73);
            this.FolderConfigChecksum.Name = "FolderConfigChecksum";
            this.FolderConfigChecksum.Size = new System.Drawing.Size(360, 20);
            this.FolderConfigChecksum.TabIndex = 14;
            this.ToolTipMain.SetToolTip(this.FolderConfigChecksum, "The category checksum that will be written to the folder.ini file created on comp" +
        "ile.");
            // 
            // WriteFolderINIFile
            // 
            this.WriteFolderINIFile.AutoSize = true;
            this.WriteFolderINIFile.Location = new System.Drawing.Point(18, 52);
            this.WriteFolderINIFile.Name = "WriteFolderINIFile";
            this.WriteFolderINIFile.Size = new System.Drawing.Size(113, 17);
            this.WriteFolderINIFile.TabIndex = 13;
            this.WriteFolderINIFile.Text = "Write folder.ini FIle";
            this.ToolTipMain.SetToolTip(this.WriteFolderINIFile, "Writes a folder.ini file to the Songs folder in the file compile that will\r\nmake " +
        "every song in this category auto-tied to it.");
            this.WriteFolderINIFile.UseVisualStyleBackColor = true;
            this.WriteFolderINIFile.CheckedChanged += new System.EventHandler(this.WriteFolderINIFile_CheckedChanged);
            // 
            // UseCategoryImageNameButton
            // 
            this.UseCategoryImageNameButton.Location = new System.Drawing.Point(559, 98);
            this.UseCategoryImageNameButton.Name = "UseCategoryImageNameButton";
            this.UseCategoryImageNameButton.Size = new System.Drawing.Size(166, 23);
            this.UseCategoryImageNameButton.TabIndex = 12;
            this.UseCategoryImageNameButton.Text = "Set As Category\'s Image";
            this.ToolTipMain.SetToolTip(this.UseCategoryImageNameButton, "Set the image checksum in the folder.ini file as the category\'s default image.");
            this.UseCategoryImageNameButton.UseVisualStyleBackColor = true;
            this.UseCategoryImageNameButton.Click += new System.EventHandler(this.UseCategoryImageNameButton_Click);
            // 
            // ExtraCategoriesHeader
            // 
            this.ExtraCategoriesHeader.AutoSize = true;
            this.ExtraCategoriesHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtraCategoriesHeader.Location = new System.Drawing.Point(9, 133);
            this.ExtraCategoriesHeader.Name = "ExtraCategoriesHeader";
            this.ExtraCategoriesHeader.Size = new System.Drawing.Size(150, 13);
            this.ExtraCategoriesHeader.TabIndex = 6;
            this.ExtraCategoriesHeader.Text = "Include Extra Categories:";
            // 
            // FolderConfigIcon
            // 
            this.FolderConfigIcon.Location = new System.Drawing.Point(193, 99);
            this.FolderConfigIcon.Name = "FolderConfigIcon";
            this.FolderConfigIcon.Size = new System.Drawing.Size(360, 20);
            this.FolderConfigIcon.TabIndex = 11;
            this.ToolTipMain.SetToolTip(this.FolderConfigIcon, "The category image checksum that will be written to the folder.ini file created o" +
        "n compile.");
            // 
            // ExtraSongsHeader
            // 
            this.ExtraSongsHeader.AutoSize = true;
            this.ExtraSongsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtraSongsHeader.Location = new System.Drawing.Point(372, 133);
            this.ExtraSongsHeader.Name = "ExtraSongsHeader";
            this.ExtraSongsHeader.Size = new System.Drawing.Size(125, 13);
            this.ExtraSongsHeader.TabIndex = 6;
            this.ExtraSongsHeader.Text = "Include Extra Songs:";
            // 
            // ExtraCategoriesList
            // 
            this.ExtraCategoriesList.FormattingEnabled = true;
            this.ExtraCategoriesList.Location = new System.Drawing.Point(16, 150);
            this.ExtraCategoriesList.Name = "ExtraCategoriesList";
            this.ExtraCategoriesList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ExtraCategoriesList.Size = new System.Drawing.Size(346, 147);
            this.ExtraCategoriesList.TabIndex = 17;
            this.ToolTipMain.SetToolTip(this.ExtraCategoriesList, "This list is for EXTRA categories you want to include in the final compile.");
            // 
            // ExtraSongsList
            // 
            this.ExtraSongsList.FormattingEnabled = true;
            this.ExtraSongsList.Location = new System.Drawing.Point(379, 150);
            this.ExtraSongsList.Name = "ExtraSongsList";
            this.ExtraSongsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ExtraSongsList.Size = new System.Drawing.Size(346, 147);
            this.ExtraSongsList.TabIndex = 17;
            this.ToolTipMain.SetToolTip(this.ExtraSongsList, "This list is for EXTRA songs you want to include in the final compile.");
            // 
            // AddSingleCateButton
            // 
            this.AddSingleCateButton.Location = new System.Drawing.Point(14, 303);
            this.AddSingleCateButton.Name = "AddSingleCateButton";
            this.AddSingleCateButton.Size = new System.Drawing.Size(68, 23);
            this.AddSingleCateButton.TabIndex = 18;
            this.AddSingleCateButton.Text = "Add...";
            this.ToolTipMain.SetToolTip(this.AddSingleCateButton, "Add a single category mod to the list.");
            this.AddSingleCateButton.UseVisualStyleBackColor = true;
            this.AddSingleCateButton.Click += new System.EventHandler(this.AddSingleCateButton_Click);
            // 
            // AddFolderOfCatsButton
            // 
            this.AddFolderOfCatsButton.Location = new System.Drawing.Point(88, 303);
            this.AddFolderOfCatsButton.Name = "AddFolderOfCatsButton";
            this.AddFolderOfCatsButton.Size = new System.Drawing.Size(126, 23);
            this.AddFolderOfCatsButton.TabIndex = 18;
            this.AddFolderOfCatsButton.Text = "Add Folder of Mods...";
            this.ToolTipMain.SetToolTip(this.AddFolderOfCatsButton, "Add a folder of category mods into the list.");
            this.AddFolderOfCatsButton.UseVisualStyleBackColor = true;
            this.AddFolderOfCatsButton.Click += new System.EventHandler(this.AddFolderOfCatsButton_Click);
            // 
            // DeleteSingleExtraCateButton
            // 
            this.DeleteSingleExtraCateButton.Location = new System.Drawing.Point(220, 303);
            this.DeleteSingleExtraCateButton.Name = "DeleteSingleExtraCateButton";
            this.DeleteSingleExtraCateButton.Size = new System.Drawing.Size(67, 23);
            this.DeleteSingleExtraCateButton.TabIndex = 18;
            this.DeleteSingleExtraCateButton.Text = "Delete";
            this.ToolTipMain.SetToolTip(this.DeleteSingleExtraCateButton, "Delete the currently selected extra categories.");
            this.DeleteSingleExtraCateButton.UseVisualStyleBackColor = true;
            this.DeleteSingleExtraCateButton.Click += new System.EventHandler(this.DeleteSingleExtraCateButton_Click);
            // 
            // ClearExtraCateListButton
            // 
            this.ClearExtraCateListButton.Location = new System.Drawing.Point(293, 303);
            this.ClearExtraCateListButton.Name = "ClearExtraCateListButton";
            this.ClearExtraCateListButton.Size = new System.Drawing.Size(67, 23);
            this.ClearExtraCateListButton.TabIndex = 18;
            this.ClearExtraCateListButton.Text = "Clear";
            this.ToolTipMain.SetToolTip(this.ClearExtraCateListButton, "Clear the entire list of extra categories to include.");
            this.ClearExtraCateListButton.UseVisualStyleBackColor = true;
            this.ClearExtraCateListButton.Click += new System.EventHandler(this.ClearExtraCateListButton_Click);
            // 
            // AddSingleExSongButton
            // 
            this.AddSingleExSongButton.Location = new System.Drawing.Point(379, 303);
            this.AddSingleExSongButton.Name = "AddSingleExSongButton";
            this.AddSingleExSongButton.Size = new System.Drawing.Size(68, 23);
            this.AddSingleExSongButton.TabIndex = 18;
            this.AddSingleExSongButton.Text = "Add...";
            this.ToolTipMain.SetToolTip(this.AddSingleExSongButton, "Add a single song mod to the list.");
            this.AddSingleExSongButton.UseVisualStyleBackColor = true;
            this.AddSingleExSongButton.Click += new System.EventHandler(this.AddSingleExSongButton_Click);
            // 
            // DeleteSingleExtraSongButton
            // 
            this.DeleteSingleExtraSongButton.Location = new System.Drawing.Point(585, 303);
            this.DeleteSingleExtraSongButton.Name = "DeleteSingleExtraSongButton";
            this.DeleteSingleExtraSongButton.Size = new System.Drawing.Size(67, 23);
            this.DeleteSingleExtraSongButton.TabIndex = 18;
            this.DeleteSingleExtraSongButton.Text = "Delete";
            this.ToolTipMain.SetToolTip(this.DeleteSingleExtraSongButton, "Delete the currently selected extra songs.");
            this.DeleteSingleExtraSongButton.UseVisualStyleBackColor = true;
            this.DeleteSingleExtraSongButton.Click += new System.EventHandler(this.DeleteSingleExtraSongButton_Click);
            // 
            // ClearExtraSongListButton
            // 
            this.ClearExtraSongListButton.Location = new System.Drawing.Point(658, 303);
            this.ClearExtraSongListButton.Name = "ClearExtraSongListButton";
            this.ClearExtraSongListButton.Size = new System.Drawing.Size(67, 23);
            this.ClearExtraSongListButton.TabIndex = 18;
            this.ClearExtraSongListButton.Text = "Clear";
            this.ToolTipMain.SetToolTip(this.ClearExtraSongListButton, "Clear the entire list of extra songs to include.");
            this.ClearExtraSongListButton.UseVisualStyleBackColor = true;
            this.ClearExtraSongListButton.Click += new System.EventHandler(this.ClearExtraSongListButton_Click);
            // 
            // AddFolderOfSongsButton
            // 
            this.AddFolderOfSongsButton.Location = new System.Drawing.Point(453, 303);
            this.AddFolderOfSongsButton.Name = "AddFolderOfSongsButton";
            this.AddFolderOfSongsButton.Size = new System.Drawing.Size(126, 23);
            this.AddFolderOfSongsButton.TabIndex = 18;
            this.AddFolderOfSongsButton.Text = "Add Folder of Mods...";
            this.ToolTipMain.SetToolTip(this.AddFolderOfSongsButton, "Add a folder of song mods into the list.");
            this.AddFolderOfSongsButton.UseVisualStyleBackColor = true;
            this.AddFolderOfSongsButton.Click += new System.EventHandler(this.AddFolderOfSongsButton_Click);
            // 
            // CompileSetlistZIPButton
            // 
            this.CompileSetlistZIPButton.Location = new System.Drawing.Point(22, 384);
            this.CompileSetlistZIPButton.Name = "CompileSetlistZIPButton";
            this.CompileSetlistZIPButton.Size = new System.Drawing.Size(709, 53);
            this.CompileSetlistZIPButton.TabIndex = 15;
            this.CompileSetlistZIPButton.Text = "Compile Setlist ZIP";
            this.ToolTipMain.SetToolTip(this.CompileSetlistZIPButton, resources.GetString("CompileSetlistZIPButton.ToolTip"));
            this.CompileSetlistZIPButton.UseVisualStyleBackColor = true;
            this.CompileSetlistZIPButton.Click += new System.EventHandler(this.CompileSetlistZIPButton_Click);
            // 
            // ExportStatusPanel
            // 
            this.ExportStatusPanel.Controls.Add(this.OutputTextLog);
            this.ExportStatusPanel.Controls.Add(this.ExportProgressBar);
            this.ExportStatusPanel.Controls.Add(this.ExportStatusLabel);
            this.ExportStatusPanel.Controls.Add(this.ExportPercentLabel);
            this.ExportStatusPanel.Controls.Add(this.ExportStatusSideLabel);
            this.ExportStatusPanel.Controls.Add(this.OutputLogHeader);
            this.ExportStatusPanel.Enabled = false;
            this.ExportStatusPanel.Location = new System.Drawing.Point(6, 443);
            this.ExportStatusPanel.Name = "ExportStatusPanel";
            this.ExportStatusPanel.Size = new System.Drawing.Size(737, 256);
            this.ExportStatusPanel.TabIndex = 14;
            // 
            // OutputLogHeader
            // 
            this.OutputLogHeader.AutoSize = true;
            this.OutputLogHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputLogHeader.Location = new System.Drawing.Point(9, 4);
            this.OutputLogHeader.Name = "OutputLogHeader";
            this.OutputLogHeader.Size = new System.Drawing.Size(70, 13);
            this.OutputLogHeader.TabIndex = 6;
            this.OutputLogHeader.Text = "Output Log";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(660, 705);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(83, 23);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "Close";
            this.ToolTipMain.SetToolTip(this.CloseButton, "Closes this dialog.");
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ExportStatusSideLabel
            // 
            this.ExportStatusSideLabel.AutoSize = true;
            this.ExportStatusSideLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportStatusSideLabel.Location = new System.Drawing.Point(13, 202);
            this.ExportStatusSideLabel.Name = "ExportStatusSideLabel";
            this.ExportStatusSideLabel.Size = new System.Drawing.Size(87, 13);
            this.ExportStatusSideLabel.TabIndex = 6;
            this.ExportStatusSideLabel.Text = "Export Status:";
            // 
            // ExportStatusLabel
            // 
            this.ExportStatusLabel.AutoSize = true;
            this.ExportStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ExportStatusLabel.Location = new System.Drawing.Point(26, 230);
            this.ExportStatusLabel.Name = "ExportStatusLabel";
            this.ExportStatusLabel.Size = new System.Drawing.Size(148, 13);
            this.ExportStatusLabel.TabIndex = 6;
            this.ExportStatusLabel.Text = "<EXPORT_STATUS_HERE>";
            // 
            // ExportPercentLabel
            // 
            this.ExportPercentLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ExportPercentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportPercentLabel.Location = new System.Drawing.Point(665, 202);
            this.ExportPercentLabel.Name = "ExportPercentLabel";
            this.ExportPercentLabel.Size = new System.Drawing.Size(60, 13);
            this.ExportPercentLabel.TabIndex = 6;
            this.ExportPercentLabel.Text = "0%";
            this.ExportPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ExportProgressBar
            // 
            this.ExportProgressBar.Location = new System.Drawing.Point(109, 197);
            this.ExportProgressBar.Name = "ExportProgressBar";
            this.ExportProgressBar.Size = new System.Drawing.Size(550, 23);
            this.ExportProgressBar.TabIndex = 7;
            // 
            // OutputTextLog
            // 
            this.OutputTextLog.Location = new System.Drawing.Point(18, 20);
            this.OutputTextLog.Name = "OutputTextLog";
            this.OutputTextLog.Size = new System.Drawing.Size(707, 171);
            this.OutputTextLog.TabIndex = 8;
            this.OutputTextLog.Text = "";
            this.ToolTipMain.SetToolTip(this.OutputTextLog, "Log of output data.\r\n\r\nIf anything important arises, it will show here!");
            // 
            // OpenFinishedZIPButton
            // 
            this.OpenFinishedZIPButton.Location = new System.Drawing.Point(459, 705);
            this.OpenFinishedZIPButton.Name = "OpenFinishedZIPButton";
            this.OpenFinishedZIPButton.Size = new System.Drawing.Size(189, 23);
            this.OpenFinishedZIPButton.TabIndex = 9;
            this.OpenFinishedZIPButton.Text = "Open Compiled ZIP Location";
            this.ToolTipMain.SetToolTip(this.OpenFinishedZIPButton, "Open the folder that contains the newly compiled ZIP inside it.");
            this.OpenFinishedZIPButton.UseVisualStyleBackColor = true;
            this.OpenFinishedZIPButton.Visible = false;
            this.OpenFinishedZIPButton.Click += new System.EventHandler(this.OpenFinishedZIPButton_Click);
            // 
            // RedFieldsReminderLabel
            // 
            this.RedFieldsReminderLabel.AutoSize = true;
            this.RedFieldsReminderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.RedFieldsReminderLabel.ForeColor = System.Drawing.Color.Red;
            this.RedFieldsReminderLabel.Location = new System.Drawing.Point(10, 22);
            this.RedFieldsReminderLabel.Name = "RedFieldsReminderLabel";
            this.RedFieldsReminderLabel.Size = new System.Drawing.Size(236, 13);
            this.RedFieldsReminderLabel.TabIndex = 5;
            this.RedFieldsReminderLabel.Text = "Note: Red fields indicate required fields.";
            // 
            // SCMMakeSetlistZIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(749, 735);
            this.Controls.Add(this.RedFieldsReminderLabel);
            this.Controls.Add(this.InfoHeaderLabel);
            this.Controls.Add(this.OpenFinishedZIPButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ExportStatusPanel);
            this.Controls.Add(this.ExportOptionsPanel);
            this.Controls.Add(this.CompileSetlistZIPButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SCMMakeSetlistZIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Make Setlist ZIP";
            this.ExportOptionsPanel.ResumeLayout(false);
            this.ExportOptionsPanel.PerformLayout();
            this.ExportStatusPanel.ResumeLayout(false);
            this.ExportStatusPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.Label ExportOptionsHeader;
        private System.Windows.Forms.Label ZIPFileNameLabel;
        private System.Windows.Forms.TextBox ZIPFileName;
        private System.Windows.Forms.Button SelectSavePathButton;
        private System.Windows.Forms.CheckBox UseGameIcon;
        private System.Windows.Forms.ToolTip ToolTipMain;
        private System.Windows.Forms.Panel ExportOptionsPanel;
        private System.Windows.Forms.CheckBox WriteFolderINIFile;
        private System.Windows.Forms.Button UseCategoryImageNameButton;
        private System.Windows.Forms.TextBox FolderConfigIcon;
        private System.Windows.Forms.CheckBox UseCustomChecksum;
        private System.Windows.Forms.Button UseCategoryChecksumNameButton;
        private System.Windows.Forms.TextBox FolderConfigChecksum;
        private System.Windows.Forms.Label ExtraCategoriesHeader;
        private System.Windows.Forms.Button AddFolderOfCatsButton;
        private System.Windows.Forms.Button ClearExtraCateListButton;
        private System.Windows.Forms.Button DeleteSingleExtraCateButton;
        private System.Windows.Forms.Button AddSingleCateButton;
        private System.Windows.Forms.ListBox ExtraSongsList;
        private System.Windows.Forms.ListBox ExtraCategoriesList;
        private System.Windows.Forms.Label ExtraSongsHeader;
        private System.Windows.Forms.Button AddFolderOfSongsButton;
        private System.Windows.Forms.Button ClearExtraSongListButton;
        private System.Windows.Forms.Button DeleteSingleExtraSongButton;
        private System.Windows.Forms.Button AddSingleExSongButton;
        private System.Windows.Forms.Button CompileSetlistZIPButton;
        private System.Windows.Forms.Panel ExportStatusPanel;
        private System.Windows.Forms.Label ExportStatusLabel;
        private System.Windows.Forms.Label ExportPercentLabel;
        private System.Windows.Forms.Label ExportStatusSideLabel;
        private System.Windows.Forms.Label OutputLogHeader;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.RichTextBox OutputTextLog;
        private System.Windows.Forms.ProgressBar ExportProgressBar;
        private System.Windows.Forms.Button OpenFinishedZIPButton;
        private System.Windows.Forms.Label RedFieldsReminderLabel;
    }
}