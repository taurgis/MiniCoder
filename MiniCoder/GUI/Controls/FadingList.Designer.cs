namespace MiniTech.MiniCoder.GUI.Controls
{
    partial class FadingList
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
            this.line6 = new System.Windows.Forms.Label();
            this.line5 = new System.Windows.Forms.Label();
            this.line4 = new System.Windows.Forms.Label();
            this.line3 = new System.Windows.Forms.Label();
            this.line2 = new System.Windows.Forms.Label();
            this.line1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // line6
            // 
            this.line6.BackColor = System.Drawing.Color.White;
            this.line6.Dock = System.Windows.Forms.DockStyle.Top;
            this.line6.Font = new System.Drawing.Font("Lucida Bright", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line6.ForeColor = System.Drawing.Color.Black;
            this.line6.Location = new System.Drawing.Point(0, 0);
            this.line6.Name = "line6";
            this.line6.Size = new System.Drawing.Size(310, 12);
            this.line6.TabIndex = 3;
            this.line6.Text = "Line 2";
            this.line6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.line6.Click += new System.EventHandler(this.line2_Click);
            // 
            // line5
            // 
            this.line5.BackColor = System.Drawing.Color.White;
            this.line5.Dock = System.Windows.Forms.DockStyle.Top;
            this.line5.Font = new System.Drawing.Font("Lucida Bright", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line5.ForeColor = System.Drawing.Color.Black;
            this.line5.Location = new System.Drawing.Point(0, 12);
            this.line5.Name = "line5";
            this.line5.Size = new System.Drawing.Size(310, 12);
            this.line5.TabIndex = 4;
            this.line5.Text = "Line 1";
            this.line5.Click += new System.EventHandler(this.line1_Click);
            // 
            // line4
            // 
            this.line4.BackColor = System.Drawing.Color.White;
            this.line4.Dock = System.Windows.Forms.DockStyle.Top;
            this.line4.Font = new System.Drawing.Font("Lucida Bright", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line4.ForeColor = System.Drawing.Color.Black;
            this.line4.Location = new System.Drawing.Point(0, 24);
            this.line4.Name = "line4";
            this.line4.Size = new System.Drawing.Size(310, 12);
            this.line4.TabIndex = 5;
            this.line4.Text = "Line 3";
            this.line4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.line4.Click += new System.EventHandler(this.label1_Click);
            // 
            // line3
            // 
            this.line3.BackColor = System.Drawing.Color.White;
            this.line3.Dock = System.Windows.Forms.DockStyle.Top;
            this.line3.Font = new System.Drawing.Font("Lucida Bright", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line3.ForeColor = System.Drawing.Color.Black;
            this.line3.Location = new System.Drawing.Point(0, 36);
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(310, 12);
            this.line3.TabIndex = 6;
            this.line3.Text = "Line 3";
            this.line3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // line2
            // 
            this.line2.BackColor = System.Drawing.Color.White;
            this.line2.Dock = System.Windows.Forms.DockStyle.Top;
            this.line2.Font = new System.Drawing.Font("Lucida Bright", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line2.ForeColor = System.Drawing.Color.Black;
            this.line2.Location = new System.Drawing.Point(0, 48);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(310, 12);
            this.line2.TabIndex = 7;
            this.line2.Text = "Line 3";
            this.line2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.White;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Font = new System.Drawing.Font("Lucida Bright", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line1.ForeColor = System.Drawing.Color.Black;
            this.line1.Location = new System.Drawing.Point(0, 60);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(310, 12);
            this.line1.TabIndex = 8;
            this.line1.Text = "Line 3";
            this.line1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FadingList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.line1);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.line3);
            this.Controls.Add(this.line4);
            this.Controls.Add(this.line5);
            this.Controls.Add(this.line6);
            this.Name = "FadingList";
            this.Size = new System.Drawing.Size(310, 75);
            this.Load += new System.EventHandler(this.FadingList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label line6;
        private System.Windows.Forms.Label line5;
        private System.Windows.Forms.Label line4;
        private System.Windows.Forms.Label line3;
        private System.Windows.Forms.Label line2;
        private System.Windows.Forms.Label line1;
    }
}
