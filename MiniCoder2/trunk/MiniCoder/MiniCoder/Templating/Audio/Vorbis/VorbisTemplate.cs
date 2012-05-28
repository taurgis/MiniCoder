using System;
using System.Xml.Serialization;
using MiniCoder2.Exceptions;

namespace MiniCoder2.Templating.Audio.Vorbis
{
    public class VorbisTemplate : AudioTemplate
    {
        [XmlElement("Mode")]
        public AudioEncodingMode Mode;
        [XmlElement("Quality")]
        public Double Quality;
        [XmlElement("BitRate")]
        public Int32 BitRate;

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

            switch (SampleRate)
            {
                case Templating.SampleRate.Hz44100:
                    if (Channels != AudioChannels.Surround)
                        sampelingRate = "-ssrc( --rate 44100 )";
                    else
                        sampelingRate = " -ar 44100";
                    break;
                case Templating.SampleRate.Hz48000:
                    if (Channels != AudioChannels.Surround)
                        sampelingRate = "-ssrc( --rate 48000 )";
                    else
                        sampelingRate = " -ar 48000";
                    break;
                case Templating.SampleRate.Hz88200:
                    if (Channels != AudioChannels.Surround)
                        sampelingRate = "-ssrc( --rate 88200 )";
                    else
                        sampelingRate = " -ar 88200";
                    break;
                case Templating.SampleRate.Hz96000:
                    if (Channels != AudioChannels.Surround)
                        sampelingRate = "-ssrc( --rate 96000 )";
                    else
                        sampelingRate = " -ar 96000";
                    break;
            }

            if (Channels == AudioChannels.Surround)
            {
                return " -i \"<source>\"" + ((this.Mode == AudioEncodingMode.VBR) ? (" -aq " + (Quality * 10)) : (" -ab " + BitRate + "k")) + " -acodec libvorbis -ac 6" + sampelingRate + " -y \"<target>\"";
            }
            else
            {
                return "-core( -input <source> -output <target> ) -ota( -d " + Delay.ToString() + " -g max" + ((Normalize) ? (" -norm 0.97 ") : ("")) + " ) " + sampelingRate + " -ogg( " + bitrate + " )";
            }
        }

        public Software getSoftware()
        {
            if (Channels == AudioChannels.Surround)
                return Software.Eac3to;
            else
                return Software.BeSweet;
        }
    }
}
