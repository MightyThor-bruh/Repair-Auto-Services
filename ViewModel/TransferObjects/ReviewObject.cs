using AutoService.Models;
using System;

namespace AutoService.ViewModel.TransferObjects
{
    public class ReviewObject
    {
        public ReviewObject()
        {

        }
        public ReviewObject(
            Guid id,
            string title,
            string description,
            DateTime createdAt,
            bool canDelete,
            Customer customer)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.CreatedAt = createdAt;
            this.CanDelete = canDelete;
            this.Customer = customer;
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool CanDelete { get; set; } = true;
        public Customer Customer { get; set; }
    }
}
