using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace MiniCoder
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

        private void ScriptPreview_Load(object sender, EventArgs e)
        {

        }
    }
}
