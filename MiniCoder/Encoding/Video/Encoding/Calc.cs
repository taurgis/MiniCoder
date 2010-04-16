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
using System.IO;
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Encoding.Input.Tracks;

namespace MiniTech.MiniCoder.Encoding.VideoEnc.Encoding
{
    public class Calc
    {
        private SortedList<String, String[]> fileDetails;
        private SortedList<String, String> encOpts;
        private SortedList<String, Track[]> fileTracks;

        public Calc(SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, SortedList<String, Track[]> fileTracks)
        {
            this.fileDetails = fileDetails;
            this.encOpts = encOpts;
            this.fileTracks = fileTracks;
        }

        public int getVideoBitrate()
        {
            try
            {
                long Kbits = int.Parse(encOpts["filesize"]) * 1024 * 8;
                int overhead = getOverhead();
                long audioSize = 0;

                for (int i = 0; i < fileTracks["audio"].Length; i++)
                    audioSize += int.Parse(encOpts["audbr"]) * int.Parse(fileDetails["audLength"][0]);

                long remainBits = (long)(Kbits - overhead - audioSize - getSubSize());

                return (int)(remainBits / int.Parse(fileDetails["audLength"][0]) + 5);
            }
            catch
            {
                LogBookController.Instance.addLogLine("Error calculating filesize. The audio length is 0", LogMessageCategories.Error);
               
                return int.Parse(encOpts["videobr"]);
            }
        }

        public int getOverhead()
        {
            int overhead = 0;

            switch (encOpts["container"])
            {
                case "0":
                    overhead = (int)(int.Parse(fileDetails["framecount"][0]) * 0.013 * 8);
                    break;
            }

            return overhead;
        }

        public int getTotalBitrate()
        {
            int totBR = 0;

            totBR += int.Parse(encOpts["vidbr"]);

            for (int i = 0; i < fileTracks["audio"].Length; i++)
                totBR += int.Parse(encOpts["audbr"]);

            return totBR;
        }

        public long getSubSize()
        {
            try
            {
                long subsize = 0;

                for (int i = 0; i < fileTracks["subs"].Length; i++)
                {
                    FileInfo fi = new FileInfo(fileTracks["subs"][i].demuxPath);
                    subsize += fi.Length / 1024 * 8;
                }

                return subsize;
            }
            catch
            {
                return 0;
            }
        }
    }
}
