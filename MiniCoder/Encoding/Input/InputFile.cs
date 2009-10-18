using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.External;
using MiniCoder.Encoding.Process_Management;

namespace MiniCoder.Encoding.Input
{
    interface InputFile
    {
        SortedList<String, Track[]> getTracks();
        Boolean demux(Tool tool, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher);
        void setTempPath(String tempPath);
       
    }
}
