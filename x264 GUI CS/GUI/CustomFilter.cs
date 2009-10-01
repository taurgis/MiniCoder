using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using x264_GUI_CS.General;

namespace x264_GUI_CS
{
    public partial class CustomFilter : Form
    {
        public string[] customFiltOpts = new string[4];
        public EncodingOptions encOpts = new EncodingOptions();
        ApplicationSettings dir;
                
        public CustomFilter(ApplicationSettings dir)
        {
            InitializeComponent();
            this.dir = dir;
        }

        public void init()
        {
                fieldFilterText.Text = customFiltOpts[0];
                resizeFilterText.Text = customFiltOpts[1];
                noiseFilterText.Text = customFiltOpts[2];
                sharpFilterText.Text = customFiltOpts[3];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            customFiltOpts[0] = fieldFilterText.Text;
            customFiltOpts[1] = resizeFilterText.Text;
            customFiltOpts[2] = noiseFilterText.Text;
            customFiltOpts[3] = sharpFilterText.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            
            Task_Libraries.Avisynth avs = new Task_Libraries.Avisynth();

            encOpts.customFilter = new string[4];

            encOpts.customFilter[0] = fieldFilterText.Text;
            encOpts.customFilter[1] = resizeFilterText.Text;
            encOpts.customFilter[2] = noiseFilterText.Text;
            encOpts.customFilter[3] = sharpFilterText.Text;

            string script = avs.addFiltersNoLog(encOpts, dir);

            ScriptPreview preview = new ScriptPreview();
            preview.setScript(script);

            DialogResult result = preview.ShowDialog();

        }

        
    }
}
