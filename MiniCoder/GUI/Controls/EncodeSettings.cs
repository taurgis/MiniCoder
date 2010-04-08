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
using MiniCoder.GUI.AviSynth;
using System.Input;
using MiniCoder.Templates.Simple;
using System.IO;
using MiniCoder.Core.Languages;

namespace MiniCOder.GUI.Controls
{
    public partial class EncodeSettings : UserControl
    {
        private int languageCode;
        string hardsubmp4 = "";
        int crfValue = 0;
        string customFilter = "";
        MainTemplate mainTemplate;

        public EncodeSettings()
        {
            InitializeComponent();
        }

        public void setLanguage(int languageCode)
        {
            this.languageCode = languageCode;
            videoOptions.Text = LanguageController.getLanguageString("videoOptionsTitle", languageCode);
            bitRateRadio.Text = LanguageController.getLanguageString("videoBitRate", languageCode);
            fileSizeRadio.Text = LanguageController.getLanguageString("videoFileSize", languageCode);
            videoQuality.Text = LanguageController.getLanguageString("videoQuality", languageCode);

            int curVidQual = vidQualCombo.SelectedIndex;
            vidQualCombo.Items.Clear();
            vidQualCombo.Items.AddRange(LanguageController.getLanguageString("videoQualityOptions", languageCode).Split(';'));
            vidQualCombo.SelectedIndex = curVidQual;
            videoCodec.Text = LanguageController.getLanguageString("videoCodec", languageCode);
            audioOptions.Text = LanguageController.getLanguageString("audioOptionsTitle", languageCode);
            audioBitrate.Text = LanguageController.getLanguageString("audioBitrate", languageCode);
            audCodec.Text = LanguageController.getLanguageString("audioCodec", languageCode);
            containerOptions.Text = LanguageController.getLanguageString("containerOptionsTitle", languageCode);
            format.Text = LanguageController.getLanguageString("containerFormat", languageCode);
            filterOptions.Text = LanguageController.getLanguageString("filterOptionsTitle", languageCode);
            preProcessing.Text = LanguageController.getLanguageString("preprocessingOptionsTitle", languageCode);
            field.Text = LanguageController.getLanguageString("preField", languageCode);
            resize.Text = LanguageController.getLanguageString("preResize", languageCode);
            int curResize = resizeCombo.SelectedIndex;
            resizeCombo.Items.Clear();
            resizeCombo.Items.AddRange(LanguageController.getLanguageString("preResizeOptions", languageCode).Split(';'));
            resizeCombo.SelectedIndex = curResize;
            widthheightLabel.Text = LanguageController.getLanguageString("preWidthHeight", languageCode);
            postprocessing.Text = LanguageController.getLanguageString("postprocessingOptionsTitle", languageCode);
            denoiserLabel.Text = LanguageController.getLanguageString("postDenoiser", languageCode);
            int curDenoise = noiseCombo.SelectedIndex;
            noiseCombo.Items.Clear();
            noiseCombo.Items.AddRange(LanguageController.getLanguageString("postDenoiserOptions", languageCode).Split(';'));
            noiseCombo.SelectedIndex = curDenoise;
            sharpenLabel.Text = LanguageController.getLanguageString("postSharpen", languageCode);
            int curSharpen = sharpCombo.SelectedIndex;
            sharpCombo.Items.Clear();
            sharpCombo.Items.AddRange(LanguageController.getLanguageString("postSharpenOptions", languageCode).Split(';'));
            sharpCombo.SelectedIndex = curSharpen;
            subtitle.Text = LanguageController.getLanguageString("postSubtitle", languageCode);
            customButton.Text = LanguageController.getLanguageString("customButton", languageCode);
            saveOptButton.Text = LanguageController.getLanguageString("saveButton", languageCode);
            settingsTooltip.SetToolTip(videoBR, LanguageController.getLanguageString("tooltipVideoBr", languageCode));
            settingsTooltip.SetToolTip(fileSize, LanguageController.getLanguageString("tooltipFileSize", languageCode));
            settingsTooltip.SetToolTip(vidQualCombo, LanguageController.getLanguageString("tooltipQuality", languageCode));
            settingsTooltip.SetToolTip(videoCombo, LanguageController.getLanguageString("tooltipVideoCodec", languageCode));
            settingsTooltip.SetToolTip(audioBR, LanguageController.getLanguageString("tooltipAudioBr", languageCode));
            settingsTooltip.SetToolTip(audioCombo, LanguageController.getLanguageString("tooltipAudioCodec", languageCode));
            settingsTooltip.SetToolTip(containerCombo, LanguageController.getLanguageString("tooltipContainer", languageCode));
            settingsTooltip.SetToolTip(fieldCombo, LanguageController.getLanguageString("tooltipField", languageCode));
            settingsTooltip.SetToolTip(resizeCombo, LanguageController.getLanguageString("tooltipResize", languageCode));
            settingsTooltip.SetToolTip(widthHeight, LanguageController.getLanguageString("tooltipWidthHeight", languageCode));
            settingsTooltip.SetToolTip(noiseCombo, LanguageController.getLanguageString("tooltipDenoise", languageCode));
            settingsTooltip.SetToolTip(openSubBtn, LanguageController.getLanguageString("tooltipSub", languageCode));
        }

