//    MiniCoder
//    Copyright (C) 2009-2010  MiniTech support@minitech.org
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
namespace MiniCoder.Templates.Simple
{
    class MainTemplate
    {
        public string templateName { get; set; }

        public string selectedVideo { get; set; }
        public string vidBitRate { get; set; }
        public string fileSize { get; set; }
        public string vidQuality { get; set; }
        public string vidCodec { get; set; }

        public string fieldFilter { get; set; }
        public string resizeFilter { get; set; }
        public string widthHeight { get; set; }

        public string audBitrate { get; set; }
        public string audCodec { get; set; }
        public string containerFormat { get; set; }

        public string denoiseFilter { get; set; }
        public string sharpenFilter { get; set; }
        public string subtitle { get; set; }

        public string customAvs { get; set; }

        public void loadTemplate(string templateName)
        {
            XmlTextReader xmlReader = new XmlTextReader(Application.StartupPath + "\\Templates\\Simple\\" + templateName + ".tpl");

                   //// // LogBook.addLogLine(""Loading template " + templateName, 0);

                   xmlReader.Read();

                   while (xmlReader.Read())
                   {
                       if (xmlReader.NodeType == XmlNodeType.Element)
                       {
                           switch (xmlReader.Name)
                           {
                               case "templateName":
                                   xmlReader.Read();
                                   templateName = xmlReader.Value;
                                   break;
                               case "selectedVideo":
                                   xmlReader.Read();
                                   selectedVideo = xmlReader.Value;
                                   break;
                               case "vidBitRate":
                                   xmlReader.Read();
                                   vidBitRate = xmlReader.Value;
                                   break;
                               case "fileSize":
                                   xmlReader.Read();
                                   fileSize = xmlReader.Value;
                                   break;
                               case "vidQuality":
                                   xmlReader.Read();
                                   vidQuality = xmlReader.Value;
                                   break;
                               case "vidCodec":
                                   xmlReader.Read();
                                   vidCodec = xmlReader.Value;
                                   break;
                               case "fieldFilter":
                                   xmlReader.Read();
                                   fieldFilter = xmlReader.Value;
                                   break;
                               case "resizeFilter":
                                   xmlReader.Read();
                                   resizeFilter = xmlReader.Value;
                                   break;
                               case "widthHeight":
                                   xmlReader.Read();
                                   widthHeight = xmlReader.Value;
                                   break;
                               case "audBitrate":
                                   xmlReader.Read();
                                   audBitrate = xmlReader.Value;
                                   break;
                               case "audCodec":
                                   xmlReader.Read();
                                   audCodec = xmlReader.Value;
                                   break;
                               case "containerFormat":
                                   xmlReader.Read();
                                   containerFormat = xmlReader.Value;
                                   break;
                               case "denoiseFilter":
                                   xmlReader.Read();
                                   denoiseFilter = xmlReader.Value;
                                   break;
                               case "sharpenFilter":
                                   xmlReader.Read();
                                   sharpenFilter = xmlReader.Value;
                                   break;
                               case "subtitle":
                                   xmlReader.Read();
                                   subtitle = xmlReader.Value;
                                   break;
                               case "customAvs":
                                   xmlReader.Read();
                                   customAvs = xmlReader.Value;
                                   break;
                           }
                       }
                   }
                   xmlReader.Close();
        }

        public void saveTemplate(string templateName)
        {
            XmlTextWriter xmlWriter = new XmlTextWriter(Application.StartupPath + "\\Templates\\Simple\\" + templateName + ".tpl" , null);
            xmlWriter.Formatting = Formatting.Indented;

            xmlWriter.WriteStartDocument();
          


            xmlWriter.WriteStartElement("Template");
            xmlWriter.WriteElementString("templateName", templateName);
            xmlWriter.WriteElementString("selectedVideo", selectedVideo);
            xmlWriter.WriteElementString("vidBitRate", vidBitRate);
            xmlWriter.WriteElementString("fileSize", fileSize);
            xmlWriter.WriteElementString("vidQuality", vidQuality);
            xmlWriter.WriteElementString("vidCodec", vidCodec);
            xmlWriter.WriteElementString("fieldFilter", fieldFilter);
            xmlWriter.WriteElementString("resizeFilter", resizeFilter);
            xmlWriter.WriteElementString("widthHeight", widthHeight);
            xmlWriter.WriteElementString("audBitrate", audBitrate);
            xmlWriter.WriteElementString("audCodec", audCodec);
            xmlWriter.WriteElementString("containerFormat", containerFormat);
            xmlWriter.WriteElementString("denoiseFilter", denoiseFilter);
            xmlWriter.WriteElementString("sharpenFilter", sharpenFilter);
            xmlWriter.WriteElementString("subtitle", subtitle);
            xmlWriter.WriteElementString("customAvs", customAvs);
            xmlWriter.WriteEndElement();



       
            //  xmlWriter.WriteFullEndElement();
            xmlWriter.Close();

        }
    }
}
