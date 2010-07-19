using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiniCoder2.Exceptions;

namespace MiniCoder2.Templating.Audio.AAC
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
        }

        private void Aac_Load(object sender, EventArgs e)
        {
            ResetInterface();
            UpdateTemplateList(controller.FetchTemplateNames());
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
            nudQuality.Value = (Decimal)0.5;
            nudDelay.Value = 0;
            nudBitrate.Value = 160;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Update the model with all the information selected in the GUI.
        /// </summary>
        public void UpdateData(ExtTemplate template)
        {
            this.template = (AacTemplate)template;
            this.txtCommandLine.Text = template.GenerateCommandLine();

            this.nudBitrate.Value = this.template.BitRate;
            this.nudDelay.Value = this.template.Delay;
            if (!this.template.Quality.Equals(0.0))
                this.nudQuality.Value = (Decimal)this.template.Quality;

            cbMode.SelectedIndex = (int)this.template.Mode;
            cbProfile.SelectedIndex = (int)this.template.Profile;

            switch (this.template.Channels)
            {
                case 2:
                    cbChannels.SelectedIndex = 0;
                    break;
                case 6:
                    cbChannels.SelectedIndex = 1;
                    break;
                default:
                    cbChannels.SelectedIndex = 0;
                    break;
            }

            switch (this.template.SampleRate)
            {
                case 0:
                    cbSampleRate.SelectedIndex = 0;
                    break;
                case 44100:
                    cbSampleRate.SelectedIndex = 1;
                    break;
                case 48000:
                    cbSampleRate.SelectedIndex = 2;
                    break;
                case 88200:
                    cbSampleRate.SelectedIndex = 3;
                    break;
                case 96000:
                    cbSampleRate.SelectedIndex = 4;
                    break;
            }
        }

        private void nudQuality_ValueChanged(object sender, EventArgs e)
        {
            controller.ChangeQuality(Double.Parse(nudQuality.Value.ToString()));
        }

        private void nudBitrate_ValueChanged(object sender, EventArgs e)
        {
            controller.ChangeBitrate((Int32.Parse(nudBitrate.Value.ToString())));
        }

        private void nudDelay_ValueChanged(object sender, EventArgs e)
        {
            controller.ChangeDelay((Int32.Parse(nudDelay.Value.ToString())));
        }

        private void cbProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ChangeProfile(cbProfile.SelectedIndex);
        }

        private void cbChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ChangeChannels(cbChannels.SelectedIndex);
        }

        private void cbSampleRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ChangeSampleRate(cbSampleRate.SelectedIndex);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String name = Microsoft.VisualBasic.Interaction.InputBox("Please fill in a name", "Name", this.template.Name);

            controller.SaveTemplate(name);
        }

        private void UpdateTemplateList(String[] templateNames)
        {
            foreach (String templateName in templateNames)
            {
                ToolStripMenuItem tempMenuItem = new ToolStripMenuItem();
                tempMenuItem.Text = templateName;
                tempMenuItem.Click += new EventHandler(templateItemMenuItem_Click);

                mnuLoad.DropDownItems.Add(tempMenuItem);
            }
        }

        private void templateItemMenuItem_Click(object sender, EventArgs e)
        {
            String name = ((ToolStripMenuItem)sender).Text;
            controller.LoadTemplate(name);
        }

        private void mnuReset_Click(object sender, EventArgs e)
        {
            ResetInterface();
        }

    }
}
