using System;
using System.Collections.Generic;
using MiniCoder.General;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using MiniCoder;
using x264_GUI_CS;

namespace x264_GUI_CS.Task_Libraries
{
    class Avisynth
    {
        private static Process mainProcess = null;
        Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        bool finishedTask = false;
        LogBook log;
        Package avs2yuv;
        Package avisynth;
        
        public Avisynth(LogBook log)
        {
            this.log = log;
        }

        public Avisynth()
        {
        }

        public string createScript(ApplicationSettings dir, General.FileInformation details,General.EncodingOptions encOpts)
        {
            string script = "";
            string sourceline = "";
            string filters = "";

            switch (details.vid_codec)
            {
                case "DIV3":
                case "XVID":
                case "DIVX":
                case "DX50":
                case "DX60":
                    switch (details.ext)
                    {
                        case ".mkv":
                            sourceline = "AVISource(\"" + details.demuxVideo  + "\", audio=false)";
                            break;
                        case ".ogm":
                            sourceline = "AVISource(\"" + dir.tempDIR + details.name + "-Video Track.avi\", audio=false)";
                            break;
                        case ".avi":
                            sourceline = "AVISource(\"" + details.fileName + "\", audio=false)";
                            break;
                        case ".mp4":
                            sourceline = "AVISource(\"" + dir.tempDIR + details.name + "-Video Track.avi\", audio=false)";
                            break;
                        default:
                            sourceline = "DirectshowSource(\"" + details.fileName + "\")";
                            break;
                    }
                    break;
                case "avc1":
                case "H264":
                case "V_MPEG4/ISO/AVC":
                case "Intel H.264":
                case "x264":
                    switch (details.ext)
                    {
                        case ".mkv":
                          sourceline = "AVCSource(\"" + details.dgaFile + "\")";
                            break;
                        case ".ogm":
                            sourceline = "AVCSource(\"" + details.dgaFile + "\")";
                            break;
                        case ".avi":
                            sourceline = "AVISource(\"" + details.fileName + "\", audio=false)";
                             break;
                        case ".mp4":
                            sourceline = "AVCSource(\"" + details.dgaFile + "\")";
                            break;
                        default:
                            sourceline = "DirectshowSource(\"" + details.dgaFile + "\")";
                            break;
                    }
                    break;
             case "20":
                    switch(details.ext)
                    {
                        case ".mkv":
                            sourceline = "AVISource(\"" + details.demuxVideo + "\",audio=false)";
                            break;
                        case ".ogm":
                            sourceline = "AVISource(\"" + dir.tempDIR + details.name + "-Video Track.avi\", audio=false)";
                            break;
                        case ".avi":
                            sourceline = "AVISource(\"" + details.fileName + "\",audio=false)";
                            break;
                        case ".mp4":
                            sourceline = "AVISource(\"" + dir.tempDIR + details.name + "-Video Track.avi\", audio=false)";
                            break;
                        default:
                            sourceline = "DirectshowSource(\"" + details.fileName + "\")";
                            break;
                     }
                    break;
             case "":                   
                        switch (details.ext)
                        {

                            default:
                                sourceline = "DGDecode_mpeg2source(\"" + details.demuxVideo + "\", info=3)\r\nColorMatrix(hints=true, threads=0)";
                                break;
                        }
                        break;
                    
                default:
                    switch(details.ext)
                    {
                        case ".mkv":
                            sourceline = "DirectshowSource(\"" + dir.tempDIR + details.name + "-Video Track.avi\")";
                            break;
                        case ".ogm":
                            sourceline = "DirectshowSource(\"" + details.fileName + "\")";
                            break;
                        case ".avi":
                            sourceline = "DirectshowSource(\"" + details.fileName + "\")";
                            break;
                        case ".mp4":
                            sourceline = "DirectshowSource(\"" + details.fileName + "\")";
                            break;
                        default:
                            sourceline = "DirectshowSource(\"" + details.fileName + "\")";
                            break;
                    }
                    break;

              
            }
            log.addLine("================= AVS FILE =================");
            log.addLine(sourceline);
            script += sourceline + "\r\n\r\n";

            filters = addFilters(encOpts, dir);
           
            script += filters;
            log.addLine("================= END AVS ==================");
            return script;
         
        }

