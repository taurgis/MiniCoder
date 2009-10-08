using System;
using System.Collections.Generic;
using MiniCoder;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace x264_GUI_CS.Containers
{
    class VOB : ifContainer
    {

        ProcessSettings proc;

        LogBook log;
        int exitCode;

        public VOB(LogBook log)
        {
            this.log = log;
            proc = new ProcessSettings(log);
        }
        Package DGIndex;
        Package virtualDubMod;
        public bool demux(ApplicationSettings dir, FileInformation details, ProcessSettings proc)
        {
            this.proc = proc;
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            try
            {
                DGIndex = (Package)dir.htRequired["DGIndex"];
                if (!DGIndex.isInstalled())
                    DGIndex.download();
                string tempArg;



                log.addLine("Started indexing VOB files");
                log.setInfoLabel("Started indexing VOB files.");
                proc.initProcess();


                string path = dir.tempDIR.Substring(0, dir.tempDIR.Length - 1);

                details.demuxAudio = new string[details.audioCount];
                details.demuxSub = new string[details.subCount];
                details.attachments = new string[0];

                proc.setFilename(Path.Combine(DGIndex.getInstallPath(), "DGIndex.exe"));

                switch (details.vid_codec)
                {
                    default:
                        details.demuxVideo = dir.tempDIR + details.name + "." + details.extension[details.vid_codec];
                        details.demuxAudio = new string[details.audioCount];
                        details.aud_Languages = new string[details.audioCount];
                        details.audTitles = new string[details.audioCount];
                        for (int i = 0; i < details.audioCount; i++)
                        {
                            details.demuxAudio[i] = dir.tempDIR + details.name + " " + "T" + (80 + i) + " 3_2ch" + " " + (Convert.ToInt32(details.audBitrate[i]) / 1000) + "Kbps DELAY 0ms." + details.extension[details.aud_codec[i]];
                            details.aud_Languages[i] = "";
                            details.audTitles[i] = "DVD Audio";

                        }
                        //-SD=< -AIF=<C:\Samurai 7\VIDEO_TS\VTS_03_1.VOB< -OF=<C:\Samurai 7\VIDEO_TS\samurai 7< -exit -hide -OM=1 -TN=80
                        tempArg = "-SD=< -AIF=<" + details.fileName + "< -OF=<" + dir.tempDIR + details.name + "< -exit -hide -OM=2 -TN=80";
                        break;
                }
                proc.setArguments(tempArg);
                exitCode = proc.startProcess();

                DirectoryInfo info = new DirectoryInfo(dir.tempDIR);
                int count = 0;
                foreach (FileInfo fInfo in info.GetFiles())
                {
                    if (fInfo.Extension == ".ac3")
                        details.demuxAudio[count++] = fInfo.FullName;
                }



                if (exitCode != 0)
                    return false;



                //ChapterXtractor
                log.addLine("Started fetching chapters.");
                log.setInfoLabel("Started fetching chapters.");
                proc.initProcess();



                proc.setFilename(Path.Combine(DGIndex.getInstallPath(), "ChapterXtractor.exe"));
                tempArg = "\"" + details.outDIR + details.name.Replace("_1", "_0") + ".IFO\" " + "\"" + dir.tempDIR + "chapters.txt\" -p5 -t1";
                proc.setArguments(tempArg);
                exitCode = proc.startProcess();

                if (exitCode != 0)
                    log.addLine("Error demuxing chapters. None present?");




                //sub extraction
                virtualDubMod = (Package)dir.htRequired["VirtualDubMod"];
                if (!virtualDubMod.isInstalled())
                    virtualDubMod.download();

                log.addLine("Started fetching subs.");
                log.setInfoLabel("Started fetching subs.");

                proc.initProcess();
                details.demuxSub = new string[1];
                details.subCount = 1;

                details.demuxSub[0] = dir.tempDIR + details.name + ".idx";
                details.sub_lang = new string[1];
                details.sub_Titles = new string[1];

                details.sub_lang[0] = "";
                details.sub_Titles[0] = "Dvd Sub";





                StreamWriter streamWriter = new StreamWriter(dir.tempDIR + details.name + ".vobsub");
                streamWriter.WriteLine(details.outDIR + details.name.Replace("_1", "_0") + ".IFO");
                streamWriter.WriteLine(dir.tempDIR + details.name);
                streamWriter.WriteLine("1");
                streamWriter.WriteLine("0");
                streamWriter.WriteLine("ALL");
                streamWriter.WriteLine("CLOSE");
                streamWriter.Close();

                proc.setFilename("C:\\WINDOWS\\system32\\rundll32.exe");
                //    "C:\WINDOWS\system32\rundll32.exe" vobsub.dll,Configure C:\Samurai 7\VIDEO_TS\VTS_03_0.vobsub

                tempArg = "VOBSUB.DLL,Configure " + dir.tempDIR + details.name + ".vobsub";
                

                proc.setArguments(tempArg);
                exitCode = proc.startProcess();



                if (proc.abandon)
                    log.setInfoLabel("Demuxing Aborted");
                else
                    log.setInfoLabel("Demuxing Complete");

                if (exitCode != 0)
                    log.addLine("Errors demuxing subs. None present?");
                else
                    return true;

                return true;
            }
            catch (KeyNotFoundException e)
            {
                log.addLine("Can't find codec " + e.Message + ":" + details.vid_codec + details.aud_codec[0]);
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
