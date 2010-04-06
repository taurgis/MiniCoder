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
            if (!aviSynth.isInstalled())
                return "";
            if (!String.IsNullOrEmpty(customPath))
                return customPath + "\\";

            return aviSynth.getInstallPath();
        }

        public Boolean download()
        {
            try
            {
                Download frmDownload;


                frmDownload = new Download(downloadPath, getInstallPath(), "dll");

                frmDownload.startDownload();

                frmDownload.ShowDialog();

                return frmDownload.isCompleted();
            }
            catch
            {
                return false;
            }

        }

        public void getOnlineVersion(XmlDocument doc)
        {
            try
            {

                XmlNodeList xmlnode = doc.SelectNodes("//Application[@name=\"" + toolName + "\"]");
                onlineVersion = xmlnode[0].ChildNodes[0].InnerText;

            }
            catch
            {

            }
        }
    }
}
