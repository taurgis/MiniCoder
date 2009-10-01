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
    class VideoEncoding
    {
        private static Process mainProcess = null;
          Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        General.ProcessSettings proc = new x264_GUI_CS.General.ProcessSettings();
        bool finishedTask = false;
        LogBook log;
        Package x264;
        Package xvid_encraw;
        string errlog, outlog;
        int pass;
        string codec;
        int exitCode;

        public VideoEncoding(LogBook log)
        {
            this.log = log;
        }

        public bool encode(ApplicationSettings dir, General.EncodingOptions encopts, General.FileInformation details, General.ProcessSettings proc)
        {
            this.proc = proc;
            x264=(Package)dir.htRequired["x264"];
            xvid_encraw = (Package)dir.htRequired["xvid_encraw"];
            string pass1Arg = "", pass2Arg = "", pass3Arg = null;
            mainProcess = new Process();
            totframes = details.framecount;
            DateTime tempStart = new DateTime();
            details.statsfile = dir.tempDIR + details.name + ".stats";

            if (encopts.sizeOpt == 1)
            {
                General.Calc brCalc = new x264_GUI_CS.General.Calc(details, encopts);
                encopts.vidBR = brCalc.getVideoBitrate();
             
                log.addLine("Video Bitrate: " + encopts.vidBR);
            }

            switch (encopts.vidCodec)
            {
                case 0:
                    codec = "x264";
                    if (!x264.isInstalled())
                        x264.download();
                    mainProcess.StartInfo.FileName = Path.Combine(x264.getInstallPath(), "x264.exe");
                    details.encodedVideo = dir.tempDIR + details.name + "_video output.264";

                    switch (encopts.vidQual)
                    {
                        case 0:
                            pass1Arg = "--pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 3.1 --bframes 1 --weightb --direct temporal --deblock 1:1 --subme 1 --partitions none --vbv-bufsize 14000 --vbv-maxrate 17500 --me dia --threads auto --thread-input --output";
                            pass2Arg = "--pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 3.1 --bframes 1 --weightb --direct temporal --deblock 1:1 --partitions p8x8,b8x8,i4x4 --vbv-bufsize 14000 --vbv-maxrate 17500 --threads auto --thread-input --output";
                            break;

                        case 1:
                            pass1Arg = "--pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 4.1 --bframes 2 --b-pyramid --weightb --direct auto --deblock 1:1 --subme 1 --partitions none  --vbv-bufsize 14000 --vbv-maxrate 17500 --me dia --threads auto --thread-input --output";
                            pass2Arg = "--pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 4.1 --ref 3 --mixed-refs --bframes 2 --b-pyramid --weightb --direct auto --deblock 1:1 --subme 8 --trellis 1 --partitions all  --8x8dct --vbv-bufsize 14000 --vbv-maxrate 17500 --me umh --threads auto --thread-input --output";
                            break;

                        case 2:
                            pass1Arg = "--pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --bframes 3 --b-adapt 1 --b-pyramid --weightb --direct auto --deblock 1:1 --subme 1 --partitions none --vbv-bufsize 14000 --vbv-maxrate 17500 --me dia --threads auto --thread-input --output";
                            pass2Arg = "--pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --ref 5 --mixed-refs --bframes 3 --b-adapt 1 --b-pyramid --weightb --direct auto --deblock 1:1 --subme 8 --trellis 1 --partitions all --8x8dct --vbv-bufsize 14000 --vbv-maxrate 17500 --me umh --threads auto --thread-input --output";
                            break;

                        case 3:
                            pass1Arg = "--pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --tune animation --bframes 8 --b-adapt 2 --b-pyramid --weightb --direct auto --deblock 1:2 --psy-rd 0.8:0 --aq-mode 0 --merange 32 --scenecut 45 --no-mbtree --threads auto --subme 2 --partitions none --me dia --output";
                            pass3Arg = "--pass 3 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --tune animation --bframes 8 --b-adapt 2 --b-pyramid --weightb --direct auto --deblock 1:2 --psy-rd 0.8:0 --aq-mode 0 --merange 32 --scenecut 45 --no-mbtree --threads auto --subme 2 --partitions none --me dia --output";
                            pass2Arg = "--pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --tune animation --ref 8 --mixed-refs --no-fast-pskip --bframes 8 --b-adapt 2 --b-pyramid --weightb --direct auto --deblock 1:2 --subme 9 --trellis 2 --psy-rd 0.8:0 --partitions all --8x8dct --aq-mode 0 --me umh --merange 32 --scenecut 45 --no-mbtree --threads auto --output";
                            break;
                        
                        case 4:
                            pass1Arg = "--pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --ref 8 --mixed-refs --no-fast-pskip --bframes 16 --b-adapt 1 --b-pyramid --direct auto --deblock 3:3 --subme 7 --chroma-qp-offset -2 --trellis 2 --psy-rd 0.6:0 --partitions all --8x8dct --aq-mode 0 --me umh --merange 16 --scenecut 40 --no-mbtree --threads auto --output";
                            pass2Arg = "--pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --ref 8 --mixed-refs --no-fast-pskip --bframes 16 --b-adapt 1 --b-pyramid --direct auto --deblock 3:3 --subme 7 --chroma-qp-offset -2 --trellis 2 --psy-rd 0.6:0 --partitions all --8x8dct --aq-mode 0 --me umh --merange 16 --scenecut 40 --no-mbtree --threads auto --output";
                            break;
                  
                        case 5:
                            pass1Arg = "--pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --ref 8 --mixed-refs --no-fast-pskip --bframes 16 --b-adapt 1 --b-pyramid --direct auto --deblock -2:-1 --subme 6 --trellis 1 --psy-rd 1.0:0 --partitions all --8x8dct --weightb --chroma-qp-offset -2 --aq-mode 0 --me umh --merange 16 --scenecut 40 --no-mbtree --threads auto --output";
                            pass2Arg = "--pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --ref 8 --mixed-refs --no-fast-pskip --bframes 16 --b-adapt 1 --b-pyramid --direct auto --deblock -2:-1 --subme 6 --trellis 1 --psy-rd 1.0:0 --partitions all --8x8dct --weightb --chroma-qp-offset -2 --aq-mode 0 --me umh --merange 16 --scenecut 40 --no-mbtree --threads auto --output";
                            break;

                        case 6:
                            pass1Arg = "--pass 1 --crf " + details.crfValue + " --level 5.1 --ref 5 --mixed-refs --no-fast-pskip --bframes 5 --b-adapt 1 --b-pyramid --direct auto --deblock 1:1 --subme 7 --chroma-qp-offset 0 --trellis 1 --psy-rd 0.0:0 --partitions all --8x8dct --me umh --qcomp 1.0 --merange 16 --scenecut 40 --weightb --threads auto --output";
                          
                            break;
                    }

                    if(pass2Arg != "")
                        mainProcess.StartInfo.Arguments = pass1Arg + " NUL \"" + details.avsFile + "\"";
                    else
                        mainProcess.StartInfo.Arguments = pass1Arg + " \"" + details.encodedVideo + "\" \"" + details.avsFile + "\"";    //--output ".264" "avs"

                
                    
                    log.addLine(mainProcess.StartInfo.Arguments);
                    break;

                case 1:
                    codec = "xvid";
                    if (!xvid_encraw.isInstalled())
                        xvid_encraw.download();
                    mainProcess.StartInfo.FileName = Path.Combine(xvid_encraw.getInstallPath(), "xvid_encraw.exe");
                    details.encodedVideo = dir.tempDIR + details.name + "_video output.avi";

                    switch (encopts.vidQual)
                    {
                        case 0:
                            pass1Arg = "-pass1 \"" + details.statsfile + "\" -bitrate " + encopts.vidBR + " -kboost 100 -chigh 30 -clow 15 -overhead 0 -turbo -max_key_interval 250 -nopacked -quality 5 -vhqmode 0 -closed_gop -lumimasking -notrellis -nochromame -imin 1 -pmin 1 -bquant_ratio 162 -bquant_offset 0 -bmin 1 -par 1:1 -threads 1 -o";
                            pass2Arg = "-pass2 \"" + details.statsfile + "\" -bitrate " + encopts.vidBR + " -kboost 100 -chigh 30 -clow 15 -overhead 0 -turbo -max_key_interval 250 -nopacked -quality 5 -vhqmode 0 -closed_gop -lumimasking -notrellis -nochromame -imin 1 -pmin 1 -bquant_ratio 162 -bquant_offset 0 -bmin 1 -threads 1  -o";
                            break;

                        case 1:
                            pass1Arg = "-pass1 \"" + details.statsfile + "\" -bitrate " + encopts.vidBR + " -kboost 100 -chigh 30 -clow 15 -overhead 0 -turbo -max_key_interval 250 -nopacked -closed_gop -lumimasking -imin 1 -pmin 1 -bvhq -bquant_ratio 162 -bquant_offset 0 -bmin 1 -par 1:1 -threads 1 -o";
                            pass2Arg = "-pass2 \"" + details.statsfile + "\" -bitrate " + encopts.vidBR + " -kboost 100 -chigh 30 -clow 15 -overhead 0 -turbo -max_key_interval 250 -nopacked -closed_gop -lumimasking -imin 1 -pmin 1 -bvhq -bquant_ratio 162 -bquant_offset 0 -bmin 1 -threads 1  -o";
                            break;

                        case 2:
                        case 3:
                            pass1Arg = "-pass1 \"" + details.statsfile + "\" -bitrate " + encopts.vidBR + " -kboost 100 -chigh 30 -clow 15 -overhead 0 -turbo -max_key_interval 250 -nopacked -quality 5 -vhqmode 0 -closed_gop -lumimasking -notrellis -nochromame -imin 1 -pmin 1 -bquant_ratio 162 -bquant_offset 0 -bmin 1 -par 1:1 -threads 1 -o";
                            pass2Arg = "-pass2 \"" + details.statsfile + "\" -bitrate " + encopts.vidBR + " -kboost 100 -chigh 30 -clow 15 -overhead 0 -turbo -max_key_interval 250 -nopacked -vhqmode 4 -qpel -closed_gop -lumimasking -imin 1 -pmin 1 -bvhq -bquant_ratio 162 -bquant_offset 0 -bmin 1 -threads 1  -o";
                            break;

                    }

                    mainProcess.StartInfo.Arguments = "-i \"" + details.avsFile + "\" " + pass1Arg + " NUL";
                    log.addLine(mainProcess.StartInfo.Arguments);
                    break;
              
            }
            tempStart = DateTime.Now;
            pass = 1;
            taskProcess();
            log.addLine("Start time:" + tempStart.ToShortTimeString());
            log.addLine("End Time:" + DateTime.Now.ToShortTimeString());
            log.addLine("Encoding Time:" + (DateTime.Now-tempStart).TotalMinutes.ToString() +" minites.");
            if (proc.abandon)
                return true;

            if (exitCode != 0)
                return false;

            if (pass3Arg != null)
            {
              tempStart = DateTime.Now;
                pass = 2;
                mainProcess.StartInfo.Arguments = mainProcess.StartInfo.Arguments = pass3Arg + " NUL \"" + details.avsFile + "\"";
                log.addLine(mainProcess.StartInfo.Arguments);
                taskProcess();
                       log.addLine("Start time:" + tempStart.ToShortTimeString());
            log.addLine("End Time:" + DateTime.Now.ToShortTimeString());
            log.addLine("Encoding Time:" + (DateTime.Now-tempStart).TotalMinutes.ToString() +" minites.");
                if (proc.abandon)
                    return true;

                if (exitCode != 0)
                    return false;
            }

            if (pass2Arg != "")
            {
                switch (encopts.vidCodec)
                {
                    case 0:
                        mainProcess.StartInfo.Arguments = pass2Arg + " \"" + details.encodedVideo + "\" \"" + details.avsFile + "\"";
                        log.addLine(mainProcess.StartInfo.Arguments);
                        break;

                    case 1:
                        mainProcess.StartInfo.Arguments = "-i \"" + details.avsFile + "\" " + pass2Arg + " \"" + details.encodedVideo + "\"";
                        log.addLine(mainProcess.StartInfo.Arguments);
                        break;
                }
           
            if (pass3Arg != null)
                pass = 3;
            else
                pass = 2;

            tempStart = DateTime.Now;
            taskProcess();
            log.addLine("Start time:" + tempStart.ToShortTimeString());
            log.addLine("End Time:" + DateTime.Now.ToShortTimeString());
            log.addLine("Encoding Time:" + (DateTime.Now - tempStart).TotalMinutes.ToString() + " minites.");
            }
            if (proc.abandon)
                return true;

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
            mainProcess.StartInfo.RedirectStandardOutput = true;

            backGround = new Thread(new ThreadStart(runprocess));
            backGround.Start();

            while (backGround.IsAlive)
            {
                Thread.Sleep(500);
                
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
                mainProcess.PriorityClass = ProcessPriorityClass.Idle;

                stderr = mainProcess.StandardError;
                stdErrThread = new Thread(new ThreadStart(stderrProcess));
                stdErrThread.Start();
                
                stdout = mainProcess.StandardOutput;
                stdOutThread = new Thread(new ThreadStart(stdoutProcess));
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
        int totframes = 0;
        private void stderrProcess()
        {
            string percent;
            while ((errlog = stderr.ReadLine()) != null)
            {
                if (codec == "x264")
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

                }
                
                Thread.Sleep(0);
            }
        }

        private void stdoutProcess()
        {
            while ((outlog = stdout.ReadLine()) != null)
            {
                if (codec == "xvid")
                {
                    if (outlog.Contains("time="))
                    {
                        int currframe = int.Parse(outlog.Trim().Substring(0, outlog.Trim().IndexOf(':')));
                        float percent = (float)currframe / (float)totframes;
                        if (percent < 0)
                            percent = 1.0F;
                        log.setInfoLabel("Encoding Video - Pass " + pass.ToString() + ": " + percent.ToString("p2"));
                    }
                    if (outlog.Contains("fps"))
                        log.addLine(outlog);
                }
                Thread.Sleep(0);
            }
        }
    }
}
