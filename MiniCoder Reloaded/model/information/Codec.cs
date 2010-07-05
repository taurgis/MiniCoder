using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be.miniTech.minicoder.model.information
{
    public class Codec
    {
        public String name { get; set; }
        public String[] ids { get; set; }

        public Codec(String name,String id)
        {
            this.name = name;
            this.ids = new String[] { id };
        }
    }
}
