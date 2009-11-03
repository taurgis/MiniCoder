using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Globalization;

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
            }

            rm = new ResourceManager("MiniCoder.Core.Languages.language", typeof(SysLanguage).Assembly);
            programTitle = rm.GetString("programTitle", culture);
            inputTabTitle = rm.GetString("inputTabTitle", culture);
            settingsTabTitle = rm.GetString("settingsTabTitle", culture);
            optionsTabTitle = rm.GetString("optionsTabTitle", culture);
            logTabTitle = rm.GetString("logTabTitle", culture);
            newsTabTitle = rm.GetString("newsTabTitle", culture);
            inputColumn1Title = rm.GetString("inputColumn1Title", culture);
            inputColumn2StatusTitle = rm.GetString("inputColumn2StatusTitle", culture);
            encodeStartButton = rm.GetString("encodeStartButton", culture);
            encodeStopButton = rm.GetString("encodeStopButton", culture);
            whenDone = rm.GetString("whenDone", culture);
            infoLabel = rm.GetString("infoLabel", culture);
            whenDoneOptions = rm.GetString("whenDoneOptions",culture).Split(Char.Parse(";"));
            videoOptionsTitle = rm.GetString("videoOptionsTitle", culture);
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
        }
    }
}
