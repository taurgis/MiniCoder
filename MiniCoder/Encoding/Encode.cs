﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MiniCoder.Encoding.Input;
using MiniCoder.External;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.Encoding.Process_Management;
using MiniCoder.Encoding.VideoEnc;
using MiniCoder.Encoding.AviSynth;
using MiniCoder.Encoding.VideoEnc.Encoding;
using MiniCoder.Encoding.Output;
namespace MiniCoder.Encoding
{
    class Encode
    {
        String fileName = "";
        SortedList<String, Tool> tools;
        SortedList<String, String[]> fileDetails;
        SortedList<String, String> encodeSet;
        SortedList<String, Track[]> fileTracks = new SortedList<string, Track[]>();
        ProcessWatcher processWatcher;
        public Encode(String fileName, SortedList<String, Tool> tools, SortedList<String, String> encodeSet, ProcessWatcher processWatcher)
        {
            this.encodeSet = encodeSet;
            this.fileName = fileName;
            fileDetails = getFileDetails(fileName);
            LogBook.addLogLine("Encoding " + fileDetails["name"][0], 0);
            LogBook.addLogLine("Fetching File Info", 1);
            LogBook.setInfoLabel("Fetching File Info");
            
            for (int i = 0; i < fileDetails["completeinfo"].Length; i++)
                LogBook.addLogLine(fileDetails["completeinfo"][i].Replace("\r", ""), 2);
            this.tools = tools;
            this.processWatcher = processWatcher;


        }
        public Boolean startTheoraEncode()
        {
            if (demuxFile())
                if (encodeVideo())
                     return true;
            return false;
        }

        public Boolean startAvsEncode()
        {
            if (demuxFile())
            {
                string avsfile = fileDetails["avsfile"][0];
                fileTracks.Clear();
                encodeSet.Remove("outDIR");
                encodeSet["width"] = fileDetails["width"][0];
                encodeSet["height"] = fileDetails["height"][0];
                fileDetails = getFileDetails(fileDetails["fileName"][0]);
               encodeSet.Add("avsfile", avsfile);
              
                if(demuxFile())
                if (analyseVfr())
                    if (dgavcIndex())
                        if (encodeAudio())
                          //  if (createAvs())
                                if (encodeVideo())
                                    return muxFile();
            
            }
            return false;
        }

        public Boolean startDefaultEncode()
        {
            if (demuxFile())
                if (analyseVfr())
                    if (dgavcIndex())
                        if (encodeAudio())
                            if (createAvs())
                                if (encodeVideo())
                                    return muxFile();
            return false;
        }

        public ProcessWatcher getProcessWatcher()
        {
            return processWatcher;
        }

        public bool muxFile()
        {
            Container container = null;
            switch (encodeSet["container"])
            {
                case "0":
                    container = new Matroska();
                    return container.mux(tools["mkvtoolnix"], fileDetails, encodeSet, processWatcher, fileTracks);

                case "1":
                    container = new Mp4Out();
                    return container.mux(tools["mp4box"], fileDetails, encodeSet, processWatcher, fileTracks);
            }
            return false;
        }

        public bool encodeVideo()
        {
            return fileTracks["video"][0].Encode(tools, fileDetails, encodeSet, processWatcher, fileTracks);


        }

        #region "AviSynth"
        private bool createAvs()
        {
            AvsCreator avsCreator = new AvsCreator(fileDetails, fileTracks["video"][0], encodeSet, tools);
            return avsCreator.getAvsFile();

        }
        #endregion

        #region "Audio"

