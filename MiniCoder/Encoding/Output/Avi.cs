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
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.External;
using MiniCoder.Encoding.Process_Management;
using System.IO;
using System.Windows.Forms;
using MiniCoder.Core.Languages;

namespace MiniCoder.Encoding.Output
{
    class AviOut : Container
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public Boolean mux(Tool ffmpeg, SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> fileTracks)
        {
            try
            {
                LogBook.Instance.addLogLine("Muxing to AVI", fileDetails["name"][0] + "FileMuxing", fileDetails["name"][0] + "FileMuxingProcess", false);
                int language = MiniSystem.getLanguage();
                MiniProcess proc = new DefaultProcess("Muxing to AVI", fileDetails["name"][0] + "FileMuxingProcess");
                proc.stdErrDisabled(true);
                proc.stdOutDisabled(false);


                proc.initProcess();
                // // LogBook.Instance.addLogLine(""Muxing", 1);
                LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("muxingMessage", language) + " avi...");
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
                if (proc.getAbandonStatus())
                    return false;

                if (proc.startProcess() != 0)
                {
                    return false;
                }
                else
                {
                    LogBook.Instance.setInfoLabel("Muxing Complete");
                  
                    LogBook.Instance.addLogLine("Muxing completed", fileDetails["name"][0] + "FileMuxing", "", false);
                    return true;
                }

            }
            catch (Exception error)
            {
                LogBook.Instance.addLogLine("Error muxing to avi. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
