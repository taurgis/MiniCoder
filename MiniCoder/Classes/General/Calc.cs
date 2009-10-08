using System;
using System.Collections.Generic;

using System.Text;
using System.IO;

namespace MiniCoder
{
    public class Calc
    {
        FileInformation details = new FileInformation();
        EncodingOptions encOpts = new EncodingOptions();

        public Calc(FileInformation details, EncodingOptions encOpts)
        {
            this.details = details;
            this.encOpts = encOpts;
        }

        public int getVideoBitrate()
        {
            long Kbits = encOpts.fileSize * 1024 * 8;
            int overhead = getOverhead();
            long audioSize = 0;

            for (int i = 0; i < details.audioCount; i++)
                audioSize += encOpts.audBR * details.audLength;

            long subsize = getSubSize();

            long remainBits = (long)(Kbits - overhead - audioSize - subsize);
            int vidBR = (int)(remainBits / details.audLength) + 5;

            return vidBR;
        }

        public int getOverhead()
        {
            int overhead = 0;

            switch (encOpts.containerFormat)
            {
                case 0:
                    overhead = (int)(details.framecount * 0.013 * 8);
                    break;
            }

            return overhead;
        }

        public int getTotalBitrate()
        {
            int totBR = 0;

            totBR += encOpts.vidBR;

            for (int i = 0; i < details.audioCount; i++)
                totBR += encOpts.audBR;

            return totBR;
        }

        public long getSubSize()
        {
            long subsize = 0;

            for (int i = 0; i < details.subCount; i++)
            {
                FileInfo fi = new FileInfo(details.demuxSub[i]);
                subsize += fi.Length / 1024 * 8;
            }

            return subsize;
        }
    }
}
