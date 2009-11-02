using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MiniCoder.GUI.External;
using MiniCoder.External;
using MiniCoder.Encoding.Process_Management;
using MiniCoder.GUI;
using MiniCoder.Core.Settings;

namespace MiniCOder.GUI.Controls
{
    public partial class EncodeOptions : UserControl
    {
        
        Tools tools;
        ProcessWatcher processWatcher = new ProcessWatcher();
        public EncodeOptions()
        {
            InitializeComponent();
            processPriority.SelectedIndex = 0;
          
        }

        private void btnApps_Click(object sender, EventArgs e)
        {
            Updater updater = new Updater(tools, false);
            updater.Show();
        }


        public SortedList<String, String> getSettings()
        {
            SortedList<String, String> settings = new SortedList<string,string>();

            settings.Add("advertdisabled", titleAdvert.Checked.ToString());
            settings.Add("skipaudio", audioSkip.Checked.ToString());
            settings.Add("skipsubs", ignoreSubs.Checked.ToString());
            settings.Add("skipattachments", ignoreAttachments.Checked.ToString());
            settings.Add("showvideo", showVideo.Checked.ToString());
            settings.Add("skipchapters", ignoreChapters.Checked.ToString());
            settings.Add("aftererror", continueAfterError.Checked.ToString());
            if (outPutLocation.Text != "")
                settings.Add("customoutput", outPutLocation.Text + "\\");
            return settings;
        }
        public void setProcessWatcher(ProcessWatcher processWatcher)
        {
            this.processWatcher = processWatcher;
        }

        public void setTools(Tools tools)
        {
            this.tools = tools;
        }

        public void loadSettings(MainSettings settings)
        {

            titleAdvert.Checked = settings.disableVideoAdvert;
            outPutLocation.Text = settings.outputPath;
            processPriority.SelectedIndex= int.Parse(settings.processPriority);
            audioSkip.Checked = settings.ignoreAudio;
            ignoreAttachments.Checked = settings.ignoreAttachments;
            ignoreChapters.Checked = settings.ignoreChapters;
            ignoreSubs.Checked = settings.ignoreSubs;
        }

        private void EncodeOptions_Load(object sender, EventArgs e)
        {
           // processPriority.SelectedIndex = 0;
        }

        private void processPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            processWatcher.setPriority(processPriority.SelectedIndex);
        }

        private void outputSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            if (folderBrowser.SelectedPath != "")
                outPutLocation.Text = folderBrowser.SelectedPath;
        }

        private void clearOutput_Click(object sender, EventArgs e)
        {
            outPutLocation.Text = "";
        }

        public void saveMe()
        {
            MainSettings main = new MainSettings();
            main.disableVideoAdvert = titleAdvert.Checked;
            main.ignoreAttachments = ignoreAttachments.Checked;
            main.ignoreAudio = audioSkip.Checked;
            main.ignoreChapters = ignoreChapters.Checked;
            main.ignoreSubs = ignoreSubs.Checked;
            main.outputPath = outPutLocation.Text;
            main.processPriority = processPriority.SelectedIndex.ToString();

            main.saveSettings();
        }
    }
}
