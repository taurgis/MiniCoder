using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;


namespace MiniCoder.GUI.AviSynth
{
    public partial class CustomFilter : Form
    {
        public string customFiltOpts { get; set; }


        public CustomFilter(string customFiltOpts)
        {
            InitializeComponent();
            this.customFiltOpts = customFiltOpts;
            fieldFilterText.Text = customFiltOpts;
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

     

      
    }
}
