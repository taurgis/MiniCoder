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

namespace MiniTech.MiniCoder.Encoding.Output
{
    public class Mp4Out : Container
    {
        public Boolean mux( SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, SortedList<String, Track[]> fileTracks)
        {
            try
            {
                ExtApplication mp4box = ToolsManager.Instance.getTool("mp4box");

                MiniProcess proc = new DefaultProcess("Muxing to MP4", fileDetails["name"][0] + "FileMuxingProcess");
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);
                proc.initProcess();

                LogBookController.Instance.addLogLine("Muxing to MP4", LogMessageCategories.Video);
                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("muxingMessage") + " MP4");

                string args;

                try
                {
                    float dar = int.Parse(encOpts["width"]) / int.Parse(encOpts["height"]);
                    float par = int.Parse(fileDetails["width"][0]) / int.Parse(fileDetails["height"][0]);

                    if (dar != par & encOpts["sizeopt"] != "0")
                    {

                        encOpts["width"] = (int.Parse(encOpts["width"]) * dar).ToString();
                    }
                }
                catch
                {
                    encOpts["width"] = fileDetails["width"][0];
                    encOpts["height"] = fileDetails["height"][0];

                }

                encOpts.Add("outfile", encOpts["outDIR"] + fileDetails["name"][0] + "_output.mp4");

                if (!mp4box.isInstalled())
                    mp4box.download();

                proc.setFilename(Path.Combine(mp4box.getInstallPath(), "mp4box.exe"));

                args = "-fps " + fileDetails["fps"][0] + " -add \"" + fileTracks["video"][0].encodePath + "#video:name=Video\" ";

                for (int i = 0; i < fileTracks["audio"].Length; i++)
                {
                    args += "-add \"" + fileTracks["audio"][i].encodePath + ":lang=" + Language.Instance.getExtention(fileTracks["audio"][i].language) + "\" ";
                }

                if (encOpts["hardsubmp4"] == "0")
                {
                    for (int i = 0; i < fileTracks["subs"].Length; i++)
                    {
                        args += "-add \"" + fileTracks["subs"][i].demuxPath + ":lang=" + Language.Instance.getExtention(fileTracks["subs"][i].language) + "\" ";

                    }
                }
                args += "-new \"" + encOpts["outfile"] + "\"";

                proc.setArguments(args);
                if (proc.getAbandonStatus())
                    return false;

                int exitCode = proc.startProcess();

                LogBookController.Instance.addLogLine("Muxing completed", LogMessageCategories.Video);

                return ProcessManager.hasProcessExitedCorrectly(proc, exitCode);
            }
            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error muxing to MP4. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
                return false;
            }
        }
    }
}
