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
    class Mp4Out : Container
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public Boolean mux(Tool mp4box, SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> fileTracks)
        {
            try
            {
                SysLanguage language = MiniSystem.getLanguage();
                MiniProcess proc = new DefaultProcess("Muxing to MP4", fileDetails["name"][0] + "FileMuxingProcess");
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);
                LogBook.addLogLine("Muxing to MP4", fileDetails["name"][0] + "FileMuxing", fileDetails["name"][0] + "FileMuxingProcess", false);

                proc.initProcess();
                LogBook.setInfoLabel(language.muxingMessage + " MP4");
                // // LogBook.addLogLine(""Muxing", 1);
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
                    args += "-add \"" + fileTracks["audio"][i].encodePath + ":lang=" + Language.getExtention(fileTracks["audio"][i].language) + "\" ";
                }




                if (encOpts["hardsubmp4"] == "0")
                {
                    for (int i = 0; i < fileTracks["subs"].Length; i++)
                    {
                        args += "-add \"" + fileTracks["subs"][i].demuxPath + ":lang=" + Language.getExtention(fileTracks["subs"][i].language) + "\" ";

                    }
                }
                args += "-new \"" + encOpts["outfile"] + "\"";




                proc.setArguments(args);
                if (proc.getAbandonStatus())
                    return false;

                if (proc.startProcess() != 0)
                {
                    return false;
                }
                else
                {
                    LogBook.addLogLine("Muxing completed", fileDetails["name"][0] + "FileMuxing", "", false);
                    return true;
                }


            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error muxing to MP4. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
