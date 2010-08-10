using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniCoder2.Exceptions;
using System.Xml.Serialization;

namespace MiniCoder2.Templating.Video.Xvid
{
    class XvidTemplate : ExtTemplate
    {
        [XmlElement("XMode")]
        public XvidEncodingMode XMode;
        [XmlElement("XMotionSearch")]
        public XVidMotionSearch XMotionSearch;
        [XmlElement("XHVSMasking")]
        public XVidHVSMasking XHVSMasking;
        [XmlElement("XVHQMode")]
        public XvidVHQMode XVHQMode;
        [XmlElement("XBitRate")]
        public Int32 XBitRate;        
        [XmlElement("XThreads")]
        public Int32 XThreads;        
        [XmlElement("XQuantizer")]
        public Int32 XQuantizer;
        [XmlElement("XKBoost")]
        public Int32 XKBoost;
        [XmlElement("XLogFile")]
        public String XLogFile;


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
                case XvidEncodingMode.AutoTwoPass:
                    Mode = "";
                    break;
                default:
                    Mode = "";
                    break;
            }

            return "program -i <input> " + Mode + " -nopacked -threads 1 " + OutputCommand + (int)XVHQMode;
        }
    }
}
