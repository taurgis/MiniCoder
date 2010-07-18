using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MiniCoder2.Templating.Files
{
    public class TemplateDao
    {
        /// <summary>
        /// A static function to be used by all templat controllers to save it to a file.
        /// The function requires that XML mapping has been completed in the object that 
        /// is sent.
        /// </summary>
        /// <param name="template">The template object</param>
        /// <param name="classType">The class type</param>
        public static void SaveTemplate(ExtTemplate template, Type classType)
        {
            XmlSerializer serializer = new XmlSerializer(classType);

            //Serialize the OrderedTable to OrderedTable.xml
            if (!Directory.Exists("templates"))
                Directory.CreateDirectory("templates");

            if (!Directory.Exists("templates\\" + classType.Name))
                Directory.CreateDirectory("templates\\" + classType.Name);

            using (StreamWriter writer = new StreamWriter("templates\\" + classType.Name + "\\" + template.Name + ".xml"))
            {
                serializer.Serialize(writer, template);
            }
        }

        public static void LoadTemplate(String name)
        {

        }
    }
}
