using System.Collections;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System;
using x264_GUI_CS.GUI;
using System.Windows.Forms;
using MiniCoder;
namespace MiniCoder
{
    public class ApplicationSettings
    {

        Packages pcRequired;
        public Hashtable htRequired;
        private string appPath;
        
        public ApplicationSettings(string appPath)
        {
           
            this.appPath = appPath;
            setAppPath();
            pcRequired = new Packages(this);
            htRequired = pcRequired.getPackages();
        }

        public string tempDIR;

        public string getAppPath()
        {
            return appPath;
        }

        public void SavePackages()
        {
            pcRequired.savePackages();
        }

        public bool is64bit()
        {
            if (IntPtr.Size == 8)
                return true;
            else
                return false;
        }

        public void setAppPath()
        {
            tempDIR = appPath + "\\temp\\";
        }

    }
}