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
using System.IO;
using MiniTech.MiniCoder.External;
using MiniTech.MiniCoder.GUI.External;
using MiniTech.MiniCoder.Encoding;
using System.Threading;
using System.Collections;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.Core.Settings;
using System.Diagnostics;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Other.Logging;
namespace MiniTech.MiniCoder.GUI
{
    public partial class MainForm : Form
    {
        Thread encodeBatchTask;
        Tools tools = new Tools(false);
        ArrayList FileList = new ArrayList();
        SortedList<String, String> encodeSet = new SortedList<string, string>();
        ProcessWatcher processWatcher = new ProcessWatcher();
        Boolean vfr;
        private int curEncode = 0;
        public MainForm()
        {
            InitializeComponent();

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            try
            {
                encodeOptions.setMain(this);
                if (File.Exists(Application.StartupPath + "\\settings.xml"))
                {
                    MainSettings main = SettingsController.loadSettings();

                    encodeOptions.loadSettings(main);

                }
                else
                {

                    encodeOptions.setLanguageDefault();
                }

                loadSystemInfo();

                cbAfterEncode.SelectedIndex = 0;
                tools = new Tools(true);

                encodeOptions.setTools(tools);
                encodeOptions.setProcessWatcher(processWatcher);

                if (MiniOnline.checkInternet())
                {
                    Updater tempUpdater = new Updater(tools, true);
                    tempUpdater.Dispose();
                    MiniOnline.GetNews(newsList);
                }
                if (!Directory.Exists(Application.StartupPath + "\\Temp\\"))
                    Directory.CreateDirectory(Application.StartupPath + "\\Temp\\");
            }
            catch (Exception error)
            {
                LogBookController.Instance.addLogLine("Error Starting up. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", LogMessageCategories.Error);
            }
        }

        private void loadSystemInfo()
        {
            LogBookController logbook = LogBookController.Instance;
            logbook.addLogLine(MiniSystem.getOSName(), LogMessageCategories.Info);
            logbook.addLogLine(MiniSystem.getDotNetFramework(), LogMessageCategories.Info);
            logbook.addLogLine(MiniSystem.getProcessorInfo(), LogMessageCategories.Info);
            logbook.addLogLine(MiniSystem.getElevation(), LogMessageCategories.Info);
        }

        public void loadLanguage()
        {
            this.Text = LanguageController.Instance.getLanguageString("programTitle");
            this.logTab.Text = LanguageController.Instance.getLanguageString("logTabTitle");
            this.inputTab.Text = LanguageController.Instance.getLanguageString("inputTabTitle");
            this.settingsTab.Text = LanguageController.Instance.getLanguageString("settingsTabTitle");
            this.optionsTab.Text = LanguageController.Instance.getLanguageString("optionsTabTitle");
            this.newsTab.Text = LanguageController.Instance.getLanguageString("newsTabTitle");
            inputList.Columns[0].Text = LanguageController.Instance.getLanguageString("inputColumn1Title");
            inputList.Columns[1].Text = LanguageController.Instance.getLanguageString("inputColumn2StatusTitle");
            startButton.Text = LanguageController.Instance.getLanguageString("encodeStartButton");
            stopButton.Text = LanguageController.Instance.getLanguageString("encodeStopButton");
            whenDone.Text = LanguageController.Instance.getLanguageString("whenDone");
            infoLabel.Text = LanguageController.Instance.getLanguageString("infoLabel");
            cbAfterEncode.Items.Clear();
            cbAfterEncode.Items.AddRange(LanguageController.Instance.getLanguageString("whenDoneOptions").Split(';'));
            cbAfterEncode.SelectedIndex = 0;
            clearMenuItem.Text = LanguageController.Instance.getLanguageString("menuClear");
            addMenu.Text = LanguageController.Instance.getLanguageString("menuAdd");
            removeMenuItem.Text = LanguageController.Instance.getLanguageString("menuRemove");
            copyToolStripMenuItem.Text = LanguageController.Instance.getLanguageString("logMenuCopy");
            sendErrorReportToolStripMenuItem.Text = LanguageController.Instance.getLanguageString("logMenuSend");

        }

        void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            encodeOptions.saveMe();
        }

        #region "File Management"

        private void addFile_Click(object sender, EventArgs e)
        {
            selectFile();
        }

