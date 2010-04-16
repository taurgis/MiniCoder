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
using MiniTech.MiniCoder.Core.Other.Logging;
using MiniTech.MiniCoder.Encoding.Process_Management;

namespace MiniTech.MiniCoder.Core.Managers
{
    public sealed class ProcessManager
    {
        public static Boolean hasProcessExitedCorrectly(MiniProcess proc, int exitCode)
        {
            if (proc.getAbandonStatus())
            {
                LogBookController.Instance.addLogLine("Process stopped.", LogMessageCategories.Video);
                
                return false;
            }

            if (exitCode != 0)
            {
                LogBookController.Instance.addLogLine("Process exited incorrectly.", LogMessageCategories.Video);

                return false;
            }

            return true;
        }
    }
}
