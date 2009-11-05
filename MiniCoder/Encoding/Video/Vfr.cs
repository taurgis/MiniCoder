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
                   SysLanguage language = MiniSystem.getLanguage();
                if (fileDetails["ext"][0].ToLower() == "mkv" && encOpts.ContainsKey("vfr"))
                {
                    LogBook.addLogLine("Started analysing VFR", fileDetails["name"][0] + "VFRAnalyse", fileDetails["name"][0] + "VFRAnalyseProcess", false);
                    MiniProcess proc = new DefaultProcess("Analysing for VFR", fileDetails["name"][0] + "VFRAnalyseProcess");
                    processWatcher.setProcess(proc);
                    if (!vfr.isInstalled())
                        vfr.download();

                    LogBook.setInfoLabel(language.vfrParsing);
                    proc.initProcess();

                    proc.setFilename(Path.Combine(vfr.getInstallPath(), "mkv2vfr.exe"));
                    proc.setArguments("\"" + fileDetails["fileName"][0] + "\" \"" + tempPath + fileDetails["name"][0] + "-Video Track.avi\" \"" + tempPath + "timecode.txt\"");

                    //MessageBox.Show(mainProcess.StartInfo.Arguments);

                    proc.startProcess();
                    // infoLabel.Text = "";

                    if (proc.getAbandonStatus())
                    {
                        LogBook.setInfoLabel(language.vfrParsingAborted);
                        return false;
                    }
                    else
                    {
                        LogBook.setInfoLabel(language.vfrParsingCompleted);

                    }
                    if (!File.Exists(tempPath + "timecode.txt"))
                        return false;


                    // // LogBook.addLogLine(""Reading VFR file", 1);


                    encOpts["vfr"] = tempPath + "timecode.txt";
                    //  details.vfrName = appSettings.tempDIR + details.name + "-Video Track.avi";
                    


                }
                else if (fileDetails["ext"][0].ToLower() == "mp4" && encOpts.ContainsKey("vfr"))
                {
                    //dtsedit -t input.mp4 timecodes.txt
                    LogBook.addLogLine("Started analysing VFR", fileDetails["name"][0] + "VFRAnalyse", fileDetails["name"][0] + "VFRAnalyseProcess", false);
                    MiniProcess proc = new DefaultProcess("Analysing for VFR", fileDetails["name"][0] + "VFRAnalyseProcess");
                    processWatcher.setProcess(proc);
                    if (!vfrMP4.isInstalled())
                        vfrMP4.download();

                    LogBook.setInfoLabel(language.vfrParsing);
                    proc.initProcess();

                    proc.setFilename(Path.Combine(vfrMP4.getInstallPath(), "DtsEdit.exe"));
                    proc.setArguments("\"" + fileDetails["fileName"][0] + "\"");

                    //MessageBox.Show(mainProcess.StartInfo.Arguments);

                    proc.startProcess();
                    // infoLabel.Text = "";

                    File.Move(fileDetails["fileName"][0] + "_timecode.txt", tempPath + "timecode.txt");



                    if (proc.getAbandonStatus())
                    {
                        LogBook.setInfoLabel(language.vfrParsingAborted);
                        return false;
                    }
                    else
                    {
                        LogBook.setInfoLabel(language.vfrParsingCompleted);

                    }
                    if (!File.Exists(tempPath + "timecode.txt"))
                        return false;

                    encOpts["vfr"] = tempPath + "timecode.txt";
                }
                return true;
            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error analysing VFR. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
