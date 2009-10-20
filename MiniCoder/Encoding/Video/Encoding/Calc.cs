using System;
using System.Collections.Generic;
using MiniCoder.Encoding.Input.Tracks;
using System.Text;
using System.IO;

namespace MiniCoder.Encoding.VideoEnc.Encoding
{
    public class Calc
    {
        SortedList<String, String[]> fileDetails;
        SortedList<String, String> encOpts;
        SortedList<String, Track[]> fileTracks;
        public Calc(SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, SortedList<String, Track[]> fileTracks)
        {
            this.fileDetails = fileDetails;
            this.encOpts = encOpts;
            this.fileTracks = fileTracks;
        }

        public int getVideoBitrate()
        {
            long Kbits = int.Parse(encOpts["filesize"]) * 1024 * 8;
            int overhead = getOverhead();
            long audioSize = 0;

            for (int i = 0; i < fileTracks["audio"].Length; i++)
                audioSize += int.Parse(encOpts["audbr"]) * int.Parse(fileDetails["audLength"][0]);

            long subsize = getSubSize();

            long remainBits = (long)(Kbits - overhead - audioSize - subsize);
            int vidBR = (int)(remainBits / int.Parse(fileDetails["audLength"][0]) + 5);

            return vidBR;
        }

        public int getOverhead()
        {
            int overhead = 0;

            switch (encOpts["container"])
            {
                case "0":
                    overhead =(int)(int.Parse(fileDetails["framecount"][0]) * 0.013 * 8);
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
            long subsize = 0;

            for (int i = 0; i < fileTracks["subs"].Length; i++)
            {
                FileInfo fi = new FileInfo(fileTracks["subs"][i].demuxPath);
                subsize += fi.Length / 1024 * 8;
            }

            return subsize;
        }
    }
}
