﻿//    MiniCoder
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
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.Encoding.Process_Management;
using MiniCoder.External;
using System.IO;
using System.Windows.Forms;
using MiniCoder.Core.Languages;

namespace MiniCoder.Encoding.Input
{
    class Mp4 : InputFile
    {
        String tempPath = Application.StartupPath + "\\temp\\";
     //   SortedList<String, String[]> fileDetails = new SortedList<string, string[]>();

        public Mp4()
        {
           
        }

        public SortedList<String, Track[]> getTracks()
        {
            return new SortedList<string, Track[]>();
        }

        public void setTempPath(string tempPath)
        {
            this.tempPath = tempPath;
        }

        public Boolean demux(Tool mp4box, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
            LogBook.Instance.addLogLine("Demuxing MP4 - Using mp4box", fileDetails["name"][0] + "DeMuxing", fileDetails["name"][0] + "DeMuxingProcess", false);
            int languageCode = MiniSystem.getLanguage();
              
            int exitCode = 0;
            MiniProcess proc = new DefaultProcess("Demuxing MP4", fileDetails["name"][0] + "DeMuxingProcess");
           processWatcher.setProcess(proc);
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            try
            {
               
                if (!mp4box.isInstalled())
                    mp4box.download();

           
                LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("demuxingmp4Video", languageCode));
                proc.initProcess();

              
             

                proc.setFilename(Path.Combine(mp4box.getInstallPath(), "MP4Box.exe"));
                string tempArg;
                switch (tracks["video"][0].codec)
                {
                    case "DIV3":
                    case "XVID":
                    case "DIVX":
                    case "DX50":
                    case "DX60":
                    case "V_MS/VFW/FOURCC":
                    case "20":
                        tracks["video"][0].demuxPath = tempPath + fileDetails["name"][0] + "-Video Track.avi";
                        tempArg = "\"" + fileDetails["fileName"][0] + "\" -avi 1 -out \"" + tempPath + fileDetails["name"][0] + "-Video Track\"";
                        break;
                    default:
                        tracks["video"][0].demuxPath = tempPath + fileDetails["name"][0] + "-Video Track." + Codec.Instance.getExtention(tracks["video"][0].codec);
                        tempArg = "\"" + fileDetails["fileName"][0] + "\" -raw 1 -out \"" + tempPath + fileDetails["name"][0] + "-Video Track." + Codec.Instance.getExtention(tracks["video"][0].codec) + "\"";
                        break;
                }
                proc.setArguments(tempArg);
                exitCode = proc.startProcess();
                if (proc.getAbandonStatus())
                    return false;
                if (exitCode != 0)
                    return false;

                if (tracks["audio"].Length == 0)
                    return true;

                LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("demuxingmp4Audio", languageCode));
                tracks["audio"][0].demuxPath = tempPath + fileDetails["name"][0] + "-Audio Track-" + "1" + "." + Codec.Instance.getExtention(tracks["audio"][0].codec);
                tempArg = "\"" + fileDetails["fileName"][0] + "\" -raw 2 -out \"" + tracks["audio"][0].demuxPath + "\"";
                proc.setArguments(tempArg);
                exitCode = proc.startProcess();

                if (proc.getAbandonStatus())
                    LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("demuxingAbortedMessage", languageCode));
                else
                    LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("demuxingCompleteMessage", languageCode));

                if (exitCode != 0)
                    return false;
                else
                    return true;

            }
            catch (KeyNotFoundException e)
            {
                LogBook.Instance.addLogLine("Can't find codec " + e.Message, fileDetails["name"][0] + "DeMuxing - " + tracks["audio"][0].codec + tracks["video"][0].codec ,"",true);
               // MessageBox.Show("Can't find codec");
                return false;
            }
        }
    }
}
