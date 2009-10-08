using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using MiniCoder;
using x264_GUI_CS;

namespace MiniCoder
{
    class Avisynth
    {
   
        
        LogBook log;
        Package avs2yuv;
        Package avisynth;
        ProcessSettings proc;
        
        public Avisynth(LogBook log)
        {
            this.log = log;
        }

        public Avisynth()
        {
        }

        public string createScript(ApplicationSettings dir, FileInformation details,EncodingOptions encOpts)
        {
            string script = "";
            string sourceline = "";
            string filters = "";

            switch (details.vid_codec)
            {
                case "DIV3":
                case "XVID":
                case "DIVX":
                case "DX50":
                case "DX60":
                    switch (details.ext)
                    {
                        case ".mkv":
                            sourceline = "AVISource(\"" + details.demuxVideo  + "\", audio=false)";
                            break;
                        case ".ogm":
                            sourceline = "AVISource(\"" + dir.tempDIR + details.name + "-Video Track.avi\", audio=false)";
                            break;
                        case ".avi":
                            sourceline = "AVISource(\"" + details.fileName + "\", audio=false)";
                            break;
                        case ".mp4":
                            sourceline = "AVISource(\"" + dir.tempDIR + details.name + "-Video Track.avi\", audio=false)";
                            break;
                        default:
                            sourceline = "DirectshowSource(\"" + details.fileName + "\")";
                            break;
                    }
                    break;
                case "avc1":
                case "H264":
                case "h264":
                case "V_MPEG4/ISO/AVC":
                case "Intel H.264":
                case "x264":
                    switch (details.ext)
                    {
                        case ".mkv":
                          sourceline = "AVCSource(\"" + details.dgaFile + "\")";
                            break;
                        case ".ogm":
                            sourceline = "AVCSource(\"" + details.dgaFile + "\")";
                            break;
                        case ".avi":
                            sourceline = "AVISource(\"" + details.fileName + "\", audio=false)";
                             break;
                        case ".mp4":
                            sourceline = "AVCSource(\"" + details.dgaFile + "\")";
                            break;
                        default:
                            sourceline = "DirectshowSource(\"" + details.dgaFile + "\")";
                            break;
                    }
                    break;
             case "20":
                    switch(details.ext)
                    {
                        case ".mkv":
                            sourceline = "AVISource(\"" + details.demuxVideo + "\",audio=false)";
                            break;
                        case ".ogm":
                            sourceline = "AVISource(\"" + dir.tempDIR + details.name + "-Video Track.avi\", audio=false)";
                            break;
                        case ".avi":
                            sourceline = "AVISource(\"" + details.fileName + "\",audio=false)";
                            break;
                        case ".mp4":
                            sourceline = "AVISource(\"" + dir.tempDIR + details.name + "-Video Track.avi\", audio=false)";
                            break;
                        default:
                            sourceline = "DirectshowSource(\"" + details.fileName + "\")";
                            break;
                     }
                    break;
             case "":                   
                        switch (details.ext)
                        {

                            default:
                                sourceline = "DGDecode_mpeg2source(\"" + details.demuxVideo + "\", info=3)\r\nColorMatrix(hints=true, threads=0)";
                                break;
                        }
                        break;
                    
                default:
                    switch(details.ext)
                    {
                        case ".mkv":
                            sourceline = "DirectshowSource(\"" + dir.tempDIR + details.name + "-Video Track.avi\")";
                            break;
                        case ".ogm":
                            sourceline = "DirectshowSource(\"" + details.fileName + "\")";
                            break;
                        case ".avi":
                            sourceline = "DirectshowSource(\"" + details.fileName + "\")";
                            break;
                        case ".mp4":
                            sourceline = "DirectshowSource(\"" + details.fileName + "\")";
                            break;
                        default:
                            sourceline = "DirectshowSource(\"" + details.fileName + "\")";
                            break;
                    }
                    break;

              
            }
            log.addLine("================= AVS FILE =================");
            log.addLine(sourceline);
            script += sourceline + "\r\n\r\n";

            filters = addFilters(encOpts, dir);
           
            script += filters;
            log.addLine("================= END AVS ==================");
            return script;
         
        }

