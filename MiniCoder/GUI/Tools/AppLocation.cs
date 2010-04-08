//    MiniCoder
//    Copyright (C) 2009-2010  MiniTech support@minitech.org
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using MiniCoder.External;
using MiniCoder.Core.Languages;
namespace MiniCoder.GUI.External
{
    public partial class AppLocation : Form
    {

        SortedList<String, Tool> packages;

        FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
        public AppLocation(SortedList<String, Tool> packages)
        {
            InitializeComponent();
            this.packages = packages;
            audioTab.Text = LanguageController.Instance.getLanguageString("audioTabTitle");
            videoTab.Text = LanguageController.Instance.getLanguageString("videoTabTitle");
            muxTab.Text = LanguageController.Instance.getLanguageString("muxingTabTitle");
            otherTab.Text = LanguageController.Instance.getLanguageString("otherTabTitle");
            saveApps.Text = LanguageController.Instance.getLanguageString("saveButton");
            cancelApps.Text = LanguageController.Instance.getLanguageString("updateCancelButton");
            this.Text = LanguageController.Instance.getLanguageString("customPathsTitle");
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
                        Tool package = (Tool)packages[key];
                        control.Text = package.getInstallPath();
                    }
                }

            }
        }

        private void customPath(string appName)
        {
            Tool tempPackage = (Tool)packages[appName];
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

        private void ffmpegSelect_Click(object sender, EventArgs e)
        {
            customPath("ffmpeg");
        }

        private void theoraSelect_Click(object sender, EventArgs e)
        {
            customPath("theora");
        }

        private void lameSelect_Click(object sender, EventArgs e)
        {
            customPath("lame");
        }
    }
}
