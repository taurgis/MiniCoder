using System;
using System.Collections.Generic;
using MiniCoder.General;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using MiniCoder;
namespace x264_GUI_CS.Task_Libraries
{
    class Muxing
    {
        
        LogBook log;
        General.ProcessSettings proc;
        bool finishedTask = false;
        
        Package mkvtoolnix;
        Package mp4box;
      
        
        public Muxing(LogBook log)
        {
            this.log = log;
            proc = new x264_GUI_CS.General.ProcessSettings(log);
        }

        public bool Mux(ApplicationSettings dir, General.FileInformation details, General.EncodingOptions encOpts, General.ProcessSettings proc)
        {
            this.proc = proc;
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            mkvtoolnix = (Package)dir.htRequired["mkvtoolnix"];
            mp4box = (Package)dir.htRequired["mp4box"];

            proc.initProcess();
            log.addLine("Muxing");
            string args;

            try
            {
                float dar = details.muxwidth / details.muxheight;
                float par = details.width / details.height;

                if (dar != par & encOpts.filtResize != 0)
                {
                    details.muxheight = encOpts.resizeHeight;
                    details.muxwidth = (int)(encOpts.resizeHeight * dar);
                }
            }
            catch
            {
                details.muxheight = details.height;
                details.muxwidth = details.width;
            }
                
            
            details.outFile = details.outDIR + details.name + "_output";

            switch (encOpts.containerFormat)
            {
                case 0:
                    if (!mkvtoolnix.isInstalled())
                        mkvtoolnix.download();
                   proc.setFilename(Path.Combine(mkvtoolnix.getInstallPath(), "mkvmerge.exe"));
                    details.outFile += ".mkv";

                    string arg1 = "";

                    if (details.vfr && File.Exists(details.vfrCode))
                        arg1 += "--timecodes 0:\"" + details.vfrCode + "\" ";

                    if(!encOpts.advert)
                    arg1 += "--title \"Encoded with MiniCoder\" ";

                    if (File.Exists(dir.tempDIR + "chapters.xml"))
                        arg1 += "--chapters \"" + dir.tempDIR + "chapters.xml\" ";

                    if (File.Exists(dir.tempDIR + "chapters.txt"))
                        arg1 += "--chapters \"" + dir.tempDIR + "chapters.txt\" ";

                    if (details.fps > 400)
                        args = "-o \"" + details.outFile + "\" --default-duration 0:" + details.fps.ToString().Replace(".0", "").Substring(0, 2) + "." + details.fps.ToString().Replace(".0", "").Substring(2, details.fps.ToString().Replace(".0", "").Length - 2) + "fps --display-dimensions 0:" + details.muxwidth.ToString() + "x" + details.muxheight.ToString() + " " + arg1 + "-d 0 -A -S \"" + details.encodedVideo + "\" ";
                    else
                        args = "-o \"" + details.outFile + "\" --default-duration 0:" + details.fps + "fps --display-dimensions 0:" + details.muxwidth.ToString() + "x" + details.muxheight.ToString() + " " + arg1 + "-d 0 -A -S \"" + details.encodedVideo + "\" ";

                  


                    for (int i = 0; i < details.audioCount; i++)
                    {
                        if (encOpts.audCodec == 0)
                            args += "--aac-is-sbr 1:1 ";
                        args += "--language 1:" + details.lang[details.aud_Languages[i]] + " --track-name 1:\"" + details.audTitles[i] + "\" -a 1 -D -S \"" + details.encodedAudio[i] + "\" ";
                    }
                   


                    for (int i = 0; i < details.subCount; i++)
                    {
                        args += "--language 0:" + details.lang[details.sub_lang[i]] + " --track-name 0:\"" + details.sub_Titles[i] + "\" -s 0 -A -D \"" + details.demuxSub[i] + "\" ";
                    }

                    if (details.attachments != null)
                    {
                        for (int i = 0; i < details.attachments.Length; i++)
                        {
                            if(File.Exists(dir.tempDIR + details.attachments[i]))
                            args += "--attachment-mime-type application/x-truetype-font --attachment-name \"" + details.attachments[i] + "\" --attach-file \"" + dir.tempDIR + details.attachments[i] + "\" ";
                        }
                    }

                    args += "--track-order 0:0,";

                    for (int i = 0; i < details.audioCount; i++)
                        args += (i + 1).ToString() + ":1,";

                    int step = details.audioCount + 1;

                    for (int i = 0; i < details.subCount; i++)
                        args += (i + step).ToString() + ":0,";

                    

                  

                    log.addLine(args);

                    proc.setArguments(args);
                                            
                    break;
                case 1:
                    if (!mp4box.isInstalled())
                        mp4box.download();
              
                    proc.setFilename(Path.Combine(mp4box.getInstallPath(), "mp4box.exe"));
                    details.outFile += ".mp4";

                   


                    if (details.fps > 400)
                        args = "-fps " + details.fps.ToString().Replace(".0", "").Substring(0, 2) + "." + details.fps.ToString().Replace(".0", "").Substring(2, details.fps.ToString().Replace(".0", "").Length - 2) + " -add \"" + details.encodedVideo + "#video:name=Video\" ";
                    else
                        args = "-fps " + details.fps + " -add \"" + details.encodedVideo + "#video:name=Video\" ";


                    

                    for (int i = 0; i < details.audioCount; i++)
                    {
                        args += "-add \"" + details.encodedAudio[i] + ":lang=" + details.lang[details.aud_Languages[i]] + "\" ";
                    }


                   

                    if (encOpts.hardSub == 0)
                    {
                        for (int i = 0; i < details.subCount; i++)
                        {
                            args += "-add \"" + details.demuxSub[i] + ":lang=" + details.lang[details.sub_lang[i]] + "\" ";

                        }
                    }
                    args += "-new \"" + details.outFile + "\"";

                   
                    log.addLine(args);

                    proc.setArguments(args);

                    break;

            }

            

            if (proc.abandon)
                return true;

            if (proc.startProcess() != 0)
                return false;
            else
            {
                return true;
            }
        }

      
    }
}
