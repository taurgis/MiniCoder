using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.View
{
    public interface TemplateForm
    {
         void SetCommandLine(String commando);
         void UpdateModel();
    }
}
