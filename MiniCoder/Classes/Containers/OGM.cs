using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using MiniCoder;
namespace x264_GUI_CS.Containers
{
    class clOGM : ifContainer
    {
        
        ProcessSettings proc;
        
       
        LogBook log;
      

        public clOGM(LogBook log)
        {
            this.log = log;
            proc = new ProcessSettings(log);
        }
        Package ogmtools;

        public bool demux(ApplicationSettings dir, FileInformation details, ProcessSettings proc)
        {
            this.proc = proc;
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            try
            {
                ogmtools = (Package)dir.htRequired["ogmtools"];
                if (!ogmtools.isInstalled())
                    ogmtools.download();

                log.addLine("Started demuxing OGM tracks");
                log.setInfoLabel("Demuxing OGM Tracks");
                proc.initProcess();
                

                string path = dir.tempDIR.Substring(0, dir.tempDIR.Length - 1);

                proc.setFilename(Path.Combine(ogmtools.getInstallPath(), "OGMDemuxer.exe"));
                string tempArg = "tracks \"" + details.fileName + "\" -p " + details.vid_id + ":\"" + dir.tempDIR + details.name + "-Video Track." + details.extension[details.vid_codec] + "\"";

                details.demuxAudio = new string[details.audioCount];
                details.demuxSub = new string[details.subCount];
                details.attachments = new string[0];

                for (int i = 0; i < details.audioCount; i++)
                {
                    details.demuxAudio[i] = dir.tempDIR + details.name + "-Audio Track-" + i.ToString() + "." + details.extension[details.aud_codec[i]];
                    tempArg += " " + details.aud_id[i] + ":\"" + details.demuxAudio[i] + "\"";
                }

                for (int i = 0; i < details.subCount; i++)
                {
                    details.demuxSub[i] = dir.tempDIR + details.name + "-Subtitle Track-" + i.ToString() + "." + details.extension[details.sub_codec[i]];
                    tempArg += " " + details.sub_id[i] + ":\"" + details.demuxSub[i] + "\"";
                }
                log.addLine(tempArg);
                proc.setArguments(tempArg);
                //MessageBox.Show(mainProcess.StartInfo.Arguments);

                proc.startProcess();

                if (proc.abandon)
                    log.setInfoLabel("Demuxing Complete");
                else
                    log.setInfoLabel("Demuxing Aborted");

                if (File.Exists(dir.tempDIR + details.name + "-Video Track." + details.extension[details.vid_codec]))
                    return true;
                else
                    return false;
                                                
            }
            catch(KeyNotFoundException e)
            {
                log.addLine("Can't find codec " + e.Message);
                MessageBox.Show("Can't find codec");
                return false;
            }

        }
       
        public bool mkv2vfr(ApplicationSettings dir, FileInformation details, ProcessSettings proc)
        {
            return true;
        }
    }
}
