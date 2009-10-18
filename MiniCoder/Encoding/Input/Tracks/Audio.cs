using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.External;
using MiniCoder.Encoding.Sound.Decoding;
using MiniCoder.Encoding.Sound.Encoding;
using MiniCoder.Encoding.Process_Management;
namespace MiniCoder.Encoding.Input.Tracks
{
    class Audio : Track
    {
        public String title { get; set; }
        public String language { get; set; }
        public String codec { get; set; }
        public String demuxPath { get; set; }
        public String encodePath { get; set; }
        public String length { get; set; }
        public int id { get; set; }
        SortedList<String, String> EncOpts;

        public Audio(String title, String Language, String codec, int id)
        {
            this.title = title;
            this.language = language;
            this.codec = codec;
            this.id = id;
        }

        public Boolean Encode(SortedList<String, Tool> tools, SortedList<String, String[]> fileDetails, SortedList<String, String> EncOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> tracks)
        {
            this.EncOpts = EncOpts;
            if (decodeAudio(tools, fileDetails, processWatcher))
                return encodeAudio(tools, fileDetails, processWatcher);

            return false;
        }

        private Boolean decodeAudio(SortedList<String, Tool> tools, SortedList<String, String[]> fileDetails, ProcessWatcher processWatcher)
        {
            MiniDecoder decoder;
            Tool tempTool;
            switch (Codec.getExtention(this.codec))
            {
                case "flac":
                    decoder = new Flac();
                    tempTool = tools["flac"];
                    break;

                case "ac3":
                case "dts":
                    decoder = new Valdec();
                    tempTool = tools["valdec"];
                    break;

                case "ogg":
                    decoder = new Oggdec();
                    tempTool = tools["oggdec"];
                    break;

                case "aac":
                case "mp4":
                    decoder = new Faad();
                    tempTool = tools["faad"];
                    break;

                case "mp2":
                case "mp3":
                    decoder = new Madplay();
                    tempTool = tools["madplay"];
                    break;

                default:
                    decoder = new Ffmpeg();
                    tempTool = tools["ffmpeg"];
                    break;
            }
            // fileDetails.Add("decodedaudio", new String[3]);
            return decoder.decode(tempTool, fileDetails, id, this, processWatcher);

        }

        private Boolean encodeAudio(SortedList<String, Tool> tools, SortedList<String, String[]> fileDetails, ProcessWatcher processWatcher)
        {
            MiniEncoder encoder = null;
            switch (EncOpts["audcodec"])
            {
                case "0":
                    encoder = new NeroAac();
                    break;
                case "1":
                    encoder = new Vorbis();
                    break;
                case "2":
                    encoder = new FFmpegAc3();
                    return encoder.encode(tools["ffmpeg"], fileDetails, id, this, EncOpts, processWatcher);
            }
            return encoder.encode(tools["besweet"], fileDetails, id, this, EncOpts, processWatcher);
        }



    }
}
