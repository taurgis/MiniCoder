﻿using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.Encoding.Process_Management;
using MiniCoder.External;
using System.IO;
using System.Windows.Forms;
using MiniCoder.Encoding.AviSynth;
using System.Text.RegularExpressions;
namespace MiniCoder.Encoding.Input
{
    class Avs : InputFile
    {
        String tempPath = Application.StartupPath + "\\temp\\";
     //   SortedList<String, String[]> fileDetails = new SortedList<string, string[]>();

        public Avs()
        {

        }

        public SortedList<String, Track[]> getTracks()
        {
            return new SortedList<string, Track[]>();
        }

        public void setTempPath(string tempPath)
        {
            this.tempPath = tempPath;
        }

        public Boolean demux(Tool vdubmod, SortedList<String, String[]> fileDetails, SortedList<String, Track[]> tracks, ProcessWatcher processWatcher)
        {
            AviSynthScriptEnvironment environment = new AviSynthScriptEnvironment();
            AviSynthClip clip = environment.OpenScriptFile(fileDetails["fileName"][0]);
            fileDetails["width"][0] = clip.VideoWidth.ToString();
            fileDetails["height"][0] = clip.VideoHeight.ToString();
            fileDetails.Add("avsfile", fileDetails["fileName"][0].Split(Char.Parse("\n")));
            fileDetails["fileName"][0] = getAvsSource(fileDetails["fileName"][0]);
            
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

                String fqdn1 = m.Groups[3].ToString();

                return fqdn1.Replace("\"","");
            }
            return "";
        }
    }
}