using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Net;
using System.IO;
using System.Collections;
using System.Diagnostics;
using MiniCoder.External;
namespace MiniCoder.GUI.External
{
    public partial class Updater : Form
    {
      
        Hashtable applicationVersions = new Hashtable();
        SortedList<String, Tool> applicationInfo;
        Boolean warnUser = false;
        Tools tools;
       
        public Updater(Tools tools)
        {
            InitializeComponent();
            this.tools = tools;
            string updaterText = GetText("http://www.gamerzzheaven.be/updater.txt");
            string[] applicationInfo = updaterText.Split(Convert.ToChar("\n"));

            for (int i = 0; i < applicationInfo.Length; i++)
            {
                string[] application = applicationInfo[i].Split(Convert.ToChar(";"));

                applicationVersions.Add(application[0], application[1]);
            }

        }
        public Updater(Tools tools, string unused)
        {
            try
            {
                InitializeComponent();

                this.tools = tools;
                string updaterText = "";
                if (MiniOnline.checkInternet())
                {
                    updaterText = GetText("http://www.gamerzzheaven.be/updater.txt");
                }
                else
                {
                    this.Close();
                }
                string[] applicationInfo = updaterText.Split(Convert.ToChar("\n"));

                for (int i = 0; i < applicationInfo.Length; i++)
                {
                    string[] application = applicationInfo[i].Split(Convert.ToChar(";"));

                    applicationVersions.Add(application[0], application[1]);
                }
                warnUser = Updater_Load_NoWindow();
                if(warnUser)
                    if (MessageBox.Show("Updates available! Download now?", "Updates", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Updater updater = new Updater(tools);
                        updater.ShowDialog();
                      
                    }
            }
            catch
            {
                LogBook.addLogLine("Error updating, can't find file or connection.", 0,"");
               
               // log.sendmail(applicationSettings);
            }
        }

        public Boolean needUpdate()
        {
            return warnUser;
        }

        private bool Updater_Load_NoWindow()
        {
            String[] core;
            Boolean updateRequired = false;

            LogBook.addLogLine("Updates", 0);

            if (Assembly.GetExecutingAssembly().GetName().Version.ToString() != applicationVersions["Core"].ToString().Replace("\r", ""))
            {
                core = new String[] { "", "Core Files", Assembly.GetExecutingAssembly().GetName().Version.ToString(), applicationVersions["Core"].ToString().Replace("\r", ""), "Update required" };
                updateRequired = true;
                LogBook.addLogLine("Updates available for core.",1);
            }
            else
            {
                core = new String[] { "", "Core Files", Assembly.GetExecutingAssembly().GetName().Version.ToString(), applicationVersions["Core"].ToString().Replace("\r", ""), "Up to date" };
            }

            coreList.Items.Add(new ListViewItem(core));
            applicationInfo = tools.getTools();

            foreach (string key in applicationInfo.Keys)
            {
                Boolean ignoreUpdates = false;
                if (key != "Core")
                {
                    Tool tempPackage = (Tool)applicationInfo[key];
                    string appVersion = "";
                    string onlineVersion = applicationVersions[key].ToString().Replace("\r", "");
                    if (tempPackage.getCategory() == "plugin")
                    {
                        if (File.Exists(tempPackage.getInstallPath() + "\\version_" + key + ".txt"))
                        {
                            StreamReader streamReader = new StreamReader(tempPackage.getInstallPath() + "\\version_" + key + ".txt");
                            appVersion = streamReader.ReadLine();
                            streamReader.Close();
                            if (appVersion.Equals("Ignore"))
                                ignoreUpdates = true;
                        }
                        else
                        {
                            appVersion = "Not Installed";
                        }
                    }
                    else
                    {
                        if (tempPackage.getCustomPath() == "")
                        {
                            if (File.Exists(tempPackage.getInstallPath() + "\\version.txt"))
                            {
                                StreamReader streamReader = new StreamReader(tempPackage.getInstallPath() + "\\version.txt");
                                appVersion = streamReader.ReadLine();
                                streamReader.Close();
                                if (appVersion.Equals("Ignore"))
                                    ignoreUpdates = true;
                            }
                            else
                            {
                                appVersion = "Not Installed";
                            }
                        }
                        else
                        {
                            appVersion = "Custom Path";
                        }
                    }
                    if (key == "avs")
                    {
                        if (tempPackage.isInstalled())
                            appVersion = "2.5";
                    }

                    if ((appVersion != onlineVersion || !tempPackage.isInstalled()))
                    {
                        string test = tempPackage.getCustomPath();
                        if (tempPackage.getCustomPath() == "" && !ignoreUpdates)
                        {
                            LogBook.addLogLine("Updates available for " + key + ".", 1);
                            updateRequired = true;
                        }
                      
                    }
                  
                }

            }
            if (updateRequired)
            {
               
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Updater_Load(object sender, EventArgs e)
        {
            try
            {
                bool updateAvailable = false;
                String[] core;
                if (Assembly.GetExecutingAssembly().GetName().Version.ToString() != applicationVersions["Core"].ToString().Replace("\r", ""))
                {
                    core = new String[] { "", "Core", Assembly.GetExecutingAssembly().GetName().Version.ToString(), applicationVersions["Core"].ToString().Replace("\r", ""), "Update required" };
                    ListViewItem tempList = new ListViewItem(core);
                    tempList.Checked = true;
                    coreList.Items.Add(tempList);
                    updateAvailable = true;
                }
                else
                {
                    core = new String[] { "", "Core", Assembly.GetExecutingAssembly().GetName().Version.ToString(), applicationVersions["Core"].ToString().Replace("\r", ""), "Up to date" };
                    coreList.Items.Add(new ListViewItem(core));
                }
                applicationInfo = tools.getTools();





                foreach (string key in applicationInfo.Keys)
                {
                    Boolean ignoreUpdates = false;
                    if (key != "Core")
                    {
                        Tool tempPackage = (Tool)applicationInfo[key];

                        string appVersion = "";
                        string onlineVersion = applicationVersions[key].ToString().Replace("\r", "");
                        string requiredUpdate = "";

                        if (tempPackage.getCategory() == "plugin")
                        {
                            String temp = tempPackage.getInstallPath() + "version_" + key + ".txt";
                            if (File.Exists(tempPackage.getInstallPath() + "version_" + key + ".txt"))
                            {
                                StreamReader streamReader = new StreamReader(tempPackage.getInstallPath() + "\\version_" + key + ".txt");
                                appVersion = streamReader.ReadLine();
                                streamReader.Close();
                                if (appVersion.Equals("Ignore"))
                                    ignoreUpdates = true;
                            }
                            else
                            {
                                appVersion = "Not Installed";
                            }
                        }
                        else
                        {
                            if (tempPackage.getCustomPath() == "")
                            {
                                if (File.Exists(tempPackage.getInstallPath() + "\\version.txt"))
                                {
                                    StreamReader streamReader = new StreamReader(tempPackage.getInstallPath() + "\\version.txt");
                                    appVersion = streamReader.ReadLine();

                                    streamReader.Close();
                                    if (appVersion.Equals("Ignore"))
                                        ignoreUpdates = true;
                                }
                                else
                                {
                                    appVersion = "Not Installed";
                                }
                            }
                            else
                            {
                                appVersion = "Custom Path";
                            }
                        }
                        if (key == "avs")
                        {
                            if (tempPackage.isInstalled())
                                appVersion = "2.5";
                        }

                        if ((appVersion != onlineVersion || !tempPackage.isInstalled()))
                        {
                            if (tempPackage.getCustomPath() == "" && !ignoreUpdates)
                            {
                                requiredUpdate = "Update Required";
                                updateAvailable = true;
                            }
                            else if (ignoreUpdates)
                                requiredUpdate = "Updates Ignored";
                            else
                            {
                                requiredUpdate = "Up to date";
                                // updateAvailable = false;
                            }
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

                }
                if (updateAvailable)
                    updateLog.Text += "Update Available\r\n";
            }
            catch
            {
                LogBook.addLogLine("No internet connection found", 0,"");
            }
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
            updateButton.Enabled = false;
            downloadProgress.Value = 0;
            downloadProgress.Minimum = 0;
            downloadProgress.Maximum = audioList.CheckedItems.Count + videoList.CheckedItems.Count + muxingList.CheckedItems.Count + pluginsList.CheckedItems.Count + otherList.CheckedItems.Count + coreList.CheckedItems.Count;


            for (int i = 0; i < audioList.Items.Count; i++)
            {
                if (audioList.Items[i].Checked)
                {
                    Tool tempPackage = (Tool)applicationInfo[audioList.Items[i].SubItems[1].Text];
                    updateLog.Text += "Downloading " + audioList.Items[i].SubItems[1].Text + " ...\r\n";
                    tempPackage.download();
                    audioList.Items[i].SubItems[4].Text = "Up to date";
                    audioList.Items[i].Checked = false;
                    downloadProgress.Value++;
                    updateLog.Text += "Download & Install Complete .. \r\n";
                }
            }

            for (int i = 0; i < videoList.Items.Count; i++)
            {
                if (videoList.Items[i].Checked)
                {
                    Tool tempPackage = (Tool)applicationInfo[videoList.Items[i].SubItems[1].Text];
                    updateLog.Text += "Downloading " + videoList.Items[i].SubItems[1].Text + " ...\r\n";
                    tempPackage.download();
                    videoList.Items[i].SubItems[4].Text = "Up to date";
                    videoList.Items[i].Checked = false;
                    downloadProgress.Value++;
                    updateLog.Text += "Download & Install Complete .. \r\n";
                }
            }

            for (int i = 0; i < pluginsList.Items.Count; i++)
            {
                if (pluginsList.Items[i].Checked)
                {
                    Tool tempPackage = (Tool)applicationInfo[pluginsList.Items[i].SubItems[1].Text];
                    updateLog.Text += "Downloading " + pluginsList.Items[i].SubItems[1].Text + " ...\r\n";
                    tempPackage.download();
                    pluginsList.Items[i].SubItems[4].Text = "Up to date";
                    pluginsList.Items[i].Checked = false;
                    downloadProgress.Value++;
                    updateLog.Text += "Download & Install Complete .. \r\n";
                }
            }

            for (int i = 0; i < muxingList.Items.Count; i++)
            {
                if (muxingList.Items[i].Checked)
                {
                    Tool tempPackage = (Tool)applicationInfo[muxingList.Items[i].SubItems[1].Text];
                    updateLog.Text += "Downloading " + muxingList.Items[i].SubItems[1].Text + " ...\r\n";
                    tempPackage.download();
                    muxingList.Items[i].SubItems[4].Text = "Up to date";
                    muxingList.Items[i].Checked = false;
                    downloadProgress.Value++;
                    updateLog.Text += "Download & Install Complete .. \r\n";
                }
            }

            for (int i = 0; i < otherList.Items.Count; i++)
            {
                if (otherList.Items[i].Checked)
                {
                    Tool tempPackage = (Tool)applicationInfo[otherList.Items[i].SubItems[1].Text];
                    updateLog.Text += "Downloading " + otherList.Items[i].SubItems[1].Text + " ...\r\n";
                    tempPackage.download();
                    otherList.Items[i].SubItems[4].Text = "Up to date";
                    otherList.Items[i].Checked = false;
                    downloadProgress.Value++;
                    updateLog.Text += "Download & Install Complete .. \r\n";
                }
            }

            for (int i = 0; i < coreList.Items.Count; i++)
            {
                if (coreList.Items[i].Checked)
                {

                    Tool tempPackage = (Tool)tools.getTools()["Core"];
                    updateLog.Text += "Downloading " + coreList.Items[i].SubItems[1].Text + " ...\r\n";
                    tempPackage.download();
                    //        Package tempPackage = (Package)applicationInfo[coreList.Items[i].SubItems[2].ToString()];
                    MessageBox.Show("Minicoder has to restart to update its core files.");
                    Application.Exit();
                    Process.Start("CoreUpdater.exe");

                }
            }
            updateButton.Enabled = true;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customPath_Click(object sender, EventArgs e)
        {
            AppLocation appLoc = new AppLocation(tools.getTools());
            appLoc.ShowDialog();
            if (appLoc.doSave())
                tools.SavePackages();
        }

        private void ignoreUpdatesMenuStrip_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tempContext = (ToolStripMenuItem)sender;
            ContextMenuStrip tempMenu = (ContextMenuStrip)tempContext.Owner;
            ListView tempListbox = (ListView)tempMenu.SourceControl;
            for (int i = 0; i < tempListbox.SelectedItems.Count; i++)
            {
                String tempName = tempListbox.SelectedItems[i].SubItems[1].Text;
                Tool tempPackage = (Tool)tools.getTools()[tempName];
                
                if (!Directory.Exists(tempPackage.getInstallPath()) || !File.Exists(tempPackage.getInstallPath() + "\\version.txt"))
                {
                    if (tempPackage.getCategory() != "plugin")
                    {
                        Directory.CreateDirectory(tempPackage.getInstallPath());

                        StreamWriter streamWrite = new StreamWriter(tempPackage.getInstallPath() + "\\version.txt");
                        streamWrite.WriteLine("Ignore");
                        streamWrite.Close();
                    }

                }
                else
                {
                    try
                    {
                        StreamWriter streamWriter;
                        if (tempPackage.getCategory() == "plugin")
                        {
                            File.Copy(tempPackage.getInstallPath() + "\\version_" + tempName + ".txt", tempPackage.getInstallPath() + "\\version_" + tempName + "_old.txt");
                             streamWriter = new StreamWriter(tempPackage.getInstallPath() + "\\version_" + tempName + ".txt", false);
                            streamWriter.WriteLine("Ignore");
                            streamWriter.Close();
                        }
                        else
                        {
                            File.Copy(tempPackage.getInstallPath() + "\\version.txt", tempPackage.getInstallPath() + "\\version_old.txt");
                             streamWriter = new StreamWriter(tempPackage.getInstallPath() + "\\version.txt", false);
                            streamWriter.WriteLine("Ignore");
                            streamWriter.Close();
                        }
                    }
                    catch (IOException)
                    {
                    }

                   
                }
            }
        }



        private void stopIgnoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tempContext = (ToolStripMenuItem)sender;
            ContextMenuStrip tempMenu = (ContextMenuStrip)tempContext.Owner;
            ListView tempListbox = (ListView)tempMenu.SourceControl;
            for (int i = 0; i < tempListbox.SelectedItems.Count; i++)
            {
                String tempName = tempListbox.SelectedItems[i].SubItems[1].Text;
                Tool tempPackage = (Tool)tools.getTools()[tempName];

                if (tempPackage.getCategory() == "plugin")
                {
                    try
                    {
                        
                        File.Delete(tempPackage.getInstallPath() + "\\version_" + tempName + ".txt");
                        File.Copy(tempPackage.getInstallPath() + "\\version_" + tempName + "_old.txt", tempPackage.getInstallPath() + "\\version_" + tempName + ".txt");
                        File.Delete(tempPackage.getInstallPath() + "\\version_" + tempName + "_old.txt");
                    }
                    catch (IOException)
                    {
                    }
                }
                else
                {
                    try
                    {
                        File.Delete(tempPackage.getInstallPath() + "\\version.txt");
                        File.Copy(tempPackage.getInstallPath() + "\\version_old.txt", tempPackage.getInstallPath() + "\\version.txt");
                        File.Delete(tempPackage.getInstallPath() + "\\version_old.txt");
                    }
                    catch (IOException)
                    {
                    }
                }


            }
        }


    }
}
