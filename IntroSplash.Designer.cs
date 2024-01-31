namespace WTDE_Launcher_V3 {
    partial class IntroSplash {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroSplash));
            this.LogoImageIcon = new System.Windows.Forms.PictureBox();
            this.LogoImageMain = new System.Windows.Forms.PictureBox();
            this.LogoBrandIMF = new System.Windows.Forms.PictureBox();
            this.LogoBrandFretworks = new System.Windows.Forms.PictureBox();
            this.VersionInfoLabel = new System.Windows.Forms.Label();
            this.CreditsInfoLabel = new System.Windows.Forms.Label();
            this.SelfKillWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.LogoImageIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoImageMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBrandIMF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBrandFretworks)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoImageIcon
            // 
            this.LogoImageIcon.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.icon;
            this.LogoImageIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoImageIcon.Location = new System.Drawing.Point(22, 8);
            this.LogoImageIcon.Name = "LogoImageIcon";
            this.LogoImageIcon.Size = new System.Drawing.Size(192, 192);
            this.LogoImageIcon.TabIndex = 0;
            this.LogoImageIcon.TabStop = false;
            // 
            // LogoImageMain
            // 
            this.LogoImageMain.BackColor = System.Drawing.Color.Transparent;
            this.LogoImageMain.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.wtde_launcher_splash;
            this.LogoImageMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoImageMain.Location = new System.Drawing.Point(229, 49);
            this.LogoImageMain.Name = "LogoImageMain";
            this.LogoImageMain.Size = new System.Drawing.Size(441, 117);
            this.LogoImageMain.TabIndex = 1;
            this.LogoImageMain.TabStop = false;
            // 
            // LogoBrandIMF
            // 
            this.LogoBrandIMF.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.logo_imf24;
            this.LogoBrandIMF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoBrandIMF.Location = new System.Drawing.Point(22, 206);
            this.LogoBrandIMF.Name = "LogoBrandIMF";
            this.LogoBrandIMF.Size = new System.Drawing.Size(85, 85);
            this.LogoBrandIMF.TabIndex = 2;
            this.LogoBrandIMF.TabStop = false;
            // 
            // LogoBrandFretworks
            // 
            this.LogoBrandFretworks.BackColor = System.Drawing.Color.Transparent;
            this.LogoBrandFretworks.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.fretworks;
            this.LogoBrandFretworks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoBrandFretworks.Location = new System.Drawing.Point(129, 206);
            this.LogoBrandFretworks.Name = "LogoBrandFretworks";
            this.LogoBrandFretworks.Size = new System.Drawing.Size(85, 85);
            this.LogoBrandFretworks.TabIndex = 3;
            this.LogoBrandFretworks.TabStop = false;
            // 
            // VersionInfoLabel
            // 
            this.VersionInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.VersionInfoLabel.Font = new System.Drawing.Font("Lexend", 18F);
            this.VersionInfoLabel.ForeColor = System.Drawing.Color.White;
            this.VersionInfoLabel.Location = new System.Drawing.Point(229, 210);
            this.VersionInfoLabel.Name = "VersionInfoLabel";
            this.VersionInfoLabel.Size = new System.Drawing.Size(453, 37);
            this.VersionInfoLabel.TabIndex = 4;
            this.VersionInfoLabel.Text = "Version 3.0";
            this.VersionInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CreditsInfoLabel
            // 
            this.CreditsInfoLabel.AutoSize = true;
            this.CreditsInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.CreditsInfoLabel.Font = new System.Drawing.Font("Lexend", 10F);
            this.CreditsInfoLabel.ForeColor = System.Drawing.Color.White;
            this.CreditsInfoLabel.Location = new System.Drawing.Point(391, 247);
            this.CreditsInfoLabel.Name = "CreditsInfoLabel";
            this.CreditsInfoLabel.Size = new System.Drawing.Size(288, 44);
            this.CreditsInfoLabel.TabIndex = 5;
            this.CreditsInfoLabel.Text = "Made by IMF24, GHWT: DE by Fretworks\r\nThanks for supporting us!";
            this.CreditsInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SelfKillWorker
            // 
            this.SelfKillWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SelfKillWorker_DoWork);
            // 
            // IntroSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.bg_intro_splash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(687, 302);
            this.Controls.Add(this.CreditsInfoLabel);
            this.Controls.Add(this.VersionInfoLabel);
            this.Controls.Add(this.LogoBrandFretworks);
            this.Controls.Add(this.LogoBrandIMF);
            this.Controls.Add(this.LogoImageMain);
            this.Controls.Add(this.LogoImageIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IntroSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IntroSplash";
            this.Shown += new System.EventHandler(this.IntroSplash_MouseEnter);
            this.MouseEnter += new System.EventHandler(this.IntroSplash_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.LogoImageIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoImageMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBrandIMF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBrandFretworks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoImageIcon;
        private System.Windows.Forms.PictureBox LogoImageMain;
        private System.Windows.Forms.PictureBox LogoBrandIMF;
        private System.Windows.Forms.PictureBox LogoBrandFretworks;
        private System.Windows.Forms.Label VersionInfoLabel;
        private System.Windows.Forms.Label CreditsInfoLabel;
        private System.ComponentModel.BackgroundWorker SelfKillWorker;
    }
}