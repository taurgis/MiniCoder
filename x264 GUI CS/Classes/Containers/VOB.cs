using System;
using System.Collections.Generic;
using MiniCoder;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using MiniCoder.General;
namespace x264_GUI_CS.Containers
{
    class VOB : ifContainer
    {
        private static Process mainProcess = null;
        Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        General.ProcessSettings proc = new x264_GUI_CS.General.ProcessSettings();
        bool finishedTask = false;
        LogBook log;
        int exitCode;

        public VOB(LogBook log)
        {
            this.log = log;
        }
        Package DGIndex;
        Package virtualDubMod;
        public bool demux(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {
            this.proc = proc;
            try
            {
                DGIndex = (Package)dir.htRequired["DGIndex"];
                if (!DGIndex.isInstalled())
                    DGIndex.download();
                string tempArg;

                

                log.addLine("Started indexing VOB files");
                log.setInfoLabel("Started indexing VOB files.");
                mainProcess = new Process();

                string path = dir.tempDIR.Substring(0, dir.tempDIR.Length - 1);

                details.demuxAudio = new string[details.audioCount];
                details.demuxSub = new string[details.subCount];
                details.attachments = new string[0];

                mainProcess.StartInfo.FileName = Path.Combine(DGIndex.getInstallPath(), "DGIndex.exe");
                
                switch (details.vid_codec)
                {
                        default:
                        details.demuxVideo = dir.tempDIR + details.name + "." + details.extension[details.vid_codec];
                        details.demuxAudio = new string[details.audioCount];
                        details.aud_Languages = new string[details.audioCount];
                        details.audTitles = new string[details.audioCount];
                        for (int i = 0; i < details.audioCount; i++)
                        {
                            details.demuxAudio[i] = dir.tempDIR + details.name + " " + "T" + (80 + i) + " 3_2ch" + " " + (Convert.ToInt32(details.audBitrate[i]) / 1000) + "Kbps DELAY 0ms." + details.extension[details.aud_codec[i]];
                            details.aud_Languages[i] = "";
                            details.audTitles[i] = "DVD Audio";
                            
                        }
                        //-SD=< -AIF=<C:\Samurai 7\VIDEO_TS\VTS_03_1.VOB< -OF=<C:\Samurai 7\VIDEO_TS\samurai 7< -exit -hide -OM=1 -TN=80
                        tempArg = "-SD=< -AIF=<" + details.fileName +"< -OF=<" + dir.tempDIR + details.name + "< -exit -hide -OM=2 -TN=80";
                        break;
                }
                mainProcess.StartInfo.Arguments = tempArg;
                taskProcess();

                if (exitCode != 0)
                    return false;

                log.addLine(tempArg);
               
                //ChapterXtractor
                log.addLine("Started fetching chapters.");
                log.setInfoLabel("Started fetching chapters.");
                mainProcess = new Process();

              
              
                mainProcess.StartInfo.FileName = Path.Combine(DGIndex.getInstallPath(), "ChapterXtractor.exe");
                tempArg =  "\"" + details.outDIR + details.name.Replace("_1","_0") + ".IFO\" " + "\"" + dir.tempDIR + "chapters.txt\" -p5 -t1";
                mainProcess.StartInfo.Arguments = tempArg;
                taskProcess();

                if (exitCode != 0)
                    return false;

                log.addLine(tempArg);


                //sub extraction
                virtualDubMod = (Package)dir.htRequired["VirtualDubMod"];
                if (!virtualDubMod.isInstalled())
                    virtualDubMod.download();

                log.addLine("Started fetching subs.");
                log.setInfoLabel("Started fetching subs.");

                mainProcess = new Process();
                details.demuxSub = new string[1];
                details.subCount = 1;
                
                details.demuxSub[0] = dir.tempDIR + details.name + ".idx";
                details.sub_lang = new string[1];
                details.sub_Titles = new string[1];
                for (int i = 0; i < details.subCount; i++)
                {
                    details.sub_lang[i] = "";
                    details.sub_Titles[i] = "Dvd Sub";
                }
                
                
                

                StreamWriter streamWriter = new StreamWriter(dir.tempDIR + details.name + ".vobsub");
                streamWriter.WriteLine(details.outDIR + details.name.Replace("_1", "_0") + ".IFO");
                streamWriter.WriteLine(dir.tempDIR + details.name);
                streamWriter.WriteLine("1");
                streamWriter.WriteLine("0");
                streamWriter.WriteLine("ALL");
                streamWriter.WriteLine("CLOSE");
                streamWriter.Close();

                mainProcess.StartInfo.FileName = "C:\\WINDOWS\\system32\\rundll32.exe";
                //    "C:\WINDOWS\system32\rundll32.exe" vobsub.dll,Configure C:\Samurai 7\VIDEO_TS\VTS_03_0.vobsub

                tempArg = "VOBSUB.DLL,Configure " + dir.tempDIR + details.name + ".vobsub";
                log.addLine(tempArg);

                mainProcess.StartInfo.Arguments = tempArg;
                taskProcess();



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
                log.addLine("Can't find codec " + e.Message + ":" + details.vid_codec + details.aud_codec[0]);
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
