using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.Encoding.Process_Management;
using MiniCoder.External;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MiniCoder.Core.Encoding;
using MiniCoder.Core.Languages;

namespace MiniCoder.Encoding.Input
{
    class Mkv : InputFile
    {
        String tempPath = Application.StartupPath + "\\temp\\";
        SysLanguage language = MiniSystem.getLanguage();
     //   SortedList<String, String[]> fileDetails = new SortedList<string, string[]>();

        public Mkv()
        {
           
        }

        public SortedList<String, Track[]> getTracks()
        {
            return new SortedList<string, Track[]>();
        }

        public void setTempPath(string tempPath)
        {
            this.tempPath = tempPath;
        }

        public Boolean demux(Tool mkvtoolnix, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
           if(demuxFiles(mkvtoolnix, fileDetails, tracks,processWatcher))
               if (demuxAttachments(mkvtoolnix, fileDetails, tracks, processWatcher))
               {
                   if (!String.IsNullOrEmpty(fileDetails["chapters"][0]))
                   {
                       return demuxChapters(mkvtoolnix, fileDetails, tracks, processWatcher);
                   }
                   return true;
               }
            return false;
        }

        private Boolean demuxFiles(Tool mkvtoolnix, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
            try
            {
                LogBook.addLogLine("Demuxing MKV - Using Mkvtoolnix", fileDetails["name"][0] + "DeMuxing", fileDetails["name"][0] + "DeMuxingProcess", false);
                
                MiniProcess proc = new DefaultProcess(language.demuxingMessage + " MKV", fileDetails["name"][0] + "DeMuxingProcess");
                processWatcher.setProcess(proc);
                if (!mkvtoolnix.isInstalled())
                    mkvtoolnix.download();


                LogBook.setInfoLabel(language.demuxingMkv);
                proc.initProcess();
              
                proc.setFilename(Path.Combine(mkvtoolnix.getInstallPath(), "mkvextract.exe"));
                string tempArg = tempArg = "tracks \"" + fileDetails["fileName"][0] + "\" ";

                tracks["video"][0].demuxPath = tempPath + fileDetails["name"][0] + "-Video Track" + "." + Codec.getExtention(tracks["video"][0].codec);

                tempArg += tracks["video"][0].id + ":\"" + tracks["video"][0].demuxPath + "\" ";


                for (int i = 0; i < tracks["audio"].Length; i++)
                {
                    tracks["audio"][i].demuxPath = tempPath + fileDetails["name"][0] + "-Audio Track-" + i.ToString() + "." + Codec.getExtention(tracks["audio"][i].codec);
                    tempArg += tracks["audio"][i].id + ":\"" + tracks["audio"][i].demuxPath + "\" ";
                }



                for (int i = 0; i < tracks["subs"].Length; i++)
                {
                    tracks["subs"][i].demuxPath = tempPath + fileDetails["name"][0] + "-Subtitle Track-" + i.ToString() + "." + Codec.getExtention(tracks["subs"][i].codec);
                    tempArg += tracks["subs"][i].id + ":\"" + tracks["subs"][i].demuxPath + "\" ";
                }



                proc.setArguments(tempArg);


                int exitCode = proc.startProcess();

                if (exitCode != 0)
                    return false;

                if (proc.getAbandonStatus())
                {
                    LogBook.setInfoLabel(language.demuxingAbortedMessage);
                    return false;
                }
                else
                    LogBook.setInfoLabel(language.demuxingCompleteMessage);

                return true;
            }
            catch (KeyNotFoundException e)
            {
                String errormessage = "";
                errormessage += "VIDEO: ";
                errormessage += tracks["video"][0].codec;
                errormessage += ", AUDIO: ";
                for (int i = 0; i < tracks["audio"].Length; i++)
                {
                    errormessage += " " + i + ": " + tracks["audio"][i].codec + ", " + tracks["audio"][i].language;
                }
                errormessage += ", SUBS: ";
                for (int i = 0; i < tracks["subs"].Length; i++)
                {
                    errormessage += " " + i + ": " + tracks["subs"][i].codec + ", " + tracks["subs"][i].language;
                }


                LogBook.addLogLine("Can't find codec :-(" + e.Message + ", " + errormessage, fileDetails["name"][0] + "DeMuxing","",true);
                MessageBox.Show("Can't find codec");
                return false;
            }
        }

