using AutoService.ViewModel.Validation;
using System.ComponentModel;

namespace AutoService.ViewModel.TransferObjects
{
    public class ServiceObject : NotifyDataErrorInfo<ServiceObject>
    {
        private string _name;
        private string _price;

        static ServiceObject()
        {
            Rules.Add(new DelegateRule<ServiceObject>(
                nameof(Name),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Name)));
            Rules.Add(new DelegateRule<ServiceObject>(
                nameof(Price),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Price)));
            Rules.Add(new DelegateRule<ServiceObject>(
                nameof(Price),
                "Число",
                x => _ = decimal.TryParse(x.Price, out decimal val)));
        }
        public ServiceObject() { }
        public ServiceObject(int id, string name, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price.ToString();
        }
        public int Id { get; set; }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string Price
        {
            get => _price;
            set
            {
                var tmp = value.Replace(',', '.');
                if (decimal.TryParse(tmp, out decimal val))
                {
                    SetProperty(ref _price, tmp);
                }
                else
                {
                    SetProperty(ref _price, "");
                }
            }
        }
    }
}
