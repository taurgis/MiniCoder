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
using System.Collections;
namespace System
{


    public sealed class Language
    {
        public Dictionary<string, string> lang = new Dictionary<string, string>();
        private static Language instance = null;

        public Language()
        {
            fillLanguages();
        }

        public static Language Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Language();
                }
                return instance;
            }
        }

        private void fillLanguages()
        {
            lang.Add("English", "eng");
            lang.Add("Japanese", "jpn");
            lang.Add("Chinese", "chi");
            lang.Add("Dutch", "dut");
            lang.Add("Finnish", "fin");
            lang.Add("rrk", "rrk");
            lang.Add("French", "fre");
            lang.Add("German", "ger");
            lang.Add("Italian", "ita");
            lang.Add("Norwegian", "nor");
            lang.Add("Portuguese", "por");
            lang.Add("Russian", "rus");
            lang.Add("Spanish", "spa");
            lang.Add("Swedish", "swe");
            lang.Add("Czech", "cze");
            lang.Add("Slovak", "slo");
            lang.Add("", "und");
        }

        public string getExtention(string language)
        {
            if (String.IsNullOrEmpty(language))
                return "und";

            return lang[language];
        }
    }
}
