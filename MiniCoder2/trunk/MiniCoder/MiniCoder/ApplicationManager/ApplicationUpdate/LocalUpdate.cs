using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.ApplicationManager.ApplicationUpdate
{
    class LocalUpdate : IUpdate
    {
        LocalUpdate()
        {
        }

        public Boolean UpdateApplication(List<String> application)
        {
            return true;
        }

        public double GetVersion(List<String> application)
        {
            return 1.0;
        }
    }
}
