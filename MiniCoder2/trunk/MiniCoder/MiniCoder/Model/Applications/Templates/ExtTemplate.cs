using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.Model.Applications.Templates
{
    public abstract class ExtTemplate
    {
        public String Name { get; set; }

        public virtual String GenerateCommandLine()
        {
            return "";
        }
    }
}
