using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
namespace MiniCoder.Encoding.Process_Management
{
    public class AttachmentProcess : MiniProcess
    {
        private static Process mainProcess = null;
        Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        public bool abandon = false;
        public bool errflag = true;
        public int processPriority = 0;
        public string currProcess = "";
        
        private bool disablestderr = false;
        private bool disablestdout = false;
        private string outputLog;
        
        int exitCode;

        public AttachmentProcess()
        {
           
        }

        public Boolean getAbandonStatus()
        {
            return abandon;
        }
        public void setPriority(int i)
        {
            processPriority = i;
        }
        public void abandonProcess()
        {
            abandon = true;
        }

        public void setFilename(string filename)
        {
            mainProcess.StartInfo.FileName = filename;
        }

        public void setArguments(string arguments)
        {
            mainProcess.StartInfo.Arguments = arguments;
        }

        public string getAdditionalOutput()
        {
            return outputLog;
        }

        public int startProcess()
        {
            if (mainProcess.StartInfo.Arguments != null)
            {
                
               // // LogBook.addLogLine(""\"" + mainProcess.StartInfo.FileName +"\" " + mainProcess.StartInfo.Arguments,2);
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
                LogBook.addLogLine("Error in process. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors","",true);
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

        string logs;
    
        private void stderrProcess()
        {
            while ((logs = stderr.ReadLine()) != null)
            {
                // LogBook.addLogLine("logs, 3);
                outputLog += logs + "\r\n";
                Thread.Sleep(0);
            }
        }
        


         private void stdoutProcess()
        {
                while ((logs = stdout.ReadLine()) != null)
                {
                    outputLog += logs + "\r\n";
                    // LogBook.addLogLine("logs, 3);
                    Thread.Sleep(0);
                }
            }
        }


      
    }

