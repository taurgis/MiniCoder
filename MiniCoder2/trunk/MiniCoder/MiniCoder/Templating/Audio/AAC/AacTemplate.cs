using System;
using System.Xml.Serialization;

namespace MiniCoder2.Templating.Audio.AAC
{
    public class AacTemplate : ExtTemplate
    {
        [XmlElement("Mode")]
        public AudioEncodingMode Mode;
        [XmlElement("Quality")]
        public Double Quality;
        [XmlElement("BitRate")]
        public Int32 BitRate;
        [XmlElement("Delay")]
        public Int32 Delay;
        [XmlElement("Profile")]
        public AudioEncodingProfile Profile;
        [XmlElement("Channels")]
        public short Channels;
        [XmlElement("SampleRate")]
        public Int32 SampleRate;
        [XmlElement("Normalize")]
        public Boolean Normalize;

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

            if (Channels == 6)
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

            if (SampleRate != 0)
                sampelingRate = "-ssrc( --rate " + SampleRate + " )";

            return "-core( -input <source> -output <target> ) -ota( -d " + Delay.ToString() + " -g max" + ((Normalize) ? (" -norm 0.97 ") : ("")) + " ) " + sampelingRate + " -bsn( -" + Enum.GetName(typeof(AudioEncodingMode), Mode) + " " + audioQuality + " " + profile + channelUsed + " )";
        }
    }
}