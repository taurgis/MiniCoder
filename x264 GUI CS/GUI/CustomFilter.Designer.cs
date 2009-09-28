namespace x264_GUI_CS
{
    partial class CustomFilter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.previewBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.sharpFilterText = new System.Windows.Forms.TextBox();
            this.noiseFilterText = new System.Windows.Forms.TextBox();
            this.resizeFilterText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.fieldFilterText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.previewBtn);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.sharpFilterText);
            this.groupBox1.Controls.Add(this.noiseFilterText);
            this.groupBox1.Controls.Add(this.resizeFilterText);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.fieldFilterText);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 250);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // previewBtn
            // 
            this.previewBtn.Location = new System.Drawing.Point(431, 216);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(80, 28);
            this.previewBtn.TabIndex = 24;
            this.previewBtn.Text = "Preview";
            this.previewBtn.UseVisualStyleBackColor = true;
            this.previewBtn.Click += new System.EventHandler(this.previewBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(475, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "Sharpening";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(321, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(151, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Denoising and Smoothing";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(166, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Resize and Deformation";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // sharpFilterText
            // 
            this.sharpFilterText.Location = new System.Drawing.Point(478, 60);
            this.sharpFilterText.Multiline = true;
            this.sharpFilterText.Name = "sharpFilterText";
            this.sharpFilterText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sharpFilterText.Size = new System.Drawing.Size(148, 122);
            this.sharpFilterText.TabIndex = 20;
            // 
            // noiseFilterText
            // 
            this.noiseFilterText.Location = new System.Drawing.Point(324, 60);
            this.noiseFilterText.Multiline = true;
            this.noiseFilterText.Name = "noiseFilterText";
            this.noiseFilterText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.noiseFilterText.Size = new System.Drawing.Size(148, 122);
            this.noiseFilterText.TabIndex = 19;
            // 
            // resizeFilterText
            // 
            this.resizeFilterText.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resizeFilterText.Location = new System.Drawing.Point(169, 60);
            this.resizeFilterText.Multiline = true;
            this.resizeFilterText.Name = "resizeFilterText";
            this.resizeFilterText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resizeFilterText.Size = new System.Drawing.Size(148, 122);
            this.resizeFilterText.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Field";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "If you want to disable a default filter disable it in the Settings Page.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Note:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(280, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(125, 216);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 28);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // fieldFilterText
            // 
            this.fieldFilterText.Location = new System.Drawing.Point(13, 60);
            this.fieldFilterText.Multiline = true;
            this.fieldFilterText.Name = "fieldFilterText";
            this.fieldFilterText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.fieldFilterText.Size = new System.Drawing.Size(148, 122);
            this.fieldFilterText.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Enter Your Custom Avisynth Filters";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // CustomFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 252);
            this.Controls.Add(this.groupBox1);
            this.Name = "CustomFilter";
            this.Text = "Custom Filter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox fieldFilterText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sharpFilterText;
        private System.Windows.Forms.TextBox noiseFilterText;
        private System.Windows.Forms.TextBox resizeFilterText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button previewBtn;
    }
}