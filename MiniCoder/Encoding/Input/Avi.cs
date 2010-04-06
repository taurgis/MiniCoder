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
    class Avi : InputFile
    {
        String tempPath = Application.StartupPath + "\\temp\\";
     //   SortedList<String, String[]> fileDetails = new SortedList<string, string[]>();

        public Avi()
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

        public Boolean demux(Tool vdubmod, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {

            LogBook.addLogLine("Demuxing AVI - Using Vdubmod", fileDetails["name"][0] + "DeMuxing", fileDetails["name"][0] + "DeMuxingProcess", false);
            MiniProcess proc = new DefaultProcess("Demuxing Avi", fileDetails["name"][0] + "DeMuxingProcess");
            SysLanguage language = MiniSystem.getLanguage();
            processWatcher.setProcess(proc);

            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            try
            {

                if (!vdubmod.isInstalled())
                    vdubmod.download();

                LogBook.setInfoLabel(language.demuxingMessage + " AVI Tracks");

                proc.initProcess();

                LogBook.addLogLine("Writing VirtualDub Script", fileDetails["name"][0] + "DeMuxing", fileDetails["name"][0] + "VdubScript", false);

                StreamWriter vcf = File.CreateText(tempPath + fileDetails["name"][0] + "_demux.vcf"); ;
                string temp = "VirtualDub.Open(\"" + fileDetails["fileName"][0].Replace("\\", "\\\\") + "\",\"\",0);\r\n";


                tracks["video"][0].demuxPath = fileDetails["fileName"][0];

                for (int i = 0; i < tracks["audio"].Length; i++)
                {
                    tracks["audio"][i].demuxPath = tempPath + fileDetails["name"][0] + "-Audio Track-" + i.ToString() + "." + Codec.getExtention(tracks["audio"][i].codec);
                    temp += ("VirtualDub.stream[" + i.ToString() + "].Demux(\"" + tracks["audio"][i].demuxPath.Replace("\\", "\\\\") + "\");");
                }

                LogBook.addLogLine(temp, fileDetails["name"][0] + "VdubScript", "", false);
                vcf.WriteLine(temp);
                vcf.Close();

                proc.setFilename(Path.Combine(vdubmod.getInstallPath(), "VirtualDubMod.exe"));
                proc.setArguments("/s\"" + tempPath + fileDetails["name"][0] + "_demux.vcf\" /x");

                proc.startProcess();


                if (proc.getAbandonStatus())
                {
                    LogBook.setInfoLabel(language.demuxingAbortedMessage);
                    return false;
                }
                else
                    LogBook.setInfoLabel(language.demuxingCompleteMessage);
                try
                {
                    if (File.Exists(tempPath + fileDetails["name"][0] + "-Audio Track-0." + Codec.getExtention(tracks["audio"][0].codec)))
                        return true;
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
            catch (KeyNotFoundException e)
            {
                LogBook.addLogLine("Can't find codec " + e.Message, fileDetails["name"][0] + "DeMuxing - " + tracks["audio"][0].codec + tracks["video"][0].codec, "", true);
              
                MessageBox.Show("Can't find codec " + fileDetails["aud_codec"][0], "");
                return false;
            }
            
        }
    }
}
