﻿using System;
using MiniCoder2.Templating.Files;

namespace MiniCoder2.Templating.Audio.FLAC
{
    public class FlacTemplateController
    {
        private FlacTemplate template;
        private TemplateForm view;
        private TemplateDao templateDao;

        public FlacTemplateController(TemplateForm view, FlacTemplate template)
        {
            this.view = view;
            this.template = template;
            templateDao = new TemplateDao();
        }

        #region "Model - Interface linking"
      
        public void ChangeDelay(Int32 delay)
        {
            this.template.Delay = delay;
            RefreshView();
        }
     
        public void ChangeChannels(int selectedIndex)
        {
            if (selectedIndex <= 2)
                switch (selectedIndex)
                {
                    case 0:
                        this.template.Channels = 1;
                        break;
                    case 1:
                        this.template.Channels = 2;
                        break;
                    case 2:
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

        public void ChangeDownConvert(Boolean isChecked)
        {
            this.template.DownConvert = isChecked;
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

                templateDao.SaveTemplate(template, typeof(FlacTemplate));
            }
        }

        /// <summary>
        /// Load a template from file.
        /// </summary>
        /// <param name="name">The name of the template.</param>
        public void LoadTemplate(String name)
        {
            this.template = (FlacTemplate)templateDao.LoadTemplate(name, typeof(FlacTemplate));
            view.UpdateData(this.template);
        }

        /// <summary>
        /// Get all templates for this type.
        /// </summary>
        /// <returns>Array of template names.</returns>
        public String[] FetchTemplateNames()
        {
            return templateDao.GetTemplatesByType(typeof(FlacTemplate));
        }

        /// <summary>
        /// Delete a template.
        /// </summary>
        /// <returns>Wether or not it was successfull.</returns>
        public Boolean DeleteTemplate()
        {
            return templateDao.DeleteTemplate(template.Name, typeof(FlacTemplate));
        }

        /// <summary>
        /// Export a template
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        /// <returns>Wether or not it was successfull.</returns>
        public Boolean ExportTemplate(String path)
        {
            return templateDao.ExportTemplate(this.template, typeof(FlacTemplate), path + "\\");
        }

        /// <summary>
        /// Import a template.
        /// </summary>
        /// <param name="path">The import file path.</param>
        /// <returns>The template class for the imported file.</returns>
        public ExtTemplate ImportTemplate(String path)
        {
            return templateDao.ImportTemplate(path, typeof(FlacTemplate));
        }
    }
}
