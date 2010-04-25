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
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Managers;
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;

namespace MiniTech.MiniCoder.Encoding.VideoEnc
{
    public class DGAVCIndex
    {
        public Boolean index(SortedList<String, String[]> fileDetails, Track video)
        {
            ExtApplication dgavcindex = ToolsManager.Instance.getTool("DGAVCIndex");
            ExtApplication dgavcdecode = ToolsManager.Instance.getTool("DGAVCDecode");

            if (fileDetails["ext"][0].ToLower().Equals(".avi"))
                return true;
            try
            {
                MiniProcess proc = new DefaultProcess(LanguageController.Instance.getLanguageString("indexingAvc"), fileDetails["name"][0] + "DGAVCStepProcess");
                ProcessManager.Instance.Process = proc;

                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);
                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("indexingAvc"));
                LogBookController.Instance.addLogLine("Started Indexing AVC", LogMessageCategories.Video);

                proc.initProcess();

                if (!dgavcindex.isInstalled())
                    dgavcindex.download();
                if (!dgavcdecode.isInstalled())
                    dgavcdecode.download();

                proc.setFilename(Path.Combine(dgavcindex.getInstallPath(), "DGAVCIndex.exe"));
                string dgaFile = LocationManager.TempFolder + fileDetails["name"][0] + ".dga";
                proc.setArguments("-i \"" + video.demuxPath + "\" -o \"" + dgaFile + "\" -a -h -e");

                int exitCode = proc.startProcess();
                video.demuxPath = dgaFile;

                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("indexingAvcCompleted"));
                LogBookController.Instance.addLogLine("Finished Indexing AVC", LogMessageCategories.Video);

                if (!ProcessManager.hasProcessExitedCorrectly(proc, exitCode))
                    return false;

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
