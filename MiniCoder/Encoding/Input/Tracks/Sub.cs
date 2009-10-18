using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.External;
using MiniCoder.Encoding.Process_Management;

namespace MiniCoder.Encoding.Input.Tracks
{
    class Sub : Track
    {
        public String title {get; set;}
        public String language { get; set; }
        public String codec { get; set; }
        public String demuxPath { get; set; }
        public String encodePath { get; set; }
        public String length { get; set; }
        public int id { get; set; }
        public Sub(String title, String Language, String codec, int id)
        {
            this.title = title;
            this.language = language;
            this.codec = codec;
            this.id = id;
        }

        public Boolean Encode(SortedList<String, Tool> tools, SortedList<String, String[]> fileDetails, SortedList<String, String> EncOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> tracks)
        {
            return true;
        }



    }
}
