using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniCoder2.Exceptions;
using MiniCoder2.View;

namespace MiniCoder2.Model.Applications.Templates
{
    public class AacTemplate : ExtTemplate
    {
        private TemplateForm view;

        private AudioEncodingMode mode;
        public AudioEncodingMode Mode
        {
            get
            {
                return this.mode;
            }
            set
            {
                this.mode = value;
                UpdateView();
            }
        }

        private Double quality;
        public Double Quality
        {
            get
            { return this.quality; }
            set
            {
                this.quality = value;
                UpdateView();
            }
        }

        private Int32 bitRate;
        public Int32 BitRate
        {
            get
            { return this.bitRate; }
            set
            {
                this.bitRate = value;
                UpdateView();
            }
        }

        private Int32 delay;
        public Int32 Delay
        {
            get
            { return this.delay; }
            set
            {
                this.delay = value;
                UpdateView();
            }
        }

        private AudioEncodingProfile profile;
        public AudioEncodingProfile Profile
        {
            get
            { return this.profile; }
            set
            {
                this.profile = value;
                UpdateView();
            }
        }

        private short channels;
        public short Channels
        {
            get
            { return this.channels; }
            set
            {
                this.channels = value;
                UpdateView();
            }
        }

        private Int32 sampleRate;
        public Int32 SampleRate
        {
            get
            { return this.sampleRate; }
            set
            {
                this.sampleRate = value;
                UpdateView();
            }
        }

        public AacTemplate(String name)
        {
            this.Name = name;
        }

        public void SetObserver(TemplateForm view)
        {
            this.view = view;
        }

        private void UpdateView()
        {
            view.UpdateData(this);
        }

        public override String GenerateCommandLine()
        {
            String audioQuality = "";
            String sampelingRate = "";
            String profile = "";
            String channelUsed = "";

            if (channels == 6)
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

            return "-core( -input <source> -output <target> ) -ota( -d " + Delay.ToString() + " -g max ) " + sampelingRate + " -bsn( -" + Enum.GetName(typeof(AudioEncodingMode), Mode) + " " + audioQuality + " " + profile + channelUsed +" )";
        }
    }
}
