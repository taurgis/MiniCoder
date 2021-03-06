﻿//    MiniCoder
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
using MiniTech.MiniCoder.Core.Managers;

namespace MiniTech.MiniCoder.Encoding.AviSynth.Plugins
{
    public class Field : Plugin
    {
        public string getAvsCode(SortedList<String, String[]> fileDetails, Track video, SortedList<String, String> EncOpts)
        {
            ExtApplication filter;
            switch (EncOpts["field"])
            {
                case "1":
                    filter =  ToolsManager.Instance.getTool("Decomb");
                    if (!filter.isInstalled())
                        filter.download();
                    return "FieldDeinterlace()\r\n";
                case "2":
                    filter = ToolsManager.Instance.getTool("BAAA");
                    if (!filter.isInstalled())
                        filter.download();
                    return "AAA()\r\n";
                default:
                    return "";
            }
        }
    }
}
