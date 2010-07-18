#region "Imports"
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
#endregion

// Author: Ryan O'Hara
// Please do not move into another folder.
// I'm not sure which folder it belongs in or
// your habits in naming folders, so I'll just
// leave it here for now.

namespace MiniCoder2.ASScript {
    public partial class AviSynth_Script_Editor : Form {
        public AviSynth_Script_Editor() {
            InitializeComponent();
        }

        // IntelliSense popup system
        private void IntelliSensePopup(int charIndex, ASMethod method) {
            Panel p = new Panel(); // this is the IntelliSense panel to be displayed.
            p.BackColor = Color.FromArgb(210, Color.LightYellow);
            p.ForeColor = Color.Black;
            Label title = new Label();
            title.Text = method.Name;
            title.Font = new Font("Trebuchet MS", 14.0f, FontStyle.Bold);
            Label info = new Label();
        }
    }
}
