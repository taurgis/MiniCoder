using System;
using System.Collections.Generic;
using System.Text;

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
        void download();
    }
}
