﻿namespace MiniCoder2.Templating.Audio.FLAC
{
    partial class Flac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Flac));
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
            this.cbDownConvert = new System.Windows.Forms.CheckBox();
            this.cbNormalize = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSampleRate = new System.Windows.Forms.ComboBox();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbChannels = new System.Windows.Forms.ComboBox();
            this.ttSettings = new System.Windows.Forms.ToolTip(this.components);
            this.btnSharing = new wyDay.Controls.SplitButton();
            this.mnuSharing = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTemplates.SuspendLayout();
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            this.mnuSharing.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.BackColor = System.Drawing.SystemColors.Control;
            this.txtCommandLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommandLine.Location = new System.Drawing.Point(5, 154);
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.ReadOnly = true;
            this.txtCommandLine.Size = new System.Drawing.Size(349, 20);
            this.txtCommandLine.TabIndex = 14;
            // 
            // btnTemplates
            // 
            this.btnTemplates.AutoSize = true;
            this.btnTemplates.ContextMenuStrip = this.mnuTemplates;
            this.btnTemplates.Location = new System.Drawing.Point(154, 125);
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
            this.btnOk.Location = new System.Drawing.Point(244, 125);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(51, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(301, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(51, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.cbDownConvert);
            this.gbSettings.Controls.Add(this.cbNormalize);
            this.gbSettings.Controls.Add(this.label7);
            this.gbSettings.Controls.Add(this.cbSampleRate);
            this.gbSettings.Controls.Add(this.nudDelay);
            this.gbSettings.Controls.Add(this.label6);
            this.gbSettings.Controls.Add(this.label5);
            this.gbSettings.Controls.Add(this.cbChannels);
            this.gbSettings.Location = new System.Drawing.Point(5, 4);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(349, 113);
            this.gbSettings.TabIndex = 18;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // cbDownConvert
            // 
            this.cbDownConvert.AutoSize = true;
            this.cbDownConvert.Location = new System.Drawing.Point(191, 25);
            this.cbDownConvert.Name = "cbDownConvert";
            this.cbDownConvert.Size = new System.Drawing.Size(131, 17);
            this.cbDownConvert.TabIndex = 30;
            this.cbDownConvert.Text = "Downconvert to 16 bit";
            this.cbDownConvert.UseVisualStyleBackColor = true;
            this.cbDownConvert.CheckedChanged += new System.EventHandler(this.cbDownConvert_CheckedChanged);
            // 
            // cbNormalize
            // 
            this.cbNormalize.AutoSize = true;
            this.cbNormalize.Location = new System.Drawing.Point(191, 54);
            this.cbNormalize.Name = "cbNormalize";
            this.cbNormalize.Size = new System.Drawing.Size(72, 17);
            this.cbNormalize.TabIndex = 28;
            this.cbNormalize.Text = "Normalize";
            this.cbNormalize.UseVisualStyleBackColor = true;
            this.cbNormalize.CheckedChanged += new System.EventHandler(this.cbNormalize_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 55);
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
            this.cbSampleRate.Location = new System.Drawing.Point(78, 52);
            this.cbSampleRate.Name = "cbSampleRate";
            this.cbSampleRate.Size = new System.Drawing.Size(104, 21);
            this.cbSampleRate.TabIndex = 26;
            this.ttSettings.SetToolTip(this.cbSampleRate, "The sample rate of playback or recording determines the maximum \r\naudio frequency" +
        " that can be reproduced.");
            this.cbSampleRate.SelectedIndexChanged += new System.EventHandler(this.cbSampleRate_SelectedIndexChanged);
            // 
            // nudDelay
            // 
            this.nudDelay.Location = new System.Drawing.Point(78, 78);
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
            this.nudDelay.Size = new System.Drawing.Size(104, 20);
            this.nudDelay.TabIndex = 25;
            this.ttSettings.SetToolTip(this.nudDelay, "The delay in miliseconds.\r\n\r\n1000 ms = 1 second");
            this.nudDelay.ValueChanged += new System.EventHandler(this.nudDelay_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Delay:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 25);
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
            "Mono",
            "Stereo",
            "5.1"});
            this.cbChannels.Location = new System.Drawing.Point(78, 22);
            this.cbChannels.Name = "cbChannels";
            this.cbChannels.Size = new System.Drawing.Size(104, 21);
            this.cbChannels.TabIndex = 22;
            this.cbChannels.SelectedIndexChanged += new System.EventHandler(this.cbChannels_SelectedIndexChanged);
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
            this.btnSharing.Location = new System.Drawing.Point(83, 125);
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
            this.mnuSharing.Size = new System.Drawing.Size(111, 48);
            // 
            // mnuExport
            // 
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Size = new System.Drawing.Size(110, 22);
            this.mnuExport.Text = "Export";
            this.mnuExport.Click += new System.EventHandler(this.mnuExport_Click);
            // 
            // mnuImport
            // 
            this.mnuImport.Name = "mnuImport";
            this.mnuImport.Size = new System.Drawing.Size(110, 22);
            this.mnuImport.Text = "Import";
            this.mnuImport.Click += new System.EventHandler(this.mnuImport_Click);
            // 
            // Flac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 186);
            this.Controls.Add(this.btnSharing);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtCommandLine);
            this.Controls.Add(this.btnTemplates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Flac";
            this.Text = "FLAC";
            this.Load += new System.EventHandler(this.Aac_Load);
            this.mnuTemplates.ResumeLayout(false);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbChannels;
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
        private System.Windows.Forms.CheckBox cbDownConvert;
        private System.Windows.Forms.CheckBox cbNormalize;

    }
}