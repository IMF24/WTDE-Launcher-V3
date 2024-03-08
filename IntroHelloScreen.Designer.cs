namespace WTDE_Launcher_V3 {
    partial class IntroHelloScreen {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroHelloScreen));
            this.InfoPanelMain = new System.Windows.Forms.Panel();
            this.WTDELogoImage = new System.Windows.Forms.PictureBox();
            this.MainInfoLabel = new System.Windows.Forms.Label();
            this.IconLogoFretworks = new System.Windows.Forms.PictureBox();
            this.IconLogoIMF = new System.Windows.Forms.PictureBox();
            this.RunWTDEButton = new System.Windows.Forms.Button();
            this.ProceedToLauncherButton = new System.Windows.Forms.Button();
            this.VersionInfoLabel = new System.Windows.Forms.Label();
            this.AboutLauncherLabel = new System.Windows.Forms.Label();
            this.NeverShowAgain = new System.Windows.Forms.CheckBox();
            this.InfoPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WTDELogoImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconLogoFretworks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconLogoIMF)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoPanelMain
            // 
            this.InfoPanelMain.BackColor = System.Drawing.Color.Transparent;
            this.InfoPanelMain.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.dark_overlay_d_l;
            this.InfoPanelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InfoPanelMain.Controls.Add(this.NeverShowAgain);
            this.InfoPanelMain.Controls.Add(this.AboutLauncherLabel);
            this.InfoPanelMain.Controls.Add(this.VersionInfoLabel);
            this.InfoPanelMain.Controls.Add(this.ProceedToLauncherButton);
            this.InfoPanelMain.Controls.Add(this.RunWTDEButton);
            this.InfoPanelMain.Controls.Add(this.IconLogoIMF);
            this.InfoPanelMain.Controls.Add(this.IconLogoFretworks);
            this.InfoPanelMain.Controls.Add(this.MainInfoLabel);
            this.InfoPanelMain.Controls.Add(this.WTDELogoImage);
            this.InfoPanelMain.Location = new System.Drawing.Point(-11, -4);
            this.InfoPanelMain.Name = "InfoPanelMain";
            this.InfoPanelMain.Size = new System.Drawing.Size(740, 645);
            this.InfoPanelMain.TabIndex = 0;
            // 
            // WTDELogoImage
            // 
            this.WTDELogoImage.Image = global::WTDE_Launcher_V3.Properties.Resources.logo_wtde;
            this.WTDELogoImage.Location = new System.Drawing.Point(267, 7);
            this.WTDELogoImage.Name = "WTDELogoImage";
            this.WTDELogoImage.Size = new System.Drawing.Size(192, 192);
            this.WTDELogoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WTDELogoImage.TabIndex = 0;
            this.WTDELogoImage.TabStop = false;
            // 
            // MainInfoLabel
            // 
            this.MainInfoLabel.AutoSize = true;
            this.MainInfoLabel.Font = new System.Drawing.Font("Lexend", 10F);
            this.MainInfoLabel.ForeColor = System.Drawing.Color.White;
            this.MainInfoLabel.Location = new System.Drawing.Point(84, 207);
            this.MainInfoLabel.Name = "MainInfoLabel";
            this.MainInfoLabel.Size = new System.Drawing.Size(565, 242);
            this.MainInfoLabel.TabIndex = 1;
            this.MainInfoLabel.Text = resources.GetString("MainInfoLabel.Text");
            this.MainInfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // IconLogoFretworks
            // 
            this.IconLogoFretworks.BackColor = System.Drawing.Color.Transparent;
            this.IconLogoFretworks.Image = global::WTDE_Launcher_V3.Properties.Resources.fretworks;
            this.IconLogoFretworks.Location = new System.Drawing.Point(23, 520);
            this.IconLogoFretworks.Name = "IconLogoFretworks";
            this.IconLogoFretworks.Size = new System.Drawing.Size(80, 80);
            this.IconLogoFretworks.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconLogoFretworks.TabIndex = 2;
            this.IconLogoFretworks.TabStop = false;
            // 
            // IconLogoIMF
            // 
            this.IconLogoIMF.BackColor = System.Drawing.Color.Transparent;
            this.IconLogoIMF.Image = global::WTDE_Launcher_V3.Properties.Resources.logo_imf24;
            this.IconLogoIMF.Location = new System.Drawing.Point(639, 520);
            this.IconLogoIMF.Name = "IconLogoIMF";
            this.IconLogoIMF.Size = new System.Drawing.Size(80, 80);
            this.IconLogoIMF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconLogoIMF.TabIndex = 3;
            this.IconLogoIMF.TabStop = false;
            // 
            // RunWTDEButton
            // 
            this.RunWTDEButton.BackColor = System.Drawing.Color.Transparent;
            this.RunWTDEButton.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.dark_overlay_m_l;
            this.RunWTDEButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RunWTDEButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RunWTDEButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.RunWTDEButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RunWTDEButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RunWTDEButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RunWTDEButton.Font = new System.Drawing.Font("Lexend", 14F);
            this.RunWTDEButton.ForeColor = System.Drawing.Color.White;
            this.RunWTDEButton.Image = global::WTDE_Launcher_V3.Properties.Resources.dark_overlay_m_l;
            this.RunWTDEButton.Location = new System.Drawing.Point(182, 520);
            this.RunWTDEButton.Name = "RunWTDEButton";
            this.RunWTDEButton.Size = new System.Drawing.Size(378, 54);
            this.RunWTDEButton.TabIndex = 5;
            this.RunWTDEButton.Text = "I\'m fine, start the game!";
            this.RunWTDEButton.UseVisualStyleBackColor = false;
            this.RunWTDEButton.Click += new System.EventHandler(this.RunWTDEButton_Click);
            // 
            // ProceedToLauncherButton
            // 
            this.ProceedToLauncherButton.BackColor = System.Drawing.Color.Transparent;
            this.ProceedToLauncherButton.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.dark_overlay_m_l;
            this.ProceedToLauncherButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProceedToLauncherButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProceedToLauncherButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ProceedToLauncherButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ProceedToLauncherButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ProceedToLauncherButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProceedToLauncherButton.Font = new System.Drawing.Font("Lexend", 14F);
            this.ProceedToLauncherButton.ForeColor = System.Drawing.Color.White;
            this.ProceedToLauncherButton.Image = global::WTDE_Launcher_V3.Properties.Resources.dark_overlay_m_l;
            this.ProceedToLauncherButton.Location = new System.Drawing.Point(182, 459);
            this.ProceedToLauncherButton.Name = "ProceedToLauncherButton";
            this.ProceedToLauncherButton.Size = new System.Drawing.Size(378, 54);
            this.ProceedToLauncherButton.TabIndex = 6;
            this.ProceedToLauncherButton.Text = "Yes, let me change some stuff!";
            this.ProceedToLauncherButton.UseVisualStyleBackColor = false;
            this.ProceedToLauncherButton.Click += new System.EventHandler(this.ProceedToLauncherButton_Click);
            // 
            // VersionInfoLabel
            // 
            this.VersionInfoLabel.Font = new System.Drawing.Font("Lexend", 10F);
            this.VersionInfoLabel.ForeColor = System.Drawing.Color.White;
            this.VersionInfoLabel.Location = new System.Drawing.Point(23, 613);
            this.VersionInfoLabel.Name = "VersionInfoLabel";
            this.VersionInfoLabel.Size = new System.Drawing.Size(345, 22);
            this.VersionInfoLabel.TabIndex = 7;
            this.VersionInfoLabel.Text = "GHWT: Definitive Edition Launcher VABC";
            this.VersionInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AboutLauncherLabel
            // 
            this.AboutLauncherLabel.Font = new System.Drawing.Font("Lexend", 10F);
            this.AboutLauncherLabel.ForeColor = System.Drawing.Color.White;
            this.AboutLauncherLabel.Location = new System.Drawing.Point(374, 613);
            this.AboutLauncherLabel.Name = "AboutLauncherLabel";
            this.AboutLauncherLabel.Size = new System.Drawing.Size(345, 22);
            this.AboutLauncherLabel.TabIndex = 8;
            this.AboutLauncherLabel.Text = "Made by IMF24, Fretworks";
            this.AboutLauncherLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NeverShowAgain
            // 
            this.NeverShowAgain.AutoSize = true;
            this.NeverShowAgain.Font = new System.Drawing.Font("Lexend", 10F);
            this.NeverShowAgain.ForeColor = System.Drawing.Color.White;
            this.NeverShowAgain.Location = new System.Drawing.Point(240, 580);
            this.NeverShowAgain.Name = "NeverShowAgain";
            this.NeverShowAgain.Size = new System.Drawing.Size(263, 26);
            this.NeverShowAgain.TabIndex = 9;
            this.NeverShowAgain.Text = "Do not show this screen at startup.";
            this.NeverShowAgain.UseVisualStyleBackColor = true;
            // 
            // IntroHelloScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.bg_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(720, 640);
            this.Controls.Add(this.InfoPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IntroHelloScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IntroHelloScreen";
            this.InfoPanelMain.ResumeLayout(false);
            this.InfoPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WTDELogoImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconLogoFretworks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconLogoIMF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel InfoPanelMain;
        private System.Windows.Forms.Label MainInfoLabel;
        private System.Windows.Forms.PictureBox WTDELogoImage;
        private System.Windows.Forms.PictureBox IconLogoIMF;
        private System.Windows.Forms.PictureBox IconLogoFretworks;
        private System.Windows.Forms.Button ProceedToLauncherButton;
        private System.Windows.Forms.Button RunWTDEButton;
        private System.Windows.Forms.Label AboutLauncherLabel;
        private System.Windows.Forms.Label VersionInfoLabel;
        private System.Windows.Forms.CheckBox NeverShowAgain;
    }
}