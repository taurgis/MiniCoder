using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
namespace MiniCoder.Core.Languages
{
   public class SysLanguage
    {
        private CultureInfo culture;
        ResourceManager rm;
        public string programTitle { get; set; }
        public string inputTabTitle { get; set; }
        public string settingsTabTitle { get; set; }
        public string optionsTabTitle { get; set; }
        public string logTabTitle { get; set; }
        public string inputColumn1Title { get; set; }
        public string newsTabTitle { get; set; }
        public string inputColumn2StatusTitle { get; set; }
        public string encodeStartButton { get; set; }
        public string encodeStopButton { get; set; }
        public string whenDone { get; set; }
        public string infoLabel { get; set; }
        public string[] whenDoneOptions { get; set; }
        public string videoOptionsTitle { get; set; }
        public string videoBitRate { get; set; }
        public string videoFileSize { get; set; }
        public string videoQuality { get; set; }
        public string[] videoQualityOptions { get; set; }
        public string videoCodec { get; set; }
        public string audioOptionsTitle { get; set; }
        public string audioBitrate { get; set; }
        public string audioCodec { get; set; }
        public string containerOptionsTitle { get; set; }
        public string containerFormat { get; set; }
        public string filterOptionsTitle { get; set; }
        public string preprocessingOptionsTitle { get; set; }
        public string preField { get; set; }
        public string preResize { get; set; }
        public string[] preResizeOptions { get; set; }
        public string preWidthHeight { get; set; }
        public string postprocessingOptionsTitle { get; set; }
        public string postDenoiser { get; set; }
        public string[] postDenoiserOptions { get; set; }
        public string postSharpen { get; set; }
        public string[] postSharpenOptions { get; set; }
        public string postSubtitle { get; set; }
        public string customButton { get; set; }
        public string saveButton { get; set; }
        public string outputSettingsTitle { get; set; }
        public string outputDisableVideoAdvert { get; set; }
        public string outputDirectory { get; set; }
        public string processSettingsTitle { get; set; }
        public string processPriority { get; set; }
        public string[] processPriorityOptions { get; set; }
        public string encodingTitle { get; set; }
        public string encodingIgnoreAttachments { get; set; }
        public string encodingIgnoreAudio { get; set; }
        public string encodingIgnoreChapters { get; set; }
        public string encodingIgnoreSubs { get; set; }
        public string encodingShowVideoPreview { get; set; }
        public string encodingNextError { get; set; }
        public string tooltipVideoBr { get; set; }
        public string tooltipFileSize { get; set; }
        public string tooltipQuality { get; set; }
        public string tooltipVideoCodec { get; set; }
        public string tooltipAudioBr { get; set; }
        public string tooltipAudioCodec { get; set; }
        public string tooltipContainer { get; set; }
        public string tooltipField { get; set; }
        public string tooltipResize { get; set; }
        public string tooltipWidthHeight { get; set; }
        public string tooltipDenoise { get; set; }
        public string tooltipSub { get; set; }
        public string customFilterTitle { get; set; }
        public string customFilterText { get; set; }
        public string customFilterNote { get; set; }
        public string customFilterOK { get; set; }
        public string customFilterCancel { get; set; }
        public string updaterTitle { get; set; }
        public string coreTabTitle { get; set; }
        public string pluginsTabTitle { get; set; }
        public string audioTabTitle { get; set; }
        public string videoTabTitle { get; set; }
        public string muxingTabTitle { get; set; }
        public string otherTabTitle { get; set; }
        public string updateColumn1 { get; set; }
        public string updateColumn2 { get; set; }
        public string updateColumn3 { get; set; }
        public string updateColumn4 { get; set; }
        public string updateColumn5 { get; set; }
        public string updateMessage { get; set; }
        public string updateCustomPath { get; set; }
        public string updateUpdateButton { get; set; }
        public string updateCancelButton { get; set; }
        public string customPathsTitle { get; set; }
        public string applicationsButton { get; set; }
        public string audioDecodingMessage { get; set; }
        public string audioEncodingMessage { get; set; }
        public string demuxingMessage { get; set; }
        public string demuxingAbortedMessage { get; set; }
        public string demuxingCompleteMessage { get; set; }
        public string demuxingmp4Video { get; set; }
        public string demuxingmp4Audio { get; set; }
        public string demuxingvobChapters { get; set; }
        public string demuxingvobSubs { get; set; }
        public string demuxingVob { get; set; }
        public string muxingMessage { get; set; }
        public string audioEncodingTrack { get; set; }
        public string encodingVideoTheora { get; set; }
        public string encodingVideoPass { get; set; }
        public string indexingAvc { get; set; }
        public string indexingAvcAbort { get; set; }
        public string indexingAvcCompleted { get; set; }
        public string vfrParsing { get; set; }
        public string vfrParsingAborted { get; set; }
        public string vfrParsingCompleted { get; set; }
        public string fileInfoFetch { get; set; }
        public string demuxingMkv { get; set; }
        public string demuxingMkvAttachments { get; set; }
        public string demuxingMkvChapters { get; set; }
        public string errorWarningMessage { get; set; }
        public string errorWarningTitle { get; set; }
        public string encodingComplete { get; set; }
        public string inputColumn2StatusAborted { get; set; }
        public string inputColumn2StatusEncoding { get; set; }
        public string inputColumn2StatusError { get; set; }
        public string inputColumn2StatusReady { get; set; }
        public string inputColumn2StatusDone { get; set; }
        public string menuAdd { get; set; }
        public string menuRemove { get; set; }
        public string menuClear { get; set; }
        public string logMenuCopy { get; set; }
        public string logMenuSend { get; set; }

