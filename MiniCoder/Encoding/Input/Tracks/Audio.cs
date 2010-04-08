//    MiniCoder
//    Copyright (C) 2009-2010  MiniTech support@minitech.org
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.

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

        public Audio(String title, String language, String codec, int id)
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
            try
            {
                MiniDecoder decoder;
                Tool tempTool;
                LogBook.Instance.addLogLine("Decoding Audio", fileDetails["name"][0] + "Encode", fileDetails["name"][0] + "AudioDecoding", false);

                switch (Codec.Instance.getExtention(this.codec))
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
            catch (Exception error)
            {
                LogBook.Instance.addLogLine("Error selecting audio decoding tool. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }

        private Boolean encodeAudio(SortedList<String, Tool> tools, SortedList<String, String[]> fileDetails, ProcessWatcher processWatcher)
        {
            try
            {

                LogBook.Instance.addLogLine("Encoding Audio", fileDetails["name"][0] + "Encode", fileDetails["name"][0] + "AudioEncoding", false);

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
                    case "3":
                        encoder = new Lame();
                        return encoder.encode(tools["lame"], fileDetails, id, this, EncOpts, processWatcher);
                }
                return encoder.encode(tools["besweet"], fileDetails, id, this, EncOpts, processWatcher);
            }
            catch (Exception error)
            {
                LogBook.Instance.addLogLine("Error selecting audio encoding tool. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }
           


    }
}
