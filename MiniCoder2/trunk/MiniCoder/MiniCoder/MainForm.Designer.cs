namespace MiniCoder2
{
    partial class MainForm
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
            this.btnAAC = new System.Windows.Forms.Button();
            this.btnXvid = new System.Windows.Forms.Button();
            this.btnMP3 = new System.Windows.Forms.Button();
            this.btnVorbis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAAC
            // 
            this.btnAAC.Location = new System.Drawing.Point(383, 76);
            this.btnAAC.Name = "btnAAC";
            this.btnAAC.Size = new System.Drawing.Size(75, 23);
            this.btnAAC.TabIndex = 0;
            this.btnAAC.Text = "AAC";
            this.btnAAC.UseVisualStyleBackColor = true;
            this.btnAAC.Click += new System.EventHandler(this.btnAAC_Click);
            // 
            // btnXvid
            // 
            this.btnXvid.Location = new System.Drawing.Point(383, 105);
            this.btnXvid.Name = "btnXvid";
            this.btnXvid.Size = new System.Drawing.Size(75, 23);
            this.btnXvid.TabIndex = 1;
            this.btnXvid.Text = "Xvid";
            this.btnXvid.UseVisualStyleBackColor = true;
            this.btnXvid.Click += new System.EventHandler(this.btnXvid_Click);
            // 
            // btnMP3
            // 
            this.btnMP3.Location = new System.Drawing.Point(464, 76);
            this.btnMP3.Name = "btnMP3";
            this.btnMP3.Size = new System.Drawing.Size(75, 23);
            this.btnMP3.TabIndex = 2;
            this.btnMP3.Text = "MP3";
            this.btnMP3.UseVisualStyleBackColor = true;
            this.btnMP3.Click += new System.EventHandler(this.btnMP3_Click);
            // 
            // btnVorbis
            // 
            this.btnVorbis.Location = new System.Drawing.Point(548, 76);
            this.btnVorbis.Name = "btnVorbis";
            this.btnVorbis.Size = new System.Drawing.Size(75, 23);
            this.btnVorbis.TabIndex = 3;
            this.btnVorbis.Text = "Vorbis";
            this.btnVorbis.UseVisualStyleBackColor = true;
            this.btnVorbis.Click += new System.EventHandler(this.btnVorbis_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 504);
            this.Controls.Add(this.btnVorbis);
            this.Controls.Add(this.btnMP3);
            this.Controls.Add(this.btnXvid);
            this.Controls.Add(this.btnAAC);
            this.Name = "MainForm";
            this.Text = "MiniCoder 2.0";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAAC;
        private System.Windows.Forms.Button btnXvid;
        private System.Windows.Forms.Button btnMP3;
        private System.Windows.Forms.Button btnVorbis;
    }
}

