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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            LeftDarkOverlay = new PictureBox();
            VersionInfoLabel = new Label();
            TabButtonGroup = new Panel();
            TabButtonGeneral = new Panel();
            TabGeneralTitle = new Label();
            MainEditorPane = new Panel();
            LogoContainer = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)LeftDarkOverlay).BeginInit();
            TabButtonGroup.SuspendLayout();
            TabButtonGeneral.SuspendLayout();
            MainEditorPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoContainer).BeginInit();
            SuspendLayout();
            // 
            // LeftDarkOverlay
            // 
            LeftDarkOverlay.BackColor = Color.Transparent;
            LeftDarkOverlay.Image = Properties.Resources.dark_overlay_l;
            LeftDarkOverlay.Location = new Point(-4, -5);
            LeftDarkOverlay.Name = "LeftDarkOverlay";
            LeftDarkOverlay.Size = new Size(318, 741);
            LeftDarkOverlay.SizeMode = PictureBoxSizeMode.StretchImage;
            LeftDarkOverlay.TabIndex = 0;
            LeftDarkOverlay.TabStop = false;
            // 
            // VersionInfoLabel
            // 
            VersionInfoLabel.AutoSize = true;
            VersionInfoLabel.BackColor = Color.Transparent;
            VersionInfoLabel.Font = new Font("Lexend", 12F, FontStyle.Regular, GraphicsUnit.Point);
            VersionInfoLabel.ForeColor = Color.White;
            VersionInfoLabel.Image = Properties.Resources.dark_overlay_l;
            VersionInfoLabel.Location = new Point(12, 671);
            VersionInfoLabel.Name = "VersionInfoLabel";
            VersionInfoLabel.Size = new Size(284, 50);
            VersionInfoLabel.TabIndex = 4;
            VersionInfoLabel.Text = "GHWT: DE Launcher V3.0 by IMF24\r\nBG Image: Fox (FoxJudy)\r\n";
            // 
            // TabButtonGroup
            // 
            TabButtonGroup.BackColor = Color.Transparent;
            TabButtonGroup.BackgroundImage = Properties.Resources.dark_overlay_l;
            TabButtonGroup.Controls.Add(TabButtonGeneral);
            TabButtonGroup.Location = new Point(0, 3);
            TabButtonGroup.Name = "TabButtonGroup";
            TabButtonGroup.Size = new Size(702, 66);
            TabButtonGroup.TabIndex = 5;
            // 
            // TabButtonGeneral
            // 
            TabButtonGeneral.BackgroundImage = Properties.Resources.button_plain;
            TabButtonGeneral.BackgroundImageLayout = ImageLayout.Stretch;
            TabButtonGeneral.Controls.Add(TabGeneralTitle);
            TabButtonGeneral.Cursor = Cursors.Hand;
            TabButtonGeneral.Location = new Point(7, 5);
            TabButtonGeneral.Name = "TabButtonGeneral";
            TabButtonGeneral.Size = new Size(110, 53);
            TabButtonGeneral.TabIndex = 6;
            // 
            // TabGeneralTitle
            // 
            TabGeneralTitle.AutoSize = true;
            TabGeneralTitle.Font = new Font("Lexend", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TabGeneralTitle.ForeColor = Color.White;
            TabGeneralTitle.Location = new Point(20, 13);
            TabGeneralTitle.Name = "TabGeneralTitle";
            TabGeneralTitle.Size = new Size(72, 25);
            TabGeneralTitle.TabIndex = 0;
            TabGeneralTitle.Text = "General";
            TabGeneralTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainEditorPane
            // 
            MainEditorPane.BackColor = Color.Transparent;
            MainEditorPane.BackgroundImage = Properties.Resources.light_overlay;
            MainEditorPane.BackgroundImageLayout = ImageLayout.Stretch;
            MainEditorPane.Controls.Add(TabButtonGroup);
            MainEditorPane.Location = new Point(313, -3);
            MainEditorPane.Name = "MainEditorPane";
            MainEditorPane.Size = new Size(701, 737);
            MainEditorPane.TabIndex = 6;
            // 
            // LogoContainer
            // 
            LogoContainer.BackColor = Color.Transparent;
            LogoContainer.BackgroundImage = Properties.Resources.dark_overlay;
            LogoContainer.Image = Properties.Resources.wtde_logo_normal;
            LogoContainer.Location = new Point(55, 0);
            LogoContainer.Name = "LogoContainer";
            LogoContainer.Size = new Size(200, 200);
            LogoContainer.SizeMode = PictureBoxSizeMode.StretchImage;
            LogoContainer.TabIndex = 7;
            LogoContainer.TabStop = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg_1_s;
            ClientSize = new Size(1008, 729);
            Controls.Add(LogoContainer);
            Controls.Add(MainEditorPane);
            Controls.Add(VersionInfoLabel);
            Controls.Add(LeftDarkOverlay);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main";
            Text = "GHWT: Definitive Edition Launcher V3.0";
            ((System.ComponentModel.ISupportInitialize)LeftDarkOverlay).EndInit();
            TabButtonGroup.ResumeLayout(false);
            TabButtonGeneral.ResumeLayout(false);
            TabButtonGeneral.PerformLayout();
            MainEditorPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LogoContainer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox LeftDarkOverlay;
        private Label VersionInfoLabel;
        private Panel TabButtonGroup;
        private Panel MainEditorPane;
        private PictureBox LogoContainer;
        private Panel TabButtonGeneral;
        private Label TabGeneralTitle;
    }
}