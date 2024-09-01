﻿namespace WTDE_Launcher_V3.Managers {
    partial class SCMEditCareerSort {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCMEditCareerSort));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.MainEditorTabs = new System.Windows.Forms.TabControl();
            this.TabCareerSortG = new System.Windows.Forms.TabPage();
            this.GuitarSortList = new System.Windows.Forms.ListBox();
            this.TabCareerSortB = new System.Windows.Forms.TabPage();
            this.BassSortList = new System.Windows.Forms.ListBox();
            this.TabCareerSortD = new System.Windows.Forms.TabPage();
            this.DrumsSortList = new System.Windows.Forms.ListBox();
            this.TabCareerSortV = new System.Windows.Forms.TabPage();
            this.VocalsSortList = new System.Windows.Forms.ListBox();
            this.TabCareerSortA = new System.Windows.Forms.TabPage();
            this.BandSortList = new System.Windows.Forms.ListBox();
            this.ResetSortOrderButton = new System.Windows.Forms.Button();
            this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.MoveItemUpGButton = new System.Windows.Forms.Button();
            this.MoveItemDownGButton = new System.Windows.Forms.Button();
            this.ActionsHeaderLabel = new System.Windows.Forms.Label();
            this.ResetSortAllOrdersButton = new System.Windows.Forms.Button();
            this.MoveToIndexButton = new System.Windows.Forms.Button();
            this.AtIndexLabel = new System.Windows.Forms.Label();
            this.IndexMoverSpinBox = new System.Windows.Forms.NumericUpDown();
            this.MainEditorTabs.SuspendLayout();
            this.TabCareerSortG.SuspendLayout();
            this.TabCareerSortB.SuspendLayout();
            this.TabCareerSortD.SuspendLayout();
            this.TabCareerSortV.SuspendLayout();
            this.TabCareerSortA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IndexMoverSpinBox)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(457, 13);
            this.InfoHeaderLabel.TabIndex = 6;
            this.InfoHeaderLabel.Text = "Manage Career Sort: Manage the sort order for Sort by Career for this category.";
            // 
            // MainEditorTabs
            // 
            this.MainEditorTabs.Controls.Add(this.TabCareerSortG);
            this.MainEditorTabs.Controls.Add(this.TabCareerSortB);
            this.MainEditorTabs.Controls.Add(this.TabCareerSortD);
            this.MainEditorTabs.Controls.Add(this.TabCareerSortV);
            this.MainEditorTabs.Controls.Add(this.TabCareerSortA);
            this.MainEditorTabs.Location = new System.Drawing.Point(12, 19);
            this.MainEditorTabs.Name = "MainEditorTabs";
            this.MainEditorTabs.SelectedIndex = 0;
            this.MainEditorTabs.Size = new System.Drawing.Size(447, 464);
            this.MainEditorTabs.TabIndex = 7;
            this.MainEditorTabs.SelectedIndexChanged += new System.EventHandler(this.MainEditorTabs_SelectedIndexChanged);
            // 
            // TabCareerSortG
            // 
            this.TabCareerSortG.Controls.Add(this.GuitarSortList);
            this.TabCareerSortG.Location = new System.Drawing.Point(4, 22);
            this.TabCareerSortG.Name = "TabCareerSortG";
            this.TabCareerSortG.Padding = new System.Windows.Forms.Padding(3);
            this.TabCareerSortG.Size = new System.Drawing.Size(439, 438);
            this.TabCareerSortG.TabIndex = 0;
            this.TabCareerSortG.Text = "Guitar Sort";
            this.TabCareerSortG.UseVisualStyleBackColor = true;
            // 
            // GuitarSortList
            // 
            this.GuitarSortList.AllowDrop = true;
            this.GuitarSortList.FormattingEnabled = true;
            this.GuitarSortList.Location = new System.Drawing.Point(97, 8);
            this.GuitarSortList.Name = "GuitarSortList";
            this.GuitarSortList.Size = new System.Drawing.Size(243, 420);
            this.GuitarSortList.TabIndex = 0;
            this.GuitarSortList.SelectedIndexChanged += new System.EventHandler(this.MainListBoxes_SelectedIndexChanged);
            // 
            // TabCareerSortB
            // 
            this.TabCareerSortB.Controls.Add(this.BassSortList);
            this.TabCareerSortB.Location = new System.Drawing.Point(4, 22);
            this.TabCareerSortB.Name = "TabCareerSortB";
            this.TabCareerSortB.Padding = new System.Windows.Forms.Padding(3);
            this.TabCareerSortB.Size = new System.Drawing.Size(439, 438);
            this.TabCareerSortB.TabIndex = 1;
            this.TabCareerSortB.Text = "Bass Sort";
            this.TabCareerSortB.UseVisualStyleBackColor = true;
            // 
            // BassSortList
            // 
            this.BassSortList.FormattingEnabled = true;
            this.BassSortList.Location = new System.Drawing.Point(97, 8);
            this.BassSortList.Name = "BassSortList";
            this.BassSortList.Size = new System.Drawing.Size(243, 420);
            this.BassSortList.TabIndex = 1;
            this.BassSortList.SelectedIndexChanged += new System.EventHandler(this.MainListBoxes_SelectedIndexChanged);
            // 
            // TabCareerSortD
            // 
            this.TabCareerSortD.Controls.Add(this.DrumsSortList);
            this.TabCareerSortD.Location = new System.Drawing.Point(4, 22);
            this.TabCareerSortD.Name = "TabCareerSortD";
            this.TabCareerSortD.Size = new System.Drawing.Size(439, 438);
            this.TabCareerSortD.TabIndex = 2;
            this.TabCareerSortD.Text = "Drums Sort";
            this.TabCareerSortD.UseVisualStyleBackColor = true;
            // 
            // DrumsSortList
            // 
            this.DrumsSortList.FormattingEnabled = true;
            this.DrumsSortList.Location = new System.Drawing.Point(97, 8);
            this.DrumsSortList.Name = "DrumsSortList";
            this.DrumsSortList.Size = new System.Drawing.Size(243, 420);
            this.DrumsSortList.TabIndex = 2;
            this.DrumsSortList.SelectedIndexChanged += new System.EventHandler(this.MainListBoxes_SelectedIndexChanged);
            // 
            // TabCareerSortV
            // 
            this.TabCareerSortV.Controls.Add(this.VocalsSortList);
            this.TabCareerSortV.Location = new System.Drawing.Point(4, 22);
            this.TabCareerSortV.Name = "TabCareerSortV";
            this.TabCareerSortV.Size = new System.Drawing.Size(439, 438);
            this.TabCareerSortV.TabIndex = 3;
            this.TabCareerSortV.Text = "Vocals Sort";
            this.TabCareerSortV.UseVisualStyleBackColor = true;
            // 
            // VocalsSortList
            // 
            this.VocalsSortList.FormattingEnabled = true;
            this.VocalsSortList.Location = new System.Drawing.Point(97, 8);
            this.VocalsSortList.Name = "VocalsSortList";
            this.VocalsSortList.Size = new System.Drawing.Size(243, 420);
            this.VocalsSortList.TabIndex = 3;
            this.VocalsSortList.SelectedIndexChanged += new System.EventHandler(this.MainListBoxes_SelectedIndexChanged);
            // 
            // TabCareerSortA
            // 
            this.TabCareerSortA.Controls.Add(this.BandSortList);
            this.TabCareerSortA.Location = new System.Drawing.Point(4, 22);
            this.TabCareerSortA.Name = "TabCareerSortA";
            this.TabCareerSortA.Size = new System.Drawing.Size(439, 438);
            this.TabCareerSortA.TabIndex = 4;
            this.TabCareerSortA.Text = "Band Sort";
            this.TabCareerSortA.UseVisualStyleBackColor = true;
            // 
            // BandSortList
            // 
            this.BandSortList.FormattingEnabled = true;
            this.BandSortList.Location = new System.Drawing.Point(97, 8);
            this.BandSortList.Name = "BandSortList";
            this.BandSortList.Size = new System.Drawing.Size(243, 420);
            this.BandSortList.TabIndex = 3;
            this.BandSortList.SelectedIndexChanged += new System.EventHandler(this.MainListBoxes_SelectedIndexChanged);
            // 
            // ResetSortOrderButton
            // 
            this.ResetSortOrderButton.Location = new System.Drawing.Point(465, 182);
            this.ResetSortOrderButton.Name = "ResetSortOrderButton";
            this.ResetSortOrderButton.Size = new System.Drawing.Size(156, 23);
            this.ResetSortOrderButton.TabIndex = 10;
            this.ResetSortOrderButton.Text = "Reset Sort Order";
            this.ToolTipMain.SetToolTip(this.ResetSortOrderButton, "Reset the sort order. This writes the sort index to -1.");
            this.ResetSortOrderButton.UseVisualStyleBackColor = true;
            this.ResetSortOrderButton.Click += new System.EventHandler(this.ResetSortOrderButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(539, 489);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(89, 23);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(444, 489);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(89, 23);
            this.OKButton.TabIndex = 10;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // MoveItemUpGButton
            // 
            this.MoveItemUpGButton.Location = new System.Drawing.Point(465, 57);
            this.MoveItemUpGButton.Name = "MoveItemUpGButton";
            this.MoveItemUpGButton.Size = new System.Drawing.Size(156, 23);
            this.MoveItemUpGButton.TabIndex = 10;
            this.MoveItemUpGButton.Text = "Move Up";
            this.MoveItemUpGButton.UseVisualStyleBackColor = true;
            this.MoveItemUpGButton.Click += new System.EventHandler(this.MoveItemUpGButton_Click);
            // 
            // MoveItemDownGButton
            // 
            this.MoveItemDownGButton.Location = new System.Drawing.Point(465, 86);
            this.MoveItemDownGButton.Name = "MoveItemDownGButton";
            this.MoveItemDownGButton.Size = new System.Drawing.Size(156, 23);
            this.MoveItemDownGButton.TabIndex = 10;
            this.MoveItemDownGButton.Text = "Move Down";
            this.MoveItemDownGButton.UseVisualStyleBackColor = true;
            this.MoveItemDownGButton.Click += new System.EventHandler(this.MoveItemDownGButton_Click);
            // 
            // ActionsHeaderLabel
            // 
            this.ActionsHeaderLabel.AutoSize = true;
            this.ActionsHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ActionsHeaderLabel.Location = new System.Drawing.Point(461, 41);
            this.ActionsHeaderLabel.Name = "ActionsHeaderLabel";
            this.ActionsHeaderLabel.Size = new System.Drawing.Size(53, 13);
            this.ActionsHeaderLabel.TabIndex = 6;
            this.ActionsHeaderLabel.Text = "Actions:";
            // 
            // ResetSortAllOrdersButton
            // 
            this.ResetSortAllOrdersButton.Location = new System.Drawing.Point(465, 211);
            this.ResetSortAllOrdersButton.Name = "ResetSortAllOrdersButton";
            this.ResetSortAllOrdersButton.Size = new System.Drawing.Size(156, 23);
            this.ResetSortAllOrdersButton.TabIndex = 10;
            this.ResetSortAllOrdersButton.Text = "Reset All Sort Orders";
            this.ResetSortAllOrdersButton.UseVisualStyleBackColor = true;
            this.ResetSortAllOrdersButton.Click += new System.EventHandler(this.ResetSortAllOrdersButton_Click);
            // 
            // MoveToIndexButton
            // 
            this.MoveToIndexButton.Location = new System.Drawing.Point(465, 115);
            this.MoveToIndexButton.Name = "MoveToIndexButton";
            this.MoveToIndexButton.Size = new System.Drawing.Size(49, 23);
            this.MoveToIndexButton.TabIndex = 10;
            this.MoveToIndexButton.Text = "Move";
            this.MoveToIndexButton.UseVisualStyleBackColor = true;
            this.MoveToIndexButton.Click += new System.EventHandler(this.MoveToIndexButton_Click);
            // 
            // AtIndexLabel
            // 
            this.AtIndexLabel.AutoSize = true;
            this.AtIndexLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.AtIndexLabel.Location = new System.Drawing.Point(516, 120);
            this.AtIndexLabel.Name = "AtIndexLabel";
            this.AtIndexLabel.Size = new System.Drawing.Size(52, 13);
            this.AtIndexLabel.TabIndex = 6;
            this.AtIndexLabel.Text = "To Index:";
            // 
            // IndexMoverSpinBox
            // 
            this.IndexMoverSpinBox.Location = new System.Drawing.Point(569, 117);
            this.IndexMoverSpinBox.Name = "IndexMoverSpinBox";
            this.IndexMoverSpinBox.Size = new System.Drawing.Size(52, 20);
            this.IndexMoverSpinBox.TabIndex = 11;
            // 
            // SCMEditCareerSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(633, 517);
            this.Controls.Add(this.IndexMoverSpinBox);
            this.Controls.Add(this.MoveToIndexButton);
            this.Controls.Add(this.MoveItemDownGButton);
            this.Controls.Add(this.AtIndexLabel);
            this.Controls.Add(this.ActionsHeaderLabel);
            this.Controls.Add(this.ResetSortAllOrdersButton);
            this.Controls.Add(this.ResetSortOrderButton);
            this.Controls.Add(this.MoveItemUpGButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.MainEditorTabs);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SCMEditCareerSort";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Sort by Career Order";
            this.MainEditorTabs.ResumeLayout(false);
            this.TabCareerSortG.ResumeLayout(false);
            this.TabCareerSortB.ResumeLayout(false);
            this.TabCareerSortD.ResumeLayout(false);
            this.TabCareerSortV.ResumeLayout(false);
            this.TabCareerSortA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IndexMoverSpinBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.TabControl MainEditorTabs;
        private System.Windows.Forms.TabPage TabCareerSortG;
        private System.Windows.Forms.TabPage TabCareerSortB;
        private System.Windows.Forms.TabPage TabCareerSortD;
        private System.Windows.Forms.TabPage TabCareerSortV;
        private System.Windows.Forms.TabPage TabCareerSortA;
        private System.Windows.Forms.ToolTip ToolTipMain;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ListBox GuitarSortList;
        private System.Windows.Forms.Button ResetSortOrderButton;
        private System.Windows.Forms.ListBox BassSortList;
        private System.Windows.Forms.ListBox DrumsSortList;
        private System.Windows.Forms.ListBox VocalsSortList;
        private System.Windows.Forms.ListBox BandSortList;
        private System.Windows.Forms.Button MoveItemUpGButton;
        private System.Windows.Forms.Button MoveItemDownGButton;
        private System.Windows.Forms.Label ActionsHeaderLabel;
        private System.Windows.Forms.Button ResetSortAllOrdersButton;
        private System.Windows.Forms.Button MoveToIndexButton;
        private System.Windows.Forms.Label AtIndexLabel;
        private System.Windows.Forms.NumericUpDown IndexMoverSpinBox;
    }
}