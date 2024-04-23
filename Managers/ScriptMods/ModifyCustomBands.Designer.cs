namespace WTDE_Launcher_V3.Managers.ScriptMods {
    partial class ModifyCustomBands {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyCustomBands));
            this.AvatarImageCobalt = new System.Windows.Forms.PictureBox();
            this.AvatarImageIMF = new System.Windows.Forms.PictureBox();
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.BandLayoutsList = new System.Windows.Forms.ListBox();
            this.BandLayoutsHeader = new System.Windows.Forms.Label();
            this.NewBandButton = new System.Windows.Forms.Button();
            this.EraseBandButton = new System.Windows.Forms.Button();
            this.BandPropsHeader = new System.Windows.Forms.Label();
            this.GtrMemberLabel = new System.Windows.Forms.Label();
            this.BandGuitarist = new System.Windows.Forms.TextBox();
            this.HideGuitarist = new System.Windows.Forms.CheckBox();
            this.SelectGuitaristChar = new System.Windows.Forms.Button();
            this.SelectBassistChar = new System.Windows.Forms.Button();
            this.HideBassist = new System.Windows.Forms.CheckBox();
            this.BandBassist = new System.Windows.Forms.TextBox();
            this.BasMemberLabel = new System.Windows.Forms.Label();
            this.SelectDrummerChar = new System.Windows.Forms.Button();
            this.HideDrummer = new System.Windows.Forms.CheckBox();
            this.BandDrummer = new System.Windows.Forms.TextBox();
            this.DrmMemberLabel = new System.Windows.Forms.Label();
            this.BandName = new System.Windows.Forms.TextBox();
            this.BandNameLabel = new System.Windows.Forms.Label();
            this.BandMembersHeader = new System.Windows.Forms.Label();
            this.SelectSingerChar = new System.Windows.Forms.Button();
            this.HideSinger = new System.Windows.Forms.CheckBox();
            this.BandSinger = new System.Windows.Forms.TextBox();
            this.VoxMemberLabel = new System.Windows.Forms.Label();
            this.AdvancedPropsHeader = new System.Windows.Forms.Label();
            this.AllowPlayerChars = new System.Windows.Forms.CheckBox();
            this.VocalistHasGuitar = new System.Windows.Forms.CheckBox();
            this.VocalistHasBass = new System.Windows.Forms.CheckBox();
            this.LoadingClip = new System.Windows.Forms.TextBox();
            this.LoadingClipLabel = new System.Windows.Forms.Label();
            this.ApplyToSongsHeader = new System.Windows.Forms.Label();
            this.ApplyToSongs = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SelectSDKPath = new System.Windows.Forms.Button();
            this.SDKPath = new System.Windows.Forms.TextBox();
            this.SDKPathLabel = new System.Windows.Forms.Label();
            this.MainEditorField = new System.Windows.Forms.Panel();
            this.BGWorkMain = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarImageCobalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarImageIMF)).BeginInit();
            this.MainEditorField.SuspendLayout();
            this.SuspendLayout();
            // 
            // AvatarImageCobalt
            // 
            this.AvatarImageCobalt.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.logo_cobalt;
            this.AvatarImageCobalt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AvatarImageCobalt.Location = new System.Drawing.Point(68, 6);
            this.AvatarImageCobalt.Name = "AvatarImageCobalt";
            this.AvatarImageCobalt.Size = new System.Drawing.Size(52, 52);
            this.AvatarImageCobalt.TabIndex = 47;
            this.AvatarImageCobalt.TabStop = false;
            // 
            // AvatarImageIMF
            // 
            this.AvatarImageIMF.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.logo_imf24;
            this.AvatarImageIMF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AvatarImageIMF.Location = new System.Drawing.Point(10, 6);
            this.AvatarImageIMF.Name = "AvatarImageIMF";
            this.AvatarImageIMF.Size = new System.Drawing.Size(52, 52);
            this.AvatarImageIMF.TabIndex = 46;
            this.AvatarImageIMF.TabStop = false;
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(126, 6);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(572, 39);
            this.InfoHeaderLabel.TabIndex = 45;
            this.InfoHeaderLabel.Text = "Modify and Create Band Lineups: Make new or alter existing band lineups. Requires" +
    " GHSDK to use.\r\n\r\nAuthor: IMF24, Cobalt";
            // 
            // BandLayoutsList
            // 
            this.BandLayoutsList.FormattingEnabled = true;
            this.BandLayoutsList.Location = new System.Drawing.Point(16, 81);
            this.BandLayoutsList.Name = "BandLayoutsList";
            this.BandLayoutsList.Size = new System.Drawing.Size(322, 433);
            this.BandLayoutsList.TabIndex = 48;
            this.BandLayoutsList.SelectedIndexChanged += new System.EventHandler(this.BandLayoutsList_SelectedIndexChanged);
            // 
            // BandLayoutsHeader
            // 
            this.BandLayoutsHeader.AutoSize = true;
            this.BandLayoutsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BandLayoutsHeader.Location = new System.Drawing.Point(7, 65);
            this.BandLayoutsHeader.Name = "BandLayoutsHeader";
            this.BandLayoutsHeader.Size = new System.Drawing.Size(129, 13);
            this.BandLayoutsHeader.TabIndex = 49;
            this.BandLayoutsHeader.Text = "Band Layouts Queue:";
            // 
            // NewBandButton
            // 
            this.NewBandButton.Location = new System.Drawing.Point(16, 518);
            this.NewBandButton.Name = "NewBandButton";
            this.NewBandButton.Size = new System.Drawing.Size(152, 23);
            this.NewBandButton.TabIndex = 50;
            this.NewBandButton.Text = "Create New Band";
            this.NewBandButton.UseVisualStyleBackColor = true;
            this.NewBandButton.Click += new System.EventHandler(this.NewBandButton_Click);
            // 
            // EraseBandButton
            // 
            this.EraseBandButton.Location = new System.Drawing.Point(186, 518);
            this.EraseBandButton.Name = "EraseBandButton";
            this.EraseBandButton.Size = new System.Drawing.Size(152, 23);
            this.EraseBandButton.TabIndex = 51;
            this.EraseBandButton.Text = "Erase Selected Band";
            this.EraseBandButton.UseVisualStyleBackColor = true;
            this.EraseBandButton.Click += new System.EventHandler(this.EraseBandButton_Click);
            // 
            // BandPropsHeader
            // 
            this.BandPropsHeader.AutoSize = true;
            this.BandPropsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BandPropsHeader.Location = new System.Drawing.Point(0, 4);
            this.BandPropsHeader.Name = "BandPropsHeader";
            this.BandPropsHeader.Size = new System.Drawing.Size(143, 13);
            this.BandPropsHeader.TabIndex = 52;
            this.BandPropsHeader.Text = "Band Layout Properties:";
            // 
            // GtrMemberLabel
            // 
            this.GtrMemberLabel.AutoSize = true;
            this.GtrMemberLabel.Location = new System.Drawing.Point(29, 87);
            this.GtrMemberLabel.Name = "GtrMemberLabel";
            this.GtrMemberLabel.Size = new System.Drawing.Size(48, 13);
            this.GtrMemberLabel.TabIndex = 53;
            this.GtrMemberLabel.Text = "Guitarist:";
            // 
            // BandGuitarist
            // 
            this.BandGuitarist.Location = new System.Drawing.Point(83, 84);
            this.BandGuitarist.Name = "BandGuitarist";
            this.BandGuitarist.Size = new System.Drawing.Size(253, 20);
            this.BandGuitarist.TabIndex = 54;
            // 
            // HideGuitarist
            // 
            this.HideGuitarist.AutoSize = true;
            this.HideGuitarist.Location = new System.Drawing.Point(382, 86);
            this.HideGuitarist.Name = "HideGuitarist";
            this.HideGuitarist.Size = new System.Drawing.Size(95, 17);
            this.HideGuitarist.TabIndex = 55;
            this.HideGuitarist.Text = "Hide Member?";
            this.HideGuitarist.UseVisualStyleBackColor = true;
            // 
            // SelectGuitaristChar
            // 
            this.SelectGuitaristChar.Location = new System.Drawing.Point(342, 83);
            this.SelectGuitaristChar.Name = "SelectGuitaristChar";
            this.SelectGuitaristChar.Size = new System.Drawing.Size(26, 23);
            this.SelectGuitaristChar.TabIndex = 56;
            this.SelectGuitaristChar.Text = "...";
            this.SelectGuitaristChar.UseVisualStyleBackColor = true;
            this.SelectGuitaristChar.Click += new System.EventHandler(this.SelectGuitaristChar_Click);
            // 
            // SelectBassistChar
            // 
            this.SelectBassistChar.Location = new System.Drawing.Point(342, 109);
            this.SelectBassistChar.Name = "SelectBassistChar";
            this.SelectBassistChar.Size = new System.Drawing.Size(26, 23);
            this.SelectBassistChar.TabIndex = 60;
            this.SelectBassistChar.Text = "...";
            this.SelectBassistChar.UseVisualStyleBackColor = true;
            this.SelectBassistChar.Click += new System.EventHandler(this.SelectBassistChar_Click);
            // 
            // HideBassist
            // 
            this.HideBassist.AutoSize = true;
            this.HideBassist.Location = new System.Drawing.Point(382, 112);
            this.HideBassist.Name = "HideBassist";
            this.HideBassist.Size = new System.Drawing.Size(95, 17);
            this.HideBassist.TabIndex = 59;
            this.HideBassist.Text = "Hide Member?";
            this.HideBassist.UseVisualStyleBackColor = true;
            // 
            // BandBassist
            // 
            this.BandBassist.Location = new System.Drawing.Point(83, 110);
            this.BandBassist.Name = "BandBassist";
            this.BandBassist.Size = new System.Drawing.Size(253, 20);
            this.BandBassist.TabIndex = 58;
            // 
            // BasMemberLabel
            // 
            this.BasMemberLabel.AutoSize = true;
            this.BasMemberLabel.Location = new System.Drawing.Point(34, 113);
            this.BasMemberLabel.Name = "BasMemberLabel";
            this.BasMemberLabel.Size = new System.Drawing.Size(43, 13);
            this.BasMemberLabel.TabIndex = 57;
            this.BasMemberLabel.Text = "Bassist:";
            // 
            // SelectDrummerChar
            // 
            this.SelectDrummerChar.Location = new System.Drawing.Point(342, 135);
            this.SelectDrummerChar.Name = "SelectDrummerChar";
            this.SelectDrummerChar.Size = new System.Drawing.Size(26, 23);
            this.SelectDrummerChar.TabIndex = 64;
            this.SelectDrummerChar.Text = "...";
            this.SelectDrummerChar.UseVisualStyleBackColor = true;
            this.SelectDrummerChar.Click += new System.EventHandler(this.SelectDrummerChar_Click);
            // 
            // HideDrummer
            // 
            this.HideDrummer.AutoSize = true;
            this.HideDrummer.Location = new System.Drawing.Point(382, 138);
            this.HideDrummer.Name = "HideDrummer";
            this.HideDrummer.Size = new System.Drawing.Size(95, 17);
            this.HideDrummer.TabIndex = 63;
            this.HideDrummer.Text = "Hide Member?";
            this.HideDrummer.UseVisualStyleBackColor = true;
            // 
            // BandDrummer
            // 
            this.BandDrummer.Location = new System.Drawing.Point(83, 136);
            this.BandDrummer.Name = "BandDrummer";
            this.BandDrummer.Size = new System.Drawing.Size(253, 20);
            this.BandDrummer.TabIndex = 62;
            // 
            // DrmMemberLabel
            // 
            this.DrmMemberLabel.AutoSize = true;
            this.DrmMemberLabel.Location = new System.Drawing.Point(25, 139);
            this.DrmMemberLabel.Name = "DrmMemberLabel";
            this.DrmMemberLabel.Size = new System.Drawing.Size(52, 13);
            this.DrmMemberLabel.TabIndex = 61;
            this.DrmMemberLabel.Text = "Drummer:";
            // 
            // BandName
            // 
            this.BandName.Location = new System.Drawing.Point(95, 24);
            this.BandName.Name = "BandName";
            this.BandName.Size = new System.Drawing.Size(377, 20);
            this.BandName.TabIndex = 66;
            this.BandName.TextChanged += new System.EventHandler(this.BandName_TextChanged);
            // 
            // BandNameLabel
            // 
            this.BandNameLabel.AutoSize = true;
            this.BandNameLabel.Location = new System.Drawing.Point(23, 27);
            this.BandNameLabel.Name = "BandNameLabel";
            this.BandNameLabel.Size = new System.Drawing.Size(66, 13);
            this.BandNameLabel.TabIndex = 65;
            this.BandNameLabel.Text = "Band Name:";
            // 
            // BandMembersHeader
            // 
            this.BandMembersHeader.AutoSize = true;
            this.BandMembersHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BandMembersHeader.Location = new System.Drawing.Point(0, 64);
            this.BandMembersHeader.Name = "BandMembersHeader";
            this.BandMembersHeader.Size = new System.Drawing.Size(94, 13);
            this.BandMembersHeader.TabIndex = 67;
            this.BandMembersHeader.Text = "Band Members:";
            // 
            // SelectSingerChar
            // 
            this.SelectSingerChar.Location = new System.Drawing.Point(342, 161);
            this.SelectSingerChar.Name = "SelectSingerChar";
            this.SelectSingerChar.Size = new System.Drawing.Size(26, 23);
            this.SelectSingerChar.TabIndex = 71;
            this.SelectSingerChar.Text = "...";
            this.SelectSingerChar.UseVisualStyleBackColor = true;
            this.SelectSingerChar.Click += new System.EventHandler(this.SelectSingerChar_Click);
            // 
            // HideSinger
            // 
            this.HideSinger.AutoSize = true;
            this.HideSinger.Location = new System.Drawing.Point(382, 164);
            this.HideSinger.Name = "HideSinger";
            this.HideSinger.Size = new System.Drawing.Size(95, 17);
            this.HideSinger.TabIndex = 70;
            this.HideSinger.Text = "Hide Member?";
            this.HideSinger.UseVisualStyleBackColor = true;
            // 
            // BandSinger
            // 
            this.BandSinger.Location = new System.Drawing.Point(83, 162);
            this.BandSinger.Name = "BandSinger";
            this.BandSinger.Size = new System.Drawing.Size(253, 20);
            this.BandSinger.TabIndex = 69;
            // 
            // VoxMemberLabel
            // 
            this.VoxMemberLabel.AutoSize = true;
            this.VoxMemberLabel.Location = new System.Drawing.Point(30, 165);
            this.VoxMemberLabel.Name = "VoxMemberLabel";
            this.VoxMemberLabel.Size = new System.Drawing.Size(47, 13);
            this.VoxMemberLabel.TabIndex = 68;
            this.VoxMemberLabel.Text = "Vocalist:";
            // 
            // AdvancedPropsHeader
            // 
            this.AdvancedPropsHeader.AutoSize = true;
            this.AdvancedPropsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.AdvancedPropsHeader.Location = new System.Drawing.Point(0, 200);
            this.AdvancedPropsHeader.Name = "AdvancedPropsHeader";
            this.AdvancedPropsHeader.Size = new System.Drawing.Size(118, 13);
            this.AdvancedPropsHeader.TabIndex = 72;
            this.AdvancedPropsHeader.Text = "Advanced Settings:";
            // 
            // AllowPlayerChars
            // 
            this.AllowPlayerChars.AutoSize = true;
            this.AllowPlayerChars.Location = new System.Drawing.Point(17, 221);
            this.AllowPlayerChars.Name = "AllowPlayerChars";
            this.AllowPlayerChars.Size = new System.Drawing.Size(182, 17);
            this.AllowPlayerChars.TabIndex = 73;
            this.AllowPlayerChars.Text = "Allow Player Selected Characters";
            this.AllowPlayerChars.UseVisualStyleBackColor = true;
            // 
            // VocalistHasGuitar
            // 
            this.VocalistHasGuitar.AutoSize = true;
            this.VocalistHasGuitar.Location = new System.Drawing.Point(17, 244);
            this.VocalistHasGuitar.Name = "VocalistHasGuitar";
            this.VocalistHasGuitar.Size = new System.Drawing.Size(116, 17);
            this.VocalistHasGuitar.TabIndex = 74;
            this.VocalistHasGuitar.Text = "Vocalist Has Guitar";
            this.VocalistHasGuitar.UseVisualStyleBackColor = true;
            // 
            // VocalistHasBass
            // 
            this.VocalistHasBass.AutoSize = true;
            this.VocalistHasBass.Location = new System.Drawing.Point(17, 267);
            this.VocalistHasBass.Name = "VocalistHasBass";
            this.VocalistHasBass.Size = new System.Drawing.Size(111, 17);
            this.VocalistHasBass.TabIndex = 75;
            this.VocalistHasBass.Text = "Vocalist Has Bass";
            this.VocalistHasBass.UseVisualStyleBackColor = true;
            // 
            // LoadingClip
            // 
            this.LoadingClip.Location = new System.Drawing.Point(88, 288);
            this.LoadingClip.Name = "LoadingClip";
            this.LoadingClip.Size = new System.Drawing.Size(199, 20);
            this.LoadingClip.TabIndex = 77;
            // 
            // LoadingClipLabel
            // 
            this.LoadingClipLabel.AutoSize = true;
            this.LoadingClipLabel.Location = new System.Drawing.Point(14, 291);
            this.LoadingClipLabel.Name = "LoadingClipLabel";
            this.LoadingClipLabel.Size = new System.Drawing.Size(68, 13);
            this.LoadingClipLabel.TabIndex = 76;
            this.LoadingClipLabel.Text = "Loading Clip:";
            // 
            // ApplyToSongsHeader
            // 
            this.ApplyToSongsHeader.AutoSize = true;
            this.ApplyToSongsHeader.Location = new System.Drawing.Point(14, 314);
            this.ApplyToSongsHeader.Name = "ApplyToSongsHeader";
            this.ApplyToSongsHeader.Size = new System.Drawing.Size(247, 13);
            this.ApplyToSongsHeader.TabIndex = 78;
            this.ApplyToSongsHeader.Text = "Apply Band to Songs (separate each by new lines):";
            // 
            // ApplyToSongs
            // 
            this.ApplyToSongs.Location = new System.Drawing.Point(26, 334);
            this.ApplyToSongs.MaxLength = 65536;
            this.ApplyToSongs.Multiline = true;
            this.ApplyToSongs.Name = "ApplyToSongs";
            this.ApplyToSongs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ApplyToSongs.Size = new System.Drawing.Size(446, 119);
            this.ApplyToSongs.TabIndex = 79;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(532, 575);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(215, 23);
            this.OKButton.TabIndex = 80;
            this.OKButton.Text = "OK / Compile Script Mod";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(753, 575);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(76, 23);
            this.CancelButton.TabIndex = 81;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // SelectSDKPath
            // 
            this.SelectSDKPath.Location = new System.Drawing.Point(411, 543);
            this.SelectSDKPath.Name = "SelectSDKPath";
            this.SelectSDKPath.Size = new System.Drawing.Size(28, 23);
            this.SelectSDKPath.TabIndex = 84;
            this.SelectSDKPath.Text = "...";
            this.SelectSDKPath.UseVisualStyleBackColor = true;
            // 
            // SDKPath
            // 
            this.SDKPath.Location = new System.Drawing.Point(87, 545);
            this.SDKPath.Name = "SDKPath";
            this.SDKPath.Size = new System.Drawing.Size(318, 20);
            this.SDKPath.TabIndex = 83;
            // 
            // SDKPathLabel
            // 
            this.SDKPathLabel.AutoSize = true;
            this.SDKPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.SDKPathLabel.ForeColor = System.Drawing.Color.Red;
            this.SDKPathLabel.Location = new System.Drawing.Point(15, 548);
            this.SDKPathLabel.Name = "SDKPathLabel";
            this.SDKPathLabel.Size = new System.Drawing.Size(66, 13);
            this.SDKPathLabel.TabIndex = 82;
            this.SDKPathLabel.Text = "SDK Path:";
            // 
            // MainEditorField
            // 
            this.MainEditorField.Controls.Add(this.BandPropsHeader);
            this.MainEditorField.Controls.Add(this.GtrMemberLabel);
            this.MainEditorField.Controls.Add(this.BandGuitarist);
            this.MainEditorField.Controls.Add(this.HideGuitarist);
            this.MainEditorField.Controls.Add(this.SelectGuitaristChar);
            this.MainEditorField.Controls.Add(this.ApplyToSongs);
            this.MainEditorField.Controls.Add(this.BasMemberLabel);
            this.MainEditorField.Controls.Add(this.ApplyToSongsHeader);
            this.MainEditorField.Controls.Add(this.BandBassist);
            this.MainEditorField.Controls.Add(this.LoadingClip);
            this.MainEditorField.Controls.Add(this.HideBassist);
            this.MainEditorField.Controls.Add(this.LoadingClipLabel);
            this.MainEditorField.Controls.Add(this.SelectBassistChar);
            this.MainEditorField.Controls.Add(this.VocalistHasBass);
            this.MainEditorField.Controls.Add(this.DrmMemberLabel);
            this.MainEditorField.Controls.Add(this.VocalistHasGuitar);
            this.MainEditorField.Controls.Add(this.BandDrummer);
            this.MainEditorField.Controls.Add(this.AllowPlayerChars);
            this.MainEditorField.Controls.Add(this.HideDrummer);
            this.MainEditorField.Controls.Add(this.AdvancedPropsHeader);
            this.MainEditorField.Controls.Add(this.SelectDrummerChar);
            this.MainEditorField.Controls.Add(this.SelectSingerChar);
            this.MainEditorField.Controls.Add(this.BandNameLabel);
            this.MainEditorField.Controls.Add(this.HideSinger);
            this.MainEditorField.Controls.Add(this.BandName);
            this.MainEditorField.Controls.Add(this.BandSinger);
            this.MainEditorField.Controls.Add(this.BandMembersHeader);
            this.MainEditorField.Controls.Add(this.VoxMemberLabel);
            this.MainEditorField.Location = new System.Drawing.Point(347, 61);
            this.MainEditorField.Name = "MainEditorField";
            this.MainEditorField.Size = new System.Drawing.Size(482, 476);
            this.MainEditorField.TabIndex = 85;
            // 
            // BGWorkMain
            // 
            this.BGWorkMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorkMain_DoWork);
            // 
            // ModifyCustomBands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 603);
            this.Controls.Add(this.SelectSDKPath);
            this.Controls.Add(this.SDKPath);
            this.Controls.Add(this.SDKPathLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.EraseBandButton);
            this.Controls.Add(this.NewBandButton);
            this.Controls.Add(this.BandLayoutsHeader);
            this.Controls.Add(this.BandLayoutsList);
            this.Controls.Add(this.AvatarImageCobalt);
            this.Controls.Add(this.AvatarImageIMF);
            this.Controls.Add(this.InfoHeaderLabel);
            this.Controls.Add(this.MainEditorField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyCustomBands";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Script Mod Editor: Band Lineup Editor";
            ((System.ComponentModel.ISupportInitialize)(this.AvatarImageCobalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarImageIMF)).EndInit();
            this.MainEditorField.ResumeLayout(false);
            this.MainEditorField.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AvatarImageCobalt;
        private System.Windows.Forms.PictureBox AvatarImageIMF;
        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.ListBox BandLayoutsList;
        private System.Windows.Forms.Label BandLayoutsHeader;
        private System.Windows.Forms.Button NewBandButton;
        private System.Windows.Forms.Button EraseBandButton;
        private System.Windows.Forms.Label BandPropsHeader;
        private System.Windows.Forms.Label GtrMemberLabel;
        private System.Windows.Forms.TextBox BandGuitarist;
        private System.Windows.Forms.CheckBox HideGuitarist;
        private System.Windows.Forms.Button SelectGuitaristChar;
        private System.Windows.Forms.Button SelectBassistChar;
        private System.Windows.Forms.CheckBox HideBassist;
        private System.Windows.Forms.TextBox BandBassist;
        private System.Windows.Forms.Label BasMemberLabel;
        private System.Windows.Forms.Button SelectDrummerChar;
        private System.Windows.Forms.CheckBox HideDrummer;
        private System.Windows.Forms.TextBox BandDrummer;
        private System.Windows.Forms.Label DrmMemberLabel;
        private System.Windows.Forms.TextBox BandName;
        private System.Windows.Forms.Label BandNameLabel;
        private System.Windows.Forms.Label BandMembersHeader;
        private System.Windows.Forms.Button SelectSingerChar;
        private System.Windows.Forms.CheckBox HideSinger;
        private System.Windows.Forms.TextBox BandSinger;
        private System.Windows.Forms.Label VoxMemberLabel;
        private System.Windows.Forms.Label AdvancedPropsHeader;
        private System.Windows.Forms.CheckBox AllowPlayerChars;
        private System.Windows.Forms.CheckBox VocalistHasGuitar;
        private System.Windows.Forms.CheckBox VocalistHasBass;
        private System.Windows.Forms.TextBox LoadingClip;
        private System.Windows.Forms.Label LoadingClipLabel;
        private System.Windows.Forms.Label ApplyToSongsHeader;
        private System.Windows.Forms.TextBox ApplyToSongs;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SelectSDKPath;
        private System.Windows.Forms.TextBox SDKPath;
        private System.Windows.Forms.Label SDKPathLabel;
        private System.Windows.Forms.Panel MainEditorField;
        private System.ComponentModel.BackgroundWorker BGWorkMain;
    }
}