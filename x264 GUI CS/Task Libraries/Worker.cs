using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using x264_GUI_CS.General;
using MiniCoder.General;
using x264_GUI_CS.Task_Libraries;
using x264_GUI_CS;
using x264_GUI_CS.Containers;
using System.IO;
namespace MiniCoder.Task_Libraries
{
    public class Worker
    {
        ProcessSettings proc;
        FileInformation details;
        LogBook log;
        EncodingOptions encodingOpts;
        ApplicationSettings appSettings;
        mainGUI main;
        public Worker(ProcessSettings proc, LogBook log, EncodingOptions encodingOpts, mainGUI main, ApplicationSettings appSettings)
        {
            this.proc = proc;
            this.log = log;
            this.encodingOpts = encodingOpts;
            this.main = main;
            this.appSettings = appSettings;
        }

        public string encodeFile(FileInformation details)
        {
           
            if (!proc.abandon)
            {
                

                main.setEncoding(true);
                


              
                string[] files = Directory.GetFiles(appSettings.tempDIR);
                try
                {
                    foreach (string file in files)
                        File.Delete(file);
                }
                catch
                {
                    log.addLine("Problems deleting file.");
                }
                main.updateStatus("encoding");


                string fpsTest = details.fps.ToString().Substring(0, 2);
                if (fpsTest != "23" && fpsTest != "29" && fpsTest != "25")
                {
                    log.addLine("Suspecting this file to be VFR.");
                    if (main.isFileVFR())
                        log.addLine("User confirms VFR");
                    else
                    {
                        log.addLine("User does not state this file to be VFR.");
                        // MessageBox.Show("I suspect this file to be VFR, but you have not marked it.");
                    }

                }
                else
                    log.addLine("File passed VFR test, this is Constant Framerate");
                details.vfr = main.isFileVFR();

                if (details.ext == ".mkv" && details.vfr)
                {
                    // log.addLine("User says that the file is VFR (Variable Frame Rate - Using mkv2vfr");

                    if (!proc.abandon)
                    {
                        proc.currProcess = "mkv2vfr";
                        ifContainer ctMKV = new clMKV(log);
                        proc.errflag = ctMKV.mkv2vfr(appSettings, details, proc);

                        if (!proc.errflag)
                        {
                            main.updateStatus("error");
                            log.addLine("Error in VFR Parsing");
                            log.sendmail(details,appSettings);
                            return "Remove";
                        }
                    }
                    else
                    {
                        main.updateStatus("Aborted");
                       // MessageBox.Show("Aborted");
                        return "Aborted";
                    }

                    log.addLine("Reading VFR file");

                   
                    details.vfrCode = appSettings.tempDIR + "timecode.txt";
                    details.vfrName = appSettings.tempDIR + details.name + "-Video Track.avi";

                    IfMediaDetails tempmedia;
                    if (IntPtr.Size == 8)
                        tempmedia = new MediaDetails64();
                    else
                        tempmedia = new MediaDetails32();
                    details.fps = tempmedia.fps(details.vfrName);
                    long tempFrames = tempmedia.frameCount(details.vfrName);
                    if (tempFrames < (details.framecount - (details.framecount / 5)))
                    {
                        log.addLine("Seems atleast 1/5th of the frames has dissapeared during conversion.");
                        log.addLine("Something went wrong.");
                        log.addLine("Remuxing the sourcefile usually solves this problem.");
                    }

                }
                log.addLine("FPS:" + details.fps);
                ifContainer container;

                if (!proc.abandon)
                {

                    proc.currProcess = "demux";
                    switch (details.ext)
                    {
                        case ".wmv":
                            container = new WMV(log);
                            proc.errflag = container.demux(appSettings, details, proc);
                            break;
                        case ".mkv":
                            
                            container = new clMKV(log);
                            proc.errflag = container.demux(appSettings, details, proc);
                            break;
                        case ".ogm":
                            container = new clOGM(log);
                            proc.errflag = container.demux(appSettings, details, proc);
                            break;
                        case ".avi":
                        case ".divx":
                            container = new clAVI(log);
                            proc.errflag = container.demux(appSettings, details, proc);
                            break;
                        case ".mp4":
                            container = new clMP4(log);
                            proc.errflag = container.demux(appSettings, details, proc);
                            break;
                        case ".VOB":
                        case ".vob":
                            container = new VOB(log);
                            proc.errflag = container.demux(appSettings, details, proc);
                            break;
                    }

                    if (!proc.errflag)
                    {
                        main.updateStatus("error");
                        log.addLine("Error demuxing");
                        log.sendmail(details, appSettings);
                       // MessageBox.Show("Demuxing Error");
                        return "Remove";
                    }
                }

                else
                {
                    main.updateStatus("Aborted");
                    //MessageBox.Show("Aborted");
                    return "Aborted";
                }

                if (!proc.abandon)
                {

                    if (details.vid_codec == "x264" || details.vid_codec == "avc1" || details.vid_codec == "H264" || details.vid_codec == "V_MPEG4/ISO/AVC")
                    {
                        if (details.ext != ".avi")
                        {
                            DGAVCIndex avc = new DGAVCIndex(log);
                            proc.errflag = avc.index(appSettings, details, proc);

                            if (!proc.errflag)
                            {
                                main.updateStatus("error");
                                log.sendmail(details, appSettings);
                                //MessageBox.Show("DGAVC Encoding Error");
                                return "Remove";
                            }
                        }
                    }

                }
                else
                {
                   main.updateStatus("Aborted");
                    //MessageBox.Show("Aborted");
                   return "Aborted";
                }



                if (!proc.abandon)
                {
                    Avisynth avs = new Avisynth(log);
                //    encodingOpts.customFilter = customFiltOpts;
                    if (encodingOpts.hardSub != 0)
                        encodingOpts.hardSubLocation = details.demuxSub[encodingOpts.hardSub - 1];

                    string script = avs.createScript(appSettings, details, encodingOpts);
                    avs.writeScript(appSettings, details, script);
                    proc.errflag = avs.checkErrors(details.avsFile, appSettings, proc);

                    if (!proc.errflag)
                    {
                        main.updateStatus("error");
                        log.sendmail(details, appSettings);
                        //MessageBox.Show("Avisynth Error");
                        return "Remove";
                    }
                }
                else
                {
                    main.updateStatus("Aborted");
                    //MessageBox.Show("Aborted");
                    return "Aborted";
                }

                if (!proc.abandon)
                {
                    AudioDecoding dec = new AudioDecoding(log);
                    try
                    {
                        proc.errflag = dec.decode(appSettings, details, proc);
                    }
                    catch
                    {
                        proc.errflag = true;
                    }
                    if (!proc.errflag)
                    {
                         main.updateStatus("error");
                         log.sendmail(details, appSettings);
                        //MessageBox.Show("Audio Decoding Error");
                        return "Remove";
                    }
                }
                else
                {
                    main.updateStatus("Aborted");
                    //MessageBox.Show("Aborted");
                    return "Aborted";
                }

                if (!proc.abandon)
                {
                    AudioEncoding enc = new AudioEncoding(log);
                    proc.errflag = enc.encode(appSettings, details, encodingOpts, proc);

                    if (!proc.errflag)
                    {
                         main.updateStatus("error");
                         log.sendmail(details, appSettings);
                       // MessageBox.Show("Audio Encoding Error");
                        return "Remove";
                    }
                }
                else
                {
                    main.updateStatus("Aborted");
                    //MessageBox.Show("Aborted");
                    return "Aborted";
                }

                if (!proc.abandon)
                {
                    VideoEncoding encvid = new VideoEncoding(log);
                    proc.errflag = encvid.encode(appSettings, encodingOpts, details, proc);

                    if (!proc.errflag)
                    {
                        main.updateStatus("error");
                        log.sendmail(details, appSettings);
                        //MessageBox.Show("Video Encoding Error");
                        return "Remove";
                    }
                }
                else
                {
                     main.updateStatus("Aborted");
                    //MessageBox.Show("Aborted");
                     return "Aborted";
                }

                if (!proc.abandon)
                {
                    Muxing muxOut = new Muxing(log);
                    proc.errflag = muxOut.Mux(appSettings, details, encodingOpts, proc);

                    if (!proc.errflag)
                    {
                        main.updateStatus("error");
                        log.sendmail(details, appSettings);
                        //MessageBox.Show("Muxing Error");
                        return "Remove";
                    }
                }
                else
                {
                     main.updateStatus("Aborted");
                    //MessageBox.Show("Aborted");
                     return "Aborted";
                }

            }

            if (!proc.abandon)
            {
               
                //fileList.RemoveAt(0);
            }
            else
            {
                 main.updateStatus("Aborted");
                //MessageBox.Show("Aborted");
                 return "Aborted";
            }
            try
            {
                string[] files2 = Directory.GetFiles(appSettings.tempDIR);
                foreach (string file in files2)
                    File.Delete(file);
            }
            catch
            {
                log.addLine("Error deleting files!");
            }


            return "Completed";
            //if (!proc.errflag)
            //{
            //   
            //}
            //else
            //{
            //    inputList.Items[fileindex].SubItems[1].Text = "Done";
            //    fileindex++;
            //    log.addLine("It took " + (DateTime.Now - startDate).Hours.ToString() + " hours and " + (DateTime.Now - startDate).Minutes.ToString() + " minutes to encode this file.");
            //    afterEncode();
            //}
        }

       
    }
}
