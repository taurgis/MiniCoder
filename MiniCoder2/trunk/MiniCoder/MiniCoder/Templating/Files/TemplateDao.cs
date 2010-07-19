using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using MiniCoder2.Exceptions;

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

            if (!Directory.Exists("templates"))
                Directory.CreateDirectory("templates");

            if (!Directory.Exists("templates\\" + classType.Name))
                Directory.CreateDirectory("templates\\" + classType.Name);

            using (StreamWriter writer = new StreamWriter("templates\\" + classType.Name + "\\" + template.Name + ".xml"))
            {
                serializer.Serialize(writer, template);
            }
        }

        /// <summary>
        /// Fetches the names of all templates for the given type.
        /// </summary>
        /// <param name="classType">The classtype of the template.</param>
        /// <returns>Array of the template names.</returns>
        public static String[] GetTemplatesByType(Type classType)
        {
            String[] files = Directory.GetFiles("templates\\" + classType.Name);
            //Using a list because not all files found will be returned.
            List<String> returnNames = new List<string>();

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Contains(".xml"))
                    returnNames.Add(RemoveUnwantedParts(files[i], classType));
            }

            return returnNames.ToArray();
        }

        /// <summary>
        /// Removes unwanted parts from filenames.
        /// </summary>
        /// <param name="fileName">The filename.</param>
        /// <param name="classType">The class type.</param>
        /// <returns>Cleaned filename.</returns>
        private static String RemoveUnwantedParts(String fileName, Type classType)
        {
            return fileName.Replace(".xml", "").Replace("templates\\" + classType.Name + "\\", "");
        }

        /// <summary>
        /// Loads a specific template.
        /// </summary>
        /// <param name="name">The name of the template.</param>
        /// <param name="classType">The class type of the template.</param>
        /// <returns>The template class.</returns>
        public static ExtTemplate LoadTemplate(String name, Type classType)
        {
            String path = "templates\\" + classType.Name + "\\" + name + ".xml";
            if (!File.Exists(path))
                throw new TemplateNotFoundException(path);

            XmlSerializer serializer =
            new XmlSerializer(classType);

            TextReader reader = new StreamReader(path);
            ExtTemplate template = (ExtTemplate)serializer.Deserialize(reader);
            reader.Close();

            return template;
        }
    }
}
