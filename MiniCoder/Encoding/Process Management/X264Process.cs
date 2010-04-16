//    MiniCoder
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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using MiniTech.MiniCoder.Core.Other.Logging;

namespace MiniTech.MiniCoder.Encoding.Process_Management
{

    public class X264Process : MiniProcess
    {
        private static Process mainProcess = null;
        private Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        private bool abandon = false;
        private int processPriority = 0;
        private Thread previewer;
        private bool disablestderr = false;
        private bool disablestdout = false;
        private string frontMessage;
        private string pass;
        private int exitCode;
        private SortedList<String, String[]> fileDetails;
        private SortedList<String, String> encOpts;
        private string loglocation = "";

        public X264Process(string frontMessage, string pass, string loglocation, SortedList<String, String[]> fileDetails, SortedList<String, String> encOpts)
        {
            this.pass = pass;
            this.frontMessage = frontMessage;
            this.loglocation = loglocation;
            this.fileDetails = fileDetails;
            this.encOpts = encOpts;
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
            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error in process. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
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
                if (null != previewer)
                {
                    previewer.Interrupt();
                    previewer.Abort();
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

        String read;
        string stderrLast = "";
        DirectShow.Preview preview;
        private void showWindow()
        {
            preview = new DirectShow.Preview();
            if (encOpts["resize"] != "0")
            {
                preview.Width = int.Parse(encOpts["width"]);
                preview.Height = int.Parse(encOpts["height"]) + 49;
            }
            else
            {
                preview.Width = int.Parse(fileDetails["width"][0]);
                preview.Height = int.Parse(fileDetails["height"][0]) + 49;
            }
            preview.openFile(fileDetails["fileName"][0]);
            windowIsOpen = true;
            preview.ShowDialog();
            windowIsOpen = false;
            preview.Dispose();

        }
        Boolean windowIsOpen = false;
        private void stderrProcess()
        {
            if ((Boolean.Parse(encOpts["showvideo"])) && mainProcess.StartInfo.Arguments.Contains(".264"))
            {
                previewer = new Thread(new ThreadStart(showWindow));
                previewer.Start();
            }
            while ((read = stderr.ReadLine()) != null)
            {
                if (!disablestderr)
                {
                    if (!stderrLast.Equals(read))
                    {
                        stderrLast = read;
                        if (read.Contains("frames") & CharOccurs(read, ',') == 3)
                        {
                            string[] split = Regex.Split(read, ",");
                            LogBookController.Instance.setInfoLabel(frontMessage + " - Pass " + pass + ": " + Regex.Split(split[0], "]")[0].Replace("[", "") + " - " + split[3]);
                            if (null != previewer && windowIsOpen)
                            {
                                string splitLocation = split[0].Split(Convert.ToChar("]"))[1].Split(char.Parse("/"))[0];
                                preview.setPosition(int.Parse(splitLocation), int.Parse(fileDetails["framecount"][0]), fileDetails["fps"][0]);
                            }
                        }
                        else
                        {
                            LogBookController.Instance.addLogLine(read, LogMessageCategories.Video);
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
                        LogBookController.Instance.addLogLine(read2, LogMessageCategories.Video);
                    }
                }
                Thread.Sleep(0);
            }
        }
    }
}

