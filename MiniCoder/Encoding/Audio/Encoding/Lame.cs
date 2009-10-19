using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.External;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.Encoding.Process_Management;
using System.IO;
using System.Windows.Forms;

namespace MiniCoder.Encoding.Sound.Encoding
{
    class Lame : MiniEncoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public Lame()
        {

        }

        public bool encode(Tool lame, SortedList<String, String[]> fileDetails, int i, Track audio, SortedList<String, String> EncOpts, ProcessWatcher processWatcher)
        {
            MiniProcess proc = new DefaultProcess("Encoding Audio Track (ID = " + (i) + ")");
            processWatcher.setProcess(proc);
            proc.stdErrDisabled(true);
            proc.stdOutDisabled(false);
           
            

            LogBook.addLogLine("Encoding Audio",1);
            proc.initProcess();





            proc.setFilename(Path.Combine(lame.getInstallPath(), "lame.exe"));


            if (!lame.isInstalled())
                lame.download();


                audio.encodePath = tempPath + Path.GetFileNameWithoutExtension(audio.demuxPath) + "_output.mp3";
               // --abr 128 -h - "C:\Documents and Settings\Thomas\My Documents\Smallville.S05E06.WS.DVDRip.XviD-SAiNTS-001.mp3"
              //    proc.setArguments("-i \"" + audio.demuxPath + "\" -y -acodec ac3 -ab " + EncOpts["audbr"] + "k \"" + audio.encodePath + "\"");
            proc.setArguments("--abr " +  EncOpts["audbr"] + " -h \"" + audio.demuxPath + "\" \"" + audio.encodePath + "\"");
                if (proc.getAbandonStatus())
                    return true;

               int exitCode = proc.startProcess();



           
            if (exitCode != 0)
            {
                return false;
            }
            else
            {
                LogBook.addLogLine("Encoded Audio",1);
                return true;
            }
        }
    }
}
