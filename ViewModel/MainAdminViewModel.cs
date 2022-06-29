using AutoService.UoF;
using AutoService.View;
using AutoService.ViewModel.Base;
using AutoService.ViewModel.Command;
using AutoService.ViewModel.Common;
using System.Windows.Controls;

namespace AutoService.ViewModel
{
    public class MainAdminViewModel : BaseViewModel
    {
        private BaseViewModel _current;
        private RelayCommand _backCommand;
        public IUnitOfWork UnitOfWork { get; }
        public IShowMesage ShowMessage { get; } = new ShowMessage();
        public MainAdminViewModel()
        {
            UnitOfWork = new UnitOfWork();
            Current = new EmployeesViewModel(this);
            SelectCommand = new RelayCommand((si) =>
            {
                ListBoxItem item = si as ListBoxItem;
                if (item != null)
                {
                    switch (item.Name)
                    {
                        case "emp":
                            Current = new EmployeesViewModel(this);
                            break;
                        case "users":
                            Current = new AdminCustomersViewModel(this);
                            break;
                        case "services":
                            Current = new ServicesViewModel(this);
                            break;
                        case "orders":
                            Current = new AdminOrdersViewModel(this);
                            break;
                        case "reviews":
                            Current = new AdminReviewsViewModel(this);
                            break;
                        case "cars":
                            Current = new AdminCarsViewModel(this);
                            break;
                    }
                }
            });
        }
        public RelayCommand SelectCommand { get; private set; }

        public BaseViewModel Current
        {
            get { return _current; }
            set
            {
                _current = value;
                OnPropertyChanged(nameof(Current));
            }
        }

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
    }
}
