﻿using System;
using System.Windows.Forms;

namespace MiniCoder2.Templating.Audio.WAV
{
    public partial class Wav : Form, TemplateForm
    {
        private WavTemplateController controller;
        private WavTemplate template;

        public Wav()
        {
            InitializeComponent();
            this.template = new WavTemplate("Default");
            this.controller = new WavTemplateController(this, template);
        }

        private void Aac_Load(object sender, EventArgs e)
        {
            ResetInterface();
            UpdateTemplateList(controller.FetchTemplateNames());
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Reset the interface to its default settings.
        /// </summary>
        private void ResetInterface()
        {
            cbSampleRate.SelectedIndex = 0;
            cbChannels.SelectedIndex = 0;
            nudDelay.Value = 0;
            cbDownConvert.Checked = false;
            cbNormalize.Checked = true;
            nudBitrate.Value = 160;
        }

        /// <summary>
        /// Update the model with all the information selected in the GUI.
        /// </summary>
        public void UpdateData(ExtTemplate template)
        {
            this.template = (WavTemplate)template;
            this.txtCommandLine.Text = template.GenerateCommandLine();
            this.nudDelay.Value = this.template.Delay;
            this.nudBitrate.Value = this.template.BitRate;

            switch (this.template.Channels)
            {
                case 1:
                    cbChannels.SelectedIndex = 0;
                    break;
                case 2:
                    cbChannels.SelectedIndex = 1;
                    break;
                case 6:
                    cbChannels.SelectedIndex = 2;
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

            cbDownConvert.Checked = this.template.DownConvert;
            cbNormalize.Checked = this.template.Normalize;

        }


        private void nudDelay_ValueChanged(object sender, EventArgs e)
        {
            controller.ChangeDelay((Int32.Parse(nudDelay.Value.ToString())));
        }

        private void cbChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ChangeChannels(cbChannels.SelectedIndex);
        }

        private void cbSampleRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ChangeSampleRate(cbSampleRate.SelectedIndex);
        }

        private void cbDownConvert_CheckedChanged(object sender, EventArgs e)
        {
            controller.ChangeDownConvert(cbDownConvert.Checked);
        }

        private void cbNormalize_CheckedChanged(object sender, EventArgs e)
        {
            controller.ChangeNormalize(cbNormalize.Checked);
        }

        private void nudBitrate_ValueChanged(object sender, EventArgs e)
        {
            controller.ChangeBitrate((Int32.Parse(nudBitrate.Value.ToString())));
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String name = Microsoft.VisualBasic.Interaction.InputBox("Please fill in a name", "Name", this.template.Name);

            controller.SaveTemplate(name);
            UpdateTemplateList(controller.FetchTemplateNames());
        }

        /// <summary>
        /// Show all templates for this type in the splitbutton menu.
        /// </summary>
        /// <param name="templateNames">Array of template names.</param>
        private void UpdateTemplateList(String[] templateNames)
        {
            mnuLoad.DropDownItems.Clear();
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

        /// <summary>
        /// Delete the current active template.
        /// </summary>
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete template " + this.template.Name + "?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                if (controller.DeleteTemplate())
                {
                    MessageBox.Show("Template deleted!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetInterface();
                }
                else
                    MessageBox.Show("Error deleting template.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                UpdateTemplateList(controller.FetchTemplateNames());
            }
        }


        private void mnuExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog searchFolderDialog = new FolderBrowserDialog();
            if (searchFolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (controller.ExportTemplate(searchFolderDialog.SelectedPath))
                    MessageBox.Show("File exported!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error exporting file!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Template XML (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ExtTemplate template = controller.ImportTemplate(openFileDialog.FileName);
                if (!template.Equals(null))
                {
                    MessageBox.Show("Import successfull!", "Success", MessageBoxButtons.OK);
                    UpdateData((WavTemplate)template);
                    UpdateTemplateList(controller.FetchTemplateNames());
                }
            }

        }

        /// <summary>
        /// When the user clicks ok the form will close and the main form will select
        /// this template.
        /// 
        /// TODO: Link to the main form. (Milestone 2)
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}