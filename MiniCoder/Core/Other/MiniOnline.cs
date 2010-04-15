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

using System.IO;
using System.Net;
using System.Windows.Forms;

namespace System
{
    public static class MiniOnline
    {
        public static void GetNews(ListView list)
        {
            String news = GetText("http://www.gamerzzheaven.be/news.txt");
            String[] newsItems = news.Split(Char.Parse("\n"));

            for (int i = 0; i < newsItems.Length; i++)
            {
                string[] newsItem = newsItems[i].Split(Char.Parse(";"));

                list.Items.Add(createListItem(newsItem[0], newsItem[1], newsItem[2]));
            }
        }

        private static ListViewItem createListItem(String date, String message, String url)
        {
            ListViewItem newsItem = new ListViewItem();
            ListViewItem.ListViewSubItem newsMessage = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem newsUrl = new ListViewItem.ListViewSubItem();

            newsItem.SubItems[0].Text = date;
            newsMessage.Text = message;
            newsUrl.Text = url;

            newsItem.SubItems.Add(newsMessage);
            newsItem.SubItems.Add(newsUrl);

            return newsItem;
        }

        private static string GetText(string url)
        {
            WebResponse response = WebRequest.Create((url)).GetResponse();
      
            return StringFromResponse(response);
        }

        private static string StringFromResponse(WebResponse response)
        {
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}
