namespace MCUpdater
{
    partial class Updater
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updater));
            this.downloadProgress = new System.Windows.Forms.ProgressBar();
            this.updateLog = new System.Windows.Forms.TextBox();
            this.programsTab = new System.Windows.Forms.TabControl();
            this.coreTab = new System.Windows.Forms.TabPage();
            this.pluginTab = new System.Windows.Forms.TabPage();
            this.audioTab = new System.Windows.Forms.TabPage();
            this.videoTab = new System.Windows.Forms.TabPage();
            this.muxTab = new System.Windows.Forms.TabPage();
            this.otherTab = new System.Windows.Forms.TabPage();
            this.cancelButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.programsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // downloadProgress
            // 
            this.downloadProgress.Location = new System.Drawing.Point(12, 271);
            this.downloadProgress.Name = "downloadProgress";
            this.downloadProgress.Size = new System.Drawing.Size(529, 23);
            this.downloadProgress.TabIndex = 0;
            // 
            // updateLog
            // 
            this.updateLog.Location = new System.Drawing.Point(12, 209);
            this.updateLog.Multiline = true;
            this.updateLog.Name = "updateLog";
            this.updateLog.Size = new System.Drawing.Size(529, 56);
            this.updateLog.TabIndex = 1;
            // 
            // programsTab
            // 
            this.programsTab.Controls.Add(this.coreTab);
            this.programsTab.Controls.Add(this.pluginTab);
            this.programsTab.Controls.Add(this.audioTab);
            this.programsTab.Controls.Add(this.videoTab);
            this.programsTab.Controls.Add(this.muxTab);
            this.programsTab.Controls.Add(this.otherTab);
            this.programsTab.Location = new System.Drawing.Point(12, 7);
            this.programsTab.Name = "programsTab";
            this.programsTab.SelectedIndex = 0;
            this.programsTab.Size = new System.Drawing.Size(529, 196);
            this.programsTab.TabIndex = 2;
            // 
            // coreTab
            // 
            this.coreTab.Location = new System.Drawing.Point(4, 22);
            this.coreTab.Name = "coreTab";
            this.coreTab.Padding = new System.Windows.Forms.Padding(3);
            this.coreTab.Size = new System.Drawing.Size(521, 170);
            this.coreTab.TabIndex = 0;
            this.coreTab.Text = "Core";
            this.coreTab.UseVisualStyleBackColor = true;
            // 
            // pluginTab
            // 
            this.pluginTab.Location = new System.Drawing.Point(4, 22);
            this.pluginTab.Name = "pluginTab";
            this.pluginTab.Padding = new System.Windows.Forms.Padding(3);
            this.pluginTab.Size = new System.Drawing.Size(521, 170);
            this.pluginTab.TabIndex = 1;
            this.pluginTab.Text = "Plugins";
            this.pluginTab.UseVisualStyleBackColor = true;
            // 
            // audioTab
            // 
            this.audioTab.Location = new System.Drawing.Point(4, 22);
            this.audioTab.Name = "audioTab";
            this.audioTab.Size = new System.Drawing.Size(521, 170);
            this.audioTab.TabIndex = 2;
            this.audioTab.Text = "Audio";
            this.audioTab.UseVisualStyleBackColor = true;
            // 
            // videoTab
            // 
            this.videoTab.Location = new System.Drawing.Point(4, 22);
            this.videoTab.Name = "videoTab";
            this.videoTab.Size = new System.Drawing.Size(521, 170);
            this.videoTab.TabIndex = 3;
            this.videoTab.Text = "Video";
            this.videoTab.UseVisualStyleBackColor = true;
            // 
            // muxTab
            // 
            this.muxTab.Location = new System.Drawing.Point(4, 22);
            this.muxTab.Name = "muxTab";
            this.muxTab.Size = new System.Drawing.Size(521, 170);
            this.muxTab.TabIndex = 4;
            this.muxTab.Text = "Muxing/Demuxing";
            this.muxTab.UseVisualStyleBackColor = true;
            // 
            // otherTab
            // 
            this.otherTab.Location = new System.Drawing.Point(4, 22);
            this.otherTab.Name = "otherTab";
            this.otherTab.Size = new System.Drawing.Size(521, 170);
            this.otherTab.TabIndex = 5;
            this.otherTab.Text = "Other";
            this.otherTab.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(466, 300);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(385, 300);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 4;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 329);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.programsTab);
            this.Controls.Add(this.updateLog);
            this.Controls.Add(this.downloadProgress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Updater";
            this.Text = "MiniCoder Updater";
            this.Load += new System.EventHandler(this.Updater_Load);
            this.programsTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar downloadProgress;
        private System.Windows.Forms.TextBox updateLog;
        private System.Windows.Forms.TabControl programsTab;
        private System.Windows.Forms.TabPage coreTab;
        private System.Windows.Forms.TabPage pluginTab;
        private System.Windows.Forms.TabPage audioTab;
        private System.Windows.Forms.TabPage videoTab;
        private System.Windows.Forms.TabPage muxTab;
        private System.Windows.Forms.TabPage otherTab;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button updateButton;
    }
}