        private void addMenu_Click(object sender, EventArgs e)
        {
            selectFile();
        }
        private void inputList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        void inputList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            // LogBook.Instance.addLogLine("Drag & Drop", "", "DragDrop",false);
            foreach (string str in files)
            {
                ListViewItem inputListItem = new ListViewItem();
                ListViewItem.ListViewSubItem statusSub = new ListViewItem.ListViewSubItem();
                FileList.Add(str);
                string fName = Path.GetFileName(str);
                inputListItem.ToolTipText = "Check if file has a variable framerate";
                inputListItem.Text = fName;
                inputListItem.SubItems.Add(statusSub);
                statusSub.Text = LanguageController.Instance.getLanguageString("inputColumn2StatusReady");
                inputList.Items.Add(inputListItem);
                // LogBook.Instance.addLogLine("Drag & Drop: " + str, "DragDrop","", false);
            }
        }

        private void selectFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Media Files|*.avi;*.mkv;*.ogm;*.mp4;*_1.vob;*.wmv;*.avs;*.rm;*.rmvb;*.flv";
            openFile.Multiselect = true;
            openFile.ShowDialog();
            foreach (String file in openFile.FileNames)
            {
                FileInfo fileInfo = new FileInfo(file);
                String[] fileListDetails = { fileInfo.Name, LanguageController.Instance.getLanguageString("inputColumn2StatusReady"), file };
                ListViewItem tempFile = new ListViewItem(fileListDetails);
                inputList.Items.Add(tempFile);
                FileList.Add(file);
            }
        }

        #endregion

        #region "Log"

        private delegate void SetNode(string message, string searchTag, string messageTag, bool error);




        private delegate void SetLabel(string message);
        public void setInfoLabel(string message)
        {

            if (this.infoLabel.InvokeRequired)
            {
                // This is a worker thread so delegate the task.
                this.infoLabel.Invoke(new SetLabel(this.setInfoLabel), message);
            }
            else
            {
                // This is the UI thread so perform the task.
                infoLabel.Text = message;
                try
                {
                    notifyMiniCoder.Text = message;
                }
                catch
                {
                    notifyMiniCoder.Text = message.Substring(0, 45) + "...";
                }
            }
        }



        #endregion

        #region "Encoding"

        private void startButton_Click(object sender, EventArgs e)
        {
            if (encodeSettings.getSelectedIndex() == -1)
                encodeSettings.loadSettings();
            encodeBatchTask = new Thread(new ThreadStart(encodeBatch));
            //proc.abandon = false;
            encodeBatchTask.Start();
            startButton.Enabled = false;
            stopButton.Enabled = true;
        }
        Encode tempEncode;
        private void encodeBatch()
        {
            processWatcher.Activate();
            while (FileList.Count != 0)
            {
                string[] files = Directory.GetFiles(Application.StartupPath + "\\temp\\");
                try
                {
                    foreach (string file in files)
                        File.Delete(file);
                }
                catch
                {

                }
                setFileStatus(LanguageController.Instance.getLanguageString("inputColumn2StatusEncoding"));

                getSettings();

                getVfrStatus();
                if (vfr)
                    encodeSet.Add("vfr", "");

                tempEncode = new Encode(FileList[0].ToString(), tools.getTools(), encodeSet, processWatcher);
                if (!tempEncode.fetchEncodeInfo())
                {
                    setFileStatus(LanguageController.Instance.getLanguageString("inputColumn2StatusError"));
                    //// LogBook.Instance.addLogLine("infoLabel.Text, 2,"");
                    // LogBook.Instance.sendmail(logView);
                    break;
                }
                if (tempEncode.getExtention() == "avs")
                {
                    if (tempEncode.startAvsEncode())
                    {
                        FileList.RemoveAt(0);
                        setFileStatus(LanguageController.Instance.getLanguageString("inputColumn2StatusDone"));
                        LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("encodingComplete"));
                        curEncode++;
                    }
                    else
                    {
                        if (processWatcher.getProcess().getAbandonStatus())
                        {
                            setFileStatus(LanguageController.Instance.getLanguageString("inputColumn2StatusAborted"));
                        }
                        else
                        {
                            setFileStatus(LanguageController.Instance.getLanguageString("inputColumn2StatusError"));
                            //// LogBook.Instance.addLogLine("infoLabel.Text, 2,"");
                            if (!Boolean.Parse(encodeSet["aftererror"])) { }
                            // LogBook.Instance.sendmail(logView);
                        }
                        if (!Boolean.Parse(encodeSet["aftererror"]))
                            break;
                        else
                        {
                            curEncode++;
                            FileList.RemoveAt(0);
                        }
                    }
                }
                else if (encodeSet["videocodec"] == "2")
                {
                    if (tempEncode.startTheoraEncode())
                    {
                        FileList.RemoveAt(0);

                        setFileStatus(LanguageController.Instance.getLanguageString("inputColumn2StatusDone"));
                        LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("encodingComplete"));
                        curEncode++;
                    }
                    else
                    {
                        if (processWatcher.getProcess().getAbandonStatus())
                        {
                            setFileStatus(LanguageController.Instance.getLanguageString("inputColumn2StatusAborted"));
                        }
                        else
                        {
                            setFileStatus(LanguageController.Instance.getLanguageString("inputColumn2StatusError"));
                            //// LogBook.Instance.addLogLine("infoLabel.Text, 2,"");
                            if (!Boolean.Parse(encodeSet["aftererror"])) { }
                            // LogBook.Instance.sendmail(logView);
                        }
                        if (!Boolean.Parse(encodeSet["aftererror"]))
                            break;
                        else
                        {
                            curEncode++;
                            FileList.RemoveAt(0);
                        }
                    }

                }
                else
                {

                    if (tempEncode.startDefaultEncode())
                    {
                        FileList.RemoveAt(0);
                        setFileStatus(LanguageController.Instance.getLanguageString("inputColumn2StatusDone"));
                        LogBookController.Instance.setInfoLabel(LanguageController.Instance.getLanguageString("encodingComplete"));
                        curEncode++;
                    }
                    else
                    {
                        try
                        {
                            if (processWatcher.getProcess().getAbandonStatus())
                            {
                                setFileStatus(LanguageController.Instance.getLanguageString("inputColumn2StatusAborted"));
                            }
                            else
                            {
                                setFileStatus(LanguageController.Instance.getLanguageString("inputColumn2StatusError"));
                                if (!Boolean.Parse(encodeSet["aftererror"])) { }
                                // LogBook.Instance.sendmail(logView);
                            }
                            if (!Boolean.Parse(encodeSet["aftererror"]))
                                break;
                            else
                            {
                                curEncode++;
                                FileList.RemoveAt(0);
                            }
                        }
                        catch
                        {

                            break;
                        }
                    }
                }


            }
            enableEncoding();
        }
        private void afterEncode()
        {
            foreach (ListViewItem eachItem in inputList.Items)
            {
                if (eachItem.SubItems[1].Text != LanguageController.Instance.getLanguageString("inputColumn2StatusDone"))
                    return;

            }


            switch (cbAfterEncode.SelectedIndex)
            {
                case 1:
                    Application.SetSuspendState(PowerState.Hibernate, true, true);
                    break;
                case 2:
                    Application.SetSuspendState(PowerState.Suspend, true, true);
                    break;
                case 3:
                    System.Diagnostics.Process.Start("shutdown -f -s -t 0");
                    break;

                default:
                    break;

            }

        }
        private delegate void encodingEnabled();
        public void enableEncoding()
        {
            if (this.encodeSettings.InvokeRequired)
            {
                this.startButton.Invoke(new encodingEnabled(this.enableEncoding));
            }
            else
            {
                startButton.Enabled = true;
                stopButton.Enabled = false;
                afterEncode();
                //LogBook.Instance.setInfoLabel("Aborted encoding");
            }

        }

        private delegate void settingsRetreiver();
        private void getSettings()
        {
            if (this.encodeSettings.InvokeRequired)
            {
                // This is a worker thread so delegate the task.
                this.encodeSettings.Invoke(new settingsRetreiver(this.getSettings));
            }
            else
            {
                encodeSet = encodeSettings.getSettings();
                foreach (string key in encodeOptions.getSettings().Keys)
                    encodeSet.Add(key, encodeOptions.getSettings()[key]);
            }
        }

        public void setProcessPriority(int i)
        {
            try
            {
                processWatcher.setPriority(i);
            }
            catch
            {

            }
        }

        #endregion



        private void stopButton_Click(object sender, EventArgs e)
        {
            try
            {

                tempEncode.getProcessWatcher().abandon();
                tempEncode.getProcessWatcher().getProcess().abandonProcess();
                //LogBook.sendmail(logView);
            }
            catch
            {
            }
        }

        private delegate void fileListUpdater(string status);
        public void setFileStatus(string status)
        {

            if (this.infoLabel.InvokeRequired)
            {
                // This is a worker thread so delegate the task.
                this.infoLabel.Invoke(new fileListUpdater(this.setFileStatus), status);
            }
            else
            {
                // This is the UI thread so perform the task.
                inputList.Items[curEncode].SubItems[1].Text = status;
            }
        }

        private delegate Boolean isFfileVfr();
        public Boolean getVfrStatus()
        {

            if (this.inputList.InvokeRequired)
            {

                // This is a worker thread so delegate the task.
                this.inputList.Invoke(new isFfileVfr(this.getVfrStatus));
                ;
            }
            else
            {
                if (inputList.Items[curEncode].Checked)
                    vfr = true;
                else
                    vfr = false;
            }
            return false;


        }

        private void notifyMiniCoder_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }
        void MainForm_Resize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyMiniCoder.Visible = true;

                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyMiniCoder.Visible = false;
            }
        }

        private void removeMenuItem_Click(object sender, EventArgs e)
        {
            removeFile();

        }

        private void removeFile()
        {
            foreach (ListViewItem eachItem in inputList.SelectedItems)
            {
                if (eachItem.Index < curEncode)
                    curEncode--;
                for (int i = 0; i < FileList.Count; i++)
                {
                    string fName = Path.GetFileName(FileList[i].ToString());
                    if (fName == eachItem.Text)
                        FileList.RemoveAt(i);
                }
                inputList.Items.Remove(eachItem);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            removeFile();
        }

        private void clearMenuItem_Click(object sender, EventArgs e)
        {
            inputList.Items.Clear();
            FileList.Clear();
            curEncode = 0;
        }

        private void newsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListView tempList = (ListView)sender;
                Process.Start(tempList.SelectedItems[0].SubItems[2].Text);
            }
            catch
            {

            }
        }



        private void sendErrorReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // LogBook.Instance.sendmail(logView);
        }

        public void updateText(LogMessage message)
        {
            logControl.addLogMessage(message);
        }


        private void allVfrCheck_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in inputList.Items)
                item.Checked = allVfrCheck.Checked;
        }
    }
}
