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

            if (xmlnode.Count != 0)
                outputPath = xmlnode[0].ChildNodes[0].InnerText;
            else
                outputPath = "";

            xmlnode = doc.SelectNodes("//Setting[@name=\"" + "disableVideoAdvert" + "\"]");

            if (xmlnode.Count != 0)
                disableVideoAdvert = Boolean.Parse(xmlnode[0].ChildNodes[0].InnerText);
            else
                disableVideoAdvert = false;

            xmlnode = doc.SelectNodes("//Setting[@name=\"" + "processPriority" + "\"]");

            if (xmlnode.Count != 0)
            {
                if (xmlnode[0].ChildNodes[0].InnerText != "-1")
                    processPriority = xmlnode[0].ChildNodes[0].InnerText;
                else
                    processPriority = "0";
            }
            else
                processPriority = "0";

            xmlnode = doc.SelectNodes("//Setting[@name=\"" + "ignoreAudio" + "\"]");

            if (xmlnode.Count != 0)
                ignoreAudio = Boolean.Parse(xmlnode[0].ChildNodes[0].InnerText);
            else
                ignoreAudio = false;

            xmlnode = doc.SelectNodes("//Setting[@name=\"" + "ignoreSubs" + "\"]");

            if (xmlnode.Count != 0)
                ignoreSubs = Boolean.Parse(xmlnode[0].ChildNodes[0].InnerText);
            else
                ignoreSubs = false;

            xmlnode = doc.SelectNodes("//Setting[@name=\"" + "ignoreAttachments" + "\"]");

            if (xmlnode.Count != 0)
                ignoreAttachments = Boolean.Parse(xmlnode[0].ChildNodes[0].InnerText);
            else
                ignoreAttachments = false;

            xmlnode = doc.SelectNodes("//Setting[@name=\"" + "ignoreChapters" + "\"]");

            if (xmlnode.Count != 0)
                ignoreChapters = Boolean.Parse(xmlnode[0].ChildNodes[0].InnerText);
            else
                ignoreChapters = false;

            xmlnode = doc.SelectNodes("//Setting[@name=\"" + "continueAfterError" + "\"]");

            if (xmlnode.Count != 0)
                continueAfterError = Boolean.Parse(xmlnode[0].ChildNodes[0].InnerText);
            else
                continueAfterError = false;

            xmlnode = doc.SelectNodes("//Setting[@name=\"" + "language" + "\"]");

            if (xmlnode.Count != 0)
            {
                if (xmlnode[0].ChildNodes[0].InnerText != "-1")
                    language = int.Parse(xmlnode[0].ChildNodes[0].InnerText);
                else
                    language = 0;
            }
            else
                language = 0;

        }


    }
}
