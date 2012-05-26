using System;
using System.Xml.Serialization;

namespace MiniCoder2.Templating.Audio.WAV
{
    public class WavTemplate : ExtTemplate
    {
        [XmlElement("Delay")]
        public Int32 Delay;
        [XmlElement("Channels")]
        public short Channels;
        [XmlElement("SampleRate")]
        public Int32 SampleRate;
        [XmlElement("DownConvert")]
        public Boolean DownConvert;
        [XmlElement("Normalize")]
        public Boolean Normalize;
        [XmlElement("BitRate")]
        public Int32 BitRate;
        /// <summary>
        /// Empty constructor for serialization
        /// </summary>
        public WavTemplate()
        {
        }

        public WavTemplate(String name)
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
                case 2:
                    channelUsed = " -down2";
                    break;
                case 6:
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

            if (SampleRate != 0)
                sampelingRate = " -resampleTo" + SampleRate;

            if (DownConvert)
                downConvert = " -down16";

            return "\"<source>\" \"<target>\" " + "-"+BitRate + normalize + downConvert + channelUsed + sampelingRate + delay + " -progressnumbers";
        }
    }
}