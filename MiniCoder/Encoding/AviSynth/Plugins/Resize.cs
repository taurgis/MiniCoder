using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.External;
namespace MiniCoder.Encoding.AviSynth.Plugins
{
    class Resize : Plugin
    {
        public Resize()
        {

        }

        public string getAvsCode(SortedList<String, String[]> fileDetails, Track video, SortedList<String, String> EncOpts, SortedList<String, Tool> tools)
        {
           
            switch (EncOpts["resize"])
            {
                case "1":
                    return "BilinearResize(" + EncOpts["width"] + "," + EncOpts["height"] + ")\r\n";
                case "2":
                    return "BicubicResize(" + EncOpts["width"] + "," + EncOpts["height"] + ")\r\n";
                case "3":
                    return "LanczosResize(" + EncOpts["width"] + "," + EncOpts["height"] + ")\r\n";
                case "4":
                    return "Lanczos4Resize(" + EncOpts["width"] + "," + EncOpts["height"] + ")\r\n";
                case "5":
                    return "Spline36Resize(" + EncOpts["width"] + "," + EncOpts["height"] + ")\r\n";
                default:
                    return "";
            }
        }
    }
}
