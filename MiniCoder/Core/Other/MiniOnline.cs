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
using System.Collections.Generic;
using System.Text;
using MiniTech.MiniCoder.GUI;
using System.Windows.Forms;
using System.Net;
using System.IO;
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

        public static void clearIECache()
        {
            ClearFolder(new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)));
        }

       private static void ClearFolder(DirectoryInfo folder)
        {
            foreach (FileInfo file in folder.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch
                {
                }
            }
            foreach (DirectoryInfo subfolder in folder.GetDirectories())
            { ClearFolder(subfolder); }
        } 
    }
}
