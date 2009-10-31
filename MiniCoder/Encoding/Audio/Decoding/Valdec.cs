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
    class Valdec : MiniDecoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";

        public Valdec()
        {
            
        }

        public Boolean decode(Tool valdec, SortedList<String, String[]> fileDetails, int i, Track audio, ProcessWatcher processWatcher)
        {
            try
            {
                MiniProcess proc = new DefaultProcess("Decoding Audio Track (ID = " + (i) + ")", fileDetails["name"][0] + "AudioDecodingProcess");
                processWatcher.setProcess(proc);
                proc.initProcess();
                proc.stdErrDisabled(true);
                proc.stdOutDisabled(true);
                LogBook.addLogLine("Decoding AC3 - Using valdec", fileDetails["name"][0] + "AudioDecoding", fileDetails["name"][0] + "AudioDecodingProcess", false);

                LogBook.setInfoLabel("Decoding Audio");

                String decodedAudio = tempPath + fileDetails["name"][0] + "-Decoded Audio Track-" + i.ToString() + ".wav";

                if (!valdec.isInstalled())
                    valdec.download();
                proc.setFilename(Path.Combine(valdec.getInstallPath(), "valdec.exe"));
                proc.setArguments("\"" + audio.demuxPath + "\" -w \"" + decodedAudio + "\" -spk:2");

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
                LogBook.addLogLine("Error decoding audio with Valdec. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
