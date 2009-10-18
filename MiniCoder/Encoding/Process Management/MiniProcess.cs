using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace MiniCoder.Encoding.Process_Management
{
    public interface MiniProcess
    {
      
        void setFilename(string filename);
        void setArguments(string arguments);
        int startProcess();
        void initProcess();
        ProcessPriorityClass getPriority();
        void stdOutDisabled(Boolean stdout);
        void stdErrDisabled(Boolean err);
        Boolean getAbandonStatus();
        string getAdditionalOutput();
        void abandonProcess();
        void setPriority(int i);
    }
}
