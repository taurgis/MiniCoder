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
    class Vorbis : MiniEncoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public Vorbis()
        {

        }

        public bool encode(Tool besweet, SortedList<String, String[]> fileDetails, int i, Track audio, SortedList<String, String> EncOpts, ProcessWatcher processWatcher)
        {
            MiniProcess proc = new AudioProcess(fileDetails["audLength"][0], "Encoding Audio Track (ID = " + (i) + ")");
                processWatcher.setProcess(proc);
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
           
            

            LogBook.addLogLine("Encoding Audio",1);
            proc.initProcess();
           

          
            

            proc.setFilename(Path.Combine(besweet.getInstallPath(), "BeSweet.exe"));

         
                if (!besweet.isInstalled())
                    besweet.download();


                audio.encodePath = tempPath + Path.GetFileNameWithoutExtension(audio.demuxPath) + "_output.ogg";
                proc.setArguments("-core( -input \"" + audio.demuxPath + "\" -output \"" + audio.encodePath + "\" ) -azid( -s stereo -c normal -L -3db ) -ota( -hybridgain ) -ogg( -b " + EncOpts["audbr"] + " )");
                      

                    

                if (proc.getAbandonStatus())
                    return false;

               int exitCode = proc.startProcess();



           
            if (exitCode != 0 && exitCode != -1073741819)
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
