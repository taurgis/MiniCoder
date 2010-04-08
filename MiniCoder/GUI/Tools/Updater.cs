//    MiniCoder
//    Copyright (C) 2009-2010  MiniTech support@minitech.org
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.

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
using MiniCoder.Core.Languages;
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

            this.Text = LanguageController.Instance.getLanguageString("updaterTitle");
            coreTab.Text = LanguageController.Instance.getLanguageString("coreTabTitle");
            pluginTab.Text = LanguageController.Instance.getLanguageString("pluginsTabTitle");
            audioTab.Text = LanguageController.Instance.getLanguageString("audioTabTitle");
            videoTab.Text = LanguageController.Instance.getLanguageString("videoTabTitle");
            muxTab.Text = LanguageController.Instance.getLanguageString("muxingTabTitle");
            otherTab.Text = LanguageController.Instance.getLanguageString("otherTabTitle");

            coreList.Columns[0].Text = LanguageController.Instance.getLanguageString("updateColumn1");
            pluginsList.Columns[0].Text = LanguageController.Instance.getLanguageString("updateColumn1");
            audioList.Columns[0].Text = LanguageController.Instance.getLanguageString("updateColumn1");
            videoList.Columns[0].Text = LanguageController.Instance.getLanguageString("updateColumn1");
            muxingList.Columns[0].Text = LanguageController.Instance.getLanguageString("updateColumn1");
            otherList.Columns[0].Text = LanguageController.Instance.getLanguageString("updateColumn1");

            coreList.Columns[1].Text = LanguageController.Instance.getLanguageString("updateColumn2");
            pluginsList.Columns[1].Text = LanguageController.Instance.getLanguageString("updateColumn2");
            audioList.Columns[1].Text = LanguageController.Instance.getLanguageString("updateColumn2");
            videoList.Columns[1].Text = LanguageController.Instance.getLanguageString("updateColumn2");
            muxingList.Columns[1].Text = LanguageController.Instance.getLanguageString("updateColumn2");
            otherList.Columns[1].Text = LanguageController.Instance.getLanguageString("updateColumn2");

            coreList.Columns[2].Text = LanguageController.Instance.getLanguageString("updateColumn3");
            pluginsList.Columns[2].Text = LanguageController.Instance.getLanguageString("updateColumn3");
            audioList.Columns[2].Text = LanguageController.Instance.getLanguageString("updateColumn3");
            videoList.Columns[2].Text = LanguageController.Instance.getLanguageString("updateColumn3");
            muxingList.Columns[2].Text = LanguageController.Instance.getLanguageString("updateColumn3");
            otherList.Columns[2].Text = LanguageController.Instance.getLanguageString("updateColumn3");

            coreList.Columns[3].Text = LanguageController.Instance.getLanguageString("updateColumn4");
            pluginsList.Columns[3].Text = LanguageController.Instance.getLanguageString("updateColumn4");
            audioList.Columns[3].Text = LanguageController.Instance.getLanguageString("updateColumn4");
            videoList.Columns[3].Text = LanguageController.Instance.getLanguageString("updateColumn4");
            muxingList.Columns[3].Text = LanguageController.Instance.getLanguageString("updateColumn4");
            otherList.Columns[3].Text = LanguageController.Instance.getLanguageString("updateColumn4");

            coreList.Columns[4].Text = LanguageController.Instance.getLanguageString("updateColumn5");
            pluginsList.Columns[4].Text = LanguageController.Instance.getLanguageString("updateColumn5");
            audioList.Columns[4].Text = LanguageController.Instance.getLanguageString("updateColumn5");
            videoList.Columns[4].Text = LanguageController.Instance.getLanguageString("updateColumn5");
            muxingList.Columns[4].Text = LanguageController.Instance.getLanguageString("updateColumn5");
            otherList.Columns[4].Text = LanguageController.Instance.getLanguageString("updateColumn5");

            customPath.Text = LanguageController.Instance.getLanguageString("updateCustomPath");
            updateButton.Text = LanguageController.Instance.getLanguageString("updateUpdateButton");
            cancelButton.Text = LanguageController.Instance.getLanguageString("updateCancelButton");

            this.tools = tools;
            toolInfo = tools.getTools();
            LogBook.Instance.addLogLine("Update Manager", "UpdateChecking", "UpdateChecking", false);
            foreach (string key in toolInfo.Keys)
            {
                Tool tempTool = toolInfo[key];

                String updateText = "";
                if (tempTool.localVersion != tempTool.onlineVersion)
                {
                    if (!String.IsNullOrEmpty(tempTool.onlineVersion) && !tempTool.localVersion.Equals("Custom") && !tempTool.localVersion.Equals("Ignore"))
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
                string[] tempInfo = { "", key, tempTool.localVersion, tempTool.onlineVersion, updateText };
                ListViewItem tempListItem = new ListViewItem(tempInfo);

                if (updateText.Equals("Update Required"))
                {
                    LogBook.Instance.addLogLine("Updates available for " + key + ".", "UpdateChecking", "", false);
                    if (hide)
                    {
                        if (MessageBox.Show(LanguageController.Instance.getLanguageString("updateMessage"), "Updates", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                    LogBook.Instance.addLogLine("Downloaded & Updated " + audioList.Items[i].SubItems[1].Text, "UpdateChecking", "", false);
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
                    LogBook.Instance.addLogLine("Downloaded & Updated " + videoList.Items[i].SubItems[1].Text, "UpdateChecking", "", false);
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
                    LogBook.Instance.addLogLine("Downloaded & Updated " + muxingList.Items[i].SubItems[1].Text, "UpdateChecking", "", false);
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
                    LogBook.Instance.addLogLine("Downloaded & Updated " + otherList.Items[i].SubItems[1].Text, "UpdateChecking", "", false);
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
                    LogBook.Instance.addLogLine("Downloaded & Updated " + pluginsList.Items[i].SubItems[1].Text, "UpdateChecking", "", false);
                }
            }
            tools.SavePackages();
            for (int i = coreList.Items.Count - 1; i >= 0; i--)
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
                        return;
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
                        LogBook.Instance.addLogLine("Downloaded & Updated " + coreList.Items[i].SubItems[1].Text, "UpdateChecking", "", false);
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
