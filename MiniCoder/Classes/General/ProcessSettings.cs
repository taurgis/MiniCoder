using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
namespace MiniCoder
{
    public class ProcessSettings
    {
        private static Process mainProcess = null;
        Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        public bool abandon = false;
        public bool errflag = true;
        public int processPriority = 0;
        public string currProcess = "";
        bool finishedTask = false;
        private bool disablestderr = false;
        private bool disablestdout = false;
        LogBook log;
        int totalTime;
        int totalFrames;
        int pass;
        int exitCode;

        public ProcessSettings(LogBook log)
        {
            this.log = log;
        }

        public void setFilename(string filename)
        {
            mainProcess.StartInfo.FileName = filename;
        }

        public void setArguments(string arguments)
        {
            mainProcess.StartInfo.Arguments = arguments;
        }

        public int startProcess()
        {
            if (mainProcess.StartInfo.Arguments != null)
            {
                log.addLine(mainProcess.StartInfo.Arguments);
                taskProcess();
                return exitCode;
            }
            return exitCode;
        }

        public void initProcess()
        {
            mainProcess = new Process();
        }

        public ProcessPriorityClass getPriority()
        {
            switch (processPriority)
            {
                case 0:
                    return ProcessPriorityClass.Idle;
                case 1:
                    return ProcessPriorityClass.BelowNormal;
                case 2:
                    return ProcessPriorityClass.Normal;
                case 3:
                    return ProcessPriorityClass.AboveNormal;
                case 4:
                    return ProcessPriorityClass.High;
                case 5:
                    return ProcessPriorityClass.RealTime;
                default:
                    return ProcessPriorityClass.Idle;


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
                    mainProcess.PriorityClass = getPriority();
                }
                catch
                {
                }
                if (abandon)
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

                //if (backGround.IsAlive)
                //{
                //    if (!mainProcess.HasExited)
                //    {
                //        mainProcess.Kill();
                //    }
                //    mainProcess.Close();
                //    backGround.Abort();
                //}

            }

        }

        private void runprocess()
        {
            Thread stdErrThread = null;
            Thread stdOutThread = null;

            try
            {
                mainProcess.Start();
                try
                {
                    mainProcess.PriorityClass = getPriority();
                }
                catch
                {

                }


                stderr = mainProcess.StandardError;
                stdout = mainProcess.StandardOutput;

                stdErrThread = new Thread(new ThreadStart(stderrProcess));
                stdOutThread = new Thread(new ThreadStart(stdoutProcess));

                stdErrThread.Start();
                stdOutThread.Start();

                if (mainProcess.StartInfo.FileName.Contains("avs2yuv.exe"))
                {
                    Thread.Sleep(2000);
                    if (!mainProcess.HasExited)
                        mainProcess.Kill();
                }
                else
                {
                    mainProcess.WaitForExit();
                    exitCode = mainProcess.ExitCode;
                }
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

        public void stdErrDisabled(Boolean err)
        {
            disablestderr = err;
        }

        public void stdOutDisabled(Boolean stdout)
        {
            disablestdout = stdout;
        }


        public void setTotalTime(int totalTime)
        {
            this.totalTime = totalTime;
        }

        private void stderrProcess()
        {
            if (mainProcess.StartInfo.FileName.Contains("BeSweet.exe"))
            {
                int encodedtime = 0;
                string errlog;
                while (( errlog = stderr.ReadLine()) != null)
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
                        log.setInfoLabel("Encoded " + encodedtime.ToString() + "/" + totalTime + " seconds");
                    }
                }
            }
            else if (mainProcess.StartInfo.FileName.Contains("x264.exe"))
            {
                string percent;
                string errlog;
                while ((errlog = stderr.ReadLine()) != null)
                {
                 
                        if (errlog.Contains("eta"))
                        {
                            percent = errlog.Substring(errlog.IndexOf('[') + 1, errlog.IndexOf(']') - errlog.IndexOf('[') - 1);
                            log.setInfoLabel("Encoding Video - Pass " + pass.ToString() + ": " + percent);
                        }
                        else
                        {
                            log.addLine(errlog);
                        }

                    

                    Thread.Sleep(0);
                }
            }
            else
            {
                while (stderr.ReadLine() != null)
                {
                    if (!disablestderr)
                    {
                        log.addLine(stderr.ReadLine());
                    }
                    Thread.Sleep(0);
                }
            }
        }


        public void setTotalFrames(int totalFrames)
        {
            this.totalFrames = totalFrames;
        }
        public void setPass(int pass)
        {
            this.pass = pass;
        }

        private void stdoutProcess()
        {
            if (mainProcess.StartInfo.FileName.Contains("xvid_encraw.exe"))
            {
                string outlog;
                while ((outlog = stdout.ReadLine()) != null)
                {
                  
                  
                        if (outlog.Contains("time="))
                        {
                            int currframe = int.Parse(outlog.Trim().Substring(0, outlog.Trim().IndexOf(':')));
                            float percent = (float)currframe / (float)totalFrames;
                            if (percent < 0)
                                percent = 1.0F;
                            log.setInfoLabel("Encoding Video - Pass " + pass.ToString() + ": " + percent.ToString("p2"));
                        }
                        if (outlog.Contains("fps"))
                            log.addLine(outlog);
                    
                    Thread.Sleep(0);
                }

            }
            else
            {
                while (stdout.ReadLine() != null)
                {
                    if (!disablestdout)
                    {
                        log.addLine(stdout.ReadLine());
                        log.setInfoLabel(stdout.ReadLine());
                    }
                    Thread.Sleep(0);
                }
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
