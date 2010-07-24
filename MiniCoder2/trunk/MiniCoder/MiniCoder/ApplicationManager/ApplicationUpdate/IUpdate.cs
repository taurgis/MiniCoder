using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.ApplicationManager.ApplicationUpdate
{
    interface IUpdate
    {
        Boolean UpdateApplication(List<String> application);
        String[] GetVersion(List<String> application);
    }
}
