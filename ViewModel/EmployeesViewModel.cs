using AutoService.Models;
using AutoService.ViewModel.Base;
using AutoService.ViewModel.Command;
using AutoService.ViewModel.TransferObjects;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AutoService.ViewModel
{
    public class EmployeesViewModel : BaseViewModel
    {
        private readonly Guid _empNoNameId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        private readonly MainAdminViewModel _vm;
        private RelayCommand _addCommand;
        private RelayCommand _changeCommand;
        private RelayCommand _deleteCommand;
        private EmpObject _newEmp;
        private EmpObject _selectedEmp;

        public EmployeesViewModel(MainAdminViewModel vm)
        {
            this._vm = vm;

            Employees = new ObservableCollection<EmpObject>(
                _vm.UnitOfWork.EmployeeRepository
                .GetAllByCondition(c => c.Id != _empNoNameId).Select(e => new EmpObject(e.Id, e.Name, e.Surname, e.Experience)));

            NewEmp = new EmpObject();
        }
        public ObservableCollection<EmpObject> Employees { get; set; }

        public EmpObject SelectedEmp
        {
            get { return _selectedEmp; }
            set
            {
                _selectedEmp = value;
                OnPropertyChanged(nameof(SelectedEmp));
            }
        }
        public EmpObject NewEmp
        {
            get { return _newEmp; }
            set
            {
                _newEmp = value;
                OnPropertyChanged(nameof(NewEmp));
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand((o) =>
                {
                    Employee addEmp = new Employee
                    {
                        Id = NewEmp.Id,
                        Name = NewEmp.Name,
                        Surname = NewEmp.Surname,
                        Experience = int.Parse(NewEmp.Exp)
                    };

                    _vm.UnitOfWork.EmployeeRepository.Add(addEmp);

                    _vm.UnitOfWork.SaveChanges();

                    Employees.Add(NewEmp);

                    NewEmp = new EmpObject();

                }, (o) => !NewEmp.HasErrors));
            }
        }
        public RelayCommand ChangeCommand
        {
            get
            {
                return _changeCommand ?? (_changeCommand = new RelayCommand((o) =>
                {
                    if (!SelectedEmp.HasErrors)
                    {
                        var emp = _vm.UnitOfWork.EmployeeRepository.GetEntityByConditionOrDefault(e => e.Id == SelectedEmp.Id);

                        emp.Name = SelectedEmp.Name;
                        emp.Surname = SelectedEmp.Surname;
                        emp.Experience = int.Parse(SelectedEmp.Exp);

                        _vm.UnitOfWork.EmployeeRepository.Update(emp);

                        _vm.UnitOfWork.SaveChanges();

                        SelectedEmp = null;
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
                    var del = o as EmpObject;

                    var emp = _vm.UnitOfWork.EmployeeRepository.GetEntityByConditionOrDefault(e => e.Id == del.Id);

                    _vm.UnitOfWork.EmployeeRepository.Delete(emp);

                    _vm.UnitOfWork.SaveChanges();

                    Employees.Remove(del);

                    SelectedEmp = null;

                }));
            }
        }
    }
}