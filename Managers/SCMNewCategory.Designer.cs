namespace WTDE_Launcher_V3.Managers {
    partial class SCMNewCategory {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCMNewCategory));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NewName = new System.Windows.Forms.TextBox();
            this.NewChecksum = new System.Windows.Forms.TextBox();
            this.ChecksumLabel = new System.Windows.Forms.Label();
            this.PathLabel = new System.Windows.Forms.Label();
            this.NewCategoryPath = new System.Windows.Forms.TextBox();
            this.SelectPathButton = new System.Windows.Forms.Button();
            this.ImageLabel = new System.Windows.Forms.Label();
            this.SelectImageButton = new System.Windows.Forms.Button();
            this.ImagePreviewBox = new System.Windows.Forms.PictureBox();
            this.MakeNewCategory = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ImagePrevLabel = new System.Windows.Forms.Label();
            this.ImagePathLabel = new System.Windows.Forms.Label();
            this.SCMNewCateToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreviewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(398, 13);
            this.InfoHeaderLabel.TabIndex = 3;
            this.InfoHeaderLabel.Text = "New Song Category: Create a new category mod to place songs into.";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.ForeColor = System.Drawing.Color.Red;
            this.NameLabel.Location = new System.Drawing.Point(65, 21);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 4;
            this.NameLabel.Text = "Name:";
            // 
            // NewName
            // 
            this.NewName.Location = new System.Drawing.Point(109, 18);
            this.NewName.Name = "NewName";
            this.NewName.Size = new System.Drawing.Size(250, 20);
            this.NewName.TabIndex = 5;
            this.SCMNewCateToolTipMain.SetToolTip(this.NewName, "Name of the category.");
            // 
            // NewChecksum
            // 
            this.NewChecksum.Location = new System.Drawing.Point(109, 44);
            this.NewChecksum.Name = "NewChecksum";
            this.NewChecksum.Size = new System.Drawing.Size(125, 20);
            this.NewChecksum.TabIndex = 6;
            this.SCMNewCateToolTipMain.SetToolTip(this.NewChecksum, "The category\'s checksum. This is what determines the category a song goes into.");
            // 
            // ChecksumLabel
            // 
            this.ChecksumLabel.AutoSize = true;
            this.ChecksumLabel.ForeColor = System.Drawing.Color.Red;
            this.ChecksumLabel.Location = new System.Drawing.Point(43, 47);
            this.ChecksumLabel.Name = "ChecksumLabel";
            this.ChecksumLabel.Size = new System.Drawing.Size(60, 13);
            this.ChecksumLabel.TabIndex = 7;
            this.ChecksumLabel.Text = "Checksum:";
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.ForeColor = System.Drawing.Color.Red;
            this.PathLabel.Location = new System.Drawing.Point(71, 73);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(32, 13);
            this.PathLabel.TabIndex = 8;
            this.PathLabel.Text = "Path:";
            // 
            // NewCategoryPath
            // 
            this.NewCategoryPath.Location = new System.Drawing.Point(109, 70);
            this.NewCategoryPath.Name = "NewCategoryPath";
            this.NewCategoryPath.Size = new System.Drawing.Size(389, 20);
            this.NewCategoryPath.TabIndex = 9;
            this.SCMNewCateToolTipMain.SetToolTip(this.NewCategoryPath, "Where will this category mod be placed?");
            // 
            // SelectPathButton
            // 
            this.SelectPathButton.Location = new System.Drawing.Point(504, 69);
            this.SelectPathButton.Name = "SelectPathButton";
            this.SelectPathButton.Size = new System.Drawing.Size(27, 23);
            this.SelectPathButton.TabIndex = 10;
            this.SelectPathButton.Text = "...";
            this.SCMNewCateToolTipMain.SetToolTip(this.SelectPathButton, "Select a folder to set the category to be created in.");
            this.SelectPathButton.UseVisualStyleBackColor = true;
            this.SelectPathButton.Click += new System.EventHandler(this.SelectPathButton_Click);
            // 
            // ImageLabel
            // 
            this.ImageLabel.AutoSize = true;
            this.ImageLabel.ForeColor = System.Drawing.Color.Red;
            this.ImageLabel.Location = new System.Drawing.Point(64, 101);
            this.ImageLabel.Name = "ImageLabel";
            this.ImageLabel.Size = new System.Drawing.Size(39, 13);
            this.ImageLabel.TabIndex = 11;
            this.ImageLabel.Text = "Image:";
            // 
            // SelectImageButton
            // 
            this.SelectImageButton.Location = new System.Drawing.Point(394, 124);
            this.SelectImageButton.Name = "SelectImageButton";
            this.SelectImageButton.Size = new System.Drawing.Size(137, 23);
            this.SelectImageButton.TabIndex = 12;
            this.SelectImageButton.Text = "Select Image...";
            this.SCMNewCateToolTipMain.SetToolTip(this.SelectImageButton, "Select an image to use for the category. It will automatically be resized to 256 " +
        "X 256.");
            this.SelectImageButton.UseVisualStyleBackColor = true;
            this.SelectImageButton.Click += new System.EventHandler(this.SelectImageButton_Click);
            // 
            // ImagePreviewBox
            // 
            this.ImagePreviewBox.Location = new System.Drawing.Point(182, 158);
            this.ImagePreviewBox.Name = "ImagePreviewBox";
            this.ImagePreviewBox.Size = new System.Drawing.Size(256, 256);
            this.ImagePreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagePreviewBox.TabIndex = 13;
            this.ImagePreviewBox.TabStop = false;
            // 
            // MakeNewCategory
            // 
            this.MakeNewCategory.Location = new System.Drawing.Point(307, 424);
            this.MakeNewCategory.Name = "MakeNewCategory";
            this.MakeNewCategory.Size = new System.Drawing.Size(150, 23);
            this.MakeNewCategory.TabIndex = 14;
            this.MakeNewCategory.Text = "OK / Create New";
            this.SCMNewCateToolTipMain.SetToolTip(this.MakeNewCategory, "Accept the defined settings and create a new category mod.");
            this.MakeNewCategory.UseVisualStyleBackColor = true;
            this.MakeNewCategory.Click += new System.EventHandler(this.MakeNewCategory_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(463, 424);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 14;
            this.CancelButton.Text = "Cancel";
            this.SCMNewCateToolTipMain.SetToolTip(this.CancelButton, "Closes this window without saving any changes.");
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ImagePrevLabel
            // 
            this.ImagePrevLabel.AutoSize = true;
            this.ImagePrevLabel.Location = new System.Drawing.Point(23, 129);
            this.ImagePrevLabel.Name = "ImagePrevLabel";
            this.ImagePrevLabel.Size = new System.Drawing.Size(80, 13);
            this.ImagePrevLabel.TabIndex = 15;
            this.ImagePrevLabel.Text = "Image Preview:";
            // 
            // ImagePathLabel
            // 
            this.ImagePathLabel.AutoSize = true;
            this.ImagePathLabel.Location = new System.Drawing.Point(109, 101);
            this.ImagePathLabel.Name = "ImagePathLabel";
            this.ImagePathLabel.Size = new System.Drawing.Size(76, 13);
            this.ImagePathLabel.TabIndex = 16;
            this.ImagePathLabel.Text = "IMAGE_PATH";
            this.SCMNewCateToolTipMain.SetToolTip(this.ImagePathLabel, "Original path to the image you selected.");
            // 
            // SCMNewCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(544, 453);
            this.Controls.Add(this.ImagePathLabel);
            this.Controls.Add(this.ImagePrevLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.MakeNewCategory);
            this.Controls.Add(this.ImagePreviewBox);
            this.Controls.Add(this.SelectImageButton);
            this.Controls.Add(this.ImageLabel);
            this.Controls.Add(this.SelectPathButton);
            this.Controls.Add(this.NewCategoryPath);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.ChecksumLabel);
            this.Controls.Add(this.NewChecksum);
            this.Controls.Add(this.NewName);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SCMNewCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Song Category";
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreviewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NewName;
        private System.Windows.Forms.TextBox NewChecksum;
        private System.Windows.Forms.Label ChecksumLabel;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.TextBox NewCategoryPath;
        private System.Windows.Forms.Button SelectPathButton;
        private System.Windows.Forms.Label ImageLabel;
        private System.Windows.Forms.Button SelectImageButton;
        private System.Windows.Forms.PictureBox ImagePreviewBox;
        private System.Windows.Forms.Button MakeNewCategory;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label ImagePrevLabel;
        private System.Windows.Forms.Label ImagePathLabel;
        private System.Windows.Forms.ToolTip SCMNewCateToolTipMain;
    }
}