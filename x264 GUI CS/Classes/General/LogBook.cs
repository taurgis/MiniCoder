using System;
using System.Collections.Generic;

using System.Text;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.IO;
namespace x264_GUI_CS
{
    class LogBook
    {
        mainGUI mainFrame;
   

        public LogBook(mainGUI mainFrame)
        {
            this.mainFrame = mainFrame;
        }

        public void addLine(string message)
        {
          

            ListViewItem inputListItem = new ListViewItem();
            ListViewItem.ListViewSubItem statusSub = new ListViewItem.ListViewSubItem();



            inputListItem.Text = System.DateTime.Now.TimeOfDay.Hours.ToString() + ":" + System.DateTime.Now.TimeOfDay.Minutes.ToString();
            
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
        public void sendmail(x264_GUI_CS.General.FileInformation details)
        {
            if (MessageBox.Show("Seems an error happend! Do you want to send an errorreport?", "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {

                var fromAddress = new MailAddress("x264errorreporter@gmail.com", "X264 errorreporter");
                var toAddress = new MailAddress("x264errorreporter@gmail.com", "Errorreporter");
                const string fromPassword = "wiske123";
                const string subject = "ErrorReporting";
                Attachment attach;
                
                   
                
                string body = details.completeinfo + "\n" + getLog();
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    
                    
                })
                {
                    if (File.Exists(details.avsFile))
                    {
                        attach = new Attachment(details.avsFile);
                        message.Attachments.Add(attach);
                    }
                    smtp.Send(message);
                    
                }
            }
            StreamWriter strw = new StreamWriter(details.outDIR + "Minicoder_crashlog.txt");
            strw.Write(getLog());
            strw.Close();
            
            //MessageBox.Show("Closing Application to prevent further errors!");
            //Application.Exit();


        
        }
        public void sendmail()
        {
            if (MessageBox.Show("Seems an error happend! Do you want to send an errorreport?", "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {

                var fromAddress = new MailAddress("x264errorreporter@gmail.com", "X264 errorreporter");
                var toAddress = new MailAddress("x264errorreporter@gmail.com", "Errorreporter");
                const string fromPassword = "wiske123";
                const string subject = "ErrorReporting";
                string body = getLog();
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
        
        }
    }
}
