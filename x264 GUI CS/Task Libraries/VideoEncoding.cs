using System;
using System.Collections.Generic;
using MiniCoder.General;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MiniCoder;

namespace x264_GUI_CS.Task_Libraries
{
    class VideoEncoding
    {
      
        General.ProcessSettings proc;
        
        LogBook log;
        Package x264;
        Package xvid_encraw;
        int exitCode;


        public VideoEncoding(LogBook log)
        {
            this.log = log;
            proc = new x264_GUI_CS.General.ProcessSettings(log);
        }

        public bool encode(ApplicationSettings dir, General.EncodingOptions encopts, General.FileInformation details, General.ProcessSettings proc)
        {
            this.proc = proc;
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            x264=(Package)dir.htRequired["x264"];
            xvid_encraw = (Package)dir.htRequired["xvid_encraw"];
            string pass1Arg = "", pass2Arg = "", pass3Arg = null;
            proc.initProcess();
            proc.setTotalFrames(details.framecount);
            DateTime tempStart = new DateTime();

            int Processors = Environment.ProcessorCount;
            String extra;
            if (Processors > 1)
                extra = "--threads auto --thread-input";
            else
                extra = "--threads auto";
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
                    
                    if (!x264.isInstalled())
                        x264.download();
                    proc.setFilename(Path.Combine(x264.getInstallPath(), "x264.exe"));
                    details.encodedVideo = dir.tempDIR + details.name + "_video output.264";

                    switch (encopts.vidQual)
                    {
                        case 0:
                            pass1Arg = "--pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 3.1 --bframes 1 --weightb --direct temporal --deblock 1:1 --subme 1 --partitions none --vbv-bufsize 14000 --vbv-maxrate 17500 --me dia " + extra + " --output";
                            pass2Arg = "--pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 3.1 --bframes 1 --weightb --direct temporal --deblock 1:1 --partitions p8x8,b8x8,i4x4 --vbv-bufsize 14000 --vbv-maxrate 17500 " + extra + " --output";
                            break;

                        case 1:
                            pass1Arg = "--pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 4.1 --bframes 2 --b-pyramid --weightb --direct auto --deblock 1:1 --subme 1 --partitions none  --vbv-bufsize 14000 --vbv-maxrate 17500 --me dia " + extra + " --output";
                            pass2Arg = "--pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 4.1 --ref 3 --mixed-refs --bframes 2 --b-pyramid --weightb --direct auto --deblock 1:1 --subme 8 --trellis 1 --partitions all  --8x8dct --vbv-bufsize 14000 --vbv-maxrate 17500 --me umh " + extra + " --output";
                            break;

                        case 2:
                            pass1Arg = "--pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --bframes 3 --b-adapt 1 --b-pyramid --weightb --direct auto --deblock 1:1 --subme 1 --partitions none --vbv-bufsize 14000 --vbv-maxrate 17500 --me dia " + extra + " --output";
                            pass2Arg = "--pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --ref 5 --mixed-refs --bframes 3 --b-adapt 1 --b-pyramid --weightb --direct auto --deblock 1:1 --subme 8 --trellis 1 --partitions all --8x8dct --vbv-bufsize 14000 --vbv-maxrate 17500 --me umh " + extra + " --output";
                            break;

                        case 3:
                            pass1Arg = "--pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --tune animation --bframes 8 --b-adapt 2 --b-pyramid --weightb --direct auto --deblock 1:2 --psy-rd 0.8:0 --aq-mode 0 --merange 32 --scenecut 45 --no-mbtree " + extra + " --subme 2 --partitions none --me dia --output";
                            pass3Arg = "--pass 3 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --tune animation --bframes 8 --b-adapt 2 --b-pyramid --weightb --direct auto --deblock 1:2 --psy-rd 0.8:0 --aq-mode 0 --merange 32 --scenecut 45 --no-mbtree " + extra + " --subme 2 --partitions none --me dia --output";
                            pass2Arg = "--pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --tune animation --ref 8 --mixed-refs --no-fast-pskip --bframes 8 --b-adapt 2 --b-pyramid --weightb --direct auto --deblock 1:2 --subme 9 --trellis 2 --psy-rd 0.8:0 --partitions all --8x8dct --aq-mode 0 --me umh --merange 32 --scenecut 45 --no-mbtree " + extra + " --output";
                            break;
                        
                        case 4:
                            pass1Arg = "--pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --ref 8 --mixed-refs --no-fast-pskip --bframes 16 --b-adapt 1 --b-pyramid --direct auto --deblock 3:3 --subme 7 --chroma-qp-offset -2 --trellis 2 --psy-rd 0.6:0 --partitions all --8x8dct --aq-mode 0 --me umh --merange 16 --scenecut 40 --no-mbtree " + extra + " --output";
                            pass2Arg = "--pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --ref 8 --mixed-refs --no-fast-pskip --bframes 16 --b-adapt 1 --b-pyramid --direct auto --deblock 3:3 --subme 7 --chroma-qp-offset -2 --trellis 2 --psy-rd 0.6:0 --partitions all --8x8dct --aq-mode 0 --me umh --merange 16 --scenecut 40 --no-mbtree " + extra + " --output";
                            break;
                  
                        case 5:
                            pass1Arg = "--pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --ref 8 --mixed-refs --no-fast-pskip --bframes 16 --b-adapt 1 --b-pyramid --direct auto --deblock -2:-1 --subme 6 --trellis 1 --psy-rd 1.0:0 --partitions all --8x8dct --weightb --chroma-qp-offset -2 --aq-mode 0 --me umh --merange 16 --scenecut 40 --no-mbtree " + extra + " --output";
                            pass2Arg = "--pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" --level 5.1 --ref 8 --mixed-refs --no-fast-pskip --bframes 16 --b-adapt 1 --b-pyramid --direct auto --deblock -2:-1 --subme 6 --trellis 1 --psy-rd 1.0:0 --partitions all --8x8dct --weightb --chroma-qp-offset -2 --aq-mode 0 --me umh --merange 16 --scenecut 40 --no-mbtree " + extra + " --output";
                            break;

                        case 6:
                            pass1Arg = "--pass 1 --crf " + details.crfValue + " --level 5.1 --ref 5 --mixed-refs --no-fast-pskip --bframes 5 --b-adapt 1 --b-pyramid --direct auto --deblock 1:1 --subme 7 --chroma-qp-offset 0 --trellis 1 --psy-rd 0.0:0 --partitions all --8x8dct --me umh --qcomp 1.0 --merange 16 --scenecut 40 --weightb " + extra + " --output";
                            break;
                        case 7:
                            pass1Arg = "--profile baseline --level 1.3 --preset fast --pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" " + extra + " --output";
                            pass2Arg = "--profile baseline --level 1.3 --preset fast --pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" " + extra + " --aud --output";
                            break;
                        case 8:
                            pass1Arg = "--profile main --level 3 --preset fast --pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" " + extra + " --output"; 
                            pass2Arg = "--profile main --level 3 --preset fast --pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" " + extra + " --aud --output";
                            break;
                        case 9:
                            pass1Arg = "--profile high --level 4.1 --preset fast --pass 1 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" " + extra + " --output";
                            pass2Arg = "--profile high --level 4.1 --preset fast --pass 2 --bitrate " + encopts.vidBR + " --stats \"" + details.statsfile + "\" " + extra + " --aud --output";
                            break;
                    }

                    if(pass2Arg != "")
                        proc.setArguments(pass1Arg + " NUL \"" + details.avsFile + "\"");
                    else
                        proc.setArguments(pass1Arg + " \"" + details.encodedVideo + "\" \"" + details.avsFile + "\"");    //--output ".264" "avs"

                
                    
                   
                    break;

                case 1:
                   
                    if (!xvid_encraw.isInstalled())
                        xvid_encraw.download();
                    proc.setFilename(Path.Combine(xvid_encraw.getInstallPath(), "xvid_encraw.exe"));
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

                    proc.setArguments("-i \"" + details.avsFile + "\" " + pass1Arg + " NUL");
                    
                    break;
              
            }
            tempStart = DateTime.Now;
            proc.setPass(1);
            exitCode = proc.startProcess();
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
            proc.setPass(2);
                proc.setArguments(pass3Arg + " NUL \"" + details.avsFile + "\"");

                exitCode = proc.startProcess();
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
                        proc.setArguments(pass2Arg + " \"" + details.encodedVideo + "\" \"" + details.avsFile + "\"");
                        
                        break;

                    case 1:
                        proc.setArguments("-i \"" + details.avsFile + "\" " + pass2Arg + " \"" + details.encodedVideo + "\"");
                        
                        break;
                }
           
            if (pass3Arg != null)
                proc.setPass(3);
            else
               proc.setPass(2);

            tempStart = DateTime.Now;
           exitCode =  proc.startProcess();
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

      
    }
}
