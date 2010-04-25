using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using MiniTech.MiniCoder.External;
namespace MiniTech.MiniCoder.Core.Managers
{
    public class ToolsManager
    {
        private static ToolsManager toolsmanager;
        private Applications tools;

        public ToolsManager()
        {
            tools = new Applications();
        }

        public SortedList<String, ExtApplication> getTools()
        {
            return tools.getTools();
        }

        public ExtApplication getTool(String name)
        {
            return tools.getTools()[name];
        }

        public void saveTools()
        {
            tools.SavePackages();
        }

        public static ToolsManager Instance
        {
            get
            {
                if (toolsmanager == null)
                    toolsmanager = new ToolsManager();

                return toolsmanager;
            }

            set
            {
                toolsmanager = value;
            }

        }
    }
}