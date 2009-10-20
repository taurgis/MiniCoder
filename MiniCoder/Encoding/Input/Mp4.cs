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
    class Mp4 : InputFile
    {
        String tempPath = Application.StartupPath + "\\temp\\";
     //   SortedList<String, String[]> fileDetails = new SortedList<string, string[]>();

        public Mp4()
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

        public Boolean demux(Tool mp4box, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
            LogBook.addLogLine("Demuxing MP4 - Using mp4box", fileDetails["name"][0] + "DeMuxing", fileDetails["name"][0] + "DeMuxingProcess", false);

            int exitCode = 0;
            MiniProcess proc = new DefaultProcess("Demuxing MP4", fileDetails["name"][0] + "DeMuxingProcess");
           processWatcher.setProcess(proc);
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            try
            {
               
                if (!mp4box.isInstalled())
                    mp4box.download();

           
                LogBook.setInfoLabel("Demuxing Video Track");
                proc.initProcess();

              
             

                proc.setFilename(Path.Combine(mp4box.getInstallPath(), "MP4Box.exe"));
                string tempArg;
                switch (tracks["video"][0].codec)
                {
                    case "DIV3":
                    case "XVID":
                    case "DIVX":
                    case "DX50":
                    case "DX60":
                    case "V_MS/VFW/FOURCC":
                    case "20":
                        tracks["video"][0].demuxPath = tempPath + fileDetails["name"][0] + "-Video Track.avi";
                        tempArg = "\"" + fileDetails["fileName"][0] + "\" -avi 1 -out \"" + tempPath + fileDetails["name"][0] + "-Video Track\"";
                        break;
                    default:
                        tracks["video"][0].demuxPath = tempPath + fileDetails["name"][0] + "-Video Track." + Codec.getExtention(tracks["video"][0].codec);
                        tempArg = "\"" + fileDetails["fileName"][0] + "\" -raw 1 -out \"" + tempPath + fileDetails["name"][0] + "-Video Track." + Codec.getExtention(tracks["video"][0].codec) + "\"";
                        break;
                }
                proc.setArguments(tempArg);
                exitCode = proc.startProcess();
                if (proc.getAbandonStatus())
                    return false;
                if (exitCode != 0)
                    return false;


                LogBook.setInfoLabel("Demuxing Audio Track");
                tracks["audio"][0].demuxPath = tempPath + fileDetails["name"][0] + "-Audio Track-" + "1" + "." + Codec.getExtention(tracks["audio"][0].codec);
                tempArg = "\"" + fileDetails["fileName"][0] + "\" -raw 2 -out \"" + tracks["audio"][0].demuxPath + "\"";
                proc.setArguments(tempArg);
                exitCode = proc.startProcess();

                if (proc.getAbandonStatus())
                    LogBook.setInfoLabel("Demuxing Aborted");
                else
                    LogBook.setInfoLabel("Demuxing Complete");

                if (exitCode != 0)
                    return false;
                else
                    return true;

            }
            catch (KeyNotFoundException e)
            {
                LogBook.addLogLine("Can't find codec " + e.Message, fileDetails["name"][0] + "DeMuxing","",true);
               // MessageBox.Show("Can't find codec");
                return false;
            }
        }
    }
}
