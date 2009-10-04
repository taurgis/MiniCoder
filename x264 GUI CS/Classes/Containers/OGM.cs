using System;
using System.Collections.Generic;
using MiniCoder.General;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using MiniCoder;
namespace x264_GUI_CS.Containers
{
    class clOGM : ifContainer
    {
        private static Process mainProcess = null;
        General.ProcessSettings proc = new x264_GUI_CS.General.ProcessSettings();
        Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        bool finishedTask = false;
        LogBook log;
        int exitCode;

        public clOGM(LogBook log)
        {
            this.log = log;
        }
        Package ogmtools;

        public bool demux(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {
            this.proc = proc;
            
            try
            {
                ogmtools = (Package)dir.htRequired["ogmtools"];
                if (!ogmtools.isInstalled())
                    ogmtools.download();

                log.addLine("Started demuxing OGM tracks");
                log.setInfoLabel("Demuxing OGM Tracks");
                mainProcess = new Process();

                string path = dir.tempDIR.Substring(0, dir.tempDIR.Length - 1);

                mainProcess.StartInfo.FileName = Path.Combine(ogmtools.getInstallPath(), "OGMDemuxer.exe");
                string tempArg = "tracks \"" + details.fileName + "\" -p " + details.vid_id + ":\"" + dir.tempDIR + details.name + "-Video Track." + details.extension[details.vid_codec] + "\"";

                details.demuxAudio = new string[details.audioCount];
                details.demuxSub = new string[details.subCount];
                details.attachments = new string[0];

                for (int i = 0; i < details.audioCount; i++)
                {
                    details.demuxAudio[i] = dir.tempDIR + details.name + "-Audio Track-" + i.ToString() + "." + details.extension[details.aud_codec[i]];
                    tempArg += " " + details.aud_id[i] + ":\"" + details.demuxAudio[i] + "\"";
                }

                for (int i = 0; i < details.subCount; i++)
                {
                    details.demuxSub[i] = dir.tempDIR + details.name + "-Subtitle Track-" + i.ToString() + "." + details.extension[details.sub_codec[i]];
                    tempArg += " " + details.sub_id[i] + ":\"" + details.demuxSub[i] + "\"";
                }
                log.addLine(tempArg);
                mainProcess.StartInfo.Arguments = tempArg;
                //MessageBox.Show(mainProcess.StartInfo.Arguments);

                taskProcess();

                if (proc.abandon)
                    log.setInfoLabel("Demuxing Complete");
                else
                    log.setInfoLabel("Demuxing Aborted");

                if (File.Exists(dir.tempDIR + details.name + "-Video Track." + details.extension[details.vid_codec]))
                    return true;
                else
                    return false;
                                                
            }
            catch(KeyNotFoundException e)
            {
                log.addLine("Can't find codec " + e.Message);
                MessageBox.Show("Can't find codec");
                return false;
            }

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
            while (stderr.ReadLine() != null)
            {
                log.addLine(stderr.ReadLine());
                Thread.Sleep(0);
            }
        
        }

        private void stdoutProcess()
        {
            while (stdout.ReadLine() != null)
            {
                log.addLine(stdout.ReadLine());
               
                Thread.Sleep(0);
            }
       
        }

        public bool mkv2vfr(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {
            return true;
        }
    }
}
