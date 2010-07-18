namespace MiniCoder2.Templating.Audio.AAC
{
    partial class Aac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aac));
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.btnTemplates = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSampleRate = new System.Windows.Forms.ComboBox();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbChannels = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbProfile = new System.Windows.Forms.ComboBox();
            this.nudBitrate = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudQuality = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.ttSettings = new System.Windows.Forms.ToolTip(this.components);
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBitrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.BackColor = System.Drawing.SystemColors.Control;
            this.txtCommandLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommandLine.Location = new System.Drawing.Point(5, 165);
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.ReadOnly = true;
            this.txtCommandLine.Size = new System.Drawing.Size(349, 20);
            this.txtCommandLine.TabIndex = 14;
            // 
            // btnTemplates
            // 
            this.btnTemplates.Location = new System.Drawing.Point(163, 136);
            this.btnTemplates.Name = "btnTemplates";
            this.btnTemplates.Size = new System.Drawing.Size(75, 23);
            this.btnTemplates.TabIndex = 15;
            this.btnTemplates.Text = "Templates";
            this.btnTemplates.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(244, 136);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(51, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(301, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(51, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.label7);
            this.gbSettings.Controls.Add(this.cbSampleRate);
            this.gbSettings.Controls.Add(this.nudDelay);
            this.gbSettings.Controls.Add(this.label6);
            this.gbSettings.Controls.Add(this.label5);
            this.gbSettings.Controls.Add(this.cbChannels);
            this.gbSettings.Controls.Add(this.label4);
            this.gbSettings.Controls.Add(this.cbProfile);
            this.gbSettings.Controls.Add(this.nudBitrate);
            this.gbSettings.Controls.Add(this.label3);
            this.gbSettings.Controls.Add(this.nudQuality);
            this.gbSettings.Controls.Add(this.label2);
            this.gbSettings.Controls.Add(this.label1);
            this.gbSettings.Controls.Add(this.cbMode);
            this.gbSettings.Location = new System.Drawing.Point(5, 4);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(349, 126);
            this.gbSettings.TabIndex = 18;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Sample Rate:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbSampleRate
            // 
            this.cbSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSampleRate.FormattingEnabled = true;
            this.cbSampleRate.Items.AddRange(new object[] {
            "Original",
            "44100 Hz",
            "48000 Hz",
            "88200 Hz",
            "96000 Hz"});
            this.cbSampleRate.Location = new System.Drawing.Point(78, 92);
            this.cbSampleRate.Name = "cbSampleRate";
            this.cbSampleRate.Size = new System.Drawing.Size(104, 21);
            this.cbSampleRate.TabIndex = 26;
            this.ttSettings.SetToolTip(this.cbSampleRate, "The sample rate of playback or recording determines the maximum \r\naudio frequency" +
                    " that can be reproduced.");
            this.cbSampleRate.SelectedIndexChanged += new System.EventHandler(this.cbSampleRate_SelectedIndexChanged);
            // 
            // nudDelay
            // 
            this.nudDelay.Location = new System.Drawing.Point(248, 66);
            this.nudDelay.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudDelay.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(92, 20);
            this.nudDelay.TabIndex = 25;
            this.ttSettings.SetToolTip(this.nudDelay, "The delay in miliseconds.\r\n\r\n1000 ms = 1 second");
            this.nudDelay.ValueChanged += new System.EventHandler(this.nudDelay_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Delay:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Channels:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbChannels
            // 
            this.cbChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChannels.FormattingEnabled = true;
            this.cbChannels.Items.AddRange(new object[] {
            "Stereo",
            "5.1"});
            this.cbChannels.Location = new System.Drawing.Point(78, 65);
            this.cbChannels.Name = "cbChannels";
            this.cbChannels.Size = new System.Drawing.Size(104, 21);
            this.cbChannels.TabIndex = 22;
            this.cbChannels.SelectedIndexChanged += new System.EventHandler(this.cbChannels_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Profile:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbProfile
            // 
            this.cbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfile.FormattingEnabled = true;
            this.cbProfile.Items.AddRange(new object[] {
            "Automatic",
            "LC",
            "HE",
            "HEv2"});
            this.cbProfile.Location = new System.Drawing.Point(78, 40);
            this.cbProfile.Name = "cbProfile";
            this.cbProfile.Size = new System.Drawing.Size(104, 21);
            this.cbProfile.TabIndex = 20;
            this.ttSettings.SetToolTip(this.cbProfile, resources.GetString("cbProfile.ToolTip"));
            this.cbProfile.SelectedIndexChanged += new System.EventHandler(this.cbProfile_SelectedIndexChanged);
            // 
            // nudBitrate
            // 
            this.nudBitrate.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudBitrate.Location = new System.Drawing.Point(249, 41);
            this.nudBitrate.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudBitrate.Name = "nudBitrate";
            this.nudBitrate.Size = new System.Drawing.Size(91, 20);
            this.nudBitrate.TabIndex = 19;
            this.ttSettings.SetToolTip(this.nudBitrate, "The bitrate determines the quality and the output filesize.\r\nThe higher the bitra" +
                    "te the better the quality, but the file will\r\nbe bigger aswell.");
            this.nudBitrate.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.nudBitrate.ValueChanged += new System.EventHandler(this.nudBitrate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Bitrate:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nudQuality
            // 
            this.nudQuality.DecimalPlaces = 1;
            this.nudQuality.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudQuality.Location = new System.Drawing.Point(249, 14);
            this.nudQuality.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuality.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudQuality.Name = "nudQuality";
            this.nudQuality.Size = new System.Drawing.Size(91, 20);
            this.nudQuality.TabIndex = 17;
            this.nudQuality.Tag = "";
            this.ttSettings.SetToolTip(this.nudQuality, "The overal quality of the video. \r\n0.1: Low\r\n1.0: High");
            this.nudQuality.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudQuality.ValueChanged += new System.EventHandler(this.nudQuality_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Quality:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mode:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbMode
            // 
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "VBR",
            "CBR",
            "ABR"});
            this.cbMode.Location = new System.Drawing.Point(78, 13);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(104, 21);
            this.cbMode.TabIndex = 14;
            this.ttSettings.SetToolTip(this.cbMode, resources.GetString("cbMode.ToolTip"));
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // ttSettings
            // 
            this.ttSettings.AutomaticDelay = 1000;
            this.ttSettings.BackColor = System.Drawing.Color.White;
            this.ttSettings.IsBalloon = true;
            this.ttSettings.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttSettings.ToolTipTitle = "Settings";
            // 
            // Aac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 197);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnTemplates);
            this.Controls.Add(this.txtCommandLine);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Aac";
            this.Text = "Aac";
            this.Load += new System.EventHandler(this.Aac_Load);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBitrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.Button btnTemplates;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSampleRate;
        private System.Windows.Forms.NumericUpDown nudDelay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbChannels;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbProfile;
        private System.Windows.Forms.NumericUpDown nudBitrate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudQuality;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.ToolTip ttSettings;

    }
}