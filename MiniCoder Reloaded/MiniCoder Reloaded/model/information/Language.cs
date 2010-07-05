using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be.miniTech.minicoder.model.information
{
   public class Language
    {
       public string name {get;set;}
       public string code { get; set; }

       public Language(string name, string code)
       {
           this.name = name;
           this.code = code;
       }
    }
}
