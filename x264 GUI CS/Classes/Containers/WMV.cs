using System;
using System.Collections.Generic;
using MiniCoder.General;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using x264_GUI_CS.General;
using MiniCoder;
namespace x264_GUI_CS.Containers
{
    class WMV : ifContainer
    {
        private static Process mainProcess = null;
        ProcessSettings proc = new ProcessSettings();
        Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        bool finishedTask = false;
        LogBook log;
        int exitCode;

        public WMV(LogBook log)
        {
            this.log = log;
        }
       // Package vdubmod;
        
        public bool demux(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {

  

            details.demuxAudio = new string[1];
            
            return true;
           
            
        }

       
        
        public bool mkv2vfr(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {
            return true;
        }

   
    }
}
