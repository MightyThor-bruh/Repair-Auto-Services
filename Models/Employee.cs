using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoService.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int Experience { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
