using AutoService.Models;
using System.Data.Entity;

namespace AutoService.Context
{
    public class AutoDbContext : DbContext
    {
        public AutoDbContext() : base("DefaultConnection")
        {
            this.Database.CreateIfNotExists();
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ModelType> ModelTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
