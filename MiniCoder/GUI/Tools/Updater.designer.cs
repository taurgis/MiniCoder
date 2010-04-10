namespace MiniTech.MiniCoder.GUI.External
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updater));
            this.downloadProgress = new System.Windows.Forms.ProgressBar();
            this.updateLog = new System.Windows.Forms.TextBox();
            this.applicationTabs = new System.Windows.Forms.TabControl();
            this.coreTab = new System.Windows.Forms.TabPage();
            this.coreList = new System.Windows.Forms.ListView();
            this.colUpdate = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colExistingVersion = new System.Windows.Forms.ColumnHeader();
            this.colLatestVersion = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.appMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ignoreUpdatesMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.stopIgnoringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginTab = new System.Windows.Forms.TabPage();
            this.pluginsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.audioTab = new System.Windows.Forms.TabPage();
            this.audioList = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.videoTab = new System.Windows.Forms.TabPage();
            this.videoList = new System.Windows.Forms.ListView();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
            this.muxTab = new System.Windows.Forms.TabPage();
            this.muxingList = new System.Windows.Forms.ListView();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.otherTab = new System.Windows.Forms.TabPage();
            this.otherList = new System.Windows.Forms.ListView();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.cancelButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.customPath = new System.Windows.Forms.Button();
            this.applicationTabs.SuspendLayout();
            this.coreTab.SuspendLayout();
            this.appMenu.SuspendLayout();
            this.pluginTab.SuspendLayout();
            this.audioTab.SuspendLayout();
            this.videoTab.SuspendLayout();
            this.muxTab.SuspendLayout();
            this.otherTab.SuspendLayout();
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
            this.updateLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.updateLog.Size = new System.Drawing.Size(529, 56);
            this.updateLog.TabIndex = 1;
            // 
            // applicationTabs
            // 
            this.applicationTabs.Controls.Add(this.coreTab);
            this.applicationTabs.Controls.Add(this.pluginTab);
            this.applicationTabs.Controls.Add(this.audioTab);
            this.applicationTabs.Controls.Add(this.videoTab);
            this.applicationTabs.Controls.Add(this.muxTab);
            this.applicationTabs.Controls.Add(this.otherTab);
            this.applicationTabs.Location = new System.Drawing.Point(12, 7);
            this.applicationTabs.Name = "applicationTabs";
            this.applicationTabs.SelectedIndex = 0;
            this.applicationTabs.Size = new System.Drawing.Size(529, 196);
            this.applicationTabs.TabIndex = 2;
            // 
            // coreTab
            // 
            this.coreTab.Controls.Add(this.coreList);
            this.coreTab.Location = new System.Drawing.Point(4, 22);
            this.coreTab.Name = "coreTab";
            this.coreTab.Padding = new System.Windows.Forms.Padding(3);
            this.coreTab.Size = new System.Drawing.Size(521, 170);
            this.coreTab.TabIndex = 0;
            this.coreTab.Text = "Core";
            this.coreTab.UseVisualStyleBackColor = true;
            // 
            // coreList
            // 
            this.coreList.CheckBoxes = true;
            this.coreList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUpdate,
            this.colName,
            this.colExistingVersion,
            this.colLatestVersion,
            this.colStatus});
            this.coreList.ContextMenuStrip = this.appMenu;
            this.coreList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coreList.FullRowSelect = true;
            this.coreList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.coreList.Location = new System.Drawing.Point(3, 3);
            this.coreList.Name = "coreList";
            this.coreList.Size = new System.Drawing.Size(515, 164);
            this.coreList.TabIndex = 6;
            this.coreList.UseCompatibleStateImageBehavior = false;
            this.coreList.View = System.Windows.Forms.View.Details;
            // 
            // colUpdate
            // 
            this.colUpdate.Text = "Update";
            this.colUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colUpdate.Width = 50;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 100;
            // 
            // colExistingVersion
            // 
            this.colExistingVersion.Text = "Existing Version";
            this.colExistingVersion.Width = 100;
            // 
            // colLatestVersion
            // 
            this.colLatestVersion.Text = "Latest Version";
            this.colLatestVersion.Width = 100;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 135;
            // 
            // appMenu
            // 
            this.appMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ignoreUpdatesMenuStrip,
            this.stopIgnoringToolStripMenuItem});
            this.appMenu.Name = "appMenu";
            this.appMenu.Size = new System.Drawing.Size(161, 48);
            // 
            // ignoreUpdatesMenuStrip
            // 
            this.ignoreUpdatesMenuStrip.Name = "ignoreUpdatesMenuStrip";
            this.ignoreUpdatesMenuStrip.Size = new System.Drawing.Size(160, 22);
            this.ignoreUpdatesMenuStrip.Text = "Ignore Updates";
            this.ignoreUpdatesMenuStrip.Click += new System.EventHandler(this.ignoreUpdatesMenuStrip_Click);
            // 
            // stopIgnoringToolStripMenuItem
            // 
            this.stopIgnoringToolStripMenuItem.Name = "stopIgnoringToolStripMenuItem";
            this.stopIgnoringToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.stopIgnoringToolStripMenuItem.Text = "Stop Ignoring";
            this.stopIgnoringToolStripMenuItem.Click += new System.EventHandler(this.stopIgnoringToolStripMenuItem_Click);
            // 
            // pluginTab
            // 
            this.pluginTab.Controls.Add(this.pluginsList);
            this.pluginTab.Location = new System.Drawing.Point(4, 22);
            this.pluginTab.Name = "pluginTab";
            this.pluginTab.Padding = new System.Windows.Forms.Padding(3);
            this.pluginTab.Size = new System.Drawing.Size(521, 170);
            this.pluginTab.TabIndex = 1;
            this.pluginTab.Text = "Plugins";
            this.pluginTab.UseVisualStyleBackColor = true;
            // 
            // pluginsList
            // 
            this.pluginsList.CheckBoxes = true;
            this.pluginsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.pluginsList.ContextMenuStrip = this.appMenu;
            this.pluginsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pluginsList.FullRowSelect = true;
            this.pluginsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.pluginsList.Location = new System.Drawing.Point(3, 3);
            this.pluginsList.Name = "pluginsList";
            this.pluginsList.Size = new System.Drawing.Size(515, 164);
            this.pluginsList.TabIndex = 7;
            this.pluginsList.UseCompatibleStateImageBehavior = false;
            this.pluginsList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Update";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Existing Version";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Latest Version";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status";
            this.columnHeader5.Width = 135;
            // 
            // audioTab
            // 
            this.audioTab.Controls.Add(this.audioList);
            this.audioTab.Location = new System.Drawing.Point(4, 22);
            this.audioTab.Name = "audioTab";
            this.audioTab.Size = new System.Drawing.Size(521, 170);
            this.audioTab.TabIndex = 2;
            this.audioTab.Text = "Audio";
            this.audioTab.UseVisualStyleBackColor = true;
            // 
            // audioList
            // 
            this.audioList.CheckBoxes = true;
            this.audioList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.audioList.ContextMenuStrip = this.appMenu;
            this.audioList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audioList.FullRowSelect = true;
            this.audioList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.audioList.Location = new System.Drawing.Point(0, 0);
            this.audioList.Name = "audioList";
            this.audioList.Size = new System.Drawing.Size(521, 170);
            this.audioList.TabIndex = 7;
            this.audioList.UseCompatibleStateImageBehavior = false;
            this.audioList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Update";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 50;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Name";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Existing Version";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Latest Version";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Status";
            this.columnHeader10.Width = 135;
            // 
            // videoTab
            // 
            this.videoTab.Controls.Add(this.videoList);
            this.videoTab.Location = new System.Drawing.Point(4, 22);
            this.videoTab.Name = "videoTab";
            this.videoTab.Size = new System.Drawing.Size(521, 170);
            this.videoTab.TabIndex = 3;
            this.videoTab.Text = "Video";
            this.videoTab.UseVisualStyleBackColor = true;
            // 
            // videoList
            // 
            this.videoList.CheckBoxes = true;
            this.videoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25});
            this.videoList.ContextMenuStrip = this.appMenu;
            this.videoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoList.FullRowSelect = true;
            this.videoList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.videoList.Location = new System.Drawing.Point(0, 0);
            this.videoList.Name = "videoList";
            this.videoList.Size = new System.Drawing.Size(521, 170);
            this.videoList.TabIndex = 9;
            this.videoList.UseCompatibleStateImageBehavior = false;
            this.videoList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Update";
            this.columnHeader21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader21.Width = 50;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Name";
            this.columnHeader22.Width = 100;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Existing Version";
            this.columnHeader23.Width = 100;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Latest Version";
            this.columnHeader24.Width = 100;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Status";
            this.columnHeader25.Width = 135;
            // 
            // muxTab
            // 
            this.muxTab.Controls.Add(this.muxingList);
            this.muxTab.Location = new System.Drawing.Point(4, 22);
            this.muxTab.Name = "muxTab";
            this.muxTab.Size = new System.Drawing.Size(521, 170);
            this.muxTab.TabIndex = 4;
            this.muxTab.Text = "Muxing/Demuxing";
            this.muxTab.UseVisualStyleBackColor = true;
            // 
            // muxingList
            // 
            this.muxingList.CheckBoxes = true;
            this.muxingList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.muxingList.ContextMenuStrip = this.appMenu;
            this.muxingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.muxingList.FullRowSelect = true;
            this.muxingList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.muxingList.Location = new System.Drawing.Point(0, 0);
            this.muxingList.Name = "muxingList";
            this.muxingList.Size = new System.Drawing.Size(521, 170);
            this.muxingList.TabIndex = 7;
            this.muxingList.UseCompatibleStateImageBehavior = false;
            this.muxingList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Update";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 50;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Name";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Existing Version";
            this.columnHeader13.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Latest Version";
            this.columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Status";
            this.columnHeader15.Width = 135;
            // 
            // otherTab
            // 
            this.otherTab.Controls.Add(this.otherList);
            this.otherTab.Location = new System.Drawing.Point(4, 22);
            this.otherTab.Name = "otherTab";
            this.otherTab.Size = new System.Drawing.Size(521, 170);
            this.otherTab.TabIndex = 5;
            this.otherTab.Text = "Other";
            this.otherTab.UseVisualStyleBackColor = true;
            // 
            // otherList
            // 
            this.otherList.CheckBoxes = true;
            this.otherList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.otherList.ContextMenuStrip = this.appMenu;
            this.otherList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otherList.FullRowSelect = true;
            this.otherList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.otherList.Location = new System.Drawing.Point(0, 0);
            this.otherList.Name = "otherList";
            this.otherList.Size = new System.Drawing.Size(521, 170);
            this.otherList.TabIndex = 7;
            this.otherList.UseCompatibleStateImageBehavior = false;
            this.otherList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Update";
            this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader16.Width = 50;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Name";
            this.columnHeader17.Width = 100;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Existing Version";
            this.columnHeader18.Width = 100;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Latest Version";
            this.columnHeader19.Width = 100;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Status";
            this.columnHeader20.Width = 135;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(466, 300);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(385, 300);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 4;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // customPath
            // 
            this.customPath.AutoSize = true;
            this.customPath.Location = new System.Drawing.Point(12, 299);
            this.customPath.Name = "customPath";
            this.customPath.Size = new System.Drawing.Size(87, 23);
            this.customPath.TabIndex = 5;
            this.customPath.Text = "Custom Path";
            this.customPath.UseVisualStyleBackColor = true;
            this.customPath.Click += new System.EventHandler(this.customPath_Click);
            // 
            // Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 329);
            this.Controls.Add(this.customPath);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applicationTabs);
            this.Controls.Add(this.updateLog);
            this.Controls.Add(this.downloadProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Updater";
            this.Text = "MiniCoder Updater";
            this.Load += new System.EventHandler(this.Updater_Load);
            this.applicationTabs.ResumeLayout(false);
            this.coreTab.ResumeLayout(false);
            this.appMenu.ResumeLayout(false);
            this.pluginTab.ResumeLayout(false);
            this.audioTab.ResumeLayout(false);
            this.videoTab.ResumeLayout(false);
            this.muxTab.ResumeLayout(false);
            this.otherTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar downloadProgress;
        private System.Windows.Forms.TextBox updateLog;
        private System.Windows.Forms.TabControl applicationTabs;
        private System.Windows.Forms.TabPage coreTab;
        private System.Windows.Forms.TabPage pluginTab;
        private System.Windows.Forms.TabPage audioTab;
        private System.Windows.Forms.TabPage videoTab;
        private System.Windows.Forms.TabPage muxTab;
        private System.Windows.Forms.TabPage otherTab;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.ListView coreList;
        private System.Windows.Forms.ColumnHeader colUpdate;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colExistingVersion;
        private System.Windows.Forms.ColumnHeader colLatestVersion;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ListView pluginsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView audioList;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ListView muxingList;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ListView otherList;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ListView videoList;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.Button customPath;
        private System.Windows.Forms.ContextMenuStrip appMenu;
        private System.Windows.Forms.ToolStripMenuItem ignoreUpdatesMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem stopIgnoringToolStripMenuItem;
    }
}

