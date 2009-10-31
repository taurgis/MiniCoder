using System;
using System.Collections.Generic;
using System.Text;
using System.OS;
using System.Security.Principal;

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
            try
            {

                return "OS: " + string.Format("{0}{1} ({2}.{3}.{4}.{5})", OsInfo.GetOSName(), OsInfo.GetOSServicePack(), OsInfo.OSMajorVersion, OsInfo.OSMinorVersion, OsInfo.OSRevisionVersion, OsInfo.OSBuildVersion);
            }
            catch
            {
                return "Error get OS info.";
            }
        }
        public static string getElevation()
        {
            try
            {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) ? "Administrative Rights: Yes" : "Administrative Rights: No";
            }
            catch
            {
                return "Error fetching elevation.";
            }
            }

        public static string getDotNetFramework()
        {
            try
            {
                return "Latest .Net Framework installed " + string.Format("{0}", OsInfo.DotNetVersionFormated(OsInfo.FormatDotNetVersion()));
            }
            catch
            {
                return "Error fetching .NET Framework.";
            }
        }
        public static string getProcessorInfo()
        {
            try
            {
                return "CPU : " + string.Format("{0}", OsInfo.GetMOStuff("Win32_Processor"));
            }
            catch
            {
                return "Error fetching CPU info";
            }
        }
    }
}
