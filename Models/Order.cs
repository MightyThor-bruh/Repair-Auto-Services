using AutoService.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoService.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public decimal Sum { get; set; }

        public Guid CarId { get; set; }
        public virtual Car Car { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public OrderStatuses OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
