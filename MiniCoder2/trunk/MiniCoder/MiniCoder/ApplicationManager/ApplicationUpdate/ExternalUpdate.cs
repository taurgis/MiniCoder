using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.ApplicationManager.ApplicationUpdate
{
    public class ExternalUpdate : IUpdate
    {
        ExternalUpdate()
        {
        }

        public Boolean UpdateApplication(List<String> application)
        {
            return true; //return true if update successful of all applications
        }

        public double GetVersion(List<String> application)
        {
            return 1.0; //return curerent application version
        }
    }
}
