using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniCoder2.Exceptions;
using System.Xml.Serialization;

namespace MiniCoder2.Templating.Audio.Xvid
{
    class XvidTemplate : ExtTemplate
    {
        [XmlElement("XMode")]
        public XvidEncodingMode XMode;
        [XmlElement("XBitRate")]
        public Int32 XBitRate;
        [XmlElement("XQuantizer")]
        public Int32 XQuantizer;
        [XmlElement("XLogFile")]
        public String XLogFile;
        [XmlElement("XKBoost")]
        public Int32 XKBoost;

        public XvidTemplate() 
        {
        }

        public XvidTemplate(String name)
        {
            this.Name = name;
        }

        public override string GenerateCommandLine()
        {
            String OutputCommand = " -o <output> ";
            String Mode;

            switch (XMode)
            {
                case XvidEncodingMode.CBR:
                    Mode = "-single -bitrate " + XBitRate.ToString() + " -smoother 0";
                    break;
                case XvidEncodingMode.CQ:
                    Mode = "-single -cq " + XQuantizer.ToString() + " -smoother 0";
                    break;
                case XvidEncodingMode.TwoPassFirst:
                    Mode = "-pass 1 " + XLogFile + " -bitrate " + XBitRate.ToString() + " -kboost " + XKBoost.ToString();
                    OutputCommand = "";
                    break;
                case XvidEncodingMode.TwoPassSecond:
                    Mode = "-pass 2 " + XLogFile + " -bitrate " + XBitRate.ToString() + " -kboost " + XKBoost.ToString();
                    break;
                ///MORE TO COME
            }

            return "program -i <input> " + XMode + " -nopacked -threads 1 " + OutputCommand;
        }
    }
}
