using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MiniCoder.General;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Net;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace MiniCoder
{
    public partial class Updater : Form
    {
        ApplicationSettings applicationSettings;
        Hashtable applicationVersions = new Hashtable();
        Hashtable applicationInfo;
        Boolean warnUser = false;
        x264_GUI_CS.LogBook log;
        public Updater(ApplicationSettings applicationSettings)
        {
            InitializeComponent();
            this.applicationSettings = applicationSettings;
            string updaterText = GetText("http://www.gamerzzheaven.be/updater.txt");
            string[] applicationInfo = updaterText.Split(Convert.ToChar("\n"));

            for (int i = 0; i < applicationInfo.Length; i++)
            {
                string[] application = applicationInfo[i].Split(Convert.ToChar(";"));
                applicationVersions.Add(application[0], application[1]);
            }
            Updater_Load();
        }
        public Updater(ApplicationSettings applicationSettings, x264_GUI_CS.LogBook log)
        {
            InitializeComponent();
            this.log = log;
            this.applicationSettings = applicationSettings;
            string updaterText = GetText("http://www.gamerzzheaven.be/updater.txt");
            string[] applicationInfo = updaterText.Split(Convert.ToChar("\n"));

            for (int i = 0; i < applicationInfo.Length; i++)
            {
                string[] application = applicationInfo[i].Split(Convert.ToChar(";"));
                applicationVersions.Add(application[0], application[1]);
            }
            warnUser = Updater_Load_NoWindow();
        }

        public Boolean needUpdate()
        {
            return warnUser;
        }

        private bool Updater_Load_NoWindow()
        {
            String[] core = { "", "Core Files", Assembly.GetExecutingAssembly().GetName().Version.ToString(), applicationVersions["Core"].ToString().Replace("\r", ""), "Up to date" };
            coreList.Items.Add(new ListViewItem(core));
            applicationInfo = applicationSettings.htRequired;
            Boolean updateRequired = false;
            

            foreach (string key in applicationInfo.Keys)
            {
                
                Package tempPackage = (Package)applicationInfo[key];
                string appVersion = "";
                string onlineVersion = applicationVersions[key].ToString().Replace("\r", "");
            

                if (File.Exists(tempPackage.getInstallPath() + "\\version.txt"))
                {
                    StreamReader streamReader = new StreamReader(tempPackage.getInstallPath() + "\\version.txt");
                    appVersion = streamReader.ReadLine();
                    streamReader.Close();
                }
                else
                {
                    appVersion = "Not Installed";
                }
                if (key == "avs")
                {
                    if (tempPackage.isInstalled())
                        appVersion = "2.5";
                }

                if ((appVersion != onlineVersion))
                {
                    log.addLine("Updates available for " + key + ".");
                    updateRequired = true;
                }
                else
                {
                    
                }

               
              




              
            }
            if (updateRequired)
                return true;
            else
            return false;

        }
        private void Updater_Load()
        {
            String[] core = { "", "Core Files", Assembly.GetExecutingAssembly().GetName().Version.ToString(), applicationVersions["Core"].ToString().Replace("\r", ""), "Up to date" };
            coreList.Items.Add(new ListViewItem(core));
            applicationInfo = applicationSettings.htRequired;

            bool updateAvailable = false;

            foreach (string key in applicationInfo.Keys)
            {
                Package tempPackage = (Package)applicationInfo[key];
                string appVersion ="";
                string onlineVersion = applicationVersions[key].ToString().Replace("\r", "");
                string requiredUpdate = "";

                if (File.Exists(tempPackage.getInstallPath() + "\\version.txt"))
                {
                    StreamReader streamReader = new StreamReader(tempPackage.getInstallPath() + "\\version.txt");
                    appVersion = streamReader.ReadLine();
                    streamReader.Close();
                }
                else
                {
                    appVersion = "Not Installed";
                }
                if (key == "avs")
                {
                    if(tempPackage.isInstalled())
                    appVersion = "2.5";
                }

                if ((appVersion != onlineVersion))
                {
                    requiredUpdate = "Update Required";
                    updateAvailable = true;
                }
                else
                    requiredUpdate = "Up to date";

                String[] appInfo = { "", key, appVersion, onlineVersion, requiredUpdate };
               
                


                ListViewItem tempListViewItem = new ListViewItem(appInfo);

                if (requiredUpdate == "Update Required")
                    tempListViewItem.Checked = true;
                switch (tempPackage.getCategory())
                {
                    case "plugin":
                        pluginsList.Items.Add(tempListViewItem);
                        break;
                    case "audio":
                        audioList.Items.Add(tempListViewItem);
                        break;
                    case "video":
                        videoList.Items.Add(tempListViewItem);
                        break;
                    case "muxer":
                        muxingList.Items.Add(tempListViewItem);
                        break;
                    case "other":
                        otherList.Items.Add(tempListViewItem);
                        break;
                }
            }
            if (updateAvailable)
                updateLog.Text += "Update Available\r\n";

        }

        public string GetText(string url)
        {
            WebRequest req = WebRequest.Create((url));

            WebResponse response = req.GetResponse();
            return StringFromResponse(response);
        }
        private string StringFromResponse(WebResponse response)
        {
            String url = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return url;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < coreList.Items.Count; i++)
            {
                if (coreList.Items[i].Checked)
                {
            //        Package tempPackage = (Package)applicationInfo[coreList.Items[i].SubItems[2].ToString()];
                    Process.Start("https://sourceforge.net/projects/minicoder");
                    
                }
            }

            for (int i = 0; i < audioList.Items.Count; i++)
            {
                if (audioList.Items[i].Checked)
                {
                    Package tempPackage = (Package)applicationInfo[audioList.Items[i].SubItems[1].Text];
                    updateLog.Text += "Downloading " + audioList.Items[i].SubItems[1].Text + " ...\r\n";
                    tempPackage.download();
                    updateLog.Text += "Download & Install Complete .. \r\n";
                }
            }

            for (int i = 0; i < videoList.Items.Count; i++)
            {
                if (videoList.Items[i].Checked)
                {
                    Package tempPackage = (Package)applicationInfo[videoList.Items[i].SubItems[1].Text];
                    updateLog.Text += "Downloading " + videoList.Items[i].SubItems[1].Text + " ...\r\n";
                    tempPackage.download();
                    updateLog.Text += "Download & Install Complete .. \r\n";
                }
            }

            for (int i = 0; i < pluginsList.Items.Count; i++)
            {
                if (pluginsList.Items[i].Checked)
                {
                    Package tempPackage = (Package)applicationInfo[pluginsList.Items[i].SubItems[1].Text];
                    updateLog.Text += "Downloading " + pluginsList.Items[i].SubItems[1].Text + " ...\r\n";
                    tempPackage.download();
                    updateLog.Text += "Download & Install Complete .. \r\n";
                }
            }

            for (int i = 0; i < muxingList.Items.Count; i++)
            {
                if (muxingList.Items[i].Checked)
                {
                    Package tempPackage = (Package)applicationInfo[muxingList.Items[i].SubItems[1].Text];
                    updateLog.Text += "Downloading " + muxingList.Items[i].SubItems[1].Text + " ...\r\n";
                    tempPackage.download();
                    updateLog.Text += "Download & Install Complete .. \r\n";
                }
            }

            for (int i = 0; i < otherList.Items.Count; i++)
            {
                if (otherList.Items[i].Checked)
                {
                    Package tempPackage = (Package)applicationInfo[otherList.Items[i].SubItems[1].Text];
                    updateLog.Text += "Downloading " + otherList.Items[i].SubItems[1].Text + " ...\r\n";
                    tempPackage.download();
                    updateLog.Text += "Download & Install Complete .. \r\n";
                }
            }

        }
    }
}
