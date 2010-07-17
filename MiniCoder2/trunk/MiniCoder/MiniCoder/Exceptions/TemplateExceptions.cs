using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.Exceptions
{
    public class ModeException : Exception
    {
        public ModeException()
        {
            this.Source = "An unknown modus has been selected for the template.";
        }
    }
}
