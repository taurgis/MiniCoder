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
using System.Windows.Forms;
using System.Xml;
using System.Reflection;

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
            if (toolName == "Core")
                this.localVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
          
        }
        public string getAppType()
        {
            return appType;
        }
        public string getCustomPath()
        {
            return "";
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
        public Boolean download()
        {
            try
            {
                Download frmDownload;


                frmDownload = new Download(downloadPath, "", "core");

                frmDownload.startDownload();

                frmDownload.ShowDialog();
                return frmDownload.isCompleted();

            }
            catch
            {
                return false;
            }

        }

    }
}
