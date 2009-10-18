using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
