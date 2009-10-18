using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.Process_Management;
using MiniCoder.External;
using MiniCoder.Encoding.Input.Tracks;
using System.IO;
using System.Windows.Forms;

namespace MiniCoder.Encoding.VideoEnc
{
    class DGAVCIndex
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public DGAVCIndex()
        {
        }

        public Boolean index(Tool dgavcindex, Tool dgavcdecode, SortedList<String, String[]> fileDetails, Track video, ProcessWatcher processWatcher)
        {
            MiniProcess proc = new DefaultProcess("Indexing AVC");
            processWatcher.setProcess(proc);
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            LogBook.setInfoLabel("Indexing AVC");
            LogBook.addLogLine("Started Indexin AVC",1);
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
            LogBook.addLogLine("Finished Indexing AVC",1);
            if (proc.getAbandonStatus())
            {
                LogBook.setInfoLabel("Indexing Aborted");
                return false;
            }
            else
                LogBook.setInfoLabel("Finished Indexing AVC");

            if (File.Exists(dgaFile))
                return true;
            else
                return false;

        }
    }
}
