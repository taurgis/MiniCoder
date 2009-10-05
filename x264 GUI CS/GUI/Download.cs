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
namespace x264_GUI_CS.GUI
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
            if (typedl == "core")
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
                if (typedl == "core")
                    client.DownloadFileAsync(url, "dl.zip");
                else if (typedl == "dll")
                    client.DownloadFileAsync(url, "dl.zip");
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
                

                FastZip fz = new FastZip();

                if (!System.IO.Directory.Exists(Application.StartupPath))
                    fz.ExtractZip("dl.zip", Application.StartupPath, "");
            }
            else
            {
                string appfolder = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                FastZip fz = new FastZip();

                if (!System.IO.Directory.Exists(appfolder + "\\x264Encoder\\Tools"))
                    System.IO.Directory.CreateDirectory(appfolder + "\\x264Encoder\\Tools");

                fz.ExtractZip("dl.zip", appfolder + "\\x264Encoder\\Tools", "");
            }
           // MessageBox.Show("Install Completed");
            dlFinished = true;
            this.Close();
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
           
            pbDownload.Value = e.ProgressPercentage;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            client.CancelAsync();
            this.Close();
        }
    }
}
