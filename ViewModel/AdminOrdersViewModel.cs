using AutoService.Models;
using AutoService.ViewModel.Base;
using AutoService.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AutoService.ViewModel
{
    public class AdminOrdersViewModel : BaseViewModel
    {
        private readonly MainAdminViewModel _vm;
        private RelayCommand _addOrderCommand;
        private RelayCommand _searchNumberCommand;
        private RelayCommand _searchEmailCommand;
        private OrderStatus _selectedStatus;
        private Order _selectedOrder;

        public AdminOrdersViewModel(MainAdminViewModel vm)
        {
            this._vm = vm;

            AllOrders = _vm.UnitOfWork.OrderRepository.GetAll().ToList();
            Orders = new ObservableCollection<Order>(AllOrders);
            Statuses = _vm.UnitOfWork.OrderStatusRepository.GetAll();
        }
        public List<Order> AllOrders { get; private set; }
        public OrderStatus[] Statuses { get; }
        public OrderStatus SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                _selectedStatus = value;
                OnPropertyChanged(nameof(SelectedStatus));
                Orders.Clear();
                if (_selectedStatus != null)
                {
                    foreach (var order in AllOrders)
                    {
                        if (order.OrderStatusId == _selectedStatus.Id)
                        {
                            Orders.Add(order);
                        }
                    }
                }
                else
                {
                    foreach (var order in AllOrders)
                    {
                        Orders.Add(order);
                    }
                }
            }
        }
        public ObservableCollection<Order> Orders { get; set; }
        public Order SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
                if(_selectedOrder != null)
                {
                    _vm.Current = new AdminMakeOrderViewModel(_vm, this, true);
                }
            }
        } 

        public RelayCommand AddOrderCommand
        {
            get
            {
                return _addOrderCommand ?? (_addOrderCommand = new RelayCommand((o) =>
                {
                    _vm.Current = new AdminMakeOrderViewModel(_vm, this);
                }));
            }
        }
        public RelayCommand SearchNumberCommand
        {
            get
            {
                return _searchNumberCommand ?? (_searchNumberCommand = new RelayCommand((o) =>
                {
                    string number = o as string;

                    Orders.Clear();
                    if (!string.IsNullOrEmpty(number))
                    {
                        foreach (var order in AllOrders)
                        {
                            if (order.Id.ToString().StartsWith(number, StringComparison.OrdinalIgnoreCase))
                            {
                                Orders.Add(order);
                            }
                        }
                    }
                    else
                    {
                        foreach (var order in AllOrders)
                        {
                            Orders.Add(order);
                        }
                    }

                }));
            }
        }
        public RelayCommand SearchEmailCommand
        {
            get
            {
                return _searchEmailCommand ?? (_searchEmailCommand = new RelayCommand((o) =>
                {
                    string number = o as string;

                    Orders.Clear();
                    if (!string.IsNullOrEmpty(number))
                    {
                        foreach (var order in AllOrders)
                        {
                            if (order.Car.Customer.Email.StartsWith(number, StringComparison.OrdinalIgnoreCase))
                            {
                                Orders.Add(order);
                            }
                        }
                    }
                    else
                    {
                        foreach (var order in AllOrders)
                        {
                            Orders.Add(order);
                        }
                    }

                }));
            }
        }
    }
}