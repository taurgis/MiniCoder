﻿//    MiniCoder
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
using System.IO;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Managers;
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;

namespace MiniTech.MiniCoder.Encoding.Sound.Decoding
{
    public class Valdec : MiniDecoder
    {
        public Boolean decode(SortedList<String, String[]> fileDetails, int i, Track audio)
        {
            try
            {
                ExtApplication valdec = ToolsManager.Instance.getTool("oggdec");

                MiniProcess proc = new DefaultProcess("Decoding Audio Track (ID = " + (i) + ")", fileDetails["name"][0] + "AudioDecodingProcess");
                ProcessManager.Instance.Process = proc;

                proc.initProcess();
                proc.stdErrDisabled(true);
                proc.stdOutDisabled(true);

                LogBookController.Instance.addLogLine("Decoding AC3 - Using valdec", LogMessageCategories.Video);
                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("audioDecodingMessage"));

                String decodedAudio = LocationManager.TempFolder + fileDetails["name"][0] + "-Decoded Audio Track-" + i.ToString() + ".wav";

                if (!valdec.isInstalled())
                    valdec.download();
                proc.setFilename(Path.Combine(valdec.getInstallPath(), "valdec.exe"));
                proc.setArguments("\"" + audio.demuxPath + "\" -w \"" + decodedAudio + "\" -spk:2");

                int exitCode = proc.startProcess();

                audio.demuxPath = decodedAudio;

                LogBookController.Instance.addLogLine("Decoding Completed", LogMessageCategories.Video);

                return ProcessManager.hasProcessExitedCorrectly(proc, exitCode);
            }
            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error decoding audio with Valdec. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
                return false;
            }
        }
    }
}
