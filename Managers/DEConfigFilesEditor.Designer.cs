namespace WTDE_Launcher_V3.Managers {
    partial class DEConfigFilesEditor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DEConfigFilesEditor));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.EditorTabsMain = new System.Windows.Forms.TabControl();
            this.WTDEConfigEditorTab = new System.Windows.Forms.TabPage();
            this.WTDEEditorTextArea = new System.Windows.Forms.TextBox();
            this.AspyrConfigEditorTab = new System.Windows.Forms.TabPage();
            this.AspyrEditorTextArea = new System.Windows.Forms.TextBox();
            this.CloseButtonNoSave = new System.Windows.Forms.Button();
            this.SaveAndExitButton = new System.Windows.Forms.Button();
            this.EditorTabsMain.SuspendLayout();
            this.WTDEConfigEditorTab.SuspendLayout();
            this.AspyrConfigEditorTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            this.InfoHeaderLabel.AutoSize = true;
            this.InfoHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.InfoHeaderLabel.Location = new System.Drawing.Point(3, 2);
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            this.InfoHeaderLabel.Size = new System.Drawing.Size(446, 13);
            this.InfoHeaderLabel.TabIndex = 1;
            this.InfoHeaderLabel.Text = "INI and XML File Editor: Edit your GHWTDE.ini and AspyrConfig.xml files raw.";
            // 
            // EditorTabsMain
            // 
            this.EditorTabsMain.Controls.Add(this.WTDEConfigEditorTab);
            this.EditorTabsMain.Controls.Add(this.AspyrConfigEditorTab);
            this.EditorTabsMain.Location = new System.Drawing.Point(12, 18);
            this.EditorTabsMain.Name = "EditorTabsMain";
            this.EditorTabsMain.SelectedIndex = 0;
            this.EditorTabsMain.Size = new System.Drawing.Size(909, 614);
            this.EditorTabsMain.TabIndex = 2;
            // 
            // WTDEConfigEditorTab
            // 
            this.WTDEConfigEditorTab.Controls.Add(this.WTDEEditorTextArea);
            this.WTDEConfigEditorTab.Location = new System.Drawing.Point(4, 22);
            this.WTDEConfigEditorTab.Name = "WTDEConfigEditorTab";
            this.WTDEConfigEditorTab.Padding = new System.Windows.Forms.Padding(3);
            this.WTDEConfigEditorTab.Size = new System.Drawing.Size(901, 588);
            this.WTDEConfigEditorTab.TabIndex = 0;
            this.WTDEConfigEditorTab.Text = "GHWTDE.ini";
            this.WTDEConfigEditorTab.UseVisualStyleBackColor = true;
            // 
            // WTDEEditorTextArea
            // 
            this.WTDEEditorTextArea.Font = new System.Drawing.Font("Consolas", 10F);
            this.WTDEEditorTextArea.Location = new System.Drawing.Point(6, 6);
            this.WTDEEditorTextArea.Multiline = true;
            this.WTDEEditorTextArea.Name = "WTDEEditorTextArea";
            this.WTDEEditorTextArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.WTDEEditorTextArea.Size = new System.Drawing.Size(889, 576);
            this.WTDEEditorTextArea.TabIndex = 0;
            this.WTDEEditorTextArea.WordWrap = false;
            // 
            // AspyrConfigEditorTab
            // 
            this.AspyrConfigEditorTab.Controls.Add(this.AspyrEditorTextArea);
            this.AspyrConfigEditorTab.Location = new System.Drawing.Point(4, 22);
            this.AspyrConfigEditorTab.Name = "AspyrConfigEditorTab";
            this.AspyrConfigEditorTab.Padding = new System.Windows.Forms.Padding(3);
            this.AspyrConfigEditorTab.Size = new System.Drawing.Size(901, 588);
            this.AspyrConfigEditorTab.TabIndex = 1;
            this.AspyrConfigEditorTab.Text = "AspyrConfig.xml";
            this.AspyrConfigEditorTab.UseVisualStyleBackColor = true;
            // 
            // AspyrEditorTextArea
            // 
            this.AspyrEditorTextArea.Font = new System.Drawing.Font("Consolas", 10F);
            this.AspyrEditorTextArea.Location = new System.Drawing.Point(6, 6);
            this.AspyrEditorTextArea.Multiline = true;
            this.AspyrEditorTextArea.Name = "AspyrEditorTextArea";
            this.AspyrEditorTextArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.AspyrEditorTextArea.Size = new System.Drawing.Size(889, 576);
            this.AspyrEditorTextArea.TabIndex = 1;
            this.AspyrEditorTextArea.WordWrap = false;
            // 
            // CloseButtonNoSave
            // 
            this.CloseButtonNoSave.Location = new System.Drawing.Point(713, 638);
            this.CloseButtonNoSave.Name = "CloseButtonNoSave";
            this.CloseButtonNoSave.Size = new System.Drawing.Size(215, 23);
            this.CloseButtonNoSave.TabIndex = 3;
            this.CloseButtonNoSave.Text = "Quit Editor Without Saving";
            this.CloseButtonNoSave.UseVisualStyleBackColor = true;
            this.CloseButtonNoSave.Click += new System.EventHandler(this.CloseButtonNoSave_Click);
            // 
            // SaveAndExitButton
            // 
            this.SaveAndExitButton.Location = new System.Drawing.Point(492, 638);
            this.SaveAndExitButton.Name = "SaveAndExitButton";
            this.SaveAndExitButton.Size = new System.Drawing.Size(215, 23);
            this.SaveAndExitButton.TabIndex = 4;
            this.SaveAndExitButton.Text = "Save and Exit";
            this.SaveAndExitButton.UseVisualStyleBackColor = true;
            this.SaveAndExitButton.Click += new System.EventHandler(this.SaveAndExitButton_Click);
            // 
            // DEConfigFilesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(933, 668);
            this.Controls.Add(this.SaveAndExitButton);
            this.Controls.Add(this.CloseButtonNoSave);
            this.Controls.Add(this.EditorTabsMain);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DEConfigFilesEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INI and XML File Editor";
            this.EditorTabsMain.ResumeLayout(false);
            this.WTDEConfigEditorTab.ResumeLayout(false);
            this.WTDEConfigEditorTab.PerformLayout();
            this.AspyrConfigEditorTab.ResumeLayout(false);
            this.AspyrConfigEditorTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.TabControl EditorTabsMain;
        private System.Windows.Forms.TabPage WTDEConfigEditorTab;
        private System.Windows.Forms.TabPage AspyrConfigEditorTab;
        private System.Windows.Forms.TextBox WTDEEditorTextArea;
        private System.Windows.Forms.TextBox AspyrEditorTextArea;
        private System.Windows.Forms.Button CloseButtonNoSave;
        private System.Windows.Forms.Button SaveAndExitButton;
    }
}