        private bool encodeAudio()
        {
            for (int i = 0; i < fileTracks["audio"].Length; i++)
            {
                if (!fileTracks["audio"][i].Encode(tools, fileDetails, encodeSet, processWatcher, fileTracks))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region "Indexing"

        private bool dgavcIndex()
        {
            switch (fileTracks["video"][0].codec)
            {
                case "x264":
                case "avc1":
                case "H264":
                case "V_MPEG4/ISO/AVC":
                    DGAVCIndex dgIndex = new DGAVCIndex();
                    return dgIndex.index(tools["DGAVCIndex"], tools["DGAVCDecode"], fileDetails, fileTracks["video"][0], processWatcher);

                default:
                    return true;
            }



        }
        public string getExtention()
        {
            return fileDetails["ext"][0];
        }
        private bool analyseVfr()
        {
            Vfr vfr = new Vfr();
            return vfr.analyse(tools["mkv2vfr"], encodeSet, fileDetails, processWatcher);
        }

        #endregion

        #region Demuxing
        private bool demuxFile()
        {
           
            switch (fileDetails["ext"][0])
            {
                case ".avi":
                    return demuxAvi();

                case ".mp4":
                    return demuxMp4();

                case ".ogm":
                    return demuxOgm();

                case ".mkv":
                    return demuxMkv();
                case ".wmv":
                    return demuxWmv();
                case ".vob":
                case ".VOB":
                    return demuxVob();
                case ".avs":
                    return demuxAvs();

            }
            return false;
        }

        private Boolean demuxAvs()
        {
            InputFile input = new Avs();
            return input.demux(tools["DGIndex"], fileDetails, fileTracks, processWatcher);
        }

        private Boolean demuxVob()
        {
            InputFile input = new Vob();
            return input.demux(tools["DGIndex"], fileDetails, fileTracks, processWatcher);
        }
        private Boolean demuxWmv()
        {
            InputFile input = new Wmv();
            return input.demux(tools["mkvtoolnix"], fileDetails, fileTracks, processWatcher);
        }

        private Boolean demuxAvi()
        {
            InputFile input = new Avi();

            return input.demux(tools["VirtualDubMod"], fileDetails, fileTracks, processWatcher);
        }

        private Boolean demuxMp4()
        {
            InputFile input = new Mp4();

            return input.demux(tools["mp4box"], fileDetails, fileTracks, processWatcher);
        }

        private Boolean demuxOgm()
        {
            InputFile input = new Ogm();

            return input.demux(tools["ogmtools"], fileDetails, fileTracks, processWatcher);
        }

        private Boolean demuxMkv()
        {
            InputFile input = new Mkv();

            return input.demux(tools["mkvtoolnix"], fileDetails, fileTracks, processWatcher);
        }
        #endregion



        private int crfValue = 0;
        public SortedList<String, String[]> getFileDetails(string fileName)
        {
            //infoLabel.Text = "Gathering Media Info";
            IfMediaDetails temp;
            SortedList<String, String[]> tempDetail = new SortedList<string, string[]>();

            if (IntPtr.Size == 8)
                temp = new MediaDetails64();
            else
                temp = new MediaDetails32();

            Track[] videoTracks = new Track[1];
            Track[] audioTracks;
            if(encodeSet["skipaudio"] != "True")
               audioTracks = new Track[temp.audioCount(fileName)];
            else
                audioTracks = new Track[0];

             Track[] subTracks ;
             if (encodeSet["skipsubs"] != "True")
                 subTracks = new Track[temp.subCount(fileName)];
             else
                 subTracks = new Track[0];

            videoTracks[0] = new Video(temp.vidCodec(fileName), temp.vidID(fileName)[0]);

            for (int i = 0; i < audioTracks.Length; i++)
                {
                    audioTracks[i] = new Audio(temp.audTitle(fileName)[i], temp.audLanguage(fileName)[i], temp.audCodec(fileName)[i], temp.audID(fileName)[i]);
                }
          
            for (int i = 0; i < subTracks.Length; i++)
            {
                subTracks[i] = new Sub(temp.subCaption(fileName)[i], temp.subLang(fileName)[i], temp.subCodec(fileName)[i], temp.subID(fileName)[i]);
            }

            if (encodeSet.ContainsKey("skipattachments"))
                tempDetail.Add("skipattachments", encodeSet["skipattachments"].Split(Char.Parse("\n")));

            fileTracks.Add("video", videoTracks);
            fileTracks.Add("audio", audioTracks);
            fileTracks.Add("subs", subTracks);
            tempDetail.Add("decodedaudio", new String[temp.audioCount(fileName)]);
            tempDetail.Add("fileName", temp.fileName(fileName).Split(Convert.ToChar("\n")));
            tempDetail.Add("fileSize", temp.fileSize(fileName).Split(Convert.ToChar(" ")));

            tempDetail.Add("name", temp.name(fileName).Split(Convert.ToChar("\n")));
            tempDetail.Add("ext", temp.fileExt(fileName).Split(Convert.ToChar(" ")));
            if (encodeSet.ContainsKey("customoutput"))
                encodeSet.Add("outDIR", encodeSet["customoutput"]);
            else
                encodeSet.Add("outDIR", (Path.GetDirectoryName(temp.fileName(fileName)) + "\\"));
            tempDetail.Add("crfValue", crfValue.ToString().Split(Convert.ToChar(" ")));



            tempDetail.Add("audLength", (temp.audLength(fileName) / 1000).ToString().Split(Convert.ToChar(" ")));

            tempDetail.Add("completeinfo", temp.completeInfo(fileName).Split(Convert.ToChar("\n")));
            if (temp.fileExt(fileName).ToUpper() == ".VOB")
                tempDetail.Add("audBitrate", temp.audBitrate(fileName).ToString().Split(Convert.ToChar(" ")));

            tempDetail.Add("width", temp.width(fileName).ToString().Split(Convert.ToChar(" ")));
            tempDetail.Add("height", temp.height(fileName).ToString().Split(Convert.ToChar(" ")));
            tempDetail.Add("fps", temp.fps(fileName).ToString().Split(Convert.ToChar(" ")));

            tempDetail.Add("framecount", temp.frameCount(fileName).ToString().Split(Convert.ToChar(" ")));

            if (encodeSet["skipchapters"] == "True")
            tempDetail.Add("chapters", "".Split(Char.Parse(" ")));
            else
            tempDetail.Add("chapters", temp.chapters(fileName).Split(Convert.ToChar(" ")));
            tempDetail.Add("vfrCode", null);
            tempDetail.Add("vfrName", null);


            return tempDetail;
        }
    }

}