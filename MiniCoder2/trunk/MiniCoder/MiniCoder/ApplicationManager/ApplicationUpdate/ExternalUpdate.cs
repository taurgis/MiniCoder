using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MiniCoder2.ApplicationManager.ApplicationUpdate
{
    class ExternalUpdate : IUpdate
    {
        public ExternalUpdate()
        {
        }

        public Boolean UpdateApplication(List<String> application)
        {
            return true; //return true if update successful of all applications
        }

        public String[] GetVersion(List<String> application)
        {
            String[] versionList = new String[5];
            String URLString = "http://www.gamerzzheaven.be/applications.xml";
            
            XmlTextReader reader = new XmlTextReader(URLString);

            while (reader.Read())
            {
                if (reader.NodeType.Equals(XmlNodeType.Element))
                {
                    if (reader.Name.Equals("Application"))
                    {
                        while (reader.MoveToNextAttribute()) // Read the attributes.
                            if (reader.Name == "name")
                            {
                                if (reader.Value.Equals("x264")) //change the z264 string value to the enum once tested
                                {
                                    reader.Read();
                                    if(reader.Name.Equals("Version"))
                                    {
                                        versionList[0] = reader.ReadString();
                                    }
                                }
                            }
                    }
                }
            }
            return versionList; //return curerent application version
        }
    }
}
