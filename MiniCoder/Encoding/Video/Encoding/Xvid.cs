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
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.External;
using MiniCoder.Encoding.Process_Management;
using System.Windows.Forms;
using System.IO;
using MiniCoder.Core.Languages;
namespace MiniCoder.Encoding.VideoEnc.Encoding
{
    class Xvid : VideoEncoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public Boolean encode(Tool xvid_encraw, SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> fileTracks)
        {
            try
            {
                SysLanguage language = MiniSystem.getLanguage();
                string pass = "0";
                MiniProcess proc;

                LogBook.addLogLine("Encoding to Xvid", fileDetails["name"][0] + "VideoEncoding", "", false);

                string pass1Arg = "", pass2Arg = "";

                DateTime tempStart = new DateTime();

                fileDetails.Add("statsfile", new string[1]);
                fileDetails["statsfile"][0] = tempPath + fileDetails["name"][0] + ".stats";
                if (encOpts["sizeopt"] == "1")
                {
                    Calc brCalc = new Calc(fileDetails, encOpts, fileTracks);
                    encOpts["videobr"] = brCalc.getVideoBitrate().ToString();

                    // // LogBook.addLogLine(""Video Bitrate: " + encOpts["videobr"], 1);
                }

                if (!xvid_encraw.isInstalled())
                    xvid_encraw.download();

                fileTracks["video"][0].encodePath = tempPath + fileDetails["name"][0] + "_video output.avi";

                switch (encOpts["vidqual"])
                {
                    case "0":
                        pass1Arg = "-pass1 \"" + fileDetails["statsfile"][0] + "\" -bitrate " + encOpts["videobr"] + " -kboost 100 -chigh 30 -clow 15 -overhead 0 -turbo -max_key_interval 250 -nopacked -quality 5 -vhqmode 0 -closed_gop -lumimasking -notrellis -nochromame -imin 1 -pmin 1 -bquant_ratio 162 -bquant_offset 0 -bmin 1 -par 1:1 -threads 1 -o";
                        pass2Arg = "-pass2 \"" + fileDetails["statsfile"][0] + "\" -bitrate " + encOpts["videobr"] + " -kboost 100 -chigh 30 -clow 15 -overhead 0 -turbo -max_key_interval 250 -nopacked -quality 5 -vhqmode 0 -closed_gop -lumimasking -notrellis -nochromame -imin 1 -pmin 1 -bquant_ratio 162 -bquant_offset 0 -bmin 1 -threads 1  -o";
                        break;

                    case "1":
                        pass1Arg = "-pass1 \"" + fileDetails["statsfile"][0] + "\" -bitrate " + encOpts["videobr"] + " -kboost 100 -chigh 30 -clow 15 -overhead 0 -turbo -max_key_interval 250 -nopacked -closed_gop -lumimasking -imin 1 -pmin 1 -bvhq -bquant_ratio 162 -bquant_offset 0 -bmin 1 -par 1:1 -threads 1 -o";
                        pass2Arg = "-pass2 \"" + fileDetails["statsfile"][0] + "\" -bitrate " + encOpts["videobr"] + " -kboost 100 -chigh 30 -clow 15 -overhead 0 -turbo -max_key_interval 250 -nopacked -closed_gop -lumimasking -imin 1 -pmin 1 -bvhq -bquant_ratio 162 -bquant_offset 0 -bmin 1 -threads 1  -o";
                        break;

                    case "2":
                        pass1Arg = "-pass1 \"" + fileDetails["statsfile"][0] + "\" -bitrate " + encOpts["videobr"] + " -kboost 100 -chigh 30 -clow 15 -overhead 0 -turbo -max_key_interval 250 -nopacked -quality 5 -vhqmode 0 -closed_gop -lumimasking -notrellis -nochromame -imin 1 -pmin 1 -bquant_ratio 162 -bquant_offset 0 -bmin 1 -par 1:1 -threads 1 -o";
                        pass2Arg = "-pass2 \"" + fileDetails["statsfile"][0] + "\" -bitrate " + encOpts["videobr"] + " -kboost 100 -chigh 30 -clow 15 -overhead 0 -turbo -max_key_interval 250 -nopacked -vhqmode 4 -qpel -closed_gop -lumimasking -imin 1 -pmin 1 -bvhq -bquant_ratio 162 -bquant_offset 0 -bmin 1 -threads 1  -o";
                        break;

                }

                pass = "1";
                proc = new XvidProcess(language.encodingVideoPass, pass, int.Parse(fileDetails["framecount"][0]), fileDetails["name"][0] + "VideoEncodingProcess1");
                proc.initProcess();
                processWatcher.setProcess(proc);
                proc.setFilename(Path.Combine(xvid_encraw.getInstallPath(), "xvid_encraw.exe"));
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);
                proc.setArguments("-i \"" + encOpts["avsfile"] + "\" " + pass1Arg + " NUL");


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

                pass = "2";

                proc = new XvidProcess(language.encodingVideoPass, pass, int.Parse(fileDetails["framecount"][0]), fileDetails["name"][0] + "VideoEncodingProcess2");
                proc.initProcess();
                processWatcher.setProcess(proc);
                proc.setFilename(Path.Combine(xvid_encraw.getInstallPath(), "xvid_encraw.exe"));
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);

                if (pass2Arg != "")
                {
                    proc.setArguments("-i \"" + encOpts["avsfile"] + "\" " + pass2Arg + " \"" + fileTracks["video"][0].encodePath + "\"");
                }
                LogBook.addLogLine("Encoding Pass 2", fileDetails["name"][0] + "VideoEncoding", fileDetails["name"][0] + "VideoEncodingProcess2", false);

                tempStart = DateTime.Now;
                exitCode = proc.startProcess();
                // // LogBook.addLogLine(""Start time:" + tempStart.ToShortTimeString(), 1);
                // // LogBook.addLogLine(""End Time:" + DateTime.Now.ToShortTimeString(), 1);
                // // LogBook.addLogLine(""Encoding Time:" + (DateTime.Now - tempStart).TotalMinutes.ToString() + " minites.", 1);

                if (proc.getAbandonStatus())
                    return true;

                if (exitCode != 0)
                    return false;
                else
                    return true;
            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error encoding video to Xvid. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }
    }
}

