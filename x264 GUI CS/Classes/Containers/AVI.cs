﻿using System;
using System.Collections.Generic;
using MiniCoder.General;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using x264_GUI_CS.General;
using MiniCoder;
namespace x264_GUI_CS.Containers
{
    class clAVI : ifContainer
    {
        private static Process mainProcess = null;
        
        Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        bool finishedTask = false;
        LogBook log = new LogBook();
        int exitCode;
        ProcessSettings proc;

        public clAVI(LogBook log)
        {
            this.log = log;
            proc = new ProcessSettings(log);
        }
        Package vdubmod;
        
        public bool demux(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {
            this.proc = proc;

            try
            {
                vdubmod = (Package)dir.htRequired["VirtualDubMod"];
                if (!vdubmod.isInstalled())
                    vdubmod.download();

                log.setInfoLabel("Demuxing AVI Tracks");
                mainProcess = new Process();

                log.addLine("Writing VirtulDubMod script");
                StreamWriter vcf = File.CreateText(dir.tempDIR + details.name + "_demux.vcf"); ;
                string temp = "VirtualDub.Open(\"" + details.fileName.Replace("\\", "\\\\") + "\",\"\",0);\r\n";
                details.demuxAudio = new string[details.audioCount];

                for (int i = 0; i < details.audioCount; i++)
                {
                    details.demuxAudio[i] = dir.tempDIR + details.name + "-Audio Track-" + i.ToString() + "." + details.extension[details.aud_codec[i]];
                    temp += ("VirtualDub.stream[" + i.ToString() + "].Demux(\"" + details.demuxAudio[i].Replace("\\", "\\\\") + "\");");
                }
                log.addLine("=============== VCF ===============");
                details.demuxSub = new string[details.subCount];
                details.attachments = new string[0];
                log.addLine(temp);
                vcf.WriteLine(temp);
                vcf.Close();
                log.addLine("=============== END ===============");
                log.addLine("Started demuxing AVI file");
                mainProcess.StartInfo.FileName = Path.Combine(vdubmod.getInstallPath(), "VirtualDubMod.exe");
                mainProcess.StartInfo.Arguments = "/s\"" + dir.tempDIR + details.name + "_demux.vcf\" /x";

                taskProcess();

                if (proc.abandon)
                    log.setInfoLabel("Demuxing Aborted");
                else
                    log.setInfoLabel("Demuxing Complete");

                if (File.Exists(dir.tempDIR + details.name + "-Audio Track-0." + details.extension[details.aud_codec[0]]))
                    return true;
                else
                    return false;
            }
            catch (KeyNotFoundException e)
            {
                log.addLine("Can't find codec " + e.Message );
                MessageBox.Show("Can't find codec " + details.aud_codec[0]);
                return false;
            }
            
        }

        private void taskProcess()
        {
            finishedTask = false;

            mainProcess.EnableRaisingEvents = true;

            mainProcess.StartInfo.UseShellExecute = false;
            mainProcess.StartInfo.RedirectStandardError = true;
            mainProcess.StartInfo.RedirectStandardOutput = true;
            mainProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

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
                log.setInfoLabel(stdout.ReadLine());
                Thread.Sleep(0);
            }
        }
        
        public bool mkv2vfr(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {
            return true;
        }

   
    }
}
