using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MiniCoder.External;
using MiniCoder.GUI.External;
using MiniCoder.Encoding;
using System.Threading;
using System.Collections;
using MiniCoder.Encoding.Process_Management;
using MiniCoder.Core.Settings;
using System.Diagnostics;
using MiniCoder.Core.Languages;
namespace MiniCoder.GUI
{
    public partial class MainForm : Form
    {
        Thread encodeBatchTask;
        Tools tools = new Tools(false);
        ArrayList FileList = new ArrayList();
        SortedList<String, String> encodeSet = new SortedList<string, string>();
        ProcessWatcher processWatcher = new ProcessWatcher();
        Boolean vfr;
        SysLanguage language;
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
                    MainSettings main = new MainSettings();
                    main.loadSettings();
                    encodeOptions.loadSettings(main);

                }
                else
                {

                    encodeOptions.setLanguageDefault();
                }

                
                LogBook.addLogLine("System Info", "", "SysInfo", false);
                LogBook.addLogLine(MiniSystem.getOSName(), "SysInfo", "", false);
                LogBook.addLogLine(MiniSystem.getDotNetFramework(), "SysInfo", "", false);
                LogBook.addLogLine(MiniSystem.getProcessorInfo(), "SysInfo", "", false);
                LogBook.addLogLine(MiniSystem.getElevation(), "SysInfo", "", false);
                LogBook.addLogLine("Errors", "", "Errors", false);

                cbAfterEncode.SelectedIndex = 0;
                tools = new Tools(true);

                encodeOptions.setTools(tools);
                encodeOptions.setProcessWatcher(processWatcher);

