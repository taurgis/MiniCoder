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
            this.CommandDisplay = new System.Windows.Forms.TextBox();
            this.BitrateBox = new System.Windows.Forms.NumericUpDown();
            this.BitrateLabel = new System.Windows.Forms.Label();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.OtherSettingsBox = new System.Windows.Forms.GroupBox();
            this.cbTrellis = new System.Windows.Forms.CheckBox();
            this.cbAdaptiveQuantization = new System.Windows.Forms.CheckBox();
            this.cbInterlaced = new System.Windows.Forms.CheckBox();
            this.cbPackedBitstream = new System.Windows.Forms.CheckBox();
            this.ThreadsLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cbTurbo = new System.Windows.Forms.CheckBox();
            this.VHQLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ToolsBox = new System.Windows.Forms.GroupBox();
            this.QPelBox = new System.Windows.Forms.CheckBox();
            this.GMCBox = new System.Windows.Forms.CheckBox();
            this.ChromaMotionBox = new System.Windows.Forms.CheckBox();
            this.VHQBFramesBox = new System.Windows.Forms.CheckBox();
            this.CloseGOPBox = new System.Windows.Forms.CheckBox();
            this.HVSMaskingLabel = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BitrateBox)).BeginInit();
            this.OtherSettingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.ToolsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.comboBox2);
            this.Settings.Controls.Add(this.HVSMaskingLabel);
            this.Settings.Controls.Add(this.comboBox1);
            this.Settings.Controls.Add(this.VHQLabel);
            this.Settings.Controls.Add(this.numericUpDown1);
            this.Settings.Controls.Add(this.ThreadsLabel);
            this.Settings.Controls.Add(this.BitrateBox);
            this.Settings.Controls.Add(this.BitrateLabel);
            this.Settings.Controls.Add(this.ModeLabel);
            this.Settings.Controls.Add(this.cbMode);
            this.Settings.Location = new System.Drawing.Point(12, 12);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(422, 144);
            this.Settings.TabIndex = 0;
            this.Settings.TabStop = false;
            this.Settings.Text = "Settings";
            this.Settings.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // CommandDisplay
            // 
            this.CommandDisplay.Location = new System.Drawing.Point(12, 304);
            this.CommandDisplay.Name = "CommandDisplay";
            this.CommandDisplay.Size = new System.Drawing.Size(422, 20);
            this.CommandDisplay.TabIndex = 20;
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
            this.BitrateLabel.Click += new System.EventHandler(this.BitrateLabel_Click);
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
            this.cbMode.Location = new System.Drawing.Point(93, 19);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(117, 21);
            this.cbMode.TabIndex = 15;
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // OtherSettingsBox
            // 
            this.OtherSettingsBox.Controls.Add(this.cbTurbo);
            this.OtherSettingsBox.Controls.Add(this.cbPackedBitstream);
            this.OtherSettingsBox.Controls.Add(this.cbInterlaced);
            this.OtherSettingsBox.Controls.Add(this.cbAdaptiveQuantization);
            this.OtherSettingsBox.Controls.Add(this.cbTrellis);
            this.OtherSettingsBox.Location = new System.Drawing.Point(12, 162);
            this.OtherSettingsBox.Name = "OtherSettingsBox";
            this.OtherSettingsBox.Size = new System.Drawing.Size(210, 136);
            this.OtherSettingsBox.TabIndex = 21;
            this.OtherSettingsBox.TabStop = false;
            this.OtherSettingsBox.Text = "Other Settings";
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
            // ThreadsLabel
            // 
            this.ThreadsLabel.AutoSize = true;
            this.ThreadsLabel.Location = new System.Drawing.Point(234, 52);
            this.ThreadsLabel.Name = "ThreadsLabel";
            this.ThreadsLabel.Size = new System.Drawing.Size(49, 13);
            this.ThreadsLabel.TabIndex = 20;
            this.ThreadsLabel.Text = "Threads:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(304, 50);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(112, 20);
            this.numericUpDown1.TabIndex = 21;
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
            // VHQLabel
            // 
            this.VHQLabel.AutoSize = true;
            this.VHQLabel.Location = new System.Drawing.Point(6, 52);
            this.VHQLabel.Name = "VHQLabel";
            this.VHQLabel.Size = new System.Drawing.Size(63, 13);
            this.VHQLabel.TabIndex = 22;
            this.VHQLabel.Text = "VHQ Mode:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0 - Off",
            "1 - Mode Decision",
            "2 - Limited Search",
            "3 - Medium Search",
            "4 - Wide Search"});
            this.comboBox1.Location = new System.Drawing.Point(93, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(117, 21);
            this.comboBox1.TabIndex = 22;
            // 
            // ToolsBox
            // 
            this.ToolsBox.Controls.Add(this.CloseGOPBox);
            this.ToolsBox.Controls.Add(this.VHQBFramesBox);
            this.ToolsBox.Controls.Add(this.ChromaMotionBox);
            this.ToolsBox.Controls.Add(this.GMCBox);
            this.ToolsBox.Controls.Add(this.QPelBox);
            this.ToolsBox.Location = new System.Drawing.Point(228, 163);
            this.ToolsBox.Name = "ToolsBox";
            this.ToolsBox.Size = new System.Drawing.Size(206, 135);
            this.ToolsBox.TabIndex = 22;
            this.ToolsBox.TabStop = false;
            this.ToolsBox.Text = "Tools";
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
            // HVSMaskingLabel
            // 
            this.HVSMaskingLabel.AutoSize = true;
            this.HVSMaskingLabel.Location = new System.Drawing.Point(6, 80);
            this.HVSMaskingLabel.Name = "HVSMaskingLabel";
            this.HVSMaskingLabel.Size = new System.Drawing.Size(75, 13);
            this.HVSMaskingLabel.TabIndex = 23;
            this.HVSMaskingLabel.Text = "HVS Masking:";
            this.HVSMaskingLabel.Click += new System.EventHandler(this.HVSMaskingLabel_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "None",
            "Lumi",
            "Variance"});
            this.comboBox2.Location = new System.Drawing.Point(93, 77);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(117, 21);
            this.comboBox2.TabIndex = 24;
            // 
            // Xvid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 335);
            this.Controls.Add(this.ToolsBox);
            this.Controls.Add(this.OtherSettingsBox);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.CommandDisplay);
            this.Name = "Xvid";
            this.Text = "Xvid";
            this.Load += new System.EventHandler(this.Xvid_Load_1);
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BitrateBox)).EndInit();
            this.OtherSettingsBox.ResumeLayout(false);
            this.OtherSettingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label VHQLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
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
        private System.Windows.Forms.ComboBox comboBox2;
    }
}