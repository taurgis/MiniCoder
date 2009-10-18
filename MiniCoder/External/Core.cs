using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.GUI;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace MiniCoder.External
{
    class Core : Tool
    {
        private string toolName;
        private string downloadPath;
        private string appType;
        private string category;
        public string localVersion { get; set; }
        public string onlineVersion { get; set; }
        public string registrySubpath { get; set; }
        public string registrySubKey { get; set; }

        public Core(string toolName, string appType, string downloadurl, string category, string customPath, string localVersion)
        {
            this.localVersion = localVersion;
            this.toolName = toolName;
            this.downloadPath = downloadurl;
            this.appType = appType;
            this.category = category;
            getOnlineVersion();
        }
        public string getAppType()
        {
            return appType;
        }
        public string getCustomPath()
        {
            return "";
        }
        private void getOnlineVersion()
        {
            try
            {


                XmlDocument doc = new XmlDocument();

                string xmlFile = "http://www.gamerzzheaven.be/applications.xml";
                doc.Load(xmlFile);
                XmlNodeList xmlnode = doc.SelectNodes("//Application[@name=\"" + toolName + "\"]");
                onlineVersion = xmlnode[0].ChildNodes[0].InnerText;

            }
            catch
            {
                onlineVersion = "Offline";
            }
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
