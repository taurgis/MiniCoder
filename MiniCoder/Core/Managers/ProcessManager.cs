using System;
using System.Collections.Generic;
using System.Text;
using MiniTech.MiniCoder.Encoding.Process_Management;
namespace MiniTech.MiniCoder.Core.Managers
{
    public sealed class ProcessManager
    {
        public static Boolean hasProcessExitedCorrectly(MiniProcess proc, int exitCode)
        {
            if (proc.getAbandonStatus())
                return false;

            if (exitCode != 0)
                return false;

            return true;
        }
    }
}
