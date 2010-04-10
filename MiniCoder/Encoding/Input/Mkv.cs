//    MiniCoder
//    Copyright (C) 2009-2010  MiniTech support@minitech.org
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Text;
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MiniTech.MiniCoder.Core.Encoding;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Other.Logging;

namespace MiniTech.MiniCoder.Encoding.Input
{
    class Mkv : InputFile
    {
        String tempPath = Application.StartupPath + "\\temp\\";

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
            if (demuxFiles(mkvtoolnix, fileDetails, tracks, processWatcher))
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
                // LogBook.Instance.addLogLine("Demuxing MKV - Using Mkvtoolnix", fileDetails["name"][0] + "DeMuxing", fileDetails["name"][0] + "DeMuxingProcess", false);

                MiniProcess proc = new DefaultProcess(LanguageController.Instance.getLanguageString("demuxingMessage") + " MKV", fileDetails["name"][0] + "DeMuxingProcess");
                processWatcher.setProcess(proc);
                if (!mkvtoolnix.isInstalled())
                    mkvtoolnix.download();


                LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingMkv"));
                proc.initProcess();

                proc.setFilename(Path.Combine(mkvtoolnix.getInstallPath(), "mkvextract.exe"));
                string tempArg = tempArg = "tracks \"" + fileDetails["fileName"][0] + "\" ";

                tracks["video"][0].demuxPath = tempPath + fileDetails["name"][0] + "-Video Track" + "." + Codec.Instance.getExtention(tracks["video"][0].codec);

                tempArg += tracks["video"][0].id + ":\"" + tracks["video"][0].demuxPath + "\" ";


                for (int i = 0; i < tracks["audio"].Length; i++)
                {
                    tracks["audio"][i].demuxPath = tempPath + fileDetails["name"][0] + "-Audio Track-" + i.ToString() + "." + Codec.Instance.getExtention(tracks["audio"][i].codec);
                    tempArg += tracks["audio"][i].id + ":\"" + tracks["audio"][i].demuxPath + "\" ";
                }



                for (int i = 0; i < tracks["subs"].Length; i++)
                {
                    tracks["subs"][i].demuxPath = tempPath + fileDetails["name"][0] + "-Subtitle Track-" + i.ToString() + "." + Codec.Instance.getExtention(tracks["subs"][i].codec);
                    tempArg += tracks["subs"][i].id + ":\"" + tracks["subs"][i].demuxPath + "\" ";
                }



                proc.setArguments(tempArg);


                int exitCode = proc.startProcess();

                if (exitCode != 0)
                    return false;

                if (proc.getAbandonStatus())
                {
                    LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingAbortedMessage"));
                    return false;
                }
                else
                    LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingCompleteMessage"));

                return true;
            }
            catch (KeyNotFoundException e)
            {
                String errormessage = "";
                errormessage += "VIDEO: " + tracks["video"][0].codec + ", AUDIO: ";
                for (int i = 0; i < tracks["audio"].Length; i++)
                {
                    errormessage += " " + i + ": " + tracks["audio"][i].codec + ", " + tracks["audio"][i].language;
                }

                errormessage += ", SUBS: ";
                for (int i = 0; i < tracks["subs"].Length; i++)
                {
                    errormessage += " " + i + ": " + tracks["subs"][i].codec + ", " + tracks["subs"][i].language;
                }

                LogBookController.Instance.addLogLine("Can't find codec: \r\n" + e.Message + "\r\n" + errormessage, LogMessageCategories.Error);
                MessageBox.Show("Can't find codec. Please submit this error to allow the codec to be supported in the next version.");
                return false;
            }
        }

        private Boolean demuxAttachments(Tool mkvtoolnix, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {

            if (fileDetails["skipattachments"][0] == "True")
                return true;

            LogBookController.Instance.addLogLine("Fetching MKV Attachments - Using MkvInfo", LogMessageCategories.Video);



            MiniProcess proc = new AttachmentProcess();
            processWatcher.setProcess(proc);
            LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingMkvAttachments"));
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


                LogBookController.Instance.addLogLine("Number of attachments: " + (split.Length - 1).ToString(), LogMessageCategories.Video);

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
                LogBookController.Instance.addLogLine("Error demuxing attachments!", LogMessageCategories.Error);

                return false;
            }
        }

        private Boolean demuxChapters(Tool mkvtoolnix, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
            // LogBook.Instance.addLogLine("Fetching MKV Chapters - Using MkvExtract", fileDetails["name"][0] + "DeMuxing", fileDetails["name"][0] + "ChapterFetching", false);

            LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("demuxingMkvChapters"));
            XMLValidator xmlValidator = new XMLValidator(tempPath + "chapters.xml");
            int chapterFetchRetries = 0;
            while (!xmlValidator.Validate() && chapterFetchRetries++ < 5)
            {
                if (!xmlValidator.Validate() && File.Exists(tempPath + "chapters.xml"))
                {
                    // LogBook.Instance.addLogLine("Error in XML", fileDetails["name"][0] + "ChapterFetching", "", true);
                }


                MiniProcess proc = new AttachmentProcess();
                processWatcher.setProcess(proc);
                proc.initProcess();


                // LogBook.Instance.addLogLine("Attempt " + chapterFetchRetries + " to fetch chapters.", fileDetails["name"][0] + "ChapterFetching", "", false);
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