        public SysLanguage(int i)
        {
   
            switch (i)
            {
                case 0:
                    culture = CultureInfo.CreateSpecificCulture("");
                    break;
                case 1:
                    culture = CultureInfo.CreateSpecificCulture("nl-NL");
                    break;
                case 2:
                    culture = CultureInfo.CreateSpecificCulture("pt-BR");
                    break;
                case 3:
                    culture = CultureInfo.CreateSpecificCulture("tr-TR");
                    break;
                default:
                    culture = CultureInfo.CreateSpecificCulture("");
                    break;
            }
        
         
            rm = ResourceManager.CreateFileBasedResourceManager("language", Application.StartupPath + "/languages", null);
        

            programTitle = rm.GetString("programTitle", culture);
            inputTabTitle = rm.GetString("inputTabTitle", culture);
            settingsTabTitle = rm.GetString("settingsTabTitle", culture);
            optionsTabTitle = rm.GetString("optionsTabTitle", culture);
            logTabTitle = rm.GetString("logTabTitle", culture);
            newsTabTitle = rm.GetString("newsTabTitle", culture);
            inputColumn1Title = "    " + rm.GetString("inputColumn1Title", culture);
            inputColumn2StatusTitle = rm.GetString("inputColumn2StatusTitle", culture);
            encodeStartButton = rm.GetString("encodeStartButton", culture);
            encodeStopButton = rm.GetString("encodeStopButton", culture);
            whenDone = rm.GetString("whenDone", culture);
            infoLabel = rm.GetString("infoLabel", culture);
            whenDoneOptions = rm.GetString("whenDoneOptions",culture).Split(Char.Parse(";"));
            videoOptionsTitle = rm.GetString("videoOptionsTitle", culture);
           
            
            //videoOptionsTitle = new StreamReader(tempStream).ReadToEnd();
            videoBitRate = rm.GetString("videoBitRate", culture);
            videoFileSize = rm.GetString("videoFileSize", culture);
            videoQuality = rm.GetString("videoQuality", culture);
            videoQualityOptions = rm.GetString("videoQualityOptions", culture).Split(Char.Parse(";"));
            videoCodec = rm.GetString("videoCodec", culture);
            audioOptionsTitle = rm.GetString("audioOptionsTitle", culture);
            audioBitrate = rm.GetString("audioBitrate", culture);
            audioCodec = rm.GetString("audioCodec", culture);
            containerOptionsTitle = rm.GetString("containerOptionsTitle", culture);
            containerFormat = rm.GetString("containerFormat", culture);
            filterOptionsTitle = rm.GetString("filterOptionsTitle", culture);
            preprocessingOptionsTitle = rm.GetString("preprocessingOptionsTitle", culture);
            preField = rm.GetString("preField", culture);
            preResize = rm.GetString("preResize", culture);
            preResizeOptions = rm.GetString("preResizeOptions", culture).Split(Char.Parse(";"));
            preWidthHeight = rm.GetString("preWidthHeight", culture);
            postprocessingOptionsTitle = rm.GetString("postprocessingOptionsTitle", culture);
            postDenoiser = rm.GetString("postDenoiser", culture);
            postDenoiserOptions = rm.GetString("postDenoiserOptions", culture).Split(Char.Parse(";"));
            postSharpen = rm.GetString("postSharpen", culture);
            postSharpenOptions = rm.GetString("postSharpenOptions", culture).Split(Char.Parse(";"));
            postSubtitle = rm.GetString("postSubtitle", culture);
            customButton = rm.GetString("customButton", culture);
            saveButton = rm.GetString("saveButton", culture);
            outputSettingsTitle = rm.GetString("outputSettingsTitle", culture);
            outputDisableVideoAdvert = rm.GetString("outputDisableVideoAdvert", culture);
            outputDirectory = rm.GetString("outputDirectory", culture);
            processSettingsTitle = rm.GetString("processSettingsTitle", culture);
            processPriority = rm.GetString("processPriority", culture);
            processPriorityOptions = rm.GetString("processPriorityOptions", culture).Split(Char.Parse(";"));
            encodingTitle = rm.GetString("encodingTitle", culture);
            encodingIgnoreAttachments = rm.GetString("encodingIgnoreAttachments", culture);
            encodingIgnoreAudio = rm.GetString("encodingIgnoreAudio", culture);
            encodingIgnoreChapters = rm.GetString("encodingIgnoreChapters", culture);
            encodingIgnoreSubs = rm.GetString("encodingIgnoreSubs", culture);
            encodingShowVideoPreview = rm.GetString("encodingShowVideoPreview", culture);
            encodingNextError = rm.GetString("encodingNextError", culture);
            tooltipVideoBr = rm.GetString("tooltipVideoBr", culture);
            tooltipFileSize = rm.GetString("tooltipFileSize", culture);
            tooltipQuality = rm.GetString("tooltipQuality", culture);
            tooltipVideoCodec = rm.GetString("tooltipVideoCodec", culture);
            tooltipAudioBr = rm.GetString("tooltipAudioBr", culture);
            tooltipAudioCodec = rm.GetString("tooltipAudioCodec", culture);
            tooltipContainer = rm.GetString("tooltipContainer", culture);
            tooltipField = rm.GetString("tooltipField", culture);
            tooltipResize = rm.GetString("tooltipResize", culture);
            tooltipWidthHeight = rm.GetString("tooltipWidthHeight", culture);
            tooltipDenoise = rm.GetString("tooltipDenoise", culture);
            tooltipSub = rm.GetString("tooltipSub", culture);
            customFilterTitle = rm.GetString("customFilterTitle", culture);
            customFilterText = rm.GetString("customFilterText", culture);
            customFilterNote = rm.GetString("customFilterNote", culture);
            customFilterOK = rm.GetString("customFilterOK", culture);
            customFilterCancel = rm.GetString("customFilterCancel", culture);
            updaterTitle = rm.GetString("updaterTitle", culture);
            coreTabTitle = rm.GetString("coreTabTitle", culture);
            pluginsTabTitle = rm.GetString("pluginsTabTitle", culture);
            audioTabTitle = rm.GetString("audioTabTitle", culture);
            videoTabTitle = rm.GetString("videoTabTitle", culture);
            muxingTabTitle = rm.GetString("muxingTabTitle", culture);
            otherTabTitle = rm.GetString("otherTabTitle", culture);
            updateColumn1 = rm.GetString("updateColumn1", culture);
            updateColumn2 = rm.GetString("updateColumn2", culture);
            updateColumn3 = rm.GetString("updateColumn3", culture);
            updateColumn4 = rm.GetString("updateColumn4", culture);
            updateColumn5 = rm.GetString("updateColumn5", culture);
            updateMessage = rm.GetString("updateMessage", culture);
            updateCustomPath = rm.GetString("updateCustomPath", culture);
            updateUpdateButton = rm.GetString("updateUpdateButton", culture);
            updateCancelButton = rm.GetString("updateCancelButton", culture);
            customPathsTitle = rm.GetString("customPathsTitle", culture);
            applicationsButton = rm.GetString("applicationsButton", culture);
            audioDecodingMessage = rm.GetString("audioDecodingMessage", culture);
            audioEncodingMessage = rm.GetString("audioEncodingMessage", culture);
            demuxingMessage = rm.GetString("demuxingMessage", culture);
            demuxingAbortedMessage = rm.GetString("demuxingAbortedMessage", culture);
            demuxingCompleteMessage = rm.GetString("demuxingCompleteMessage", culture);
            demuxingmp4Video = rm.GetString("demuxingmp4Video", culture);
            demuxingmp4Audio = rm.GetString("demuxingmp4Audio", culture);
            demuxingvobChapters = rm.GetString("demuxingvobChapters", culture);
            demuxingvobSubs = rm.GetString("demuxingvobSubs", culture);
            demuxingVob = rm.GetString("demuxingVob", culture);
            muxingMessage = rm.GetString("muxingMessage", culture);
            audioEncodingTrack = rm.GetString("audioEncodingTrack", culture);
            encodingVideoTheora = rm.GetString("encodingVideoTheora", culture);
            encodingVideoPass = rm.GetString("encodingVideoPass", culture);
            indexingAvc = rm.GetString("indexingAvc", culture);
            indexingAvcAbort = rm.GetString("indexingAvcAbort", culture);
            indexingAvcCompleted = rm.GetString("indexingAvcCompleted", culture);
            vfrParsing = rm.GetString("vfrParsing", culture);
            vfrParsingAborted = rm.GetString("vfrParsingAborted", culture);
            vfrParsingCompleted = rm.GetString("vfrParsingCompleted", culture);
            fileInfoFetch = rm.GetString("fileInfoFetch", culture);
            demuxingMkv = rm.GetString("demuxingMkv", culture);
            demuxingMkvAttachments = rm.GetString("demuxingMkvAttachments", culture);
            demuxingMkvChapters = rm.GetString("demuxingMkvChapters", culture);
            errorWarningMessage = rm.GetString("errorWarningMessage", culture);
            errorWarningTitle = rm.GetString("errorWarningTitle", culture);
            encodingComplete = rm.GetString("encodingComplete", culture);
            inputColumn2StatusAborted = rm.GetString("inputColumn2StatusAborted", culture);
            inputColumn2StatusEncoding = rm.GetString("inputColumn2StatusEncoding", culture);
            inputColumn2StatusError = rm.GetString("inputColumn2StatusError", culture);
            inputColumn2StatusReady = rm.GetString("inputColumn2StatusReady", culture);
            inputColumn2StatusDone = rm.GetString("inputColumn2StatusDone", culture);
            menuAdd = rm.GetString("menuAdd", culture);
            menuRemove = rm.GetString("menuRemove", culture);
            menuClear = rm.GetString("menuClear", culture);
            logMenuCopy = rm.GetString("logMenuCopy", culture);
            logMenuSend = rm.GetString("logMenuSend", culture);
        }
    }
}
