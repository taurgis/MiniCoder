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
using MiniCoder.Encoding.Process_Management;
using MiniCoder.External;
using System.IO;
using System.Windows.Forms;
using MiniCoder.Core.Languages;

namespace MiniCoder.Encoding.Input
{
    class Ogm : InputFile
    {
        String tempPath = Application.StartupPath + "\\temp\\";
     //   SortedList<String, String[]> fileDetails = new SortedList<string, string[]>();

        public Ogm()
        {
           
        }

        public SortedList<String, Track[]> getTracks()
        {
            return new SortedList<string, Track[]>();
        }

        public void setTempPath(string tempPath)
        {
            this.tempPath = tempPath;
        }

        public Boolean demux(Tool ogmtools, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
            LogBook.Instance.addLogLine("Demuxing OGM - Using OgmTools", fileDetails["name"][0] + "DeMuxing", fileDetails["name"][0] + "DeMuxingProcess", false);
            int languageCode = MiniSystem.getLanguage();

            MiniProcess proc = new DefaultProcess("Demuxing OGM", fileDetails["name"][0] + "DeMuxingProcess");
           processWatcher.setProcess(proc);
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            try
            {
             
                if (!ogmtools.isInstalled())
                    ogmtools.download();

            
                LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("demuxingMessage", languageCode) + " OGM");
                proc.initProcess();


              

                proc.setFilename(Path.Combine(ogmtools.getInstallPath(), "OGMDemuxer.exe"));
                string tempArg = "tracks \"" + fileDetails["fileName"][0] + "\" -p " + tracks["video"][0].id + ":\"" + tempPath + fileDetails["name"][0] + "-Video Track." + Codec.Instance.getExtention(tracks["video"][0].codec) + "\"";
                tracks["video"][0].demuxPath = tempPath + fileDetails["name"][0] + "-Video Track." + Codec.Instance.getExtention(tracks["video"][0].codec);

                for (int i = 0; i < tracks["audio"].Length; i++)
                {
                    tracks["audio"][i].demuxPath = tempPath + fileDetails["name"][0] + "-Audio Track-" + i.ToString() + "." + Codec.Instance.getExtention(tracks["audio"][i].codec);
                    tempArg += " " + tracks["audio"][i].id + ":\"" + tracks["audio"][i].demuxPath + "\"";
                }

                for (int i = 0; i < tracks["subs"].Length; i++)
                {
                    tracks["subs"][i].demuxPath = tempPath + fileDetails["name"][0] + "-Subtitle Track-" + i.ToString() + "." + Codec.Instance.getExtention(tracks["subs"][i].codec);
                    tempArg += " " + tracks["subs"][i].id + ":\"" + tracks["subs"][i].demuxPath + "\"";
                }
                //// LogBook.Instance.addLogLine("tempArg,1);
                proc.setArguments(tempArg);
                //MessageBox.Show(mainProcess.StartInfo.Arguments);

                proc.startProcess();

                if (proc.getAbandonStatus())
                {
                    LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("demuxingAbortedMessage", languageCode));
                    return false;
                }
                else
                    LogBook.Instance.setInfoLabel(LanguageController.getLanguageString("demuxingCompleteMessage", languageCode));


                if (File.Exists(tempPath + fileDetails["name"][0] + "-Video Track." + Codec.Instance.getExtention(tracks["video"][0].codec)))
                    return true;
                else
                    return false;

            }
            catch (KeyNotFoundException e)
            {
                LogBook.Instance.addLogLine("Can't find codec " + e.Message, fileDetails["name"][0] + "DeMuxing","",true);
                MessageBox.Show("Can't find codec");
                return false;
            }
        }
    }
}
