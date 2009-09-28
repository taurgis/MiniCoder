using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace x264_GUI_CS.Task_Libraries
{
    class Muxing
    {
        private static Process mainProcess = null;
        Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        General.ProcessSettings proc = new x264_GUI_CS.General.ProcessSettings();
        bool finishedTask = false;
        LogBook log;
        Package mkvtoolnix;
        int exitCode;
        
        public Muxing(LogBook log)
        {
            this.log = log;
        }

        public bool Mux(ApplicationSettings dir, General.FileInformation details, General.EncodingOptions encOpts, General.ProcessSettings proc)
        {
            this.proc = proc;
            mkvtoolnix = (Package)dir.htRequired["mkvtoolnix"];
            if (!mkvtoolnix.isInstalled())
                mkvtoolnix.download();
            mainProcess = new Process();
            log.addLine("Muxing");
            string args;

            try
            {
                float dar = details.muxwidth / details.muxheight;
                float par = details.width / details.height;

                if (dar != par & encOpts.filtResize != 0)
                {
                    details.muxheight = encOpts.resizeHeight;
                    details.muxwidth = (int)(encOpts.resizeHeight * dar);
                }
            }
            catch
            {
                details.muxheight = details.height;
                details.muxwidth = details.width;
            }
                
            
            details.outFile = details.outDIR + details.name + "_output";

            switch (encOpts.containerFormat)
            {
                case 0:
                    mainProcess.StartInfo.FileName = Path.Combine(mkvtoolnix.getInstallPath(), "mkvmerge.exe");
                    details.outFile += ".mkv";

                    string arg1 = "";

                    if (details.vfr && File.Exists(details.vfrCode))
                        arg1 += "--timecodes 0:\"" + details.vfrCode + "\" ";

                    arg1 += "--title \"Encoded with MiniCoder\" ";
                    if (File.Exists(dir.tempDIR + "chapters.xml"))
                        arg1 += "--chapters \"" + dir.tempDIR + "chapters.xml\" ";

                    if (details.fps > 400)
                        args = "-o \"" + details.outFile + "\" --default-duration 0:" + details.fps.ToString().Replace(".0", "").Substring(0, 2) + "." + details.fps.ToString().Replace(".0", "").Substring(2, details.fps.ToString().Replace(".0", "").Length - 2) + "fps --display-dimensions 0:" + details.muxwidth.ToString() + "x" + details.muxheight.ToString() + " " + arg1 + "-d 0 -A -S \"" + details.encodedVideo + "\" ";
                    else
                        args = "-o \"" + details.outFile + "\" --default-duration 0:" + details.fps + "fps --display-dimensions 0:" + details.muxwidth.ToString() + "x" + details.muxheight.ToString() + " " + arg1 + "-d 0 -A -S \"" + details.encodedVideo + "\" ";

                  


                    for (int i = 0; i < details.audioCount; i++)
                    {
                        if (encOpts.audCodec == 0)
                            args += "--aac-is-sbr 1:1 ";
                        args += "--language 1:" + details.lang[details.aud_Languages[i]] + " --track-name 1:\"" + details.audTitles[i] + "\" -a 1 -D -S \"" + details.encodedAudio[i] + "\" ";
                    }
                   


                    for (int i = 0; i < details.subCount; i++)
                    {
                        args += "--language 0:" + details.lang[details.sub_lang[i]] + " --track-name 0:\"" + details.sub_Titles[i] + "\" -s 0 -A -D \"" + details.demuxSub[i] + "\" ";
                    }

                    if (details.attachments != null)
                    {
                        for (int i = 0; i < details.attachments.Count(); i++)
                        {
                            if(File.Exists(dir.tempDIR + details.attachments[i]))
                            args += "--attachment-mime-type application/x-truetype-font --attachment-name \"" + details.attachments[i] + "\" --attach-file \"" + dir.tempDIR + details.attachments[i] + "\" ";
                        }
                    }

                    args += "--track-order 0:0,";

                    for (int i = 0; i < details.audioCount; i++)
                        args += (i + 1).ToString() + ":1,";

                    int step = details.audioCount + 1;

                    for (int i = 0; i < details.subCount; i++)
                        args += (i + step).ToString() + ":0,";

                    

                  

                    log.addLine(args);

                    mainProcess.StartInfo.Arguments = args;
                                            
                    break;
            }

            taskProcess();

            if (proc.abandon)
                return true;

            if (exitCode != 0)
                return false;
            else
                return true;
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
                mainProcess.PriorityClass = ProcessPriorityClass.Idle;

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
                log.setInfoLabel(stdout.ReadLine());
                Thread.Sleep(0);
            }
        }
    }
}
