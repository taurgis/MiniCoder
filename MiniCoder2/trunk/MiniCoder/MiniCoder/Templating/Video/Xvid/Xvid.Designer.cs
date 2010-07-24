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
            this.BitrateBox = new System.Windows.Forms.NumericUpDown();
            this.BitrateLabel = new System.Windows.Forms.Label();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.CommandDisplay = new System.Windows.Forms.TextBox();
            this.Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BitrateBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.CommandDisplay);
            this.Settings.Controls.Add(this.BitrateBox);
            this.Settings.Controls.Add(this.BitrateLabel);
            this.Settings.Controls.Add(this.ModeLabel);
            this.Settings.Controls.Add(this.cbMode);
            this.Settings.Location = new System.Drawing.Point(12, 12);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(404, 202);
            this.Settings.TabIndex = 0;
            this.Settings.TabStop = false;
            this.Settings.Text = "Settings";
            this.Settings.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // BitrateBox
            // 
            this.BitrateBox.Location = new System.Drawing.Point(266, 20);
            this.BitrateBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.BitrateBox.Name = "BitrateBox";
            this.BitrateBox.Size = new System.Drawing.Size(120, 20);
            this.BitrateBox.TabIndex = 19;
            // 
            // BitrateLabel
            // 
            this.BitrateLabel.AutoSize = true;
            this.BitrateLabel.Location = new System.Drawing.Point(207, 22);
            this.BitrateLabel.Name = "BitrateLabel";
            this.BitrateLabel.Size = new System.Drawing.Size(40, 13);
            this.BitrateLabel.TabIndex = 18;
            this.BitrateLabel.Text = "Bitrate:";
            // 
            // ModeLabel
            // 
            this.ModeLabel.AutoSize = true;
            this.ModeLabel.Location = new System.Drawing.Point(12, 22);
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
            this.cbMode.Location = new System.Drawing.Point(76, 19);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(104, 21);
            this.cbMode.TabIndex = 15;
            // 
            // CommandDisplay
            // 
            this.CommandDisplay.Location = new System.Drawing.Point(15, 161);
            this.CommandDisplay.Name = "CommandDisplay";
            this.CommandDisplay.Size = new System.Drawing.Size(371, 20);
            this.CommandDisplay.TabIndex = 20;
            // 
            // Xvid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 223);
            this.Controls.Add(this.Settings);
            this.Name = "Xvid";
            this.Text = "Xvid";
            this.Load += new System.EventHandler(this.Xvid_Load_1);
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BitrateBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Settings;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label ModeLabel;
        private System.Windows.Forms.Label BitrateLabel;
        private System.Windows.Forms.NumericUpDown BitrateBox;
        private System.Windows.Forms.TextBox CommandDisplay;
    }
}