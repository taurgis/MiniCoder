using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using be.miniTech.minicoder.model.information;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

namespace XmlDataGenerators
{
    class Program
    {
        static void Main(string[] args)
        {
            createCodecXml();
        }

        private static void createCodecXml()
        {
            List<Codec> list = new List<Codec>();
            list.Add(new Codec("ass", new String[] { "S_TEXT/ASS", "ASS" }));
            list.Add(new Codec("ssa", new String[] { "S_TEXT/SSA", "SSA" }));
            list.Add(new Codec("pcm", new String[] { "PCM", "1" }));
            list.Add(new Codec("rmvb", new String[] { "V_REAL", "cook" }));
            list.Add(new Codec("avi", new String[] { "20", "V_MPEG2", "tscc", "DIV3", "DX50", "DX60", "DIVX", "XVID", "V_MS/VFW/FOURCC", "MPEG-4 Visual", "FPS1" }));
            list.Add(new Codec("264", new String[] { "Intel H.264", "AVC", "V_MPEG4/ISO/AVC", "avc1", "h264", "H264" }));
            list.Add(new Codec("mp3", new String[] { "A_MPEG/L3", "MPEG Audio", "55" }));
            list.Add(new Codec("aac", new String[] { "A_AAC/MPEG4/LC/SBR/PS", "A_AAC", "40", "67", "AAC", "A_AAC/MPEG4/LC/SBR" }));
            list.Add(new Codec("usf", new String[] { "S_TEXT/USF" }));
            list.Add(new Codec("srt", new String[] { "Subrip", "S_TEXT/UTF8", "UTF - 8" }));
            list.Add(new Codec("wma", new String[] { "WMA2" }));
            list.Add(new Codec("idx", new String[] { "VobSub", "S_VOBSUB" }));
            list.Add(new Codec("ogg", new String[] { "V_THEORA", "A_VORBIS", "Vorbis", "sgn" }));
            list.Add(new Codec("Chapters", new String[] { "Chapters" }));
            list.Add(new Codec("att", new String[] { "Attachement" }));
            list.Add(new Codec("ac3", new String[] { "A_AC3", "AC-3", "2000" }));
            list.Add(new Codec("d2v", new String[] { "MPEG Video", "" }));
            list.Add(new Codec("wmv", new String[] { "WMV1", "WMV2", "WMV3" }));
            list.Add(new Codec("dts", new String[] { "A_DTS" }));
            list.Add(new Codec("flac", new String[] { "A_FLAC" }));
            list.Add(new Codec("mpa", new String[] { "A_MPEG/L1" }));
            list.Add(new Codec("mp2", new String[] { "A_MPEG/L2" }));
            list.Add(new Codec("wav", new String[] { "A_PCM/INT/LIT" }));
            list.Add(new Codec("qdm", new String[] { "A_QUICKTIME" }));
            list.Add(new Codec("ra", new String[] { "A_REAL" }));
            list.Add(new Codec("tta", new String[] { "A_TTA1" }));
            list.Add(new Codec("wv", new String[] { "A_WAVPACK" }));
            list.Add(new Codec("mpg", new String[] { "V_MPEG1" }));
            list.Add(new Codec("m4v", new String[] { "V_MPEG4/ISO/ASP" }));

            XmlSerializer serializer = new XmlSerializer(typeof(Codec[]));

            //Serialize the OrderedTable to OrderedTable.xml

            using (StreamWriter writer = new StreamWriter("codecs.xml"))
            {

                serializer.Serialize(writer, list.ToArray());
                
            }

        }
    }
}
