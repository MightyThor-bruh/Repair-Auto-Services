using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoService.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        [Required]
        public string CreatedYear { get; set; }
        [Required]
        public int Mileage { get; set; }
        public string Image { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
