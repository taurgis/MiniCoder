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

namespace MiniCoder_Reloaded
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            EncodingController controller = new EncodingController();
            controller.startEncode("C:\\Users\\Thomas Theunen\\Downloads\\_5BRe-encoded_20by_20steveyk_5DKioBaJi-12.mkv");
        
        }
    }
}
