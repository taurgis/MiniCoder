using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
namespace MiniCoder
{
    interface ifContainer
    {
        bool demux(ApplicationSettings dir, FileInformation details, ProcessSettings proc);
        bool mkv2vfr(ApplicationSettings dir, FileInformation details, ProcessSettings proc);
    }
}
