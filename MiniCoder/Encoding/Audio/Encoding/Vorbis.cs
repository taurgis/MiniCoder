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
    class Vorbis : MiniEncoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public Vorbis()
        {

        }

        public bool encode(Tool besweet, SortedList<String, String[]> fileDetails, int i, Track audio, SortedList<String, String> EncOpts, ProcessWatcher processWatcher)
        {
            try
            {
                SysLanguage language = MiniSystem.getLanguage();
                MiniProcess proc = new AudioProcess(fileDetails["audLength"][0], language.audioEncodingTrack + " (ID = " + (i) + ")", fileDetails["name"][0] + "AudioEncodingProcess");
                
                processWatcher.setProcess(proc);
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);



                LogBook.addLogLine("Encoding to vorbis", fileDetails["name"][0] + "AudioEncoding", fileDetails["name"][0] + "AudioEncodingProcess", false);

                proc.initProcess();





                proc.setFilename(Path.Combine(besweet.getInstallPath(), "BeSweet.exe"));


                if (!besweet.isInstalled())
                    besweet.download();


                audio.encodePath = tempPath + Path.GetFileNameWithoutExtension(audio.demuxPath) + "_output.ogg";
                proc.setArguments("-core( -input \"" + audio.demuxPath + "\" -output \"" + audio.encodePath + "\" ) -azid( -s stereo -c normal -L -3db ) -ota( -hybridgain ) -ogg( -b " + EncOpts["audbr"] + " )");




                if (proc.getAbandonStatus())
                    return false;

                int exitCode = proc.startProcess();




                if (exitCode != 0 && exitCode != -1073741819)
                {
                    return false;
                }
                else
                {
                    LogBook.addLogLine("Encoding audio completed", fileDetails["name"][0] + "AudioEncoding", "", false);

                    return true;
                }
            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error encoding audio to Vorbis. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
