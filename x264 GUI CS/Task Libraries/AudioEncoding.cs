using System;
using System.Collections.Generic;
using MiniCoder.General;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MiniCoder;
namespace x264_GUI_CS.Task_Libraries
{
    class AudioEncoding
    {
        Package besweet;
    
      
        General.ProcessSettings proc;
        bool finishedTask = false;
        LogBook log;
        
       
        int exitCode;

        public AudioEncoding(LogBook log)
        {
            this.log = log;
            proc = new General.ProcessSettings(log);
        }

        public bool encode(ApplicationSettings dir, General.FileInformation details, General.EncodingOptions encOpts, General.ProcessSettings proc)
        {
            this.proc = proc;
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            besweet = (Package)dir.htRequired["besweet"];
            proc.setTotalTime(details.audLength);

            log.addLine("Encoding Audio");
            proc.initProcess();
            Avisynth avsAudio = new Avisynth();

            details.encodedAudio = new string[details.audioCount];
            int br = encOpts.audBR;

            proc.setFilename(Path.Combine(besweet.getInstallPath(), "BeSweet.exe"));

            for (int i = 0; i < details.audioCount; i++)
            {
                if (!besweet.isInstalled())
                    besweet.download();

                switch (encOpts.audCodec)
                {
                    case 0:
                        details.encodedAudio[i] = dir.tempDIR + Path.GetFileNameWithoutExtension(details.demuxAudio[i]) + "_output.mp4";
                        proc.setArguments("-core( -input \"" + details.decodedAudio[i] + "\" -output \"" + details.encodedAudio[i] + "\" ) -azid( -s stereo -c normal -L -3db ) -bsn( -2ch -abr " + br.ToString() + " -codecquality_high ) -ota( -g max )");
                        break;                        

                    case 1:                       
                        details.encodedAudio[i] = dir.tempDIR + Path.GetFileNameWithoutExtension(details.demuxAudio[i]) + "_output.ogg";
                        proc.setArguments("-core( -input \"" + details.decodedAudio[i] + "\" -output \"" + details.encodedAudio[i] + "\" ) -azid( -s stereo -c normal -L -3db ) -ota( -hybridgain ) -ogg( -b " + br.ToString() + " )");
                        break;
                }

                if (proc.abandon)
                    return true;

                int exitcode = proc.startProcess();
                    
                

            }
            if (exitCode != 0)
            {
                return false;
            }
            else
            {
                log.addLine("Encoded Audio");
                return true;
            }
           

        }

       
    }
}
