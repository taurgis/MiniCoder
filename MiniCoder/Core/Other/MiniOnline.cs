using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.GUI;
using System.Windows.Forms;
using System.Net;
using System.IO;
namespace System
{
    public static class MiniOnline
    {
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
}
