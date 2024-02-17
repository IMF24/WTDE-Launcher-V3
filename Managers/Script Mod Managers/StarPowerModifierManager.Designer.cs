namespace WTDE_Launcher_V3 {
    partial class StarPowerModifierManager {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StarPowerModifierManager));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.ArrayIDLabel = new System.Windows.Forms.Label();
            this.SPGemColorsHeader = new System.Windows.Forms.Label();
            this.StarColor = new System.Windows.Forms.Label();
            this.SPGemColorLabel = new System.Windows.Forms.Label();
            this.ChangeStarColor = new System.Windows.Forms.Button();
            this.ChangeKickStarColor = new System.Windows.Forms.Button();
            this.KickStarColor = new System.Windows.Forms.Label();
            this.KickStarLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.ChangeBaseKickStarColor = new System.Windows.Forms.Button();
            this.BaseKickStarColor = new System.Windows.Forms.Label();
            this.BaseKickColorLabel = new System.Windows.Forms.Label();
            this.ChangeBaseStarColor = new System.Windows.Forms.Button();
            this.BaseStarColor = new System.Windows.Forms.Label();
            this.BaseColorLabel = new System.Windows.Forms.Label();
            this.AvatarImageBox = new System.Windows.Forms.PictureBox();
            this.ChangeHighwayTintColor = new System.Windows.Forms.Button();
            this.HighwayColor = new System.Windows.Forms.Label();
            this.HWTintColorHeader = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.FlameLightningColsHeader = new System.Windows.Forms.Label();
            this.FXArray = new System.Windows.Forms.ComboBox();
            this.ChangeBlueFlameColor = new System.Windows.Forms.Button();
            this.BlueColor = new System.Windows.Forms.Label();
            this.BlueFlameLabel = new System.Windows.Forms.Label();
            this.ChangeOrangeFlameColor = new System.Windows.Forms.Button();
            this.OrangeColor = new System.Windows.Forms.Label();
            this.HitFlameColors = new System.Windows.Forms.Label();
            this.OrangeFlameLabel = new System.Windows.Forms.Label();
            this.ChangeGlowColor = new System.Windows.Forms.Button();
            this.GlowColor = new System.Windows.Forms.Label();
            this.SPBoardGlowLabel = new System.Windows.Forms.Label();
            this.ChangeLightningColor = new System.Windows.Forms.Button();
            this.LightningColor = new System.Windows.Forms.Label();
            this.StarPowerFXHeader = new System.Windows.Forms.Label();
            this.SPLightningLabel = new System.Windows.Forms.Label();
            this.SPMToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.AvatarImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(68, 6);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(485, 39);
            this.InfoHeaderLabel.TabIndex = 2;
            this.InfoHeaderLabel.Text = "Star Power Modifier: Alters the look of Star Power notes, lightning, and flame co" +
    "lors.\r\n\r\nAuthor: IMF24, Zedek The Plague Doctor";
            // 
            // ArrayIDLabel
            // 
            this.ArrayIDLabel.AutoSize = true;
            this.ArrayIDLabel.Location = new System.Drawing.Point(22, 240);
            this.ArrayIDLabel.Name = "ArrayIDLabel";
            this.ArrayIDLabel.Size = new System.Drawing.Size(48, 13);
            this.ArrayIDLabel.TabIndex = 3;
            this.ArrayIDLabel.Text = "Array ID:";
            // 
            // SPGemColorsHeader
            // 
            this.SPGemColorsHeader.AutoSize = true;
            this.SPGemColorsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.SPGemColorsHeader.Location = new System.Drawing.Point(7, 64);
            this.SPGemColorsHeader.Name = "SPGemColorsHeader";
            this.SPGemColorsHeader.Size = new System.Drawing.Size(95, 13);
            this.SPGemColorsHeader.TabIndex = 5;
            this.SPGemColorsHeader.Text = "SP Gem Colors:";
            // 
            // StarColor
            // 
            this.StarColor.BackColor = System.Drawing.Color.Cyan;
            this.StarColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StarColor.Location = new System.Drawing.Point(271, 82);
            this.StarColor.Name = "StarColor";
            this.StarColor.Size = new System.Drawing.Size(24, 24);
            this.StarColor.TabIndex = 6;
            this.SPMToolTipMain.SetToolTip(this.StarColor, "The gem color of notes while Star Power is active.");
            // 
            // SPGemColorLabel
            // 
            this.SPGemColorLabel.AutoSize = true;
            this.SPGemColorLabel.Location = new System.Drawing.Point(22, 87);
            this.SPGemColorLabel.Name = "SPGemColorLabel";
            this.SPGemColorLabel.Size = new System.Drawing.Size(81, 13);
            this.SPGemColorLabel.TabIndex = 3;
            this.SPGemColorLabel.Text = "Star Gem Color:";
            // 
            // ChangeStarColor
            // 
            this.ChangeStarColor.Location = new System.Drawing.Point(178, 82);
            this.ChangeStarColor.Name = "ChangeStarColor";
            this.ChangeStarColor.Size = new System.Drawing.Size(84, 23);
            this.ChangeStarColor.TabIndex = 7;
            this.ChangeStarColor.Text = "Pick Color...";
            this.ChangeStarColor.UseVisualStyleBackColor = true;
            this.ChangeStarColor.Click += new System.EventHandler(this.ChangeStarColor_Click);
            // 
            // ChangeKickStarColor
            // 
            this.ChangeKickStarColor.Location = new System.Drawing.Point(178, 111);
            this.ChangeKickStarColor.Name = "ChangeKickStarColor";
            this.ChangeKickStarColor.Size = new System.Drawing.Size(84, 23);
            this.ChangeKickStarColor.TabIndex = 10;
            this.ChangeKickStarColor.Text = "Pick Color...";
            this.ChangeKickStarColor.UseVisualStyleBackColor = true;
            this.ChangeKickStarColor.Click += new System.EventHandler(this.ChangeKickStarColor_Click);
            // 
            // KickStarColor
            // 
            this.KickStarColor.BackColor = System.Drawing.Color.Cyan;
            this.KickStarColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KickStarColor.Location = new System.Drawing.Point(271, 111);
            this.KickStarColor.Name = "KickStarColor";
            this.KickStarColor.Size = new System.Drawing.Size(24, 24);
            this.KickStarColor.TabIndex = 9;
            this.SPMToolTipMain.SetToolTip(this.KickStarColor, "The gem color of open notes or kick drums while Star Power is active.");
            // 
            // KickStarLabel
            // 
            this.KickStarLabel.AutoSize = true;
            this.KickStarLabel.Location = new System.Drawing.Point(22, 116);
            this.KickStarLabel.Name = "KickStarLabel";
            this.KickStarLabel.Size = new System.Drawing.Size(115, 13);
            this.KickStarLabel.TabIndex = 8;
            this.KickStarLabel.Text = "Kick/Open Note Color:";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(566, 378);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Cancel";
            this.SPMToolTipMain.SetToolTip(this.CancelButton, "Close this window without saving any changes.");
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(485, 378);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 11;
            this.OKButton.Text = "OK";
            this.SPMToolTipMain.SetToolTip(this.OKButton, "Save all changes and close this window.");
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ChangeBaseKickStarColor
            // 
            this.ChangeBaseKickStarColor.Location = new System.Drawing.Point(178, 169);
            this.ChangeBaseKickStarColor.Name = "ChangeBaseKickStarColor";
            this.ChangeBaseKickStarColor.Size = new System.Drawing.Size(84, 23);
            this.ChangeBaseKickStarColor.TabIndex = 17;
            this.ChangeBaseKickStarColor.Text = "Pick Color...";
            this.ChangeBaseKickStarColor.UseVisualStyleBackColor = true;
            this.ChangeBaseKickStarColor.Click += new System.EventHandler(this.ChangeBaseKickStarColor_Click);
            // 
            // BaseKickStarColor
            // 
            this.BaseKickStarColor.BackColor = System.Drawing.Color.White;
            this.BaseKickStarColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BaseKickStarColor.Location = new System.Drawing.Point(271, 169);
            this.BaseKickStarColor.Name = "BaseKickStarColor";
            this.BaseKickStarColor.Size = new System.Drawing.Size(24, 24);
            this.BaseKickStarColor.TabIndex = 16;
            this.SPMToolTipMain.SetToolTip(this.BaseKickStarColor, "The base gem color for kick or open notes. Same as the base gem color,\r\nbut appli" +
        "es to open/kick drum notes.");
            // 
            // BaseKickColorLabel
            // 
            this.BaseKickColorLabel.AutoSize = true;
            this.BaseKickColorLabel.Location = new System.Drawing.Point(22, 174);
            this.BaseKickColorLabel.Name = "BaseKickColorLabel";
            this.BaseKickColorLabel.Size = new System.Drawing.Size(111, 13);
            this.BaseKickColorLabel.TabIndex = 15;
            this.BaseKickColorLabel.Text = "Base Kick Note Color:";
            // 
            // ChangeBaseStarColor
            // 
            this.ChangeBaseStarColor.Location = new System.Drawing.Point(178, 140);
            this.ChangeBaseStarColor.Name = "ChangeBaseStarColor";
            this.ChangeBaseStarColor.Size = new System.Drawing.Size(84, 23);
            this.ChangeBaseStarColor.TabIndex = 14;
            this.ChangeBaseStarColor.Text = "Pick Color...";
            this.ChangeBaseStarColor.UseVisualStyleBackColor = true;
            this.ChangeBaseStarColor.Click += new System.EventHandler(this.ChangeBaseStarColor_Click);
            // 
            // BaseStarColor
            // 
            this.BaseStarColor.BackColor = System.Drawing.Color.White;
            this.BaseStarColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BaseStarColor.Location = new System.Drawing.Point(271, 140);
            this.BaseStarColor.Name = "BaseStarColor";
            this.BaseStarColor.Size = new System.Drawing.Size(24, 24);
            this.BaseStarColor.TabIndex = 13;
            this.SPMToolTipMain.SetToolTip(this.BaseStarColor, "The base gem color. This is the lower-most part of the note; in other words,\r\nit " +
        "is indicative of the ring around the bottom of the note.");
            // 
            // BaseColorLabel
            // 
            this.BaseColorLabel.AutoSize = true;
            this.BaseColorLabel.Location = new System.Drawing.Point(22, 145);
            this.BaseColorLabel.Name = "BaseColorLabel";
            this.BaseColorLabel.Size = new System.Drawing.Size(86, 13);
            this.BaseColorLabel.TabIndex = 12;
            this.BaseColorLabel.Text = "Base Gem Color:";
            // 
            // AvatarImageBox
            // 
            this.AvatarImageBox.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.logo_imf24;
            this.AvatarImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AvatarImageBox.Location = new System.Drawing.Point(10, 6);
            this.AvatarImageBox.Name = "AvatarImageBox";
            this.AvatarImageBox.Size = new System.Drawing.Size(52, 52);
            this.AvatarImageBox.TabIndex = 18;
            this.AvatarImageBox.TabStop = false;
            // 
            // ChangeHighwayTintColor
            // 
            this.ChangeHighwayTintColor.Location = new System.Drawing.Point(521, 82);
            this.ChangeHighwayTintColor.Name = "ChangeHighwayTintColor";
            this.ChangeHighwayTintColor.Size = new System.Drawing.Size(84, 23);
            this.ChangeHighwayTintColor.TabIndex = 22;
            this.ChangeHighwayTintColor.Text = "Pick Color...";
            this.ChangeHighwayTintColor.UseVisualStyleBackColor = true;
            this.ChangeHighwayTintColor.Click += new System.EventHandler(this.ChangeHighwayTintColor_Click);
            // 
            // HighwayColor
            // 
            this.HighwayColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.HighwayColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HighwayColor.Location = new System.Drawing.Point(614, 82);
            this.HighwayColor.Name = "HighwayColor";
            this.HighwayColor.Size = new System.Drawing.Size(24, 24);
            this.HighwayColor.TabIndex = 21;
            this.SPMToolTipMain.SetToolTip(this.HighwayColor, "Tint of the highway while Star Power is active.");
            // 
            // HWTintColorHeader
            // 
            this.HWTintColorHeader.AutoSize = true;
            this.HWTintColorHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.HWTintColorHeader.Location = new System.Drawing.Point(350, 64);
            this.HWTintColorHeader.Name = "HWTintColorHeader";
            this.HWTintColorHeader.Size = new System.Drawing.Size(105, 13);
            this.HWTintColorHeader.TabIndex = 20;
            this.HWTintColorHeader.Text = "SP Highway Tint:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(365, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "SP Highway Tint Color:";
            // 
            // FlameLightningColsHeader
            // 
            this.FlameLightningColsHeader.AutoSize = true;
            this.FlameLightningColsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.FlameLightningColsHeader.Location = new System.Drawing.Point(7, 215);
            this.FlameLightningColsHeader.Name = "FlameLightningColsHeader";
            this.FlameLightningColsHeader.Size = new System.Drawing.Size(164, 13);
            this.FlameLightningColsHeader.TabIndex = 23;
            this.FlameLightningColsHeader.Text = "Flame and Lightning Colors:";
            // 
            // FXArray
            // 
            this.FXArray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FXArray.FormattingEnabled = true;
            this.FXArray.Items.AddRange(new object[] {
            "standard_fx",
            "pink_fx",
            "stealth_fx",
            "Eggs_N_Bacon_fx",
            "Old_Glory_fx",
            "Toxic_Waste_fx",
            "Diabolic_fx"});
            this.FXArray.Location = new System.Drawing.Point(76, 237);
            this.FXArray.Name = "FXArray";
            this.FXArray.Size = new System.Drawing.Size(219, 21);
            this.FXArray.TabIndex = 24;
            this.SPMToolTipMain.SetToolTip(this.FXArray, resources.GetString("FXArray.ToolTip"));
            // 
            // ChangeBlueFlameColor
            // 
            this.ChangeBlueFlameColor.Location = new System.Drawing.Point(178, 328);
            this.ChangeBlueFlameColor.Name = "ChangeBlueFlameColor";
            this.ChangeBlueFlameColor.Size = new System.Drawing.Size(84, 23);
            this.ChangeBlueFlameColor.TabIndex = 31;
            this.ChangeBlueFlameColor.Text = "Pick Color...";
            this.ChangeBlueFlameColor.UseVisualStyleBackColor = true;
            this.ChangeBlueFlameColor.Click += new System.EventHandler(this.ChangeBlueFlameColor_Click);
            // 
            // BlueColor
            // 
            this.BlueColor.BackColor = System.Drawing.Color.Cyan;
            this.BlueColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlueColor.Location = new System.Drawing.Point(271, 328);
            this.BlueColor.Name = "BlueColor";
            this.BlueColor.Size = new System.Drawing.Size(24, 24);
            this.BlueColor.TabIndex = 30;
            this.SPMToolTipMain.SetToolTip(this.BlueColor, "The color of the note flames while Star Power IS active.");
            // 
            // BlueFlameLabel
            // 
            this.BlueFlameLabel.AutoSize = true;
            this.BlueFlameLabel.Location = new System.Drawing.Point(22, 333);
            this.BlueFlameLabel.Name = "BlueFlameLabel";
            this.BlueFlameLabel.Size = new System.Drawing.Size(115, 13);
            this.BlueFlameLabel.TabIndex = 29;
            this.BlueFlameLabel.Text = "SP Active Flame Color:";
            // 
            // ChangeOrangeFlameColor
            // 
            this.ChangeOrangeFlameColor.Location = new System.Drawing.Point(178, 299);
            this.ChangeOrangeFlameColor.Name = "ChangeOrangeFlameColor";
            this.ChangeOrangeFlameColor.Size = new System.Drawing.Size(84, 23);
            this.ChangeOrangeFlameColor.TabIndex = 28;
            this.ChangeOrangeFlameColor.Text = "Pick Color...";
            this.ChangeOrangeFlameColor.UseVisualStyleBackColor = true;
            this.ChangeOrangeFlameColor.Click += new System.EventHandler(this.ChangeOrangeFlameColor_Click);
            // 
            // OrangeColor
            // 
            this.OrangeColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.OrangeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OrangeColor.Location = new System.Drawing.Point(271, 299);
            this.OrangeColor.Name = "OrangeColor";
            this.OrangeColor.Size = new System.Drawing.Size(24, 24);
            this.OrangeColor.TabIndex = 27;
            this.SPMToolTipMain.SetToolTip(this.OrangeColor, "The color of the note flames while Star Power is NOT active.");
            // 
            // HitFlameColors
            // 
            this.HitFlameColors.AutoSize = true;
            this.HitFlameColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.HitFlameColors.Location = new System.Drawing.Point(7, 281);
            this.HitFlameColors.Name = "HitFlameColors";
            this.HitFlameColors.Size = new System.Drawing.Size(103, 13);
            this.HitFlameColors.TabIndex = 26;
            this.HitFlameColors.Text = "Hit Flame Colors:";
            // 
            // OrangeFlameLabel
            // 
            this.OrangeFlameLabel.AutoSize = true;
            this.OrangeFlameLabel.Location = new System.Drawing.Point(22, 304);
            this.OrangeFlameLabel.Name = "OrangeFlameLabel";
            this.OrangeFlameLabel.Size = new System.Drawing.Size(123, 13);
            this.OrangeFlameLabel.TabIndex = 25;
            this.OrangeFlameLabel.Text = "SP Inactive Flame Color:";
            // 
            // ChangeGlowColor
            // 
            this.ChangeGlowColor.Location = new System.Drawing.Point(521, 328);
            this.ChangeGlowColor.Name = "ChangeGlowColor";
            this.ChangeGlowColor.Size = new System.Drawing.Size(84, 23);
            this.ChangeGlowColor.TabIndex = 38;
            this.ChangeGlowColor.Text = "Pick Color...";
            this.ChangeGlowColor.UseVisualStyleBackColor = true;
            this.ChangeGlowColor.Click += new System.EventHandler(this.ChangeGlowColor_Click);
            // 
            // GlowColor
            // 
            this.GlowColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GlowColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GlowColor.Location = new System.Drawing.Point(614, 328);
            this.GlowColor.Name = "GlowColor";
            this.GlowColor.Size = new System.Drawing.Size(24, 24);
            this.GlowColor.TabIndex = 37;
            this.SPMToolTipMain.SetToolTip(this.GlowColor, "The glow color of the edges of the fret board (highway) while Star Power is activ" +
        "e.");
            // 
            // SPBoardGlowLabel
            // 
            this.SPBoardGlowLabel.AutoSize = true;
            this.SPBoardGlowLabel.Location = new System.Drawing.Point(365, 333);
            this.SPBoardGlowLabel.Name = "SPBoardGlowLabel";
            this.SPBoardGlowLabel.Size = new System.Drawing.Size(130, 13);
            this.SPBoardGlowLabel.TabIndex = 36;
            this.SPBoardGlowLabel.Text = "SP Fret Board Glow Color:";
            // 
            // ChangeLightningColor
            // 
            this.ChangeLightningColor.Location = new System.Drawing.Point(521, 299);
            this.ChangeLightningColor.Name = "ChangeLightningColor";
            this.ChangeLightningColor.Size = new System.Drawing.Size(84, 23);
            this.ChangeLightningColor.TabIndex = 35;
            this.ChangeLightningColor.Text = "Pick Color...";
            this.ChangeLightningColor.UseVisualStyleBackColor = true;
            this.ChangeLightningColor.Click += new System.EventHandler(this.ChangeLightningColor_Click);
            // 
            // LightningColor
            // 
            this.LightningColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LightningColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LightningColor.Location = new System.Drawing.Point(614, 299);
            this.LightningColor.Name = "LightningColor";
            this.LightningColor.Size = new System.Drawing.Size(24, 24);
            this.LightningColor.TabIndex = 34;
            this.SPMToolTipMain.SetToolTip(this.LightningColor, "The color of the lightning effects seen on the edges of the fret board\r\nwhile Sta" +
        "r Power is active. Also applies to when SP is earned.");
            // 
            // StarPowerFXHeader
            // 
            this.StarPowerFXHeader.AutoSize = true;
            this.StarPowerFXHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.StarPowerFXHeader.Location = new System.Drawing.Point(350, 281);
            this.StarPowerFXHeader.Name = "StarPowerFXHeader";
            this.StarPowerFXHeader.Size = new System.Drawing.Size(150, 13);
            this.StarPowerFXHeader.TabIndex = 33;
            this.StarPowerFXHeader.Text = "Star Power Effect Colors:";
            // 
            // SPLightningLabel
            // 
            this.SPLightningLabel.AutoSize = true;
            this.SPLightningLabel.Location = new System.Drawing.Point(365, 304);
            this.SPLightningLabel.Name = "SPLightningLabel";
            this.SPLightningLabel.Size = new System.Drawing.Size(97, 13);
            this.SPLightningLabel.TabIndex = 32;
            this.SPLightningLabel.Text = "SP Lightning Color:";
            // 
            // StarPowerModifierManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(646, 406);
            this.Controls.Add(this.ChangeGlowColor);
            this.Controls.Add(this.GlowColor);
            this.Controls.Add(this.SPBoardGlowLabel);
            this.Controls.Add(this.ChangeLightningColor);
            this.Controls.Add(this.LightningColor);
            this.Controls.Add(this.StarPowerFXHeader);
            this.Controls.Add(this.SPLightningLabel);
            this.Controls.Add(this.ChangeBlueFlameColor);
            this.Controls.Add(this.BlueColor);
            this.Controls.Add(this.BlueFlameLabel);
            this.Controls.Add(this.ChangeOrangeFlameColor);
            this.Controls.Add(this.OrangeColor);
            this.Controls.Add(this.HitFlameColors);
            this.Controls.Add(this.OrangeFlameLabel);
            this.Controls.Add(this.FXArray);
            this.Controls.Add(this.FlameLightningColsHeader);
            this.Controls.Add(this.ChangeHighwayTintColor);
            this.Controls.Add(this.HighwayColor);
            this.Controls.Add(this.HWTintColorHeader);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.AvatarImageBox);
            this.Controls.Add(this.ChangeBaseKickStarColor);
            this.Controls.Add(this.BaseKickStarColor);
            this.Controls.Add(this.BaseKickColorLabel);
            this.Controls.Add(this.ChangeBaseStarColor);
            this.Controls.Add(this.BaseStarColor);
            this.Controls.Add(this.BaseColorLabel);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ChangeKickStarColor);
            this.Controls.Add(this.KickStarColor);
            this.Controls.Add(this.KickStarLabel);
            this.Controls.Add(this.ChangeStarColor);
            this.Controls.Add(this.StarColor);
            this.Controls.Add(this.SPGemColorsHeader);
            this.Controls.Add(this.SPGemColorLabel);
            this.Controls.Add(this.ArrayIDLabel);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StarPowerModifierManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Script Mod Options: Star Power Modifier";
            ((System.ComponentModel.ISupportInitialize)(this.AvatarImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.Label ArrayIDLabel;
        private System.Windows.Forms.Label SPGemColorsHeader;
        private System.Windows.Forms.Label StarColor;
        private System.Windows.Forms.Label SPGemColorLabel;
        private System.Windows.Forms.Button ChangeStarColor;
        private System.Windows.Forms.Button ChangeKickStarColor;
        private System.Windows.Forms.Label KickStarColor;
        private System.Windows.Forms.Label KickStarLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button ChangeBaseKickStarColor;
        private System.Windows.Forms.Label BaseKickStarColor;
        private System.Windows.Forms.Label BaseKickColorLabel;
        private System.Windows.Forms.Button ChangeBaseStarColor;
        private System.Windows.Forms.Label BaseStarColor;
        private System.Windows.Forms.Label BaseColorLabel;
        private System.Windows.Forms.PictureBox AvatarImageBox;
        private System.Windows.Forms.Button ChangeHighwayTintColor;
        private System.Windows.Forms.Label HighwayColor;
        private System.Windows.Forms.Label HWTintColorHeader;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label FlameLightningColsHeader;
        private System.Windows.Forms.ComboBox FXArray;
        private System.Windows.Forms.Button ChangeBlueFlameColor;
        private System.Windows.Forms.Label BlueColor;
        private System.Windows.Forms.Label BlueFlameLabel;
        private System.Windows.Forms.Button ChangeOrangeFlameColor;
        private System.Windows.Forms.Label OrangeColor;
        private System.Windows.Forms.Label HitFlameColors;
        private System.Windows.Forms.Label OrangeFlameLabel;
        private System.Windows.Forms.Button ChangeGlowColor;
        private System.Windows.Forms.Label GlowColor;
        private System.Windows.Forms.Label SPBoardGlowLabel;
        private System.Windows.Forms.Button ChangeLightningColor;
        private System.Windows.Forms.Label LightningColor;
        private System.Windows.Forms.Label StarPowerFXHeader;
        private System.Windows.Forms.Label SPLightningLabel;
        private System.Windows.Forms.ToolTip SPMToolTipMain;
    }
}