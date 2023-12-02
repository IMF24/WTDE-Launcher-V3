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
            MainEditorLightBG = new PictureBox();
            label1 = new Label();
            TabButtonGroup = new Panel();
            ((System.ComponentModel.ISupportInitialize)LeftDarkOverlay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainEditorLightBG).BeginInit();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Image = Properties.Resources.dark_overlay_l;
            label1.Location = new Point(12, 705);
            label1.Name = "label1";
            label1.Size = new Size(265, 15);
            label1.TabIndex = 4;
            label1.Text = "GHWT: Definitive Edition Launcher V3.0 by IMF24\r\n";
            // 
            // TabButtonGroup
            // 
            TabButtonGroup.BackColor = Color.Transparent;
            TabButtonGroup.BackgroundImage = Properties.Resources.dark_overlay_l;
            TabButtonGroup.Location = new Point(314, -3);
            TabButtonGroup.Name = "TabButtonGroup";
            TabButtonGroup.Size = new Size(702, 66);
            TabButtonGroup.TabIndex = 5;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg_1_s;
            ClientSize = new Size(1008, 729);
            Controls.Add(TabButtonGroup);
            Controls.Add(label1);
            Controls.Add(LeftDarkOverlay);
            Controls.Add(MainEditorLightBG);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main";
            Text = "GHWT: Definitive Edition Launcher V3.0";
            ((System.ComponentModel.ISupportInitialize)LeftDarkOverlay).EndInit();
            ((System.ComponentModel.ISupportInitialize)MainEditorLightBG).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox LeftDarkOverlay;
        private PictureBox MainEditorLightBG;
        private Label label1;
        private Panel TabButtonGroup;
    }
}