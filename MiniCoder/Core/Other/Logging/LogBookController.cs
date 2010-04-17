//    MiniCoder
//    Copyright (C) 2009-2010  MiniTech support@minitech.org
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using Minitech.MiniCoder.Core.Other.Logging.Reports;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.GUI;

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
            if (!String.IsNullOrEmpty(message))
            {
                LogMessageCategory cat = (LogMessageCategory)categories[category];

                if (message.Contains("\r\n"))
                {
                    String[] splitMessage = message.Split('\n');

                    foreach(String mes in splitMessage)
                        mainForm.updateText(new LogMessage(mes.Replace("&", "&amp;"), cat));
                }
                else
                    mainForm.updateText(new LogMessage(message.Replace("&", "&amp;"), cat));
            }
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
                ReportController.createTextDocument(logbook);
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
