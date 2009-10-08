using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;

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
            proc = new ProcessSettings(log);
        }
       // Package vdubmod;
        
        public bool demux(ApplicationSettings dir, FileInformation details, ProcessSettings proc)
        {

  

            details.demuxAudio = new string[1];
            
            return true;
           
            
        }

       
        
        public bool mkv2vfr(ApplicationSettings dir, FileInformation details, ProcessSettings proc)
        {
            return true;
        }

   
    }
}
