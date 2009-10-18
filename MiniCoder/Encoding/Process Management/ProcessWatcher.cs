using System;
using System.Collections.Generic;
using System.Text;

namespace MiniCoder.Encoding.Process_Management
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
