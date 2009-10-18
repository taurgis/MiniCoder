using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using MiniCoder.GUI;

namespace MiniCoder.External
{
    class RegistryApp : Tool
    {
        private string toolName;
        private string downloadPath;
        private string customPath;
        private string category;
        private string appType;

        private string registrySubpath;
        private string registrySubKey;

        public RegistryApp(string toolName, string appType, string registrySubpath, string registrySubKey, string downloadurl, string category, string customPath)
        {
            this.toolName = toolName;
            this.appType = appType;
            this.downloadPath = downloadurl;
            this.customPath = customPath;
            this.registrySubKey = registrySubKey;
            this.registrySubpath = registrySubpath;
            this.category = category;
        }

        public void setCustomPath(string path)
        {
            this.customPath = path;
        }

        public string getAppType()
        {
            return appType;
        }

        public string getDownloadPath()
        {
            return downloadPath;
        }
        public string getCustomPath()
        {
            return customPath;
        }

        public string getCategory()
        {
            return category;
        }

        public Boolean isInstalled()
        {
            try
            {
                RegistryKey key;
                String registryBasePath;
                if (MiniSystem.is64bit())
                    registryBasePath = "SOFTWARE\\Wow6432Node\\";
                else
                    registryBasePath = "SOFTWARE\\";
                try
                {
                    key = Registry.LocalMachine.OpenSubKey(registryBasePath + registrySubpath);
                }
                catch
                {
                    return false;
                }
                if (appType == "dll")
                {
                    try
                    {
                        if (File.Exists(key.GetValue(registrySubKey).ToString() + "\\" + toolName + ".dll"))
                            return true;
                        else
                            return false;
                    }
                    catch
                    {
                        return false;
                    }

                }
                if (key == null)
                    return false;
                else
                    return true;

            }
            catch
            {
                return false;
            }
        }

    

        public string getInstallPath()
        {
             if (customPath != "")
                return customPath +"\\";


           
                RegistryKey key;
                String registryBasePath;
                if (MiniSystem.is64bit())
                    registryBasePath = "SOFTWARE\\Wow6432Node\\";
                else
                    registryBasePath = "SOFTWARE\\";

                key = Registry.LocalMachine.OpenSubKey(registryBasePath + registrySubpath);
                try
                {
                    return key.GetValue(registrySubKey).ToString() + "\\";
                }
                catch
                {
                    return "";
                }

        }

        public void download()
        {
            Download frmDownload;
            if (appType == "zip")
                frmDownload = new Download(downloadPath, getInstallPath(), appType);
            else if (appType == "exe")
                frmDownload = new Download(downloadPath, "", appType);
            else
                frmDownload = new Download(downloadPath, getInstallPath(), appType);
            frmDownload.startDownload();

            frmDownload.ShowDialog();
        }
    }
}
