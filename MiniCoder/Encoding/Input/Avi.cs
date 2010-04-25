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
using System.Windows.Forms;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Managers;
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;

namespace MiniTech.MiniCoder.Encoding.Input
{
    public class Avi : InputFile
    {
        public SortedList<String, Track[]> getTracks()
        {
            return new SortedList<string, Track[]>();
        }

        public Boolean demux(SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks)
        {
            ExtApplication vdubmod = ToolsManager.Instance.getTool("vdubmod");

            LogBookController.Instance.addLogLine("Demuxing AVI - Using Vdubmod", LogMessageCategories.Video);

            MiniProcess proc = new DefaultProcess("Demuxing Avi", fileDetails["name"][0] + "DeMuxingProcess");
            ProcessManager.Instance.Process = proc;

            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);

            try
            {
                if (!vdubmod.isInstalled())
                    vdubmod.download();

                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingMessage") + " AVI Tracks");

                proc.initProcess();

                LogBookController.Instance.addLogLine("Writing VirtualDub Script", LogMessageCategories.Video);

                StreamWriter vcf = File.CreateText(LocationManager.TempFolder + fileDetails["name"][0] + "_demux.vcf"); ;
                string temp = "VirtualDub.Open(\"" + fileDetails["fileName"][0].Replace("\\", "\\\\") + "\",\"\",0);\r\n";

                tracks["video"][0].demuxPath = fileDetails["fileName"][0];

                for (int i = 0; i < tracks["audio"].Length; i++)
                {
                    tracks["audio"][i].demuxPath = LocationManager.TempFolder + fileDetails["name"][0] + "-Audio Track-" + i.ToString() + "." + Codec.Instance.getExtention(tracks["audio"][i].codec);
                    temp += ("VirtualDub.stream[" + i.ToString() + "].Demux(\"" + tracks["audio"][i].demuxPath.Replace("\\", "\\\\") + "\");");
                }

                LogBookController.Instance.addLogLine(temp, LogMessageCategories.Video);

                vcf.WriteLine(temp);
                vcf.Close();

                proc.setFilename(Path.Combine(vdubmod.getInstallPath(), "VirtualDubMod.exe"));
                proc.setArguments("/s\"" + LocationManager.TempFolder + fileDetails["name"][0] + "_demux.vcf\" /x");

                proc.startProcess();

                if (proc.getAbandonStatus())
                {
                    LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingAbortedMessage"));
                    return false;
                }
                else
                    LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingCompleteMessage"));
                try
                {
                    if (File.Exists(LocationManager.TempFolder + fileDetails["name"][0] + "-Audio Track-0." + Codec.Instance.getExtention(tracks["audio"][0].codec)))
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
                LogBookController.Instance.addLogLine("Can't find codec: \r\n" + e.Message + "\r\n" + ErrorManager.fetchTrackData(tracks), LogMessageCategories.Error);
             
                return false;
            }

        }
    }
}
