using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace x264_GUI_CS
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
            if (args.Length != 0)
            {
                // invoked from shell, process the selected file
                CopyGrayscaleImage(args, tempGui);
            }
            Application.Run(tempGui);
           
        }

       
      static bool ProcessCommand(string[] args)
        {
            // register
            if (args.Length == 0 || string.Compare(args[0], "-unregister", true) == 0)
            {
                // full path to self, %L is placeholder for selected file
                

            
                return true;
            }

            // unregister		
            if (string.Compare(args[0], "-register", true) == 0)
            {
                // unregister the context menu
         //      Shell.FileShellExtension.Unregister(Program.FileType, Program.KeyName);

                MessageBox.Show(string.Format(
                    "The {0} shell extension was unregistered.",
                    Program.KeyName), Program.KeyName);

                return true;
            }

            // command line did not contain an action
            return false;
        }

        /// <summary>
        /// Make a grayscale copy of the image.
        /// </summary>
        /// <param name="filePath">Full path to the image to copy.</param>
        static void CopyGrayscaleImage(string[] filePath, mainGUI tempg)
        {
            tempg.addFIles(filePath);
        }
    }

}
