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
using MiniCoder2.Templating.Audio.MP3;
using MiniCoder2.Templating.Audio.Vorbis;
using MiniCoder2.Templating.Audio.DTS;
using MiniCoder2.Templating.Audio.FLAC;
using MiniCoder2.Templating.Audio.AC3;

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

        private void btnMP3_Click(object sender, EventArgs e)
        {
            Mp3 frmMp3 = new Mp3();
            frmMp3.ShowDialog();
        }

        private void btnVorbis_Click(object sender, EventArgs e)
        {
            Vorbis frmVorbis = new Vorbis();
            frmVorbis.ShowDialog();
        }

        private void btnDTS_Click(object sender, EventArgs e)
        {
            Dts frmDTS = new Dts();
            frmDTS.ShowDialog();
        }

        private void btnFlac_Click(object sender, EventArgs e)
        {
            Flac frmFlac = new Flac();
            frmFlac.ShowDialog();
        }

        private void btnAc3_Click(object sender, EventArgs e)
        {
            Ac3 frmAc3 = new Ac3();
            frmAc3.ShowDialog();
        }
    }
}
