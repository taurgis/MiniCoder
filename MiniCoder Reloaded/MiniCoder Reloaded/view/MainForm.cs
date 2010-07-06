using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MediaInfoWrapper;
using be.miniTech.minicoder.controller;
using be.miniTech.minicoder.model.inputfile;

namespace MiniCoder_Reloaded
{
    public partial class MainForm : Form
    {
        private InputFile currentFile;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            //AnalysisController.fetchFileInfo("C:\\Users\\Thomas Theunen\\Downloads\\_5BRe-encoded_20by_20steveyk_5DKioBaJi-12.mkv");

        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "AviSynth Scripts (*.avs)|*.avs|" +
                  "All supported encodable files|" +
                  "*.avs;*.ac3;*.mp2;*.mpa;*.wav;*.vob;*.mpg;*.mpeg;*.m2t*;*.m2v;*.mpv;*.tp;*.ts;*.trp;*.pva;*.vro;*.d2v;*.avi;*.mp4;*.mkv;*.rmvb|" +
                  "All files|*.*";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentFile = new AnalysisController().fetchFileInfo(openFileDialog.FileName);
            }
        }
    }
}
