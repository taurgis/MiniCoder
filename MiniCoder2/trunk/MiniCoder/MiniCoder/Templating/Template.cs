using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.Templating
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
