using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using System.Text.RegularExpressions;
using x264_GUI_CS;
using x264_GUI_CS.Containers;
using System.IO;
namespace MiniCoder
{
    public class Worker
    {
        ProcessSettings proc;
        String encodingStatus;
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
            Boolean isAvs = false;
            if (encodingOpts.vidCodec == 2)
                encodingOpts.skipAudio = true;

            if (!proc.abandon)
            {
                main.setEncoding(true);

                if (!Encoding.DeleteFiles(appSettings))
                    log.addLine("Problems deleting files.");

                main.updateStatus("encoding");

                if (details.ext.Equals(".avs"))
                {
                    isAvs = true;
                    details = AvsDetails(details.fileName, details, encodingOpts);



                }

                //VFR Information & Encoding
                details.vfr = main.isFileVFR();
                encodingStatus = VFRStep(details);

                if (!String.IsNullOrEmpty(encodingStatus))
                    return encodingStatus;

                //Demuxing File
                encodingStatus = DemuxingStep(details);
                if (!String.IsNullOrEmpty(encodingStatus))
                    return encodingStatus;

                if (!isAvs)
                {
                    //AVC Indexing
                    encodingStatus = AVCIndexingStep(details);
                    if (!String.IsNullOrEmpty(encodingStatus))
                        return encodingStatus;
                    if (!(encodingOpts.vidCodec == 2))
                    {
                        //AVISynth Script Generation
                        encodingStatus = AviSynthStep(details);
                        if (!String.IsNullOrEmpty(encodingStatus))
                            return encodingStatus;
                    }
                }
                if (!encodingOpts.skipAudio)
                {
                    //Audio Decoding
                    encodingStatus = AudioDecodingStep(details);
                    if (!String.IsNullOrEmpty(encodingStatus))
                        return encodingStatus;

                    //Audio Encoding
                    encodingStatus = AudioEncodingStep(details);
                    if (!String.IsNullOrEmpty(encodingStatus))
                        return encodingStatus;
                }
                else
                    details.audioCount = 0;


                //Video Encoding
                encodingStatus = VideoEncodingStep(details);
                if (!String.IsNullOrEmpty(encodingStatus))
                    return encodingStatus;

                //muxing
                if(encodingOpts.vidCodec != 2)
                    encodingStatus = MuxingStep(details);
                if (!String.IsNullOrEmpty(encodingStatus))
                    return encodingStatus;


            }
            

            if (proc.abandon)
            {
                main.updateStatus("Aborted");
                
                return "Aborted";
            }

            try
            {
                Encoding.DeleteFiles(appSettings);
            }
            catch (IOException)
            {
                log.addLine("Error deleting files!");
            }


            return "Completed";
     
        }

        private String[] getResize(string avsFile)
        {
              string re1 = "(Resize)";	// Variable Name 1
            string re2 = "(.)";	// Any Single Character 1
            string re3 = "(\\d+)";	// Integer Number 1
            string re4 = "(,)";	// Any Single Character 2
            string re5 = "(\\d+)";	// Integer Number 2
            string re6 = "(.)";	// Any Single Character 3

            Regex r2 = new Regex(re1 + re2 + re3 + re4 + re5 + re6, RegexOptions.IgnoreCase | RegexOptions.Singleline);




            Match m = r2.Match(avsFile);
             
            string[] resize = new string[2];
           
            if (m.Success)
            {
                resize[0] = m.Groups[3].ToString();
                resize[1] = m.Groups[5].ToString();
            }

            return resize;
        }

        private String getAvsSource(string avsFile)
        {
            string re1 = "(Source)";	// Word 1
            string re2 = "(\\()";	// Any Single Character 1
            string re3 = "(\".*?\")";	// Double Quote String 1

            Regex r = new Regex(re1 + re2 + re3, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(avsFile);
            if (m.Success)
            {

                String fqdn1 = m.Groups[3].ToString();
              
                return fqdn1;
            }
            return "";
        }

        private FileInformation AvsDetails(string avsFile, FileInformation details, EncodingOptions encOpts)
        {

            StreamReader streamReader = new StreamReader(details.fileName);
            string txt = streamReader.ReadToEnd();
            streamReader.Close();
            String sourceFile = getAvsSource(txt).Replace("\"", "");
            String[] fileResolution = getResize(txt);

            IfMediaDetails temp;
            if (IntPtr.Size == 8)
                temp = new MediaDetails64();
            else
                temp = new MediaDetails32();

            FileInformation tempInformation = Encoding.mediainfo(sourceFile, details.crfValue);

            tempInformation.avsFile = details.fileName;
            if(!String.IsNullOrEmpty(fileResolution[0]))
            {
            encOpts.resizeHeight = int.Parse(fileResolution[1]);
            encOpts.resizeWidth = int.Parse(fileResolution[0]);
            tempInformation.muxheight = encOpts.resizeHeight;
            tempInformation.muxwidth = encOpts.resizeWidth;
            }
            //tempInformation.outDIR = details.outDIR;
            
            
            return tempInformation;
            


        }

        private String VFRStep(FileInformation details)
        {
            if (details.ext == ".mkv" && details.vfr)
            {
                // log.addLine("User says that the file is VFR (Variable Frame Rate - Using mkv2vfr");

                if (!proc.abandon)
                {
                    proc.currProcess = "mkv2vfr";
                    ifContainer ctMKV = new clMKV(log, encodingOpts);
                    proc.errflag = ctMKV.mkv2vfr(appSettings, details, proc);

                    if (!proc.errflag)
                    {
                        main.updateStatus("error");
                        log.addLine("Error in VFR Parsing");
                        log.sendmail(details, appSettings);
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
            return "";
        }

        private String DemuxingStep(FileInformation details)
        {
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

                        container = new clMKV(log, encodingOpts);
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

            return "";
        }

        private String AVCIndexingStep(FileInformation details)
        {
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
            return "";
        }

        private String AviSynthStep(FileInformation details)
        {
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
            return "";
        }

        private String AudioDecodingStep(FileInformation details)
        {
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
            return "";
        }

        private String AudioEncodingStep(FileInformation details)
        {
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
            return "";
        }

        private String VideoEncodingStep(FileInformation details)
        {
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

            return "";
        }

        private String MuxingStep(FileInformation details)
        {
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
            return "";
        }

    }
}
