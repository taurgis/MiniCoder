﻿using System;
using System.Xml.Serialization;

namespace MiniCoder2.Templating.Audio.DTS
{
    public class DtsTemplate : AudioTemplate
    {
        [XmlElement("DownConvert")]
        public Boolean DownConvert;
        [XmlElement("ExtractDtsCore")]
        public Boolean ExtractDtsCore;

        /// <summary>
        /// Empty constructor for serialization
        /// </summary>
        public DtsTemplate()
        {
        }

        public DtsTemplate(String name)
        {
            this.Name = name;
        }

        public override String GenerateCommandLine()
        {
            String sampelingRate = "";
            String channelUsed = "";
            String downConvert = "";
            String normalize = "";
            String delay = "";
            switch (Channels)
            {
                case AudioChannels.Stereo:
                    channelUsed = " -down2";
                    break;
                case AudioChannels.Surround:
                    channelUsed = " -down6";
                    break;
            }

            if (Delay > 0)
            {
                delay = " +" + Delay + "ms";
            }
            else if (Delay < 0)
            {
                delay = " " + Delay + "ms";
            }

            if (Normalize)
                normalize = " -normalize";

            switch (SampleRate)
            {
                case Templating.SampleRate.Hz44100:
                    sampelingRate = " -resampleTo44100";
                    break;
                case Templating.SampleRate.Hz48000:
                    sampelingRate = " -resampleTo48000";
                    break;
                case Templating.SampleRate.Hz88200:
                    sampelingRate = " -resampleTo88200";
                    break;
                case Templating.SampleRate.Hz96000:
                    sampelingRate = " -resampleTo96000";
                    break;
            }

            if (DownConvert)
                downConvert = " -down16";

            return "\"<source>\" \"<target>\" " + ((ExtractDtsCore) ? ("-core") : (normalize + downConvert + channelUsed + sampelingRate)) + delay + " -progressnumbers";
        }

        public Software getSoftware()
        {
            return Software.Eac3to;
        }
    }
}