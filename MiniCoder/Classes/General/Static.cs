using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using System.Net;
namespace MiniCoder
{


    public static class Encoding
    {
        public static Boolean DeleteFiles(ApplicationSettings appSettings)
        {
            string[] files = Directory.GetFiles(appSettings.tempDIR);
            try
            {
                foreach (string file in files)
                    File.Delete(file);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static FileInformation mediainfo(string fileName, int crf)
        {
            //infoLabel.Text = "Gathering Media Info";

            IfMediaDetails temp;
            if (IntPtr.Size == 8)
                temp = new MediaDetails64();
            else
                temp = new MediaDetails32();

            FileInformation tempDetail = new FileInformation();

            tempDetail.fileName = temp.fileName(fileName);
            tempDetail.fileSize = temp.fileSize(fileName);
            tempDetail.format = temp.fileFormat(fileName);
            tempDetail.name = temp.name(fileName);
            tempDetail.ext = temp.fileExt(fileName);
            tempDetail.outDIR = Path.GetDirectoryName(tempDetail.fileName) + "\\";
            tempDetail.crfValue = crf;
            tempDetail.audioCount = temp.audioCount(fileName);
            tempDetail.aud_Languages = temp.audLanguage(fileName);
            if (tempDetail.ext != ".avi")
                tempDetail.aud_id = temp.audID(fileName);
            tempDetail.aud_codec = temp.audCodec(fileName);
            tempDetail.audLength = (int)(temp.audLength(fileName) / 1000);
            tempDetail.audTitles = temp.audTitle(fileName);
            tempDetail.completeinfo = temp.completeInfo(fileName);
            if (tempDetail.ext.ToUpper() == ".VOB")
                tempDetail.audBitrate = temp.audBitrate(fileName);

            tempDetail.width = temp.width(fileName);
            tempDetail.height = temp.height(fileName);
            tempDetail.fps = temp.fps(fileName);
            tempDetail.vid_codec = temp.vidCodec(fileName);
            tempDetail.framecount = temp.frameCount(fileName);
            //     tempDetail.frameType = temp.frameRateType(fileName);
            tempDetail.subCount = temp.subCount(fileName);
            if (tempDetail.subCount != 0)
            {
                tempDetail.sub_Titles = temp.subCaption(fileName);
                tempDetail.sub_id = temp.subID(fileName);
                tempDetail.sub_codec = temp.subCodec(fileName);
                tempDetail.sub_lang = temp.subLang(fileName);
            }
            tempDetail.chapters = temp.chapters(fileName);
            tempDetail.vfrCode = null;
            tempDetail.vfrName = null;

           // infoLabel.Text = "";
            return tempDetail;
        }
    }

    public static class Provider
    {
        private static DummyProvider provider = new DummyProvider();

        public static DummyProvider getProvider()
        {
            return provider;
        }
    }

    public static class Startup
    {
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        static extern int GetDiskFreeSpaceEx(
         string lpDirectoryName,
         out ulong lpFreeBytesAvailable,
         out ulong lpTotalNumberOfBytes,
         out ulong lpTotalNumberOfFreeBytes);

        


        public static bool checkInternet()
        {
            try
            {
                System.Net.IPHostEntry objIPHE = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch
            {
                return false; // host not reachable.
            }
        }

        public static long getFreeSpace(string disk)
        {
            ulong freeBytesAvailable, totalBytes, freeBytes;
            GetDiskFreeSpaceEx(disk, out freeBytesAvailable, out totalBytes, out freeBytes);
            return Convert.ToInt64(freeBytes, Provider.getProvider());
        }

        public static void GetNews(ListView list)
        {
            String news = GetText("http://www.gamerzzheaven.be/news.txt");
           
           String[] newsItems = news.Split(Char.Parse("\n"));
           for (int i = 0; i < newsItems.Length; i++)
           {
               string[] newsItem = newsItems[i].Split(Char.Parse(";"));
               ListViewItem temp = new ListViewItem();
               ListViewItem.ListViewSubItem newsMessage = new ListViewItem.ListViewSubItem();
               ListViewItem.ListViewSubItem newsUrl = new ListViewItem.ListViewSubItem();
               temp.SubItems[0].Text = newsItem[0];
               newsMessage.Text = newsItem[1];
               newsUrl.Text = newsItem[2];

               temp.SubItems.Add(newsMessage);
               temp.SubItems.Add(newsUrl);
               list.Items.Add(temp);
           }
          

        }

        private static string GetText(string url)
        {
            WebRequest req = WebRequest.Create((url));

            WebResponse response = req.GetResponse();
            return StringFromResponse(response);
        }
        private static string StringFromResponse(WebResponse response)
        {
            String url = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return url;
        }

    }

    public class DummyProvider : IFormatProvider
    {
        // Normally, GetFormat returns an object of the requested type
        // (usually itself) if it is able; otherwise, it returns Nothing. 
        public object GetFormat(Type argType)
        {
            // Here, GetFormat displays the name of argType, after removing 
            // the namespace information. GetFormat always returns null.
            string argStr = argType.ToString();
            if (argStr == "")
                argStr = "Empty";
            argStr = argStr.Substring(argStr.LastIndexOf('.') + 1);

            //Console.Write("{0,-20}", argStr);
            return null;
        }
    }

}

