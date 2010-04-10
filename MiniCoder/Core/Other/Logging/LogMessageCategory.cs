using System;
using System.Collections.Generic;
using System.Text;

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
