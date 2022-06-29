using AutoService.Models;
using AutoService.ViewModel.Base;
using AutoService.ViewModel.Command;
using AutoService.ViewModel.TransferObjects;
using System.Collections.ObjectModel;
using System.Linq;

namespace AutoService.ViewModel
{
    public class ServicesViewModel : BaseViewModel
    {
        private readonly MainAdminViewModel _vm;
        private RelayCommand _addCommand;
        private RelayCommand _changeCommand;
        private RelayCommand _deleteCommand;
        private ServiceObject _newService;
        private ServiceObject _selectedService;

        public ServicesViewModel(MainAdminViewModel vm)
        {
            this._vm = vm;

            Services = new ObservableCollection<ServiceObject>(_vm.UnitOfWork.ServiceRepository.GetAll().Select(s => new ServiceObject(s.Id, s.Name, s.Price)));

            NewService = new ServiceObject();
        }

        public ObservableCollection<ServiceObject> Services { get; set; }

        public ServiceObject SelectedService
        {
            get { return _selectedService; }
            set
            {
                _selectedService = value;
                OnPropertyChanged(nameof(SelectedService));
            }
        }
        public ServiceObject NewService
        {
            get { return _newService; }
            set
            {
                _newService = value;
                OnPropertyChanged(nameof(NewService));
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand((o) =>
                {
                    Service addService = new Service
                    {
                        Name = NewService.Name,
                        Price = decimal.Parse(NewService.Price)
                    };

                    _vm.UnitOfWork.ServiceRepository.Add(addService);

                    _vm.UnitOfWork.SaveChanges();

                    NewService.Id = addService.Id;

                    Services.Add(NewService);

                    NewService = new ServiceObject();

                }, (o) => !NewService.HasErrors));
            }
        }
        public RelayCommand ChangeCommand
        {
            get
            {
                return _changeCommand ?? (_changeCommand = new RelayCommand((o) =>
                {
                    if(!SelectedService.HasErrors)
                    {
                        var changeService = _vm.UnitOfWork.ServiceRepository.GetEntityByConditionOrDefault(s => s.Id == SelectedService.Id);

                        changeService.Name = SelectedService.Name;
                        changeService.Price = decimal.Parse(SelectedService.Price);

                        _vm.UnitOfWork.ServiceRepository.Update(changeService);

                        _vm.UnitOfWork.SaveChanges();

                        SelectedService = null;
                    }
                }));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand((o) =>
                {
                    var del = o as ServiceObject;

                    var delService = _vm.UnitOfWork.ServiceRepository.GetEntityByConditionOrDefault(s => s.Id == del.Id);

                    _vm.UnitOfWork.ServiceRepository.Delete(delService);

                    _vm.UnitOfWork.SaveChanges();

                    Services.Remove(del);

                    SelectedService = null;

                }));
            }
        }
    }
}