using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiniCoder2.ApplicationManager.ApplicationUpdate;

namespace MiniCoder2.ApplicationManager.Gui
{
    public partial class ApplicationUpdateForm : Form
    {
        UpdateControl Uc = null;
        List<String> ApplicationList = new List<String>();

        public ApplicationUpdateForm()
        {
            InitializeComponent();
        }

        private void btnCheckForUpdate_Click(object sender, EventArgs e)
        {
            ApplicationList.Add("Test");

            Uc = new UpdateControl();
            Uc.ApplicationList = ApplicationList;
            Uc.CheckForUpdates();
            if(Uc.VersionList.GetValue((int)ExtApplication.X264) != ("0.1")) //"0.1" string value to be replaced by a local version list
            {
                clbApplicationList.SelectedIndex = (int)ExtApplication.X264;
                clbApplicationList.Items[0] += "    0.1 >>> " + Uc.VersionList.GetValue((int)ExtApplication.X264);
            }
        }

        private void lbxApplicationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //show version path
        }

    }
}
