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
        private TemplateInterface view;

        public TemplateController(TemplateInterface view, ExtTemplate template)
        {
            this.view = view;
            this.template = template;
        }

        public void GenerateCommandLine()
        {
            view.ShowCommandLine();
        }
    }
}
