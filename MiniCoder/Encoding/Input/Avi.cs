using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.Encoding.Process_Management;
using MiniCoder.External;
using System.IO;
using System.Windows.Forms;

namespace MiniCoder.Encoding.Input
{
    class Avi : InputFile
    {
        String tempPath = Application.StartupPath + "\\temp\\";
     //   SortedList<String, String[]> fileDetails = new SortedList<string, string[]>();

        public Avi()
        {

        }

        public SortedList<String, Track[]> getTracks()
        {
            return new SortedList<string, Track[]>();
        }

        public void setTempPath(string tempPath)
        {
            this.tempPath = tempPath;
        }

        public Boolean demux(Tool vdubmod, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
            MiniProcess proc = new DefaultProcess("Demuxing Avi");
            processWatcher.setProcess(proc);

            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            try
            {
            
                if (!vdubmod.isInstalled())
                   vdubmod.download();

                LogBook.setInfoLabel("Demuxing AVI Tracks");
                LogBook.addLogLine("Demuxing AVI Tracks", 1);
                proc.initProcess();

                LogBook.addLogLine("Writing VirtualDub Script", 2);

                StreamWriter vcf = File.CreateText(tempPath + fileDetails["name"][0] + "_demux.vcf"); ;
                string temp = "VirtualDub.Open(\"" + fileDetails["fileName"][0].Replace("\\", "\\\\") + "\",\"\",0);\r\n";
                //fileDetails["demuxAudio"] = new string[int.Parse(fileDetails["audioCount"][0])];

                tracks["video"][0].demuxPath = fileDetails["fileName"][0];

                for (int i = 0; i < tracks["audio"].Length; i++)
                {
                  tracks["audio"][i].demuxPath = tempPath + fileDetails["name"][0] + "-Audio Track-" + i.ToString() + "." + Codec.getExtention(tracks["audio"][i].codec);
                  temp += ("VirtualDub.stream[" + i.ToString() + "].Demux(\"" + tracks["audio"][i].demuxPath.Replace("\\", "\\\\") + "\");");
                }
                LogBook.addLogLine("=============== VCF ===============",3);
                LogBook.addLogLine(temp,3);
                vcf.WriteLine(temp);
                vcf.Close();
                LogBook.addLogLine("=============== END ===============",3);
                LogBook.addLogLine("Started demuxing AVI file",1);
                proc.setFilename(Path.Combine(vdubmod.getInstallPath(), "VirtualDubMod.exe"));
                proc.setArguments("/s\"" + tempPath + fileDetails["name"][0] + "_demux.vcf\" /x");

                proc.startProcess();


                if (proc.getAbandonStatus())
                {
                    LogBook.setInfoLabel("Demuxing Aborted");
                    return false;
                }
                else
                    LogBook.setInfoLabel("Demuxing Complete");

                if (File.Exists(tempPath + fileDetails["name"][0] + "-Audio Track-0." + Codec.getExtention(tracks["audio"][0].codec)))
                   return true;
                else
                    return false;
            }
            catch (KeyNotFoundException e)
            {
                LogBook.addLogLine("Can't find codec " + e.Message,2);
                MessageBox.Show("Can't find codec " + fileDetails["aud_codec"][0], "");
                return false;
            }
        }
    }
}
