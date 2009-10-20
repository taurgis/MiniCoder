using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.External;
using MiniCoder.Encoding.Process_Management;
using System.Windows.Forms;
using System.IO;

namespace MiniCoder.Encoding.VideoEnc.Encoding
{
    class Theora : VideoEncoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public Boolean encode(Tool theora, SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> fileTracks)
        {
            LogBook.addLogLine("Encoding to Theora", fileDetails["name"][0] + "VideoEncoding", "", false);
          
            MiniProcess proc;

           
            string pass1Arg = "";

            DateTime tempStart = new DateTime();
     
          
            if (encOpts["sizeopt"] == "1")
            {
                Calc brCalc = new Calc(fileDetails, encOpts, fileTracks);
                encOpts["videobr"] = brCalc.getVideoBitrate().ToString();

              // // // LogBook.addLogLine(""Video Bitrate: " + encOpts["videobr"], 1);
            }

            if (!theora.isInstalled())
                theora.download();

            fileTracks["video"][0].encodePath = encOpts["outDIR"] + fileDetails["name"][0] + "_output.ogg";

               
                    LogBook.setInfoLabel("Encoding Theora video");
                    if (!theora.isInstalled())
                        theora.download();
                   
                
                    string resize ="";
                    if (encOpts["resize"] != "0")
                        resize = "--width " + encOpts["width"] + " --height " + encOpts["height"];

                    switch (encOpts["vidqual"])
                    {
                        case "0":
                            pass1Arg = "\"" + fileDetails["fileName"][0] + "\" " + resize + " -a 10 -A " + encOpts["audbr"] + " -v 4 -V " + encOpts["videobr"] + " -o \"" + encOpts["outDIR"] + fileDetails["name"][0] + "_output.ogg" + "\"";  
                            
                            break;

                        case "1":
                            pass1Arg = "\"" + fileDetails["fileName"][0] + "\" " + resize + " -a 10 -A " + encOpts["audbr"] + " -v 7 -V " + encOpts["videobr"] + " -o \"" + encOpts["outDIR"] + fileDetails["name"][0] + "_output.ogg" + "\"";
                            break;

                        case "2":
                            pass1Arg = "\"" + fileDetails["fileName"][0] + "\" " + resize + " -a 10 -A " + encOpts["audbr"] + " -v 10 -V " + encOpts["videobr"] + " -o \"" + encOpts["outDIR"] + fileDetails["name"][0] + "_output.ogg" + "\"";
                            break;

                    }

                    
                  

            
         
            proc = new TheoraProcess("Encoding video");
            proc.initProcess();
            processWatcher.setProcess(proc);
            proc.setFilename(Path.Combine(theora.getInstallPath(), "theora.exe"));
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            proc.setArguments(pass1Arg);


            int exitCode;

            tempStart = DateTime.Now;

            exitCode = proc.startProcess();
            //// LogBook.addLogLine(""Start time:" + tempStart.ToShortTimeString(), 1);
            //// LogBook.addLogLine(""End Time:" + DateTime.Now.ToShortTimeString(), 1);
            //// LogBook.addLogLine(""Encoding Time:" + (DateTime.Now - tempStart).TotalMinutes.ToString() + " minites.", 1);


            LogBook.addLogLine("Encoding completed", fileDetails["name"][0] + "VideoEncoding", "", false);
            if (proc.getAbandonStatus())
                return true;

            if (exitCode != 0)
                return false;
            else
                return true;
        }
    }
}

