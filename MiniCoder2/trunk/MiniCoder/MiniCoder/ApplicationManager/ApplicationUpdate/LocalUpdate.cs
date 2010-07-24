using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.ApplicationManager.ApplicationUpdate
{
    class LocalUpdate : IUpdate
    {
        public LocalUpdate()
        {
        }

        public Boolean UpdateApplication(List<String> application)
        {
            return true;
        }

        public String[] GetVersion(List<String> application)
        {
            String[] versionList = new String[1];
            versionList[0] = "1.0";
            return versionList; //return curerent application version
        }
    }
}
