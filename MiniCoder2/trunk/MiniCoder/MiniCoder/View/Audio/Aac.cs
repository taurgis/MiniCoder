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
        private AacTemplateController controller;
        private AacTemplate template;

        public Aac()
        {
            InitializeComponent();
            this.template = new AacTemplate("Default");
            this.controller = new AacTemplateController(this, template);
            this.template.SetObserver(this);
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

            controller.ChangeMode(cbMode.SelectedIndex);
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

      
        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Update the model with all the information selected in the GUI.
        /// </summary>
        public void UpdateData(ExtTemplate template)
        {
            this.txtCommandLine.Text = template.GenerateCommandLine();
        }

    }
}
