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

namespace MiniTech.MiniCoder.Core.Other.Logging
{
    public class LogMessage
    {
        public long logId { get; set; }
        public String message { get; set; }
        public LogMessageCategory category { get; set; }
        public Boolean error { get; set; }
        public DateTime time { get; set; }

        public LogMessage(String message, LogMessageCategory category)
        {
            logId = 0;
            this.message = message;
            this.category = category;
            category.addMessage(this);
            time = DateTime.Now;
        }
    }
}