        public SortedList<string, string> getSettings()
        {
            SortedList<string, string> options = new SortedList<string, string>();
            options.Add("audbr", audioBR.Text);
            if (containerCombo.SelectedIndex != 2)
                options.Add("audcodec", audioCombo.SelectedIndex.ToString());
            else
                options.Add("audcodec", (audioCombo.SelectedIndex + 2).ToString());
            options.Add("field", fieldCombo.SelectedIndex.ToString());
            options.Add("resize", resizeCombo.SelectedIndex.ToString());
            if (resizeCombo.SelectedIndex != 0)
            {
                options.Add("width", widthHeight.Text.Split(Char.Parse(":"))[0]);
                options.Add("height", widthHeight.Text.Split(Char.Parse(":"))[1]);
            }
            options.Add("denoise", noiseCombo.SelectedIndex.ToString());
            options.Add("sharpen", sharpCombo.SelectedIndex.ToString());
            options.Add("custom", customFilter + "\r\n");
            if (fileSizeRadio.Checked)
                options.Add("sizeopt", "1");
            else
                options.Add("sizeopt", "0");

            options.Add("hardsubmp4", hardsubmp4);
            options.Add("videobr", videoBR.Text);
            options.Add("filesize", fileSize.Text);
            options.Add("vidqual", vidQualCombo.SelectedIndex.ToString());
            options.Add("crfvalue", crfValue.ToString());
            options.Add("container", containerCombo.SelectedIndex.ToString());
            options.Add("videocodec", videoCombo.SelectedIndex.ToString());
            if (subText.Text != "Select Subtitle file to use")
                if (File.Exists(subText.Text))
                    options.Add("hardsub", subText.Text);
            //still need to enable options




            return options;

        }

        public int getSelectedIndex()
        {
            return templateCombo.SelectedIndex;
        }

        private void EncodeSettings_Load(object sender, EventArgs e)
        {
            audioCombo.SelectedIndex = 0;
            fieldCombo.SelectedIndex = 0;
            resizeCombo.SelectedIndex = 0;
            noiseCombo.SelectedIndex = 0;
            sharpCombo.SelectedIndex = 0;
            widthHeight.SelectedIndex = 0;
            videoCombo.SelectedIndex = 0;
            containerCombo.SelectedIndex = 0;
            vidQualCombo.SelectedIndex = 0;
            loadSettings();
        }
        public void loadSettings()
        {
            try
            {
                templateCombo.Items.Clear();
                if (!Directory.Exists(Application.StartupPath + "\\Templates\\Simple\\"))
                    Directory.CreateDirectory(Application.StartupPath + "\\Templates\\Simple\\");
                DirectoryInfo directory = new DirectoryInfo(Application.StartupPath + "\\Templates\\Simple\\");
                mainTemplate = new MainTemplate();
                foreach (FileInfo file in directory.GetFiles())
                {
                    templateCombo.Items.Add(file.Name.Substring(0, file.Name.Length - 4));
                }

                try
                {
                    templateCombo.SelectedIndex = 0;
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        private void customButton_Click(object sender, EventArgs e)
        {
            CustomFilter custom = new CustomFilter(customFilter, languageCode);
            custom.ShowDialog();
            customFilter = custom.customFiltOpts;
        }

        private void vidQualCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vidQualCombo.SelectedItem.ToString() == "CRF (Anime)")
            {
                if (crfValue == 0)
                    crfValue = Convert.ToInt32(InputBox.Show("Please enter CRF value!", "CRF Value", "20"));
                else
                    crfValue = Convert.ToInt32(InputBox.Show("Please enter CRF value!", "CRF Value", crfValue.ToString()));
            }
        }

        private void videoCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            audioCombo.Enabled = true;
            containerCombo.Enabled = true;
            if (videoCombo.SelectedIndex == 0)
            {
                vidQualCombo.Items.Clear();

                vidQualCombo.Items.AddRange(LanguageController.getLanguageString("videoQualityOptions", languageCode).Split(';'));

                vidQualCombo.SelectedIndex = 0;
            }
            else
            {
                if (videoCombo.SelectedIndex == 2)
                {
                    if (int.Parse(audioBR.Text) < 50)
                        audioBR.Text = "50";

                    audioCombo.SelectedIndex = 1;
                    audioCombo.Enabled = false;
                    containerCombo.Enabled = false;

                }
                try
                {
                    vidQualCombo.Items.RemoveAt(3);
                    vidQualCombo.Items.RemoveAt(3);
                    vidQualCombo.Items.RemoveAt(3);
                    vidQualCombo.Items.RemoveAt(3);
                    vidQualCombo.Items.RemoveAt(3);
                    vidQualCombo.Items.RemoveAt(3);
                    vidQualCombo.Items.RemoveAt(3);
                }
                catch
                {
                }
                vidQualCombo.SelectedIndex = 0;

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

        private void cbTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LogBook.Instance.addLogLine("Template Management", "TemplateManagement", "TemplateManagement", false);

                mainTemplate = SimpleTemplateController.loadTemplate(templateCombo.SelectedItem.ToString());
                LogBook.Instance.addLogLine(DateTime.Now.ToString("t") + ": Loaded template " + templateCombo.SelectedItem + " ...", "TemplateManagement", "", false);
                videoBR.Text = mainTemplate.vidBitRate;
                fileSize.Text = mainTemplate.fileSize;
                vidQualCombo.SelectedIndex = int.Parse(mainTemplate.vidQuality);
                videoCombo.SelectedIndex = int.Parse(mainTemplate.vidCodec);
                fieldCombo.SelectedIndex = int.Parse(mainTemplate.fieldFilter);
                resizeCombo.SelectedIndex = int.Parse(mainTemplate.resizeFilter);
                widthHeight.Text = mainTemplate.widthHeight;
                audioBR.Text = mainTemplate.audBitrate;
                if (mainTemplate.selectedVideo == "0")
                    bitRateRadio.Checked = true;
                else
                    fileSizeRadio.Checked = true;
                audioCombo.SelectedIndex = int.Parse(mainTemplate.audCodec);
                containerCombo.SelectedIndex = int.Parse(mainTemplate.containerFormat);
                noiseCombo.SelectedIndex = int.Parse(mainTemplate.denoiseFilter);
                sharpCombo.SelectedIndex = int.Parse(mainTemplate.sharpenFilter);
                subText.Text = mainTemplate.subtitle;
                customFilter = mainTemplate.customAvs;

            }
            catch
            {

            }
        }

