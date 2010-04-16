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
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.External;
using MiniTech.MiniCoder.Encoding.Process_Management;
using System.Windows.Forms;
using System.IO;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Core.Managers;

namespace MiniTech.MiniCoder.Encoding.VideoEnc.Encoding
{
    public class x264 : VideoEncoder
    {
        public Boolean encode(Tool x264, SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> fileTracks)
        {
            try
            {
                string pass = "0";
                MiniProcess proc;

                LogBookController.Instance.addLogLine("Encoding to X264", LogMessageCategories.Video);
                string pass1Arg = "", pass2Arg = "", pass3Arg = null;

                int Processors = Environment.ProcessorCount;
                String extra;

                if (Processors > 1)
                    extra = "--threads auto --thread-input";
                else
                    extra = "--threads auto";

                fileDetails.Add("statsfile", new string[1]);
                fileDetails["statsfile"][0] = LocationManager.TempFolder + fileDetails["name"][0] + ".stats";
                if (encOpts["sizeopt"] == "1")
                {
                    Calc brCalc = new Calc(fileDetails, encOpts, fileTracks);
                    encOpts["videobr"] = brCalc.getVideoBitrate().ToString();
                }

                if (!x264.isInstalled())
                    x264.download();

                fileTracks["video"][0].encodePath = LocationManager.TempFolder + fileDetails["name"][0] + "_video output.264";

                switch (encOpts["vidqual"])
                {
                    case "0":
                        LogBookController.Instance.addLogLine("Medium", LogMessageCategories.Video);
                        pass1Arg = "--pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --bframes 1 --weightb --direct temporal --deblock 1:1 --subme 1 --partitions none --vbv-bufsize 14000 --vbv-maxrate 17500 --me dia " + extra + " --output";
                        pass2Arg = "--pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --bframes 1 --weightb --direct temporal --deblock 1:1 --partitions p8x8,b8x8,i4x4 --vbv-bufsize 14000 --vbv-maxrate 17500 " + extra + " --output";
                        break;

                    case "1":
                        LogBookController.Instance.addLogLine("High", LogMessageCategories.Video);
                        pass1Arg = "--pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --bframes 2 --b-pyramid normal --weightb --direct auto --deblock 1:1 --subme 1 --partitions none  --vbv-bufsize 14000 --vbv-maxrate 17500 --me dia " + extra + " --output";
                        pass2Arg = "--pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --ref 3 --mixed-refs --bframes 2 --b-pyramid normal --weightb --direct auto --deblock 1:1 --subme 8 --trellis 1 --partitions all  --8x8dct --vbv-bufsize 14000 --vbv-maxrate 17500 --me umh " + extra + " --output";
                        break;

                    case "2":
                        LogBookController.Instance.addLogLine("Very High", LogMessageCategories.Video);
                        pass1Arg = "--pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --bframes 3 --b-pyramid normal --b-adapt 1 --weightb --direct auto --deblock 1:1 --subme 1 --partitions none --vbv-bufsize 14000 --vbv-maxrate 17500 --me dia " + extra + " --output";
                        pass2Arg = "--pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --ref 5 --mixed-refs --bframes 3 --b-pyramid normal --b-adapt 1 --weightb --direct auto --deblock 1:1 --subme 8 --trellis 1 --partitions all --8x8dct --vbv-bufsize 14000 --vbv-maxrate 17500 --me umh " + extra + " --output";
                        break;

                    case "3":
                        LogBookController.Instance.addLogLine("Very High (+50 mb anime)", LogMessageCategories.Video);
                        pass1Arg = "--pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --tune animation --bframes 8 --b-adapt 2 --b-pyramid normal --weightb --qcomp 0.8 --direct auto --deblock 1:2 --psy-rd 0.4:0 --aq-mode 0 --merange 32 --scenecut 45 " + extra + " --subme 2 --partitions none --me dia --output";
                        pass2Arg = "--pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --tune animation --ref 8 --mixed-refs --no-fast-pskip --qcomp 0.8 --bframes 8 --b-adapt 2 --b-pyramid normal --weightb --direct auto --deblock 1:2 --subme 9 --trellis 2 --psy-rd 0.4:0 --partitions all --8x8dct --aq-mode 0 --me umh --merange 32 --scenecut 45 " + extra + " --output";
                        break;

                    case "4":
                        LogBookController.Instance.addLogLine("Very High (-50 mb anime)", LogMessageCategories.Video);
                        pass1Arg = "--pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --ref 8 --mixed-refs --no-fast-pskip --qcomp 0.8 --bframes 16 --b-adapt 1 --b-pyramid normal --direct auto --deblock 3:3 --subme 7 --chroma-qp-offset -2 --trellis 2 --psy-rd 0.6:0 --partitions all --8x8dct --aq-mode 0 --me umh --merange 16 --scenecut 40 " + extra + " --output";
                        pass2Arg = "--pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --ref 8 --mixed-refs --no-fast-pskip --qcomp 0.8 --bframes 16 --b-adapt 1 --b-pyramid normal --direct auto --deblock 3:3 --subme 7 --chroma-qp-offset -2 --trellis 2 --psy-rd 0.6:0 --partitions all --8x8dct --aq-mode 0 --me umh --merange 16 --scenecut 40 " + extra + " --output";
                        break;

                    case "5":
                        LogBookController.Instance.addLogLine("Very High (TV-Shows)", LogMessageCategories.Video);
                        pass1Arg = "--pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --ref 8 --mixed-refs --no-fast-pskip --qcomp 0.8 --bframes 16 --b-adapt 1 --b-pyramid normal --direct auto --deblock -2:-1 --subme 6 --trellis 1 --psy-rd 1.0:0 --partitions all --8x8dct --weightb --chroma-qp-offset -2 --aq-mode 0 --me umh --merange 16 --scenecut 40 " + extra + " --output";
                        pass2Arg = "--pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" --ref 8 --mixed-refs --no-fast-pskip --qcomp 0.8 --bframes 16 --b-adapt 1 --b-pyramid normal --direct auto --deblock -2:-1 --subme 6 --trellis 1 --psy-rd 1.0:0 --partitions all --8x8dct --weightb --chroma-qp-offset -2 --aq-mode 0 --me umh --merange 16 --scenecut 40 " + extra + " --output";
                        break;

                    case "6":
                        LogBookController.Instance.addLogLine("CRF (Anime)", LogMessageCategories.Video);
                        pass1Arg = "--crf " + encOpts["crfvalue"] + " --ref 5 --mixed-refs --no-fast-pskip --bframes 5 --b-pyramid normal --b-adapt 1 --direct auto --deblock 1:1 --subme 7 --chroma-qp-offset 0 --trellis 1 --psy-rd 0.0:0 --partitions all --8x8dct --me umh --qcomp 0.8 --merange 16 --scenecut 40 --weightb " + extra + " --output";
                        break;
                    case "7":
                        LogBookController.Instance.addLogLine("Ipod", LogMessageCategories.Video);
                        pass1Arg = "--profile baseline --level 1.3 --preset fast --pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" " + extra + " --output";
                        pass2Arg = "--profile baseline --level 1.3 --preset fast --pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" " + extra + " --aud --output";
                        break;
                    case "8":
                        LogBookController.Instance.addLogLine("PSP", LogMessageCategories.Video);
                        pass1Arg = "--profile main --level 3 --preset fast --pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" " + extra + " --output";
                        pass2Arg = "--profile main --level 3 --preset fast --pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" " + extra + " --aud --output";
                        break;
                    case "9":
                        LogBookController.Instance.addLogLine("PS3", LogMessageCategories.Video);
                        pass1Arg = "--profile high --level 4.1 --preset fast --pass 1 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" " + extra + " --output";
                        pass2Arg = "--profile high --level 4.1 --preset fast --pass 2 --bitrate " + encOpts["videobr"] + " --stats \"" + fileDetails["statsfile"][0] + "\" " + extra + " --aud --output";
                        break;
                }

                pass = "1";
                proc = new X264Process(LanguageController.Instance.getLanguageString("encodingVideoPass"), pass, fileDetails["name"][0] + "VideoEncodingProcess1", fileDetails, encOpts);
                proc.initProcess();
                processWatcher.setProcess(proc);
                proc.setFilename(Path.Combine(x264.getInstallPath(), "x264.exe"));
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);

                if (pass2Arg != "")
                    proc.setArguments(pass1Arg + " NUL \"" + encOpts["avsfile"] + "\"");
                else
                    proc.setArguments(pass1Arg + " \"" + fileTracks["video"][0].encodePath + "\" \"" + encOpts["avsfile"] + "\"");    //--output ".264" "avs"

                LogBookController.Instance.addLogLine("Encoding Pass 1", LogMessageCategories.Video);

                if (!ProcessManager.hasProcessExitedCorrectly(proc, proc.startProcess()))
                    return false;

                if (pass3Arg != null)
                {
                    pass = "2";

                    proc = new X264Process(LanguageController.Instance.getLanguageString("encodingVideoPass"), pass, fileDetails["name"][0] + "VideoEncodingProcess2", fileDetails, encOpts);
                    proc.initProcess();
                    processWatcher.setProcess(proc);
                    proc.setFilename(Path.Combine(x264.getInstallPath(), "x264.exe"));
                    proc.stdErrDisabled(false);
                    proc.stdOutDisabled(false);

                    proc.setArguments(pass3Arg + " NUL \"" + encOpts["avsfile"] + "\"");
                    LogBookController.Instance.addLogLine("Encoding Pass 3", LogMessageCategories.Video);

                    if (!ProcessManager.hasProcessExitedCorrectly(proc, proc.startProcess()))
                        return false;
                }

                if (pass3Arg != null)
                    pass = "3";
                else
                    pass = "2";

                proc = new X264Process(LanguageController.Instance.getLanguageString("encodingVideoPass"), pass, fileDetails["name"][0] + "VideoEncodingProcess3", fileDetails, encOpts);
                proc.initProcess();
                processWatcher.setProcess(proc);
                proc.setFilename(Path.Combine(x264.getInstallPath(), "x264.exe"));
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);

                if (pass2Arg != "")
                {
                    proc.setArguments(pass2Arg + " \"" + fileTracks["video"][0].encodePath + "\" \"" + encOpts["avsfile"] + "\"");

                    LogBookController.Instance.addLogLine("Encoding Pass 2", LogMessageCategories.Video);

                    int exitCode = proc.startProcess();

                    LogBookController.Instance.addLogLine("Encoding completed", LogMessageCategories.Video);
                    return ProcessManager.hasProcessExitedCorrectly(proc, exitCode);
                }

                return true;
            }
            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error encoding video to X264. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
                return false;
            }
        }
    }
}

