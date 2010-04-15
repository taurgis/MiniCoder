//    MiniCoder
//    Copyright (C) 2009-2010  MiniTech support@minitech.org
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.External;

namespace MiniTech.MiniCoder.Encoding.AviSynth.Plugins
{
    public class Sharpen : Plugin
    {
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
