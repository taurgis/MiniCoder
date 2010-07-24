using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiniCoder2.Templating.Audio.AAC;
using MiniCoder2.Templating.Video.Xvid;

namespace MiniCoder2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAAC_Click(object sender, EventArgs e)
        {
            Aac frmAac = new Aac();
            frmAac.ShowDialog();
        }

        private void btnXvid_Click(object sender, EventArgs e)
        {
            Xvid frmXvid = new Xvid();
            frmXvid.ShowDialog();
        }
    }
}
