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
    class Flac : MiniDecoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";

        public Flac()
        {
            
        }

        public Boolean decode(Tool flac, SortedList<String, String[]> fileDetails, int i, Track audio, ProcessWatcher processWatcher)
        {
            try
            {
                int language = MiniSystem.getLanguage();
               
                MiniProcess proc = new DefaultProcess("Decoding Audio Track (ID = " + (i) + ")", fileDetails["name"][0] + "AudioDecodingProcess");
                processWatcher.setProcess(proc);
                proc.initProcess();
                proc.stdErrDisabled(true);
                proc.stdOutDisabled(true);
                LogBook.Instance.addLogLine("Decoding Flac - Using flac", fileDetails["name"][0] + "AudioDecoding", fileDetails["name"][0] + "AudioDecodingProcess", false);

                LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("audioDecodingMessage", language));

                String decodedAudio = tempPath + fileDetails["name"][0] + "-Decoded Audio Track-" + i.ToString() + ".wav";

                if (!flac.isInstalled())
                    flac.download();
                proc.setFilename(Path.Combine(flac.getInstallPath(), "flac.exe"));
                proc.setArguments("-d -o \"" + decodedAudio + "\" \"" + audio.demuxPath + "\"");

                int exitCode = proc.startProcess();
                if (proc.getAbandonStatus())
                    return false;

                if (exitCode != 0)
                    return false;
                audio.demuxPath = decodedAudio;
                LogBook.Instance.addLogLine("Decoding completed", fileDetails["name"][0] + "AudioDecoding", "", false);

                return true;
            }
            catch (Exception error)
            {
                LogBook.Instance.addLogLine("Error decoding audio with Flac. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
