using AutoService.UoF;
using AutoService.ViewModel.Base;
using AutoService.ViewModel.TransferObjects;
using AutoService.ViewModel.Common;
using AutoService.ViewModel.Command;
using System.Windows.Controls;
using AutoService.View;
using AutoService.Models;

namespace AutoService.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public IUnitOfWork UnitOfWork { get; }
        public IShowMesage ShowMessage { get; } = new ShowMessage();
        public ILoadImage LoadImage { get; } = new LoadImage(); 
        private BaseViewModel _current;
        private RelayCommand _backCommand;
        private RelayCommand _changeImageCommand;
        public MainWindowViewModel()
        {
            UnitOfWork = new UnitOfWork();
            var customer = UnitOfWork.CustomerRepository.GetEntityByConditionOrDefault(c => c.Id == CurrentUser.Id);
            CurrentCustomer = new CustomerObject(customer.Id, customer.Name, customer.Surname, customer.Email, customer.Image, customer.Cars);
            Current = new MainCustomerViewModel(this);
            SelectCommand = new RelayCommand((si) =>
            {
                ListBoxItem item = si as ListBoxItem;
                if (item != null)
                {
                    switch (item.Name)
                    {
                        case "main":
                            Current = new MainCustomerViewModel(this);
                            break;
                        case "orders":
                            Current = new MainOrdersViewModel(this);
                            break;
                        case "reviews":
                            Current = new MainReviewsViewModel(this);
                            break;
                        case "emps":
                            Current = new MainEmpsViewModel(this);
                            break;
                    }
                }
            });
        }
        public CustomerObject CurrentCustomer { get; set; }
        public RelayCommand SelectCommand { get; set; }
        public RelayCommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand((o) =>
                {
                    var login = new Login();
                    login.Show();

                    this.Close();
                }));
            }
        }
        public BaseViewModel Current
        {
            get { return _current; }
            set
            {
                _current = value;
                OnPropertyChanged(nameof(Current));
            }
        }
        public RelayCommand ChangeImageCommand
        {
            get
            {
                return _changeImageCommand ?? (_changeImageCommand = new RelayCommand((o) =>
                {
                    var path = LoadImage.OpenFileDialog();

                    if (!string.IsNullOrEmpty(path))
                    {
                        path = LoadImage.SaveImage(path, nameof(Customer), CurrentCustomer.Id);

                        var updateCustomer = UnitOfWork.CustomerRepository.GetEntityByConditionOrDefault(c => c.Id == CurrentCustomer.Id);

                        updateCustomer.Image = CurrentCustomer.Image = path;

                        UnitOfWork.CustomerRepository.Update(updateCustomer);

                        UnitOfWork.SaveChanges();
                    }
                }));
            }
        }
    }
}
