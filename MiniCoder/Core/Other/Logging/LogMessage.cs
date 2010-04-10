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