                if (MiniOnline.checkInternet())
                {
                    Updater tempUpdater = new Updater(tools, true,language);
                    tempUpdater.Dispose();
                    MiniOnline.GetNews(newsList);
                }
                if (!Directory.Exists(Application.StartupPath + "\\Temp\\"))
                    Directory.CreateDirectory(Application.StartupPath + "\\Temp\\");
            }
            catch (Exception error)
            {
                LogBook.addLogLine("Error Starting up. (" + error.Source + ", " + error.Message + ", " + error.Data + ", " + error.ToString() + ")", "Errors", "", true);
               
            }
        }

        public SysLanguage getLanguage()
        {
            return language;
        }

        public void loadLanguage(int i)
        {
            language = new SysLanguage(i);
            this.Text = language.programTitle;
            this.logTab.Text = language.logTabTitle;
            this.inputTab.Text = language.inputTabTitle;
            this.settingsTab.Text = language.settingsTabTitle;
            this.optionsTab.Text = language.optionsTabTitle;
            this.newsTab.Text = language.newsTabTitle;
            inputList.Columns[0].Text = language.inputColumn1Title;
            inputList.Columns[1].Text = language.inputColumn2StatusTitle;
            startButton.Text = language.encodeStartButton;
            stopButton.Text = language.encodeStopButton;
            whenDone.Text = language.whenDone;
            infoLabel.Text = language.infoLabel;
            cbAfterEncode.Items.Clear();
            cbAfterEncode.Items.AddRange(language.whenDoneOptions);
            cbAfterEncode.SelectedIndex = 0;
            clearMenuItem.Text = language.menuClear;
            addMenu.Text = language.menuAdd;
            removeMenuItem.Text = language.menuRemove;
            copyToolStripMenuItem.Text = language.logMenuCopy;
            sendErrorReportToolStripMenuItem.Text = language.logMenuSend;
            encodeSettings.setLanguage(language);
            encodeOptions.setLanguage(language);
           
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
            LogBook.addLogLine("Drag & Drop", "", "DragDrop",false);
            foreach (string str in files)
            {
                ListViewItem inputListItem = new ListViewItem();
                ListViewItem.ListViewSubItem statusSub = new ListViewItem.ListViewSubItem();
                FileList.Add(str);
                string fName = Path.GetFileName(str);
                inputListItem.ToolTipText = "Check if file has a variable framerate";
                inputListItem.Text = fName;
                inputListItem.SubItems.Add(statusSub);
                statusSub.Text = language.inputColumn2StatusReady;
                inputList.Items.Add(inputListItem);
                LogBook.addLogLine("Drag & Drop: " + str, "DragDrop","", false);
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
                String[] fileListDetails = { fileInfo.Name, language.inputColumn2StatusReady, file };
                ListViewItem tempFile = new ListViewItem(fileListDetails);
                inputList.Items.Add(tempFile);
                FileList.Add(file);
            }
        }

        #endregion

        #region "Log"
      
        private delegate void SetNode(string message, string searchTag, string messageTag, bool error);
        public void addLogLine(string message, string searchTag, string messageTag, bool error)
        {
            try
            {
                if (this.logView.InvokeRequired)
                {
                    this.logView.Invoke(new SetNode(addLogLine), message, searchTag, messageTag, error);
                }
                else
                {
                    String log =DateTime.Now.ToString("t");



                    if (String.IsNullOrEmpty(searchTag))
                    {
                        TreeNode tempNode = new TreeNode(message);
                        if (!String.IsNullOrEmpty(messageTag))
                            tempNode.Tag = messageTag;
                       // tempNode.ImageIndex = 1;
                        tempNode.Text = log + ": " + message;
                        logView.Nodes.Add(tempNode);
                    }
                    else
                    {
                        TreeNode retrieved = LogBook.findNode(logView, searchTag);
                        if (retrieved != null)
                        {
                            if (!String.IsNullOrEmpty(messageTag) && !String.IsNullOrEmpty(searchTag))
                            {
                                if (messageTag != searchTag)
                                {
                                    TreeNode retrieved2 = LogBook.findNode(logView, messageTag);
                                    if (retrieved2 != null)
                                    {
                                        return;
                                    }
                                }
                              
                                //test
                            }
                            if (!retrieved.Text.Contains(message))
                            {
                                TreeNode tempNode = new TreeNode(message);
                                if (!String.IsNullOrEmpty(messageTag))
                                    tempNode.Tag = messageTag;
                                retrieved.Nodes.Add(tempNode);
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(messageTag) && !String.IsNullOrEmpty(searchTag))
                            {
                                TreeNode tempNode = new TreeNode(message);
                                if (!String.IsNullOrEmpty(messageTag))
                                    tempNode.Tag = messageTag;
                                // tempNode.ImageIndex = 1;
                                tempNode.Text = log + ": " + message;
                                logView.Nodes.Add(tempNode);
                            }
                        }
                    }
                }
            }
            catch
            {

            }

        }



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
                setFileStatus(language.inputColumn2StatusEncoding);

                getSettings();

                getVfrStatus();
                if (vfr)
                    encodeSet.Add("vfr", "");

                tempEncode = new Encode(FileList[0].ToString(), tools.getTools(), encodeSet, processWatcher);
                if (!tempEncode.fetchEncodeInfo())
                {
                    setFileStatus(language.inputColumn2StatusError);
                    // LogBook.addLogLine("infoLabel.Text, 2,"");
                    LogBook.sendmail(logView);
                    break;
                }
                if (tempEncode.getExtention() == "avs")
                {
                    if (tempEncode.startAvsEncode())
                    {
                        FileList.RemoveAt(0);
                        setFileStatus(language.inputColumn2StatusDone);
                        LogBook.setInfoLabel(language.encodingComplete);
                        curEncode++;
                    }
                    else
                    {
                        if (processWatcher.getProcess().getAbandonStatus())
                        {
                            setFileStatus(language.inputColumn2StatusAborted);
                        }
                        else
                        {
                            setFileStatus(language.inputColumn2StatusError);
                            // LogBook.addLogLine("infoLabel.Text, 2,"");
                            if (!Boolean.Parse(encodeSet["aftererror"]))
                            LogBook.sendmail(logView);
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

                        setFileStatus(language.inputColumn2StatusDone);
                        LogBook.setInfoLabel(language.encodingComplete);
                        curEncode++;
                    }
                    else
                    {
                        if (processWatcher.getProcess().getAbandonStatus())
                        {
                            setFileStatus(language.inputColumn2StatusAborted);
                        }
                        else
                        {
                            setFileStatus(language.inputColumn2StatusError);
                            // LogBook.addLogLine("infoLabel.Text, 2,"");
                            if (!Boolean.Parse(encodeSet["aftererror"]))
                                LogBook.sendmail(logView);
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
                        setFileStatus(language.inputColumn2StatusDone);
                        LogBook.setInfoLabel(language.encodingComplete);
                        curEncode++;
                    }
                    else
                    {
                        try
                        {
                            if (processWatcher.getProcess().getAbandonStatus())
                            {
                                setFileStatus(language.inputColumn2StatusAborted);
                            }
                            else
                            {
                                setFileStatus(language.inputColumn2StatusError);
                                if (!Boolean.Parse(encodeSet["aftererror"]))
                                      LogBook.sendmail(logView);
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
                if (eachItem.SubItems[1].Text != language.inputColumn2StatusDone)
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
                //LogBook.setInfoLabel("Aborted encoding");
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

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               Clipboard.SetText(logView.SelectedNode.Text, TextDataFormat.Text);
            }
            catch
            {

            }
        }

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
            LogBook.sendmail(logView);
        }

        private void allVfrCheck_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in inputList.Items)
                item.Checked = allVfrCheck.Checked;
        }
    }
}
