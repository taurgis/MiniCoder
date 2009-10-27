using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.External;
namespace MiniCoder.Encoding.AviSynth.Plugins
{
    class Field : Plugin
    {
        public Field()
        {

        }

        public string getAvsCode(SortedList<String, String[]> fileDetails, Track video, SortedList<String, String> EncOpts, SortedList<String, Tool> tools)
        {
            Tool filter;
            switch (EncOpts["field"])
            {
                case "1":
                    filter = tools["Decomb"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "FieldDeinterlace()\r\n";
                case "2":
                    filter = tools["AAA"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "AAA()\r\n";
                default:
                    return "";
            }
        }
    }
}
