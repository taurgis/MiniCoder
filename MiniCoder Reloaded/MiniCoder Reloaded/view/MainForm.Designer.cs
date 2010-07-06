namespace MiniCoder_Reloaded
{
    partial class MainForm
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
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioTabDefault = new System.Windows.Forms.TabPage();
            this.audioTabs = new System.Windows.Forms.TabControl();
            this.topMenu.SuspendLayout();
            this.audioTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 422);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(453, 22);
            this.statusBar.TabIndex = 0;
            // 
            // topMenu
            // 
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Size = new System.Drawing.Size(453, 24);
            this.topMenu.TabIndex = 1;
            this.topMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.toolStripMenuItem1,
            this.exitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitMenuItem.Text = "Exit";
            // 
            // audioTabDefault
            // 
            this.audioTabDefault.Location = new System.Drawing.Point(4, 22);
            this.audioTabDefault.Name = "audioTabDefault";
            this.audioTabDefault.Padding = new System.Windows.Forms.Padding(3);
            this.audioTabDefault.Size = new System.Drawing.Size(445, 171);
            this.audioTabDefault.TabIndex = 0;
            this.audioTabDefault.Text = "Track 1";
            this.audioTabDefault.UseVisualStyleBackColor = true;
            // 
            // audioTabs
            // 
            this.audioTabs.Controls.Add(this.audioTabDefault);
            this.audioTabs.Location = new System.Drawing.Point(0, 222);
            this.audioTabs.Name = "audioTabs";
            this.audioTabs.SelectedIndex = 0;
            this.audioTabs.Size = new System.Drawing.Size(453, 197);
            this.audioTabs.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 444);
            this.Controls.Add(this.audioTabs);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.topMenu);
            this.MainMenuStrip = this.topMenu;
            this.Name = "MainForm";
            this.Text = "MiniCoder Reloaded";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.audioTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.TabPage audioTabDefault;
        private System.Windows.Forms.TabControl audioTabs;
    }
}

