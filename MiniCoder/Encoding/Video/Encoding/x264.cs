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
    class x264 : VideoEncoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public Boolean encode(Tool x264, SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> fileTracks)
        {
            try
            {
                string pass = "0";
                MiniProcess proc;

                LogBook.addLogLine("Encoding to X264", fileDetails["name"][0] + "VideoEncoding", "", false);
                string pass1Arg = "", pass2Arg = "", pass3Arg = null;


                // proc.setTotalFrames(fileDetails["framecount"]);

                DateTime tempStart = new DateTime();

                int Processors = Environment.ProcessorCount;
                String extra;
                if (Processors > 1)
                    extra = "--threads auto --thread-input";
                else
                    extra = "--threads auto";
                fileDetails.Add("statsfile", new string[1]);
                fileDetails["statsfile"][0] = tempPath + fileDetails["name"][0] + ".stats";
                if (encOpts["sizeopt"] == "1")
                {
                    Calc brCalc = new Calc(fileDetails, encOpts, fileTracks);
                    encOpts["videobr"] = brCalc.getVideoBitrate().ToString();

                    // // // LogBook.addLogLine(""Video Bitrate: " + encOpts["videobr"], 1);
                }



                if (!x264.isInstalled())
                    x264.download();

                fileTracks["video"][0].encodePath = tempPath + fileDetails["name"][0] + "_video output.264";

                switch (encOpts["vidqual"])
                {
                    case "0":
                        pass1Arg = "--pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --level 3.1 --bframes 1 --weightb --direct temporal --deblock 1:1 --subme 1 --partitions none --vbv-bufsize 14000 --vbv-maxrate 17500 --me dia " + extra + " --output";
                        pass2Arg = "--pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --level 3.1 --bframes 1 --weightb --direct temporal --deblock 1:1 --partitions p8x8,b8x8,i4x4 --vbv-bufsize 14000 --vbv-maxrate 17500 " + extra + " --output";
                        break;

                    case "1":
                        pass1Arg = "--pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --level 4.1 --bframes 2 --b-pyramid normal --weightb --direct auto --deblock 1:1 --subme 1 --partitions none  --vbv-bufsize 14000 --vbv-maxrate 17500 --me dia " + extra + " --output";
                        pass2Arg = "--pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --level 4.1 --ref 3 --mixed-refs --bframes 2 --b-pyramid normal --weightb --direct auto --deblock 1:1 --subme 8 --trellis 1 --partitions all  --8x8dct --vbv-bufsize 14000 --vbv-maxrate 17500 --me umh " + extra + " --output";
                        break;

                    case "2":
                        pass1Arg = "--pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --level 5.1 --bframes 3 --b-pyramid normal --b-adapt 1 --weightb --direct auto --deblock 1:1 --subme 1 --partitions none --vbv-bufsize 14000 --vbv-maxrate 17500 --me dia " + extra + " --output";
                        pass2Arg = "--pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --level 5.1 --ref 5 --mixed-refs --bframes 3 --b-pyramid normal --b-adapt 1 --weightb --direct auto --deblock 1:1 --subme 8 --trellis 1 --partitions all --8x8dct --vbv-bufsize 14000 --vbv-maxrate 17500 --me umh " + extra + " --output";
                        break;

                    case "3":
                        pass1Arg = "--pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --level 5.1 --tune animation --bframes 8 --b-adapt 2 --b-pyramid normal --weightb --direct auto --deblock 1:2 --psy-rd 0.8:0 --aq-mode 0 --merange 32 --scenecut 45 --no-mbtree " + extra + " --subme 2 --partitions none --me dia --output";
                        pass3Arg = "--pass 3 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --level 5.1 --tune animation --bframes 8 --b-adapt 2 --b-pyramid normal --weightb --direct auto --deblock 1:2 --psy-rd 0.8:0 --aq-mode 0 --merange 32 --scenecut 45 --no-mbtree " + extra + " --subme 2 --partitions none --me dia --output";
                        pass2Arg = "--pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --level 5.1 --tune animation --ref 8 --mixed-refs --no-fast-pskip --bframes 8 --b-adapt 2 --b-pyramid normal --weightb --direct auto --deblock 1:2 --subme 9 --trellis 2 --psy-rd 0.8:0 --partitions all --8x8dct --aq-mode 0 --me umh --merange 32 --scenecut 45 --no-mbtree " + extra + " --output";
                        break;

                    case "4":
                        pass1Arg = "--pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --level 5.1 --ref 8 --mixed-refs --no-fast-pskip --bframes 16 --b-adapt 1 --b-pyramid normal --direct auto --deblock 3:3 --subme 7 --chroma-qp-offset -2 --trellis 2 --psy-rd 0.6:0 --partitions all --8x8dct --aq-mode 0 --me umh --merange 16 --scenecut 40 --no-mbtree " + extra + " --output";
                        pass2Arg = "--pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --level 5.1 --ref 8 --mixed-refs --no-fast-pskip --bframes 16 --b-adapt 1 --b-pyramid normal --direct auto --deblock 3:3 --subme 7 --chroma-qp-offset -2 --trellis 2 --psy-rd 0.6:0 --partitions all --8x8dct --aq-mode 0 --me umh --merange 16 --scenecut 40 --no-mbtree " + extra + " --output";
                        break;

                    case "5":
                        pass1Arg = "--pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --level 5.1 --ref 8 --mixed-refs --no-fast-pskip --bframes 16 --b-adapt 1 --b-pyramid normal --direct auto --deblock -2:-1 --subme 6 --trellis 1 --psy-rd 1.0:0 --partitions all --8x8dct --weightb --chroma-qp-offset -2 --aq-mode 0 --me umh --merange 16 --scenecut 40 --no-mbtree " + extra + " --output";
                        pass2Arg = "--pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --level 5.1 --ref 8 --mixed-refs --no-fast-pskip --bframes 16 --b-adapt 1 --b-pyramid normal --direct auto --deblock -2:-1 --subme 6 --trellis 1 --psy-rd 1.0:0 --partitions all --8x8dct --weightb --chroma-qp-offset -2 --aq-mode 0 --me umh --merange 16 --scenecut 40 --no-mbtree " + extra + " --output";
                        break;

                    case "6":
                        pass1Arg = "--pass 1 --crf " + encOpts["crfvalue"] + " --level 5.1 --ref 5 --mixed-refs --no-fast-pskip --bframes 5 --b-pyramid normal --b-adapt 1 --direct auto --deblock 1:1 --subme 7 --chroma-qp-offset 0 --trellis 1 --psy-rd 0.0:0 --partitions all --8x8dct --me umh --qcomp 1.0 --merange 16 --scenecut 40 --weightb " + extra + " --output";
                        break;
                    case "7":
                        pass1Arg = "--profile baseline --level 1.3 --preset fast --pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" " + extra + " --output";
                        pass2Arg = "--profile baseline --level 1.3 --preset fast --pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" " + extra + " --aud --output";
                        break;
                    case "8":
                        pass1Arg = "--profile main --level 3 --preset fast --pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" " + extra + " --output";
                        pass2Arg = "--profile main --level 3 --preset fast --pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" " + extra + " --aud --output";
                        break;
                    case "9":
                        pass1Arg = "--profile high --level 4.1 --preset fast --pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" " + extra + " --output";
                        pass2Arg = "--profile high --level 4.1 --preset fast --pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" " + extra + " --aud --output";
                        break;
                }
                pass = "1";
                proc = new X264Process("Encoding video", pass, fileDetails["name"][0] + "VideoEncodingProcess1", fileDetails, encOpts);
                proc.initProcess();
                processWatcher.setProcess(proc);
                proc.setFilename(Path.Combine(x264.getInstallPath(), "x264.exe"));
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);


                if (pass2Arg != "")
                    proc.setArguments(pass1Arg + " NUL \"" + encOpts["avsfile"] + "\"");
                else
                    proc.setArguments(pass1Arg + " \"" + fileTracks["video"][0].encodePath + "\" \"" + encOpts["avsfile"] + "\"");    //--output ".264" "avs"

                int exitCode;

                tempStart = DateTime.Now;
                LogBook.addLogLine("Encoding Pass 1", fileDetails["name"][0] + "VideoEncoding", fileDetails["name"][0] + "VideoEncodingProcess1", false);
                exitCode = proc.startProcess();
                // // LogBook.addLogLine(""Start time:" + tempStart.ToShortTimeString(), 1);
                // // LogBook.addLogLine(""End Time:" + DateTime.Now.ToShortTimeString(), 1);
                // // LogBook.addLogLine(""Encoding Time:" + (DateTime.Now - tempStart).TotalMinutes.ToString() + " minites.", 1);
                if (proc.getAbandonStatus())
                    return false;

                if (exitCode != 0)
                    return false;

                if (pass3Arg != null)
                {
                    tempStart = DateTime.Now;
                    pass = "2";

                    proc = new X264Process("Encoding video", pass, fileDetails["name"][0] + "VideoEncodingProcess2", fileDetails, encOpts);
                    proc.initProcess();
                    processWatcher.setProcess(proc);
                    proc.setFilename(Path.Combine(x264.getInstallPath(), "x264.exe"));
                    proc.stdErrDisabled(false);
                    proc.stdOutDisabled(false);

                    proc.setArguments(pass3Arg + " NUL \"" + encOpts["avsfile"] + "\"");
                    LogBook.addLogLine("Encoding Pass 3", fileDetails["name"][0] + "VideoEncoding", fileDetails["name"][0] + "VideoEncodingProcess2", false);

                    exitCode = proc.startProcess();
                    // // LogBook.addLogLine(""Start time:" + tempStart.ToShortTimeString(), 1);
                    // // LogBook.addLogLine(""End Time:" + DateTime.Now.ToShortTimeString(), 1);
                    // // LogBook.addLogLine(""Encoding Time:" + (DateTime.Now - tempStart).TotalMinutes.ToString() + " minites.", 1);
                    if (proc.getAbandonStatus())
                        return true;

                    if (exitCode != 0)
                        return false;
                }
                if (pass3Arg != null)
                    pass = "3";
                else
                    pass = "2";

                proc = new X264Process("Encoding video", pass, fileDetails["name"][0] + "VideoEncodingProcess3", fileDetails, encOpts);
                proc.initProcess();
                processWatcher.setProcess(proc);
                proc.setFilename(Path.Combine(x264.getInstallPath(), "x264.exe"));
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);

                if (pass2Arg != "")
                {
                    proc.setArguments(pass2Arg + " \"" + fileTracks["video"][0].encodePath + "\" \"" + encOpts["avsfile"] + "\"");

                    LogBook.addLogLine("Encoding Pass 2", fileDetails["name"][0] + "VideoEncoding", fileDetails["name"][0] + "VideoEncodingProcess3", false);

                    tempStart = DateTime.Now;
                    exitCode = proc.startProcess();
                }
                // // LogBook.addLogLine(""Start time:" + tempStart.ToShortTimeString(), 1);
                // // LogBook.addLogLine(""End Time:" + DateTime.Now.ToShortTimeString(), 1);
                // // LogBook.addLogLine(""Encoding Time:" + (DateTime.Now - tempStart).TotalMinutes.ToString() + " minites.", 1);

                if (proc.getAbandonStatus())
                    return false;

                if (exitCode != 0)
                    return false;
                else
                {
                    LogBook.addLogLine("Encoding completed", fileDetails["name"][0] + "VideoEncoding", "", false);

                    return true;

                }
            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error encoding video to X264. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }
    }
}

