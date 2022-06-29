using AutoService.Models;
using AutoService.ViewModel.Base;
using AutoService.ViewModel.Command;
using AutoService.ViewModel.TransferObjects;
using System.Collections.ObjectModel;
using System.Linq;

namespace AutoService.ViewModel
{
    public class AdminCarsViewModel : BaseViewModel
    {
        private readonly MainAdminViewModel _vm;
        private RelayCommand _addProdCommand;
        private RelayCommand _changeProdCommand;
        private RelayCommand _deleteProdCommand;
        private RelayCommand _addModelCommand;
        private RelayCommand _changeModelCommand;
        private RelayCommand _deleteModelCommand;
        private ProducerObject _newProd;
        private ModelObject _newModel;
        private ProducerObject _selectedProducer;
        private ProducerObject _selectedProdModel;
        private ProducerObject _selectedProdChange;
        private ModelObject _selectedModel;
        private ModelType _selectedType;
        private ModelType _selectedChangeType;

        public AdminCarsViewModel(MainAdminViewModel vm)
        {
            this._vm = vm;
            Producers = new ObservableCollection<ProducerObject>(_vm.UnitOfWork
                .ProducerRepository
                .GetAll()
                .Select(s => new ProducerObject(s.Id, s.Name, s.Country)));
            Models = new ObservableCollection<ModelObject>(_vm.UnitOfWork
                .ModelRepository
                .GetAll()
                .Select(m => new ModelObject(m.Id, m.Name, m.Power, m.AccelerationSec, m.Producer, m.Type)));
            Types = _vm.UnitOfWork
                .ModelTypeRepository
                .GetAll();

            NewProd = new ProducerObject();
            NewModel = new ModelObject();
        }

        public ObservableCollection<ProducerObject> Producers { get; set; }
        public ObservableCollection<ModelObject> Models { get; set; }
        public ModelType[] Types { get; set; }
        public ProducerObject SelectedProducer
        {
            get { return _selectedProducer; }
            set
            {
                _selectedProducer = value;
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }
        public ModelType SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                NewModel.ModelType = _selectedType.Id;
                NewModel.ModelTypeName = _selectedType.Name;
                OnPropertyChanged(nameof(SelectedType));
            }
        }
        public ModelType SelectedChangeType
        {
            get { return _selectedChangeType; }
            set
            {
                _selectedChangeType = value;
                SelectedModel.ModelType = _selectedChangeType.Id;
                SelectedModel.ModelTypeName = _selectedChangeType.Name;
                OnPropertyChanged(nameof(SelectedChangeType));
            }
        }
        public ProducerObject SelectedProdModel
        {
            get { return _selectedProdModel; }
            set
            {
                _selectedProdModel = value;
                NewModel.ProducerId = _selectedProdModel.Id;
                NewModel.ProducerName = _selectedProdModel.Name;
                OnPropertyChanged(nameof(SelectedProdModel));
            }
        }
        public ProducerObject SelectedProdChange
        {
            get { return _selectedProdChange; }
            set
            {
                _selectedProdChange = value;
                SelectedModel.ProducerId = _selectedProdChange.Id;
                SelectedModel.ProducerName = _selectedProdChange.Name;
                OnPropertyChanged(nameof(SelectedProdChange));
            }
        }
        public ModelObject SelectedModel
        {
            get { return _selectedModel; }
            set
            {
                _selectedModel = value;
                if(_selectedModel != null)
                {
                    SelectedProdChange = Producers.FirstOrDefault(x => x.Id == _selectedModel.ProducerId);
                    SelectedChangeType = Types.FirstOrDefault(x => x.Id == _selectedModel.ModelType);
                }
                OnPropertyChanged(nameof(SelectedModel));
            }
        }
        public ProducerObject NewProd
        {
            get { return _newProd; }
            set
            {
                _newProd = value;
                OnPropertyChanged(nameof(NewProd));
            }
        }
            
        public ModelObject NewModel
        {
            get { return _newModel; }
            set
            {
                _newModel = value;
                OnPropertyChanged(nameof(NewModel));
            }
        }

