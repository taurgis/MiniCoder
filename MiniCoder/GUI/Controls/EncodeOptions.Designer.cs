namespace MiniCOder.GUI.Controls
{
    partial class EncodeOptions
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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.continueAfterError = new System.Windows.Forms.CheckBox();
            this.showVideo = new System.Windows.Forms.CheckBox();
            this.ignoreAttachments = new System.Windows.Forms.CheckBox();
            this.ignoreSubs = new System.Windows.Forms.CheckBox();
            this.ignoreChapters = new System.Windows.Forms.CheckBox();
            this.audioSkip = new System.Windows.Forms.CheckBox();
            this.btnApps = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.processPriority = new System.Windows.Forms.ComboBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.clearOutput = new System.Windows.Forms.Button();
            this.outputSelect = new System.Windows.Forms.Button();
            this.outPutLocation = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.titleAdvert = new System.Windows.Forms.CheckBox();
            this.languagesSelect = new System.Windows.Forms.ComboBox();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.continueAfterError);
            this.groupBox8.Controls.Add(this.showVideo);
            this.groupBox8.Controls.Add(this.ignoreAttachments);
            this.groupBox8.Controls.Add(this.ignoreSubs);
            this.groupBox8.Controls.Add(this.ignoreChapters);
            this.groupBox8.Controls.Add(this.audioSkip);
            this.groupBox8.Location = new System.Drawing.Point(3, 152);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(378, 118);
            this.groupBox8.TabIndex = 18;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Encoding";
            // 
            // continueAfterError
            // 
            this.continueAfterError.AutoSize = true;
            this.continueAfterError.Location = new System.Drawing.Point(9, 101);
            this.continueAfterError.Name = "continueAfterError";
            this.continueAfterError.Size = new System.Drawing.Size(167, 17);
            this.continueAfterError.TabIndex = 5;
            this.continueAfterError.Text = "Continue to next file after error";
            this.continueAfterError.UseVisualStyleBackColor = true;
            // 
            // showVideo
            // 
            this.showVideo.AutoSize = true;
            this.showVideo.Location = new System.Drawing.Point(9, 79);
            this.showVideo.Name = "showVideo";
            this.showVideo.Size = new System.Drawing.Size(206, 17);
            this.showVideo.TabIndex = 4;
            this.showVideo.Text = "Show Video Preview (Debug purpose)";
            this.showVideo.UseVisualStyleBackColor = true;
            // 
            // ignoreAttachments
            // 
            this.ignoreAttachments.AutoSize = true;
            this.ignoreAttachments.Location = new System.Drawing.Point(162, 56);
            this.ignoreAttachments.Name = "ignoreAttachments";
            this.ignoreAttachments.Size = new System.Drawing.Size(118, 17);
            this.ignoreAttachments.TabIndex = 3;
            this.ignoreAttachments.Text = "Ignore Attachments";
            this.ignoreAttachments.UseVisualStyleBackColor = true;
            // 
            // ignoreSubs
            // 
            this.ignoreSubs.AutoSize = true;
            this.ignoreSubs.Location = new System.Drawing.Point(9, 56);
            this.ignoreSubs.Name = "ignoreSubs";
            this.ignoreSubs.Size = new System.Drawing.Size(81, 17);
            this.ignoreSubs.TabIndex = 2;
            this.ignoreSubs.Text = "Ignore subs";
            this.ignoreSubs.UseVisualStyleBackColor = true;
            // 
            // ignoreChapters
            // 
            this.ignoreChapters.AutoSize = true;
            this.ignoreChapters.Location = new System.Drawing.Point(162, 30);
            this.ignoreChapters.Name = "ignoreChapters";
            this.ignoreChapters.Size = new System.Drawing.Size(101, 17);
            this.ignoreChapters.TabIndex = 1;
            this.ignoreChapters.Text = "Ignore Chapters";
            this.ignoreChapters.UseVisualStyleBackColor = true;
            // 
            // audioSkip
            // 
            this.audioSkip.AutoSize = true;
            this.audioSkip.Location = new System.Drawing.Point(9, 30);
            this.audioSkip.Name = "audioSkip";
            this.audioSkip.Size = new System.Drawing.Size(86, 17);
            this.audioSkip.TabIndex = 0;
            this.audioSkip.Text = "Ignore Audio";
            this.audioSkip.UseVisualStyleBackColor = true;
            // 
            // btnApps
            // 
            this.btnApps.Location = new System.Drawing.Point(3, 276);
            this.btnApps.Name = "btnApps";
            this.btnApps.Size = new System.Drawing.Size(101, 26);
            this.btnApps.TabIndex = 16;
            this.btnApps.Text = "Applications";
            this.btnApps.UseVisualStyleBackColor = true;
            this.btnApps.Click += new System.EventHandler(this.btnApps_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label15);
            this.groupBox10.Controls.Add(this.processPriority);
            this.groupBox10.Location = new System.Drawing.Point(3, 83);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(378, 63);
            this.groupBox10.TabIndex = 17;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Process Settings";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(6, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 21);
            this.label15.TabIndex = 14;
            this.label15.Text = "Priority:";
            // 
            // processPriority
            // 
            this.processPriority.DisplayMember = "Low";
            this.processPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.processPriority.DropDownWidth = 100;
            this.processPriority.FormattingEnabled = true;
            this.processPriority.Items.AddRange(new object[] {
            "Low",
            "Below Normal",
            "Normal",
            "Above Normal",
            "High",
            "Realtime"});
            this.processPriority.Location = new System.Drawing.Point(73, 25);
            this.processPriority.Name = "processPriority";
            this.processPriority.Size = new System.Drawing.Size(100, 21);
            this.processPriority.TabIndex = 13;
            this.processPriority.SelectedIndexChanged += new System.EventHandler(this.processPriority_SelectedIndexChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.clearOutput);
            this.groupBox9.Controls.Add(this.outputSelect);
            this.groupBox9.Controls.Add(this.outPutLocation);
            this.groupBox9.Controls.Add(this.label16);
            this.groupBox9.Controls.Add(this.titleAdvert);
            this.groupBox9.Location = new System.Drawing.Point(3, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(378, 74);
            this.groupBox9.TabIndex = 15;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Output Settings";
            this.groupBox9.Enter += new System.EventHandler(this.groupBox9_Enter);
            // 
            // clearOutput
            // 
            this.clearOutput.Location = new System.Drawing.Point(337, 46);
            this.clearOutput.Name = "clearOutput";
            this.clearOutput.Size = new System.Drawing.Size(33, 23);
            this.clearOutput.TabIndex = 6;
            this.clearOutput.Text = "X";
            this.clearOutput.UseVisualStyleBackColor = true;
            this.clearOutput.Click += new System.EventHandler(this.clearOutput_Click);
            // 
            // outputSelect
            // 
            this.outputSelect.Location = new System.Drawing.Point(298, 46);
            this.outputSelect.Name = "outputSelect";
            this.outputSelect.Size = new System.Drawing.Size(33, 23);
            this.outputSelect.TabIndex = 5;
            this.outputSelect.Text = "...";
            this.outputSelect.UseVisualStyleBackColor = true;
            this.outputSelect.Click += new System.EventHandler(this.outputSelect_Click);
            // 
            // outPutLocation
            // 
            this.outPutLocation.Enabled = false;
            this.outPutLocation.Location = new System.Drawing.Point(73, 46);
            this.outPutLocation.Name = "outPutLocation";
            this.outPutLocation.Size = new System.Drawing.Size(219, 20);
            this.outPutLocation.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Output Dir:";
            // 
            // titleAdvert
            // 
            this.titleAdvert.AutoSize = true;
            this.titleAdvert.Location = new System.Drawing.Point(6, 21);
            this.titleAdvert.Name = "titleAdvert";
            this.titleAdvert.Size = new System.Drawing.Size(142, 17);
            this.titleAdvert.TabIndex = 2;
            this.titleAdvert.Text = "Disable video title advert";
            this.titleAdvert.UseVisualStyleBackColor = true;
            // 
            // languagesSelect
            // 
            this.languagesSelect.DisplayMember = "Low";
            this.languagesSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languagesSelect.DropDownWidth = 100;
            this.languagesSelect.FormattingEnabled = true;
            this.languagesSelect.Items.AddRange(new object[] {
            "English",
            "Nederlands"});
            this.languagesSelect.Location = new System.Drawing.Point(259, 280);
            this.languagesSelect.Name = "languagesSelect";
            this.languagesSelect.Size = new System.Drawing.Size(100, 21);
            this.languagesSelect.TabIndex = 15;
            this.languagesSelect.SelectedIndexChanged += new System.EventHandler(this.languagesSelect_SelectedIndexChanged);
            // 
            // EncodeOptions
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.languagesSelect);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.btnApps);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Name = "EncodeOptions";
            this.Size = new System.Drawing.Size(385, 309);
            this.Load += new System.EventHandler(this.EncodeOptions_Load);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox ignoreAttachments;
        private System.Windows.Forms.CheckBox ignoreSubs;
        private System.Windows.Forms.CheckBox ignoreChapters;
        private System.Windows.Forms.CheckBox audioSkip;
        private System.Windows.Forms.Button btnApps;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox processPriority;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button clearOutput;
        private System.Windows.Forms.Button outputSelect;
        private System.Windows.Forms.TextBox outPutLocation;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox titleAdvert;
        private System.Windows.Forms.CheckBox showVideo;
        private System.Windows.Forms.CheckBox continueAfterError;
        private System.Windows.Forms.ComboBox languagesSelect;

    }
}
