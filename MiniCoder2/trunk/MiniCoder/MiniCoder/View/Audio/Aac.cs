using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiniCoder2.Controller.Applications;
using MiniCoder2.Model.Applications.Templates;

namespace MiniCoder2.View.Audio
{
    public partial class Aac : Form, TemplateForm
    {
        private TemplateController templateController;
        private AacTemplate aacTemplate;

        public Aac()
        {
            InitializeComponent();
            this.aacTemplate = new AacTemplate("Default");
            this.templateController = new TemplateController(this, aacTemplate);
        }

        private void Aac_Load(object sender, EventArgs e)
        {
            ResetInterface();
        }
 
        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMode.SelectedIndex.Equals(0))
            {
                nudBitrate.Enabled = false;
                nudQuality.Enabled = true;
            }
            else
            {
                nudBitrate.Enabled = true;
                nudQuality.Enabled = false;
            }

            UpdateCommandLine();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetInterface()
        {
            cbMode.SelectedIndex = 0;
            cbProfile.SelectedIndex = 0;
            cbSampleRate.SelectedIndex = 0;
            cbChannels.SelectedIndex = 0;
        }

        private void UpdateCommandLine()
        {
            templateController.GenerateCommandLine();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        public void SetCommandLine(String commandLine)
        {
            txtCommandLine.Text = commandLine;
        }

        public void UpdateModel()
        {
            switch (cbMode.SelectedIndex)
            {
                case 0:
                    aacTemplate.Mode = AudioEncodingMode.VBR;
                    break;
                case 1:
                    aacTemplate.Mode = AudioEncodingMode.CBR;
                    break;
                case 2:
                    aacTemplate.Mode = AudioEncodingMode.ABR;
                    break;
            }
        }

    }
}
