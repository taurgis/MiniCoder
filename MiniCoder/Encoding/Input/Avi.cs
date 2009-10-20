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
            LogBook.addLogLine("Demuxing AVI - Using Vdubmod", fileDetails["name"][0] + "DeMuxing", fileDetails["name"][0] + "DeMuxingProcess", false);
            MiniProcess proc = new DefaultProcess("Demuxing Avi", fileDetails["name"][0] + "DeMuxingProcess");
            processWatcher.setProcess(proc);

            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            try
            {

                if (!vdubmod.isInstalled())
                    vdubmod.download();

                LogBook.setInfoLabel("Demuxing AVI Tracks");
        
                proc.initProcess();

                LogBook.addLogLine("Writing VirtualDub Script", fileDetails["name"][0] + "DeMuxing", fileDetails["name"][0] + "VdubScript",false);

                StreamWriter vcf = File.CreateText(tempPath + fileDetails["name"][0] + "_demux.vcf"); ;
                string temp = "VirtualDub.Open(\"" + fileDetails["fileName"][0].Replace("\\", "\\\\") + "\",\"\",0);\r\n";
                

                tracks["video"][0].demuxPath = fileDetails["fileName"][0];

                for (int i = 0; i < tracks["audio"].Length; i++)
                {
                    tracks["audio"][i].demuxPath = tempPath + fileDetails["name"][0] + "-Audio Track-" + i.ToString() + "." + Codec.getExtention(tracks["audio"][i].codec);
                    temp += ("VirtualDub.stream[" + i.ToString() + "].Demux(\"" + tracks["audio"][i].demuxPath.Replace("\\", "\\\\") + "\");");
                }
              
                LogBook.addLogLine(temp, fileDetails["name"][0] + "VdubScript","",false);
                vcf.WriteLine(temp);
                vcf.Close();
           
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
                try
                {
                    if (File.Exists(tempPath + fileDetails["name"][0] + "-Audio Track-0." + Codec.getExtention(tracks["audio"][0].codec)))
                        return true;
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
            catch (KeyNotFoundException e)
            {
                LogBook.addLogLine("Can't find codec " + e.Message, fileDetails["name"][0] + "DeMuxing","",true);
                MessageBox.Show("Can't find codec " + fileDetails["aud_codec"][0], "");
                return false;
            }
        }
    }
}
