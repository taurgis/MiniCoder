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
using MiniCoder.Encoding.Process_Management;
using MiniCoder.External;
using MiniCoder.Encoding.Input.Tracks;
using System.IO;
using System.Windows.Forms;
using MiniCoder.Core.Languages;
namespace MiniCoder.Encoding.VideoEnc
{
    class Vfr
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public Boolean analyse(Tool vfr, Tool vfrMP4, SortedList<String, String> encOpts, SortedList<String, String[]> fileDetails, ProcessWatcher processWatcher)
        {
            try
            {
                int languageCode = MiniSystem.getLanguage();
                if (fileDetails["ext"][0].ToLower() == "mkv" && encOpts.ContainsKey("vfr"))
                {
                    LogBook.Instance.addLogLine("Started analysing VFR", fileDetails["name"][0] + "VFRAnalyse", fileDetails["name"][0] + "VFRAnalyseProcess", false);
                    MiniProcess proc = new DefaultProcess("Analysing for VFR", fileDetails["name"][0] + "VFRAnalyseProcess");
                    processWatcher.setProcess(proc);
                    if (!vfr.isInstalled())
                        vfr.download();

                    LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("vfrParsing", languageCode));
                    proc.initProcess();

                    proc.setFilename(Path.Combine(vfr.getInstallPath(), "mkv2vfr.exe"));
                    proc.setArguments("\"" + fileDetails["fileName"][0] + "\" \"" + tempPath + fileDetails["name"][0] + "-Video Track.avi\" \"" + tempPath + "timecode.txt\"");

                    //MessageBox.Show(mainProcess.StartInfo.Arguments);

                    proc.startProcess();
                    // infoLabel.Text = "";

                    if (proc.getAbandonStatus())
                    {
                        LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("vfrParsingAborted", languageCode));
                        return false;
                    }
                    else
                    {
                        LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("vfrParsingCompleted", languageCode));

                    }
                    if (!File.Exists(tempPath + "timecode.txt"))
                        return false;


                    // // LogBook.Instance.addLogLine(""Reading VFR file", 1);


                    encOpts["vfr"] = tempPath + "timecode.txt";
                    //  details.vfrName = appSettings.tempDIR + details.name + "-Video Track.avi";



                }
                else if (fileDetails["ext"][0].ToLower() == "mp4" && encOpts.ContainsKey("vfr"))
                {
                    //dtsedit -t input.mp4 timecodes.txt
                    LogBook.Instance.addLogLine("Started analysing VFR", fileDetails["name"][0] + "VFRAnalyse", fileDetails["name"][0] + "VFRAnalyseProcess", false);
                    MiniProcess proc = new DefaultProcess("Analysing for VFR", fileDetails["name"][0] + "VFRAnalyseProcess");
                    processWatcher.setProcess(proc);
                    if (!vfrMP4.isInstalled())
                        vfrMP4.download();

                    LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("vfrParsing", languageCode));
                    proc.initProcess();

                    proc.setFilename(Path.Combine(vfrMP4.getInstallPath(), "DtsEdit.exe"));
                    proc.setArguments("\"" + fileDetails["fileName"][0] + "\"");

                    //MessageBox.Show(mainProcess.StartInfo.Arguments);

                    proc.startProcess();
                    // infoLabel.Text = "";

                    File.Move(fileDetails["fileName"][0] + "_timecode.txt", tempPath + "timecode.txt");



                    if (proc.getAbandonStatus())
                    {
                        LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("vfrParsingAborted", languageCode));
                        return false;
                    }
                    else
                    {
                        LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("vfrParsingCompleted", languageCode));

                    }
                    if (!File.Exists(tempPath + "timecode.txt"))
                        return false;

                    encOpts["vfr"] = tempPath + "timecode.txt";
                }
                return true;
            }
            catch (Exception error)
            {
                LogBook.Instance.addLogLine("Error analysing VFR. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
