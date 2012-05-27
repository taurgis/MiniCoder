﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MiniCoder2.Templating
{
    [XmlRoot("Template")]
    public abstract class ExtTemplate
    {
        [XmlElement("Name")]
        public String Name { get; set; }

        /// <summary>
        /// Generates the paramaters to be sent to the external program.
        /// </summary>
        /// <returns>The command line</returns>
        public virtual String GenerateCommandLine()
        {
            return "";
        }

        public virtual void Update(ExtTemplate template)
        {
            //Do nothing
        }

        /// <summary>
        /// Checks whether or not the template contains valid values. This is determined
        /// by the paramaters set by the external program. These values are usually found
        /// in the documentation.
        /// 
        /// Ex. A maximum bitrate
        /// </summary>
        /// <returns>Whether or not the template is valid</returns>
        public virtual Boolean IsValid()
        {
            if (!String.IsNullOrEmpty(Name))
                return true;
            else
                return false;
        }
    }
}