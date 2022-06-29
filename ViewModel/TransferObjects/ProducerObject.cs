using AutoService.ViewModel.Validation;

namespace AutoService.ViewModel.TransferObjects
{
    public class ProducerObject : NotifyDataErrorInfo<ProducerObject>
    {
        private string _name;
        private string _country;

        static ProducerObject()
        {
            Rules.Add(new DelegateRule<ProducerObject>(
                nameof(Name),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Name)));
            Rules.Add(new DelegateRule<ProducerObject>(
                nameof(Country),
                "Необходимо заполнить",
                x => !string.IsNullOrEmpty(x.Country)));
        }
        public ProducerObject() { }
        public ProducerObject(int id, string name, string country)
        {
            this.Id = id;
            this.Name = name;
            this.Country = country;
        }
        public int Id { get; set; }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }
    }
}
