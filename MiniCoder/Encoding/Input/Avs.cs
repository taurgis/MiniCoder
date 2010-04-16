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
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MiniTech.MiniCoder.Core.Managers;
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Encoding.AviSynth;
using MiniTech.MiniCoder.Encoding.Input.Tracks;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.External;

namespace MiniTech.MiniCoder.Encoding.Input
{
    public class Avs : InputFile
    {
        public SortedList<String, Track[]> getTracks()
        {
            return new SortedList<string, Track[]>();
        }

        public Boolean demux(Tool vdubmod, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
            LogBookController.Instance.addLogLine("Analysing AVS file", LogMessageCategories.Video);

            AviSynthScriptEnvironment environment = new AviSynthScriptEnvironment();
            AviSynthClip clip = environment.OpenScriptFile(fileDetails["fileName"][0]);
            fileDetails.Add("width", clip.VideoWidth.ToString().Split(Convert.ToChar("~")));
            fileDetails.Add("height", clip.VideoHeight.ToString().Split(Convert.ToChar(" ")));
            fileDetails.Add("avsfile", fileDetails["fileName"][0].Split(Char.Parse("\n")));
            fileDetails["fileName"][0] = getAvsSource(fileDetails["fileName"][0]);

            LogBookController.Instance.addLogLine("Retrieved source: " + fileDetails["fileName"][0], LogMessageCategories.Video);

            clip = null;
            environment = null;

            return true;
        }

        private String getAvsSource(string avsFile)
        {
            StreamReader reader = new StreamReader(avsFile);

            avsFile = reader.ReadToEnd();
            reader.Close();
            string re1 = "(Source)";	// Word 1
            string re2 = "(\\()";	// Any Single Character 1
            string re3 = "(\".*?\")";	// Double Quote String 1

            Regex r = new Regex(re1 + re2 + re3, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(avsFile);
           
            if (m.Success)
            {
                return m.Groups[3].ToString().Replace("\"", "");
            }
           
            return "";
        }
    }
}
