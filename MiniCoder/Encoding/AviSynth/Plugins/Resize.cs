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
    public class Resize : Plugin
    {
        public string getAvsCode(SortedList<String, String[]> fileDetails, Track video, SortedList<String, String> EncOpts)
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
