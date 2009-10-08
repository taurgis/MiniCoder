using System;
using System.Collections.Generic;
using MiniCoder.General;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using MiniCoder;
namespace x264_GUI_CS.Task_Libraries
{
    class AudioDecoding
    {
        Package flac;
        Package oggdec;
        Package ffmpeg;
        Package faad;
        Package madplay;
        Package valdec;
   
        General.ProcessSettings proc;
       
        LogBook log;

        public AudioDecoding(LogBook log)
        {
            this.log = log;
            
        }

        public bool decode(ApplicationSettings dir, General.FileInformation details, General.ProcessSettings proc)
        {
            this.proc = proc;
            proc.stdErrDisabled(true);
            proc.stdOutDisabled(false);
            flac = (Package)dir.htRequired["flac"];
            madplay = (Package)dir.htRequired["madplay"];
            faad = (Package)dir.htRequired["faad"];
            oggdec = (Package)dir.htRequired["oggdec"];
            valdec = (Package)dir.htRequired["valdec"];
            ffmpeg = (Package)dir.htRequired["ffmpeg"];
            //mainProcess = new Process();
            proc.initProcess();
            log.addLine("Decoding Audio");
            log.setInfoLabel("Decoding Audio");

            details.decodedAudio=new string[details.audioCount];

            for (int i = 0; i < details.demuxAudio.Length; i++)
            {
                details.decodedAudio[i] = dir.tempDIR + details.name + "-Decoded Audio Track-" + i.ToString() + ".wav";
                string ext = details.extension[details.aud_codec[i]];

                switch (ext)
                {
                    case "wma":
                        if (!ffmpeg.isInstalled())
                            ffmpeg.download();
                        proc.setFilename(Path.Combine(ffmpeg.getInstallPath(), "ffmpeg.exe"));
                        proc.setArguments("-i \"" + details.fileName + "\" -f wav -y \"" + details.decodedAudio[i] + "\"");
                      
                        break;
                    case "flac":
                        if (!flac.isInstalled())
                            flac.download();
                         proc.setFilename(Path.Combine(flac.getInstallPath(), "flac.exe"));
                        proc.setArguments("-d -o \"" + details.decodedAudio[i] + "\" \"" + details.demuxAudio[i] + "\"");
                        break;

                    case "ac3":
                    case "dts":
                        if (!valdec.isInstalled())
                            valdec.download();
                         proc.setFilename(Path.Combine(valdec.getInstallPath(), "valdec.exe"));
                       proc.setArguments("\"" + details.demuxAudio[i] + "\" -w \"" + details.decodedAudio[i] + "\" -spk:2");
                        break;

                    case "ogg":
                        if (!oggdec.isInstalled())
                            oggdec.download();
                         proc.setFilename(Path.Combine(oggdec.getInstallPath(), "oggdec.exe"));
                       proc.setArguments("-m -w \"" + details.decodedAudio[i] + "\" \"" + details.demuxAudio[i] + "\"");
                        break;

                    case "aac":
                    case "mp4":
                        if (!faad.isInstalled())
                            faad.download();
                         proc.setFilename(Path.Combine(faad.getInstallPath(), "faad.exe"));
                        proc.setArguments("-d -o \"" + details.decodedAudio[i] + "\" \"" + details.demuxAudio[i] + "\"");
                        break;

                    case "mp2":
                    case "mp3":
                        if (!madplay.isInstalled())
                            madplay.download();
                        proc.setFilename(Path.Combine(madplay.getInstallPath(), "madplay.exe"));
                        proc.setArguments("-S -o wave:\"" + details.decodedAudio[i] + "\" \"" + details.demuxAudio[i] + "\"");
                        break;

                    default:
                        if (!ffmpeg.isInstalled())
                            ffmpeg.download();
                         proc.setFilename(Path.Combine(ffmpeg.getInstallPath(), "ffmpeg.exe"));
                        proc.setArguments("-i \"" + details.fileName + "\" -f wav -y \"" + details.decodedAudio[i] + "\"");
                        
                        break;
                }

                proc.startProcess();
                
            }

            log.addLine("Decoded Audio");
            log.setInfoLabel("Decoded Audio");

            
            
            foreach (string file in details.decodedAudio)
            {
              if(!File.Exists(file))
                {
                    return false;
                   
                }
            }
            return true;
        }

      
    }
}
