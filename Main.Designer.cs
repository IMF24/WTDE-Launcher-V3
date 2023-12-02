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
            MainEditorPane = new Panel();
            LogoContainer = new PictureBox();
            TabButtonGeneral = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)LeftDarkOverlay).BeginInit();
            TabButtonGroup.SuspendLayout();
            MainEditorPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoContainer).BeginInit();
            TabButtonGeneral.SuspendLayout();
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
            VersionInfoLabel.ForeColor = Color.White;
            VersionInfoLabel.Image = Properties.Resources.dark_overlay_l;
            VersionInfoLabel.Location = new Point(12, 705);
            VersionInfoLabel.Name = "VersionInfoLabel";
            VersionInfoLabel.Size = new Size(265, 15);
            VersionInfoLabel.TabIndex = 4;
            VersionInfoLabel.Text = "GHWT: Definitive Edition Launcher V3.0 by IMF24\r\n";
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
            // TabButtonGeneral
            // 
            TabButtonGeneral.BackgroundImage = Properties.Resources.button_plain;
            TabButtonGeneral.BackgroundImageLayout = ImageLayout.Stretch;
            TabButtonGeneral.Controls.Add(label1);
            TabButtonGeneral.Location = new Point(7, 5);
            TabButtonGeneral.Name = "TabButtonGeneral";
            TabButtonGeneral.Size = new Size(103, 53);
            TabButtonGeneral.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lexend", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 13);
            label1.Name = "label1";
            label1.Size = new Size(72, 25);
            label1.TabIndex = 0;
            label1.Text = "General";
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            MainEditorPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LogoContainer).EndInit();
            TabButtonGeneral.ResumeLayout(false);
            TabButtonGeneral.PerformLayout();
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
        private Label label1;
    }
}