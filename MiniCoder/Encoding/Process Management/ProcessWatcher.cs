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

namespace MiniTech.MiniCoder.Encoding.Process_Management
{
   public class ProcessWatcher
    {
        MiniProcess proc;
        int priority = 0;
        bool abandonStatus = false;
        public ProcessWatcher()
        {
       
        }
        public void abandon()
        {
            abandonStatus = true;
        }

        public void Activate()
        {
            abandonStatus = false;
        }
        public void setProcess(MiniProcess proc)
        {
           
            this.proc = proc;
            proc.setPriority(priority);
            if (abandonStatus)
            {
                proc.abandonProcess();
            }
        }

        public MiniProcess getProcess()
        {
            return proc;
        }

        public void setPriority(int i)
        {
            try
            {
                this.priority = i;
                proc.setPriority(i);


            }
            catch
            {
            }
        }
    }
}
