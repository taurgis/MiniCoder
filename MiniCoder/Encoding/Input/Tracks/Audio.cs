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
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.Encoding.Sound.Decoding;
using MiniTech.MiniCoder.Encoding.Sound.Encoding;
using MiniTech.MiniCoder.External;

namespace MiniTech.MiniCoder.Encoding.Input.Tracks
{
    public class Audio : Track
    {
        public String title { get; set; }
        public String language { get; set; }
        public String codec { get; set; }
        public String demuxPath { get; set; }
        public String encodePath { get; set; }
        public String length { get; set; }
        public int id { get; set; }
        private SortedList<String, String> EncOpts;

        public Audio(String title, String language, String codec, int id)
        {
            this.title = title;
            this.language = language;
            this.codec = codec;
            this.id = id;
        }

        public Boolean Encode(SortedList<String, String[]> fileDetails, SortedList<String, String> EncOpts, SortedList<String, Track[]> tracks)
        {
            this.EncOpts = EncOpts;
            if (decodeAudio(fileDetails))
                return encodeAudio(fileDetails);

            return false;
        }

        private Boolean decodeAudio(SortedList<String, String[]> fileDetails)
        {
            try
            {
                MiniDecoder decoder;
                LogBookController.Instance.addLogLine("Decoding Audio", LogMessageCategories.Video);

                switch (Codec.Instance.getExtention(this.codec))
                {
                    case "flac":
                        decoder = new Flac();
                        break;

                    case "ac3":
                    case "dts":
                        decoder = new Valdec();
                        break;

                    case "ogg":
                        decoder = new Oggdec();
                        break;

                    case "aac":
                    case "mp4":
                        decoder = new Faad();
                        break;

                    case "mp2":
                    case "mp3":
                        decoder = new Madplay();
                        break;

                    default:
                        decoder = new Ffmpeg();
                        break;
                }

                return decoder.decode(fileDetails, id, this);
            }
            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error selecting audio decoding tool. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
                return false;
            }
        }

        private Boolean encodeAudio( SortedList<String, String[]> fileDetails)
        {
            try
            {
                LogBookController.Instance.addLogLine("Encoding Audio", LogMessageCategories.Video);

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
                        return encoder.encode(fileDetails, id, this, EncOpts);
                    case "3":
                        encoder = new Lame();
                        return encoder.encode(fileDetails, id, this, EncOpts);
                }
                return encoder.encode(fileDetails, id, this, EncOpts);
            }
            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error selecting audio encoding tool. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
                return false;
            }
        }
    }
}
