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
            this.SuspendLayout();
            // 
            // btnAAC
            // 
            this.btnAAC.Location = new System.Drawing.Point(437, 72);
            this.btnAAC.Name = "btnAAC";
            this.btnAAC.Size = new System.Drawing.Size(75, 23);
            this.btnAAC.TabIndex = 0;
            this.btnAAC.Text = "AAC";
            this.btnAAC.UseVisualStyleBackColor = true;
            this.btnAAC.Click += new System.EventHandler(this.btnAAC_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 504);
            this.Controls.Add(this.btnAAC);
            this.Name = "MainForm";
            this.Text = "MiniCoder 2.0";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAAC;
    }
}

