using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.External;
using MiniCoder.Encoding.Process_Management;
using System.IO;
using MiniCoder.Encoding.Input.Tracks;
using System.Windows.Forms;

namespace MiniCoder.Encoding.Sound.Decoding
{
    class Ffmpeg : MiniDecoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";

        public Ffmpeg()
        {
            
        }

        public Boolean decode(Tool ffmpeg, SortedList<String, String[]> fileDetails, int i, Track audio, ProcessWatcher processWatcher)
        {
            try
            {
                MiniProcess proc = new DefaultProcess("Decoding Audio Track (ID = " + (i) + ")", fileDetails["name"][0] + "AudioDecodingProcess");
                processWatcher.setProcess(proc);
                proc.initProcess();
                // // LogBook.addLogLine(""Decoding Audio",1);
                LogBook.setInfoLabel("Decoding Audio");
                LogBook.addLogLine("Decoding Unknown - Using FFMpeg", fileDetails["name"][0] + "AudioDecoding", fileDetails["name"][0] + "AudioDecodingProcess", false);

                String decodedAudio = tempPath + fileDetails["name"][0] + "-Decoded Audio Track-" + i.ToString() + ".wav";

                if (!ffmpeg.isInstalled())
                    ffmpeg.download();
                proc.setFilename(Path.Combine(ffmpeg.getInstallPath(), "ffmpeg.exe"));
                proc.setArguments("-i \"" + fileDetails["fileName"][0] + "\" -f wav -y \"" + decodedAudio + "\"");

                int exitCode = proc.startProcess();
                if (proc.getAbandonStatus())
                    return false;

                if (exitCode != 0)
                    return false;
                audio.demuxPath = decodedAudio;
                LogBook.addLogLine("Decoding Complete", fileDetails["name"][0] + "AudioDecoding", "", false);

                return true;
            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error decoding audio with FFmpeg. (" + error + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