        public RelayCommand AddProdCommand
        {
            get
            {
                return _addProdCommand ?? (_addProdCommand = new RelayCommand((o) =>
                {
                    Producer addProd = new Producer
                    {
                        Name = NewProd.Name,
                        Country = NewProd.Country
                    };

                    _vm.UnitOfWork.ProducerRepository.Add(addProd);

                    _vm.UnitOfWork.SaveChanges();

                    NewProd.Id = addProd.Id;

                    Producers.Add(NewProd);

                    NewProd = new ProducerObject();

                }, (o) => !NewProd.HasErrors));
            }
        }
        public RelayCommand ChangeProdCommand
        {
            get
            {
                return _changeProdCommand ?? (_changeProdCommand = new RelayCommand((o) =>
                {
                    if (!SelectedProducer.HasErrors)
                    {
                        var changeProd = _vm.UnitOfWork.ProducerRepository.GetEntityByConditionOrDefault(s => s.Id == SelectedProducer.Id);

                        changeProd.Name = SelectedProducer.Name;
                        changeProd.Country = SelectedProducer.Country;

                        _vm.UnitOfWork.ProducerRepository.Update(changeProd);

                        _vm.UnitOfWork.SaveChanges();

                        SelectedProducer = null;
                    }
                }));
            }
        }
        public RelayCommand DeleteProdCommand
        {
            get
            {
                return _deleteProdCommand ?? (_deleteProdCommand = new RelayCommand((o) =>
                {
                    var del = o as ProducerObject;

                    var delProd = _vm.UnitOfWork.ProducerRepository.GetEntityByConditionOrDefault(s => s.Id == del.Id);

                    _vm.UnitOfWork.ProducerRepository.Delete(delProd);

                    _vm.UnitOfWork.SaveChanges();

                    Producers.Remove(del);

                    SelectedProducer = null;

                }));
            }
        }
        public RelayCommand AddModelCommand
        {
            get
            {
                return _addModelCommand ?? (_addModelCommand = new RelayCommand((o) =>
                {
                    Model addModel = new Model
                    {
                        Name = NewModel.Name,
                        Power = double.Parse(NewModel.Power),
                        AccelerationSec = double.Parse(NewModel.AccelerationSec),
                        ModelTypeId = NewModel.ModelType,
                        ProducerId = NewModel.ProducerId
                    };

                    _vm.UnitOfWork.ModelRepository.Add(addModel);

                    _vm.UnitOfWork.SaveChanges();

                    NewModel.Id = addModel.Id;

                    Models.Add(NewModel);

                    NewModel = new ModelObject();

                }, (o) => !NewModel.HasErrors));
            }
        }
        public RelayCommand ChangeModelCommand
        {
            get
            {
                return _changeModelCommand ?? (_changeModelCommand = new RelayCommand((o) =>
                {
                    if (!SelectedModel.HasErrors)
                    {
                        var changeModel = _vm.UnitOfWork.ModelRepository.GetEntityByConditionOrDefault(s => s.Id == SelectedModel.Id);

                        changeModel.Name = SelectedModel.Name;
                        changeModel.Power = double.Parse(SelectedModel.Power);
                        changeModel.AccelerationSec = double.Parse(SelectedModel.AccelerationSec);
                        changeModel.ModelTypeId = SelectedModel.ModelType;
                        changeModel.ProducerId = SelectedModel.ProducerId;

                        _vm.UnitOfWork.ModelRepository.Update(changeModel);

                        _vm.UnitOfWork.SaveChanges();

                        SelectedModel = null;
                    }
                }));
            }
        }
        public RelayCommand DeleteModelCommand
        {
            get
            {
                return _deleteModelCommand ?? (_deleteModelCommand = new RelayCommand((o) =>
                {
                    var del = o as ModelObject;

                    var delModel = _vm.UnitOfWork.ModelRepository.GetEntityByConditionOrDefault(s => s.Id == del.Id);

                    _vm.UnitOfWork.ModelRepository.Delete(delModel);

                    _vm.UnitOfWork.SaveChanges();

                    Models.Remove(del);

                    SelectedModel = null;

                }));
            }
        }
    }
}