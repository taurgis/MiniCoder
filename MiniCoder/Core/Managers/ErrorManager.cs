using System;
using System.Collections.Generic;
using System.Text;
using MiniTech.MiniCoder.Encoding.Input.Tracks;

namespace MiniTech.MiniCoder.Core.Managers
{
    public static class ErrorManager
    {
        public static String fetchTrackData(SortedList<String, Track[]> tracks)
        {
            String errormessage = "";
            errormessage += "VIDEO: " + tracks["video"][0].codec + ", AUDIO: ";
            for (int i = 0; i < tracks["audio"].Length; i++)
            {
                errormessage += " " + i + ": " + tracks["audio"][i].codec + ", " + tracks["audio"][i].language;
            }

            errormessage += ", SUBS: ";
            for (int i = 0; i < tracks["subs"].Length; i++)
            {
                errormessage += " " + i + ": " + tracks["subs"][i].codec + ", " + tracks["subs"][i].language;
            }

            return errormessage;
        }
    }
}
