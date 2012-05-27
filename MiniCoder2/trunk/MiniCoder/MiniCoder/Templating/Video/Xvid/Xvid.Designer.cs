namespace MiniCoder2.Templating.Video.Xvid
{
    partial class Xvid
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
            this.Settings = new System.Windows.Forms.GroupBox();
            this.cbProfile = new System.Windows.Forms.ComboBox();
            this.ProfileLabel = new System.Windows.Forms.Label();
            this.nudBFrames = new System.Windows.Forms.NumericUpDown();
            this.BFramesLabel = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.cbMotionSearch = new System.Windows.Forms.ComboBox();
            this.MotionSearchLabel = new System.Windows.Forms.Label();
            this.cbHVSMasking = new System.Windows.Forms.ComboBox();
            this.HVSMaskingLabel = new System.Windows.Forms.Label();
            this.cbVHQMode = new System.Windows.Forms.ComboBox();
            this.VHQLabel = new System.Windows.Forms.Label();
            this.nudThreads = new System.Windows.Forms.NumericUpDown();
            this.ThreadsLabel = new System.Windows.Forms.Label();
            this.nudBitrate = new System.Windows.Forms.NumericUpDown();
            this.CompressionLabel = new System.Windows.Forms.Label();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.nudQuantization = new System.Windows.Forms.NumericUpDown();
            this.OtherSettingsBox = new System.Windows.Forms.GroupBox();
            this.tbTurbo = new System.Windows.Forms.CheckBox();
            this.tbPackedBitstream = new System.Windows.Forms.CheckBox();
            this.tbInterlaced = new System.Windows.Forms.CheckBox();
            this.tbAdaptiveQuantization = new System.Windows.Forms.CheckBox();
            this.tbTrellis = new System.Windows.Forms.CheckBox();
            this.ToolsBox = new System.Windows.Forms.GroupBox();
            this.tbCloseGOP = new System.Windows.Forms.CheckBox();
            this.tbVHQBFrames = new System.Windows.Forms.CheckBox();
            this.tbChromaMotion = new System.Windows.Forms.CheckBox();
            this.tbGMC = new System.Windows.Forms.CheckBox();
            this.tbQPel = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.mnuSharing = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSharing = new wyDay.Controls.SplitButton();
            this.mnuTemplates = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ttSettings = new System.Windows.Forms.ToolTip(this.components);
            this.btnTemplates = new wyDay.Controls.SplitButton();
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBFrames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBitrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantization)).BeginInit();
            this.OtherSettingsBox.SuspendLayout();
            this.ToolsBox.SuspendLayout();
            this.mnuSharing.SuspendLayout();
            this.mnuTemplates.SuspendLayout();
            this.SuspendLayout();
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.cbProfile);
            this.Settings.Controls.Add(this.ProfileLabel);
            this.Settings.Controls.Add(this.nudBFrames);
            this.Settings.Controls.Add(this.BFramesLabel);
            this.Settings.Controls.Add(this.cbMode);
            this.Settings.Controls.Add(this.cbMotionSearch);
            this.Settings.Controls.Add(this.MotionSearchLabel);
            this.Settings.Controls.Add(this.cbHVSMasking);
            this.Settings.Controls.Add(this.HVSMaskingLabel);
            this.Settings.Controls.Add(this.cbVHQMode);
            this.Settings.Controls.Add(this.VHQLabel);
            this.Settings.Controls.Add(this.nudThreads);
            this.Settings.Controls.Add(this.ThreadsLabel);
            this.Settings.Controls.Add(this.nudBitrate);
            this.Settings.Controls.Add(this.CompressionLabel);
            this.Settings.Controls.Add(this.ModeLabel);
            this.Settings.Controls.Add(this.nudQuantization);
            this.Settings.Location = new System.Drawing.Point(12, 12);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(422, 135);
            this.Settings.TabIndex = 0;
            this.Settings.TabStop = false;
            this.Settings.Text = "Settings";
            // 
            // cbProfile
            // 
            this.cbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfile.FormattingEnabled = true;
            this.cbProfile.Items.AddRange(new object[] {
            "None"});
            this.cbProfile.Location = new System.Drawing.Point(290, 98);
            this.cbProfile.Name = "cbProfile";
            this.cbProfile.Size = new System.Drawing.Size(112, 21);
            this.cbProfile.TabIndex = 30;
            this.cbProfile.SelectedIndexChanged += new System.EventHandler(this.cbProfile_SelectedIndexChanged);
            // 
            // ProfileLabel
            // 
            this.ProfileLabel.AutoSize = true;
            this.ProfileLabel.Location = new System.Drawing.Point(221, 101);
            this.ProfileLabel.Name = "ProfileLabel";
            this.ProfileLabel.Size = new System.Drawing.Size(39, 13);
            this.ProfileLabel.TabIndex = 29;
            this.ProfileLabel.Text = "Profile:";
            // 
            // nudBFrames
            // 
            this.nudBFrames.Location = new System.Drawing.Point(290, 45);
            this.nudBFrames.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudBFrames.Name = "nudBFrames";
            this.nudBFrames.Size = new System.Drawing.Size(112, 20);
            this.nudBFrames.TabIndex = 28;
            this.nudBFrames.ValueChanged += new System.EventHandler(this.nudBFrames_ValueChanged);
            // 
            // BFramesLabel
            // 
            this.BFramesLabel.AutoSize = true;
            this.BFramesLabel.Location = new System.Drawing.Point(220, 47);
            this.BFramesLabel.Name = "BFramesLabel";
            this.BFramesLabel.Size = new System.Drawing.Size(51, 13);
            this.BFramesLabel.TabIndex = 27;
            this.BFramesLabel.Text = "BFrames:";
            // 
            // cbMode
            // 
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "CBR",
            "CQ",
            "2Pass - 1st Pass",
            "2Pass - 2nd Pass",
            "Auto 2Pass"});
            this.cbMode.Location = new System.Drawing.Point(93, 17);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(112, 21);
            this.cbMode.TabIndex = 15;
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // cbMotionSearch
            // 
            this.cbMotionSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMotionSearch.FormattingEnabled = true;
            this.cbMotionSearch.Items.AddRange(new object[] {
            "None",
            "Very Low",
            "Low",
            "Medium",
            "High",
            "Very High",
            "Ultra High"});
            this.cbMotionSearch.Location = new System.Drawing.Point(93, 99);
            this.cbMotionSearch.Name = "cbMotionSearch";
            this.cbMotionSearch.Size = new System.Drawing.Size(112, 21);
            this.cbMotionSearch.TabIndex = 26;
            this.cbMotionSearch.SelectedIndexChanged += new System.EventHandler(this.cbMotionSearch_SelectedIndexChanged);
            // 
            // MotionSearchLabel
            // 
            this.MotionSearchLabel.AutoSize = true;
            this.MotionSearchLabel.Location = new System.Drawing.Point(6, 102);
            this.MotionSearchLabel.Name = "MotionSearchLabel";
            this.MotionSearchLabel.Size = new System.Drawing.Size(79, 13);
            this.MotionSearchLabel.TabIndex = 25;
            this.MotionSearchLabel.Text = "Motion Search:";
            // 
            // cbHVSMasking
            // 
            this.cbHVSMasking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHVSMasking.FormattingEnabled = true;
            this.cbHVSMasking.Items.AddRange(new object[] {
            "None",
            "Lumi",
            "Variance"});
            this.cbHVSMasking.Location = new System.Drawing.Point(93, 72);
            this.cbHVSMasking.Name = "cbHVSMasking";
            this.cbHVSMasking.Size = new System.Drawing.Size(112, 21);
            this.cbHVSMasking.TabIndex = 24;
            this.cbHVSMasking.SelectedIndexChanged += new System.EventHandler(this.cbHVSMasking_SelectedIndexChanged);
            // 
            // HVSMaskingLabel
            // 
            this.HVSMaskingLabel.AutoSize = true;
            this.HVSMaskingLabel.Location = new System.Drawing.Point(6, 75);
            this.HVSMaskingLabel.Name = "HVSMaskingLabel";
            this.HVSMaskingLabel.Size = new System.Drawing.Size(75, 13);
            this.HVSMaskingLabel.TabIndex = 23;
            this.HVSMaskingLabel.Text = "HVS Masking:";
            // 
            // cbVHQMode
            // 
            this.cbVHQMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVHQMode.FormattingEnabled = true;
            this.cbVHQMode.Items.AddRange(new object[] {
            "Off",
            "Mode Decision",
            "Limited Search",
            "Medium Search",
            "Wide Search"});
            this.cbVHQMode.Location = new System.Drawing.Point(93, 44);
            this.cbVHQMode.Name = "cbVHQMode";
            this.cbVHQMode.Size = new System.Drawing.Size(112, 21);
            this.cbVHQMode.TabIndex = 22;
            this.cbVHQMode.SelectedIndexChanged += new System.EventHandler(this.cbVHQMode_SelectedIndexChanged);
            // 
            // VHQLabel
            // 
            this.VHQLabel.AutoSize = true;
            this.VHQLabel.Location = new System.Drawing.Point(6, 47);
            this.VHQLabel.Name = "VHQLabel";
            this.VHQLabel.Size = new System.Drawing.Size(63, 13);
            this.VHQLabel.TabIndex = 22;
            this.VHQLabel.Text = "VHQ Mode:";
            // 
            // nudThreads
            // 
            this.nudThreads.Location = new System.Drawing.Point(290, 72);
            this.nudThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreads.Name = "nudThreads";
            this.nudThreads.Size = new System.Drawing.Size(112, 20);
            this.nudThreads.TabIndex = 21;
            this.nudThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreads.ValueChanged += new System.EventHandler(this.nudThreads_ValueChanged);
            // 
            // ThreadsLabel
            // 
            this.ThreadsLabel.AutoSize = true;
            this.ThreadsLabel.Location = new System.Drawing.Point(220, 74);
            this.ThreadsLabel.Name = "ThreadsLabel";
            this.ThreadsLabel.Size = new System.Drawing.Size(49, 13);
            this.ThreadsLabel.TabIndex = 20;
            this.ThreadsLabel.Text = "Threads:";
            // 
            // nudBitrate
            // 
            this.nudBitrate.Location = new System.Drawing.Point(290, 19);
            this.nudBitrate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudBitrate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBitrate.Name = "nudBitrate";
            this.nudBitrate.Size = new System.Drawing.Size(112, 20);
            this.nudBitrate.TabIndex = 19;
            this.nudBitrate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBitrate.ValueChanged += new System.EventHandler(this.nudBitrate_ValueChanged);
            // 
            // CompressionLabel
            // 
            this.CompressionLabel.AutoSize = true;
            this.CompressionLabel.Location = new System.Drawing.Point(220, 21);
            this.CompressionLabel.Name = "CompressionLabel";
            this.CompressionLabel.Size = new System.Drawing.Size(40, 13);
            this.CompressionLabel.TabIndex = 18;
            this.CompressionLabel.Text = "Bitrate:";
            // 
            // ModeLabel
            // 
            this.ModeLabel.AutoSize = true;
            this.ModeLabel.Location = new System.Drawing.Point(6, 22);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(37, 13);
            this.ModeLabel.TabIndex = 16;
            this.ModeLabel.Text = "Mode:";
            // 
            // nudQuantization
            // 
            this.nudQuantization.DecimalPlaces = 1;
            this.nudQuantization.Location = new System.Drawing.Point(290, 19);
            this.nudQuantization.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudQuantization.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantization.Name = "nudQuantization";
            this.nudQuantization.Size = new System.Drawing.Size(112, 20);
            this.nudQuantization.TabIndex = 31;
            this.nudQuantization.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantization.ValueChanged += new System.EventHandler(this.nudQuantization_ValueChanged);
            // 
            // OtherSettingsBox
            // 
            this.OtherSettingsBox.Controls.Add(this.tbTurbo);
            this.OtherSettingsBox.Controls.Add(this.tbPackedBitstream);
            this.OtherSettingsBox.Controls.Add(this.tbInterlaced);
            this.OtherSettingsBox.Controls.Add(this.tbAdaptiveQuantization);
            this.OtherSettingsBox.Controls.Add(this.tbTrellis);
            this.OtherSettingsBox.Location = new System.Drawing.Point(12, 153);
            this.OtherSettingsBox.Name = "OtherSettingsBox";
            this.OtherSettingsBox.Size = new System.Drawing.Size(205, 136);
            this.OtherSettingsBox.TabIndex = 21;
            this.OtherSettingsBox.TabStop = false;
            this.OtherSettingsBox.Text = "Other Settings";
            // 
            // tbTurbo
            // 
            this.tbTurbo.AutoSize = true;
            this.tbTurbo.Location = new System.Drawing.Point(15, 44);
            this.tbTurbo.Name = "tbTurbo";
            this.tbTurbo.Size = new System.Drawing.Size(54, 17);
            this.tbTurbo.TabIndex = 4;
            this.tbTurbo.Text = "Turbo";
            this.tbTurbo.UseVisualStyleBackColor = true;
            this.tbTurbo.CheckedChanged += new System.EventHandler(this.tbTurbo_CheckedChanged);
            // 
            // tbPackedBitstream
            // 
            this.tbPackedBitstream.AutoSize = true;
            this.tbPackedBitstream.Location = new System.Drawing.Point(15, 90);
            this.tbPackedBitstream.Name = "tbPackedBitstream";
            this.tbPackedBitstream.Size = new System.Drawing.Size(109, 17);
            this.tbPackedBitstream.TabIndex = 3;
            this.tbPackedBitstream.Text = "Packed Bitstream";
            this.tbPackedBitstream.UseVisualStyleBackColor = true;
            this.tbPackedBitstream.CheckedChanged += new System.EventHandler(this.tbPackedBitstream_CheckedChanged);
            // 
            // tbInterlaced
            // 
            this.tbInterlaced.AutoSize = true;
            this.tbInterlaced.Location = new System.Drawing.Point(15, 20);
            this.tbInterlaced.Name = "tbInterlaced";
            this.tbInterlaced.Size = new System.Drawing.Size(73, 17);
            this.tbInterlaced.TabIndex = 2;
            this.tbInterlaced.Text = "Interlaced";
            this.tbInterlaced.UseVisualStyleBackColor = true;
            this.tbInterlaced.CheckedChanged += new System.EventHandler(this.tbInterlaced_CheckedChanged);
            // 
            // tbAdaptiveQuantization
            // 
            this.tbAdaptiveQuantization.AutoSize = true;
            this.tbAdaptiveQuantization.Location = new System.Drawing.Point(15, 113);
            this.tbAdaptiveQuantization.Name = "tbAdaptiveQuantization";
            this.tbAdaptiveQuantization.Size = new System.Drawing.Size(130, 17);
            this.tbAdaptiveQuantization.TabIndex = 1;
            this.tbAdaptiveQuantization.Text = "Adaptive Quantization";
            this.tbAdaptiveQuantization.UseVisualStyleBackColor = true;
            this.tbAdaptiveQuantization.CheckedChanged += new System.EventHandler(this.tbAdaptiveQuantization_CheckedChanged);
            // 
            // tbTrellis
            // 
            this.tbTrellis.AutoSize = true;
            this.tbTrellis.Location = new System.Drawing.Point(15, 67);
            this.tbTrellis.Name = "tbTrellis";
            this.tbTrellis.Size = new System.Drawing.Size(115, 17);
            this.tbTrellis.TabIndex = 0;
            this.tbTrellis.Text = "Trellis Quantization";
            this.tbTrellis.UseVisualStyleBackColor = true;
            this.tbTrellis.CheckedChanged += new System.EventHandler(this.tbTrellis_CheckedChanged);
            // 
            // ToolsBox
            // 
            this.ToolsBox.Controls.Add(this.tbCloseGOP);
            this.ToolsBox.Controls.Add(this.tbVHQBFrames);
            this.ToolsBox.Controls.Add(this.tbChromaMotion);
            this.ToolsBox.Controls.Add(this.tbGMC);
            this.ToolsBox.Controls.Add(this.tbQPel);
            this.ToolsBox.Location = new System.Drawing.Point(226, 154);
            this.ToolsBox.Name = "ToolsBox";
            this.ToolsBox.Size = new System.Drawing.Size(208, 135);
            this.ToolsBox.TabIndex = 22;
            this.ToolsBox.TabStop = false;
            this.ToolsBox.Text = "Tools";
            // 
            // tbCloseGOP
            // 
            this.tbCloseGOP.AutoSize = true;
            this.tbCloseGOP.Location = new System.Drawing.Point(6, 112);
            this.tbCloseGOP.Name = "tbCloseGOP";
            this.tbCloseGOP.Size = new System.Drawing.Size(84, 17);
            this.tbCloseGOP.TabIndex = 26;
            this.tbCloseGOP.Text = "Closed GOP";
            this.tbCloseGOP.UseVisualStyleBackColor = true;
            this.tbCloseGOP.CheckedChanged += new System.EventHandler(this.tbCloseGOP_CheckedChanged);
            // 
            // tbVHQBFrames
            // 
            this.tbVHQBFrames.AutoSize = true;
            this.tbVHQBFrames.Location = new System.Drawing.Point(6, 89);
            this.tbVHQBFrames.Name = "tbVHQBFrames";
            this.tbVHQBFrames.Size = new System.Drawing.Size(108, 17);
            this.tbVHQBFrames.TabIndex = 25;
            this.tbVHQBFrames.Text = "VHQ for BFrames";
            this.tbVHQBFrames.UseVisualStyleBackColor = true;
            this.tbVHQBFrames.CheckedChanged += new System.EventHandler(this.tbVHQBFrames_CheckedChanged);
            // 
            // tbChromaMotion
            // 
            this.tbChromaMotion.AutoSize = true;
            this.tbChromaMotion.Location = new System.Drawing.Point(7, 66);
            this.tbChromaMotion.Name = "tbChromaMotion";
            this.tbChromaMotion.Size = new System.Drawing.Size(97, 17);
            this.tbChromaMotion.TabIndex = 24;
            this.tbChromaMotion.Text = "Chroma Motion";
            this.tbChromaMotion.UseVisualStyleBackColor = true;
            this.tbChromaMotion.CheckedChanged += new System.EventHandler(this.tbChromaMotion_CheckedChanged);
            // 
            // tbGMC
            // 
            this.tbGMC.AutoSize = true;
            this.tbGMC.Location = new System.Drawing.Point(7, 43);
            this.tbGMC.Name = "tbGMC";
            this.tbGMC.Size = new System.Drawing.Size(50, 17);
            this.tbGMC.TabIndex = 23;
            this.tbGMC.Text = "GMC";
            this.tbGMC.UseVisualStyleBackColor = true;
            this.tbGMC.CheckedChanged += new System.EventHandler(this.tbGMC_CheckedChanged);
            // 
            // tbQPel
            // 
            this.tbQPel.AutoSize = true;
            this.tbQPel.Location = new System.Drawing.Point(7, 20);
            this.tbQPel.Name = "tbQPel";
            this.tbQPel.Size = new System.Drawing.Size(49, 17);
            this.tbQPel.TabIndex = 0;
            this.tbQPel.Text = "QPel";
            this.tbQPel.UseVisualStyleBackColor = true;
            this.tbQPel.CheckedChanged += new System.EventHandler(this.tbQPel_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(359, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(278, 296);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 24;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // mnuSharing
            // 
            this.mnuSharing.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExport,
            this.mnuImport});
            this.mnuSharing.Name = "mnuTemplates";
            this.mnuSharing.Size = new System.Drawing.Size(153, 70);
            // 
            // mnuExport
            // 
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Size = new System.Drawing.Size(152, 22);
            this.mnuExport.Text = "Export";
            this.mnuExport.Click += new System.EventHandler(this.mnuExport_Click);
            // 
            // mnuImport
            // 
            this.mnuImport.Name = "mnuImport";
            this.mnuImport.Size = new System.Drawing.Size(152, 22);
            this.mnuImport.Text = "Import";
            this.mnuImport.Click += new System.EventHandler(this.mnuImport_Click);
            // 
            // btnSharing
            // 
            this.btnSharing.AutoSize = true;
            this.btnSharing.ContextMenuStrip = this.mnuSharing;
            this.btnSharing.Location = new System.Drawing.Point(118, 296);
            this.btnSharing.Name = "btnSharing";
            this.btnSharing.Size = new System.Drawing.Size(65, 23);
            this.btnSharing.SplitMenuStrip = this.mnuSharing;
            this.btnSharing.TabIndex = 28;
            this.btnSharing.Text = "Share";
            this.btnSharing.UseVisualStyleBackColor = true;
            // 
            // mnuTemplates
            // 
            this.mnuTemplates.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReset,
            this.toolStripMenuItem1,
            this.mnuLoad,
            this.mnuSave,
            this.toolStripMenuItem2,
            this.mnuDelete});
            this.mnuTemplates.Name = "mnuTemplates";
            this.mnuTemplates.Size = new System.Drawing.Size(108, 104);
            // 
            // mnuReset
            // 
            this.mnuReset.Name = "mnuReset";
            this.mnuReset.Size = new System.Drawing.Size(107, 22);
            this.mnuReset.Text = "Reset";
            this.mnuReset.Click += new System.EventHandler(this.mnuReset_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(104, 6);
            // 
            // mnuLoad
            // 
            this.mnuLoad.Name = "mnuLoad";
            this.mnuLoad.Size = new System.Drawing.Size(107, 22);
            this.mnuLoad.Text = "Load";
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(107, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(104, 6);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(107, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // ttSettings
            // 
            this.ttSettings.AutomaticDelay = 1000;
            this.ttSettings.BackColor = System.Drawing.Color.White;
            this.ttSettings.IsBalloon = true;
            this.ttSettings.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttSettings.ToolTipTitle = "Settings";
            // 
            // btnTemplates
            // 
            this.btnTemplates.AutoSize = true;
            this.btnTemplates.ContextMenuStrip = this.mnuTemplates;
            this.btnTemplates.Location = new System.Drawing.Point(189, 296);
            this.btnTemplates.Name = "btnTemplates";
            this.btnTemplates.Size = new System.Drawing.Size(84, 23);
            this.btnTemplates.SplitMenuStrip = this.mnuTemplates;
            this.btnTemplates.TabIndex = 27;
            this.btnTemplates.Text = "Templates";
            this.btnTemplates.UseVisualStyleBackColor = true;
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.BackColor = System.Drawing.SystemColors.Control;
            this.txtCommandLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommandLine.Location = new System.Drawing.Point(12, 329);
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.ReadOnly = true;
            this.txtCommandLine.Size = new System.Drawing.Size(421, 20);
            this.txtCommandLine.TabIndex = 29;
            // 
            // Xvid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 361);
            this.Controls.Add(this.txtCommandLine);
            this.Controls.Add(this.btnSharing);
            this.Controls.Add(this.btnTemplates);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ToolsBox);
            this.Controls.Add(this.OtherSettingsBox);
            this.Controls.Add(this.Settings);
            this.Name = "Xvid";
            this.Text = "Xvid";
            this.Load += new System.EventHandler(this.Xvid_Load);
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBFrames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBitrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantization)).EndInit();
            this.OtherSettingsBox.ResumeLayout(false);
            this.OtherSettingsBox.PerformLayout();
            this.ToolsBox.ResumeLayout(false);
            this.ToolsBox.PerformLayout();
            this.mnuSharing.ResumeLayout(false);
            this.mnuTemplates.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Settings;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label ModeLabel;
        private System.Windows.Forms.Label CompressionLabel;
        private System.Windows.Forms.NumericUpDown nudBitrate;
        private System.Windows.Forms.GroupBox OtherSettingsBox;
        private System.Windows.Forms.ComboBox cbVHQMode;
        private System.Windows.Forms.Label VHQLabel;
        private System.Windows.Forms.NumericUpDown nudThreads;
        private System.Windows.Forms.Label ThreadsLabel;
        private System.Windows.Forms.CheckBox tbTurbo;
        private System.Windows.Forms.CheckBox tbPackedBitstream;
        private System.Windows.Forms.CheckBox tbInterlaced;
        private System.Windows.Forms.CheckBox tbAdaptiveQuantization;
        private System.Windows.Forms.CheckBox tbTrellis;
        private System.Windows.Forms.GroupBox ToolsBox;
        private System.Windows.Forms.CheckBox tbCloseGOP;
        private System.Windows.Forms.CheckBox tbVHQBFrames;
        private System.Windows.Forms.CheckBox tbChromaMotion;
        private System.Windows.Forms.CheckBox tbGMC;
        private System.Windows.Forms.CheckBox tbQPel;
        private System.Windows.Forms.Label HVSMaskingLabel;
        private System.Windows.Forms.ComboBox cbHVSMasking;
        private System.Windows.Forms.ComboBox cbMotionSearch;
        private System.Windows.Forms.Label MotionSearchLabel;
        private System.Windows.Forms.NumericUpDown nudBFrames;
        private System.Windows.Forms.Label BFramesLabel;
        private System.Windows.Forms.ComboBox cbProfile;
        private System.Windows.Forms.Label ProfileLabel;
        private System.Windows.Forms.NumericUpDown nudQuantization;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ContextMenuStrip mnuSharing;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
        private System.Windows.Forms.ToolStripMenuItem mnuImport;
        private wyDay.Controls.SplitButton btnSharing;
        private System.Windows.Forms.ContextMenuStrip mnuTemplates;
        private System.Windows.Forms.ToolStripMenuItem mnuReset;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuLoad;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolTip ttSettings;
        private wyDay.Controls.SplitButton btnTemplates;
        private System.Windows.Forms.TextBox txtCommandLine;
    }
}