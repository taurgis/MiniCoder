using MiniTech.MiniCoder.GUI.Controls;

namespace MiniTech.MiniCoder.Core.Other.Logging
{
    partial class LogbookControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogbookControl));
            this.debugIcon = new System.Windows.Forms.PictureBox();
            this.logContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoImage = new System.Windows.Forms.PictureBox();
            this.errorImage = new System.Windows.Forms.PictureBox();
            this.pnlSystemInfo = new System.Windows.Forms.Panel();
            this.sysInfo = new MiniTech.MiniCoder.GUI.Controls.FadingList();
            this.errorsPanel = new System.Windows.Forms.Panel();
            this.errorInfo = new MiniTech.MiniCoder.GUI.Controls.FadingList();
            this.debugPanel = new System.Windows.Forms.Panel();
            this.debugInfo = new MiniTech.MiniCoder.GUI.Controls.FadingList();
            this.videoImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.videoInfo = new MiniTech.MiniCoder.GUI.Controls.FadingList();
            ((System.ComponentModel.ISupportInitialize)(this.debugIcon)).BeginInit();
            this.logContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorImage)).BeginInit();
            this.pnlSystemInfo.SuspendLayout();
            this.errorsPanel.SuspendLayout();
            this.debugPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // debugIcon
            // 
            this.debugIcon.BackColor = System.Drawing.Color.Transparent;
            this.debugIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("debugIcon.BackgroundImage")));
            this.debugIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.debugIcon.ContextMenuStrip = this.logContext;
            this.debugIcon.Location = new System.Drawing.Point(0, 172);
            this.debugIcon.Name = "debugIcon";
            this.debugIcon.Size = new System.Drawing.Size(80, 80);
            this.debugIcon.TabIndex = 2;
            this.debugIcon.TabStop = false;
            // 
            // logContext
            // 
            this.logContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewLogToolStripMenuItem,
            this.sendReportToolStripMenuItem});
            this.logContext.Name = "logContext";
            this.logContext.Size = new System.Drawing.Size(153, 70);
            // 
            // viewLogToolStripMenuItem
            // 
            this.viewLogToolStripMenuItem.Name = "viewLogToolStripMenuItem";
            this.viewLogToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewLogToolStripMenuItem.Text = "View Log";
            this.viewLogToolStripMenuItem.Click += new System.EventHandler(this.viewLogToolStripMenuItem_Click);
            // 
            // sendReportToolStripMenuItem
            // 
            this.sendReportToolStripMenuItem.Name = "sendReportToolStripMenuItem";
            this.sendReportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sendReportToolStripMenuItem.Text = "Send report";
            this.sendReportToolStripMenuItem.Click += new System.EventHandler(this.sendReportToolStripMenuItem_Click);
            // 
            // infoImage
            // 
            this.infoImage.BackColor = System.Drawing.Color.Transparent;
            this.infoImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("infoImage.BackgroundImage")));
            this.infoImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.infoImage.ContextMenuStrip = this.logContext;
            this.infoImage.Location = new System.Drawing.Point(0, 0);
            this.infoImage.Name = "infoImage";
            this.infoImage.Size = new System.Drawing.Size(80, 80);
            this.infoImage.TabIndex = 1;
            this.infoImage.TabStop = false;
            // 
            // errorImage
            // 
            this.errorImage.BackColor = System.Drawing.Color.Transparent;
            this.errorImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("errorImage.BackgroundImage")));
            this.errorImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.errorImage.ContextMenuStrip = this.logContext;
            this.errorImage.Location = new System.Drawing.Point(0, 86);
            this.errorImage.Name = "errorImage";
            this.errorImage.Size = new System.Drawing.Size(80, 80);
            this.errorImage.TabIndex = 0;
            this.errorImage.TabStop = false;
            // 
            // pnlSystemInfo
            // 
            this.pnlSystemInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSystemInfo.Controls.Add(this.sysInfo);
            this.pnlSystemInfo.Location = new System.Drawing.Point(86, 0);
            this.pnlSystemInfo.Name = "pnlSystemInfo";
            this.pnlSystemInfo.Size = new System.Drawing.Size(310, 80);
            this.pnlSystemInfo.TabIndex = 4;
            // 
            // sysInfo
            // 
            this.sysInfo.BackColor = System.Drawing.Color.White;
            this.sysInfo.ContextMenuStrip = this.logContext;
            this.sysInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sysInfo.Location = new System.Drawing.Point(0, 0);
            this.sysInfo.Name = "sysInfo";
            this.sysInfo.Size = new System.Drawing.Size(308, 78);
            this.sysInfo.TabIndex = 0;
            // 
            // errorsPanel
            // 
            this.errorsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.errorsPanel.Controls.Add(this.errorInfo);
            this.errorsPanel.Location = new System.Drawing.Point(86, 86);
            this.errorsPanel.Name = "errorsPanel";
            this.errorsPanel.Size = new System.Drawing.Size(310, 80);
            this.errorsPanel.TabIndex = 5;
            // 
            // errorInfo
            // 
            this.errorInfo.BackColor = System.Drawing.Color.White;
            this.errorInfo.ContextMenuStrip = this.logContext;
            this.errorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorInfo.Location = new System.Drawing.Point(0, 0);
            this.errorInfo.Name = "errorInfo";
            this.errorInfo.Size = new System.Drawing.Size(308, 78);
            this.errorInfo.TabIndex = 0;
            // 
            // debugPanel
            // 
            this.debugPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.debugPanel.Controls.Add(this.debugInfo);
            this.debugPanel.Location = new System.Drawing.Point(86, 172);
            this.debugPanel.Name = "debugPanel";
            this.debugPanel.Size = new System.Drawing.Size(310, 80);
            this.debugPanel.TabIndex = 6;
            // 
            // debugInfo
            // 
            this.debugInfo.BackColor = System.Drawing.Color.White;
            this.debugInfo.ContextMenuStrip = this.logContext;
            this.debugInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugInfo.Location = new System.Drawing.Point(0, 0);
            this.debugInfo.Name = "debugInfo";
            this.debugInfo.Size = new System.Drawing.Size(308, 78);
            this.debugInfo.TabIndex = 0;
            // 
            // videoImage
            // 
            this.videoImage.BackColor = System.Drawing.Color.Transparent;
            this.videoImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("videoImage.BackgroundImage")));
            this.videoImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.videoImage.ContextMenuStrip = this.logContext;
            this.videoImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("videoImage.InitialImage")));
            this.videoImage.Location = new System.Drawing.Point(0, 259);
            this.videoImage.Name = "videoImage";
            this.videoImage.Size = new System.Drawing.Size(80, 80);
            this.videoImage.TabIndex = 7;
            this.videoImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.videoInfo);
            this.panel1.Location = new System.Drawing.Point(86, 259);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 80);
            this.panel1.TabIndex = 8;
            // 
            // videoInfo
            // 
            this.videoInfo.BackColor = System.Drawing.Color.White;
            this.videoInfo.ContextMenuStrip = this.logContext;
            this.videoInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoInfo.Location = new System.Drawing.Point(0, 0);
            this.videoInfo.Name = "videoInfo";
            this.videoInfo.Size = new System.Drawing.Size(308, 78);
            this.videoInfo.TabIndex = 0;
            // 
            // LogbookControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.videoImage);
            this.Controls.Add(this.debugPanel);
            this.Controls.Add(this.errorsPanel);
            this.Controls.Add(this.pnlSystemInfo);
            this.Controls.Add(this.debugIcon);
            this.Controls.Add(this.infoImage);
            this.Controls.Add(this.errorImage);
            this.Name = "LogbookControl";
            this.Size = new System.Drawing.Size(401, 345);
            ((System.ComponentModel.ISupportInitialize)(this.debugIcon)).EndInit();
            this.logContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.infoImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorImage)).EndInit();
            this.pnlSystemInfo.ResumeLayout(false);
            this.errorsPanel.ResumeLayout(false);
            this.debugPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.videoImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox errorImage;
        private System.Windows.Forms.PictureBox infoImage;
        private System.Windows.Forms.PictureBox debugIcon;
        private System.Windows.Forms.Panel pnlSystemInfo;
        private System.Windows.Forms.Panel errorsPanel;
        private System.Windows.Forms.Panel debugPanel;
        private MiniCoder.GUI.Controls.FadingList sysInfo;
        private MiniCoder.GUI.Controls.FadingList errorInfo;
        private MiniCoder.GUI.Controls.FadingList debugInfo;
        private System.Windows.Forms.PictureBox videoImage;
        private System.Windows.Forms.Panel panel1;
        private FadingList videoInfo;
        private System.Windows.Forms.ContextMenuStrip logContext;
        private System.Windows.Forms.ToolStripMenuItem viewLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendReportToolStripMenuItem;
    }
}
