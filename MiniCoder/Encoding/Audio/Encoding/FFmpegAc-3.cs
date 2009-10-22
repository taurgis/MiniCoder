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
    class FFmpegAc3 : MiniEncoder
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        public FFmpegAc3()
        {

        }

        public bool encode(Tool ffmpeg, SortedList<String, String[]> fileDetails, int i, Track audio, SortedList<String, String> EncOpts, ProcessWatcher processWatcher)
        {
            try
            {
                MiniProcess proc = new DefaultProcess("Encoding Audio Track (ID = " + (i) + ")", fileDetails["name"][0] + "AudioEncodingProcess");
                processWatcher.setProcess(proc);
                proc.stdErrDisabled(false);
                proc.stdOutDisabled(false);

                LogBook.addLogLine("Encoding audio to FFMpeg AC-3", fileDetails["name"][0] + "AudioEncoding", fileDetails["name"][0] + "AudioEncodingProcess", false);

                // // LogBook.addLogLine(""Encoding Audio",1);
                proc.initProcess();





                proc.setFilename(Path.Combine(ffmpeg.getInstallPath(), "ffmpeg.exe"));


                if (!ffmpeg.isInstalled())
                    ffmpeg.download();


                audio.encodePath = tempPath + Path.GetFileNameWithoutExtension(audio.demuxPath) + "_output.ac3";

                //proc.setArguments("-core( -input \"" + audio.demuxPath + "\" -output \"" + audio.encodePath + "\" ) -azid( -s stereo -c normal -L -3db ) -bsn( -2ch -abr " + EncOpts["audbr"] + " -codecquality_high ) -ota( -g max )");
                //-i - -y -acodec ac3 -ab 64k "C:\Documents and Settings\Thomas\My Documents\Smallville.S05E06.WS.DVDRip.XviD-SAiNTS-001.ac3"
                proc.setArguments("-i \"" + audio.demuxPath + "\" -y -acodec ac3 -ab " + EncOpts["audbr"] + "k \"" + audio.encodePath + "\"");

                if (proc.getAbandonStatus())
                    return true;

                int exitCode = proc.startProcess();




                if (exitCode != 0)
                {
                    return false;
                }
                else
                {
                    LogBook.addLogLine("Encoding audio completed", fileDetails["name"][0] + "AudioEncoding", "", false);

                    return true;
                }
            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error encoding audio to FFmpegAc-3. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }
    }
}
