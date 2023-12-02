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
            pictureBox2 = new PictureBox();
            TabBarDarkOverlay = new PictureBox();
            MainEditorLightBG = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)LeftDarkOverlay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TabBarDarkOverlay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainEditorLightBG).BeginInit();
            SuspendLayout();
            // 
            // LeftDarkOverlay
            // 
            LeftDarkOverlay.BackColor = Color.Transparent;
            LeftDarkOverlay.Image = Properties.Resources.dark_overlay;
            LeftDarkOverlay.Location = new Point(-4, -5);
            LeftDarkOverlay.Name = "LeftDarkOverlay";
            LeftDarkOverlay.Size = new Size(318, 741);
            LeftDarkOverlay.SizeMode = PictureBoxSizeMode.StretchImage;
            LeftDarkOverlay.TabIndex = 0;
            LeftDarkOverlay.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(320, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(106, 47);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // TabBarDarkOverlay
            // 
            TabBarDarkOverlay.BackColor = Color.Transparent;
            TabBarDarkOverlay.Image = Properties.Resources.dark_overlay;
            TabBarDarkOverlay.Location = new Point(308, -5);
            TabBarDarkOverlay.Name = "TabBarDarkOverlay";
            TabBarDarkOverlay.Size = new Size(708, 64);
            TabBarDarkOverlay.SizeMode = PictureBoxSizeMode.StretchImage;
            TabBarDarkOverlay.TabIndex = 2;
            TabBarDarkOverlay.TabStop = false;
            // 
            // MainEditorLightBG
            // 
            MainEditorLightBG.BackColor = Color.Transparent;
            MainEditorLightBG.Image = Properties.Resources.light_overlay;
            MainEditorLightBG.Location = new Point(308, -5);
            MainEditorLightBG.Name = "MainEditorLightBG";
            MainEditorLightBG.Size = new Size(708, 765);
            MainEditorLightBG.SizeMode = PictureBoxSizeMode.StretchImage;
            MainEditorLightBG.TabIndex = 3;
            MainEditorLightBG.TabStop = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg_1_s;
            ClientSize = new Size(1008, 729);
            Controls.Add(pictureBox2);
            Controls.Add(LeftDarkOverlay);
            Controls.Add(TabBarDarkOverlay);
            Controls.Add(MainEditorLightBG);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main";
            Text = "GHWT: Definitive Edition Launcher V3.0";
            ((System.ComponentModel.ISupportInitialize)LeftDarkOverlay).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)TabBarDarkOverlay).EndInit();
            ((System.ComponentModel.ISupportInitialize)MainEditorLightBG).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox LeftDarkOverlay;
        private PictureBox pictureBox2;
        private PictureBox TabBarDarkOverlay;
        private PictureBox MainEditorLightBG;
    }
}