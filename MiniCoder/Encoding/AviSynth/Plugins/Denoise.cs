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
