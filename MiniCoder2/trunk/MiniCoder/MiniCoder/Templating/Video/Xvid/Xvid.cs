using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniCoder2.Templating.Video.Xvid
{
    public partial class Xvid : Form, TemplateForm
    {
        XvidTemplate xTemplate;
        XvidTemplateController xController;

        public Xvid()
        {
            InitializeComponent();
            this.xTemplate = new XvidTemplate("Default");
            this.xController = new XvidTemplateController(this, xTemplate);
        }

        private void Xvid_Load(object sender, EventArgs e)
        {
            ResetInterface();
        }

        private void ResetInterface()
        {
            cbMode.SelectedIndex = (int)XVidEncodingMode.CBR;
            cbMotionSearch.SelectedIndex = (int)XVidMotionSearch.UltraHigh;
            cbVHQMode.SelectedIndex = (int)XVidVHQMode.ModeDecision;
            cbHVSMasking.SelectedIndex = (int)XVidHVSMasking.None;
            cbProfile.SelectedIndex = (int)XVidProfile.None;

            xTemplate.InitialiseOptions();
            tbChromaMotion.Checked = (bool)xTemplate.XOptions["XChromaMotion"];
            tbTrellis.Checked = (bool)xTemplate.XOptions["XTrellisQuant"]; ;
            tbCloseGOP.Checked = (bool)xTemplate.XOptions["XClosedGOP"]; ;
            nudBitrate.Value = 700;
            nudQuantization.Value = 8.0M;
            nudBFrames.Value = 2;
            nudThreads.Value = 1;
        }

        public void UpdateData(ExtTemplate template) 
        {
            this.xTemplate = (XvidTemplate)template;
            this.CommandDisplay.Text = this.xTemplate.GenerateCommandLine();
        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMode.SelectedIndex == (int)XVidEncodingMode.CQ)
            {
                nudBitrate.Hide();
                nudQuantization.Show();
                CompressionLabel.Text = "Quantization:";
            }
            else
            {
                nudQuantization.Hide();
                nudBitrate.Show();
                CompressionLabel.Text = "Bitrate:"; 
            }

            this.xController.ChangeMode(cbMode.SelectedIndex);
        }

        private void nudBitrate_ValueChanged(object sender, EventArgs e)
        {
            this.xController.ChangeBitrate(Int32.Parse(nudBitrate.Value.ToString()));
        }       

        private void nudQuantization_ValueChanged(object sender, EventArgs e)
        {
            this.xController.ChangeQuantization(decimal.Parse(nudQuantization.Value.ToString()));
        }

        private void cbVHQMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.xController.ChangeVHQMode(cbVHQMode.SelectedIndex);
        }

        private void cbHVSMasking_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.xController.ChangeHVSMasking(cbMotionSearch.SelectedIndex);
        }

        private void cbMotionSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.xController.ChangeMotionSearch(cbMotionSearch.SelectedIndex);
        }

        private void nudThreads_ValueChanged(object sender, EventArgs e)
        {
            this.xController.ChangeThreads(Int32.Parse(nudThreads.Value.ToString()));
        }

        private void nudBFrames_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cbProfile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbInterlaced_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbTurbo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbTrellis_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbPackedBitstream_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbAdaptiveQuantization_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbQPel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbGMC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbChromaMotion_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbVHQBFrames_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbCloseGOP_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
