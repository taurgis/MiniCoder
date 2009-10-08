using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace MiniCoder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        // file type to register
       

        // context menu name in the registry
        const string KeyName = "MiniCoder";

        // context menu text
        const string MenuText = "Encode With MiniCoder";
      
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainGUI tempGui = new mainGUI();
           
            Application.Run(tempGui);
           
        }

    }

}
