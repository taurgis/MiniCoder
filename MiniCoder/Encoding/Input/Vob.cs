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
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;
using System.IO;
using System.Windows.Forms;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Other.Logging;

namespace MiniTech.MiniCoder.Encoding.Input
{
    class Vob : InputFile
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        //   SortedList<String, String[]> fileDetails = new SortedList<string, string[]>();

        public Vob()
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

        public Boolean demux(Tool DGIndex, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
            if (demuxFile(DGIndex, fileDetails, tracks, processWatcher))
                if (demuxSubs(DGIndex, fileDetails, tracks, processWatcher))
                    if (demuxChapters(DGIndex, fileDetails, tracks, processWatcher))
                        return true;

            return false;

        }

        private Boolean demuxChapters(Tool DGIndex, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
            try
            {
               // LogBook.Instance.addLogLine("Demuxing Chapters - Using ChapterXtractor", fileDetails["name"][0] + "DeMuxing", fileDetails["name"][0] + "DeMuxingProcess", false);

                MiniProcess proc = new DefaultProcess("Fetching chapters", fileDetails["name"][0] + "DeMuxingProcess");

               LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingvobChapters"));
                proc.initProcess();


                proc.setFilename(Path.Combine(DGIndex.getInstallPath(), "ChapterXtractor.exe"));
                string tempArg = "\"" + fileDetails["fileName"][0].Replace("_1", "_0").Replace(".VOB", ".IFO") + "\" " + "\"" + tempPath + "chapters.txt\" -p5 -t1";
                proc.setArguments(tempArg);
                int exitCode = proc.startProcess();

                FileInfo tempChapFile = new FileInfo(tempPath + "chapters.txt");
                if (tempChapFile.Length == 0)
                    File.Delete(tempPath + "chapters.txt");

                if (exitCode != 0)
                {
                   // LogBook.Instance.addLogLine("Error demuxing chapters, none present?", fileDetails["name"][0] + "DeMuxing", "", false);
                }
                return true;
            }
            catch (IOException)
            {
                return true;
            }
        }
        private Boolean demuxSubs(Tool DGIndex, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
           // LogBook.Instance.addLogLine("Demuxing subs - Using Vobsub", fileDetails["name"][0] + "DeMuxing", "", false);
            MiniProcess proc = new DefaultProcess("Fetching subs", fileDetails["name"][0] + "DeMuxingProcess");

           LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingvobSubs"));

            proc.initProcess();


            string tempArg = "";

            StreamWriter streamWriter = new StreamWriter(tempPath + fileDetails["name"][0] + ".vobsub");
            streamWriter.WriteLine(fileDetails["fileName"][0].Replace("_1", "_0").Replace(".VOB", ".IFO"));
            streamWriter.WriteLine(tempPath + fileDetails["name"][0]);
            streamWriter.WriteLine("1");
            streamWriter.WriteLine("0");
            streamWriter.WriteLine("ALL");
            streamWriter.WriteLine("CLOSE");
            streamWriter.Close();

            proc.setFilename("C:\\WINDOWS\\system32\\rundll32.exe");

            tempArg = "VOBSUB.DLL,Configure " + tempPath + fileDetails["name"][0] + ".vobsub";


            proc.setArguments(tempArg);
            int exitCode = proc.startProcess();



            if (proc.getAbandonStatus())
            {
               LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingAbortedMessage"));
                return false;
            }
            else
               LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingCompleteMessage"));

            if (exitCode != 0)
                return false;
            else
                return true;


        }

        private Boolean demuxFile(Tool DGIndex, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
            MiniProcess proc = new DefaultProcess("Indexing VOB", fileDetails["name"][0] + "DeMuxingProcess");
            processWatcher.setProcess(proc);
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);


            if (!DGIndex.isInstalled())
                DGIndex.download();
            string tempArg;

           // LogBook.Instance.addLogLine("Demuxing VOB - Using DGIndex", fileDetails["name"][0] + "DeMuxing", "", false);
           LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingVob"));
            proc.initProcess();

            proc.setFilename(Path.Combine(DGIndex.getInstallPath(), "DGIndex.exe"));

            tracks["video"][0].demuxPath = tempPath + fileDetails["name"][0] + "." + Codec.Instance.getExtention(tracks["video"][0].codec);
            tempArg = "-SD=< -AIF=<" + fileDetails["fileName"][0] + "< -OF=<" + tempPath + fileDetails["name"][0] + "< -exit -hide -OM=2 -TN=80";

            proc.setArguments(tempArg);
            int exitCode = proc.startProcess();

            DirectoryInfo info = new DirectoryInfo(tempPath);
            int count = 0;
            foreach (FileInfo fInfo in info.GetFiles())
            {
                if (fInfo.Extension == ".ac3")
                    tracks["audio"][count++].demuxPath = fInfo.FullName;
            }

            if (proc.getAbandonStatus())
            {
               LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingAbortedMessage"));
                return false;
            }
            else
               LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingCompleteMessage"));


            if (exitCode != 0)
                return false;

            return true;
        }

    }
}
