using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class ChatUser
    {
        public long ChatId { get; set; }
        public Chat Chat { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
