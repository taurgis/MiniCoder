using System;
using System.Collections.Generic;
using MiniCoder.General;
using System.Text;
using System.Diagnostics;
using System.Threading;
namespace x264_GUI_CS
{
    interface ifContainer
    {
        bool demux(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc);
        bool mkv2vfr(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc);
    }
}
