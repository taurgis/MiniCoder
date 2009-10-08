using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using MiniCoder;
namespace x264_GUI_CS.Containers
{
    class clMKV : ifContainer
    {
        Package mkvtoolnix;
        Package pcmkv2vfr;
        ProcessSettings proc;
        private static String outputLog = "";
        private static string logs = "";
        private static Process mainProcess = null;
        Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        bool finishedTask = false;
        LogBook log;
        int exitCode;
        string chapters;
       // Boolean errorInchapter = false;
        Boolean fetchChapters = false;
        public clMKV(LogBook log)
        {
            this.log = log;
            proc = new ProcessSettings(log);
        }
           
        public bool demux(ApplicationSettings dir, FileInformation details, ProcessSettings proc)
        {
            this.proc = proc;
            outputLog = "";
            try
            {
                mkvtoolnix = (Package)dir.htRequired["mkvtoolnix"];

                if (!mkvtoolnix.isInstalled())
                    mkvtoolnix.download();

                log.addLine("MKVToolnix Dir:" + mkvtoolnix.getInstallPath());
                log.setInfoLabel("Demuxing MKV Tracks");
                mainProcess = new Process();
                log.addLine("Started demuxing MKV file");
                mainProcess.StartInfo.FileName = Path.Combine(mkvtoolnix.getInstallPath(), "mkvextract.exe");
                string tempArg = tempArg = "tracks \"" + details.fileName + "\" ";

                //if (details.vfr)
                //{
                //    details.demuxVideo = details.vfrName;
                //}
                //else
                //{
                    //if (details.vid_codec == "avc1" || details.vid_codec == "H264" || details.vid_codec == "V_MPEG4/ISO/AVC")
                    //{
                        tempArg += "1:\"" + dir.tempDIR + details.name + "-Video Track" + "." + details.extension[details.vid_codec] + "\" ";
                        details.demuxVideo = dir.tempDIR + details.name + "-Video Track" + "." + details.extension[details.vid_codec];
                    //}
                    //else
                    //{

                    //    tempArg = "tracks \"" + details.fileName + "\" " + details.vid_id + ":\"" + dir.tempDIR + details.name + "-Video Track" + "." + details.extension[details.vid_codec] + "\"";
                    //    details.demuxVideo = details.vfrName;
                    //}
                
                //}
                log.addLine("Demuxed Video: " + details.demuxVideo);
                details.demuxAudio = new string[details.audioCount];
                log.addLine("Audio Count: " + details.audioCount);
                for (int i = 0; i < details.audioCount; i++)
                {
                    details.demuxAudio[i] = dir.tempDIR + details.name + "-Audio Track-" + i.ToString() + "." + details.extension[details.aud_codec[i]];
                    tempArg +=details.aud_id[i] + ":\"" + details.demuxAudio[i] + "\" ";
                }
                details.demuxSub = new string[details.subCount];
                log.addLine("Sub Count: " + details.subCount);
                for (int i = 0; i < details.subCount; i++)
                {
                    details.demuxSub[i] = dir.tempDIR + details.name + "-Subtitle Track-" + i.ToString() + "." + details.extension[details.sub_codec[i]];
                    tempArg +=details.sub_id[i] + ":\"" + details.demuxSub[i] + "\" ";
                }

                log.addLine(tempArg);
                mainProcess.StartInfo.Arguments = tempArg;
             
                taskProcess();
                               
                if (exitCode != 0)
                    return false;

                if (proc.abandon)
                    log.setInfoLabel("Demuxing Aborted");
                else
                    log.setInfoLabel("Demuxing Complete");

                log.setInfoLabel("Demuxing Attachments");
                mainProcess = new Process();

                mainProcess.StartInfo.FileName = Path.Combine(mkvtoolnix.getInstallPath(), "mkvinfo.exe");
                mainProcess.StartInfo.Arguments = "\"" + details.fileName + "\"";

                taskProcess();

                string[] split = Regex.Split(outputLog, "\\+ File name: ");
                                               
                string temp;

                details.attachments = new string[split.Length - 1];

                char[] sep1 = { ':' };
                char[] sep2 = { '\r' };
                try
                {
                    int start = outputLog.IndexOfAny(sep1, outputLog.IndexOf("Display width")) + 2;
                    int end = outputLog.IndexOfAny(sep2, outputLog.IndexOf("Display width"));
                    temp = outputLog.Substring(start, end - start);
                    int width = int.Parse(temp);

                    start = outputLog.IndexOfAny(sep1, outputLog.IndexOf("Display height")) + 2;
                    end = outputLog.IndexOfAny(sep2, outputLog.IndexOf("Display height"));
                    temp = outputLog.Substring(start, end - start);
                    int height = int.Parse(temp);

                    details.muxwidth = width;
                    details.muxheight = height;

                    log.addLine("Number of attachments: " + split.Length);
                    for (int i = 1; i < split.Length; i++)
                        details.attachments[i - 1] = split[i].Substring(0, split[i].IndexOf("\r\n"));

                    mainProcess = new Process();

                    mainProcess.StartInfo.FileName = Path.Combine(mkvtoolnix.getInstallPath(), "mkvextract.exe");
                    tempArg = "attachments \"" + details.fileName + "\"";

                    for (int i = 1; i <= details.attachments.Length; i++)
                        tempArg += " " + i.ToString() + ":\"" + dir.tempDIR + details.attachments[i - 1] + "\"";

                    mainProcess.StartInfo.Arguments = tempArg;
                    taskProcess();
                }
                catch
                {
                    log.addLine("Error demuxing!");
                    log.addLine("Remuxing the MKV file might solve this problem.");
                }
                log.setInfoLabel("Done Demuxing");
                log.addLine("Done Demuxing");


          
                if (details.chapters != "")
                {
                       XMLValidator xmlValidator = new XMLValidator(dir.tempDIR + "chapters.xml");
                    int chapterFetchRetries = 0;
                    while(!xmlValidator.Validate() && chapterFetchRetries++ < 5)
                    {
                        if(!xmlValidator.Validate() && File.Exists(dir.tempDIR + "chapters.xml"))
                        {
                            log.addLine("Error in XML");
                        }
                      
                            log.addLine("Attempt " + chapterFetchRetries + " to fetch chapters.");
                        
                    mainProcess = new Process();
                    log.addLine("Fetching Chapters");
                    mainProcess.StartInfo.FileName = Path.Combine(mkvtoolnix.getInstallPath(), "mkvextract.exe");
                    tempArg = "chapters \"" + details.fileName + "\"";
                    fetchChapters = true;
                    mainProcess.StartInfo.Arguments = tempArg;
                    taskProcess();
                    log.addLine("==================== CHAPTER INFO ====================");
                    log.addLine(chapters);
                    log.addLine("==================== END CHAPTER  ====================");
                    //if (!errorInchapter)
                    //{
                        StreamWriter strChapters = new StreamWriter((dir.tempDIR + "chapters.xml"), false);
                        strChapters.Write(chapters);
                        strChapters.Close();                     
                                         
                    //}
                    }

                    if (!xmlValidator.Validate())
                    {
                        log.addLine("Error validating XML file after 5 tries");
                        File.Delete(dir.tempDIR + "chapters.xml");
                        log.addLine("Continuing without the chapters.");
                    }
                }
                /*mainProcess = new Process();

                mainProcess.StartInfo.FileName = Path.Combine(dir.mkvtoolnixDIR, "mkvextract.exe");
                mainProcess.StartInfo.Arguments = "cuesheet \"" + details.fileName + "\" > \"D:\\chapters.cue\"";

                MessageBox.Show(mainProcess.StartInfo.Arguments);
                taskProcess();
                log.setInfoLabel"";
                textBox1.Text = mainProcess.StartInfo.Arguments;*/

                if (proc.abandon)
                    log.setInfoLabel("Demuxing Aborted");
                else
                    log.setInfoLabel("Demuxing Complete");

                return true;

            }

            catch(KeyNotFoundException e)
            {
                String errormessage = "";
                errormessage += "VIDEO: " ;
                errormessage += details.vid_codec;
                errormessage += ", AUDIO: " ;
                 for (int i = 0; i < details.audioCount; i++)
                {
                     errormessage += " " + i + ": " + details.aud_codec[i] + ", " + details.aud_Languages[i];
                 }
                 errormessage += ", SUBS: ";
                 for (int i = 0; i < details.subCount; i++)
                {
                    errormessage += " " + i + ": " + details.sub_codec[i] + ", " + details.sub_lang[i];
                 }


                log.addLine("Can't find codec :-(" + e.Message + ", " + errormessage);
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
                    try
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
                    catch
                    {

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
            //while ((outputLog += stdout.ReadLine()) != null)
            //{
            //    log.addLine(stdout.ReadLine());
            //    log.setInfoLabel(stdout.ReadLine());
            //    Thread.Sleep(0);
            //}
            while ((logs = stderr.ReadLine()) != null)
            {
                outputLog += logs + "\r\n";
                Thread.Sleep(0);
            }
        }

        private void stdoutProcess()
        {
            //while ((outputLog += stdout.ReadLine()) != null)
            //{
            //    log.addLine(stdout.ReadLine());
            //    log.setInfoLabel(stdout.ReadLine());
            //    Thread.Sleep(0);
            //}
            while ((logs = stdout.ReadLine()) != null)
            {
                outputLog += logs + "\r\n";
                if (fetchChapters)
                {
                   
                    chapters += logs + "\r\n";

                }
                Thread.Sleep(0);
            }
        }
        public bool mkv2vfr(ApplicationSettings dir, FileInformation details, ProcessSettings proc)
        {
            this.proc = proc;
            pcmkv2vfr = (Package)dir.htRequired["mkv2vfr"];

            if (!pcmkv2vfr.isInstalled())
                pcmkv2vfr.download();

            log.setInfoLabel("Parsing VFR");
            mainProcess = new Process();
            log.addLine("Making VFR file");
            mainProcess.StartInfo.FileName = Path.Combine(pcmkv2vfr.getInstallPath(), "mkv2vfr.exe");
            mainProcess.StartInfo.Arguments = "\"" + details.fileName + "\" \"" + dir.tempDIR + details.name + "-Video Track.avi\" \"" + dir.tempDIR + "timecode.txt\"";

            //MessageBox.Show(mainProcess.StartInfo.Arguments);

            taskProcess();
            // infoLabel.Text = "";

            if (proc.abandon)
                log.setInfoLabel("Parsing Completed");
            else
                log.setInfoLabel("Parsing Aborted");

            if (File.Exists(dir.tempDIR + "timecode.txt"))
                return true;
            else
                return false;
            
        }

    }
}
