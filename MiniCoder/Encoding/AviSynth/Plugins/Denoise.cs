using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.External;
namespace MiniCoder.Encoding.AviSynth.Plugins
{
    class Denoise : Plugin
    {
        public Denoise()
        {

        }

        public string getAvsCode(SortedList<String, String[]> fileDetails, Track video, SortedList<String, String> EncOpts, SortedList<String, Tool> tools)
        {
            Tool filter;
            switch (EncOpts["denoise"])
            {
                case "1":
                    filter = tools["UnDot"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "UnDot()\r\n";
                case "2":
                    filter = tools["FluxSmooth"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "FluxSmoothST()\r\n";
                case "3":
                    filter = tools["HQDN3D"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "HQDN3D()\r\n";
                case "4":
                    filter = tools["UnDot"];
                    if (!filter.isInstalled())
                        filter.download();
                    filter = tools["Deen"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "UnDot.Deen()\r\n";
                default:
                    return "";
            }
        }
    }
}
