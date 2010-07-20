using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.Templating
{
    public enum AudioEncodingMode : byte
    {
        VBR = 0, CBR = 1, ABR = 2
    }

    public enum AudioEncodingProfile
    {
        Automatic = 0, LC = 1, HE = 2,
        HEv2 = 3
    }

    public enum XvidEncodingMode : byte
    {
        CBR = 0, CQ = 1, TwoPassFirst = 2, 
        TwoPassSecond = 3, AutoTwoPass = 4
    }
}
