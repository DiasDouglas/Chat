using System;
using System.ComponentModel.DataAnnotations;

namespace Chat.Models
{
    public class Message
    {
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public long ChatId { get; set; }
        public Chat Chat { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
