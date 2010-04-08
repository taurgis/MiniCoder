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
using MiniCoder.External;
using MiniCoder.Encoding.Process_Management;
using System.IO;
using MiniCoder.Encoding.Input.Tracks;
using System.Windows.Forms;
using MiniCoder.Core.Languages;
namespace MiniCoder.Encoding.Sound.Decoding
{
    class Ffmpeg : MiniDecoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";

        public Ffmpeg()
        {
            
        }

        public Boolean decode(Tool ffmpeg, SortedList<String, String[]> fileDetails, int i, Track audio, ProcessWatcher processWatcher)
        {
            try
            {
                int languageCode = MiniSystem.getLanguage();
               
                MiniProcess proc = new DefaultProcess("Decoding Audio Track (ID = " + (i) + ")", fileDetails["name"][0] + "AudioDecodingProcess");
                processWatcher.setProcess(proc);
                proc.initProcess();
                proc.stdErrDisabled(true);
                proc.stdOutDisabled(true);
                // // LogBook.Instance.addLogLine(""Decoding Audio",1);
                LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("audioDecodingMessage", languageCode));
                LogBook.Instance.addLogLine("Decoding Unknown - Using FFMpeg", fileDetails["name"][0] + "AudioDecoding", fileDetails["name"][0] + "AudioDecodingProcess", false);

                String decodedAudio = tempPath + fileDetails["name"][0] + "-Decoded Audio Track-" + i.ToString() + ".wav";

                if (!ffmpeg.isInstalled())
                    ffmpeg.download();
                proc.setFilename(Path.Combine(ffmpeg.getInstallPath(), "ffmpeg.exe"));
                proc.setArguments("-i \"" + fileDetails["fileName"][0] + "\" -f wav -y \"" + decodedAudio + "\"");

                int exitCode = proc.startProcess();
                if (proc.getAbandonStatus())
                    return false;

                if (exitCode != 0)
                    return false;
                audio.demuxPath = decodedAudio;
                LogBook.Instance.addLogLine("Decoding Complete", fileDetails["name"][0] + "AudioDecoding", "", false);

                return true;
            }
            catch (Exception error)
            {
                LogBook.Instance.addLogLine("Error decoding audio with FFmpeg. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
