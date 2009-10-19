using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.External;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.Encoding.Process_Management;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
namespace MiniCoder.Encoding.Sound.Encoding
{
    class NeroAac : MiniEncoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public NeroAac()
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


            if (!File.Exists(besweet.getInstallPath() + "neroAacEnc.exe"))
              {
                  MessageBox.Show("Due to licensing we are not allowed to put Nero AAC in the package automaticly.\r\nPlease download Nero Aac and put it in the folder about to open.('NeroAacEnc.exe' directly in Besweet folder.)");
                  Process.Start("http://www.nero.com/eng/downloads-nerodigital-nero-aac-codec.php");
                  Process.Start(besweet.getInstallPath());
              }

          
            

            proc.setFilename(Path.Combine(besweet.getInstallPath(), "BeSweet.exe"));

         
                if (!besweet.isInstalled())
                    besweet.download();


                audio.encodePath = tempPath + Path.GetFileNameWithoutExtension(audio.demuxPath) + "_output.mp4";
                proc.setArguments("-core( -input \"" + audio.demuxPath + "\" -output \"" + audio.encodePath + "\" ) -azid( -s stereo -c normal -L -3db ) -bsn( -2ch -abr " + EncOpts["audbr"] + " -codecquality_high ) -ota( -g max )");
                     

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
