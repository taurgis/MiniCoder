using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
namespace MiniTech.MiniCoder.Templates.Simple
{
    public abstract class SimpleTemplateController
    {
        public static MainTemplate loadTemplate(String templateName)
        {
            MainTemplate template = new MainTemplate();

            XmlSerializer s = new XmlSerializer(typeof(MainTemplate));

            TextReader r = new StreamReader(Application.StartupPath + "\\Templates\\Simple\\" + templateName + ".tpl");
            template = (MainTemplate)s.Deserialize(r);
            r.Close();
            return template;
        }

        public static void saveTemplate(MainTemplate template)
        {
            XmlSerializer s = new XmlSerializer(typeof(MainTemplate));
            TextWriter w = new StreamWriter(Application.StartupPath + "\\Templates\\Simple\\" + template.templateName + ".tpl");
            s.Serialize(w, template);
            w.Close();
        }

    }
}
