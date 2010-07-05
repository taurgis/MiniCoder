using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using be.miniTech.minicoder.model.information;
using System.Xml.Serialization;
using System.IO;

namespace be.miniTech.minicoder.dao
{
    public class CodecDao
    {
        private List<Codec> loadCodecsFromFile()
        {
            XmlSerializer serializer =
            new XmlSerializer(typeof(List<Codec>));

            TextReader reader = new StreamReader("codecs.xml", Encoding.Unicode);

            return (List<Codec>)serializer.Deserialize(reader);
        }

        public List<Codec> getAllCodecs()
        {
            return loadCodecsFromFile();
        }
    }
}
