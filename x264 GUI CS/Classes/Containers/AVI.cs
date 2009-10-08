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
    class clAVI : ifContainer
    {
       
       
      
        LogBook log = new LogBook();
      
        ProcessSettings proc;

        public clAVI(LogBook log)
        {
            this.log = log;
            proc = new ProcessSettings(log);
        }
        Package vdubmod;
        
        public bool demux(ApplicationSettings dir, FileInformation details, ProcessSettings proc)
        {
            this.proc = proc;
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            try
            {
                vdubmod = (Package)dir.htRequired["VirtualDubMod"];
                if (!vdubmod.isInstalled())
                    vdubmod.download();

                log.setInfoLabel("Demuxing AVI Tracks");
                proc.initProcess();
                

                log.addLine("Writing VirtulDubMod script");
                StreamWriter vcf = File.CreateText(dir.tempDIR + details.name + "_demux.vcf"); ;
                string temp = "VirtualDub.Open(\"" + details.fileName.Replace("\\", "\\\\") + "\",\"\",0);\r\n";
                details.demuxAudio = new string[details.audioCount];

                for (int i = 0; i < details.audioCount; i++)
                {
                    details.demuxAudio[i] = dir.tempDIR + details.name + "-Audio Track-" + i.ToString() + "." + details.extension[details.aud_codec[i]];
                    temp += ("VirtualDub.stream[" + i.ToString() + "].Demux(\"" + details.demuxAudio[i].Replace("\\", "\\\\") + "\");");
                }
                log.addLine("=============== VCF ===============");
                details.demuxSub = new string[details.subCount];
                details.attachments = new string[0];
                log.addLine(temp);
                vcf.WriteLine(temp);
                vcf.Close();
                log.addLine("=============== END ===============");
                log.addLine("Started demuxing AVI file");
                proc.setFilename(Path.Combine(vdubmod.getInstallPath(), "VirtualDubMod.exe"));
                proc.setArguments("/s\"" + dir.tempDIR + details.name + "_demux.vcf\" /x");

                proc.startProcess();
                

                if (proc.abandon)
                    log.setInfoLabel("Demuxing Aborted");
                else
                    log.setInfoLabel("Demuxing Complete");

                if (File.Exists(dir.tempDIR + details.name + "-Audio Track-0." + details.extension[details.aud_codec[0]]))
                    return true;
                else
                    return false;
            }
            catch (KeyNotFoundException e)
            {
                log.addLine("Can't find codec " + e.Message );
                MessageBox.Show("Can't find codec " + details.aud_codec[0]);
                return false;
            }
            
        }

       
        
        public bool mkv2vfr(ApplicationSettings dir, FileInformation details, ProcessSettings proc)
        {
            return true;
        }

   
    }
}
