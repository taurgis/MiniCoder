//    MiniCoder
//    Copyright (C) 2009-2010  MiniTech support@minitech.org
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Softwasre Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.OS;
using System.Security.Principal;
using System.Text;
using MiniTech.MiniCoder.Core.Other.Logging;

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
            return string.Format("{0}{1} ({2}.{3}.{4}.{5})", OsInfo.GetOSName(), OsInfo.GetOSServicePack(), OsInfo.OSMajorVersion, OsInfo.OSMinorVersion, OsInfo.OSRevisionVersion, OsInfo.OSBuildVersion);
        }

        public static string getElevation()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) ? "Yes" : "No";
        }

        public static string getRamSize()
        {
            ManagementObjectSearcher Search = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");

            foreach (ManagementObject Mobject in Search.Get())
            {
                double Ram_Bytes = (Convert.ToDouble(Mobject["TotalPhysicalMemory"]));

                return ((int)(Ram_Bytes / 1048576)).ToString() + " Mb";
            }

            return String.Empty;
        }

        public static string getCurrentUser()
        {
            return Environment.UserName;
        }

        public static string getIpAddress()
        {
            IPHostEntry ip = Dns.GetHostEntry(Dns.GetHostName());
            String allIps = "";

            foreach (IPAddress address in ip.AddressList)
            {
                if (!address.IsIPv6SiteLocal && !address.IsIPv6LinkLocal && !address.IsIPv6Multicast && !(address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6))
                    allIps += address.ToString() + "\n\r";
            }

            return allIps;
        }

        public static String GetExternalIp()
        {
            try
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                WebClient webClient = new WebClient();

                return utf8.GetString(webClient.DownloadData("http://whatismyip.com/automation/n09230945.asp"));
            }
            catch (WebException ex)
            {
                LogBookController.Instance.addLogLine("Error connecting to whatismyip. \r\n" + ex, LogMessageCategories.Error);
                return "Unknown";
            }
        }

        public static string isConnected()
        {
            try
            {
                Ping ping = new Ping();
                PingReply pingreply = ping.Send(IPAddress.Parse("74.125.77.147"));
                return "Yes";
            }
            catch (PingException ex)
            {
                LogBookController.Instance.addLogLine("Error pinging google. \r\n" + ex, LogMessageCategories.Error);

                return "No";
            }
        }

        public static string getMachineName()
        {
            return Environment.MachineName;
        }

        public static string getSystemDirectory()
        {
            return Environment.SystemDirectory;

        }

        public static string getCurrentDirectory()
        {
            return Environment.CurrentDirectory;
        }

        public static string isShuttingDown()
        {
            return Environment.HasShutdownStarted.ToString();
        }

        public static string getMappedMemory()
        {
            return (Environment.WorkingSet / 1048576).ToString() + " Mb";
        }

        public static string getDomain()
        {
            return Environment.UserDomainName;
        }

        public static string getProcessorCount()
        {
            return Environment.ProcessorCount.ToString();
        }

        public static string getUptime()
        {
            return (Environment.TickCount / 60000).ToString() + " minutes";
        }

        public static string getDotNetFramework()
        {
            return string.Format("{0}", OsInfo.DotNetVersionFormated(OsInfo.FormatDotNetVersion()));
        }

        public static string getProcessorInfo()
        {
            return string.Format("{0}", OsInfo.GetMOStuff("Win32_Processor"));
        }
    }
}
