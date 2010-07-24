using System;
using System.Xml.Serialization;

namespace MiniCoder2.Templating.Audio.MP3
{
    public class Mp3Template : ExtTemplate
    {
        [XmlElement("Mode")]
        public AudioEncodingMode Mode;
        [XmlElement("Quality")]
        public Double Quality;
        [XmlElement("BitRate")]
        public Int32 BitRate;
        [XmlElement("Delay")]
        public Int32 Delay;
        [XmlElement("SampleRate")]
        public Int32 SampleRate;

        /// <summary>
        /// Empty constructor for serialization
        /// </summary>
        public Mp3Template()
        {
        }

        public Mp3Template(String name)
        {
            this.Name = name;
        }


        public override String GenerateCommandLine()
        {
            String audioQuality = "";
            String sampelingRate = "";
            String bitrate = "";

            switch (Mode)
            {
                case AudioEncodingMode.VBR:
                    int quality = (int)(Quality * (double)10);
                    bitrate = "-v --vbr-new -V " + (10 - quality) + " -b " + BitRate + " -h";
                    break;
                case AudioEncodingMode.ABR:
                    bitrate = "--abr " + BitRate + " -h";
                    break;
                case AudioEncodingMode.CBR:
                    bitrate = "-b " + BitRate + " -h";
                    break;
            }

            switch (Mode)
            {
                case AudioEncodingMode.ABR:
                case AudioEncodingMode.CBR:
                    audioQuality = BitRate.ToString();
                    break;
                case AudioEncodingMode.VBR:
                    audioQuality = Quality.ToString();
                    break;
            }

            if (SampleRate != 0)
                sampelingRate = "-ssrc( --rate " + SampleRate + " )";

            return "-core( -input <source> -output <target> ) -ota( -d " + Delay.ToString() + " -g max ) " + sampelingRate + " -lame( " + bitrate + " )";
        }
    }
}
