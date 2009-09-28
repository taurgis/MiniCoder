using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace x264_GUI_CS
{
    public partial class ScriptPreview : Form
    {
        public ScriptPreview()
        {
            InitializeComponent();
         
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setScript(string script)
        {
            previewText.Text = script;
        }
    }
}
