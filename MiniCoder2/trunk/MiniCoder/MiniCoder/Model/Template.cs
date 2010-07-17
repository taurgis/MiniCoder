using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MiniCoder2.Model.Applications.Templates;

namespace MiniCoder2.Model
{
    public class Template
    {
        public String Name { get; set; }
        public ExtTemplate AudioTemplate { get; set; }
        public ExtTemplate VideoTemplate { get; set; }

        public Template() 
        {
            this.Name = "";
        }

        public Template(String name)
        {
            this.Name = name;
        }

    }
}
