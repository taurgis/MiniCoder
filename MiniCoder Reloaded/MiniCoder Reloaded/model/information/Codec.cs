using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace be.miniTech.minicoder.model.information
{
    [XmlRoot("Codec")]
    public class Codec
    {
        [XmlElement("name")]
        public String name { get; set; }
        [XmlArray("keys")]
        public String[] ids { get; set; }

        public Codec()
        {
        }

        public Codec(String name, String id)
        {
            this.name = name;
            this.ids = new String[] { id };
        }

        public Codec(String name, String[] ids)
        {
            this.name = name;
            this.ids = ids;
        }
    }
}
