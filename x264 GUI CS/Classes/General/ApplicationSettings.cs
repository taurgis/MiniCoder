using System.Collections;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System;
using x264_GUI_CS.GUI;
using System.Windows.Forms;
namespace x264_GUI_CS
{
    public class ApplicationSettings
    {

        Packages pcRequired;
        public Hashtable htRequired;
        string appPath;
        public ApplicationSettings(string appPath)
        {
            pcRequired = new Packages(this);
            this.appPath = appPath;
            setAppPath();
            htRequired = pcRequired.getPackages();
        }

        public string tempDIR;


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