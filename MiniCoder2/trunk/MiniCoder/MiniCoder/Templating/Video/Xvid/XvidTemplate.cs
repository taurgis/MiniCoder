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
        public Int32 XThreads = 1;        
        [XmlElement("XBFrames")]
        public Int32 XBFrames;
        [XmlElement("XKBoost")]
        public Int32 XKBoost = 100;
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
            String InitialCommand = "program -i <input> ";
            String OutputCommand = " -o <output> ";
            String Threads = " -threads " + XThreads;
            String Mode = "";            
            String Options = "";

            switch (XMode)
            {
                case XVidEncodingMode.CBR:
                    Mode = "-single -bitrate " + XBitRate + " -smoother 0";
                    break;
                case XVidEncodingMode.CQ:
                    Mode = "-single -cq " + XQuantizer + " -smoother 0";
                    break;
                case XVidEncodingMode.TwoPassFirst:
                    Mode = "-pass 1 -bitrate " + XBitRate + " -kboost " + XKBoost;
                    OutputCommand = "";
                    break;
                case XVidEncodingMode.TwoPassSecond:
                    Mode = "-pass 2 -bitrate " + XBitRate + " -kboost " + XKBoost;
                    break;
                case XVidEncodingMode.AutoTwoPass:
                    Mode = "";
                    break;
                default:
                    Mode = "";
                    break;
            }
            
            Options = GenerateOptions();

            return InitialCommand + Mode + Threads + OutputCommand + Options;
        }

        public string GenerateOptions()
        {
            string result = "";
            foreach (DictionaryEntry dEntry in XOptions)
            {
                if ((bool)dEntry.Value)
                {
                    switch ((string)dEntry.Key)
                    {
                        case "XInterlace":
                            result += " -interlaced ";
                            break;
                        case "XTurbo":
                            if(XMode >= XVidEncodingMode.TwoPassFirst)
                                result += " -turbo ";
                            break;
                        case "XPackedBitstream":
                            result += "";
                            break;
                        case "XAdaptiveQuant":
                            result += "";
                            break;
                        case "XQPel":
                            result += " -qpel ";
                            break;
                        case "XGMC":
                            result += " -gmc ";
                            break;
                        case "XVHQBFrames":
                            result += " -bvhq ";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch ((string)dEntry.Key)
                    {
                        case "XChromaMotion":
                            result += " -nochromame ";
                            break;
                        case "XTrellisQuant":
                            result += " -notrellis ";
                            break;
                        case "XClosedGOP":
                            result += " -noclosed_gop ";
                            break;
                        case "XPackedBitstream":
                            result += " -nopacked ";
                            break;
                        default:
                            break;
                    }
                }
            }
            return result;
        }

    }
}
