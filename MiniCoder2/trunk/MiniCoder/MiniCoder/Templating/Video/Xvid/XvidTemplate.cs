using System;
using System.Collections;
using System.Linq;
using System.Text;
using MiniCoder2.Exceptions;
using System.Xml.Serialization;

namespace MiniCoder2.Templating.Video.Xvid
{
    public class XvidTemplate : ExtTemplate
    {
        [XmlIgnore]
        public XVidEncodingMode Mode;
        [XmlElement("Mode")]
        public byte ModeByte
        {
            get { return (byte)Mode; }
            set { Mode = (XVidEncodingMode)value; }
        }
       
        [XmlIgnore]
        public XVidMotionSearch MotionSearch;
        [XmlElement("MotionSearch")]
        public byte MotionSearchByte
        {
            get { return (byte)MotionSearch; }
            set { MotionSearch = (XVidMotionSearch)value; }
        }

        [XmlIgnore]
        public XVidHVSMasking HVSMasking;
        [XmlElement("HVSMasking")]
        public byte HVSMaskingByte
        {
            get { return (byte)HVSMasking; }
            set { HVSMasking = (XVidHVSMasking)value; }
        }

        [XmlIgnore]
        public XVidVHQMode VHQMode;
        [XmlElement("VHQMode")]
        public byte VHQModeByte
        {
            get { return (byte)VHQMode; }
            set { VHQMode = (XVidVHQMode)value; }
        }

        [XmlIgnore]
        public XVidProfile Profile;
        [XmlElement("Profile")]
        public byte ProfileByte
        {
            get { return (byte)Profile; }
            set { Profile = (XVidProfile)value; }
        }

        [XmlElement("BitRate")]
        public Int32 BitRate;        
        [XmlElement("Threads")]
        public Int32 Threads = 1;        
        [XmlElement("BFrames")]
        public Int32 BFrames;
        [XmlElement("KBoost")]
        public Int32 KBoost = 100;
        [XmlElement("Quantizer")]
        public Decimal Quantizer;
        [XmlElement("ChromaMotion")]
        public Boolean ChromaMotion;
        [XmlElement("TrellisQuant")]
        public Boolean TrellisQuant;
        [XmlElement("ClosedGOP")]
        public Boolean ClosedGOP;
        [XmlElement("Interlace")]
        public Boolean Interlace;
        [XmlElement("Turbo")]
        public Boolean Turbo;
        [XmlElement("PackedBitstream")]
        public Boolean PackedBitstream;
        [XmlElement("AdaptiveQuant")]
        public Boolean AdaptiveQuant;
        [XmlElement("QPel")]
        public Boolean QPel;
        [XmlElement("GMC")]
        public Boolean GMC;
        [XmlElement("VHQBFrames")]
        public Boolean VHQBFrames;
 
        public XvidTemplate()
        {
        }

        public XvidTemplate(String name = "")
        {
            this.Name = name;         
        }

  
        public override string GenerateCommandLine()
        {
            String InitialCommand = "program -i <input> ";
            String OutputCommand = " -o <output> ";
            String threads = " -threads " + Threads;
            String mode = "";            
            String Options = "";

            switch (Mode)
            {
                case XVidEncodingMode.CBR:
                    mode = "-single -bitrate " + BitRate + " -smoother 0";
                    break;
                case XVidEncodingMode.CQ:
                    mode = "-single -cq " + Quantizer + " -smoother 0";
                    break;
                case XVidEncodingMode.TwoPassFirst:
                    mode = "-pass 1 -bitrate " + BitRate + " -kboost " + KBoost;
                    OutputCommand = "";
                    break;
                case XVidEncodingMode.TwoPassSecond:
                    mode = "-pass 2 -bitrate " + BitRate + " -kboost " + KBoost;
                    break;
                case XVidEncodingMode.AutoTwoPass:
                    mode = "";
                    break;
                default:
                    mode = "";
                    break;
            }
            
            Options = GenerateOptions();

            return InitialCommand + Mode + threads + OutputCommand + Options;
        }

        private string GenerateOptions()
        {
            string result = "";

            if (Interlace)
            {
                result += " -interlaced ";
            }

            if (Turbo)
            {
                if (Mode >= XVidEncodingMode.TwoPassFirst)
                {
                    result += " -turbo ";
                }
            }

            if (QPel)
            {
                result += " -qpel ";
            }

            if (GMC)
            {
                result += " -gmc ";
            }

            if (VHQBFrames)
            {
                result += " -bvhq ";
            }

            if (!ChromaMotion)
            {
                result += " -nochromame ";
            }

            if (!TrellisQuant)
            {
                result += " -notrellis ";
            }

            if (!ClosedGOP)
            {
                result += " -noclosed_gop ";
            }

            if (!PackedBitstream)
            {
                result += " -nopacked ";
            }
         
            return result;
        }

    }
}
