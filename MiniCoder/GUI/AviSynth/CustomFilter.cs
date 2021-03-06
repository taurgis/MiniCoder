﻿//    MiniCoder
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MiniTech.MiniCoder.Core.Languages;
using System.Text;
using System.Windows.Forms;


namespace MiniTech.MiniCoder.GUI.AviSynth
{
    public partial class CustomFilter : Form
    {
        public string customFiltOpts { get; set; }


        public CustomFilter(string customFiltOpts)
        {
            InitializeComponent();
            this.customFiltOpts = customFiltOpts;
            fieldFilterText.Text = customFiltOpts;
            this.Text = LanguageController.Instance.getLanguageString("customFilterTitle");
            customLabel.Text = LanguageController.Instance.getLanguageString("customFilterText");
            noteLabel.Text = LanguageController.Instance.getLanguageString("customFilterNote");
            btnOK.Text = LanguageController.Instance.getLanguageString("customFilterOK");
            btnCancel.Text = LanguageController.Instance.getLanguageString("customFilterCancel");
        }

      

        private void btnOK_Click(object sender, EventArgs e)
        {
            customFiltOpts = fieldFilterText.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomFilter_Load(object sender, EventArgs e)
        {

        }

     

      
    }
}
