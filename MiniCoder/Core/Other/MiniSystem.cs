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
using System.OS;
using System.Security.Principal;
using MiniTech.MiniCoder.Core.Languages;
using MiniTech.MiniCoder.GUI;
using System.Windows.Forms;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

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

                return string.Format("{0}{1} ({2}.{3}.{4}.{5})", OsInfo.GetOSName(), OsInfo.GetOSServicePack(), OsInfo.OSMajorVersion, OsInfo.OSMinorVersion, OsInfo.OSRevisionVersion, OsInfo.OSBuildVersion);
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
                return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) ? "Yes" : "No";
            }
            catch
            {
                return "Error fetching elevation.";
            }
        }

        public static string getRamSize()
        {
            ManagementObjectSearcher Search = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");

            foreach (ManagementObject Mobject in Search.Get())
            {
                double Ram_Bytes = (Convert.ToDouble(Mobject["TotalPhysicalMemory"]));
                return ((int)(Ram_Bytes / 1048576)).ToString() + " Mb";
            }
            return "";
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
                return utf8.GetString(webClient.DownloadData(
                "http://whatismyip.com/automation/n09230945.asp"));
            }
            catch
            {
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
            catch
            {
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
            try
            {
                return string.Format("{0}", OsInfo.DotNetVersionFormated(OsInfo.FormatDotNetVersion()));
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
                return string.Format("{0}", OsInfo.GetMOStuff("Win32_Processor"));
            }
            catch
            {
                return "Error fetching CPU info";
            }
        }
    }
}
