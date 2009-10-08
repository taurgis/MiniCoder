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
    class clMP4 : ifContainer
    {
        Package mp4box;
        LogBook log;
        ProcessSettings proc;
        int exitCode;

        public clMP4(LogBook log)
        {
            this.log = log;
            proc = new ProcessSettings(log);
        }

        public bool demux(ApplicationSettings dir, FileInformation details, ProcessSettings proc)
        {
            this.proc = proc;
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            try
            {
                mp4box = (Package)dir.htRequired["mp4box"];
                if (!mp4box.isInstalled())
                    mp4box.download();

                log.addLine("Started demuxing MP4 tracks");
                log.setInfoLabel("Demuxing Video Track");
                proc.initProcess();
                
                string path = dir.tempDIR.Substring(0, dir.tempDIR.Length - 1);

                details.demuxAudio = new string[details.audioCount];
                details.demuxSub = new string[details.subCount];
                details.attachments = new string[0];

                proc.setFilename(Path.Combine(mp4box.getInstallPath(), "MP4Box.exe"));
                string tempArg;
                switch (details.vid_codec)
                {
                    case "DIV3":
                    case "XVID":
                    case "DIVX":
                    case "DX50":
                    case "DX60":
                    case "V_MS/VFW/FOURCC":
                    case "20":
                        details.demuxVideo = dir.tempDIR + details.name + "-Video Track.avi";
                        tempArg = "\"" + details.fileName + "\" -avi 1 -out \"" + dir.tempDIR + details.name + "-Video Track\"";
                        break;
                    default:
                        details.demuxVideo = dir.tempDIR + details.name + "-Video Track." + details.extension[details.vid_codec];
                        tempArg = "\"" + details.fileName + "\" -raw 1 -out \"" + dir.tempDIR + details.name + "-Video Track." + details.extension[details.vid_codec] + "\"";
                        break;
                }
                proc.setArguments(tempArg);
                exitCode = proc.startProcess();

                if (exitCode != 0)
                    return false;

                log.addLine(tempArg);
                log.setInfoLabel("Demuxing Audio Track");
                details.demuxAudio[0] = dir.tempDIR + details.name + "-Audio Track-" + "1" + "." + details.extension[details.aud_codec[0]];
                tempArg = "\"" + details.fileName + "\" -raw 2 -out \"" + details.demuxAudio[0] + "\"";
                proc.setArguments(tempArg);
                exitCode = proc.startProcess();

                if (proc.abandon)
                    log.setInfoLabel("Demuxing Aborted");
                else
                    log.setInfoLabel("Demuxing Complete");

                if (exitCode != 0)
                    return false;
                else
                    return true;

            }
            catch (KeyNotFoundException e)
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
