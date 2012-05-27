using System;
using System.Xml.Serialization;

namespace MiniCoder2.Templating.Audio.WAV
{
    public class WavTemplate : ExtTemplate
    {
        [XmlElement("Delay")]
        public Int32 Delay;
        [XmlIgnore]
        public AudioChannels Channels;
        [XmlElement("Channels")]
        public byte ChannelsByte
        {
            get { return (byte)Channels; }
            set { Channels = (AudioChannels)value; }
        }
        [XmlIgnore]
        public SampleRate SampleRate;
        [XmlElement("SampleRate")]
        public byte SampleRateByte
        {
            get { return (byte)SampleRate; }
            set { SampleRate = (SampleRate)value; }
        }
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

            return "\"<source>\" \"<target>\" " + "-"+BitRate + normalize + downConvert + channelUsed + sampelingRate + delay + " -progressnumbers";
        }
    }
}