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
    class Matroska : Container
    {
        public Boolean mux(Tool mkvtoolnix, SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> fileTracks)
        {
            try
            {

                MiniProcess proc = new DefaultProcess("Muxing to MKV", fileDetails["name"][0] + "FileMuxingProcess");
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);
                proc.initProcess();

                LogBookController.Instance.addLogLine("Muxing to MKV", LogMessageCategories.Video);
                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("muxingMessage") + " MKV");

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

                encOpts.Add("outfile", encOpts["outDIR"] + fileDetails["name"][0] + "_output.mkv");

                if (!mkvtoolnix.isInstalled())
                    mkvtoolnix.download();

                proc.setFilename(Path.Combine(mkvtoolnix.getInstallPath(), "mkvmerge.exe"));

                string arg1 = "";

                if (encOpts.ContainsKey("vfr"))
                    if (!String.IsNullOrEmpty(encOpts["vfr"]))
                        arg1 += "--timecodes 0:\"" + encOpts["vfr"] + "\" ";

                if (encOpts["advertdisabled"] == "False")
                    arg1 += "--title \"Encoded with MiniCoder\" ";

                if (File.Exists(LocationManager.TempFolder + "chapters.xml"))
                    arg1 += "--chapters \"" + LocationManager.TempFolder + "chapters.xml\" ";

                if (File.Exists(LocationManager.TempFolder + "chapters.txt"))
                    arg1 += "--chapters \"" + LocationManager.TempFolder + "chapters.txt\" ";

                try
                {
                    args = "-o \"" + encOpts["outfile"] + "\" --default-duration 0:" + fileDetails["fps"][0] + "fps --display-dimensions 0:" + encOpts["width"] + "x" + encOpts["height"] + " " + arg1 + "-d 0 -A -S \"" + fileTracks["video"][0].encodePath + "\" ";
                }
                catch
                {
                    LogBookController.Instance.addLogLine("Error parsing fps", LogMessageCategories.Error);
                    return false;
                }


                for (int i = 0; i < fileTracks["audio"].Length; i++)
                {
                    if (encOpts["audcodec"] == "0")
                    {
                        args += "--aac-is-sbr 1:1 ";
                        args += "--language 1:" + Language.Instance.getExtention(fileTracks["audio"][i].language) + " --track-name 1:\"" + fileTracks["audio"][i].title + "\" -a 1 -D -S \"" + fileTracks["audio"][i].encodePath + "\" ";
                    }
                    else
                        args += "--language 0:" + Language.Instance.getExtention(fileTracks["audio"][i].language) + " --track-name 0:\"" + fileTracks["audio"][i].title + "\" -a 0 -D -S \"" + fileTracks["audio"][i].encodePath + "\" ";
                }

                for (int i = 0; i < fileTracks["subs"].Length; i++)
                {
                    args += "--language 0:" + Language.Instance.getExtention(fileTracks["subs"][i].language) + " --track-name 0:\"" + fileTracks["subs"][i].title + "\" -s 0 -A -D \"" + fileTracks["subs"][i].demuxPath + "\" ";
                }

                if (fileTracks.ContainsKey("attachments"))
                {
                    for (int i = 0; i < fileTracks["attachments"].Length; i++)
                    {
                        if (File.Exists(fileTracks["attachments"][i].demuxPath))
                            args += "--attachment-mime-type application/x-truetype-font --attachment-name \"" + fileTracks["attachments"][i].title + "\" --attach-file \"" + fileTracks["attachments"][i].demuxPath + "\" ";
                    }
                }

                args += "--track-order 0:0,";

                for (int i = 0; i < fileTracks["audio"].Length; i++)
                    args += (i + 1).ToString() + ":1,";

                int step = fileTracks["audio"].Length + 1;

                for (int i = 0; i < fileTracks["subs"].Length; i++)
                    args += (i + step).ToString() + ":0,";

                proc.setArguments(args);

                int exitCode = proc.startProcess();

                LogBookController.Instance.addLogLine("Muxing Completed", LogMessageCategories.Video);

                return ProcessManager.hasProcessExitedCorrectly(proc, exitCode);
            }

            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error muxing to Matroska. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
                return false;
            }
        }
    }
}
