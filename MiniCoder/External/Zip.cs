using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MiniCoder.GUI;

namespace MiniCoder.External
{
    class Zip : Tool
    {
        private string toolName;
        private string downloadPath;
        private string customPath;
        private string category;
        private string appBasePath = Application.StartupPath + "\\Tools\\";
        private string appType;

        public Zip(string toolName, string appType, string downloadurl, string category, string customPath)
        {
            this.toolName = toolName;
            this.downloadPath = downloadurl;
            this.customPath = customPath;
            this.appType = appType;
            this.category = category;
        }

        public string getAppType()
        {
            return appType;
        }
        public string getCustomPath()
        {
            return customPath;
        }
         public void setCustomPath(string path)
        {
            this.customPath = path;
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
            String tempToolname = toolName;

            if (toolName == "mkvtoolnix")
            {
                tempToolname = "mkvextract";
                   
            }
            else if (toolName == "ogmtools")
            {
                tempToolname = "OGMDemuxer";
                   
            }

            if (!string.IsNullOrEmpty(customPath))
            {
                if (File.Exists(customPath + "\\" + tempToolname + ".exe"))
                    return true;
                else
                    return false;
            }
            if (File.Exists(appBasePath + toolName + "\\" + tempToolname + ".exe"))
                return true;
            else
                return false;

        }

       

         public string getInstallPath()
         {
             if (customPath != "")
                 return customPath + "\\";

             return appBasePath + toolName + "\\";
         }

         public void download()
         {
             try
             {
                 Download frmDownload;
                
                     frmDownload = new Download(downloadPath, getInstallPath(), "zip");
                
                 frmDownload.startDownload();

                 frmDownload.ShowDialog();
                
             }
             catch
             {

             }

         }

    }
}
