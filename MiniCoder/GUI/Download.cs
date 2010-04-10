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
using System.Net;
using System.Diagnostics;
using ICSharpCode.SharpZipLib.Zip;
namespace MiniTech.MiniCoder.GUI
{
    public partial class Download : Form
    {
        String downloadurl;
        string downloadpath;
        string typedl;
       public Boolean dlFinished = false;
        public Download(string downloadurl, string downloadpath, string typedl)
        {
            InitializeComponent();
            this.downloadurl = downloadurl;
            this.downloadpath = downloadpath;
            this.typedl = typedl;
        }

        private void Download_Load(object sender, EventArgs e)
        {

        }
        WebClient client = new WebClient();
        public void startDownload()
        {
           
            Uri url = new Uri(downloadurl);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            if (typedl == "exe")
                client.DownloadFileAsync(url, "dl.exe");
            else if (typedl == "core")
                client.DownloadFileAsync(url, "dl.zip");
            else if (typedl == "dll")
                client.DownloadFileAsync(url, "dl.zip");
            else
                client.DownloadFileAsync(url, "dl.zip");
            
       }
        public Download startDownload(string te)
        {
            try
            {

                Uri url = new Uri(downloadurl);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                if (typedl == "exe")
                    client.DownloadFileAsync(url, "dl.exe");
                else
                    client.DownloadFileAsync(url, "dl.zip");
            }
            catch
            {
                MessageBox.Show("error downloading " + downloadurl);
            }
            return this;

        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            
                if (typedl == "exe")
                {

                    Process proc = new Process();

                    proc.StartInfo.FileName = "dl.exe";

                    proc.Start();
                    proc.WaitForExit();
                }
                else if (typedl == "dll")
                {
                    string appfolder = downloadpath;

                    FastZip fz = new FastZip();

                    if (System.IO.Directory.Exists(appfolder))
                        fz.ExtractZip("dl.zip", appfolder, "");
                }
                else if (typedl == "core")
                {
                    try
                    {
                        if (downloadurl != "http://www.gamerzzheaven.be/core.zip")
                        {
                            FastZip fz = new FastZip();

                            if (System.IO.Directory.Exists(Application.StartupPath))
                                fz.ExtractZip("dl.zip", Application.StartupPath, "");
                        }
                        }
                    catch
                    {
                        dlFinished = true;
                        this.Close();
                    }
                }
                else
                {
                    string appfolder = Application.StartupPath + "\\Tools\\";

                    FastZip fz = new FastZip();

                    if (!System.IO.Directory.Exists(appfolder))
                        System.IO.Directory.CreateDirectory(appfolder);

                    fz.ExtractZip("dl.zip", appfolder, "");
                }
                // MessageBox.Show("Install Completed");
                dlFinished = true;
                this.Close();
           
        }

        public Boolean isCompleted()
        {
            return dlFinished;
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
           
            pbDownload.Value = e.ProgressPercentage;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            client.CancelAsync();
            dlFinished = false;
            this.Close();
        }
    }
}
