using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.ApplicationManager.ApplicationUpdate
{
    class UpdateControl
    {
        public List<String> ApplicationList {get; set;}
        public String[] VersionList {get; set;}

        IUpdate AppUpdate = null;

        public UpdateControl()
        {
            this.ApplicationList = null;
        }

        public UpdateControl(List<String> applicationList)
        {
            this.ApplicationList = applicationList;
        }

        /// <summary>
        /// Check to see if each external application in the list of applications
        /// is up to date
        /// </summary>
        public void CheckForUpdates()
        {
            if (ApplicationList != null)
            {
                AppUpdate = new ExternalUpdate();
                VersionList = AppUpdate.GetVersion(ApplicationList);
            }
        }

        public void UpdateApplication()
        {
            if (ApplicationList != null)
            {
                AppUpdate = new ExternalUpdate();
                AppUpdate.UpdateApplication(ApplicationList);
            }
        }

    }
}
