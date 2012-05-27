using System;
using MiniCoder2.Templating.Files;

namespace MiniCoder2.Templating.Audio.MP3
{
    public class Mp3TemplateController
    {
        private Mp3Template template;
        private TemplateForm<Mp3Template> view;
        private TemplateDao templateDao;

        public Mp3TemplateController(TemplateForm<Mp3Template> view, Mp3Template template)
        {
            this.view = view;
            this.template = template;
            templateDao = new TemplateDao();
        }

        #region "Model - Interface linking"

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

        private void RefreshView()
        {
            view.UpdateData(template);
        }

        #endregion

        /// <summary>
        /// Save a template to a file.
        /// </summary>
        /// <param name="name">The name of the template.</param>
        public void SaveTemplate(String name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                this.template.Name = name;

                templateDao.SaveTemplate(name, template, typeof(Mp3Template));
            }
        }

        /// <summary>
        /// Load a template from file.
        /// </summary>
        /// <param name="name">The name of the template.</param>
        public void LoadTemplate(String name)
        {
            this.template = (Mp3Template)templateDao.LoadTemplate(name, typeof(Mp3Template));
            view.UpdateData(this.template);
        }

        /// <summary>
        /// Get all templates for this type.
        /// </summary>
        /// <returns>Array of template names.</returns>
        public String[] FetchTemplateNames()
        {
            return templateDao.GetTemplatesByType(typeof(Mp3Template));
        }

        /// <summary>
        /// Delete a template.
        /// </summary>
        /// <returns>Wether or not it was successfull.</returns>
        public Boolean DeleteTemplate()
        {
            return templateDao.DeleteTemplate(template.Name, typeof(Mp3Template));
        }

        /// <summary>
        /// Export a template
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        /// <returns>Wether or not it was successfull.</returns>
        public Boolean ExportTemplate(String path)
        {
            return templateDao.ExportTemplate(this.template, typeof(Mp3Template), path + "\\");
        }

        /// <summary>
        /// Import a template.
        /// </summary>
        /// <param name="path">The import file path.</param>
        /// <returns>The template class for the imported file.</returns>
        public ExtTemplate ImportTemplate(String path)
        {
            return templateDao.ImportTemplate(path, typeof(Mp3Template));
        }
    }
}
