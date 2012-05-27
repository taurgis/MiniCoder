using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniCoder2.Templating.Files;

namespace MiniCoder2.Templating.Audio
{
    public abstract class AudioTemplateController<T>
    {
        public TemplateDao templateDao;
        public TemplateForm<T> view;
        public T template;

        public AudioTemplateController(TemplateForm<T> view, T template)
        {
            this.view = view;
            this.template = template;
            templateDao = new TemplateDao();
        }

        /// <summary>
        /// Save a template to a file.
        /// </summary>
        /// <param name="name">The name of the template.</param>
        public void SaveTemplate(String name, Type classType)
        {
           templateDao.SaveTemplate(name, template, classType);
        }

        /// <summary>
        /// Load a template from file.
        /// </summary>
        /// <param name="name">The name of the template.</param>
        public void LoadTemplate(String name, Type classType)
        {
            this.template = (T)templateDao.LoadTemplate(name, classType);
            view.UpdateData(this.template);
        }

        /// <summary>
        /// Get all templates for this type.
        /// </summary>
        /// <returns>Array of template names.</returns>
        public String[] FetchTemplateNames(Type classType)
        {
            return templateDao.GetTemplatesByType(classType);
        }

        /// <summary>
        /// Delete a template.
        /// </summary>
        /// <returns>Wether or not it was successfull.</returns>
        public Boolean DeleteTemplate(String name, Type classType)
        {
            return templateDao.DeleteTemplate(name, classType);
        }

        /// <summary>
        /// Export a template
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        /// <returns>Wether or not it was successfull.</returns>
        public Boolean ExportTemplate(String path, Type classType)
        {
            return templateDao.ExportTemplate(this.template, classType, path + "\\");
        }

        /// <summary>
        /// Import a template.
        /// </summary>
        /// <param name="path">The import file path.</param>
        /// <returns>The template class for the imported file.</returns>
        public ExtTemplate ImportTemplate(String path, Type classType)
        {
            return templateDao.ImportTemplate(path, classType);
        }
    }
}
