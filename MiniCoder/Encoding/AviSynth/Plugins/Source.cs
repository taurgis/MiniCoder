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
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.External;

namespace MiniTech.MiniCoder.Encoding.AviSynth.Plugins
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
                        case "mkv":
                            sourceline = "AVISource(\"" + video.demuxPath + "\", audio=false)";
                            break;
                        case "ogm":
                            sourceline = "AVISource(\"" + video.demuxPath + "\", audio=false)";
                            break;
                        case "avi":
                            sourceline = "AVISource(\"" + video.demuxPath + "\", audio=false)";
                            break;
                        case "mp4":
                            sourceline = "AVISource(\"" + video.demuxPath + "\", audio=false)";
                            break;
                        default:
                            sourceline = "DirectshowSource(\"" + video.demuxPath + "\", audio=False)\r\nConvertToYV12()";
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
                        case "mkv":
                        case "ogm":
                        case "mp4":
                        case "avi":
                            sourceline = "AVCSource(\"" + video.demuxPath + "\")";
                            break;
                        default:
                            sourceline = "DirectshowSource(\"" + video.demuxPath + "\", audio=False)\r\nConvertToYV12()";
                            break;
                    }
                    break;
                case "20":
                    switch (fileDetails["ext"][0].ToLower())
                    {
                        case "mkv":
                            sourceline = "AVISource(\"" + video.demuxPath + "\",audio=false)";
                            break;
                        case "ogm":
                            sourceline = "AVISource(\"" + video.demuxPath + "\", audio=false)";
                            break;
                        case "avi":
                            sourceline = "AVISource(\"" + video.demuxPath + "\",audio=false)";
                            break;
                        case "mp4":
                            sourceline = "AVISource(\"" + video.demuxPath + "\", audio=false)";
                            break;
                        default:
                            sourceline = "DirectshowSource(\"" + video.demuxPath + "\", audio=False)\r\nConvertToYV12()";
                            break;
                    }
                    break;
                case "MPEG Video":
                    switch (fileDetails["ext"][0].ToLower())
                    {
                        case "vob":
                            sourceline = "DGDecode_mpeg2source(\"" + video.demuxPath + "\", info=3)\r\nColorMatrix(hints=true, threads=0)";
                            break;

                        default:
                            sourceline = "DirectshowSource(\"" + video.demuxPath + "\", audio=False)\r\nConvertToYV12()";
                            break;
                    }
                    break;

                default:
                    sourceline = "DirectshowSource(\"" + video.demuxPath + "\", audio=False)\r\nConvertToYV12()";

                    break;


            }
            return sourceline;
        }
    }
}
