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
            this.Settings = new System.Windows.Forms.GroupBox();
            this.cbMotionSearch = new System.Windows.Forms.ComboBox();
            this.MotionSearchLabel = new System.Windows.Forms.Label();
            this.cbHVSMasking = new System.Windows.Forms.ComboBox();
            this.HVSMaskingLabel = new System.Windows.Forms.Label();
            this.cbVHQMode = new System.Windows.Forms.ComboBox();
            this.VHQLabel = new System.Windows.Forms.Label();
            this.nudThreads = new System.Windows.Forms.NumericUpDown();
            this.ThreadsLabel = new System.Windows.Forms.Label();
            this.BitrateBox = new System.Windows.Forms.NumericUpDown();
            this.BitrateLabel = new System.Windows.Forms.Label();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.CommandDisplay = new System.Windows.Forms.TextBox();
            this.OtherSettingsBox = new System.Windows.Forms.GroupBox();
            this.cbTurbo = new System.Windows.Forms.CheckBox();
            this.cbPackedBitstream = new System.Windows.Forms.CheckBox();
            this.cbInterlaced = new System.Windows.Forms.CheckBox();
            this.cbAdaptiveQuantization = new System.Windows.Forms.CheckBox();
            this.cbTrellis = new System.Windows.Forms.CheckBox();
            this.ToolsBox = new System.Windows.Forms.GroupBox();
            this.CloseGOPBox = new System.Windows.Forms.CheckBox();
            this.VHQBFramesBox = new System.Windows.Forms.CheckBox();
            this.ChromaMotionBox = new System.Windows.Forms.CheckBox();
            this.GMCBox = new System.Windows.Forms.CheckBox();
            this.QPelBox = new System.Windows.Forms.CheckBox();
            this.Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitrateBox)).BeginInit();
            this.OtherSettingsBox.SuspendLayout();
            this.ToolsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.cbMotionSearch);
            this.Settings.Controls.Add(this.MotionSearchLabel);
            this.Settings.Controls.Add(this.cbHVSMasking);
            this.Settings.Controls.Add(this.HVSMaskingLabel);
            this.Settings.Controls.Add(this.cbVHQMode);
            this.Settings.Controls.Add(this.VHQLabel);
            this.Settings.Controls.Add(this.nudThreads);
            this.Settings.Controls.Add(this.ThreadsLabel);
            this.Settings.Controls.Add(this.BitrateBox);
            this.Settings.Controls.Add(this.BitrateLabel);
            this.Settings.Controls.Add(this.ModeLabel);
            this.Settings.Controls.Add(this.cbMode);
            this.Settings.Location = new System.Drawing.Point(12, 12);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(422, 135);
            this.Settings.TabIndex = 0;
            this.Settings.TabStop = false;
            this.Settings.Text = "Settings";
            this.Settings.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.cbMotionSearch.Size = new System.Drawing.Size(117, 21);
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
            this.cbHVSMasking.Size = new System.Drawing.Size(117, 21);
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
            this.cbVHQMode.Size = new System.Drawing.Size(117, 21);
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
            this.nudThreads.Location = new System.Drawing.Point(304, 50);
            this.nudThreads.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudThreads.Name = "nudThreads";
            this.nudThreads.Size = new System.Drawing.Size(112, 20);
            this.nudThreads.TabIndex = 21;
            this.nudThreads.ValueChanged += new System.EventHandler(this.nudThreads_ValueChanged);
            // 
            // ThreadsLabel
            // 
            this.ThreadsLabel.AutoSize = true;
            this.ThreadsLabel.Location = new System.Drawing.Point(234, 52);
            this.ThreadsLabel.Name = "ThreadsLabel";
            this.ThreadsLabel.Size = new System.Drawing.Size(49, 13);
            this.ThreadsLabel.TabIndex = 20;
            this.ThreadsLabel.Text = "Threads:";
            // 
            // BitrateBox
            // 
            this.BitrateBox.Location = new System.Drawing.Point(304, 20);
            this.BitrateBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.BitrateBox.Name = "BitrateBox";
            this.BitrateBox.Size = new System.Drawing.Size(112, 20);
            this.BitrateBox.TabIndex = 19;
            this.BitrateBox.ValueChanged += new System.EventHandler(this.BitrateBox_ValueChanged);
            // 
            // BitrateLabel
            // 
            this.BitrateLabel.AutoSize = true;
            this.BitrateLabel.Location = new System.Drawing.Point(234, 22);
            this.BitrateLabel.Name = "BitrateLabel";
            this.BitrateLabel.Size = new System.Drawing.Size(40, 13);
            this.BitrateLabel.TabIndex = 18;
            this.BitrateLabel.Text = "Bitrate:";
            // 
            // ModeLabel
            // 
            this.ModeLabel.AutoSize = true;
            this.ModeLabel.Location = new System.Drawing.Point(6, 22);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(37, 13);
            this.ModeLabel.TabIndex = 16;
            this.ModeLabel.Text = "Mode:";
            this.ModeLabel.Click += new System.EventHandler(this.Mode_Click);
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
            this.cbMode.Size = new System.Drawing.Size(117, 21);
            this.cbMode.TabIndex = 15;
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // CommandDisplay
            // 
            this.CommandDisplay.Location = new System.Drawing.Point(12, 295);
            this.CommandDisplay.Name = "CommandDisplay";
            this.CommandDisplay.Size = new System.Drawing.Size(422, 20);
            this.CommandDisplay.TabIndex = 20;
            // 
            // OtherSettingsBox
            // 
            this.OtherSettingsBox.Controls.Add(this.cbTurbo);
            this.OtherSettingsBox.Controls.Add(this.cbPackedBitstream);
            this.OtherSettingsBox.Controls.Add(this.cbInterlaced);
            this.OtherSettingsBox.Controls.Add(this.cbAdaptiveQuantization);
            this.OtherSettingsBox.Controls.Add(this.cbTrellis);
            this.OtherSettingsBox.Location = new System.Drawing.Point(12, 153);
            this.OtherSettingsBox.Name = "OtherSettingsBox";
            this.OtherSettingsBox.Size = new System.Drawing.Size(210, 136);
            this.OtherSettingsBox.TabIndex = 21;
            this.OtherSettingsBox.TabStop = false;
            this.OtherSettingsBox.Text = "Other Settings";
            // 
            // cbTurbo
            // 
            this.cbTurbo.AutoSize = true;
            this.cbTurbo.Location = new System.Drawing.Point(15, 44);
            this.cbTurbo.Name = "cbTurbo";
            this.cbTurbo.Size = new System.Drawing.Size(54, 17);
            this.cbTurbo.TabIndex = 4;
            this.cbTurbo.Text = "Turbo";
            this.cbTurbo.UseVisualStyleBackColor = true;
            // 
            // cbPackedBitstream
            // 
            this.cbPackedBitstream.AutoSize = true;
            this.cbPackedBitstream.Location = new System.Drawing.Point(15, 90);
            this.cbPackedBitstream.Name = "cbPackedBitstream";
            this.cbPackedBitstream.Size = new System.Drawing.Size(109, 17);
            this.cbPackedBitstream.TabIndex = 3;
            this.cbPackedBitstream.Text = "Packed Bitstream";
            this.cbPackedBitstream.UseVisualStyleBackColor = true;
            // 
            // cbInterlaced
            // 
            this.cbInterlaced.AutoSize = true;
            this.cbInterlaced.Location = new System.Drawing.Point(15, 20);
            this.cbInterlaced.Name = "cbInterlaced";
            this.cbInterlaced.Size = new System.Drawing.Size(73, 17);
            this.cbInterlaced.TabIndex = 2;
            this.cbInterlaced.Text = "Interlaced";
            this.cbInterlaced.UseVisualStyleBackColor = true;
            // 
            // cbAdaptiveQuantization
            // 
            this.cbAdaptiveQuantization.AutoSize = true;
            this.cbAdaptiveQuantization.Location = new System.Drawing.Point(15, 113);
            this.cbAdaptiveQuantization.Name = "cbAdaptiveQuantization";
            this.cbAdaptiveQuantization.Size = new System.Drawing.Size(130, 17);
            this.cbAdaptiveQuantization.TabIndex = 1;
            this.cbAdaptiveQuantization.Text = "Adaptive Quantization";
            this.cbAdaptiveQuantization.UseVisualStyleBackColor = true;
            // 
            // cbTrellis
            // 
            this.cbTrellis.AutoSize = true;
            this.cbTrellis.Location = new System.Drawing.Point(15, 67);
            this.cbTrellis.Name = "cbTrellis";
            this.cbTrellis.Size = new System.Drawing.Size(115, 17);
            this.cbTrellis.TabIndex = 0;
            this.cbTrellis.Text = "Trellis Quantization";
            this.cbTrellis.UseVisualStyleBackColor = true;
            // 
            // ToolsBox
            // 
            this.ToolsBox.Controls.Add(this.CloseGOPBox);
            this.ToolsBox.Controls.Add(this.VHQBFramesBox);
            this.ToolsBox.Controls.Add(this.ChromaMotionBox);
            this.ToolsBox.Controls.Add(this.GMCBox);
            this.ToolsBox.Controls.Add(this.QPelBox);
            this.ToolsBox.Location = new System.Drawing.Point(228, 154);
            this.ToolsBox.Name = "ToolsBox";
            this.ToolsBox.Size = new System.Drawing.Size(206, 135);
            this.ToolsBox.TabIndex = 22;
            this.ToolsBox.TabStop = false;
            this.ToolsBox.Text = "Tools";
            // 
            // CloseGOPBox
            // 
            this.CloseGOPBox.AutoSize = true;
            this.CloseGOPBox.Location = new System.Drawing.Point(6, 112);
            this.CloseGOPBox.Name = "CloseGOPBox";
            this.CloseGOPBox.Size = new System.Drawing.Size(84, 17);
            this.CloseGOPBox.TabIndex = 26;
            this.CloseGOPBox.Text = "Closed GOP";
            this.CloseGOPBox.UseVisualStyleBackColor = true;
            // 
            // VHQBFramesBox
            // 
            this.VHQBFramesBox.AutoSize = true;
            this.VHQBFramesBox.Location = new System.Drawing.Point(6, 89);
            this.VHQBFramesBox.Name = "VHQBFramesBox";
            this.VHQBFramesBox.Size = new System.Drawing.Size(108, 17);
            this.VHQBFramesBox.TabIndex = 25;
            this.VHQBFramesBox.Text = "VHQ for BFrames";
            this.VHQBFramesBox.UseVisualStyleBackColor = true;
            // 
            // ChromaMotionBox
            // 
            this.ChromaMotionBox.AutoSize = true;
            this.ChromaMotionBox.Location = new System.Drawing.Point(7, 66);
            this.ChromaMotionBox.Name = "ChromaMotionBox";
            this.ChromaMotionBox.Size = new System.Drawing.Size(97, 17);
            this.ChromaMotionBox.TabIndex = 24;
            this.ChromaMotionBox.Text = "Chroma Motion";
            this.ChromaMotionBox.UseVisualStyleBackColor = true;
            // 
            // GMCBox
            // 
            this.GMCBox.AutoSize = true;
            this.GMCBox.Location = new System.Drawing.Point(7, 43);
            this.GMCBox.Name = "GMCBox";
            this.GMCBox.Size = new System.Drawing.Size(50, 17);
            this.GMCBox.TabIndex = 23;
            this.GMCBox.Text = "GMC";
            this.GMCBox.UseVisualStyleBackColor = true;
            // 
            // QPelBox
            // 
            this.QPelBox.AutoSize = true;
            this.QPelBox.Location = new System.Drawing.Point(7, 20);
            this.QPelBox.Name = "QPelBox";
            this.QPelBox.Size = new System.Drawing.Size(49, 17);
            this.QPelBox.TabIndex = 0;
            this.QPelBox.Text = "QPel";
            this.QPelBox.UseVisualStyleBackColor = true;
            // 
            // Xvid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 322);
            this.Controls.Add(this.ToolsBox);
            this.Controls.Add(this.OtherSettingsBox);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.CommandDisplay);
            this.Name = "Xvid";
            this.Text = "Xvid";
            this.Load += new System.EventHandler(this.Xvid_Load);
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitrateBox)).EndInit();
            this.OtherSettingsBox.ResumeLayout(false);
            this.OtherSettingsBox.PerformLayout();
            this.ToolsBox.ResumeLayout(false);
            this.ToolsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Settings;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label ModeLabel;
        private System.Windows.Forms.Label BitrateLabel;
        private System.Windows.Forms.NumericUpDown BitrateBox;
        private System.Windows.Forms.TextBox CommandDisplay;
        private System.Windows.Forms.GroupBox OtherSettingsBox;
        private System.Windows.Forms.ComboBox cbVHQMode;
        private System.Windows.Forms.Label VHQLabel;
        private System.Windows.Forms.NumericUpDown nudThreads;
        private System.Windows.Forms.Label ThreadsLabel;
        private System.Windows.Forms.CheckBox cbTurbo;
        private System.Windows.Forms.CheckBox cbPackedBitstream;
        private System.Windows.Forms.CheckBox cbInterlaced;
        private System.Windows.Forms.CheckBox cbAdaptiveQuantization;
        private System.Windows.Forms.CheckBox cbTrellis;
        private System.Windows.Forms.GroupBox ToolsBox;
        private System.Windows.Forms.CheckBox CloseGOPBox;
        private System.Windows.Forms.CheckBox VHQBFramesBox;
        private System.Windows.Forms.CheckBox ChromaMotionBox;
        private System.Windows.Forms.CheckBox GMCBox;
        private System.Windows.Forms.CheckBox QPelBox;
        private System.Windows.Forms.Label HVSMaskingLabel;
        private System.Windows.Forms.ComboBox cbHVSMasking;
        private System.Windows.Forms.ComboBox cbMotionSearch;
        private System.Windows.Forms.Label MotionSearchLabel;
    }
}