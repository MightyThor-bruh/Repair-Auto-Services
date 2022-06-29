using AutoService.Models;
using AutoService.UoF;
using AutoService.View;
using AutoService.ViewModel.Base;
using AutoService.ViewModel.Command;
using AutoService.ViewModel.Common;
using AutoService.ViewModel.TransferObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace AutoService.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShowMesage _showMessage = new ShowMessage();
        private RelayCommand _registerCommand;
        private RelayCommand _addCommand;
        private Producer _selectedProducer;
        private Model _selectedModel;
        private Model[] _models;
        private CarObject _addCar;

        public RegisterViewModel()
        {
            _unitOfWork = new UnitOfWork();

            Producers = _unitOfWork.ProducerRepository.GetAll();
            AddCar = new CarObject();

            CustomerCars = new ObservableCollection<Car>();
        }
        public ObservableCollection<Car> CustomerCars { get; set; }
        public Producer[] Producers { get; set; }
        public CarObject AddCar
        {
            get { return _addCar; }
            set
            {
                _addCar = value;
                OnPropertyChanged(nameof(AddCar));
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
        public Producer SelectedProducer
        {
            get { return _selectedProducer; }
            set
            {
                _selectedProducer = value;
                if(_selectedProducer != null)
                {
                    Models = _unitOfWork.ModelRepository.GetAllByCondition(m => m.ProducerId == _selectedProducer.Id);
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
                if(_selectedModel is null)
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
        public RegisterObject Register { get; set; } = new RegisterObject();

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
                        CustomerId = Register.Id,
                        Image = AddCar.Image
                    };

                    CustomerCars.Add(addCar);

                    AddCar = new CarObject();
                    SelectedProducer = null;
                }, (o) => !AddCar.HasErrors && SelectedModel != null));
            }
        }

        public RelayCommand RegisterCommand
        {
            get
            {
                return _registerCommand ?? (_registerCommand = new RelayCommand((o) =>
                {
                    var box = o as PasswordBox;

                    Register.Password = box.Password;

                    if(!Register.HasErrors)
                    {

                        if (_unitOfWork.CustomerRepository.GetEntityByConditionOrDefault(c => c.Email == Register.Email) is null)
                        {

                            var customer = new Customer
                            {
                                Id = Register.Id,
                                Name = Register.Name,
                                Surname = Register.Surname,
                                Email = Register.Email,
                                Password = BCrypt.Net.BCrypt.HashPassword(Register.Password),
                                Cars = new List<Car>(CustomerCars),
                                Image = Register.Image
                            };

                            _unitOfWork.CustomerRepository.Add(customer);

                            _unitOfWork.SaveChanges();

                            CurrentUser.Id = customer.Id;

                            var main = new MainWindow();

                            main.Show();

                            this.Close();
                        }
                        else
                        {
                            _showMessage.Show(
                                "Введенный Email уже используется",
                                "AutoService",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        _showMessage.Show(
                                "Не все поля заполнены",
                                "AutoService",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Information);
                    }

                }, (o) => CustomerCars.Count > 0));
            }
        }
    }
}
