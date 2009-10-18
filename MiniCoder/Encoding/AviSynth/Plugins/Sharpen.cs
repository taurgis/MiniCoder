using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.External;
namespace MiniCoder.Encoding.AviSynth.Plugins
{
    class Sharpen : Plugin
    {
        public Sharpen()
        {

        }

        public string getAvsCode(SortedList<String, String[]> fileDetails, Track video, SortedList<String, String> EncOpts, SortedList<String, Tool> tools)
        {
            Tool filter;
            switch (EncOpts["sharpen"])
            {
                case "1":
                    filter = tools["UnFilter"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "UnFilter(20,20)\r\n";
                case "2":
                    filter = tools["Toon-v1.0-lite"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "ToonLite(strength=0.75)\r\n";
                case "3":
                    filter = tools["aWarpSharp"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "aWarpSharp()\r\n";
                case "4":
                    filter = tools["MSharpen"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "MSharpen()\r\n";
                default:
                    return "";
            }
        }
    }
}
