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
