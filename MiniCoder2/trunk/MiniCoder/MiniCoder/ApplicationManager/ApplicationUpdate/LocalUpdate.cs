using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.ApplicationManager.UpdateControl
{
    class LocalUpdate : IUpdate
    {
        LocalUpdate()
        {
        }

        public Boolean UpdateApplication()
        {
            return true;
        }

        public double GetVersion()
        {
            return 1.0;
        }
    }
}
