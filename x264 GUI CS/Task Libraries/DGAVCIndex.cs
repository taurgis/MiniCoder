using System;
using System.Collections.Generic;
using MiniCoder;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MiniCoder.General;
namespace x264_GUI_CS.Task_Libraries
{
    class DGAVCIndex
    {
        General.ProcessSettings proc;
       
        bool finishedTask = false;
        LogBook log;
        int exitCode;
        Package dgavcindex;
        Package dgavcdecode;

        public DGAVCIndex(LogBook log)
        {
            this.log = log;
            proc = new General.ProcessSettings(log);
        }

        public bool index(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {
            this.proc = proc;
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            log.setInfoLabel("Indexing AVC");
            log.addLine("Started Indexin AVC");
            proc.initProcess();
            dgavcindex = (Package)dir.htRequired["DGAVCIndex"];
            dgavcdecode=(Package) dir.htRequired["DGAVCDecode"];
            if (!dgavcindex.isInstalled())
                dgavcindex.download();
            if (!dgavcdecode.isInstalled())
                dgavcdecode.download();

            proc.setFilename(Path.Combine(dgavcindex.getInstallPath(), "DGAVCIndex.exe"));
            details.dgaFile=dir.tempDIR+details.name+".dga";
            proc.setArguments("-i \"" + details.demuxVideo + "\" -o \"" + details.dgaFile + "\" -a -h -e");

            proc.startProcess();
            log.addLine("Finished Indexing AVC");
            if (proc.abandon)
                log.setInfoLabel("Indexing Aborted");
            else
                log.setInfoLabel("Finished Indexing AVC");

            if (File.Exists(details.dgaFile))
                return true;
            else
                return false;
        }

       

    }
}
