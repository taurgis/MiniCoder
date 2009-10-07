using System;
using System.Collections.Generic;
using MiniCoder.General;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using x264_GUI_CS.General;
using MiniCoder;
namespace x264_GUI_CS.Containers
{
    class WMV : ifContainer
    {
        private static Process mainProcess = null;
        ProcessSettings proc = new ProcessSettings();
        Thread backGround;
        private static StreamReader stdout = null;
        private static StreamReader stderr = null;
        bool finishedTask = false;
        LogBook log;
        int exitCode;

        public WMV(LogBook log)
        {
            this.log = log;
        }
       // Package vdubmod;
        
        public bool demux(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {

            StreamWriter stream = new StreamWriter(dir.tempDIR + details.name + "_audio.avs");
            stream.WriteLine("DirectShowSource(\"" + details.fileName + ", video=false)");
            stream.WriteLine("EnsureVBRMP3Sync()");
            stream.WriteLine("Normalize()");
            stream.Write("return last");
            stream.Close();

            details.demuxAudio = new string[1];
            details.demuxAudio[0] = dir.tempDIR + details.name + "_audio.avs";
            return true;
            //    if (!vdubmod.isInstalled())
            //        vdubmod.download();
            //try
            //{
            //    vdubmod = (Package)dir.htRequired["VirtualDubMod"];
            //    if (!vdubmod.isInstalled())
            //        vdubmod.download();

            //    log.setInfoLabel("Demuxing AVI Tracks");
            //    mainProcess = new Process();

            //    log.addLine("Writing VirtulDubMod script");
            //    StreamWriter vcf = File.CreateText(dir.tempDIR + details.name + "_demux.vcf"); ;
            //    string temp = "VirtualDub.Open(\"" + details.fileName.Replace("\\", "\\\\") + "\",\"\",0);\r\n";
            //    details.demuxAudio = new string[details.audioCount];

            //    for (int i = 0; i < details.audioCount; i++)
            //    {
            //        details.demuxAudio[i] = dir.tempDIR + details.name + "-Audio Track-" + i.ToString() + "." + details.extension[details.aud_codec[i]];
            //        temp += ("VirtualDub.stream[" + i.ToString() + "].Demux(\"" + details.demuxAudio[i].Replace("\\", "\\\\") + "\");");
            //    }
            //    log.addLine("=============== VCF ===============");
            //    details.demuxSub = new string[details.subCount];
            //    details.attachments = new string[0];
            //    log.addLine(temp);
            //    vcf.WriteLine(temp);
            //    vcf.Close();
            //    log.addLine("=============== END ===============");
            //    log.addLine("Started demuxing AVI file");
            //    mainProcess.StartInfo.FileName = Path.Combine(vdubmod.getInstallPath(), "VirtualDubMod.exe");
            //    mainProcess.StartInfo.Arguments = "/s\"" + dir.tempDIR + details.name + "_demux.vcf\" /x";

            //    taskProcess();

            //    if (proc.abandon)
            //        log.setInfoLabel("Demuxing Aborted");
            //    else
            //        log.setInfoLabel("Demuxing Complete");

            //    if (File.Exists(dir.tempDIR + details.name + "-Audio Track-0." + details.extension[details.aud_codec[0]]))
            //        return true;
            //    else
            //        return false;
            //}
            //catch (KeyNotFoundException e)
            //{
            //    log.addLine("Can't find codec " + e.Message );
            //    MessageBox.Show("Can't find codec " + details.aud_codec[0]);
            //    return false;
            //}
            
        }

       
        
        public bool mkv2vfr(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {
            return true;
        }

   
    }
}
