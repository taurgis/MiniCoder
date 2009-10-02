using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;


namespace x264_GUI_CS.General
{
    public class ProcessSettings
    {
        public bool abandon = false;
        public bool errflag = true;
        public int processPriority = 0;
        public string currProcess = "";

        public ProcessPriorityClass getPriority()
        {
            switch (processPriority)
            {
                case 0:
                    return ProcessPriorityClass.Idle;
                case 1:
                    return ProcessPriorityClass.BelowNormal;
                case 2:
                    return ProcessPriorityClass.Normal;
                case 3:
                    return ProcessPriorityClass.AboveNormal;
                case 4:
                    return ProcessPriorityClass.High;
                case 5:
                    return ProcessPriorityClass.RealTime;
                default:
                    return ProcessPriorityClass.Idle;


            }
            
        }
    }
}
