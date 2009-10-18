using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.External;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.Encoding.Process_Management;
namespace MiniCoder.Encoding.Sound.Decoding
{
    interface MiniDecoder
    {
        Boolean decode(Tool decoder, SortedList<String, String[]> fileDetails, int i, Track audio, ProcessWatcher processWatcher);
    }
}
