using AutoService.Models;
using AutoService.Models.Enums;
using AutoService.ViewModel.Base;
using AutoService.ViewModel.Command;
using AutoService.ViewModel.TransferObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace AutoService.ViewModel
{
    public class AdminMakeOrderViewModel : BaseViewModel
    {
        private readonly Guid _empNoNameId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        private readonly MainAdminViewModel _vm;
        private readonly AdminOrdersViewModel _orders;
        private RelayCommand _backCommand;
        private RelayCommand _makeCommand;
        private RelayCommand _changeCommand;
        private EmpComboBoxItem _selectedEmp;
        private Customer _selectedCustomer;
        private OrderStatus _selectedStatus;
        private Service[] _allServices;
        private Car[] _cars;
        private Car _selectedCar;
        private bool _dropopen = false;
        private string _text;
        private ObservableCollection<ServiceComboBoxItem> _mServices;
        private HashSet<ServiceComboBoxItem> _mCheckedServices;
        public IEnumerable<ServiceComboBoxItem> Services { get { return _mServices; } }
        
        public AdminMakeOrderViewModel(
            MainAdminViewModel vm, 
            AdminOrdersViewModel orders,
            bool isEdit = false)
        {
            this._vm = vm;
            this._orders = orders;
            this.IsEdit = isEdit;

            if(_orders.SelectedOrder != null &&
                (_orders.SelectedOrder.OrderStatus.Id == OrderStatuses.Fulfilled ||
                _orders.SelectedOrder.OrderStatus.Id == OrderStatuses.Canceled))
            {
                CanEdit = false;
            }

            Emps = _vm.UnitOfWork.EmployeeRepository.GetAllByCondition(c => c.Id != _empNoNameId);
            Customers = _vm.UnitOfWork.CustomerRepository.GetAll();
            Statuses = _vm.UnitOfWork.OrderStatusRepository.GetAll();

            EmpsNames = Emps.Select(e => new EmpComboBoxItem { Id = e.Id, FullName = $"{e.Name} {e.Surname}" }).ToArray();

            if (IsEdit)
            {
                Order = new OrderObject
                {
                    Id = orders.SelectedOrder.Id,
                    CustomerEmail = orders.SelectedOrder.Car.Customer.Email,
                    EmpId = orders.SelectedOrder.EmployeeId,
                    StartDate = orders.SelectedOrder.StartDate,
                    Services = orders.SelectedOrder.Services.ToList(),
                    Status = orders.SelectedOrder.OrderStatus,
                    CustomerCar = orders.SelectedOrder.Car
                };
                SelectedStatus = Order.Status;
                SelectedCustomer = orders.SelectedOrder.Car.Customer;
                SelectedCar = Order.CustomerCar;
                SelectedEmp = EmpsNames.FirstOrDefault(e => e.Id == Order.EmpId);
            }
            else
            {
                Order = new OrderObject();
                SelectedStatus = Statuses.First(s => s.Id == OrderStatuses.Accepted);
            }
            StartDate = DateTime.Now;
            EndDate = StartDate.AddMonths(1);

            _mServices = new ObservableCollection<ServiceComboBoxItem>();
            _mCheckedServices = new HashSet<ServiceComboBoxItem>();
            _mServices.CollectionChanged += Services_CollectionChanged;

            _allServices = _vm.UnitOfWork.ServiceRepository.GetAll();

            foreach (var item in _allServices)
            {
                var addSer = new ServiceComboBoxItem(item.Id, item.Name, item.Price);
                _mServices.Add(addSer);
                if(Order.Services.Any(s => s.Id == item.Id))
                {
                    addSer.IsChecked = true;
                }
            }
        }
        public Employee[] Emps { get; }
        public OrderStatus[] Statuses { get; }
        public bool IsEdit { get; set; }
        public bool CanEdit { get; set; } = true;
        public Car[] Cars
        {
            get { return _cars; }
            set
            {
                _cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }
        public Car SelectedCar
        {
            get { return _selectedCar; }
            set
            {
                _selectedCar = value;
                if(_selectedCar != null)
                {
                    Order.CustomerCar = _selectedCar;
                }
                OnPropertyChanged(nameof(SelectedCar));
            }
        }
        public OrderStatus SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                _selectedStatus = value;
                if(_selectedStatus != null)
                {
                    Order.Status = _selectedStatus;
                }
                OnPropertyChanged(nameof(SelectedStatus));
            }
        }
        public EmpComboBoxItem[] EmpsNames { get; set; }
        public string[] Emails { get; set; }
        public Customer[] Customers { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public OrderObject Order { get; set; }
        public EmpComboBoxItem SelectedEmp
        {
            get { return _selectedEmp; }
            set
            {
                _selectedEmp = value;
                if(_selectedEmp != null)
                {
                    Order.EmpId = _selectedEmp.Id;
                }
                
                OnPropertyChanged(nameof(SelectedEmp));
            }
        }
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                if(_selectedCustomer != null)
                {
                    Order.CustomerEmail = _selectedCustomer.Email;
                    Cars = _selectedCustomer.Cars.ToArray();
                }
                else
                {
                    Order.CustomerEmail = string.Empty;
                    Cars = Array.Empty<Car>();
                }
                
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }
        public RelayCommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand((o) =>
                {
                    _orders.SelectedOrder = null;
                    _vm.Current = _orders;
                }));
            }
        }
        public RelayCommand MakeCommand
        {
            get
            {
                return _makeCommand ?? (_makeCommand = new RelayCommand((o) =>
                {
                    var newOrder = new Order
                    {
                        Id = Order.Id,
                        CarId = Order.CustomerCar.Id,
                        Sum = Order.Sum,
                        CreatedAt = DateTime.Now,
                        EmployeeId = Order.EmpId,
                        OrderStatusId = Models.Enums.OrderStatuses.Accepted,
                        StartDate = Order.StartDate,
                        Services = Order.Services
                    };

                    _vm.UnitOfWork.OrderRepository.Add(newOrder);

                    var notification = new Notification
                    {
                        CreatedAt = DateTime.Now,
                        CustomerId = Order.CustomerCar.CustomerId,
                        Message = $"Заказ принят. Номер {newOrder.Id}"
                    };

                    _vm.UnitOfWork.NotificationsRepository.Add(notification);

                    _vm.UnitOfWork.SaveChanges();

                    _vm.ShowMessage.Show(
                        "Оформлен",
                        "AutoService",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Information);

                    _orders.AllOrders.Add(newOrder);
                    _orders.Orders.Add(newOrder);

                    _vm.Current = _orders;

                }, (o) => !Order.HasErrors));
            }
        }

        public RelayCommand ChangeCommand
        {
            get
            {
                return _changeCommand ?? (_changeCommand = new RelayCommand((o) =>
                {
                    _orders.SelectedOrder.Car = Order.CustomerCar;
                    _orders.SelectedOrder.Sum = Order.Sum;
                    _orders.SelectedOrder.EmployeeId = Order.EmpId;
                    _orders.SelectedOrder.OrderStatus = Order.Status;
                    _orders.SelectedOrder.StartDate = Order.StartDate;
                    _orders.SelectedOrder.Services = Order.Services;

                    _vm.UnitOfWork.OrderRepository.Update(_orders.SelectedOrder);

                    var notification = new Notification
                    {
                        CreatedAt = DateTime.Now,
                        CustomerId = Order.CustomerCar.CustomerId,
                        Message = $"В заказ под номером {Order.Id} были внесены изменения"
                    };

                    if(Order.Status.Id == OrderStatuses.Processing)
                    {
                        notification.Message = $"Выполняется заказ под номером {Order.Id}";
                    }
                    else if(Order.Status.Id == OrderStatuses.Canceled)
                    {
                        notification.Message = $"Заказ под номером {Order.Id} был отменен";
                    }
                    else if(Order.Status.Id == OrderStatuses.Fulfilled)
                    {
                        notification.Message = $"Заказ под номером {Order.Id} выполнен";
                    }

                    _vm.UnitOfWork.NotificationsRepository.Add(notification);

                    _vm.UnitOfWork.SaveChanges();

                    _vm.ShowMessage.Show(
                        "Изменен",
                        "AutoService",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Information);

                    _orders.SelectedOrder = null;
                    _vm.Current = _orders;

                }, (o) => !Order.HasErrors && CanEdit));
            }
        }
        public bool DropOpen
        {
            get { return _dropopen; }
            set { _dropopen = value; OnPropertyChanged(nameof(Text)); }
        }

        public string Text
        {
            set
            {
                if (value != null && value.IndexOf("Element") != -1) return;
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
            get
            {
                return _text;
            }
        }

        private void Services_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (ServiceComboBoxItem service in e.OldItems)
                {
                    service.PropertyChanged -= Service_PropertyChanged;
                    _mCheckedServices.Remove(service);
                    var ser = _allServices.First(s => s.Id == service.Id);
                    Order.Services.Remove(ser);
                }
            }
            if (e.NewItems != null)
            {
                foreach (ServiceComboBoxItem service in e.NewItems)
                {
                    service.PropertyChanged += Service_PropertyChanged;
                    if (service.IsChecked)
                    {
                        _mCheckedServices.Add(service);
                        var ser = _allServices.First(s => s.Id == service.Id);
                        Order.Services.Add(ser);
                    }
                }
            }
            UpdateText();
        }

        private void Service_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsChecked")
            {
                ServiceComboBoxItem service = (ServiceComboBoxItem)sender;
                if (service.IsChecked)
                {
                    _mCheckedServices.Add(service);
                    var ser = _allServices.First(s => s.Id == service.Id);
                    Order.Services.Add(ser);
                    Order.Sum += decimal.Parse(service.Price);
                }
                else
                {
                    _mCheckedServices.Remove(service);
                    var ser = _allServices.First(s => s.Id == service.Id);
                    Order.Services.Remove(ser);
                    Order.Sum -= decimal.Parse(service.Price);
                }
                UpdateText();
            }
        }

        private void UpdateText()
        {
            switch (_mCheckedServices.Count)
            {
                case 0:
                    Text = "Добавьте услуги";
                    break;
                case 1:
                    Text = $"{_mCheckedServices.First().Name}";
                    break;
                default:
                    Text = "Много";
                    break;
            }
        }
    }
}