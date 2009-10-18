using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.External;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.Encoding.Process_Management;
namespace MiniCoder.Encoding.Sound.Encoding
{
    interface MiniEncoder
    {
        bool encode(Tool encoder, SortedList<String, String[]> fileDetails, int i, Track audio, SortedList<String, String> EncOpts, ProcessWatcher processWatcher);
    }
}
