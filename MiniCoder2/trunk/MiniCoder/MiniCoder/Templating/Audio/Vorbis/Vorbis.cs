using System;
using System.Windows.Forms;

namespace MiniCoder2.Templating.Audio.Vorbis
{
    public partial class Vorbis : Form, TemplateForm
    {
        private VorbisTemplateController controller;
        private VorbisTemplate template;

        public Vorbis()
        {
            InitializeComponent();
            this.template = new VorbisTemplate("Default");
            this.controller = new VorbisTemplateController(this, template);
        }

        private void Aac_Load(object sender, EventArgs e)
        {
            ResetInterface();
            UpdateTemplateList(controller.FetchTemplateNames());
        }

        /// <summary>
        /// When variable bitrate is selected only the quality matters and bitrate is calculated
        /// automatically. On other modes quality is disabled and the bitrate is editable.
        /// </summary>
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

        /// <summary>
        /// Reset the interface to its default settings.
        /// </summary>
        private void ResetInterface()
        {
            cbMode.SelectedIndex = 0;
            cbSampleRate.SelectedIndex = 0;
            nudQuality.Value = (Decimal)0.5;
            nudDelay.Value = 0;
            nudBitrate.Value = 160;
            cbNormalize.Checked = true;
        }

        /// <summary>
        /// Update the model with all the information selected in the GUI.
        /// </summary>
        public void UpdateData(ExtTemplate template)
        {
            this.template = (VorbisTemplate)template;
            this.txtCommandLine.Text = template.GenerateCommandLine();

            this.nudBitrate.Value = this.template.BitRate;
            this.nudDelay.Value = this.template.Delay;
            if (!this.template.Quality.Equals(0.0))
                this.nudQuality.Value = (Decimal)this.template.Quality;

            cbMode.SelectedIndex = (int)this.template.Mode;
            cbNormalize.Checked = this.template.Normalize;

            switch (this.template.SampleRate)
            {
                case 0:
                    cbSampleRate.SelectedIndex = 0;
                    break;
                case SampleRate.Hz44100:
                    cbSampleRate.SelectedIndex = 1;
                    break;
                case SampleRate.Hz48000:
                    cbSampleRate.SelectedIndex = 2;
                    break;
                case SampleRate.Hz88200:
                    cbSampleRate.SelectedIndex = 3;
                    break;
                case SampleRate.Hz96000:
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

        private void cbSampleRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ChangeSampleRate(cbSampleRate.SelectedIndex);
        }

        private void cbNormalize_CheckedChanged(object sender, EventArgs e)
        {
            controller.ChangeNormalize(cbNormalize.Checked);
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
                    UpdateData((VorbisTemplate)template);
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