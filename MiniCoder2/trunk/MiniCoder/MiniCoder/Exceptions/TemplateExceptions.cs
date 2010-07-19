using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.Exceptions
{
    public class UknownModeException : Exception
    {
        public UknownModeException()
        {
            this.Source = "An unknown modus has been selected for the template.";
        }
    }

    public class TemplateNotFoundException : Exception
    {
        public TemplateNotFoundException(String path)
        {
            this.Source = "Unable to find codec file:" + path;
        }
    }
}
