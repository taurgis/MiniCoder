using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace System
{


    static partial class Language
    {
        public static string getExtention(string language)
        {
            Languages tempLang = new Languages();
            return tempLang.getLanguageCode(language);

        }


        private class Languages
        {
            public Dictionary<string, string> lang = new Dictionary<string, string>();

            public Languages()
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

            public string getLanguageCode(string language)
            {
                if (String.IsNullOrEmpty(language))
                    return "und";
                return lang[language];
            }
        }
    }
}
