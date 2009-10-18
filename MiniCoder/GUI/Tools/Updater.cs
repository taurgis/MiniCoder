﻿using System;
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
       
        public Updater(Tools tools)
        {
            InitializeComponent();

            toolInfo = tools.getTools();

            foreach (string key in toolInfo.Keys)
            {
                Tool tempTool = toolInfo[key];
                string[] tempInfo = { "", key, tempTool.localVersion, tempTool.onlineVersion,""};
                ListViewItem tempListItem = new ListViewItem(tempInfo);

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
                    Tool tempPackage = (Tool)toolInfo[videoList.Items[i].SubItems[1].Text];
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
                    Tool tempPackage = (Tool)toolInfo[pluginsList.Items[i].SubItems[1].Text];
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
                    Tool tempPackage = (Tool)toolInfo[muxingList.Items[i].SubItems[1].Text];
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
                    Tool tempPackage = (Tool)toolInfo[otherList.Items[i].SubItems[1].Text];
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
