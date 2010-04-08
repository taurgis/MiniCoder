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
using System.Diagnostics;
using MiniCoder.Core.Languages;

namespace MiniCoder.Encoding.Sound.Encoding
{
    class NeroAac : MiniEncoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public NeroAac()
        {

        }

        public bool encode(Tool besweet, SortedList<String, String[]> fileDetails, int i, Track audio, SortedList<String, String> EncOpts, ProcessWatcher processWatcher)
        {
            try
            {
                int languageCode = MiniSystem.getLanguage();
                MiniProcess proc = new AudioProcess(fileDetails["audLength"][0], LanguageController.getLanguageString("audioEncodingTrack", languageCode) + " (ID = " + (i) + ")", fileDetails["name"][0] + "AudioEncodingProcess");
               
                processWatcher.setProcess(proc);
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);



                LogBook.Instance.addLogLine("Encoding to Nero AAC", fileDetails["name"][0] + "AudioEncoding", fileDetails["name"][0] + "AudioEncodingProcess", false);

                proc.initProcess();


                if (!File.Exists(besweet.getInstallPath() + "neroAacEnc.exe"))
                {
                    MessageBox.Show("Due to licensing we are not allowed to put Nero AAC in the package automaticly.\r\nPlease download Nero Aac and put it in the folder about to open.('NeroAacEnc.exe' directly in Besweet folder.)");
                    Process.Start("http://www.nero.com/eng/downloads-nerodigital-nero-aac-codec.php");
                    Process.Start(besweet.getInstallPath());
                }




                proc.setFilename(Path.Combine(besweet.getInstallPath(), "BeSweet.exe"));


                if (!besweet.isInstalled())
                    besweet.download();


                audio.encodePath = tempPath + Path.GetFileNameWithoutExtension(audio.demuxPath) + "_output.mp4";
                proc.setArguments("-core( -input \"" + audio.demuxPath + "\" -output \"" + audio.encodePath + "\" ) -azid( -s stereo -c normal -L -3db ) -bsn( -2ch -abr " + EncOpts["audbr"] + " -codecquality_high ) -ota( -g max )");


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
                LogBook.Instance.addLogLine("Error encoding audio to Nero AAC. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
