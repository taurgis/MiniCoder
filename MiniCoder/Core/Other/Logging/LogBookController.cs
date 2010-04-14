using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using MiniTech.MiniCoder.GUI;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Minitech.MiniCoder.Core.Other.Logging.Reports;
using MiniTech.MiniCoder.Core.Languages;
using System.Diagnostics;
namespace MiniTech.MiniCoder.Core.Other.Logging
{
    public sealed class LogBookController
    {
        private static MainForm mainForm;
        private static LogBookController instance = null;
        private Hashtable categories;
        private LogBook logbook;

        public LogBookController()
        {
            mainForm = (MainForm)Application.OpenForms["MainForm"];
            categories = new Hashtable();
            logbook = new LogBook("http://sourceforge.net/tracker/?func=add&group_id=280183&atid=1189049");

            createCategories();
        }

        public static LogBookController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogBookController();
                }
                return instance;
            }
        }

        public void addLogLine(string message, LogMessageCategories category)
        {
            LogMessageCategory cat = (LogMessageCategory)categories[category];
            mainForm.updateText(new LogMessage(message, cat));
        }

        public void viewLog()
        {
            Process.Start(ReportController.generateDocument(logbook));
        }

        public void setInfoLabel(string message)
        {
            mainForm.setInfoLabel(message);
        }

        public void sendmail()
        {
            if (MessageBox.Show(LanguageController.Instance.getLanguageString("errorWarningMessage"), LanguageController.Instance.getLanguageString("errorWarningTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                if (File.Exists(Application.StartupPath + "\\temp\\" + "\\log.doc"))
                    File.Delete(Application.StartupPath + "\\temp\\" + "\\log.doc");

                File.Copy(ReportController.generateDocument(logbook), Application.StartupPath + "\\temp\\" + "\\log.doc");

                createZip();

                MessageBox.Show("There is a file named \"errorlog.zip\' in \"My Documents\". Please add it as an attachment on your erroreport on sourceforge!");
                Process.Start("http://sourceforge.net/tracker/?func=add&group_id=280183&atid=1189049");
            }
        }

        private void createZip()
        {
            string fileFilter = @"\.avs;\.txt;\.xml;\.vcf;\.doc";
            using (FileStream stream = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\errorlog.zip", FileMode.Create, FileAccess.Write, FileShare.None, 1024, FileOptions.WriteThrough))
            {
                FastZip tempZip = new FastZip();
                tempZip.CreateZip(stream, Application.StartupPath + "\\temp\\", true, fileFilter, null);
            }
        }

        private void createCategories()
        {
            LogMessageCategory systemInfo = new LogMessageCategory("System Info");
            LogMessageCategory errors = new LogMessageCategory("Errors");
            LogMessageCategory encodes = new LogMessageCategory("Video");
            LogMessageCategory debug = new LogMessageCategory("Debug");

            categories.Add(LogMessageCategories.Info, systemInfo);
            categories.Add(LogMessageCategories.Error, errors);
            categories.Add(LogMessageCategories.Video, encodes);
            categories.Add(LogMessageCategories.Debug, debug);


            logbook.addCategory(systemInfo);
            logbook.addCategory(errors);
            logbook.addCategory(encodes);
            logbook.addCategory(debug);
        }
    }
}
