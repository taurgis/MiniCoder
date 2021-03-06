﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.ApplicationManager
{
    public static class ApplicationControl
    {
        
        public static String GetPath(int ApplicationIndex)
        {
            switch (ApplicationIndex)
            {
                case 0:
                    return @"\AviSyth";
                case 1:
                    return @"\Besweet";
                case 2:
                    return @"\MKVToolnix";
                case 3:
                    return @"\MP4Box";
                case 4:
                    return @"\X264";
                default:
                    return @"\";
            }
        }

        public static String ApplicationRefrence(int ApplicationIndex)
        {
            switch (ApplicationIndex)
            {
                case 0:
                    return "X264";
                case 1:
                    return "AviSyth";
                case 2:
                    return "Besweet";
                case 3:
                    return "MKVToolnix";
                case 4:
                    return "MP4Box";
                default:
                    return "";
            }
        }
    }
}
