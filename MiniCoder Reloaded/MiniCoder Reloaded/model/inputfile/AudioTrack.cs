using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using be.miniTech.minicoder.model.information;

namespace be.miniTech.minicoder.model.inputfile
{
   public class AudioTrack
    {
       public int audioID { get; set; }
       public String title { get; set; }
       public Codec codec { get; set; }
       public Language language { get; set; }
       public long duration { get; set; }
    }
}
