using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MiniCoder.General;
using System.Text;
using System.Windows.Forms;
using System.IO;
using x264_GUI_CS.General;
namespace x264_GUI_CS
{
    public partial class Wizard : Form
    {
        ApplicationSettings appsettings;
        public Wizard(ApplicationSettings appsettings)
        {
            InitializeComponent();
            this.appsettings = appsettings;
        }

        private void Wizard_Load(object sender, EventArgs e)
        {
            btnStep1.Image = Image.FromFile(Application.StartupPath + "\\Images\\Wizard\\button.jpg");
            tbp1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Images\\Wizard\\1.jpg");
            tp3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Images\\Wizard\\2.jpg");
            btnStep3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Images\\Wizard\\button2.jpg");
            pbSizeTest.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Images\\Wizard\\neutral.jpg");
            btnSave.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Images\\Wizard\\save.jpg");
            videoCombo.SelectedIndex = 0;
        }

        private void tbp1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void pbTV_Click(object sender, EventArgs e)
        {

        }

        private void vidQualCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pbQuality.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Images\\Wizard\\VidQual\\" + vidQualCombo.SelectedIndex.ToString() + ".jpg");
                switch (vidQualCombo.SelectedIndex)
                {
                    case 0:
                            lblDescription.Text = "This is a basic x264 profile, if you have a pretty decent computer I suggest you don't use this one.";
                            lblEncodingTime.Text = "Low";
                            lblBitrate.Text = "300 (Anime ends up around 55-60mb)";
                            break;
                    case 1:
                        lblDescription.Text = "This is a higher setting for the basic profile, it will give a better endresult than medium setting. Again if you have a decent PC don't use this setting.";
                        lblEncodingTime.Text = "Low";
                        lblBitrate.Text = "300 (Anime ends up around 55-60mb)";
                        break;
                    case 2:
                        lblDescription.Text = "This is the highest setting of a basic profile, this will give a decent endresult when encoding. Use this if you have a decent PC at the minimum 2-3 years old.";
                        lblEncodingTime.Text = "Medium";
                        lblBitrate.Text = "300 (Anime ends up around 55-60mb)";
                        break;
                    case 3:
                        lblDescription.Text = "This is the currently used MiniTheatre profile most encoders use to encode their anime. Use this profile if you have a PC of at the minimum 1-2 years old with a dualcore processor.";
                        lblEncodingTime.Text = "High";
                        lblBitrate.Text = "300 (Anime ends up around 55-60mb)";
                        break;
                    case 4:
                        lblDescription.Text = "This is an alternative profile by MiniTheatre for encoding anime to a low filesize of around 30-40mb. Use this if you really want extreme small filesizes and a PC with a dualcore processor.";
                        lblEncodingTime.Text = "High";
                        lblBitrate.Text = "300 (Anime ends up around 55-60mb)";
                        break;
                    case 5:
                        lblDescription.Text = "This is the MT profile for TV-shows and movies. Use this if you have atleast a dualcore processor.";
                        lblEncodingTime.Text = "Verry High";
                        lblBitrate.Text = "300 (A TV-show ends up at 120mb if its around 40mins long)";
                        break;
                    case 6:
                             lblDescription.Text = "This is the profile our good friends at AnimeStash use. This is also a website that reencodes anime to small filesizes. This system uses CRF wich will decide how big the file will be on quality. Use this profile if you have a PC of a minimum 3 years old.";
                            lblEncodingTime.Text = "Low-Medium";
                            lblBitrate.Text = "No control over this. AUTO";
                            break;
                }
            }
            catch
            {
            }

        }

        private void lblBitrate_Click(object sender, EventArgs e)
        {

        }

        private void lblEncodingTime_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnStep2_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoCombo.SelectedItem.ToString() == "" || vidQualCombo.SelectedItem.ToString() == "" || fileSize.Text.ToString() == "" || videoBR.Text == "")
                    MessageBox.Show("Please fill in all fields!");
                else
                    tabControl1.SelectedIndex = 2;
            }
            catch
            {
                MessageBox.Show("Please fill in all fields correctly!");
            }
        }

        private void audioCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (audioCombo.SelectedIndex)
            {
                case 0:
                    lblCodecDescription.Text = "Advanced Audio Coding (AAC) is a standardized, lossy compression and encoding scheme for digital audio. Designed to be the successor of the MP3 format, AAC generally achieves better sound quality than MP3 at many bit rates.";
                    break;
                case 1:
                    lblCodecDescription.Text = "Vorbis is a free and open source software project headed by the Xiph.Org Foundation. The project produces an audio format specification and software implementation (codec) for lossy audio compression that is intended to be a replacement for the proprietary MP3 format. Vorbis is most commonly used in conjunction with the Ogg container format and it is therefore often referred to as Ogg Vorbis.";
                    break;
            }
        }

        private void resizeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void resizeCombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (resizeCombo.SelectedIndex != 0)
            {
                widthText.Enabled = true;
                heightText.Enabled = true;
            }
            else
            {
                widthText.Enabled = false;
                heightText.Enabled = false;
            }

            switch (resizeCombo.SelectedIndex)
            {
                case 0:
                    pbSizeTest.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Images\\Wizard\\neutral.jpg");
      
                    break;
                case 1:
                    pbSizeTest.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Images\\Wizard\\soft.jpg");
      
                    break;
                case 2:
                    pbSizeTest.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Images\\Wizard\\neutral.jpg");
      
                    break;
                case 3:
                    pbSizeTest.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Images\\Wizard\\sharp.jpg");
      
                    break;
                case 4:
                    pbSizeTest.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Images\\Wizard\\sharper.jpg");
      
                    break;
                case 5:

                    break;

            }
        }

        private void widthText_TextChanged(object sender, EventArgs e)
        {
            resizePic();
        }

        private void heightText_TextChanged(object sender, EventArgs e)
        {
            resizePic();
        }

        private void resizePic()
        {
            try
            {
                pbSizeTest.Width = Convert.ToInt32(widthText.Text) / 4;
                pbSizeTest.Height = Convert.ToInt32(heightText.Text) / 4;
            }
            catch
            {

            }
        }

        private void btnStep3_Click(object sender, EventArgs e)
        {
            try
            {
               
                    if (audioBR.Text == "" || audioCombo.SelectedItem.ToString() == "")
                        MessageBox.Show("Please fill in all values!");
                    else
                        tabControl1.SelectedIndex = 3;
               
            }
            catch
            {
                MessageBox.Show("Please fill in all values!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (resizeCombo.SelectedIndex != 0)
                {
                    if (resizeCombo.SelectedItem.ToString() == "" || widthText.Text == "" || heightText.Text == "")
                        MessageBox.Show("Please fill in all values!");
                    else
                    {
                       createDefault();
                        this.Close();
                    }
                }
                else
                {
                    createDefault();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Please fill in all values!");
            }
        }




        private void createDefault()
        {
            if (!Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\x264Encoder\\Templates\\"))
                Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\x264Encoder\\Templates\\");

            EncodingOptions encOpts = new EncodingOptions();
            try
            {
                encOpts.vidBR = int.Parse(videoBR.Text);
                encOpts.vidCodec = videoCombo.SelectedIndex;
                encOpts.vidQual = vidQualCombo.SelectedIndex;

                encOpts.audBR = int.Parse(audioBR.Text);
                encOpts.audCodec = audioCombo.SelectedIndex;

                encOpts.containerFormat = 0;

                encOpts.filtField = 1;
                encOpts.filtResize = resizeCombo.SelectedIndex;

                if (encOpts.filtResize != 0)
                {
                    encOpts.resizeHeight = int.Parse(heightText.Text);
                    encOpts.resizeWidth = int.Parse(widthText.Text);
                }

                encOpts.filtNoise = 0;
                encOpts.filtSharp = 0;
                encOpts.subtitle = "Select Subtitle file to use";
                encOpts.templateName = "default";
                encOpts.sizeOpt = 0;
                encOpts.save();
                //     encOpts.customFilter = customFiltOpts;


            }
            catch
            {

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

        private void fileSizeRadio_CheckedChanged(object sender, EventArgs e)
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


                for (int i = 0; i < vidQualCombo.Items.Count; i++)
                {
                    if (vidQualCombo.Items[i].ToString() == "MT (+50mb Anime)")
                        goto next;
                }
                vidQualCombo.Items.Add("MT (+50mb Anime)");
            next:
                for (int i = 0; i < vidQualCombo.Items.Count; i++)
                {
                    if (vidQualCombo.Items[i].ToString() == "MT-2 (-50mb Anime)")
                        goto next2;
                }
                vidQualCombo.Items.Add("MT-2 (-50mb Anime)");
            next2:
                for (int i = 0; i < vidQualCombo.Items.Count; i++)
                {
                    if (vidQualCombo.Items[i].ToString() == "MT-3 (TV-Shows/Movies)")
                        goto next3;
                }
                vidQualCombo.Items.Add("MT-3 (TV-Shows/Movies)");
            next3:
                for (int i = 0; i < vidQualCombo.Items.Count; i++)
                {
                    if (vidQualCombo.Items[i].ToString() == "AniStash (CRF)")
                        return;
                }
                vidQualCombo.Items.Add("AniStash (CRF)");
            }
            else
            {


                vidQualCombo.Items.Remove("MT (+50mb Anime)");
                vidQualCombo.Items.Remove("MT-2 (-50mb Anime)");
                vidQualCombo.Items.Remove("MT-3 (TV-Shows/Movies)");
                vidQualCombo.Items.Remove("AniStash (CRF)");

            }
        }

      

    }
}
