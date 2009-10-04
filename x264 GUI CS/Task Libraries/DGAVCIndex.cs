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
        General.ProcessSettings proc = new x264_GUI_CS.General.ProcessSettings();
        private static String outputLog = "";
        private static string logs = "";
        private static Process mainProcess = null;
        Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        bool finishedTask = false;
        LogBook log;
        int exitCode;
        Package dgavcindex;
        Package dgavcdecode;

        public DGAVCIndex(LogBook log)
        {
            this.log = log;
        }

        public bool index(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {
            log.setInfoLabel("Indexing AVC");
            log.addLine("Started Indexin AVC");
            mainProcess = new Process();
            dgavcindex = (Package)dir.htRequired["DGAVCIndex"];
            dgavcdecode=(Package) dir.htRequired["DGAVCDecode"];
            if (!dgavcindex.isInstalled())
                dgavcindex.download();
            if (!dgavcdecode.isInstalled())
                dgavcdecode.download();

            mainProcess.StartInfo.FileName = Path.Combine(dgavcindex.getInstallPath(), "DGAVCIndex.exe");
            details.dgaFile=dir.tempDIR+details.name+".dga";
            mainProcess.StartInfo.Arguments = "-i \"" + details.demuxVideo + "\" -o \"" + details.dgaFile + "\" -a -h -e";
                                 
            taskProcess();
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

        private void taskProcess()
        {
            finishedTask = false;

            mainProcess.EnableRaisingEvents = true;

            mainProcess.StartInfo.UseShellExecute = false;
            mainProcess.StartInfo.CreateNoWindow = true;
            mainProcess.StartInfo.RedirectStandardError = true;
            mainProcess.StartInfo.RedirectStandardOutput = true;

            backGround = new Thread(new ThreadStart(runprocess));
            backGround.Start();

            while (backGround.IsAlive)
            {
                Thread.Sleep(500);
                try
                {
                    mainProcess.PriorityClass = proc.getPriority();
                }
                catch
                {

                }
                if (proc.abandon)
                {
                    if (backGround.IsAlive)
                    {
                        if (!mainProcess.HasExited)
                        {
                            mainProcess.Kill();
                        }
                        mainProcess.Close();
                        backGround.Abort();
                    }
                }

                if (!finishedTask)
                    continue;

                if (backGround.IsAlive)
                {
                    if (!mainProcess.HasExited)
                    {
                        mainProcess.Kill();
                    }
                    mainProcess.Close();
                    backGround.Abort();
                }

            }

        }

        private void runprocess()
        {
            Thread stdErrThread = null;
            Thread stdOutThread = null;

            try
            {
                mainProcess.Start();
                mainProcess.PriorityClass = proc.getPriority();

                stderr = mainProcess.StandardError;
                stdout = mainProcess.StandardOutput;

                stdErrThread = new Thread(new ThreadStart(stderrProcess));
                stdOutThread = new Thread(new ThreadStart(stdoutProcess));

                stdErrThread.Start();
                stdOutThread.Start();

                mainProcess.WaitForExit();
                exitCode = mainProcess.ExitCode;

                Thread.Sleep(2000);
            }
            finally
            {
                if (null != stdOutThread)
                {

                    stdOutThread.Interrupt();
                    stdOutThread.Abort();
                }
                if (null != stdErrThread)
                {
                    stdErrThread.Interrupt();
                    stdErrThread.Abort();
                }
            }
        }

        private void stderrProcess()
        {
            while ((logs = stderr.ReadLine()) != null)
            {
                outputLog += logs + "\r\n";
                Thread.Sleep(0);
            }
        }

        private void stdoutProcess()
        {
            while ((logs = stdout.ReadLine()) != null)
            {
                outputLog += logs + "\r\n";
                Thread.Sleep(0);
            }
        }

    }
}
