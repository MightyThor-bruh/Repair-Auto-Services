using AutoService.Models;
using AutoService.ViewModel.Validation;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace AutoService.ViewModel.TransferObjects
{
    public class RegisterObject : NotifyDataErrorInfo<RegisterObject>
    {
        private string _name;
        private string _surname;
        private string _email = string.Empty;
        private string _password= string.Empty;

        static RegisterObject()
        {
            Rules.Add(new DelegateRule<RegisterObject>(
                nameof(Name),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Name)));
            Rules.Add(new DelegateRule<RegisterObject>(
                nameof(Surname),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Surname)));
            Rules.Add(new DelegateRule<RegisterObject>(
                nameof(Email),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Email)));
            Rules.Add(new DelegateRule<RegisterObject>(
                nameof(Email),
                "Не соответствует шаблону",
                x => Regex.IsMatch(x.Email, @"^([a-zA-Z0-9_-]+\.)*[a-zA-Z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$")));
            Rules.Add(new DelegateRule<RegisterObject>(
                nameof(Password),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Password)));
            Rules.Add(new DelegateRule<RegisterObject>(
                nameof(Password),
                "Только латиница и цифры",
                x => Regex.IsMatch(x.Password, @"^[a-zA-Z0-9]{8,16}$")));
        }
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Image { get; set; } = @"..\..\Images\user.png";
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
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
    }
}
