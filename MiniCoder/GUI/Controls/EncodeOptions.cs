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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MiniTech.MiniCoder.GUI.External;
using MiniTech.MiniCoder.External;
using MiniTech.MiniCoder.Encoding.Process_Management;
using MiniTech.MiniCoder.GUI;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.Core.Settings;
using System.Diagnostics;
using MiniTech.MiniCoder.Core.Managers;
namespace MiniTech.MiniCoder.GUI.Controls
{
    public partial class EncodeOptions : UserControl
    {

        private Tools tools;

        private MainForm mainForm;

        public EncodeOptions()
        {
            InitializeComponent();
            processPriority.SelectedIndex = 0;


        }

        public void setLanguage()
        {

            outputSettings.Text = LanguageController.Instance.getLanguageString("outputSettingsTitle");
            titleAdvert.Text = LanguageController.Instance.getLanguageString("outputDisableVideoAdvert");
            outputDir.Text = LanguageController.Instance.getLanguageString("outputDirectory");
            processSettings.Text = LanguageController.Instance.getLanguageString("processSettingsTitle");
            processPriorityLabel.Text = LanguageController.Instance.getLanguageString("processPriority");
            int curPriority = processPriority.SelectedIndex;
            processPriority.Items.Clear();
            processPriority.Items.AddRange(LanguageController.Instance.getLanguageString("processPriorityOptions").Split(';'));
            processPriority.SelectedIndex = curPriority;
            encodingGroup.Text = LanguageController.Instance.getLanguageString("encodingTitle");
            ignoreAttachments.Text = LanguageController.Instance.getLanguageString("encodingIgnoreAttachments");
            audioSkip.Text = LanguageController.Instance.getLanguageString("encodingIgnoreAudio");
            ignoreChapters.Text = LanguageController.Instance.getLanguageString("encodingIgnoreChapters");
            ignoreSubs.Text = LanguageController.Instance.getLanguageString("encodingIgnoreSubs");
            showVideo.Text = LanguageController.Instance.getLanguageString("encodingShowVideoPreview");
            continueAfterError.Text = LanguageController.Instance.getLanguageString("encodingNextError");
            btnApps.Text = LanguageController.Instance.getLanguageString("applicationsButton");
        }


        private void btnApps_Click(object sender, EventArgs e)
        {
            Updater updater = new Updater(tools, false);
            updater.Show();
        }

        public void setMain(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }
        public SortedList<String, String> getSettings()
        {
            SortedList<String, String> settings = new SortedList<string, string>();

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

        public void setTools(Tools tools)
        {
            this.tools = tools;
        }

        public void setLanguageDefault()
        {
            languagesSelect.SelectedIndex = 0;
        }

        public void loadSettings(MainSettings settings)
        {

            titleAdvert.Checked = settings.disableVideoAdvert;
            outPutLocation.Text = settings.outputPath;
            processPriority.SelectedIndex = int.Parse(settings.processPriority);
            audioSkip.Checked = settings.ignoreAudio;
            ignoreAttachments.Checked = settings.ignoreAttachments;
            ignoreChapters.Checked = settings.ignoreChapters;
            ignoreSubs.Checked = settings.ignoreSubs;
            continueAfterError.Checked = settings.continueAfterError;
            languagesSelect.SelectedIndex = settings.language;
        }

   

        private void processPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessManager.Instance.setPriority(processPriority.SelectedIndex);
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
            SettingsController.saveSettings(main);
        }

        private void languagesSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            LanguageController.Instance.setLanguage(languagesSelect.SelectedIndex);
            mainForm.loadLanguage();
        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }
    }
}
