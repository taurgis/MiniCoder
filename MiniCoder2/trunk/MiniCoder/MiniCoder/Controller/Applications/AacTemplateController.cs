using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiniCoder2.View;
using MiniCoder2.Model.Applications.Templates;

namespace MiniCoder2.Controller.Applications
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
        }

      

    }
}
