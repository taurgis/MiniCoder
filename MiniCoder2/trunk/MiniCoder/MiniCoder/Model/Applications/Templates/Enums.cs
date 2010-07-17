using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.Model.Applications.Templates
{
    public enum AudioEncodingMode : byte
    {
        VBR, CBR, ABR
    }

    public enum AudioEncodingProfile
    {
        Automatic, LC, HE,
        HEv2
    }
}
