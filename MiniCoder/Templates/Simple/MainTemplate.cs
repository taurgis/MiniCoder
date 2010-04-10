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
using System.Xml.Serialization;
using System.Windows.Forms;
namespace MiniTech.MiniCoder.Templates.Simple
{
    [XmlRoot("MiniCoder-Template")]
   public class MainTemplate
    {
        [XmlElement("templateName")]
        public string templateName { get; set; }

        [XmlElement("selectedVideo")]
        public string selectedVideo { get; set; }
        [XmlElement("vidBitRate")]
        public string vidBitRate { get; set; }
        [XmlElement("fileSize")]
        public string fileSize { get; set; }
        [XmlElement("vidQuality")]
        public string vidQuality { get; set; }
        [XmlElement("vidCodec")]
        public string vidCodec { get; set; }

        [XmlElement("fieldFilter")]
        public string fieldFilter { get; set; }
        [XmlElement("resizeFilter")]
        public string resizeFilter { get; set; }
        [XmlElement("widthHeight")]
        public string widthHeight { get; set; }

        [XmlElement("audBitrate")]
        public string audBitrate { get; set; }
        [XmlElement("audCodec")]
        public string audCodec { get; set; }
        [XmlElement("containerFormat")]
        public string containerFormat { get; set; }

        [XmlElement("denoiseFilter")]
        public string denoiseFilter { get; set; }
        [XmlElement("sharpenFilter")]
        public string sharpenFilter { get; set; }
        [XmlElement("subtitle")]
        public string subtitle { get; set; }

        [XmlElement("customAvs")]
        public string customAvs { get; set; }
    }
}
