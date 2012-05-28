using System;
using System.Xml.Serialization;

namespace MiniCoder2.Templating.Audio.AAC
{
    public class AacTemplate : AudioTemplate
    {
        [XmlElement("Mode")]
        public AudioEncodingMode Mode;
        [XmlElement("Quality")]
        public Double Quality;
        [XmlElement("BitRate")]
        public Int32 BitRate;
        [XmlElement("Profile")]
        public AudioEncodingProfile Profile;

        /// <summary>
        /// Empty constructor for serialization
        /// </summary>
        public AacTemplate()
        {
        }

        public AacTemplate(String name)
        {
            this.Name = name;
        }


        public override String GenerateCommandLine()
        {
            String audioQuality = "";
            String sampelingRate = "";
            String profile = "";
            String channelUsed = "";

            if (Channels == AudioChannels.Surround)
                channelUsed = " -6chnew";

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

            switch (Profile)
            {
                case AudioEncodingProfile.Automatic:
                    profile = "";
                    break;
                case AudioEncodingProfile.LC:
                    profile = "-aacprofile_lc";
                    break;
                case AudioEncodingProfile.HE:
                    profile = "-aacprofile_he";
                    break;
                case AudioEncodingProfile.HEv2:
                    profile = "-aacprofile_hev2 ";
                    break;
                default:
                    profile = "";
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

            return "-core( -input <source> -output <target> ) -ota( -d " + Delay.ToString() + " -g max" + ((Normalize) ? (" -norm 0.97 ") : ("")) + " ) " + sampelingRate + " -bsn( -" + Enum.GetName(typeof(AudioEncodingMode), Mode) + " " + audioQuality + " " + profile + channelUsed + " )";
        }

        public Software getSoftware()
        {
            return Software.BeSweet;
        }
    }
}