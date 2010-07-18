using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.ApplicationManager.ApplicationUpdate
{
    class UpdateControl
    {
        public List<String> application {get; set;}

        UpdateControl()
        {
            this.application = null;
        }

        UpdateControl(List<String> application)
        {
            this.application = application;
        }

        public void CheckForUpdates()
        {
            if (application != null)
            {
                //IUpdate AppUpdate = new ExternalUpdate();
            }
        }

    }
}
