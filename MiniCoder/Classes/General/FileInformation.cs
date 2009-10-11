﻿using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
namespace MiniCoder
{
    public class FileInformation
    {
        public Dictionary<string, string> extension = new Dictionary<string, string>();
        public Dictionary<string, string> lang = new Dictionary<string, string>();
        public ArrayList fileList = new ArrayList();

        public bool vfr;
        public string fileName;
        public string name;
        public string ext;
        public string fileSize;
        public string format;
        public string vfrName;
        public string vfrCode;
        public int streamcount;
        public int[] trackcodes;
        public string outDIR;
        public int crfValue;
        public string vid_format;
        public string vid_codec;
        public int vid_id;
        public int width;
        public int muxwidth;
        public int height;
        public int muxheight;
        public float dar;
        public float fps;
        public int framecount;
        public string frameType;
        public string aud_format;
        public string[] aud_codec;
        public int channels;
        public int audioCount;
        public float samplingRate;
        public int[] aud_id;
        public string[] aud_Languages;
        public int audLength;
        public string[] audTitles;

        public string sub_format;
        public string[] sub_codec;
        public int subCount;
        public string[] sub_Titles;
        public int[] sub_id;
        public string[] sub_lang;

        public string[] attachments = null;
        public string chapters;

        public string demuxVideo;
        public string[] demuxAudio;
        public string[] demuxSub;
        public int[] audBitrate;
        public string avsFile;
        public string dgaFile;
        public string avsAudioFile;
        public string[] decodedAudio;
        public string[] encodedAudio;
        public string encodedVideo;
        public string statsfile;
        public string outFile;
        public string completeinfo;

        public bool abandon;

        public FileInformation()
        {
            setDic();
        }

        private void setDic()
        {
            extension.Add("S_TEXT/ASS", "ass");
            extension.Add("S_TEXT/SSA", "ssa");
            extension.Add("SSA", "ssa");
            extension.Add("ASS", "ass");
            extension.Add("H264", "264");
            extension.Add("h264", "264");
            extension.Add("A_AAC/MPEG4/LC/SBR", "aac");
            extension.Add("MPEG Audio", "mp3");
            extension.Add("S_TEXT/USF", "usf");
            extension.Add("S_TEXT/UTF8", "srt");
            extension.Add("UTF-8", "srt");
            extension.Add("WMA2", "wma");
            extension.Add("S_VOBSUB", "idx");
            extension.Add("avc1","264");
            extension.Add("AAC", "aac");
            extension.Add("Subrip", "srt");
            extension.Add("VobSub", "idx");
            extension.Add("Chapters", "Chapters");
            extension.Add("Attachement", "att");
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

            lang.Add("English", "eng");
            lang.Add("Japanese", "jpn");
            lang.Add("Chinese", "chi");
            lang.Add("Dutch", "dut");
            lang.Add("Finnish", "fin");
            lang.Add("rrk", "rrk");
            lang.Add("French", "fre");
            lang.Add("German", "ger");
            lang.Add("Italian", "ita");
            lang.Add("Norwegian", "nor");
            lang.Add("Portuguese", "por");
            lang.Add("Russian", "rus");
            lang.Add("Spanish", "spa");
            lang.Add("Swedish", "swe");
            lang.Add("Czech", "cze");
            lang.Add("Slovak", "slo");
            lang.Add("", "und");
        }
    }
 }
   