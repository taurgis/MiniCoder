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

namespace MiniTech.MiniCoder.Core.Other.Logging
{
    public enum LogMessageCategories
    {
        Debug, Error, Video, Info
    }

    public class LogMessageCategory
    {
        public String categoryName { get; set; }
        public List<LogMessageCategory> subCategories { get; set; }
        public List<LogMessage> messages { get; set; }

        public LogMessageCategory(string categoryName)
        {
            this.categoryName = categoryName;
            this.subCategories = new List<LogMessageCategory>();
            this.messages = new List<LogMessage>();
        }

        public void addSubCategory(LogMessageCategory category)
        {
            subCategories.Add(category);
        }

        public void addMessage(LogMessage message)
        {
            messages.Add(message);
        }
    }
}
