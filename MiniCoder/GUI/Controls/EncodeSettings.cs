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
        SysLanguage language = new SysLanguage(0);
        string hardsubmp4 = "";
        int crfValue = 0;
        string customFilter = "";
        MainTemplate mainTemplate;
        public EncodeSettings()
        {
            InitializeComponent();

           

        }

        public void setLanguage(SysLanguage language)
        {
            this.language = language;
            videoOptions.Text = language.videoOptionsTitle;
            bitRateRadio.Text = language.videoBitRate;
            fileSizeRadio.Text = language.videoFileSize;
            videoQuality.Text = language.videoQuality;

            int curVidQual = vidQualCombo.SelectedIndex;
            vidQualCombo.Items.Clear();
            vidQualCombo.Items.AddRange(language.videoQualityOptions);
            vidQualCombo.SelectedIndex = curVidQual;
            videoCodec.Text = language.videoCodec;
            audioOptions.Text = language.audioOptionsTitle;
            audioBitrate.Text = language.audioBitrate;
            audCodec.Text = language.audioCodec;
            containerOptions.Text = language.containerOptionsTitle;
            format.Text = language.containerFormat;
            filterOptions.Text = language.filterOptionsTitle;
            preProcessing.Text = language.preprocessingOptionsTitle;
            field.Text = language.preField;
            resize.Text = language.preResize;
            int curResize = resizeCombo.SelectedIndex;
            resizeCombo.Items.Clear();
            resizeCombo.Items.AddRange(language.preResizeOptions);
            resizeCombo.SelectedIndex = curResize;
            widthheightLabel.Text = language.preWidthHeight;
            postprocessing.Text = language.postprocessingOptionsTitle;
            denoiserLabel.Text = language.postDenoiser;
            int curDenoise = noiseCombo.SelectedIndex;
            noiseCombo.Items.Clear();
            noiseCombo.Items.AddRange(language.postDenoiserOptions);
            noiseCombo.SelectedIndex = curDenoise;
            sharpenLabel.Text = language.postSharpen;
            int curSharpen = sharpCombo.SelectedIndex;
            sharpCombo.Items.Clear();
            sharpCombo.Items.AddRange(language.postSharpenOptions);
            sharpCombo.SelectedIndex = curSharpen;
            subtitle.Text = language.postSubtitle;
            customButton.Text = language.customButton;
            saveOptButton.Text = language.saveButton;
            settingsTooltip.SetToolTip(videoBR, language.tooltipVideoBr);
            settingsTooltip.SetToolTip(fileSize, language.tooltipFileSize);
            settingsTooltip.SetToolTip(vidQualCombo, language.tooltipQuality);
            settingsTooltip.SetToolTip(videoCombo, language.tooltipVideoCodec);
            settingsTooltip.SetToolTip(audioBR, language.tooltipAudioBr);
            settingsTooltip.SetToolTip(audioCombo, language.tooltipAudioCodec);
            settingsTooltip.SetToolTip(containerCombo, language.tooltipContainer);
            settingsTooltip.SetToolTip(fieldCombo, language.tooltipField);
            settingsTooltip.SetToolTip(resizeCombo, language.tooltipResize);
            settingsTooltip.SetToolTip(widthHeight, language.tooltipWidthHeight);
            settingsTooltip.SetToolTip(noiseCombo, language.tooltipDenoise);
            settingsTooltip.SetToolTip(openSubBtn, language.tooltipSub);
        }

        public SortedList<string, string> getSettings()
        {
            SortedList<string, string> options = new SortedList<string, string>();
            options.Add("audbr", audioBR.Text);
            if(containerCombo.SelectedIndex != 2)
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
            CustomFilter custom = new CustomFilter(customFilter, language);
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

               
                vidQualCombo.Items.AddRange(language.videoQualityOptions);
              
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
                LogBook.addLogLine("Template Management", "TemplateManagement", "TemplateManagement", false);
               
                mainTemplate.loadTemplate(templateCombo.SelectedItem.ToString());
                LogBook.addLogLine(DateTime.Now.ToString("t") + ": Loaded template " + templateCombo.SelectedItem + " ...", "TemplateManagement", "", false);
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
                mainTemplate = new MainTemplate {
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
                    string templateName = InputBox.Show("Enter template name", "Template Name", templateCombo.Items[templateCombo.SelectedIndex].ToString());
                    if(!String.IsNullOrEmpty(templateName))
                    mainTemplate.saveTemplate(templateName);
                }
                catch
                {
                    string templateName = InputBox.Show("Enter template name", "Template Name", "default");
                   if(!String.IsNullOrEmpty(templateName))
                       mainTemplate.saveTemplate(templateName);
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
