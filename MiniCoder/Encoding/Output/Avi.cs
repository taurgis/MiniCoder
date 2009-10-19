using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.External;
using MiniCoder.Encoding.Process_Management;
using System.IO;
using System.Windows.Forms;
namespace MiniCoder.Encoding.Output
{
    class AviOut : Container
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public Boolean mux(Tool ffmpeg, SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> fileTracks)
        {
            MiniProcess proc = new DefaultProcess("Muxing to AVI");
            proc.stdErrDisabled(true);
            proc.stdOutDisabled(false);


            proc.initProcess();
            LogBook.addLogLine("Muxing", 1);
            LogBook.setInfoLabel("Muxing to avi...");
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

            if (int.Parse(fileDetails["fps"][0]) > 400)
                args = "-i \"" + fileTracks["video"][0].encodePath + "\" -vcodec copy -r " + fileDetails["fps"][0].Replace(".0", "").Substring(0, 2) + "." + fileDetails["fps"][0].Replace(".0", "").Substring(2, fileDetails["fps"][0].Replace(".0", "").Length - 2) + " -s " + encOpts["width"] + "x" + encOpts["height"] + " ";
            else
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
                LogBook.setInfoLabel("Muxing Complete");
                return true;

            }


        }
    }
}
