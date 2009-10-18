using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.GUI;
using System.IO;
using System.Xml;
namespace MiniCoder.External
{
    class AvsPlugin : Tool
    {
        private string toolName;
        private string downloadPath;
        private string customPath;
        private string category;
        public string localVersion { get; set; }
        public string onlineVersion { get; set; }
        public string registrySubpath { get; set; }
        public string registrySubKey { get; set; }

        private Tool aviSynth;
        public AvsPlugin(string toolName, string downloadurl, string category, Tool aviSynth, string localVersion)
        {
            this.toolName = toolName;
            this.localVersion = localVersion;
            this.downloadPath = downloadurl;
            this.category = category;
            this.aviSynth = aviSynth;
            getOnlineVersion();
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

            }
        }
    }
}
