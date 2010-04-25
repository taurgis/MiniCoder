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
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using System.IO;
using System.Windows.Forms;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Core.Managers;

namespace MiniTech.MiniCoder.Encoding.VideoEnc
{
    public class Vfr
    {
        public Boolean analyse(SortedList<String, String> encOpts, SortedList<String, String[]> fileDetails)
        {
            try
            {
                ExtApplication vfr = ToolsManager.Instance.getTool("mkv2vfr");
                ExtApplication vfrMP4 = ToolsManager.Instance.getTool("DtsEdit");

                if (fileDetails["ext"][0].ToLower() == "mkv" && encOpts.ContainsKey("vfr"))
                {
                    LogBookController.Instance.addLogLine("Started analysing VFR", LogMessageCategories.Video);

                    MiniProcess proc = new DefaultProcess("Analysing for VFR", fileDetails["name"][0] + "VFRAnalyseProcess");
                    ProcessManager.Instance.Process = proc;

                    if (!vfr.isInstalled())
                        vfr.download();

                    LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("vfrParsing"));
                    proc.initProcess();

                    proc.setFilename(Path.Combine(vfr.getInstallPath(), "mkv2vfr.exe"));
                    proc.setArguments("\"" + fileDetails["fileName"][0] + "\" \"" + LocationManager.TempFolder + fileDetails["name"][0] + "-Video Track.avi\" \"" + LocationManager.TempFolder + "timecode.txt\"");

                    int exitCode = proc.startProcess();


                    LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("vfrParsingCompleted"));

                    if (!ProcessManager.hasProcessExitedCorrectly(proc, exitCode))
                        return false;

                    if (!File.Exists(LocationManager.TempFolder + "timecode.txt"))
                        return false;

                    encOpts["vfr"] = LocationManager.TempFolder + "timecode.txt";
                }
                else if (fileDetails["ext"][0].ToLower() == "mp4" && encOpts.ContainsKey("vfr"))
                {
                    LogBookController.Instance.addLogLine("Started analysing VFR", LogMessageCategories.Video);
                    MiniProcess proc = new DefaultProcess("Analysing for VFR", fileDetails["name"][0] + "VFRAnalyseProcess");
                    ProcessManager.Instance.Process = proc;

                    if (!vfrMP4.isInstalled())
                        vfrMP4.download();

                    LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("vfrParsing"));
                    proc.initProcess();

                    proc.setFilename(Path.Combine(vfrMP4.getInstallPath(), "DtsEdit.exe"));
                    proc.setArguments("\"" + fileDetails["fileName"][0] + "\"");

                    int exitCode = proc.startProcess();

                    File.Move(fileDetails["fileName"][0] + "_timecode.txt", LocationManager.TempFolder + "timecode.txt");


                    LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("vfrParsingCompleted"));

                    if (!ProcessManager.hasProcessExitedCorrectly(proc, exitCode))
                        return false;

                    if (!File.Exists(LocationManager.TempFolder + "timecode.txt"))
                        return false;

                    encOpts["vfr"] = LocationManager.TempFolder + "timecode.txt";
                }
                return true;
            }
            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error analysing VFR. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
                return false;
            }
        }
    }
}
