using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MiniCoder
{

    public static class Provider
    {
        private static DummyProvider provider = new DummyProvider();

        public static DummyProvider getProvider()
        {
            return provider;
        }
    }

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

    public class DummyProvider : IFormatProvider
    {
        // Normally, GetFormat returns an object of the requested type
        // (usually itself) if it is able; otherwise, it returns Nothing. 
        public object GetFormat(Type argType)
        {
            // Here, GetFormat displays the name of argType, after removing 
            // the namespace information. GetFormat always returns null.
            string argStr = argType.ToString();
            if (argStr == "")
                argStr = "Empty";
            argStr = argStr.Substring(argStr.LastIndexOf('.') + 1);

            Console.Write("{0,-20}", argStr);
            return null;
        }
    }

}

