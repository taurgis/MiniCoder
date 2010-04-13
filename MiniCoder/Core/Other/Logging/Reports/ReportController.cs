﻿using System;
using System.Collections.Generic;
using System.Text;
using MiniTech.MiniCoder.Core.Other.Logging;
using System.IO;
namespace Minitech.MiniCoder.Core.Other.Logging.Reports
{
    public class ReportController
    {
        public static String generateDocument(LogBook logbook)
        {
            String path = Path.GetTempPath() + "tempReport.doc";

            StreamReader reader = new StreamReader("reports/errortemplate.xml");

            String text = reader.ReadToEnd();

            text = replaceHeaderDate(text);
            text = replaceComputerInfo(text);
            text = replaceLogMessages(text, logbook);

            if (saveLogFile(text,path))
                return path;
            else
                return "";
        }

        private static Boolean saveLogFile(String text, String path)
        {
            try
            {
                StreamWriter writer = new StreamWriter(path);
                writer.Write(text);
                writer.Close();

                return true;
            }
            catch (IOException ex)
            {
                LogBookController.Instance.addLogLine("Error saving logfile. Is it currently open?" +"\n" + ex, LogMessageCategories.Error);
                return false;
            }
        }

        private static String replaceLogMessages(String text, LogBook logbook)
        {
            String trTemplate = new StreamReader("reports/tr.txt").ReadToEnd();
            foreach (LogMessageCategory cat in logbook.categories)
            {
                String strToReplace = "";
                switch (cat.categoryName)
                {
                    case "Video":
                        strToReplace = "${videoerrors}";
                        break;
                    case "Errors":
                        strToReplace = "${exceptions}";
                        break;
                    case "Debug":
                        strToReplace = "${debug}";
                        break;
                    default:
                        strToReplace = "${notsupportedyet}";
                        break;
                }
                String completeTable = " ";

                foreach (LogMessage message in cat.messages)
                {
                    String tempTr = trTemplate;
                    tempTr = tempTr.Replace("${errorid}", message.logId.ToString());
                    tempTr = tempTr.Replace("${errortime}", message.time.ToString());
                    tempTr = tempTr.Replace("${errormessage}", message.message);
                    completeTable += tempTr;
                }
                text = text.Replace(strToReplace, completeTable);
            }

            return text;
        }

        private static String replaceHeaderDate(String text)
        {
            while (text.Contains("${Current Date}"))
                text = text.Replace("${Current Date}", DateTime.Now.ToLongDateString().ToUpperInvariant());


            return text;
        }

        private static String replaceComputerInfo(String text)
        {
            text = text.Replace("${operatingsystem}", MiniSystem.getOSName());
            text = text.Replace("${processor}", MiniSystem.getProcessorInfo());
            text = text.Replace("${framework}", MiniSystem.getDotNetFramework());
            text = text.Replace("${admin}", MiniSystem.getElevation());
            text = text.Replace("${ram}", MiniSystem.getRamSize());
            text = text.Replace("${machinename}", MiniSystem.getMachineName());
            text = text.Replace("${domain}", MiniSystem.getDomain());
            text = text.Replace("${processorcount}", MiniSystem.getProcessorCount());
            text = text.Replace("${uptime}", MiniSystem.getUptime());
            text = text.Replace("${username}", MiniSystem.getCurrentUser());
            text = text.Replace("${systemdir}", MiniSystem.getSystemDirectory());
            text = text.Replace("${curdir}", MiniSystem.getCurrentDirectory());
            text = text.Replace("${shutdown}", MiniSystem.isShuttingDown());
            text = text.Replace("${mappedmem}", MiniSystem.getMappedMemory());
            text = text.Replace("${localip}", MiniSystem.getIpAddress());
            text = text.Replace("${realip}", MiniSystem.GetExternalIp().ToString());
            text = text.Replace("${internet}", MiniSystem.isConnected());

            return text;
        }

    }
}
