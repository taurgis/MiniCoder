using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using MiniTech.MiniCoder.GUI;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
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

        public void createCategory(String categoryName, String parent)
        {
            LogMessageCategory cat = new LogMessageCategory(categoryName);
            LogMessageCategory parentCat = (LogMessageCategory)categories[parent];
            parentCat.addSubCategory(cat);
            categories.Add(categoryName, cat);
        }

        public void addLogLine(string message, LogMessageCategories category)
        {
            LogMessageCategory cat = (LogMessageCategory)categories[category];
            mainForm.updateText(new LogMessage(message, cat));
        }

        public void setInfoLabel(string message)
        {
            mainForm.setInfoLabel(message);
        }

        public void sendmail()
        {
            /*
                        if (MessageBox.Show(LanguageController.Instance.getLanguageString("errorWarningMessage"), LanguageController.Instance.getLanguageString("errorWarningTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\temp\\" + "\\log.txt");

                            streamWriter.Close();

                            createZip();

                            MessageBox.Show("There is a file named \"errorlog.zip\' in \"My Documents\". Please add it as an attachment on your erroreport on sourceforge!");
                            Process.Start("http://sourceforge.net/tracker/?func=add&group_id=280183&atid=1189049");
                        }
             */
        }

        private void createZip()
        {
            string fileFilter = @"\.avs;\.txt;\.xml;\.vcf";
            using (FileStream stream = new FileStream("errorlog.zip", FileMode.Create, FileAccess.Write, FileShare.None, 1024, FileOptions.WriteThrough))
            {
                new FastZip().CreateZip(stream, Application.StartupPath + "\\temp\\", true, fileFilter, null);
            }
        }


    }
}
