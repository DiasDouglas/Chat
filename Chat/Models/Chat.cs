using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class Chat
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Message> Messages { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<ChatUser> ChatUsers { get; set; }
    }
}
