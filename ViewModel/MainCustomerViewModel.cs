using AutoService.Models;
using AutoService.Models.Enums;
using AutoService.ViewModel.Base;
using AutoService.ViewModel.Command;
using AutoService.ViewModel.TransferObjects;
using System.Linq;

namespace AutoService.ViewModel
{
    public class MainCustomerViewModel : BaseViewModel
    {
        private readonly MainWindowViewModel _vm;
        private CarObject _currentCar;
        private CarObject _addCar;
        private RelayCommand _saveCommand;
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _changeImageCommand;
        private Producer _selectedProducer;
        private Model _selectedModel;
        private Model[] _models;

        public MainCustomerViewModel(MainWindowViewModel vm)
        {
            this._vm = vm;
            this.CurrentCustomer = _vm.CurrentCustomer;
            CurrentCar = CurrentCustomer.Cars.First();

            AddCar = new CarObject();
            Producers = _vm.UnitOfWork.ProducerRepository.GetAll();
            Notifications = _vm.UnitOfWork
                .NotificationsRepository
                .GetAllByCondition(n => n.CustomerId == CurrentCustomer.Id)
                .OrderByDescending(n => n.CreatedAt)
                .Take(5)
                .ToArray();
        }
        public CustomerObject CurrentCustomer { get; set; }
        public Producer[] Producers { get; set; }
        public Notification[] Notifications { get; set; }
        public Producer SelectedProducer
        {
            get { return _selectedProducer; }
            set
            {
                _selectedProducer = value;
                if (_selectedProducer != null)
                {
                    Models = _vm.UnitOfWork.ModelRepository.GetAllByCondition(m => m.ProducerId == _selectedProducer.Id);
                }
                else
                {
                    Models = null;
                }
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }
        public Model SelectedModel
        {
            get { return _selectedModel; }
            set
            {
                _selectedModel = value;
                if (_selectedModel is null)
                {
                    AddCar.Model = null;
                }
                else
                {
                    AddCar.Model = _selectedModel;
                }
                OnPropertyChanged(nameof(SelectedModel));
            }
        }
        public Model[] Models
        {
            get { return _models; }
            set
            {
                _models = value;
                OnPropertyChanged(nameof(Models));
            }
        }
        public CarObject CurrentCar
        {
            get { return _currentCar; }
            set
            {
                _currentCar = value;
                OnPropertyChanged(nameof(CurrentCar));
            }
        }
        public CarObject AddCar
        {
            get { return _addCar; }
            set
            {
                _addCar = value;
                OnPropertyChanged(nameof(AddCar));
            }
        }
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand((o) =>
                {
                    var customer = _vm.UnitOfWork.CustomerRepository.GetEntityByConditionOrDefault(c => c.Id == CurrentCustomer.Id);

                    customer.Name = CurrentCustomer.Name;
                    customer.Surname = CurrentCustomer.Surname;
                    customer.Email = CurrentCustomer.Email;

                    _vm.UnitOfWork.CustomerRepository.Update(customer);

                    _vm.UnitOfWork.SaveChanges();

                }, (o) => !CurrentCustomer.HasErrors));
            }
        }
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand((o) =>
                {
                    Car addCar = new Car
                    {
                        Id = AddCar.Id,
                        Model = AddCar.Model,
                        CreatedYear = AddCar.CreatedDate,
                        Mileage = int.Parse(AddCar.Mileage),
                        CustomerId = CurrentCustomer.Id,
                        Image = AddCar.Image
                    };
                    _vm.UnitOfWork.CarRepository.Add(addCar);

                    _vm.UnitOfWork.SaveChanges();

                    CurrentCustomer.Cars.Add(AddCar);

                    CurrentCar = CurrentCustomer.Cars.First();

                    AddCar = new CarObject();
                    SelectedProducer = null;

                },(o) => !AddCar.HasErrors && SelectedModel != null));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand((o) =>
                {
                    var delCar = _vm.UnitOfWork.CarRepository.GetEntityByConditionOrDefault(c => c.Id == CurrentCar.Id);
                    if(!_vm.UnitOfWork.OrderRepository.GetAll()
                    .Any(s => s.CarId == delCar.Id && (s.OrderStatusId == OrderStatuses.Accepted || s.OrderStatusId == OrderStatuses.Processing)))
                    {
                        CurrentCustomer.Cars.Remove(CurrentCar);

                        CurrentCar = CurrentCustomer.Cars.FirstOrDefault();

                        _vm.UnitOfWork.CarRepository.Delete(delCar);

                        _vm.UnitOfWork.SaveChanges();
                    }
                    else
                    {
                        _vm.ShowMessage.Show(
                            "Невозможно удалить(отмените заказы с данной машиной)",
                            "AutoService",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Error);
                    }

                }));
            }
        }
        public RelayCommand ChangeImageCommand
        {
            get
            {
                return _changeImageCommand ?? (_changeImageCommand = new RelayCommand((o) =>
                {
                    var path = _vm.LoadImage.OpenFileDialog();

                    if(!string.IsNullOrEmpty(path))
                    {
                        path = _vm.LoadImage.SaveImage(path, nameof(Car), CurrentCustomer.Id, CurrentCar.Id);

                        var updateCar = _vm.UnitOfWork.CarRepository.GetEntityByConditionOrDefault(c => c.Id == CurrentCar.Id);

                        CurrentCar.Image = updateCar.Image = path;

                        _vm.UnitOfWork.CarRepository.Update(updateCar);

                        _vm.UnitOfWork.SaveChanges();
                    }
                }));
            }
        }
    }
}