        private void saveOptButton_Click(object sender, EventArgs e)
        {
            try
            {
                mainTemplate = new MainTemplate
                {
                    vidBitRate = videoBR.Text,
                    fileSize = fileSize.Text,
                    vidQuality = vidQualCombo.SelectedIndex.ToString(),
                    vidCodec = videoCombo.SelectedIndex.ToString(),
                    fieldFilter = fieldCombo.SelectedIndex.ToString(),
                    resizeFilter = resizeCombo.SelectedIndex.ToString(),
                    widthHeight = widthHeight.Text,
                    audBitrate = audioBR.Text,
                    audCodec = audioCombo.SelectedIndex.ToString(),
                    containerFormat = containerCombo.SelectedIndex.ToString(),
                    denoiseFilter = noiseCombo.SelectedIndex.ToString(),
                    sharpenFilter = sharpCombo.SelectedIndex.ToString(),
                    subtitle = subText.Text,
                    customAvs = customFilter,
                };
                if (bitRateRadio.Checked)
                    mainTemplate.selectedVideo = "0";
                else
                    mainTemplate.selectedVideo = "1";

                try
                {
                    mainTemplate.templateName = InputBox.Show("Enter template name", "Template Name", templateCombo.Items[templateCombo.SelectedIndex].ToString());
                    if (!String.IsNullOrEmpty(mainTemplate.templateName))
                    {
                        SimpleTemplateController.saveTemplate(mainTemplate);
                    }
                }
                catch
                {
                    mainTemplate.templateName = InputBox.Show("Enter template name", "Template Name", "default");
                    if (!String.IsNullOrEmpty(mainTemplate.templateName))
                        SimpleTemplateController.saveTemplate(mainTemplate);
                }

                loadSettings();
            }
            catch
            {

            }
        }

        private void containerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = audioCombo.SelectedIndex;
            audioCombo.Items.Clear();

            audioCombo.Items.Add("Nero AAC");
            audioCombo.Items.Add("Vorbis");
            audioCombo.Items.Add("FFmpeg AC-3");
            audioCombo.Items.Add("Lame MP3");
            audioCombo.SelectedIndex = index;
            switch (containerCombo.SelectedIndex)
            {
                case 1:
                    try
                    {
                        hardsubmp4 = InputBox.Show("Please select wich sub you wish to add to the MP4/AVI file. 1,2,3... 1 = First sub file, 2 = Second sub file,... 0 means that you will add subfiles softsubbed.", "Hardsub", "0");
                    }
                    catch
                    {
                        MessageBox.Show("Please enter a number");
                        containerCombo_SelectedIndexChanged(sender, e);

                    }
                    break;
                case 2:
                    {
                        try
                        {
                            hardsubmp4 = InputBox.Show("Please select wich sub you wish to add to the MP4/AVI file. 1,2,3... 1 = First sub file, 2 = Second sub file,... 0 means that you will add subfiles softsubbed.", "Hardsub", "0");
                        }
                        catch
                        {
                            MessageBox.Show("Please enter a number");
                            containerCombo_SelectedIndexChanged(sender, e);

                        }
                        audioCombo.Items.Remove("Nero AAC");
                        audioCombo.Items.Remove("Vorbis");
                        audioCombo.SelectedIndex = 0;
                    }
                    break;
            }
        }

        private void btnDeleteTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Delete(Application.StartupPath + "\\Templates\\Simple\\" + templateCombo.SelectedItem.ToString() + ".tpl");
                    loadSettings();
                }
            }
            catch
            {
            }
        }


    }
}
