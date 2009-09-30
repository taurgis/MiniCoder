using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace x264_GUI_CS.GUI
{
    public partial class frmFileInformation : Form
    {
        General.FileInformation fileInformation;
        mainGUI frmMain;
        int hardSub = 0;
        //public frmFileInformation(General.FileInformation fileInformation, mainGUI frmMain)
        //{
        //    InitializeComponent();
        //    this.fileInformation = fileInformation;
        //    this.frmMain = frmMain;
          
        //    this.TopMost = true;
            
        //}
        General.EncodingOptions encOptsExisting;
        public frmFileInformation(General.FileInformation fileInformation, mainGUI frmMain, General.EncodingOptions encodingOpts)
        {

            InitializeComponent();
            this.fileInformation = fileInformation;
            this.frmMain = frmMain;

            this.TopMost = true;

            this.encOptsExisting = encodingOpts;
        }


        private void frmFileInformation_Load(object sender, EventArgs e)
        {
            this.Text = fileInformation.name;
            txtFileLocation.Text = fileInformation.fileName  ;
            this.Location = new Point(frmMain.Location.X + frmMain.Width, frmMain.Location.Y);

            //audio length

            lblLength.Text = (fileInformation.audLength / 60).ToString() + " minites";
            lblFileSize.Text = ((Convert.ToInt64(fileInformation.fileSize) / 1024) / 1024).ToString() + " Mb";
            lblFramerate.Text = fileInformation.fps.ToString();
            lblAudioCount.Text = fileInformation.audioCount.ToString();
            lblSubTracks.Text = fileInformation.subCount.ToString();
            lblCodec.Text = fileInformation.vid_codec;

            //select default settings

            videoCombo.SelectedIndex = 0;
            vidQualCombo.SelectedIndex = 3;
            fileSize.Enabled = false;
            audioCombo.SelectedIndex = 0;
            containerCombo.SelectedIndex = 0;
            fieldCombo.SelectedIndex = 0;
            cbResize.SelectedIndex = 0;
            noiseCombo.SelectedIndex = 0;
            sharpCombo.SelectedIndex = 0;
         

            

            if (encOptsExisting != null)
            {
                if (encOptsExisting.sizeOpt == 0)
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
                videoBR.Text = encOptsExisting.vidBR.ToString();
                fileSize.Text = encOptsExisting.fileSize.ToString();
                videoCombo.SelectedIndex = encOptsExisting.vidCodec;
                vidQualCombo.SelectedIndex = encOptsExisting.vidQual;

                audioBR.Text = encOptsExisting.audBR.ToString(); ;
                audioCombo.SelectedIndex = encOptsExisting.audCodec;

                containerCombo.SelectedIndex = encOptsExisting.containerFormat;

                fieldCombo.SelectedIndex = encOptsExisting.filtField;
                cbResize.SelectedIndex = encOptsExisting.filtResize;

                if (encOptsExisting.filtResize != 0)
                {
                    NudVerticalResolution.Text = encOptsExisting.resizeHeight.ToString(); ;
                    NudHorizontalResolution.Text = encOptsExisting.resizeWidth.ToString(); ;
                }

                noiseCombo.SelectedIndex = encOptsExisting.filtNoise;
                sharpCombo.SelectedIndex = encOptsExisting.filtSharp;
                subText.Text = encOptsExisting.subtitle;
            }
            NudHorizontalResolution.Text = fileInformation.width.ToString();
            NudVerticalResolution.Text = fileInformation.height.ToString();


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

      

     
       private void cbResize_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (cbResize.SelectedIndex != 0)
           {
               NudHorizontalResolution.Enabled = true;
               NudVerticalResolution.Enabled = true;
           }
           else
           {
               NudHorizontalResolution.Enabled = false;
               NudVerticalResolution.Enabled = false;
           }
       }

       private void videoCombo_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (videoCombo.SelectedIndex == 0)
           {
               for (int i = 0; i < vidQualCombo.Items.Count; i++)
               {
                   if (vidQualCombo.Items[i].ToString() == "Very High (+50mb Anime)")
                       goto next;
               }
               vidQualCombo.Items.Add("Very High (+50mb Anime)");
           next:
               for (int i = 0; i < vidQualCombo.Items.Count; i++)
               {
                   if (vidQualCombo.Items[i].ToString() == "Very High (-50mb Anime)")
                       goto next2;
               }
               vidQualCombo.Items.Add("Very High (-50mb Anime)");
           next2:
               for (int i = 0; i < vidQualCombo.Items.Count; i++)
               {
                   if (vidQualCombo.Items[i].ToString() == "Very High (TV-Shows/Movies)")
                       goto next3;
               }
               vidQualCombo.Items.Add("Very High (TV-Shows/Movies)");
           next3:
               for (int i = 0; i < vidQualCombo.Items.Count; i++)
               {
                   if (vidQualCombo.Items[i].ToString() == "CRF (Anime)")
                       return;
               }
               vidQualCombo.Items.Add("CRF (Anime)");
           }
           else
           {
               vidQualCombo.Items.Remove("Very High (+50mb Anime)");
               vidQualCombo.Items.Remove("Very High (-50mb Anime)");
               vidQualCombo.Items.Remove("Very High (TV-Shows/Movies)");
               vidQualCombo.Items.Remove("CRF (Anime)");

           }
       }

       private void bitRateRadio_CheckedChanged_1(object sender, EventArgs e)
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

       private void widthText_TextLeave(object sender, EventArgs e)
       {
           try
           {
               checkSize();
           }
           catch
           {
           }
       }

       private void heightText_TextLeave(object sender, EventArgs e)
       {
           try
           {
               checkSize();
           }
           catch
           {
           }
       }

       private void checkSize()
       {
           if ((Convert.ToInt32(NudHorizontalResolution.Text) % 16) != 0)
           {
               MessageBox.Show("Width should be a multiple of 16 for error prevention and quality!");
               
           }
           if ((Convert.ToInt32(NudVerticalResolution.Text) % 16) != 0)
           {
               MessageBox.Show("Height should be a multiple of 16 for error prevention and quality!");
               
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

       private void btnSave_Click(object sender, EventArgs e)
       {
            General.EncodingOptions encOpts = new General.EncodingOptions();

            

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
                encOpts.filtResize = cbResize.SelectedIndex;

                if (encOpts.filtResize != 0)
                {
                    encOpts.resizeHeight = int.Parse(NudVerticalResolution.Text);
                    encOpts.resizeWidth = int.Parse(NudHorizontalResolution.Text);
                }

                encOpts.filtNoise = noiseCombo.SelectedIndex;
                encOpts.filtSharp = sharpCombo.SelectedIndex;
                encOpts.subtitle = subText.Text;

               //encOpts.customFilter = customFiltOpts;
                frmMain.addCustomSettings(fileInformation.name, encOpts);
                MessageBox.Show("Settings saved");
            } 
            catch (FormatException)
            {
               
               
            }
       }

       private void vidQualCombo_SelectedIndexChanged(object sender, EventArgs e)
       {
             if (vidQualCombo.SelectedItem.ToString() == "CRF (Anime)")
            {
             if(fileInformation.crfValue == 0)
                 fileInformation.crfValue = Convert.ToInt32(InputBox.Show("Please enter CRF value!", "CRF Value", "20"));
             else
                 fileInformation.crfValue = Convert.ToInt32(InputBox.Show("Please enter CRF value!", "CRF Value", fileInformation.crfValue.ToString()));
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

  

    


    

    

     

    

 

      



     
        
    
      

  
    }
}
