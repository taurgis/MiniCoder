using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MiniCoder.General;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using x264_GUI_CS.Task_Libraries;
using System.Reflection;


namespace x264_GUI_CS
{
    public partial class mainGUI : Form
    {
        ApplicationSettings appSettings = new ApplicationSettings(Application.StartupPath);
        General.FileInformation details = new General.FileInformation();
        General.EncodingOptions encodingOpts = new General.EncodingOptions();
        General.EncodingOptions preview = new x264_GUI_CS.General.EncodingOptions();
        General.ProcessSettings proc = new General.ProcessSettings();
        ArrayList fileList = new ArrayList();
        Thread encodeBatchTask;
        int crfValue = 0;
        LogBook log;
        Hashtable customSettings = new Hashtable();
                
        [DllImport("user32.dll")]
        internal static extern short GetKeyState(int keyCode);
        [DllImport("user32.dll")]
        internal static extern int ExitWindowsEx(int uFlags, int dwReason);

       
        bool encoding = false;
        bool encOptsErr;

        private int hardSub = 0;
        public string customFiltOpts;
        public string currentProc;
                         
        public mainGUI()
        {
            try
            {
                InitializeComponent();
                videoCombo.SelectedIndex = 0;
                audioCombo.SelectedIndex = 0;
                containerCombo.SelectedIndex = 0;
                vidQualCombo.SelectedIndex = 1;
                resizeCombo.SelectedIndex = 0;
                fieldCombo.SelectedIndex = 0;
                noiseCombo.SelectedIndex = 0;
                sharpCombo.SelectedIndex = 0;
                log = new LogBook(this);
                log.addLine("Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
                if (!Directory.Exists(appSettings.tempDIR))
                    Directory.CreateDirectory(appSettings.tempDIR);

                if (bitRateRadio.Checked)
                {
                    videoBR.Enabled = true;
                    fileSize.Enabled = false;
                }
                if (fileSizeRadio.Checked)
                {
                    videoBR.Enabled = false;
                    fileSize.Enabled = true;
                }
            }
            catch(Exception er)
            {
                log.addLine("Error Starting up");
                log.addLine(er.Message);
                log.sendmail();
            }
        }

        public void addCustomSettings(String fileName, General.EncodingOptions encOpts)
        {
            if(customSettings.Contains(fileName))
            {
                customSettings.Remove(fileName);
            }
            customSettings.Add(fileName, encOpts);
            log.addLine("Added custom settings for " + fileName);
            log.addLine("There are now " + customSettings.Count + " custom settings stored!");
        }


        private void addMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openInput.ShowDialog();

            if (result == DialogResult.OK)
            {
                foreach (string str in openInput.FileNames)
                {
                    ListViewItem inputListItem = new ListViewItem();
                    ListViewItem.ListViewSubItem statusSub = new ListViewItem.ListViewSubItem();
                    fileList.Add(str);
                    string fName = Path.GetFileName(str);
                    inputListItem.Text = fName;
                    inputListItem.ToolTipText = "Check if file has a variable framerate";
                    inputListItem.SubItems.Add(statusSub);
                    statusSub.Text = "Ready";
                    inputList.Items.Add(inputListItem);
                }
            }
        }

        private void removeMenuItem_Click(object sender, EventArgs e)
        {
            
            foreach (ListViewItem eachItem in inputList.SelectedItems)
            {
                if (eachItem.Index < fileindex)
                    fileindex--;
                for (int i = 0; i < fileList.Count; i++)
                {
                    string fName = Path.GetFileName(fileList[i].ToString());
                    if (fName == eachItem.Text)
                        fileList.RemoveAt(i);
                }
                inputList.Items.Remove(eachItem);
           
            }

          
        }

