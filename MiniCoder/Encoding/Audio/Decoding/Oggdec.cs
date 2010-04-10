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
using System.Text;
using MiniTech.MiniCoder.External;
using MiniTech.MiniCoder.Encoding.Process_Management;
using System.IO;
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using System.Windows.Forms;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Other.Logging;
namespace MiniTech.MiniCoder.Encoding.Sound.Decoding
{
    class Oggdec : MiniDecoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";

        public Oggdec()
        {
            
        }

        public Boolean decode(Tool oggdec, SortedList<String, String[]> fileDetails, int i, Track audio, ProcessWatcher processWatcher)
        {
            try
            {
                MiniProcess proc = new DefaultProcess("Decoding Audio Track (ID = " + (i) + ")", fileDetails["name"][0] + "AudioDecodingProcess");
                processWatcher.setProcess(proc);
                proc.initProcess();
                proc.stdErrDisabled(true);
                proc.stdOutDisabled(true);
               // LogBook.Instance.addLogLine("Decoding OGG - Using oggdec", fileDetails["name"][0] + "AudioDecoding", fileDetails["name"][0] + "AudioDecodingProcess", false);

               LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("audioDecodingMessage"));

                String decodedAudio = tempPath + fileDetails["name"][0] + "-Decoded Audio Track-" + i.ToString() + ".wav";

                if (!oggdec.isInstalled())
                    oggdec.download();
                proc.setFilename(Path.Combine(oggdec.getInstallPath(), "oggdec.exe"));
                proc.setArguments("-m -w \"" + decodedAudio + "\" \"" + audio.demuxPath + "\"");

                int exitCode = proc.startProcess();
                if (proc.getAbandonStatus())
                    return false;

                if (exitCode != 0)
                    return false;
                audio.demuxPath = decodedAudio;
               // LogBook.Instance.addLogLine("Decoding completed", fileDetails["name"][0] + "AudioDecoding", "", false);

                return true;
            }
            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error decoding audio with OggDec. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
                return false;
            }

        }
    }
}
