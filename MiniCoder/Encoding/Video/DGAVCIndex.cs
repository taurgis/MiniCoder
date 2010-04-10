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
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using System.IO;
using System.Windows.Forms;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Other.Logging;

namespace MiniTech.MiniCoder.Encoding.VideoEnc
{
    class DGAVCIndex
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public DGAVCIndex()
        {
        }

        public Boolean index(Tool dgavcindex, Tool dgavcdecode, SortedList<String, String[]> fileDetails, Track video, ProcessWatcher processWatcher)
        {

            if (fileDetails["ext"][0].ToLower().Equals(".avi"))
                return true;
            try
            {
                MiniProcess proc = new DefaultProcess(LanguageController.Instance.getLanguageString("indexingAvc"), fileDetails["name"][0] + "DGAVCStepProcess");
                processWatcher.setProcess(proc);
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);
                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("indexingAvc"));
                // LogBook.Instance.addLogLine("Started Indexing AVC", fileDetails["name"][0] + "DGAVCStep", fileDetails["name"][0] + "DGAVCStepProcess", false);
                proc.initProcess();

                if (!dgavcindex.isInstalled())
                    dgavcindex.download();
                if (!dgavcdecode.isInstalled())
                    dgavcdecode.download();

                proc.setFilename(Path.Combine(dgavcindex.getInstallPath(), "DGAVCIndex.exe"));
                string dgaFile = tempPath + fileDetails["name"][0] + ".dga";
                proc.setArguments("-i \"" + video.demuxPath + "\" -o \"" + dgaFile + "\" -a -h -e");

                proc.startProcess();
                video.demuxPath = dgaFile;

                if (proc.getAbandonStatus())
                {
                    LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("indexingAvcAbort"));
                    return false;
                }
                else
                {
                    LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("indexingAvcCompleted"));
                    LogBookController.Instance.addLogLine("Finished Indexing AVC", LogMessageCategories.Video);
                }
                if (File.Exists(dgaFile))
                    return true;
                else
                    return false;
            }
            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error indexing AVC. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
                return false;
            }
        }
    }
}
