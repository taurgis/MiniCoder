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
    class Flac : MiniDecoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";

        public Flac()
        {
            
        }

        public Boolean decode(Tool flac, SortedList<String, String[]> fileDetails, int i, Track audio, ProcessWatcher processWatcher)
        {
            MiniProcess proc = new DefaultProcess("Decoding Audio Track (ID = " + (i) + ")");
            processWatcher.setProcess(proc);
            proc.initProcess();
            LogBook.addLogLine("Decoding Audio",1);
            LogBook.setInfoLabel("Decoding Audio");

            String decodedAudio = tempPath + fileDetails["name"][0] + "-Decoded Audio Track-" + i.ToString() + ".wav"; 

            if (!flac.isInstalled())
                flac.download();
            proc.setFilename(Path.Combine(flac.getInstallPath(), "flac.exe"));
            proc.setArguments("-d -o \"" + decodedAudio + "\" \"" + audio.demuxPath + "\"");

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
