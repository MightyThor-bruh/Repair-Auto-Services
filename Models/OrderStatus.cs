using AutoService.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoService.Models
{
    public class OrderStatus
    {
        [Key]
        public OrderStatuses Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
