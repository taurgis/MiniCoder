using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace System
{


    static partial class Codec
    {
        public static string getExtention(string codec)
        {
            Codecs tempCodec = new Codecs();
            return tempCodec.getExtention(codec);

        }


        private class Codecs
        {
            private Dictionary<string, string> extension = new Dictionary<string, string>();

            public Codecs()
            {
                extension.Add("S_TEXT/ASS", "ass");
                extension.Add("S_TEXT/SSA", "ssa");
                extension.Add("SSA", "ssa");
                extension.Add("ASS", "ass");
                extension.Add("H264", "264");
                extension.Add("55", "mp3");
                extension.Add("h264", "264");
                extension.Add("A_AAC/MPEG4/LC/SBR", "aac");
                extension.Add("MPEG Audio", "mp3");
                extension.Add("S_TEXT/USF", "usf");
                extension.Add("S_TEXT/UTF8", "srt");
                extension.Add("UTF-8", "srt");
                extension.Add("WMA2", "wma");
                extension.Add("S_VOBSUB", "idx");
                extension.Add("avc1", "264");
                extension.Add("AAC", "aac");
                extension.Add("Subrip", "srt");
                extension.Add("40", "aac");
                extension.Add("VobSub", "idx");
                extension.Add("Chapters", "Chapters");
                extension.Add("Attachement", "att");
                extension.Add("A_AAC/MPEG4/LC/SBR/PS", "aac");
                extension.Add("A_AAC", "aac");
                extension.Add("A_AC3", "ac3");
                extension.Add("AC-3", "ac3");
               
                extension.Add("", "d2v");
                extension.Add("A_DTS", "dts");
                extension.Add("A_FLAC", "flac");
                extension.Add("A_MPEG/L1", "mpa");
                extension.Add("A_MPEG/L2", "mp2");
                extension.Add("A_MPEG/L3", "mp3");
                extension.Add("A_PCM/INT/LIT", "wav");
                extension.Add("A_QUICKTIME", "qdm");
                extension.Add("A_REAL", "ra");
                extension.Add("A_TTA1", "tta");
                extension.Add("A_VORBIS", "ogg");
                extension.Add("Vorbis", "ogg");
                extension.Add("A_WAVPACK", "wv");
                extension.Add("V_MPEG1", "mpg");
                extension.Add("V_MPEG4/ISO/AVC", "264");
                extension.Add("V_MPEG4/ISO/ASP", "m4v");
                extension.Add("V_MS/VFW/FOURCC", "avi");
                extension.Add("Intel H.264", "264");
                extension.Add("V_REAL", "rmvb");
                extension.Add("2000", "ac3");
                extension.Add("V_THEORA", "ogg");
                extension.Add("DIV3", "avi");
                extension.Add("DX50", "avi");
                extension.Add("DX60", "avi");
                extension.Add("DIVX", "avi");
                extension.Add("XVID", "avi");
                extension.Add("WMV1", "wmv");
                extension.Add("WMV2", "wmv");
                extension.Add("WMV3", "wmv");
                extension.Add("AVC", "264");
                extension.Add("20", "avi");
                extension.Add("V_MPEG2", "avi");
                extension.Add("tscc", "avi");
            }

            public string getExtention(string codec)
            {
                return extension[codec];
            }
        }
    }
}
