using System;
using System.Collections.Generic;
using System.Text;
using System.OS;


namespace System
{
    public static class MiniSystem
    {
        public static bool is64bit()
        {
            if (IntPtr.Size == 8)
                return true;
            else
                return false;
        }

        public static string getOSName()
        {

            return "OS: " + string.Format("{0}{1} ({2}.{3}.{4}.{5})", OsInfo.GetOSName(), OsInfo.GetOSServicePack(), OsInfo.OSMajorVersion, OsInfo.OSMinorVersion, OsInfo.OSRevisionVersion, OsInfo.OSBuildVersion);

        }

        public static string getDotNetFramework()
        {
            return "Latest .Net Framework installed " + string.Format("{0}", OsInfo.DotNetVersionFormated(OsInfo.FormatDotNetVersion()));
            
        }
        public static string getProcessorInfo()
        {

            return "CPU : " + string.Format("{0}", OsInfo.GetMOStuff("Win32_Processor"));
        }
    }
}
