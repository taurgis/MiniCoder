using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be.miniTech.minicoder.model.inputfile
{
   public class InputFile
    {
       public List<AudioTrack> audioTracks { get; set; }
       public List<VideoTrack> videoTracks { get; set; }
       public bool hasChapters { get; set; }

       public List<SubtitleTrack> subtitleTracks { get; set; }
    }
}
