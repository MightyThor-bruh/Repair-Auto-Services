using AutoService.Context;
using AutoService.Models;
using AutoService.Repository;

namespace AutoService.UoF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutoDbContext _dbContext;
        private IRepository<Admin> _adminRepository;
        private IRepository<Customer> _customerRepository;
        private IRepository<Employee> _employeeRepository;
        private IRepository<Service> _serviceRepository;
        private IRepository<Order> _orderRepository;
        private IRepository<Producer> _producerRepository;
        private IRepository<Model> _modelRepository;
        private IRepository<ModelType> _modelTypeRepository;
        private IRepository<OrderStatus> _orderStatusRepository;
        private IRepository<Car> _carRepository;
        private IRepository<Review> _reviewRepository;
        private IRepository<Notification> _notificationsRepository;

        public UnitOfWork()
        {
            _dbContext = new AutoDbContext();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public IRepository<Admin> AdminRepository => _adminRepository ?? (_adminRepository = new Repository<Admin>(_dbContext));
        public IRepository<Customer> CustomerRepository => _customerRepository ?? (_customerRepository = new Repository<Customer>(_dbContext));
        public IRepository<Employee> EmployeeRepository => _employeeRepository ?? (_employeeRepository = new Repository<Employee>(_dbContext));
        public IRepository<Service> ServiceRepository => _serviceRepository ?? (_serviceRepository = new Repository<Service>(_dbContext));
        public IRepository<Order> OrderRepository => _orderRepository ?? (_orderRepository = new Repository<Order>(_dbContext));
        public IRepository<Producer> ProducerRepository => _producerRepository ?? (_producerRepository = new Repository<Producer>(_dbContext));
        public IRepository<Model> ModelRepository => _modelRepository ?? (_modelRepository = new Repository<Model>(_dbContext));
        public IRepository<ModelType> ModelTypeRepository => _modelTypeRepository ?? (_modelTypeRepository = new Repository<ModelType>(_dbContext));
        public IRepository<OrderStatus> OrderStatusRepository => _orderStatusRepository ?? (_orderStatusRepository = new Repository<OrderStatus>(_dbContext));
        public IRepository<Car> CarRepository => _carRepository ?? (_carRepository = new Repository<Car>(_dbContext));
        public IRepository<Review> ReviewRepository => _reviewRepository ?? (_reviewRepository = new Repository<Review>(_dbContext));
        public IRepository<Notification> NotificationsRepository => _notificationsRepository ?? (_notificationsRepository = new Repository<Notification>(_dbContext));
    }
}
