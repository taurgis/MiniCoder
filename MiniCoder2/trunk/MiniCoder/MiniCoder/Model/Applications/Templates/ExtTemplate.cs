using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.Model.Applications.Templates
{
    public abstract class ExtTemplate
    {
        public String Name { get; set; }

        public ExtTemplate()
        {
            this.Name = "";
        }

        public ExtTemplate(String name)
        {
            this.Name = name;
        }

        public String GenerateCommandLine()
        {
            return "";
        }
    }
}
