using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Collections;


namespace x264_GUI_CS.GUI
{
    public partial class AppManagement : Form
    {
        ApplicationSettings appSettings;
        
        public AppManagement(ApplicationSettings appSettings)
        {
            InitializeComponent();
            this.appSettings = appSettings;
        }
        Hashtable programs = new Hashtable();
        private void AppManagement_Load(object sender, EventArgs e)
        {
            programs = appSettings.htRequired;
            foreach (string key in programs.Keys)
            {
                Package tempPackage = (Package)programs[key];
                
                addRow(key, tempPackage.getAppType(), tempPackage.getInstallPath(), tempPackage.getVersion(), "dunno", tempPackage.getDownloadUrl());


            }
            //addRow("mkv2vfr", "exe", appSettings.mkv2vfrDIR + "mkv2vfr.exe", appSettings.GetAppVersion(appSettings.mkv2vfrDIR + "mkv2vfr.exe"), "", "http://www.gamerzzheaven.be/mkv2vfr.zip");
            //addRow("mkvextract - MkvToolnix", "exe", appSettings.mkvtoolnixDIR + "mkvextract.exe", appSettings.GetAppVersion(appSettings.mkvtoolnixDIR + "mkvextract.exe"), "2.6.0", "http://www.gamerzzheaven.be/mkvtoolnix.exe");
            //addRow("mkvinfo - MkvToolnix", "exe", appSettings.mkvtoolnixDIR + "mkvinfo.exe", appSettings.GetAppVersion(appSettings.mkvtoolnixDIR + "mkvinfo.exe"), "2.6.0", "http://www.gamerzzheaven.be/mkvtoolnix.exe");
            //addRow("mkvmerge - MkvToolnix", "exe", appSettings.mkvtoolnixDIR + "mkvmerge.exe", appSettings.GetAppVersion(appSettings.mkvtoolnixDIR + "mkvmerge.exe"), "2.6.0", "http://www.gamerzzheaven.be/mkvtoolnix.exe");
            //addRow("MP4Box", "exe", appSettings.mp4boxDIR + "MP4Box.exe", appSettings.GetAppVersion(appSettings.mp4boxDIR + "MP4Box.exe"), "0, 4, 5, 0", "http://www.minitheatre.org/x264prog/mp4box.zip");
            //addRow("OGMDemuxer", "exe", appSettings.ogmtoolsDIR + "OGMDemuxer.exe", appSettings.GetAppVersion(appSettings.ogmtoolsDIR + "OGMDemuxer.exe"), "", "http://www.gamerzzheaven.be/OGMTools.zip");
            //addRow("VirtualDubMod", "exe", appSettings.vdubmodDIR + "VirtualDubMod.exe", appSettings.GetAppVersion(appSettings.vdubmodDIR + "VirtualDubMod.exe"), "1.5.10.2", "http://www.gamerzzheaven.be/VirtualDubMod.zip");
            //addRow("x264", "exe", appSettings.x264DIR + "x264.exe", appSettings.GetAppVersion(appSettings.x264DIR + "x264.exe"), "", "http://www.gamerzzheaven.be/x264.zip");
            //addRow("ffmpeg", "exe", appSettings.ffmpegDIR + "ffmpeg.exe", appSettings.GetAppVersion(appSettings.ffmpegDIR + "ffmpeg.exe"), "", "http://www.gamerzzheaven.be/ffmpeg.zip");
            //addRow("oggenc2", "exe", appSettings.oggenc2DIR + "oggenc2.exe", appSettings.GetAppVersion(appSettings.oggenc2DIR + "oggenc2.exe"), "", "http://www.gamerzzheaven.be/oggenc2.zip");
            //addRow("BeSweet", "exe", appSettings.besweetDIR + "BeSweet.exe", appSettings.GetAppVersion(appSettings.besweetDIR + "BeSweet.exe"), "", "http://www.gamerzzheaven.be/BeSweet.zip");
            //addRow("Decomb", "dll", appSettings.avspluginsDIR + "Decomb.dll", "No version", "", "http://www.gamerzzheaven.be/Decomb.dll");
            //addRow("UnDot", "dll", appSettings.avspluginsDIR + "Undot.dll", "No version", "", "http://www.gamerzzheaven.be/Undot.dll");
            //addRow("FluxSmooth", "dll", appSettings.avspluginsDIR + "Fluxsmooth.dll", "No version", "", "test");
            //addRow("HQDN3D", "dll", appSettings.avspluginsDIR + "HQDN3D.dll", "No version", "", "http://www.gamerzzheaven.be/Fluxsmooth.dll");
            //addRow("Deen", "dll", appSettings.avspluginsDIR + "Deen.dll", "No version", "", "http://www.gamerzzheaven.be/Deen.dll");
            //addRow("VSFilter", "dll", appSettings.avspluginsDIR + "VSFilter.dll", "No version", "", "http://www.gamerzzheaven.be/VSFilter.dll");
            //addRow("UnFilter", "dll", appSettings.avspluginsDIR + "UnFilter.dll", "No version", "", "http://www.gamerzzheaven.be/UnFilter.dll");
            //addRow("Toon-v1.0-lite", "dll", appSettings.avspluginsDIR + "Toon-v1.0-lite.dll", "No version", "", "http://www.gamerzzheaven.be/Toon-v1.0-lite.dll");
            //addRow("aWarpSharp", "dll", appSettings.avspluginsDIR + "aWarpSharp.dll", "No version", "", "http://www.gamerzzheaven.be/aWarpSharp.dll");
            //addRow("MSharpen", "dll", appSettings.avspluginsDIR + "MSharpen.dll", "No version", "", "http://www.gamerzzheaven.be/MSharpen.dll");
            
            
            
           
            
        }

