using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MiniCoder.Core.Languages;
using System.Text;
using System.Windows.Forms;


namespace MiniCoder.GUI.AviSynth
{
    public partial class CustomFilter : Form
    {
        public string customFiltOpts { get; set; }


        public CustomFilter(string customFiltOpts, SysLanguage language)
        {
            InitializeComponent();
            this.customFiltOpts = customFiltOpts;
            fieldFilterText.Text = customFiltOpts;
            this.Text = language.customFilterTitle;
            customLabel.Text = language.customFilterText;
            noteLabel.Text = language.customFilterNote;
            btnOK.Text = language.customFilterOK;
            btnCancel.Text = language.customFilterCancel;
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

        private void CustomFilter_Load(object sender, EventArgs e)
        {

        }

     

      
    }
}
