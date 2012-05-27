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
    public partial class Xvid : Form, TemplateForm<XvidTemplate>
    {
        XvidTemplate template;
        XvidTemplateController controller;

        public Xvid()
        {
            InitializeComponent();
            this.template = new XvidTemplate("Default");
            this.controller = new XvidTemplateController(this, template);
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

       
            nudBitrate.Value = 700;
            nudQuantization.Value = 8.0M;
            nudBFrames.Value = 2;
            nudThreads.Value = 1;
        }

        public void UpdateData(Object template)
        {
            this.template = (XvidTemplate)template;
            this.txtCommandLine.Text = this.template.GenerateCommandLine();
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

            this.controller.ChangeMode(cbMode.SelectedIndex);
        }

        private void nudBitrate_ValueChanged(object sender, EventArgs e)
        {
            this.controller.ChangeBitrate((int)nudBitrate.Value);
        }

        private void nudQuantization_ValueChanged(object sender, EventArgs e)
        {
            this.controller.ChangeQuantization(nudQuantization.Value);
        }

        private void cbVHQMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.ChangeVHQMode(cbVHQMode.SelectedIndex);
        }

        private void cbHVSMasking_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.ChangeHVSMasking(cbMotionSearch.SelectedIndex);
        }

        private void cbMotionSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.ChangeMotionSearch(cbMotionSearch.SelectedIndex);
        }

        private void nudThreads_ValueChanged(object sender, EventArgs e)
        {
            this.controller.ChangeThreads((int)nudThreads.Value);
        }

        private void nudBFrames_ValueChanged(object sender, EventArgs e)
        {
            this.controller.ChangeBFrames((int)nudBFrames.Value);
        }

        private void cbProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.xController.ChangeProfile(Int32.Parse(cbProfile.Text));
        }

        private void tbInterlaced_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.SelectInterlaced(tbInterlaced.Checked);
        }

        private void tbTurbo_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.SelectTurbo(tbTurbo.Checked);
        }

        private void tbTrellis_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.SelectTrellisQuant(tbTrellis.Checked);
        }

        private void tbPackedBitstream_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.SelectPackedBitstream(tbPackedBitstream.Checked);
        }

        private void tbAdaptiveQuantization_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.SelectAdaptiveQuant(tbAdaptiveQuantization.Checked);
        }

        private void tbQPel_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.SelectQPel(tbQPel.Checked);
        }

        private void tbGMC_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.SelectGMC(tbGMC.Checked);
        }

        private void tbChromaMotion_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.SelectChromaMotion(tbChromaMotion.Checked);
        }

        private void tbVHQBFrames_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.SelectVHQBFrames(tbVHQBFrames.Checked);
        }

        private void tbCloseGOP_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.SelectClosedGOP(tbCloseGOP.Checked);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                Template template = controller.ImportTemplate(openFileDialog.FileName);
                if (!template.Equals(null))
                {
                    MessageBox.Show("Import successfull!", "Success", MessageBoxButtons.OK);
                    UpdateData((XvidTemplate)template);
                    UpdateTemplateList(controller.FetchTemplateNames());
                }
            }

        }
    }
}