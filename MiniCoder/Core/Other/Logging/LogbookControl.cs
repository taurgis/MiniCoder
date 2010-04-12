using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MiniTech.MiniCoder.Core.Other.Logging
{
    public partial class LogbookControl : UserControl
    {
        public LogbookControl()
        {
            InitializeComponent();
        }


        public void addLogMessage(LogMessage message)
        {
            String time = message.time.Hour + ":" + message.time.Minute;

            switch (message.category.categoryName)
            {
                case "System Info":
                    sysInfo.addLine(time + " - " + message.message);
                    break;
                case "Errors":
                    errorInfo.addLine(time + " - " + message.message);
                    break;
                case "Debug":
                    debugInfo.addLine(time + " - " + message.message);
                    break;
                case "Video":
                    videoInfo.addLine(time + " - " + message.message);
                    break;
            }
        }

        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogBookController.Instance.viewLog();
        }
    }
}
