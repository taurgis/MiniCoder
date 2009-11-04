using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.GUI;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Diagnostics;
using MiniCoder.Core.Languages;
namespace System
{
    public static class LogBook
    {
        static MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];
        public static void addLogLine(string message, string searchTag, string messageTag, bool error) 
        {
            try
            {
                if (!string.IsNullOrEmpty(message))
                    mainForm.addLogLine(message, searchTag, messageTag, false);
            }
            catch
            {

            }
        }

        public static TreeNode findNode(TreeView treeView, string tag)
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                TreeNode nodi = iterateNode(node, tag);
                if (nodi != null)
                    return nodi;

            }
            return null;
        }

        private static TreeNode iterateNode(TreeNode treeNode, string tag)
        {
           

            if (treeNode.Nodes.Count > 0)
            {
                if (treeNode.Tag.ToString() == tag)
                    return treeNode;

                foreach (TreeNode node in treeNode.Nodes)
                {
                    TreeNode nodi = iterateNode(node, tag);
                    if (nodi != null)
                        return nodi;
                }
                return null;

            }
            else
            {
                if(treeNode.Tag != null)
                if (treeNode.Tag.ToString() == tag)
                    return treeNode;

                return null;
            }

        }

        public static void setInfoLabel(string message)
        {
            mainForm.setInfoLabel(message);
        }

        private static string AnalyseTree(TreeView list, StreamWriter writer)
        {
            string nodeText = "";
            foreach (TreeNode treeNode in list.Nodes)
            {
                writer.WriteLine(AnalyseNodes(treeNode, writer));
            }

            return nodeText;
        }

        private static string AnalyseNodes(TreeNode node, StreamWriter writer)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode inNode in node.Nodes)
                writer.WriteLine(AnalyseNodes(inNode, writer));
                return "";
            }
            else
            {
              return node.Text; 
                
            }

           
        }

      

        public static void sendmail(TreeView list)
        {
            SysLanguage language = MiniSystem.getLanguage();
            if (MessageBox.Show(language.errorWarningMessage , language.errorWarningTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
               

                StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\temp\\" + "\\log.txt");
                AnalyseTree(list, streamWriter);
                streamWriter.Close();
                string fileFilter = @"\.avs;\.txt;\.xml;\.vcf";
              
                using (FileStream stream = new FileStream("errorlog.zip", FileMode.Create, FileAccess.Write, FileShare.None, 1024, FileOptions.WriteThrough))
                {

                    FastZip fz = new FastZip();

                    fz.CreateZip(stream, Application.StartupPath + "\\temp\\", true, fileFilter, null);

                }

                MessageBox.Show("There is a file named \"errorlog.zip\' in \"My Documents\". Please add it as an attachment on your erroreport on sourceforge!");
                Process.Start("http://sourceforge.net/tracker/?func=add&group_id=280183&atid=1189049");


                // fz.CreateZip("errorlog.zip", dir.tempDIR, false, fileFilter);

                string test = Environment.SpecialFolder.Desktop.ToString();

            }


        }
    }
}
