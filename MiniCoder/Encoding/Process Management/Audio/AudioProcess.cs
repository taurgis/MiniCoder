﻿//    MiniCoder
//    Copyright (C) 2009-2010  MiniTech support@minitech.org
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using MiniTech.MiniCoder.Core.Other.Logging;

namespace MiniTech.MiniCoder.Encoding.Process_Management
{
    public class AudioProcess : MiniProcess
    {
        private int totaltime = 0;
        private static Process mainProcess = null;
        private Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        private bool abandon = false;
        private int processPriority = 0;
        private string loglocation = "";
        private bool disablestderr = false;
        private bool disablestdout = false;
        private string frontMessage;
        private String read;
        private string stderrLast = "";
        private int exitCode;

        public AudioProcess(string totaltime, string frontMessage, string loglocation)
        {
            this.totaltime = int.Parse(totaltime);
            this.frontMessage = frontMessage;
            this.loglocation = loglocation;
        }

        public string getAdditionalOutput()
        {
            return "";
        }

        public void setPriority(int i)
        {
            processPriority = i;
        }

        public void abandonProcess()
        {
            abandon = true;
        }

        public Boolean getAbandonStatus()
        {
            return abandon;
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
                LogBookController.Instance.addLogLine("\"" + mainProcess.StartInfo.FileName + "\" " + mainProcess.StartInfo.Arguments, LogMessageCategories.Video);

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

                mainProcess.WaitForExit();
                exitCode = mainProcess.ExitCode;

                Thread.Sleep(2000);
            }
            finally
            {
                Thread.Sleep(2000);
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

        private void stderrProcess()
        {
            TimeSpan tempTime = new TimeSpan(0, 0, totaltime);
            while ((read = stderr.ReadLine()) != null)
            {
                if (!disablestderr)
                {
                    if (!stderrLast.Equals(read))
                    {
                        stderrLast = read;
                        if (read.Contains("transcoding") & CharOccurs(read, ':') == 3)
                        {
                            string[] split = Regex.Split(read, ":");
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

                            LogBookController.Instance.setInfoLabel(frontMessage + ": " + "Encoded " + hr + ":" + min + ":" + sec + " / " + tempTime.Hours + ":" + tempTime.Minutes + ":" + tempTime.Seconds);
                        }
                    }
                }
                Thread.Sleep(0);
            }
        }
        private static int CharOccurs(string stringToSearch, char charToFind)
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

        String read2;
        string stdoutlast = "";
        private void stdoutProcess()
        {
            while ((read2 = stdout.ReadLine()) != null)
            {
                if (!disablestdout)
                {
                    if (!stdoutlast.Equals(read2))
                    {
                        stdoutlast = read2;
                    }
                }
                Thread.Sleep(0);
            }
        }
    }
}

