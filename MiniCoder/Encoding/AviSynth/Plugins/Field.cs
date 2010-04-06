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
