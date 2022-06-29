using AutoService.Models;
using AutoService.Repository;

namespace AutoService.UoF
{
    public interface IUnitOfWork
    {
        IRepository<Admin> AdminRepository { get; }
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Employee> EmployeeRepository { get; }
        IRepository<Service> ServiceRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<Producer> ProducerRepository { get; }
        IRepository<Model> ModelRepository { get; }
        IRepository<ModelType> ModelTypeRepository { get; }
        IRepository<OrderStatus> OrderStatusRepository { get; }
        IRepository<Car> CarRepository { get; }
        IRepository<Review> ReviewRepository { get; }
        IRepository<Notification> NotificationsRepository { get; }
        int SaveChanges();
    }
}
