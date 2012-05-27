using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MiniCoder2.ASScript
{
    /// <summary>
    /// A textbox that uses syntax highlighting and IntelliSense.
    /// </summary>
    class ASTextBox : Control
    {
        // when IntelliSense is requested for text.
        public delegate void IntelliSenseRequestedEventHandler(string methodName, out ASMethod method);
        //   public event IntelliSenseRequestedEventHandler IntelliSenseRequested;
        public String[] Keywords = new String[] {
            "Trim",
            "AVISource",
            "WAVSource",
            "DirectShowSource",
            "LanczosResize"
        };
        private Point scrollAmount = Point.Empty;
        private int selectionStart = 0;
        private int selectionLength = 0;

        #region Constructor
        public ASTextBox()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.Opaque |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.Selectable |
                          ControlStyles.UserPaint, true);
        }
        #endregion

        #region Drawing
        protected override void OnPaint(PaintEventArgs e)
        {
            // retrieve the graphics object.
            Graphics g = e.Graphics;

            // draw each word in the specified font.
            Font f = new Font("Courier New", 10f);
            Size charSize = g.MeasureString("x", f).ToSize();
            Point currentLocation = new Point(-this.scrollAmount.X, -this.scrollAmount.Y);
            bool vScroll = false, hScroll = false;
            for (int i = 0; i < this.Text.Length; i++)
            {
                if (this.Text[i] == '\n')
                {
                    currentLocation.Y += charSize.Height;
                    if (currentLocation.Y > this.Height - SCROLLBAR_SIZE) vScroll = true;
                }
                else if (this.Text[i] != '\r')
                {
                    g.DrawString(this.Text[i].ToString(), f, Brushes.Black, currentLocation);
                    currentLocation.X += charSize.Width;
                    if (currentLocation.X > this.Width - SCROLLBAR_SIZE) hScroll = true;
                }
            }
            if (this.Focused)
            {
                // draw the selection.
                // TODO: Finish this section :)
            }

            // draw the scrollbars.
            this.DrawScrollBars(g, hScroll, vScroll);

            // call the base method.
            base.OnPaint(e);
        }

        private const int SCROLLBAR_SIZE = 25;
        private void DrawScrollBars(Graphics g, bool horizontal, bool vertical)
        {
            Rectangle rectHorizontal = new Rectangle(0, this.Height - SCROLLBAR_SIZE, this.Width, SCROLLBAR_SIZE);
            Rectangle rectVertical = new Rectangle(this.Width - SCROLLBAR_SIZE, 0, SCROLLBAR_SIZE, this.Height);
            if (horizontal && vertical)
            {
                rectHorizontal.Width -= SCROLLBAR_SIZE;
                rectVertical.Height -= SCROLLBAR_SIZE;
                g.FillRectangle(Brushes.Gray, this.Width - SCROLLBAR_SIZE, this.Height - SCROLLBAR_SIZE, SCROLLBAR_SIZE, SCROLLBAR_SIZE);
            }
            if (horizontal)
            {
                g.FillRectangle(Brushes.DimGray, rectHorizontal);
                g.DrawRectangle(Pens.White, rectHorizontal);
                g.DrawRectangle(Pens.White, new Rectangle(rectHorizontal.Location, new Size(SCROLLBAR_SIZE, SCROLLBAR_SIZE)));
                g.DrawRectangle(Pens.White, new Rectangle(rectHorizontal.Right - SCROLLBAR_SIZE, rectHorizontal.Y, SCROLLBAR_SIZE, SCROLLBAR_SIZE));
            }
            if (vertical)
            {
                g.FillRectangle(Brushes.DimGray, rectVertical);
                g.DrawRectangle(Pens.White, rectVertical);
                g.DrawRectangle(Pens.White, new Rectangle(rectVertical.Location, new Size(SCROLLBAR_SIZE, SCROLLBAR_SIZE)));
                g.DrawRectangle(Pens.White, new Rectangle(rectVertical.X, rectVertical.Bottom - SCROLLBAR_SIZE, SCROLLBAR_SIZE, SCROLLBAR_SIZE));
            }
        }
        #endregion

        #region Utility Functions

        private const string SeparatorChars = "+-*/ ";

        private string GetWordAt(int i)
        {
            while (i > 0 && !SeparatorChars.Contains(this.Text[i])) i--;
            StringBuilder s = new StringBuilder();
            while (i < this.Text.Length && !SeparatorChars.Contains(this.Text[++i])) s.Append(this.Text[i]);
            return s.ToString();
        }

        private bool IsSeparatorChar(char c)
        {
            return SeparatorChars.Contains(c);
        }

        private void AddAtCursor(string s)
        {
            if (this.SelectionLength > 0)
            {
                this.Text = this.Text.Remove(this.SelectionStart, this.SelectionLength);
                this.selectionLength = 0;
            }
            this.Text = this.Text.Insert(this.SelectionStart, s);
            this.selectionStart += s.Length;
        }

        private void Backspace()
        {
            if (this.SelectionStart > 0)
                this.Text = this.Text.Remove(this.SelectionStart - 1, 1);
            else
                System.Media.SystemSounds.Beep.Play();
        }
        #endregion

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.Select(0, 0);
        }

        #region Keyboard
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.AddAtCursor("\n\r");
                    break;
                case Keys.Back:
                    this.Backspace();
                    break;
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            this.AddAtCursor(e.KeyChar.ToString());
            base.OnKeyPress(e);
        }
        #endregion

        #region Selection Properties & Methods

        /// <summary>
        /// Selects a specific area in the ASTextBox.
        /// </summary>
        /// <param name="start">Where to start the selection.</param>
        /// <param name="length">The length of the selection.</param>
        public void Select(int start, int length)
        {
            this.selectionStart = start;
            this.selectionLength = length;
            this.Invalidate();
        }

        public int SelectionStart
        {
            get
            {
                return this.selectionStart;
            }
        }

        public int SelectionLength
        {
            get
            {
                return this.selectionLength;
            }
        }
        #endregion

    }
}
