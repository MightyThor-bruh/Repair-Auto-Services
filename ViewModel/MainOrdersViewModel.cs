using AutoService.Models;
using AutoService.Models.Enums;
using AutoService.ViewModel.Base;
using AutoService.ViewModel.Command;
using AutoService.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AutoService.ViewModel
{
    public class MainOrdersViewModel : BaseViewModel
    {
        private readonly MainWindowViewModel _vm;
        private RelayCommand _addOrderCommand;
        private RelayCommand _clearCommand;
        private RelayCommand _searchNumberCommand;
        private Order _selectedOrder;
        private OrderStatus _selectedStatus;
        public MainOrdersViewModel(MainWindowViewModel vm)
        {
            this._vm = vm;

            AllOrders = _vm.UnitOfWork.OrderRepository.GetAllByCondition(c => c.Car.CustomerId == CurrentUser.Id).ToList();
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
                if(_selectedStatus != null)
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
                if (_selectedOrder != null)
                {
                    _vm.Current = new MainMakeOrderViewModel(_vm, this, true);
                }
            }
        }
        public RelayCommand AddOrderCommand
        {
            get
            {
                return _addOrderCommand ?? (_addOrderCommand = new RelayCommand((o) =>
                {
                    _vm.Current = new MainMakeOrderViewModel(_vm, this);
                }));
            }
        }
        public RelayCommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new RelayCommand((o) =>
                {
                    SelectedStatus = null;
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
                    SelectedStatus = null;
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
    }
}