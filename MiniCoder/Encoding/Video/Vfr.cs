﻿using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.Process_Management;
using MiniCoder.External;
using MiniCoder.Encoding.Input.Tracks;
using System.IO;
using System.Windows.Forms;

namespace MiniCoder.Encoding.VideoEnc
{
    class Vfr
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public Boolean analyse(Tool mkv2vfr, SortedList<String, String> encOpts, SortedList<String, String[]> fileDetails, ProcessWatcher processWatcher)
        {
            try
            {
                if (fileDetails["ext"][0] == ".mkv" && encOpts.ContainsKey("vfr"))
                {
                    LogBook.addLogLine("Started analysing VFR", fileDetails["name"][0] + "VFRAnalyse", fileDetails["name"][0] + "VFRAnalyseProcess", false);
                    MiniProcess proc = new DefaultProcess("Analysing for VFR", fileDetails["name"][0] + "VFRAnalyseProcess");
                    processWatcher.setProcess(proc);
                    if (!mkv2vfr.isInstalled())
                        mkv2vfr.download();

                    LogBook.setInfoLabel("Parsing VFR");
                    proc.initProcess();

                    proc.setFilename(Path.Combine(mkv2vfr.getInstallPath(), "mkv2vfr.exe"));
                    proc.setArguments("\"" + fileDetails["fileName"][0] + "\" \"" + tempPath + fileDetails["name"] + "-Video Track.avi\" \"" + tempPath + "timecode.txt\"");

                    //MessageBox.Show(mainProcess.StartInfo.Arguments);

                    proc.startProcess();
                    // infoLabel.Text = "";

                    if (proc.getAbandonStatus())
                    {
                        LogBook.setInfoLabel("Parsing Aborted");
                        return false;
                    }
                    else
                    {
                        LogBook.setInfoLabel("Parsing Completed");

                    }
                    if (!File.Exists(tempPath + "timecode.txt"))
                        return false;


                    // // LogBook.addLogLine(""Reading VFR file", 1);


                    encOpts["vfr"] = tempPath + "timecode.txt";
                    //  details.vfrName = appSettings.tempDIR + details.name + "-Video Track.avi";

                    IfMediaDetails tempmedia;
                    if (IntPtr.Size == 8)
                        tempmedia = new MediaDetails64();
                    else
                        tempmedia = new MediaDetails32();
                    fileDetails["fps"][0] = tempmedia.fps(encOpts["vfr"]).ToString();



                }
                return true;
            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error analysing VFR. (" + error + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
