using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x264_GUI_CS.Classes.General
{
    class ShellActions
    {
        // file type to register
        const string FileType = "avifile";

        // context menu name in the registry
        const string KeyName = "MiniCoder";

        // context menu text
        const string MenuText = "Encode With MiniCoder";

        [STAThread]
        static void Main(string[] args)
        {
            // process register or unregister commands
            if (!ProcessCommand(args))
            {
                // invoked from shell, process the selected file
                CopyGrayscaleImage(args[0]);
            }
        }

        /// <summary>
        /// Process command line actions (register or unregister).
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>True if processed an action in the command line.</returns>
        static bool ProcessCommand(string[] args)
        {
            // register
            if (args.Length == 0 || string.Compare(args[0], "-unregister", true) == 0)
            {
                // full path to self, %L is placeholder for selected file
                string menuCommand = string.Format(
                    "\"{0}\" \"%L\"", Application.ExecutablePath);

                // register the context menu
                FileShellExtension.Register(Program.FileType,
                    Program.KeyName, Program.MenuText,
                    menuCommand);

                MessageBox.Show(string.Format(
                    "The {0} shell extension was registered.",
                    Program.KeyName), Program.KeyName);

                return true;
            }

            // unregister		
            if (string.Compare(args[0], "-register", true) == 0)
            {
                // unregister the context menu
                FileShellExtension.Unregister(Program.FileType, Program.KeyName);

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
        static void CopyGrayscaleImage(string[] filePath)
        {
           
        }
    }
}
