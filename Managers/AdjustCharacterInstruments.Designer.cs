namespace WTDE_Launcher_V3.Managers {
    partial class AdjustCharacterInstruments {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdjustCharacterInstruments));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.ActiveCharTextLabel = new System.Windows.Forms.Label();
            this.ActiveCharacterLabel = new System.Windows.Forms.Label();
            this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.MixerIconGuitar = new System.Windows.Forms.PictureBox();
            this.MixerIconBass = new System.Windows.Forms.PictureBox();
            this.MixerIconDrums = new System.Windows.Forms.PictureBox();
            this.MixerIconVocals = new System.Windows.Forms.PictureBox();
            this.MixedIconMicStand = new System.Windows.Forms.PictureBox();
            this.PrefGuitarLabel = new System.Windows.Forms.Label();
            this.PrefBassLabel = new System.Windows.Forms.Label();
            this.PrefDrumLabel = new System.Windows.Forms.Label();
            this.PrefMicLabel = new System.Windows.Forms.Label();
            this.PrefMicStandLabel = new System.Windows.Forms.Label();
            this.NewPreferredGuitar = new System.Windows.Forms.TextBox();
            this.NewPreferredBass = new System.Windows.Forms.TextBox();
            this.NewPreferredDrums = new System.Windows.Forms.TextBox();
            this.NewPreferredMic = new System.Windows.Forms.TextBox();
            this.NewPreferredMicStand = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SelectGuitarButton = new System.Windows.Forms.Button();
            this.SelectBassButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MixerIconGuitar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MixerIconBass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MixerIconDrums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MixerIconVocals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MixedIconMicStand)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(495, 13);
            this.InfoHeaderLabel.TabIndex = 3;
            this.InfoHeaderLabel.Text = "Adjust Preferred Character Instruments: Sets the preferred instruments on a chara" +
    "cter.";
            // 
            // ActiveCharTextLabel
            // 
            this.ActiveCharTextLabel.AutoSize = true;
            this.ActiveCharTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ActiveCharTextLabel.Location = new System.Drawing.Point(11, 27);
            this.ActiveCharTextLabel.Name = "ActiveCharTextLabel";
            this.ActiveCharTextLabel.Size = new System.Drawing.Size(106, 13);
            this.ActiveCharTextLabel.TabIndex = 4;
            this.ActiveCharTextLabel.Text = "Active Character:";
            // 
            // ActiveCharacterLabel
            // 
            this.ActiveCharacterLabel.AutoSize = true;
            this.ActiveCharacterLabel.Location = new System.Drawing.Point(123, 27);
            this.ActiveCharacterLabel.Name = "ActiveCharacterLabel";
            this.ActiveCharacterLabel.Size = new System.Drawing.Size(153, 13);
            this.ActiveCharacterLabel.TabIndex = 5;
            this.ActiveCharacterLabel.Text = "ACTIVE_CHARACTER_HERE";
            // 
            // MixerIconGuitar
            // 
            this.MixerIconGuitar.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.mixer_icon_guitar;
            this.MixerIconGuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MixerIconGuitar.Location = new System.Drawing.Point(24, 52);
            this.MixerIconGuitar.Name = "MixerIconGuitar";
            this.MixerIconGuitar.Size = new System.Drawing.Size(24, 24);
            this.MixerIconGuitar.TabIndex = 6;
            this.MixerIconGuitar.TabStop = false;
            // 
            // MixerIconBass
            // 
            this.MixerIconBass.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.mixer_icon_bass;
            this.MixerIconBass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MixerIconBass.Location = new System.Drawing.Point(24, 82);
            this.MixerIconBass.Name = "MixerIconBass";
            this.MixerIconBass.Size = new System.Drawing.Size(24, 24);
            this.MixerIconBass.TabIndex = 6;
            this.MixerIconBass.TabStop = false;
            // 
            // MixerIconDrums
            // 
            this.MixerIconDrums.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.mixer_icon_drums;
            this.MixerIconDrums.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MixerIconDrums.Location = new System.Drawing.Point(24, 112);
            this.MixerIconDrums.Name = "MixerIconDrums";
            this.MixerIconDrums.Size = new System.Drawing.Size(24, 24);
            this.MixerIconDrums.TabIndex = 6;
            this.MixerIconDrums.TabStop = false;
            // 
            // MixerIconVocals
            // 
            this.MixerIconVocals.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.mixer_icon_vocals;
            this.MixerIconVocals.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MixerIconVocals.Location = new System.Drawing.Point(24, 142);
            this.MixerIconVocals.Name = "MixerIconVocals";
            this.MixerIconVocals.Size = new System.Drawing.Size(24, 24);
            this.MixerIconVocals.TabIndex = 6;
            this.MixerIconVocals.TabStop = false;
            // 
            // MixedIconMicStand
            // 
            this.MixedIconMicStand.BackgroundImage = global::WTDE_Launcher_V3.Properties.Resources.mixer_icon_mic_stand;
            this.MixedIconMicStand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MixedIconMicStand.Location = new System.Drawing.Point(24, 172);
            this.MixedIconMicStand.Name = "MixedIconMicStand";
            this.MixedIconMicStand.Size = new System.Drawing.Size(24, 24);
            this.MixedIconMicStand.TabIndex = 6;
            this.MixedIconMicStand.TabStop = false;
            // 
            // PrefGuitarLabel
            // 
            this.PrefGuitarLabel.AutoSize = true;
            this.PrefGuitarLabel.Location = new System.Drawing.Point(55, 58);
            this.PrefGuitarLabel.Name = "PrefGuitarLabel";
            this.PrefGuitarLabel.Size = new System.Drawing.Size(111, 13);
            this.PrefGuitarLabel.TabIndex = 4;
            this.PrefGuitarLabel.Text = "Preferred Lead Guitar:";
            // 
            // PrefBassLabel
            // 
            this.PrefBassLabel.AutoSize = true;
            this.PrefBassLabel.Location = new System.Drawing.Point(55, 88);
            this.PrefBassLabel.Name = "PrefBassLabel";
            this.PrefBassLabel.Size = new System.Drawing.Size(110, 13);
            this.PrefBassLabel.TabIndex = 4;
            this.PrefBassLabel.Text = "Preferred Bass Guitar:";
            // 
            // PrefDrumLabel
            // 
            this.PrefDrumLabel.AutoSize = true;
            this.PrefDrumLabel.Location = new System.Drawing.Point(55, 118);
            this.PrefDrumLabel.Name = "PrefDrumLabel";
            this.PrefDrumLabel.Size = new System.Drawing.Size(96, 13);
            this.PrefDrumLabel.TabIndex = 4;
            this.PrefDrumLabel.Text = "Preferred Drum Kit:";
            // 
            // PrefMicLabel
            // 
            this.PrefMicLabel.AutoSize = true;
            this.PrefMicLabel.Location = new System.Drawing.Point(55, 148);
            this.PrefMicLabel.Name = "PrefMicLabel";
            this.PrefMicLabel.Size = new System.Drawing.Size(112, 13);
            this.PrefMicLabel.TabIndex = 4;
            this.PrefMicLabel.Text = "Preferred Microphone:";
            // 
            // PrefMicStandLabel
            // 
            this.PrefMicStandLabel.AutoSize = true;
            this.PrefMicStandLabel.Location = new System.Drawing.Point(55, 178);
            this.PrefMicStandLabel.Name = "PrefMicStandLabel";
            this.PrefMicStandLabel.Size = new System.Drawing.Size(107, 13);
            this.PrefMicStandLabel.TabIndex = 4;
            this.PrefMicStandLabel.Text = "Preferred Mic. Stand:";
            // 
            // NewPreferredGuitar
            // 
            this.NewPreferredGuitar.Location = new System.Drawing.Point(177, 55);
            this.NewPreferredGuitar.Name = "NewPreferredGuitar";
            this.NewPreferredGuitar.Size = new System.Drawing.Size(362, 20);
            this.NewPreferredGuitar.TabIndex = 7;
            // 
            // NewPreferredBass
            // 
            this.NewPreferredBass.Location = new System.Drawing.Point(177, 85);
            this.NewPreferredBass.Name = "NewPreferredBass";
            this.NewPreferredBass.Size = new System.Drawing.Size(362, 20);
            this.NewPreferredBass.TabIndex = 7;
            // 
            // NewPreferredDrums
            // 
            this.NewPreferredDrums.Location = new System.Drawing.Point(177, 115);
            this.NewPreferredDrums.Name = "NewPreferredDrums";
            this.NewPreferredDrums.Size = new System.Drawing.Size(362, 20);
            this.NewPreferredDrums.TabIndex = 7;
            // 
            // NewPreferredMic
            // 
            this.NewPreferredMic.Location = new System.Drawing.Point(177, 145);
            this.NewPreferredMic.Name = "NewPreferredMic";
            this.NewPreferredMic.Size = new System.Drawing.Size(362, 20);
            this.NewPreferredMic.TabIndex = 7;
            // 
            // NewPreferredMicStand
            // 
            this.NewPreferredMicStand.Location = new System.Drawing.Point(177, 175);
            this.NewPreferredMicStand.Name = "NewPreferredMicStand";
            this.NewPreferredMicStand.Size = new System.Drawing.Size(362, 20);
            this.NewPreferredMicStand.TabIndex = 7;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(492, 213);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(86, 23);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(400, 213);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(86, 23);
            this.OKButton.TabIndex = 8;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // SelectGuitarButton
            // 
            this.SelectGuitarButton.Location = new System.Drawing.Point(545, 54);
            this.SelectGuitarButton.Name = "SelectGuitarButton";
            this.SelectGuitarButton.Size = new System.Drawing.Size(27, 23);
            this.SelectGuitarButton.TabIndex = 8;
            this.SelectGuitarButton.Text = "...";
            this.SelectGuitarButton.UseVisualStyleBackColor = true;
            this.SelectGuitarButton.Click += new System.EventHandler(this.SelectGuitarButton_Click);
            // 
            // SelectBassButton
            // 
            this.SelectBassButton.Location = new System.Drawing.Point(545, 84);
            this.SelectBassButton.Name = "SelectBassButton";
            this.SelectBassButton.Size = new System.Drawing.Size(27, 23);
            this.SelectBassButton.TabIndex = 8;
            this.SelectBassButton.Text = "...";
            this.SelectBassButton.UseVisualStyleBackColor = true;
            this.SelectBassButton.Click += new System.EventHandler(this.SelectBassButton_Click);
            // 
            // AdjustCharacterInstruments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(584, 241);
            this.Controls.Add(this.SelectBassButton);
            this.Controls.Add(this.SelectGuitarButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.NewPreferredMicStand);
            this.Controls.Add(this.NewPreferredMic);
            this.Controls.Add(this.NewPreferredDrums);
            this.Controls.Add(this.NewPreferredBass);
            this.Controls.Add(this.NewPreferredGuitar);
            this.Controls.Add(this.MixedIconMicStand);
            this.Controls.Add(this.MixerIconVocals);
            this.Controls.Add(this.MixerIconDrums);
            this.Controls.Add(this.MixerIconBass);
            this.Controls.Add(this.MixerIconGuitar);
            this.Controls.Add(this.ActiveCharacterLabel);
            this.Controls.Add(this.PrefBassLabel);
            this.Controls.Add(this.PrefMicStandLabel);
            this.Controls.Add(this.PrefMicLabel);
            this.Controls.Add(this.PrefDrumLabel);
            this.Controls.Add(this.PrefGuitarLabel);
            this.Controls.Add(this.ActiveCharTextLabel);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdjustCharacterInstruments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adjust Preferred Character Instruments";
            ((System.ComponentModel.ISupportInitialize)(this.MixerIconGuitar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MixerIconBass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MixerIconDrums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MixerIconVocals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MixedIconMicStand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.Label ActiveCharTextLabel;
        private System.Windows.Forms.Label ActiveCharacterLabel;
        private System.Windows.Forms.ToolTip ToolTipMain;
        private System.Windows.Forms.PictureBox MixerIconGuitar;
        private System.Windows.Forms.PictureBox MixerIconBass;
        private System.Windows.Forms.PictureBox MixerIconDrums;
        private System.Windows.Forms.PictureBox MixerIconVocals;
        private System.Windows.Forms.PictureBox MixedIconMicStand;
        private System.Windows.Forms.Label PrefGuitarLabel;
        private System.Windows.Forms.Label PrefBassLabel;
        private System.Windows.Forms.Label PrefDrumLabel;
        private System.Windows.Forms.Label PrefMicLabel;
        private System.Windows.Forms.Label PrefMicStandLabel;
        private System.Windows.Forms.TextBox NewPreferredGuitar;
        private System.Windows.Forms.TextBox NewPreferredBass;
        private System.Windows.Forms.TextBox NewPreferredDrums;
        private System.Windows.Forms.TextBox NewPreferredMic;
        private System.Windows.Forms.TextBox NewPreferredMicStand;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button SelectGuitarButton;
        private System.Windows.Forms.Button SelectBassButton;
    }
}