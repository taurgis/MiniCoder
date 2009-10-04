using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using MiniCoder.General;
using x264_GUI_CS.General;

namespace x264_GUI_CS
{
    public partial class CustomFilter : Form
    {
        public string customFiltOpts;
        public EncodingOptions encOpts = new EncodingOptions();
        ApplicationSettings dir;
                
        public CustomFilter(ApplicationSettings dir)
        {
            InitializeComponent();
            this.dir = dir;
        }

        public void init()
        {
            fieldFilterText.Text = customFiltOpts;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            customFiltOpts = fieldFilterText.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            
            Task_Libraries.Avisynth avs = new Task_Libraries.Avisynth();

           

            encOpts.customFilter = fieldFilterText.Text;
      

            string script = avs.addFiltersNoLog(encOpts, dir);

            ScriptPreview preview = new ScriptPreview();
            preview.setScript(script);

            DialogResult result = preview.ShowDialog();

        }

        
    }
}
