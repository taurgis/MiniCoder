﻿using System;
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
using MiniCoder.Core.Languages;
using MiniCoder.Core.Settings;

namespace MiniCOder.GUI.Controls
{
    public partial class EncodeOptions : UserControl
    {
        
        Tools tools;
        ProcessWatcher processWatcher = new ProcessWatcher();
        MainForm mainForm;
        SysLanguage language;
        public EncodeOptions()
        {
            InitializeComponent();
            processPriority.SelectedIndex = 0;
           
   
        }

        public void setLanguage(SysLanguage language)
        {
            this.language = language;
            outputSettings.Text = language.outputSettingsTitle;
            titleAdvert.Text = language.outputDisableVideoAdvert;
            outputDir.Text = language.outputDirectory;
            processSettings.Text = language.processSettingsTitle;
            processPriorityLabel.Text = language.processPriority;
            int curPriority = processPriority.SelectedIndex;
            processPriority.Items.Clear();
            processPriority.Items.AddRange(language.processPriorityOptions);
            processPriority.SelectedIndex = curPriority;
            encodingGroup.Text = language.encodingTitle;
            ignoreAttachments.Text = language.encodingIgnoreAttachments;
            audioSkip.Text = language.encodingIgnoreAudio;
            ignoreChapters.Text = language.encodingIgnoreChapters;
            ignoreSubs.Text = language.encodingIgnoreSubs;
            showVideo.Text = language.encodingShowVideoPreview;
            continueAfterError.Text = language.encodingNextError;
            btnApps.Text = language.applicationsButton;
        }


        private void btnApps_Click(object sender, EventArgs e)
        {
            Updater updater = new Updater(tools, false, language);
            updater.Show();
        }

        public void setMain(MainForm mainForm)
        {
            this.mainForm = mainForm;
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
            continueAfterError.Checked = settings.continueAfterError;
            languagesSelect.SelectedIndex = settings.language;
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
            main.continueAfterError = continueAfterError.Checked;
            main.language = languagesSelect.SelectedIndex;
            main.saveSettings();
        }

        private void languagesSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainForm.loadLanguage(languagesSelect.SelectedIndex);
        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }
    }
}
