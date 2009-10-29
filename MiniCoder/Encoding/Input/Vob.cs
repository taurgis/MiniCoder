using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.Encoding.Process_Management;
using MiniCoder.External;
using System.IO;
using System.Windows.Forms;

namespace MiniCoder.Encoding.Input
{
    class Vob : InputFile
    {
        String tempPath = Application.StartupPath + "\\temp\\";
     //   SortedList<String, String[]> fileDetails = new SortedList<string, string[]>();

        public Vob()
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

        public Boolean demux(Tool DGIndex, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
            if (demuxFile(DGIndex, fileDetails, tracks, processWatcher))
                if (demuxSubs(DGIndex, fileDetails, tracks, processWatcher))
                     if (demuxChapters(DGIndex, fileDetails, tracks, processWatcher))
                             return true;

            return false;
              
        }
        private Boolean demuxChapters(Tool DGIndex, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {

            LogBook.addLogLine("Demuxing Chapters - Using ChapterXtractor", fileDetails["name"][0] + "DeMuxing", fileDetails["name"][0] + "DeMuxingProcess", false);

            MiniProcess proc = new DefaultProcess("Fetching chapters", fileDetails["name"][0] + "DeMuxingProcess");
           // // LogBook.addLogLine(""Started fetching chapters.", 1);
            LogBook.setInfoLabel("Started fetching chapters.");
            proc.initProcess();



            proc.setFilename(Path.Combine(DGIndex.getInstallPath(), "ChapterXtractor.exe"));
           string tempArg = "\"" + fileDetails["fileName"][0].Replace("_1", "_0").Replace(".VOB",".IFO") + "\" " + "\"" + tempPath + "chapters.txt\" -p5 -t1";
            proc.setArguments(tempArg);
            int exitCode = proc.startProcess();

            try
            {
                FileInfo tempChapFile = new FileInfo(tempPath + "chapters.txt");
                if (tempChapFile.Length == 0)
                    File.Delete(tempPath + "chapters.txt");
            }
            catch
            {

            }
            if (exitCode != 0)
            {
                LogBook.addLogLine("Error demuxing chapters, none present?", fileDetails["name"][0] + "DeMuxing", "", false);

            }
            return true;
        }
        private Boolean demuxSubs(Tool DGIndex, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
            LogBook.addLogLine("Demuxing subs - Using Vobsub", fileDetails["name"][0] + "DeMuxing", "", false);

            //sub extraction
            MiniProcess proc = new DefaultProcess("Fetching subs", fileDetails["name"][0] + "DeMuxingProcess");

           // // LogBook.addLogLine(""Started fetching subs.",1);
            LogBook.setInfoLabel("Started fetching subs.");

            proc.initProcess();


            string tempArg = "";

            StreamWriter streamWriter = new StreamWriter(tempPath + fileDetails["name"][0] + ".vobsub");
            streamWriter.WriteLine(fileDetails["fileName"][0].Replace("_1", "_0").Replace(".VOB",".IFO"));
            streamWriter.WriteLine(tempPath + fileDetails["name"][0]);
            streamWriter.WriteLine("1");
            streamWriter.WriteLine("0");
            streamWriter.WriteLine("ALL");
            streamWriter.WriteLine("CLOSE");
            streamWriter.Close();

            proc.setFilename("C:\\WINDOWS\\system32\\rundll32.exe");
            //    "C:\WINDOWS\system32\rundll32.exe" vobsub.dll,Configure C:\Samurai 7\VIDEO_TS\VTS_03_0.vobsub

            tempArg = "VOBSUB.DLL,Configure " + tempPath + fileDetails["name"][0] + ".vobsub";


            proc.setArguments(tempArg);
           int exitCode = proc.startProcess();



           if (proc.getAbandonStatus())
           {
               LogBook.setInfoLabel("Demuxing Aborted");
               return false;
           }
           else
               LogBook.setInfoLabel("Demuxing Complete");

           if (exitCode != 0)
               return false;
           // // LogBook.addLogLine(""Errors demuxing subs. None present?",1, "");
           else
               return true;

            
        }

        private Boolean demuxFile(Tool DGIndex, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
              MiniProcess proc = new DefaultProcess("Indexing VOB",fileDetails["name"][0] + "DeMuxingProcess");
            processWatcher.setProcess(proc);
            proc.stdErrDisabled(false);
            proc.stdOutDisabled(false);
            try
            {
               
                if (!DGIndex.isInstalled())
                    DGIndex.download();
                string tempArg;

                LogBook.addLogLine("Demuxing OGM - Using DGIndex", fileDetails["name"][0] + "DeMuxing", "", false);


               // // LogBook.addLogLine(""Started indexing VOB files", 1);
                LogBook.setInfoLabel("Started indexing VOB files.");
                proc.initProcess();


             //   string path = tempPath.Substring(0, tempPath.Length - 1);


                proc.setFilename(Path.Combine(DGIndex.getInstallPath(), "DGIndex.exe"));

                tracks["video"][0].demuxPath = tempPath + fileDetails["name"][0] + "." + Codec.getExtention(tracks["video"][0].codec);


         
                        //-SD=< -AIF=<C:\Samurai 7\VIDEO_TS\VTS_03_1.VOB< -OF=<C:\Samurai 7\VIDEO_TS\samurai 7< -exit -hide -OM=1 -TN=80
                        tempArg = "-SD=< -AIF=<" + fileDetails["fileName"][0] + "< -OF=<" + tempPath + fileDetails["name"][0] + "< -exit -hide -OM=2 -TN=80";
                    
                
                proc.setArguments(tempArg);
               int exitCode = proc.startProcess();

                DirectoryInfo info = new DirectoryInfo(tempPath);
                int count = 0;
                foreach (FileInfo fInfo in info.GetFiles())
                {
                    if (fInfo.Extension == ".ac3")
                        tracks["audio"][count++].demuxPath = fInfo.FullName;
                        
                }

                if (proc.getAbandonStatus())
                {
                    LogBook.setInfoLabel("Demuxing Aborted");
                    return false;
                }
                else
                    LogBook.setInfoLabel("Demuxing Complete");
                

                if (exitCode != 0)
                    return false;

                return true;
            }
            catch
            {
            }

            return false;
        }

    }
}
