using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.GUI;
using System.IO;
namespace MiniCoder.External
{
    class AvsPlugin : Tool
    {
        private string toolName;
        private string downloadPath;
        private string customPath;
        private string category;
    
        private Tool aviSynth;
        public AvsPlugin(string toolName, string downloadurl, string category, Tool aviSynth)
        {
            this.toolName = toolName;
         
            this.downloadPath = downloadurl;
            this.category = category;
            this.aviSynth = aviSynth;
        }
        public string getAppType()
        {
            return "plugin";
        }
        public string getCustomPath()
        {
            return customPath;
        }
        public string getCategory()
        {
            return category;
        }
        public string getDownloadPath()
        {
            return downloadPath;
        }
        public Boolean isInstalled()
        {
           
            if (File.Exists(aviSynth.getInstallPath()+ toolName + ".dll"))
                return true;
            else
                return false;
        }

        public void setCustomPath(string path)
        {
            customPath = path;
        }

        public string getInstallPath()
        {
            if (!String.IsNullOrEmpty(customPath))
                return customPath + "\\";

            return aviSynth.getInstallPath();
        }

        public void download()
        {
            try
            {
                Download frmDownload;


                frmDownload = new Download(downloadPath, getInstallPath(), "dll");

                frmDownload.startDownload();

                frmDownload.ShowDialog();

            }
            catch
            {

            }

        }
    }
}
