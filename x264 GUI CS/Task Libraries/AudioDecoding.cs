using System;
using System.Collections.Generic;
using MiniCoder.General;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using MiniCoder;
namespace x264_GUI_CS.Task_Libraries
{
    class AudioDecoding
    {
        Package flac;
        Package oggdec;
        Package ffmpeg;
        Package faad;
        Package madplay;
        Package valdec;
        private static Process mainProcess = null;
        Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        General.ProcessSettings proc = new x264_GUI_CS.General.ProcessSettings();
        bool finishedTask = false;
        LogBook log;

        public AudioDecoding(LogBook log)
        {
            this.log = log;
        }

        public bool decode(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {
            this.proc = proc;
            flac = (Package)dir.htRequired["flac"];
            madplay = (Package)dir.htRequired["madplay"];
            faad = (Package)dir.htRequired["faad"];
            oggdec = (Package)dir.htRequired["oggdec"];
            valdec = (Package)dir.htRequired["valdec"];
            ffmpeg = (Package)dir.htRequired["ffmpeg"];
            mainProcess = new Process();
            log.addLine("Decoding Audio");
            log.setInfoLabel("Decoding Audio");

            details.decodedAudio=new string[details.audioCount];

            for (int i = 0; i < details.demuxAudio.Length; i++)
            {
                details.decodedAudio[i] = dir.tempDIR + details.name + "-Decoded Audio Track-" + i.ToString() + ".wav";
                string ext = details.extension[details.aud_codec[i]];

                switch (ext)
                {
                    case "wma":
                        if (!ffmpeg.isInstalled())
                            ffmpeg.download();
                        mainProcess.StartInfo.FileName = Path.Combine(ffmpeg.getInstallPath(), "ffmpeg.exe");
                        mainProcess.StartInfo.Arguments = "-i \"" + details.fileName + "\" -f wav -y \"" + details.decodedAudio[i] + "\"";
                      
                        break;
                    case "flac":
                        if (!flac.isInstalled())
                            flac.download();
                        mainProcess.StartInfo.FileName = Path.Combine(flac.getInstallPath(), "flac.exe");
                        mainProcess.StartInfo.Arguments = "-d -o \"" + details.decodedAudio[i] + "\" \"" + details.demuxAudio[i] + "\"";
                        break;

                    case "ac3":
                    case "dts":
                        if (!valdec.isInstalled())
                            valdec.download();
                        mainProcess.StartInfo.FileName = Path.Combine(valdec.getInstallPath(), "valdec.exe");
                        mainProcess.StartInfo.Arguments = "\"" + details.demuxAudio[i] + "\" -w \"" + details.decodedAudio[i] + "\" -spk:2";
                        break;

                    case "ogg":
                        if (!oggdec.isInstalled())
                            oggdec.download();
                        mainProcess.StartInfo.FileName = Path.Combine(oggdec.getInstallPath(), "oggdec.exe");
                        mainProcess.StartInfo.Arguments = "-m -w \"" + details.decodedAudio[i] + "\" \"" + details.demuxAudio[i] + "\"";
                        break;

                    case "aac":
                    case "mp4":
                        if (!faad.isInstalled())
                            faad.download();
                        mainProcess.StartInfo.FileName = Path.Combine(faad.getInstallPath(), "faad.exe");
                        mainProcess.StartInfo.Arguments = "-d -o \"" + details.decodedAudio[i] + "\" \"" + details.demuxAudio[i] + "\"";
                        break;

                    case "mp2":
                    case "mp3":
                        if (!madplay.isInstalled())
                            madplay.download();
                        mainProcess.StartInfo.FileName = Path.Combine(madplay.getInstallPath(), "madplay.exe");
                        mainProcess.StartInfo.Arguments = "-S -o wave:\"" + details.decodedAudio[i] + "\" \"" + details.demuxAudio[i] + "\"";
                        break;

                    default:
                        if (!ffmpeg.isInstalled())
                            ffmpeg.download();
                        mainProcess.StartInfo.FileName = Path.Combine(ffmpeg.getInstallPath(), "ffmpeg.exe");
                        mainProcess.StartInfo.Arguments = "-i \"" + details.fileName + "\" -f wav -y \"" + details.decodedAudio[i] + "\"";
                        
                        break;
                }

                if (mainProcess.StartInfo.Arguments!=null)
                    taskProcess();
                
            }

            log.addLine("Decoded Audio");
            log.setInfoLabel("Decoded Audio");

            string[] files = Directory.GetFiles(dir.tempDIR);
            bool error = true;
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".wav")
                {
                    error = false;
                    break;
                }
            }
            if (error)
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
                        try
                        {
                            if (!mainProcess.HasExited)
                            {
                                mainProcess.Kill();
                            }
                            mainProcess.Close();
                            backGround.Abort();
                        }
                        catch
                        {
                        }
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
                //log.addLine(stderr.ReadLine());
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
