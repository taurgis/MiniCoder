namespace x264_GUI_CS.GUI
{
    partial class AppManagement
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
            this.components = new System.ComponentModel.Container();
            this.dgPrograms = new System.Windows.Forms.DataGridView();
            this.cProgram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRequired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDownload = new System.Windows.Forms.DataGridViewButtonColumn();
            this.appMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.customPathMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrograms)).BeginInit();
            this.appMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgPrograms
            // 
            this.dgPrograms.AllowUserToAddRows = false;
            this.dgPrograms.AllowUserToDeleteRows = false;
            this.dgPrograms.AllowUserToOrderColumns = true;
            this.dgPrograms.AllowUserToResizeRows = false;
            this.dgPrograms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPrograms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cProgram,
            this.cType,
            this.cLocation,
            this.cVersion,
            this.cRequired,
            this.cDownload});
            this.dgPrograms.ContextMenuStrip = this.appMenu;
            this.dgPrograms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPrograms.Location = new System.Drawing.Point(0, 0);
            this.dgPrograms.Name = "dgPrograms";
            this.dgPrograms.RowHeadersVisible = false;
            this.dgPrograms.Size = new System.Drawing.Size(603, 497);
            this.dgPrograms.TabIndex = 0;
            this.dgPrograms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPrograms_CellContentClick);
            // 
            // cProgram
            // 
            this.cProgram.HeaderText = "Addon";
            this.cProgram.Name = "cProgram";
            this.cProgram.ReadOnly = true;
            // 
            // cType
            // 
            this.cType.HeaderText = "Type";
            this.cType.Name = "cType";
            this.cType.ReadOnly = true;
            // 
            // cLocation
            // 
            this.cLocation.HeaderText = "Location";
            this.cLocation.Name = "cLocation";
            this.cLocation.ReadOnly = true;
            // 
            // cVersion
            // 
            this.cVersion.HeaderText = "Version";
            this.cVersion.Name = "cVersion";
            this.cVersion.ReadOnly = true;
            // 
            // cRequired
            // 
            this.cRequired.HeaderText = "Required";
            this.cRequired.Name = "cRequired";
            this.cRequired.ReadOnly = true;
            // 
            // cDownload
            // 
            this.cDownload.HeaderText = "Download";
            this.cDownload.Name = "cDownload";
            this.cDownload.ReadOnly = true;
            // 
            // appMenu
            // 
            this.appMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customPathMenuItem});
            this.appMenu.Name = "appMenu";
            this.appMenu.Size = new System.Drawing.Size(164, 48);
            // 
            // customPathMenuItem
            // 
            this.customPathMenuItem.Name = "customPathMenuItem";
            this.customPathMenuItem.Size = new System.Drawing.Size(163, 22);
            this.customPathMenuItem.Text = "Set custom path";
            this.customPathMenuItem.Click += new System.EventHandler(this.customPathMenuItem_Click);
            // 
            // AppManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 497);
            this.Controls.Add(this.dgPrograms);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppManagement";
            this.ShowInTaskbar = false;
            this.Text = "Applications";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AppManagement_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppManagement_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgPrograms)).EndInit();
            this.appMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

     

        #endregion

        private System.Windows.Forms.DataGridView dgPrograms;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProgram;
        private System.Windows.Forms.DataGridViewTextBoxColumn cType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn cVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRequired;
        private System.Windows.Forms.DataGridViewButtonColumn cDownload;
        private System.Windows.Forms.ContextMenuStrip appMenu;
        private System.Windows.Forms.ToolStripMenuItem customPathMenuItem;
    }
}