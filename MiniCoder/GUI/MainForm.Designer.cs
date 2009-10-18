using MiniCOder.GUI.Controls;

namespace MiniCoder.GUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainTabPage = new System.Windows.Forms.TabControl();
            this.inputTab = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.cbAfterEncode = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.addFile = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inputList = new System.Windows.Forms.ListView();
            this.inputHeader = new System.Windows.Forms.ColumnHeader();
            this.statusHeader = new System.Windows.Forms.ColumnHeader();
            this.inputPath = new System.Windows.Forms.ColumnHeader();
            this.inputMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startButton = new System.Windows.Forms.Button();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.logTab = new System.Windows.Forms.TabPage();
            this.logView = new System.Windows.Forms.TreeView();
            this.logMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.aboutTab = new System.Windows.Forms.TabPage();
            this.newsList = new System.Windows.Forms.ListView();
            this.dateHeader = new System.Windows.Forms.ColumnHeader();
            this.newsHeader = new System.Windows.Forms.ColumnHeader();
            this.urlHeader = new System.Windows.Forms.ColumnHeader();
            this.infoLabel = new System.Windows.Forms.Label();
            this.notifyMiniCoder = new System.Windows.Forms.NotifyIcon(this.components);
            this.encodeSettings = new MiniCOder.GUI.Controls.EncodeSettings();
            this.encodeOptions = new MiniCOder.GUI.Controls.EncodeOptions();
            this.mainTabPage.SuspendLayout();
            this.inputTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.inputMenu.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.optionsTab.SuspendLayout();
            this.logTab.SuspendLayout();
            this.logMenu.SuspendLayout();
            this.aboutTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabPage
            // 
            this.mainTabPage.Controls.Add(this.inputTab);
            this.mainTabPage.Controls.Add(this.settingsTab);
            this.mainTabPage.Controls.Add(this.optionsTab);
            this.mainTabPage.Controls.Add(this.logTab);
            this.mainTabPage.Controls.Add(this.aboutTab);
            this.mainTabPage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTabPage.Location = new System.Drawing.Point(2, 10);
            this.mainTabPage.Name = "mainTabPage";
            this.mainTabPage.SelectedIndex = 0;
            this.mainTabPage.Size = new System.Drawing.Size(410, 385);
            this.mainTabPage.TabIndex = 1;
            // 
            // inputTab
            // 
            this.inputTab.Controls.Add(this.label7);
            this.inputTab.Controls.Add(this.cbAfterEncode);
            this.inputTab.Controls.Add(this.btnDelete);
            this.inputTab.Controls.Add(this.addFile);
            this.inputTab.Controls.Add(this.stopButton);
            this.inputTab.Controls.Add(this.groupBox1);
            this.inputTab.Controls.Add(this.startButton);
            this.inputTab.Location = new System.Drawing.Point(4, 25);
            this.inputTab.Name = "inputTab";
            this.inputTab.Padding = new System.Windows.Forms.Padding(3);
            this.inputTab.Size = new System.Drawing.Size(402, 356);
            this.inputTab.TabIndex = 0;
            this.inputTab.Text = "Input";
            this.inputTab.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(186, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "When done";
            // 
            // cbAfterEncode
            // 
            this.cbAfterEncode.DisplayMember = "Do Nothing";
            this.cbAfterEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAfterEncode.FormattingEnabled = true;
            this.cbAfterEncode.Items.AddRange(new object[] {
            "Do Nothing",
            "Hibernate",
            "Standby",
            "Shutdown"});
            this.cbAfterEncode.Location = new System.Drawing.Point(263, 328);
            this.cbAfterEncode.Name = "cbAfterEncode";
            this.cbAfterEncode.Size = new System.Drawing.Size(123, 24);
            this.cbAfterEncode.TabIndex = 9;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(39, 295);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(21, 25);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "x";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // addFile
            // 
            this.addFile.Location = new System.Drawing.Point(12, 295);
            this.addFile.Name = "addFile";
            this.addFile.Size = new System.Drawing.Size(21, 25);
            this.addFile.TabIndex = 7;
            this.addFile.Text = "+";
            this.addFile.UseVisualStyleBackColor = true;
            this.addFile.Click += new System.EventHandler(this.addFile_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(296, 295);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(90, 27);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inputList);
            this.groupBox1.Location = new System.Drawing.Point(6, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 282);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // inputList
            // 
            this.inputList.AllowDrop = true;
            this.inputList.CheckBoxes = true;
            this.inputList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.inputHeader,
            this.statusHeader,
            this.inputPath});
            this.inputList.ContextMenuStrip = this.inputMenu;
            this.inputList.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputList.FullRowSelect = true;
            this.inputList.GridLines = true;
            this.inputList.Location = new System.Drawing.Point(6, 12);
            this.inputList.Name = "inputList";
            this.inputList.ShowItemToolTips = true;
            this.inputList.Size = new System.Drawing.Size(374, 265);
            this.inputList.TabIndex = 2;
            this.inputList.UseCompatibleStateImageBehavior = false;
            this.inputList.View = System.Windows.Forms.View.Details;
            this.inputList.DragDrop += new System.Windows.Forms.DragEventHandler(this.inputList_DragDrop);
            this.inputList.DragEnter += new System.Windows.Forms.DragEventHandler(this.inputList_DragEnter);
            // 
            // inputHeader
            // 
            this.inputHeader.Text = "Input (Mark if file has VFR)";
            this.inputHeader.Width = 265;
            // 
            // statusHeader
            // 
            this.statusHeader.Text = "Status";
            // 
            // inputPath
            // 
            this.inputPath.Text = "";
            this.inputPath.Width = 0;
            // 
            // inputMenu
            // 
            this.inputMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenu,
            this.removeMenuItem,
            this.toolStripMenuItem2,
            this.clearMenuItem});
            this.inputMenu.Name = "inputMenu";
            this.inputMenu.Size = new System.Drawing.Size(125, 76);
            // 
            // addMenu
            // 
            this.addMenu.Name = "addMenu";
            this.addMenu.Size = new System.Drawing.Size(124, 22);
            this.addMenu.Text = "Add";
            this.addMenu.Click += new System.EventHandler(this.addMenu_Click);
            // 
            // removeMenuItem
            // 
            this.removeMenuItem.Name = "removeMenuItem";
            this.removeMenuItem.Size = new System.Drawing.Size(124, 22);
            this.removeMenuItem.Text = "Remove";
            this.removeMenuItem.Click += new System.EventHandler(this.removeMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(121, 6);
            // 
            // clearMenuItem
            // 
            this.clearMenuItem.Name = "clearMenuItem";
            this.clearMenuItem.Size = new System.Drawing.Size(124, 22);
            this.clearMenuItem.Text = "Clear";
            this.clearMenuItem.Click += new System.EventHandler(this.clearMenuItem_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(200, 295);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(90, 27);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.encodeSettings);
            this.settingsTab.Location = new System.Drawing.Point(4, 25);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(402, 356);
            this.settingsTab.TabIndex = 1;
            this.settingsTab.Text = "Settings";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // optionsTab
            // 
            this.optionsTab.Controls.Add(this.encodeOptions);
            this.optionsTab.Location = new System.Drawing.Point(4, 25);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Size = new System.Drawing.Size(402, 356);
            this.optionsTab.TabIndex = 5;
            this.optionsTab.Text = "Options";
            this.optionsTab.UseVisualStyleBackColor = true;
            // 
            // logTab
            // 
            this.logTab.Controls.Add(this.logView);
            this.logTab.Location = new System.Drawing.Point(4, 25);
            this.logTab.Name = "logTab";
            this.logTab.Padding = new System.Windows.Forms.Padding(3);
            this.logTab.Size = new System.Drawing.Size(402, 356);
            this.logTab.TabIndex = 3;
            this.logTab.Text = "Log";
            this.logTab.UseVisualStyleBackColor = true;
            // 
            // logView
            // 
            this.logView.ContextMenuStrip = this.logMenu;
            this.logView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logView.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logView.ImageIndex = 1;
            this.logView.ImageList = this.iconList;
            this.logView.Location = new System.Drawing.Point(3, 3);
            this.logView.Name = "logView";
            this.logView.SelectedImageIndex = 0;
            this.logView.Size = new System.Drawing.Size(396, 350);
            this.logView.TabIndex = 1;
            // 
            // logMenu
            // 
            this.logMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.logMenu.Name = "logMenu";
            this.logMenu.Size = new System.Drawing.Size(111, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "info.png");
            this.iconList.Images.SetKeyName(1, "default.png");
            this.iconList.Images.SetKeyName(2, "error.png");
            // 
            // aboutTab
            // 
            this.aboutTab.Controls.Add(this.newsList);
            this.aboutTab.Location = new System.Drawing.Point(4, 25);
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.Size = new System.Drawing.Size(402, 356);
            this.aboutTab.TabIndex = 4;
            this.aboutTab.Text = "News";
            this.aboutTab.UseVisualStyleBackColor = true;
            // 
            // newsList
            // 
            this.newsList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.newsList.AutoArrange = false;
            this.newsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dateHeader,
            this.newsHeader,
            this.urlHeader});
            this.newsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsList.FullRowSelect = true;
            this.newsList.GridLines = true;
            this.newsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.newsList.Location = new System.Drawing.Point(0, 0);
            this.newsList.Name = "newsList";
            this.newsList.Size = new System.Drawing.Size(402, 356);
            this.newsList.TabIndex = 1;
            this.newsList.UseCompatibleStateImageBehavior = false;
            this.newsList.View = System.Windows.Forms.View.Details;
            // 
            // dateHeader
            // 
            this.dateHeader.Text = "Date";
            this.dateHeader.Width = 72;
            // 
            // newsHeader
            // 
            this.newsHeader.Text = "News";
            this.newsHeader.Width = 315;
            // 
            // urlHeader
            // 
            this.urlHeader.Width = 0;
            // 
            // infoLabel
            // 
            this.infoLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.Location = new System.Drawing.Point(3, 398);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(410, 22);
            this.infoLabel.TabIndex = 2;
            this.infoLabel.Text = "GUI Ready";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notifyMiniCoder
            // 
            this.notifyMiniCoder.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyMiniCoder.Icon")));
            this.notifyMiniCoder.Text = "MiniCoder";
            this.notifyMiniCoder.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyMiniCoder_MouseDoubleClick);
            // 
            // encodeSettings
            // 
            this.encodeSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.encodeSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.encodeSettings.Location = new System.Drawing.Point(3, 3);
            this.encodeSettings.Margin = new System.Windows.Forms.Padding(0);
            this.encodeSettings.Name = "encodeSettings";
            this.encodeSettings.Size = new System.Drawing.Size(396, 350);
            this.encodeSettings.TabIndex = 0;
            // 
            // encodeOptions
            // 
            this.encodeOptions.Location = new System.Drawing.Point(0, 0);
            this.encodeOptions.Name = "encodeOptions";
            this.encodeOptions.Size = new System.Drawing.Size(385, 309);
            this.encodeOptions.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 421);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.mainTabPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MiniCoder - Encoding GUI";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.mainTabPage.ResumeLayout(false);
            this.inputTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.inputMenu.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            this.optionsTab.ResumeLayout(false);
            this.logTab.ResumeLayout(false);
            this.logMenu.ResumeLayout(false);
            this.aboutTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

     

     

        #endregion

        private System.Windows.Forms.TabControl mainTabPage;
        private System.Windows.Forms.TabPage inputTab;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbAfterEncode;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button addFile;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView inputList;
        private System.Windows.Forms.ColumnHeader inputHeader;
        private System.Windows.Forms.ColumnHeader statusHeader;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.TabPage optionsTab;
        private System.Windows.Forms.TabPage logTab;
        private System.Windows.Forms.TabPage aboutTab;
        private System.Windows.Forms.ListView newsList;
        private System.Windows.Forms.ColumnHeader dateHeader;
        private System.Windows.Forms.ColumnHeader newsHeader;
        private System.Windows.Forms.ColumnHeader urlHeader;
        private System.Windows.Forms.ColumnHeader inputPath;
        private System.Windows.Forms.ContextMenuStrip inputMenu;
        private System.Windows.Forms.ToolStripMenuItem addMenu;
        private System.Windows.Forms.ToolStripMenuItem removeMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clearMenuItem;
        private EncodeSettings encodeSettings;
        private EncodeOptions encodeOptions;
        private System.Windows.Forms.TreeView logView;
        public System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.ContextMenuStrip logMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyMiniCoder;
        private System.Windows.Forms.ImageList iconList;
    }
}

