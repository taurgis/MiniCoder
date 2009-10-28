using System;
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
            try
            {
                this.encodeSet = encodeSet;
                this.fileName = fileName;
                fileDetails = getFileDetails(fileName);

                LogBook.addLogLine("Encoding " + fileDetails["name"][0], fileDetails["name"][0] + "Encode", fileDetails["name"][0] + "Encode", false);
                LogBook.addLogLine("Encode Settings", fileDetails["name"][0] + "Encode", fileDetails["name"][0] + "EncodeSettings", false);

                foreach (string key in encodeSet.Keys)
                {
                    LogBook.addLogLine(key + " : " + encodeSet[key], fileDetails["name"][0] + "EncodeSettings", "", false);

                }

                LogBook.addLogLine("Fetching File Info", fileDetails["name"][0] + "Encode", fileDetails["name"][0] + "FileInfo", false);
                LogBook.setInfoLabel("Fetching File Info");

                for (int i = 0; i < fileDetails["completeinfo"].Length; i++)
                    LogBook.addLogLine(fileDetails["completeinfo"][i].Replace("\r", ""), fileDetails["name"][0] + "FileInfo", "", false);

                //LogBook.addLogLine("Fetching Created File Info", fileDetails["name"][0] + "Encode", fileDetails["name"][0] + "FileInfoFetch", false);
               

                //foreach (string key in fileDetails.Keys)
                //{
                //    for(int i = 0; i < fileDetails[key].Length;i++)
                //        LogBook.addLogLine(key + " : " + fileDetails[key][i], fileDetails["name"][0] + "FileInfoFetch", "", false);

                //}
                
                this.tools = tools;
                this.processWatcher = processWatcher;
            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error starting encode. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
               // return false;
            }

        }
        public Boolean startTheoraEncode()
        {
            try
            {
                if (demuxFile())
                    if (encodeVideo())
                        return true;
                return false;
            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error starting Theora encode. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }

        public Boolean startAvsEncode()
        {
            try
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

                    if (demuxFile())
                        if (analyseVfr())
                            if (dgavcIndex())
                                if (encodeAudio())
                                    //  if (createAvs())
                                    if (encodeVideo())
                                        return muxFile();

                }
                return false;
            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error encoding AVS file. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }

        public Boolean startDefaultEncode()
        {
            try
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
            catch (Exception error)
            {
                LogBook.addLogLine("Error starting default encode. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }

        public ProcessWatcher getProcessWatcher()
        {
            return processWatcher;
        }

        public bool muxFile()
        {
            LogBook.addLogLine("Muxing File", fileDetails["name"][0] + "Encode", fileDetails["name"][0] + "FileMuxing", false);
          
            Container container = null;
            switch (encodeSet["container"])
            {
                case "0":
                    container = new Matroska();
                    return container.mux(tools["mkvtoolnix"], fileDetails, encodeSet, processWatcher, fileTracks);

                case "1":
                    container = new Mp4Out();
                    return container.mux(tools["mp4box"], fileDetails, encodeSet, processWatcher, fileTracks);
                case "2":
                    container = new AviOut();
                    return container.mux(tools["ffmpeg"], fileDetails, encodeSet, processWatcher, fileTracks);
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
            LogBook.addLogLine("Creating AVS File", fileDetails["name"][0] + "Encode", fileDetails["name"][0] + "AvsCreation", false);
          
            AvsCreator avsCreator = new AvsCreator(fileDetails, fileTracks["video"][0], encodeSet, tools);
            return avsCreator.getAvsFile(fileTracks);

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
            LogBook.addLogLine("DGAVCIndex Step", fileDetails["name"][0] + "Encode", fileDetails["name"][0] + "DGAVCStep", false);
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
            LogBook.addLogLine("VFR Step", fileDetails["name"][0] + "Encode", fileDetails["name"][0] + "VFRAnalyse", false);
            Vfr vfr = new Vfr();
            return vfr.analyse(tools["mkv2vfr"], tools["DtsEdit"], encodeSet, fileDetails, processWatcher);
        }

        #endregion

        #region Demuxing
        private bool demuxFile()
        {
            LogBook.addLogLine("Demuxing", fileDetails["name"][0] + "Encode", fileDetails["name"][0] + "DeMuxing",false);
            switch (fileDetails["ext"][0].ToUpper())
            {
                case "AVI":
                    return demuxAvi();
                case "MP4":
                    return demuxMp4();
                case "OGM":
                    return demuxOgm();
                case "MKV":
                    return demuxMkv();
                case "WMV":
                    return demuxWmv();
                case "VOB":
                    return demuxVob();
                case "AVS":
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
            
            SortedList<String, String[]> tempDetail = new SortedList<string, string[]>();
            MediaInfoWrapper.MediaInfo mediaInfo = new MediaInfoWrapper.MediaInfo(fileName);

      

            Track[] videoTracks = new Track[1];
            Track[] audioTracks;
            if (encodeSet["skipaudio"] != "True")
                audioTracks = new Track[mediaInfo.AudioCount];
            else
                audioTracks = new Track[0];

            Track[] subTracks;
            if (encodeSet["skipsubs"] != "True")
                subTracks = new Track[mediaInfo.TextCount];
            else
                subTracks = new Track[0];

            videoTracks[0] = new Video(mediaInfo.Video[0].CodecID.ToString(), int.Parse(mediaInfo.Video[0].ID));

            for (int i = 0; i < audioTracks.Length; i++)
            {
              //  audioTracks[i] = new Audio(temp.audTitle(fileName)[i], temp.audLanguage(fileName)[i], temp.audCodec(fileName)[i], temp.audID(fileName)[i]);
                audioTracks[i] = new Audio(mediaInfo.Audio[i].Title, mediaInfo.Audio[i].Language,mediaInfo.Audio[i].CodecID.ToString(), int.Parse(mediaInfo.Audio[i].ID));
            }

            for (int i = 0; i < subTracks.Length; i++)
            {
               // subTracks[i] = new Sub(temp.subCaption(fileName)[i], temp.subLang(fileName)[i], temp.subCodec(fileName)[i], temp.subID(fileName)[i]);
                subTracks[i] = new Sub(mediaInfo.Text[i].Title, mediaInfo.Text[i].Language, mediaInfo.Text[i].Codec, int.Parse(mediaInfo.Text[i].ID));
            }

            if (encodeSet.ContainsKey("skipattachments"))
                tempDetail.Add("skipattachments", encodeSet["skipattachments"].Split(Char.Parse("\n")));

            fileTracks.Add("video", videoTracks);
            fileTracks.Add("audio", audioTracks);
            fileTracks.Add("subs", subTracks);
            tempDetail.Add("decodedaudio", new String[mediaInfo.AudioCount]);
            tempDetail.Add("fileName", mediaInfo.General[0].CompleteName.Split(Convert.ToChar("\n")));
            tempDetail.Add("fileSize", mediaInfo.General[0].FileSize.Split(Convert.ToChar(" ")));

            tempDetail.Add("name", mediaInfo.General[0].FileName.Split(Convert.ToChar("\n")));
            tempDetail.Add("ext", mediaInfo.General[0].FileExtension.Split(Convert.ToChar(" ")));
            if (encodeSet.ContainsKey("customoutput"))
                encodeSet.Add("outDIR", encodeSet["customoutput"]);
            else
                encodeSet.Add("outDIR", (Path.GetDirectoryName(mediaInfo.General[0].CompleteName + "\\")));
            tempDetail.Add("crfValue", crfValue.ToString().Split(Convert.ToChar(" ")));



            

            tempDetail.Add("completeinfo", mediaInfo.InfoComplete.Split(Convert.ToChar("\n")));
            if (audioTracks.Length > 0)
            {
                tempDetail.Add("audLength", (int.Parse(mediaInfo.Audio[0].Duration) / 1000).ToString().Split(Convert.ToChar(" ")));
                if (mediaInfo.General[0].FileExtension.ToUpper() == ".VOB")
                    tempDetail.Add("audBitrate", mediaInfo.Audio[0].BitRate.ToString().Split(Convert.ToChar(" ")));
            }
            tempDetail.Add("width", mediaInfo.Video[0].Width.Split(Convert.ToChar(" ")));
            tempDetail.Add("height",mediaInfo.Video[0].Height.Split(Convert.ToChar(" ")));
            tempDetail.Add("fps", mediaInfo.Video[0].FrameRate.Split(Convert.ToChar(" ")));

            tempDetail.Add("framecount", mediaInfo.Video[0].FrameCount.Split(Convert.ToChar(" ")));

            if (encodeSet["skipchapters"] == "True")
               tempDetail.Add("chapters", "".Split(Char.Parse(" ")));
            else
            {
                
                    tempDetail.Add("chapters", "dontskip".Split(Char.Parse(" ")));
            }
                tempDetail.Add("vfrCode", null);
            tempDetail.Add("vfrName", null);


            return tempDetail;
        }
    }

}
