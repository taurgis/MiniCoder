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
using System.IO;
using System.Windows.Forms;
using MiniCoder.GUI;
using System.Xml;
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
        public string localVersion { get; set; }
        public string onlineVersion { get; set; }
        public string registrySubpath { get; set; }
        public string registrySubKey { get; set; }

        public Zip(string toolName, string appType, string downloadurl, string category, string customPath, string localVersion)
        {
            this.localVersion = localVersion;
            this.toolName = toolName;
            this.downloadPath = downloadurl;
            this.customPath = customPath;
            this.appType = appType;
            this.category = category;
          //  getOnlineVersion();
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

            if (!string.IsNullOrEmpty(customPath) && !customPath.Equals("\r\n    "))
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

         public Boolean download()
         {
             try
             {
                 Download frmDownload;
                
                     frmDownload = new Download(downloadPath, getInstallPath(), "zip");
                
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