        private void clearMenuItem_Click(object sender, EventArgs e)
        {
            inputList.Items.Clear();
            fileList.Clear();
            fileindex = 0;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!encoding)
            {
                CheckForIllegalCrossThreadCalls = false;

                string[] files = Directory.GetFiles(appSettings.tempDIR);
                try
                {
                    foreach (string file in files)
                        File.Delete(file);
                }
                catch
                {

                }
                encodeBatchTask = new Thread(new ThreadStart(encodeBatch));
                proc.abandon = false;
                encodeBatchTask.Start();
               
            }
            else
            {
                MessageBox.Show("Please wait for current process to complete");
            }
        }
        int fileindex = 0;

        public void setEncoding(bool encoding)
        {
            this.encoding = encoding;
        }

        public bool isFileVFR()
        {
            if (inputList.Items[fileindex].Checked)
                return true;

            return false;
        }

        public void updateStatus(string status)
        {
            inputList.Items[fileindex].SubItems[1].Text = status;
        }

        public int getCrfValue()
        {
            return crfValue;
        }
        private void encodeBatch()
        {

            DateTime startDate = new DateTime();
            

            while(fileList.Count!=0)
            {
                startDate = DateTime.Now;
                MiniCoder.Task_Libraries.Worker worker = new MiniCoder.Task_Libraries.Worker(proc, log, getEncodeOpts(), this, appSettings);
                Boolean breakWhile = false;
                details = mediainfo(0);
                if(outPutLocation.Text != "")
                details.outDIR = outPutLocation.Text + "\\";
                if (customSettings.Contains(details.name))
                {
                    log.addLine("Found custom settings for " + details.name);
                    encodingOpts = (General.EncodingOptions)customSettings[details.name];
                    General.EncodingOptions tempOps = getEncodeOpts();

                    encodingOpts.customFilter = tempOps.customFilter;

                }
                else
                {
                    log.addLine("Found no custom settings for this file. Using general settings.");
                    encodingOpts = getEncodeOpts();
                }

                encodingOpts.advert = titleAdvert.Checked;

                if (encOptsErr)
                {
                    MessageBox.Show("Incorrect Encoding Options");
                    return;
                }

                string result = worker.encodeFile(details);

                switch (result)
                {
                    case "Remove":
                        fileindex++;
                        fileList.RemoveAt(0);
                        break;

                    case "Aborted":
                        breakWhile = true;
                           break;
                    case "Completed":
                           fileList.RemoveAt(0);
                           inputList.Items[fileindex].SubItems[1].Text = "Done";
                        fileindex++;
                        log.addLine("It took " + (DateTime.Now - startDate).Hours.ToString() + " hours and " + (DateTime.Now - startDate).Minutes.ToString() + " minutes to encode this file.");
                       afterEncode();
                       break;

                }

                if (breakWhile)
                    break;
            }
            encoding = false;
        }

        private General.FileInformation mediainfo(int i)
        {
            infoLabel.Text = "Gathering Media Info";

            IfMediaDetails temp;
                if (IntPtr.Size == 8)
                    temp = new MediaDetails64();
                else
                    temp  = new MediaDetails32();

            General.FileInformation tempDetail = new General.FileInformation();

            tempDetail.fileName = temp.fileName(fileList[i].ToString());
            tempDetail.fileSize = temp.fileSize(fileList[i].ToString());
            tempDetail.format = temp.fileFormat(fileList[i].ToString());
            tempDetail.name = temp.name(fileList[i].ToString());
            tempDetail.ext=temp.fileExt(fileList[i].ToString());
            tempDetail.outDIR = Path.GetDirectoryName(tempDetail.fileName) + "\\";
            tempDetail.crfValue = crfValue;
            tempDetail.audioCount = temp.audioCount(fileList[i].ToString());
            tempDetail.aud_Languages = temp.audLanguage(fileList[i].ToString());
            if(tempDetail.ext!=".avi")
                tempDetail.aud_id = temp.audID(fileList[i].ToString());
            tempDetail.aud_codec = temp.audCodec(fileList[i].ToString());
            tempDetail.audLength = (int)(temp.audLength(fileList[i].ToString()) / 1000);
            tempDetail.audTitles = temp.audTitle(fileList[i].ToString());
            tempDetail.completeinfo = temp.completeInfo(fileList[i].ToString());
           if(tempDetail.ext.ToUpper() == ".VOB")
            tempDetail.audBitrate = temp.audBitrate(fileList[i].ToString());
            
            tempDetail.width = temp.width(fileList[i].ToString());
            tempDetail.height = temp.height(fileList[i].ToString());
            tempDetail.fps = temp.fps(fileList[i].ToString());
            tempDetail.vid_codec = temp.vidCodec(fileList[i].ToString());
            tempDetail.framecount = temp.frameCount(fileList[i].ToString());
       //     tempDetail.frameType = temp.frameRateType(fileList[i].ToString());
            tempDetail.subCount=temp.subCount(fileList[i].ToString());
            if (tempDetail.subCount != 0)
            {
                tempDetail.sub_Titles = temp.subCaption(fileList[i].ToString());
                tempDetail.sub_id = temp.subID(fileList[i].ToString());
                tempDetail.sub_codec = temp.subCodec(fileList[i].ToString());
                tempDetail.sub_lang = temp.subLang(fileList[i].ToString());
            }
            tempDetail.chapters = temp.chapters(fileList[i].ToString());
            tempDetail.vfrCode = null;
            tempDetail.vfrName = null;

            infoLabel.Text = "";
            return tempDetail;                                     
        }
       

