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
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;

namespace MiniTech.MiniCoder.Encoding.Input
{
    public class Wmv : InputFile
    {
        public SortedList<String, Track[]> getTracks()
        {
            return new SortedList<string, Track[]>();
        }

        public Boolean demux(SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks)
        {
            LogBookController.Instance.addLogLine("Demuxing WMV - Setting up variables", LogMessageCategories.Video);

            tracks["video"][0].demuxPath = fileDetails["fileName"][0];
            tracks["audio"][0].demuxPath = fileDetails["fileName"][0];

            return true;
        }
    }
}
