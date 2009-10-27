using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using QuartzTypeLib;

namespace DirectShow
{
	/// <summary>
	/// Zusammendfassende Beschreibung f�r Form1.
	/// </summary>
    public class Preview : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.ComponentModel.IContainer components;

        private const int WM_APP = 0x8000;
        private const int WM_GRAPHNOTIFY = WM_APP + 1;
        private const int EC_COMPLETE = 0x01;
        private const int WS_CHILD = 0x40000000;
        private const int WS_CLIPCHILDREN = 0x2000000;

        private FilgraphManager m_objFilterGraph = null;
        private IBasicAudio m_objBasicAudio = null;
        private IVideoWindow m_objVideoWindow = null;
        private IMediaEvent m_objMediaEvent = null;
        private IMediaEventEx m_objMediaEventEx = null;
        private IMediaPosition m_objMediaPosition = null;
        private IMediaControl m_objMediaControl = null;

        enum MediaStatus { None, Stopped, Paused, Running };

        private MediaStatus m_CurrentStatus = MediaStatus.None;

        public Preview()
        {
            //
            // Erforderlich f�r die Windows Form-Designerunterst�tzung
            //
            InitializeComponent();

            //
            // TODO: F�gen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
            //
            UpdateStatusBar();
            UpdateToolBar();
        }

        /// <summary>
        /// Die verwendeten Ressourcen bereinigen.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            CleanUp();
            
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

		#region Windows Form Designer generated code
        /// <summary>
        /// Erforderliche Methode f�r die Designerunterst�tzung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preview));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Red;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 424);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(442, 19);
            this.statusBar1.TabIndex = 2;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "Ready";
            this.statusBarPanel1.Width = 309;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "00:00:00";
            this.statusBarPanel2.Width = 58;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Text = "00:00:00";
            this.statusBarPanel3.Width = 58;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 424);
            this.panel1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Preview
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(442, 443);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Preview";
            this.Text = "DirectShow";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

        /// <summary>
        /// Der Haupteinstiegspunkt f�r die Anwendung.
    

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            
        }

        public void openFile(string filename)
        {
            CleanUp();

            m_objFilterGraph = new FilgraphManager();
            m_objFilterGraph.RenderFile(filename);

           
            try
            {
                m_objVideoWindow = m_objFilterGraph as IVideoWindow;
                m_objVideoWindow.Owner = (int)panel1.Handle;
                m_objVideoWindow.WindowStyle = WS_CHILD | WS_CLIPCHILDREN;
                m_objVideoWindow.SetWindowPosition(panel1.ClientRectangle.Left,
                    panel1.ClientRectangle.Top,
                    panel1.ClientRectangle.Width,
                    panel1.ClientRectangle.Height);
            }
            catch (Exception)
            {
                m_objVideoWindow = null;
            }
            
        
            m_objMediaEvent = m_objFilterGraph as IMediaEvent;

            m_objMediaEventEx = m_objFilterGraph as IMediaEventEx;
            m_objMediaEventEx.SetNotifyWindow((int)this.Handle, WM_GRAPHNOTIFY, 0);

            m_objMediaPosition = m_objFilterGraph as IMediaPosition;

            m_objMediaControl = m_objFilterGraph as IMediaControl;

            this.Text = "Preview - [" + filename + "]";
            m_objMediaControl.Run();
            m_objMediaControl.Pause();
            

            UpdateStatusBar();
            UpdateToolBar();
        }

        public void setPosition(int frame, int totalframes, string fps)
        {
            float newfps;
            if (float.Parse(fps) > 400)
                newfps = float.Parse(fps) /1000;
            else
                newfps = float.Parse(fps);

            int lengthSeconds = (int)(totalframes / newfps);
            double percentage = (Double)((Double)frame / (Double)totalframes);
            double currentsecond =((Double)lengthSeconds * (Double)percentage);
            
            m_objMediaControl.Run();

            
            m_objMediaPosition.CurrentPosition = currentsecond;
            m_objMediaControl.Pause();
            
            m_CurrentStatus = MediaStatus.Running;
        }

        private void CleanUp()
        {
            if (m_objMediaControl != null)
                m_objMediaControl.Stop();

            m_CurrentStatus = MediaStatus.Stopped;

            if (m_objMediaEventEx != null)
                m_objMediaEventEx.SetNotifyWindow(0, 0, 0);

            if (m_objVideoWindow != null)
            {
                m_objVideoWindow.Visible = 0;
                m_objVideoWindow.Owner = 0;
            }

            if (m_objMediaControl != null) m_objMediaControl = null;
            if (m_objMediaPosition != null) m_objMediaPosition = null;
            if (m_objMediaEventEx != null) m_objMediaEventEx = null;
            if (m_objMediaEvent != null) m_objMediaEvent = null;
            if (m_objVideoWindow != null) m_objVideoWindow = null;
            if (m_objBasicAudio != null) m_objBasicAudio = null;
            if (m_objFilterGraph != null) m_objFilterGraph = null;
        }

        private void menuItem4_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void Form1_SizeChanged(object sender, System.EventArgs e)
        {
            if (m_objVideoWindow != null)
            {
                m_objVideoWindow.SetWindowPosition(panel1.ClientRectangle.Left,
                    panel1.ClientRectangle.Top,
                    panel1.ClientRectangle.Width,
                    panel1.ClientRectangle.Height);
            }
        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
           
            
            UpdateStatusBar();
            UpdateToolBar();                        
        }

        protected override void WndProc( ref Message m)
        {
            if (m.Msg == WM_GRAPHNOTIFY)
            {
                int lEventCode;
                int lParam1, lParam2;

                while (true)
                {
                    try
                    {
                        m_objMediaEventEx.GetEvent(out lEventCode, 
                            out lParam1,
                            out lParam2,
                            0); 
 
                        m_objMediaEventEx.FreeEventParams(lEventCode, lParam1, lParam2);

                        if (lEventCode == EC_COMPLETE)
                        {
                            m_objMediaControl.Stop();
                            m_objMediaPosition.CurrentPosition = 0;
                            m_CurrentStatus = MediaStatus.Stopped;
                            UpdateStatusBar();
                            UpdateToolBar();
                        }
                    } 
                    catch (Exception)
                    {
                        break;
                    }
                }
            }

            base.WndProc(ref m);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (m_CurrentStatus == MediaStatus.Running)
            {
                UpdateStatusBar();
            }
        }

        private void UpdateStatusBar()
        {
            switch (m_CurrentStatus)
            {
                case MediaStatus.None   : statusBarPanel1.Text = "Stopped"; break;
                case MediaStatus.Paused : statusBarPanel1.Text = "Paused "; break;
                case MediaStatus.Running: statusBarPanel1.Text = "Running"; break;
                case MediaStatus.Stopped: statusBarPanel1.Text = "Stopped"; break;
            }

            if (m_objMediaPosition != null)
            {
                int s = (int) m_objMediaPosition.Duration;
                int h = s / 3600;
                int m = (s  - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);
                
                statusBarPanel2.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);

                s = (int) m_objMediaPosition.CurrentPosition;
                h = s / 3600;
                m = (s  - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);
                
                statusBarPanel3.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
            }
            else
            {
                statusBarPanel2.Text = "00:00:00";
                statusBarPanel3.Text = "00:00:00";
            }
        }

        private void UpdateToolBar()
        {
           
        }

        private void menuItem5_Click(object sender, System.EventArgs e)
        {
          
        }
    }
}
