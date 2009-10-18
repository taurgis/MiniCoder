﻿using System;
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
namespace MiniCOder.GUI.Controls
{
    public partial class EncodeSettings : UserControl
    {
        string hardsubmp4 = "";
        int crfValue = 0;
        string customFilter = "";
        MainTemplate mainTemplate;
        public EncodeSettings()
        {
            InitializeComponent();
         
            audioCombo.SelectedIndex = 0;
            fieldCombo.SelectedIndex = 0;
            resizeCombo.SelectedIndex = 0;
            noiseCombo.SelectedIndex = 0;
            sharpCombo.SelectedIndex = 0;
            widthHeight.SelectedIndex = 0;
            videoCombo.SelectedIndex = 0;
            containerCombo.SelectedIndex = 0;
            vidQualCombo.SelectedIndex = 0;
          
            }

        public SortedList<string, string> getSettings()
        {
            SortedList<string, string> options = new SortedList<string, string>();
            options.Add("audbr", audioBR.Text);
            options.Add("audcodec", audioCombo.SelectedIndex.ToString());
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
                options.Add("hardsub", subText.Text);
            //still need to enable options
            
            options.Add("advert", "");
           

            return options;

        }

        private void EncodeSettings_Load(object sender, EventArgs e)
        {
            loadSettings();
        }
        private void loadSettings()
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
            CustomFilter custom = new CustomFilter(customFilter);
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
                vidQualCombo.Items.Remove("Very High (+50mb Anime)");
                vidQualCombo.Items.Remove("Very High (-50mb Anime)");
                vidQualCombo.Items.Remove("Very High (TV-Shows/Movies)");
                vidQualCombo.Items.Remove("CRF (Anime)");
                vidQualCombo.Items.Remove("Ipod");
                vidQualCombo.Items.Remove("PSP");
                vidQualCombo.Items.Remove("PS3");
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
                mainTemplate.loadTemplate(templateCombo.SelectedItem.ToString());
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
            switch (containerCombo.SelectedIndex)
            {
                case 1:
                    try
                    {
                        hardsubmp4 = InputBox.Show("Please select wich sub you wish to add to the MP4 file. 1,2,3... 1 = First sub file, 2 = Second sub file,... 0 means that you will add subfiles softsubbed.", "Hardsub", "0");
                    }
                    catch
                    {
                        MessageBox.Show("Please enter a number");
                        containerCombo_SelectedIndexChanged(sender, e);

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