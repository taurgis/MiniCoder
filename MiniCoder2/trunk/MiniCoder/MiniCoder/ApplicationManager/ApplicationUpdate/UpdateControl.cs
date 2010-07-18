using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.ApplicationManager.ApplicationUpdate
{
    class UpdateControl
    {
        public List<String> applicationList {get; set;}
        IUpdate AppUpdate = null;

        UpdateControl()
        {
            this.applicationList = null;
        }

        UpdateControl(List<String> applicationList)
        {
            this.applicationList = applicationList;
        }

        public void CheckForUpdates()
        {
            if (applicationList != null)
            {
                AppUpdate = new ExternalUpdate();
                AppUpdate.GetVersion(applicationList);
            }
        }

        public void UpdateApplication()
        {
            if (applicationList != null)
            {
                AppUpdate = new ExternalUpdate();
                AppUpdate.UpdateApplication(applicationList);
            }
        }

    }
}
