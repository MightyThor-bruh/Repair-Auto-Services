using AutoService.Models;
using AutoService.Models.Enums;
using AutoService.ViewModel.Validation;
using System;
using System.Collections.Generic;

namespace AutoService.ViewModel.TransferObjects
{
    public class OrderObject : NotifyDataErrorInfo<OrderObject>
    {
        private string _customerEmail;
        private decimal _sum;
        private Guid _empId;
        private Car _customerCar;
        private DateTime _startDate;

        static OrderObject()
        {
            Rules.Add(new DelegateRule<OrderObject>(
                nameof(CustomerEmail),
                "",
                x => !string.IsNullOrEmpty(x.CustomerEmail)));
            Rules.Add(new DelegateRule<OrderObject>(
                nameof(EmpId),
                "",
                x => x.EmpId != Guid.Empty));
            Rules.Add(new DelegateRule<OrderObject>(
                nameof(CustomerCar),
                "",
                x => x.CustomerCar != null));
            Rules.Add(new DelegateRule<OrderObject>(
                nameof(Sum),
                "",
                x => x.Sum > 0));
        }
        public OrderObject()
        {
            Id = Guid.NewGuid();
            Services = new List<Service>();
            StartDate = DateTime.Now;
        }
        public string CustomerEmail
        {
            get { return _customerEmail; }
            set { SetProperty(ref _customerEmail, value); }
        }
        public Guid EmpId
        {
            get { return _empId; }
            set { SetProperty(ref _empId, value); }
        }
        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; } 
        public decimal Sum
        {
            get { return _sum; }
            set { SetProperty(ref _sum, value); }
        }
        public Car CustomerCar
        {
            get { return _customerCar; }
            set { SetProperty(ref _customerCar, value); }
        }
        public List<Service> Services { get; set; }
    }
}
