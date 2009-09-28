﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;
using x264_GUI_CS.GUI;

namespace x264_GUI_CS
{
    class Package
    {
        private string appName;
        private string appType; //dll, exe,...
        private Boolean isRegistry; //is this thing in the registry?
        private string downloadPath;
        private string registrySubpath;
      //  private string appversion;
        private string registrySubKey;
        private string appBasePath = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\x264Encoder\\Tools\\";
        private ApplicationSettings appSettings;
        public String dlStatus;
        public Package(string appName, string appType, Boolean isRegistry, string registrySubpath, ApplicationSettings appSettings, string registrySubKey, string downloadurl)
        {
          this.appName = appName;
          this.appType = appType;
          this.isRegistry = isRegistry;
          this.downloadPath = downloadurl;
          if (this.isRegistry)
          {
              this.registrySubpath = registrySubpath;
              this.registrySubKey = registrySubKey;
          }
          this.appSettings = appSettings;
        }

        public Boolean isInstalled()
        {
            if (isRegistry)
            {
                try
                {
                    RegistryKey key;
                    String registryBasePath;
                    if (appSettings.is64bit())
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
                            if (File.Exists(key.GetValue(registrySubKey).ToString() + "\\" + appName + ".dll"))
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
            else
            {

                if (Directory.Exists(appBasePath + appName + "\\"))
                    return true;
                else
                    return false;


            }

        }

        public string getInstallPath()
        {
            
            if (isRegistry)
            {
                RegistryKey key;
                String registryBasePath;
                if (appSettings.is64bit())
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
            else
            {
                return appBasePath + appName + "\\";
            }


        }

        public void download()
        {
            Download frmDownload;
            if(appType == "zip")
                      frmDownload = new Download(downloadPath, getInstallPath(), appType);
            else if(appType == "exe")
                frmDownload = new Download(downloadPath,"", appType);
            else
                      frmDownload = new Download(downloadPath, getInstallPath() + appName, appType);
            frmDownload.startDownload();
            frmDownload.ShowDialog();
            dlStatus = "bussy";
           
            
        }
   
        public string getVersion()
        {
            return "";
        }

        public string getDownloadUrl()
        {
            return downloadPath;
        }

        public string getAppType()
        {
            return appType;
        }
    }
}
