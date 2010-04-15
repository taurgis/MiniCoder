using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MiniTech.MiniCoder.Core.Managers
{
    public sealed class LocationManager
    {
        private static String tempFolder = Application.StartupPath + "\\temp\\";

        public static String TempFolder
        {
            get
            {
                return tempFolder;
            }

            set
            {
                tempFolder = value;
            }
        }
    }
}
