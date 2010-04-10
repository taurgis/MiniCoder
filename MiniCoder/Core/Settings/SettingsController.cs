using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace MiniTech.MiniCoder.Core.Settings
{
    public abstract class SettingsController
    {
        public static MainSettings loadSettings()
        {
            MainSettings settings = new MainSettings();
            XmlSerializer s = new XmlSerializer(typeof(MainSettings));

            TextReader r = new StreamReader("settings.xml");
            settings = (MainSettings)s.Deserialize(r);
            r.Close();

            return settings;
        }

        public static void saveSettings(MainSettings settings)
        {
            XmlSerializer s = new XmlSerializer(typeof(MainSettings));
            TextWriter w = new StreamWriter("settings.xml");
            s.Serialize(w, settings);
            w.Close();
        }

    }
}
