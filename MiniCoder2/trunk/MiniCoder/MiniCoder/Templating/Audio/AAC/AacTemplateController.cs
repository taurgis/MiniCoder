using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiniCoder2.Templating.Files;

namespace MiniCoder2.Templating.Audio.AAC
{
    public class AacTemplateController
    {
        private AacTemplate template;
        private TemplateForm view;

        public AacTemplateController(TemplateForm view, AacTemplate template)
        {
            this.view = view;
            this.template = template;
        }

        public void ChangeMode(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    template.Mode = AudioEncodingMode.VBR;
                    break;
                case 1:
                    template.Mode = AudioEncodingMode.CBR;
                    break;
                case 2:
                    template.Mode = AudioEncodingMode.ABR;
                    break;
            }

            RefreshView();
        }

        public void ChangeQuality(Double quality)
        {
            if (quality > 0 && quality <= 1)
                template.Quality = quality;

            RefreshView();
        }

        public void ChangeBitrate(Int32 bitRate)
        {
            if (bitRate > 0)
                template.BitRate = bitRate;

            RefreshView();
        }

        public void ChangeDelay(Int32 delay)
        {
            template.Delay = delay;
            RefreshView();
        }

        public void ChangeProfile(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    template.Profile = AudioEncodingProfile.Automatic;
                    break;
                case 1:
                    template.Profile = AudioEncodingProfile.LC;
                    break;
                case 2:
                    template.Profile = AudioEncodingProfile.HE;
                    break;
                case 3:
                    template.Profile = AudioEncodingProfile.HEv2;
                    break;

            }
            RefreshView();
        }

        public void ChangeChannels(int selectedIndex)
        {
            if (selectedIndex <= 1)
                switch (selectedIndex)
                {
                    case 0:
                        template.Channels = 2;
                        break;
                    case 1:
                        template.Channels = 6;
                        break;
                }

            RefreshView();
        }

        public void ChangeSampleRate(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    template.SampleRate = 0;
                    break;
                case 1:
                    template.SampleRate = 44100;
                    break;
                case 2:
                    template.SampleRate = 48000;
                    break;
                case 3:
                    template.SampleRate = 88200;
                    break;
                case 4:
                    template.SampleRate = 96000;
                    break;
            }
            RefreshView();
        }

        private void RefreshView()
        {
            view.UpdateData();
        }

        public void SaveTemplate()
        {
            if (!String.IsNullOrEmpty(template.Name))
                TemplateDao.SaveTemplate(template, typeof(AacTemplate));
        }
    }
}
