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
        private TemplateDao templateDao;

        public AacTemplateController(TemplateForm view, AacTemplate template)
        {
            this.view = view;
            this.template = template;
            templateDao = new TemplateDao();
        }

        public void ChangeMode(int selectedIndex)
        {
            this.template.Mode = (AudioEncodingMode)selectedIndex;

            RefreshView();
        }

        public void ChangeQuality(Double quality)
        {
            if (quality > 0 && quality <= 1)
                this.template.Quality = quality;

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
            if (selectedIndex <= 1)
                switch (selectedIndex)
                {
                    case 0:
                        this.template.Channels = 2;
                        break;
                    case 1:
                        this.template.Channels = 6;
                        break;
                }

            RefreshView();
        }

        public void ChangeSampleRate(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    this.template.SampleRate = 0;
                    break;
                case 1:
                    this.template.SampleRate = 44100;
                    break;
                case 2:
                    this.template.SampleRate = 48000;
                    break;
                case 3:
                    this.template.SampleRate = 88200;
                    break;
                case 4:
                    this.template.SampleRate = 96000;
                    break;
            }
            RefreshView();
        }

        private void RefreshView()
        {
            view.UpdateData(template);
        }

        public void SaveTemplate(String name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                this.template.Name = name;

                templateDao.SaveTemplate(template, typeof(AacTemplate));
            }
        }

        public String[] FetchTemplateNames()
        {
            return templateDao.GetTemplatesByType(typeof(AacTemplate));
        }

        public void LoadTemplate(String name)
        {
            this.template = (AacTemplate)templateDao.LoadTemplate(name, typeof(AacTemplate));
            view.UpdateData(this.template);
        }

        public Boolean DeleteTemplate(String name)
        {
            return templateDao.DeleteTemplate(name, typeof(AacTemplate));
        }
    }
}
