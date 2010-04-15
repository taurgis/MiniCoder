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

using System.Xml;
using System.Xml.Serialization;

namespace MiniTech.MiniCoder.Core.Settings
{
    [XmlRoot("settings")]
    public class MainSettings
    {
        [XmlElement("outputPath")]
        public string outputPath { get; set; }
        [XmlElement("disableVideoAdvert")]
        public bool disableVideoAdvert { get; set; }
        [XmlElement("processPriority")]
        public string processPriority { get; set; }
        [XmlElement("ignoreAudio")]
        public bool ignoreAudio { get; set; }
        [XmlElement("ignoreSubs")]
        public bool ignoreSubs { get; set; }
        [XmlElement("ignoreAttachments")]
        public bool ignoreAttachments { get; set; }
        [XmlElement("ignoreChapters")]
        public bool ignoreChapters { get; set; }
        [XmlElement("continueAfterError")]
        public bool continueAfterError { get; set; }
        [XmlElement("language")]
        public int language { get; set; }
    }
}
