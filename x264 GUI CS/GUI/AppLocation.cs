using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace MiniCoder.GUI
{
    public partial class AppLocation : Form
    {

        Hashtable packages;

        FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
        public AppLocation(Hashtable packages)
        {
            InitializeComponent();
            this.packages = packages;
        }

        private void madplaySelect_Click(object sender, EventArgs e)
        {
            customPath("madplay");

        }

        private void AppLocation_Load(object sender, EventArgs e)
        {
            foreach (string key in packages.Keys)
            {
                for (int i = 0; i < applicationTabs.TabCount; i++)
                {
                    Control control = applicationTabs.TabPages[i].Controls[key + "Path"];
                    if (control != null)
                    {
                        Package package = (Package)packages[key];
                        control.Text = package.getInstallPath();
                    }
                }

            }
        }

        private void customPath(string appName)
        {
            Package tempPackage = (Package)packages[appName];
            folderBrowser.ShowDialog();
            if (folderBrowser.SelectedPath != "")
                tempPackage.setCustomPath(folderBrowser.SelectedPath);

            packages.Remove(appName);
            packages.Add(appName, tempPackage);

            for (int i = 0; i < applicationTabs.TabCount; i++)
            {
                Control control = applicationTabs.TabPages[i].Controls[appName + "Path"];
                if (control != null)
                {
                    control.Text = tempPackage.getInstallPath();
                }
            }

        }

        private void flacSelect_Click(object sender, EventArgs e)
        {
            customPath("flac");
        }

        private void valdecSelect_Click(object sender, EventArgs e)
        {
            customPath("valdec");
        }

        private void faadSelect_Click(object sender, EventArgs e)
        {
            customPath("faad");
        }

        private void oggdecSelect_Click(object sender, EventArgs e)
        {
            customPath("oggdec");
        }

        private void besweetSelect_Click(object sender, EventArgs e)
        {
            customPath("besweet");
        }

        private void x264Select_Click(object sender, EventArgs e)
        {
            customPath("x264");
        }

        private void xvid_encrawSelect_Click(object sender, EventArgs e)
        {
            customPath("xvid_encraw");
        }

        private void DGAVCIndexSelect_Click(object sender, EventArgs e)
        {
            customPath("DGAVCIndex");
        }

        private void mp4boxSelect_Click(object sender, EventArgs e)
        {
            customPath("mp4box");
        }

        private void mkv2vfrSelect_Click(object sender, EventArgs e)
        {
            customPath("mkv2vfr");
        }

        private void mkvtoolnixSelect_Click(object sender, EventArgs e)
        {
            customPath("mkvtoolnix");
        }

        private void DGIndexSelect_Click(object sender, EventArgs e)
        {
            customPath("DGIndex");
        }

        private void ogmtoolsSelect_Click(object sender, EventArgs e)
        {
            customPath("ogmtools");
        }

        private void VirtualDubModSelect_Click(object sender, EventArgs e)
        {
            customPath("VirtualDubMod");
        }

        private void avs2yuvSelect_Click(object sender, EventArgs e)
        {
            customPath("avs2yuv");
        }
        Boolean save = false;
        private void saveApps_Click(object sender, EventArgs e)
        {
            save = true;
            this.Close();
        }

        public Boolean doSave()
        {
            return save;
        }

        private void cancelApps_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
