using System;
using System.Collections;
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
        [XmlElement("XBFrames")]
        public Int32 XBFrames;
        [XmlElement("XKBoost")]
        public Int32 XKBoost;
        [XmlElement("XQuantizer")]
        public Decimal XQuantizer;
        [XmlElement("XOptions")]
        public Hashtable XOptions;

        public XvidTemplate(String name = "")
        {
            this.Name = name;
            InitialiseOptions();            
        }

        public void InitialiseOptions()
        {
            XOptions = new Hashtable() 
            {
                 {"XChromaMotion", true}, 
                 {"XTrellisQuant", true}, 
                 {"XClosedGOP", true},
                 {"XInterlace", false}, 
                 {"XTurbo" , false}, 
                 {"XPackedBitstream" , false},
                 {"XAdaptiveQuant" , false}, 
                 {"XQPel" , false}, 
                 {"XGMC" , false},
                 {"XVHQBFrames" , false}
            };
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
                    XKBoost = 100;
                    Mode = "-pass 1 -bitrate " + XBitRate.ToString() + " -kboost " + XKBoost.ToString();
                    OutputCommand = "";
                    break;
                case XVidEncodingMode.TwoPassSecond:
                    XKBoost = 100;
                    Mode = "-pass 2 -bitrate " + XBitRate.ToString() + " -kboost " + XKBoost.ToString();
                    break;
                case XVidEncodingMode.AutoTwoPass:
                    XKBoost = 100;
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
