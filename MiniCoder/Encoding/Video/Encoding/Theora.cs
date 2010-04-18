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
    public class Theora : VideoEncoder
    {
        public Boolean encode(Tool theora, SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts, SortedList<String, Track[]> fileTracks)
        {
            try
            {
                LogBookController.Instance.addLogLine("Encoding to Theora", LogMessageCategories.Video);

                MiniProcess proc;

                string pass1Arg = "";

                if (encOpts["sizeopt"] == "1")
                {
                    Calc brCalc = new Calc(fileDetails, encOpts, fileTracks);
                    encOpts["videobr"] = brCalc.getVideoBitrate().ToString();
                }

                if (!theora.isInstalled())
                    theora.download();

                fileTracks["video"][0].encodePath = encOpts["outDIR"] + fileDetails["name"][0] + "_output.ogg";

                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("encodingVideoTheora"));
                
                if (!theora.isInstalled())
                    theora.download();

                string resize = "";
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

                proc = new TheoraProcess(LanguageController.Instance.getLanguageString("encodingVideoTheora"));
                proc.initProcess();
                ProcessManager.Instance.process = proc;
                proc.setFilename(Path.Combine(theora.getInstallPath(), "theora.exe"));
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);
                proc.setArguments(pass1Arg);

                return ProcessManager.hasProcessExitedCorrectly(proc, proc.startProcess());
            }
            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error encoding video to Theora. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
                return false;
            }
        }
    }
}

