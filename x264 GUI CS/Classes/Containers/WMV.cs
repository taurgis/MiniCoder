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
       
        ProcessSettings proc;
       
      
        LogBook log;
      

        public WMV(LogBook log)
        {
            this.log = log;
            proc = new General.ProcessSettings(log);
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
