using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniCoder2.Exceptions;

namespace MiniCoder2.Model.Applications.Templates
{
    public class AacTemplate : ExtTemplate
    {
        public AudioEncodingMode Mode { get; set; }
        public Double Quality { get; set; }
        public Int32 BitRate { get; set; }
        public Int32 Delay { get; set; }
        public AudioEncodingProfile Profile { get; set; }
        public short Channels { get; set; }
        public Int32 SampleRate { get; set; }

        public AacTemplate(String name)
        {
            this.Name = name;
        }

        public override String GenerateCommandLine()
        {
            String audioQuality = "";
            String sampelingRate = "";
            String profile = "";

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

            return "-core( -input <source> -output <target> ) -ota( -d " + Delay.ToString() + " -g max ) " + sampelingRate + " -bsn( -" + Enum.GetName(typeof(AudioEncodingMode), Mode) + " " + audioQuality + " " + profile + " )";
        }
    }
}
