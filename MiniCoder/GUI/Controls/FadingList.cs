using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MiniTech.MiniCoder.GUI.Controls
{
    public partial class FadingList : UserControl
    {
        public FadingList()
        {
            InitializeComponent();
            line1.Text = "";
            line2.Text = "";
            line3.Text = "";
            line4.Text = "";
            line5.Text = "";
            line6.Text = "";


        }

        private void FadingList_Load(object sender, EventArgs e)
        {

        }




        private delegate void AddLine(string newLine);
        public void addLine(String newLine)
        {
            if (this.line1.InvokeRequired)
                this.line1.Invoke(new AddLine(this.addLine), newLine);
            else
            {
                line6.Text = line5.Text;
                line5.Text = line4.Text;
                line4.Text = line3.Text;
                line3.Text = line2.Text;
                line2.Text = line1.Text;
                line1.Text = newLine;
            }
        }
    }
}
