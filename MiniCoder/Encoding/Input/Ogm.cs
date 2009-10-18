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
    class Ogm : InputFile
    {
        String tempPath = Application.StartupPath + "\\temp\\";
     //   SortedList<String, String[]> fileDetails = new SortedList<string, string[]>();

        public Ogm()
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

        public Boolean demux(Tool ogmtools, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
           MiniProcess proc = new DefaultProcess("Demuxing OGM");
           processWatcher.setProcess(proc);
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            try
            {
             
                if (!ogmtools.isInstalled())
                    ogmtools.download();

                LogBook.addLogLine("Started demuxing OGM tracks",1);
                LogBook.setInfoLabel("Demuxing OGM Tracks");
                proc.initProcess();


              

                proc.setFilename(Path.Combine(ogmtools.getInstallPath(), "OGMDemuxer.exe"));
                string tempArg = "tracks \"" + fileDetails["fileName"][0] + "\" -p " + tracks["video"][0].id + ":\"" + tempPath + fileDetails["name"][0] + "-Video Track." + Codec.getExtention(tracks["video"][0].codec) + "\"";


                for (int i = 0; i < tracks["audio"].Length; i++)
                {
                    tracks["audio"][i].demuxPath = tempPath + fileDetails["name"][0] + "-Audio Track-" + i.ToString() + "." + Codec.getExtention(tracks["audio"][i].codec);
                    tempArg += " " + tracks["audio"][i].id + ":\"" + tracks["audio"][i].demuxPath + "\"";
                }

                for (int i = 0; i < tracks["subs"].Length; i++)
                {
                    tracks["subs"][i].demuxPath = tempPath + fileDetails["name"][0] + "-Subtitle Track-" + i.ToString() + "." + Codec.getExtention(tracks["subs"][i].codec);
                    tempArg += " " + tracks["subs"][i].id + ":\"" + tracks["subs"][i].demuxPath + "\"";
                }
                LogBook.addLogLine(tempArg,1);
                proc.setArguments(tempArg);
                //MessageBox.Show(mainProcess.StartInfo.Arguments);

                proc.startProcess();

                if (proc.getAbandonStatus())
                {
                    LogBook.setInfoLabel("Demuxing Aborted");
                    return false;
                }
                else
                    LogBook.setInfoLabel("Demuxing Complete");
                

                if (File.Exists(tempPath + fileDetails["name"][0] + "-Video Track." + Codec.getExtention(tracks["video"][0].codec)))
                    return true;
                else
                    return false;

            }
            catch (KeyNotFoundException e)
            {
                LogBook.addLogLine("Can't find codec " + e.Message, 1, "");
                MessageBox.Show("Can't find codec");
                return false;
            }
        }
    }
}
