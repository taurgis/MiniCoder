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
        SortedList<String, Tool> toolInfo;
        Boolean warnUser = false;
        Tools tools;
       
        public Updater(Tools tools, Boolean hide)
        {
            
            InitializeComponent();
            this.tools = tools;
            toolInfo = tools.getTools();
           LogBook.addLogLine("Update Manager","UpdateChecking","UpdateChecking",false);
            foreach (string key in toolInfo.Keys)
            {
                Tool tempTool = toolInfo[key];
                
                String updateText="";
                if (tempTool.localVersion != tempTool.onlineVersion)
                {
                    if (!String.IsNullOrEmpty(tempTool.onlineVersion) && !tempTool.localVersion.Equals("Custom") &&!tempTool.localVersion.Equals("Ignore"))
                    {
                        if (!key.Equals("avs"))
                            updateText = "Update Required";
                        else
                        {
                            if (!tempTool.isInstalled())
                                updateText = "Update Required";
                            else
                            {
                                updateText = "Up to Date";
                                tempTool.localVersion = tempTool.onlineVersion;
                            }
                        }
                    }
                }
                else
                {
                    updateText = "Up to Date";
                }
                string[] tempInfo = { "", key, tempTool.localVersion, tempTool.onlineVersion, updateText};
                ListViewItem tempListItem = new ListViewItem(tempInfo);

                if (updateText.Equals("Update Required"))
                {
                    LogBook.addLogLine("Updates available for " + key + ".","UpdateChecking","", false);
                    if (hide)
                    {
                        if (MessageBox.Show("Updates available. Do you wish to download them now?", "Updates", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Updater upd = new Updater(tools, false);
                            this.Close();
                            upd.ShowDialog();
                            return;

                        }
                        else
                        {
                            this.Close();
                            return;
                        }
                    }
                    tempListItem.Checked = true;
                }
                switch (tempTool.getCategory())
                {
                    case "core":
                        coreList.Items.Add(tempListItem);
                        break;
                    case "plugin":
                        pluginsList.Items.Add(tempListItem);
                        break;
                    case "audio":
                        audioList.Items.Add(tempListItem);
                        break;
                    case "video":
                        videoList.Items.Add(tempListItem);
                        break;
                    case "muxer":
                        muxingList.Items.Add(tempListItem);
                        break;
                    case "other":
                        otherList.Items.Add(tempListItem);
                        break;
                }

           


            }
        }
        

        public Boolean needUpdate()
        {
            return warnUser;
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
                    Tool tempPackage = (Tool)toolInfo[audioList.Items[i].SubItems[1].Text];
                    updateLog.Text = "Downloading " + audioList.Items[i].SubItems[1].Text + " ...\r\n" + updateLog.Text;
                    if (!tempPackage.download())
                    {
                        updateButton.Enabled = true;
                        updateLog.Text = "Downloading cancelled\r\n" + updateLog.Text;
                        return;
                    }
                    tempPackage.localVersion = tempPackage.onlineVersion;
                    audioList.Items[i].SubItems[4].Text = "Up to date";
                    audioList.Items[i].Checked = false;
                    downloadProgress.Value++;
                    updateLog.Text += "Download & Install Complete .. \r\n";
                    LogBook.addLogLine("Downloaded & Updated " + audioList.Items[i].SubItems[1].Text, "UpdateChecking", "", false);
                }
            }

            for (int i = 0; i < videoList.Items.Count; i++)
            {
                if (videoList.Items[i].Checked)
                {
                    Tool tempPackage = (Tool)toolInfo[videoList.Items[i].SubItems[1].Text];
                    updateLog.Text = "Downloading " + videoList.Items[i].SubItems[1].Text + " ...\r\n" + updateLog.Text;
                    if (!tempPackage.download())
                    {
                        updateButton.Enabled = true;
                        updateLog.Text = "Downloading cancelled\r\n" + updateLog.Text;
                        return;
                    }
                    tempPackage.localVersion = tempPackage.onlineVersion;
                    videoList.Items[i].SubItems[4].Text = "Up to date";
                    videoList.Items[i].Checked = false;
                    downloadProgress.Value++;
                    updateLog.Text += "Download & Install Complete .. \r\n";
                    LogBook.addLogLine("Downloaded & Updated " + videoList.Items[i].SubItems[1].Text, "UpdateChecking", "", false);
                }
            }

            for (int i = 0; i < pluginsList.Items.Count; i++)
            {
                if (pluginsList.Items[i].Checked)
                {
                    Tool tempPackage = (Tool)toolInfo[pluginsList.Items[i].SubItems[1].Text];
                    updateLog.Text = "Downloading " + pluginsList.Items[i].SubItems[1].Text + " ...\r\n" + updateLog.Text;
                    if (!tempPackage.download())
                    {
                        updateButton.Enabled = true;
                        updateLog.Text = "Downloading cancelled\r\n" + updateLog.Text;
                        return;
                    }
                    tempPackage.localVersion = tempPackage.onlineVersion;
                    pluginsList.Items[i].SubItems[4].Text = "Up to date";
                    pluginsList.Items[i].Checked = false;
                    downloadProgress.Value++;
                    updateLog.Text += "Download & Install Complete .. \r\n";
                    LogBook.addLogLine("Downloaded & Updated " + pluginsList.Items[i].SubItems[1].Text, "UpdateChecking", "", false);
                }
            }

            for (int i = 0; i < muxingList.Items.Count; i++)
            {
                if (muxingList.Items[i].Checked)
                {
                    Tool tempPackage = (Tool)toolInfo[muxingList.Items[i].SubItems[1].Text];
                    updateLog.Text = "Downloading " + muxingList.Items[i].SubItems[1].Text + " ...\r\n" + updateLog.Text;
                    if (!tempPackage.download())
                    {
                        updateButton.Enabled = true;
                        updateLog.Text = "Downloading cancelled\r\n" + updateLog.Text;
                        return;
                    }
                    tempPackage.localVersion = tempPackage.onlineVersion;
                    muxingList.Items[i].SubItems[4].Text = "Up to date";
                    muxingList.Items[i].Checked = false;
                    downloadProgress.Value++;
                    updateLog.Text += "Download & Install Complete .. \r\n";
                    LogBook.addLogLine("Downloaded & Updated " + muxingList.Items[i].SubItems[1].Text, "UpdateChecking", "", false);
                }
            }

            for (int i = 0; i < otherList.Items.Count; i++)
            {
                if (otherList.Items[i].Checked)
                {
                    Tool tempPackage = (Tool)toolInfo[otherList.Items[i].SubItems[1].Text];
                    updateLog.Text = "Downloading " + otherList.Items[i].SubItems[1].Text + " ...\r\n" + updateLog.Text;
                    if (!tempPackage.download())
                    {
                        updateButton.Enabled = true;
                        updateLog.Text = "Downloading cancelled\r\n" + updateLog.Text;
                        return;
                    }
                    tempPackage.localVersion = tempPackage.onlineVersion;
                    otherList.Items[i].SubItems[4].Text = "Up to date";
                    otherList.Items[i].Checked = false;
                    downloadProgress.Value++;
                    updateLog.Text += "Download & Install Complete .. \r\n";
                    LogBook.addLogLine("Downloaded & Updated " + otherList.Items[i].SubItems[1].Text, "UpdateChecking", "", false);
                }
            }
            tools.SavePackages();
            for (int i = 0; i < coreList.Items.Count; i++)
            {
                if (coreList.Items[i].Checked)
                {
                    if (coreList.Items[i].SubItems[1].Text == "Core")
                    {
                        Tool tempPackage = (Tool)tools.getTools()["Core"];
                        updateLog.Text = "Downloading " + coreList.Items[i].SubItems[1].Text + " ...\r\n" + updateLog.Text;
                        if (!tempPackage.download())
                        {
                            updateButton.Enabled = true;
                            updateLog.Text = "Downloading cancelled\r\n" + updateLog.Text;
                            return;
                        }

                        //        Package tempPackage = (Package)applicationInfo[coreList.Items[i].SubItems[2].ToString()];
                        MessageBox.Show("Minicoder has to restart to update its core files.");
                        Application.Exit();
                        Process.Start("CoreUpdater.exe");
                    }
                    else
                    {
                        Tool tempPackage = (Tool)toolInfo[coreList.Items[i].SubItems[1].Text];
                        updateLog.Text = "Downloading " + coreList.Items[i].SubItems[1].Text + " ...\r\n" + updateLog.Text;
                        if (!tempPackage.download())
                        {
                            updateButton.Enabled = true;
                            updateLog.Text = "Downloading cancelled\r\n" + updateLog.Text;
                            return;
                        }
                        tempPackage.localVersion = tempPackage.onlineVersion;
                        coreList.Items[i].SubItems[4].Text = "Up to date";
                        coreList.Items[i].Checked = false;
                        downloadProgress.Value++;
                        updateLog.Text += "Download & Install Complete .. \r\n";
                        LogBook.addLogLine("Downloaded & Updated " + coreList.Items[i].SubItems[1].Text, "UpdateChecking", "", false);
                        tools.SavePackages();
                    }
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

            Tool tempPackage = (Tool)toolInfo[tempListbox.SelectedItems[0].SubItems[1].Text];
            tempPackage.localVersion = "Ignore";

            tools.SavePackages();
        }



        private void stopIgnoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tempContext = (ToolStripMenuItem)sender;
            ContextMenuStrip tempMenu = (ContextMenuStrip)tempContext.Owner;
            ListView tempListbox = (ListView)tempMenu.SourceControl;
            Tool tempPackage = (Tool)toolInfo[tempListbox.SelectedItems[0].SubItems[1].Text];
            tempPackage.localVersion = "Unignored";

            tools.SavePackages();
        }

        private void Updater_Load(object sender, EventArgs e)
        {

        }


    }
}
