using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoService.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Index(IsUnique = true)]
        [StringLength(256)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
