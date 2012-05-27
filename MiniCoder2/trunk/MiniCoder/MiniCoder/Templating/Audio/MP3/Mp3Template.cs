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
        [XmlIgnore]
        public SampleRate SampleRate;
        [XmlElement("SampleRate")]
        public byte SampleRateByte
        {
            get { return (byte)SampleRate; }
            set { SampleRate = (SampleRate)value; }
        }
        [XmlElement("Normalize")]
        public Boolean Normalize;

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

            switch (SampleRate)
            {
                case Templating.SampleRate.Hz44100:
                    sampelingRate = "-ssrc( --rate 44100 )";
                    break;
                case Templating.SampleRate.Hz48000:
                    sampelingRate = "-ssrc( --rate 48000 )";
                    break;
                case Templating.SampleRate.Hz88200:
                    sampelingRate = "-ssrc( --rate 88200 )";
                    break;
                case Templating.SampleRate.Hz96000:
                    sampelingRate = "-ssrc( --rate 96000 )";
                    break;
            }

            return "-core( -input <source> -output <target> ) -ota( -d " + Delay.ToString() + " -g max" + ((Normalize) ? (" -norm 0.97 ") : ("")) + " ) " + sampelingRate + " -lame( " + bitrate + " )";
        }
    }
}