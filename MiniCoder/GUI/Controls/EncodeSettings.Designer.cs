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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncodeSettings));
            this.btnDeleteTemplate = new System.Windows.Forms.Button();
            this.templateCombo = new System.Windows.Forms.ComboBox();
            this.saveOptButton = new System.Windows.Forms.Button();
            this.containerOptions = new System.Windows.Forms.GroupBox();
            this.format = new System.Windows.Forms.Label();
            this.containerCombo = new System.Windows.Forms.ComboBox();
            this.customButton = new System.Windows.Forms.Button();
            this.filterOptions = new System.Windows.Forms.GroupBox();
            this.postprocessing = new System.Windows.Forms.GroupBox();
            this.subtitle = new System.Windows.Forms.Label();
            this.openSubBtn = new System.Windows.Forms.Button();
            this.subText = new System.Windows.Forms.TextBox();
            this.sharpenLabel = new System.Windows.Forms.Label();
            this.sharpCombo = new System.Windows.Forms.ComboBox();
            this.denoiserLabel = new System.Windows.Forms.Label();
            this.noiseCombo = new System.Windows.Forms.ComboBox();
            this.preProcessing = new System.Windows.Forms.GroupBox();
            this.widthHeight = new System.Windows.Forms.ComboBox();
            this.widthheightLabel = new System.Windows.Forms.Label();
            this.resize = new System.Windows.Forms.Label();
            this.resizeCombo = new System.Windows.Forms.ComboBox();
            this.field = new System.Windows.Forms.Label();
            this.fieldCombo = new System.Windows.Forms.ComboBox();
            this.audioOptions = new System.Windows.Forms.GroupBox();
            this.audioCombo = new System.Windows.Forms.ComboBox();
            this.audCodec = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.audioBR = new System.Windows.Forms.TextBox();
            this.audioBitrate = new System.Windows.Forms.Label();
            this.videoOptions = new System.Windows.Forms.GroupBox();
            this.fileSizeRadio = new System.Windows.Forms.RadioButton();
            this.bitRateRadio = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.fileSize = new System.Windows.Forms.TextBox();
            this.videoCodec = new System.Windows.Forms.Label();
            this.videoCombo = new System.Windows.Forms.ComboBox();
            this.vidQualCombo = new System.Windows.Forms.ComboBox();
            this.videoQuality = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.videoBR = new System.Windows.Forms.TextBox();
            this.openSub = new System.Windows.Forms.OpenFileDialog();
            this.settingsTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.containerOptions.SuspendLayout();
            this.filterOptions.SuspendLayout();
            this.postprocessing.SuspendLayout();
            this.preProcessing.SuspendLayout();
            this.audioOptions.SuspendLayout();
            this.videoOptions.SuspendLayout();
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
            this.saveOptButton.AutoSize = true;
            this.saveOptButton.Location = new System.Drawing.Point(181, 311);
            this.saveOptButton.Name = "saveOptButton";
            this.saveOptButton.Size = new System.Drawing.Size(60, 26);
            this.saveOptButton.TabIndex = 11;
            this.saveOptButton.Text = "Save";
            this.saveOptButton.UseVisualStyleBackColor = true;
            this.saveOptButton.Click += new System.EventHandler(this.saveOptButton_Click);
            // 
            // containerOptions
            // 
            this.containerOptions.Controls.Add(this.format);
            this.containerOptions.Controls.Add(this.containerCombo);
            this.containerOptions.Location = new System.Drawing.Point(199, 96);
            this.containerOptions.Name = "containerOptions";
            this.containerOptions.Size = new System.Drawing.Size(197, 51);
            this.containerOptions.TabIndex = 12;
            this.containerOptions.TabStop = false;
            this.containerOptions.Text = "Container";
            // 
            // format
            // 
            this.format.AutoSize = true;
            this.format.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.format.Location = new System.Drawing.Point(10, 24);
            this.format.Name = "format";
            this.format.Size = new System.Drawing.Size(46, 15);
            this.format.TabIndex = 10;
            this.format.Text = "Format";
            this.format.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // containerCombo
            // 
            this.containerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.containerCombo.FormattingEnabled = true;
            this.containerCombo.Items.AddRange(new object[] {
            "Matroska",
            "MP4",
            "Avi"});
            this.containerCombo.Location = new System.Drawing.Point(86, 19);
            this.containerCombo.Name = "containerCombo";
            this.containerCombo.Size = new System.Drawing.Size(94, 21);
            this.containerCombo.TabIndex = 5;
            this.settingsTooltip.SetToolTip(this.containerCombo, resources.GetString("containerCombo.ToolTip"));
            this.containerCombo.SelectedIndexChanged += new System.EventHandler(this.containerCombo_SelectedIndexChanged);
            // 
            // customButton
            // 
            this.customButton.AutoSize = true;
            this.customButton.Location = new System.Drawing.Point(6, 311);
            this.customButton.Name = "customButton";
            this.customButton.Size = new System.Drawing.Size(61, 26);
            this.customButton.TabIndex = 9;
            this.customButton.Text = "Custom";
            this.customButton.UseVisualStyleBackColor = true;
            this.customButton.Click += new System.EventHandler(this.customButton_Click);
            // 
            // filterOptions
            // 
            this.filterOptions.Controls.Add(this.postprocessing);
            this.filterOptions.Controls.Add(this.preProcessing);
            this.filterOptions.Location = new System.Drawing.Point(0, 153);
            this.filterOptions.Name = "filterOptions";
            this.filterOptions.Size = new System.Drawing.Size(395, 152);
            this.filterOptions.TabIndex = 10;
            this.filterOptions.TabStop = false;
            this.filterOptions.Text = "Filter Options";
            // 
            // postprocessing
            // 
            this.postprocessing.Controls.Add(this.subtitle);
            this.postprocessing.Controls.Add(this.openSubBtn);
            this.postprocessing.Controls.Add(this.subText);
            this.postprocessing.Controls.Add(this.sharpenLabel);
            this.postprocessing.Controls.Add(this.sharpCombo);
            this.postprocessing.Controls.Add(this.denoiserLabel);
            this.postprocessing.Controls.Add(this.noiseCombo);
            this.postprocessing.Location = new System.Drawing.Point(196, 22);
            this.postprocessing.Name = "postprocessing";
            this.postprocessing.Size = new System.Drawing.Size(192, 125);
            this.postprocessing.TabIndex = 1;
            this.postprocessing.TabStop = false;
            this.postprocessing.Text = "Post-Processing";
            // 
            // subtitle
            // 
            this.subtitle.AutoSize = true;
            this.subtitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitle.Location = new System.Drawing.Point(10, 90);
            this.subtitle.Name = "subtitle";
            this.subtitle.Size = new System.Drawing.Size(48, 15);
            this.subtitle.TabIndex = 16;
            this.subtitle.Text = "Subtitle";
            this.subtitle.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            // sharpenLabel
            // 
            this.sharpenLabel.AutoSize = true;
            this.sharpenLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sharpenLabel.Location = new System.Drawing.Point(11, 60);
            this.sharpenLabel.Name = "sharpenLabel";
            this.sharpenLabel.Size = new System.Drawing.Size(54, 15);
            this.sharpenLabel.TabIndex = 14;
            this.sharpenLabel.Text = "Sharpen";
            this.sharpenLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.sharpCombo.Location = new System.Drawing.Point(87, 56);
            this.sharpCombo.Name = "sharpCombo";
            this.sharpCombo.Size = new System.Drawing.Size(94, 21);
            this.sharpCombo.TabIndex = 13;
            // 
            // denoiserLabel
            // 
            this.denoiserLabel.AutoSize = true;
            this.denoiserLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denoiserLabel.Location = new System.Drawing.Point(10, 30);
            this.denoiserLabel.Name = "denoiserLabel";
            this.denoiserLabel.Size = new System.Drawing.Size(58, 15);
            this.denoiserLabel.TabIndex = 12;
            this.denoiserLabel.Text = "Denoiser";
            this.denoiserLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.noiseCombo.Location = new System.Drawing.Point(87, 26);
            this.noiseCombo.Name = "noiseCombo";
            this.noiseCombo.Size = new System.Drawing.Size(94, 21);
            this.noiseCombo.TabIndex = 12;
            this.settingsTooltip.SetToolTip(this.noiseCombo, "Video denoising is the process of removing noise \r\nfrom a video signal.\r\n");
            // 
            // preProcessing
            // 
            this.preProcessing.Controls.Add(this.widthHeight);
            this.preProcessing.Controls.Add(this.widthheightLabel);
            this.preProcessing.Controls.Add(this.resize);
            this.preProcessing.Controls.Add(this.resizeCombo);
            this.preProcessing.Controls.Add(this.field);
            this.preProcessing.Controls.Add(this.fieldCombo);
            this.preProcessing.Location = new System.Drawing.Point(3, 22);
            this.preProcessing.Name = "preProcessing";
            this.preProcessing.Size = new System.Drawing.Size(187, 125);
            this.preProcessing.TabIndex = 0;
            this.preProcessing.TabStop = false;
            this.preProcessing.Text = "Pre-Processing";
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
            this.widthHeight.Location = new System.Drawing.Point(107, 87);
            this.widthHeight.Name = "widthHeight";
            this.widthHeight.Size = new System.Drawing.Size(73, 21);
            this.widthHeight.TabIndex = 12;
            this.settingsTooltip.SetToolTip(this.widthHeight, "The width and heigth of the re-encoded video.\r\n");
            // 
            // widthheightLabel
            // 
            this.widthheightLabel.AutoSize = true;
            this.widthheightLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.widthheightLabel.Location = new System.Drawing.Point(13, 91);
            this.widthheightLabel.Name = "widthheightLabel";
            this.widthheightLabel.Size = new System.Drawing.Size(77, 15);
            this.widthheightLabel.TabIndex = 11;
            this.widthheightLabel.Text = "Width/Heigth";
            this.widthheightLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // resize
            // 
            this.resize.AutoSize = true;
            this.resize.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resize.Location = new System.Drawing.Point(14, 60);
            this.resize.Name = "resize";
            this.resize.Size = new System.Drawing.Size(45, 15);
            this.resize.TabIndex = 10;
            this.resize.Text = "Resize";
            this.resize.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.resizeCombo.Location = new System.Drawing.Point(86, 56);
            this.resizeCombo.Name = "resizeCombo";
            this.resizeCombo.Size = new System.Drawing.Size(94, 21);
            this.resizeCombo.TabIndex = 9;
            this.settingsTooltip.SetToolTip(this.resizeCombo, resources.GetString("resizeCombo.ToolTip"));
            this.resizeCombo.SelectedIndexChanged += new System.EventHandler(this.resizeCombo_SelectedIndexChanged);
            // 
            // field
            // 
            this.field.AutoSize = true;
            this.field.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.field.Location = new System.Drawing.Point(14, 30);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(34, 15);
            this.field.TabIndex = 8;
            this.field.Text = "Field";
            this.field.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // fieldCombo
            // 
            this.fieldCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fieldCombo.DropDownWidth = 100;
            this.fieldCombo.FormattingEnabled = true;
            this.fieldCombo.Items.AddRange(new object[] {
            "None",
            "FieldDeInterlace",
            "AAA"});
            this.fieldCombo.Location = new System.Drawing.Point(86, 26);
            this.fieldCombo.Name = "fieldCombo";
            this.fieldCombo.Size = new System.Drawing.Size(94, 21);
            this.fieldCombo.TabIndex = 8;
            this.settingsTooltip.SetToolTip(this.fieldCombo, "FieldDeinterlace: \r\nThis filter provides functionality similar to the postprocess" +
                    "ing function \r\nof Telecide. You can use it for pure interlaced streams \r\n");
            // 
            // audioOptions
            // 
            this.audioOptions.Controls.Add(this.audioCombo);
            this.audioOptions.Controls.Add(this.audCodec);
            this.audioOptions.Controls.Add(this.label5);
            this.audioOptions.Controls.Add(this.audioBR);
            this.audioOptions.Controls.Add(this.audioBitrate);
            this.audioOptions.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioOptions.Location = new System.Drawing.Point(199, 6);
            this.audioOptions.Name = "audioOptions";
            this.audioOptions.Size = new System.Drawing.Size(197, 90);
            this.audioOptions.TabIndex = 8;
            this.audioOptions.TabStop = false;
            this.audioOptions.Text = "Audio Options";
            // 
            // audioCombo
            // 
            this.audioCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioCombo.DropDownWidth = 90;
            this.audioCombo.FormattingEnabled = true;
            this.audioCombo.Items.AddRange(new object[] {
            "Nero AAC",
            "Vorbis",
            "FFmpeg AC-3",
            "Lame MP3"});
            this.audioCombo.Location = new System.Drawing.Point(86, 53);
            this.audioCombo.Name = "audioCombo";
            this.audioCombo.Size = new System.Drawing.Size(94, 24);
            this.audioCombo.TabIndex = 9;
            this.settingsTooltip.SetToolTip(this.audioCombo, "Both audio codecs provide high quality at low bitrates.\r\n\r\nRecommended: Nero AAC\r" +
                    "\n");
            // 
            // audCodec
            // 
            this.audCodec.AutoSize = true;
            this.audCodec.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audCodec.Location = new System.Drawing.Point(9, 60);
            this.audCodec.Name = "audCodec";
            this.audCodec.Size = new System.Drawing.Size(43, 15);
            this.audCodec.TabIndex = 8;
            this.audCodec.Text = "Codec";
            this.audCodec.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "kbps";
            // 
            // audioBR
            // 
            this.audioBR.Location = new System.Drawing.Point(86, 22);
            this.audioBR.MaxLength = 3;
            this.audioBR.Name = "audioBR";
            this.audioBR.Size = new System.Drawing.Size(61, 22);
            this.audioBR.TabIndex = 1;
            this.audioBR.Text = "40";
            this.settingsTooltip.SetToolTip(this.audioBR, "Variable Audio Bitrate determines the quality of the audio output.\r\nThe higher th" +
                    "e bitrate the better the quality.\r\n\r\nRecommended: Minimum 32 Kbps\r\n");
            // 
            // audioBitrate
            // 
            this.audioBitrate.AutoSize = true;
            this.audioBitrate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioBitrate.Location = new System.Drawing.Point(10, 29);
            this.audioBitrate.Name = "audioBitrate";
            this.audioBitrate.Size = new System.Drawing.Size(42, 15);
            this.audioBitrate.TabIndex = 0;
            this.audioBitrate.Text = "Bitrate";
            this.audioBitrate.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // videoOptions
            // 
            this.videoOptions.Controls.Add(this.fileSizeRadio);
            this.videoOptions.Controls.Add(this.bitRateRadio);
            this.videoOptions.Controls.Add(this.label17);
            this.videoOptions.Controls.Add(this.fileSize);
            this.videoOptions.Controls.Add(this.videoCodec);
            this.videoOptions.Controls.Add(this.videoCombo);
            this.videoOptions.Controls.Add(this.vidQualCombo);
            this.videoOptions.Controls.Add(this.videoQuality);
            this.videoOptions.Controls.Add(this.label6);
            this.videoOptions.Controls.Add(this.videoBR);
            this.videoOptions.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoOptions.Location = new System.Drawing.Point(0, 6);
            this.videoOptions.Name = "videoOptions";
            this.videoOptions.Size = new System.Drawing.Size(193, 141);
            this.videoOptions.TabIndex = 7;
            this.videoOptions.TabStop = false;
            this.videoOptions.Text = "Video Options";
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
            this.label17.Location = new System.Drawing.Point(155, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(28, 16);
            this.label17.TabIndex = 10;
            this.label17.Text = "MB";
            // 
            // fileSize
            // 
            this.fileSize.Enabled = false;
            this.fileSize.Location = new System.Drawing.Point(100, 47);
            this.fileSize.MaxLength = 4;
            this.fileSize.Name = "fileSize";
            this.fileSize.Size = new System.Drawing.Size(52, 22);
            this.fileSize.TabIndex = 8;
            this.fileSize.Text = "60";
            this.settingsTooltip.SetToolTip(this.fileSize, resources.GetString("fileSize.ToolTip"));
            // 
            // videoCodec
            // 
            this.videoCodec.AutoSize = true;
            this.videoCodec.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoCodec.Location = new System.Drawing.Point(20, 109);
            this.videoCodec.Name = "videoCodec";
            this.videoCodec.Size = new System.Drawing.Size(43, 15);
            this.videoCodec.TabIndex = 7;
            this.videoCodec.Text = "Codec";
            this.videoCodec.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.settingsTooltip.SetToolTip(this.videoCombo, resources.GetString("videoCombo.ToolTip"));
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
            this.settingsTooltip.SetToolTip(this.vidQualCombo, resources.GetString("vidQualCombo.ToolTip"));
            this.vidQualCombo.SelectedIndexChanged += new System.EventHandler(this.vidQualCombo_SelectedIndexChanged);
            // 
            // videoQuality
            // 
            this.videoQuality.AutoSize = true;
            this.videoQuality.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoQuality.Location = new System.Drawing.Point(19, 79);
            this.videoQuality.Name = "videoQuality";
            this.videoQuality.Size = new System.Drawing.Size(44, 15);
            this.videoQuality.TabIndex = 4;
            this.videoQuality.Text = "Quality";
            this.videoQuality.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "kbps";
            // 
            // videoBR
            // 
            this.videoBR.Location = new System.Drawing.Point(100, 21);
            this.videoBR.MaxLength = 4;
            this.videoBR.Name = "videoBR";
            this.videoBR.Size = new System.Drawing.Size(52, 22);
            this.videoBR.TabIndex = 3;
            this.videoBR.Text = "300";
            this.settingsTooltip.SetToolTip(this.videoBR, resources.GetString("videoBR.ToolTip"));
            // 
            // openSub
            // 
            this.openSub.Filter = "Subtitle Files|*.ssa;*.ass;*.srt;*.sub;*.idx";
            // 
            // settingsTooltip
            // 
            this.settingsTooltip.AutoPopDelay = 200000;
            this.settingsTooltip.InitialDelay = 500;
            this.settingsTooltip.IsBalloon = true;
            this.settingsTooltip.ReshowDelay = 1000;
            this.settingsTooltip.ShowAlways = true;
            this.settingsTooltip.UseAnimation = false;
            this.settingsTooltip.UseFading = false;
            // 
            // EncodeSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnDeleteTemplate);
            this.Controls.Add(this.templateCombo);
            this.Controls.Add(this.saveOptButton);
            this.Controls.Add(this.containerOptions);
            this.Controls.Add(this.customButton);
            this.Controls.Add(this.filterOptions);
            this.Controls.Add(this.audioOptions);
            this.Controls.Add(this.videoOptions);
            this.Name = "EncodeSettings";
            this.Size = new System.Drawing.Size(398, 345);
            this.Load += new System.EventHandler(this.EncodeSettings_Load);
            this.containerOptions.ResumeLayout(false);
            this.containerOptions.PerformLayout();
            this.filterOptions.ResumeLayout(false);
            this.postprocessing.ResumeLayout(false);
            this.postprocessing.PerformLayout();
            this.preProcessing.ResumeLayout(false);
            this.preProcessing.PerformLayout();
            this.audioOptions.ResumeLayout(false);
            this.audioOptions.PerformLayout();
            this.videoOptions.ResumeLayout(false);
            this.videoOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteTemplate;
        private System.Windows.Forms.ComboBox templateCombo;
        private System.Windows.Forms.Button saveOptButton;
        private System.Windows.Forms.GroupBox containerOptions;
        private System.Windows.Forms.Label format;
        private System.Windows.Forms.ComboBox containerCombo;
        private System.Windows.Forms.Button customButton;
        private System.Windows.Forms.GroupBox filterOptions;
        private System.Windows.Forms.GroupBox postprocessing;
        private System.Windows.Forms.Label subtitle;
        private System.Windows.Forms.Button openSubBtn;
        private System.Windows.Forms.TextBox subText;
        private System.Windows.Forms.Label sharpenLabel;
        private System.Windows.Forms.ComboBox sharpCombo;
        private System.Windows.Forms.Label denoiserLabel;
        private System.Windows.Forms.ComboBox noiseCombo;
        private System.Windows.Forms.GroupBox preProcessing;
        private System.Windows.Forms.ComboBox widthHeight;
        private System.Windows.Forms.Label widthheightLabel;
        private System.Windows.Forms.Label resize;
        private System.Windows.Forms.ComboBox resizeCombo;
        private System.Windows.Forms.Label field;
        private System.Windows.Forms.ComboBox fieldCombo;
        private System.Windows.Forms.GroupBox audioOptions;
        private System.Windows.Forms.ComboBox audioCombo;
        private System.Windows.Forms.Label audCodec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox audioBR;
        private System.Windows.Forms.Label audioBitrate;
        private System.Windows.Forms.GroupBox videoOptions;
        private System.Windows.Forms.RadioButton fileSizeRadio;
        private System.Windows.Forms.RadioButton bitRateRadio;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox fileSize;
        private System.Windows.Forms.Label videoCodec;
        private System.Windows.Forms.ComboBox videoCombo;
        private System.Windows.Forms.ComboBox vidQualCombo;
        private System.Windows.Forms.Label videoQuality;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox videoBR;
        private System.Windows.Forms.OpenFileDialog openSub;
        private System.Windows.Forms.ToolTip settingsTooltip;





    }
}
