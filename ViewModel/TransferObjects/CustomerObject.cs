using AutoService.Models;
using AutoService.ViewModel.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace AutoService.ViewModel.TransferObjects
{
    public class CustomerObject : NotifyDataErrorInfo<CustomerObject>
    {
        private string _name;
        private string _surname;
        private string _email = string.Empty;
        private string _image;
        static CustomerObject()
        {
            Rules.Add(new DelegateRule<CustomerObject>(
                nameof(Name),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Name)));
            Rules.Add(new DelegateRule<CustomerObject>(
                nameof(Surname),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Surname)));
            Rules.Add(new DelegateRule<CustomerObject>(
                nameof(Email),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Email)));
            Rules.Add(new DelegateRule<CustomerObject>(
                nameof(Email),
                "Не соответствует шаблону",
                x => Regex.IsMatch(x.Email, @"^([a-zA-Z0-9_-]+\.)*[a-zA-Z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$")));
        }

        public CustomerObject(
            Guid id, 
            string name,
            string surname,
            string email,
            string image,
            ICollection<Car> cars) 
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Image = image;
            this.Cars = new ObservableCollection<CarObject>(cars.Select(c => new CarObject
            {
                Id = c.Id,
                CreatedDate = c.CreatedYear,
                Mileage = c.Mileage.ToString(),
                Model = c.Model,
                Image = c.Image
            }));
        }
        public Guid Id { get; set; }
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public string Surname
        {
            get { return _surname; }
            set { SetProperty(ref _surname, value); }
        }
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }
        public ObservableCollection<CarObject> Cars { get; set; }
    }
}
