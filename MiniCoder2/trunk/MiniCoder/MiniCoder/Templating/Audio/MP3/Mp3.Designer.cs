namespace MiniCoder2.Templating.Audio.MP3
{
    partial class Mp3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mp3));
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.btnTemplates = new wyDay.Controls.SplitButton();
            this.mnuTemplates = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSampleRate = new System.Windows.Forms.ComboBox();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudBitrate = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudQuality = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.ttSettings = new System.Windows.Forms.ToolTip(this.components);
            this.btnSharing = new wyDay.Controls.SplitButton();
            this.mnuSharing = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTemplates.SuspendLayout();
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBitrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuality)).BeginInit();
            this.mnuSharing.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.BackColor = System.Drawing.SystemColors.Control;
            this.txtCommandLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommandLine.Location = new System.Drawing.Point(5, 136);
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.ReadOnly = true;
            this.txtCommandLine.Size = new System.Drawing.Size(349, 20);
            this.txtCommandLine.TabIndex = 14;
            // 
            // btnTemplates
            // 
            this.btnTemplates.AutoSize = true;
            this.btnTemplates.ContextMenuStrip = this.mnuTemplates;
            this.btnTemplates.Location = new System.Drawing.Point(156, 107);
            this.btnTemplates.Name = "btnTemplates";
            this.btnTemplates.Size = new System.Drawing.Size(84, 23);
            this.btnTemplates.SplitMenuStrip = this.mnuTemplates;
            this.btnTemplates.TabIndex = 15;
            this.btnTemplates.Text = "Templates";
            this.btnTemplates.UseVisualStyleBackColor = true;
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
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(246, 107);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(51, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(303, 107);
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
            this.gbSettings.Controls.Add(this.nudBitrate);
            this.gbSettings.Controls.Add(this.label3);
            this.gbSettings.Controls.Add(this.nudQuality);
            this.gbSettings.Controls.Add(this.label2);
            this.gbSettings.Controls.Add(this.label1);
            this.gbSettings.Controls.Add(this.cbMode);
            this.gbSettings.Location = new System.Drawing.Point(5, 4);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(349, 97);
            this.gbSettings.TabIndex = 18;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 43);
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
            this.cbSampleRate.Location = new System.Drawing.Point(78, 40);
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
            // btnSharing
            // 
            this.btnSharing.AutoSize = true;
            this.btnSharing.ContextMenuStrip = this.mnuSharing;
            this.btnSharing.Location = new System.Drawing.Point(85, 107);
            this.btnSharing.Name = "btnSharing";
            this.btnSharing.Size = new System.Drawing.Size(65, 23);
            this.btnSharing.SplitMenuStrip = this.mnuSharing;
            this.btnSharing.TabIndex = 19;
            this.btnSharing.Text = "Share";
            this.btnSharing.UseVisualStyleBackColor = true;
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
            // Mp3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 164);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.btnSharing);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtCommandLine);
            this.Controls.Add(this.btnTemplates);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mp3";
            this.Text = "Mp3";
            this.Load += new System.EventHandler(this.Aac_Load);
            this.mnuTemplates.ResumeLayout(false);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBitrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuality)).EndInit();
            this.mnuSharing.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCommandLine;
        private wyDay.Controls.SplitButton btnTemplates;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSampleRate;
        private System.Windows.Forms.NumericUpDown nudDelay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudBitrate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudQuality;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.ToolTip ttSettings;
        private System.Windows.Forms.ContextMenuStrip mnuTemplates;
        private System.Windows.Forms.ToolStripMenuItem mnuReset;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuLoad;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private wyDay.Controls.SplitButton btnSharing;
        private System.Windows.Forms.ContextMenuStrip mnuSharing;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
        private System.Windows.Forms.ToolStripMenuItem mnuImport;

    }
}