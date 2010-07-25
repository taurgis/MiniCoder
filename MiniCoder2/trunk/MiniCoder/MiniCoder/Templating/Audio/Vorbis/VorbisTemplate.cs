using System;
using System.Xml.Serialization;
using MiniCoder2.Exceptions;

namespace MiniCoder2.Templating.Audio.Vorbis
{
    public class VorbisTemplate : ExtTemplate
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
        public VorbisTemplate()
        {
        }

        public VorbisTemplate(String name)
        {
            this.Name = name;
        }


        public override String GenerateCommandLine()
        {
            String sampelingRate = "";
            String bitrate = "";

            switch (Mode)
            {
                case AudioEncodingMode.VBR:
                    int quality = (int)(Quality * (double)10);
                    bitrate = "-q " + Quality;
                    break;
                case AudioEncodingMode.CBR:
                    bitrate = "-b " + BitRate;
                    break;
                default:
                    throw new UknownModeException();
            }


            if (SampleRate != 0)
                sampelingRate = "-ssrc( --rate " + SampleRate + " )";

            return "-core( -input <source> -output <target> ) -ota( -d " + Delay.ToString() + " -g max ) " + sampelingRate + " -ogg( " + bitrate + " )";
        }
    }
}
