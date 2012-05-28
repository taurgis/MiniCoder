using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniCoder2.Templating.Files;

namespace MiniCoder2.Templating
{
    public abstract class TemplateController<T>
    {
        public TemplateDao templateDao;
        public TemplateForm<T> view;
        public T template;

        public TemplateController(TemplateForm<T> view, T template)
        {
            this.view = view;
            this.template = template;
            this.templateDao = new TemplateDao();
        }

        /// <summary>
        /// Save a template to a file.
        /// </summary>
        /// <param name="name">The name of the template.</param>
        public void SaveTemplate(String name)
        {
            
           templateDao.SaveTemplate(name, template, this.template.GetType());
        }

        /// <summary>
        /// Load a template from file.
        /// </summary>
        /// <param name="name">The name of the template.</param>
        public void LoadTemplate(String name)
        {
            this.template = (T)templateDao.LoadTemplate(name, this.template.GetType());
            view.UpdateData(this.template);
        }

        /// <summary>
        /// Get all templates for this type.
        /// </summary>
        /// <returns>Array of template names.</returns>
        public String[] FetchTemplateNames()
        {
            return templateDao.GetTemplatesByType(this.template.GetType());
        }

        /// <summary>
        /// Delete a template.
        /// </summary>
        /// <returns>Wether or not it was successfull.</returns>
        public Boolean DeleteTemplate(String name)
        {
            return templateDao.DeleteTemplate(name, this.template.GetType());
        }

        /// <summary>
        /// Export a template
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        /// <returns>Wether or not it was successfull.</returns>
        public Boolean ExportTemplate(String path)
        {
            return templateDao.ExportTemplate(this.template, this.template.GetType(), path + "\\");
        }

        /// <summary>
        /// Import a template.
        /// </summary>
        /// <param name="path">The import file path.</param>
        /// <returns>The template class for the imported file.</returns>
        public Template ImportTemplate(String path)
        {
            return templateDao.ImportTemplate(path, this.template.GetType());
        }

        /// <summary>
        /// Refresh the view with the updated parameters.
        /// </summary>
        public void RefreshView()
        {
            view.UpdateData(this.template);
        }
    }
}
