namespace MiniCOder.GUI.Controls
{
    partial class EncodeSettings
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
            this.btnDeleteTemplate = new System.Windows.Forms.Button();
            this.templateCombo = new System.Windows.Forms.ComboBox();
            this.saveOptButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.containerCombo = new System.Windows.Forms.ComboBox();
            this.customButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.openSubBtn = new System.Windows.Forms.Button();
            this.subText = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.sharpCombo = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.noiseCombo = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.widthHeight = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.resizeCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldCombo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.audioCombo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.audioBR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fileSizeRadio = new System.Windows.Forms.RadioButton();
            this.bitRateRadio = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.fileSize = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.videoCombo = new System.Windows.Forms.ComboBox();
            this.vidQualCombo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.videoBR = new System.Windows.Forms.TextBox();
            this.openSub = new System.Windows.Forms.OpenFileDialog();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeleteTemplate
            // 
            this.btnDeleteTemplate.Location = new System.Drawing.Point(247, 311);
            this.btnDeleteTemplate.Name = "btnDeleteTemplate";
            this.btnDeleteTemplate.Size = new System.Drawing.Size(25, 26);
            this.btnDeleteTemplate.TabIndex = 14;
            this.btnDeleteTemplate.Text = "X";
            this.btnDeleteTemplate.UseVisualStyleBackColor = true;
            this.btnDeleteTemplate.Click += new System.EventHandler(this.btnDeleteTemplate_Click);
            // 
            // templateCombo
            // 
            this.templateCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateCombo.FormattingEnabled = true;
            this.templateCombo.Location = new System.Drawing.Point(278, 313);
            this.templateCombo.Name = "templateCombo";
            this.templateCombo.Size = new System.Drawing.Size(113, 21);
            this.templateCombo.TabIndex = 13;
            this.templateCombo.SelectedIndexChanged += new System.EventHandler(this.cbTemplates_SelectedIndexChanged);
            // 
            // saveOptButton
            // 
            this.saveOptButton.Location = new System.Drawing.Point(193, 311);
            this.saveOptButton.Name = "saveOptButton";
            this.saveOptButton.Size = new System.Drawing.Size(48, 26);
            this.saveOptButton.TabIndex = 11;
            this.saveOptButton.Text = "Save";
            this.saveOptButton.UseVisualStyleBackColor = true;
            this.saveOptButton.Click += new System.EventHandler(this.saveOptButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.containerCombo);
            this.groupBox5.Location = new System.Drawing.Point(199, 96);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(197, 51);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Container";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Format";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // containerCombo
            // 
            this.containerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.containerCombo.FormattingEnabled = true;
            this.containerCombo.Items.AddRange(new object[] {
            "Matroska",
            "MP4"});
            this.containerCombo.Location = new System.Drawing.Point(75, 20);
            this.containerCombo.Name = "containerCombo";
            this.containerCombo.Size = new System.Drawing.Size(94, 21);
            this.containerCombo.TabIndex = 5;
            this.containerCombo.SelectedIndexChanged += new System.EventHandler(this.containerCombo_SelectedIndexChanged);
            // 
            // customButton
            // 
            this.customButton.Location = new System.Drawing.Point(6, 311);
            this.customButton.Name = "customButton";
            this.customButton.Size = new System.Drawing.Size(79, 26);
            this.customButton.TabIndex = 9;
            this.customButton.Text = "Custom";
            this.customButton.UseVisualStyleBackColor = true;
            this.customButton.Click += new System.EventHandler(this.customButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Location = new System.Drawing.Point(0, 153);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(395, 152);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter Options";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.openSubBtn);
            this.groupBox7.Controls.Add(this.subText);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.sharpCombo);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.noiseCombo);
            this.groupBox7.Location = new System.Drawing.Point(196, 22);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(192, 125);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Post-Processing";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(10, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 15);
            this.label14.TabIndex = 16;
            this.label14.Text = "Subtitle";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // openSubBtn
            // 
            this.openSubBtn.Location = new System.Drawing.Point(154, 86);
            this.openSubBtn.Name = "openSubBtn";
            this.openSubBtn.Size = new System.Drawing.Size(29, 22);
            this.openSubBtn.TabIndex = 15;
            this.openSubBtn.Text = "...";
            this.openSubBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.openSubBtn.UseVisualStyleBackColor = true;
            this.openSubBtn.Click += new System.EventHandler(this.openSubBtn_Click);
            // 
            // subText
            // 
            this.subText.Location = new System.Drawing.Point(75, 86);
            this.subText.MaxLength = 4;
            this.subText.Name = "subText";
            this.subText.ReadOnly = true;
            this.subText.Size = new System.Drawing.Size(73, 20);
            this.subText.TabIndex = 12;
            this.subText.Text = "Select Subtitle file to use";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 15);
            this.label13.TabIndex = 14;
            this.label13.Text = "Sharpen";
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // sharpCombo
            // 
            this.sharpCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sharpCombo.FormattingEnabled = true;
            this.sharpCombo.Items.AddRange(new object[] {
            "None",
            "Light",
            "Medium",
            "Heavy",
            "Insane"});
            this.sharpCombo.Location = new System.Drawing.Point(75, 56);
            this.sharpCombo.Name = "sharpCombo";
            this.sharpCombo.Size = new System.Drawing.Size(94, 21);
            this.sharpCombo.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(10, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 15);
            this.label12.TabIndex = 12;
            this.label12.Text = "Denoiser";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // noiseCombo
            // 
            this.noiseCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.noiseCombo.FormattingEnabled = true;
            this.noiseCombo.Items.AddRange(new object[] {
            "None",
            "Light",
            "Medium",
            "Heavy",
            "Insane"});
            this.noiseCombo.Location = new System.Drawing.Point(75, 26);
            this.noiseCombo.Name = "noiseCombo";
            this.noiseCombo.Size = new System.Drawing.Size(94, 21);
            this.noiseCombo.TabIndex = 12;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.widthHeight);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.resizeCombo);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.fieldCombo);
            this.groupBox6.Location = new System.Drawing.Point(3, 22);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(187, 125);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Pre-Processing";
            // 
            // widthHeight
            // 
            this.widthHeight.DropDownWidth = 150;
            this.widthHeight.FormattingEnabled = true;
            this.widthHeight.Items.AddRange(new object[] {
            "320:240",
            "512:384",
            "640:360",
            "640:480",
            "736:416",
            "1280:720"});
            this.widthHeight.Location = new System.Drawing.Point(96, 87);
            this.widthHeight.Name = "widthHeight";
            this.widthHeight.Size = new System.Drawing.Size(73, 21);
            this.widthHeight.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Width/Heigth";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Resize";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // resizeCombo
            // 
            this.resizeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resizeCombo.DropDownWidth = 150;
            this.resizeCombo.FormattingEnabled = true;
            this.resizeCombo.Items.AddRange(new object[] {
            "None",
            "Soft",
            "Neutral",
            "Sharp",
            "Very Sharp (Lanczos4)",
            "Very Sharp (Spline36)"});
            this.resizeCombo.Location = new System.Drawing.Point(75, 56);
            this.resizeCombo.Name = "resizeCombo";
            this.resizeCombo.Size = new System.Drawing.Size(94, 21);
            this.resizeCombo.TabIndex = 9;
            this.resizeCombo.SelectedIndexChanged += new System.EventHandler(this.resizeCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Field";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // fieldCombo
            // 
            this.fieldCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fieldCombo.DropDownWidth = 100;
            this.fieldCombo.FormattingEnabled = true;
            this.fieldCombo.Items.AddRange(new object[] {
            "None",
            "FieldDeInterlace"});
            this.fieldCombo.Location = new System.Drawing.Point(75, 26);
            this.fieldCombo.Name = "fieldCombo";
            this.fieldCombo.Size = new System.Drawing.Size(94, 21);
            this.fieldCombo.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.audioCombo);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.audioBR);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(199, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 90);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Audio Options";
            // 
            // audioCombo
            // 
            this.audioCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioCombo.DropDownWidth = 90;
            this.audioCombo.FormattingEnabled = true;
            this.audioCombo.Items.AddRange(new object[] {
            "Nero AAC",
            "Vorbis",
            "FFmpeg AC-3"});
            this.audioCombo.Location = new System.Drawing.Point(75, 56);
            this.audioCombo.Name = "audioCombo";
            this.audioCombo.Size = new System.Drawing.Size(94, 24);
            this.audioCombo.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "Codec";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "kbps";
            // 
            // audioBR
            // 
            this.audioBR.Location = new System.Drawing.Point(75, 25);
            this.audioBR.MaxLength = 3;
            this.audioBR.Name = "audioBR";
            this.audioBR.Size = new System.Drawing.Size(52, 22);
            this.audioBR.TabIndex = 1;
            this.audioBR.Text = "40";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bitrate";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fileSizeRadio);
            this.groupBox2.Controls.Add(this.bitRateRadio);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.fileSize);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.videoCombo);
            this.groupBox2.Controls.Add(this.vidQualCombo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.videoBR);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 141);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Video Options";
            // 
            // fileSizeRadio
            // 
            this.fileSizeRadio.AutoSize = true;
            this.fileSizeRadio.Location = new System.Drawing.Point(3, 47);
            this.fileSizeRadio.Name = "fileSizeRadio";
            this.fileSizeRadio.Size = new System.Drawing.Size(77, 20);
            this.fileSizeRadio.TabIndex = 12;
            this.fileSizeRadio.Text = "File Size";
            this.fileSizeRadio.UseVisualStyleBackColor = true;
            // 
            // bitRateRadio
            // 
            this.bitRateRadio.AutoSize = true;
            this.bitRateRadio.Checked = true;
            this.bitRateRadio.Location = new System.Drawing.Point(3, 22);
            this.bitRateRadio.Name = "bitRateRadio";
            this.bitRateRadio.Size = new System.Drawing.Size(64, 20);
            this.bitRateRadio.TabIndex = 11;
            this.bitRateRadio.TabStop = true;
            this.bitRateRadio.Text = "Bitrate";
            this.bitRateRadio.UseVisualStyleBackColor = true;
            this.bitRateRadio.CheckedChanged += new System.EventHandler(this.bitRateRadio_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(139, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(28, 16);
            this.label17.TabIndex = 10;
            this.label17.Text = "MB";
            // 
            // fileSize
            // 
            this.fileSize.Enabled = false;
            this.fileSize.Location = new System.Drawing.Point(81, 47);
            this.fileSize.MaxLength = 4;
            this.fileSize.Name = "fileSize";
            this.fileSize.Size = new System.Drawing.Size(52, 22);
            this.fileSize.TabIndex = 8;
            this.fileSize.Text = "60";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Codec";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // videoCombo
            // 
            this.videoCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoCombo.DropDownWidth = 80;
            this.videoCombo.FormattingEnabled = true;
            this.videoCombo.Items.AddRange(new object[] {
            "x264",
            "Xvid",
            "Theora"});
            this.videoCombo.Location = new System.Drawing.Point(81, 105);
            this.videoCombo.Name = "videoCombo";
            this.videoCombo.Size = new System.Drawing.Size(94, 24);
            this.videoCombo.TabIndex = 6;
            this.videoCombo.SelectedIndexChanged += new System.EventHandler(this.videoCombo_SelectedIndexChanged);
            // 
            // vidQualCombo
            // 
            this.vidQualCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vidQualCombo.DropDownWidth = 180;
            this.vidQualCombo.FormattingEnabled = true;
            this.vidQualCombo.Items.AddRange(new object[] {
            "Medium",
            "High",
            "Very High",
            "Very High (+50mb Anime)",
            "Very High (-50mb Anime)",
            "Very High (TV-Shows/Movies)",
            "CRF (Anime)",
            "Ipod",
            "PSP",
            "PS3"});
            this.vidQualCombo.Location = new System.Drawing.Point(81, 75);
            this.vidQualCombo.Name = "vidQualCombo";
            this.vidQualCombo.Size = new System.Drawing.Size(94, 24);
            this.vidQualCombo.TabIndex = 5;
            this.vidQualCombo.SelectedIndexChanged += new System.EventHandler(this.vidQualCombo_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Quality";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(139, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "kbps";
            // 
            // videoBR
            // 
            this.videoBR.Location = new System.Drawing.Point(81, 21);
            this.videoBR.MaxLength = 4;
            this.videoBR.Name = "videoBR";
            this.videoBR.Size = new System.Drawing.Size(52, 22);
            this.videoBR.TabIndex = 3;
            this.videoBR.Text = "300";
            // 
            // openSub
            // 
            this.openSub.Filter = "Subtitle Files|*.ssa;*.ass;*.srt;*.sub;*.idx";
            // 
            // EncodeSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnDeleteTemplate);
            this.Controls.Add(this.templateCombo);
            this.Controls.Add(this.saveOptButton);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.customButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "EncodeSettings";
            this.Size = new System.Drawing.Size(398, 345);
            this.Load += new System.EventHandler(this.EncodeSettings_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteTemplate;
        private System.Windows.Forms.ComboBox templateCombo;
        private System.Windows.Forms.Button saveOptButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox containerCombo;
        private System.Windows.Forms.Button customButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button openSubBtn;
        private System.Windows.Forms.TextBox subText;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox sharpCombo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox noiseCombo;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox widthHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox resizeCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox fieldCombo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox audioCombo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox audioBR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton fileSizeRadio;
        private System.Windows.Forms.RadioButton bitRateRadio;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox fileSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox videoCombo;
        private System.Windows.Forms.ComboBox vidQualCombo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox videoBR;
        private System.Windows.Forms.OpenFileDialog openSub;





    }
}
