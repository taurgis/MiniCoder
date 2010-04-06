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
using System.Collections;
using System.Xml;
using System.Xml.Schema;

namespace MiniCoder.Core.Encoding
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