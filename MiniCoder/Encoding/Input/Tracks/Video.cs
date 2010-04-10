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
using MiniTech.MiniCoder.External;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.Encoding.VideoEnc.Encoding;
using MiniTech.MiniCoder.Core.Other.Logging;
namespace MiniTech.MiniCoder.Encoding.Input.Tracks
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
            try
            {
               // LogBook.Instance.addLogLine("Encoding Video", fileDetails["name"][0] + "Encode", fileDetails["name"][0] + "VideoEncoding", false);

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
            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error selecting video encoding tool. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
                return false;
            }
        }



    }
}
