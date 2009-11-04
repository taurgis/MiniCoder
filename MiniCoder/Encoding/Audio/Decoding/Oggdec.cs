using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.External;
using MiniCoder.Encoding.Process_Management;
using System.IO;
using MiniCoder.Encoding.Input.Tracks;
using System.Windows.Forms;
using MiniCoder.Core.Languages;

namespace MiniCoder.Encoding.Sound.Decoding
{
    class Oggdec : MiniDecoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";

        public Oggdec()
        {
            
        }

        public Boolean decode(Tool oggdec, SortedList<String, String[]> fileDetails, int i, Track audio, ProcessWatcher processWatcher)
        {
            try
            {
                MiniProcess proc = new DefaultProcess("Decoding Audio Track (ID = " + (i) + ")", fileDetails["name"][0] + "AudioDecodingProcess");
                SysLanguage language = MiniSystem.getLanguage();
                processWatcher.setProcess(proc);
                proc.initProcess();
                proc.stdErrDisabled(true);
                proc.stdOutDisabled(true);
                LogBook.addLogLine("Decoding OGG - Using oggdec", fileDetails["name"][0] + "AudioDecoding", fileDetails["name"][0] + "AudioDecodingProcess", false);

                LogBook.setInfoLabel(language.audioDecodingMessage);

                String decodedAudio = tempPath + fileDetails["name"][0] + "-Decoded Audio Track-" + i.ToString() + ".wav";

                if (!oggdec.isInstalled())
                    oggdec.download();
                proc.setFilename(Path.Combine(oggdec.getInstallPath(), "oggdec.exe"));
                proc.setArguments("-m -w \"" + decodedAudio + "\" \"" + audio.demuxPath + "\"");

                int exitCode = proc.startProcess();
                if (proc.getAbandonStatus())
                    return false;

                if (exitCode != 0)
                    return false;
                audio.demuxPath = decodedAudio;
                LogBook.addLogLine("Decoding completed", fileDetails["name"][0] + "AudioDecoding", "", false);

                return true;
            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error decoding audio with OggDec. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }

        }
    }
}
