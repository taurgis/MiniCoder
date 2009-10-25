using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.External;

namespace MiniCoder.Encoding.AviSynth.Plugins
{
    class Source : Plugin
    {
        public Source()
        {
        }

        public string getAvsCode(SortedList<String, String[]> fileDetails, Track video, SortedList<String, String> EncOpts, SortedList<String, Tool> tools)
        {
            string sourceline = "";
           

            switch (video.codec)
            {
                case "DIV3":
                case "XVID":
                case "DIVX":
                case "DX50":
                case "DX60":
                    switch (fileDetails["ext"][0].ToLower())
                    {
                        case ".mkv":
                            sourceline = "AVISource(\"" + video.demuxPath + "\", audio=false)";
                            break;
                        case ".ogm":
                            sourceline = "AVISource(\"" + video.demuxPath + "\", audio=false)";
                            break;
                        case ".avi":
                            sourceline = "AVISource(\"" + video.demuxPath + "\", audio=false)";
                            break;
                        case ".mp4":
                            sourceline = "AVISource(\"" + video.demuxPath + "\", audio=false)";
                            break;
                        default:
                            sourceline = "DirectshowSource(\"" + video.demuxPath + "\")\r\nConvertToYV12()";
                            break;
                    }
                    break;
                case "avc1":
                case "H264":
                case "h264":
                case "V_MPEG4/ISO/AVC":
                case "Intel H.264":
                case "x264":
                    switch (fileDetails["ext"][0].ToLower())
                    {
                        case ".mkv":
                        case ".ogm":
                        case ".mp4":
                            sourceline = "AVCSource(\"" + video.demuxPath + "\")";
                            break;
                        case ".avi":
                            sourceline = "AVISource(\"" + video.demuxPath + "\", audio=false)";
                            break;
                        default:
                            sourceline = "DirectshowSource(\"" + video.demuxPath + "\")\r\nConvertToYV12()";
                            break;
                    }
                    break;
                case "20":
                    switch (fileDetails["ext"][0].ToLower())
                    {
                        case ".mkv":
                            sourceline = "AVISource(\"" + video.demuxPath + "\",audio=false)";
                            break;
                        case ".ogm":
                            sourceline = "AVISource(\"" + video.demuxPath + "\", audio=false)";
                            break;
                        case ".avi":
                            sourceline = "AVISource(\"" + video.demuxPath + "\",audio=false)";
                            break;
                        case ".mp4":
                            sourceline = "AVISource(\"" + video.demuxPath + "\", audio=false)";
                            break;
                        default:
                            sourceline = "DirectshowSource(\"" + video.demuxPath + "\")\r\nConvertToYV12()";
                            break;
                    }
                    break;
                case "":
                    switch (fileDetails["ext"][0].ToLower())
                    {

                        default:
                            sourceline = "DGDecode_mpeg2source(\"" + video.demuxPath + "\", info=3)\r\nColorMatrix(hints=true, threads=0)";
                            break;
                    }
                    break;

                default:
                            sourceline = "DirectshowSource(\"" + video.demuxPath + "\")\r\nConvertToYV12()";
                         
                    break;


            }
            return sourceline;
        }
    }
}
