﻿using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.External;
using MiniCoder.Encoding.Process_Management;
using System.IO;
using System.Windows.Forms;
namespace MiniCoder.Encoding.Output
{
    class Mp4Out : Container
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public Boolean mux(Tool mp4box, SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> fileTracks)
        {
            MiniProcess proc = new DefaultProcess("Muxing to MP4");
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);


            proc.initProcess();
            LogBook.addLogLine("Muxing", 1);
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


            if (int.Parse(fileDetails["fps"][0]) > 400)
                args = "-fps " + fileDetails["fps"][0].Replace(".0", "").Substring(0, 2) + "." + fileDetails["fps"][0].Replace(".0", "").Substring(2, fileDetails["fps"][0].Replace(".0", "").Length - 2) + " -add \"" + fileTracks["video"][0].encodePath + "#video:name=Video\" ";
            else
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
                return true;
            }


        }
    }
}
