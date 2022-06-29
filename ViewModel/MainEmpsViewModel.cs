using AutoService.Models;
using AutoService.ViewModel.Base;
using System;

namespace AutoService.ViewModel
{
    public class MainEmpsViewModel : BaseViewModel
    {
        private readonly Guid _empNoNameId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        private readonly MainWindowViewModel _vm;

        public MainEmpsViewModel(MainWindowViewModel vm)
        {
            this._vm = vm;

            Emps = _vm.UnitOfWork.EmployeeRepository.GetAllByCondition(c => c.Id != _empNoNameId);
        }

        public Employee[] Emps { get; }
    }
}