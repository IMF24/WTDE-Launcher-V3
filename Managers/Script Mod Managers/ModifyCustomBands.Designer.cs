namespace WTDE_Launcher_V3 {
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
            this.AvatarImageCobalt = new System.Windows.Forms.PictureBox();
            this.AvatarImageIMF = new System.Windows.Forms.PictureBox();
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarImageCobalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarImageIMF)).BeginInit();
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
            // ModifyCustomBands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 517);
            this.Controls.Add(this.AvatarImageCobalt);
            this.Controls.Add(this.AvatarImageIMF);
            this.Controls.Add(this.InfoHeaderLabel);
            this.Name = "ModifyCustomBands";
            this.Text = "ModifyCustomBands";
            ((System.ComponentModel.ISupportInitialize)(this.AvatarImageCobalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarImageIMF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AvatarImageCobalt;
        private System.Windows.Forms.PictureBox AvatarImageIMF;
        private System.Windows.Forms.Label InfoHeaderLabel;
    }
}