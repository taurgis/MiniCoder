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
using System.IO;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Managers;
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;

namespace MiniTech.MiniCoder.Encoding.Output
{
    public class AviOut : Container
    {
        public Boolean mux(SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, SortedList<String, Track[]> fileTracks)
        {
            try
            {
                ExtApplication ffmpeg = ToolsManager.Instance.getTool("ffmpeg");

                LogBookController.Instance.addLogLine("Muxing to AVI", LogMessageCategories.Video);

                MiniProcess proc = new DefaultProcess("Muxing to AVI", fileDetails["name"][0] + "FileMuxingProcess");
                proc.stdErrDisabled(true);
                proc.stdOutDisabled(false);
                proc.initProcess();

                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("muxingMessage") + " avi...");
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

                encOpts.Add("outfile", encOpts["outDIR"] + fileDetails["name"][0] + "_output.avi");

                if (!ffmpeg.isInstalled())
                    ffmpeg.download();

                proc.setFilename(Path.Combine(ffmpeg.getInstallPath(), "ffmpeg.exe"));

                args = "-i \"" + fileTracks["video"][0].encodePath + "\" -vcodec copy -r " + fileDetails["fps"][0] + " -s " + encOpts["width"] + "x" + encOpts["height"] + " ";

                for (int i = 0; i < fileTracks["audio"].Length; i++)
                {
                    args += "-i \"" + fileTracks["audio"][i].encodePath + "\" -acodec copy ";
                }

                args += "\"" + encOpts["outfile"] + "\"";

                proc.setArguments(args);

                int exitCode = proc.startProcess();


                LogBookController.Instance.setInfoLabel("Muxing Complete");
                LogBookController.Instance.addLogLine("Muxing completed", LogMessageCategories.Video);

                return ProcessManager.hasProcessExitedCorrectly(proc, exitCode);
            }
            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error muxing to avi. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
                return false;
            }
        }
    }
}