        public string addFilters(General.EncodingOptions encOpts, ApplicationSettings dir)
        {
            Filters filt = new Filters(dir);
            string filtOpts = "";
                    
            filtOpts += "# Field\r\n" + filt.addField(encOpts.filtField) + "\r\n";
            if(filt.addField(encOpts.filtField) != "")
            log.addLine(filt.addField(encOpts.filtField));
            if (encOpts.customFilter[0] != "")
            {
                filtOpts += encOpts.customFilter[0] + "\r\n\r\n";
                log.addLine(encOpts.customFilter[0]);
            }
            filtOpts += "# Resizer\r\n" + filt.addResize(encOpts.filtResize, encOpts.resizeWidth, encOpts.resizeHeight) + "\r\n";
            if (filt.addResize(encOpts.filtResize, encOpts.resizeWidth, encOpts.resizeHeight) != "")
            log.addLine(filt.addResize(encOpts.filtResize, encOpts.resizeWidth, encOpts.resizeHeight));
            if (encOpts.customFilter[1] != "")
            {
                filtOpts += encOpts.customFilter[1] + "\r\n\r\n";
                log.addLine(encOpts.customFilter[1]);
            }
            filtOpts += "# Denoiser\r\n" + filt.addNoise(encOpts.filtNoise) + "\r\n";
            if (filt.addNoise(encOpts.filtNoise) != "")
            log.addLine(filt.addNoise(encOpts.filtNoise));
            if (encOpts.customFilter[2] != "")
            {
                filtOpts += encOpts.customFilter[2] + "\r\n\r\n";
                log.addLine(encOpts.customFilter[2]);
            }
            filtOpts += "# Sharpener\r\n" + filt.addSharp(encOpts.filtSharp) + "\r\n";
            if(filt.addSharp(encOpts.filtSharp) != "")
            log.addLine(filt.addSharp(encOpts.filtSharp));
            if (encOpts.customFilter[3] != "")
            {
                filtOpts += encOpts.customFilter[3] + "\r\n\r\n";
                log.addLine(encOpts.customFilter[3]);
            }

            if (encOpts.subtitle != "")
            {
                filtOpts += "# Subtitle\r\n" + filt.addSub(encOpts.subtitle) + "\r\n\r\n";
                log.addLine(filt.addSub(encOpts.subtitle));
            }

            if (encOpts.hardSub != 0)
            {
                filtOpts += "TextSub(\"" + encOpts.hardSubLocation + "\")";
            }

            return filtOpts;
        }
        public string addFiltersNoLog(General.EncodingOptions encOpts, ApplicationSettings dir)
        {
            Filters filt = new Filters(dir);
            string filtOpts = "";

            filtOpts += "# Field\r\n" + filt.addField(encOpts.filtField) + "\r\n";
           
            if (encOpts.customFilter[0] != "")
            {
                filtOpts += encOpts.customFilter[0] + "\r\n\r\n";
              
            }
            filtOpts += "# Resizer\r\n" + filt.addResize(encOpts.filtResize, encOpts.resizeWidth, encOpts.resizeHeight) + "\r\n";
            if (encOpts.customFilter[1] != "")
            {
                filtOpts += encOpts.customFilter[1] + "\r\n\r\n";
             }
            filtOpts += "# Denoiser\r\n" + filt.addNoise(encOpts.filtNoise) + "\r\n";
            if (encOpts.customFilter[2] != "")
            {
                filtOpts += encOpts.customFilter[2] + "\r\n\r\n";
             }
            filtOpts += "# Sharpener\r\n" + filt.addSharp(encOpts.filtSharp) + "\r\n";
            if (encOpts.customFilter[3] != "")
            {
                filtOpts += encOpts.customFilter[3] + "\r\n\r\n";
             }
            if (encOpts.subtitle != "")
            {
                filtOpts += "# Subtitle\r\n" + filt.addSub(encOpts.subtitle) + "\r\n\r\n";
            }
            return filtOpts;
        }
        public void writeScript(ApplicationSettings dir, General.FileInformation details,string avsLine)
        {
            StreamWriter avs;

            avs = File.CreateText(details.avsFile = dir.tempDIR + details.name + ".avs");
            avs.WriteLine(avsLine);

            avs.Close();
        }
        
        public bool checkErrors(string file,ApplicationSettings dir)
        {
            avs2yuv = (Package)dir.htRequired["avs2yuv"];
            avisynth = (Package)dir.htRequired["avs"];

            if (!avisynth.isInstalled())
                avisynth.download();

            if (!avs2yuv.isInstalled())
                avs2yuv.download();

            mainProcess = new Process();

            log.addLine("Verifying Avisynth script");
            mainProcess.StartInfo.FileName = Path.Combine(avs2yuv.getInstallPath(), "avs2yuv.exe");
            mainProcess.StartInfo.Arguments = "\"" + file + "\" NUL";

            taskProcess();

            string err = log.getLog();

            if (err.Contains("Avisynth error"))
            {
                if (err.Contains("line 1"))
                {
                    log.addLine("Error on line 1. Attemtping to resolve with ConvertToYV12!");
                    StreamWriter sw;
                    sw = File.AppendText(file);
                    sw.WriteLine("\r\nConvertToYV12()");
                    sw.Close();
                    return true;
                }
                MessageBox.Show("Avisynth Error");
                return false;
            }

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

                Thread.Sleep(2000);

                if(!mainProcess.HasExited)
                    mainProcess.Kill();

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
                log.addLine(stdout.ReadLine());
                log.setInfoLabel(stdout.ReadLine());
                Thread.Sleep(0);
            }
            //while ((testText.Text = stdout.ReadLine()) != null)
            //{
            //    outputLog += testText.Text + "\r\n";
            //    Thread.Sleep(0);
            //}
        }
    }
}
