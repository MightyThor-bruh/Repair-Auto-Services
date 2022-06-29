using System;

namespace AutoService.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }  
    }
}
