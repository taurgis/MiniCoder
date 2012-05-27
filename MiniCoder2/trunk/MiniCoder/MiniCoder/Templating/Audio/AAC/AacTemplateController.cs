using System;
using MiniCoder2.Templating.Files;

namespace MiniCoder2.Templating.Audio.AAC
{
    public class AacTemplateController : AudioTemplateController<AacTemplate>
    {
        public AacTemplateController(TemplateForm<AacTemplate> view, AacTemplate template)
            : base(view, template)
        {
            this.view = view;
            this.template = template;
        }

        public void ChangeMode(int selectedIndex)
        {
            this.template.Mode = (AudioEncodingMode)selectedIndex;

            RefreshView();
        }

        public void ChangeQuality(Double quality)
        {
            if (quality > 0 && quality <= 1)
            {
                this.template.BitRate = ((int)(quality * (double)10) * 32);
                this.template.Quality = quality;
            }
            RefreshView();
        }

        public void ChangeBitrate(Int32 bitRate)
        {
            if (bitRate > 0)
                this.template.BitRate = bitRate;

            RefreshView();
        }

        public void ChangeDelay(Int32 delay)
        {
            this.template.Delay = delay;
            RefreshView();
        }

        public void ChangeProfile(int selectedIndex)
        {
            this.template.Profile = (AudioEncodingProfile)selectedIndex;
            RefreshView();
        }

        public void ChangeChannels(int selectedIndex)
        {
            if (selectedIndex <= 2)
                switch (selectedIndex)
                {
                    case 0:
                        this.template.Channels = AudioChannels.Mono;
                        break;
                    case 1:
                        this.template.Channels = AudioChannels.Stereo;
                        break;
                    case 2:
                        this.template.Channels = AudioChannels.Surround;
                        break;
                }

            RefreshView();
        }

        public void ChangeSampleRate(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    this.template.SampleRate = SampleRate.Original;
                    break;
                case 1:
                    this.template.SampleRate = SampleRate.Hz44100;
                    break;
                case 2:
                    this.template.SampleRate = SampleRate.Hz48000;
                    break;
                case 3:
                    this.template.SampleRate = SampleRate.Hz88200;
                    break;
                case 4:
                    this.template.SampleRate = SampleRate.Hz96000;
                    break;
            }
            RefreshView();
        }

        public void ChangeNormalize(Boolean normalize)
        {
            this.template.Normalize = normalize;
            RefreshView();
        }

    }
}