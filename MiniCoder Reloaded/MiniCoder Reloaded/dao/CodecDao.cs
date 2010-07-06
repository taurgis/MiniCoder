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
            if (!File.Exists("codecs.xml"))
                return new List<Codec>();

            XmlSerializer serializer =
            new XmlSerializer(typeof(Codec[]));

            TextReader reader = new StreamReader("codecs.xml");
            Codec[] returnList = (Codec[])serializer.Deserialize(reader);
            reader.Close();

            return new List<Codec>(returnList);
        }

        public List<Codec> getAllCodecs()
        {
            return loadCodecsFromFile();
        }

        public Codec getCodecByKey(String key)
        {
            List<Codec> codecs = loadCodecsFromFile();
            for (int i = 0; i < codecs.Count; i++)
            {
                Codec tempCodec = codecs[i];
                String[] keys = tempCodec.ids;
                if (keys.Contains(key))
                    return tempCodec;
            }

            // Returning null codec, we do this to tell the program to use 
            // FFMPEG to decode the audio since it has the most support for 
            // all types of audio. When it is a video we can just use 
            // DirectShowSource in avs.
            return Codec.NULL_CODEC;
        }
    }
}
