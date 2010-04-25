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
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Managers;
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;

namespace MiniTech.MiniCoder.Encoding.Input
{
    class Ogm : InputFile
    {
        public SortedList<String, Track[]> getTracks()
        {
            return new SortedList<string, Track[]>();
        }

        public Boolean demux(SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks)
        {
            ExtApplication ogmtools = ToolsManager.Instance.getTool("ogmtools");

            LogBookController.Instance.addLogLine("Demuxing OGM - Using OgmTools", LogMessageCategories.Video);

            MiniProcess proc = new DefaultProcess("Demuxing OGM", fileDetails["name"][0] + "DeMuxingProcess");
            ProcessManager.Instance.Process = proc;

            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);

            try
            {
                if (!ogmtools.isInstalled())
                    ogmtools.download();

                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingMessage") + " OGM");
                proc.initProcess();

                proc.setFilename(Path.Combine(ogmtools.getInstallPath(), "OGMDemuxer.exe"));
                string tempArg = "tracks \"" + fileDetails["fileName"][0] + "\" -p " + tracks["video"][0].id + ":\"" + LocationManager.TempFolder + fileDetails["name"][0] + "-Video Track." + Codec.Instance.getExtention(tracks["video"][0].codec) + "\"";
                tracks["video"][0].demuxPath = LocationManager.TempFolder + fileDetails["name"][0] + "-Video Track." + Codec.Instance.getExtention(tracks["video"][0].codec);

                for (int i = 0; i < tracks["audio"].Length; i++)
                {
                    tracks["audio"][i].demuxPath = LocationManager.TempFolder + fileDetails["name"][0] + "-Audio Track-" + i.ToString() + "." + Codec.Instance.getExtention(tracks["audio"][i].codec);
                    tempArg += " " + tracks["audio"][i].id + ":\"" + tracks["audio"][i].demuxPath + "\"";
                }

                for (int i = 0; i < tracks["subs"].Length; i++)
                {
                    tracks["subs"][i].demuxPath = LocationManager.TempFolder + fileDetails["name"][0] + "-Subtitle Track-" + i.ToString() + "." + Codec.Instance.getExtention(tracks["subs"][i].codec);
                    tempArg += " " + tracks["subs"][i].id + ":\"" + tracks["subs"][i].demuxPath + "\"";
                }

                proc.setArguments(tempArg);
                int exitCode = proc.startProcess();

                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingCompleteMessage"));

                if (!ProcessManager.hasProcessExitedCorrectly(proc, exitCode))
                    return false;

                if (File.Exists(LocationManager.TempFolder + fileDetails["name"][0] + "-Video Track." + Codec.Instance.getExtention(tracks["video"][0].codec)))
                    return true;
                else
                    return false;
            }
            catch (KeyNotFoundException e)
            {
                LogBookController.Instance.addLogLine("Can't find codec: \r\n" + e.Message + "\r\n" + ErrorManager.fetchTrackData(tracks), LogMessageCategories.Error);

                return false;
            }
        }
    }
}