        private Boolean demuxAttachments(Tool mkvtoolnix, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {

            if (fileDetails["skipattachments"][0] == "True")
                return true;

            LogBook.addLogLine("Fetching MKV Attachments - Using MkvInfo", fileDetails["name"][0] + "DeMuxing", fileDetails["name"][0] + "AttachmentFetching", false);


            MiniProcess proc = new AttachmentProcess();
            processWatcher.setProcess(proc);
            LogBook.setInfoLabel(language.demuxingMkvAttachments);
            proc.initProcess();

            proc.setFilename(Path.Combine(mkvtoolnix.getInstallPath(), "mkvinfo.exe"));
            proc.setArguments("\"" + fileDetails["fileName"][0] + "\"");
          
            proc.startProcess();
            string outputLog = proc.getAdditionalOutput();

            string[] split = Regex.Split(outputLog, "\\+ File name: ");

            string temp;

            Track[] attachments = new Track[split.Length - 1];

            char[] sep1 = { ':' };
            char[] sep2 = { '\r' };
            try
            {
                int start = outputLog.IndexOfAny(sep1, outputLog.IndexOf("Display width")) + 2;
                int end = outputLog.IndexOfAny(sep2, outputLog.IndexOf("Display width"));
                temp = outputLog.Substring(start, end - start);
                int width = int.Parse(temp);

                start = outputLog.IndexOfAny(sep1, outputLog.IndexOf("Display height")) + 2;
                end = outputLog.IndexOfAny(sep2, outputLog.IndexOf("Display height"));
                temp = outputLog.Substring(start, end - start);
                int height = int.Parse(temp);



                LogBook.addLogLine("Number of attachments: " + (split.Length - 1).ToString(), fileDetails["name"][0] + "AttachmentFetching","",false);
                if ((split.Length - 1) == 0)
                    return true;

                for (int i = 1; i < split.Length; i++)
                    attachments[i - 1] = new Attachment(tempPath + split[i].Substring(0, split[i].IndexOf("\r\n")), split[i].Substring(0, split[i].IndexOf("\r\n")));

                proc = new DefaultProcess("Demuxing Attachments", fileDetails["name"][0] + "AttachmentFetching");
                proc.initProcess();

                proc.setFilename(Path.Combine(mkvtoolnix.getInstallPath(), "mkvextract.exe"));
                string tempArg = "attachments \"" + fileDetails["fileName"][0] + "\"";

                for (int i = 1; i <= attachments.Length; i++)
                    tempArg += " " + i.ToString() + ":\"" + attachments[i - 1].demuxPath + "\"";

                proc.setArguments(tempArg);
                int exitCode = proc.startProcess();

                if (proc.getAbandonStatus())
                    return false;

                if (exitCode != 0)
                    return false;

                tracks.Add("attachments", attachments);

                return true;
            }
            catch
            {
               LogBook.addLogLine("Error demuxing attachments!",fileDetails["name"][0] + "AttachmentFetching","",true);
               // log.addLine("Remuxing the MKV file might solve this problem.");
                return false;
            }
        }

        private Boolean demuxChapters(Tool mkvtoolnix, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
            LogBook.addLogLine("Fetching MKV Chapters - Using MkvExtract", fileDetails["name"][0] + "DeMuxing", fileDetails["name"][0] + "ChapterFetching", false);

            LogBook.setInfoLabel(language.demuxingMkvChapters);
            XMLValidator xmlValidator = new XMLValidator(tempPath + "chapters.xml");
                    int chapterFetchRetries = 0;
                    while (!xmlValidator.Validate() && chapterFetchRetries++ < 5)
                    {
                        if (!xmlValidator.Validate() && File.Exists(tempPath + "chapters.xml"))
                        {
                            LogBook.addLogLine("Error in XML", fileDetails["name"][0] + "ChapterFetching","",true);
                        }

                        
                      MiniProcess  proc = new AttachmentProcess();
                      processWatcher.setProcess(proc);
                        proc.initProcess();


                        LogBook.addLogLine("Attempt " + chapterFetchRetries + " to fetch chapters.", fileDetails["name"][0] + "ChapterFetching","",false);
                        proc.setFilename(Path.Combine(mkvtoolnix.getInstallPath(), "mkvextract.exe"));
                        string tempArg = "chapters \"" + fileDetails["fileName"][0] + "\"";
                       
                        proc.setArguments(tempArg);
                      
                        proc.startProcess();
                        if (proc.getAbandonStatus())
                            return false;

                        string chapters = proc.getAdditionalOutput();
                       
                    
                     

                        StreamWriter strChapters = new StreamWriter((tempPath + "chapters.xml"), false);
                        strChapters.Write(chapters);
                        strChapters.Close();
                    }

                    if (chapterFetchRetries >= 5)
                        File.Delete(tempPath + "chapters.xml");
                    return true;
        }
    }
}
