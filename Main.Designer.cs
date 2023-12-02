namespace WTDE_Launcher_V3
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.LeftDarkOverlay = new System.Windows.Forms.PictureBox();
            this.VersionInfoLabel = new System.Windows.Forms.Label();
            this.TabButtonGroup = new System.Windows.Forms.Panel();
            this.MainEditorPane = new System.Windows.Forms.Panel();
            this.MOTDPanel = new System.Windows.Forms.Panel();
            this.MOTDLabel = new System.Windows.Forms.Label();
            this.LogoWTDE = new System.Windows.Forms.PictureBox();
            this.RunWTDE = new System.Windows.Forms.Button();
            this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.AdjustSettings = new System.Windows.Forms.Button();
            this.OpenMods = new System.Windows.Forms.Button();
            this.LogoFretworks = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LeftDarkOverlay)).BeginInit();
            this.MainEditorPane.SuspendLayout();
            this.MOTDPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoWTDE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoFretworks)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftDarkOverlay
            // 
            this.LeftDarkOverlay.BackColor = System.Drawing.Color.Transparent;
            this.LeftDarkOverlay.Image = global::WTDE_Launcher_V3.Properties.Resources.dark_overlay_d_l;
            this.LeftDarkOverlay.Location = new System.Drawing.Point(-5, -6);
            this.LeftDarkOverlay.Margin = new System.Windows.Forms.Padding(4);
            this.LeftDarkOverlay.Name = "LeftDarkOverlay";
            this.LeftDarkOverlay.Size = new System.Drawing.Size(398, 926);
            this.LeftDarkOverlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LeftDarkOverlay.TabIndex = 0;
            this.LeftDarkOverlay.TabStop = false;
            // 
            // VersionInfoLabel
            // 
            this.VersionInfoLabel.AutoSize = true;
            this.VersionInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.VersionInfoLabel.Font = new System.Drawing.Font("Lexend", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VersionInfoLabel.ForeColor = System.Drawing.Color.White;
            this.VersionInfoLabel.Image = global::WTDE_Launcher_V3.Properties.Resources.dark_overlay_d_l;
            this.VersionInfoLabel.Location = new System.Drawing.Point(12, 838);
            this.VersionInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VersionInfoLabel.Name = "VersionInfoLabel";
            this.VersionInfoLabel.Size = new System.Drawing.Size(359, 64);
            this.VersionInfoLabel.TabIndex = 4;
            this.VersionInfoLabel.Text = "GHWT: DE Launcher V3.0 by IMF24\r\nBG Image: Fox (FoxJudy)\r\n";
            this.VersionInfoLabel.Click += new System.EventHandler(this.VersionInfoLabel_Click);
            // 
            // TabButtonGroup
            // 
            this.TabButtonGroup.BackColor = System.Drawing.Color.Transparent;
            this.TabButtonGroup.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.dark_overlay_l;
            this.TabButtonGroup.Location = new System.Drawing.Point(0, 4);
            this.TabButtonGroup.Margin = new System.Windows.Forms.Padding(4);
            this.TabButtonGroup.Name = "TabButtonGroup";
            this.TabButtonGroup.Size = new System.Drawing.Size(878, 82);
            this.TabButtonGroup.TabIndex = 5;
            // 
            // MainEditorPane
            // 
            this.MainEditorPane.BackColor = System.Drawing.Color.Transparent;
            this.MainEditorPane.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.light_overlay;
            this.MainEditorPane.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainEditorPane.Controls.Add(this.TabButtonGroup);
            this.MainEditorPane.Location = new System.Drawing.Point(391, -4);
            this.MainEditorPane.Margin = new System.Windows.Forms.Padding(4);
            this.MainEditorPane.Name = "MainEditorPane";
            this.MainEditorPane.Size = new System.Drawing.Size(876, 921);
            this.MainEditorPane.TabIndex = 6;
            // 
            // MOTDPanel
            // 
            this.MOTDPanel.BackColor = System.Drawing.Color.Transparent;
            this.MOTDPanel.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.dark_overlay_m;
            this.MOTDPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MOTDPanel.Controls.Add(this.MOTDLabel);
            this.MOTDPanel.Location = new System.Drawing.Point(318, 665);
            this.MOTDPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MOTDPanel.Name = "MOTDPanel";
            this.MOTDPanel.Size = new System.Drawing.Size(876, 921);
            this.MOTDPanel.TabIndex = 7;
            // 
            // MOTDLabel
            // 
            this.MOTDLabel.AutoSize = true;
            this.MOTDLabel.Font = new System.Drawing.Font("Lexend", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MOTDLabel.ForeColor = System.Drawing.Color.White;
            this.MOTDLabel.Location = new System.Drawing.Point(18, 14);
            this.MOTDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MOTDLabel.Name = "MOTDLabel";
            this.MOTDLabel.Size = new System.Drawing.Size(660, 72);
            this.MOTDLabel.TabIndex = 0;
            this.MOTDLabel.Text = "MOTD not found, call IMF!\r\n\r\nIf you\'re seeing this, it means we probably couldn\'t" +
    " establish a connection to the internet.";
            this.MOTDLabel.Click += new System.EventHandler(this.MOTDLabel_Click);
            // 
            // LogoWTDE
            // 
            this.LogoWTDE.BackColor = System.Drawing.Color.Transparent;
            this.LogoWTDE.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.dark_overlay_d;
            this.LogoWTDE.Image = global::WTDE_Launcher_V3.Properties.Resources.wtde_logo_normal;
            this.LogoWTDE.Location = new System.Drawing.Point(74, 0);
            this.LogoWTDE.Margin = new System.Windows.Forms.Padding(4);
            this.LogoWTDE.Name = "LogoWTDE";
            this.LogoWTDE.Size = new System.Drawing.Size(250, 250);
            this.LogoWTDE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoWTDE.TabIndex = 7;
            this.LogoWTDE.TabStop = false;
            // 
            // RunWTDE
            // 
            this.RunWTDE.BackColor = System.Drawing.Color.Transparent;
            this.RunWTDE.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.dark_overlay_d;
            this.RunWTDE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RunWTDE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RunWTDE.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.RunWTDE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RunWTDE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RunWTDE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RunWTDE.Font = new System.Drawing.Font("Lexend", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RunWTDE.ForeColor = System.Drawing.Color.White;
            this.RunWTDE.Location = new System.Drawing.Point(15, 258);
            this.RunWTDE.Margin = new System.Windows.Forms.Padding(4);
            this.RunWTDE.Name = "RunWTDE";
            this.RunWTDE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RunWTDE.Size = new System.Drawing.Size(355, 68);
            this.RunWTDE.TabIndex = 6;
            this.RunWTDE.Text = "Start WTDE";
            this.ToolTipMain.SetToolTip(this.RunWTDE, "Save your configuration settings and launch WTDE.");
            this.RunWTDE.UseVisualStyleBackColor = false;
            // 
            // AdjustSettings
            // 
            this.AdjustSettings.BackColor = System.Drawing.Color.Transparent;
            this.AdjustSettings.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.dark_overlay_d;
            this.AdjustSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AdjustSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdjustSettings.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.AdjustSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AdjustSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AdjustSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdjustSettings.Font = new System.Drawing.Font("Lexend", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AdjustSettings.ForeColor = System.Drawing.Color.White;
            this.AdjustSettings.Location = new System.Drawing.Point(15, 347);
            this.AdjustSettings.Margin = new System.Windows.Forms.Padding(4);
            this.AdjustSettings.Name = "AdjustSettings";
            this.AdjustSettings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AdjustSettings.Size = new System.Drawing.Size(355, 68);
            this.AdjustSettings.TabIndex = 9;
            this.AdjustSettings.Text = "Adjust Settings";
            this.ToolTipMain.SetToolTip(this.AdjustSettings, "Adjust your configuration settings for the mod.");
            this.AdjustSettings.UseVisualStyleBackColor = false;
            this.AdjustSettings.Click += new System.EventHandler(this.AdjustSettings_Click);
            // 
            // OpenMods
            // 
            this.OpenMods.BackColor = System.Drawing.Color.Transparent;
            this.OpenMods.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.dark_overlay_d;
            this.OpenMods.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenMods.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenMods.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.OpenMods.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.OpenMods.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.OpenMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenMods.Font = new System.Drawing.Font("Lexend", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OpenMods.ForeColor = System.Drawing.Color.White;
            this.OpenMods.Location = new System.Drawing.Point(15, 436);
            this.OpenMods.Margin = new System.Windows.Forms.Padding(4);
            this.OpenMods.Name = "OpenMods";
            this.OpenMods.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OpenMods.Size = new System.Drawing.Size(355, 68);
            this.OpenMods.TabIndex = 10;
            this.OpenMods.Text = "Open Mods Folder";
            this.ToolTipMain.SetToolTip(this.OpenMods, "Open your mods folder.");
            this.OpenMods.UseVisualStyleBackColor = false;
            this.OpenMods.Click += new System.EventHandler(this.OpenMods_Click);
            // 
            // LogoFretworks
            // 
            this.LogoFretworks.BackColor = System.Drawing.Color.Transparent;
            this.LogoFretworks.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.dark_overlay_d;
            this.LogoFretworks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoFretworks.Image = global::WTDE_Launcher_V3.Properties.Resources.logo_fretworks;
            this.LogoFretworks.Location = new System.Drawing.Point(9, 715);
            this.LogoFretworks.Margin = new System.Windows.Forms.Padding(4);
            this.LogoFretworks.Name = "LogoFretworks";
            this.LogoFretworks.Size = new System.Drawing.Size(375, 119);
            this.LogoFretworks.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoFretworks.TabIndex = 8;
            this.LogoFretworks.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.bg_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1260, 911);
            this.Controls.Add(this.OpenMods);
            this.Controls.Add(this.MOTDPanel);
            this.Controls.Add(this.AdjustSettings);
            this.Controls.Add(this.VersionInfoLabel);
            this.Controls.Add(this.LogoFretworks);
            this.Controls.Add(this.RunWTDE);
            this.Controls.Add(this.LogoWTDE);
            this.Controls.Add(this.MainEditorPane);
            this.Controls.Add(this.LeftDarkOverlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "GHWT: Definitive Edition Launcher V3.0";
            ((System.ComponentModel.ISupportInitialize)(this.LeftDarkOverlay)).EndInit();
            this.MainEditorPane.ResumeLayout(false);
            this.MOTDPanel.ResumeLayout(false);
            this.MOTDPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoWTDE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoFretworks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox LeftDarkOverlay;
        private Label VersionInfoLabel;
        private Panel TabButtonGroup;
        private Panel MainEditorPane;
        private PictureBox LogoWTDE;
        private Button RunWTDE;
        private ToolTip ToolTipMain;
        private PictureBox LogoFretworks;
        private Panel MOTDPanel;
        private Label MOTDLabel;
        private Button AdjustSettings;
        private Button OpenMods;
    }
}