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

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void Mode_Click(object sender, EventArgs e)
        {           
        }

        private void Xvid_load(object sender, EventArgs e)
        {
            ResetInterface();
        }

        private void Xvid_Load_1(object sender, EventArgs e)
        {
            ResetInterface();
        }

        private void ResetInterface()
        {
            cbMode.SelectedIndex = (int)XvidEncodingMode.CBR;
            BitrateBox.Value = 150;
        }

        public void UpdateData(ExtTemplate template) 
        {
            this.xTemplate = (XvidTemplate)template;
            this.CommandDisplay.Text = this.xTemplate.GenerateCommandLine();
        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.xController.ChangeMode(cbMode.SelectedIndex);
        }

        private void BitrateBox_ValueChanged(object sender, EventArgs e)
        {
            this.xController.ChangeBitrate(Int32.Parse(BitrateBox.Value.ToString()));
        }

        private void BitrateLabel_Click(object sender, EventArgs e)
        {

        }

        private void HVSMaskingLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
