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
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.Encoding.Process_Management;
using System.IO;
using System.Windows.Forms;
using MiniCoder.Core.Languages;

namespace MiniCoder.Encoding.Sound.Encoding
{
    class FFmpegAc3 : MiniEncoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public FFmpegAc3()
        {

        }

        public bool encode(Tool ffmpeg, SortedList<String, String[]> fileDetails, int i, Track audio, SortedList<String, String> EncOpts, ProcessWatcher processWatcher)
        {
            try
            {
       
                MiniProcess proc = new DefaultProcess(LanguageController.Instance.getLanguageString("audioEncodingTrack") + " (ID = " + (i) + ")", fileDetails["name"][0] + "AudioEncodingProcess");
                
                processWatcher.setProcess(proc);
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);

                LogBook.Instance.addLogLine("Encoding to FFMpeg AC-3", fileDetails["name"][0] + "AudioEncoding", fileDetails["name"][0] + "AudioEncodingProcess", false);

                // // LogBook.Instance.addLogLine(""Encoding Audio",1);
                proc.initProcess();





                proc.setFilename(Path.Combine(ffmpeg.getInstallPath(), "ffmpeg.exe"));


                if (!ffmpeg.isInstalled())
                    ffmpeg.download();


                audio.encodePath = tempPath + Path.GetFileNameWithoutExtension(audio.demuxPath) + "_output.ac3";

                //proc.setArguments("-core( -input \"" + audio.demuxPath + "\" -output \"" + audio.encodePath + "\" ) -azid( -s stereo -c normal -L -3db ) -bsn( -2ch -abr " + EncOpts["audbr"] + " -codecquality_high ) -ota( -g max )");
                //-i - -y -acodec ac3 -ab 64k "C:\Documents and Settings\Thomas\My Documents\Smallville.S05E06.WS.DVDRip.XviD-SAiNTS-001.ac3"
                proc.setArguments("-i \"" + audio.demuxPath + "\" -y -acodec ac3 -ab " + EncOpts["audbr"] + "k \"" + audio.encodePath + "\"");

                if (proc.getAbandonStatus())
                    return true;

                int exitCode = proc.startProcess();




                if (exitCode != 0)
                {
                    return false;
                }
                else
                {
                    LogBook.Instance.addLogLine("Encoding audio completed", fileDetails["name"][0] + "AudioEncoding", "", false);

                    return true;
                }
            }
            catch (Exception error)
            {
                LogBook.Instance.addLogLine("Error encoding audio to FFmpegAc-3. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
