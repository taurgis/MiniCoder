using System;
using MiniCoder2.Templating.Files;

namespace MiniCoder2.Templating.Audio.MP3
{
    public class Mp3TemplateController : TemplateController<Mp3Template>
    {
        public Mp3TemplateController(TemplateForm<Mp3Template> view, Mp3Template template) : base(view, template)
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
