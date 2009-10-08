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
    class clMP4 : ifContainer
    {
        private static Process mainProcess = null;
        Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        LogBook log;
        General.ProcessSettings proc;
        bool finishedTask = false;
        
        int exitCode;

        public clMP4(LogBook log)
        {
            this.log = log;
            proc = new x264_GUI_CS.General.ProcessSettings(log);
        }
        Package mp4box;
        public bool demux(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {
            this.proc = proc;
            try
            {
                mp4box = (Package)dir.htRequired["mp4box"];
                if (!mp4box.isInstalled())
                    mp4box.download();

                log.addLine("Started demuxing MP4 tracks");
                log.setInfoLabel("Demuxing Video Track");
                mainProcess = new Process();

                string path = dir.tempDIR.Substring(0, dir.tempDIR.Length - 1);

                details.demuxAudio = new string[details.audioCount];
                details.demuxSub = new string[details.subCount];
                details.attachments = new string[0];

                mainProcess.StartInfo.FileName = Path.Combine(mp4box.getInstallPath(), "MP4Box.exe");
                string tempArg;
                switch (details.vid_codec)
                {
                    case "DIV3":
                    case "XVID":
                    case "DIVX":
                    case "DX50":
                    case "DX60":
                    case "V_MS/VFW/FOURCC":
                    case "20":
                        details.demuxVideo = dir.tempDIR + details.name + "-Video Track.avi";
                        tempArg = "\"" + details.fileName + "\" -avi 1 -out \"" + dir.tempDIR + details.name + "-Video Track\"";
                        break;
                    default:
                        details.demuxVideo = dir.tempDIR + details.name + "-Video Track." + details.extension[details.vid_codec];
                        tempArg = "\"" + details.fileName + "\" -raw 1 -out \"" + dir.tempDIR + details.name + "-Video Track." + details.extension[details.vid_codec] + "\"";
                        break;
                }
                mainProcess.StartInfo.Arguments = tempArg;
                taskProcess();

                if (exitCode != 0)
                    return false;

                log.addLine(tempArg);
                log.setInfoLabel("Demuxing Audio Track");
                details.demuxAudio[0] = dir.tempDIR + details.name + "-Audio Track-" + "1" + "." + details.extension[details.aud_codec[0]];
                tempArg = "\"" + details.fileName + "\" -raw 2 -out \"" + details.demuxAudio[0] + "\"";
                mainProcess.StartInfo.Arguments = tempArg;
                taskProcess();
                              
                log.addLine(tempArg);

                if (proc.abandon)
                    log.setInfoLabel("Demuxing Aborted");
                else
                    log.setInfoLabel("Demuxing Complete");

                if (exitCode != 0)
                    return false;
                else
                    return true;
            }
            catch (KeyNotFoundException e)
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
            //while ((testText.Text = stderr.ReadLine()) != null)
            //{
            //    outputLog += testText.Text + "\r\n";
            //    Thread.Sleep(0);
            //}
        }

        private void stdoutProcess()
        {
            while (stdout.ReadLine() != null)
            {
               // log.addLine(stdout.ReadLine());
                log.setInfoLabel(stdout.ReadLine());
                Thread.Sleep(0);
            }
            //while ((testText.Text = stdout.ReadLine()) != null)
            //{
            //    outputLog += testText.Text + "\r\n";
            //    Thread.Sleep(0);
            //}
        }
        
        public bool mkv2vfr(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {
            return true;
        }

   
    }
}