        //private void stderrProcess()
        //{
        //    while ((testText.Text = stderr.ReadLine()) != null)
        //    {
        //        Thread.Sleep(0);
        //    }
        //}

        //private void stdoutProcess()
        //{
        //    while ((testText.Text = stdout.ReadLine()) != null)
        //    {
        //        Thread.Sleep(0);
        //    }
        //}
      
       
        private void stopButton_Click(object sender, EventArgs e)
        {
            proc.abandon = true;
        }

        private void audioBR_KeyDown(object sender, KeyEventArgs e)
        {
            if (((int)e.KeyCode < 48 || (int)e.KeyCode > 57) && (int)e.KeyCode != 8 && (int)e.KeyCode != 46 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39)
            {
                bool Numlock = GetKeyState((int)Keys.NumLock) != 0;

                if (Numlock)
                {
                    if ((int)e.KeyCode < 96 || (int)e.KeyCode > 105)
                        e.SuppressKeyPress = true;
                }
            }
        }

        private void videoBR_KeyDown(object sender, KeyEventArgs e)
        {
            if (((int)e.KeyCode < 48 || (int)e.KeyCode > 57) && (int)e.KeyCode != 8 && (int)e.KeyCode != 46 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39)
            {
                bool Numlock = GetKeyState((int)Keys.NumLock) != 0;

                if (Numlock)
                {
                    if ((int)e.KeyCode < 96 || (int)e.KeyCode > 105)
                        e.SuppressKeyPress = true;
                }
            }
        }

        private void openSubBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openSub.ShowDialog();

