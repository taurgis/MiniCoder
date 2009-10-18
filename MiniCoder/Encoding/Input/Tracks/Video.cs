using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.External;
using MiniCoder.Encoding.Process_Management;
using MiniCoder.Encoding.VideoEnc.Encoding;
namespace MiniCoder.Encoding.Input.Tracks
{
    class Video : Track
    {
        public String title {get; set;}
        public String language { get; set; }
        public String codec { get; set; }
        public String demuxPath { get; set; }
        public String encodePath { get; set; }
        public String length { get; set; }
        public int id { get; set; }

        public Video(String codec, int id)
        {
            this.id = id;
            this.codec = codec;
         
        }

        public Boolean Encode(SortedList<String, Tool> tools, SortedList<String, String[]> fileDetails, SortedList<String, String> EncOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> tracks)
        {
            VideoEncoder videoEncoder = null;
            switch (EncOpts["videocodec"])
            {
                case "0":
                    videoEncoder = new x264();
                    return videoEncoder.encode(tools["x264"], fileDetails, EncOpts, processWatcher, tracks);
                case "1":
                    videoEncoder = new Xvid();
                    return videoEncoder.encode(tools["xvid_encraw"], fileDetails, EncOpts, processWatcher, tracks); ;
                case "2":
                    videoEncoder = new Theora();
                    return videoEncoder.encode(tools["theora"], fileDetails, EncOpts, processWatcher, tracks); ;
            }
            return false;
        }



    }
}
