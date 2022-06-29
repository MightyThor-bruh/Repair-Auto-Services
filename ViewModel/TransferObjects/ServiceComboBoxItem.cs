using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AutoService.ViewModel.TransferObjects
{
    public class ServiceComboBoxItem : INotifyPropertyChanged
    {
        private bool _isChecked;

        public ServiceComboBoxItem() { }
        public ServiceComboBoxItem(int id, string name, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price.ToString();
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Price { get; private set; }
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
