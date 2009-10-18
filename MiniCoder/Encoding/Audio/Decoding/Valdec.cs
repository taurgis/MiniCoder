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
            MiniProcess proc = new DefaultProcess("Decoding Audio Track (ID = " + (i) + ")");
            processWatcher.setProcess(proc);
            proc.initProcess();
            LogBook.addLogLine("Decoding Audio",1);
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

            return true;
        }
    }
}
