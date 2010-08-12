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
        public XVidEncodingMode XMode;
        [XmlElement("XMotionSearch")]
        public XVidMotionSearch XMotionSearch;
        [XmlElement("XHVSMasking")]
        public XVidHVSMasking XHVSMasking;
        [XmlElement("XVHQMode")]
        public XVidVHQMode XVHQMode;
        [XmlElement("XProfile")]
        public XVidProfile XProfile;
        [XmlElement("XBitRate")]
        public Int32 XBitRate;        
        [XmlElement("XThreads")]
        public Int32 XThreads;        
        [XmlElement("XQuantizer")]
        public Int32 XQuantizer;
        [XmlElement("XBFrames")]
        public Int32 XBFrames;
        [XmlElement("XLogFile")]
        public String XLogFile;        
        [XmlElement("XKBoost")]
        public bool XKBoost;
        [XmlElement("XChromaMotion")]
        public bool XChromaMotion;
        [XmlElement("XTrellisQuant")]
        public bool XTrellisQuant;
        [XmlElement("XClosedGOP")]
        public bool XClosedGOP;
        [XmlElement("XInterlace")]
        public bool XInterlace;
        [XmlElement("XTurbo")]
        public bool XTurbo;
        [XmlElement("XPackedBitstream")]
        public bool XPackedBitstream;
        [XmlElement("XAdaptiveQuant")]
        public bool XAdaptiveQuant;
        [XmlElement("XQPel")]
        public bool XQPel;
        [XmlElement("XGMC")]
        public bool XGMC;
        [XmlElement("XVHQBFrames")]
        public bool XVHQBFrames;

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
                case XVidEncodingMode.CBR:
                    Mode = "-single -bitrate " + XBitRate.ToString() + " -smoother 0";
                    break;
                case XVidEncodingMode.CQ:
                    Mode = "-single -cq " + XQuantizer.ToString() + " -smoother 0";
                    break;
                case XVidEncodingMode.TwoPassFirst:
                    Mode = "-pass 1 " + XLogFile + " -bitrate " + XBitRate.ToString() + " -kboost " + XKBoost.ToString();
                    OutputCommand = "";
                    break;
                case XVidEncodingMode.TwoPassSecond:
                    Mode = "-pass 2 " + XLogFile + " -bitrate " + XBitRate.ToString() + " -kboost " + XKBoost.ToString();
                    break;
                case XVidEncodingMode.AutoTwoPass:
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
