namespace WTDE_Launcher_V3 {
    partial class SCMEditCategory {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCMEditCategory));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.ChecksumLabel = new System.Windows.Forms.Label();
            this.NewChecksum = new System.Windows.Forms.TextBox();
            this.NewName = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PathNameLabel = new System.Windows.Forms.Label();
            this.PathLabelRO = new System.Windows.Forms.Label();
            this.ImageLabel = new System.Windows.Forms.Label();
            this.LogoImageBox = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.ReplaceImage = new System.Windows.Forms.Button();
            this.ExtractImage = new System.Windows.Forms.Button();
            this.SCMEditCateToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LogoImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(341, 13);
            this.InfoHeaderLabel.TabIndex = 4;
            this.InfoHeaderLabel.Text = "Edit Category: Edit the metadata for the selected category.";
            // 
            // ChecksumLabel
            // 
            this.ChecksumLabel.AutoSize = true;
            this.ChecksumLabel.ForeColor = System.Drawing.Color.Red;
            this.ChecksumLabel.Location = new System.Drawing.Point(28, 47);
            this.ChecksumLabel.Name = "ChecksumLabel";
            this.ChecksumLabel.Size = new System.Drawing.Size(60, 13);
            this.ChecksumLabel.TabIndex = 11;
            this.ChecksumLabel.Text = "Checksum:";
            // 
            // NewChecksum
            // 
            this.NewChecksum.Location = new System.Drawing.Point(94, 44);
            this.NewChecksum.Name = "NewChecksum";
            this.NewChecksum.Size = new System.Drawing.Size(125, 20);
            this.NewChecksum.TabIndex = 10;
            this.SCMEditCateToolTipMain.SetToolTip(this.NewChecksum, resources.GetString("NewChecksum.ToolTip"));
            // 
            // NewName
            // 
            this.NewName.Location = new System.Drawing.Point(94, 18);
            this.NewName.Name = "NewName";
            this.NewName.Size = new System.Drawing.Size(250, 20);
            this.NewName.TabIndex = 9;
            this.SCMEditCateToolTipMain.SetToolTip(this.NewName, "Name of the category.");
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.ForeColor = System.Drawing.Color.Red;
            this.NameLabel.Location = new System.Drawing.Point(50, 21);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 8;
            this.NameLabel.Text = "Name:";
            // 
            // PathNameLabel
            // 
            this.PathNameLabel.AutoSize = true;
            this.PathNameLabel.ForeColor = System.Drawing.Color.Black;
            this.PathNameLabel.Location = new System.Drawing.Point(56, 75);
            this.PathNameLabel.Name = "PathNameLabel";
            this.PathNameLabel.Size = new System.Drawing.Size(32, 13);
            this.PathNameLabel.TabIndex = 12;
            this.PathNameLabel.Text = "Path:";
            // 
            // PathLabelRO
            // 
            this.PathLabelRO.AutoSize = true;
            this.PathLabelRO.ForeColor = System.Drawing.Color.Gray;
            this.PathLabelRO.Location = new System.Drawing.Point(91, 75);
            this.PathLabelRO.Name = "PathLabelRO";
            this.PathLabelRO.Size = new System.Drawing.Size(61, 13);
            this.PathLabelRO.TabIndex = 13;
            this.PathLabelRO.Text = "PATH_DIR";
            this.SCMEditCateToolTipMain.SetToolTip(this.PathLabelRO, "Folder path to the category mod.");
            // 
            // ImageLabel
            // 
            this.ImageLabel.AutoSize = true;
            this.ImageLabel.ForeColor = System.Drawing.Color.Black;
            this.ImageLabel.Location = new System.Drawing.Point(49, 102);
            this.ImageLabel.Name = "ImageLabel";
            this.ImageLabel.Size = new System.Drawing.Size(39, 13);
            this.ImageLabel.TabIndex = 14;
            this.ImageLabel.Text = "Image:";
            // 
            // LogoImageBox
            // 
            this.LogoImageBox.Location = new System.Drawing.Point(94, 102);
            this.LogoImageBox.Name = "LogoImageBox";
            this.LogoImageBox.Size = new System.Drawing.Size(192, 192);
            this.LogoImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoImageBox.TabIndex = 15;
            this.LogoImageBox.TabStop = false;
            this.SCMEditCateToolTipMain.SetToolTip(this.LogoImageBox, "Logo image for the category.");
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(453, 323);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 16;
            this.CloseButton.Text = "Cancel";
            this.SCMEditCateToolTipMain.SetToolTip(this.CloseButton, "Closes this window without saving any changes.");
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(372, 323);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 16;
            this.AcceptButton.Text = "OK";
            this.SCMEditCateToolTipMain.SetToolTip(this.AcceptButton, "Apply all changes in this dialog to the category mod.");
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // ReplaceImage
            // 
            this.ReplaceImage.Location = new System.Drawing.Point(303, 102);
            this.ReplaceImage.Name = "ReplaceImage";
            this.ReplaceImage.Size = new System.Drawing.Size(219, 23);
            this.ReplaceImage.TabIndex = 16;
            this.ReplaceImage.Text = "Replace Image...";
            this.SCMEditCateToolTipMain.SetToolTip(this.ReplaceImage, "Replace the logo image with a new one. The provided image will\r\nautomatically be " +
        "scaled to 256 X 256.");
            this.ReplaceImage.UseVisualStyleBackColor = true;
            this.ReplaceImage.Click += new System.EventHandler(this.ReplaceImage_Click);
            // 
            // ExtractImage
            // 
            this.ExtractImage.Location = new System.Drawing.Point(303, 131);
            this.ExtractImage.Name = "ExtractImage";
            this.ExtractImage.Size = new System.Drawing.Size(219, 23);
            this.ExtractImage.TabIndex = 17;
            this.ExtractImage.Text = "Extract Image...";
            this.SCMEditCateToolTipMain.SetToolTip(this.ExtractImage, "Save the category image as a PNG.");
            this.ExtractImage.UseVisualStyleBackColor = true;
            this.ExtractImage.Click += new System.EventHandler(this.ExtractImage_Click);
            // 
            // SCMEditCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(534, 351);
            this.Controls.Add(this.ExtractImage);
            this.Controls.Add(this.ReplaceImage);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.LogoImageBox);
            this.Controls.Add(this.ImageLabel);
            this.Controls.Add(this.PathLabelRO);
            this.Controls.Add(this.PathNameLabel);
            this.Controls.Add(this.ChecksumLabel);
            this.Controls.Add(this.NewChecksum);
            this.Controls.Add(this.NewName);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SCMEditCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Category Data";
            ((System.ComponentModel.ISupportInitialize)(this.LogoImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.Label ChecksumLabel;
        private System.Windows.Forms.TextBox NewChecksum;
        private System.Windows.Forms.TextBox NewName;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PathNameLabel;
        private System.Windows.Forms.Label PathLabelRO;
        private System.Windows.Forms.Label ImageLabel;
        private System.Windows.Forms.PictureBox LogoImageBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Button ReplaceImage;
        private System.Windows.Forms.Button ExtractImage;
        private System.Windows.Forms.ToolTip SCMEditCateToolTipMain;
    }
}