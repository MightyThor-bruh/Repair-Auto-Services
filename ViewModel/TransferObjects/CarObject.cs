using AutoService.Models;
using AutoService.ViewModel.Validation;
using System;
using System.Text.RegularExpressions;

namespace AutoService.ViewModel.TransferObjects
{
    public class CarObject : NotifyDataErrorInfo<CarObject>
    {
        private Model _model;
        private string _createdDate = string.Empty;
        private string _mileage;
        private string _image = @"..\Images\car.png";
        private static int minYear = 1900;
        private static int maxYear = DateTime.Now.Year;

        static CarObject()
        {
            Rules.Add(new DelegateRule<CarObject>(
                nameof(Mileage),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Mileage)));
            Rules.Add(new DelegateRule<CarObject>(
                nameof(CreatedDate),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.CreatedDate)));
            Rules.Add(new DelegateRule<CarObject>(
                nameof(CreatedDate),
                "Год в формате yyyy",
                x => _ = int.TryParse(x.CreatedDate, out int val) && val >= minYear && val <= maxYear));
            Rules.Add(new DelegateRule<CarObject>(
                nameof(Mileage),
                "Число",
                x => _ = int.TryParse(x.Mileage, out int val)));
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }
        public Model Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        }
        public string CreatedDate
        {
            get { return _createdDate; }
            set { SetProperty(ref _createdDate, value); }
        }
        public string Mileage
        {
            get { return _mileage; }
            set { SetProperty(ref _mileage, value); }
        }
    }
}
