//    MiniCoder
//    Copyright (C) 2009-2010  MiniTech support@minitech.org
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.

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
    public sealed class LogBook
    {
        private static MainForm mainForm;
        private static LogBook instance = null;
        public LogBook()
        {
            mainForm = (MainForm)Application.OpenForms["MainForm"];
        }

        public static LogBook Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogBook();
                }
                return instance;
            }
        }


        public void addLogLine(string message, string searchTag, string messageTag, bool error)
        {
            if (!string.IsNullOrEmpty(message))
                mainForm.addLogLine(message, searchTag, messageTag, false);

        }

        public TreeNode findNode(TreeView treeView, string tag)
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                TreeNode nodi = iterateNode(node, tag);
                if (nodi != null)
                    return nodi;
            }
            return null;
        }

        private TreeNode iterateNode(TreeNode treeNode, string tag)
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
                if (treeNode.Tag != null)
                    if (treeNode.Tag.ToString() == tag)
                        return treeNode;

                return null;
            }

        }

        public void setInfoLabel(string message)
        {
            mainForm.setInfoLabel(message);
        }

        private string AnalyseTree(TreeView list, StreamWriter writer)
        {
            string nodeText = "";
            foreach (TreeNode treeNode in list.Nodes)
            {
                writer.WriteLine(AnalyseNodes(treeNode, writer));
            }

            return nodeText;
        }

        private string AnalyseNodes(TreeNode node, StreamWriter writer)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode inNode in node.Nodes)
                    writer.WriteLine(AnalyseNodes(inNode, writer));
                return "";
            }
            else
                return node.Text;
        }



        public void sendmail(TreeView list)
        {

            if (MessageBox.Show(LanguageController.Instance.getLanguageString("errorWarningMessage"), LanguageController.Instance.getLanguageString("errorWarningTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
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
            }
        }
    }
}