        public string addFilters(EncodingOptions encOpts, ApplicationSettings dir)
        {
            Filters filt = new Filters(dir);
            string filtOpts = "";
            if (encOpts.customFilter != "")
            {
                if(encOpts.customFilter.Contains(";;;"))
                    encOpts.customFilter = encOpts.customFilter.Replace(";;;","");

                filtOpts += "# Custom\r\n" + encOpts.customFilter + "\r\n\r\n";
                log.addLine(encOpts.customFilter);
            }       
            filtOpts += "# Field\r\n" + filt.addField(encOpts.filtField) + "\r\n";
            if(filt.addField(encOpts.filtField) != "")
            log.addLine(filt.addField(encOpts.filtField));
            
            filtOpts += "# Resizer\r\n" + filt.addResize(encOpts.filtResize, encOpts.resizeWidth, encOpts.resizeHeight) + "\r\n";
            if (filt.addResize(encOpts.filtResize, encOpts.resizeWidth, encOpts.resizeHeight) != "")
            log.addLine(filt.addResize(encOpts.filtResize, encOpts.resizeWidth, encOpts.resizeHeight));
           
            filtOpts += "# Denoiser\r\n" + filt.addNoise(encOpts.filtNoise) + "\r\n";
            if (filt.addNoise(encOpts.filtNoise) != "")
            log.addLine(filt.addNoise(encOpts.filtNoise));
           
            filtOpts += "# Sharpener\r\n" + filt.addSharp(encOpts.filtSharp) + "\r\n";
            if(filt.addSharp(encOpts.filtSharp) != "")
            log.addLine(filt.addSharp(encOpts.filtSharp));
            

            if (encOpts.subtitle != "")
            {
                filtOpts += "# Subtitle\r\n" + filt.addSub(encOpts.subtitle) + "\r\n\r\n";
                log.addLine(filt.addSub(encOpts.subtitle));
            }

            if (encOpts.hardSub != 0)
            {
                filtOpts += "TextSub(\"" + encOpts.hardSubLocation + "\")";
            }

            return filtOpts;
        }
        public string addFiltersNoLog(EncodingOptions encOpts, ApplicationSettings dir)
        {
            Filters filt = new Filters(dir);
            string filtOpts = "";
            if (encOpts.customFilter != "")
            {
                filtOpts += "# Custom\r\n" + encOpts.customFilter + "\r\n\r\n";
                
            }    
            filtOpts += "# Field\r\n" + filt.addField(encOpts.filtField) + "\r\n";
           
            filtOpts += "# Resizer\r\n" + filt.addResize(encOpts.filtResize, encOpts.resizeWidth, encOpts.resizeHeight) + "\r\n";
            
            filtOpts += "# Denoiser\r\n" + filt.addNoise(encOpts.filtNoise) + "\r\n";
           
            filtOpts += "# Sharpener\r\n" + filt.addSharp(encOpts.filtSharp) + "\r\n";
            
            if (encOpts.subtitle != "")
            {
                filtOpts += "# Subtitle\r\n" + filt.addSub(encOpts.subtitle) + "\r\n\r\n";
            }
            return filtOpts;
        }
        public void writeScript(ApplicationSettings dir, FileInformation details,string avsLine)
        {
            StreamWriter avs;

            avs = File.CreateText(details.avsFile = dir.tempDIR + details.name + ".avs");
            avs.WriteLine(avsLine);

            avs.Close();
        }

        public bool checkErrors(string file, ApplicationSettings dir, ProcessSettings proc)
        {
            this.proc = proc;
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            avs2yuv = (Package)dir.htRequired["avs2yuv"];
            avisynth = (Package)dir.htRequired["avs"];

            if (!avisynth.isInstalled())
                avisynth.download();

            if (!avs2yuv.isInstalled())
                avs2yuv.download();

            proc.initProcess();
            

            log.addLine("Verifying Avisynth script");
            proc.setFilename(Path.Combine(avs2yuv.getInstallPath(), "avs2yuv.exe"));
            proc.setArguments("\"" + file + "\" NUL");

            proc.startProcess();

            string err = log.getLog();

            if (err.Contains("Avisynth error"))
            {
                if (err.Contains("line 1"))
                {
                    MessageBox.Show("Error on this line indicates an AVS error caused by Windows Vista/7 UAC. Please disable UAC and try again!");
                }
                else
                {
                    MessageBox.Show("Avisynth Error");
                }
                return false;
            }

            return true;
        }

       
    }
}