        private void addRow(string appName, string appType, string appLocation, string appVersion, string appRequired, string downloadurl)
        {
            Hashtable programs = appSettings.htRequired;
            Package tempPkg = (Package)programs[appName];
            DataGridViewRow dgrApp = new DataGridViewRow();
            DataGridViewCell dgcAppname = new DataGridViewTextBoxCell();
            DataGridViewCell dgcAppType = new DataGridViewTextBoxCell();
            DataGridViewCell dgcLocation = new DataGridViewTextBoxCell();
            DataGridViewCell dgcVersion = new DataGridViewTextBoxCell();
            DataGridViewCell dgcRequired = new DataGridViewTextBoxCell();
            DataGridViewCell dgcDownload = new DataGridViewButtonCell();
            dgcAppname.Value = appName;
            dgcAppType.Value = appType;
            if(appType != "dll")
            dgcLocation.Value = appLocation + appName + ".exe";
            else
                dgcLocation.Value = appLocation + appName + ".dll";
            dgcVersion.Value = appVersion;
            dgcRequired.Value = appRequired;
            dgcDownload.Value = "Download";
            try
            {
                if (tempPkg.isInstalled())
                {
                    dgcDownload.Value = "Installed";


                }
                else
                {
               
                    dgcDownload.ToolTipText = downloadurl;
                }
            }
            catch
            {
             
              
                
            }
                dgrApp.Cells.Add(dgcAppname);
            dgrApp.Cells.Add(dgcAppType);
            dgrApp.Cells.Add(dgcLocation);
            dgrApp.Cells.Add(dgcVersion);
            dgrApp.Cells.Add(dgcRequired);
            dgrApp.Cells.Add(dgcDownload);

            dgPrograms.Rows.Add(dgrApp);



        }

        private void dgPrograms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 2)
            {
                OpenFileDialog programSelect = new OpenFileDialog();
                programSelect.InitialDirectory = dgPrograms[e.ColumnIndex, e.RowIndex].Value.ToString();
                programSelect.ShowDialog();
                if (programSelect.FileName != "")
                {
                    dgPrograms[e.ColumnIndex, e.RowIndex].Value = programSelect.FileName;

                    Package tempProgram = (Package)programs[dgPrograms[0, e.RowIndex].Value.ToString()];
                    tempProgram.setCustomPath((programSelect.FileName.ToString()));
                    programs.Remove(dgPrograms[0, e.RowIndex].Value.ToString());
                    programs.Add(dgPrograms[0, e.RowIndex].Value.ToString(), tempProgram);
                }


            }


            
            if (e.ColumnIndex == 5 && dgPrograms[e.ColumnIndex, e.RowIndex].Value.ToString() != "Installed")
            {
                WebClient client = new WebClient();
                if (dgPrograms[0, e.RowIndex].Value.ToString().Contains("MkvToolnix"))
                {
                    Download frmDownload = new Download(dgPrograms[e.ColumnIndex, e.RowIndex].ToolTipText, "", "exe");
                    frmDownload.Show();

                    frmDownload.startDownload();

                    
                }
                else if (dgPrograms[1, e.RowIndex].Value.ToString() == "dll")
                {
                    Package tempPackage = (Package)appSettings.htRequired["avs"];
                    Download frmDownload = new Download(dgPrograms[e.ColumnIndex, e.RowIndex].ToolTipText, tempPackage.getInstallPath() + dgPrograms[0, e.RowIndex].Value.ToString(), "dll");
                    frmDownload.Show();

                    frmDownload.startDownload();
                    //Download frmDownload;
                    //if(!Directory.Exists(appSettings.avspluginsDIR))
                    //{
                    //   frmDownload = new Download("http://www.gamerzzheaven.be/Avisynth_258.exe","", "exe");
                    //    frmDownload.Show();
                    //    frmDownload.startDownload();
                    //}

                  //frmDownload = new Download(dgPrograms[e.ColumnIndex, e.RowIndex].ToolTipText, appSettings.avspluginsDIR + "\\" + dgPrograms[0, e.RowIndex].Value.ToString(), "dll");
                  //  frmDownload.Show();

                  //  frmDownload.startDownload();
                }
                else
                {
                    Download frmDownload = new Download(dgPrograms[e.ColumnIndex, e.RowIndex].ToolTipText, "", "zip");
                    frmDownload.Show();

                    frmDownload.startDownload();

                }
             
           
             

                dgPrograms[e.ColumnIndex, e.RowIndex].Value = "Installed";
                dgPrograms[e.ColumnIndex, e.RowIndex].ToolTipText = "";
            }
            }

        private void AppManagement_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            appSettings.SavePackages();
        }
    }
}

