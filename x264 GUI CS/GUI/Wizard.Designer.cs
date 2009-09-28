namespace x264_GUI_CS
{
    partial class Wizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wizard));
            this.openSub = new System.Windows.Forms.OpenFileDialog();
            this.openTemplate = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbp1 = new System.Windows.Forms.TabPage();
            this.tp2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStep1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pbTV = new System.Windows.Forms.PictureBox();
            this.pbQuality = new System.Windows.Forms.PictureBox();
            this.videoCombo = new System.Windows.Forms.ComboBox();
            this.vidQualCombo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblEncodingTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBitrate = new System.Windows.Forms.Label();
            this.btnStep2 = new System.Windows.Forms.Button();
            this.tp3 = new System.Windows.Forms.TabPage();
            this.audioCombo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.audioBR = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCodecDescription = new System.Windows.Forms.Label();
            this.btnStep3 = new System.Windows.Forms.Button();
            this.tp4 = new System.Windows.Forms.TabPage();
            this.pbSizeTest = new System.Windows.Forms.PictureBox();
            this.heightText = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.widthText = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.resizeCombo = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblResizeDescription = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.fileSizeRadio = new System.Windows.Forms.RadioButton();
            this.bitRateRadio = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.fileSize = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.videoBR = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tbp1.SuspendLayout();
            this.tp2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuality)).BeginInit();
            this.tp3.SuspendLayout();
            this.tp4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSizeTest)).BeginInit();
            this.SuspendLayout();
            // 
            // openSub
            // 
            this.openSub.FileName = "openFileDialog1";
            this.openSub.Filter = "Subtitle Files|*.ssa;*.ass;*.srt;*.sub;*.idx";
            // 
            // openTemplate
            // 
            this.openTemplate.Filter = "Template Files|*.tpl;";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbp1);
            this.tabControl1.Controls.Add(this.tp2);
            this.tabControl1.Controls.Add(this.tp3);
            this.tabControl1.Controls.Add(this.tp4);
            this.tabControl1.Location = new System.Drawing.Point(-4, -21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(629, 334);
            this.tabControl1.TabIndex = 0;
            // 
            // tbp1
            // 
            this.tbp1.BackColor = System.Drawing.Color.White;
            this.tbp1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbp1.Controls.Add(this.btnStep1);
            this.tbp1.Controls.Add(this.label2);
            this.tbp1.Controls.Add(this.label1);
            this.tbp1.Location = new System.Drawing.Point(4, 22);
            this.tbp1.Name = "tbp1";
            this.tbp1.Padding = new System.Windows.Forms.Padding(3);
            this.tbp1.Size = new System.Drawing.Size(621, 308);
            this.tbp1.TabIndex = 0;
            this.tbp1.Text = "x";
            this.tbp1.UseVisualStyleBackColor = true;
            this.tbp1.Click += new System.EventHandler(this.tbp1_Click);
            // 
            // tp2
            // 
            this.tp2.BackColor = System.Drawing.Color.White;
            this.tp2.Controls.Add(this.fileSizeRadio);
            this.tp2.Controls.Add(this.bitRateRadio);
            this.tp2.Controls.Add(this.label19);
            this.tp2.Controls.Add(this.fileSize);
            this.tp2.Controls.Add(this.label20);
            this.tp2.Controls.Add(this.videoBR);
            this.tp2.Controls.Add(this.btnStep2);
            this.tp2.Controls.Add(this.lblBitrate);
            this.tp2.Controls.Add(this.label5);
            this.tp2.Controls.Add(this.lblEncodingTime);
            this.tp2.Controls.Add(this.label6);
            this.tp2.Controls.Add(this.lblDescription);
            this.tp2.Controls.Add(this.label4);
            this.tp2.Controls.Add(this.label9);
            this.tp2.Controls.Add(this.label8);
            this.tp2.Controls.Add(this.videoCombo);
            this.tp2.Controls.Add(this.vidQualCombo);
            this.tp2.Controls.Add(this.pbQuality);
            this.tp2.Controls.Add(this.pbTV);
            this.tp2.Controls.Add(this.label3);
            this.tp2.Location = new System.Drawing.Point(4, 22);
            this.tp2.Name = "tp2";
            this.tp2.Padding = new System.Windows.Forms.Padding(3);
            this.tp2.Size = new System.Drawing.Size(621, 308);
            this.tp2.TabIndex = 1;
            this.tp2.Text = "tp2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hi there";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 120);
            this.label2.TabIndex = 2;
            this.label2.Text = "It seems this is your first time starting up MiniCoder.\r\n\r\nWe will try to guide y" +
                "ou through setting up the program as easy as possible.\r\n\r\nSo what are you waitin" +
                "g for? \r\nPress \"Get Started\"!";
            // 
            // btnStep1
            // 
            this.btnStep1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnStep1.FlatAppearance.BorderSize = 0;
            this.btnStep1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnStep1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnStep1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStep1.Location = new System.Drawing.Point(22, 155);
            this.btnStep1.Name = "btnStep1";
            this.btnStep1.Size = new System.Drawing.Size(75, 131);
            this.btnStep1.TabIndex = 3;
            this.btnStep1.Text = "\r\n\r\n\r\n  Get\r\nStarted";
            this.btnStep1.UseVisualStyleBackColor = true;
            this.btnStep1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Video Quality";
            // 
            // pbTV
            // 
            this.pbTV.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbTV.BackgroundImage")));
            this.pbTV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbTV.ErrorImage = null;
            this.pbTV.Location = new System.Drawing.Point(210, 27);
            this.pbTV.Name = "pbTV";
            this.pbTV.Size = new System.Drawing.Size(400, 275);
            this.pbTV.TabIndex = 5;
            this.pbTV.TabStop = false;
            this.pbTV.Click += new System.EventHandler(this.pbTV_Click);
            // 
            // pbQuality
            // 
            this.pbQuality.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbQuality.Location = new System.Drawing.Point(224, 48);
            this.pbQuality.Name = "pbQuality";
            this.pbQuality.Size = new System.Drawing.Size(372, 208);
            this.pbQuality.TabIndex = 6;
            this.pbQuality.TabStop = false;
            // 
            // videoCombo
            // 
            this.videoCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoCombo.FormattingEnabled = true;
            this.videoCombo.Items.AddRange(new object[] {
            "x264",
            "Xvid"});
            this.videoCombo.Location = new System.Drawing.Point(72, 56);
            this.videoCombo.Name = "videoCombo";
            this.videoCombo.Size = new System.Drawing.Size(132, 21);
            this.videoCombo.TabIndex = 8;
            this.videoCombo.SelectedIndexChanged += new System.EventHandler(this.videoCombo_SelectedIndexChanged);
            // 
            // vidQualCombo
            // 
            this.vidQualCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vidQualCombo.DropDownWidth = 140;
            this.vidQualCombo.FormattingEnabled = true;
            this.vidQualCombo.Items.AddRange(new object[] {
            "Medium",
            "High",
            "Very High",
            "MT (+50mb Anime)",
            "MT-2 (-50mb Anime)",
            "MT-3 (TV-Shows/Movies)",
            "AniStash (CRF)"});
            this.vidQualCombo.Location = new System.Drawing.Point(72, 30);
            this.vidQualCombo.Name = "vidQualCombo";
            this.vidQualCombo.Size = new System.Drawing.Size(132, 21);
            this.vidQualCombo.TabIndex = 7;
            this.vidQualCombo.SelectedIndexChanged += new System.EventHandler(this.vidQualCombo_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Codec";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Quality";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Description:";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(15, 145);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(189, 100);
            this.lblDescription.TabIndex = 12;
            // 
            // lblEncodingTime
            // 
            this.lblEncodingTime.Location = new System.Drawing.Point(105, 250);
            this.lblEncodingTime.Name = "lblEncodingTime";
            this.lblEncodingTime.Size = new System.Drawing.Size(87, 20);
            this.lblEncodingTime.TabIndex = 14;
            this.lblEncodingTime.Click += new System.EventHandler(this.lblEncodingTime_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Encoding Time";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Example Bitrate:";
            // 
            // lblBitrate
            // 
            this.lblBitrate.Location = new System.Drawing.Point(105, 278);
            this.lblBitrate.Name = "lblBitrate";
            this.lblBitrate.Size = new System.Drawing.Size(371, 20);
            this.lblBitrate.TabIndex = 16;
            this.lblBitrate.Click += new System.EventHandler(this.lblBitrate_Click);
            // 
            // btnStep2
            // 
            this.btnStep2.Location = new System.Drawing.Point(521, 279);
            this.btnStep2.Name = "btnStep2";
            this.btnStep2.Size = new System.Drawing.Size(75, 23);
            this.btnStep2.TabIndex = 17;
            this.btnStep2.Text = "Next";
            this.btnStep2.UseVisualStyleBackColor = true;
            this.btnStep2.Click += new System.EventHandler(this.btnStep2_Click);
            // 
            // tp3
            // 
            this.tp3.BackColor = System.Drawing.Color.White;
            this.tp3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tp3.Controls.Add(this.btnStep3);
            this.tp3.Controls.Add(this.lblCodecDescription);
            this.tp3.Controls.Add(this.label13);
            this.tp3.Controls.Add(this.label12);
            this.tp3.Controls.Add(this.audioCombo);
            this.tp3.Controls.Add(this.label10);
            this.tp3.Controls.Add(this.label7);
            this.tp3.Controls.Add(this.audioBR);
            this.tp3.Controls.Add(this.label11);
            this.tp3.Location = new System.Drawing.Point(4, 22);
            this.tp3.Name = "tp3";
            this.tp3.Size = new System.Drawing.Size(621, 308);
            this.tp3.TabIndex = 2;
            this.tp3.Text = "tp3";
            // 
            // audioCombo
            // 
            this.audioCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioCombo.DropDownWidth = 90;
            this.audioCombo.FormattingEnabled = true;
            this.audioCombo.Items.AddRange(new object[] {
            "Nero AAC",
            "Vorbis"});
            this.audioCombo.Location = new System.Drawing.Point(83, 65);
            this.audioCombo.Name = "audioCombo";
            this.audioCombo.Size = new System.Drawing.Size(73, 21);
            this.audioCombo.TabIndex = 14;
            this.audioCombo.SelectedIndexChanged += new System.EventHandler(this.audioCombo_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "Codec";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "kbps";
            // 
            // audioBR
            // 
            this.audioBR.Location = new System.Drawing.Point(83, 34);
            this.audioBR.MaxLength = 3;
            this.audioBR.Name = "audioBR";
            this.audioBR.Size = new System.Drawing.Size(52, 20);
            this.audioBR.TabIndex = 11;
            this.audioBR.Text = "40";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Bitrate";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(21, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(267, 116);
            this.label12.TabIndex = 15;
            this.label12.Text = resources.GetString("label12.Text");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 23);
            this.label13.TabIndex = 16;
            this.label13.Text = "Audio Quality";
            // 
            // lblCodecDescription
            // 
            this.lblCodecDescription.Location = new System.Drawing.Point(192, 11);
            this.lblCodecDescription.Name = "lblCodecDescription";
            this.lblCodecDescription.Size = new System.Drawing.Size(325, 91);
            this.lblCodecDescription.TabIndex = 19;
            // 
            // btnStep3
            // 
            this.btnStep3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnStep3.FlatAppearance.BorderSize = 0;
            this.btnStep3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnStep3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnStep3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStep3.Location = new System.Drawing.Point(33, 235);
            this.btnStep3.Name = "btnStep3";
            this.btnStep3.Size = new System.Drawing.Size(123, 56);
            this.btnStep3.TabIndex = 20;
            this.btnStep3.UseVisualStyleBackColor = true;
            this.btnStep3.Click += new System.EventHandler(this.btnStep3_Click);
            // 
            // tp4
            // 
            this.tp4.BackColor = System.Drawing.Color.White;
            this.tp4.Controls.Add(this.btnSave);
            this.tp4.Controls.Add(this.label18);
            this.tp4.Controls.Add(this.lblResizeDescription);
            this.tp4.Controls.Add(this.label17);
            this.tp4.Controls.Add(this.heightText);
            this.tp4.Controls.Add(this.label15);
            this.tp4.Controls.Add(this.label14);
            this.tp4.Controls.Add(this.widthText);
            this.tp4.Controls.Add(this.label16);
            this.tp4.Controls.Add(this.resizeCombo);
            this.tp4.Controls.Add(this.pbSizeTest);
            this.tp4.Location = new System.Drawing.Point(4, 22);
            this.tp4.Name = "tp4";
            this.tp4.Size = new System.Drawing.Size(621, 308);
            this.tp4.TabIndex = 3;
            this.tp4.Text = "tp4";
            // 
            // pbSizeTest
            // 
            this.pbSizeTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSizeTest.Location = new System.Drawing.Point(273, 56);
            this.pbSizeTest.Name = "pbSizeTest";
            this.pbSizeTest.Size = new System.Drawing.Size(337, 177);
            this.pbSizeTest.TabIndex = 0;
            this.pbSizeTest.TabStop = false;
            // 
            // heightText
            // 
            this.heightText.Enabled = false;
            this.heightText.Location = new System.Drawing.Point(141, 83);
            this.heightText.MaxLength = 4;
            this.heightText.Name = "heightText";
            this.heightText.Size = new System.Drawing.Size(35, 20);
            this.heightText.TabIndex = 19;
            this.heightText.TextChanged += new System.EventHandler(this.heightText_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(92, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 15);
            this.label15.TabIndex = 18;
            this.label15.Text = "Height";
            this.label15.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 15);
            this.label14.TabIndex = 17;
            this.label14.Text = "Width";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // widthText
            // 
            this.widthText.Enabled = false;
            this.widthText.Location = new System.Drawing.Point(56, 82);
            this.widthText.MaxLength = 4;
            this.widthText.Name = "widthText";
            this.widthText.Size = new System.Drawing.Size(35, 20);
            this.widthText.TabIndex = 14;
            this.widthText.TextChanged += new System.EventHandler(this.widthText_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 15);
            this.label16.TabIndex = 16;
            this.label16.Text = "Resize";
            this.label16.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.resizeCombo.Location = new System.Drawing.Point(73, 52);
            this.resizeCombo.Name = "resizeCombo";
            this.resizeCombo.Size = new System.Drawing.Size(73, 21);
            this.resizeCombo.TabIndex = 15;
            this.resizeCombo.SelectedIndexChanged += new System.EventHandler(this.resizeCombo_SelectedIndexChanged_1);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(270, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 13);
            this.label17.TabIndex = 20;
            this.label17.Text = "Scale: 4:1";
            // 
            // lblResizeDescription
            // 
            this.lblResizeDescription.Location = new System.Drawing.Point(15, 124);
            this.lblResizeDescription.Name = "lblResizeDescription";
            this.lblResizeDescription.Size = new System.Drawing.Size(239, 65);
            this.lblResizeDescription.TabIndex = 21;
            this.lblResizeDescription.Text = "Reisizing Filters determin how the video comes out greatly. You can sharpen a vid" +
                "eo or make it smoother...";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(11, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(129, 23);
            this.label18.TabIndex = 22;
            this.label18.Text = "Resizing Filters";
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(95, 174);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 131);
            this.btnSave.TabIndex = 23;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // fileSizeRadio
            // 
            this.fileSizeRadio.AutoSize = true;
            this.fileSizeRadio.Location = new System.Drawing.Point(16, 105);
            this.fileSizeRadio.Name = "fileSizeRadio";
            this.fileSizeRadio.Size = new System.Drawing.Size(64, 17);
            this.fileSizeRadio.TabIndex = 23;
            this.fileSizeRadio.Text = "File Size";
            this.fileSizeRadio.UseVisualStyleBackColor = true;
            this.fileSizeRadio.CheckedChanged += new System.EventHandler(this.fileSizeRadio_CheckedChanged);
            // 
            // bitRateRadio
            // 
            this.bitRateRadio.AutoSize = true;
            this.bitRateRadio.Checked = true;
            this.bitRateRadio.Location = new System.Drawing.Point(16, 80);
            this.bitRateRadio.Name = "bitRateRadio";
            this.bitRateRadio.Size = new System.Drawing.Size(55, 17);
            this.bitRateRadio.TabIndex = 22;
            this.bitRateRadio.TabStop = true;
            this.bitRateRadio.Text = "Bitrate";
            this.bitRateRadio.UseVisualStyleBackColor = true;
            this.bitRateRadio.CheckedChanged += new System.EventHandler(this.bitRateRadio_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(152, 111);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "MB";
            // 
            // fileSize
            // 
            this.fileSize.Enabled = false;
            this.fileSize.Location = new System.Drawing.Point(94, 105);
            this.fileSize.MaxLength = 4;
            this.fileSize.Name = "fileSize";
            this.fileSize.Size = new System.Drawing.Size(52, 20);
            this.fileSize.TabIndex = 20;
            this.fileSize.Text = "60";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(152, 86);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(30, 13);
            this.label20.TabIndex = 18;
            this.label20.Text = "kbps";
            // 
            // videoBR
            // 
            this.videoBR.Location = new System.Drawing.Point(94, 79);
            this.videoBR.MaxLength = 4;
            this.videoBR.Name = "videoBR";
            this.videoBR.Size = new System.Drawing.Size(52, 20);
            this.videoBR.TabIndex = 19;
            this.videoBR.Text = "300";
            // 
            // Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 308);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Wizard";
            this.Text = "Wizard";
            this.Load += new System.EventHandler(this.Wizard_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbp1.ResumeLayout(false);
            this.tbp1.PerformLayout();
            this.tp2.ResumeLayout(false);
            this.tp2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuality)).EndInit();
            this.tp3.ResumeLayout(false);
            this.tp3.PerformLayout();
            this.tp4.ResumeLayout(false);
            this.tp4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSizeTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openSub;
        private System.Windows.Forms.OpenFileDialog openTemplate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbp1;
        private System.Windows.Forms.TabPage tp2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStep1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbTV;
        private System.Windows.Forms.PictureBox pbQuality;
        private System.Windows.Forms.ComboBox videoCombo;
        private System.Windows.Forms.ComboBox vidQualCombo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBitrate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEncodingTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStep2;
        private System.Windows.Forms.TabPage tp3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox audioCombo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox audioBR;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCodecDescription;
        private System.Windows.Forms.Button btnStep3;
        private System.Windows.Forms.TabPage tp4;
        private System.Windows.Forms.PictureBox pbSizeTest;
        private System.Windows.Forms.TextBox heightText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox widthText;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox resizeCombo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblResizeDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton fileSizeRadio;
        private System.Windows.Forms.RadioButton bitRateRadio;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox fileSize;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox videoBR;
    }
}