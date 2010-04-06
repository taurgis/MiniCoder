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
using MiniCoder.Encoding.AviSynth.Plugins;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.External;
using System.Windows.Forms;
using System.IO;

namespace MiniCoder.Encoding.AviSynth
{
    class AvsCreator
    {
        SortedList<String, String[]> fileDetails;
        SortedList<String, String> EncOpts;
        SortedList<String, Tool> tools;
        Track video;

        public AvsCreator(SortedList<String, String[]> fileDetails, Track video, SortedList<String, String> EncOpts, SortedList<String, Tool> tools)
        {
            this.fileDetails = fileDetails;
            this.video = video;
            this.EncOpts = EncOpts;
            this.tools = tools;
        }

        public Boolean getAvsFile(SortedList<String, Track[]> fileTracks)
        {
            try
            {
                string avs = "";

                avs += getSourceLine() + "\r\n";
                avs += EncOpts["custom"];
                avs += getFieldLine();
                avs += getResizeLine();
                avs += getDenoiseLine();
                avs += getSharpenLine();
                if (EncOpts.ContainsKey("hardsub"))
                    avs += "TextSub(\"" + EncOpts["hardsub"] + "\")";
                if (EncOpts.ContainsKey("hardsubmp4"))
                    if (EncOpts["hardsubmp4"] != "0" && (EncOpts["container"] == "1" || EncOpts["container"] == "2") && fileTracks["subs"].Length > 0)
                        avs += "\r\nTextSub(\"" + fileTracks["subs"][int.Parse(EncOpts["hardsubmp4"]) - 1].demuxPath + "\")";
                EncOpts.Add("avsfile", (Application.StartupPath + "\\temp\\" + fileDetails["name"][0] + ".avs"));
                StreamWriter streamWriter = new StreamWriter(EncOpts["avsfile"]);
                streamWriter.Write(avs);
                streamWriter.Close();

                LogBook.addLogLine(avs, fileDetails["name"][0] + "AvsCreation", "", false);


                return checkAvs();
            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error writing AVS file. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
                return false;
            }
        }

        private Boolean checkAvs()
        {
            try
            {
                AviSynthScriptEnvironment environment = new AviSynthScriptEnvironment();

                AviSynthClip temp = environment.OpenScriptFile(EncOpts["avsfile"]);
                temp = null;
                return true;
               
            }
            catch (AviSynthException er)
            {
                LogBook.addLogLine("Error checking AVS file: " + er.Message, "Errors", "", true);
                // LogBook.addLogLine("er.Message,1);
                MessageBox.Show("Error in AVS File: " + er.Message);
                return false;
            }
                
        }

        private string getSourceLine()
        {
            Plugin source = new Source();
            return source.getAvsCode(fileDetails, video, EncOpts, tools);
        }

        private string getFieldLine()
        {
            Plugin field = new Field();
            return field.getAvsCode(fileDetails, video, EncOpts, tools);
        }

        private string getResizeLine()
        {
            Plugin resize = new Resize();
            return resize.getAvsCode(fileDetails, video, EncOpts, tools);
        }

        private string getDenoiseLine()
        {
            Plugin denoise = new Denoise();
            return denoise.getAvsCode(fileDetails, video, EncOpts, tools);
        }
        private string getSharpenLine()
        {
            Plugin sharpen = new Sharpen();
            return sharpen.getAvsCode(fileDetails, video, EncOpts, tools);
        }

    }
}
