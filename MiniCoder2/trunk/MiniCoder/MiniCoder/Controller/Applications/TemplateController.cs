using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiniCoder2.View;
using MiniCoder2.Model.Applications.Templates;

namespace MiniCoder2.Controller.Applications
{
    public class TemplateController
    {
        private ExtTemplate template;
        private TemplateForm view;

        public TemplateController(TemplateForm view, ExtTemplate template)
        {
            this.view = view;
            this.template = template;
        }

        /// <summary>
        /// Updates the model with the data from the interface. After that we check 
        /// whether or not the template is valid. If the template is valid we update 
        /// the command line.
        /// </summary>
        public void GenerateCommandLine()
        {
            view.UpdateModel();

            if (template.IsValid())
                view.SetCommandLine(template.GenerateCommandLine());
        }

    }
}
