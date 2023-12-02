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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            LeftDarkOverlay = new PictureBox();
            VersionInfoLabel = new Label();
            TabButtonGroup = new Panel();
            MainEditorPane = new Panel();
            LogoWTDE = new PictureBox();
            RunWTDE = new Button();
            ToolTipMain = new ToolTip(components);
            LogoFretworks = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)LeftDarkOverlay).BeginInit();
            MainEditorPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoWTDE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LogoFretworks).BeginInit();
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
            VersionInfoLabel.Location = new Point(12, 670);
            VersionInfoLabel.Name = "VersionInfoLabel";
            VersionInfoLabel.Size = new Size(284, 50);
            VersionInfoLabel.TabIndex = 4;
            VersionInfoLabel.Text = "GHWT: DE Launcher V3.0 by IMF24\r\nBG Image: Fox (FoxJudy)\r\n";
            // 
            // TabButtonGroup
            // 
            TabButtonGroup.BackColor = Color.Transparent;
            TabButtonGroup.BackgroundImage = Properties.Resources.dark_overlay_l;
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
            // LogoWTDE
            // 
            LogoWTDE.BackColor = Color.Transparent;
            LogoWTDE.BackgroundImage = Properties.Resources.dark_overlay;
            LogoWTDE.Image = Properties.Resources.wtde_logo_normal;
            LogoWTDE.Location = new Point(59, 0);
            LogoWTDE.Name = "LogoWTDE";
            LogoWTDE.Size = new Size(200, 200);
            LogoWTDE.SizeMode = PictureBoxSizeMode.StretchImage;
            LogoWTDE.TabIndex = 7;
            LogoWTDE.TabStop = false;
            // 
            // RunWTDE
            // 
            RunWTDE.BackColor = Color.Transparent;
            RunWTDE.BackgroundImage = Properties.Resources.dark_overlay;
            RunWTDE.BackgroundImageLayout = ImageLayout.Stretch;
            RunWTDE.Cursor = Cursors.Hand;
            RunWTDE.FlatAppearance.BorderColor = Color.White;
            RunWTDE.FlatAppearance.MouseDownBackColor = Color.Transparent;
            RunWTDE.FlatAppearance.MouseOverBackColor = Color.Transparent;
            RunWTDE.FlatStyle = FlatStyle.Flat;
            RunWTDE.Font = new Font("Lexend", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            RunWTDE.ForeColor = Color.White;
            RunWTDE.Location = new Point(12, 206);
            RunWTDE.Name = "RunWTDE";
            RunWTDE.RightToLeft = RightToLeft.No;
            RunWTDE.Size = new Size(284, 54);
            RunWTDE.TabIndex = 6;
            RunWTDE.Text = "Start WTDE";
            ToolTipMain.SetToolTip(RunWTDE, "Save your configuration settings and launch WTDE.");
            RunWTDE.UseVisualStyleBackColor = false;
            RunWTDE.Click += RunWTDE_Click;
            // 
            // LogoFretworks
            // 
            LogoFretworks.BackColor = Color.Transparent;
            LogoFretworks.BackgroundImage = Properties.Resources.dark_overlay;
            LogoFretworks.BackgroundImageLayout = ImageLayout.Stretch;
            LogoFretworks.Image = Properties.Resources.logo_fretworks;
            LogoFretworks.Location = new Point(7, 572);
            LogoFretworks.Name = "LogoFretworks";
            LogoFretworks.Size = new Size(300, 95);
            LogoFretworks.SizeMode = PictureBoxSizeMode.StretchImage;
            LogoFretworks.TabIndex = 8;
            LogoFretworks.TabStop = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg_1_s;
            ClientSize = new Size(1008, 729);
            Controls.Add(VersionInfoLabel);
            Controls.Add(LogoFretworks);
            Controls.Add(RunWTDE);
            Controls.Add(LogoWTDE);
            Controls.Add(MainEditorPane);
            Controls.Add(LeftDarkOverlay);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main";
            Text = "GHWT: Definitive Edition Launcher V3.0";
            ((System.ComponentModel.ISupportInitialize)LeftDarkOverlay).EndInit();
            MainEditorPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LogoWTDE).EndInit();
            ((System.ComponentModel.ISupportInitialize)LogoFretworks).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}