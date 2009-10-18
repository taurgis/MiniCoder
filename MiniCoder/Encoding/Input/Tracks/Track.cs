using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.External;
using MiniCoder.Encoding.Process_Management;
namespace MiniCoder.Encoding.Input.Tracks
{
    public interface Track
    {
        String title { get; set; }
        String language { get; set; }
        String codec { get; set; }
        String demuxPath { get; set; }
        String encodePath { get; set; }
        String length { get; set; }
        int id { get; set; }
        Boolean Encode(SortedList<String, Tool> tools, SortedList<String, String[]> fileDetails, SortedList<String, String> EncOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> tracks);
    }
}
