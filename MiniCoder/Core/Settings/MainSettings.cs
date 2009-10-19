using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
namespace MiniCoder.Core.Settings
{
    class MainSettings
    {
        public string outputPath { get; set; }
        public bool disableVideoAdvert { get; set; }
        public string processPriority { get; set; }
        public bool ignoreAudio { get; set; }
        public bool ignoreSubs { get; set; }
        public bool ignoreAttachments { get; set; }
        public bool ignoreChapters { get; set; }

        public void saveSettings()
        {
            XmlTextWriter xmlWriter = new XmlTextWriter(Application.StartupPath + "\\settings.xml", null);
          
            xmlWriter.Formatting = Formatting.Indented;

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("SimpleSettings");

            writeElement(xmlWriter, "outputPath", outputPath);
            writeElement(xmlWriter, "disableVideoAdvert", disableVideoAdvert.ToString());
            writeElement(xmlWriter, "processPriority", processPriority);
            writeElement(xmlWriter, "ignoreAudio", ignoreAudio.ToString());
            writeElement(xmlWriter, "ignoreSubs", ignoreSubs.ToString());
            writeElement(xmlWriter, "ignoreAttachments", ignoreAttachments.ToString());
            writeElement(xmlWriter, "ignoreChapters", ignoreChapters.ToString());


            xmlWriter.WriteEndElement();
            xmlWriter.Close();
           
        }

        private void writeElement(XmlTextWriter writer, string element, string value)
        {
            writer.WriteStartElement("Setting");
            writer.WriteAttributeString("name", element);
            writer.WriteElementString("setting", value);
            writer.WriteEndElement();
        }
    }
}
