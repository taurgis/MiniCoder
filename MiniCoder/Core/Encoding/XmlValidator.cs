﻿//    MiniCoder
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
using System.IO;
using System.Xml;
using System.Xml.Schema;
using MiniTech.MiniCoder.Core.Other.Logging;

namespace MiniTech.MiniCoder.Core.Encoding
{
    /* XMLValidator is currently only used to validate chapter files 
     * contained in MP4 or MKV files.
     * 
     * Recent update: 
     * Removed depricated functions.
     */

    public class XMLValidator
    {
        private string fileName;
        public XMLValidator(string fileName)
        {
            this.fileName = fileName;
            LogBookController.Instance.addLogLine("Reading file: " + fileName, LogMessageCategories.Debug);
        }

        public Boolean Validate()
        {
            XmlTextReader txtreader = null;
            try
            {
                txtreader = new XmlTextReader(fileName);

                XmlDocument doc = new XmlDocument();
                doc.Load(txtreader);
                ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);

                doc.Validate(eventHandler);
            }
            catch (IOException e)
            {
                LogBookController.Instance.addLogLine("Error accessing chapter files. Probably doesn't exist. \n" + e, LogMessageCategories.Error);
               
                return false;
            }
            catch (XmlException e)
            {
                LogBookController.Instance.addLogLine("Error inside chapters XML file, trying again.\n" + e, LogMessageCategories.Error);
                return false;
            }
            finally
            {
                txtreader.Close();
            }

            return true;
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            LogBookController.Instance.addLogLine("XML Error: " + e.Message, LogMessageCategories.Debug);

            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    break;
                default:
                    break;
            }
        }
    }
}