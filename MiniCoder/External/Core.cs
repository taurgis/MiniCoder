using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.GUI;
using System.IO;
using System.Windows.Forms;
namespace MiniCoder.External
{
    class Core : Tool
    {
        private string toolName;
        private string downloadPath;
      private string appType;
        private string category;

        public Core(string toolName, string appType, string downloadurl, string category, string customPath)
        {
            this.toolName = toolName;
            this.downloadPath = downloadurl;
            this.appType = appType;
            this.category = category;
        }
        public string getAppType()
        {
            return appType;
        }
        public string getCustomPath()
        {
            return "";
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
            if (File.Exists("MiniCoder.exe"))
                return true;
            else
                return false;
        }

        public void setCustomPath(string path)
        {
            //fake
        }

        public string getInstallPath()
        {


            return Application.StartupPath + "\\";
        }
        public void download()
        {
            try
            {
                Download frmDownload;
               
               
                    frmDownload = new Download(downloadPath, "", "core");
               
                frmDownload.startDownload();

                frmDownload.ShowDialog();
               
            }
            catch
            {

            }

        }

    }
}
