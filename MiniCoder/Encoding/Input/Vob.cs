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
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;
using System.IO;
using System.Windows.Forms;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Core.Managers;

namespace MiniTech.MiniCoder.Encoding.Input
{
    public class Vob : InputFile
    {
        private ExtApplication DGIndex = ToolsManager.Instance.getTool("DGIndex");

        public SortedList<String, Track[]> getTracks()
        {
            return new SortedList<string, Track[]>();
        }

        public Boolean demux(SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks)
        {
            if (demuxFile(fileDetails, tracks))
                if (demuxSubs(fileDetails, tracks))
                    if (demuxChapters(fileDetails, tracks))
                        return true;

            return false;
        }

        private Boolean demuxChapters(SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks)
        {
            try
            {
                LogBookController.Instance.addLogLine("Demuxing Chapters - Using ChapterXtractor", LogMessageCategories.Video);
                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingvobChapters"));

                MiniProcess proc = new DefaultProcess("Fetching chapters", fileDetails["name"][0] + "DeMuxingProcess");

                proc.initProcess();
                proc.setFilename(Path.Combine(DGIndex.getInstallPath(), "ChapterXtractor.exe"));

                string tempArg = "\"" + fileDetails["fileName"][0].Replace("_1", "_0").Replace(".VOB", ".IFO") + "\" " + "\"" + LocationManager.TempFolder + "chapters.txt\" -p5 -t1";
                proc.setArguments(tempArg);

                int exitCode = proc.startProcess();

                FileInfo tempChapFile = new FileInfo(LocationManager.TempFolder + "chapters.txt");

                if (tempChapFile.Length == 0)
                    File.Delete(LocationManager.TempFolder + "chapters.txt");

                return ProcessManager.hasProcessExitedCorrectly(proc, exitCode);
            }
            catch (IOException)
            {
                return true;
            }
        }
        private Boolean demuxSubs(SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks)
        {
            LogBookController.Instance.addLogLine("Demuxing subs - Using Vobsub", LogMessageCategories.Video);
            LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingvobSubs"));

            MiniProcess proc = new DefaultProcess("Fetching subs", fileDetails["name"][0] + "DeMuxingProcess");

            proc.initProcess();

            string tempArg = "";

            StreamWriter streamWriter = new StreamWriter(LocationManager.TempFolder + fileDetails["name"][0] + ".vobsub");
            streamWriter.WriteLine(fileDetails["fileName"][0].Replace("_1", "_0").Replace(".VOB", ".IFO"));
            streamWriter.WriteLine(LocationManager.TempFolder + fileDetails["name"][0]);
            streamWriter.WriteLine("1");
            streamWriter.WriteLine("0");
            streamWriter.WriteLine("ALL");
            streamWriter.WriteLine("CLOSE");
            streamWriter.Close();

            proc.setFilename("C:\\WINDOWS\\system32\\rundll32.exe");

            tempArg = "VOBSUB.DLL,Configure " + LocationManager.TempFolder + fileDetails["name"][0] + ".vobsub";

            proc.setArguments(tempArg);
            int exitCode = proc.startProcess();

            LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingCompleteMessage"));

            return ProcessManager.hasProcessExitedCorrectly(proc, exitCode);
        }

        private Boolean demuxFile(SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks)
        {
            MiniProcess proc = new DefaultProcess("Indexing VOB", fileDetails["name"][0] + "DeMuxingProcess");
            ProcessManager.Instance.Process = proc;
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);

            if (!DGIndex.isInstalled())
                DGIndex.download();
            string tempArg;

            LogBookController.Instance.addLogLine("Demuxing VOB - Using DGIndex", LogMessageCategories.Video);
            LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingVob"));

            proc.initProcess();
            proc.setFilename(Path.Combine(DGIndex.getInstallPath(), "DGIndex.exe"));

            tracks["video"][0].demuxPath = LocationManager.TempFolder + fileDetails["name"][0] + "." + Codec.Instance.getExtention(tracks["video"][0].codec);
            tempArg = "-SD=< -AIF=<" + fileDetails["fileName"][0] + "< -OF=<" + LocationManager.TempFolder + fileDetails["name"][0] + "< -exit -hide -OM=2 -TN=80";

            proc.setArguments(tempArg);
            int exitCode = proc.startProcess();

            DirectoryInfo info = new DirectoryInfo(LocationManager.TempFolder);
            int count = 0;

            foreach (FileInfo fInfo in info.GetFiles())
            {
                if (fInfo.Extension == ".ac3")
                    tracks["audio"][count++].demuxPath = fInfo.FullName;
            }

            LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingCompleteMessage"));

            return ProcessManager.hasProcessExitedCorrectly(proc, exitCode);
        }

    }
}
