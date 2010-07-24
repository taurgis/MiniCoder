namespace MiniCoder2.ApplicationManager.Gui
{
    partial class ApplicationUpdateForm
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
            this.btnCheckForUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clbApplicationList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnCheckForUpdate
            // 
            this.btnCheckForUpdate.Location = new System.Drawing.Point(279, 295);
            this.btnCheckForUpdate.Name = "btnCheckForUpdate";
            this.btnCheckForUpdate.Size = new System.Drawing.Size(124, 23);
            this.btnCheckForUpdate.TabIndex = 0;
            this.btnCheckForUpdate.Text = "Check for Updates";
            this.btnCheckForUpdate.UseVisualStyleBackColor = true;
            this.btnCheckForUpdate.Click += new System.EventHandler(this.btnCheckForUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // clbApplicationList
            // 
            this.clbApplicationList.FormattingEnabled = true;
            this.clbApplicationList.Items.AddRange(new object[] {
            "x264",
            "AviSynth"});
            this.clbApplicationList.Location = new System.Drawing.Point(36, 104);
            this.clbApplicationList.Name = "clbApplicationList";
            this.clbApplicationList.Size = new System.Drawing.Size(166, 124);
            this.clbApplicationList.TabIndex = 3;
            // 
            // ApplicationUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 490);
            this.Controls.Add(this.clbApplicationList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheckForUpdate);
            this.Name = "ApplicationUpdateForm";
            this.Text = "ApplicationUpdateForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheckForUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clbApplicationList;
    }
}