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
    class Matroska : Container
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public Boolean mux(Tool mkvtoolnix, SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> fileTracks)
        {
            try
            {
                MiniProcess proc = new DefaultProcess("Muxing to MKV", fileDetails["name"][0] + "FileMuxingProcess");
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);
                LogBook.addLogLine("Muxing to MKV", fileDetails["name"][0] + "FileMuxing", fileDetails["name"][0] + "FileMuxingProcess", false);

                proc.initProcess();
                //// // LogBook.addLogLine(""Muxing",1);
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
                    arg1 += "--timecodes 0:\"" + encOpts["vfr"] + "\" ";

                if (encOpts["advertdisabled"] == "False")
                    arg1 += "--title \"Encoded with MiniCoder\" ";

                if (File.Exists(tempPath + "chapters.xml"))
                    arg1 += "--chapters \"" + tempPath + "chapters.xml\" ";

                if (File.Exists(tempPath + "chapters.txt"))
                    arg1 += "--chapters \"" + tempPath + "chapters.txt\" ";

                if (int.Parse(fileDetails["fps"][0]) > 400)
                    args = "-o \"" + encOpts["outfile"] + "\" --default-duration 0:" + fileDetails["fps"][0].Replace(".0", "").Substring(0, 2) + "." + fileDetails["fps"][0].Replace(".0", "").Substring(2, fileDetails["fps"][0].Replace(".0", "").Length - 2) + "fps --display-dimensions 0:" + encOpts["width"] + "x" + encOpts["height"] + " " + arg1 + "-d 0 -A -S \"" + fileTracks["video"][0].encodePath + "\" ";
                else
                    args = "-o \"" + encOpts["outfile"] + "\" --default-duration 0:" + fileDetails["fps"][0] + "fps --display-dimensions 0:" + encOpts["width"] + "x" + encOpts["height"] + " " + arg1 + "-d 0 -A -S \"" + fileTracks["video"][0].encodePath + "\" ";




                for (int i = 0; i < fileTracks["audio"].Length; i++)
                {
                    if (encOpts["audcodec"] == "0")
                    {
                        args += "--aac-is-sbr 1:1 ";
                        args += "--language 1:" + Language.getExtention(fileTracks["audio"][i].language) + " --track-name 1:\"" + fileTracks["audio"][i].title + "\" -a 1 -D -S \"" + fileTracks["audio"][i].encodePath + "\" ";

                    }
                    else
                        args += "--language 0:" + Language.getExtention(fileTracks["audio"][i].language) + " --track-name 0:\"" + fileTracks["audio"][i].title + "\" -a 0 -D -S \"" + fileTracks["audio"][i].encodePath + "\" ";
                }



                for (int i = 0; i < fileTracks["subs"].Length; i++)
                {
                    args += "--language 0:" + Language.getExtention(fileTracks["subs"][i].language) + " --track-name 0:\"" + fileTracks["subs"][i].title + "\" -s 0 -A -D \"" + fileTracks["subs"][i].demuxPath + "\" ";
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
                if (proc.getAbandonStatus())
                    return false;
                int exitCode = proc.startProcess();
                if (exitCode != 0)
                {
                    // MessageBox.Show("Error during muxing, the output file could still be present though.");
                    return false;
                }
                else
                {
                    LogBook.addLogLine("Muxing Completed", fileDetails["name"][0] + "FileMuxing", "", false);
                    return true;

                }



            }

            catch (Exception error)
            {
                LogBook.addLogLine("Error muxing to Matroska. (" + error + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
