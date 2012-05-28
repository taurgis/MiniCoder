using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.Templating
{
    public enum Software : byte
    {
        Unnknown = 0, BeSweet = 1, Eac3to = 2, ffmpeg = 3
    }

    public enum AudioEncodingMode : byte
    {
        VBR = 0, CBR = 1, ABR = 2
    }

    public enum AudioEncodingProfile
    {
        Automatic = 0, LC = 1, HE = 2,
        HEv2 = 3
    }

    public enum XVidEncodingMode : byte
    {
        CBR = 0, CQ = 1, TwoPassFirst = 2, 
        TwoPassSecond = 3, AutoTwoPass = 4
    }

    public enum XVidVHQMode : byte
    {
        Off = 0, ModeDecision = 1, 
        LimitedSearch = 2, MediumSearch = 3, 
        WideSearch = 4
    }

    public enum XVidHVSMasking : byte
    {
        None = 0, Lumi = 1, Variance = 2
    }

    public enum XVidMotionSearch : byte
    {
        None = 0, VeryLow = 1, Low = 2, 
        Medium = 3, High = 4, VeryHigh = 5,
        UltraHigh = 6
    }

    public enum XVidProfile : byte
    {
        None = 0
    }

    public enum AudioChannels : byte
    {
        Mono = 1, Stereo = 2, Surround = 6
    }

    public enum SampleRate : byte
    {
        Original = 0, Hz44100 =  1, Hz48000 = 2, Hz88200 = 3, Hz96000 = 4 
    }
}