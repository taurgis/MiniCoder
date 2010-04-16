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
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;

namespace MiniTech.MiniCoder.Encoding.Input.Tracks
{
    public interface Track
    {
        String title { get; set; }
        String language { get; set; }
        String codec { get; set; }
        String demuxPath { get; set; }
        String encodePath { get; set; }
        String length { get; set; }
        int id { get; set; }
        Boolean Encode(SortedList<String, Tool> tools, SortedList<String, String[]> fileDetails, SortedList<String, String> EncOpts, ProcessWatcher processWatcher, SortedList<String, Track[]> tracks);
    }
}
