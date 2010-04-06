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
using System.Xml;
namespace MiniCoder.External
{
    public interface Tool
    {
        void setCustomPath(string path);
        Boolean isInstalled();
        string getCategory();
        string getAppType();
        string getCustomPath();
        string getInstallPath();
        string getDownloadPath();
        string localVersion { get; set; }
        string onlineVersion { get; set; }
        string registrySubpath { get; set; }
        string registrySubKey { get; set; }
        Boolean download();
        void getOnlineVersion(XmlDocument doc);
    }
}
