﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniCoder2.View
{
    /// <summary>
    /// An interface for all GUI's that where made for templating. 
    /// These are the functions that the controller needs from the view.
    /// </summary>
    public interface TemplateForm
    {
         void SetCommandLine(String commando);
         void UpdateModel();
    }
}
