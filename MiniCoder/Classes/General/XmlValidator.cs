using System;
using System.Collections;
using System.Xml;
using System.Xml.Schema;

namespace MiniCoder
{
    public class XMLValidator
    {
        private string fileName;
        static private ArrayList errors = new ArrayList();
        static private bool bValid;

        public XMLValidator(string fileName)
        {
            this.fileName = fileName;
            bValid = true;
        }

        public ArrayList GetErrors()
        {
            return errors;
        }

        public bool Validate()
        {
            XmlValidatingReader reader = null;
            try
            {
                errors.Clear();
                bValid = true;
                XmlTextReader txtreader = new XmlTextReader(fileName);
                reader = new XmlValidatingReader(txtreader);



                // Set the validation event handler

                reader.ValidationEventHandler +=
                       new ValidationEventHandler(ValidationCallBack);

                // Read XML data

                while (reader.Read()) { }

            }
            catch (Exception e)
            {
                bValid = false;
                errors.Add(e.Message);
            }
            finally
            {
                //Close the reader.

                reader.Close();
            }

            return bValid;
        }

        private void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            bValid = false;
            errors.Add(args.Message);
        }

    }
}