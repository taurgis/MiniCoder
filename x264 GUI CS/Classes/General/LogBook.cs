using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
namespace x264_GUI_CS
{
    public class LogBook
    {
        mainGUI mainFrame;

        string fileFilter = @"\.avs;\.txt;\.xml;\.vcf";

        public LogBook()
        {
        }
        public LogBook(mainGUI mainFrame)
        {
            this.mainFrame = mainFrame;
        }

        public void addLine(string message)
        {
          

            ListViewItem inputListItem = new ListViewItem();
            ListViewItem.ListViewSubItem statusSub = new ListViewItem.ListViewSubItem();


            
                inputListItem.Text = System.DateTime.Now.ToString("t");
            
            
            inputListItem.SubItems.Add(statusSub);
          
            statusSub.Text = message;
           
           
          mainFrame.lvLog.Items.Add(inputListItem);
          
        }


        public string getLog()
        {
            string logComplete ="";
            foreach (ListViewItem eachItem in mainFrame.lvLog.Items)
            {
                logComplete += eachItem.SubItems[1].Text + "\r\n";

            }
            return logComplete;
        }

        public void setInfoLabel(string info)
        {
            mainFrame.setMessage(info);
         
        }
        public void sendmail(x264_GUI_CS.General.FileInformation details, MiniCoder.General.ApplicationSettings dir)
        {
            if (MessageBox.Show("Seems an error happend! Do you want to send an errorreport?", "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                StreamWriter streamWriter = new StreamWriter(dir.tempDIR + "\\log.txt");
                streamWriter.Write(getLog());
                streamWriter.Close();
                
                using (FileStream stream = new FileStream("errorlog.zip", FileMode.Create, FileAccess.Write, FileShare.None, 1024, FileOptions.WriteThrough))
                {

                    FastZip fz = new FastZip();

                    fz.CreateZip(stream, dir.tempDIR, true, fileFilter, null);

                }
                
                MessageBox.Show("There is a file named \"errorlog.zip\' in \"My Documents\". Please add it as an attachment on your erroreport on sourceforge!");
                Process.Start("http://sourceforge.net/tracker/?func=add&group_id=280183&atid=1189049");
                
                
               // fz.CreateZip("errorlog.zip", dir.tempDIR, false, fileFilter);
                
                string test = Environment.SpecialFolder.Desktop.ToString();
                
            }

        
        }
        public void sendmail(MiniCoder.General.ApplicationSettings dir)
        {
            if (MessageBox.Show("Seems an error happend! Do you want to send an errorreport?", "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {

                StreamWriter streamWriter = new StreamWriter(dir.tempDIR + "\\log.txt");
                streamWriter.Write(getLog());
                streamWriter.Close();
                
                using (FileStream stream = new FileStream("errorlog.zip", FileMode.Create, FileAccess.Write, FileShare.None, 1024, FileOptions.WriteThrough))
                {

                    FastZip fz = new FastZip();

                    fz.CreateZip(stream, dir.tempDIR, true, fileFilter, null);

                }

                MessageBox.Show("There is a file named \"errorlog.zip\' in \"My Documents\". Please add it as an attachment on your erroreport on sourceforge!");
                Process.Start("http://sourceforge.net/tracker/?func=add&group_id=280183&atid=1189049");


                // fz.CreateZip("errorlog.zip", dir.tempDIR, false, fileFilter);

              //  string test = Environment.SpecialFolder.Desktop.ToString();
            }
        
        }
    }
}
