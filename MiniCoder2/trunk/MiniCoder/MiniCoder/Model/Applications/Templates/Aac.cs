﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.Model.Applications.Templates
{
    public class Aac : ExtTemplate
    {
        public AudioEncodingMode Mode { get; set; }
        public Double Quality { get; set; }
        public Int32 BitRate { get; set; }
        public Int32 Delay { get; set; }
        public AudioEncodingProfile Profile { get; set; }
        public short Channels { get; set; }
        public Int32 SampleRate { get; set; }

        public Aac(String name)
        {
            this.Name = name;
        }

        public override String GenerateCommandLine()
        {
            String quality = "";
            String sampleRate = "";

            switch (Mode)
            {
                case AudioEncodingMode.ABR:
                case AudioEncodingMode.CBR:
                    quality = BitRate.ToString();
                    break;
                case AudioEncodingMode.VBR:
                    quality = Quality.ToString();
                    break;
            }

            if (SampleRate != 0)
                sampleRate = "-ssrc( --rate " + SampleRate + " )";

            return "-core( -input <source> -output <target> ) -ota( -d " + 
                Delay.ToString() + " -g max ) " + sampleRate + " -bsn( -" + 
                Enum.GetName(typeof(AudioEncodingMode), Mode) + " " + 
                quality + " " + Profile + " )";
        }
    }
}
