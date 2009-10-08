using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MiniCoder
{
    public static class Startup
    {
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        static extern int GetDiskFreeSpaceEx(
         string lpDirectoryName,
         out ulong lpFreeBytesAvailable,
         out ulong lpTotalNumberOfBytes,
         out ulong lpTotalNumberOfFreeBytes);

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

        public static ulong getFreeSpace(string disk)
        {
            ulong freeBytesAvailable, totalBytes, freeBytes;
            GetDiskFreeSpaceEx(disk, out freeBytesAvailable, out totalBytes, out freeBytes);
            return freeBytes;
        }
    }
}