            if (result == DialogResult.OK)
            {
                subText.Text = openSub.FileName;
            }
            else
            {
                subText.Text = "Select Subtitle file to use";
            }
        }


        private void heightText_KeyDown(object sender, KeyEventArgs e)
        {
            if (((int)e.KeyCode < 48 || (int)e.KeyCode > 57) && (int)e.KeyCode != 8 && (int)e.KeyCode != 46 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39)
            {
                bool Numlock = GetKeyState((int)Keys.NumLock) != 0;

                if (Numlock)
                {
                    if ((int)e.KeyCode < 96 || (int)e.KeyCode > 105)
                        e.SuppressKeyPress = true;
                }
            }
        }

        private void widthText_KeyDown(object sender, KeyEventArgs e)
        {
            if (((int)e.KeyCode < 48 || (int)e.KeyCode > 57) && (int)e.KeyCode != 8 && (int)e.KeyCode != 46 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39)
            {
                bool Numlock = GetKeyState((int)Keys.NumLock) != 0;

                if (Numlock)
                {
                    if ((int)e.KeyCode < 96 || (int)e.KeyCode > 105)
                        e.SuppressKeyPress = true;
                }
            }
        }

        private void resizeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resizeCombo.SelectedIndex != 0)
            {
                widthHeight.Enabled = true;
            }
            else
            {
                widthHeight.Enabled = false;
            }
        }

        private void customButton_Click(object sender, EventArgs e)
        {
            CustomFilter customFilt = new CustomFilter(appSettings);
            customFilt.encOpts = getEncodeOpts();
            customFilt.customFiltOpts = customFiltOpts;
            customFilt.init();
            
            if (encOptsErr)
            {
                MessageBox.Show("Incorrect Encoding Options");
                return;
            }
            DialogResult result = customFilt.ShowDialog();
            customFiltOpts = customFilt.customFiltOpts;
        }
        
        private void btnApps_Click(object sender, EventArgs e)
        {
            MiniCoder.Updater apps = new MiniCoder.Updater(appSettings);
            apps.ShowDialog();
            appSettings = new ApplicationSettings(Application.StartupPath);
        }

     
        public General.EncodingOptions getEncodeOpts()
        {
            General.EncodingOptions encOpts = new General.EncodingOptions();

            encOptsErr = false;

            try
            {
                if (bitRateRadio.Checked)
                {
                    encOpts.vidBR = int.Parse(videoBR.Text);
                    encOpts.type = "bitrate";
                    encOpts.sizeOpt = 0;
                }

                if (fileSizeRadio.Checked)
                {
                    encOpts.fileSize = int.Parse(fileSize.Text);
                    encOpts.type = "filesize";
                    encOpts.sizeOpt = 1;
                }

                encOpts.vidCodec = videoCombo.SelectedIndex;
                encOpts.vidQual = vidQualCombo.SelectedIndex;
                encOpts.hardSub = hardSub;
                encOpts.audBR = int.Parse(audioBR.Text);
                encOpts.audCodec = audioCombo.SelectedIndex;

                encOpts.containerFormat = containerCombo.SelectedIndex;

                encOpts.filtField = fieldCombo.SelectedIndex;
                encOpts.filtResize = resizeCombo.SelectedIndex;

                if (encOpts.filtResize != 0)
                {
                    string[] splitWidthHeight = widthHeight.Text.Split(Convert.ToChar(":"));
                    encOpts.resizeHeight = int.Parse(splitWidthHeight[1]);
                    encOpts.resizeWidth = int.Parse(splitWidthHeight[0]);
                }

                encOpts.filtNoise = noiseCombo.SelectedIndex;
                encOpts.filtSharp = sharpCombo.SelectedIndex;
                encOpts.subtitle = subText.Text;
                
                encOpts.customFilter = customFiltOpts;

                return encOpts;
            }
            catch (FormatException)
            {
                encOptsErr = true;
                return encOpts;
            }
        }

        private void updateRequired()
        {
            try
            {
                MiniCoder.Updater updater = new MiniCoder.Updater(appSettings, log);
                if (updater.needUpdate())
                {
                    if (MessageBox.Show("Updates found. Do you want to install them now?", "Updates", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        updater = new MiniCoder.Updater(appSettings);
                        updater.ShowDialog();
                        

                    }
                    else
                        updater.Close();

                    
                }
            }
            catch 
            {
                log.addLine("No internet found. Please check your connection");
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
        private void mainGUI_Load(object sender, EventArgs e)
        {
            try
            {
                
                processPriority.SelectedIndex = 0;
             
                updateRequired();
                if (!Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\x264Encoder\\Templates\\"))
                {
                    log.addLine("Template folder not found, creating!");
                    Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\x264Encoder\\Templates\\");
                }
                else
                    log.addLine("Template folder found!");

                    DirectoryInfo Dir = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\x264Encoder\\Templates\\");
                    FileInfo[] FileList = Dir.GetFiles("*.tpl", SearchOption.AllDirectories);
                    foreach (FileInfo FI in FileList)
                    {
                        cbTemplates.Items.Add(FI.Name.Replace(".tpl", ""));
                    }

                
                if (File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\x264Encoder\\Templates\\default.tpl"))
                {
                    for (int i = 0; i < cbTemplates.Items.Count; i++)
                    {
                        if (cbTemplates.Items[i].ToString() == "default")
                            cbTemplates.SelectedIndex = i;
                    }
                }

            }
            catch (Exception exc)
            {
                log.addLine("Error during startup");
                log.addLine(exc.Message.ToString());
                log.sendmail();
            }

        }

        private void cbTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTemplates.SelectedItem.ToString() != "")
            {
                encodingOpts.load(cbTemplates.SelectedItem.ToString());
                encodingOpts.templateName = cbTemplates.SelectedItem.ToString();
                if (encodingOpts.sizeOpt == 0)
                {
                    bitRateRadio.Checked = true;
                    fileSizeRadio.Checked = false;
                    videoBR.Enabled = true;
                    fileSize.Enabled = false;
                }
                else
                {
                    bitRateRadio.Checked = false;
                    fileSizeRadio.Checked = true;
                    videoBR.Enabled = false;
                    fileSize.Enabled = true;
                }
                videoBR.Text = encodingOpts.vidBR.ToString();
                fileSize.Text = encodingOpts.fileSize.ToString();
                videoCombo.SelectedIndex = encodingOpts.vidCodec;
                vidQualCombo.SelectedIndex = encodingOpts.vidQual;

                audioBR.Text = encodingOpts.audBR.ToString(); ;
                audioCombo.SelectedIndex = encodingOpts.audCodec;

                containerCombo.SelectedIndex = encodingOpts.containerFormat;

                fieldCombo.SelectedIndex = encodingOpts.filtField;
                resizeCombo.SelectedIndex = encodingOpts.filtResize;

                if (encodingOpts.filtResize != 0)
                {
                    widthHeight.Text = encodingOpts.resizeWidth + ":" + encodingOpts.resizeHeight; 
           
                }

                noiseCombo.SelectedIndex = encodingOpts.filtNoise;
                sharpCombo.SelectedIndex = encodingOpts.filtSharp;
                subText.Text=  encodingOpts.subtitle ;

               customFiltOpts = encodingOpts.customFilter;
            }
        }

        private void saveOptButton_Click(object sender, EventArgs e)
        {
            int tempIndex = cbTemplates.SelectedIndex;
            encodingOpts = getEncodeOpts();
            encodingOpts.templateName = InputBox.Show("Enter template name", "Template Name", cbTemplates.Items[cbTemplates.SelectedIndex].ToString());
            encodingOpts.save();
            cbTemplates.Items.Clear();
            DirectoryInfo Dir = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\x264Encoder\\Templates\\");
            FileInfo[] FileList = Dir.GetFiles("*.tpl", SearchOption.AllDirectories);
            foreach (FileInfo FI in FileList)
            {
                cbTemplates.Items.Add(FI.Name.Replace(".tpl", ""));
            }
            cbTemplates.SelectedIndex = tempIndex;
        }

        private void mainGUI_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                nfIcon.Visible = true;
             
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                nfIcon.Visible = false;
            }
        }

        private void nfIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.sendmail(details);
        }

        public void setMessage(string message)
        {
            infoLabel.Text = message;
            if (message != null)
            {
                if (message.Length < 64)
                    nfIcon.Text = message;
                else
                    nfIcon.Text = "";
            }
        }

        private void fileSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (((int)e.KeyCode < 48 || (int)e.KeyCode > 57) && (int)e.KeyCode != 8 && (int)e.KeyCode != 46 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39)
            {
                bool Numlock = GetKeyState((int)Keys.NumLock) != 0;

                if (Numlock)
                {
                    if ((int)e.KeyCode < 96 || (int)e.KeyCode > 105)
                        e.SuppressKeyPress = true;
                }
            }

        }

        private void bitRateRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (bitRateRadio.Checked)
            {
                videoBR.Enabled = true;
                fileSize.Enabled = false;
            }
            if (fileSizeRadio.Checked)
            {
                videoBR.Enabled = false;
                fileSize.Enabled = true;
            }            
        }

        private void videoCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoCombo.SelectedIndex == 0)
            {
                vidQualCombo.Items.Clear();

                vidQualCombo.Items.Add("Medium");
                vidQualCombo.Items.Add("High");
                vidQualCombo.Items.Add("Very High");
                vidQualCombo.Items.Add("Very High (+50mb Anime)");
                vidQualCombo.Items.Add("Very High (-50mb Anime)");
                vidQualCombo.Items.Add("Very High (TV-Shows/Movies)");
                vidQualCombo.Items.Add("CRF (Anime)");
                vidQualCombo.Items.Add("Ipod");
                vidQualCombo.Items.Add("PSP");
                vidQualCombo.Items.Add("PS3");
            }
            else
            {
                vidQualCombo.Items.Remove("Very High (+50mb Anime)");
                vidQualCombo.Items.Remove("Very High (-50mb Anime)");
                vidQualCombo.Items.Remove("Very High (TV-Shows/Movies)");
                vidQualCombo.Items.Remove("CRF (Anime)");
                vidQualCombo.Items.Remove("Ipod");
                vidQualCombo.Items.Remove("PSP");
                vidQualCombo.Items.Remove("PS3");

            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = openInput.ShowDialog();

            if (result == DialogResult.OK)
            {
                foreach (string str in openInput.FileNames)
                {
                    ListViewItem inputListItem = new ListViewItem();
                    ListViewItem.ListViewSubItem statusSub = new ListViewItem.ListViewSubItem();
                    fileList.Add(str);
                    string fName = Path.GetFileName(str);
                    inputListItem.ToolTipText = "Check if file has a variable framerate";
                    inputListItem.Text = fName;
                    inputListItem.SubItems.Add(statusSub);
                    statusSub.Text = "Ready";
                    inputList.Items.Add(inputListItem);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in inputList.SelectedItems)
            {
                if (eachItem.Index < fileindex)
                    fileindex--;
                for (int i = 0; i < fileList.Count; i++)
                {
                    string fName = Path.GetFileName(fileList[i].ToString());
                    if (fName == eachItem.Text)
                        fileList.RemoveAt(i);
                }
                inputList.Items.Remove(eachItem);

            }

        }

        private void afterEncode()
        {
            foreach (ListViewItem eachItem in inputList.Items)
            {
                if (eachItem.SubItems[1].Text != "Done")
                    return;

            }


            switch (cbAfterEncode.Text)
            {
                case "Hibernate":
                    Application.SetSuspendState(PowerState.Hibernate, true, true);
                    break;
                case "Standby":
                    Application.SetSuspendState(PowerState.Suspend, true, true);
                    break;
                case "Shutdown":
                    System.Diagnostics.Process.Start("shutdown -f -s -t 0");
                    break;

                default:
                    break;

            }

        }

        private void copyLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
         Clipboard.SetText(log.getLog());
        }

        private void vidQualCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vidQualCombo.SelectedItem.ToString() == "CRF (Anime)")
            {
             if(crfValue == 0)
                crfValue = Convert.ToInt32(InputBox.Show("Please enter CRF value!", "CRF Value", "20"));
             else
                 crfValue = Convert.ToInt32(InputBox.Show("Please enter CRF value!", "CRF Value", crfValue.ToString()));
            }
        }

      

        private void llReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.minitheatre.org/index.php?option=com_kunena&Itemid=70&func=view&catid=109&id=17098");
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

            foreach (string str in files)
            {
                ListViewItem inputListItem = new ListViewItem();
                ListViewItem.ListViewSubItem statusSub = new ListViewItem.ListViewSubItem();
                fileList.Add(str);
                string fName = Path.GetFileName(str);
                inputListItem.ToolTipText = "Check if file has a variable framerate";
                inputListItem.Text = fName;
                inputListItem.SubItems.Add(statusSub);
                statusSub.Text = "Ready";
                inputList.Items.Add(inputListItem);
                log.addLine("Drag & Drop: " + str);
            }
           
        }

        public void addFIles(string[] files)
        {
           
                ListViewItem inputListItem = new ListViewItem();
                ListViewItem.ListViewSubItem statusSub = new ListViewItem.ListViewSubItem();
                fileList.Add(files[0]);
                string fName = Path.GetFileName(files[0]);
                inputListItem.ToolTipText = "Check if file has a variable framerate";
                inputListItem.Text = fName;
                inputListItem.SubItems.Add(statusSub);
                statusSub.Text = "Ready";
                inputList.Items.Add(inputListItem);
                log.addLine("Drag & Drop: " + files[0]);
            
        }
        const string KeyName = "MiniCoder";

        
        const string MenuText = "Encode With MiniCoder";
        string menuCommand = string.Format(
                    "\"{0}\" \"%L\"", Application.ExecutablePath);
              private void btnDeleteTemplate_Click(object sender, EventArgs e)
        {
            int tempIndex = cbTemplates.SelectedIndex;
            encodingOpts = getEncodeOpts();
            encodingOpts.templateName = cbTemplates.Items[cbTemplates.SelectedIndex].ToString();
            encodingOpts.delete();
            cbTemplates.Items.Clear();
            DirectoryInfo Dir = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\x264Encoder\\Templates\\");
            FileInfo[] FileList = Dir.GetFiles("*.tpl", SearchOption.AllDirectories);
            foreach (FileInfo FI in FileList)
            {
                cbTemplates.Items.Add(FI.Name.Replace(".tpl", ""));
            }
            cbTemplates.SelectedIndex = tempIndex;
        }

        private void customSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if nothing is selected prevent error
            try
            {
               
                int completedFiles = 0;
                for (int i = 0; i < inputList.Items.Count; i++)
                {
                    if (inputList.Items[i].SubItems[1].Text == "Done")
                    {
                        completedFiles++;
                    }
                }
                if (!(customSettings.Contains(inputList.SelectedItems[0].Text.Substring(0, inputList.SelectedItems[0].Text.Length-4))))
                {
                    GUI.frmFileInformation frmFileInfo = new x264_GUI_CS.GUI.frmFileInformation(mediainfo(inputList.SelectedItems[0].Index - completedFiles), this, getEncodeOpts());
                    frmFileInfo.Show();
                }
                else
                {
                    GUI.frmFileInformation frmFileInfo = new x264_GUI_CS.GUI.frmFileInformation(mediainfo(inputList.SelectedItems[0].Index - completedFiles), this, (General.EncodingOptions)customSettings[inputList.SelectedItems[0].Text.Substring(0, inputList.SelectedItems[0].Text.Length - 4)]);
                    frmFileInfo.Show();
                }
            }
            catch
            {
            }
        }

         
        private void inputMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (inputList.SelectedItems.Count != 0)
                {
                    if (inputList.SelectedItems[0].SubItems[1].Text != "Ready")
                    {
                        tsCustomSettings.Enabled = false;
                    }
                    else
                    {
                        tsCustomSettings.Enabled = true;
                    }
                }
                else
                {
                    tsCustomSettings.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void containerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (containerCombo.SelectedIndex)
            {
                case 1:
                    try
                    {
                        hardSub = Convert.ToInt32(InputBox.Show("Please select wich sub you wish to add to the MP4 file. 1,2,3... 1 = First sub file, 2 = Second sub file,... 0 means that you will add subfiles softsubbed.", "Hardsub", "0"));
                    }
                    catch
                    {
                        MessageBox.Show("Please enter a number");
                        containerCombo_SelectedIndexChanged(sender, e);
                       
                    }
                    break;
            }
        }

        private void processPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            proc.processPriority = processPriority.SelectedIndex;
        }

        private void outputSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            if(folderBrowser.SelectedPath != "")
            outPutLocation.Text = folderBrowser.SelectedPath;
        }

        private void clearOutput_Click(object sender, EventArgs e)
        {
            outPutLocation.Text = "";
        }

       

       

  

        


     

  
    }
}
