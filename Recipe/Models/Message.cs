using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipe.Models
{
    public static class Message
    {
        
        public static string DisplayMessage(string MessageType, string MessageContent)
        {
            return $@"<div class='alert alert-{MessageType}' role='alert'>
                {MessageContent}
                </div>";
        }
    }
}