using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.External;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.Encoding.Process_Management;

namespace MiniCoder.Encoding.VideoEnc.Encoding
{
    interface VideoEncoder
    {
        Boolean encode(Tool tool, SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> fileTracks);
    }
}
