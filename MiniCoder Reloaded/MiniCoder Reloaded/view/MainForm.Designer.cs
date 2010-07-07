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
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attachmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTab = new System.Windows.Forms.TabControl();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.queueTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectPathButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subtitleTabs = new System.Windows.Forms.TabControl();
            this.subtitleTabDefault = new System.Windows.Forms.TabPage();
            this.audioTabs = new System.Windows.Forms.TabControl();
            this.audioTabDefault = new System.Windows.Forms.TabPage();
            this.logTab = new System.Windows.Forms.TabPage();
            this.topMenu.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.subtitleTabs.SuspendLayout();
            this.audioTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // topMenu
            // 
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.videoToolStripMenuItem});
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
            this.toolStripMenuItem3,
            this.switchInterfaceToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(158, 22);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // switchInterfaceToolStripMenuItem
            // 
            this.switchInterfaceToolStripMenuItem.Name = "switchInterfaceToolStripMenuItem";
            this.switchInterfaceToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.switchInterfaceToolStripMenuItem.Text = "Switch Interface";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exitMenuItem.Text = "Exit";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(155, 6);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attachmentsToolStripMenuItem});
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // attachmentsToolStripMenuItem
            // 
            this.attachmentsToolStripMenuItem.Name = "attachmentsToolStripMenuItem";
            this.attachmentsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.attachmentsToolStripMenuItem.Text = "Attachments";
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.settingsTab);
            this.mainTab.Controls.Add(this.queueTab);
            this.mainTab.Controls.Add(this.logTab);
            this.mainTab.Location = new System.Drawing.Point(0, 27);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(453, 418);
            this.mainTab.TabIndex = 2;
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.groupBox1);
            this.settingsTab.Controls.Add(this.subtitleTabs);
            this.settingsTab.Controls.Add(this.audioTabs);
            this.settingsTab.Location = new System.Drawing.Point(4, 22);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(445, 392);
            this.settingsTab.TabIndex = 0;
            this.settingsTab.Text = "Settings";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // queueTab
            // 
            this.queueTab.Location = new System.Drawing.Point(4, 22);
            this.queueTab.Name = "queueTab";
            this.queueTab.Padding = new System.Windows.Forms.Padding(3);
            this.queueTab.Size = new System.Drawing.Size(445, 392);
            this.queueTab.TabIndex = 1;
            this.queueTab.Text = "Queue";
            this.queueTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.selectPathButton);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(-2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 135);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Video";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "Crop";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(365, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Enqueu";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(365, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(85, 75);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(274, 21);
            this.comboBox3.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Template:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(301, 44);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(140, 21);
            this.comboBox2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Container:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(85, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Target Codec:";
            // 
            // selectPathButton
            // 
            this.selectPathButton.Location = new System.Drawing.Point(415, 17);
            this.selectPathButton.Name = "selectPathButton";
            this.selectPathButton.Size = new System.Drawing.Size(26, 23);
            this.selectPathButton.TabIndex = 5;
            this.selectPathButton.Text = "...";
            this.selectPathButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(325, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "File Path:";
            // 
            // subtitleTabs
            // 
            this.subtitleTabs.Controls.Add(this.subtitleTabDefault);
            this.subtitleTabs.Location = new System.Drawing.Point(-2, 300);
            this.subtitleTabs.Name = "subtitleTabs";
            this.subtitleTabs.SelectedIndex = 0;
            this.subtitleTabs.Size = new System.Drawing.Size(449, 92);
            this.subtitleTabs.TabIndex = 6;
            // 
            // subtitleTabDefault
            // 
            this.subtitleTabDefault.BackColor = System.Drawing.SystemColors.Control;
            this.subtitleTabDefault.Location = new System.Drawing.Point(4, 22);
            this.subtitleTabDefault.Name = "subtitleTabDefault";
            this.subtitleTabDefault.Padding = new System.Windows.Forms.Padding(3);
            this.subtitleTabDefault.Size = new System.Drawing.Size(441, 66);
            this.subtitleTabDefault.TabIndex = 0;
            this.subtitleTabDefault.Text = "Subtitle 1";
            // 
            // audioTabs
            // 
            this.audioTabs.Controls.Add(this.audioTabDefault);
            this.audioTabs.Location = new System.Drawing.Point(-2, 142);
            this.audioTabs.Name = "audioTabs";
            this.audioTabs.SelectedIndex = 0;
            this.audioTabs.Size = new System.Drawing.Size(449, 156);
            this.audioTabs.TabIndex = 5;
            // 
            // audioTabDefault
            // 
            this.audioTabDefault.BackColor = System.Drawing.SystemColors.Control;
            this.audioTabDefault.Location = new System.Drawing.Point(4, 22);
            this.audioTabDefault.Name = "audioTabDefault";
            this.audioTabDefault.Padding = new System.Windows.Forms.Padding(3);
            this.audioTabDefault.Size = new System.Drawing.Size(441, 130);
            this.audioTabDefault.TabIndex = 0;
            this.audioTabDefault.Text = "Track 1";
            // 
            // logTab
            // 
            this.logTab.Location = new System.Drawing.Point(4, 22);
            this.logTab.Name = "logTab";
            this.logTab.Size = new System.Drawing.Size(445, 392);
            this.logTab.TabIndex = 2;
            this.logTab.Text = "Log";
            this.logTab.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 444);
            this.Controls.Add(this.mainTab);
            this.Controls.Add(this.topMenu);
            this.MainMenuStrip = this.topMenu;
            this.Name = "MainForm";
            this.Text = "MiniCoder Reloaded";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.mainTab.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.subtitleTabs.ResumeLayout(false);
            this.audioTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchInterfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attachmentsToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button selectPathButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl subtitleTabs;
        private System.Windows.Forms.TabPage subtitleTabDefault;
        private System.Windows.Forms.TabControl audioTabs;
        private System.Windows.Forms.TabPage audioTabDefault;
        private System.Windows.Forms.TabPage queueTab;
        private System.Windows.Forms.TabPage logTab;
    }
}

