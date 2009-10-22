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
    class Madplay : MiniDecoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";

        public Madplay()
        {
            
        }

        public Boolean decode(Tool madplay, SortedList<String, String[]> fileDetails, int i, Track audio, ProcessWatcher processWatcher)
        {
            try
            {
                MiniProcess proc = new DefaultProcess("Decoding Audio Track (ID = " + (i) + ")", fileDetails["name"][0] + "AudioDecodingProcess");
                proc.stdErrDisabled(true);
                proc.stdOutDisabled(false);
                processWatcher.setProcess(proc);
                proc.initProcess();
                LogBook.addLogLine("Decoding MPEG - Using madplay", fileDetails["name"][0] + "AudioDecoding", fileDetails["name"][0] + "AudioDecodingProcess", false);

                LogBook.setInfoLabel("Decoding Audio");

                String decodedAudio = tempPath + fileDetails["name"][0] + "-Decoded Audio Track-" + i.ToString() + ".wav";

                if (!madplay.isInstalled())
                    madplay.download();
                proc.setFilename(Path.Combine(madplay.getInstallPath(), "madplay.exe"));
                proc.setArguments("-S -o wave:\"" + decodedAudio + "\" \"" + audio.demuxPath + "\"");

                int exitCode = proc.startProcess();
                if (proc.getAbandonStatus())
                    return false;

                if (exitCode != 0)
                    return false;
                audio.demuxPath = decodedAudio;
                LogBook.addLogLine("Decoding Completed", fileDetails["name"][0] + "AudioDecoding", "", false);

                return true;
            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error decoding audio with MadPlay. (" + error.Source + ", " + error.Message + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
