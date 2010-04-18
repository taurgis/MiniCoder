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
using System.Windows.Forms;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Managers;
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;

namespace MiniTech.MiniCoder.Encoding.Input
{
    public class Mp4 : InputFile
    {
        public SortedList<String, Track[]> getTracks()
        {
            return new SortedList<string, Track[]>();
        }

        public Boolean demux(Tool mp4box, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks)
        {
            LogBookController.Instance.addLogLine("Demuxing MP4 - Using mp4box", LogMessageCategories.Video);

            int exitCode = 0;
            MiniProcess proc = new DefaultProcess("Demuxing MP4", fileDetails["name"][0] + "DeMuxingProcess");

            ProcessManager.Instance.Process = proc;
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);

            try
            {
                if (!mp4box.isInstalled())
                    mp4box.download();

                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingmp4Video"));

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
                        tracks["video"][0].demuxPath = LocationManager.TempFolder + fileDetails["name"][0] + "-Video Track.avi";
                        tempArg = "\"" + fileDetails["fileName"][0] + "\" -avi 1 -out \"" + LocationManager.TempFolder + fileDetails["name"][0] + "-Video Track\"";
                        break;
                    default:
                        tracks["video"][0].demuxPath = LocationManager.TempFolder + fileDetails["name"][0] + "-Video Track." + Codec.Instance.getExtention(tracks["video"][0].codec);
                        tempArg = "\"" + fileDetails["fileName"][0] + "\" -raw 1 -out \"" + LocationManager.TempFolder + fileDetails["name"][0] + "-Video Track." + Codec.Instance.getExtention(tracks["video"][0].codec) + "\"";
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

                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingmp4Audio"));

                tracks["audio"][0].demuxPath = LocationManager.TempFolder + fileDetails["name"][0] + "-Audio Track-" + "1" + "." + Codec.Instance.getExtention(tracks["audio"][0].codec);
                tempArg = "\"" + fileDetails["fileName"][0] + "\" -raw 2 -out \"" + tracks["audio"][0].demuxPath + "\"";
                proc.setArguments(tempArg);
                exitCode = proc.startProcess();

                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingCompleteMessage"));

                return ProcessManager.hasProcessExitedCorrectly(proc, exitCode);
            }
            catch (KeyNotFoundException e)
            {
                LogBookController.Instance.addLogLine("Can't find codec: \r\n" + e.Message + "\r\n" + ErrorManager.fetchTrackData(tracks), LogMessageCategories.Error);

                return false;
            }
        }
    }
}
