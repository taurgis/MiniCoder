using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
namespace MiniCoder.Core.Settings
{
    public class MainSettings
    {
        public string outputPath { get; set; }
        public bool disableVideoAdvert { get; set; }
        public string processPriority { get; set; }
        public bool ignoreAudio { get; set; }
        public bool ignoreSubs { get; set; }
        public bool ignoreAttachments { get; set; }
        public bool ignoreChapters { get; set; }
        public bool continueAfterError { get; set; }
        public int language { get; set; }

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
            writeElement(xmlWriter, "continueAfterError", continueAfterError.ToString());
            writeElement(xmlWriter, "language", language.ToString());

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

        public void loadSettings()
        {

            XmlDocument doc = new XmlDocument();

            string xmlFile = Application.StartupPath + "\\settings.xml";
            doc.Load(xmlFile);
            XmlNodeList xmlnode = doc.SelectNodes("//Setting[@name=\"" + "outputPath" + "\"]");
            outputPath = xmlnode[0].ChildNodes[0].InnerText;

            xmlnode = doc.SelectNodes("//Setting[@name=\"" + "disableVideoAdvert" + "\"]");
            disableVideoAdvert = Boolean.Parse(xmlnode[0].ChildNodes[0].InnerText);

            xmlnode = doc.SelectNodes("//Setting[@name=\"" + "processPriority" + "\"]");
            processPriority = xmlnode[0].ChildNodes[0].InnerText;

             xmlnode = doc.SelectNodes("//Setting[@name=\"" + "ignoreAudio" + "\"]");
            ignoreAudio = Boolean.Parse(xmlnode[0].ChildNodes[0].InnerText);

             xmlnode = doc.SelectNodes("//Setting[@name=\"" + "ignoreSubs" + "\"]");
            ignoreSubs = Boolean.Parse(xmlnode[0].ChildNodes[0].InnerText);

             xmlnode = doc.SelectNodes("//Setting[@name=\"" + "ignoreAttachments" + "\"]");
            ignoreAttachments = Boolean.Parse(xmlnode[0].ChildNodes[0].InnerText);

             xmlnode = doc.SelectNodes("//Setting[@name=\"" + "ignoreChapters" + "\"]");
            ignoreChapters = Boolean.Parse(xmlnode[0].ChildNodes[0].InnerText);

            xmlnode = doc.SelectNodes("//Setting[@name=\"" + "continueAfterError" + "\"]");
            continueAfterError = Boolean.Parse(xmlnode[0].ChildNodes[0].InnerText);

            xmlnode = doc.SelectNodes("//Setting[@name=\"" + "language" + "\"]");
            language = int.Parse(xmlnode[0].ChildNodes[0].InnerText);

        }
    }
}
