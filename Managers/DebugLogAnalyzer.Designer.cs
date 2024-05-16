namespace WTDE_Launcher_V3.Managers {
    partial class DebugLogAnalyzer {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugLogAnalyzer));
            this.InfoHeaderLabel = new System.Windows.Forms.Label();
            this.PathNameLabel = new System.Windows.Forms.Label();
            this.DebugLogPath = new System.Windows.Forms.TextBox();
            this.SelectDebugLogButton = new System.Windows.Forms.Button();
            this.ScanProgressLabel = new System.Windows.Forms.Label();
            this.ScanProgressBar = new System.Windows.Forms.ProgressBar();
            this.ScanProgressPercent = new System.Windows.Forms.Label();
            this.IssuesFoundGroup = new System.Windows.Forms.GroupBox();
            this.ScanLogButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.AnalyzeOutputText = new System.Windows.Forms.TextBox();
            this.IssuesFoundGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoHeaderLabel
            // 
            resources.ApplyResources(this.InfoHeaderLabel, "InfoHeaderLabel");
            this.InfoHeaderLabel.Name = "InfoHeaderLabel";
            // 
            // PathNameLabel
            // 
            resources.ApplyResources(this.PathNameLabel, "PathNameLabel");
            this.PathNameLabel.Name = "PathNameLabel";
            // 
            // DebugLogPath
            // 
            resources.ApplyResources(this.DebugLogPath, "DebugLogPath");
            this.DebugLogPath.Name = "DebugLogPath";
            // 
            // SelectDebugLogButton
            // 
            resources.ApplyResources(this.SelectDebugLogButton, "SelectDebugLogButton");
            this.SelectDebugLogButton.Name = "SelectDebugLogButton";
            this.SelectDebugLogButton.UseVisualStyleBackColor = true;
            this.SelectDebugLogButton.Click += new System.EventHandler(this.SelectDebugLogButton_Click);
            // 
            // ScanProgressLabel
            // 
            resources.ApplyResources(this.ScanProgressLabel, "ScanProgressLabel");
            this.ScanProgressLabel.Name = "ScanProgressLabel";
            // 
            // ScanProgressBar
            // 
            resources.ApplyResources(this.ScanProgressBar, "ScanProgressBar");
            this.ScanProgressBar.Name = "ScanProgressBar";
            // 
            // ScanProgressPercent
            // 
            resources.ApplyResources(this.ScanProgressPercent, "ScanProgressPercent");
            this.ScanProgressPercent.Name = "ScanProgressPercent";
            // 
            // IssuesFoundGroup
            // 
            this.IssuesFoundGroup.Controls.Add(this.AnalyzeOutputText);
            resources.ApplyResources(this.IssuesFoundGroup, "IssuesFoundGroup");
            this.IssuesFoundGroup.Name = "IssuesFoundGroup";
            this.IssuesFoundGroup.TabStop = false;
            // 
            // ScanLogButton
            // 
            resources.ApplyResources(this.ScanLogButton, "ScanLogButton");
            this.ScanLogButton.Name = "ScanLogButton";
            this.ScanLogButton.UseVisualStyleBackColor = true;
            this.ScanLogButton.Click += new System.EventHandler(this.ScanLogButton_Click);
            // 
            // CloseButton
            // 
            resources.ApplyResources(this.CloseButton, "CloseButton");
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // AnalyzeOutputText
            // 
            resources.ApplyResources(this.AnalyzeOutputText, "AnalyzeOutputText");
            this.AnalyzeOutputText.Name = "AnalyzeOutputText";
            this.AnalyzeOutputText.ReadOnly = true;
            // 
            // DebugLogAnalyzer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ScanLogButton);
            this.Controls.Add(this.IssuesFoundGroup);
            this.Controls.Add(this.ScanProgressPercent);
            this.Controls.Add(this.ScanProgressBar);
            this.Controls.Add(this.ScanProgressLabel);
            this.Controls.Add(this.SelectDebugLogButton);
            this.Controls.Add(this.DebugLogPath);
            this.Controls.Add(this.PathNameLabel);
            this.Controls.Add(this.InfoHeaderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebugLogAnalyzer";
            this.IssuesFoundGroup.ResumeLayout(false);
            this.IssuesFoundGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoHeaderLabel;
        private System.Windows.Forms.Label PathNameLabel;
        private System.Windows.Forms.TextBox DebugLogPath;
        private System.Windows.Forms.Button SelectDebugLogButton;
        private System.Windows.Forms.Label ScanProgressLabel;
        private System.Windows.Forms.ProgressBar ScanProgressBar;
        private System.Windows.Forms.Label ScanProgressPercent;
        private System.Windows.Forms.GroupBox IssuesFoundGroup;
        private System.Windows.Forms.Button ScanLogButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox AnalyzeOutputText;
    }
}