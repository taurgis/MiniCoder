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
using System.IO;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Managers;
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;

namespace MiniTech.MiniCoder.Encoding.Sound.Encoding
{
    public class FFmpegAc3 : MiniEncoder
    {
        public bool encode(SortedList<String, String[]> fileDetails, int i, Track audio, SortedList<String, String> EncOpts)
        {
            try
            {
                ExtApplication ffmpeg = ToolsManager.Instance.getTool("ffmpeg");
                MiniProcess proc = new DefaultProcess(LanguageController.Instance.getLanguageString("audioEncodingTrack") + " (ID = " + (i) + ")", fileDetails["name"][0] + "AudioEncodingProcess");
                ProcessManager.Instance.Process = proc;

                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);

                LogBookController.Instance.addLogLine("Encoding to FFMpeg AC-3", LogMessageCategories.Video);

                proc.initProcess();

                proc.setFilename(Path.Combine(ffmpeg.getInstallPath(), "ffmpeg.exe"));

                if (!ffmpeg.isInstalled())
                    ffmpeg.download();

                audio.encodePath = LocationManager.TempFolder + Path.GetFileNameWithoutExtension(audio.demuxPath) + "_output.ac3";

                proc.setArguments("-i \"" + audio.demuxPath + "\" -y -acodec ac3 -ab " + EncOpts["audbr"] + "k \"" + audio.encodePath + "\"");

                int exitCode = proc.startProcess();

                LogBookController.Instance.addLogLine("Encoding audio completed", LogMessageCategories.Video);

                return ProcessManager.hasProcessExitedCorrectly(proc, exitCode);
            }
            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error encoding audio to FFmpegAc-3. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
                return false;
            }
        }
    }
}