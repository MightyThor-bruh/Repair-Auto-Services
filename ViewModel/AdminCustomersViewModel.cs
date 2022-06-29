using AutoService.Models;
using AutoService.ViewModel.Base;

namespace AutoService.ViewModel
{
    public class AdminCustomersViewModel : BaseViewModel
    {
        private readonly MainAdminViewModel _vm;

        public AdminCustomersViewModel(MainAdminViewModel vm)
        {
            this._vm = vm;
            Customers = _vm.UnitOfWork.CustomerRepository.GetAll();
        }
        public Customer[] Customers { get; set; }
    }
}
