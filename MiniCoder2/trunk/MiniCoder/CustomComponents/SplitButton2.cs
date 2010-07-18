using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace CustomControls {
    class SplitButton2 : Button {
        private ToolStripDropDownClosedEventHandler closedEventHandler = null;

        /// <summary>
        /// The drop-down menu to display when the button is clicked.
        /// </summary>
        [Description("The drop-down menu to display when the button is clicked.")]
        public ContextMenuStrip DropDown { get; set; }

        protected override void OnClick(EventArgs e) {
            base.OnClick(e);
            if(this.DropDown != null) {
                if(!this.DroppedDown) {
                    this.DroppedDown = true;
                    this.closedEventHandler = new ToolStripDropDownClosedEventHandler(DropDown_Closed);
                    this.DropDown.Closed += this.closedEventHandler;
                    this.DropDown.Show(this, new System.Drawing.Point(0, this.Height), ToolStripDropDownDirection.BelowLeft);
                    if(this.DropDownShown != null)
                        this.DropDownShown(this, EventArgs.Empty);
                }
            }
        }

        private void DropDown_Closed(object sender, ToolStripDropDownClosedEventArgs e) {
            if(this.DropDownHidden != null)
                this.DropDownHidden(this, EventArgs.Empty);
            this.DropDown.Closed -= this.closedEventHandler;
        }

        delegate void DropDownShownEventHandler(object sender, EventArgs e);
        delegate void DropDownHiddenEventHandler(object sender, EventArgs e);

        private event DropDownShownEventHandler DropDownShown;
        private event DropDownHiddenEventHandler DropDownHidden;

        /// <summary>
        /// Whether or not the SplitButton2's menu is currently visible.
        /// </summary>
        [Browsable(false)]
        public bool DroppedDown { get; set; }

        public override string Text {
            get {
                return base.Text + ' ' + System.Text.Encoding.Unicode.GetString(new byte[] {(byte)(0x25BC >> 8),(byte)(0x25BC & 0xFF)});
            }
            set {
                base.Text = value;
            }
        }
    }
}
