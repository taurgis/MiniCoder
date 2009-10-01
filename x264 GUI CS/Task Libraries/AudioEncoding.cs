using System;
using System.Collections.Generic;

using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace x264_GUI_CS.Task_Libraries
{
    class AudioEncoding
    {
        Package besweet;
        private static Process mainProcess = null;
        Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        General.ProcessSettings proc = new x264_GUI_CS.General.ProcessSettings();
        bool finishedTask = false;
        LogBook log;
        string errlog;
        int totaltime;
        int exitCode;

        public AudioEncoding(LogBook log)
        {
            this.log = log;
        }

        public bool encode(ApplicationSettings dir, General.FileInformation details, General.EncodingOptions encOpts, General.ProcessSettings proc)
        {
            this.proc = proc;
            besweet = (Package)dir.htRequired["besweet"];
            totaltime = details.audLength;

            log.addLine("Encoding Audio");
            mainProcess = new Process();
            Avisynth avsAudio = new Avisynth();

            details.encodedAudio = new string[details.audioCount];
            int br = encOpts.audBR;

            mainProcess.StartInfo.FileName = Path.Combine(besweet.getInstallPath(), "BeSweet.exe");

            for (int i = 0; i < details.audioCount; i++)
            {
                if (!besweet.isInstalled())
                    besweet.download();

                switch (encOpts.audCodec)
                {
                    case 0:
                        details.encodedAudio[i] = dir.tempDIR + Path.GetFileNameWithoutExtension(details.demuxAudio[i]) + "_output.mp4";
                        mainProcess.StartInfo.Arguments = "-core( -input \"" + details.decodedAudio[i] + "\" -output \"" + details.encodedAudio[i] + "\" ) -azid( -s stereo -c normal -L -3db ) -bsn( -2ch -abr " + br.ToString() + " -codecquality_high ) -ota( -g max )";
                        break;                        

                    case 1:                       
                        details.encodedAudio[i] = dir.tempDIR + Path.GetFileNameWithoutExtension(details.demuxAudio[i]) + "_output.ogg";
                        mainProcess.StartInfo.Arguments = "-core( -input \"" + details.decodedAudio[i] + "\" -output \"" + details.encodedAudio[i] + "\" ) -azid( -s stereo -c normal -L -3db ) -ota( -hybridgain ) -ogg( -b " + br.ToString() + " )";
                        break;
                }

                taskProcess();

                if (proc.abandon)
                    return true;
            }
            log.addLine("Encoded Audio");
            log.addLine(mainProcess.StartInfo.Arguments);

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
            mainProcess.StartInfo.RedirectStandardOutput = false;
          
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
                            try
                            {
                                mainProcess.Kill();
                            }
                            catch
                            {
                            }
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
                //stdout = mainProcess.StandardOutput;

                stdErrThread = new Thread(new ThreadStart(stderrProcess));
                //stdOutThread = new Thread(new ThreadStart(stdoutProcess));

                stdErrThread.Start();
                //stdOutThread.Start();

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
            int encodedtime = 0;
            while ((errlog = stderr.ReadLine()) != null)
            {
                if (errlog.Contains("transcoding") & CharOccurs(errlog, ':') == 3)
                {
                    string[] split = Regex.Split(errlog, ":");
                    int hr;
                    try
                    {
                        hr = int.Parse(split[0].Substring(split[0].Length - 2, 2));
                    }
                    catch
                    {
                         hr = 0;
                    }
                        int min = int.Parse(split[1]);
                    int sec = int.Parse(split[2].Substring(0, 2));
                    encodedtime = hr * 3600 + min * 60 + sec;
                                      
                }
                //log.addLine(stderr.ReadLine());
                log.setInfoLabel("Encoded " + encodedtime.ToString() + "/" + totaltime + " seconds");
            }
        }

        private void stdoutProcess()
        {
            while (stdout.ReadLine() != null)
            {
                log.addLine(stdout.ReadLine());
                log.setInfoLabel(stdout.ReadLine());
            }
        }

        public static int CharOccurs(string stringToSearch, char charToFind)
        {
            int count = 0;
            char[] chars = stringToSearch.ToCharArray();
            foreach (char c in chars)
            {
                if (c == charToFind)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
