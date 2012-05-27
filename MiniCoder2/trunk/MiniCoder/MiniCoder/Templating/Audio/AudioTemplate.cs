using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MiniCoder2.Templating.Audio
{
    public class AudioTemplate : Template
    {
        [XmlElement("Normalize")]
        public Boolean Normalize;
        [XmlElement("Delay")]
        public Int32 Delay;
        [XmlIgnore]
        public SampleRate SampleRate;
        [XmlElement("SampleRate")]
        public byte SampleRateByte
        {
            get { return (byte)SampleRate; }
            set { SampleRate = (SampleRate)value; }
        }
        [XmlIgnore]
        public AudioChannels Channels;
        [XmlElement("Channels")]
        public byte ChannelsByte
        {
            get { return (byte)Channels; }
            set { Channels = (AudioChannels)value; }
        }
    }
}
